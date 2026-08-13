---
title: API publique et modifications incompatibles ascendantes dans Aspose.Slides pour Java 14.10.0
linktitle: Aspose.Slides pour Java 14.10.0
type: docs
weight: 90
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
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
description: "Examinez les mises à jour de l'API publique et les changements incompatibles dans Aspose.Slides pour Java afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), ainsi que toutes les nouvelles restrictions et autres [changements](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introduits avec l’API Aspose.Slides pour Java 14.10.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **La méthode com.aspose.slides.FieldType.getFooter() a été ajoutée**
La méthode getFooter() renvoie le type de champ de pied de page. Elle a été ajoutée pour permettre la création de champs de ce type et pour une sérialisation valide de la présentation.
### **L'élément com.aspose.slides.ShapeElementFillSource.Own a été supprimé**
L'élément ShapeElementFillSource.Own a été supprimé car dupliqué. Utilisez ShapeElementFillSource.Shape à la place de ShapeElementFillSource.Own.
### **Des méthodes de suppression des points de données et des catégories de graphiques ont été ajoutées**
**Les méthodes suivantes, qui permettent de supprimer un point de données d'une collection de points de données, ont été ajoutées :**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()

**La méthode suivante, qui permet de supprimer une catégorie de graphique de la collection contenant, a été ajoutée :**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


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
### **Les constructeurs inutiles et obsolètes ont été supprimés**
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