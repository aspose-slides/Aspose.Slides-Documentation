---
title: 슬라이드에 주석 추가
type: docs
weight: 10
url: /ko/net/add-a-comment-to-a-slide/
---
## **OpenXML 프레젠테이션**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// 프레젠테이션 문서의 첫 번째 슬라이드에 주석을 추가합니다.

// 프레젠테이션 문서에는 최소한 하나의 슬라이드가 있어야 합니다.

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // CommentAuthorsPart 객체를 선언합니다.

    CommentAuthorsPart authorsPart;

    // 기존의 주석 작성자 파트가 있는지 확인합니다.

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // 없으면 새 파트를 추가합니다.

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // 주석 작성자 파트에 주석 작성자 목록이 있는지 확인합니다.

    if (authorsPart.CommentAuthorList == null)

    {

        // 없으면 새 파트를 추가합니다.

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // 새로운 작성자 ID를 선언합니다.

    uint authorId = 0;

    CommentAuthor author = null;

    // 주석 작성자 목록에 기존 자식 요소가 있으면...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // 전달된 작성자가 목록에 있는지 확인합니다.

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // 그렇다면...

        if (authors.Any())

        {

            // 새 주석 작성자에게 기존 작성자 ID를 할당합니다.

            author = authors.First();

            authorId = author.Id;

        }

        // 그렇지 않으면...

        if (author == null)

        {

            // 전달된 작성자에게 새 ID를 할당합니다

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // 주석 작성자 목록에 기존 자식 요소가 없을 경우.

    if (author == null)

    {

        authorId++;

        // 주석 작성자 목록에 새 자식 요소(작성자)를 추가합니다.

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // GetFirstSlide 메서드를 사용해 첫 번째 슬라이드를 가져옵니다.

    SlidePart slidePart1 = GetFirstSlide(doc);

    // comments 파트를 선언합니다.

    SlideCommentsPart commentsPart;

    // 첫 번째 슬라이드 파트에 comments 파트가 있는지 확인합니다.

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // 없으면 새 comments 파트를 추가합니다.

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // 그렇지 않으면 슬라이드 파트의 첫 번째 comments 파트를 사용합니다.

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // comment 리스트가 없으면.

    if (commentsPart.CommentList == null)

    {

        // 새 comments 리스트를 추가합니다.

        commentsPart.CommentList = new CommentList();

    }

    // 새 comment ID를 가져옵니다.

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // 새 comment를 추가합니다.

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // comment 요소에 position 자식 노드를 추가합니다.

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // comment 작성자 파트를 저장합니다.

    authorsPart.CommentAuthorList.Save();

    // comments 파트를 저장합니다.

    commentsPart.CommentList.Save();

}

}

// 프레젠테이션 문서의 첫 번째 슬라이드 파트를 가져옵니다.

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// 첫 번째 슬라이드의 관계 ID를 가져옵니다.

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// 관계 ID로 슬라이드 파트를 가져옵니다.

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}
``` 
## **Aspose.Slides**
.NET용 **Aspose.Slides**에서는 PPT 슬라이드 주석 컬렉션이 모든 **Slide** 클래스에 포함됩니다. **CommentCollection** 클래스는 특정 슬라이드 주석을 보관하는 데 사용됩니다. **Comment** 클래스에는 슬라이드 주석을 추가한 작성자, 그의 이니셜, 생성 시간, 슬라이드에서 주석의 위치 및 주석 텍스트와 같은 정보가 포함됩니다. **CommentAuthor** 클래스는 프레젠테이션 수준에서 슬라이드 주석 작성자를 추가하는 데 사용됩니다. **Presentation** 클래스는 **CommentAuthors** 클래스에서 프레젠테이션용 작성자 컬렉션을 보관합니다.

다음 예제에서는 슬라이드 주석을 추가하기 위한 코드 스니펫을 추가했습니다.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    // 빈 슬라이드 추가

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    // 작성자 추가

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    // 주석 위치

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    // 슬라이드에 작성자의 슬라이드 주석 추가

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide/)