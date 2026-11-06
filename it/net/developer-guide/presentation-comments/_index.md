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
- commenti diapositiva
- aggiungi commento
- accedi al commento
- modifica commento
- commento di risposta
- rimuovi commento
- elimina commento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci i commenti della presentazione con Aspose.Slides per .NET: aggiungi, leggi, modifica, rispondi e rimuovi i commenti nelle presentazioni PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti della presentazione con Aspose.Slides per .NET. Introduce i principali tipi relativi ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con le risposte e i commenti moderni, e rimuovere i commenti da una presentazione.

Gli esempi coprono scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il testo dei commenti e i metadati, costruire catene di risposte e rimuovere commenti selezionati o tutti i commenti.

In PowerPoint, i commenti appaiono come annotazioni sulle diapositive. Selezionare un commento visualizza il suo testo e la discussione correlata.

Per richiedere che i commenti siano mostrati o nascosti all'apertura di una presentazione senza modificare i commenti stessi, vedi [Mostra o nascondi i commenti all'apertura di una presentazione](/slides/it/net/presentation-view-properties/).

## **Perché aggiungere commenti alle presentazioni?**

È possibile utilizzare i commenti per fornire feedback e collaborare con i colleghi durante la revisione delle presentazioni.

Aspose.Slides per .NET fornisce le seguenti API per lavorare con i commenti:

* La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) che fornisce l'accesso agli autori dei commenti della presentazione.
* L'interfaccia [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) che rappresenta i commenti associati a un singolo autore.
* L'interfaccia [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) che fornisce informazioni su un commento, includendo l'autore, l'ora di creazione, la posizione e il testo.
* La classe [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) che fornisce informazioni su un autore, includendo il nome, le iniziali e i commenti associati.

## **Aggiungere commenti alle diapositive**

L'esempio crea due diapositive e registra un autore di commenti con [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Utilizza [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) per inserire un commento su ciascuna diapositiva, quindi recupera i commenti della prima diapositiva per quell'autore con [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). La console visualizza il testo del primo commento due volte, dimostrando l'accesso sia tramite la diapositiva sia tramite l'autore, e la presentazione salvata contiene entrambi i commenti.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

var author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");
var position = new PointF(0.2f, 0.2f);
var createdTime = DateTime.Now;

author.Comments.AddComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author.Comments.AddComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

var comments = firstSlide.GetSlideComments(author);
if (comments.Length > 0)
{
    var firstComment = comments[0];
    Console.WriteLine(firstComment.Text);

    var commentText = firstComment.Author.Comments[0].Text;
    Console.WriteLine(commentText);
}

presentation.Save("Comments_out.pptx", SaveFormat.Pptx);
```

## **Trovare o creare un autore di commenti**

Quando una revisione automatizzata elabora ripetutamente la stessa presentazione, cerca nella sua collezione [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) prima di aggiungere un autore. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) confronta sia il nome che le iniziali e restituisce un array di autori corrispondenti, oppure un array vuoto se non esistono corrispondenze. Al contrario, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) ricerca solo per nome, indipendentemente dalle iniziali. Chiamare [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) con un nome e iniziali già presenti nella collezione genera un'eccezione.

L'esempio richiede un file di presentazione con almeno una diapositiva. In ciascuna delle due passate, riutilizza il primo autore corrispondente, o ne crea uno solo quando il risultato è vuoto. Se ci sono più corrispondenze, seleziona il primo elemento dell'array senza unire o rimuovere gli altri autori. Poi chiama [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) per l'autore selezionato e salva la presentazione. La seconda passata apre l'output della prima passata e ripete l'operazione.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string authorName = "Reviewer";
const string authorInitials = "RV";

var inputFile = "input.pptx";
var position = new PointF(20, 20);

for (var pass = 1; pass <= 2; pass++)
{
    using var presentation = new Presentation(inputFile);

    var matches = presentation.CommentAuthors.FindByNameAndInitials(authorName, authorInitials);
    
    var author = matches.Length > 0 ? matches[0] : presentation.CommentAuthors.AddAuthor(authorName, authorInitials);
    author.Comments.AddComment("Please review this slide.", presentation.Slides[0], position, DateTime.Now);

    var outputFile = $"review_pass_{pass}.pptx";
    presentation.Save(outputFile, SaveFormat.Pptx);
    inputFile = outputFile;
}
```

