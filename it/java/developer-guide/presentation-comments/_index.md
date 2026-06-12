---
title: Gestire i commenti della presentazione in Java
linktitle: Commenti della presentazione
type: docs
weight: 100
url: /it/java/presentation-comments/
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
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci i commenti delle presentazioni con Aspose.Slides per Java: aggiungi, leggi, modifica e elimina i commenti nei file PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti della presentazione in Aspose.Slides. Mostra i principali tipi relativi ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, gestire le risposte, utilizzare i commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi si concentrano su scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il contenuto e i metadati dei commenti, costruire catene di risposte e cancellare tutti i commenti o eliminare quelli selezionati.

In PowerPoint, un commento appare come una nota o un'annotazione su una diapositiva. Quando si fa clic su un commento, il suo contenuto o i messaggi vengono visualizzati.

## **Perché aggiungere commenti alle presentazioni?**

Potresti voler utilizzare i commenti per fornire feedback o comunicare con i colleghi quando revisioni delle presentazioni.

Per consentirti di usare i commenti nelle presentazioni PowerPoint, Aspose.Slides per Java fornisce

* La classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) che contiene le collezioni di autori (dall’interfaccia [ICommentAuthorCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ICommentAuthorCollection)). Gli autori aggiungono commenti alle diapositive. 
* L’interfaccia [ICommentCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ICommentCollection) che contiene la collezione di commenti per singoli autori. 
* La classe [IComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/IComment) che contiene informazioni su autori e i loro commenti: chi ha aggiunto il commento, l’ora di aggiunta, la posizione del commento, ecc. 
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/java/com.aspose.slides/CommentAuthor) che contiene informazioni su singoli autori: il nome dell’autore, le sue iniziali, i commenti associati al nome dell’autore, ecc. 

## **Aggiungere commenti alle diapositive**
Questo codice Java mostra come aggiungere un commento a una diapositiva in una presentazione PowerPoint:

```java
// Istanzia la classe Presentation
Presentation pres = new Presentation();
try {
    // Aggiunge una diapositiva vuota
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Aggiunge un autore
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Imposta la posizione per i commenti
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Aggiunge un commento alla diapositiva per un autore sulla diapositiva 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Aggiunge un commento alla diapositiva per un autore sulla diapositiva 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Accede a ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Quando null viene passato come argomento, i commenti di tutti gli autori vengono riportati alla diapositiva selezionata
    IComment[] Comments = slide.getSlideComments(author);

    // Accede al commento all'indice 0 per la diapositiva 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Seleziona la collezione dei commenti dell'autore all'indice 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accedere ai commenti delle diapositive**
Questo codice Java mostra come accedere a un commento esistente su una diapositiva in una presentazione PowerPoint:

```java
// Istanzia la classe Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rispondere ai commenti**
Un commento padre è il commento principale o originale in una gerarchia di commenti o risposte. Utilizzando i metodi [getParentComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/IComment#getParentComment--) o [setParentComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (dall’interfaccia [IComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/IComment)), è possibile impostare o ottenere un commento padre.

Questo codice Java mostra come aggiungere commenti e ottenere le risposte a essi:

```java
Presentation pres = new Presentation();
try {
    // Aggiunge un commento
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Aggiunge una risposta a comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Aggiunge un'altra risposta a comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Aggiunge una risposta a una risposta esistente
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Visualizza la gerarchia dei commenti nella console
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Rimuove comment1 e tutte le risposte ad esso
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 

* Quando il metodo [Remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/IComment#remove--) (dall’interfaccia [IComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/IComment)) viene utilizzato per eliminare un commento, anche le risposte al commento vengono eliminate. 
* Se l’impostazione [setParentComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) genera un riferimento circolare, verrà generata un’eccezione [PptxEditException](https://reference.aspose.com/slides/it/java/com.aspose.slides/PptxEditException).

{{% /alert %}}

## **Aggiungere commenti moderni**

Nel 2021, Microsoft ha introdotto i *commenti moderni* in PowerPoint. La funzionalità dei commenti moderni migliora notevolmente la collaborazione in PowerPoint. Grazie ai commenti moderni, gli utenti di PowerPoint possono risolvere i commenti, ancorare i commenti a oggetti e testi e interagire molto più facilmente rispetto al passato.

In [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/it/java/aspose-slides-for-java-21-11-release-notes/), abbiamo implementato il supporto per i commenti moderni aggiungendo la classe [ModernComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/ModernComment). I metodi [addModernComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) e [insertModernComment](https://reference.aspose.com/slides/it/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) sono stati aggiunti alla classe [CommentCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/CommentCollection).

Questo codice Java mostra come aggiungere un commento moderno a una diapositiva in una presentazione PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere i commenti**

### **Eliminare tutti i commenti e gli autori**

Questo codice Java mostra come rimuovere tutti i commenti e gli autori in una presentazione:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Elimina tutti i commenti dalla presentazione
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Elimina tutti gli autori
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Eliminare commenti specifici**

Questo codice Java mostra come eliminare commenti specifici su una diapositiva:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // aggiungi commenti...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // rimuovi tutti i commenti che contengono il testo "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides supporta uno stato come “risolto” per i commenti moderni?**

Sì. I [commenti moderni](https://reference.aspose.com/slides/it/java/com.aspose.slides/moderncomment/) espongono un metodo [setStatus](https://reference.aspose.com/slides/it/java/com.aspose.slides/moderncomment/#setStatus-byte-); è possibile impostare lo [stato del commento](https://reference.aspose.com/slides/it/java/com.aspose.slides/moderncommentstatus/) (ad esempio, contrassegnarlo come risolto), e questo stato viene salvato nel file e riconosciuto da PowerPoint.

**Sono supportate discussioni strutturate (catene di risposte) e c’è un limite di nidificazione?**

Sì. Ogni commento può fare riferimento al suo [commento padre](https://reference.aspose.com/slides/it/java/com.aspose.slides/comment/#getParentComment--), consentendo catene di risposte arbitrarie. L’API non dichiara un limite specifico di profondità di nidificazione.

**In quale sistema di coordinate è definita la posizione del marcatore di commento su una diapositiva?**

La posizione è memorizzata come punto a virgola mobile nel sistema di coordinate della diapositiva. Questo permette di posizionare il marcatore di commento esattamente dove necessario.