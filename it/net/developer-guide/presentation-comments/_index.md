---
title: Gestire i commenti delle presentazioni in .NET
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
- aggiungere commento
- accedere al commento
- modificare commento
- rispondere al commento
- rimuovere commento
- eliminare commento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci i commenti delle presentazioni con Aspose.Slides per .NET: aggiungi, leggi, modifica, rispondi e rimuovi i commenti nelle presentazioni PowerPoint in modo rapido e semplice."
---
## **Panoramica**

Questo articolo spiega come gestire i commenti delle presentazioni con Aspose.Slides per .NET. Introduce i principali tipi correlati ai commenti e dimostra come aggiungere commenti alle diapositive, accedere ai commenti esistenti, lavorare con risposte e commenti moderni e rimuovere i commenti da una presentazione.

Gli esempi coprono scenari comuni di revisione e collaborazione in PowerPoint, come assegnare commenti agli autori, leggere il testo e i metadati dei commenti, creare catene di risposte e rimuovere commenti selezionati o tutti i commenti.

In PowerPoint, i commenti appaiono come annotazioni sulle diapositive. Selezionare un commento visualizza il suo testo e la discussione correlata.

## **Perché aggiungere commenti alle presentazioni?**

È possibile utilizzare i commenti per fornire feedback e collaborare con i colleghi durante la revisione delle presentazioni.

Aspose.Slides per .NET fornisce le seguenti API per lavorare con i commenti:

