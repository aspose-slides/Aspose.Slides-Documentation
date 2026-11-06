---
title: Zarządzanie komentarzami w prezentacji w Pythonie via Java
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/python-java/presentation-comments/
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
- Python
- Java
- Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji przy użyciu Aspose.Slides for Python via Java: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides for Python via Java. Wprowadza główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu komentarza i metadanych, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W programie PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst oraz powiązaną dyskusję.

Aby żądać, aby komentarze były wyświetlane lub ukryte podczas otwierania prezentacji bez zmieniania samych komentarzy, zobacz [Pokaż lub ukryj komentarze przy otwieraniu prezentacji](/slides/pl/python-java/presentation-view-properties/).

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby przekazywać opinie i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for Python via Java udostępnia następujące interfejsy API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), która zapewnia dostęp do autorów komentarzy w prezentacji.
* Klasa [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/), która reprezentuje komentarze powiązane z poszczególnym autorem.
* Klasa [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/), która zapewnia informacje o komentarzu, w tym jego autora, czas utworzenia, pozycję i tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/), która zapewnia informacje o autorze, w tym jego imię, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Przykład tworzy dwa slajdy i rejestruje autora komentarza za pomocą [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Używa [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) aby umieścić po jeden komentarz na każdym slajdzie, a następnie pobiera komentarze pierwszego slajdu dla tego autora przy pomocy [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). Konsola wyświetla tekst pierwszego komentarza dwukrotnie, demonstrując dostęp zarówno przez slajd, jak i autora, a zapisana prezentacja zawiera oba komentarze.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))

    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Znajdź lub utwórz autora komentarza**

Podczas gdy automatyczny przegląd wielokrotnie przetwarza tę samą prezentację, przed dodaniem autora należy przeszukać kolekcję zwróconą przez [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) dopasowuje zarówno nazwę, jak i inicjały i zwraca tablicę pasujących autorów, lub pustą tablicę, jeśli nie ma dopasowań. Natomiast [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) wyszukuje tylko po nazwie, niezależnie od inicjałów. Wywołanie [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) z nazwą i inicjałami już istniejącymi w kolekcji powoduje wyrzucenie wyjątku.

Przykład wymaga pliku prezentacji z co najmniej jednym slajdem. W każdej z dwóch iteracji ponownie używa pierwszego pasującego autora lub tworzy nowego tylko wtedy, gdy wynik jest pusty. Jeśli istnieje wiele dopasowań, wybiera pierwszy element tablicy bez łączenia lub usuwania pozostałych autorów. Następnie wywołuje [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) dla wybranego autora i zapisuje prezentację. Druga iteracja otwiera wynik pierwszej iteracji i powtarza operację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

Druga iteracja dodaje kolejny komentarz bez dodawania kolejnego autora ani usuwania istniejących komentarzy. Końcowy plik, `review_pass_2.pptx`, zawiera oba nowe komentarze wraz z wszelkimi oryginalnymi komentarzami. Ponowne użycie autora nie deduplikuje komentarzy: aby uniknąć wielokrotnego dodawania tego samego komentarza, należy przed jego dodaniem wdrożyć osobną detekcję duplikatów.

## **Dostęp do komentarzy slajdów**

