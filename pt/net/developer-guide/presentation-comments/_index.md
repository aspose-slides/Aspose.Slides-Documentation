---
title: Gerenciar Comentários de Apresentação em .NET
linktitle: Comentários de Apresentação
type: docs
weight: 100
url: /pt/net/presentation-comments/
keywords:
- comentário
- comentário moderno
- comentários do PowerPoint
- comentários de apresentação
- comentários de slide
- adicionar comentário
- acessar comentário
- editar comentário
- responder comentário
- remover comentário
- excluir comentário
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie comentários de apresentação com Aspose.Slides para .NET: adicione, leia, edite, responda e remova comentários em apresentações do PowerPoint de forma rápida e fácil."
---
## **Visão geral**

Este artigo explica como gerenciar comentários de apresentação com Aspose.Slides para .NET. Ele apresenta os principais tipos relacionados a comentários e demonstra como adicionar comentários aos slides, acessar comentários existentes, trabalhar com respostas e comentários modernos e remover comentários de uma apresentação.

Os exemplos cobrem cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler texto e metadados dos comentários, construir cadeias de respostas e remover comentários selecionados ou todos os comentários.

No PowerPoint, os comentários aparecem como anotações nos slides. Selecionar um comentário exibe seu texto e a discussão relacionada.

## **Por que adicionar comentários às apresentações?**

Você pode usar comentários para fornecer feedback e colaborar com colegas ao revisar apresentações.

Aspose.Slides para .NET fornece as seguintes APIs para trabalhar com comentários:

* The [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) class, que fornece acesso aos autores de comentários da apresentação.
* The [ICommentCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/icommentcollection) interface, que representa os comentários associados a um autor individual.
* The [IComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment) interface, que fornece informações sobre um comentário, incluindo seu autor, horário de criação, posição e texto.
* The [CommentAuthor](https://reference.aspose.com/slides/pt/net/aspose.slides/commentauthor) class, que fornece informações sobre um autor, incluindo seu nome, iniciais e comentários associados.

## **Adicionar comentários ao slide**
O exemplo a seguir mostra como adicionar comentários aos slides em uma apresentação do PowerPoint:

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

## **Acessar comentários do slide**
O exemplo a seguir mostra como acessar comentários existentes em uma apresentação do PowerPoint:

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

## **Responder a comentários**
Um comentário pai é o comentário original no topo de uma hierarquia de respostas. A propriedade [ParentComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment/properties/parentcomment) da interface [IComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment) permite obter ou definir o comentário pai.

O exemplo a seguir mostra como adicionar respostas e inspecionar a hierarquia resultante de comentários:

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

* Quando o método [Remove](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment/methods/remove) da interface [IComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment) é usado para excluir um comentário, todas as respostas a esse comentário também são excluídas.
* Se a propriedade [ParentComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icomment/properties/parentcomment) criar uma referência circular, uma [PptxEditException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxeditexception) será lançada.

{{% /alert %}}

## **Adicionar comentários modernos**

Os comentários modernos podem ser associados ao próprio slide, a uma forma específica ou a um intervalo de texto dentro de um AutoShape. O método [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/pt/net/aspose.slides/icommentcollection/addmoderncomment/) aceita um argumento [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) além do slide e das coordenadas do marcador de comentário.

Quando `null` é passado para o argumento shape, o comentário é um comentário de nível de slide. Seu marcador é posicionado pelas coordenadas fornecidas, mas não está associado a uma forma específica, portanto [IModernComment.Shape](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/shape/) retorna `null`. Quando um [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) é fornecido, o comentário é ancorado a essa forma. As coordenadas ainda definem a posição do marcador de comentário no slide, enquanto a associação à forma pode ser obtida através de [IModernComment.Shape](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/shape/).

### **Ancorar um comentário moderno a uma forma**

O exemplo a seguir cria tanto um comentário moderno de nível de slide quanto um comentário moderno ancorado a um AutoShape específico. Em seguida, lê a forma associada de cada comentário.

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

### **Ancorar comentários a diferentes tipos de forma**

Qualquer objeto de slide que implemente [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) pode ser usado como âncora de forma. Exemplos comuns incluem [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/pt/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/pt/net/aspose.slides/iconnector/) e instâncias de [IGraphicalObject](https://reference.aspose.com/slides/pt/net/aspose.slides/igraphicalobject/) como gráficos.

O exemplo a seguir cria vários tipos de forma comuns e associa um comentário moderno a cada um deles.

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

### **Ancorar um comentário a texto e definir seu status**

Para um comentário moderno associado a um [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/textselectionstart/) especifica a posição inicial do texto selecionado na caixa de texto da forma, enquanto [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/textselectionlength/) especifica o comprimento da seleção. Juntas, essas propriedades associam o comentário a um intervalo de texto específico dentro do AutoShape.

A propriedade [IModernComment.Status](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/status/) pode ser lida ou atualizada com um valor da enumeração [ModernCommentStatus](https://reference.aspose.com/slides/pt/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — nenhum status específico de comentário moderno está definido.
- `Active` — o comentário está ativo.
- `Resolved` — o comentário foi resolvido.
- `Closed` — o comentário está fechado.

O exemplo a seguir cria um comentário moderno ancorado a uma forma, associa-o a uma seleção de texto, marca-o como resolvido, salva a apresentação e verifica os valores após reabrir o arquivo.

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

### **Inspecionar comentários modernos existentes**

Para inspecionar uma apresentação existente, verifique quais comentários implementam [IModernComment](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/), então examine [IModernComment.Shape](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/textselectionlength/) e [IModernComment.Status](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/status/). Uma forma `null` indica um comentário de nível de slide. Para uma âncora [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/), as propriedades de seleção de texto identificam o intervalo associado na caixa de texto da forma.

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

## **Remover comentários**

### **Remover todos os comentários e autores de comentários**

O exemplo a seguir mostra como remover todos os comentários e autores de comentários de uma apresentação:

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

### **Remover comentários específicos**

O exemplo a seguir mostra como remover comentários específicos de um slide:

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

**O Aspose.Slides suporta um status resolvido para comentários modernos?**

Sim. [IModernComment.Status](https://reference.aspose.com/slides/pt/net/aspose.slides/imoderncomment/status/) pode ser lido e definido com um valor de [ModernCommentStatus](https://reference.aspose.com/slides/pt/net/aspose.slides/moderncommentstatus/), incluindo `Resolved`. O status é armazenado na apresentação e pode ser lido novamente após o arquivo ser reaberto.

**As discussões em cadeia (respostas) são suportadas e há um limite de aninhamento?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/pt/net/aspose.slides/comment/parentcomment/), permitindo cadeias de respostas. A API não define um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição do marcador é definida por coordenadas de ponto flutuante no sistema de coordenadas do slide, permitindo que você a posicione com precisão no slide.