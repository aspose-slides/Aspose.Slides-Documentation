---
title: Gestire i commenti della presentazione in .NET
linktitle: Commenti della presentazione
type: docs
weight: 100
url: /it/net/presentation-comments/
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
- .NET
- C#
- Aspose.Slides
description: "Gestisci i commenti delle presentazioni con Aspose.Slides per .NET: aggiungi, leggi, modifica ed elimina commenti nei file PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti di presentazione in Aspose.Slides. Mostra i principali tipi relativi ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, gestire le risposte, utilizzare i commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi si concentrano su scenari comuni di revisione e collaborazione in PowerPoint, come l'assegnazione di commenti agli autori, la lettura del contenuto e dei metadati dei commenti, la creazione di catene di risposte e la cancellazione di tutti i commenti o l'eliminazione di quelli selezionati.

In PowerPoint, un commento appare come una nota o annotazione su una diapositiva. Quando un commento viene cliccato, il suo contenuto o i suoi messaggi vengono mostrati. 

## **Perché aggiungere commenti alle presentazioni?**

Potresti voler usare i commenti per fornire feedback o comunicare con i colleghi quando revisioni le presentazioni.

Per consentirti di usare i commenti nelle presentazioni PowerPoint, Aspose.Slides per .NET fornisce

* la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation), che contiene le collezioni di autori (dalla proprietà [CommentAuthorCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icommentauthorcollection/properties/index)). Gli autori aggiungono commenti alle diapositive. 
* l'interfaccia [ICommentCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icommentcollection), che contiene la collezione di commenti per singoli autori. 
* la classe [IComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment), che contiene informazioni sugli autori e i loro commenti: chi ha aggiunto il commento, l'ora in cui è stato aggiunto, la posizione del commento, ecc. 
* la classe [CommentAuthor](https://reference.aspose.com/slides/it/net/aspose.slides/commentauthor), che contiene informazioni sui singoli autori: il nome dell'autore, le sue iniziali, i commenti associati al nome dell'autore, ecc. 

## **Aggiungere commenti alle diapositive**
Questo codice C# mostra come aggiungere un commento a una diapositiva in una presentazione PowerPoint:

```c#
// Istanzia la classe Presentation
using (Presentation presentation = new Presentation())
{
    // Aggiunge una diapositiva vuota
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Aggiunge un autore
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Imposta la posizione per i commenti
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Aggiunge un commento alla diapositiva per un autore sulla diapositiva 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Aggiunge un commento alla diapositiva per un autore sulla diapositiva 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Accede a ISlide 1
    ISlide slide = presentation.Slides[0];

    // Quando viene passato null come argomento, i commenti di tutti gli autori vengono riportati alla diapositiva selezionata
    IComment[] Comments = slide.GetSlideComments(author);

    // Accede al commento all'indice 0 per la diapositiva 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Seleziona la collezione di commenti dell'autore all'indice 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Accedere ai commenti delle diapositive**
Questo codice C# mostra come accedere a un commento esistente su una diapositiva in una presentazione PowerPoint:

```c#
// Instanzia la classe Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **Rispondere ai commenti**
Un commento principale è il commento iniziale o superiore in una gerarchia di commenti o risposte. Utilizzando la proprietà [ParentComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment/properties/parentcomment) (dall'interfaccia [IComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment)), è possibile impostare o ottenere un commento principale. 

Questo codice C# mostra come aggiungere commenti e ottenere le relative risposte:

```c#
using (Presentation pres = new Presentation())
{
    // Aggiunge un commento
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Aggiunge una risposta al commento1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Aggiunge un'altra risposta al commento1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Aggiunge una risposta a una risposta esistente
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Visualizza la gerarchia dei commenti sulla console
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Rimuove il commento1 e tutte le risposte ad esso
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attenzione" %}} 

* Quando il metodo [Remove](https://reference.aspose.com/slides/it/net/aspose.slides/icomment/methods/remove) (dall'interfaccia [IComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment)) viene utilizzato per eliminare un commento, anche le risposte al commento vengono cancellate. 
* Se l'impostazione [ParentComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment/properties/parentcomment) genera un riferimento circolare, verrà sollevata un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Aggiungere commenti moderni**

Nel 2021, Microsoft ha introdotto i *commenti moderni* in PowerPoint. La funzionalità dei commenti moderni migliora notevolmente la collaborazione in PowerPoint. Grazie ai commenti moderni, gli utenti di PowerPoint possono risolvere i commenti, ancorare i commenti a oggetti e testi e interagire molto più facilmente rispetto a prima. 

In [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/it/net/aspose-slides-for-net-21-11-release-notes/), abbiamo implementato il supporto per i commenti moderni aggiungendo la classe [ModernComment](https://reference.aspose.com/slides/it/net/aspose.slides/moderncomment). I metodi [AddModernComment](https://reference.aspose.com/slides/it/net/aspose.slides/commentcollection/methods/addmoderncomment) e [InsertModernComment](https://reference.aspose.com/slides/it/net/aspose.slides/commentcollection/methods/insertmoderncomment) sono stati aggiunti alla classe [CommentCollection](https://reference.aspose.com/slides/it/net/aspose.slides/commentcollection). 

Questo codice C# mostra come aggiungere un commento moderno a una diapositiva in una presentazione PowerPoint: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Rimuovere i commenti**

### **Eliminare tutti i commenti e gli autori**

Questo codice C# mostra come rimuovere tutti i commenti e gli autori in una presentazione:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Elimina tutti i commenti dalla presentazione
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Elimina tutti gli autori
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Eliminare commenti specifici**

Questo codice C# mostra come eliminare commenti specifici su una diapositiva:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // aggiungi commenti...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // rimuovi tutti i commenti che contengono il testo "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Domande frequenti**

**Aspose.Slides supporta uno stato come "risolto" per i commenti moderni?**

Sì. I [Modern comments](https://reference.aspose.com/slides/it/net/aspose.slides/moderncomment/) espongono una proprietà [Status](https://reference.aspose.com/slides/it/net/aspose.slides/moderncomment/status/); è possibile leggere e impostare lo stato di un commento (ad esempio, marcarlo come risolto), e questo stato viene salvato nel file e riconosciuto da PowerPoint.

**Le discussioni a filo (catene di risposte) sono supportate e c’è un limite di nidificazione?**

Sì. Ogni commento può fare riferimento al proprio commento genitore, consentendo catene di risposte arbitrarie. L'API non dichiara un limite specifico alla profondità di nidificazione.

**In quale sistema di coordinate è definita la posizione del marcatore di commento su una diapositiva?**

La posizione è memorizzata come un punto a virgola mobile nel sistema di coordinate della diapositiva. Questo consente di posizionare il marcatore del commento esattamente dove è necessario.