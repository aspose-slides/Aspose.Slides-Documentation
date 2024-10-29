---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für Java 14.10.0
type: docs
weight: 90
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) Klassen, Methoden, Eigenschaften usw., neue Einschränkungen und andere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), die mit der Aspose.Slides für Java 14.10.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Die Methode com.aspose.slides.FieldType.getFooter() wurde hinzugefügt**
Die Methode getFooter() gibt den Fußzeilentyp zurück. Sie wurde hinzugefügt, um die Möglichkeit zu implementieren, Felder dieses Typs zu erstellen und eine gültige Präsentationsserialisierung zu gewährleisten.
### **Das Element com.aspose.slides.ShapeElementFillSource.Own wurde gelöscht**
Das Element ShapeElementFillSource.Own wurde als Duplikat gelöscht. Verwenden Sie stattdessen ShapeElementFillSource.Shape.
### **Methoden zum Entfernen von Diagrammdatenpunkten und -kategorien wurden hinzugefügt**
**Die folgenden Methoden, die es ermöglichen, einen Diagrammdatenpunkt aus einer Diagrammdatenpunktsammlung zu entfernen, wurden hinzugefügt:**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()

**Die folgende Methode, die es erlaubt, eine Diagrammkategorie aus der enthaltenden Sammlung zu entfernen, wurde hinzugefügt:**

IChartCategory.remove()

``` java

 Präsentation pres = new Präsentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // entfernen mit ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // entfernen mit ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // entfernen mit ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Veraltete Aspose.Slides.ParagraphFormat-Methoden wurden entfernt**
Die Methoden getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() und die entsprechenden Set-Methoden wurden entfernt. Sie wurden schon vor langem als veraltet markiert.
### **Unnötige und veraltete Konstruktoren wurden entfernt**
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