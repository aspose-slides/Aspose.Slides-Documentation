---
title: Añadir líneas de tendencia a gráficos de presentación en C++
linktitle: Línea de tendencia
type: docs
url: /es/cpp/trend-line/
keywords:
- gráfico
- línea de tendencia
- línea de tendencia exponencial
- línea de tendencia lineal
- línea de tendencia logarítmica
- línea de tendencia de media móvil
- línea de tendencia polinómica
- línea de tendencia de potencia
- línea de tendencia personalizada
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Añade y personaliza rápidamente líneas de tendencia en gráficos de PowerPoint con Aspose.Slides para C++ — una guía práctica para captar la atención de tu audiencia."
---
## **Resumen**

Este artículo explica cómo añadir líneas de tendencia a los gráficos de presentación mediante Aspose.Slides. Muestra cómo crear un gráfico, añadir líneas de tendencia a las series del gráfico y trabajar con varios tipos de líneas de tendencia, incluyendo exponencial, lineal, logarítmica, media móvil, polinómica y de potencia.

También describe cómo añadir una línea personalizada a un gráfico insertando una forma de línea, e incluye una breve FAQ sobre los valores de proyección de línea de tendencia hacia adelante y hacia atrás y si las líneas de tendencia se conservan al exportar a PDF o SVG y al renderizar gráficos como imágenes.

## **Añadir una línea de tendencia**
Aspose.Slides para C++ proporciona una API sencilla para gestionar diferentes líneas de tendencia de gráficos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva por su índice.
3. Añada un gráfico con datos predeterminados junto con cualquiera del tipo deseado (este ejemplo utiliza ChartType.ClusteredColumn).
4. Añadiendo la línea de tendencia exponencial para la serie 1 del gráfico.
5. Añadiendo una línea de tendencia lineal para la serie 1 del gráfico.
6. Añadiendo una línea de tendencia logarítmica para la serie 2 del gráfico.
7. Añadiendo una línea de tendencia de media móvil para la serie 2 del gráfico.
8. Añadiendo una línea de tendencia polinómica para la serie 3 del gráfico.
9. Añadiendo una línea de tendencia de potencia para la serie 3 del gráfico.
10. Guarde la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico con líneas de tendencia.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Añadir una línea personalizada**
Aspose.Slides para C++ proporciona una API sencilla para añadir líneas personalizadas en un gráfico. Para añadir una línea sencilla y simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva usando su índice
- Cree un nuevo gráfico utilizando el método AddChart expuesto por el objeto Shapes
- Añada un AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes
- Establezca el color de las líneas de la forma.
- Guarde la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con líneas personalizadas.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **Preguntas frecuentes**

**¿Qué significan 'adelante' y 'atrás' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectada hacia adelante/atrás: para los gráficos de dispersión (XY) — en unidades del eje; para los gráficos que no son de dispersión — en número de categorías. Sólo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/) y renderiza los gráficos como imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/cpp/create-shape-thumbnails/).