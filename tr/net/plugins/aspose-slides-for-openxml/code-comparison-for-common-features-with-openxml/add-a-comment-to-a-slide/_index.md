---
title: Bir slayta yorum ekle
type: docs
weight: 10
url: /tr/net/add-a-comment-to-a-slide/
---
## **OpenXML Sunumu**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Sunum belgesinin ilk slaytına bir yorum ekler.

// Sunum belgesi en az bir slayt içermelidir.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Bir CommentAuthorsPart nesnesi bildir.

    CommentAuthorsPart authorsPart;

    // Var olan bir yorum yazarları bölümünün olup olmadığını doğrula.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Yoksa, yeni bir tane ekle.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Yorum yazarları bölümünde bir yorum yazar listesi olup olmadığını doğrula.

    if (authorsPart.CommentAuthorList == null)

    {

        // Yoksa, yeni bir tane ekle.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Yeni bir yazar kimliği bildir.

    uint authorId = 0;

    CommentAuthor author = null;

    // Yorum yazarları listesinde mevcut alt öğeler varsa...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Sağlanan yazarın listede olup olmadığını doğrula.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Eğer varsa...

        if (authors.Any())

        {

            // Yeni yorum yazarına mevcut yazar kimliğini ata.

            author = authors.First();

            authorId = author.Id;

        }

        // Eğer yoksa...

        if (author == null)

        {

            // Sağlanan yazara yeni bir kimlik ata

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Yorum yazarları listesinde mevcut alt öğe yoksa.

    if (author == null)

    {

        authorId++;

        // Yorum yazar listesine yeni bir alt öğe (yorum yazarı) ekle.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // GetFirstSlide yöntemini kullanarak ilk slaytı al.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Bir yorumlar bölümü bildir.

    SlideCommentsPart commentsPart;

    // İlk slayt bölümünde bir yorumlar bölümü olup olmadığını doğrula.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Yoksa, yeni bir yorumlar bölümü ekle.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Aksi takdirde, slayt bölümündeki ilk yorumlar bölümünü kullan.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Yorum listesi yoksa.

    if (commentsPart.CommentList == null)

    {

        // Yeni bir yorum listesi ekle.

        commentsPart.CommentList = new CommentList();

    }

    // Yeni yorum kimliğini al.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Yeni bir yorum ekle.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Yorum elemanına pozisyon alt düğümünü ekle.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Yorum yazarları bölümünü kaydet.

    authorsPart.CommentAuthorList.Save();

    // Yorumlar bölümünü kaydet.

    commentsPart.CommentList.Save();

}

}

// Sunum belgesindeki ilk slaytın slayt bölümünü al.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// İlk slaytın ilişki kimliğini al

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// İlişki kimliğiyle slayt bölümünü al.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
**Aspose.Slides** for .NET'te, PPT slayt yorum koleksiyonu her **Slide** sınıfına dahil edilmiştir. **CommentCollection** sınıfı, belirli slayt yorumlarını tutmak için kullanılır. **Comment** sınıfı, slayt yorumunu ekleyen yazar, yazarın baş harfleri, oluşturulma zamanı, slayttaki yorumun konumu ve yorum metni gibi bilgileri içerir. **CommentAuthor** sınıfı, sunum seviyesinde slayt yorumları için yazarları eklemek amacıyla kullanılır. **Presentation** sınıfı, **CommentAuthors** sınıfında sunum için yazar koleksiyonunu tutar.

Aşağıdaki örnekte, slayt yorumlarını eklemek için kod parçacığını ekledik.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    // Boş slayt ekleniyor

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    // Yazar ekleniyor

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    // Yorumların konumu

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    // Bir yazar için slayta yorum ekleniyor

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)