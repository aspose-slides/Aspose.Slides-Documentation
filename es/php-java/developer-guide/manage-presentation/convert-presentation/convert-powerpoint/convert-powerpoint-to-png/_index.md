---
title: Convertir diapositivas de PowerPoint a PNG en PHP
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/php-java/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a PNG
- presentación a PNG
- diapositiva a PNG
- PPT a PNG
- PPTX a PNG
- guardar PPT como PNG
- guardar PPTX como PNG
- exportar PPT a PNG
- exportar PPTX a PNG
- PHP
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint a imágenes PNG de alta calidad rápidamente con Aspose.Slides para PHP a través de Java, garantizando resultados precisos y automatizados."
---
## **Visión general**

Este artículo explica cómo convertir diapositivas de presentación a imágenes PNG usando Aspose.Slides para PHP a través de Java. Puede cargar presentaciones en formatos como PPT, PPTX y ODP, renderizar cada diapositiva y guardarla como una imagen PNG independiente.

Los ejemplos a continuación demuestran la renderización con la escala predeterminada, el aumento de la escala, la especificación de las dimensiones de salida en píxeles y la elección de un estilo de renderizado de degradado.

## **Convertir PowerPoint a PNG**

Cargue una presentación con la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y acceda a sus diapositivas a través de la colección [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). El ejemplo renderiza cada diapositiva con [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) sin parámetros para crear una miniatura. A continuación llama a [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) con [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) para guardar cada diapositiva renderizada como una imagen PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
La sobrecarga sin parámetros de [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) renderiza con una escala de 0,2. Por ejemplo, una diapositiva de 720 × 540 puntos produce una miniatura de 144 × 108 píxeles. Para controlar las dimensiones de salida, utilice las sobrecargas con factores de escala o un tamaño de imagen explícito que se muestra a continuación.
{{% /alert %}}

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Passe factores de escala horizontal y vertical a [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) para controlar las dimensiones renderizadas. En este ejemplo, ambos factores son 2, de modo que una diapositiva de 720 — 540 puntos produce una imagen de 1440 — 1080 píxeles. Los factores de escala iguales conservan la relación de aspecto de la diapositiva. Cada imagen se guarda en formato PNG con [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Para especificar las dimensiones de salida en píxeles, pase un tamaño a [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) en lugar de factores de escala. Este ejemplo renderiza cada diapositiva a 960 — 720 píxeles y guarda el resultado con [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Elija dimensiones que coincidan con la relación de aspecto de la diapositiva para evitar deformar la imagen.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Elegir un estilo de renderizado de degradado**

Suponga que una diapositiva contiene rellenos degradados, pero las transiciones en el PNG exportado aparecen más claras o diferentes de lo que se ve en PowerPoint. Puede usar el método [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) heredado por [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) para elegir cómo se renderizan los degradados.

Descargue [gradient-styles.pptx](gradient-styles.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene dos degradados lineales: cian a naranja en la parte superior y azul a amarillo en la parte inferior. Cada degradado tiene dos paradas, en el 0 % y el 100 %.

El siguiente ejemplo carga esta presentación y renderiza la misma primera diapositiva en ambos modos con [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Las imágenes a continuación muestran la salida de la misma diapositiva, con ambos degradados en cada imagen:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

En este ejemplo, `Default` produce colores intermedios más claros, mientras que `PowerPointUI` produce colores intermedios más oscuros. La diferencia depende de los colores y las paradas del degradado.

Elija `Default` cuando la salida estándar de Aspose.Slides se ajuste a sus necesidades. Pruebe `PowerPointUI` cuando su prioridad sea coincidir con la apariencia en PowerPoint. Compare ambas salidas con el resultado deseado; ninguno de los modos es universalmente preferible.

## **FAQ**

**¿Cómo puedo exportar una forma concreta, como un gráfico o una imagen, en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/php-java/create-shape-thumbnails/), lo que le permite renderizar una forma como una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí. Utilice una instancia de presentación distinta para cada hilo o proceso; [no comparta una única instancia entre hilos](/slides/es/php-java/multithreading/).

**¿Cuáles son las limitaciones de la versión de evaluación al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes resultantes y aplica [otras restricciones](/slides/es/php-java/licensing/) hasta que se aplique una licencia.