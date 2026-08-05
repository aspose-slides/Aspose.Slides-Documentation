---
title: Personnaliser les graphiques à bulles dans les présentations avec C++
linktitle: Graphique à bulles
type: docs
url: /fr/cpp/bubble-chart/
keywords:
- graphique à bulles
- taille de bulle
- mise à l'échelle de la taille
- représentation de la taille
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Créez et personnalisez des graphiques à bulles puissants dans PowerPoint avec Aspose.Slides pour C++ afin d'améliorer facilement votre visualisation de données."
---
## **Vue d'ensemble**

Cet article montre comment travailler avec les graphiques à bulles dans Aspose.Slides. Il couvre deux options de personnalisation spécifiques : le redimensionnement des bulles via la méthode `set_BubbleSizeScale` et le contrôle de la façon dont les valeurs de taille des bulles sont représentées via la méthode `set_BubbleSizeRepresentation`.

Les exemples montrent comment créer un graphique à bulles, ajuster son redimensionnement, et changer la représentation de la taille des bulles pour utiliser la largeur. L'article comprend également une courte section FAQ qui précise la prise en charge du type de graphique « Bubble with 3-D », indique que les limites pratiques du graphique dépendent des performances et de la version cible de PowerPoint, et explique que l'exportation préserve l'apparence du graphique grâce au moteur de rendu Aspose.Slides.

## **Mise à l'échelle de la taille du graphique à bulles**
Aspose.Slides pour C++ prend en charge la mise à l'échelle de la taille des graphiques à bulles. Dans Aspose.Slides pour **C++ IChartSeries.BubbleSizeScale** et **IChartSeriesGroup.BubbleSizeScale** des propriétés ont été ajoutées. L'exemple ci‑dessous est fourni. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Représenter les données comme tailles de graphiques à bulles**
Une nouvelle méthode **get_BubbleSizeRepresentation()** a été ajoutée aux classes **IChartSeries** et **ChartSeries**. **BubbleSizeRepresentation** spécifie comment les valeurs de taille des bulles sont représentées dans le graphique à bulles. Les valeurs possibles sont : **BubbleSizeRepresentationType.Area** et **BubbleSizeRepresentationType.Width**. En conséquence, l'énumération **BubbleSizeRepresentationType** a été ajoutée pour définir les manières possibles de représenter les données comme tailles de graphiques à bulles. Le code d'exemple est fourni ci‑dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Un graphique à bulles avec effet 3 D est‑il pris en charge, et en quoi diffère‑t‑il d’un graphique standard ?**

Oui. Il existe un type de graphique distinct, « Bubble with 3‑D ». Il applique un style 3‑D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Ce type est disponible dans l'énumération [chart type](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/charttype/).

**Existe‑t‑il une limite au nombre de séries et de points dans un graphique à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes sont déterminées par les performances et la version cible de PowerPoint. Il est recommandé de garder le nombre de points raisonnable pour la lisibilité et la vitesse de rendu.

**Comment l’exportation affecte‑t‑elle l’apparence d’un graphique à bulles (PDF, images) ?**

L’exportation vers les formats pris en charge préserve l’aspect du graphique ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster/vecteur, les règles générales de rendu des graphiques s’appliquent (résolution, anti‑aliasing), il faut donc choisir un DPI suffisant pour l’impression.