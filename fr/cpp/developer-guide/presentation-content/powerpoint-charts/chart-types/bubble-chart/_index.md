---
title: Personnaliser les graphiques à bulles dans les présentations en С++
linktitle: Graphique à bulles
type: docs
url: /fr/cpp/bubble-chart/
keywords:
- graphique à bulles
- taille de la bulle
- mise à l'échelle de la taille
- représentation de la taille
- PowerPoint
- présentation
- С++
- Aspose.Slides
description: "Créez et personnalisez des graphiques à bulles puissants dans PowerPoint avec Aspose.Slides pour С++ afin d'améliorer facilement la visualisation de vos données."
---

## **Mise à l’échelle de la taille du diagramme à bulles**
Aspose.Slides for C++ offre la prise en charge de la mise à l’échelle de la taille des diagrammes à bulles. Dans Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** et **IChartSeriesGroup.BubbleSizeScale** des propriétés ont été ajoutées. L’exemple de code ci‑dessous est fourni. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Représenter les données comme tailles de diagrammes à bulles**
Une nouvelle méthode **get_BubbleSizeRepresentation()** a été ajoutée aux classes **IChartSeries** et **ChartSeries**. **BubbleSizeRepresentation** indique comment les valeurs de taille des bulles sont représentées dans le diagramme à bulles. Les valeurs possibles sont : **BubbleSizeRepresentationType.Area** et **BubbleSizeRepresentationType.Width**. En conséquence, l’énumération **BubbleSizeRepresentationType** a été ajoutée pour spécifier les manières possibles de représenter les données comme tailles de diagrammes à bulles. Le code d’exemple est fourni ci‑dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Un diagramme à bulles avec effet 3‑D est‑il pris en charge, et en quoi diffère‑t‑il d’un diagramme standard ?**

Oui. Il existe un type de diagramme distinct, « Bubble with 3‑D ». Il applique un style 3‑D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Le type est disponible dans l’[type de graphique](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) de l’énumération.

**Existe‑t‑il une limite au nombre de séries et de points dans un diagramme à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes dépendent des performances et de la version cible de PowerPoint. Il est recommandé de garder le nombre de points raisonnable pour la lisibilité et la vitesse de rendu.

**Comment l’exportation affectera‑t‑elle l’apparence d’un diagramme à bulles (PDF, images) ?**

L’exportation vers les formats pris en charge conserve l’apparence du diagramme ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster/vectoriels, les règles générales de rendu des graphiques de diagramme s’appliquent (résolution, anti‑aliasing), il faut donc choisir un DPI suffisant pour l’impression.