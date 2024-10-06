---
title: API Public et Changements Incompatibles Rétro dans Aspose.Slides pour Java 15.2.0
type: docs
weight: 110
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) de classes, méthodes, propriétés, etc., toutes nouvelles restrictions et autres [changements](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) introduits avec l'API Aspose.Slides pour Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

Il existe des problèmes connus avec certains bullets d'image et objets WordArt qui seront corrigés dans Aspose.Slides pour Java 15.2.0.

{{% /alert %}} 
## **Changements de l'API Publique**
### **Les méthodes addDataPointForDoughnutSeries ont été ajoutées**
Les deux surcharges de la méthode IChartDataPointCollection.addDataPointForDoughnutSeries() ont été ajoutées pour ajouter des points de données dans des séries de type Doughnut.
### **La classe com.aspose.slides.SmartArtShape a été héritée de la classe com.aspose.slides.GeometryShape**
La classe com.aspose.slides.SmartArtShape a été héritée de la classe com.aspose.slides.GeometryShape. Ce changement améliore le modèle d'objet Aspose.Slides et ajoute de nouvelles fonctionnalités à la classe SmartArtShape.
### **Les méthodes IGradientStopCollection.add(...) et IGradientStopCollection.insert(...) ont été modifiées**
La signature de IGradientStop add(float position, int presetColor) est remplacée par la signature IGradientStop addPresetColor(float position, int presetColor).

La signature de la méthode IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) est remplacée par la signature IGradientStop addSchemeColor(float position, int schemeColor).

La signature de la méthode IGradientStopCollection void insert(int index, float position, int presetColor) est remplacée par la signature void insertPresetColor(int index, float position, int presetColor).

La signature de la méthode IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) est remplacée par la signature void insertSchemeColor(int index, float position, int schemeColor).
### **La méthode java.awt.Color getAutomaticSeriesColor() a été ajoutée à com.aspose.slides.IChartSeries**
La méthode getAutomaticSeriesColor() retourne une couleur automatique de la série basé sur l'index de la série et le style du graphique. Cette couleur est utilisée par défaut si FillType est égal à NotDefined.
﻿

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Une méthode pour supprimer un point de données de graphique et une catégorie de graphique par son index a été ajoutée**
La méthode IChartDataPointCollection.removeAt(int index) a été ajoutée pour supprimer un point de données de graphique par son index.
La méthode IChartCategoryCollection.removeAt(int index) a été ajoutée pour supprimer une catégorie de graphique par son index.
### **La valeur PptXPptY a été ajoutée à l'énumération com.aspose.slides.PropertyType**
La valeur PptXPptY a été ajoutée à l'énumération com.aspose.slides.PropertyType dans le cadre d'un correctif de problème de sérialisation.