---
title: "Renderizar diapositivas de presentación como imágenes SVG en Android"
linktitle: "Diapositiva a SVG"
type: docs
weight: 50
url: /es/androidjava/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint a SVG"
- "presentación a SVG"
- "diapositiva a SVG"
- "PPT a SVG"
- "PPTX a SVG"
- "guardar PPT como SVG"
- "guardar PPTX como SVG"
- "exportar PPT a SVG"
- "exportar PPTX a SVG"
- "renderizar diapositiva"
- "convertir diapositiva"
- "exportar diapositiva"
- "imagen vectorial"
- "PowerPoint"
- "presentación"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aprenda cómo renderizar diapositivas de PowerPoint como imágenes SVG usando Aspose.Slides para Android. Visuales de alta calidad con ejemplos de código Java simples."
---

## **Formato SVG**

SVG—acrónimo de Scalable Vector Graphics—es un tipo o formato gráfico estándar utilizado para representar imágenes bidimensionales. SVG almacena las imágenes como vectores en XML con detalles que definen su comportamiento o apariencia. 

SVG es uno de los pocos formatos de imagen que cumple con estándares muy altos en estos aspectos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por estas razones, se utiliza comúnmente en el desarrollo web. 

Puede que desees usar archivos SVG cuando necesites

- **imprime tu presentación en un *formato muy grande*.** Las imágenes SVG pueden escalarse a cualquier resolución o nivel. Puedes redimensionar las imágenes SVG tantas veces como sea necesario sin sacrificar calidad.
- **utiliza los gráficos y tablas de tus diapositivas en *diferentes medios o plataformas*.** La mayoría de los lectores pueden interpretar archivos SVG. 
- **utiliza los *tamaños más pequeños posibles* de imágenes**. Los archivos SVG suelen ser más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos basados en mapa de bits (JPEG o PNG).

## **Renderizar una diapositiva como una imagen SVG**

Aspose.Slides for Android vía Java permite exportar las diapositivas de tus presentaciones como imágenes SVG. Sigue estos pasos para generar imágenes SVG:

1. Crea una instancia de la clase Presentation.  
2. Recorre todas las diapositivas de la presentación.  
3. escribe cada diapositiva en su propio archivo SVG mediante FileOutputStream.  

{{% alert color="primary" %}} 

Puede que desees probar nuestra aplicación web gratuita[free web application](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides for Android vía Java.

{{% /alert %}} 

Este código de ejemplo en Java muestra cómo convertir PPT a SVG usando Aspose.Slides:
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

El soporte de características específicas de SVG se implementa de manera distinta en los motores de los navegadores. Los parámetros de [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) ayudan a suavizar las incompatibilidades.

**¿Es posible exportar no solo diapositivas sino también formas individuales a SVG?**

Sí. Cualquier [shape can be saved as a separate SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), lo que resulta práctico para iconos, pictogramas y reutilización de gráficos.

**¿Se pueden combinar varias diapositivas en un solo SVG (strip/document)?**

El escenario estándar es una diapositiva → un SVG. Combinar varias diapositivas en un único lienzo SVG es un paso de post‑procesamiento que se realiza a nivel de la aplicación.