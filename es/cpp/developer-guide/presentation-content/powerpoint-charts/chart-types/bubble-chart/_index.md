---
title: Gráfico de Burbujas
type: docs
url: /cpp/bubble-chart/
---

## **Escalado del Tamaño del Gráfico de Burbujas**
Aspose.Slides para C++ proporciona soporte para el escalado del tamaño del gráfico de burbujas. En Aspose.Slides para **C++ se han agregado las propiedades **IChartSeries.BubbleSizeScale** y **IChartSeriesGroup.BubbleSizeScale**. A continuación se presenta un ejemplo de muestra.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **Representar Datos como Tamaños de Gráfico de Burbujas**
Se ha agregado un nuevo método **get_BubbleSizeRepresentation()** a las clases **IChartSeries** y **ChartSeries**. **BubbleSizeRepresentation** especifica cómo se representan los valores del tamaño de las burbujas en el gráfico de burbujas. Los valores posibles son: **BubbleSizeRepresentationType.Area** y **BubbleSizeRepresentationType.Width**. En consecuencia, se ha agregado el enum **BubbleSizeRepresentationType** para especificar las posibles formas de representar datos como tamaños de gráfico de burbujas. A continuación se presenta un código de muestra.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}