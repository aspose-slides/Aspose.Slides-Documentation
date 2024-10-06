---
title: API Public et Changements Incompatibles avec les Versions Antérieures dans Aspose.Slides pour Java 14.10.0
type: docs
weight: 90
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) de classes, méthodes, propriétés, etc., toutes les nouvelles restrictions et autres [changements](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introduits avec l'API Aspose.Slides pour Java 14.10.0.

{{% /alert %}} 
## **Changements de l'API Public**
### **La méthode com.aspose.slides.FieldType.getFooter() a été ajoutée**
La méthode getFooter() retourne le type de champ de pied de page. Elle a été ajoutée pour permettre la création de champs de ce type et pour une sérialisation de présentation valide.
### **L'élément com.aspose.slides.ShapeElementFillSource.Own a été supprimé**
L'élément ShapeElementFillSource.Own a été supprimé car dupliqué. Utilisez ShapeElementFillSource.Shape à la place de ShapeElementFillSource.Own.
### **Des méthodes pour la suppression de points de données de graphique et de catégories ont été ajoutées**
**Les méthodes suivantes, qui permettent de supprimer un point de données de graphique d'une collection de points de données de graphique, ont été ajoutées :**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**La méthode suivante, qui permet de supprimer une catégorie de graphique de la collection contenant, a été ajoutée :**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // supprimer avec ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // supprimer avec ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // supprimer avec ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Les méthodes obsolètes Aspose.Slides.ParagraphFormat ont été supprimées**
Les méthodes getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() et les méthodes set correspondantes ont été supprimées. Elles étaient marquées comme obsolètes depuis longtemps.
### **Des constructeurs non utiles et obsolètes ont été supprimés**
Les constructeurs suivants ont été supprimés :

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)