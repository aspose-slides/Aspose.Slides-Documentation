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
description: "Gestisci i commenti delle presentazioni con Aspose.Slides per Python via .NET: aggiungi, leggi, modifica e elimina i commenti nei file PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti nelle presentazioni in Aspose.Slides. Mostra i principali tipi correlati ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, gestire le risposte, utilizzare i commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi si concentrano su scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il contenuto e i metadati dei commenti, costruire catene di risposte e cancellare tutti i commenti o eliminare quelli selezionati.

In PowerPoint, un commento appare come una nota o un'annotazione su una diapositiva. Quando si fa clic su un commento, il suo contenuto o i suoi messaggi vengono mostrati.

## **Perché aggiungere commenti alle presentazioni?**

Potresti voler utilizzare i commenti per fornire feedback o comunicare con i tuoi colleghi durante la revisione delle presentazioni.

Per consentirti di usare i commenti nelle presentazioni PowerPoint, Aspose.Slides for Python via .NET fornisce

* La classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) , che contiene le raccolte di autori (dalla proprietà [CommentAuthorCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentauthorcollection/)). Gli autori aggiungono commenti alle diapositive.
* La classe [CommentCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentcollection/) , che contiene la raccolta di commenti per singoli autori.
* La classe [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) , che contiene informazioni sugli autori e i loro commenti: chi ha aggiunto il commento, l'ora in cui è stato aggiunto, la posizione del commento, ecc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentauthor/) , che contiene informazioni su singoli autori: il nome dell'autore, le sue iniziali, i commenti associati al nome dell'autore, ecc.

## **Aggiungere un commento alla diapositiva**
Questo codice Python mostra come aggiungere un commento a una diapositiva in una presentazione PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Istanziamento della classe Presentation
with slides.Presentation() as presentation:
    # Aggiunge una diapositiva vuota
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Aggiunge un autore
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Imposta la posizione per i commenti
    point = draw.PointF(0.2, 0.2)

    # Aggiunge un commento alla diapositiva per un autore sulla diapositiva 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Aggiunge un commento alla diapositiva per un autore sulla diapositiva 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Accesso a ISlide 1
    slide = presentation.slides[0]

    # Quando viene passato null come argomento, i commenti di tutti gli autori vengono portati alla diapositiva selezionata
    comments = slide.get_slide_comments(author)

    # Accede al commento all'indice 0 per la diapositiva 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Seleziona la collezione di commenti dell'autore all'indice 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **Accedere ai commenti della diapositiva**
Questo codice Python mostra come accedere a un commento esistente su una diapositiva in una presentazione PowerPoint:

```python
import aspose.slides as slides

# Istanziamento della classe Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **Commenti di risposta**
Un commento padre è il commento principale o originale in una gerarchia di commenti o risposte. Utilizzando la proprietà `parent_comment` (dalla classe [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) ), è possibile impostare o ottenere un commento padre.

Questo codice Python mostra come aggiungere commenti e ottenere le risposte a essi:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Aggiunge un commento
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Aggiunge una risposta a comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Aggiunge un'altra risposta a comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Aggiunge una risposta a una risposta esistente
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Visualizza la gerarchia dei commenti nella console
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

    # Rimuove comment1 e tutte le sue risposte
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attenzione" %}} 
* Quando il metodo `remove` (dalla classe [Comment](https://reference.aspose.com/slides/it/python-net/aspose.slides/comment/) ) viene usato per eliminare un commento, le risposte al commento vengono anch'esse cancellate.
* Se l'impostazione `parent_comment` genera un riferimento circolare, verrà sollevata `PptxEditException`.
{{% /alert %}}

## **Aggiungere un commento moderno**

Nel 2021, Microsoft ha introdotto i *commenti moderni* in PowerPoint. La funzionalità dei commenti moderni migliora notevolmente la collaborazione in PowerPoint. Attraverso i commenti moderni, gli utenti di PowerPoint possono risolvere i commenti, ancorare i commenti a oggetti e testi e interagire in modo molto più semplice rispetto al passato.

Abbiamo implementato il supporto per i commenti moderni aggiungendo la classe [ModernComment](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/). I metodi `add_modern_comment` e `insert_modern_comment` sono stati aggiunti alla classe [CommentCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/commentcollection/).

Questo codice Python mostra come aggiungere un commento moderno a una diapositiva in una presentazione PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovere il commento**

### **Eliminare tutti i commenti e gli autori**

Questo codice Python mostra come rimuovere tutti i commenti e gli autori in una presentazione:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Elimina tutti i commenti dalla presentazione
    for author in presentation.comment_authors:
        author.comments.clear()

    # Elimina tutti gli autori
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Eliminare commenti specifici**

Questo codice Python mostra come eliminare commenti specifici su una diapositiva:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # aggiungi commenti...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # rimuovi tutti i commenti che contengono il testo "comment 1"
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

**Aspose.Slides supporta uno stato come 'risolto' per i commenti moderni?**

Sì. I [Commenti moderni](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/) espongono una proprietà [status](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/status/); è possibile leggere e impostare lo [stato del commento](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncommentstatus/) (ad esempio, marcarlo come risolto), e questo stato viene salvato nel file e riconosciuto da PowerPoint.

**Sono supportate le discussioni a thread (catene di risposte) e c'è un limite di nidificazione?**

Sì. Ogni commento può fare riferimento al proprio [commento padre](https://reference.aspose.com/slides/it/python-net/aspose.slides/moderncomment/parent_comment/), permettendo catene di risposte arbitrarie. L'API non dichiara un limite specifico di profondità di nidificazione.

**In quale sistema di coordinate è definita la posizione del segno del commento su una diapositiva?**

La posizione è memorizzata come un punto a virgola mobile nel sistema di coordinate della diapositiva. Questo consente di posizionare il segno del commento esattamente dove è necessario.