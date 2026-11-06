---
title: Gerenciar Comentários de Apresentação em .NET
linktitle: Comentários da Apresentação
type: docs
weight: 100
url: /pt/net/presentation-comments/
keywords:
- comentário
- comentário moderno
- comentários do PowerPoint
- comentários da apresentação
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
description: "Gerencie comentários de apresentação com Aspose.Slides para .NET: adicione, leia, edite, responda e remova comentários em apresentações PowerPoint rapidamente e facilmente."
---
## **Visão geral**

Este artigo explica como gerenciar comentários em apresentações com Aspose.Slides para .NET. Ele apresenta os principais tipos relacionados a comentários e demonstra como adicionar comentários a slides, acessar comentários existentes, trabalhar com respostas e comentários modernos, e remover comentários de uma apresentação.

Os exemplos cobrem cenários comuns de revisão e colaboração no PowerPoint, como atribuir comentários a autores, ler o texto e os metadados dos comentários, construir cadeias de respostas e remover comentários selecionados ou todos os comentários.

No PowerPoint, os comentários aparecem como anotações nos slides. Selecionar um comentário exibe seu texto e a discussão relacionada.

Para solicitar que os comentários sejam mostrados ou ocultados ao abrir uma apresentação sem alterar os próprios comentários, veja [Mostrar ou Ocultar Comentários ao Abrir uma Apresentação](/slides/pt/net/presentation-view-properties/).

## **Por que adicionar comentários a apresentações?**

Você pode usar comentários para fornecer feedback e colaborar com colegas ao revisar apresentações.

Aspose.Slides para .NET oferece as seguintes APIs para trabalhar com comentários:

* The [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class, que fornece acesso aos autores de comentários da apresentação.
* The [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection) interface, que representa os comentários associados a um autor específico.
* The [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) interface, que fornece informações sobre um comentário, incluindo seu autor, horário de criação, posição e texto.
* The [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor) class, que fornece informações sobre um autor, incluindo seu nome, iniciais e comentários associados.

## **Adicionar Comentários a Slides**

O exemplo cria dois slides e registra um autor de comentário com [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Ele usa [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) para colocar um comentário em cada slide, depois recupera os comentários do primeiro slide para esse autor com [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). O console exibe o texto do primeiro comentário duas vezes, demonstrando o acesso tanto pelo slide quanto pelo autor, e a apresentação salva contém ambos os comentários.

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

## **Localizar ou Criar um Autor de Comentário**

Quando uma revisão automatizada processa a mesma apresentação repetidamente, pesquise sua coleção [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) antes de adicionar um autor. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) corresponde tanto ao nome quanto às iniciais e retorna um array de autores correspondentes, ou um array vazio se não houver correspondências. Em contraste, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) pesquisa apenas pelo nome, independentemente das iniciais. Chamar [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) com um nome e iniciais já presentes na coleção lança uma exceção.

O exemplo requer um arquivo de apresentação com ao menos um slide. Em cada uma das duas passagens, ele reutiliza o primeiro autor correspondente, ou cria um apenas quando o resultado está vazio. Se houver múltiplas correspondências, ele seleciona o primeiro elemento do array sem mesclar ou remover os demais autores. Em seguida, ele chama [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) para o autor selecionado e salva a apresentação. A segunda passagem abre a saída da primeira passagem e repete a operação.

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

A segunda passagem adiciona outro comentário sem adicionar outro autor ou remover comentários existentes. O arquivo final, `review_pass_2.pptx`, contém ambos os novos comentários junto a quaisquer comentários originais. Reutilizar um autor não deduplica comentários: para evitar adicionar repetidamente o mesmo comentário, implemente detecção de duplicatas separada antes de adicioná‑lo.

## **Acessar Comentários de Slides**

O exemplo abre uma apresentação existente e lê sua coleção [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Para cada autor, ele itera pelos [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) e imprime o número do slide, o texto do comentário, o nome do autor e o horário de criação. A apresentação de entrada deve conter comentários para produzir saída no console.

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

## **Responder a Comentários**

Um comentário pai é o comentário original no topo de uma hierarquia de respostas. A propriedade [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) da interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) permite obter ou definir o pai de um comentário.

O exemplo cria comentários de dois autores e usa [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) para construir respostas, incluindo uma resposta a outra resposta. Passar `null` para [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) recupera comentários de todos os autores; o console indenta cada entrada de acordo com sua profundidade na hierarquia de respostas. O exemplo salva a discussão completa, chama [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) no primeiro comentário raiz e salva uma segunda apresentação com esse comentário e suas respostas removidos.

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
* Quando o método [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) da interface [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) é usado para excluir um comentário, todas as respostas a esse comentário também são excluídas.
* Se a propriedade [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) criar uma referência circular, uma [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) será lançada.
{{% /alert %}}

