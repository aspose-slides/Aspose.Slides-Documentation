---
title: Verwalten von Präsentationskommentaren in .NET
linktitle: Präsentationskommentare
type: docs
weight: 100
url: /de/net/presentation-comments/
keywords:
- Kommentar
- moderner Kommentar
- PowerPoint-Kommentare
- Präsentationskommentare
- Folienkommentare
- Kommentar hinzufügen
- Kommentar abrufen
- Kommentar bearbeiten
- Auf Kommentar antworten
- Kommentar entfernen
- Kommentar löschen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für .NET: Kommentare in PowerPoint‑Präsentationen schnell und einfach hinzufügen, lesen, bearbeiten, darauf antworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationskommentare mit Aspose.Slides für .NET verwaltet. Er stellt die wichtigsten kommentarbezogenen Typen vor und demonstriert, wie man Kommentare zu Folien hinzufügt, vorhandene Kommentare abruft, mit Antworten und modernen Kommentaren arbeitet und Kommentare aus einer Präsentation entfernt.

Die Beispiele decken gängige Prüf‑ und Zusammenarbeitsszenarien in PowerPoint ab, wie das Zuweisen von Kommentaren zu Autoren, das Lesen von Kommentartexten und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf den Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen zusammenzuarbeiten, wenn Sie Präsentationen prüfen.

Aspose.Slides für .NET stellt die folgenden APIs für die Arbeit mit Kommentaren bereit:

