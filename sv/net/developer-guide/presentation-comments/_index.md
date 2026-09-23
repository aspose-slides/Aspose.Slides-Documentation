---
title: Hantera presentationskommentarer i .NET
linktitle: Presentationskommentarer
type: docs
weight: 100
url: /sv/net/presentation-comments/
keywords:
- kommentar
- modern kommentar
- PowerPoint-kommentarer
- presentationskommentarer
- bildkommentarer
- lägg till kommentar
- åtkomst till kommentar
- redigera kommentar
- svara på kommentar
- ta bort kommentar
- radera kommentar
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera presentationskommentarer med Aspose.Slides för .NET: lägg till, läs, redigera, svara på och ta bort kommentarer i PowerPoint-presentationer snabbt och enkelt."
---
## **Översikt**

Den här artikeln förklarar hur du hanterar presentationskommentarer med Aspose.Slides för .NET. Den introducerar de viktigaste kommentarrelaterade typerna och demonstrerar hur du lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga granskning‑ och samarbetsscenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentartext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som anmärkningar på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

För att begära att kommentarer ska visas eller döljas när en presentation öppnas utan att ändra själva kommentarerna, se [Visa eller dölj kommentarer när en presentation öppnas](/slides/sv/net/presentation-view-properties/).

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge feedback och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för .NET tillhandahåller följande API:er för att arbeta med kommentarer:

* Klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) som ger åtkomst till presentationens kommentar‑författare.
* Gränssnittet [ICommentCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/icommentcollection) som representerar kommentarerna som är kopplade till en enskild författare.
* Gränssnittet [IComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment) som ger information om en kommentar, inklusive dess författare, skapningstid, position och text.
* Klassen [CommentAuthor](https://reference.aspose.com/slides/sv/net/aspose.slides/commentauthor) som ger information om en författare, inklusive namn, initialer och associerade kommentarer.

## **Lägg till bildkommentarer**
Följande exempel visar hur du lägger till kommentarer på bilder i en PowerPoint-presentation:

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

## **Åtkomst till bildkommentarer**
Följande exempel visar hur du får åtkomst till befintliga kommentarer i en PowerPoint-presentation:

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

## **Svara på kommentarer**
En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. Egenskapen [ParentComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment/properties/parentcomment) i gränssnittet [IComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment) låter dig hämta eller ange föräldern till en kommentar.

Följande exempel visar hur du lägger till svar och undersöker den resulterande kommentarhierarkin:

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
* När [Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment/methods/remove)-metoden i gränssnittet [IComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment) används för att ta bort en kommentar, tas även alla svar på den kommentaren bort.
* Om egenskapen [ParentComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icomment/properties/parentcomment) skapar en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan kopplas till själva bilden, till en specifik form eller till ett textområde i en AutoShape. Metoden [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/sv/net/aspose.slides/icommentcollection/addmoderncomment/) accepterar ett [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/)‑argument utöver bild‑ och kommentarmarkörkoordinaterna.

När `null` skickas för formaargumentet är kommentaren en bildnivå‑kommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte kopplad till någon specifik form, så [IModernComment.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/shape/) returnerar `null`. När en [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/) tillhandahålls, förankras kommentaren på den formen. Koordinaterna definierar fortfarande positionen för kommentarmarkören på bilden, medan formkopplingen kan hämtas via [IModernComment.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/shape/).

### **Fästa en modern kommentar på en form**

Följande exempel skapar både en bildnivå‑modern kommentar och en modern kommentar förankrad till en specifik AutoShape. Därefter läses den associerade formen från varje kommentar.

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

### **Fäst kommentarer på olika formtyper**

Alla bildobjekt som implementerar [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/) kan användas som formankare. Vanliga exempel inkluderar [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/sv/net/aspose.slides/iconnector/), och [IGraphicalObject](https://reference.aspose.com/slides/sv/net/aspose.slides/igraphicalobject/)-instanser som diagram.

Följande exempel skapar flera vanliga formtyper och associerar en modern kommentar med var och en.

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

### **Fäst en kommentar på text och ange dess status**

För en modern kommentar som är kopplad till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/), anger [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/textselectionstart/) startpositionen för den markerade texten i formens textruta, medan [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/textselectionlength/) anger längden på markeringen. Tillsammans associerar dessa egenskaper kommentaren med ett specifikt textområde i AutoShape.

Egenskapen [IModernComment.Status](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/status/) kan läsas eller uppdateras med ett värde från uppräkningen [ModernCommentStatus](https://reference.aspose.com/slides/sv/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — ingen specifik modern‑kommentarstatus är definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har markerats som löst.
- `Closed` — kommentaren är stängd.

Följande exempel skapar en formförankrad modern kommentar, associerar den med en textmarkering, markerar den som löst, sparar presentationen och verifierar värdena efter att filen har öppnats igen.

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

### **Inspektera befintliga moderna kommentarer**

För att inspektera en befintlig presentation, kontrollera vilka kommentarer som implementerar [IModernComment](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/), granska sedan [IModernComment.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/textselectionlength/) och [IModernComment.Status](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/status/). En `null`‑form indikerar en bildnivå‑kommentar. För en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/)‑ankare identifierar textmarkerings‑egenskaperna det associerade området i formens textruta.

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

## **Ta bort kommentarer**

### **Ta bort alla kommentarer och kommentarförfattare**

Följande exempel visar hur du tar bort alla kommentarer och kommentarförfattare från en presentation:

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

### **Ta bort specifika kommentarer**

Följande exempel visar hur du tar bort specifika kommentarer från en bild:

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

**Stöder Aspose.Slides ett löst‑status för moderna kommentarer?**

Ja. [IModernComment.Status](https://reference.aspose.com/slides/sv/net/aspose.slides/imoderncomment/status/) kan läsas och sättas med ett [ModernCommentStatus](https://reference.aspose.com/slides/sv/net/aspose.slides/moderncommentstatus/)-värde, inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen efter att filen har öppnats.

**Stöds trådade diskussioner (svarskedjor), och finns det någon begränsning för nästling?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/sv/net/aspose.slides/comment/parentcomment/), vilket möjliggör svarskedjor. API:et definierar ingen specifik begränsning för nästlingsdjup.

**I vilket koordinatsystem definieras en kommentarmarkörs position på en bild?**

Markörens position definieras av flyttal‑koordinater i bildens koordinatsystem, vilket gör att du kan placera den exakt på bilden.