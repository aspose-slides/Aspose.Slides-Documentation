---
title: Convertir diapositivas de PowerPoint a PNG en JavaScript
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/nodejs-java/convert-powerpoint-to-png/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint a imágenes PNG de alta calidad en JavaScript rápidamente con Aspose.Slides para Node.js, garantizando resultados precisos y automatizados."
---
## **Visión general**

Este artículo explica cómo convertir diapositivas de presentación a imágenes PNG usando Aspose.Slides para Node.js a través de Java. Puede cargar presentaciones en formatos como PPT, PPTX y ODP, renderizar cada diapositiva y guardarla como una imagen PNG separada.

Los ejemplos a continuación demuestran la renderización con la escala predeterminada, el aumento de la escala, la especificación de las dimensiones de salida en píxeles y la elección de un estilo de renderizado de degradado.

## **Convertir PowerPoint a PNG**

Cargue una presentación con la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y acceda a sus diapositivas a través de la colección [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). El ejemplo renderiza cada diapositiva con [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) sin parámetros para crear una miniatura. Luego llama a [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) con [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) para guardar cada diapositiva renderizada como una imagen PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
La sobrecarga sin parámetros de [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) renderiza con una escala de 0.2. Por ejemplo, una diapositiva que mide 720 × 540 puntos produce una miniatura de 144 × 108 píxeles. Para controlar las dimensiones de salida, utilice las sobrecargas con factores de escala o un tamaño de imagen explícito que se muestra a continuación.
{{% /alert %}}

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Pase factores de escala horizontal y vertical a [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) para controlar las dimensiones renderizadas. En este ejemplo, ambos factores son 2, por lo que una diapositiva que mide 720 × 540 puntos produce una imagen de 1440 × 1080 píxeles. Los factores de escala iguales conservan la proporción de la diapositiva. Cada imagen se guarda en formato PNG con [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Para especificar las dimensiones de salida en píxeles, pase un tamaño a [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) en lugar de factores de escala. Este ejemplo renderiza cada diapositiva a 960 × 720 píxeles y guarda el resultado con [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Elija dimensiones que coincidan con la proporción de la diapositiva para evitar estirar la imagen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Elija un estilo de renderizado de degradado**

Suponga que una diapositiva contiene rellenos degradados, pero las transiciones en el PNG exportado aparecen más claras o diferentes de lo que ve en PowerPoint. Puede usar el método [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) heredado por [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) para elegir cómo se renderizan los degradados.

Descargue [gradient-styles.pptx](gradient-styles.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene dos degradados lineales: cian a naranja en la parte superior y azul a amarillo en la parte inferior. Cada degradado tiene dos paradas, al 0 % y al 100 %.

El siguiente ejemplo carga esta presentación y renderiza la misma primera diapositiva en ambos modos con [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Los degradados de cian a naranja y de azul a amarillo renderizados con Default](gradient-Default.png) | ![Los mismos degradados renderizados con PowerPointUI](gradient-PowerPointUI.png) |

En este ejemplo, `Default` produce colores intermedios más claros, mientras que `PowerPointUI` produce colores intermedios más oscuros. La diferencia depende de los colores y las paradas del degradado.

Elija `Default` cuando la salida estándar de Aspose.Slides se ajuste a sus necesidades. Pruebe `PowerPointUI` cuando su prioridad sea que la apariencia coincida con la de PowerPoint. Compare ambos resultados con el que desea; ninguno de los modos es universalmente preferible.

## **Preguntas frecuentes**

**¿Cómo puedo exportar una forma específica, como un gráfico o una imagen, en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/nodejs-java/create-shape-thumbnails/), lo que le permite renderizar una forma como una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí. Utilice una instancia de presentación separada para cada hilo o proceso; [no comparta una única instancia entre hilos](/slides/es/nodejs-java/multithreading/).

**¿Cuáles son las limitaciones de la evaluación al exportar a PNG?**

El modo de evaluación agrega una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/nodejs-java/licensing/) hasta que se aplique una licencia.