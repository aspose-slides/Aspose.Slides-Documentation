---
title: Blasendiagramm
type: docs
url: /de/cpp/bubble-chart/
---

## **Skalierung der Blasendiagrammgröße**
Aspose.Slides für C++ bietet Unterstützung für die Skalierung der Blasendiagrammgröße. In Aspose.Slides für **C++ wurden die Eigenschaften IChartSeries.BubbleSizeScale** und **IChartSeriesGroup.BubbleSizeScale** hinzugefügt. Ein Beispiel ist unten gegeben. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **Daten als Blasendiagrammgrößen darstellen**
Die neue Methode **get_BubbleSizeRepresentation()** wurde zu den Klassen **IChartSeries** und **ChartSeries** hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Blasengrößenwerte im Blasendiagramm dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.Area** und **BubbleSizeRepresentationType.Width**. Entsprechend wurde das Enum **BubbleSizeRepresentationType** hinzugefügt, um die möglichen Möglichkeiten zur Darstellung von Daten als Blasendiagrammgrößen zu spezifizieren. Beispielcode ist unten gegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}