* La classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) fornisce l'accesso agli autori dei commenti della presentazione.
* L'interfaccia [ICommentCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icommentcollection) rappresenta i commenti associati a un singolo autore.
* L'interfaccia [IComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment) fornisce informazioni su un commento, includendo autore, data di creazione, posizione e testo.
* La classe [CommentAuthor](https://reference.aspose.com/slides/it/net/aspose.slides/commentauthor) fornisce informazioni su un autore, includendo nome, iniziali e commenti associati.

## **Aggiungere commenti alle diapositive**
L'esempio seguente mostra come aggiungere commenti alle diapositive in una presentazione PowerPoint:

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

## **Accedere ai commenti delle diapositive**
L'esempio seguente mostra come accedere ai commenti esistenti in una presentazione PowerPoint:

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
Un commento padre è il commento originale in cima a una gerarchia di risposte. La proprietà [ParentComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment/properties/parentcomment) dell'interfaccia [IComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment) consente di ottenere o impostare il commento padre di un commento.

L'esempio seguente mostra come aggiungere risposte e ispezionare la gerarchia di commenti risultante:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var position = new PointF(10, 10);
var createdTime = DateTime.Now;

var author1 = presentation.CommentAuthors.AddAuthor("Author_1", "A.A.");
var comment1 = author1.Comments.AddComment("comment 1", slide, position, createdTime);

var author2 = presentation.CommentAuthors.AddAuthor("Author_2", "B.B.");
var reply1 = author2.Comments.AddComment("reply 1 for comment 1", slide, position, createdTime);
reply1.ParentComment = comment1;

var reply2 = author2.Comments.AddComment("reply 2 for comment 1", slide, position, createdTime);
reply2.ParentComment = comment1;

var subReply = author1.Comments.AddComment("subreply 3 for reply 2", slide, position, createdTime);
subReply.ParentComment = reply2;

author2.Comments.AddComment("comment 2", slide, position, createdTime);
var comment3 = author2.Comments.AddComment("comment 3", slide, position, createdTime);

var reply3 = author1.Comments.AddComment("reply 4 for comment 3", slide, position, createdTime);
reply3.ParentComment = comment3;

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

comment1.Remove();
presentation.Save("remove_comment.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* Quando il metodo [Remove](https://reference.aspose.com/slides/it/net/aspose.slides/icomment/methods/remove) dell'interfaccia [IComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment) viene utilizzato per eliminare un commento, tutte le risposte a quel commento vengono eliminate anch'esse.
* Se la proprietà [ParentComment](https://reference.aspose.com/slides/it/net/aspose.slides/icomment/properties/parentcomment) crea un riferimento circolare, viene generata un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Aggiungere commenti moderni**

I commenti moderni possono essere associati alla diapositiva stessa, a una forma specifica o a un intervallo di testo all'interno di un'AutoShape. Il metodo [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/it/net/aspose.slides/icommentcollection/addmoderncomment/) accetta un argomento [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) in aggiunta alla diapositiva e alle coordinate del marcatore del commento.

Quando viene passato `null` per l'argomento forma, il commento è un commento a livello di diapositiva. Il suo marcatore è posizionato secondo le coordinate fornite, ma non è associato a una forma particolare, quindi [IModernComment.Shape](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/shape/) restituisce `null`. Quando viene fornita una [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/), il commento è ancorato a quella forma. Le coordinate definiscono comunque la posizione del marcatore del commento sulla diapositiva, mentre l'associazione alla forma può essere recuperata tramite [IModernComment.Shape](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/shape/).

### **Ancorare un commento moderno a una forma**

L'esempio seguente crea sia un commento moderno a livello di diapositiva sia un commento moderno ancorato a una AutoShape specifica. Quindi legge la forma associata a ciascun commento.

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

Qualsiasi oggetto diapositiva che implementa [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) può essere usato come ancoraggio di forma. Esempi comuni includono [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/it/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/it/net/aspose.slides/iconnector/) e istanze di [IGraphicalObject](https://reference.aspose.com/slides/it/net/aspose.slides/igraphicalobject/) come i grafici.

L'esempio seguente crea diversi tipi di forma comuni e associa a ciascuno un commento moderno.

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

### **Ancorare un commento al testo e impostarne lo stato**

Per un commento moderno associato a una [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/), la proprietà [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/textselectionstart/) specifica la posizione iniziale del testo selezionato nel frame di testo della forma, mentre [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/textselectionlength/) specifica la lunghezza della selezione. Insieme, queste proprietà associano il commento a un intervallo di testo specifico all'interno dell'AutoShape.

La proprietà [IModernComment.Status](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/status/) può essere letta o aggiornata con un valore dell'enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/it/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — nessuno stato specifico per il commento moderno è definito.
- `Active` — il commento è attivo.
- `Resolved` — il commento è stato risolto.
- `Closed` — il commento è chiuso.

L'esempio seguente crea un commento moderno ancorato a una forma, lo associa a una selezione di testo, lo segna come risolto, salva la presentazione e verifica i valori dopo aver riaperto il file.

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

Per ispezionare una presentazione esistente, verificare quali commenti implementano [IModernComment](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/), quindi esaminare [IModernComment.Shape](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/textselectionlength/) e [IModernComment.Status](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/status/). Una forma `null` indica un commento a livello di diapositiva. Per un ancoraggio a [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/), le proprietà di selezione del testo identificano l'intervallo associato nel frame di testo della forma.

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

### **Rimuovere tutti i commenti e gli autori dei commenti**

L'esempio seguente mostra come rimuovere tutti i commenti e gli autori dei commenti da una presentazione:

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

L'esempio seguente mostra come rimuovere commenti specifici da una diapositiva:

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

Sì. La proprietà [IModernComment.Status](https://reference.aspose.com/slides/it/net/aspose.slides/imoderncomment/status/) può essere letta e impostata con un valore dell'enumerazione [ModernCommentStatus](https://reference.aspose.com/slides/it/net/aspose.slides/moderncommentstatus/), incluso `Resolved`. Lo stato è memorizzato nella presentazione e può essere letto nuovamente dopo aver riaperto il file.

**Le discussioni a thread (catene di risposte) sono supportate e c'è un limite di annidamento?**

Sì. Ogni commento può fare riferimento al proprio [parent comment](https://reference.aspose.com/slides/it/net/aspose.slides/comment/parentcomment/), consentendo catene di risposte. L'API non definisce un limite specifico di profondità di annidamento.

**In quale sistema di coordinate è definita la posizione del marcatore di un commento su una diapositiva?**

La posizione del marcatore è definita da coordinate in virgola mobile nel sistema di coordinate della diapositiva, consentendo di posizionarlo con precisione sulla diapositiva.