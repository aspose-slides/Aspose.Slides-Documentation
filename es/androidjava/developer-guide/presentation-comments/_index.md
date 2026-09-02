---
title: Gestionar comentarios de presentaciones en Android
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/androidjava/presentation-comments/
keywords:
- comentario
- comentario moderno
- comentarios de PowerPoint
- comentarios de presentación
- comentarios de diapositiva
- agregar comentario
- acceder al comentario
- editar comentario
- responder al comentario
- eliminar comentario
- borrar comentario
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Gestiona los comentarios de presentaciones con Aspose.Slides para Android mediante Java: agrega, lee, edita, responde y elimina comentarios en presentaciones de PowerPoint de forma rápida y sencilla."
---
## **Resumen**

Este artículo explica cómo administrar los comentarios de una presentación con Aspose.Slides para Android mediante Java. Introduce los principales tipos relacionados con los comentarios y demuestra cómo agregar comentarios a diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios habituales de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, construir cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Al seleccionar un comentario se muestra su texto y la discusión relacionada.

## **¿Por qué agregar comentarios a presentaciones?**

Puedes usar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides para Android mediante Java ofrece las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) que brinda acceso a los autores de comentarios de la presentación.
* La interfaz [ICommentCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icommentcollection/) que representa los comentarios asociados a un autor individual.
* La interfaz [IComment](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icomment/) que proporciona información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/commentauthor/) que brinda información sobre un autor, incluido su nombre, iniciales y los comentarios asociados.

## **Agregar comentarios a diapositivas**

El siguiente ejemplo muestra cómo agregar comentarios a diapositivas en una presentación de PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acceder a los comentarios de diapositivas**

El siguiente ejemplo muestra cómo acceder a los comentarios existentes en una presentación de PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Responder a los comentarios**

Un comentario principal es el comentario original en la parte superior de una jerarquía de respuestas. Los métodos [IComment.getParentComment](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icomment/#getParentComment--) y [IComment.setParentComment](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) le permiten obtener o establecer el comentario padre.

El siguiente ejemplo muestra cómo agregar respuestas e inspeccionar la jerarquía de comentarios resultante:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    PointF position = new PointF(10, 10);
    Date createdTime = new Date();

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Advertencia" %}}
* Cuando se utiliza el método [IComment.remove](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icomment/#remove--) para eliminar un comentario, también se eliminan todas las respuestas a ese comentario.
* Si [IComment.setParentComment](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Agregar comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma específica o a un rango de texto dentro de un AutoShape. El método [ICommentCollection.addModernComment](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) acepta un argumento [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/) además de la diapositiva y las coordenadas del marcador de comentario.

Cuando se pasa `null` como argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas suministradas, pero no está asociado a una forma concreta, por lo que [IModernComment.getShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getShape--) devuelve `null`. Cuando se proporciona un [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/), el comentario se ancla a esa forma. Las coordenadas siguen definiendo la posición del marcador del comentario en la diapositiva, mientras que la asociación con la forma puede recuperarse a través de [IModernComment.getShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Anclar un comentario moderno a una forma**

El siguiente ejemplo crea tanto un comentario moderno a nivel de diapositiva como un comentario moderno anclado a un AutoShape específico. Luego lee la forma asociada de cada comentario.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Anclar comentarios a diferentes tipos de forma**

Cualquier objeto de diapositiva que implemente [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/) puede usarse como ancla de forma. Los ejemplos más habituales incluyen [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iconnector/) e instancias de [IGraphicalObject](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/igraphicalobject/) como gráficos.

El siguiente ejemplo crea varios tipos de forma comunes y asocia un comentario moderno con cada una.

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Anclar un comentario a texto y establecer su estado**

Para un comentario moderno asociado a un [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/), los métodos [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) y [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) acceden a la posición inicial del texto seleccionado en el marco de texto de la forma. Los métodos [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) y [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) acceden a la longitud de la selección. Juntos, estos valores asocian el comentario a un rango de texto específico dentro del AutoShape.

Los métodos [IModernComment.getStatus](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getStatus--) y [IModernComment.setStatus](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) acceden a un valor de las constantes [ModernCommentStatus](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — no se ha definido un estado específico para el comentario moderno.
- `Active` — el comentario está activo.
- `Resolved` — el comentario ha sido resuelto.
- `Closed` — el comentario está cerrado.

El siguiente ejemplo crea un comentario moderno anclado a una forma, lo asocia a una selección de texto, lo marca como resuelto, guarda la presentación y verifica los valores después de volver a abrir el archivo.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    PointF commentPosition = new PointF(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Inspeccionar comentarios modernos existentes**

Para inspeccionar una presentación existente, comprueba qué comentarios implementan [IModernComment](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/), luego examina [IModernComment.getShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) y [IModernComment.getStatus](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Una forma `null` indica un comentario a nivel de diapositiva. Para una ancla [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/), los métodos de selección de texto identifican el rango asociado en el marco de texto de la forma.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Eliminar comentarios**

### **Eliminar todos los comentarios y autores de comentarios**

El siguiente ejemplo muestra cómo eliminar todos los comentarios y los autores de comentarios de una presentación:

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eliminar comentarios específicos**

El siguiente ejemplo muestra cómo eliminar comentarios específicos de una diapositiva:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado resuelto para los comentarios modernos?**

Sí. Los métodos [IModernComment.getStatus](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#getStatus--) y [IModernComment.setStatus](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) acceden a un valor de [ModernCommentStatus](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/moderncommentstatus/), incluido `Resolved`. El estado se almacena en la presentación y puede leerse nuevamente después de volver a abrir el archivo.

**¿Se admiten discusiones en hilo (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [comentario padre](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icomment/#getParentComment--), lo que permite cadenas de respuestas. La API no define un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarlo con precisión en la diapositiva.