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
- dostęp do komentarza
- edytuj komentarz
- odpowiedź na komentarz
- usuń komentarz
- kasuj komentarz
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj zarządzanie komentarzami w prezentacjach przy użyciu Aspose.Slides for Python via .NET: dodawaj, odczytuj, edytuj i usuwaj komentarze w plikach PowerPoint szybko i łatwo."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać komentarzami w prezentacji w Aspose.Slides. Pokazuje główne typy związane z komentarzami i demonstruje, jak dodawać komentarze do slajdów, uzyskiwać dostęp do istniejących komentarzy, pracować z odpowiedziami, używać nowoczesnych komentarzy oraz usuwać komentarze z prezentacji.

Przykłady koncentrują się na typowych scenariuszach przeglądu i współpracy w PowerPoint, takich jak przypisywanie komentarzy do autorów, odczytywanie treści i metadanych komentarzy, budowanie łańcuchów odpowiedzi oraz czyszczenie wszystkich komentarzy lub usuwanie wybranych.

W PowerPoint komentarz wyświetlany jest jako notatka lub adnotacja na slajdzie. Po kliknięciu komentarza wyświetlana jest jego zawartość lub wiadomości.

## **Dlaczego dodawać komentarze do prezentacji?**

Możesz chcieć używać komentarzy, aby przekazać opinie lub komunikować się z współpracownikami podczas przeglądania prezentacji.

Aby umożliwić korzystanie z komentarzy w prezentacjach PowerPoint, Aspose.Slides for Python via .NET udostępnia

* klasę [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), która zawiera kolekcję autorów (z właściwości [CommentAuthorCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/commentauthorcollection/)). Autorzy dodają komentarze do slajdów. 
* klasę [CommentCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/commentcollection/), która zawiera kolekcję komentarzy dla poszczególnych autorów. 
* klasę [Comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/), która zawiera informacje o autorach i ich komentarzach: kto dodał komentarz, kiedy został dodany, pozycję komentarza itp. 
* klasę [CommentAuthor](https://reference.aspose.com/slides/pl/python-net/aspose.slides/commentauthor/), która zawiera informacje o poszczególnych autorach: nazwę autora, jego inicjały, komentarze powiązane z nazwą autora itp. 

## **Dodaj komentarz do slajdu**
Ten kod w Pythonie pokazuje, jak dodać komentarz do slajdu w prezentacji PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Tworzy instancję klasy Presentation
with slides.Presentation() as presentation:
    # Dodaje pusty slajd
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Dodaje autora
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Ustawia pozycję dla komentarzy
    point = draw.PointF(0.2, 0.2)

    # Dodaje komentarz slajdu dla autora na slajdzie 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Dodaje komentarz slajdu dla autora na slajdzie 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Dostęp do ISlide 1
    slide = presentation.slides[0]

    # Gdy jako argument przekazany zostanie null, komentarze od wszystkich autorów są pobierane dla wybranego slajdu
    comments = slide.get_slide_comments(author)

    # Uzyskuje dostęp do komentarza o indeksie 0 dla slajdu 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Wybiera kolekcję komentarzy autora o indeksie 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **Uzyskaj dostęp do komentarzy slajdu**
Ten kod w Pythonie pokazuje, jak uzyskać dostęp do istniejącego komentarza na slajdzie w prezentacji PowerPoint:

```python
import aspose.slides as slides

# Tworzy instancję klasy Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **Odpowiadanie na komentarze**
Komentarz nadrzędny to górny lub oryginalny komentarz w hierarchii komentarzy lub odpowiedzi. Używając właściwości `parent_comment` (z klasy [Comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/)), możesz ustawić lub pobrać komentarz nadrzędny.

Ten kod w Pythonie pokazuje, jak dodać komentarze i pobrać odpowiedzi do nich:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Dodaje komentarz
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Dodaje odpowiedź do comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Dodaje kolejną odpowiedź do comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Dodaje odpowiedź do istniejącej odpowiedzi
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Wyświetla hierarchię komentarzy w konsoli
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # Usuwa comment1 i wszystkie odpowiedzi do niego
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Uwaga" %}} 

* Gdy metoda `remove` (z klasy [Comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/comment/)) jest używana do usunięcia komentarza, również usuwane są odpowiedzi na ten komentarz. 
* Jeśli ustawienie `parent_comment` powoduje odniesienie cykliczne, zostanie zgłoszony `PptxEditException`.

{{% /alert %}}

## **Dodaj nowoczesny komentarz**

W 2021 r. Microsoft wprowadził *nowoczesne komentarze* w PowerPoint. Funkcja nowoczesnych komentarzy znacznie usprawnia współpracę w PowerPoint. Dzięki nowoczesnym komentarzom użytkownicy PowerPoint mogą rozwiązywać komentarze, przypinać je do obiektów i tekstów oraz prowadzić interakcje znacznie łatwiej niż dotąd.

Wprowadziliśmy obsługę nowoczesnych komentarzy, dodając klasę [ModernComment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/). Do klasy [CommentCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/commentcollection/) dodano metody `add_modern_comment` i `insert_modern_comment`.

Ten kod w Pythonie pokazuje, jak dodać nowoczesny komentarz do slajdu w prezentacji PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuń komentarz**

### **Usuń wszystkie komentarze i autorów**

Ten kod w Pythonie pokazuje, jak usunąć wszystkie komentarze i autorów w prezentacji:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Usuwa wszystkie komentarze z prezentacji
    for author in presentation.comment_authors:
        author.comments.clear()

    # Usuwa wszystkich autorów
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Usuń wybrane komentarze**

Ten kod w Pythonie pokazuje, jak usunąć wybrane komentarze na slajdzie:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # dodaj komentarze...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # usuń wszystkie komentarze, które zawierają tekst "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy Aspose.Slides obsługuje status taki jak „rozwiązany” dla nowoczesnych komentarzy?**

Tak. [Modern comments](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/) udostępniają właściwość [status](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/status/); możesz odczytać i ustawić [stan komentarza](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncommentstatus/) (na przykład oznaczyć go jako rozwiązany), a stan ten jest zapisywany w pliku i rozpoznawany przez PowerPoint.

**Czy obsługiwane są wątki dyskusji (łańcuchy odpowiedzi) i czy istnieje limit zagnieżdżenia?**

Tak. Każdy komentarz może odwoływać się do swojego [parent comment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/moderncomment/parent_comment/), umożliwiając dowolne łańcuchy odpowiedzi. API nie określa konkretnego limitu głębokości zagnieżdżenia.

**W jakim systemie współrzędnych definiowana jest pozycja znacznika komentarza na slajdzie?**

Pozycja jest przechowywana jako punkt zmiennoprzecinkowy w systemie współrzędnych slajdu. Dzięki temu możesz umieścić znacznik komentarza dokładnie tam, gdzie jest potrzebny.