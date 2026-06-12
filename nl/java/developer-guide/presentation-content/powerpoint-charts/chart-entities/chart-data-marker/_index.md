---
title: Beheer grafiekdatamarkers in presentaties met Java
linktitle: Datamarker
type: docs
url: /nl/java/chart-data-marker/
keywords:
- grafiek
- datapunt
- marker
- markeropties
- marker grootte
- vullingstype
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u grafiekdatamarkers in Aspose.Slides voor Java kunt aanpassen, waardoor de impact van presentaties in PPT- en PPTX-formaten wordt verhoogd met duidelijke Java‑codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiekdatamarkers werkt in Aspose.Slides. Het toont hoe u een grafiek maakt, een reeks en de gegevenspunten ervan benadert, afbeeldingvullingen toepast op markers op het niveau van gegevenspunten, de markergrootte aanpast en de bijgewerkte presentatie opslaat. Het vermeldt ook dat standaard marker‑vormen beschikbaar zijn via de `MarkerStyleType`‑enumeratie en dat de weergave van markers behouden blijft bij het exporteren van grafieken naar rasterformaten of SVG.

## **Instellen van grafiekmarkeropties**
De markers kunnen worden ingesteld op grafiekdatapunten binnen specifieke reeksen. Om grafiekmarkeropties in te stellen, volgt u de onderstaande stappen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.
- Maak de standaardgrafiek.
- Stel de afbeelding in.
- Haal de eerste grafiekreeks.
- Voeg een nieuw gegevenspunt toe.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grafiekmarkeropties ingesteld op het niveau van gegevenspunten.

```java
// Lege presentatie aanmaken
Presentation pres = new Presentation();
try {
    // Eerste dia benaderen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Standaardgrafiek maken
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Standaard werkbladindex van grafiekgegevens ophalen
    int defaultWorksheetIndex = 0;
    
    // Werkblad met grafiekgegevens ophalen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Demo-reeks verwijderen
    chart.getChartData().getSeries().clear();
    
    // Nieuwe reeks toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Afbeelding 1 laden
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Afbeelding 2 laden
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Eerste grafiekreeks nemen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Nieuw punt (1:3) hier toevoegen.
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
    
    // De marker van de grafiekreeks wijzigen
    series.getMarker().setSize(15);
    
    // Presentatie met grafiek opslaan
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke marker‑vormen zijn standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, ruit, driehoek, enz.); de lijst wordt gedefinieerd door de [MarkerStyleType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/markerstyletype/)‑klasse. Als u een niet‑standaardvorm nodig heeft, gebruik dan een marker met een afbeeldingvulling om aangepaste visuals te simuleren.

**Worden markers behouden bij het exporteren van een grafiek naar een afbeelding of SVG?**

Ja. Bij het renderen van grafieken naar [rasterformaten](/slides/nl/java/convert-powerpoint-to-png/) of het opslaan van [vormen als SVG](/slides/nl/java/render-a-slide-as-an-svg-image/), behouden markers hun weergave en instellingen, inclusief grootte, vulling en omtrek.