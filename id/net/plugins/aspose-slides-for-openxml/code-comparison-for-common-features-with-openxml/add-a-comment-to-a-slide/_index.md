---
title: Menambahkan komentar ke slide
type: docs
weight: 10
url: /id/net/add-a-comment-to-a-slide/
---
## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Menambahkan komentar ke slide pertama dari dokumen presentasi.

// Dokumen presentasi harus berisi setidaknya satu slide.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Mendeklarasikan objek CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Memverifikasi bahwa ada bagian penulis komentar yang sudah ada.

    // Jika tidak, tambahkan yang baru.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Jika tidak, tambahkan yang baru.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Memverifikasi bahwa ada daftar penulis komentar dalam bagian penulis komentar.

    // Jika tidak, tambahkan yang baru.

    if (authorsPart.CommentAuthorList == null)

    {

        // Jika tidak, tambahkan yang baru.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Mendeklarasikan ID penulis baru.

    uint authorId = 0;

    CommentAuthor author = null;

    // Jika ada elemen anak yang ada dalam daftar penulis komentar...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Memverifikasi bahwa penulis yang diberikan ada dalam daftar.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Jika ya...

        if (authors.Any())

        {

            // Menetapkan ID penulis yang ada kepada penulis komentar baru.

            author = authors.First();

            authorId = author.Id;

        }

        // Jika tidak...

        if (author == null)

        {

            // Menetapkan ID baru kepada penulis yang diberikan

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Jika tidak ada elemen anak yang ada dalam daftar penulis komentar.

    if (author == null)

    {

        authorId++;

        // Tambahkan elemen anak baru (penulis komentar) ke daftar penulis komentar.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Dapatkan slide pertama, menggunakan metode GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Mendeklarasikan bagian komentar.

    SlideCommentsPart commentsPart;

    // Memverifikasi bahwa ada bagian komentar dalam bagian slide pertama.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Jika tidak, tambahkan bagian komentar baru.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Jika tidak, gunakan bagian komentar pertama dalam bagian slide.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Jika daftar komentar tidak ada.

    if (commentsPart.CommentList == null)

    {

        // Tambahkan daftar komentar baru.

        commentsPart.CommentList = new CommentList();

    }

    // Dapatkan ID komentar baru.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Tambahkan komentar baru.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Tambahkan node anak posisi ke elemen komentar.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Simpan bagian penulis komentar.

    authorsPart.CommentAuthorList.Save();

    // Simpan bagian komentar.

    commentsPart.CommentList.Save();

}

}

// Dapatkan ID hubungan slide pertama

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Dapatkan hubungan ID slide pertama

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Dapatkan bagian slide berdasarkan ID hubungan.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}
``` 
## **Aspose.Slides**
Di **Aspose.Slides** untuk .NET, koleksi komentar slide PPT disertakan dalam setiap kelas **Slide**. Kelas **CommentCollection** digunakan untuk menyimpan komentar slide tertentu. Kelas **Comment** berisi informasi seperti penulis yang menambahkan komentar slide, inisialnya, waktu pembuatan, posisi komentar slide pada slide, dan teks komentar. Kelas **CommentAuthor** digunakan untuk menambahkan penulis komentar slide pada tingkat presentasi. Kelas **Presentation** menyimpan koleksi penulis untuk presentasi dalam kelas **CommentAuthors**.

Dalam contoh berikut, kami telah menambahkan potongan kode untuk menambahkan komentar slide.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Menambahkan slide kosong

    //Menambahkan Penulis

    //Posisi komentar

    //Menambahkan komentar slide untuk penulis pada slide

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Position of comments

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Adding slide comment for an author on slide

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)