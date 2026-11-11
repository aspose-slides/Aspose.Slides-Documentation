---
title: Renderizar diapositivas de presentación como imágenes SVG en PHP
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /es/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentación a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- opciones de exportación SVG
- SVG interactivo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Exporta diapositivas de PowerPoint como imágenes SVG en PHP y controla fuentes, texto, imágenes, IDs y eventos con Aspose.Slides."
---
## **Visión general**

SVG es un formato de imagen basado en XML escalable que funciona bien para la publicación web, visores de diapositivas, flujos de trabajo de accesibilidad y post‑procesado automatizado. Aspose.Slides exporta cada diapositiva a un archivo SVG independiente y permite controlar cómo se escriben el texto, las fuentes, las imágenes y los elementos SVG.

Utilice [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) cuando el SVG exportado deba ser compacto, predecible entre navegadores o estar listo para su uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), seleccione una diapositiva y escríbala a un flujo con [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). El siguiente ejemplo exporta cada diapositiva de una presentación a un archivo SVG independiente.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

El nombre de archivo utiliza [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) en lugar del índice del bucle. También puede exportar una forma individual con [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) cuando un visor de diapositivas o una página web necesita solo esa forma.

## **Configurar la salida SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) controla el renderizado SVG. Para marcos de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) incluye el marco de texto en el área de renderizado, y [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) determina si se aplica la rotación del marco. Establezca [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) a `true` cuando el texto deba renderizarse sin ligaduras.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Controlar el recorte de extremos de línea en puntas de flecha**

SVG 1.1 no dispone de una configuración de inserción de marcador para especificar dónde debe detenerse una línea bajo una punta de flecha. Por defecto, Aspose.Slides acorta la línea exportada para que su trazo no sobresalga del marcador. Llame a [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) con `true` para dibujar el trazo hasta el punto final original de la línea. Esta configuración afecta solo a la salida SVG. La línea mantiene su posición y longitud en la diapositiva.

El ejemplo dibuja puntas de flecha de triángulo y diamante en líneas de 2 y 10 puntos de ancho. Exporta la misma diapositiva dos veces, modificando solo la opción de recorte.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

La comparación muestra la punta triangular en la línea de 10 puntos. Con el recorte activado, la punta es aguda. Con el recorte desactivado, el trazo sobresale por los lados inclinados del marcador y deja un extremo plano.

![Triángulo de 10 puntos ampliado con punta aguda cuando el recorte está activado y extremo plano cuando está desactivado](line-end-cropping.png)

En las demás líneas del ejemplo, el trazo sobresaliente es menos visible en el triángulo de 2 puntos. El diamante relleno cubre el extremo del trazo en ambos anchos.

## **Controlar texto y fuentes**

Al exportar diapositivas a SVG, puede controlar si el texto se conserva como texto o se convierte en gráficos vectoriales, y cómo se incluyen o referencian las fuentes externas. Las opciones siguientes le ayudan a equilibrar la coherencia visual, la selección de texto y las dependencias de fuentes en el SVG exportado.

### **Vectorizar todo el texto**

Establezca [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) a `true` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina las dependencias de fuentes y hace que el resultado visual sea más consistente entre navegadores, pero el texto ya no es seleccionable ni buscable como texto SVG.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Elegir cómo manejar las fuentes externas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) utiliza un valor de [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) para las fuentes que se cargan externamente. Elija `AddLinksToFontFiles` para referenciar archivos de fuentes separados, `Embed` para incluir los datos de la fuente en el SVG, o `Vectorize` para renderizar solo el texto que usa fuentes externas como gráficos. Verifique la licencia de las fuentes antes de incrustarlas.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Reducir el tamaño de imágenes incrustadas**

Utilice [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) para reducir la resolución de las imágenes incrustadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) para omitir áreas recortadas de la fuente y [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) para controlar la calidad de codificación JPEG. Estas configuraciones reducen el tamaño del archivo a costa de la fidelidad de la imagen o de los datos de imagen retenidos.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Controlar la resolución de rasterización de Metafiles**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) establece el límite inferior de resolución para rasterizar metafiles durante la exportación SVG. Úselo para equilibrar detalle y tamaño de archivo cuando se rasteriza una imagen EMF o WMF. No define un DPI global para el SVG ni obliga a que cada objeto de la diapositiva se convierta en una imagen raster.

