---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro Java 14.10.0
linktitle: Aspose.Slides pro Java 14.10.0
type: docs
weight: 90
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a nekompatibilní změny v Aspose.Slides pro Java, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka vypisuje všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) třídy, metody, vlastnosti apod., případná nová omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) zavedené v API Aspose.Slides pro Java 14.10.0.
{{% /alert %}} 
## **Změny veřejného API**
### **byla přidána metoda com.aspose.slides.FieldType.getFooter()**
Metoda getFooter() vrací typ pole zápatí. Byla přidána pro možnost vytvářet pole tohoto typu a pro platnou serializaci prezentace.
### **Prvek com.aspose.slides.ShapeElementFillSource.Own byl smazán**
Prvek ShapeElementFillSource.Own byl smazán jako duplicitní. Použijte místo něj ShapeElementFillSource.Shape.
### **Byly přidány metody pro odstraňování datových bodů a kategorií v grafech**
**Následující metody, které umožňují odstranit datový bod grafu ze sbírky datových bodů grafu, byly přidány:**

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()  

**Následující metoda, která umožňuje odstranit kategorii grafu ze zahrnující sbírky, byla přidána:**

IChartCategory.remove()  

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // odstranit pomocí ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // odstranit pomocí ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // odstranit pomocí ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Zastaralé metody Aspose.Slides.ParagraphFormat byly odstraněny**
Metody getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() a odpovídající metody set byly odstraněny. Byly označeny jako zastaralé už před dlouhou dobou.
### **Neužitečné a zastaralé konstruktory byly odstraněny**
Byly odstraněny následující konstruktory:

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