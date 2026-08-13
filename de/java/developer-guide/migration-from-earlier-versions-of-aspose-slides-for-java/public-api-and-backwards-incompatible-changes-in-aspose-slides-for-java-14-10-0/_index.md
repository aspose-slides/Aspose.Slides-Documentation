---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für Java 14.10.0
linktitle: Aspose.Slides für Java 14.10.0
type: docs
weight: 90
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- Migration
- Legacy-Code
- Moderne Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die Breaking Changes in Aspose.Slides für Java, um Ihre PowerPoint-PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 
Diese Seite listet alle [hinzugefügten](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) Klassen, Methoden, Eigenschaften usw., sowie neue Einschränkungen und weitere [Änderungen](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) ein, die mit der Aspose.Slides for Java 14.10.0 API eingeführt wurden.
{{% /alert %}} 
## **Änderungen der öffentlichen API**
### **com.aspose.slides.FieldType.getFooter() Methode wurde hinzugefügt**
Die getFooter()-Methode gibt den Fußzeilenfeldtyp zurück. Sie wurde hinzugefügt, um die Möglichkeit zu implementieren, Felder dieses Typs zu erstellen, und für eine gültige Präsentationsserialisierung.
### **Element com.aspose.slides.ShapeElementFillSource.Own wurde gelöscht**
Das Element ShapeElementFillSource.Own wurde als Duplikat gelöscht. Verwenden Sie ShapeElementFillSource.Shape anstelle von ShapeElementFillSource.Own.
### **Methoden zum Entfernen von Diagrammdatenpunkten und -kategorien wurden hinzugefügt**
**Die folgenden Methoden, die das Entfernen eines Diagrammdatapunkts aus einer Diagrammdatapunktesammlung ermöglichen, wurden hinzugefügt:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Die folgende Methode, die das Entfernen einer Diagrammkategorie aus der enthaltenden Sammlung ermöglicht, wurde hinzugefügt:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // Entfernen mit ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // Entfernen mit ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // Entfernen mit ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Veraltete Aspose.Slides.ParagraphFormat-Methoden wurden entfernt**
Die Methoden getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() und die entsprechenden Set-Methoden wurden entfernt. Sie wurden bereits vor langer Zeit als veraltet markiert.
### **Unnütze und veraltete Konstruktoren wurden entfernt**
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