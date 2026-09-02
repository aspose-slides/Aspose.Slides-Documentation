---
title: Gestionar marcos de imagen en presentaciones usando PHP
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/php-java/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- imagen incrustada
- imagen vinculada
- extraer imagen
- imagen raster
- imagen SVG
- recortar imagen
- eliminar áreas recortadas
- comprimir imagen
- StretchOffset
- formato de marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Crear, dar formato, vincular, recortar, extraer y comprimir marcos de imagen en presentaciones con Aspose.Slides para PHP vía Java."
---
## **Visión general**

Un marco de imagen es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) posee recursos de imagen incrustados a través de su [ImageCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagecollection/), mientras que un [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) controla la posición, el tamaño, el formato de línea, la rotación, el recorte, los efectos de imagen y otras configuraciones a nivel de marco.

Esta separación resulta útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) devuelto y utilice ese recurso de imagen al crear marcos de imagen.

Los marcos de imagen pueden contener imágenes raster como PNG o JPEG e imágenes vectoriales SVG. También pueden referirse a imágenes vinculadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo debe almacenarse la imagen antes de aplicar formato u optimización.

## **Agregar y formatear una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un marco de imagen con [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addpictureframe/). La imagen pasa a formar parte del paquete de la presentación, de modo que la presentación permanece autocontenida cuando se traslada a otro equipo.

El siguiente ejemplo añade una imagen JPEG, crea un marco con las dimensiones nativas de la imagen y aplica formato de línea y rotación:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El marco de imagen controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones en píxeles originales almacenadas en el recurso de imagen incrustada. Esta distinción cobra importancia al recortar o comprimir una imagen más adelante.

## **Usar escala relativa**

[PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) expone el escalado relativo de anchura y altura del marco mediante [setRelativeScaleWidth](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/setrelativescalewidth/) y [setRelativeScaleHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita preservar una relación con el tamaño de la imagen origen en lugar de calcular manualmente las dimensiones finales.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La escala relativa cambia la configuración de escala del marco; no vuelve a muestrear ni comprime la imagen incrustada.

## **Imágenes incrustadas y vinculadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por lo tanto, es la opción más segura para la portabilidad y una renderización predecible. Una imagen vinculada almacena una ubicación externa mediante el método [Picture::setLinkPathLong](https://reference.aspose.com/slides/es/php-java/aspose.slides/picture/setlinkpathlong/) en lugar de incrustar los datos de la imagen de la misma forma.

Las imágenes vinculadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo vinculado debe seguir siendo accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen vinculada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Añadir una imagen vinculada**

El siguiente ejemplo crea un marco de imagen y lo apunta a un archivo de imagen local. Solo trata el vínculo de imágenes; el vínculo de vídeo es un flujo de trabajo multimedia separado y, intencionalmente, no se mezcla en este ejemplo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilice vínculos cuando la gestión de archivos externos sea intencional. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imagen rotas suele ser menos útil que una presentación más grande y autocontenida.

## **Extraer imágenes de los marcos de imagen**

Antes de extraer una imagen de una presentación existente, compruebe que una forma sea realmente un [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) y que contenga una imagen incrustada. Los marcos de imagen vinculados pueden no contener bytes de imagen que puedan extraerse de la misma manera.

### **Extraer una imagen raster**

La API moderna de imágenes usa [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) directamente. El siguiente ejemplo encuentra la primera imagen raster incrustada en una diapositiva y la guarda como PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Guardar mediante [IImage::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/#save) convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo raster convertido, use los datos binarios del recurso de imagen.

### **Extraer una imagen SVG**

Para una imagen SVG, el [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) expone un objeto [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/). Esto le permite recuperar los datos SVG directamente en lugar de rasterizar primero la imagen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG obligan a renderizar ese contenido vectorial a píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia byte a byte del SVG incrustado original; use los datos de [SvgImage::getSvgData](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/getsvgdata/) cuando se requiera el recurso vectorial original.

## **Recortar una imagen**

El recorte cambia qué parte de una imagen es visible dentro del marco. Los valores de recorte en [PictureFillFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturefillformat/) son porcentajes de las dimensiones de la imagen origen. El recorte no elimina inicialmente los píxeles ocultos de la imagen incrustada; solo modifica la región visible.

El siguiente ejemplo encuentra de forma segura un marco de imagen y aplica valores de recorte:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Como los datos de la imagen oculta siguen presentes, el recorte puede modificarse posteriormente sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la sección siguiente.

## **Eliminar datos de imagen recortados**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: tras guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de desrecorte posterior.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también se usa en otros marcos de imagen, esos marcos siguen necesitando su recurso existente, por lo que eliminar áreas recortadas no reduce necesariamente el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir imágenes raster**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) reduce la resolución de imágenes raster en relación con el tamaño al que se muestra la imagen. También puede eliminar regiones recortadas en la misma operación. El método devuelve `true` cuando la imagen se redimensionó o recortó y `false` cuando no fue necesario ningún cambio.

Utilice un valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturescompression/) cuando una resolución objetivo estándar sea suficiente:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Se puede pasar un valor DPI positivo personalizado en lugar de un valor predefinido cuando se requiere un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y de metarchivo no se reduce con este flujo de compresión raster. Además, recuerde que una resolución menor y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el mayor tamaño al que la imagen será realmente vista o exportada, en lugar de aplicar el DPI más bajo de forma global.

## **Gestionar efectos de transformación de imágenes**

Para un flujo de trabajo completo que cubra brillo, contraste, transformaciones de color, desenfoque, efectos alfa, cadenas ordenadas, inspección, eliminación y verificación de ida y vuelta, consulte [Image Transform Effects](/slides/es/php-java/image-transform-effects/).

## **Bloquear la geometría del marco de imagen**

Los ajustes de [PictureFrameLock](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframelock/) controlan qué operaciones de edición están deshabilitadas para un marco de imagen. Por ejemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) conserva las proporciones de la forma mientras se redimensiona.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El bloqueo se aplica a la forma del marco de imagen. No fuerza a que la imagen origen sea muestreada nuevamente o cambiada permanentemente al mismo ratio de aspecto.

