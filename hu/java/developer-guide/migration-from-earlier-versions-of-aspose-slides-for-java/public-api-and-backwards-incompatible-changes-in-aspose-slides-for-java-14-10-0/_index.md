---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.10.0-ban
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a törődésre alkalmas változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migreálja PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [added](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) osztályt, metódust, tulajdonságot és így tovább, valamint az új korlátozásokat és egyéb [changes](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) bevezetését az Aspose.Slides for Java 14.10.0 API-val.

{{% /alert %}} 
## **Nyilvános API változások**
### **com.aspose.slides.FieldType.getFooter() metódus hozzá lett adva**
A getFooter() metódus visszaadja a lábléc mező típusát. Azért lett hozzáadva, hogy lehetővé tegye ennek a típusnak a mezők létrehozását, valamint az érvényes bemutató sorosítását.
### **Elem com.aspose.slides.ShapeElementFillSource.Own törölve lett**
A ShapeElementFillSource.Own elem duplikátumként lett törölve. Használja a ShapeElementFillSource.Shape-et a ShapeElementFillSource.Own helyett.
### **Diagram adatpontok és kategóriák eltávolításához kapcsolódó metódusok hozzá lettek adva**
A következő metódusok, amelyek lehetővé teszik egy diagram adatpont eltávolítását egy diagram adatpont gyűjteményből, hozzá lettek adva:

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

A következő metódus, amely lehetővé teszi egy diagramkategória eltávolítását a tartalmazó gyűjteményből, hozzá lett adva:

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // eltávolítás a ChartCategory.remove() használatával

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // eltávolítás a ChartCategoryCollection.remove() használatával

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // eltávolítás a ChartDataPoint.remove() használatával

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Elavult Aspose.Slides.ParagraphFormat metódusok eltávolítva lettek**
A getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith() és getNumberedBulletStyle() metódusok, valamint a hozzájuk tartozó set metódusok eltávolításra kerültek. Ezeket már régóta elavultként jelölték meg.
### **Használhatatlan és elavult konstruktorok törölve lettek**
A következő konstruktorok törölve lettek:

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