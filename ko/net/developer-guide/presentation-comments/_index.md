---
title: .NET에서 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/net/presentation-comments/
keywords:
- 댓글
- 최신 댓글
- PowerPoint 댓글
- 프레젠테이션 댓글
- 슬라이드 댓글
- 댓글 추가
- 댓글 접근
- 댓글 편집
- 댓글 답글
- 댓글 제거
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 프레젠테이션 댓글을 관리합니다: PowerPoint 프레젠테이션에서 댓글을 빠르고 쉽게 추가, 읽기, 편집, 답글 달기 및 제거합니다."
---
## **개요**

이 문서는 Aspose.Slides for .NET을 사용하여 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 유형을 소개하고 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하고, 답글 및 최신 댓글을 다루며, 프레젠테이션에서 댓글을 제거하는 방법을 보여줍니다.

예제에서는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다룹니다. 예를 들어, 댓글을 작성자에게 할당하고, 댓글 텍스트 및 메타데이터를 읽으며, 답글 체인을 구축하고, 선택된 댓글 또는 모든 댓글을 제거하는 방법 등을 포함합니다.

PowerPoint에서 댓글은 슬라이드에 주석 형태로 표시됩니다. 댓글을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

## **프레젠테이션에 댓글을 추가하는 이유**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 댓글을 사용할 수 있습니다.

Aspose.Slides for .NET은 댓글 작업을 위한 다음 API를 제공합니다:

* The [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스는 프레젠테이션의 댓글 작성자에 대한 액세스를 제공합니다.
* The [ICommentCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/icommentcollection) 인터페이스는 개별 작성자와 연결된 댓글을 나타냅니다.
* The [IComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment) 인터페이스는 댓글에 대한 정보를 제공하며, 여기에는 작성자, 생성 시간, 위치 및 텍스트가 포함됩니다.
* The [CommentAuthor](https://reference.aspose.com/slides/ko/net/aspose.slides/commentauthor) 클래스는 작성자에 대한 정보를 제공하며, 여기에는 이름, 이니셜 및 연관된 댓글이 포함됩니다.

## **슬라이드 댓글 추가**

다음 예제는 PowerPoint 프레젠테이션에서 슬라이드에 댓글을 추가하는 방법을 보여줍니다:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **슬라이드 댓글 접근**

다음 예제는 PowerPoint 프레젠테이션에서 기존 댓글에 접근하는 방법을 보여줍니다:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **댓글에 답글 달기**

부모 댓글은 답글 계층 구조의 최상위에 있는 원본 댓글입니다. [IComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment) 인터페이스의 [ParentComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment/properties/parentcomment) 속성을 사용하면 댓글의 부모를 가져오거나 설정할 수 있습니다.

다음 예제는 답글을 추가하고 결과 댓글 계층 구조를 검사하는 방법을 보여줍니다:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* [IComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment) 인터페이스의 [Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment/methods/remove) 메서드를 사용하여 댓글을 삭제하면 해당 댓글에 대한 모든 답글도 함께 삭제됩니다.
* [ParentComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment/properties/parentcomment) 속성이 순환 참조를 만들 경우, [PptxEditException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxeditexception) 예외가 발생합니다.

{{% /alert %}}

## **최신 댓글 추가**

최신 댓글은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위와 연결될 수 있습니다. [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icommentcollection/addmoderncomment/) 메서드는 슬라이드와 댓글 마커 좌표 외에도 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/) 인수를 받아들입니다.

`null`이 shape 인수로 전달되면 댓글은 슬라이드 수준 댓글이 됩니다. 마커는 제공된 좌표에 따라 배치되지만 특정 도형과 연관되지 않으므로 [IModernComment.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/shape/)은 `null`을 반환합니다. [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/)이 제공되면 댓글이 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드에서 댓글 마커의 위치를 정의하며, 도형 연관성은 [IModernComment.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/shape/)을 통해 가져올 수 있습니다.

### **도형에 최신 댓글 고정**

다음 예제는 슬라이드 수준 최신 댓글과 특정 AutoShape에 고정된 최신 댓글을 모두 생성합니다. 그런 다음 각 댓글에서 연관된 도형을 읽어옵니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **다양한 도형 유형에 댓글 고정**

[IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/)을 구현하는 모든 슬라이드 개체를 도형 고정점으로 사용할 수 있습니다. 일반적인 예로는 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/ko/net/aspose.slides/iconnector/) 및 차트와 같은 [IGraphicalObject](https://reference.aspose.com/slides/ko/net/aspose.slides/igraphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반 도형 유형을 생성하고 각 도형에 최신 댓글을 연결합니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";
var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **텍스트에 댓글 고정 및 상태 설정**

[IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)와 연관된 최신 댓글의 경우, [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/textselectionstart/)은 도형의 텍스트 프레임에서 선택된 텍스트의 시작 위치를 지정하고, [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/textselectionlength/)은 선택 범위의 길이를 지정합니다. 이 두 속성을 함께 사용하면 댓글을 AutoShape 내부의 특정 텍스트 범위와 연관시킬 수 있습니다.

[IModernComment.Status](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/status/) 속성은 [ModernCommentStatus](https://reference.aspose.com/slides/ko/net/aspose.slides/moderncommentstatus/) 열거형 값으로 읽거나 업데이트할 수 있습니다:

- `NotDefined` — 특정 최신 댓글 상태가 정의되지 않음.
- `Active` — 댓글이 활성 상태임.
- `Resolved` — 댓글이 해결됨.
- `Closed` — 댓글이 닫힘.

다음 예제는 도형에 고정된 최신 댓글을 생성하고, 텍스트 선택과 연결하며, 해결된 상태로 표시하고, 프레젠테이션을 저장한 뒤 파일을 다시 열었을 때 값을 확인합니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **기존 최신 댓글 검사**

기존 프레젠테이션을 검사하려면 어떤 댓글이 [IModernComment](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/)를 구현하는지 확인한 다음, [IModernComment.Shape](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/textselectionlength/), 및 [IModernComment.Status](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/status/)를 살펴봅니다. `null` 도형은 슬라이드 수준 댓글임을 나타냅니다. [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)에 고정된 경우, 텍스트 선택 속성은 도형의 텍스트 프레임에서 연관된 범위를 식별합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **댓글 제거**

### **모든 댓글 및 댓글 작성자 제거**

다음 예제는 프레젠테이션에서 모든 댓글 및 댓글 작성자를 제거하는 방법을 보여줍니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();
presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **특정 댓글 제거**

다음 예제는 슬라이드에서 특정 댓글을 제거하는 방법을 보여줍니다:

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides에서 최신 댓글에 대한 해결 상태를 지원합니까?**

예. [IModernComment.Status](https://reference.aspose.com/slides/ko/net/aspose.slides/imoderncomment/status/)은 [ModernCommentStatus](https://reference.aspose.com/slides/ko/net/aspose.slides/moderncommentstatus/) 값으로 읽고 설정할 수 있으며, 여기에는 `Resolved`도 포함됩니다. 상태는 프레젠테이션에 저장되며 파일을 다시 연 후에도 다시 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며, 중첩 제한이 있나요?**

예. 각 댓글은 자신의 [parent comment](https://reference.aspose.com/slides/ko/net/aspose.slides/comment/parentcomment/)을 참조할 수 있어 답글 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 정의하지 않습니다.

**슬라이드에서 댓글 마커의 위치는 어떤 좌표계로 정의됩니까?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 이를 통해 슬라이드에 정확히 배치할 수 있습니다.