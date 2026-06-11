---
title: Hantera diagramdatamärken i presentationer med JavaScript
linktitle: Datamärke
type: docs
url: /sv/nodejs-java/chart-data-marker/
keywords:
- diagram
- datapunkt
- märke
- markeringsalternativ
- märkestorlek
- fyllnadstyp
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du anpassar diagramdatamärken i Aspose.Slides för Node.js, vilket ökar presentationens effekt i PPT- och PPTX-format med tydliga kodexempel."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatamärken i Aspose.Slides. Den visar hur man skapar ett diagram, får åtkomst till en serie och dess datapunkter, tillämpar bildfyllningar på märken på datapunktsnivå, justerar märkesstorlek och sparar den uppdaterade presentationen. Den nämner också att standardmärkesformer finns tillgängliga via `MarkerStyleType`‑enumerationen och att märkens utseende bevaras när diagram exporteras till rasterformat eller SVG.

## **Ange diagrammarkeringsalternativ**

Märkena kan ställas in på diagramdatapunkter inom specifika serier. För att ställa in diagrammarkeringsalternativ, följ stegen nedan:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
- Skapa standarddiagrammet.
- Ställ in bilden.
- Hämta den första diagramserien.
- Lägg till en ny datapunkt.
- Skriv presentationen till disk.

I exemplet nedan har vi ställt in diagrammarkeringsalternativen på datapunktsnivå.

```javascript
// Skapar tom presentation
var pres = new aspose.slides.Presentation();
try {
    // Åtkomst till första bilden
    var slide = pres.getSlides().get_Item(0);
    // Skapar standarddiagrammet
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Hämtar standarddiagrammets dataarbetsblad-index
    var defaultWorksheetIndex = 0;
    // Hämtar diagrammets dataarbetsblad
    var fact = chart.getChartData().getChartDataWorkbook();
    // Raderar demo-serier
    chart.getChartData().getSeries().clear();
    // Lägger till ny serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Ladda bild 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Ladda bild 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Hämtar första diagramserien
    var series = chart.getChartData().getSeries().get_Item(0);
    // Lägg till ny punkt (1:3) där.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // Ändrar diagramseriens märke
    series.getMarker().setSize(15);
    // Sparar presentation med diagram
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Vilka markeringsformer är tillgängliga direkt?**

Standardformer är tillgängliga (cirkel, fyrkant, diamant, triangel osv.); listan definieras av enumerationen [MarkerStyleType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/markerstyletype/). Om du behöver en icke‑standardform, använd ett märke med bildfyllning för att efterlikna anpassade visuella element.

**Bevaras märken när ett diagram exporteras till en bild eller SVG?**

Ja. När diagram renderas till [rasterformat](/slides/sv/nodejs-java/convert-powerpoint-to-png/) eller när [former sparas som SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/), behåller märken sitt utseende och sina inställningar, inklusive storlek, fyllning och kontur.