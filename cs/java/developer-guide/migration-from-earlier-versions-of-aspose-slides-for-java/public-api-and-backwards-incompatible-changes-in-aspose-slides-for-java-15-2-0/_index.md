---
title: Veřejné API a nekompatibilní změny v Aspose.Slides pro Java 15.2.0
linktitle: Aspose.Slides pro Java 15.2.0
type: docs
weight: 110
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a breaking changes v Aspose.Slides pro Java, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) třídy, metody, vlastnosti a podobně, jakékoli nové omezení a další [změny](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) zavedené v Aspose.Slides pro Java 15.2.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

Existují známé problémy s některými obrázkovými odrážkami a objekty WordArt, které budou opraveny v Aspose.Slides pro Java 15.2.0.

{{% /alert %}} 
## **Změny veřejného API**
### **Metody addDataPointForDoughnutSeries byly přidány**
Byly přidány dvě přetížení metody IChartDataPointCollection.addDataPointForDoughnutSeries() pro přidávání datových bodů do řad typu Doughnut.

### **Třída com.aspose.slides.SmartArtShape byla zděděna od třídy com.aspose.slides.GeometryShape**
Třída com.aspose.slides.SmartArtShape byla zděděna od třídy com.aspose.slides.GeometryShape. Tato změna vylepšuje model objektů Aspose.Slides a přidává nové funkce do třídy SmartArtShape.

### **Metody IGradientStopCollection.add(...) a IGradientStopCollection.insert(...) byly změněny**
Podpis IGradientStop add(float position, int presetColor) byl nahrazen podpisem IGradientStop addPresetColor(float position, int presetColor).

Podpis metody IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) byl nahrazen podpisem IGradientStop addSchemeColor(float position, int schemeColor).

Podpis metody IGradientStopCollection void insert(int index, float position, int presetColor) byl nahrazen podpisem void insertPresetColor(int index, float position, int presetColor).

Podpis metody IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) byl nahrazen podpisem void insertSchemeColor(int index, float position, int schemeColor).

### **Metoda java.awt.Color getAutomaticSeriesColor() byla přidána do com.aspose.slides.IChartSeries**
Metoda getAutomaticSeriesColor() vrací automatickou barvu řady na základě indexu řady a stylu grafu. Tato barva je použita jako výchozí, pokud je FillType nastaven na NotDefined.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Metoda pro odebrání datového bodu grafu a kategorie grafu podle jejího indexu byla přidána**
Metoda IChartDataPointCollection.removeAt(int index) byla přidána pro odebrání datového bodu grafu podle jeho indexu.
Metoda IChartCategoryCollection.removeAt(int index) byla přidána pro odebrání kategorie grafu podle jejího indexu.

### **Hodnota PptXPptY byla přidána do výčtu com.aspose.slides.PropertyType**
Hodnota PptXPptY byla přidána do výčtu com.aspose.slides.PropertyType v souvislosti s opravou problému se serializací.