La seconda passata aggiunge un altro commento senza aggiungere un nuovo autore né rimuovere i commenti esistenti. Il file finale, `review_pass_2.pptx`, contiene entrambi i nuovi commenti insieme a eventuali commenti originali. Riutilizzare un autore non deduplica i commenti: per evitare di aggiungere ripetutamente lo stesso commento, implementare un rilevamento dei duplicati separato prima di aggiungerlo.

## **Accedere ai commenti delle diapositive**

L'esempio apre una presentazione esistente e legge la sua collezione [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Per ogni autore, itera attraverso [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) e stampa il numero della diapositiva, il testo del commento, il nome dell'autore e l'ora di creazione. La presentazione di input deve contenere commenti per produrre output sulla console.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Comments1.pptx");

foreach (var author in presentation.CommentAuthors)
{
    foreach (var comment in author.Comments)
    {
        Console.WriteLine($"Slide: {comment.Slide.SlideNumber}");
        Console.WriteLine($"Comment: {comment.Text}");
        Console.WriteLine($"Author: {comment.Author.Name}");
        Console.WriteLine($"Posted at: {comment.CreatedTime}");
        Console.WriteLine();
    }
}
```

## **Rispondere ai commenti**

Un commento padre è il commento originale in cima a una gerarchia di risposte. La proprietà [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) dell'interfaccia [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) consente di ottenere o impostare il padre di un commento.

L'esempio crea commenti da due autori e utilizza [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) per costruire risposte, inclusa una risposta a un'altra risposta. Passare `null` a [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) recupera i commenti da tutti gli autori; la console rientra ogni voce in base alla sua profondità nella gerarchia di risposte. L'esempio salva la discussione completa, chiama [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) sul primo commento radice e salva una seconda presentazione con quel commento e le sue risposte rimosse.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var originalAuthor = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var rootComment = originalAuthor.Comments.AddComment("comment 1", slide, position, createdTime);

var reviewer = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var firstReply = reviewer.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
firstReply.ParentComment = rootComment;

var secondReply = reviewer.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
secondReply.ParentComment = rootComment;

var subReply = originalAuthor.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = secondReply;

reviewer.Comments.AddComment("comment 2", slide, position, createdTime);
var separateComment = reviewer.Comments.AddComment("comment 3", slide, position, createdTime);

var separateReply = originalAuthor.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
separateReply.ParentComment = separateComment;

var comments = slide.GetSlideComments(null);
for (var i = 0; i < comments.Length; i++)
{
    var comment = comments[i];
    while (comment.ParentComment != null)
    {
        Console.Write("\t");
        comment = comment.ParentComment;
    }

    Console.WriteLine($"{comments[i].Author.Name}: {comments[i].Text}");
}

presentation.Save("parent_comment.pptx", SaveFormat.Pptx);

rootComment.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Quando il metodo [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) dell'interfaccia [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) viene usato per eliminare un commento, tutte le risposte a quel commento vengono anch'esse eliminate.
* Se la proprietà [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) crea un riferimento circolare, viene generata un'eccezione [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).
{{% /alert %}}

## **Aggiungere commenti moderni**

I commenti moderni possono essere associati alla diapositiva stessa, a una forma specifica o a un intervallo di testo all'interno di un'AutoShape. Il metodo [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) accetta un argomento [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) oltre alla diapositiva e alle coordinate del marcatore del commento.

Quando per l'argomento shape viene passato `null`, il commento è a livello di diapositiva. Il suo marcatore è posizionato tramite le coordinate fornite, ma non è associato a una forma specifica, quindi [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) restituisce `null`. Quando viene fornito un [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), il commento è ancorato a quella forma. Le coordinate continuano a definire la posizione del marcatore del commento sulla diapositiva, mentre l'associazione alla forma può essere recuperata tramite [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Ancorare un commento moderno a una forma**

L'esempio chiama [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) due volte: una volta con una forma `null` per un commento a livello di diapositiva e una volta con un rettangolo come ancoraggio. Leggere [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) stampa `True` per il controllo null del commento a livello di diapositiva e `Revenue title` per il commento ancorato. Entrambi i commenti vengono salvati con la presentazione.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
shape.Name = "Revenue title";
shape.TextFrame.Text = "Quarterly revenue";

var createdTime = DateTime.Now;
var slideCommentPosition = new PointF(20, 20);
var shapeCommentPosition = new PointF(60, 60);
var slideComment = author.Comments.AddModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
var shapeComment = author.Comments.AddModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console.WriteLine(slideComment.Shape == null);
Console.WriteLine(shapeComment.Shape?.Name);

presentation.Save("modern_comments.pptx", SaveFormat.Pptx);
```

