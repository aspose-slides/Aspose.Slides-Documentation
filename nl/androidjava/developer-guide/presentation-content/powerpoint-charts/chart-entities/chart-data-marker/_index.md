---
title: Beheer diagramdatamarkeringen in presentaties op Android
linktitle: Datamarkering
type: docs
url: /nl/androidjava/chart-data-marker/
keywords:
- diagram
- datapunt
- markering
- markeeropties
- markergrootte
- vultype
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas diagramdatamarkeringen aan in Aspose.Slides voor Android, waardoor de impact van presentaties in PPT- en PPTX-formaten wordt versterkt met duidelijke Java-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe je met diagramdatamarkeringen in Aspose.Slides werkt. Het laat zien hoe je een diagram maakt, een serie en de bijbehorende datapunten benadert, afbeeldingsvullingen toepast op markeringen op datumpuntniveau, de grootte van de markering aanpast en de bijgewerkte presentatie opslaat. Het vermeldt ook dat standaard markervormen beschikbaar zijn via de `MarkerStyleType`‑enumeratie en dat het uiterlijk van de markering behouden blijft bij het exporteren van diagrammen naar rasterformaten of SVG.

## **Instellen van diagrammarkeeropties**

De markeringen kunnen worden ingesteld op diagramdatapunten binnen een bepaalde serie. Om diagrammarkeeropties in te stellen, volg je de onderstaande stappen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
- Maak het standaard diagram.
- Stel de afbeelding in.
- Neem de eerste diagramserie.
- Voeg een nieuw datapunt toe.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de diagrammarkeeropties op het niveau van datapunten ingesteld.

```java
// Lege presentatie aanmaken
Presentation pres = new Presentation();
try {
    // Toegang tot eerste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Standaarddiagram aanmaken
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Het indexnummer van het standaarddiagramdatablad ophalen
    int defaultWorksheetIndex = 0;
    
    // Het diagramdatablad ophalen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Demo-reeks verwijderen
    chart.getChartData().getSeries().clear();
    
    // Nieuwe reeks toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Afbeelding 1 laden
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Afbeelding 2 laden
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Eerste diagramreeks nemen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Nieuw punt (1:3) daar toevoegen.
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
    
    // Diagramreeksmarkering wijzigen
    series.getMarker().setSize(15);
    
    // Presentatie met diagram opslaan
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veelgestelde vragen**

**Welke marker‑vormen zijn standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, ruit, driehoek, enz.); de lijst wordt gedefinieerd door de [MarkerStyleType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/markerstyletype/) klasse. Als je een niet‑standaardvorm nodig hebt, gebruik dan een markering met een afbeeldingsvulling om aangepaste visuals te emuleren.

**Worden markeringen behouden bij het exporteren van een diagram naar een afbeelding of SVG?**

Ja. Bij het renderen van diagrammen naar [rasterformaten](/slides/nl/androidjava/convert-powerpoint-to-png/) of het opslaan van [vormen als SVG](/slides/nl/androidjava/render-a-slide-as-an-svg-image/), behouden markeringen hun uiterlijk en instellingen, waaronder grootte, vulling en omtrek.