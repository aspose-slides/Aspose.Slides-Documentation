---
title: .NET에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/net/presentation-comments/
keywords:
- 주석
- 최신 주석
- PowerPoint 주석
- 프레젠테이션 주석
- 슬라이드 주석
- 주석 추가
- 주석 접근
- 주석 편집
- 주석 회신
- 주석 제거
- 주석 삭제
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용해 프레젠테이션 주석을 관리합니다: PowerPoint 프레젠테이션에서 주석을 빠르고 쉽게 추가, 읽기, 편집, 회신 및 제거합니다."
---
## **개요**

이 문서는 Aspose.Slides for .NET을 사용하여 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 형식을 소개하고 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 회신 및 최신 주석을 처리하며, 프레젠테이션에서 주석을 제거하는 방법을 시연합니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오(작성자에게 주석 할당, 주석 텍스트와 메타데이터 읽기, 회신 체인 구축, 선택된 주석 또는 모든 주석 제거)를 다룹니다.

PowerPoint에서 주석은 슬라이드에 표시되는 주석입니다. 주석을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 주석을 표시하거나 숨기고 싶지만 주석 자체는 변경하지 않으려면 [Show or Hide Comments When Opening a Presentation](/slides/ko/net/presentation-view-properties/)를 참조하세요.

## **왜 프레젠테이션에 주석을 추가하나요?**

프레젠테이션 검토 시 피드백을 제공하고 동료와 협업하기 위해 주석을 사용할 수 있습니다.

Aspose.Slides for .NET은 주석 작업을 위한 다음 API를 제공합니다:

* [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 클래스는 프레젠테이션의 주석 작성자에 대한 액세스를 제공합니다.
* [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) 인터페이스는 개별 작성자와 연결된 주석을 나타냅니다.
* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 인터페이스는 주석의 작성자, 생성 시간, 위치 및 텍스트 등 정보를 제공합니다.
* [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) 클래스는 이름, 이니셜 및 연결된 주석을 포함한 작성자 정보를 제공합니다.

## **슬라이드 주석 추가**

예제는 두 개의 슬라이드를 만든 다음 [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/)로 주석 작성자를 등록합니다. [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/)을 사용해 각 슬라이드에 하나씩 주석을 배치한 뒤, [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/)로 해당 작성자의 첫 번째 슬라이드 주석을 가져옵니다. 콘솔은 첫 번째 주석 텍스트를 두 번 표시하여 슬라이드와 작성자 모두를 통해 접근함을 보여 주며, 저장된 프레젠테이션에는 두 주석이 모두 포함됩니다.

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

## **주석 작성자 찾기 또는 만들기**

자동 검토가 동일한 프레젠테이션을 반복해서 처리할 때는 작성자를 추가하기 전에 [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) 컬렉션을 검색합니다. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/)는 이름과 이니셜을 모두 일치시키며 일치하는 작성자 배열을 반환하고, 일치하는 항목이 없으면 빈 배열을 반환합니다. 반면 [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/)은 이니셜과 무관하게 이름만으로 검색합니다. 이미 컬렉션에 존재하는 이름과 이니셜으로 [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/)를 호출하면 예외가 발생합니다.

예제는 최소 하나의 슬라이드가 있는 프레젠테이션 파일이 필요합니다. 두 번의 패스 각각에서 첫 번째 일치하는 작성자를 재사용하거나 결과가 비어 있을 때만 새로 만들고, 일치하는 작성자가 여러 개 있으면 다른 작성자를 병합하거나 제거하지 않고 첫 번째 배열 요소를 선택합니다. 그런 다음 선택된 작성자에 대해 [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/)를 호출하고 프레젠테이션을 저장합니다. 두 번째 패스는 첫 번째 패스의 출력 파일을 열어 동일 작업을 반복합니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

두 번째 패스는 또 다른 주석을 추가하지만 추가 작성자를 만들거나 기존 주석을 제거하지는 않습니다. 최종 파일 `review_pass_2.pptx`에는 원래 주석과 함께 두 개의 새 주석이 모두 포함됩니다. 작성자를 재사용해도 주석이 중복 제거되지 않으므로, 동일 주석을 반복해서 추가하지 않도록 별도의 중복 감지를 구현해야 합니다.

## **슬라이드 주석 접근**

예제는 기존 프레젠테이션을 열고 [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) 컬렉션을 읽습니다. 각 작성자에 대해 [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/)를 순회하면서 슬라이드 번호, 주석 텍스트, 작성자 이름 및 생성 시간을 출력합니다. 입력 프레젠테이션에 주석이 포함되어 있어야 콘솔 출력이 생성됩니다.

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

## **주석에 회신 달기**

부모 주석은 회신 계층 구조의 최상위 원본 주석입니다. [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 인터페이스의 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) 속성을 통해 주석의 부모를 가져오거나 설정할 수 있습니다.

예제는 두 명의 작성자에 대해 주석을 만든 다음 [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/)를 사용해 회신을 구축하고, 회신에 대한 회신까지 포함합니다. `null`을 [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/)에 전달하면 모든 작성자의 주석을 가져옵니다; 콘솔은 회신 계층 깊이에 따라 각 항목을 들여쓰기합니다. 예제는 전체 토론을 저장하고, 첫 번째 루트 주석에 대해 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/)를 호출한 뒤, 해당 주석과 회신이 제거된 두 번째 프레젠테이션을 저장합니다.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

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

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
* [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) 인터페이스의 [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) 메서드를 사용해 주석을 삭제하면 해당 주석에 대한 모든 회신도 함께 삭제됩니다.
* [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) 속성이 순환 참조를 생성하면 [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)이 발생합니다.
{{% /alert %}}

