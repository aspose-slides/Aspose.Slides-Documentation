---
title: Gestionar marcadores de posición de presentación en PHP
linktitle: Gestionar marcadores de posición
type: docs
weight: 10
url: /es/php-java/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- marcador de posición de contenido
- texto de sugerencia
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo inspeccionar y editar los marcadores de posición de texto, imagen, gráfico y contenido, y comprender la herencia de los marcadores de posición con Aspose.Slides para PHP mediante Java."
---
## **Visión general**

Un marcador de posición es una forma que reserva una posición para un tipo particular de contenido en una plantilla de presentación. Los ejemplos más comunes son marcadores de título, cuerpo, imagen, gráfico y marcadores de contenido de uso general. A diferencia de una forma ordinaria, un marcador de posición puede heredar su posición, tamaño, formato y otras configuraciones de una diapositiva de diseño o de una diapositiva maestra.

Aspose.Slides expone la información de los marcadores de posición a través del método [Shape::getPlaceholder](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getplaceholder/). El método devuelve un objeto [Placeholder](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholder/) o `null` para una forma normal. Utilice [Placeholder::getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholder/gettype/) para determinar qué se pretende que contenga el marcador de posición.

La clase de forma sigue siendo importante después de conocer el tipo de marcador de posición:

- Un marcador de posición vacío de texto, imagen, gráfico o contenido suele representarse mediante un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/).
- Un marcador de posición de imagen rellenado puede representarse mediante un [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/).
- Un marcador de posición de gráfico rellenado puede representarse mediante un [Chart](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/).
- Un marcador de posición de contenido puede contener varios tipos de contenido. Compruebe tanto [Placeholder::getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholder/gettype/) como la clase de forma en tiempo de ejecución en lugar de asumir que cada marcador de posición es un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholder/gettype/) describe el papel de un marcador de posición; no garantiza la clase de forma en tiempo de ejecución. Siempre use una verificación de tipo antes de acceder a miembros específicos de texto, imagen, gráfico, tabla o multimedia.
{{% /alert %}}

## **Entender la herencia de los marcadores de posición**

Los marcadores de posición forman una jerarquía:

1. Una diapositiva maestra define estilos reutilizables y, en algunos casos, marcadores de nivel maestro.
2. Una diapositiva de diseño define la disposición utilizada por una o más diapositivas normales y puede heredar de la maestra.
3. Una diapositiva normal contiene los marcadores de posición para esa diapositiva y puede heredar de su diseño.

Llame a [Shape::getBasePlaceholder](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getbaseplaceholder/) para subir un nivel en esta jerarquía. Normalmente, un marcador de posición de diapositiva devuelve su marcador de posición de diseño; un marcador de posición de diseño puede devolver su marcador de posición maestro. El método devuelve `null` cuando la forma no tiene marcador de posición base.

El siguiente ejemplo enumera los marcadores de posición en la primera diapositiva y muestra sus marcadores de posición base:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Editar un marcador de posición en una diapositiva normal crea o modifica una anulación local para esa diapositiva. Editar el diseño o la maestra relacionados puede afectar a todas las diapositivas que aún heredan esa configuración. Una forma ordinaria local no tiene marcador de posición base y no comienza a heredar simplemente porque ocupa las mismas coordenadas.

## **Cambiar texto en un marcador de posición**

Los marcadores de posición de título, título centrado, subtítulo, cuerpo y texto normalmente admiten texto. Compruebe si es un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) antes de usar su método [getTextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/gettextframe/).

Este ejemplo actualiza el primer marcador de posición de título en la primera diapositiva y guarda el resultado:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Este patrón evita tratar los marcadores de posición de imagen, gráfico, tabla o multimedia como objetos [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/). También identifica el marcador de posición por su propósito en lugar de depender de un índice de forma frágil.

## **Establecer texto de sugerencia en un diseño**

