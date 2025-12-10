---
title: Agregar líneas de tendencia a los gráficos de presentaciones en С++
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
- С++
- Aspose.Slides
description: "Agregue y personalice rápidamente líneas de tendencia en gráficos de PowerPoint con Aspose.Slides para С++ — una guía práctica para cautivar a su audiencia."
---

## **Agregar una línea de tendencia**
Aspose.Slides para C++ proporciona una API sencilla para administrar diferentes líneas de tendencia de gráficos:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva por su índice.
1. Añadir un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo utiliza ChartType.ClusteredColumn).
1. Añadir la línea de tendencia exponencial para la serie 1 del gráfico.
1. Añadir una línea de tendencia lineal para la serie 1 del gráfico.
1. Añadir una línea de tendencia logarítmica para la serie 2 del gráfico.
1. Añadir una línea de tendencia de media móvil para la serie 2 del gráfico.
1. Añadir una línea de tendencia polinómica para la serie 3 del gráfico.
1. Añadir una línea de tendencia de potencia para la serie 3 del gráfico.
1. Guardar la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico con líneas de tendencia.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Agregar una línea personalizada**
Aspose.Slides para C++ ofrece una API sencilla para agregar líneas personalizadas en un gráfico. Para añadir una línea sencilla a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Obtener la referencia de una diapositiva usando su Index
- Crear un nuevo gráfico mediante el método AddChart expuesto por el objeto Shapes
- Añadir un AutoShape de tipo Line mediante el método AddAutoShape expuesto por el objeto Shapes
- Establecer el Color de las líneas de la forma.
- Guardar la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con líneas personalizadas.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**¿Qué significan ‘forward’ y ‘backward’ en una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades del eje; para gráficos que no son de dispersión — en número de categorías. Sólo se permiten valores no negativos.

**¿Se preservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/) y renderiza gráficos como imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/cpp/create-shape-thumbnails/) mismo.