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
description: "Verwalten Sie Präsentationskommentare mit Aspose.Slides für .NET: Kommentare in PowerPoint‑Präsentationen schnell und einfach hinzufügen, lesen, bearbeiten, beantworten und entfernen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationskommentare mit Aspose.Slides für .NET verwalten. Er führt die wichtigsten kommentarbezogenen Typen ein und zeigt, wie man Kommentare zu Folien hinzufügt, vorhandene Kommentare abruft, mit Antworten und modernen Kommentaren arbeitet und Kommentare aus einer Präsentation entfernt.

Die Beispiele decken gängige Überprüfungs‑ und Zusammenarbeitsszenarien in PowerPoint ab, z. B. das Zuordnen von Kommentaren zu Autoren, das Lesen von Kommentartexten und Metadaten, das Erstellen von Antwortketten und das Entfernen ausgewählter Kommentare oder aller Kommentare.

In PowerPoint erscheinen Kommentare als Anmerkungen auf Folien. Das Auswählen eines Kommentars zeigt dessen Text und die zugehörige Diskussion an.

Um zu steuern, dass Kommentare beim Öffnen einer Präsentation ein‑ oder ausgeblendet werden, ohne die Kommentare selbst zu ändern, siehe [Kommentare beim Öffnen einer Präsentation ein- oder ausblenden](/slides/de/net/presentation-view-properties/).

## **Warum Kommentare zu Präsentationen hinzufügen?**

Sie können Kommentare verwenden, um Feedback zu geben und mit Kollegen zusammenzuarbeiten, wenn Sie Präsentationen prüfen.

Aspose.Slides für .NET stellt die folgenden APIs zum Arbeiten mit Kommentaren bereit:

* Die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) stellt den Zugriff auf die Kommentarautoren der Präsentation bereit.
* Das Interface [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) repräsentiert die Kommentare, die einem einzelnen Autor zugeordnet sind.
* Das Interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) liefert Informationen zu einem Kommentar, einschließlich Autor, Erstellungszeit, Position und Text.
* Die Klasse [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) liefert Informationen zu einem Autor, einschließlich Name, Initialen und zugehöriger Kommentare.

## **Folienkommentare hinzufügen**

Das Beispiel erstellt zwei Folien und registriert einen Kommentarautor mit [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Es verwendet [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) um jeweils einen Kommentar auf jeder Folie zu platzieren, ruft dann die Kommentare der ersten Folie für diesen Autor mit [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) ab. Die Konsole gibt den Text des ersten Kommentars zweimal aus, wodurch der Zugriff sowohl über die Folie als auch über den Autor demonstriert wird, und die gespeicherte Präsentation enthält beide Kommentare.

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

## **Einen Kommentarautor finden oder erstellen**

Wenn eine automatisierte Überprüfung dieselbe Präsentation wiederholt verarbeitet, durchsuchen Sie vor dem Hinzufügen eines Autors die [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/)‑Sammlung. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) vergleicht sowohl Name als auch Initialen und gibt ein Array passender Autoren zurück, oder ein leeres Array, wenn keine Übereinstimmungen existieren. Im Gegensatz dazu sucht [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) nur nach dem Namen, unabhängig von den Initialen. Der Aufruf von [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) mit einem bereits vorhandenen Namen und Initialen löst eine Ausnahme aus.

Das Beispiel benötigt eine Präsentationsdatei mit mindestens einer Folie. In jedem der beiden Durchläufe wird der zuerst gefundene passende Autor wiederverwendet oder nur dann neu erstellt, wenn das Ergebnis leer ist. Gibt es mehrere Treffer, wird das erste Element des Arrays gewählt, ohne die anderen Autoren zu zusammenzuführen oder zu entfernen. Anschließend wird [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) für den ausgewählten Autor aufgerufen und die Präsentation gespeichert. Der zweite Durchlauf öffnet die Ausgabe des ersten Durchlaufs und wiederholt den Vorgang.

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

