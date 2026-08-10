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

SVG es un formato de imagen XML escalable que funciona bien para la publicación web, visualizadores de diapositivas, flujos de trabajo de accesibilidad y posprocesado automatizado. Aspose.Slides exporta cada diapositiva a un archivo SVG separado y le permite controlar cómo se escriben el texto, las fuentes, las imágenes y los elementos SVG.

Utilice [SVGOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/) cuando el SVG exportado deba ser compacto, predecible en todos los navegadores o listo para uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/), seleccione una diapositiva y escríbala a un flujo con [Slide.writeAsSvg](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#writeAsSvg). El siguiente ejemplo exporta cada diapositiva de una presentación como un archivo SVG separado.

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

El nombre de archivo utiliza [Slide.getSlideNumber](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getSlideNumber) en lugar del índice del bucle. También puede exportar una forma individual con [Shape.writeAsSvg](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#writeAsSvg) cuando un visor de diapositivas o una página web necesita solo esa forma.

## **Configurar la salida SVG**

[SVGOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/) controla el renderizado SVG. Para los marcos de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setUseFrameSize) incluye el marco de texto en el área de renderizado, y [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setUseFrameRotation) determina si se aplica la rotación del marco. Establezca [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) a `true` cuando el texto deba renderizarse sin ligaduras.

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

## **Controlar texto y fuentes**

### **Vectorizar todo el texto**

Establezca [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setVectorizeText) a `true` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina las dependencias de fuentes y hace que el resultado visual sea más coherente entre navegadores, pero el texto ya no será seleccionable ni buscable como texto SVG.

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

### **Elegir cómo se gestionan las fuentes externas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) utiliza un valor de [SvgExternalFontsHandling](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgexternalfontshandling/) para las fuentes que se cargan externamente. Elija `AddLinksToFontFiles` para referenciar archivos de fuentes separados, `Embed` para incluir los datos de la fuente en el SVG, o `Vectorize` para renderizar solo el texto que usa fuentes externas como gráficos. Verifique la licencia de la fuente antes de incrustar fuentes.

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

Utilice [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setPicturesCompression) para reducir la resolución de las imágenes incrustadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) para omitir las áreas recortadas de la fuente y [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setJpegQuality) para controlar la calidad de codificación JPEG. Estas configuraciones reducen el tamaño del archivo a costa de la fidelidad de la imagen o de los datos de imagen retenidos.

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

## **Asignar IDs estables a formas y texto**

Proporcione una devolución de llamada de formato a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setShapeFormattingController) para establecer [SvgShape.setId](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgshape/#setId) en cada forma SVG. La devolución de llamada también puede establecer valores [SvgTSpan.setId](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgtspan/#setId) en los elementos `tspan` de texto.

PhpJavaBridge no puede invocar una devolución de llamada PHP desde `writeAsSvg` cuando se ejecuta en modo de flujo. Coloque la lógica de formato en una pequeña clase auxiliar Java, complíquela y añada el archivo JAR resultante al classpath del puente. El auxiliar puede usar [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getOfficeInteropShapeId), que es estable durante la vida útil de la forma, y un contador repetible para sus `tspan` de texto. Consulte la [implementación Java de `StableSvgIdController`](/slides/es/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) para el código auxiliar.

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

## **Añadir controladores de eventos SVG**

En una devolución de llamada de formato, llame a [SvgShape.setEventHandler](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgshape/#setEventHandler) con un valor de [SvgEvent](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgevent/) para añadir un controlador de eventos JavaScript a una forma exportada. Asigne la devolución de llamada con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setShapeFormattingController) y defina la función JavaScript en la página o documento SVG que aloje el resultado.

Al igual que con los IDs estables, implemente la devolución de llamada en un auxiliar Java cuando PhpJavaBridge use el modo de flujo. La [implementación Java de `SvgEventController`](/slides/es/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) asigna un ID y un controlador `OnClick` a una forma llamada `ActionButton`. Compile ese auxiliar, añádalo al classpath del puente como `com.example.slides.SvgEventController` y utilícelo desde PHP de la siguiente manera:

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

La página anfitriona puede definir la función JavaScript referenciada por el controlador. Asignar IDs y controladores de eventos permite visualizadores de diapositivas, mejoras de accesibilidad y otros flujos de trabajo SVG interactivos.

## **Preguntas frecuentes**

**¿Cuándo debería usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setVectorizeText) en lugar de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgexternalfontshandling/)?**

Utilice [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgoptions/#setVectorizeText) cuando todo el texto deba ser independiente de las fuentes. Utilice [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgexternalfontshandling/) cuando solo el texto que usa fuentes externas deba convertirse en gráficos.

**¿Cuál es la mejor forma de reducir el tamaño de un SVG?**

Comience comprimiendo las imágenes incrustadas, eliminando las áreas recortadas de la imagen y eligiendo archivos de fuentes enlazados cuando el entorno de destino pueda servirlos. Pruebe el resultado porque la reducción de la resolución de la imagen, la menor calidad JPEG y el texto vectorizado tienen diferentes compromisos entre calidad y tamaño.

**¿Puedo modificar los elementos SVG exportados después de la exportación?**

Sí. Asigne IDs mediante una devolución de llamada de formato y luego seleccione los elementos SVG correspondientes en su herramienta de posprocesado o script de navegador.