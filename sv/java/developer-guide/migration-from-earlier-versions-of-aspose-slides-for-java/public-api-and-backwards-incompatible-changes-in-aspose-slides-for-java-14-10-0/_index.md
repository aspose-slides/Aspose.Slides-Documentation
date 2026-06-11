---
title: Offentlig API och bakåt inkompatibla förändringar i Aspose.Slides för Java 14.10.0
linktitle: Aspose.Slides för Java 14.10.0
type: docs
weight: 90
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migration
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP-presentationer."
---
{{% alert color="primary" %}} 
Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) som införts med Aspose.Slides för Java 14.10.0 API.
{{% /alert %}} 
## **Offentliga API-ändringar**
### **com.aspose.slides.FieldType.getFooter()-metoden har lagts till**
getFooter() method returns footer field type. It has been added for the implementation of the possibility to create fields of this type and for valid presentation serialization.
### **Elementet com.aspose.slides.ShapeElementFillSource.Own har tagits bort**
Element ShapeElementFillSource.Own has been deleted as duplicated. Use ShapeElementFillSource.Shape instead of ShapeElementFillSource.Own.
### **Metoder för borttagning av diagramdatapunkter och -kategorier har lagts till**
**Följande metoder, som möjliggör borttagning av en diagramdatapunkt från en samling av diagramdatapunkter, har lagts till:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Följande metod, som möjliggör borttagning av en diagramkategori från den innehållande samlingen, har lagts till:**

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ta bort med ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ta bort med ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ta bort med ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Föråldrade Aspose.Slides.ParagraphFormat-metoder har tagits bort**
The methods getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() and corresponding set methods have been removed. They were marked as obsolete long time ago.
### **Onyttiga och föråldrade konstruktörer har tagits bort**
The following constructors have been removed:

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