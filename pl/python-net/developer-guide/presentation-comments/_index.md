---
title: Zarządzanie komentarzami prezentacji w Pythonie
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/python-net/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdu
- dodaj komentarz
- uzyskaj dostęp do komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- skasuj komentarz
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji za pomocą Aspose.Slides for Python via .NET: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy użyciu Aspose.Slides for Python via .NET. Wprowadza główne typy związane z komentarzami i pokazuje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu komentarza i metadanych, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst i powiązaną dyskusję.

Aby żądać, aby komentarze były wyświetlane lub ukryte podczas otwierania prezentacji bez zmiany samych komentarzy, zobacz [Show or Hide Comments When Opening a Presentation](/slides/pl/python-net/presentation-view-properties/).

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby zapewnić opinię i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for Python via .NET provides the following APIs for working with comments:

* Klasa [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) zapewnia dostęp do autorów komentarzy prezentacji.
* Klasa [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) reprezentuje komentarze powiązane z pojedynczym autorem.
* Klasa [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) dostarcza informacje o komentarzu, w tym o jego autorze, czasie utworzenia, pozycji i tekście.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) dostarcza informacje o autorze, w tym jego nazwę, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Przykład tworzy dwa slajdy i rejestruje autora komentarza przy użyciu [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Używa [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) do umieszczenia jednego komentarza na każdym slajdzie, a potem pobiera komentarze pierwszego slajdu dla tego autora przy użyciu [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). Konsola wyświetla tekst pierwszego komentarza dwa razy, demonstrując dostęp zarówno przez slajd, jak i autora, a zapisana prezentacja zawiera oba komentarze.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Znajdź lub utwórz autora komentarza**

Gdy automatyczny przegląd wielokrotnie przetwarza tę samą prezentację, przed dodaniem autora przeszukaj jego kolekcję [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Metoda [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) dopasowuje zarówno nazwę, jak i inicjały i zwraca tablicę pasujących autorów lub pustą tablicę, jeśli nie ma dopasowań. Natomiast [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) wyszukuje tylko po nazwie, niezależnie od inicjałów. Wywołanie [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) z nazwą i inicjałami już istniejącymi w kolekcji powoduje wyrzucenie wyjątku.

Przykład wymaga pliku prezentacji z co najmniej jednym slajdem. W każdej z dwóch iteracji ponownie używa pierwszego dopasowanego autora lub tworzy nowego tylko wtedy, gdy wynik jest pusty. Jeśli istnieje wiele dopasowań, wybiera pierwszy element tablicy bez łączenia ani usuwania pozostałych autorów. Następnie wywołuje [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) dla wybranego autora i zapisuje prezentację. Druga iteracja otwiera wynik pierwszej iteracji i powtarza operację.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

Druga iteracja dodaje kolejny komentarz bez dodawania nowego autora ani usuwania istniejących komentarzy. Końcowy plik, `review_pass_2.pptx`, zawiera oba nowe komentarze obok wszelkich oryginalnych komentarzy. Ponowne użycie autora nie deduplikuje komentarzy: aby uniknąć wielokrotnego dodawania tego samego komentarza, zaimplementuj oddzielne wykrywanie duplikatów przed jego dodaniem.

## **Dostęp do komentarzy slajdu**

Przykład otwiera istniejącą prezentację i odczytuje jej kolekcję [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Dla każdego autora iteruje po [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) i wypisuje numer slajdu, tekst komentarza, imię autora oraz czas utworzenia. Wejściowa prezentacja musi zawierać komentarze, aby wygenerować wyjście w konsoli.

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Odpowiadanie na komentarze**

Komentarz nadrzędny to pierwotny komentarz na szczycie hierarchii odpowiedzi. Właściwość [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) klasy [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) pozwala pobrać lub ustawić nadrzędny komentarz.

Przykład tworzy komentarze od dwóch autorów i używa [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) do budowania odpowiedzi, włączając odpowiedź na inną odpowiedź. Przekazanie `None` do [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) pobiera komentarze od wszystkich autorów; konsola wcięć każdą pozycję zgodnie z jej głębokością w hierarchii odpowiedzi. Przykład zapisuje pełną dyskusję, wywołuje [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) na pierwszym komentarzu głównym i zapisuje drugą prezentację z usuniętymi tym komentarzem i jego odpowiedziami.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Gdy metoda [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) klasy [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli właściwość [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) tworzy odniesienie cykliczne, zostaje wyrzucony [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, z konkretnym kształtem lub z zakresem tekstu wewnątrz AutoShape. Metoda [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) przyjmuje argument [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy dla argumentu shape przekazany jest `None`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany przy użyciu podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) zwraca `None`. Gdy podany zostanie [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), komentarz jest zakotwiczony w tym kształcie. Współrzędne nadal definiują pozycję znacznika komentarza na slajdzie, a powiązanie z kształtem można odczytać poprzez [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Umocowanie nowoczesnego komentarza do kształtu**

Przykład wywołuje [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) dwa razy: raz z kształtem `None` dla komentarza na poziomie slajdu i raz z prostokątem jako kotwicą. Odczytanie [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) wypisuje `True` dla sprawdzenia null komentarza na poziomie slajdu i `Revenue title` dla komentarza zakotwiczonego. Oba komentarze są zapisywane w prezentacji.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Umocowanie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu pochodzący od [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) może być użyty jako kotwica kształtu. Typowe przykłady to [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) oraz instancje [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) takie jak wykresy.

Przykład używa [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) do powiązania komentarza z każdym z pięciu typów kształtów: AutoShape, ramką obrazu, grupą, łącznikiem i wykresem. Obraz jest osadzony w danych obrazu, więc nie jest wymagana zewnętrzna grafika. Każdy komentarz ma własną pozycję znacznika, a zapisana prezentacja zachowuje wszystkie pięć powiązań kształtów.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Umocowanie komentarza do tekstu i ustawienie jego statusu**

Dla nowoczesnego komentarza powiązanego z [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), właściwość [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) określa początkową pozycję zaznaczonego tekstu w ramce tekstowej kształtu, a [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) określa długość zaznaczenia. Razem te właściwości powiązują komentarz z określonym zakresem tekstu wewnątrz AutoShape.

Właściwość [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) może być odczytana lub zaktualizowana przy użyciu wartości z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — nie określono konkretnego statusu nowoczesnego komentarza.
- `ACTIVE` — komentarz jest aktywny.
- `RESOLVED` — komentarz został rozwiązany.
- `CLOSED` — komentarz jest zamknięty.

Przykład zakotwicza nowoczesny komentarz do słów „quarterly revenue” w tekście prostokąta. Oblicza zerowo‑bazowy [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) z tekstu i ustawia [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) na liczbę wybranych znaków. Po ustawieniu [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) na `RESOLVED` zapisuje i ponownie otwiera prezentację. Cztery kontrole w konsoli powinny wypisać `True`, potwierdzając zachowanie kotwicy kształtu, zakresu tekstu i statusu.

```python
from datetime import datetime

import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = slides.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Inspekcja istniejących nowoczesnych komentarzy**

Przykład wymaga istniejącej prezentacji zawierającej nowoczesne komentarze i wypisuje ich tekst, status oraz szczegóły kotwicy. Aby je przejrzeć, sprawdź, które komentarze są instancjami [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), a następnie zbadaj [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) i [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). `None` kształt wskazuje na komentarz na poziomie slajdu. Dla kotwicy typu [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) właściwości wyboru tekstu identyfikują powiązany zakres w ramce tekstowej kształtu.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Usuwanie komentarzy**

Aspose.Slides for Python via .NET pozwala usunąć wszystkie komentarze i ich autorów z prezentacji lub usunąć wybrane komentarze, zachowując pozostałe. Poniższe przykłady demonstrują oba podejścia i zapisują zaktualizowaną prezentację.

### **Usuwanie wszystkich komentarzy i autorów komentarzy**

Przykład otwiera istniejącą prezentację i wywołuje [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) dla każdego autora, a następnie wywołuje [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) w celu usunięcia samych autorów. Zapisana prezentacja nie zawiera ani komentarzy, ani ich autorów. Użyj prezentacji zawierającej komentarze, aby zaobserwować usunięcie.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Usuwanie wybranych komentarzy**

Przykład tworzy dwa komentarze na jednym slajdzie i używa [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) do znalezienia komentarzy każdego autora. Zbiera komentarze, których tekst równa się „comment 1”, przed wywołaniem [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), aby uniknąć zmian w kolekcji podczas wyboru. Zapisana prezentacja zachowuje tylko „comment 2”.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy Aspose.Slides obsługuje status rozwiązany dla nowoczesnych komentarzy?**

Tak. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) może być odczytany i ustawiony przy użyciu wartości z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), w tym `RESOLVED`. Status jest przechowywany w prezentacji i może być ponownie odczytany po ponownym otwarciu pliku.

**Czy obsługiwane są dyskusje wątki (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), umożliwiając tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnego limitu głębokości zagnieżdżenia.

**W jakim układzie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest definiowana przez współrzędne zmiennoprzecinkowe w układzie współrzędnych slajdu, co umożliwia precyzyjne umieszczenie go na slajdzie.