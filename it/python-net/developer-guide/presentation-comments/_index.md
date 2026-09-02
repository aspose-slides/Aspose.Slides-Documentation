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
- aggiungi commento
- accedi al commento
- modifica commento
- rispondi al commento
- rimuovi commento
- elimina commento
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i commenti della presentazione con Aspose.Slides per Python via .NET: aggiungi, leggi, modifica, rispondi e rimuovi i commenti nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti della presentazione con Aspose.Slides for Python via .NET. Introduce i principali tipi relativi ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con le risposte e i commenti moderni, e rimuovere i commenti da una presentazione.

Gli esempi coprono scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il testo dei commenti e i metadati, creare catene di risposta e rimuovere commenti selezionati o tutti i commenti.

In PowerPoint, i commenti appaiono come annotazioni sulle diapositive. Selezionare un commento visualizza il suo testo e la discussione correlata.

## **Perché aggiungere commenti alle presentazioni?**

Puoi usare i commenti per fornire feedback e collaborare con i colleghi durante la revisione delle presentazioni.

* The [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.  
  * classe, che fornisce l'accesso agli autori dei commenti della presentazione.
* The [CommentCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.  
  * classe, che rappresenta i commenti associati a un singolo autore.
* The [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.  
  * classe, che fornisce informazioni su un commento, includendo il suo autore, l'ora di creazione, la posizione e il testo.
* The [CommentAuthor](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.  
  * classe, che fornisce informazioni su un autore, includendo il suo nome, le iniziali e i commenti associati.

## **Aggiungere commenti alle diapositive**

Il seguente esempio mostra come aggiungere commenti alle diapositive in una presentazione PowerPoint:

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

Il seguente esempio mostra come accedere ai commenti esistenti in una presentazione PowerPoint:

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

Un commento principale è il commento originale in cima a una gerarchia di risposte. La proprietà [parent_comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/parent_comment/) della classe [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) consente di ottenere o impostare il genitore di un commento.

Il seguente esempio mostra come aggiungere risposte e ispezionare la gerarchia di commenti risultante:

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
* Quando il metodo [remove](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/remove/) della classe [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) viene utilizzato per eliminare un commento, tutte le risposte a quel commento vengono eliminate.
* Se la proprietà [parent_comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/parent_comment/) crea un riferimento circolare, viene generata un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Aggiungere commenti moderni**

I commenti moderni possono essere associati alla diapositiva stessa, a una forma specifica o a un intervallo di testo all'interno di un'AutoShape. Il metodo [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentcollection/add_modern_comment/) accetta un argomento [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) oltre alla diapositiva e alle coordinate del marcatore del commento.

Quando `None` viene passato per l'argomento shape, il commento è un commento a livello di diapositiva. Il suo marcatore è posizionato dalle coordinate fornite, ma non è associato a una forma particolare, quindi [ModernComment.shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/shape/) restituisce `None`. Quando viene fornita una [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/), il commento è ancorato a quella forma. Le coordinate continuano a definire la posizione del marcatore del commento sulla diapositiva, mentre l'associazione alla forma può essere recuperata tramite [ModernComment.shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/shape/).

### **Ancorare un commento moderno a una forma**

Il seguente esempio crea sia un commento moderno a livello di diapositiva sia un commento moderno ancorato a una AutoShape specifica. Successivamente legge la forma associata da ciascun commento.

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

Qualsiasi oggetto della diapositiva derivato da [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) può essere usato come ancoraggio di forma. Esempi comuni includono istanze di [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/it/python-net/aspose.slides/connector/), e [GraphicalObject](https://reference.aspose.com/slides/it/python-net/aspose.slides/graphicalobject/) come grafici.

Il seguente esempio crea diversi tipi di forma comuni e associa a ciascuno un commento moderno.

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

Per un commento moderno associato a un'[AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/text_selection_start/) specifica la posizione iniziale del testo selezionato nel riquadro di testo della forma, mentre [ModernComment.text_selection_length](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/text_selection_length/) specifica la lunghezza della selezione. Insieme, queste proprietà associano il commento a un intervallo di testo specifico all'interno dell'AutoShape.

La proprietà [ModernComment.status](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/status/) può essere letta o impostata con un valore dall'enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — nessuno stato specifico di commento moderno è definito.
- `ACTIVE` — il commento è attivo.
- `RESOLVED` — il commento è stato risolto.
- `CLOSED` — il commento è chiuso.

Il seguente esempio crea un commento moderno ancorato a una forma, lo associa a una selezione di testo, lo segna come risolto, salva la presentazione e verifica i valori dopo aver riaperto il file.

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

### **Ispezionare i commenti moderni esistenti**

Per ispezionare una presentazione esistente, verifica quali commenti sono istanze di [ModernComment](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/), quindi esamina [ModernComment.shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/text_selection_length/), e [ModernComment.status](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/status/). Una forma `None` indica un commento a livello di diapositiva. Per un ancoraggio di [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/), le proprietà di selezione del testo identificano l'intervallo associato nel riquadro di testo della forma.

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

Il seguente esempio mostra come rimuovere tutti i commenti e gli autori dei commenti da una presentazione:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Rimuovere commenti specifici**

Il seguente esempio mostra come rimuovere commenti specifici da una diapositiva:

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

Sì. [ModernComment.status](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/status/) può essere letta e impostata con un valore [ModernCommentStatus](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncommentstatus/), incluso `RESOLVED`. Lo stato è memorizzato nella presentazione e può essere letto nuovamente dopo che il file è stato riaperto.

**Le discussioni a thread (catene di risposta) sono supportate e c'è un limite di annidamento?**

Sì. Ogni commento può fare riferimento al proprio [parent comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/parent_comment/), consentendo catene di risposta. L'API non definisce un limite specifico di profondità di annidamento.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione del marcatore è definita da coordinate in virgola mobile nel sistema di coordinate della diapositiva, consentendo di posizionarlo con precisione sulla diapositiva.