---
title: Personnaliser les graphiques à bulles dans les présentations sur Android
linktitle: Graphique à bulles
type: docs
url: /fr/androidjava/bubble-chart/
keywords:
- graphique à bulles
- taille de bulle
- mise à l'échelle de taille
- représentation de taille
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer et personnaliser des graphiques à bulles puissants dans PowerPoint avec Aspose.Slides for Android via Java pour améliorer votre visualisation de données facilement."
---

## **Mise à l'échelle de la taille du graphique à bulles**
Aspose.Slides for Android via Java fournit la prise en charge de la mise à l'échelle de la taille du graphique à bulles. Dans Aspose.Slides for Android via Java les méthodes [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) et [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) ont été ajoutées. L'exemple de code ci‑dessous est fourni. 
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Représenter les données en tant que tailles de graphique à bulles**
Les méthodes [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) et [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) ont été ajoutées aux interfaces [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) ainsi qu'aux classes associées. **BubbleSizeRepresentation** indique comment les valeurs de taille des bulles sont représentées dans le graphique à bulles. Les valeurs possibles sont : [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) et [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). En conséquence, l’énumération [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) a été ajoutée pour spécifier les manières possibles de représenter les données en tant que tailles de graphique à bulles. Un exemple de code est fourni ci‑dessous.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Un « graphique à bulles avec effet 3D » est‑il pris en charge, et comment diffère‑t‑il d’un graphique standard ?**

Oui. Il existe un type de graphique distinct, « Bubble with 3-D ». Il applique un style 3 D aux bulles mais n’ajoute pas d’axe supplémentaire ; les données restent X‑Y‑S (taille). Ce type est disponible dans la classe [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

**Y a‑t‑il une limite au nombre de séries et de points dans un graphique à bulles ?**

Il n’y a pas de limite stricte au niveau de l’API ; les contraintes sont déterminées par les performances et la version cible de PowerPoint. Il est recommandé de garder un nombre de points raisonnable pour la lisibilité et la vitesse de rendu.

**Comment l’exportation affecte‑t‑elle l’apparence d’un graphique à bulles (PDF, images) ?**

L’exportation vers les formats supportés préserve l’apparence du graphique ; le rendu est effectué par le moteur Aspose.Slides. Pour les formats raster/vecteur, les règles générales de rendu des graphiques s’appliquent (résolution, anti‑aliasing), il faut donc choisir une DPI suffisante pour l’impression.