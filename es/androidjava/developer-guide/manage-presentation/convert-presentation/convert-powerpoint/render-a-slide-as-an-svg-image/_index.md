---
title: Renderizar diapositivas de presentación como imágenes SVG en Android
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /es/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentación a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- guardar PPT como SVG
- guardar PPTX como SVG
- exportar PPT a SVG
- exportar PPTX a SVG
- renderizar diapositiva
- convertir diapositiva
- exportar diapositiva
- imagen vectorial
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprende cómo renderizar diapositivas de PowerPoint como imágenes SVG utilizando Aspose.Slides para Android. Visuales de alta calidad con ejemplos de código Java simples."
---

## **Formato SVG**

SVG—un acrónimo de Scalable Vector Graphics—es un tipo o formato gráfico estándar utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia. 

SVG es uno de los pocos formatos de imágenes que cumple con estándares muy altos en estos aspectos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por esas razones, se usa comúnmente en el desarrollo web. 

Es posible que desees usar archivos SVG cuando necesites

- **imprime tu presentación en un *formato muy grande*.** Las imágenes SVG pueden escalar a cualquier resolución o nivel. Puedes redimensionar las imágenes SVG tantas veces como sea necesario sin sacrificar calidad.
- **utiliza gráficos y diagramas de tus diapositivas en *diferentes medios o plataformas**.* La mayoría de los lectores pueden interpretar archivos SVG. 
- **utiliza los *tamaños más pequeños posibles de imágenes***. Los archivos SVG son generalmente más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos basados en mapa de bits (JPEG o PNG).

## **Renderizar una diapositiva como imagen SVG**

Aspose.Slides for Android via Java permite exportar diapositivas de tus presentaciones como imágenes SVG. Sigue estos pasos para generar imágenes SVG:

1. Crea una instancia de la clase Presentation.
2. Recorre todas las diapositivas de la presentación.
3. Escribe cada diapositiva en su propio archivo SVG mediante FileOutputStream.

{{% alert color="primary" %}} 
Es posible que quieras probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides for Android via Java.
{{% /alert %}} 

Este código de muestra en Java te muestra cómo convertir PPT a SVG usando Aspose.Slides:
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Por qué el SVG resultante puede verse diferente en distintos navegadores?**

El soporte de características específicas de SVG se implementa de manera diferente en los motores de los navegadores. Los parámetros de [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) ayudan a suavizar las incompatibilidades.

**¿Es posible exportar no solo diapositivas sino también formas individuales a SVG?**

Sí. Cualquier [forma puede guardarse como un SVG separado](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) es conveniente para iconos, pictogramas y reutilizar gráficos.

**¿Se pueden combinar varias diapositivas en un solo SVG (tira/documento)?**

El escenario estándar es una diapositiva → un SVG. Combinar varias diapositivas en un solo lienzo SVG es un paso de postprocesamiento realizado a nivel de aplicación.