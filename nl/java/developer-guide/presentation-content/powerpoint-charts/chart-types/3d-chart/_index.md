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
description: "Maak 3D-diagrammen in PowerPoint-presentaties met Aspose.Slides voor Java. Pas rotatie, hoogteverhoudingen, diagramdiepte en de tussenruimte tussen series aan met Java-voorbeelden."
---
## **Overzicht**

Aspose.Slides for Java stelt je in staat om de weergave van een 3D-diagram aan te passen via de [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) methode. Dit artikel laat zien hoe je rotatie, hoogteverhoudingen, diepte, assen onder een rechte hoek en de tussenruimte tussen series kunt aanpassen, en vervolgens de presentatie opslaat in PPTX-formaat.

## **Stel de rotatie en diepte van een 3D-diagram in**

Het voorbeeld hieronder maakt een [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) aan en gebruikt [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) om een gestapeld 3D-kolomdiagram toe te voegen aan de eerste dia. Het vervangt de standaard series en categorieën door twee series met elk drie waarden. Werkblad‑index `0` identificeert het eerste gegevens‑werkblad van het diagram; rij `0` bevat de namen van de series en kolom `0` bevat de categorielabels.

De [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) en [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) methoden stellen de rotatie van het diagram in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) stelt de diepte in op 150 % van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) rechte‑hoeken‑assen inschakelt in plaats van perspectief. De resulterende presentatie bevat het gevulde diagram met deze 3D‑weergave‑instellingen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pas de hoogteverhoudingen van een 3D-diagram aan**

Gebruik [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) om de hoogte van een 3D-diagram in te stellen als percentage van de breedte. Dit verandert de verhoudingen van de 3D‑scene zonder de grootte van het diagramobject op de dia te wijzigen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) diagram met de standaardgegevens: drie series en vier categorieën. Het slaat drie presentaties op met hoogteverhoudingen van 50 %, 100 % en 200 %. De positie, breedte en hoogte van het diagram blijven vast. De gegevens, rotatie, diepte, serietussenruimte en opmaak zijn identiek in alle drie de bestanden; alleen het hoogteppercentage wijzigt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

De volgende afbeeldingen illustreren dezelfde hoogte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een kleiner percentage levert een plattere scene op, terwijl een groter percentage een hogere scene binnen hetzelfde diagramobject oplevert. PowerPoint kan tevens de as‑tick‑intervallen en labelplaatsing aanpassen om de scene passend te maken.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Deze methoden beheersen verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Hoogte van de 3D‑scene als percentage van de breedte. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Hoogte van het diagramobject op de dia, in punten. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Diepte van de 3D‑scene als percentage van de breedte. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Tussenruimte tussen series langs de diepte‑as, als percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief cylinder‑, kegel‑ en piramidevarianten, evenals 3D‑lijn‑, gebieds‑, taart‑ en oppervlakdiagrammen. De bovenstaande vergelijking gebruikt het geverifieerde type `Column3D`. De instelling verandert niet het uiterlijk van een 2D `ClusteredColumn` diagram of een `BubbleWith3D` diagram; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) klasse. Voor andere diagramopmaakinstellingen, zie [Diagramopmaak](/slides/nl/java/chart-formatting/).

## **Pas de ruimte tussen series aan**

Gebruik [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) om de afstand tussen dataseries langs de diepte‑as van een 3D-diagram te regelen, uitgedrukt als een percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de opening, terwijl grotere waarden de tussenruimte vergroten. Met een vaste diagramdiepte maakt een grotere opening de markers dunner langs de diepte‑as.

Toegang tot de groep krijg je via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). De instelling geldt voor elke serie in die groep, niet alleen voor de serie die gebruikt wordt om er toegang toe te krijgen. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) geeft de diepte‑opening terug en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief hun cylinder‑, kegel‑ en piramidevarianten, evenals 3D‑lijn‑ en gebiedsdiagrammen. Het uiterlijk hangt af van of de series in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijk vergelijk van openingen tussen afzonderlijke series, gebruik `ChartType.Column3D` uit de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) klasse.

| Methode | Effect |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Tussenruimte tussen series langs de diepte‑as, als percentage van de markerbreedte. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Tussenruimte tussen aangrenzende staaf‑ of kolomclusters, als percentage van de staaf‑ of kolombreedte. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Algemene diagramdiepte, als percentage van de diagrambreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaarddiagramgegevens, die drie series en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, opening‑breedte en diagramdiepte; alleen de opening‑diepte wijzigt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

De volgende afbeeldingen illustreren dezelfde opening‑diepte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Openingsdiepte: 0% | Openingsdiepte: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Wijzig het 3D serietype en de staafvorm**

In een gegroepeerd cilinderschijf‑diagram begint de eerste serie met een cilindrische staafvorm. Het voorbeeld drukt de geheel‑getalwaarden af die worden geretourneerd door [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) en [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) vóór en na elke wijziging. De tabel geeft de bijbehorende constante namen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Wijziging van de eerste serie | Serietype | Staafvorm |
| --- | --- | --- |
| Maak het diagram | `ClusteredCylinder` | `Cylinder` |
| Stel het serietype in op `ClusteredCone` | `ClusteredCone` | `Cone` |
| Stel de staafvorm in op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` verandert ook het serietype in `ClusteredColumn3D`. Als je code vertakt op basis van het serietype, roep dan `series.getType()` aan nadat je de vorm hebt gewijzigd. Een vóór de toewijzing gecachte waarde zou nog steeds de `ClusteredCone`‑tak selecteren.

![PowerPoint-vergelijking die de eerste serie toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **Veelgestelde vragen**

**Welke diagramtypen ondersteunen 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die beschikbaar worden gesteld via de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) klasse. Voor een exacte, actuele lijst, raadpleeg de leden van de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) in de API‑referentie van jouw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. Je kunt een diagram exporteren naar een afbeelding met [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) of [render the entire slide](/slides/nl/java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer je een raster‑preview nodig hebt of het diagram wilt insluiten in documenten, dashboards of webpagina’s zonder PowerPoint te vereisen.

**Hoe presteert het maken en renderen van grote 3D-diagrammen?**

De prestaties hangen af van de gegevens‑omvang en de visuele complexiteit. Voor optimale resultaten, houd 3D‑effecten minimaal, vermijd zware texturen op wanden en plot‑gebieden, beperk het aantal gegevenspunten per serie waar mogelijk, en render naar een output met een passende resolutie en afmetingen voor het beoogde scherm of afdruk.