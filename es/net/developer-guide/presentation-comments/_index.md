---
title: Gestionar comentarios de presentación en .NET
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
- acceso al comentario
- editar comentario
- responder comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestiona comentarios de presentación con Aspose.Slides para .NET: añade, lee, edita, responde y elimina comentarios en presentaciones de PowerPoint de forma rápida y sencilla."
---
## **Visión general**

Este artículo explica cómo administrar los comentarios de una presentación con Aspose.Slides para .NET. Presenta los tipos principales relacionados con los comentarios y demuestra cómo añadir comentarios a diapositivas, acceder a comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios habituales de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de un comentario, crear cadenas de respuestas y eliminar los comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Al seleccionar un comentario se muestra su texto y la discusión relacionada.

Para solicitar que los comentarios se muestren u oculten al abrir una presentación sin modificar los propios comentarios, vea [Mostrar u ocultar comentarios al abrir una presentación](/slides/es/net/presentation-view-properties/).

## **¿Por qué añadir comentarios a las presentaciones?**

Puede utilizar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides para .NET ofrece las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), que brinda acceso a los autores de comentarios de la presentación.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection), que representa los comentarios asociados a un autor concreto.
* La interfaz [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment), que proporciona información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/net/aspose.slides/commentauthor), que brinda información sobre un autor, incluido su nombre, iniciales y los comentarios asociados.

## **Añadir comentarios a diapositivas**

El ejemplo crea dos diapositivas y registra un autor de comentarios con [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/). Utiliza [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) para colocar un comentario en cada diapositiva, luego recupera los comentarios de la primera diapositiva para ese autor con [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/). La consola muestra el texto del primer comentario dos veces, demostrando el acceso tanto a través de la diapositiva como del autor, y la presentación guardada contiene ambos comentarios.

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

## **Buscar o crear un autor de comentarios**

Cuando una revisión automatizada procesa la misma presentación de manera repetida, busque en su colección [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/) antes de añadir un autor. [FindByNameAndInitials](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbynameandinitials/) coincide tanto con el nombre como con las iniciales y devuelve una matriz de autores coincidentes, o una matriz vacía si no existen coincidencias. En contraste, [FindByName](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/findbyname/) busca solo por nombre, independientemente de las iniciales. Llamar a [AddAuthor](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/addauthor/) con un nombre e iniciales ya presentes en la colección lanza una excepción.

El ejemplo necesita un archivo de presentación con al menos una diapositiva. En cada una de dos pasadas, reutiliza el primer autor coincidente, o crea uno solo cuando el resultado está vacío. Si hay varias coincidencias, selecciona el primer elemento de la matriz sin combinar ni eliminar los demás autores. Luego llama a [AddComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addcomment/) para el autor seleccionado y guarda la presentación. La segunda pasada abre la salida de la primera pasada y repite la operación.

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

La segunda pasada añade otro comentario sin crear otro autor ni eliminar los comentarios existentes. El archivo final, `review_pass_2.pptx`, contiene ambos comentarios nuevos junto a los comentarios originales. Reutilizar un autor no deduplica los comentarios: para evitar añadir repetidamente el mismo comentario, implemente una detección de duplicados antes de añadirlo.

## **Acceder a los comentarios de diapositivas**