## **Adicionar Comentários Modernos**

Comentários modernos podem ser associados ao próprio slide, a uma forma específica ou a um intervalo de texto dentro de um AutoShape. O método [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) aceita um argumento [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) além do slide e das coordenadas do marcador de comentário.

Quando `null` é passado para o argumento da forma, o comentário é um comentário de nível de slide. Seu marcador é posicionado pelas coordenadas fornecidas, mas não está associado a uma forma específica, portanto [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) retorna `null`. Quando um [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) é fornecido, o comentário é ancorado a essa forma. As coordenadas ainda definem a posição do marcador de comentário no slide, enquanto a associação à forma pode ser recuperada através de [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Ancorar um Comentário Moderno a uma Forma**

O exemplo chama [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) duas vezes: uma vez com uma forma `null` para um comentário de nível de slide e outra com um retângulo como âncora. Ler [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) imprime `True` para a verificação nula do comentário de nível de slide e `Revenue title` para o comentário ancorado. Ambos os comentários são salvos com a apresentação.

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

### **Ancorar Comentários a Diferentes Tipos de Forma**

Qualquer objeto de slide que implemente [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pode ser usado como âncora de forma. Exemplos comuns incluem [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) e instâncias de [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) como gráficos.

O exemplo usa [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) para associar um comentário a cada um de cinco tipos de forma: um AutoShape, um quadro de imagem, um grupo, um conector e um gráfico. A imagem do quadro é incorporada, portanto nenhuma imagem externa é necessária. Cada comentário tem sua própria posição de marcador, e a apresentação salva mantém todas as cinco associações de forma.

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

### **Ancorar um Comentário ao Texto e Definir Seu Status**

Para um comentário moderno associado a um [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) especifica a posição inicial do texto selecionado na caixa de texto da forma, enquanto [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) especifica o comprimento da seleção. Juntas, essas propriedades associam o comentário a um intervalo de texto específico dentro do AutoShape.

A propriedade [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) pode ser lida ou atualizada com um valor da enumeração [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — nenhum status específico de comentário moderno definido.
- `Active` — o comentário está ativo.
- `Resolved` — o comentário foi resolvido.
- `Closed` — o comentário está fechado.

O exemplo ancorra um comentário moderno às palavras “quarterly revenue” no texto de um retângulo. Ele calcula o [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) baseado em zero a partir do texto e define [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) para o número de caracteres selecionados. Após definir [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) para `Resolved`, ele salva e reabre a apresentação. As quatro verificações no console devem imprimir `True`, confirmando que a âncora da forma, o intervalo de texto e o status foram preservados.

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

### **Inspecionar Comentários Modernos Existentes**

O exemplo requer uma apresentação existente contendo comentários modernos e imprime seu texto, status e detalhes de âncora. Para inspecioná‑los, verifique quais comentários implementam [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), então examine [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) e [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Uma forma `null` indica um comentário de nível de slide. Para uma âncora [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), as propriedades de seleção de texto identificam o intervalo associado na caixa de texto da forma.

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

## **Remover Comentários**

Aspose.Slides para .NET permite remover todos os comentários e seus autores de uma apresentação ou excluir comentários selecionados mantendo o restante. Os exemplos a seguir demonstram ambas as abordagens e salvam a apresentação atualizada.

### **Remover Todos os Comentários e Autores de Comentários**

O exemplo abre uma apresentação existente e chama [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) para cada autor, então chama [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) para remover os próprios autores. A apresentação salva não contém nem comentários nem autores de comentários. Use uma apresentação que contenha comentários para observar a remoção.

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

### **Remover Comentários Específicos**

O exemplo cria dois comentários em um slide e usa [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) para localizar comentários de cada autor. Ele coleta comentários cujo texto é igual a “comment 1” antes de chamar [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), evitando alterações na coleção durante a seleção. A apresentação salva retém apenas “comment 2”.

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

## **Perguntas Frequentes**

**O Aspose.Slides oferece suporte a um status resolvido para comentários modernos?**

Sim. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) pode ser lido e definido com um valor da enumeração [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), incluindo `Resolved`. O status é armazenado na apresentação e pode ser lido novamente após o arquivo ser reaberto.

**As discussões em árvore (cadeias de respostas) são suportadas e há um limite de profundidade?**

Sim. Cada comentário pode referenciar seu [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), permitindo cadeias de respostas. A API não define um limite específico de profundidade de aninhamento.

**Em que sistema de coordenadas a posição do marcador de comentário é definida em um slide?**

A posição do marcador é definida por coordenadas de ponto flutuante no sistema de coordenadas do slide, permitindo posicioná‑lo com precisão no slide.