---
title: Zarządzanie komentarzami prezentacji w .NET
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/net/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdów
- dodaj komentarz
- dostęp do komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- skasuj komentarz
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj komentarzami prezentacji za pomocą Aspose.Slides dla .NET: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides dla .NET. Przedstawia główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu komentarza i metadanych, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W PowerPoint komentarze wyświetlane są jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst i powiązaną dyskusję.

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby udzielić informacji zwrotnej i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides dla .NET udostępnia następujące API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), która zapewnia dostęp do autorów komentarzy w prezentacji.
* Interfejs [ICommentCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/icommentcollection), który reprezentuje komentarze powiązane z poszczególnym autorem.
* Interfejs [IComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment), który dostarcza informacji o komentarzu, w tym o autorze, czasie utworzenia, położeniu i tekście.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/net/aspose.slides/commentauthor), która dostarcza informacji o autorze, w tym jego imię, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**
Poniższy przykład pokazuje, jak dodać komentarze do slajdów w prezentacji PowerPoint:

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

## **Uzyskiwanie dostępu do komentarzy slajdów**
Poniższy przykład pokazuje, jak uzyskać dostęp do istniejących komentarzy w prezentacji PowerPoint:

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

## **Odpowiadanie na komentarze**
Komentarz nadrzędny to oryginalny komentarz na szczycie hierarchii odpowiedzi. Właściwość [ParentComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment/properties/parentcomment) interfejsu [IComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment) umożliwia pobranie lub ustawienie komentarza nadrzędnego.

Poniższy przykład pokazuje, jak dodać odpowiedzi i przejrzeć powstałą hierarchię komentarzy:

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

* Gdy metoda [Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment/methods/remove) interfejsu [IComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli właściwość [ParentComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icomment/properties/parentcomment) tworzy odwołanie cykliczne, zgłaszany jest [PptxEditException](https://reference.aspose.com/slides/pl/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, z konkretnym kształtem lub z zakresem tekstu wewnątrz AutoShape. Metoda [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/pl/net/aspose.slides/icommentcollection/addmoderncomment/) przyjmuje argument [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy jako argument kształtu przekazane zostanie `null`, komentarz jest komentarzem poziomu slajdu. Jego znacznik jest pozycjonowany za pomocą podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [IModernComment.Shape](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/shape/) zwraca `null`. Gdy podany zostanie [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/), komentarz jest zakotwiczony do tego kształtu. Współrzędne nadal określają pozycję znacznika komentarza na slajdzie, a powiązanie kształtu można odczytać przez [IModernComment.Shape](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/shape/).

### **Zakotwiczenie nowoczesnego komentarza w kształcie**

Poniższy przykład tworzy zarówno nowoczesny komentarz poziomu slajdu, jak i nowoczesny komentarz zakotwiczony do konkretnego AutoShape. Następnie odczytuje powiązany kształt z każdego komentarza.

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

### **Zakotwiczenie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu implementujący [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) może być użyty jako kotwica kształtu. Typowe przykłady to [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/pl/net/aspose.slides/iconnector/) oraz instancje [IGraphicalObject](https://reference.aspose.com/slides/pl/net/aspose.slides/igraphicalobject/) takie jak wykresy.

Poniższy przykład tworzy kilka typowych kształtów i powiązuje z każdym z nich nowoczesny komentarz.

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

### **Zakotwiczenie komentarza do tekstu i ustawienie jego statusu**

Dla nowoczesnego komentarza powiązanego z [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/), właściwość [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/textselectionstart/) określa początkową pozycję wybranego tekstu w ramce tekstowej kształtu, natomiast [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/textselectionlength/) określa długość zaznaczenia. Razem te właściwości powiązują komentarz z określonym zakresem tekstu wewnątrz AutoShape.

Właściwość [IModernComment.Status](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/status/) może być odczytywana lub aktualizowana przy użyciu wartości z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/pl/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — nie zdefiniowano konkretnego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Poniższy przykład tworzy nowoczesny komentarz zakotwiczony w kształcie, powiązuje go z zaznaczeniem tekstu, oznacza jako rozwiązany, zapisuje prezentację i weryfikuje wartości po ponownym otwarciu pliku.

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

### **Przeglądanie istniejących nowoczesnych komentarzy**

Aby przejrzeć istniejącą prezentację, sprawdź, które komentarze implementują [IModernComment](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/), a następnie zbadaj [IModernComment.Shape](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/textselectionlength/) i [IModernComment.Status](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/status/). `null` w polu shape wskazuje na komentarz poziomu slajdu. Dla kotwicy typu [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) właściwości wyboru tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

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

## **Usuwanie komentarzy**

### **Usuwanie wszystkich komentarzy i autorów komentarzy**

Poniższy przykład pokazuje, jak usunąć wszystkie komentarze i autorów komentarzy z prezentacji:

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

### **Usuwanie wybranych komentarzy**

Poniższy przykład pokazuje, jak usunąć wybrane komentarze z slajdu:

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

**Czy Aspose.Slides obsługuje status rozwiązany dla nowoczesnych komentarzy?**

Tak. [IModernComment.Status](https://reference.aspose.com/slides/pl/net/aspose.slides/imoderncomment/status/) może być odczytywany i ustawiany przy użyciu wartości [ModernCommentStatus](https://reference.aspose.com/slides/pl/net/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany ponownie po ponownym otwarciu pliku.

**Czy obsługiwane są dyskusje wątkowe (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/net/aspose.slides/comment/parentcomment/), co umożliwia tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest definiowana za pomocą współrzędnych zmiennoprzecinkowych w systemie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.