Der zweite Durchlauf fügt einen weiteren Kommentar hinzu, ohne einen zusätzlichen Autor anzulegen oder vorhandene Kommentare zu entfernen. Die endgültige Datei `review_pass_2.pptx` enthält beide neuen Kommentare neben allen ursprünglichen Kommentaren. Das Wiederverwenden eines Autors dedupliziert Kommentare nicht: Um ein wiederholtes Hinzufügen desselben Kommentars zu vermeiden, sollten Sie vor dem Hinzufügen eine separate Duplikaterkennung implementieren.

## **Zugriff auf Folienkommentare**

Das Beispiel öffnet eine vorhandene Präsentation und liest deren [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/)‑Sammlung. Für jeden Autor wird über [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) iteriert und die Foliennummer, der Kommentartext, der Autorname sowie die Erstellungszeit ausgegeben. Die Eingabepäsentation muss Kommentare enthalten, damit Konsolenausgaben erzeugt werden.

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

Ein Elternkommentar ist der ursprüngliche Kommentar an der Spitze einer Antworthierarchie. Die Eigenschaft [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) des Interfaces [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) ermöglicht das Abrufen bzw. Festlegen des Elternteils eines Kommentars.

Das Beispiel erstellt Kommentare von zwei Autoren und verwendet [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/), um Antworten zu bauen, einschließlich einer Antwort auf eine weitere Antwort. Das Übergeben von `null` an [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) ruft Kommentare aller Autoren ab; die Konsole rückt jeden Eintrag entsprechend seiner Tiefe in der Antworthierarchie ein. Das Beispiel speichert die vollständige Diskussion, ruft [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) für den ersten Stammkommentar auf und speichert eine zweite Präsentation, in der dieser Kommentar und seine Antworten entfernt wurden.

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
* Wenn die Methode [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) des Interfaces [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) verwendet wird, um einen Kommentar zu löschen, werden alle Antworten auf diesen Kommentar ebenfalls gelöscht.
* Führt die Eigenschaft [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) zu einer zirkulären Referenz, wird eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ausgelöst.
{{% /alert %}}

## **Moderne Kommentare hinzufügen**

Moderne Kommentare können der Folie selbst, einer bestimmten Form oder einem Textbereich innerhalb einer AutoShape zugeordnet werden. Die Methode [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) akzeptiert zusätzlich zum Folien‑ und Marker‑Koordinatenargument ein [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)-Argument.

Wird `null` für das Form‑Argument übergeben, handelt es sich um einen kommentarebene‑Kommentar. Sein Marker wird über die angegebenen Koordinaten positioniert, ist jedoch keiner konkreten Form zugeordnet, sodass [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) `null` zurückgibt. Wird eine [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) übergeben, wird der Kommentar an diese Form verankert. Die Koordinaten bestimmen weiterhin die Position des Kommentar‑Markers auf der Folie, während die Form‑Zuordnung über [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) abgerufen werden kann.

### **Ein modernen Kommentar an einer Form verankern**

Das Beispiel ruft [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) zweimal auf: einmal mit einer `null`‑Form für einen folienebenen Kommentar und einmal mit einem Rechteck als Anker. Das Auslesen von [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) gibt `True` für die Nullprüfung des folienebenen Kommentars und `Revenue title` für den verankerten Kommentar aus. Beide Kommentare werden mit der Präsentation gespeichert.

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

Jedes Folienobjekt, das [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) implementiert, kann als Anker verwendet werden. Gebräuchliche Beispiele sind [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) und [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/)-Instanzen wie Diagramme.

Das Beispiel verwendet [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/), um einem Kommentar jeder der fünf Formtypen zuzuordnen: einer AutoShape, einem Bildrahmen, einer Gruppe, einem Connector und einem Diagramm. Das Bild verwendet eingebettete Bilddaten, sodass kein externes Bild nötig ist. Jeder Kommentar hat eine eigene Marker‑Position, und die gespeicherte Präsentation behält alle fünf Formzuordnungen bei.

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

