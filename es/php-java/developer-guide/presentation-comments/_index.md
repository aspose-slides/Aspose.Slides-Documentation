---
title: Gestionar comentarios de presentación en PHP
linktitle: Comentarios de presentación
type: docs
weight: 100
url: /es/php-java/presentation-comments/
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
- PHP
- Aspose.Slides
description: "Gestiona los comentarios de presentaciones con Aspose.Slides para PHP mediante Java: añade, lee, edita, responde y elimina comentarios en presentaciones de PowerPoint de forma rápida y sencilla."
---
## **Visión general**

Este artículo explica cómo administrar los comentarios de una presentación con Aspose.Slides para PHP mediante Java. Presenta los tipos principales relacionados con los comentarios y demuestra cómo añadir comentarios a las diapositivas, acceder a los comentarios existentes, trabajar con respuestas y comentarios modernos, y eliminar comentarios de una presentación.

Los ejemplos cubren escenarios habituales de revisión y colaboración en PowerPoint, como asignar comentarios a autores, leer el texto y los metadatos de los comentarios, construir cadenas de respuestas y eliminar comentarios seleccionados o todos los comentarios.

En PowerPoint, los comentarios aparecen como anotaciones en las diapositivas. Al seleccionar un comentario se muestra su texto y la discusión relacionada.

Para solicitar que los comentarios se muestren u oculten al abrir una presentación sin modificar los propios comentarios, vea [Mostrar u ocultar comentarios al abrir una presentación](/slides/es/php-java/presentation-view-properties/).

## **¿Por qué añadir comentarios a las presentaciones?**

Puedes usar los comentarios para proporcionar retroalimentación y colaborar con colegas al revisar presentaciones.

Aspose.Slides para PHP mediante Java proporciona las siguientes API para trabajar con comentarios:

* La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que brinda acceso a los autores de comentarios de la presentación.
* La clase [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) que representa los comentarios asociados a un autor individual.
* La clase [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) que proporciona información sobre un comentario, incluido su autor, hora de creación, posición y texto.
* La clase [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) que brinda información sobre un autor, incluido su nombre, iniciales y comentarios asociados.

## **Añadir comentarios a diapositivas**

El ejemplo crea dos diapositivas y registra un autor de comentarios con [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Usa [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) para colocar un comentario en cada diapositiva, luego recupera los comentarios de la primera diapositiva para ese autor con [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). La consola muestra el texto del primer comentario dos veces, demostrando el acceso tanto a través de la diapositiva como del autor, y la presentación guardada contiene ambos comentarios.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));

    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Buscar o crear un autor de comentarios**

Cuando una revisión automatizada procesa la misma presentación repetidamente, busca en la colección devuelta por [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) antes de añadir un autor. [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) coincide tanto con el nombre como con las iniciales y devuelve una matriz de autores coincidentes, o una matriz vacía si no hay coincidencias. En contraste, [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) busca solo por nombre, sin importar las iniciales. Llamar a [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) con un nombre e iniciales ya presentes en la colección lanza una excepción.

El ejemplo requiere un archivo de presentación con al menos una diapositiva. En cada una de dos pasadas, reutiliza el primer autor coincidente, o crea uno solo cuando el resultado está vacío. Si hay varias coincidencias, selecciona el primer elemento de la matriz sin fusionar o eliminar los demás autores. Luego llama a [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) para el autor seleccionado y guarda la presentación. La segunda pasada abre la salida de la primera pasada y repite la operación.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$authorName = "Reviewer";
$authorInitials = "RV";

$inputFile = "input.pptx";
$position = new Point2DFloat(20, 20);
$arrayClass = new JavaClass("java.lang.reflect.Array");