El ejemplo abre una presentación existente y lee su colección [CommentAuthors](https://reference.aspose.com/slides/net/aspose.slides/presentation/commentauthors/). Para cada autor, itera a través de [Comments](https://reference.aspose.com/slides/net/aspose.slides/icommentauthor/comments/) e imprime el número de diapositiva, el texto del comentario, el nombre del autor y la hora de creación. La presentación de entrada debe contener comentarios para producir salida en la consola.

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

Un comentario principal es el comentario original en la parte superior de una jerarquía de respuestas. La propiedad [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) de la interfaz [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) permite obtener o establecer el padre de un comentario.

El ejemplo crea comentarios de dos autores y utiliza [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) para crear respuestas, incluida una respuesta a otra respuesta. Pasar `null` a [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) recupera los comentarios de todos los autores; la consola sangra cada entrada según su profundidad en la jerarquía de respuestas. El ejemplo guarda la discusión completa, llama a [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) sobre el primer comentario raíz y guarda una segunda presentación con ese comentario y sus respuestas eliminados.

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
* Cuando se utiliza el método [Remove](https://reference.aspose.com/slides/net/aspose.slides/icomment/remove/) de la interfaz [IComment](https://reference.aspose.com/slides/net/aspose.slides/icomment) para eliminar un comentario, también se eliminan todas las respuestas a ese comentario.
* Si la propiedad [ParentComment](https://reference.aspose.com/slides/net/aspose.slides/icomment/parentcomment/) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).
{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma concreta o a un rango de texto dentro de un AutoShape. El método [ICommentCollection.AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) acepta un argumento [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) además de la diapositiva y las coordenadas del marcador del comentario.

Cuando se pasa `null` para el argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas suministradas, pero no está asociado a una forma concreta, por lo que [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) devuelve `null`. Cuando se suministra un [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), el comentario se ancla a esa forma. Las coordenadas siguen definiendo la posición del marcador del comentario en la diapositiva, mientras que la asociación de forma puede recuperarse a través de [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/).

### **Anclar un comentario moderno a una forma**

El ejemplo llama a [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) dos veces: una vez con una forma `null` para un comentario a nivel de diapositiva y otra con un rectángulo como ancla. Leer [Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/) muestra `True` para la verificación nula del comentario a nivel de diapositiva y `Revenue title` para el comentario anclado. Ambos comentarios se guardan con la presentación.

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

Cualquier objeto de diapositiva que implemente [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) puede usarse como ancla de forma. Los ejemplos habituales incluyen [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/net/aspose.slides/iconnector/) e instancias de [IGraphicalObject](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobject/) como gráficos.

El ejemplo utiliza [AddModernComment](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/addmoderncomment/) para asociar un comentario a cada uno de cinco tipos de forma: un AutoShape, un marco de imagen, un grupo, un conector y un gráfico. La imagen del cuadro se inserta mediante datos de imagen incrustados, por lo que no se requiere una imagen externa. Cada comentario tiene su propia posición del marcador, y la presentación guardada conserva las cinco asociaciones de forma.

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

Para un comentario moderno asociado a un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) especifica la posición inicial del texto seleccionado en el marco de texto de la forma, mientras que [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) indica la longitud de la selección. Juntas, estas propiedades asocian el comentario a un rango de texto concreto dentro del AutoShape.

La propiedad [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) puede leerse o actualizarse con un valor de la enumeración [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/):

- `NotDefined` — no se ha definido un estado específico para el comentario moderno.
- `Active` — el comentario está activo.
- `Resolved` — el comentario se ha resuelto.
- `Closed` — el comentario está cerrado.

El ejemplo ancla un comentario moderno a las palabras “quarterly revenue” en el texto de un rectángulo. Calcula el [TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/) basado en cero a partir del texto y define [TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) con el número de caracteres seleccionados. Después de establecer [Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) a `Resolved`, guarda y vuelve a abrir la presentación. Las cuatro comprobaciones en la consola deben imprimir `True`, confirmando que el ancla de forma, el rango de texto y el estado se han conservado.

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

El ejemplo necesita una presentación existente que contenga comentarios modernos e imprime su texto, estado y detalles del ancla. Para inspeccionarla, compruebe qué comentarios implementan [IModernComment](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/), luego examine [IModernComment.Shape](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/shape/), [IModernComment.TextSelectionStart](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionstart/), [IModernComment.TextSelectionLength](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/textselectionlength/) y [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/). Una forma `null` indica un comentario a nivel de diapositiva. Para un ancla de [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), las propiedades de selección de texto identifican el rango asociado en el marco de texto de la forma.

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

Aspose.Slides para .NET permite eliminar todos los comentarios y sus autores de una presentación o borrar comentarios seleccionados manteniendo el resto. Los ejemplos siguientes demuestran ambos enfoques y guardan la presentación actualizada.

### **Eliminar todos los comentarios y autores de comentarios**

El ejemplo abre una presentación existente y llama a [ICommentCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/clear/) para cada autor, luego llama a [ICommentAuthorCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icommentauthorcollection/clear/) para eliminar a los autores. La presentación guardada no contiene ni comentarios ni autores de comentarios. Use una presentación que contenga comentarios para observar la eliminación.

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

El ejemplo crea dos comentarios en una diapositiva y utiliza [GetSlideComments](https://reference.aspose.com/slides/net/aspose.slides/islide/getslidecomments/) para encontrar los comentarios de cada autor. Recopila los comentarios cuyo texto sea igual a “comment 1” antes de llamar a [ICommentCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/icommentcollection/remove/), evitando cambios en la colección durante la selección. La presentación guardada conserva solo “comment 2”.

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

## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado resuelto para los comentarios modernos?**

Sí. [IModernComment.Status](https://reference.aspose.com/slides/net/aspose.slides/imoderncomment/status/) puede leerse y establecerse con un valor de [ModernCommentStatus](https://reference.aspose.com/slides/net/aspose.slides/moderncommentstatus/), incluido `Resolved`. El estado se guarda en la presentación y puede leerse nuevamente después de volver a abrir el archivo.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [parent comment](https://reference.aspose.com/slides/net/aspose.slides/comment/parentcomment/), lo que permite crear cadenas de respuestas. La API no define un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de un comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarla con precisión en la diapositiva.