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

Den här artikeln förklarar hur man hanterar presentationskommentarer med Aspose.Slides för .NET. Den introducerar de viktigaste kommentarrelaterade typerna och visar hur man lägger till kommentarer på bilder, får åtkomst till befintliga kommentarer, arbetar med svar och moderna kommentarer samt tar bort kommentarer från en presentation.

Exemplen täcker vanliga gransknings‑ och samarbets scenarier i PowerPoint, såsom att tilldela kommentarer till författare, läsa kommentarttext och metadata, bygga svarskedjor och ta bort valda kommentarer eller alla kommentarer.

I PowerPoint visas kommentarer som anteckningar på bilder. När du markerar en kommentar visas dess text och relaterade diskussion.

För att begära att kommentarer visas eller döljs när en presentation öppnas utan att ändra själva kommentarerna, se [Visa eller dölja kommentarer när en presentation öppnas](/slides/sv/net/presentation-view-properties/).

## **Varför lägga till kommentarer i presentationer?**

Du kan använda kommentarer för att ge feedback och samarbeta med kollegor när du granskar presentationer.

Aspose.Slides för .NET tillhandahåller följande API:er för att arbeta med kommentarer:

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class, which provides access to the presentation's comment authors.
* The [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) interface, which represents the comments associated with an individual author.
* The [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) class, which provides information about an author, including their name, initials, and associated comments.

## **Lägg till bildkommentarer**

Exemplet skapar två bilder och registrerar en kommentarförfattare med [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Det använder [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) för att placera en kommentar på varje bild, hämtar sedan den första bildens kommentarer för den författaren med [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). Konsolen visar den första kommentarens text två gånger, vilket demonstrerar åtkomst via både bilden och författaren, och den sparade presentationen innehåller båda kommentarerna.

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

## **Sök eller skapa en kommentarförfattare**

När en automatiserad granskning bearbetar samma presentation upprepade gånger, sök i dess [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/)‑samling innan du lägger till en författare. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) matchar både namn och initialer och returnerar en array med matchande författare, eller en tom array om inga matchningar finns. I motsats till detta söker [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) endast efter namn, oavsett initialer. Att anropa [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) med ett namn och initialer som redan finns i samlingen kastar ett undantag.

Exemplet kräver en presentationsfil med minst en bild. På varje av två genomgångar återanvänder det den första matchande författaren, eller skapar en ny endast när resultatet är tomt. Om det finns flera matchningar väljer det det första array‑elementet utan att slå samman eller ta bort de andra författarna. Det anropar sedan [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) för den valda författaren och sparar presentationen. Den andra genomgången öppnar den första genomgångens utdata och upprepar operationen.

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

Den andra genomgången lägger till ytterligare en kommentar utan att lägga till en ny författare eller ta bort befintliga kommentarer. Slutfilen, `review_pass_2.pptx`, innehåller båda nya kommentarerna tillsammans med eventuella ursprungliga kommentarer. Återanvändning av en författare deduplicerar inte kommentarer: för att undvika att upprepade gånger lägga till samma kommentar, implementera separat dupliceringsdetektion innan du lägger till den.

## **Åtkomst till bildkommentarer**

Exemplet öppnar en befintlig presentation och läser dess [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/)‑samling. För varje författare itererar det genom [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) och skriver ut bildnummer, kommentartext, författarnamn och skapningstid. Inmatningspresentationen måste innehålla kommentarer för att producera konsolutdata.

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

En föräldrakommentar är den ursprungliga kommentaren högst upp i en svarshierarki. [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/)-egenskapen i [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)-gränssnittet låter dig hämta eller ange föräldern för en kommentar.

Exemplet skapar kommentarer från två författare och använder [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) för att bygga svar, inklusive ett svar på ett annat svar. Att skicka `null` till [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) hämtar kommentarer från alla författare; konsolen indenterar varje post enligt dess djup i svarshierarkin. Exemplet sparar den kompletta diskussionen, anropar [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) på den första rotkommentaren och sparar en andra presentation med den kommentaren och dess svar borttagna.

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
* När metoden [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) i [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment)-gränssnittet används för att radera en kommentar, tas alla svar på den kommentaren också bort.
* Om [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/)‑egenskapen skapar en cirkulär referens, kastas ett [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).
{{% /alert %}}

## **Lägg till moderna kommentarer**