### **Ancorare i commenti a diversi tipi di forma**

Qualsiasi oggetto diapositiva che implementa [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) può essere usato come ancoraggio di forma. Esempi comuni includono [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/), e istanze [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) come i grafici.

L'esempio utilizza [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) per associare un commento a ciascuno dei cinque tipi di forma: un'AutoShape, un picture frame, un gruppo, un connettore e un grafico. L'immagine utilizza dati immagine incorporati, quindi non è necessaria un'immagine esterna. Ogni commento ha la propria posizione del marcatore e la presentazione salvata conserva tutte e cinque le associazioni di forma.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var createdTime = DateTime.Now;

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
autoShape.TextFrame.Text = "AutoShape";

var autoShapeCommentPosition = new PointF(30, 30);
author.Comments.AddModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

var imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
var imageData = Convert.FromBase64String(imageBase64);
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
var pictureCommentPosition = new PointF(230, 30);
author.Comments.AddModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

var groupShape = slide.Shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
var groupCommentPosition = new PointF(40, 150);
author.Comments.AddModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
var connectorCommentPosition = new PointF(240, 150);
author.Comments.AddModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
var chartCommentPosition = new PointF(420, 40);
author.Comments.AddModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation.Save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
```

### **Ancorare un commento a testo e impostarne lo stato**

Per un commento moderno associato a un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) specifica la posizione iniziale del testo selezionato nel riquadro di testo della forma, mentre [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) specifica la lunghezza della selezione. Insieme, queste proprietà associano il commento a un intervallo di testo specifico all'interno dell'AutoShape.

La proprietà [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) può essere letta o aggiornata con un valore dell'enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — nessuno stato specifico del commento moderno è definito.
- `Active` — il commento è attivo.
- `Resolved` — il commento è stato risolto.
- `Closed` — il commento è chiuso.

L'esempio ancorra un commento moderno alle parole "quarterly revenue" nel testo di un rettangolo. Calcola il [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) a indice zero dal testo e imposta [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) al numero di caratteri selezionati. Dopo aver impostato [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) a `Resolved`, salva e riapre la presentazione. I quattro controlli sulla console dovrebbero stampare `True`, confermando che l'ancoraggio della forma, l'intervallo di testo e lo stato sono stati preservati.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputFile = "modern_comment_text_anchor.pptx";
const string shapeText = "Review the quarterly revenue forecast.";
const string selectedText = "quarterly revenue";
var expectedSelectionStart = shapeText.IndexOf(selectedText, StringComparison.Ordinal);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.Name = "Forecast text";
shape.TextFrame.Text = shapeText;

var author = presentation.CommentAuthors.AddAuthor("Reviewer", "RV");
var commentPosition = new PointF(60, 60);
var comment = author.Comments.AddModernComment("Verify this forecast wording.", slide, shape, commentPosition, DateTime.Now);
comment.TextSelectionStart = expectedSelectionStart;
comment.TextSelectionLength = selectedText.Length;
comment.Status = ModernCommentStatus.Resolved;

presentation.Save(outputFile, SaveFormat.Pptx);

using var reopenedPresentation = new Presentation(outputFile);
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedComments = reopenedSlide.GetSlideComments(null);

foreach (var reopenedComment in reopenedComments)
{
    if (reopenedComment is not IModernComment modernComment)
    {
        continue;
    }

    var shapeMatches = modernComment.Shape?.Name == "Forecast text";
    var selectionStartMatches = modernComment.TextSelectionStart == expectedSelectionStart;
    var selectionLengthMatches = modernComment.TextSelectionLength == selectedText.Length;
    var statusMatches = modernComment.Status == ModernCommentStatus.Resolved;

    Console.WriteLine($"Shape anchor preserved: {shapeMatches}");
    Console.WriteLine($"Text selection start preserved: {selectionStartMatches}");
    Console.WriteLine($"Text selection length preserved: {selectionLengthMatches}");
    Console.WriteLine($"Resolved status preserved: {statusMatches}");
}
```

