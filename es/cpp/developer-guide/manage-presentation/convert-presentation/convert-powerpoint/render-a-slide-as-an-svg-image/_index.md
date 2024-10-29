---
title: Renderizar una diapositiva como una imagen SVG
type: docs
weight: 50
url: /es/cpp/render-a-slide-as-an-svg-image/
---

SVG—un acrónimo de Gráficos Vectoriales Escalables—es un tipo o formato gráfico estándar utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia.

SVG es uno de los pocos formatos de imagen que cumple con estándares muy altos en estos términos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad, entre otros. Por estas razones, se utiliza comúnmente en el desarrollo web.

Es posible que desees utilizar archivos SVG cuando necesites

- **imprimir tu presentación en un *formato muy grande*.** Las imágenes SVG pueden escalarse a cualquier resolución o nivel. Puedes redimensionar imágenes SVG tantas veces como sea necesario sin sacrificar la calidad.
- **utilizar gráficos y diagramas de tus diapositivas en *diferentes medios o plataformas**.* La mayoría de los lectores pueden interpretar archivos SVG.
- **usar los *tamaños más pequeños posibles de imágenes***. Los archivos SVG son generalmente más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos basados en bitmap (JPEG o PNG).

Aspose.Slides para C++ te permite exportar diapositivas en tus presentaciones como imágenes SVG. Sigue estos pasos para generar imágenes SVG:

1. Crea una instancia de la clase Presentation.
2. Itera a través de todas las diapositivas en la presentación.
3. Escribe cada diapositiva en su propio archivo SVG a través de FileStream.

{{% alert color="primary" %}} 

Es posible que desees probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides para C++.

{{% /alert %}} 

Este código de muestra en C++ te muestra cómo convertir PPT a SVG usando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```