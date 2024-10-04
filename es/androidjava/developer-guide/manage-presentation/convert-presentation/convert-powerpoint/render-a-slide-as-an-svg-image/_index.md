---
title: Renderizar una Diapositiva como una Imagen SVG
type: docs
weight: 50
url: /androidjava/render-a-slide-as-an-svg-image/
---

SVG—un acrónimo de Gráficos Vectoriales Escalables—es un tipo de gráfico estándar o formato utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia.

SVG es uno de los pocos formatos para imágenes que cumple con estándares muy altos en estos términos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad, entre otros. Por estas razones, se utiliza comúnmente en el desarrollo web.

Puede que desee utilizar archivos SVG cuando necesite

- **imprimir su presentación en un *formato muy grande*.** Las imágenes SVG pueden escalarse a cualquier resolución o nivel. Puede redimensionar las imágenes SVG tantas veces como sea necesario sin sacrificar calidad.
- **utilizar gráficos y tablas de sus diapositivas en *diferentes medios o plataformas**.* La mayoría de los lectores pueden interpretar archivos SVG.
- **usar el *tamaño más pequeño posible de las imágenes***. Los archivos SVG son generalmente más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos formatos basados en mapa de bits (JPEG o PNG).

Aspose.Slides para Android a través de Java le permite exportar diapositivas de sus presentaciones como imágenes SVG. Siga estos pasos para generar imágenes SVG:

1. Cree una instancia de la clase Presentation.
2. Itérese a través de todas las diapositivas en la presentación.
3. Escriba cada diapositiva en su propio archivo SVG a través de FileOutputStream.

{{% alert color="primary" %}} 

Puede que desee probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la cual implementamos la función de conversión de PPT a SVG de Aspose.Slides para Android a través de Java.

{{% /alert %}} 

Este código de ejemplo en Java le muestra cómo convertir PPT a SVG usando Aspose.Slides:

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