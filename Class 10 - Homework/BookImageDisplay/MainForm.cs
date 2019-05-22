using BooksProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookImageDisplay
{
    public partial class MainForm : Form
    {
        private IEnumerable<Author> authors;

        private PictureBox pictureBox = new PictureBox();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BooksLoader loader = new BooksLoader();
            authors = loader.GetAllAuthors();
            LbxAuthors.DataSource = authors;
            LbxAuthors.DisplayMember = "Name";

            pictureBox.Location = new Point(756, 12);
            pictureBox.Size = new Size(874, 330);
            pictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            Controls.Add(pictureBox);
        }

        private void LbxAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Author author = LbxAuthors.SelectedItem as Author;
            LbxBooks.DataSource = author.Books;
            LbxBooks.DisplayMember = "Title";
        }

        private void LbxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

            var author = LbxAuthors.SelectedItem as Author;
            var book = LbxBooks.SelectedItem as Book;
            var authorInitials = "";
            var bookName = string.Join("", book.Title.Split(' '));
            var imageName = "";

            bookName = bookName.Substring(0, Math.Min(8, bookName.Length));

            #region BooksWithTwoAuthors
            var booksWithTwoAuthors = authors
                .SelectMany(a => a.Books)
                .GroupBy(b => b.Title)
                .Where(g => g.Count() == 2)
                .Select(g => new
                {
                    booktitle = g.Key
                }).Distinct();

            var namesAndTitles = authors.Select(a => new
            {
                a.Name,
                BooksTitles = a.Books.Select(b => b.Title)
            });

            var authorsNames = namesAndTitles.Select(n => new
            {
                Authors = namesAndTitles.Where(w => w.BooksTitles.Contains(book.Title)).Select(a => new { a.Name })
            }).Distinct().First().Authors;

            #endregion

            if (booksWithTwoAuthors.Where(b => b.booktitle == book.Title).Count() == 0)
            {

                authorInitials = string.Join("", author.Name.Split(' ').Select(p => p[0])).ToString();

                imageName = $"http://www.worldswithoutend.com/covers_ml/{authorInitials}_{bookName}.jpg";

            }
            else
            {
                foreach (var nameOfAuthor in authorsNames)
                {
                    authorInitials += string.Join("", nameOfAuthor.Name.Split(' ').Select(p => p[0])).ToString();
                }
                imageName = $"http://www.worldswithoutend.com/covers_ml/{authorInitials}-{bookName}.jpg";
            }
            
            try
            {
                pictureBox.Load(imageName);
            }
            catch (WebException wex)
            {
                var response = wex.Response as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.NotFound)
                {                 
                    pictureBox.Load("https://via.placeholder.com/145x225.png?text=No+image+found");
                }
                else
                {
                    throw;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Png Image|*.png|Bmp Image|*.bmp|Jpg Image|*.jpg|Jpeg Image|*jpeg;|Png Image|*png|Gif|*gif";
            ImageFormat format = ImageFormat.Jpeg;
            if (f.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(f.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    case ".gif":
                        format = ImageFormat.Gif;
                        break;
                }
                pictureBox.Image.Save(f.FileName, format);
            }
        }

        private void lnkNovelPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var book = LbxBooks.SelectedItem as Book;
            var url = $"http://www.worldswithoutend.com/novel.asp?ID={book.ID}";
            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }
    }
}
