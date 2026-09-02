---
title: Convertir diapositivas de presentación a imágenes en PHP
linktitle: Diapositiva a Imagen
type: docs
weight: 35
url: /es/php-java/convert-slide/
keywords:
- convertir diapositiva
- exportar diapositiva
- diapositiva a imagen
- guardar diapositiva como imagen
- diapositiva a EMF
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a mapa de bits
- diapositiva a TIFF
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: Convertir diapositivas de presentaciones PPT, PPTX y ODP a PNG, JPEG, GIF, TIFF, EMF y otros formatos de imagen en PHP con Aspose.Slides.
---
## **Introducción**

Aspose.Slides para PHP a través de Java puede renderizar diapositivas individuales de presentaciones PowerPoint y OpenDocument como PNG, JPEG, GIF, TIFF y otros formatos de imagen.

Para convertir una diapositiva en una imagen, siga estos pasos:

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
2. Seleccione la diapositiva que desea renderizar.
3. Si es necesario, configure la renderización con la clase [RenderingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/tiffoptions/).
4. Llame al método [Slide::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getImage). Devuelve un objeto [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/).
5. Llame al método [IImage::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/#save) y especifique el formato de salida con un valor [ImageFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/imageformat/).

## **Convertir una diapositiva a una imagen PNG**

La conversión más simple utiliza la configuración de renderizado predeterminada. El objeto [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) resultante puede procesarse en memoria o guardarse en un archivo.

El siguiente ejemplo en PHP renderiza la primera diapositiva y la guarda como imagen PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Convertir diapositivas a imágenes con tamaños personalizados**

Utilice la sobrecarga [Slide::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getImage) que acepta un valor [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) para renderizar una diapositiva con dimensiones de píxel exactas.

El siguiente ejemplo crea una imagen JPEG de 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Convertir diapositivas con notas y comentarios a imágenes**

Por defecto, las imágenes de diapositivas no incluyen notas ni comentarios. Pase un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/notescommentslayoutingoptions/) al método [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) para controlar dónde aparecen las notas y los comentarios.

El siguiente ejemplo coloca notas truncadas debajo de la diapositiva y comentarios a su derecha:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Advertencia" color="warning" %}}
Para la conversión de diapositiva a imagen, no pase [BottomFull](https://reference.aspose.com/slides/es/php-java/aspose.slides/notespositions/) al método [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/es/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Las notas pueden contener más texto del que el tamaño fijo de la imagen puede albergar. Use [BottomTruncated](https://reference.aspose.com/slides/es/php-java/aspose.slides/notespositions/) en su lugar.
{{% /alert %}}

## **Convertir diapositivas a imágenes usando opciones TIFF**

La clase [TiffOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/tiffoptions/) le permite controlar el tamaño, la resolución y otras propiedades de la imagen TIFF renderizada.

El siguiente ejemplo renderiza la primera diapositiva como una imagen TIFF de 2160 × 2880 a 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Advertencia" color="warning" %}}
El soporte de TIFF no está garantizado en versiones de Java anteriores a JDK 9.
{{% /alert %}}

## **Convertir todas las diapositivas a imágenes**

Itere a través de la colección de diapositivas para convertir toda la presentación en una serie de imágenes. Las diapositivas ocultas se incluyen a menos que las omita explícitamente.

El siguiente ejemplo renderiza cada diapositiva como una imagen JPEG con factores de escala horizontal y vertical de 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Crear salida Enhanced Metafile**

Enhanced Metafile (EMF) es útil cuando los gráficos vectoriales deben intercambiarse con Microsoft Office u otras aplicaciones de Windows que admiten metafiles de Windows. A diferencia de una imagen basada en píxeles, un EMF puede conservar las operaciones de dibujo vectorial que se escalan sin la misma pérdida de nitidez. Sin embargo, EMF es principalmente un formato de compatibilidad para aplicaciones con soporte de metafiles de Windows, no un formato de intercambio universal. Además, el contenido complejo de la diapositiva, como imágenes de mapa de bits y algunos efectos, puede almacenarse como elementos rasterizados dentro del contenedor de metafile vectorial.

### **Exportar una diapositiva a EMF**

El método [Slide::writeAsEmf](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#writeAsEmf) escribe una diapositiva en un flujo de destino en formato EMF. El siguiente ejemplo carga una presentación, selecciona la primera diapositiva y la escribe en un flujo de archivo EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

El llamador posee el flujo pasado a [Slide::writeAsEmf](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#writeAsEmf) y es responsable de cerrarlo, como se muestra arriba.

### **Convertir una imagen SVG a EMF y añadirla a una presentación**

Utilice [SvgImage::writeAsEmf](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/#writeAsEmf) para convertir contenido SVG a EMF. Los bytes resultantes pueden añadirse a la presentación mediante [ImageCollection::addImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagecollection/#addImage) y colocarse en una diapositiva con [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/#addPictureFrame).

El siguiente ejemplo crea un [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/) a partir de marcado SVG, lo convierte en un EMF en memoria, inserta el metafile en la primera diapositiva y guarda la presentación:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/#writeAsEmf) no toma la propiedad del flujo de destino. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) almacena todos los datos generados en memoria, por lo que no es necesario restablecer la posición antes de llamar a `toByteArray`. El array de bytes devuelto sigue siendo válido después de cerrar el flujo.

La generación de EMF está disponible en los sistemas operativos soportados por la configuración seleccionada de Aspose.Slides para PHP a través de Java y JDK, pero el renderizado puede variar entre plataformas cuando las fuentes o dependencias gráficas no están disponibles. Instale las fuentes usadas por el contenido original o configure sustituciones adecuadas, siga los [requisitos de plataforma](/slides/es/php-java/system-requirements/) para Aspose.Slides para PHP a través de Java y valide el resultado en la aplicación que consumirá el EMF. Las aplicaciones en Linux y macOS a menudo tienen un soporte limitado o inconsistente para mostrar y editar metafiles de Windows.

## **Renderizado de Emoji a Color**

{{% alert title="Nota" color="info" %}}
Para renderizar correctamente los emojis a color al convertir diapositivas de una presentación a imágenes, las fuentes emoji usadas en la presentación deben estar instaladas y disponibles en el sistema que realiza la conversión. Por ejemplo, si la presentación usa **Segoe UI Emoji** y esa fuente falta, los emojis pueden aparecer en monocromo en las imágenes resultantes.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite el renderizado de diapositivas con animaciones?**

No. El método [Slide::getImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getImage) renderiza una imagen estática de la diapositiva y no exporta animaciones.

**¿Se pueden exportar como imágenes las diapositivas ocultas?**

Sí. Las diapositivas ocultas pueden renderizarse como diapositivas normales. Inclúyalas en el bucle de procesamiento, como se muestra en el ejemplo anterior.

**¿Se conservan las sombras y otros efectos en las imágenes de diapositivas?**

Sí. Aspose.Slides renderiza sombras, transparencia y otros efectos gráficos compatibles en las imágenes de las diapositivas.