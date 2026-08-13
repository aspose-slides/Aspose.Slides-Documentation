---
title: Offentliga API- och bakåtinkompatibla ändringar i Aspose.Slides för Java 14.10.0
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
description: "Gå igenom offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP‑presentationslösningar."
---
{{% alert color="info" %}}

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) som introducerats med Aspose.Slides for Java 14.10.0 API.

{{% /alert %}}
## **Offentliga API-förändringar**
### **metoden com.aspose.slides.FieldType.getFooter() har lagts till**
Metoden getFooter() returnerar footer‑fält‑typen. Den har lagts till för att möjliggöra skapandet av fält av denna typ och för giltig serialisering av presentationer.
### **Elementet com.aspose.slides.ShapeElementFillSource.Own har tagits bort**
Elementet ShapeElementFillSource.Own har tagits bort som duplikat. Använd ShapeElementFillSource.Shape istället för ShapeElementFillSource.Own.
### **Metoder för att ta bort diagramdatapunkter och -kategorier har lagts till**
**Följande metoder, som möjliggör att ta bort en diagramdatapunkt från en diagramdatapunktssamling, har lagts till:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Följande metod, som möjliggör att ta bort en diagramkategori från den innehållande samlingen, har lagts till:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


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
### **Föråldrade Aspose.Slides.ParagraphFormat‑metoder har tagits bort**
Metoderna getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() och motsvarande set‑metoder har tagits bort. De markerades som föråldrade för länge sedan.
### **Onyttiga och föråldrade konstruktorer har tagits bort**
Följande konstruktorer har tagits bort:

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