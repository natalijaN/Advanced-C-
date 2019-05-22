using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Story
    {
        public string Title { get; set; }       
        public Type StoryType { get; set; }
        public bool IsOriginal { get; set; }

        public Story(string title, Type storyType, bool isOriginal)
        {
            Title = title;
            StoryType = storyType;
            IsOriginal = isOriginal;
        }

    }
    public enum Type
    {
        Novellette,
        Novella,
        ShortStory
    }
}
