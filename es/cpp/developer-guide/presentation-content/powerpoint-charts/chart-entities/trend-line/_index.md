---
title: Línea de Tendencia
type: docs
url: /es/cpp/trend-line/
---

## **Agregar Línea de Tendencia**
Aspose.Slides para C++ proporciona una API simple para gestionar diferentes Líneas de Tendencia en gráficos:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Obtenga la referencia de una diapositiva por su índice.
1. Agregue un gráfico con datos predeterminados junto con cualquier tipo deseado (este ejemplo utiliza ChartType.ClusteredColumn).
1. Agregando la línea de tendencia exponencial para la serie de gráficos 1.
1. Agregando una línea de tendencia lineal para la serie de gráficos 1.
1. Agregando una línea de tendencia logarítmica para la serie de gráficos 2.
1. Agregando una línea de tendencia de media móvil para la serie de gráficos 2.
1. Agregando una línea de tendencia polinómica para la serie de gráficos 3.
1. Agregando una línea de tendencia de potencia para la serie de gráficos 3.
1. Escriba la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico con Líneas de Tendencia.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Agregar Línea Personalizada**
Aspose.Slides para C++ proporciona una API simple para agregar líneas personalizadas en un gráfico. Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva usando su índice
- Cree un nuevo gráfico utilizando el método AddChart expuesto por el objeto Shapes
- Agregue una AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes
- Establezca el color de las líneas de la forma.
- Escriba la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con Líneas Personalizadas.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}