* Die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) Klasse, die Zugriff auf die Kommentar‑Autoren der Präsentation bietet.
* Die [ICommentCollection](https://reference.aspose.com/slides/de/net/aspose.slides/icommentcollection) Schnittstelle, die die Kommentare eines einzelnen Autors darstellt.
* Die [IComment](https://reference.aspose.com/slides/de/net/aspose.slides/icomment) Schnittstelle, die Informationen zu einem Kommentar liefert, einschließlich Autor, Erstellungszeit, Position und Text.
* Die [CommentAuthor](https://reference.aspose.com/slides/de/net/aspose.slides/commentauthor) Klasse, die Informationen zu einem Autor bereitstellt, darunter Name, Initialen und zugehörige Kommentare.

## **Folienkommentare hinzufügen**
Das folgende Beispiel zeigt, wie man Kommentare zu Folien in einer PowerPoint‑Präsentation hinzufügt:

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

## **Folienkommentare abrufen**
Das folgende Beispiel zeigt, wie man vorhandene Kommentare in einer PowerPoint‑Präsentation abruft:

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

## **Auf Kommentare antworten**
Ein Eltern‑Kommentar ist der ursprüngliche Kommentar an der Spitze einer Antwort‑Hierarchie. Die [ParentComment](https://reference.aspose.com/slides/de/net/aspose.slides/icomment/properties/parentcomment) Eigenschaft der [IComment](https://reference.aspose.com/slides/de/net/aspose.slides/icomment) Schnittstelle ermöglicht das Abrufen oder Setzen des Elternteils eines Kommentars.

Das folgende Beispiel zeigt, wie man Antworten hinzufügt und die resultierende Kommentar‑Hierarchie inspiziert:

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

* Wenn die [Remove](https://reference.aspose.com/slides/de/net/aspose.slides/icomment/methods/remove) Methode der [IComment](https://reference.aspose.com/slides/de/net/aspose.slides/icomment) Schnittstelle verwendet wird, um einen Kommentar zu löschen, werden alle Antworten auf diesen Kommentar ebenfalls gelöscht.
* Wenn die [ParentComment](https://reference.aspose.com/slides/de/net/aspose.slides/icomment/properties/parentcomment) Eigenschaft eine zirkuläre Referenz erzeugt, wird eine [PptxEditException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxeditexception) ausgelöst.

{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer AutoShape zugeordnet werden. Die [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/de/net/aspose.slides/icommentcollection/addmoderncomment/) Methode akzeptiert ein [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) Argument zusätzlich zu den Folien‑ und Kommentar‑Marker‑Koordinaten.

Wenn `null` für das Shape‑Argument übergeben wird, handelt es sich bei dem Kommentar um einen Folien‑Kommentar. Sein Marker wird anhand der angegebenen Koordinaten positioniert, ist jedoch keiner bestimmten Form zugeordnet, sodass [IModernComment.Shape](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/shape/) `null` zurückgibt. Wird ein [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) angegeben, wird der Kommentar an dieser Form verankert. Die Koordinaten definieren weiterhin die Position des Kommentar‑Markers auf der Folie, während die Formzugehörigkeit über [IModernComment.Shape](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/shape/) abgerufen werden kann.

### **Einen modernen Kommentar an einer Form verankern**

Das folgende Beispiel erstellt sowohl einen Folien‑Kommentar als auch einen modernen Kommentar, der an einer bestimmten AutoShape verankert ist. Anschließend wird die zugehörige Form jedes Kommentars ausgelesen.

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

### **Kommentare an verschiedenen Formtypen verankern**

Jedes Folienobjekt, das die [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) Schnittstelle implementiert, kann als Anker verwendet werden. Übliche Beispiele umfassen [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/de/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/de/net/aspose.slides/iconnector/) und [IGraphicalObject](https://reference.aspose.com/slides/de/net/aspose.slides/igraphicalobject/) Instanzen wie Diagramme.

Das folgende Beispiel erstellt mehrere gängige Formtypen und verknüpft einen modernen Kommentar mit jedem von ihnen.

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

### **Einen Kommentar an Text anhängen und seinen Status festlegen**

Für einen modernen Kommentar, der einer [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) zugeordnet ist, gibt [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/textselectionstart/) die Startposition des ausgewählten Textes im Textfeld der Form an, während [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/textselectionlength/) die Länge der Auswahl angibt. Zusammen verknüpfen diese Eigenschaften den Kommentar mit einem bestimmten Textbereich innerhalb der AutoShape.

Die [IModernComment.Status](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/status/) Eigenschaft kann gelesen oder mit einem Wert aus der [ModernCommentStatus](https://reference.aspose.com/slides/de/net/aspose.slides/moderncommentstatus/) Aufzählung aktualisiert werden:

- `NotDefined` — kein spezifischer moderner Kommentarstatus ist definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde gelöst.
- `Closed` — der Kommentar ist geschlossen.

Das folgende Beispiel erstellt einen an einer Form verankerten modernen Kommentar, verknüpft ihn mit einer Textauswahl, markiert ihn als gelöst, speichert die Präsentation und prüft die Werte nach erneutem Öffnen der Datei.

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

### **Vorhandene moderne Kommentare untersuchen**

Um eine bestehende Präsentation zu prüfen, ermitteln Sie, welche Kommentare die [IModernComment](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/) Schnittstelle implementieren, und untersuchen Sie dann [IModernComment.Shape](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/textselectionlength/) und [IModernComment.Status](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/status/). Ein `null` Shape weist auf einen Folien‑Kommentar hin. Bei einem [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) Anker identifizieren die Textauswahl‑Eigenschaften den zugehörigen Bereich im Textfeld der Form.

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

## **Kommentare entfernen**

### **Alle Kommentare und Kommentarautoren entfernen**

Das folgende Beispiel zeigt, wie man alle Kommentare und Kommentarautoren aus einer Präsentation entfernt:

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

### **Bestimmte Kommentare entfernen**

Das folgende Beispiel zeigt, wie man bestimmte Kommentare von einer Folie entfernt:

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

**Unterstützt Aspose.Slides einen gelösten Status für moderne Kommentare?**

Ja. [IModernComment.Status](https://reference.aspose.com/slides/de/net/aspose.slides/imoderncomment/status/) kann mit einem [ModernCommentStatus](https://reference.aspose.com/slides/de/net/aspose.slides/moderncommentstatus/) Wert gelesen und gesetzt werden, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach erneutem Öffnen der Datei wieder ausgelesen werden.

**Werden Threaded Discussions (Antwortketten) unterstützt und gibt es ein Verschachtelungs‑Limit?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/de/net/aspose.slides/comment/parentcomment/) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert kein spezifisches Begrenzungs‑Tiefe‑Limit.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie ihn präzise auf der Folie platzieren können.