Descargue [metafile-rasterization.pptx](metafile-rasterization.pptx), que contiene una imagen EMF con líneas diagonales muy próximas. El siguiente ejemplo exporta su primera diapositiva a tres resoluciones de rasterización mediante [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Todas las demás configuraciones de exportación permanecen idénticas para que los resultados puedan compararse.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

En la salida, el EMF se convirtió en un PNG incrustado en cada SVG. Las siguientes medidas corresponden a la presentación suministrada; no son una fórmula general para convertir DPI a dimensiones de píxeles.

| DPI de rasterización de Metafile | Dimensiones PNG incrustado | Tamaño del archivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparación a continuación muestra la misma zona del raster incrustado con el mismo tamaño de visualización ampliado. Las líneas diagonales presentan pixelado visible a 72 DPI y bordes más suaves a resoluciones superiores, mientras que el archivo SVG aumenta. Incrementar el valor no mejora necesariamente cada detalle ni cambia cada imagen exportada.

![Detalle ampliado de líneas diagonales a 72, 150 y 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) controla la reducción de la resolución de la imagen y puede ocultar el efecto de cambiar la resolución de rasterización del metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) controla la calidad de codificación JPEG, no la resolución de rasterización del metafile.

## **Asignar IDs estables a formas y texto**

Proporcione una devolución de llamada de formato a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) para establecer [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) en cada forma SVG. La devolución de llamada también puede establecer valores [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) en los elementos `tspan` de texto.

PhpJavaBridge no puede invocar una devolución de llamada PHP desde `writeAsSvg` cuando se ejecuta en modo de flujo. Coloque la lógica de formato en una pequeña clase auxiliar Java, compílela y añada el archivo JAR resultante al classpath del puente. El auxiliar puede usar [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), que es estable durante la vida útil de la forma, y un contador repetible para sus fragmentos de texto. Consulte la [implementación Java de `StableSvgIdController`](/slides/es/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) para el código del auxiliar.

Después de añadir la clase compilada `com.example.slides.StableSvgIdController` al classpath del puente, instánciela desde PHP y asígnela a `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Añadir manejadores de eventos SVG**

En una devolución de llamada de formato, llame a [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) con un valor [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) para añadir un manejador de eventos JavaScript a una forma exportada. Asigne la devolución de llamada con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) y defina la función JavaScript en la página o documento SVG que aloje el resultado.

Al igual que con los IDs estables, implemente la devolución de llamada en un auxiliar Java cuando PhpJavaBridge utiliza el modo de flujo. La [implementación Java de `SvgEventController`](/slides/es/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) asigna un ID y un manejador `OnClick` a una forma llamada `ActionButton`. Compile ese auxiliar, añádalo al classpath del puente como `com.example.slides.SvgEventController`, y úselo desde PHP de la siguiente manera:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

La página anfitriona puede definir la función JavaScript referenciada por el manejador. Asignar IDs y manejadores de eventos permite visores de diapositivas, mejoras de accesibilidad y otros flujos de trabajo SVG interactivos.

## **Preguntas frecuentes**

**¿Cuándo debería usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) en lugar de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Utilice [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) cuando todo el texto deba ser independiente de las fuentes. Utilice [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) cuando solo el texto que usa fuentes externas deba convertirse en gráficos.

**¿Cuál es la mejor manera de reducir el tamaño de un SVG?**

Comience comprimiendo las imágenes incrustadas, eliminando las áreas recortadas y eligiendo archivos de fuentes enlazados cuando el entorno de destino pueda servirlos. Pruebe el resultado porque la menor resolución de imagen, la menor calidad JPEG y el texto vectorizado presentan diferentes compromisos entre calidad y tamaño.

**¿Puedo modificar los elementos SVG exportados después de la exportación?**

Sí. Asigne IDs mediante una devolución de llamada de formato, y luego seleccione los elementos SVG correspondientes en su herramienta de post‑procesado o script del navegador.