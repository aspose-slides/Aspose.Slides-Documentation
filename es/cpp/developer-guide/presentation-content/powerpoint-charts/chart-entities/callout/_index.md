---
title: Gestionar llamadas de anotación en gráficos de presentación usando C++
linktitle: Llamada
type: docs
url: /es/cpp/callout/
keywords:
- llamada de gráfico
- usar llamada
- etiqueta de datos
- formato de etiqueta
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Cree y configure llamadas de anotación en Aspose.Slides para C++ con ejemplos de código concisos, compatibles con PPT y PPTX para automatizar flujos de trabajo de presentaciones."
---
## **Visión general**

Este artículo explica cómo trabajar con llamadas de anotación para las etiquetas de datos de los gráficos en Aspose.Slides. Muestra cómo usar el método `set_ShowLabelAsDataCallout` para mostrar las etiquetas como llamadas de anotación, cómo configurar los ajustes de etiquetas relacionados con las llamadas de anotación para un gráfico de anillo, y señala que las llamadas de anotación y su apariencia se conservan cuando las presentaciones se exportan a PDF, HTML5, SVG y formatos de imagen raster.

## **Uso de llamadas de anotación**
Nueva propiedad **ShowLabelAsDataCallout** se ha añadido a la clase **DataLabelFormat** y a la interfaz **IDataLabelFormat**, lo que determina si la etiqueta de datos del gráfico especificado se mostrará como llamada de anotación o como etiqueta de datos. En el ejemplo que se muestra a continuación, hemos configurado las llamadas de anotación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Establecer una llamada de anotación para un gráfico de anillo**
Aspose.Slides para C++ ofrece soporte para establecer la forma de la llamada de anotación de la etiqueta de datos de la serie para un gráfico de anillo. A continuación se muestra un ejemplo de muestra.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**¿Se conservan las llamadas de anotación al convertir una presentación a PDF, HTML5, SVG o imágenes?**

Sí. Las llamadas de anotación forman parte del renderizado del gráfico, por lo que cuando exportas a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/es/cpp/export-to-html5/), [SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/), o [raster images](/slides/es/cpp/convert-powerpoint-to-png/), se conservan junto con el formato de la diapositiva.

**¿Las fuentes personalizadas funcionan en las llamadas de anotación y se puede conservar su apariencia al exportar?**

Sí. Aspose.Slides soporta [incorporar fuentes](/slides/es/cpp/embedded-font/) en la presentación y controla la incorporación de fuentes durante exportaciones como [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), asegurando que las llamadas de anotación se vean iguales en diferentes sistemas.