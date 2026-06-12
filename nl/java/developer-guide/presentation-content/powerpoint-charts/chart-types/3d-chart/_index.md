---
title: Pas 3D-diagrammen aan in presentaties met Java
linktitle: 3D-diagram
type: docs
url: /nl/java/3d-chart/
keywords:
- 3D-diagram
- rotatie
- diepte
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u 3D-diagrammen maakt en aanpast in Aspose.Slides voor Java, met ondersteuning voor PPT- en PPTX-bestanden — verbeter uw presentaties vandaag."
---
## **Overzicht**

Dit artikel legt uit hoe u een 3D-diagram in Aspose.Slides kunt aanpassen door de `Rotation3D`‑instellingen zoals `RotationX`, `RotationY`, `DepthPercents` en `RightAngleAxes` te configureren. Het doorloopt het maken van een presentatie, het toevoegen van een 3D-diagram met standaardgegevens, het toepassen van de vereiste 3D‑weergave‑instellingen en het opslaan van de aangepaste presentatie als een PPTX‑bestand.

## **Stel de eigenschappen RotationX, RotationY en DepthPercents van een 3D-diagram in**

Aspose.Slides for Java biedt een eenvoudige API om deze eigenschappen in te stellen. Het volgende artikel helpt u bij het instellen van verschillende eigenschappen, zoals **X,Y-rotatie, DepthPercents** enz. De voorbeeldcode past de bovengenoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)-klasse.  
2. Open de eerste dia.  
3. Voeg een diagram toe met standaardgegevens.  
4. Stel de Rotation3D‑eigenschappen in.  
5. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```java
Presentation pres = new Presentation();
try {
    // Open de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voeg een diagram toe met standaardgegevens
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Instellen van de index van het gegevensblad van het diagram
    int defaultWorksheetIndex = 0;
    
    // Ophalen van het werkblad met diagramgegevens
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Voeg series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Voeg categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Stel Rotation3D-eigenschappen in
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Neem de tweede diagramserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Vul nu de seriedata in
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Stel Overlap-waarde in
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Schrijf presentatie naar schijf
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke diagramtypen ondersteunen de 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, samen met gerelateerde 3D‑typen die beschikbaar zijn via de [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/)-klasse. Voor een exacte, actuele lijst, raadpleegt u de leden van [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. U kunt een diagram exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-) of [de gehele dia renderen](/slides/nl/java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een pixel‑perfecte preview nodig heeft of het diagram wilt insluiten in documenten, dashboards of webpagina’s zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D-diagrammen?**

De prestaties hangen af van de datavolume en de visuele complexiteit. Voor de beste resultaten houdt u 3D‑effecten minimaal, vermijdt u zware texturen op muren en plotgebieden, beperkt u het aantal datapunten per serie zoveel mogelijk, en rendert u naar een uitgang met een passende grootte (resolutie en afmetingen) die overeenkomt met de beoogde weergave‑ of afdrukbehoeften.