---
title: Gestire i commenti della presentazione in JavaScript
linktitle: Commenti della presentazione
type: docs
weight: 100
url: /it/nodejs-java/presentation-comments/
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
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i commenti delle presentazioni con Aspose.Slides per Node.js: aggiungi, leggi, modifica ed elimina commenti nei file PowerPoint usando JavaScript in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti di presentazione in Aspose.Slides. Mostra i principali tipi correlati ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, gestire le risposte, utilizzare i commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi si concentrano su scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il contenuto e i metadati dei commenti, costruire catene di risposte e cancellare tutti i commenti o eliminare quelli selezionati.

In PowerPoint, un commento appare come una nota o un'annotazione su una diapositiva. Quando si fa clic su un commento, il suo contenuto o i messaggi vengono visualizzati.

## **Perché aggiungere commenti alle presentazioni?**

Potresti voler utilizzare i commenti per fornire feedback o comunicare con i colleghi durante la revisione delle presentazioni.

Per consentirti di utilizzare i commenti nelle presentazioni PowerPoint, Aspose.Slides per Node.js via Java fornisce

* La classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) che contiene le raccolte di autori (dalla classe [CommentAuthorCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CommentAuthorCollection)). Gli autori aggiungono commenti alle diapositive.
* La classe [CommentCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CommentCollection) che contiene la raccolta di commenti per singoli autori.
* La classe [Comment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Comment) che contiene informazioni sugli autori e i loro commenti: chi ha aggiunto il commento, l'ora in cui è stato aggiunto, la posizione del commento, ecc.
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CommentAuthor) che contiene informazioni sui singoli autori: il nome dell'autore, le sue iniziali, i commenti associati al nome dell'autore, ecc.

## **Aggiungere commento alla diapositiva**
Questo codice JavaScript mostra come aggiungere un commento a una diapositiva in una presentazione PowerPoint:

```javascript
// Istanzia la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Aggiunge una diapositiva vuota
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Aggiunge un autore
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Imposta la posizione per i commenti
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Aggiunge un commento alla diapositiva per un autore sulla diapositiva 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Aggiunge un commento alla diapositiva per un autore sulla diapositiva 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Accede a ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Quando null viene passato come argomento, i commenti di tutti gli autori vengono riportati alla diapositiva selezionata
    var Comments = slide.getSlideComments(author);
    // Accede al commento all'indice 0 per la diapositiva 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Seleziona la raccolta di commenti dell'Autore all'indice 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Accedere ai commenti della diapositiva**
Questo codice JavaScript mostra come accedere a un commento esistente su una diapositiva in una presentazione PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rispondere ai commenti**
Un commento padre è il commento principale o originale in una gerarchia di commenti o risposte. Utilizzando i metodi [getParentComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Comment#getParentComment--) o [setParentComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (dalla classe [Comment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Comment)), è possibile impostare o ottenere un commento padre.

Questo codice JavaScript mostra come aggiungere commenti e ottenere le risposte a essi:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Aggiunge un commento
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Aggiunge una risposta a comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Aggiunge un'altra risposta a comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Aggiunge una risposta a una risposta esistente
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Visualizza la gerarchia dei commenti sulla console
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Rimuove comment1 e tutte le risposte ad esso
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attenzione" %}} 

* Quando il metodo [Remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Comment#remove--) (dalla classe [Comment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Comment)) viene utilizzato per eliminare un commento, le risposte al commento vengono anch'esse eliminate.
* Se l'impostazione [setParentComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) genera un riferimento circolare, verrà sollevata una [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Aggiungere commento moderno**

Nel 2021, Microsoft ha introdotto i *commenti moderni* in PowerPoint. La funzionalità dei commenti moderni migliora notevolmente la collaborazione in PowerPoint. Attraverso i commenti moderni, gli utenti di PowerPoint possono risolvere i commenti, ancorare i commenti a oggetti e testi e interagire molto più facilmente rispetto al passato. 

Aspose.Slides supporta i commenti moderni tramite la classe [ModernComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ModernComment). I metodi [addModernComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) e [insertModernComment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) sono stati aggiunti alla classe [CommentCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/CommentCollection).

Questo codice JavaScript mostra come aggiungere un commento moderno a una diapositiva in una presentazione PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovere commenti**

### **Eliminare tutti i commenti e gli autori**
Questo codice JavaScript mostra come rimuovere tutti i commenti e gli autori in una presentazione:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Elimina tutti i commenti dalla presentazione
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Elimina tutti gli autori
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Eliminare commenti specifici**
Questo codice JavaScript mostra come eliminare commenti specifici su una diapositiva:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // aggiungi commenti...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // rimuovi tutti i commenti che contengono il testo "comment 1"
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Aspose.Slides supporta uno stato come 'risolto' per i commenti moderni?**

Sì. I [Modern comments](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/) espongono i metodi [getStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/getstatus/) e [setStatus](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncomment/setStatus/); è possibile leggere e impostare lo [stato del commento](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/moderncommentstatus/) (ad esempio, contrassegnarlo come risolto), e questo stato viene salvato nel file e riconosciuto da PowerPoint.

**Sono supportate discussioni in thread (catene di risposte) e c'è un limite di annidamento?**

Sì. Ogni commento può fare riferimento al proprio [parent comment](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/comment/getparentcomment/), consentendo catene di risposte arbitrarie. L'API non dichiara un limite specifico di profondità di annidamento.

**In quale sistema di coordinate è definita la posizione del marcatore di commento su una diapositiva?**

La posizione è memorizzata come punto a virgola mobile nel sistema di coordinate della diapositiva. Questo consente di posizionare il marcatore del commento esattamente dove necessario.