---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für PHP über Java 14.10.0
type: docs
weight: 90
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) Klassen, Methoden, Eigenschaften und so weiter, alle neuen Einschränkungen und andere [Änderungen](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) auf, die mit der Aspose.Slides für PHP über Java 14.10.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **Die Methode com.aspose.slides.FieldType::getFooter() wurde hinzugefügt**
Die Methode getFooter() gibt den Typ des Fußzeilenfeldes zurück. Sie wurde hinzugefügt, um die Möglichkeit zu schaffen, Felder dieses Typs zu erstellen und für eine gültige Präsentationsserialisierung.
### **Das Element com.aspose.slides.ShapeElementFillSource.Own wurde gelöscht**
Das Element ShapeElementFillSource.Own wurde als Duplikat gelöscht. Verwenden Sie anstelle von ShapeElementFillSource.Own den ShapeElementFillSource.Shape.
### **Methoden zum Entfernen von Diagrammdatenpunkten und -kategorien wurden hinzugefügt**
**Die folgenden Methoden, die das Entfernen eines Diagrammdatenpunkts aus einer Diagrammdatenpunktsammlung ermöglichen, wurden hinzugefügt:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Die folgende Methode, die das Entfernen einer Diagrammkategorie aus der enthaltenen Sammlung ermöglicht, wurde hinzugefügt:**

IChartCategory.remove()

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 400, true);
  $chart->getChartData()->getCategories()->get_Item(0)->remove();// Entfernen mit ChartCategory.remove()

  $chart->getChartData()->getCategories()->remove($chart->getChartData()->getCategories()->get_Item(0));// Entfernen mit ChartCategoryCollection.remove()

  foreach($chart->getChartData()->getSeries() as $ser) {
    $ser->getDataPoints()->get_Item(0)->remove();// Entfernen mit ChartDataPoint.remove()

    $ser->getDataPoints()->remove($ser->getDataPoints()->get_Item(0));// ChartDataPointCollection.remove()

  }
  $pres->save("presentation.pptx", SaveFormat::Pptx);

```
### **Veraltete Methoden von Aspose.Slides.ParagraphFormat wurden entfernt**
Die Methoden getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() und die entsprechenden Set-Methoden wurden entfernt. Sie wurden vor langer Zeit als veraltet markiert.
### **Nicht nützliche und veraltete Konstruktoren wurden entfernt**
Die folgenden Konstruktoren wurden entfernt:

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