### **Ispezionare i commenti moderni esistenti**

L'esempio richiede una presentazione esistente contenente commenti moderni e stampa il loro testo, stato e dettagli di ancoraggio. Per ispezionarla, verifica quali commenti implementano [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), poi esamina [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) e [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Una forma `null` indica un commento a livello di diapositiva. Per un ancoraggio [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), le proprietà di selezione del testo identificano l'intervallo associato nel riquadro di testo della forma.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("comments.pptx");

foreach (var slide in presentation.Slides)
{
    var comments = slide.GetSlideComments(null);
    foreach (var comment in comments)
    {
        if (comment is not IModernComment modernComment)
        {
            continue;
        }

        Console.WriteLine($"Slide: {slide.SlideNumber}");
        Console.WriteLine($"Text: {modernComment.Text}");
        Console.WriteLine($"Status: {modernComment.Status}");

        var shape = modernComment.Shape;
        if (shape == null)
        {
            Console.WriteLine("Anchor: slide level");
        }
        else
        {
            Console.WriteLine($"Anchor shape: {shape.Name}");
            Console.WriteLine($"Anchor type: {shape.GetType().Name}");

            if (shape is IAutoShape)
            {
                Console.WriteLine($"Text selection start: {modernComment.TextSelectionStart}");
                Console.WriteLine($"Text selection length: {modernComment.TextSelectionLength}");
            }
        }

        Console.WriteLine();
    }
}
```

## **Rimuovere i commenti**

Aspose.Slides per .NET consente di rimuovere tutti i commenti e i relativi autori da una presentazione o di eliminare commenti selezionati mantenendo il resto. I seguenti esempi dimostrano entrambi gli approcci e salvano la presentazione aggiornata.

### **Rimuovere tutti i commenti e gli autori dei commenti**

L'esempio apre una presentazione esistente e chiama [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) per ogni autore, poi chiama [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) per rimuovere gli stessi autori. La presentazione salvata non contiene né commenti né autori dei commenti. Utilizza una presentazione contenente commenti per osservare la rimozione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("example.pptx");

foreach (var author in presentation.CommentAuthors)
{
    author.Comments.Clear();
}

presentation.CommentAuthors.Clear();

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

### **Rimuovere commenti specifici**

L'esempio crea due commenti su una diapositiva e utilizza [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) per trovare i commenti di ciascun autore. Raccoglie i commenti il cui testo è uguale a "comment 1" prima di chiamare [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), evitando modifiche alla collezione durante la selezione. La presentazione salvata conserva solo "comment 2".

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var author = presentation.CommentAuthors.AddAuthor("Author", "A");
var createdTime = DateTime.Now;

var firstCommentPosition = new PointF(0.2f, 0.2f);
var secondCommentPosition = new PointF(0.3f, 0.2f);
author.Comments.AddComment("comment 1", slide, firstCommentPosition, createdTime);
author.Comments.AddComment("comment 2", slide, secondCommentPosition, createdTime);

foreach (var commentAuthor in presentation.CommentAuthors)
{
    var commentsToRemove = new List<IComment>();
    var comments = slide.GetSlideComments(commentAuthor);

    foreach (var comment in comments)
    {
        if (comment.Text == "comment 1")
        {
            commentsToRemove.Add(comment);
        }
    }

    foreach (var comment in commentsToRemove)
    {
        commentAuthor.Comments.Remove(comment);
    }
}

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides supporta uno stato risolto per i commenti moderni?**

Sì. La proprietà [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) può essere letta e impostata con un valore [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), incluso `Resolved`. Lo stato è memorizzato nella presentazione e può essere letto nuovamente dopo che il file è stato riaperto.

**Sono supportate discussioni in thread (catene di risposte) e c'è un limite di annidamento?**

Sì. Ogni commento può fare riferimento al proprio [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), consentendo catene di risposte. L'API non definisce un limite specifico di profondità di annidamento.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione del marcatore è definita da coordinate a virgola mobile nel sistema di coordinate della diapositiva, consentendo di posizionarla con precisione sulla diapositiva.