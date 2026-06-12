---
title: Pas 3D-diagrammen in presentaties aan met JavaScript
linktitle: 3D-diagram
type: docs
url: /nl/nodejs-java/3d-chart/
keywords:
- 3D-diagram
- rotatie
- diepte
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe je 3D-diagrammen maakt en aanpast in Aspose.Slides voor Node.js via Java, met ondersteuning voor PPT- en PPTX-bestanden, versterk vandaag nog je presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je een 3D‑diagram in Aspose.Slides kunt aanpassen door de `Rotation3D`‑instellingen zoals `RotationX`, `RotationY`, `DepthPercents` en `RightAngleAxes` te configureren. Het loopt door het maken van een presentatie, het toevoegen van een 3D‑diagram met standaardgegevens, het toepassen van de benodigde 3D‑view‑instellingen en het opslaan van de gewijzigde presentatie als een PPTX‑bestand.

## **Stel de eigenschappen RotationX, RotationY en DepthPercents van een 3D‑diagram in**

Aspose.Slides for Node.js via Java biedt een eenvoudige API om deze eigenschappen in te stellen. Het volgende artikel helpt je bij het instellen van verschillende eigenschappen zoals **X,Y Rotatie, DepthPercents** enz. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Open de eerste dia.
3. Voeg een diagram toe met standaardgegevens.
4. Stel de Rotation3D‑eigenschappen in.
5. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Open de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Voeg diagram toe met standaardgegevens
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Instellen van de index van het diagramdatablad
    var defaultWorksheetIndex = 0;
    // Het ophalen van het diagramdatablad
    var fact = chart.getChartData().getChartDataWorkbook();
    // Voeg series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Voeg categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Stel Rotation3D-eigenschappen in
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Neem de tweede diagramserie
    var series = chart.getChartData().getSeries().get_Item(1);
    // Vul nu de seriedata in
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Stel OverLap-waarde in
    series.getParentSeriesGroup().setOverlap(100);
    // Schrijf presentatie naar schijf
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**Welke diagramtypen ondersteunen de 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, samen met gerelateerde 3D‑types die worden blootgesteld via de [ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/) enumeratie. Voor een exacte, actuele lijst, controleer de leden van [ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/) in de API‑referentie van jouw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑diagram krijgen voor een rapport of het web?**

Ja. Je kunt een diagram exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage) of [render de hele dia](/slides/nl/nodejs-java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer je een pixel‑perfecte weergave nodig hebt of het diagram wilt embedden in documenten, dashboards of webpagina's zonder dat PowerPoint vereist is.

**Hoe presterend is het bouwen en renderen van grote 3D‑diagrammen?**

De prestaties hangen af van de hoeveelheid data en de visuele complexiteit. Voor de beste resultaten houd je 3D‑effecten minimaal, vermijd zware texturen op de wanden en het plotgebied, beperk het aantal gegevenspunten per serie waar mogelijk, en render naar een output van geschikte grootte (resolutie en afmetingen) die aansluit bij het beoogde scherm of de afdrukbehoefte.