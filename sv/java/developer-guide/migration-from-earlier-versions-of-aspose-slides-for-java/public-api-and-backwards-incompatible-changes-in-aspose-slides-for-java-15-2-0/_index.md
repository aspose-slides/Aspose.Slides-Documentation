---
title: Offentliga API och bakåtinkompatibla ändringar i Aspose.Slides för Java 15.2.0
linktitle: Aspose.Slides för Java 15.2.0
type: docs
weight: 110
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: Granska offentliga API‑uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP‑presentationslösningar.
---
{{% alert color="primary" %}} 

Denna sida listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) klasser, metoder, egenskaper och så vidare, eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) som introduceras med Aspose.Slides för Java 15.2.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

Det finns kända problem med vissa bildpunkter och WordArt‑objekt som kommer att åtgärdas i Aspose.Slides för Java 15.2.0.

{{% /alert %}} 
## **Offentliga API‑ändringar**
### **addDataPointForDoughnutSeries‑metoder har lagts till**
De två överlagringarna av IChartDataPointCollection.addDataPointForDoughnutSeries()‑metoden har lagts till för att lägga till datapunkter i serier av typen Doughnut.
### **klassen com.aspose.slides.SmartArtShape har ärvt från klassen com.aspose.slides.GeometryShape**
com.aspose.slides.SmartArtShape class har ärvt från com.aspose.slides.GeometryShape class. Denna ändring förbättrar Aspose.Slides‑objektmodellen och lägger till nya funktioner i SmartArtShape‑klassen.
### **IGradientStopCollection.add(...) och IGradientStopCollection.insert(...)‑metoder har ändrats**
Signaturen för IGradientStop add(float position, int presetColor) ersätts med signaturen IGradientStop addPresetColor(float position, int presetColor).

Signaturen för IGradientStopCollection‑metoden IGradientStop add(float position, SchemeColor schemeColor) ersätts med signaturen IGradientStop addSchemeColor(float position, int schemeColor).

Signaturen för IGradientStopCollection‑metoden void insert(int index, float position, int presetColor) ersätts med signaturen void insertPresetColor(int index, float position, int presetColor).

Signaturen för IGradientStopCollection‑metoden void insert(int index, float position, SchemeColor schemeColor) ersätts med signaturen void insertSchemeColor(int index, float position, int schemeColor).
### **java.awt.Color getAutomaticSeriesColor()‑metod har lagts till i com.aspose.slides.IChartSeries**
getAutomaticSeriesColor()‑metoden returnerar en automatisk färg för serien baserat på serieindex och diagramstil. Denna färg används som standard om FillType är NotDefined.
 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Metod för att ta bort diagramdatapunkt och diagramkategori efter index har lagts till**
IChartDataPointCollection.removeAt(int index)‑metoden har lagts till för att ta bort en diagramdatapunkt efter dess index.
IChartCategoryCollection.removeAt(int index)‑metoden har lagts till för att ta bort en diagramkategori efter dess index.
### **PptXPptY‑värde har lagts till i uppräkningen com.aspose.slides.PropertyType**
PptXPptY‑värdet har lagts till i com.aspose.slides.PropertyType‑uppräkningen i samband med en fix för ett serialiseringsproblem.