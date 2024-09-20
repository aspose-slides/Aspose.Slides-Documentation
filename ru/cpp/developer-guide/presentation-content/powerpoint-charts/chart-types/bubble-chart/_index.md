---
title: Диаграмма с пузырьками
type: docs
url: /cpp/bubble-chart/
---

## **Масштабирование размеров пузырьков диаграммы**
Aspose.Slides для C++ поддерживает масштабирование размеров пузырьков диаграммы. В Aspose.Slides для **C++ были добавлены свойства IChartSeries.BubbleSizeScale и IChartSeriesGroup.BubbleSizeScale**. Ниже приведен пример.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Представление данных в виде размеров пузырьков диаграммы**
Новый метод **get_BubbleSizeRepresentation()** был добавлен в классы **IChartSeries** и **ChartSeries**. **BubbleSizeRepresentation** определяет, как значения размеров пузырьков представлены в диаграмме с пузырьками. Возможные значения: **BubbleSizeRepresentationType.Area** и **BubbleSizeRepresentationType.Width**. Соответственно, перечисление **BubbleSizeRepresentationType** было добавлено для определения возможных способов представления данных в виде размеров пузырьков диаграммы. Пример кода приведён ниже.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}