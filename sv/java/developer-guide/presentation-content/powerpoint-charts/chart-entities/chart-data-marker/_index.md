---
title: Hantera diagramdatamarkörer i presentationer med Java
linktitle: Datamarkör
type: docs
url: /sv/java/chart-data-marker/
keywords:
- diagram
- datapunkt
- markör
- marköralternativ
- markörstorlek
- fyllningstyp
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du anpassar diagramdatamarkörer i Aspose.Slides för Java, vilket ökar presentationens effekt i PPT- och PPTX-format med tydliga Java‑kodexempel."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatamarkörer i Aspose.Slides. Den visar hur man skapar ett diagram, får åtkomst till en serie och dess datapunkter, applicerar bildfyllning på markörer på datapunktsnivå, justerar markörstorlek och sparar den uppdaterade presentationen. Den noterar också att standardmarkörformer finns tillgängliga via `MarkerStyleType`‑uppräkningen och att markörens utseende bevaras när diagram exporteras till rasterformat eller SVG.

## **Ställ in diagrammarköralternativ**
Markörerna kan ställas in på diagramdatapunkter inom specifika serier. För att ställa in diagrammarköralternativ, följ stegen nedan:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) klassen.
- Skapa standarddiagrammet.
- Ställ in bilden.
- Hämta den första diagramserien.
- Lägg till ny datapunkt.
- Skriv presentationen till disk.

I exemplet nedan har vi ställt in diagrammarköralternativen på datapunktsnivå.

```java
// Skapa tom presentation
Presentation pres = new Presentation();
try {
    // Åtkomst till första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Skapa standarddiagrammet
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Hämta standarddiagramdata arbetsbladets index
    int defaultWorksheetIndex = 0;
    
    // Hämta diagramdataarbetsbladet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Ta bort demo-serien
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
    
    // Ändra diagramseriens markör
    series.getMarker().setSize(15);
    
    // Spara presentation med diagram
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Vilka markörformer finns tillgängliga som standard?**

Standardformer finns tillgängliga (cirkel, kvadrat, diamant, triangel osv.); listan definieras av klassen [MarkerStyleType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/markerstyletype/). Om du behöver en icke‑standardform, använd en markör med bildfyllning för att efterlikna anpassade visuella element.

**Bevaras markörer när ett diagram exporteras till en bild eller SVG?**

Ja. När diagram renderas till [rasterformat](/slides/sv/java/convert-powerpoint-to-png/) eller sparas som [former som SVG](/slides/sv/java/render-a-slide-as-an-svg-image/), behåller markörerna sitt utseende och sina inställningar, inklusive storlek, fyllning och kontur.