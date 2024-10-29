---
title: API public et changements incompatibles avec les versions précédentes dans Aspose.Slides pour PHP via Java 14.10.0
type: docs
weight: 90
url: /fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les [ajouts](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) de classes, méthodes, propriétés, etc., toutes nouvelles restrictions et autres [changements](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introduits avec l'API Aspose.Slides pour PHP via Java 14.10.0.

{{% /alert %}} 
## **Changements de l'API publique**
### **La méthode com.aspose.slides.FieldType::getFooter() a été ajoutée**
La méthode getFooter() retourne le type de champ de pied de page. Elle a été ajoutée pour permettre la création de champs de ce type et pour la sérialisation valide des présentations.
### **L'élément com.aspose.slides.ShapeElementFillSource.Own a été supprimé**
L'élément ShapeElementFillSource.Own a été supprimé comme étant dupliqué. Utilisez ShapeElementFillSource.Shape à la place de ShapeElementFillSource.Own.
### **Des méthodes pour enlever des points de données de graphique et des catégories ont été ajoutées**
**Les méthodes suivantes, qui permettent de retirer un point de données de graphique d'une collection de points de données, ont été ajoutées :**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**La méthode suivante, qui permet de retirer une catégorie de graphique de la collection contenant, a été ajoutée :**

IChartCategory.remove()

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 400, true);
  $chart->getChartData()->getCategories()->get_Item(0)->remove();// retirer avec ChartCategory.remove()

  $chart->getChartData()->getCategories()->remove($chart->getChartData()->getCategories()->get_Item(0));// retirer avec ChartCategoryCollection.remove()

  foreach($chart->getChartData()->getSeries() as $ser) {
    $ser->getDataPoints()->get_Item(0)->remove();// retirer avec ChartDataPoint.remove()

    $ser->getDataPoints()->remove($ser->getDataPoints()->get_Item(0));// ChartDataPointCollection.remove()

  }
  $pres->save("presentation.pptx", SaveFormat::Pptx);

```
### **Les méthodes obsolètes Aspose.Slides.ParagraphFormat ont été supprimées**
Les méthodes getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() et les méthodes set correspondantes ont été supprimées. Elles avaient été marquées comme obsolètes il y a longtemps.
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