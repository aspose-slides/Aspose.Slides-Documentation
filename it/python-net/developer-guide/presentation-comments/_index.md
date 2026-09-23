---
title: Gestire i commenti della presentazione in Python
linktitle: Commenti della presentazione
type: docs
weight: 100
url: /it/python-net/presentation-comments/
keywords:
- commento
- commento moderno
- commenti PowerPoint
- commenti della presentazione
- commenti della diapositiva
- aggiungere commento
- accedere al commento
- modificare commento
- rispondere al commento
- rimuovere commento
- eliminare commento
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestire i commenti della presentazione con Aspose.Slides per Python tramite .NET: aggiungere, leggere, modificare, rispondere e rimuovere i commenti nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti di una presentazione con Aspose.Slides per Python tramite .NET. Introduce i principali tipi correlati ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con le risposte e i commenti moderni, e rimuovere i commenti da una presentazione.

Gli esempi coprono scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il testo e i metadati dei commenti, costruire catene di risposte e rimuovere commenti selezionati o tutti i commenti.

In PowerPoint, i commenti compaiono come annotazioni sulle diapositive. Selezionare un commento visualizza il suo testo e la discussione correlata.

Per richiedere che i commenti siano mostrati o nascosti all’apertura di una presentazione senza modificarne il contenuto, vedere [Show or Hide Comments When Opening a Presentation](/slides/it/python-net/presentation-view-properties/).

## **Perché aggiungere commenti alle presentazioni?**

È possibile utilizzare i commenti per fornire feedback e collaborare con i colleghi durante la revisione delle presentazioni.

Aspose.Slides per Python tramite .NET fornisce le seguenti API per lavorare con i commenti:

* La classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) che fornisce l'accesso agli autori dei commenti della presentazione.
* La classe [CommentCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentcollection/) che rappresenta i commenti associati a un singolo autore.
* La classe [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) che fornisce informazioni su un commento, inclusi autore, data di creazione, posizione e testo.
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentauthor/) che fornisce informazioni su un autore, inclusi nome, iniziali e commenti associati.

## **Aggiungere commenti alle diapositive**

L’esempio seguente mostra come aggiungere commenti alle diapositive in una presentazione PowerPoint:

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

## **Accedere ai commenti delle diapositive**

L’esempio seguente mostra come accedere ai commenti esistenti in una presentazione PowerPoint:

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

## **Rispondere ai commenti**

Un commento genitore è il commento originale in cima a una gerarchia di risposte. La proprietà [parent_comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/parent_comment/) della classe [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) consente di ottenere o impostare il genitore di un commento.

L’esempio seguente mostra come aggiungere risposte e ispezionare la gerarchia di commenti risultante:

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

{{% alert color="warning" title="Warning" %}}
* Quando il metodo [remove](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/remove/) della classe [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) viene utilizzato per eliminare un commento, tutte le risposte a quel commento vengono cancellate.
* Se la proprietà [parent_comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/parent_comment/) crea un riferimento circolare, viene generata un’eccezione [PptxEditException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Aggiungere commenti moderni**

I commenti moderni possono essere associati alla diapositiva stessa, a una forma specifica o a un intervallo di testo all’interno di un’AutoShape. Il metodo [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentcollection/add_modern_comment/) accetta un argomento [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) in aggiunta alla diapositiva e alle coordinate del marcatore del commento.

Quando viene passato `None` per l’argomento shape, il commento è a livello di diapositiva. Il suo marcatore è posizionato dalle coordinate fornite, ma non è associato a una forma particolare, quindi [ModernComment.shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/shape/) restituisce `None`. Quando viene fornita una [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/), il commento è ancorato a quella forma. Le coordinate continuano a definire la posizione del marcatore del commento sulla diapositiva, mentre l’associazione alla forma può essere recuperata tramite [ModernComment.shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/shape/).

### **Ancorare un commento moderno a una forma**

L’esempio seguente crea sia un commento moderno a livello di diapositiva sia un commento moderno ancorato a una AutoShape specifica. Quindi legge la forma associata a ciascun commento.

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

### **Ancorare commenti a diversi tipi di forma**

Qualsiasi oggetto diapositiva derivato da [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) può essere usato come ancora di forma. Esempi comuni includono [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/it/python-net/aspose.slides/connector/) e [GraphicalObject](https://reference.aspose.com/slides/it/python-net/aspose.slides/graphicalobject/) come grafici.

L’esempio seguente crea diversi tipi di forma comuni e associa a ciascuno un commento moderno.

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

### **Ancorare un commento a un testo e impostarne lo stato**

Per un commento moderno associato a un’[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/), la proprietà [ModernComment.text_selection_start](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/text_selection_start/) specifica la posizione iniziale del testo selezionato nel frame di testo della forma, mentre [ModernComment.text_selection_length](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/text_selection_length/) specifica la lunghezza della selezione. Insieme, queste proprietà associano il commento a un intervallo di testo specifico all’interno dell’AutoShape.

La proprietà [ModernComment.status](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/status/) può essere letta o aggiornata con un valore dell’enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — nessuno stato specifico del commento moderno è definito.
- `ACTIVE` — il commento è attivo.
- `RESOLVED` — il commento è stato risolto.
- `CLOSED` — il commento è chiuso.

L’esempio seguente crea un commento moderno ancorato a una forma, lo associa a una selezione di testo, lo segna come risolto, salva la presentazione e verifica i valori dopo aver riaperto il file.

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

### **Esaminare i commenti moderni esistenti**

Per esaminare una presentazione esistente, verificare quali commenti sono istanze di [ModernComment](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/), quindi esaminare [ModernComment.shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/text_selection_length/) e [ModernComment.status](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/status/). Una forma `None` indica un commento a livello di diapositiva. Per un’ancora [AutoShape], le proprietà di selezione del testo identificano l’intervallo associato nel frame di testo della forma.

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

## **Rimuovere i commenti**

### **Rimuovere tutti i commenti e gli autori dei commenti**

L’esempio seguente mostra come rimuovere tutti i commenti e gli autori dei commenti da una presentazione:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Rimuovere commenti specifici**

L’esempio seguente mostra come rimuovere commenti specifici da una diapositiva:

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

**Aspose.Slides supporta uno stato risolto per i commenti moderni?**

Sì. La proprietà [ModernComment.status](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/status/) può essere letta e impostata con un valore di [ModernCommentStatus](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncommentstatus/), incluso `RESOLVED`. Lo stato è memorizzato nella presentazione e può essere letto nuovamente dopo aver riaperto il file.

**Le discussioni a thread (catene di risposte) sono supportate e c’è un limite di nidificazione?**

Sì. Ogni commento può fare riferimento al proprio [parent comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/parent_comment/), consentendo catene di risposte. L’API non definisce un limite specifico di profondità di nidificazione.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione del marcatore è definita da coordinate in virgola mobile nel sistema di coordinate della diapositiva, permettendo di posizionarlo con precisione sulla diapositiva.