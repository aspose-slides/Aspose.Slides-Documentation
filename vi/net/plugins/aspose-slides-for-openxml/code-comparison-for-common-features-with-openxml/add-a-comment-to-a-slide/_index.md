---
title: Thêm bình luận vào một slide
type: docs
weight: 10
url: /vi/net/add-a-comment-to-a-slide/
---
## **Bản trình bày OpenXML**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// Thêm một bình luận vào slide đầu tiên của tài liệu trình chiếu.

// Tài liệu trình chiếu phải chứa ít nhất một slide.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // Khai báo một đối tượng CommentAuthorsPart.

    CommentAuthorsPart authorsPart;

    // Kiểm tra xem phần tác giả bình luận đã tồn tại chưa.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // Nếu không, thêm một phần mới.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // Kiểm tra xem có danh sách tác giả bình luận trong phần tác giả bình luận không.

    if (authorsPart.CommentAuthorList == null)

    {

        // Nếu không, thêm một phần mới.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // Khai báo một ID tác giả mới.

    uint authorId = 0;

    CommentAuthor author = null;

    // Nếu có các phần tử con tồn tại trong danh sách tác giả bình luận...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // Kiểm tra xem tác giả được truyền vào có nằm trong danh sách không.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // Nếu có...

        if (authors.Any())

        {

            // Gán ID tác giả hiện có cho tác giả bình luận mới.

            author = authors.First();

            authorId = author.Id;

        }

        // Nếu không...

        if (author == null)

        {

            // Gán một ID mới cho tác giả được truyền vào

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // Nếu không có phần tử con nào tồn tại trong danh sách tác giả bình luận.

    if (author == null)

    {

        authorId++;

        // Thêm một phần tử con mới (tác giả bình luận) vào danh sách tác giả bình luận.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // Lấy slide đầu tiên, bằng phương thức GetFirstSlide.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // Khai báo một phần bình luận.

    SlideCommentsPart commentsPart;

    // Kiểm tra xem có phần bình luận trong phần slide đầu tiên không.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // Nếu không, thêm một phần bình luận mới.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // Nếu có, sử dụng phần bình luận đầu tiên trong phần slide.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // Nếu danh sách bình luận không tồn tại.

    if (commentsPart.CommentList == null)

    {

        // Thêm một danh sách bình luận mới.

        commentsPart.CommentList = new CommentList();

    }

    // Lấy ID bình luận mới.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // Thêm một bình luận mới.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // Thêm nút con vị trí vào phần tử bình luận.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // Lưu phần tác giả bình luận.

    authorsPart.CommentAuthorList.Save();

    // Lưu phần bình luận.

    commentsPart.CommentList.Save();

}

}

// Lấy phần slide của slide đầu tiên trong tài liệu trình chiếu.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// Lấy ID quan hệ của slide đầu tiên

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// Lấy phần slide bằng ID quan hệ.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
Trong **Aspose.Slides** cho .NET, bộ sưu tập bình luận slide PPT được bao gồm trong mỗi lớp **Slide**. Lớp **CommentCollection** được sử dụng để chứa các bình luận slide cụ thể. Lớp **Comment** bao gồm các thông tin như tác giả đã thêm bình luận slide, chữ ký của họ, thời gian tạo, vị trí của bình luận trên slide và nội dung bình luận. Lớp **CommentAuthor** được sử dụng để thêm các tác giả cho bình luận slide ở mức trình bày. Lớp **Presentation** giữ bộ sưu tập các tác giả cho trình bày trong lớp **CommentAuthors**.

Trong ví dụ sau, chúng tôi đã thêm đoạn mã để thêm các bình luận slide.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //Thêm slide trống

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //Thêm tác giả

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //Vị trí của bình luận

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //Thêm bình luận slide cho một tác giả trên slide

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)