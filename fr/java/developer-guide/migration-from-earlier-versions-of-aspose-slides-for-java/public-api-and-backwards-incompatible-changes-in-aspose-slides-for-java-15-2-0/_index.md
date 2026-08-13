---
title: API publique et modifications incompatibles avec les versions antérieures dans Aspose.Slides for Java 15.2.0
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Passez en revue les mises à jour de l'API publique et les modifications incompatibles dans Aspose.Slides for Java pour migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 
Cette page répertorie toutes les classes, méthodes, propriétés, etc., ainsi que les nouvelles restrictions et les autres [modifications](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) introduites avec l'API Aspose.Slides for Java 15.2.0.
{{% /alert %}} {{% alert color="info" %}} 
Il existe des problèmes connus avec certaines puces d'image et objets WordArt qui seront corrigés dans Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **Modifications de l'API publique**
### **Méthodes addDataPointForDoughnutSeries ajoutées**
Les deux surcharges de la méthode IChartDataPointCollection.addDataPointForDoughnutSeries() ont été ajoutées pour ajouter des points de données aux séries de type Doughnut.
### **La classe com.aspose.slides.SmartArtShape a été héritée de la classe com.aspose.slides.GeometryShape**
La classe com.aspose.slides.SmartArtShape a été héritée de la classe com.aspose.slides.GeometryShape. Cette modification améliore le modèle d'objet Aspose.Slides et ajoute de nouvelles fonctionnalités à la classe SmartArtShape.
### **Les méthodes IGradientStopCollection.add(...) et IGradientStopCollection.insert(...) ont été modifiées**
La signature de IGradientStop add(float position, int presetColor) est remplacée par la signature IGradientStop addPresetColor(float position, int presetColor).
La signature de la méthode IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) est remplacée par la signature IGradientStop addSchemeColor(float position, int schemeColor).
La signature de la méthode IGradientStopCollection void insert(int index, float position, int presetColor) est remplacée par la signature void insertPresetColor(int index, float position, int presetColor).
La signature de la méthode IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) est remplacée par la signature void insertSchemeColor(int index, float position, int schemeColor).
### **La méthode java.awt.Color getAutomaticSeriesColor() a été ajoutée à com.aspose.slides.IChartSeries**
La méthode getAutomaticSeriesColor() renvoie une couleur automatique de la série basée sur l'index de la série et le style du graphique. Cette couleur est utilisée par défaut si FillType est égal à NotDefined.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Méthode de suppression d'un point de données de graphique et d'une catégorie de graphique par leur indice a été ajoutée**
La méthode IChartDataPointCollection.removeAt(int index) a été ajoutée pour supprimer un point de données de graphique par son indice.
La méthode IChartCategoryCollection.removeAt(int index) a été ajoutée pour supprimer une catégorie de graphique par son indice.
### **Valeur PptXPptY ajoutée à l'énumération com.aspose.slides.PropertyType**
La valeur PptXPptY a été ajoutée à l'énumération com.aspose.slides.PropertyType dans le cadre d'une correction d'un problème de sérialisation.