---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides for Java 15.2.0
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- migracja
- kod starszy
- kod nowoczesny
- podejście starsze
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i zmian łamiących kompatybilność w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) klasy, metody, właściwości i tak dalej, wszelkie nowe ograniczenia oraz inne [zmiany](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) wprowadzone w interfejsie API Aspose.Slides for Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

Istnieją znane problemy z niektórymi wypunktowaniami obrazkowymi i obiektami WordArt, które zostaną naprawione w Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Public API Changes**
### **addDataPointForDoughnutSeries methods have been added**
Zostały dodane dwa przeciążenia metody IChartDataPointCollection.addDataPointForDoughnutSeries() służące do dodawania punktów danych do serii typu Doughnut.
### **com.aspose.slides.SmartArtShape class has been inherited from com.aspose.slides.GeometryShape class**
Klasa com.aspose.slides.SmartArtShape została dziedziczona po klasie com.aspose.slides.GeometryShape. Ta zmiana usprawnia model obiektowy Aspose.Slides i dodaje nowe funkcje do klasy SmartArtShape.
### **IGradientStopCollection.add(...) and IGradientStopCollection.insert(...) methods have been changed**
Podpis IGradientStop add(float position, int presetColor) został zastąpiony podpisem IGradientStop addPresetColor(float position, int presetColor).  
Podpis metody IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) został zastąpiony podpisem IGradientStop addSchemeColor(float position, int schemeColor).  
Podpis metody IGradientStopCollection void insert(int index, float position, int presetColor) został zastąpiony podpisem void insertPresetColor(int index, float position, int presetColor).  
Podpis metody IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) został zastąpiony podpisem void insertSchemeColor(int index, float position, int schemeColor).  
### **java.awt.Color getAutomaticSeriesColor() method has been added to com.aspose.slides.IChartSeries**
Metoda getAutomaticSeriesColor() zwraca automatyczny kolor serii oparty na indeksie serii i stylu wykresu. Ten kolor jest używany domyślnie, jeśli FillType jest równe NotDefined.
 
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Method for removing chart data point and chart category by its index has been added**
Metoda IChartDataPointCollection.removeAt(int index) została dodana w celu usunięcia punktu danych wykresu według jego indeksu.  
Metoda IChartCategoryCollection.removeAt(int index) została dodana w celu usunięcia kategorii wykresu według jej indeksu.
### **PptXPptY value has been added to com.aspose.slides.PropertyType enumeration**
Wartość PptXPptY została dodana do wyliczenia com.aspose.slides.PropertyType w ramach naprawy problemu serializacji.