for ($pass = 1; $pass <= 2; $pass++) {
    $presentation = new Presentation($inputFile);
    try {
        $matches = $presentation->getCommentAuthors()->findByNameAndInitials($authorName, $authorInitials);
        $matchCount = java_values($arrayClass->getLength($matches));

        $author = $matchCount > 0 ? $matches[0] : $presentation->getCommentAuthors()->addAuthor($authorName, $authorInitials);
        $createdTime = new Java("java.util.Date");
        $author->getComments()->addComment("Please review this slide.", $presentation->getSlides()->get_Item(0), $position, $createdTime);

        $outputFile = "review_pass_" . $pass . ".pptx";
        $presentation->save($outputFile, SaveFormat::Pptx);
        $inputFile = $outputFile;
    } finally {
        $presentation->dispose();
    }
}
```

La segunda pasada añade otro comentario sin agregar otro autor ni eliminar los comentarios existentes. El archivo final, `review_pass_2.pptx`, contiene ambos comentarios nuevos junto a los comentarios originales. Reutilizar un autor no deduplica los comentarios: para evitar añadir repetidamente el mismo comentario, implemente una detección de duplicados independiente antes de añadirlo.

## **Acceder a los comentarios de diapositivas**

El ejemplo abre una presentación existente y lee la colección devuelta por [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). Para cada autor, itera a través de la colección devuelta por [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) e imprime el número de diapositiva, el texto del comentario, el nombre del autor y la hora de creación. La presentación de entrada debe contener comentarios para producir salida en la consola.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Responder a los comentarios**

Un comentario padre es el comentario original en la parte superior de una jerarquía de respuestas. Los métodos [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) y [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) permiten obtener o establecer el padre de un comentario.

El ejemplo crea comentarios de dos autores y usa [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) para construir respuestas, incluida una respuesta a otra respuesta. Pasar `null` a [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) recupera los comentarios de todos los autores; la consola sangra cada entrada según su profundidad en la jerarquía de respuestas. El ejemplo guarda la discusión completa, llama a [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) en el primer comentario raíz y guarda una segunda presentación con ese comentario y sus respuestas eliminados.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* Cuando se usa el método [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) para eliminar un comentario, también se eliminan todas sus respuestas.
* Si [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) crea una referencia circular, se lanza una [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Añadir comentarios modernos**

Los comentarios modernos pueden asociarse a la propia diapositiva, a una forma específica o a un rango de texto dentro de un AutoShape. El método [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) acepta un argumento [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) además de la diapositiva y las coordenadas del marcador de comentario.

Cuando se pasa `null` como argumento de forma, el comentario es un comentario a nivel de diapositiva. Su marcador se posiciona mediante las coordenadas suministradas, pero no está asociado a una forma concreta, por lo que [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) devuelve `null`. Cuando se proporciona una [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), el comentario queda anclado a esa forma. Las coordenadas siguen definiendo la posición del marcador de comentario en la diapositiva, mientras que la asociación con la forma puede recuperarse a través de [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Anclar un comentario moderno a una forma**

El ejemplo llama a [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) dos veces: una con una forma `null` para un comentario a nivel de diapositiva y otra con un rectángulo como ancla. Al leer [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) se imprime `true` para la comprobación de nulidad del comentario a nivel de diapositiva y `Revenue title` para el comentario anclado. Ambos comentarios se guardan con la presentación.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Anclar comentarios a diferentes tipos de forma**

Cualquier objeto de diapositiva representado por la clase [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) puede usarse como ancla de forma. Los ejemplos habituales incluyen [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) y [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) como gráficos.

El ejemplo usa [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) para asociar un comentario a cada uno de cinco tipos de forma: un AutoShape, un marco de imagen, un grupo, un conector y un gráfico. La imagen utiliza datos incrustados, por lo que no se requiere una imagen externa. Cada comentario tiene su propia posición de marcador, y la presentación guardada conserva las cinco asociaciones de forma.

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");

    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Anclar un comentario a texto y establecer su estado**

Para un comentario moderno asociado a un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) y [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) acceden a la posición inicial del texto seleccionado en el marco de texto de la forma. [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) y [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) obtienen la longitud de la selección. Juntos, estos valores asocian el comentario a un rango de texto específico dentro del AutoShape.

Los métodos [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) y [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) acceden a un valor de las constantes [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):
- `NotDefined` — no se ha definido un estado específico de comentario moderno.
- `Active` — el comentario está activo.
- `Resolved` — el comentario ha sido resuelto.
- `Closed` — el comentario está cerrado.

El ejemplo ancla un comentario moderno a las palabras "quarterly revenue" en el texto de un rectángulo. Calcula el inicio de la selección (basado en cero) a partir del texto y lo pasa a [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) y usa [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) para establecer el número de caracteres seleccionados. Después de llamar a [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) con `Resolved`, guarda y vuelve a abrir la presentación. Las cuatro comprobaciones en la consola deben imprimir `true`, confirmando que el ancla de la forma, el rango de texto y el estado se conservan.

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **Inspeccionar comentarios modernos existentes**

El ejemplo requiere una presentación existente que contenga comentarios modernos y muestra su texto, estado y detalles del ancla. Para inspeccionarla, comprueba si cada comentario es un [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/), luego examina [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) y [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). Una forma `null` indica un comentario a nivel de diapositiva. Para un ancla de [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), los métodos de selección de texto identifican el rango asociado en el marco de texto de la forma.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Eliminar comentarios**

Aspose.Slides para PHP mediante Java permite eliminar todos los comentarios y sus autores de una presentación o borrar comentarios seleccionados manteniendo el resto. Los siguientes ejemplos demuestran ambos enfoques y guardan la presentación actualizada.

### **Eliminar todos los comentarios y autores de comentarios**

El ejemplo abre una presentación existente y llama a [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) para cada autor, luego llama a [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) para eliminar a los propios autores. La presentación guardada no contiene ni comentarios ni autores de comentarios. Utiliza una presentación que contenga comentarios para observar la eliminación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Eliminar comentarios específicos**

El ejemplo crea dos comentarios en una diapositiva y usa [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) para encontrar los comentarios de cada autor. Recoge los comentarios cuyo texto sea "comment 1" antes de llamar a [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/), evitando cambios en la colección durante la selección. La presentación guardada conserva solo "comment 2".

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Aspose.Slides admite un estado resuelto para los comentarios modernos?**

Sí. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) y [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) acceden a un valor de [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/), incluido `Resolved`. El estado se almacena en la presentación y puede leerse de nuevo después de volver a abrir el archivo.

**¿Se admiten discusiones en hilos (cadenas de respuestas) y existe un límite de anidamiento?**

Sí. Cada comentario puede referenciar su [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), lo que permite cadenas de respuestas. La API no define un límite específico de profundidad de anidamiento.

**¿En qué sistema de coordenadas se define la posición del marcador de un comentario en una diapositiva?**

La posición del marcador se define mediante coordenadas de punto flotante en el sistema de coordenadas de la diapositiva, lo que permite colocarlo con precisión en la diapositiva.