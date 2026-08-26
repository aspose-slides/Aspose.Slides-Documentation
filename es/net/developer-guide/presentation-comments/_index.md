---
title: Gestionar comentarios de presentaciones en .NET
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/net/presentation-comments/
keywords:
- comentario
- comentario moderno
- comentarios de PowerPoint
- comentarios de presentación
- comentarios de diapositiva
- añadir comentario
- acceder al comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestione los comentarios de presentaciones con Aspose.Slides para .NET: añada, lea, edite, responda y elimine comentarios en presentaciones de PowerPoint de forma rápida y sencilla."
---
## **Visión general**

Este artículo explica cómo gestionar los comentarios de una presentación con Aspose.Slides para .NET. Presenta los principales tipos relacionados con los comentarios y muestra cómo añadir comentarios a diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios habituales de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, crear cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Al seleccionar un comentario se muestra su texto y la discusión relacionada.

## **¿Por qué añadir comentarios a las presentaciones?**

Puedes usar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides para .NET proporciona las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) que proporciona acceso a los autores de comentarios de la presentación.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/es/net/aspose.slides/icommentcollection) que representa los comentarios asociados a un autor individual.
* La interfaz [IComment](https://reference.aspose.com/slides/es/net/aspose.slides/icomment) que proporciona información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/es/net/aspose.slides/commentauthor) que proporciona información sobre un autor, incluidos su nombre, iniciales y comentarios asociados.

## **Añadir comentarios a diapositivas**

El siguiente ejemplo muestra cómo añadir comentarios a diapositivas en una presentación de PowerPoint:

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

## **Acceder a los comentarios de diapositivas**

El siguiente ejemplo muestra cómo acceder a los comentarios existentes en una presentación de PowerPoint:

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

## **Responder a los comentarios**

Un comentario principal es el comentario original en la parte superior de una jerarquía de respuestas. La propiedad [ParentComment](https://reference.aspose.com/slides/es/net/aspose.slides/icomment/properties/parentcomment) de la interfaz [IComment](https://reference.aspose.com/slides/es/net/aspose.slides/icomment) permite obtener o establecer el comentario padre.

El siguiente ejemplo muestra cómo añadir respuestas e inspeccionar la jerarquía de comentarios resultante:

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

* Cuando se utiliza el método [Remove](https://reference.aspose.com/slides/es/net/aspose.slides/icomment/methods/remove) de la interfaz [IComment](https://reference.aspose.com/slides/es/net/aspose.slides/icomment), para eliminar un comentario, también se eliminan todas las respuestas a ese comentario.
* Si la propiedad [ParentComment](https://reference.aspose.com/slides/es/net/aspose.slides/icomment/properties/parentcomment) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxeditexception).

{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma específica o a un rango de texto dentro de un AutoShape. El método [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/es/net/aspose.slides/icommentcollection/addmoderncomment/) acepta un argumento [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/) además de la diapositiva y las coordenadas del marcador de comentario.

Cuando se pasa `null` como argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas proporcionadas, pero no está asociado a una forma concreta, por lo que [IModernComment.Shape](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/shape/) devuelve `null`. Cuando se suministra un [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/), el comentario se ancla a esa forma. Las coordenadas siguen definiendo la posición del marcador de comentario en la diapositiva, mientras que la asociación de forma puede obtenerse a través de [IModernComment.Shape](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/shape/).

### **Anclar un comentario moderno a una forma**

El siguiente ejemplo crea tanto un comentario moderno a nivel de diapositiva como un comentario moderno anclado a un AutoShape específico. Luego lee la forma asociada a cada comentario.

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

### **Anclar comentarios a diferentes tipos de forma**

Cualquier objeto de diapositiva que implemente [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/) puede usarse como ancla de forma. Los ejemplos comunes incluyen instancias de [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/es/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/es/net/aspose.slides/iconnector/) y [IGraphicalObject](https://reference.aspose.com/slides/es/net/aspose.slides/igraphicalobject/) como gráficos.

El siguiente ejemplo crea varios tipos de forma comunes y asocia un comentario moderno a cada uno.

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

### **Anclar un comentario a texto y establecer su estado**

Para un comentario moderno asociado a un [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/textselectionstart/) indica la posición inicial del texto seleccionado en el marco de texto de la forma, mientras que [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/textselectionlength/) indica la longitud de la selección. Juntas, estas propiedades asocian el comentario con un rango de texto específico dentro del AutoShape.

La propiedad [IModernComment.Status](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/status/) puede leerse o actualizarse con un valor de la enumeración [ModernCommentStatus](https://reference.aspose.com/slides/es/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — no se ha definido ningún estado específico de comentario moderno.
- `Active` — el comentario está activo.
- `Resolved` — el comentario se ha resuelto.
- `Closed` — el comentario está cerrado.

El siguiente ejemplo crea un comentario moderno anclado a una forma, lo asocia a una selección de texto, lo marca como resuelto, guarda la presentación y verifica los valores después de volver a abrir el archivo.

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

### **Inspeccionar comentarios modernos existentes**

Para inspeccionar una presentación existente, comprueba qué comentarios implementan [IModernComment](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/), luego examina [IModernComment.Shape](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/textselectionlength/) y [IModernComment.Status](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/status/). Una forma `null` indica un comentario a nivel de diapositiva. Para un ancla de [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/), las propiedades de selección de texto identifican el rango asociado en el marco de texto de la forma.

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

## **Eliminar comentarios**

### **Eliminar todos los comentarios y autores de comentarios**

El siguiente ejemplo muestra cómo eliminar todos los comentarios y autores de comentarios de una presentación:

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

### **Eliminar comentarios específicos**

El siguiente ejemplo muestra cómo eliminar comentarios específicos de una diapositiva:

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

**¿Aspose.Slides admite un estado resuelto para los comentarios modernos?**

Sí. La [IModernComment.Status](https://reference.aspose.com/slides/es/net/aspose.slides/imoderncomment/status/) puede leerse y establecerse con un valor de [ModernCommentStatus](https://reference.aspose.com/slides/es/net/aspose.slides/moderncommentstatus/), incluido `Resolved`. El estado se almacena en la presentación y puede leerse nuevamente después de volver a abrir el archivo.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y hay un límite de anidamiento?**

Sí. Cada comentario puede hacer referencia a su [parent comment](https://reference.aspose.com/slides/es/net/aspose.slides/comment/parentcomment/), lo que permite cadenas de respuestas. La API no define un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de un comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarlo con precisión en la diapositiva.