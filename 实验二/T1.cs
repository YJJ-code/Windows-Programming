/*using System;
namespace AlbumApplication
{
    class Photo
    {
        private string _title;
        public Photo(string title)
        {
            this._title = title;
        }
        public string Title
        {
            get
            {
                return _title;
            }
        }
    }
    class Album
    {
        private Photo[] photolist;
        static public int size = 5;
        public Album()
        {
            photolist = new Photo[size];
        }
        public Photo this[int index]
        {
            get
            {
                if (index >= 0 && index <= size - 1)
                {
                    return photolist[index];
                }
                else
                {
                    Console.WriteLine("索引非法");
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    photolist[index] = value;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Album album1 = new Album();
            album1[0] = new Photo("Photo1");
            album1[1] = new Photo("Photo2");
            album1[2] = new Photo("Photo3");
            album1[3] = new Photo("Photo4");
            album1[4] = new Photo("Photo5");
            for (int i = 0; i < Album.size; i++)
            {
                Console.WriteLine(album1[i].Title);
            }
        }
    }
}*/