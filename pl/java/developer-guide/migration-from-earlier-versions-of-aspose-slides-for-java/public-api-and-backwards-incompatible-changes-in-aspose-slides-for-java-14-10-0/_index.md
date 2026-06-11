---
title: Publiczne API i zmiany niezgodne wstecz w Aspose.Slides dla Javy 14.10.0
linktitle: Aspose.Slides dla Javy 14.10.0
type: docs
weight: 90
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migracja
- kod dziedziczony
- nowoczesny kod
- podejście dziedziczone
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zapoznaj się z aktualizacjami publicznego API i zmianami niekompatybilnymi w Aspose.Slides dla Javy, aby płynnie migrować rozwiązania prezentacji PowerPoint (PPT, PPTX) i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) klasy, metody, własności itd., wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) wprowadzone w API Aspose.Slides for Java 14.10.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Dodano metodę com.aspose.slides.FieldType.getFooter()**
Metoda getFooter() zwraca typ pola stopki. Została dodana w celu umożliwienia tworzenia pól tego typu oraz prawidłowej serializacji prezentacji.
### **Element com.aspose.slides.ShapeElementFillSource.Own został usunięty**
Element ShapeElementFillSource.Own został usunięty jako zdublowany. Zamiast ShapeElementFillSource.Own użyj ShapeElementFillSource.Shape.
### **Dodano metody usuwania punktów danych wykresu oraz kategorii**
**Dodano następujące metody, które umożliwiają usunięcie punktu danych wykresu z kolekcji punktów danych wykresu:**  

IChartDataPointCollection.remove(IChartDataPoint)  
IChartDataPoint.remove()  

**Dodano następującą metodę, która umożliwia usunięcie kategorii wykresu z zawierającej ją kolekcji:**  

IChartCategory.remove()  

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // usuń za pomocą ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // usuń za pomocą ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // usuń za pomocą ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Usunięto przestarzałe metody Aspose.Slides.ParagraphFormat**
Metody getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() oraz odpowiadające im metody set zostały usunięte. Zostały oznaczone jako przestarzałe już dawno temu.
### **Usunięto nieprzydatne i przestarzałe konstruktory**
Usunięto następujące konstruktory:

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