## **Ajustar los valores StretchOffset**

Cuando el modo de relleno de imagen es estirado, los valores stretch‑offset en [PictureFillFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del marco de imagen. Los porcentajes positivos crean una inserción desde un borde, mientras que los porcentajes negativos crean una expansión.

Esto es diferente del recorte. Los valores de recorte seleccionan qué parte de la imagen origen es visible; los stretch‑offset cambian el rectángulo en el que se estira el relleno de imagen visible.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilice stretch‑offset para la colocación del relleno. Use las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen origen.

## **Consideraciones de almacenamiento, tamaño de archivo y exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del marco de imagen se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autocontenida y son las más fiables para compartir y renderizar en servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes vinculadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos permanezcan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que las áreas recortadas se eliminen explícitamente o se eliminen durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster sobredimensionadas, pero sacrifica la resolución original. Debe aplicarse después de conocer el tamaño final en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial es importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial en sí. Las exportaciones raster de diapositivas siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deben reutilizar un recurso [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) existente cuando sea posible en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño de visualización real, elimine los píxeles recortados solo cuando no se requiera edición posterior y evite enlaces externos a menos que la gestión de dependencias forme parte del diseño del despliegue.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un marco de imagen y un recurso de imagen?**

Un [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) representa un recurso de imagen asociado a la presentación. Un [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) es una forma en una diapositiva que muestra una imagen y almacena la geometría y formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo incrustar o vincular las imágenes?**

Incruste imágenes cuando la presentación deba ser portátil, archivada o renderizada sin acceso a recursos externos. Vincule imágenes solo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí mismo. La configuración normal de recorte oculta partes de la imagen origen pero conserva los píxeles subyacentes. Utilice [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) o la compresión de imágenes con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen tras la compresión?**

No. La compresión puede reducir la resolución raster almacenada y la eliminación de regiones recortadas descarta datos de imagen. Mantenga la imagen origen fuera de la presentación si más adelante se requiere edición en alta resolución.

**¿Cómo deben gestionarse las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial importe. El [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de utilizar miembros específicos de marcos de imagen. Una comprobación `java_instanceof` contra [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) evita conversiones no válidas y permite al código manejar diapositivas que no contengan marcos de imagen.