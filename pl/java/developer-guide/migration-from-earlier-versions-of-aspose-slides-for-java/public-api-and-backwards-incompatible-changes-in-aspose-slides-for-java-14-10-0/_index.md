---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides dla Java 14.10.0
linktitle: Aspose.Slides dla Java 14.10.0
type: docs
weight: 90
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- migracja
- starszy kod
- nowoczesny kod
- starsze podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i zmian łamiących w Aspose.Slides dla Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) wprowadzone w API Aspose.Slides for Java 14.10.0.

{{% /alert %}} 
## **Zmiany publicznego API**
### **com.aspose.slides.FieldType.getFooter() metoda została dodana**
Metoda getFooter() zwraca typ pola stopki. Została dodana w celu umożliwienia tworzenia pól tego typu oraz prawidłowej serializacji prezentacji.
### **Element com.aspose.slides.ShapeElementFillSource.Own został usunięty**
Element ShapeElementFillSource.Own został usunięty jako duplikat. Użyj ShapeElementFillSource.Shape zamiast ShapeElementFillSource.Own.
### **Dodano metody usuwania punktów danych wykresu i kategorii**
**Dodano następujące metody, które pozwalają usunąć punkt danych wykresu z kolekcji punktów danych wykresu:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Dodano następującą metodę, która pozwala usunąć kategorię wykresu z zawierającej kolekcji:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


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
Usunięto metody getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() oraz odpowiadające im metody set. Zostały oznaczone jako przestarzałe już dawno temu.
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