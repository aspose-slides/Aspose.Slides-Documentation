---
title: API public et modifications non compatibles avec les versions antérieures dans Aspose.Slides pour Java 14.10.0
type: docs
weight: 90
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), les nouvelles restrictions et autres [modifications](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introduites avec l'API Aspose.Slides pour Java 14.10.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **La méthode com.aspose.slides.FieldType.getFooter() a été ajoutée**
La méthode getFooter() retourne le type de champ de pied de page. Elle a été ajoutée pour mettre en œuvre la possibilité de créer des champs de ce type et pour une sérialisation de présentation valide.
### **L'élément com.aspose.slides.ShapeElementFillSource.Own a été supprimé**
L'élément ShapeElementFillSource.Own a été supprimé car il était dupliqué. Utilisez ShapeElementFillSource.Shape au lieu de ShapeElementFillSource.Own.
### **Des méthodes pour supprimer des points de données de graphiques et des catégories ont été ajoutées**
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
### **Des constructeurs inutiles et obsolètes ont été supprimés**
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