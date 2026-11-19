---
title: Pas 3D-diagrammen aan in presentaties op Android
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
description: "Maak 3D-diagrammen in PowerPoint-presentaties met Aspose.Slides voor Android via Java. Pas rotatie, hoogteverhoudingen, diagramdiepte en tussenruimte tussen reeksen aan met Java‑voorbeelden."
---
## **Overzicht**

Aspose.Slides for Android via Java stelt u in staat om de weergave van een 3D-diagram aan te passen via de [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) methode. Dit artikel laat zien hoe u rotatie, hoogteratio's, diepte, rechthoekige assen en de tussenruimte tussen reeksen kunt aanpassen, en vervolgens de presentatie opslaat in PPTX-formaat.

## **Stel de rotatie en diepte van een 3D-diagram in**

Het onderstaande voorbeeld maakt een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) aan en gebruikt [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) om een gestapeld 3D-kolomdiagram toe te voegen aan de eerste dia. Het vervangt de standaardreeksen en -categorieën door twee reeksen met elk drie waarden. Werkbladindex `0` identificeert het eerste gegevenswerkblad van het diagram; rij `0` bevat de reeksenamen, en kolom `0` bevat de categorie‑labels.

De methoden [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) en [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) stellen de rotatie van het diagram in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) stelt de diepte in op 150% van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) rechthoekige assen inschakelt in plaats van perspectief. De resulterende presentatie bevat het gevulde diagram met deze 3D‑weergave‑instellingen.

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

Gebruik [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) om de hoogte van een 3D-diagram in te stellen als een percentage van de breedte. Dit verandert de verhoudingen van de 3D‑scene zonder de grootte van het diagramobject op de dia aan te passen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) diagram met de standaardgegevens: drie reeksen en vier categorieën. Het slaat drie presentaties op met hoogteverhoudingen van 50%, 100% en 200%. De positie, breedte en hoogte van het diagram blijven vast. De gegevens, rotatie, diepte, reekstussenruimte en opmaak zijn identiek in alle drie de bestanden; alleen het hoogtepercentage verandert.

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

De volgende afbeeldingen illustreren dezelfde hoogte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een lager percentage geeft een plattere scene, terwijl een hoger percentage een hogere scene binnen hetzelfde diagramobject oplevert. PowerPoint kan ook de interval‑ en labelplaatsing van de assen aanpassen om de scene passend te maken.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D-kolomdiagram met hoogte ingesteld op 50 procent van de breedte](height_percent_50.png) | ![3D-kolomdiagram met hoogte ingesteld op 100 procent van de breedte](height_percent_100.png) | ![3D-kolomdiagram met hoogte ingesteld op 200 procent van de breedte](height_percent_200.png) |

Deze methoden beheren verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Hoogte van de 3D-scene als een percentage van de breedte. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Hoogte van het diagramobject op de dia, in points. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Diepte van de 3D-scene als een percentage van de breedte. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Tussenruimte tussen reeksen langs de diepte‑as, als een percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom- en staafdiagrammen, inclusief cilinder-, kegel- en piramidevarianten, evenals 3D‑lijn-, gebieds-, taart‑ en oppervlakdiagrammen. De bovenstaande vergelijking maakt gebruik van het geverifieerde type `Column3D`. De instelling verandert niet het uiterlijk van een 2D-`ClusteredColumn` diagram of een `BubbleWith3D` diagram; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) klasse. Voor andere diagram‑opmaakinstellingen, zie [Diagramopmaak](/slides/nl/androidjava/chart-formatting/).

## **Pas de tussenruimte tussen reeksen aan**

Gebruik [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) om de afstand tussen gegevensreeksen langs de diepte‑as van een 3D‑diagram te regelen, uitgedrukt als een percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de tussenruimte, terwijl grotere waarden de spatiëring vergroten. Bij een vaste diagramdiepte maakt een grotere tussenruimte de markers dunner langs de diepte‑as.

Benader de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). De instelling geldt voor elke reeks in die groep, niet alleen voor de reeks die werd gebruikt om er toegang toe te krijgen. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) retourneert de diepte‑tussenruimte en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom- en staafdiagrammen, inclusief hun cilinder-, kegel- en piramidevarianten, evenals 3D‑lijn‑ en gebieddiagrammen. Het uiterlijk hangt af van of de reeksen in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijk vergelijk van tussenruimtes tussen afzonderlijke reeksen, gebruik `ChartType.Column3D` uit de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) klasse.

Deze methoden beheren verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Tussenruimte tussen reeksen langs de diepte‑as, als een percentage van de markerbreedte. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Tussenruimte tussen aangrenzende balk‑ of kolomclusters, als een percentage van de balk‑ of kolombreedte. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Algemene diagramdiepte, als een percentage van de diagrambreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaard diagramgegevens, die drie reeksen en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, tussenruimte‑breedte en diagramdiepte; alleen de diepte‑tussenruimte verandert.

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

De volgende afbeeldingen illustreren dezelfde diepte‑tussenruimte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Diepte‑tussenruimte: 0% | Diepte‑tussenruimte: 500% |
| --- | --- |
| ![3D‑kolomdiagram zonder tussenruimte tussen reeksen langs de diepte‑as](gap_depth_0.png) | ![3D‑kolomdiagram met een tussenruimte van 500 procent tussen reeksen langs de diepte‑as](gap_depth_500.png) |

## **Wijzig het 3D‑reeks‑type en de staafvorm**

In een gegroepeerd cilinderdiagram begint de eerste reeks met een cilindrische staafvorm. Het voorbeeld drukt de geheel‑getalwaarden af die worden geretourneerd door [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) en [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) vóór en na elke wijziging. De tabel geeft de bijbehorende constanten‑namen.

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

| Wijziging van de eerste reeks | Reeks‑type | Staaf‑vorm |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` verandert ook het reeks‑type naar `ClusteredColumn3D`. Als uw code vertakt op basis van het reeks‑type, roep dan `series.getType()` aan na het wijzigen van de vorm. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `ClusteredCone`‑vertakking selecteren.

![PowerPoint‑vergelijking die de eerste reeks toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **Veelgestelde vragen**

**Welke diagramtypen ondersteunen de 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, samen met verwante 3D‑typen die toegankelijk zijn via de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) klasse. Voor een exacte en actuele lijst, controleer de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) leden in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑diagram krijgen voor een rapport of voor het web?**

Ja. U kunt een diagram exporteren naar een afbeelding met [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) of [de volledige dia renderen](/slides/nl/androidjava/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een raster‑preview nodig heeft of het diagram wilt insluiten in documenten, dashboards of webpagina’s zonder PowerPoint.

**Hoe presteert het bouwen en renderen van grote 3D‑diagrammen?**

De prestaties hangen af van het volume aan gegevens en de visuele complexiteit. Voor optimale resultaten, houd 3D‑effecten minimaal, vermijd zware texturen op wanden en plot‑gebieden, beperk het aantal datapunten per reeks waar mogelijk, en render naar een passend formaat (resolutie en afmetingen) dat overeenkomt met de beoogde weergave‑ of afdrukbehoefte.