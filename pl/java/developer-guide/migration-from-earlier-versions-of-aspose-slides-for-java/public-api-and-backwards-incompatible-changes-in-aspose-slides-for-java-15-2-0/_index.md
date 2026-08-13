---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 15.2.0
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API i zmiany łamiące w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 
Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) wprowadzone w API Aspose.Slides for Java 15.2.0.
{{% /alert %}} {{% alert color="info" %}} 
Istnieją znane problemy z niektórymi wypunktowaniami graficznymi i obiektami WordArt, które zostaną naprawione w Aspose.Slides for Java 15.2.0.
{{% /alert %}} 
## **Zmiany publicznego API**
### **dodano metody addDataPointForDoughnutSeries**
Dwa przeciążenia metody IChartDataPointCollection.addDataPointForDoughnutSeries() zostały dodane w celu dodawania punktów danych do serii typu Doughnut.
### **klasa com.aspose.slides.SmartArtShape została odziedziczona po klasie com.aspose.slides.GeometryShape**
Klasa com.aspose.slides.SmartArtShape została odziedziczona po klasie com.aspose.slides.GeometryShape. Ta zmiana usprawnia model obiektowy Aspose.Slides i dodaje nowe funkcje do klasy SmartArtShape.
### **zmieniono metody IGradientStopCollection.add(...) i IGradientStopCollection.insert(...)**
Podpis IGradientStop add(float position, int presetColor) został zastąpiony podpisem IGradientStop addPresetColor(float position, int presetColor).

Podpis metody IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) został zastąpiony podpisem IGradientStop addSchemeColor(float position, int schemeColor).

Podpis metody IGradientStopCollection void insert(int index, float position, int presetColor) został zastąpiony podpisem void insertPresetColor(int index, float position, int presetColor).

Podpis metody IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) został zastąpiony podpisem void insertSchemeColor(int index, float position, int schemeColor).
### **dodano metodę java.awt.Color getAutomaticSeriesColor() do com.aspose.slides.IChartSeries**
Metoda getAutomaticSeriesColor() zwraca automatyczny kolor serii na podstawie indeksu serii i stylu wykresu. Ten kolor jest używany domyślnie, jeśli FillType równa się NotDefined.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **dodano metodę usuwania punktu danych wykresu i kategorii wykresu po ich indeksie**
Metoda IChartDataPointCollection.removeAt(int index) została dodana w celu usunięcia punktu danych wykresu po jego indeksie.
Metoda IChartCategoryCollection.removeAt(int index) została dodana w celu usunięcia kategorii wykresu po jej indeksie.
### **do wyliczenia com.aspose.slides.PropertyType dodano wartość PptXPptY**
Wartość PptXPptY została dodana do wyliczenia com.aspose.slides.PropertyType w ramach naprawy problemu serializacji.