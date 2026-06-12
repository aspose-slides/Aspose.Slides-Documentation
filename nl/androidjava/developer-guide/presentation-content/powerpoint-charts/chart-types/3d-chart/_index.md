---
title: Aangepaste 3D-diagrammen in presentaties op Android
linktitle: 3D-diagram
type: docs
url: /nl/androidjava/3d-chart/
keywords:
- 3D-diagram
- rotatie
- diepte
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u 3D-diagrammen maakt en aanpast in Aspose.Slides voor Android via Java, met ondersteuning voor PPT- en PPTX-bestanden - verbeter vandaag nog uw presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u een 3D‑diagram in Aspose.Slides kunt aanpassen door `Rotation3D`‑instellingen te configureren, zoals `RotationX`, `RotationY`, `DepthPercents` en `RightAngleAxes`. Het leidt u door het maken van een presentatie, het toevoegen van een 3D‑diagram met standaardgegevens, het toepassen van de vereiste 3D‑weergave‑instellingen en het opslaan van de gewijzigde presentatie als een PPTX‑bestand.

## **Stel de eigenschappen RotationX, RotationY en DepthPercents in van een 3D‑diagram**

Aspose.Slides for Android via Java biedt een eenvoudige API voor het instellen van deze eigenschappen. Het onderstaande artikel helpt u bij het instellen van verschillende eigenschappen zoals **X,Y Rotatie, DepthPercents** enz. De voorbeeldcode past het instellen van de eerder genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)-klasse.  
2. Open de eerste dia.  
3. Voeg een diagram toe met standaardgegevens.  
4. Stel Rotation3D‑eigenschappen in.  
5. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```java
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Diagram toevoegen met standaardgegevens
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Instellen van de index van het diagramdatablad
    int defaultWorksheetIndex = 0;
    
    // Het ophalen van het diagramdatablad
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Series toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Categorieën toevoegen
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Rotation3D-eigenschappen instellen
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Neem de tweede diagramserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Seriesgegevens nu vullen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Overlapwaarde instellen
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Presentatie naar schijf schrijven
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke diagramtypen ondersteunen de 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die beschikbaar zijn via de [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/)-klasse. Voor een exacte, actuele lijst, raadpleeg de leden van [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑diagram krijgen voor een rapport of het web?**

Ja. U kunt een diagram exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) of [render de volledige dia](/slides/nl/androidjava/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is nuttig wanneer u een pixel‑perfecte preview nodig heeft of het diagram wilt embedden in documenten, dashboards of webpagina's zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D‑diagrammen?**

De prestaties hangen af van het datavolume en de visuele complexiteit. Voor optimale resultaten houdt u 3D‑effecten minimaal, vermijdt u zware texturen op wanden en plotgebieden, beperkt u het aantal gegevenspunten per serie waar mogelijk, en rendert u naar een uitvoer met een passende grootte (resolutie en afmetingen) die overeenkomt met de beoogde weergave‑ of afdrukspecificaties.