Moderna kommentarer kan associeras med själva bilden, med en specifik form eller med ett textintervall i en AutoShape. Metoden [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) accepterar ett [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)-argument utöver bilden och koordinaterna för kommentarmarkören.

När `null` skickas för shape‑argumentet blir kommentaren en bildnivå‑kommentar. Dess markör placeras enligt de angivna koordinaterna, men den är inte knuten till någon specifik form, så [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) returnerar `null`. När en [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) tillhandahålls, förankras kommentaren till den formen. Koordinaterna definierar fortfarande positionen för kommentarmarkören på bilden, medan form‑kopplingen kan hämtas via [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Förankra en modern kommentar till en form**

Exemplet anropar [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) två gånger: en gång med en `null`‑form för en bildnivå‑kommentar och en gång med en rektangel som förankring. Att läsa [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) skriver ut `True` för bildnivå‑kommentarens null‑kontroll och `Revenue title` för den förankrade kommentaren. Båda kommentarerna sparas med presentationen.

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

### **Förankra kommentarer till olika formtyper**

Alla bildobjekt som implementerar [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) kan användas som form‑förankring. Vanliga exempel inkluderar [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) och [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/)-instanser såsom diagram.

Exemplet använder [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) för att associera en kommentar med var och en av fem formtyper: en AutoShape, en bildram, en grupp, en koppling och ett diagram. Bilden använder inbäddad bilddata, så ingen extern bild behövs. Varje kommentar har sin egen markörposition, och den sparade presentationen behåller alla fem form‑associationer.

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

### **Förankra en kommentar till text och sätt dess status**

För en modern kommentar kopplad till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), specificerar [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) startpositionen för den valda texten i formens textram, medan [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) anger längden på urvalet. Tillsammans associerar dessa egenskaper kommentaren med ett specifikt textintervall i AutoShape.

[IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/)-egenskapen kan läsas eller uppdateras med ett värde från uppräkningen [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — ingen specifik modern‑kommentarstatus definierad.
- `Active` — kommentaren är aktiv.
- `Resolved` — kommentaren har lösts.
- `Closed` — kommentaren är stängd.

Exemplet förankrar en modern kommentar till orden "quarterly revenue" i en rektangels text. Det beräknar den nollbaserade [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) från texten och sätter [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) till antalet valda tecken. Efter att ha satt [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) till `Resolved` sparas och öppnas presentationen igen. De fyra konsollkontrollerna bör alla skriva ut `True`, vilket bekräftar att form‑förankring, textintervall och status bevarades.

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

Exemplet kräver en befintlig presentation som innehåller moderna kommentarer och skriver ut deras text, status och förankringsdetaljer. För att inspektera den, kontrollera vilka kommentarer som implementerar [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), granska sedan [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) och [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). En `null`‑form indikerar en bildnivå‑kommentar. För en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)-förankring identifierar text‑urvalsegenskaperna det associerade intervallet i formens textram.

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

Aspose.Slides för .NET låter dig ta bort alla kommentarer och deras författare från en presentation eller radera valda kommentarer samtidigt som resten behålls. Följande exempel demonstrerar båda tillvägagångssätten och sparar den uppdaterade presentationen.

### **Ta bort alla kommentarer och kommentarförfattare**

Exemplet öppnar en befintlig presentation och anropar [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) för varje författare, därefter [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) för att ta bort författarna själva. Den sparade presentationen innehåller varken kommentarer eller kommentarförfattare. Använd en presentation som innehåller kommentarer för att se borttagningen.

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

Exemplet skapar två kommentarer på en bild och använder [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) för att hitta kommentarer av varje författare. Det samlar kommentarer vars text är lika med "comment 1" innan det anropar [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), för att undvika förändringar i samlingen under urvalet. Den sparade presentationen behåller endast "comment 2".

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

**Stöder Aspose.Slides en löst status för moderna kommentarer?**

Ja. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) kan läsas och sättas med ett [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/)-värde, inklusive `Resolved`. Statusen lagras i presentationen och kan läsas igen när filen öppnas på nytt.

**Stöds trådade diskussioner (svarskedjor), och finns det någon begränsning för nästling?**

Ja. Varje kommentar kan referera till sin [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), vilket möjliggör svarskedjor. API‑et definierar ingen specifik gräns för nästlingsdjup.

**I vilket koordinatsystem definieras en kommentarmarkörs position på en bild?**

Markörpositionen definieras av flyttal‑koordinater i bildens koordinatsystem, vilket låter dig placera den exakt på bilden.