---
title: Zarządzanie komentarzami w prezentacji w .NET
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
  - odpowiedź na komentarz
  - usuń komentarz
  - kasuj komentarz
  - PowerPoint
  - prezentacja
  - .NET
  - C#
  - Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji za pomocą Aspose.Slides dla .NET: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides dla .NET. Przedstawia główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w programie PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu komentarza i metadanych, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W programie PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst oraz powiązaną dyskusję.

Aby żądać, aby komentarze były wyświetlane lub ukrywane podczas otwierania prezentacji bez zmiany samych komentarzy, zobacz [Pokaż lub ukryj komentarze podczas otwierania prezentacji](/slides/pl/net/presentation-view-properties/).

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby udzielać informacji zwrotnej i współpracować z współpracownikami podczas przeglądania prezentacji.

Aspose.Slides for .NET udostępnia następujące interfejsy API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) zapewnia dostęp do autorów komentarzy w prezentacji.
* Interfejs [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) reprezentuje komentarze powiązane z pojedynczym autorem.
* Interfejs [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) zapewnia informacje o komentarzu, w tym jego autora, czas utworzenia, pozycję i tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) zapewnia informacje o autorze, w tym jego imię, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Przykład tworzy dwa slajdy i rejestruje autora komentarza przy użyciu [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Używa [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) aby umieścić jeden komentarz na każdym slajdzie, a następnie pobiera komentarze pierwszego slajdu dla tego autora przy pomocy [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). Konsola wyświetla tekst pierwszego komentarza dwa razy, demonstrując dostęp zarówno poprzez slajd, jak i autora, a zapisowana prezentacja zawiera oba komentarze.

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

## **Znajdź lub utwórz autora komentarza**

Gdy automatyczny przegląd wielokrotnie przetwarza tę samą prezentację, przed dodaniem autora przeszukaj jej kolekcję [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) dopasowuje zarówno nazwę, jak i inicjały i zwraca tablicę pasujących autorów lub pustą tablicę, jeśli brak dopasowań. Natomiast [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) wyszukuje tylko po nazwie, niezależnie od inicjałów. Wywołanie [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) z nazwą i inicjałami już istniejącymi w kolekcji powoduje wyrzucenie wyjątku.

Przykład wymaga pliku prezentacji z co najmniej jednym slajdem. W każdym z dwóch przebiegów ponownie używa pierwszego pasującego autora lub tworzy nowego tylko wtedy, gdy wynik jest pusty. Jeśli istnieje wiele dopasowań, wybiera pierwszy element tablicy bez łączenia lub usuwania pozostałych autorów. Następnie wywołuje [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) dla wybranego autora i zapisuje prezentację. Drugi przebieg otwiera wynik pierwszego przebiegu i powtarza operację.

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

Drugi przebieg dodaje kolejny komentarz bez dodawania kolejnego autora ani usuwania istniejących komentarzy. Końcowy plik `review_pass_2.pptx` zawiera oba nowe komentarze wraz z wszelkimi oryginalnymi komentarzami. Ponowne użycie autora nie powoduje deduplikacji komentarzy: aby uniknąć wielokrotnego dodawania tego samego komentarza, przed jego dodaniem należy zaimplementować oddzielne wykrywanie duplikatów.

## **Uzyskiwanie dostępu do komentarzy slajdów**

Przykład otwiera istniejącą prezentację i odczytuje jej kolekcję [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Dla każdego autora iteruje po [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) i wypisuje numer slajdu, tekst komentarza, nazwę autora oraz czas utworzenia. Prezentacja wejściowa musi zawierać komentarze, aby wygenerować wyjście w konsoli.

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

## **Odpowiedź na komentarze**

Komentarz nadrzędny to oryginalny komentarz na szczycie hierarchii odpowiedzi. Właściwość [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) interfejsu [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) umożliwia pobranie lub ustawienie nadrzędnego komentarza.

Przykład tworzy komentarze od dwóch autorów i używa [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) do budowania odpowiedzi, w tym odpowiedzi na inną odpowiedź. Przekazanie `null` do [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) pobiera komentarze od wszystkich autorów; konsola wcięci każdy wpis zgodnie z jego głębokością w hierarchii odpowiedzi. Przykład zapisuje pełną dyskusję, wywołuje [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) na pierwszym komentarzu głównym i zapisuje drugą prezentację z usuniętym tym komentarzem oraz jego odpowiedziami.

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
* Gdy metoda [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) interfejsu [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli właściwość [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) tworzy referencję okrągłą, zostaje wyrzucony [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane ze slajdem, konkretnym kształtem lub zakresem tekstu wewnątrz AutoShape. Metoda [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) przyjmuje argument [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), oprócz slajdu i współrzędnych znacznika komentarza.

Gdy `null` jest przekazywany jako argument shape, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany według podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) zwraca `null`. Gdy podany zostanie [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), komentarz jest zakotwiczony do tego kształtu. Współrzędne nadal określają pozycję znacznika komentarza na slajdzie, a powiązanie kształtu można odczytać przez [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Przypięcie nowoczesnego komentarza do kształtu**

Przykład wywołuje [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) dwa razy: raz z `null` shape dla komentarza na poziomie slajdu i raz z prostokątem jako kotwicą. Odczyt [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) wypisuje `True` dla sprawdzenia `null` w komentarzu na poziomie slajdu oraz `Revenue title` dla komentarza zakotwiczonego. Oba komentarze są zapisywane razem z prezentacją.

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

### **Przypinanie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu implementujący [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) może być użyty jako kotwica kształtu. Typowe przykłady obejmują [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) oraz [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) takie jak wykresy.

Przykład używa [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) do powiązania komentarza z pięcioma typami kształtów: AutoShape, ramką obrazu, grupą, łącznikiem i wykresem. Obraz jest osadzony w danych obrazu, więc nie wymaga zewnętrznego pliku. Każdy komentarz ma własną pozycję znacznika, a zapisana prezentacja zachowuje wszystkie pięć powiązań kształtów.

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

### **Przypięcie komentarza do tekstu i ustawienie jego statusu**

Dla nowoczesnego komentarza powiązanego z [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) określa początkową pozycję zaznaczonego tekstu w ramce tekstowej kształtu, a [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) określa długość zaznaczenia. Razem te właściwości powiązują komentarz z konkretnym zakresem tekstu wewnątrz AutoShape.

Właściwość [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) może być odczytana lub zaktualizowana wartością z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — nie określono konkretnego statusu nowoczesnego komentarza.
- `Active` — komentarz jest aktywny.
- `Resolved` — komentarz został rozwiązany.
- `Closed` — komentarz jest zamknięty.

Przykład zakotwicza nowoczesny komentarz do słów „quarterly revenue” w tekście prostokąta. Oblicza zerowo‑indeksowy [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) z tekstu i ustawia [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) na liczbę zaznaczonych znaków. Po ustawieniu [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) na `Resolved` zapisuje i ponownie otwiera prezentację. Cztery sprawdzenia w konsoli powinny kolejno wypisać `True`, potwierdzając zachowanie kotwicy kształtu, zakresu tekstu i statusu.

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

### **Inspekcja istniejących nowoczesnych komentarzy**

Przykład wymaga istniejącej prezentacji zawierającej nowoczesne komentarze i wypisuje ich tekst, status oraz szczegóły kotwicy. Aby je zbadać, sprawdź, które komentarze implementują [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), a następnie przeanalizuj [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) i [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). `null` shape wskazuje na komentarz na poziomie slajdu. Dla kotwicy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) właściwości wyboru tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

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

Aspose.Slides for .NET pozwala usuwać wszystkie komentarze i ich autorów z prezentacji lub usuwać wybrane komentarze, pozostawiając resztę. Poniższe przykłady demonstrują oba podejścia i zapisują zaktualizowaną prezentację.

### **Usunięcie wszystkich komentarzy i autorów komentarzy**

Przykład otwiera istniejącą prezentację i wywołuje [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) dla każdego autora, a następnie wywołuje [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) w celu usunięcia samych autorów. Zapisana prezentacja nie zawiera żadnych komentarzy ani ich autorów. Użyj prezentacji zawierającej komentarze, aby zobaczyć efekt usunięcia.

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

### **Usunięcie konkretnych komentarzy**

Przykład tworzy dwa komentarze na jednym slajdzie i używa [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) aby znaleźć komentarze każdego autora. Zbiera komentarze, których tekst równa się "comment 1", zanim wywoła [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), unikając modyfikacji kolekcji w trakcie wyboru. Zapisana prezentacja zachowuje tylko "comment 2".

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

Tak. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) może być odczytany i ustawiony wartością z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany ponownie po ponownym otwarciu pliku.

**Czy wątki dyskusji (łańcuchy odpowiedzi) są obsługiwane i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), umożliwiając łańcuchy odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych określona jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest określana przez współrzędne zmiennoprzecinkowe w systemie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.