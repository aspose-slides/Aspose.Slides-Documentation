---
title: Gestionar comentarios de presentación en Node.js
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/nodejs-java/presentation-comments/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestiona los comentarios de presentaciones con Aspose.Slides for Node.js mediante Java: añade, lee, edita, responde y elimina comentarios en presentaciones de PowerPoint."
---
## **Visión general**

Este artículo explica cómo administrar los comentarios de una presentación con Aspose.Slides para Node.js mediante Java. Presenta los principales tipos relacionados con los comentarios y muestra cómo añadir comentarios a diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios comunes de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, crear cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Al seleccionar un comentario se muestra su texto y la discusión relacionada.

## **¿Por qué añadir comentarios a las presentaciones?**

Puede utilizar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides para Node.js mediante Java ofrece las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) que permite acceder a los autores de comentarios de la presentación.
* La clase [CommentCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/commentcollection/) que representa los comentarios asociados a un autor individual.
* La clase [Comment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/comment/) que proporciona información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/commentauthor/) que ofrece información sobre un autor, incluido su nombre, iniciales y los comentarios asociados.

## **Añadir comentarios a diapositivas**

El siguiente ejemplo muestra cómo añadir comentarios a diapositivas en una presentación de PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acceder a los comentarios de las diapositivas**

El siguiente ejemplo muestra cómo acceder a los comentarios existentes en una presentación de PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Responder a los comentarios**

Un comentario principal es el comentario original en la parte superior de una jerarquía de respuestas. Los métodos [Comment.getParentComment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/comment/getparentcomment/) y [Comment.setParentComment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/comment/setparentcomment/) le permiten obtener o establecer el comentario padre.

El siguiente ejemplo muestra cómo añadir respuestas e inspeccionar la jerarquía de comentarios resultante:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Cuando se utiliza el método [Comment.remove](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/comment/remove/) para eliminar un comentario, también se eliminan todas las respuestas a ese comentario.
* Si [Comment.setParentComment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/comment/setparentcomment/) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma concreta o a un rango de texto dentro de un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/). El método [CommentCollection.addModernComment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) acepta un argumento [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) además de la diapositiva y las coordenadas del marcador de comentario.

Cuando se pasa `null` para el argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas suministradas, pero no está asociado a una forma concreta, por lo que [ModernComment.getShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/getshape/) devuelve `null`. Cuando se proporciona una [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/), el comentario se ancla a esa forma. Las coordenadas siguen definiendo la posición del marcador de comentario en la diapositiva, mientras que la asociación con la forma puede recuperarse mediante [ModernComment.getShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Anclar un comentario moderno a una forma**

El siguiente ejemplo crea tanto un comentario moderno a nivel de diapositiva como un comentario moderno anclado a un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) concreto. A continuación, lee la forma asociada a cada comentario.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Anclar comentarios a diferentes tipos de forma**

Cualquier objeto de diapositiva derivado de [Shape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) puede utilizarse como ancla de forma. Los ejemplos más habituales incluyen [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/connector/) y [GraphicalObject](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/graphicalobject/) como gráficos.

El siguiente ejemplo crea varios tipos de forma comunes y asocia un comentario moderno a cada uno.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Anclar un comentario a texto y establecer su estado**

Para un comentario moderno asociado a un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) y [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) acceden a la posición inicial del texto seleccionado en el marco de texto de la forma. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) y [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) acceden a la longitud de la selección. En conjunto, estos valores asocian el comentario a un rango de texto específico dentro del [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/).

Los métodos [ModernComment.getStatus](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/getstatus/) y [ModernComment.setStatus](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/setstatus/) acceden a un valor de la enumeración [ModernCommentStatus](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — no se ha definido un estado concreto para el comentario moderno.
- `Active` — el comentario está activo.
- `Resolved` — el comentario ha sido resuelto.
- `Closed` — el comentario está cerrado.

El siguiente ejemplo crea un comentario moderno anclado a una forma, lo asocia a una selección de texto, lo marca como resuelto, guarda la presentación y verifica los valores tras volver a abrir el archivo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Examinar los comentarios modernos existentes**

Para examinar una presentación existente, compruebe qué comentarios son instancias de [ModernComment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/), luego inspeccione [ModernComment.getShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) y [ModernComment.getStatus](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/getstatus/). Una forma `null` indica un comentario a nivel de diapositiva. Para una ancla de [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/), los métodos de selección de texto identifican el rango asociado en el marco de texto de la forma.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Eliminar comentarios**

### **Eliminar todos los comentarios y autores de comentarios**

El siguiente ejemplo muestra cómo eliminar todos los comentarios y autores de comentarios de una presentación:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eliminar comentarios específicos**

El siguiente ejemplo muestra cómo eliminar comentarios específicos de una diapositiva:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado resuelto para los comentarios modernos?**

Sí. [ModernComment.getStatus](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/getstatus/) y [ModernComment.setStatus](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncomment/setstatus/) acceden a un valor de [ModernCommentStatus](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/moderncommentstatus/), incluido `Resolved`. El estado se almacena en la presentación y puede leerse nuevamente después de volver a abrir el archivo.

**¿Se admiten discusiones en hilo (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [parent comment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/comment/getparentcomment/), lo que permite crear cadenas de respuestas. La API no define un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de un comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarlo con precisión en la diapositiva.