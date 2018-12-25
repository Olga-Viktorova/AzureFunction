using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTriger
{
    public class DocumentModel
    {
        public int DocumentNode { get; set; }
        public short DocumentLevel { get; set; }
        public string Title { get; set; }
        public int Owner { get; set; }
        public bool FolderFlag { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Revision { get; set; }
        public int ChangeNumber { get; set; }
        public short Status { get; set; }
        public byte[] Document { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        
        //public ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
    }

}