## **최신 주석 추가**

최신 주석은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위에 연결될 수 있습니다. [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) 메서드는 슬라이드와 주석 마커 좌표 외에 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 매개변수를 받습니다.

`null`을 shape 인수로 전달하면 주석은 슬라이드 수준 주석이 됩니다. 마커는 제공된 좌표로 배치되지만 특정 도형에 연결되지 않으므로 [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/)은 `null`을 반환합니다. [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)가 제공되면 주석은 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 마커 위치를 정의하고, 도형 연결은 [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/)를 통해 확인할 수 있습니다.

### **도형에 최신 주석 고정**

예제는 [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/)를 두 번 호출합니다. 첫 번째는 슬라이드 수준 주석을 위해 `null` shape를 사용하고, 두 번째는 사각형을 고정점으로 사용합니다. [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/)을 읽으면 슬라이드 수준 주석의 null 체크에서 `True`가, 고정된 주석에서는 `Revenue title`이 출력됩니다. 두 주석 모두 프레젠테이션에 저장됩니다.

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

### **다양한 도형 유형에 주석 고정**

[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)을 구현하는 모든 슬라이드 개체를 도형 고정점으로 사용할 수 있습니다. 일반적인 예로는 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), 그리고 차트와 같은 [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) 인스턴스가 있습니다.

예제는 [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/)을 사용해 AutoShape, 그림 프레임, 그룹, 연결선, 차트 등 다섯 가지 도형 유형 각각에 주석을 연결합니다. 그림은 임베드된 이미지 데이터를 사용하므로 외부 이미지가 필요하지 않습니다. 각 주석은 자체 마커 위치를 갖고, 저장된 프레젠테이션은 다섯 도형 연결을 모두 보존합니다.

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

### **텍스트에 주석 고정 및 상태 설정**

[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)에 연결된 최신 주석의 경우, [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/)는 도형 텍스트 프레임 내 선택된 텍스트의 시작 위치를 지정하고, [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/)는 선택 길이를 지정합니다. 이 두 속성을 함께 사용하면 AutoShape 내부의 특정 텍스트 범위에 주석을 연결할 수 있습니다.

[IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) 속성은 [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) 열거형 값으로 읽거나 업데이트할 수 있습니다:

- `NotDefined` — 특정 최신 주석 상태가 정의되지 않음.
- `Active` — 주석이 활성 상태.
- `Resolved` — 주석이 해결됨.
- `Closed` — 주석이 닫힘.

예제는 사각형 텍스트의 "quarterly revenue" 단어에 최신 주석을 고정합니다. 텍스트에서 zero‑based [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/)를 계산하고, 선택된 문자 수만큼 [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/)를 설정합니다. [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/)를 `Resolved`로 설정한 뒤 프레젠테이션을 저장하고 다시 엽니다. 네 개의 콘솔 검사는 각각 `True`를 출력하여 도형 고정, 텍스트 범위 및 상태가 보존되었음을 확인합니다.

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

### **기존 최신 주석 검사**

예제는 최신 주석이 포함된 기존 프레젠테이션을 요구하고, 각 주석의 텍스트, 상태 및 고정 세부 정보를 출력합니다. 이를 검사하려면 주석이 [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/)를 구현하는지 확인한 뒤, [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/), [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/)를 조사합니다. `null` shape는 슬라이드 수준 주석을 나타냅니다. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 고정인 경우 텍스트 선택 속성이 도형 텍스트 프레임 내 연결된 범위를 식별합니다.

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

## **주석 제거**

Aspose.Slides for .NET을 사용하면 프레젠테이션에서 모든 주석 및 작성자를 제거하거나 일부 주석만 삭제하면서 나머지는 유지할 수 있습니다. 다음 예제는 두 접근 방식을 시연하고 업데이트된 프레젠테이션을 저장합니다.

### **모든 주석 및 주석 작성자 제거**

예제는 기존 프레젠테이션을 열고 각 작성자에 대해 [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/)를 호출한 뒤, [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/)를 호출해 작성자를 자체적으로 제거합니다. 저장된 프레젠테이션에는 주석도 작성자도 포함되지 않습니다. 주석이 포함된 프레젠테이션을 사용해 제거 효과를 확인하십시오.

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

### **특정 주석 제거**

예제는 하나의 슬라이드에 두 개의 주석을 만든 뒤 [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/)을 사용해 각 작성자의 주석을 찾습니다. 텍스트가 "comment 1"인 주석을 수집한 뒤 [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/)를 호출하여 선택 중 컬렉션이 변경되는 것을 방지합니다. 저장된 프레젠테이션에는 "comment 2"만 남습니다.

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

**Aspose.Slides에서 최신 주석에 대한 해결 상태를 지원하나요?**

예. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/)는 [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) 값으로 읽고 설정할 수 있으며, 여기에는 `Resolved`가 포함됩니다. 상태는 프레젠테이션에 저장되고 파일을 다시 연 후에도 읽을 수 있습니다.

**스레드형 토론(회신 체인)이 지원되며 중첩 제한이 있나요?**

예. 각 주석은 [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/)을 참조할 수 있어 회신 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 정의하지 않습니다.

**주석 마커의 위치는 슬라이드의 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 슬라이드에서 정확히 원하는 위치에 배치할 수 있습니다.