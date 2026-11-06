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
- commenti di presentazione
- commenti diapositiva
- aggiungi commento
- accedi commento
- modifica commento
- rispondi al commento
- rimuovi commento
- elimina commento
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i commenti della presentazione con Aspose.Slides per Python tramite .NET: aggiungi, leggi, modifica, rispondi a e rimuovi i commenti nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti delle presentazioni con Aspose.Slides per Python tramite .NET. Introduce i principali tipi relativi ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con risposte e commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi coprono scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il testo e i metadati dei commenti, costruire catene di risposte e rimuovere commenti selezionati o tutti i commenti.

In PowerPoint, i commenti appaiono come annotazioni sulle diapositive. Selezionare un commento mostra il suo testo e la discussione correlata.

Per richiedere che i commenti siano mostrati o nascosti all’apertura di una presentazione senza modificare i commenti stessi, vedere [Mostra o nascondi i commenti all'apertura di una presentazione](/slides/it/python-net/presentation-view-properties/).

## **Perché aggiungere commenti alle presentazioni?**

Puoi utilizzare i commenti per fornire feedback e collaborare con i colleghi durante la revisione delle presentazioni.

Aspose.Slides per Python tramite .NET fornisce le seguenti API per lavorare con i commenti:

* La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) fornisce l'accesso agli autori dei commenti della presentazione.
* La classe [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) rappresenta i commenti associati a un singolo autore.
* La classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) fornisce informazioni su un commento, inclusi autore, data di creazione, posizione e testo.
* La classe [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) fornisce informazioni su un autore, inclusi nome, iniziali e commenti associati.

## **Aggiungi commenti alle diapositive**

L’esempio crea due diapositive e registra un autore di commenti con [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Utilizza [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) per inserire un commento su ciascuna diapositiva, quindi recupera i commenti della prima diapositiva per quell’autore con [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). La console visualizza il testo del primo commento due volte, dimostrando l’accesso sia tramite la diapositiva sia tramite l’autore, e la presentazione salvata contiene entrambi i commenti.

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

## **Trova o crea un autore di commenti**

Quando una revisione automatizzata elabora la stessa presentazione più volte, cerca nella raccolta [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) prima di aggiungere un autore. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) confronta sia il nome sia le iniziali e restituisce un array di autori corrispondenti, o un array vuoto se non ci sono corrispondenze. Al contrario, [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) ricerca solo per nome, indipendentemente dalle iniziali. Chiamare [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) con un nome e iniziali già presenti nella raccolta genera un’eccezione.

L’esempio richiede un file di presentazione con almeno una diapositiva. In ciascuna delle due iterazioni, riutilizza il primo autore corrispondente, o ne crea uno solo quando il risultato è vuoto. Se ci sono più corrispondenze, seleziona il primo elemento dell’array senza unire o rimuovere gli altri autori. Quindi chiama [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) per l’autore selezionato e salva la presentazione. La seconda iterazione apre l’output della prima iterazione e ripete l’operazione.

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

La seconda iterazione aggiunge un altro commento senza aggiungere un nuovo autore né rimuovere i commenti esistenti. Il file finale, `review_pass_2.pptx`, contiene entrambi i nuovi commenti insieme a eventuali commenti originali. Riutilizzare un autore non deduplica i commenti: per evitare di aggiungere ripetutamente lo stesso commento, implementa un controllo di duplicati separato prima di aggiungerlo.

## **Accedi ai commenti delle diapositive**

L’esempio apre una presentazione esistente e legge la sua raccolta [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Per ogni autore, itera attraverso [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) e stampa il numero della diapositiva, il testo del commento, il nome dell’autore e la data di creazione. La presentazione di input deve contenere commenti per produrre output nella console.

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

## **Rispondi ai commenti**

Un commento genitore è il commento originale in cima a una gerarchia di risposte. La proprietà [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) della classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) consente di ottenere o impostare il genitore di un commento.

L’esempio crea commenti da due autori e utilizza [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) per costruire risposte, incluso una risposta a un’altra risposta. Passare `None` a [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) recupera i commenti da tutti gli autori; la console indentifica ogni voce in base alla profondità nella gerarchia di risposta. L’esempio salva la discussione completa, chiama [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) sul primo commento radice e salva una seconda presentazione con quel commento e le sue risposte rimosse.

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
* Quando il metodo [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) della classe [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) viene utilizzato per eliminare un commento, tutte le risposte a quel commento vengono eliminate.
* Se la proprietà [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) crea un riferimento circolare, viene generata un'eccezione [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Aggiungi commenti moderni**

