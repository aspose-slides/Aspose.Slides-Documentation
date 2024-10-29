---
title: Renderizar una diapositiva como una imagen SVG
type: docs
weight: 50
url: /es/java/render-a-slide-as-an-svg-image/
---

SVG—un acrónimo de Gráficos Vectoriales Escalables—es un tipo o formato estándar de gráficos utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia.

SVG es uno de los pocos formatos para imágenes que cumple con estándares muy altos en estos términos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por estas razones, es comúnmente utilizado en el desarrollo web.

Es posible que desees utilizar archivos SVG cuando necesites

- **imprimir tu presentación en un *formato muy grande*.** Las imágenes SVG pueden escalarse a cualquier resolución o nivel. Puedes redimensionar imágenes SVG tantas veces como sea necesario sin sacrificar la calidad.
- **usar gráficos y diagramas de tus diapositivas en *diferentes medios o plataformas***. La mayoría de los lectores pueden interpretar archivos SVG.
- **utilizar los *tamaños de imagen más pequeños posibles***. Los archivos SVG son generalmente más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos basados en mapa de bits (JPEG o PNG).

Aspose.Slides para Java te permite exportar diapositivas en tus presentaciones como imágenes SVG. Sigue estos pasos para generar imágenes SVG:

1. Crea una instancia de la clase Presentation.
2. Itera a través de todas las diapositivas en la presentación.
3. Escribe cada diapositiva en su propio archivo SVG a través de FileOutputStream.

{{% alert color="primary" %}} 

Es posible que desees probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides para Java.

{{% /alert %}} 

Este código de muestra en Java te muestra cómo convertir PPT a SVG utilizando Aspose.Slides:

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