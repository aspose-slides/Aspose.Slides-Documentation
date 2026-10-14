---
title: Convertir diapositivas de PowerPoint a PNG en Android
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint a imágenes PNG de alta calidad rápidamente con Aspose.Slides para Android mediante Java, garantizando resultados precisos y automatizados."
---
## **Descripción general**

Este artículo explica cómo convertir diapositivas de presentación a imágenes PNG utilizando Aspose.Slides para Android a través de Java. Puedes cargar presentaciones en formatos como PPT, PPTX y ODP, renderizar cada diapositiva y guardarla como una imagen PNG independiente.

Los ejemplos a continuación demuestran la renderización con la escala predeterminada, aumentar la escala, especificar las dimensiones de salida en píxeles y elegir un estilo de renderizado de degradado.

## **Convertir PowerPoint a PNG**

Carga una presentación con la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y accede a sus diapositivas mediante la colección [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--). El ejemplo renderiza cada diapositiva con [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) sin parámetros para crear una miniatura. Luego llama a [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) con [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) para guardar cada diapositiva renderizada como una imagen PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
La sobrecarga sin parámetros de [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) renderiza a una escala de 0.2. Por ejemplo, una diapositiva de 720 × 540 puntos produce una miniatura de 144 × 108 píxeles. Para controlar las dimensiones de salida, utiliza las sobrecargas con factores de escala o un tamaño de imagen explícito que se muestra a continuación.
{{% /alert %}}

## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Pasa factores de escala horizontal y vertical a [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) para controlar las dimensiones renderizadas. En este ejemplo, ambos factores son 2, por lo que una diapositiva de 720 × 540 puntos produce una imagen de 1440 × 1080 píxeles. Los factores de escala iguales conservan la proporción de la diapositiva. Cada imagen se guarda en formato PNG con [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint a PNG con tamaño personalizado**

Para especificar las dimensiones de salida en píxeles, pasa un tamaño a [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) en lugar de factores de escala. Este ejemplo renderiza cada diapositiva a 960 × 720 píxeles y guarda el resultado con [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Elige dimensiones que coincidan con la proporción de la diapositiva para evitar estirar la imagen.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Elegir un estilo de renderizado de degradado**

Supongamos que una diapositiva contiene rellenos con degradado, pero las transiciones en el PNG exportado aparecen más claras o de otro modo diferentes de lo que ves en PowerPoint. Puedes usar el método [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) heredado por [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) para elegir cómo se renderizan los degradados.

Descarga [gradient-styles.pptx](gradient-styles.pptx) y colócalo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene dos degradados lineales: cian a naranja en la parte superior y azul a amarillo en la parte inferior. Cada degradado tiene dos puntos de parada, al 0 % y al 100 %.

El siguiente ejemplo carga esta presentación y renderiza la misma primera diapositiva en ambos modos con [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Las imágenes a continuación muestran la salida de la misma diapositiva, con ambos degradados en cada imagen:

| Default | PowerPointUI |
| --- | --- |
| ![Degradados de cian a naranja y azul a amarillo renderizados con Default](gradient-Default.png) | ![Los mismos degradados renderizados con PowerPointUI](gradient-PowerPointUI.png) |

En este ejemplo, `Default` produce colores intermedios más claros, mientras que `PowerPointUI` produce colores intermedios más oscuros. La diferencia depende de los colores y de los puntos de parada del degradado.

Elige `Default` cuando la salida estándar de Aspose.Slides se ajuste a tus necesidades. Prueba `PowerPointUI` cuando tu prioridad sea igualar la apariencia en PowerPoint. Compara ambas salidas con el resultado que deseas; ninguno de los modos es universalmente preferible.

## **Preguntas frecuentes**

**¿Cómo puedo exportar una forma específica, como un gráfico o una imagen, en lugar de toda la diapositiva?**

Aspose.Slides admite [generar miniaturas para formas individuales](/slides/es/androidjava/create-shape-thumbnails/), lo que te permite renderizar una forma como una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí. Utiliza una instancia de presentación separada para cada hilo o proceso; [no compartas una única instancia entre hilos](/slides/es/androidjava/multithreading/).

**¿Cuáles son las limitaciones de evaluación al exportar a PNG?**

El modo de evaluación añade una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/androidjava/licensing/) hasta que se aplique una licencia.