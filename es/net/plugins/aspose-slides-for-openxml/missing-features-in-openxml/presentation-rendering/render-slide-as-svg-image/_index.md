---
title: Renderizar diapositiva como imagen SVG
type: docs
weight: 50
url: /es/net/render-slide-as-svg-image/
---
SVG—un acrónimo de Scalable Vector Graphics—es un tipo o formato estándar de gráficos utilizado para representar imágenes bidimensionales. SVG almacena las imágenes como vectores en XML con detalles que definen su comportamiento o apariencia. 

SVG es uno de los pocos formatos de imagen que cumple con estándares muy altos en estos aspectos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por estas razones, se utiliza habitualmente en el desarrollo web. 

Puede que desee usar archivos SVG en los siguientes escenarios:

- cuando planea imprimir su presentación en un formato muy grande. Las imágenes SVG pueden escalar a cualquier resolución o nivel. Puede redimensionar las imágenes SVG tantas veces como sea necesario sin sacrificar calidad.
- cuando pretende usar gráficos y diagramas de sus diapositivas en diferentes medios o plataformas. La mayoría de los lectores pueden interpretar archivos SVG. 
- cuando necesita utilizar los tamaños más pequeños posibles de imágenes. Los archivos SVG suelen ser más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente en los formatos basados en mapa de bits (JPEG o PNG).

Aspose.Slides para .NET le permite exportar diapositivas de sus presentaciones como imágenes **SVG**. Para generar una imagen SVG a partir de cualquier diapositiva, haga lo siguiente:

- Cree una instancia de la clase Presentation.
- Recorra todas las diapositivas de la presentación.
- Escriba cada diapositiva en su propio archivo SVG mediante FileStream.

{{% alert color="info" %}} 
Puede que desee probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/es/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides para .NET.
{{% /alert %}} 

Este código de ejemplo en C# le muestra cómo convertir PPT a SVG utilizando Aspose.Slides:

``` csharp
using Aspose.Slides;

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