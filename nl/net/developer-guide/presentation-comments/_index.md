---
title: Beheer presentatie-opmerkingen in .NET
linktitle: Presentatie-opmerkingen
type: docs
weight: 100
url: /nl/net/presentation-comments/
keywords:
- opmerking
- moderne opmerking
- PowerPoint-opmerkingen
- presentatie-opmerkingen
- dia-opmerkingen
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
description: "Beheer presentatie-opmerkingen met Aspose.Slides voor .NET: voeg opmerkingen toe, lees ze, bewerk ze, beantwoord ze en verwijder ze in PowerPoint-presentaties, snel en eenvoudig."
---
## **Overzicht**

Dit artikel legt uit hoe u opmerkingen in een presentatie beheert met Aspose.Slides for .NET. Het introduceert de belangrijkste typen met betrekking tot opmerkingen en laat zien hoe u opmerkingen aan dia's kunt toevoegen, bestaande opmerkingen kunt benaderen, met antwoorden en moderne opmerkingen kunt werken, en opmerkingen uit een presentatie kunt verwijderen.

De voorbeelden behandelen veelvoorkomende beoordelings- en samenwerkingsscenario's in PowerPoint, zoals het toewijzen van opmerkingen aan auteurs, het lezen van de tekst en metadata van opmerkingen, het opbouwen van antwoordketens, en het verwijderen van geselecteerde opmerkingen of alle opmerkingen.

In PowerPoint verschijnen opmerkingen als annotaties op dia's. Het selecteren van een opmerking toont de tekst en de bijbehorende discussie.

Om te vragen dat opmerkingen worden getoond of verborgen bij het openen van een presentatie zonder de opmerkingen zelf te wijzigen, zie [Toon of verberg opmerkingen bij het openen van een presentatie](/slides/nl/net/presentation-view-properties/).

## **Waarom opmerkingen aan presentaties toevoegen?**

U kunt opmerkingen gebruiken om feedback te geven en samen te werken met collega’s bij het beoordelen van presentaties.

Aspose.Slides for .NET biedt de volgende API’s voor het werken met opmerkingen:

* De [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) klasse, die toegang geeft tot de opmerkingauteurs van de presentatie.
* De [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) interface, die de opmerkingen vertegenwoordigt die aan een individuele auteur zijn gekoppeld.
* De [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface, die informatie over een opmerking biedt, inclusief de auteur, creatietijd, positie en tekst.
* De [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) klasse, die informatie over een auteur biedt, inclusief de naam, initialen en gekoppelde opmerkingen.

## **Opmerkingen aan dia's toevoegen**

Het voorbeeld maakt twee dia's aan en registreert een opmerkingauteur met [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Het gebruikt [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) om één opmerking op elke dia te plaatsen, en haalt vervolgens de opmerkingen van de eerste dia op voor die auteur met [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). De console toont de tekst van de eerste opmerking twee keer, wat aantoont dat men zowel via de dia als via de auteur toegang heeft, en de opgeslagen presentatie bevat beide opmerkingen.

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

## **Zoek of maak een opmerkingauteur**

Wanneer een geautomatiseerde beoordeling dezelfde presentatie herhaaldelijk verwerkt, doorzoek dan de [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) collectie voordat u een auteur toevoegt. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) zoekt zowel op naam als initialen en geeft een array van overeenkomende auteurs terug, of een lege array als er geen overeenkomsten zijn. Daarentegen zoekt [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) alleen op naam, ongeacht de initialen. Het aanroepen van [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) met een naam en initialen die al in de collectie aanwezig zijn, veroorzaakt een uitzondering.

Het voorbeeld vereist een presentatiebestand met ten minste één dia. Bij elke van de twee doorgangen hergebruikt het de eerste overeenkomende auteur, of maakt het er één aan alleen wanneer het resultaat leeg is. Als er meerdere overeenkomsten zijn, selecteert het het eerste array‑element zonder de andere auteurs te combineren of te verwijderen. Vervolgens roept het [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) aan voor de geselecteerde auteur en slaat de presentatie op. De tweede doorgang opent de uitvoer van de eerste doorgang en herhaalt de bewerking.

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

