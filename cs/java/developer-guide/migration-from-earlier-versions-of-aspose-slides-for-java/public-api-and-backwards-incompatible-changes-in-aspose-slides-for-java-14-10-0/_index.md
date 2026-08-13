---
title: Veřejné API a nekompatibilní změny v Aspose.Slides for Java 14.10.0
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migrace
- starý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a zásadní změny v Aspose.Slides for Java, abyste hladce migrovali svá řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 
Tato stránka uvádí všechny [added](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) třídy, metody, vlastnosti a podobně, nová omezení a další [changes](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) zavedené s API Aspose.Slides for Java 14.10.0.
{{% /alert %}} 
## **Změny veřejného API**
### **metoda com.aspose.slides.FieldType.getFooter() byla přidána**
Metoda getFooter() vrací typ pole zápatí. Byla přidána pro umožnění vytváření polí tohoto typu a pro platnou serializaci prezentace.
### **Prvek com.aspose.slides.ShapeElementFillSource.Own byl odstraněn**
Prvek ShapeElementFillSource.Own byl odstraněn jako duplicitní. Použijte ShapeElementFillSource.Shape místo ShapeElementFillSource.Own.
### **Metody pro odstraňování datových bodů grafu a kategorií byly přidány**
**Následující metody, které umožňují odebrat datový bod grafu ze sbírky datových bodů grafu, byly přidány:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Následující metoda, která umožňuje odebrat kategorii grafu ze sbírky, byla přidána:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


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
Metody getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() a odpovídající set metody byly odstraněny. Byly označeny jako zastaralé již před dlouhou dobou.
### **Neužitečné a zastaralé konstruktory byly odstraněny**
Následující konstruktory byly odstraněny:

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