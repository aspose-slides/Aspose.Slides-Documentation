---
title: Beheer presentatiecommentaren in .NET
linktitle: Presentatiecommentaren
type: docs
weight: 100
url: /nl/net/presentation-comments/
keywords:
- commentaar
- modern commentaar
- PowerPoint-commentaren
- presentatiecommentaren
- dia commentaren
- commentaar toevoegen
- commentaar benaderen
- commentaar bewerken
- commentaar beantwoorden
- commentaar verwijderen
- commentaar verwijderen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatiecommentaren met Aspose.Slides voor .NET: voeg commentaren toe, lees ze, bewerk ze, beantwoord ze en verwijder commentaren in PowerPoint-presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatiecommentaren beheert met Aspose.Slides voor .NET. Het introduceert de belangrijkste types met betrekking tot commentaren en laat zien hoe u commentaren aan dia's toevoegt, bestaande commentaren benadert, werkt met antwoorden en moderne commentaren, en commentaren uit een presentatie verwijdert.

De voorbeelden behandelen gangbare beoordelings‑ en samenwerkingsscenario's in PowerPoint, zoals commentaren aan auteurs toewijzen, commentaartekst en metadata lezen, antwoordketens opbouwen, en geselecteerde commentaren of alle commentaren verwijderen.

In PowerPoint verschijnen commentaren als annotaties op dia's. Het selecteren van een commentaar toont de tekst en de bijbehorende discussie.

## **Waarom commentaren aan presentaties toevoegen?**

U kunt commentaren gebruiken om feedback te geven en samen te werken met collega’s bij het beoordelen van presentaties.

Aspose.Slides voor .NET biedt de volgende API’s voor het werken met commentaren:

* De [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse, die toegang biedt tot de commentaarauteurs van de presentatie.
* De [ICommentCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icommentcollection)‑interface, die de commentaren vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment)‑interface, die informatie over een commentaar biedt, inclusief auteur, creatietijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/net/aspose.slides/commentauthor)‑klasse, die informatie over een auteur biedt, inclusief naam, initialen en gekoppelde commentaren.

## **Dia‑commentaren toevoegen**
Het volgende voorbeeld laat zien hoe u commentaren aan dia's in een PowerPoint‑presentatie toevoegt:

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

## **Dia‑commentaren benaderen**
Het volgende voorbeeld laat zien hoe u bestaande commentaren in een PowerPoint‑presentatie benadert:

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

## **Antwoorden op commentaren**
Een bovenliggend commentaar is het oorspronkelijke commentaar bovenaan een antwoordhiërarchie. De [ParentComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/properties/parentcomment)‑eigenschap van de [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment)‑interface stelt u in staat om de bovenliggende commentaar op te halen of in te stellen.

Het volgende voorbeeld laat zien hoe u antwoorden toevoegt en de resulterende commentaarhiërarchie inspecteert:

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

{{% alert color="warning" title="Attentie" %}} 

* Wanneer de [Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/methods/remove)‑methode van de [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment)‑interface wordt gebruikt om een commentaar te verwijderen, worden ook alle antwoorden op dat commentaar verwijderd.
* Als de [ParentComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/properties/parentcomment)‑eigenschap een circulaire verwijzing creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception) opgegooid.

{{% /alert %}}

## **Moderne commentaren toevoegen**

Moderne commentaren kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icommentcollection/addmoderncomment/)‑methode accepteert een [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/)‑argument naast de dia‑ en commentaarmarker‑coördinaten.

Wanneer `null` wordt doorgegeven voor het vorm‑argument, is het commentaar een dia‑niveau commentaar. De marker wordt gepositioneerd op basis van de opgegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, zodat [IModernComment.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/shape/) `null` retourneert. Wanneer een [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) wordt opgegeven, wordt het commentaar verankerd aan die vorm. De coördinaten bepalen nog steeds de positie van de commentaarmarker op de dia, terwijl de vormkoppeling kan worden opgevraagd via [IModernComment.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/shape/).

### **Een modern commentaar aan een vorm verankeren**

Het volgende voorbeeld maakt zowel een dia‑niveau modern commentaar als een modern commentaar verankerd aan een specifieke AutoShape. Vervolgens leest het de gekoppelde vorm van elk commentaar.

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

### **Commentaren verankeren aan verschillende vormtypen**

Elk dia‑object dat de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/)‑interface implementeert, kan worden gebruikt als vormveranker. Veelvoorkomende voorbeelden zijn [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/nl/net/aspose.slides/iconnector/), en [IGraphicalObject](https://reference.aspose.com/slides/nl/net/aspose.slides/igraphicalobject/)-instanties zoals diagrammen.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen en koppelt een modern commentaar aan elk van hen.

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

### **Een commentaar aan tekst verankeren en de status instellen**

Voor een modern commentaar gekoppeld aan een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/), specificeert [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/textselectionstart/) de startpositie van de geselecteerde tekst in het tekstframe van de vorm, terwijl [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/textselectionlength/) de lengte van de selectie aangeeft. Samen associëren deze eigenschappen het commentaar met een specifieke tekstreeks binnen de AutoShape.

De [IModernComment.Status](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/status/)‑eigenschap kan worden gelezen of bijgewerkt met een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nl/net/aspose.slides/moderncommentstatus/)‑enumeratie:

- `NotDefined` — er is geen specifieke modern‑commentaarstatus gedefinieerd.
- `Active` — het commentaar is actief.
- `Resolved` — het commentaar is opgelost.
- `Closed` — het commentaar is gesloten.

Het volgende voorbeeld maakt een vorm‑verankerd modern commentaar, koppelt het aan een tekstreeks, markeert het als opgelost, slaat de presentatie op en controleert de waarden na het opnieuw openen van het bestand.

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

### **Bestaande moderne commentaren inspecteren**

Om een bestaande presentatie te inspecteren, controleert u welke commentaren de [IModernComment](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/)‑interface implementeren, bekijkt vervolgens [IModernComment.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/textselectionlength/) en [IModernComment.Status](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/status/). Een `null` vorm wijst op een dia‑niveau commentaar. Voor een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/)‑veranker geven de tekstreekseigenschappen de bijbehorende reeks in het tekstframe van de vorm aan.

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

## **Commentaren verwijderen**

### **Alle commentaren en commentaarauteurs verwijderen**

Het volgende voorbeeld laat zien hoe u alle commentaren en commentaarauteurs uit een presentatie verwijdert:

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

### **Specifieke commentaren verwijderen**

Het volgende voorbeeld laat zien hoe u specifieke commentaren van een dia verwijdert:

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

**Ondersteunt Aspose.Slides een opgeloste status voor moderne commentaren?**

Ja. De [IModernComment.Status](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/status/) kan worden gelezen en ingesteld met een [ModernCommentStatus](https://reference.aspose.com/slides/nl/net/aspose.slides/moderncommentstatus/)‑waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand is heropend.

**Worden threads (antwoordketens) ondersteund en is er een limiet op de diepte?**

Ja. Elk commentaar kan verwijzen naar zijn [bovenliggend commentaar](https://reference.aspose.com/slides/nl/net/aspose.slides/comment/parentcomment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet op de nesting‑diepte.

**In welk coördinatensysteem wordt de positie van een commentaarmarker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑komma‑coördinaten in het dia‑coördinatensysteem, waardoor u de marker nauwkeurig op de dia kunt plaatsen.