De tweede doorgang voegt een extra opmerking toe zonder een extra auteur toe te voegen of bestaande opmerkingen te verwijderen. Het uiteindelijke bestand, `review_pass_2.pptx`, bevat beide nieuwe opmerkingen naast eventuele oorspronkelijke opmerkingen. Het hergebruiken van een auteur dedupliceert opmerkingen niet: om te voorkomen dat dezelfde opmerking herhaaldelijk wordt toegevoegd, implementeer een afzonderlijke detectie van duplicaten voordat u deze toevoegt.

## **Toegang tot dia‑opmerkingen**

Het voorbeeld opent een bestaande presentatie en leest de [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) collectie. Voor elke auteur loopt het door [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) en drukt het het dia‑nummer, de opmerkingtekst, de naam van de auteur en de creatietijd af. De invoerpresentatie moet opmerkingen bevatten om console‑output te genereren.

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

Een hoofdopmerking is de oorspronkelijke opmerking bovenaan een antwoord‑hiërarchie. De [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) eigenschap van de [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface stelt u in staat om het bovenliggende commentaar van een opmerking op te vragen of in te stellen.

Het voorbeeld maakt opmerkingen van twee auteurs aan en gebruikt [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) om antwoorden op te bouwen, inclusief een antwoord op een ander antwoord. Het doorgeven van `null` aan [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) haalt opmerkingen op van alle auteurs; de console insprongt elke vermelding volgens de diepte in de antwoordhiërarchie. Het voorbeeld slaat de volledige discussie op, roept [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) aan op de eerste hoofdopmerking, en slaat een tweede presentatie op waarbij die opmerking en de bijbehorende antwoorden zijn verwijderd.

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

{{% alert color="warning" title="Waarschuwing" %}}
* Wanneer de [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) methode van de [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface wordt gebruikt om een opmerking te verwijderen, worden ook alle antwoorden op die opmerking verwijderd.
* Als de [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) eigenschap een circulaire verwijzing creëert, wordt een [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) gegooid.
{{% /alert %}}

## **Moderne opmerkingen toevoegen**

Moderne opmerkingen kunnen worden gekoppeld aan de dia zelf, aan een specifieke vorm, of aan een tekstreeks binnen een AutoShape. De [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) methode accepteert een [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) argument naast de dia‑ en opmerking‑markercoördinaten.

Wanneer `null` wordt doorgegeven voor het shape‑argument, is de opmerking een dia‑niveau opmerking. De marker wordt geplaatst volgens de meegegeven coördinaten, maar is niet gekoppeld aan een specifieke vorm, waardoor [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) `null` retourneert. Wanneer een [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) wordt opgegeven, wordt de opmerking aan die vorm verankerd. De coördinaten bepalen nog steeds de positie van de opmerkingmarker op de dia, terwijl de vormkoppeling kan worden opgehaald via [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Een moderne opmerking aan een vorm verankeren**

Het voorbeeld roept [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) twee keer aan: eenmaal met een `null` shape voor een dia‑niveau opmerking en eenmaal met een rechthoek als anker. Het uitlezen van [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) geeft `True` weer voor de null‑controle van de dia‑niveau opmerking en `Revenue title` voor de verankerde opmerking. Beide opmerkingen worden samen met de presentatie opgeslagen.

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

### **Opmerkingen aan verschillende vormtypen verankeren**

Elk dia‑object dat [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) implementeert kan als vormanker worden gebruikt. Veelvoorkomende voorbeelden zijn [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) en [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) instanties zoals grafieken.

Het voorbeeld gebruikt [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) om een opmerking te koppelen aan elk van vijf vormtypen: een AutoShape, een afbeeldingframe, een groep, een connector en een grafiek. De afbeelding maakt gebruik van ingebedde afbeeldingsdata, dus er is geen externe afbeelding nodig. Elke opmerking heeft een eigen markerpositie, en de opgeslagen presentatie behoudt alle vijf vormkoppelingen.

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

Voor een moderne opmerking die gekoppeld is aan een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), geeft [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) de beginnende positie van de geselecteerde tekst in het tekstvak van de vorm aan, terwijl [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) de lengte van de selectie specificeert. Samen koppelen deze eigenschappen de opmerking aan een specifieke tekstreeks binnen de AutoShape.

[IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) kan worden gelezen of ingesteld met een [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) waarde, inclusief:

- `NotDefined` — er is geen specifieke moderne‑opmerkingstatus gedefinieerd.
- `Active` — de opmerking is actief.
- `Resolved` — de opmerking is opgelost.
- `Closed` — de opmerking is gesloten.

Het voorbeeld verankert een moderne opmerking aan de woorden "quarterly revenue" in de tekst van een rechthoek. Het berekent de nul‑gebaseerde [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) uit de tekst en stelt [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) in op het aantal geselecteerde tekens. Na het instellen van [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) op `Resolved`, slaat het de presentatie op en opent deze opnieuw. De vier console‑controles moeten elk `True` weergeven, wat bevestigt dat de vormanker, tekstreeks en status bewaard zijn gebleven.

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

Het voorbeeld vereist een bestaande presentatie met moderne opmerkingen en drukt hun tekst, status en ankerdetails af. Om dit te inspecteren, controleert u welke opmerkingen [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) implementeren, en bekijkt vervolgens [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) en [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Een `null` shape duidt op een dia‑niveau opmerking. Voor een [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) anker identificeren de tekst‑selectie‑eigenschappen de bijbehorende reeks in het tekstvak van de vorm.

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

Aspose.Slides for .NET stelt u in staat om alle opmerkingen en hun auteurs uit een presentatie te verwijderen, of om geselecteerde opmerkingen te verwijderen terwijl de rest behouden blijft. De volgende voorbeelden demonstreren beide benaderingen en slaan de bijgewerkte presentatie op.

### **Alle opmerkingen en opmerkingauteurs verwijderen**

Het voorbeeld opent een bestaande presentatie en roept [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) aan voor elke auteur, vervolgens roept het [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) aan om de auteurs zelf te verwijderen. De opgeslagen presentatie bevat geen opmerkingen of opmerkingauteurs. Gebruik een presentatie met opmerkingen om de verwijdering te zien.

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

Het voorbeeld maakt twee opmerkingen op één dia en gebruikt [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) om opmerkingen per auteur te vinden. Het verzamelt opmerkingen waarvan de tekst gelijk is aan "comment 1" voordat het [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/) aanroept, om wijzigingen in de collectie tijdens de selectie te voorkomen. De opgeslagen presentatie behoudt alleen "comment 2".

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

**Ondersteunt Aspose.Slides een opgeloste status voor moderne opmerkingen?**

Ja. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) kan worden gelezen en ingesteld met een [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) waarde, inclusief `Resolved`. De status wordt opgeslagen in de presentatie en kan opnieuw worden gelezen nadat het bestand opnieuw is geopend.

**Worden discussies met threads (antwoordketens) ondersteund, en is er een limiet op het nesting‑niveau?**

Ja. Elke opmerking kan verwijzen naar zijn [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), waardoor antwoordketens mogelijk zijn. De API definieert geen specifieke limiet voor de diepte van nesting.

**In welk coördinatensysteem wordt de positie van een opmerkingmarker op een dia gedefinieerd?**

De markerpositie wordt gedefinieerd door zwevende‑komma coördinaten in het dia‑coördinatensysteem, waardoor u de marker precies op de dia kunt plaatsen.