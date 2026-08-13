---
title: Offentligt API och bakåtinkompatibla ändringar i Aspose.Slides for Java 15.2.0
linktitle: Aspose.Slides for Java 15.2.0
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
description: "Granska uppdateringar av offentligt API och brytande förändringar i Aspose.Slides for Java för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) klasser, metoder, egenskaper med mera, eventuella nya begränsningar och andra [ändringar](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) som införts med Aspose.Slides for Java 15.2.0 API.

{{% /alert %}} {{% alert color="info" %}} 

Det finns kända problem med vissa bildpunkter och WordArt‑objekt som kommer att åtgärdas i Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Ändringar i offentligt API**
### **addDataPointForDoughnutSeries‑metoder har lagts till**
De två överlagringarna av IChartDataPointCollection.addDataPointForDoughnutSeries()-metoden har lagts till för att lägga till datapunkter i serier av typen Doughnut.
### **com.aspose.slides.SmartArtShape‑klassen har ärvts från com.aspose.slides.GeometryShape‑klassen**
Klassen com.aspose.slides.SmartArtShape har ärvts från klassen com.aspose.slides.GeometryShape. Denna förändring förbättrar Aspose.Slides objektmodell och lägger till nya funktioner i SmartArtShape‑klassen.
### **IGradientStopCollection.add(...) och IGradientStopCollection.insert(...)‑metoder har ändrats**
Signaturen för IGradientStop add(float position, int presetColor) har ersatts med signaturen IGradientStop addPresetColor(float position, int presetColor).

Signaturen för IGradientStopCollection‑metoden IGradientStop add(float position, SchemeColor schemeColor) har ersatts med signaturen IGradientStop addSchemeColor(float position, int schemeColor).

Signaturen för IGradientStopCollection‑metoden void insert(int index, float position, int presetColor) har ersatts med signaturen void insertPresetColor(int index, float position, int presetColor).

Signaturen för IGradientStopCollection‑metoden void insert(int index, float position, SchemeColor schemeColor) har ersatts med signaturen void insertSchemeColor(int index, float position, int schemeColor).
### **java.awt.Color getAutomaticSeriesColor()‑metoden har lagts till i com.aspose.slides.IChartSeries**
Metoden getAutomaticSeriesColor() returnerar en automatisk färg för serien baserat på serie‑index och diagramstil. Denna färg används som standard om FillType är lika med NotDefined.
 

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Metod för att ta bort diagramdatapunkt och diagramkategori efter index har lagts till**
Metoden IChartDataPointCollection.removeAt(int index) har lagts till för att ta bort diagramdatapunkt efter dess index.
Metoden IChartCategoryCollection.removeAt(int index) har lagts till för att ta bort diagramkategori efter dess index.
### **Värdet PptXPptY har lagts till i com.aspose.slides.PropertyType‑enumerationen**
Värdet PptXPptY har lagts till i com.aspose.slides.PropertyType‑enumerationen i samband med en korrigering av ett serialiseringsproblem.