El texto de sugerencia es la instrucción en tiempo de diseño que se muestra en un marcador de posición vacío, como *Haga clic para añadir el título*. Establezca un texto de sugerencia personalizado en el marcador de posición del diseño en lugar de intentar alcanzarlo a través de la colección de formas de una diapositiva normal. Acceda al diseño mediante [Slide::getLayoutSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getLayoutSlide) y recorra la colección devuelta por [BaseSlide::getShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/#getShapes).

El siguiente ejemplo cambia las sugerencias de título y subtítulo en el diseño utilizado por la primera diapositiva:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El texto de sugerencia no es contenido de diapositiva normal. Está destinado a los marcadores de posición vacíos en aplicaciones de edición como PowerPoint. Una vez que un usuario o programa proporciona contenido real, la sugerencia deja de mostrarse. Cambiar una sugerencia tampoco reemplaza el texto existente en las diapositivas que utilizan el diseño.

## **Actualizar un marcador de posición de imagen**

Hay dos casos a gestionar:

- Si el marcador de posición de imagen ya está rellenado y representado por un [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/), reemplace la imagen mediante [PictureFillFormat::getPicture](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturefillformat/getpicture/) y [SlidesPicture::setImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidespicture/setimage/).
- Si aún es un marcador de posición vacío, añada un marco de imagen en las coordenadas del marcador de posición con [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addpictureframe/) y elimine el marcador de posición vacío.

El siguiente ejemplo admite ambos casos y guarda la presentación:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La sustitución creada para un marcador de posición vacío es un marco de imagen local, no un nuevo marcador de posición, porque [Shape::getPlaceholder](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getplaceholder/) no ofrece un setter. Mantiene la posición reservada pero ya no hereda el comportamiento específico del marcador de posición. Si es esencial conservar la relación del marcador de posición, prepare y rellene el marcador de posición en PowerPoint primero, y luego actualice el [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) resultante con Aspose.Slides.

Para la transparencia de imágenes, recorte y otros efectos específicos de imágenes, consulte [Manage Picture Frames](/slides/es/php-java/picture-frame/). esas operaciones pertenecen al marco de imagen o al relleno de imagen, no a los metadatos del marcador de posición.

## **Trabajar con marcadores de posición de gráfico y contenido**

Un marcador de posición de gráfico rellenado puede representarse mediante un [Chart](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/). Este ejemplo encuentra dicho gráfico tanto por el tipo de marcador de posición como por la clase en tiempo de ejecución, cambia su título y guarda el archivo:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Un marcador de posición de contenido general suele tener [PlaceholderType::Object](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholdertype/). En PowerPoint actúa como un lanzador para varios tipos de contenido, incluidos gráficos, tablas, diagramas, imágenes y multimedia. Después de que se haya rellenado, inspeccione la clase de forma real para saber qué contiene. Los diseños especializados también pueden exponer [PlaceholderType::Chart](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholdertype/), o [PlaceholderType::Diagram](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholdertype/).

Aspose.Slides no convierte un marcador de posición vacío de [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) en un [Chart](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/) simplemente cambiando [Placeholder::getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/placeholder/gettype/); el tipo no puede modificarse mediante la clase. Para rellenar programáticamente un gráfico o área de contenido vacía, añada el objeto necesario en las coordenadas del marcador de posición y luego elimine el marcador de posición vacío. El siguiente ejemplo hace eso para un gráfico:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El gráfico añadido es un gráfico local ordinario. Ocupa el área del marcador de posición pero no hereda del marcador de posición del diseño. Utilice los artículos dedicados a la gestión de gráficos [chart management articles](/slides/es/php-java/powerpoint-charts/) cuando necesite reemplazar sus categorías, series o datos del libro de trabajo.

## **Ejemplo completo: actualizar contenido de texto o imagen**

El siguiente ejemplo completo abre una plantilla, busca en la primera diapositiva un marcador de posición de título o de imagen, comprueba los tipos de marcador de posición y de forma, actualiza el contenido apropiado y guarda el resultado. El ejemplo evita deliberadamente asumir un índice de forma o tratar cada marcador de posición como la misma clase.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Qué es un marcador de posición base?**

Un marcador de posición base es la forma correspondiente en el diseño o la maestra de la que otro marcador de posición hereda. Utilice [Shape::getBasePlaceholder](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getbaseplaceholder/) para obtenerlo. Una forma local ordinaria devuelve `null` porque no forma parte de la jerarquía de marcadores de posición.

**¿Puedo cambiar todos los títulos de diapositiva editando un marcador de posición del diseño?**

Puede cambiar el formato heredado o el texto de sugerencia a través de un diseño, pero el contenido de los títulos existentes se almacena en las diapositivas normales. Para reemplazar el texto real del título en toda la presentación, recorra las diapositivas y actualice cada marcador de posición de título.

**¿Cómo gestiono los marcadores de posición de fecha, número de diapositiva, encabezado y pie de página?**

Utilice los gestores de encabezado y pie de página en el alcance apropiado (diapositiva, diseño, maestra, notas o folleto). Consulte [Manage Presentation Header and Footer](/slides/es/php-java/presentation-header-and-footer/) para obtener ejemplos completos.