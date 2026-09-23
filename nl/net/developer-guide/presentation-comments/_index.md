---
title: Beheer presentatieopmerkingen in .NET
linktitle: Presentatieopmerkingen
type: docs
weight: 100
url: /nl/net/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint opmerkingen
- presentatie opmerkingen
- dia opmerkingen
- opmerking toevoegen
- opmerking benaderen
- opmerking bewerken
- opmerking beantwoorden
- opmerking verwijderen
- opmerking wissen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer presentatieopmerkingen met Aspose.Slides for .NET: voeg toe, lees, bewerk, beantwoord en verwijder opmerkingen in PowerPoint presentaties snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieopmerkingen beheert met Aspose.Slides for .NET. Het introduceert de belangrijkste typen die met opmerkingen te maken hebben en toont hoe u opmerkingen aan dia's toevoegt, bestaande opmerkingen benadert, werkt met antwoorden en moderne opmerkingen, en opmerkingen uit een presentatie verwijdert.

De voorbeelden behandelen veelvoorkomende beoordelings- en samenwerkingsscenario's in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van opmerkingstekst en metadata, het opbouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia's. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

Om te vragen dat opmerkingen worden getoond of verborgen wanneer een presentatie wordt geopend zonder de opmerkingen zelf te wijzigen, zie [Toon of verberg opmerkingen bij het openen van een presentatie](/slides/nl/net/presentation-view-properties/).

## **Waarom opmerkingen aan presentaties toevoegen?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega's bij het beoordelen van presentaties.

Aspose.Slides for .NET biedt de volgende API's voor het werken met opmerkingen:

* De [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse, die toegang biedt tot de opmerkingauteurs van de presentatie.
* De [ICommentCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/icommentcollection) interface, die de opmerkingen vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment) interface, die informatie over een opmerking biedt, inclusief de auteur, aanmaaktijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/nl/net/aspose.slides/commentauthor) klasse, die informatie over een auteur biedt, inclusief naam, initialen en bijbehorende opmerkingen.

## **Opmerkingen aan dia's toevoegen**
Het volgende voorbeeld toont hoe u opmerkingen aan dia's toevoegt in een PowerPoint‑presentatie:

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

## **Opmerkingen op dia's benaderen**
Het volgende voorbeeld toont hoe u bestaande opmerkingen in een PowerPoint‑presentatie benadert:

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

## **Antwoorden op opmerkingen**
Een hoofdopmerking is de oorspronkelijke opmerking bovenaan een antwoordenhiërarchie. De [ParentComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/properties/parentcomment) eigenschap van de [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment) interface stelt u in staat de ouder van een opmerking op te halen of in te stellen.

Het volgende voorbeeld toont hoe u antwoorden toevoegt en de resulterende opmerkingenhiërarchie inspecteert:

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
* Wanneer de [Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/methods/remove) methode van de [IComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment) interface wordt gebruikt om een opmerking te verwijderen, worden ook alle antwoorden op die opmerking verwijderd.
* Als de [ParentComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icomment/properties/parentcomment) eigenschap een circulaire verwijzing creëert, wordt er een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception) opgegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifiek vormobject, of aan een tekstreeks binnen een AutoShape. De [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/nl/net/aspose.slides/icommentcollection/addmoderncomment/) methode accepteert een [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) argument naast de dia‑ en opmerkingenmarkeringscoördinaten.

Wanneer `null` wordt doorgegeven voor het vormobject, is de opmerking een dia‑niveau opmerking. De marker wordt gepositioneerd volgens de opgegeven coördinaten, maar is niet gekoppeld aan een specifiek vormobject, zodat [IModernComment.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/shape/) `null` retourneert. Wanneer een [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) wordt opgegeven, wordt de opmerking verankerd aan dat vormobject. De coördinaten bepalen nog steeds de positie van de opmerkingenmarker op de dia, terwijl de vormkoppeling kan worden opgehaald via [IModernComment.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/shape/).

### **Een moderne opmerking aan een vorm verankeren**

Het volgende voorbeeld maakt zowel een moderne opmerking op dia‑niveau als een moderne opmerking die aan een specifieke AutoShape is verankerd. Vervolgens leest het de gekoppelde vorm van elke opmerking.

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

### **Opmerkingen verankeren aan verschillende vormtypen**

Elk dia‑object dat [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) implementeert, kan worden gebruikt als vormanker. Veelvoorkomende voorbeelden zijn [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/nl/net/aspose.slides/iconnector/), en [IGraphicalObject](https://reference.aspose.com/slides/nl/net/aspose.slides/igraphicalobject/) instanties, zoals grafieken.

Het volgende voorbeeld maakt verschillende veelvoorkomende vormtypen aan en koppelt aan elk een moderne opmerking.

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

### **Een opmerking aan tekst verankeren en de status instellen**

Voor een moderne opmerking die gekoppeld is aan een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/), specificeert [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/textselectionstart/) de startpositie van de geselecteerde tekst in het tekstvak van de vorm, terwijl [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/textselectionlength/) de lengte van de selectie aangeeft. Gezamenlijk koppelen deze eigenschappen de opmerking aan een specifieke tekstreeks binnen de AutoShape.

De [IModernComment.Status](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/status/) eigenschap kan worden gelezen of bijgewerkt met een waarde uit de [ModernCommentStatus](https://reference.aspose.com/slides/nl/net/aspose.slides/moderncommentstatus/) enumeratie:
- `NotDefined` — er is geen specifieke moderne‑opmerkingstatus gedefinieerd.
- `Active` — de opmerking is actief.
- `Resolved` — de opmerking is opgelost.
- `Closed` — de opmerking is gesloten.

Het volgende voorbeeld maakt een aan een vorm verankerde moderne opmerking, koppelt deze aan een tekstreeks, markeert deze als opgelost, slaat de presentatie op en verifieert de waarden na het heropenen van het bestand.

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

### **Bestaande moderne opmerkingen inspecteren**

Om een bestaande presentatie te inspecteren, controleert u welke opmerkingen [IModernComment](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/) implementeren, vervolgens bekijkt u [IModernComment.Shape](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/textselectionlength/) en [IModernComment.Status](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/status/). Een `null` vorm duidt op een opmerking op dia‑niveau. Voor een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) anker identificeren de tekstselectie‑eigenschappen het bijbehorende bereik in het tekstvak van de vorm.

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

## **Opmerkingen verwijderen**

### **Alle opmerkingen en opmerkingauteurs verwijderen**

Het volgende voorbeeld toont hoe u alle opmerkingen en opmerkingauteurs uit een presentatie verwijdert:

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

### **Specifieke opmerkingen verwijderen**

Het volgende voorbeeld toont hoe u specifieke opmerkingen van een dia verwijdert:

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

**Ondersteunt Aspose.Slides een resolved‑status voor moderne opmerkingen?**

Ja. [IModernComment.Status](https://reference.aspose.com/slides/nl/net/aspose.slides/imoderncomment/status/) kan worden gelezen en ingesteld met een [ModernCommentStatus](https://reference.aspose.com/slides/nl/net/aspose.slides/moderncommentstatus/) waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand opnieuw is geopend.

**Worden discussies in threads (antwoordketens) ondersteund, en is er een limiet op de diepte?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/nl/net/aspose.slides/comment/parentcomment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van de nesting.

**In welk coördinatensysteem wordt de positie van een opmerkingenmarker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑kommagetallen in het coördinatensysteem van de dia, waarmee u deze nauwkeurig op de dia kunt plaatsen.