---
title: Administrar anotaciones en gráficos de presentación con C++
linktitle: Anotación
type: docs
url: /es/cpp/callout/
keywords:
- anotación de gráfico
- usar anotación
- etiqueta de datos
- formato de etiqueta
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Cree y diseñe anotaciones en Aspose.Slides para C++ con ejemplos de código concisos, compatibles con PPT y PPTX para automatizar flujos de trabajo de presentaciones."
---

## **Uso de anotaciones**
Se ha agregado la nueva propiedad **ShowLabelAsDataCallout** a la clase **DataLabelFormat** y a la interfaz **IDataLabelFormat**, lo que determina si la etiqueta de datos del gráfico especificado se mostrará como anotación de datos o como etiqueta de datos. En el ejemplo que se muestra a continuación, hemos configurado las anotaciones.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Establecer una anotación para un gráfico de dona**
Aspose.Slides for C++ ofrece soporte para establecer la forma de anotación de etiqueta de datos de la serie para un gráfico de dona. A continuación se muestra un ejemplo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**¿Se conservan las anotaciones al convertir una presentación a PDF, HTML5, SVG o imágenes?**

Sí. Las anotaciones forman parte del renderizado del gráfico, por lo que al exportar a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/es/cpp/export-to-html5/), [SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/) o [imágenes raster](/slides/es/cpp/convert-powerpoint-to-png/), se conservan junto con el formato de la diapositiva.

**¿Los tipos de letra personalizados funcionan en las anotaciones y se puede conservar su apariencia al exportar?**

Sí. Aspose.Slides admite [incrustar fuentes](/slides/es/cpp/embedded-font/) en la presentación y controla la incrustación de fuentes durante exportaciones como [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), lo que garantiza que las anotaciones se vean iguales en diferentes sistemas.