Przykład otwiera istniejącą prezentację i odczytuje kolekcję zwróconą przez [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Dla każdego autora iteruje po kolekcji zwróconej przez [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments), drukując numer slajdu, tekst komentarza, nazwę autora i czas utworzenia. Wejściowa prezentacja musi zawierać komentarze, aby wygenerować wyjście w konsoli.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Odpowiadanie na komentarze**

Komentarz nadrzędny to oryginalny komentarz na szczycie hierarchii odpowiedzi. Metody [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) i [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) umożliwiają pobranie lub ustawienie nadrzędnego komentarza.

Przykład tworzy komentarze od dwóch autorów i używa [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment), aby budować odpowiedzi, w tym odpowiedź na inną odpowiedź. Przekazanie `None` do [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) pobiera komentarze od wszystkich autorów; konsola wcięła każdy wpis zgodnie z głębokością w hierarchii odpowiedzi. Przykład zapisuje pełną dyskusję, wywołuje [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) na pierwszym komentarzu głównym i zapisuje drugą prezentację z usuniętym tym komentarzem oraz jego odpowiedziami.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* Gdy metoda [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz również zostają usunięte.
* Jeśli [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) tworzy referencję cykliczną, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, konkretnym kształtem lub zakresem tekstu wewnątrz [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Metoda [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) przyjmuje argument [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) oprócz współrzędnych slajdu i znacznika komentarza.

Gdy dla argumentu shape przekazany jest `None`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest umieszczany przy użyciu podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) zwraca `None`. Gdy podany jest [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), komentarz jest zakotwiczony do tego kształtu. Współrzędne nadal definiują pozycję znacznika komentarza na slajdzie, a powiązanie z kształtem można odczytać za pomocą [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Zakotwiczenie nowoczesnego komentarza do kształtu**

Przykład wywołuje [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) dwa razy: raz z kształtem `None` dla komentarza na poziomie slajdu i raz z prostokątem jako kotwicą. Odczytanie [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) wypisuje `True` dla sprawdzenia `None` komentarza na poziomie slajdu oraz `Revenue title` dla zakotwiczonego komentarza. Oba komentarze są zapisywane wraz z prezentacją.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zakotwicz komentarze do różnych typów kształtów**

Dowolny obiekt slajdu, który dziedziczy po [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), może być użyty jako kotwica kształtu. Powszechne przykłady to [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/) oraz instancje [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/), takie jak wykresy.

Przykład używa [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment), aby powiązać komentarz z każdym z pięciu typów kształtów: AutoShape, ramką obrazu, grupą, łącznikiem i wykresem. Obraz wykorzystuje wbudowane dane obrazu, więc nie wymaga zewnętrznego pliku graficznego. Każdy komentarz ma własną pozycję znacznika, a zapisana prezentacja zachowuje wszystkie pięć powiązań kształtów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")

    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zakotwicz komentarz do tekstu i ustaw jego status**

Dla nowoczesnego komentarza powiązanego z [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) oraz [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) służą do odczytu początkowej pozycji zaznaczonego tekstu w ramce tekstowej kształtu. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) i [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) odczytują długość zaznaczenia. Razem te wartości powiązują komentarz z określonym zakresem tekstu wewnątrz AutoShape.

[ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) i [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) odwołują się do wartości z stałych [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — nie zdefiniowano konkretnego statusu nowoczesnego komentarza.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — komentarz jest aktywny.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — komentarz został rozwiązany.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — komentarz jest zamknięty.

Przykład zakotwicza nowoczesny komentarz do słów „quarterly revenue” w tekście prostokąta. Oblicza zerową pozycję początkową zaznaczenia na podstawie tekstu i przekazuje ją do [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart), a następnie używa [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength), aby ustawić liczbę zaznaczonych znaków. Po wywołaniu [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) z wartością `Resolved`, zapisuje i ponownie otwiera prezentację. Cztery kontrole w konsoli powinny każda wypisać `True`, potwierdzając, że kotwica kształtu, zakres tekstu i status zostały zachowane.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Inspekcja istniejących nowoczesnych komentarzy**

Przykład wymaga istniejącej prezentacji zawierającej nowoczesne komentarze i wypisuje ich tekst, status oraz szczegóły kotwicy. Aby je zbadać, sprawdź, które komentarze są instancjami [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), a następnie przeanalizuj [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) oraz [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). Kształt `None` wskazuje na komentarz na poziomie slajdu. Dla kotwicy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), metody zaznaczania tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Usuwanie komentarzy**

Aspose.Slides for Python via Java umożliwia usunięcie wszystkich komentarzy i ich autorów z prezentacji lub usunięcie wybranych komentarzy przy zachowaniu pozostałych. Poniższe przykłady demonstrują oba podejścia i zapisują zaktualizowaną prezentację.

### **Usunięcie wszystkich komentarzy i autorów komentarzy**

Przykład otwiera istniejącą prezentację i wywołuje [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) dla każdego autora, a następnie wywołuje [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear), aby usunąć samych autorów. Zapisana prezentacja nie zawiera ani komentarzy, ani autorów komentarzy. Użyj prezentacji zawierającej komentarze, aby zaobserwować usunięcie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Usunięcie wybranych komentarzy**

Przykład tworzy dwa komentarze na jednym slajdzie i używa [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments), aby znaleźć komentarze od każdego autora. Zbiera komentarze, których tekst jest równy „comment 1” przed wywołaniem [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove), unikając zmian w kolekcji podczas wyboru. Zapisana prezentacja zachowuje tylko „comment 2”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy Aspose.Slides obsługuje status rozwiązany dla nowoczesnych komentarzy?**

Tak. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) i [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) odwołują się do wartości [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/), w tym `Resolved`. Status jest przechowywany w prezentacji i może być odczytany ponownie po ponownym otwarciu pliku.

**Czy wątki dyskusji (łańcuchy odpowiedzi) są obsługiwane i czy istnieje limit zagnieżdżania?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment), co umożliwia tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest definiowana za pomocą współrzędnych zmiennoprzecinkowych w systemie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.