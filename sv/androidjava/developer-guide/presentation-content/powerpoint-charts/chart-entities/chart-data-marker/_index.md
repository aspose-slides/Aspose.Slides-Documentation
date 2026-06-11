---
title: Hantera diagramdatamarkörer i presentationer på Android
linktitle: Datamarkör
type: docs
url: /sv/androidjava/chart-data-marker/
keywords:
- diagram
- datapunkt
- markör
- marköralternativ
- markörstorlek
- fyllningstyp
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Anpassa diagramdatamarkörer i Aspose.Slides för Android, vilket ökar presentationens genomslag i PPT- och PPTX-format med tydliga Java-kodexempel."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatamarkörer i Aspose.Slides. Den visar hur man skapar ett diagram, får åtkomst till en serie och dess datapunkter, applicerar bildfyllning på markörer på datapunktsnivå, justerar markörens storlek och sparar den uppdaterade presentationen. Den nämner också att standardmarkörformer finns tillgängliga via `MarkerStyleType`‑enumerationen och att markörens utseende bevaras när diagram exporteras till rasterformat eller SVG.

## **Ställ in diagrammarköralternativ**
Markörerna kan ställas in på diagramdatapunkter inom specifika serier. För att ställa in diagrammarköralternativ, följ stegen nedan:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
- Skapa standarddiagrammet.
- Ange bilden.
- Hämta den första diagramserien.
- Lägg till en ny datapunkt.
- Skriv presentationen till disk.

I exemplet nedan har vi ställt in diagrammarköralternativen på datapunktsnivå.

```java
// Skapar tom presentation
Presentation pres = new Presentation();
try {
    // Åtkomst till första sliden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Skapar standarddiagrammet
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Hämtar standarddiagramdata arbetsbladets index
    int defaultWorksheetIndex = 0;
    
    // Hämtar diagramdata arbetsbladet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Ta bort demoserien
    chart.getChartData().getSeries().clear();
    
    // Lägg till ny serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Ladda bild 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Ladda bild 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Hämta första diagramserien
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Lägg till ny punkt (1:3) där.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Ändrar diagramseriens markör
    series.getMarker().setSize(15);
    
    // Spara presentation med diagram
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Vilka markörformer finns tillgängliga som standard?**

Standardformer är tillgängliga (cirkel, fyrkant, diamant, triangel osv.); listan definieras av klassen [MarkerStyleType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/markerstyletype/). Om du behöver en icke‑standardform, använd en markör med bildfyllning för att efterlikna anpassade visualiseringar.

**Behålls markörerna vid export av ett diagram till en bild eller SVG?**

Ja. När diagram renderas till [rasterformat](/slides/sv/androidjava/convert-powerpoint-to-png/) eller när [former sparas som SVG](/slides/sv/androidjava/render-a-slide-as-an-svg-image/), behåller markörerna sitt utseende och sina inställningar, inklusive storlek, fyllning och kontur.