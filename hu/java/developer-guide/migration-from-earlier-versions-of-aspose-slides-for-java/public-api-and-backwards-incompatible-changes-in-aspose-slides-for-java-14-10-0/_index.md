---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.10.0-ban
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
- bemutató
- Java
- Aspose.Slides
description: "Tekintse át a publikus API frissítéseket és a törékeny változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP bemutató megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) osztályt, metódust, tulajdonságot stb., az új korlátozásokat és más [változásokat](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) a Aspose.Slides for Java 14.10.0 API-val kapcsolatban.

{{% /alert %}} 
## **Publikus API változások**
### **com.aspose.slides.FieldType.getFooter() metódus hozzá lett adva**
A getFooter() metódus visszaadja a lábléc mező típusát. Hozzá lett adva annak érdekében, hogy lehető legyen ennek a típusnak a mezők létrehozása, és a bemutató helyes sorosítása.
### **Elem com.aspose.slides.ShapeElementFillSource.Own törölve lett**
A ShapeElementFillSource.Own elemet duplikációnak tekintve törölték. Használja a ShapeElementFillSource.Shape-et a ShapeElementFillSource.Own helyett.
### **Diagram adatpontok, kategóriák eltávolítására szolgáló metódusok hozzá lettek adva**
**A következő metódusok, amelyek lehetővé teszik egy diagram adatpont eltávolítását egy diagram adatpontgyűjtből, hozzá lettek adva:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Az alábbi metódus, amely lehetővé teszi egy diagram kategória eltávolítását a tartalmazó gyűjtből, hozzá lett adva:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


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
### **Az elavult Aspose.Slides.ParagraphFormat metódusok törölve lettek**
A getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() és a hozzájuk tartozó set metódusok törölve lettek. Ezeket már régóta elavultként jelölték meg.
### **Haszontalan és elavult konstruktorok törölve lettek**
A következő konstruktorok lettek törölve:

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