### **Einen Kommentar an Text verankern und seinen Status festlegen**

Für einen modernen Kommentar, der einer [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) zugeordnet ist, gibt [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) die Startposition des ausgewählten Textes im Textfeld der Form an, während [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) die Länge der Auswahl definiert. Zusammen ordnen diese Eigenschaften den Kommentar einem bestimmten Textbereich innerhalb der AutoShape zu.

Die Eigenschaft [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) kann gelesen oder mit einem Wert aus der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) aktualisiert werden:

- `NotDefined` — kein spezifischer Modern‑Comment‑Status definiert.
- `Active` — der Kommentar ist aktiv.
- `Resolved` — der Kommentar wurde gelöst.
- `Closed` — der Kommentar ist geschlossen.

Das Beispiel verankert einen modernen Kommentar an den Worten „quarterly revenue“ im Text eines Rechtecks. Es berechnet den nullbasierten [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) aus dem Text und setzt [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) auf die Anzahl der ausgewählten Zeichen. Nach dem Setzen von [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) auf `Resolved` wird die Präsentation gespeichert und erneut geöffnet. Die vier Konsolen‑Checks sollten jeweils `True` ausgeben, was bestätigt, dass Anker, Textbereich und Status erhalten geblieben sind.

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

Das Beispiel benötigt eine vorhandene Präsentation, die moderne Kommentare enthält, und gibt deren Text, Status und Ankerdetails aus. Um sie zu untersuchen, prüfen Sie, welche Kommentare das Interface [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/) implementieren, und betrachten dann [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) sowie [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Ein `null`‑Shape weist auf einen folienebenen Kommentar hin. Bei einer [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)‑Verankerung identifizieren die Textauswahl‑Eigenschaften den zugehörigen Bereich im Textfeld der Form.

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

Aspose.Slides für .NET ermöglicht das Entfernen aller Kommentare und ihrer Autoren aus einer Präsentation oder das Löschen ausgewählter Kommentare bei gleichzeitiger Beibehaltung des Rests. Die folgenden Beispiele demonstrieren beide Ansätze und speichern die aktualisierte Präsentation.

### **Alle Kommentare und Kommentarautoren entfernen**

Das Beispiel öffnet eine vorhandene Präsentation und ruft für jeden Autor [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) auf, anschließend [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/), um die Autoren selbst zu entfernen. Die gespeicherte Präsentation enthält weder Kommentare noch Kommentarautoren. Verwenden Sie eine Präsentation mit Kommentaren, um die Entfernung zu beobachten.

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

Das Beispiel erstellt zwei Kommentare auf einer Folie und verwendet [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/), um Kommentare jedes Autors zu finden. Es sammelt Kommentare, deren Text exakt „comment 1“ lautet, bevor [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/) aufgerufen wird, um Änderungen an der Sammlung während der Auswahl zu vermeiden. Die gespeicherte Präsentation enthält nur noch „comment 2“.

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

Ja. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) kann gelesen und mit einem Wert aus der Aufzählung [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/) gesetzt werden, einschließlich `Resolved`. Der Status wird in der Präsentation gespeichert und kann nach erneutem Öffnen der Datei wieder ausgelesen werden.

**Werden verschachtelte Diskussionen (Antwortketten) unterstützt und gibt es ein Limit für die Verschachtelungstiefe?**

Ja. Jeder Kommentar kann auf seinen [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/) verweisen, wodurch Antwortketten ermöglicht werden. Die API definiert keine spezifische Begrenzung der Verschachtelungstiefe.

**In welchem Koordinatensystem ist die Position eines Kommentar‑Markers auf einer Folie definiert?**

Die Marker‑Position wird durch Gleitkomma‑Koordinaten im Folien‑Koordinatensystem definiert, sodass Sie sie exakt auf der Folie platzieren können.