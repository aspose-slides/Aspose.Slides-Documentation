---
title: Beheer grafiekdatamarkers in presentaties met JavaScript
linktitle: Datamarker
type: docs
url: /nl/nodejs-java/chart-data-marker/
keywords:
- grafiek
- datapunt
- markering
- markeropties
- markergrootte
- vullingstype
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u grafiekdatamarkers kunt aanpassen in Aspose.Slides voor Node.js, waardoor de impact van presentaties in PPT- en PPTX-formaten wordt vergroot met heldere codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiekdatamarkers werkt in Aspose.Slides. Het toont hoe u een grafiek maakt, een serie en de datapunten benadert, afbeeldingvullingen toepast op markers op het datapunteniveau, de markergrootte aanpast en de bijgewerkte presentatie opslaat. Het vermeldt ook dat standaardmarker‑vormen beschikbaar zijn via de `MarkerStyleType`‑enumeratie en dat de weergave van markers behouden blijft bij het exporteren van grafieken naar rasterformaten of SVG.

## **Markeropties voor grafiek instellen**

De markers kunnen worden ingesteld op grafiekdatapunten binnen bepaalde series. Volg de onderstaande stappen om de markeropties voor de grafiek in te stellen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
- Maak de standaardgrafiek.
- Stel de afbeelding in.
- Neem de eerste grafiekserie.
- Voeg een nieuw datapunt toe.
- Schrijf de presentatie naar de schijf.

In het onderstaande voorbeeld hebben we de markeropties voor de grafiek ingesteld op datapunteniveau.

```javascript
// Lege presentatie maken
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Standaardgrafiek maken
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Het standaardwerkblad‑index van de grafiekdata ophalen
    var defaultWorksheetIndex = 0;
    // Het werkblad van de grafiekdata ophalen
    var fact = chart.getChartData().getChartDataWorkbook();
    // Demo‑serie verwijderen
    chart.getChartData().getSeries().clear();
    // Nieuwe serie toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Afbeelding 1 laden
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Afbeelding 2 laden
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Eerste grafiekserie nemen
    var series = chart.getChartData().getSeries().get_Item(0);
    // Nieuw punt (1:3) toevoegen daar.
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
    // De marker van de grafiekserie wijzigen
    series.getMarker().setSize(15);
    // Presentatie met grafiek opslaan
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Welke marker‑vormen zijn er standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, ruit, driehoek, enz.); de lijst wordt gedefinieerd door de [MarkerStyleType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/markerstyletype/)‑enumeratie. Als u een niet‑standaard vorm nodig heeft, gebruik dan een marker met een afbeeldingvulling om aangepaste visuals te emuleren.

**Worden markers behouden bij het exporteren van een grafiek naar een afbeelding of SVG?**

Ja. Bij het renderen van grafieken naar [rasterformaten](/slides/nl/nodejs-java/convert-powerpoint-to-png/) of het opslaan van [vormen als SVG](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/), behouden markers hun uiterlijk en instellingen, inclusief grootte, vulling en omtrek.