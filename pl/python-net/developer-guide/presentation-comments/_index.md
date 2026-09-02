---
title: Zarządzanie komentarzami w prezentacji w Pythonie
linktitle: Komentarze prezentacji
type: docs
weight: 100
url: /pl/python-net/presentation-comments/
keywords:
- komentarz
- nowoczesny komentarz
- komentarze PowerPoint
- komentarze prezentacji
- komentarze slajdów
- dodaj komentarz
- odczyt komentarza
- edytuj komentarz
- odpowiedz na komentarz
- usuń komentarz
- kasuj komentarz
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj komentarzami w prezentacji za pomocą Aspose.Slides for Python via .NET: dodawaj, odczytuj, edytuj, odpowiadaj i usuwaj komentarze w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji przy pomocy Aspose.Slides for Python via .NET. Wprowadza główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami i nowoczesnymi komentarzami oraz usuwać komentarze z prezentacji.

Przykłady obejmują typowe scenariusze przeglądu i współpracy w PowerPoint, takie jak przypisywanie komentarzy do autorów, odczytywanie tekstu i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz usuwanie wybranych komentarzy lub wszystkich komentarzy.

W PowerPoint komentarze pojawiają się jako adnotacje na slajdach. Wybranie komentarza wyświetla jego tekst oraz powiązaną dyskusję.

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz używać komentarzy, aby przekazywać opinie i współpracować z kolegami podczas przeglądania prezentacji.

Aspose.Slides for Python via .NET udostępnia następujące API do pracy z komentarzami:

* Klasa [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) zapewnia dostęp do autorów komentarzy w prezentacji.
* Klasa [CommentCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/commentcollection/) reprezentuje komentarze powiązane z poszczególnym autorem.
* Klasa [Comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/) dostarcza informacji o komentarzu, w tym autora, czas utworzenia, pozycję i tekst.
* Klasa [CommentAuthor](https://reference.aspose.com/slides/pl/python-net/aspose.slides/commentauthor/) dostarcza informacji o autorze, w tym jego imię, inicjały i powiązane komentarze.

## **Dodawanie komentarzy do slajdów**

Poniższy przykład pokazuje, jak dodać komentarze do slajdów w prezentacji PowerPoint:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
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

## **Dostęp do komentarzy slajdów**

Poniższy przykład pokazuje, jak uzyskać dostęp do istniejących komentarzy w prezentacji PowerPoint:

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

Komentarz nadrzędny to oryginalny komentarz na szczycie hierarchii odpowiedzi. Właściwość [parent_comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/parent_comment/) klasy [Comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/) umożliwia pobranie lub ustawienie rodzica komentarza.

Poniższy przykład pokazuje, jak dodać odpowiedzi i sprawdzić powstałą hierarchię komentarzy:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Ostrzeżenie" %}}
* Gdy metoda [remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/remove/) klasy [Comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/) jest używana do usunięcia komentarza, wszystkie odpowiedzi na ten komentarz są również usuwane.
* Jeśli właściwość [parent_comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/parent_comment/) tworzy odniesienie cykliczne, zgłaszany jest [PptxEditException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Dodawanie nowoczesnych komentarzy**

Nowoczesne komentarze mogą być powiązane z samym slajdem, konkretnym kształtem lub zakresem tekstu wewnątrz AutoShape. Metoda [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/commentcollection/add_modern_comment/) przyjmuje argument [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) oprócz slajdu i współrzędnych znacznika komentarza.

Gdy jako argument shape przekazane zostanie `None`, komentarz jest komentarzem na poziomie slajdu. Jego znacznik jest pozycjonowany przy użyciu podanych współrzędnych, ale nie jest powiązany z konkretnym kształtem, więc [ModernComment.shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/shape/) zwraca `None`. Gdy podany zostanie [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/), komentarz jest przypięty do tego kształtu. Współrzędne nadal określają pozycję znacznika komentarza na slajdzie, natomiast powiązanie z kształtem można odczytać przez [ModernComment.shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/shape/).

### **Przypięcie nowoczesnego komentarza do kształtu**

Poniższy przykład tworzy zarówno nowoczesny komentarz na poziomie slajdu, jak i nowoczesny komentarz przytwierdzony do konkretnego AutoShape. Następnie odczytuje powiązany kształt z każdego komentarza.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Przypinanie komentarzy do różnych typów kształtów**

Każdy obiekt slajdu dziedziczący po [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) może być użyty jako kotwica kształtu. Typowe przykłady to [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/pl/python-net/aspose.slides/connector/) oraz instancje [GraphicalObject](https://reference.aspose.com/slides/pl/python-net/aspose.slides/graphicalobject/) takie jak wykresy.

Poniższy przykład tworzy kilka typowych kształtów i powiązuje z każdym z nich nowoczesny komentarz.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Przypięcie komentarza do tekstu i ustawienie jego statusu**

W przypadku nowoczesnego komentarza powiązanego z [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/), właściwość [ModernComment.text_selection_start](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/text_selection_start/) określa początkową pozycję wybranego tekstu w ramce tekstowej kształtu, natomiast [ModernComment.text_selection_length](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/text_selection_length/) określa długość wyboru. Razem te właściwości łączą komentarz z konkretnym zakresem tekstu wewnątrz AutoShape.

Właściwość [ModernComment.status](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/status/) może być odczytana lub zaktualizowana przy użyciu wartości z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — nie określono konkretnego statusu nowoczesnego komentarza.
- `ACTIVE` — komentarz jest aktywny.
- `RESOLVED` — komentarz został rozwiązany.
- `CLOSED` — komentarz jest zamknięty.

Poniższy przykład tworzy nowoczesny komentarz przytwierdzony do kształtu, powiązuje go z zaznaczeniem tekstu, oznacza jako rozwiązany, zapisuje prezentację i weryfikuje wartości po ponownym otwarciu pliku.

```python
from datetime import datetime

import aspose.pydrawing as draw
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
    comment_position = draw.PointF(60, 60)
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

### **Sprawdzanie istniejących nowoczesnych komentarzy**

Aby zbadać istniejącą prezentację, sprawdź, które komentarze są instancjami [ModernComment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/), a następnie przeanalizuj [ModernComment.shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/text_selection_length/) i [ModernComment.status](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/status/). Kształt `None` oznacza komentarz na poziomie slajdu. W przypadku kotwicy [AutoShape] właściwości wyboru tekstu określają powiązany zakres w ramce tekstowej kształtu.

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

### **Usuwanie wszystkich komentarzy i autorów komentarzy**

Poniższy przykład pokazuje, jak usunąć wszystkie komentarze i autorów komentarzy z prezentacji:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Usuwanie wybranych komentarzy**

Poniższy przykład pokazuje, jak usunąć wybrane komentarze ze slajdu:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
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

**Czy Aspose.Slides obsługuje status „rozwiązany” dla nowoczesnych komentarzy?**

Tak. Właściwość [ModernComment.status](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/status/) może być odczytana i ustawiona przy użyciu wartości z wyliczenia [ModernCommentStatus](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncommentstatus/), w tym `RESOLVED`. Status jest przechowywany w prezentacji i może być odczytany po ponownym otwarciu pliku.

**Czy obsługiwane są wątki dyskusji (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/parent_comment/), umożliwiając tworzenie łańcuchów odpowiedzi. API nie definiuje konkretnych ograniczeń głębokości zagnieżdżenia.

**W jakim układzie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja znacznika jest definiowana przez współrzędne zmiennoprzecinkowe w układzie współrzędnych slajdu, co pozwala precyzyjnie umieścić go na slajdzie.