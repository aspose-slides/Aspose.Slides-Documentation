---
title: Personnaliser les graphiques à bulles dans les présentations avec Python
linktitle: Graphique à bulles
type: docs
url: /fr/python-java/bubble-chart/
keywords:
- graphique à bulles
- taille de bulle
- mise à l'échelle de taille
- représentation de taille
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créez et personnalisez des graphiques à bulles puissants dans PowerPoint avec Aspose.Slides for Python via Java pour améliorer facilement votre visualisation de données."
---
## **Vue d’ensemble**

Cet article montre comment travailler avec les graphiques à bulles dans Aspose.Slides. Il couvre deux options de personnalisation spécifiques : le redimensionnement des bulles via la méthode [setBubbleSizeScale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) et le contrôle de la façon dont les valeurs de taille des bulles sont représentées via la méthode [setBubbleSizeRepresentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Les exemples démontrent comment créer un graphique à bulles, ajuster le redimensionnement de taille, et changer la représentation de la taille de la bulle pour utiliser la largeur. L’article inclut également une courte section FAQ qui précise la prise en charge du type de graphique « Bubble with 3‑D », indique que les limites pratiques du graphique dépendent des performances et de la version cible de PowerPoint, et explique que l’exportation préserve l’apparence du graphique grâce au moteur de rendu Aspose.Slides.

## **Redimensionnement de la taille des bulles**
Aspose.Slides for Python via Java prend en charge le redimensionnement des graphiques à bulles via les méthodes [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) et [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). L’exemple suivant montre comment mettre à l’échelle les tailles des bulles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Représenter les données comme tailles de bulles**
Les méthodes [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) et [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) sont disponibles dans la classe [ChartSeriesGroup](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/). La représentation de la taille de la bulle indique comment les valeurs de taille des bulles sont présentées dans le graphique à bulles. Les valeurs possibles sont [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bubblesizerepresentationtype/#Area) et [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bubblesizerepresentationtype/#Width). L’énumération [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bubblesizerepresentationtype/) spécifie les manières possibles de représenter les données comme tailles de graphiques à bulles. L’exemple suivant montre comment représenter les tailles de bulles en utilisant la largeur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Un « graphique à bulles avec effet 3‑D » est‑il pris en charge, et en quoi diffère‑t‑il d’un graphique standard ?**

Oui. Il existe un type de graphique distinct, « Bubble with 3‑D ». Il applique un style 3‑D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Le type est disponible dans la classe [chart type](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/).

**Existe‑t‑il une limite du nombre de séries et de points dans un graphique à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes sont déterminées par les performances et la version cible de PowerPoint. Il est recommandé de garder le nombre de points raisonnable pour la lisibilité et la vitesse de rendu.

**Comment l’exportation affecte‑t‑elle l’apparence d’un graphique à bulles (PDF, images) ?**

L’exportation vers les formats pris en charge préserve l’apparence du graphique ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster/vectoriels, les règles générales de rendu des graphiques s’appliquent (résolution, anti‑aliasing), il faut donc choisir un DPI suffisant pour l’impression.