---
title: Graphique en bulles
type: docs
url: /cpp/bubble-chart/
---

## **Mise à l'échelle de la taille des graphiques en bulles**
Aspose.Slides pour C++ fournit un support pour la mise à l'échelle de la taille des graphiques en bulles. Dans Aspose.Slides pour **C++**, les propriétés **IChartSeries.BubbleSizeScale** et **IChartSeriesGroup.BubbleSizeScale** ont été ajoutées. Un exemple de code est donné ci-dessous. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **Représenter les données sous forme de tailles de graphique en bulles**
Un nouveau méthode **get_BubbleSizeRepresentation()** a été ajoutée aux classes **IChartSeries** et **ChartSeries**. **BubbleSizeRepresentation** spécifie comment les valeurs de taille des bulles sont représentées dans le graphique en bulles. Les valeurs possibles sont : **BubbleSizeRepresentationType.Area** et **BubbleSizeRepresentationType.Width**. En conséquence, l'énumération **BubbleSizeRepresentationType** a été ajoutée pour spécifier les manières possibles de représenter les données sous forme de tailles de graphique en bulles. Un exemple de code est donné ci-dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}