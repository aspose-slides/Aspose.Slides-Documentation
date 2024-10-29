---
title: Renderizar Diapositivas Como Imágenes SVG
type: docs
weight: 50
url: /es/net/render-slide-as-svg-image/
---

SVG—un acrónimo para Gráficos Vectoriales Escalables—es un tipo o formato estándar de gráficos utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia. 

SVG es uno de los pocos formatos de imágenes que cumple con estándares muy altos en estos términos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por estas razones, es comúnmente utilizado en el desarrollo web. 

Es posible que desees usar archivos SVG en estos escenarios:

- cuando planeas imprimir tu presentación en un formato muy grande. Las imágenes SVG pueden escalarse a cualquier resolución o nivel. Puedes redimensionar imágenes SVG tantas veces como sea necesario sin sacrificar calidad.
- cuando pretendes usar gráficos y diagramas de tus diapositivas en diferentes medios o plataformas. La mayoría de los lectores pueden interpretar archivos SVG. 
- cuando necesitas utilizar los tamaños de imagen más pequeños posibles. Los archivos SVG son generalmente más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos basados en mapa de bits (JPEG o PNG).

Aspose.Slides para .NET te permite exportar diapositivas en tus presentaciones como **imágenes SVG**. Para generar una imagen SVG de cualquiera, haz lo siguiente:

- Crea una instancia de la clase Presentation.
- Itera a través de todas las diapositivas en la presentación.
- Escribe cada diapositiva en su propio archivo SVG a través de FileStream.

{{% alert color="primary" %}} 

Es posible que desees probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides para .NET.

{{% /alert %}} 

Este código de ejemplo en C# te muestra cómo convertir PPT a SVG utilizando Aspose.Slides:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```