I commenti moderni possono essere associati alla diapositiva stessa, a una forma specifica o a un intervallo di testo all’interno di un’AutoShape. Il metodo [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) accetta un argomento [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) oltre alla diapositiva e alle coordinate del marcatore del commento.

Quando a `None` viene passato per l’argomento shape, il commento è un commento a livello di diapositiva. Il suo marcatore è posizionato dalle coordinate fornite, ma non è associato a una forma specifica, quindi [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) restituisce `None`. Quando viene fornita una [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), il commento è ancorato a quella forma. Le coordinate continuano a definire la posizione del marcatore del commento sulla diapositiva, mentre l’associazione alla forma può essere recuperata tramite [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Ancorare un commento moderno a una forma**

L’esempio chiama [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) due volte: una volta con una forma `None` per un commento a livello di diapositiva e una volta con un rettangolo come ancora. Leggendo [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) stampa `True` per il controllo null del commento a livello di diapositiva e `Revenue title` per il commento ancorato. Entrambi i commenti vengono salvati con la presentazione.

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

### **Ancorare commenti a diversi tipi di forma**

Qualsiasi oggetto diapositiva derivato da [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) può essere usato come ancora di forma. Esempi comuni includono [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) e istanze [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) come grafici.

L’esempio utilizza [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) per associare un commento a ciascuno dei cinque tipi di forma: un AutoShape, un frame immagine, un gruppo, un connettore e un grafico. L’immagine è incorporata, quindi non è richiesta un’immagine esterna. Ogni commento ha la propria posizione del marcatore e la presentazione salvata mantiene tutte e cinque le associazioni di forma.

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

### **Ancorare un commento a un testo e impostarne lo stato**

Per un commento moderno associato a un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) specifica la posizione iniziale del testo selezionato nella casella di testo della forma, mentre [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) specifica la lunghezza della selezione. Insieme, queste proprietà associano il commento a un intervallo di testo specifico dentro l’AutoShape.

La proprietà [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) può essere letta o aggiornata con un valore dell’enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — nessuno stato specifico per il commento moderno è definito.
- `ACTIVE` — il commento è attivo.
- `RESOLVED` — il commento è stato risolto.
- `CLOSED` — il commento è chiuso.

L’esempio ancora un commento moderno alle parole “quarterly revenue” nel testo di un rettangolo. Calcola il valore zero‑based di [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) dal testo e imposta [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) al numero di caratteri selezionati. Dopo aver impostato [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) a `RESOLVED`, salva e riapre la presentazione. I quattro controlli sulla console dovrebbero stampare `True`, confermando che l’ancora della forma, l’intervallo di testo e lo stato sono stati preservati.

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

### **Ispezionare i commenti moderni esistenti**

L’esempio richiede una presentazione esistente contenente commenti moderni e stampa il loro testo, stato e dettagli di ancoraggio. Per ispezionarla, verifica quali commenti sono istanze di [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), quindi esamina [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) e [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). Una forma `None` indica un commento a livello di diapositiva. Per un’ancora [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), le proprietà di selezione del testo identificano l’intervallo associato nella casella di testo della forma.

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

Aspose.Slides per Python tramite .NET consente di rimuovere tutti i commenti e i loro autori da una presentazione oppure di eliminare commenti selezionati mantenendo gli altri. Gli esempi seguenti dimostrano entrambi gli approcci e salvano la presentazione aggiornata.

### **Rimuovere tutti i commenti e gli autori dei commenti**

L’esempio apre una presentazione esistente e chiama [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) per ciascun autore, quindi chiama [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) per rimuovere gli autori stessi. La presentazione salvata non contiene né commenti né autori dei commenti. Usa una presentazione contenente commenti per osservare la rimozione.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Rimuovere commenti specifici**

L’esempio crea due commenti su una diapositiva e utilizza [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) per trovare i commenti di ciascun autore. Raccoglie i commenti il cui testo è uguale a “comment 1” prima di chiamare [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), evitando modifiche alla raccolta durante la selezione. La presentazione salvata conserva solo “comment 2”.

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

**Aspose.Slides supporta uno stato risolto per i commenti moderni?**

Sì. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) può essere letto e impostato con un valore di [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), incluso `RESOLVED`. Lo stato è memorizzato nella presentazione e può essere letto nuovamente dopo aver riaperto il file.

**Sono supportate discussioni a thread (catene di risposte) e c’è un limite di nidificazione?**

Sì. Ogni commento può fare riferimento al proprio [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), consentendo catene di risposte. L’API non definisce un limite specifico di profondità di nidificazione.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione del marcatore è definita da coordinate in virgola mobile nel sistema di coordinate della diapositiva, consentendo di posizionarlo con precisione sulla diapositiva.