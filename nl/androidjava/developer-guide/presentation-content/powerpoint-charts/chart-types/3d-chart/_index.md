---
title: 3D-diagrammen aanpassen in presentaties op Android
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
description: "Maak 3D-diagrammen in PowerPoint-presentaties met Aspose.Slides for Android via Java. Pas rotatie, hoogteratio's, diagramdiepte en de tussenruimte tussen reeksen aan met Java-voorbeelden."
---
## **Overzicht**

Aspose.Slides for Android via Java stelt u in staat de weergave van een 3D-diagram aan te passen via de [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) methode. Dit artikel laat zien hoe u rotatie, hoogteratio's, diepte, rechthoekige assen en de tussenruimte tussen reeksen kunt aanpassen, en vervolgens de presentatie opslaat in PPTX-formaat.

## **Stel de rotatie en diepte van een 3D-diagram in**

Het voorbeeld hieronder maakt een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) en gebruikt [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) om een gestapeld 3D-kolomdiagram toe te voegen aan de eerste dia. Het vervangt de standaardreeksen en -categorieën door twee reeksen met elk drie waarden. Werkblad‑index `0` identificeert het eerste gegevenswerkblad van het diagram; rij `0` bevat de reeksnamen en kolom `0` bevat de categorielabels.

De [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) en [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) methoden stellen de rotatie van het diagram in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) stelt de diepte in op 150 % van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) rechthoekige assen inschakelt in plaats van perspectief. De resulterende presentatie bevat het gevulde diagram met deze 3D‑weergave‑instellingen.

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

## **Pas een afbeeldingvulling toe op een 3D-diagramoppervlak**

Een 3D-diagram heeft drie oppervlakken die u onafhankelijk kunt vullen: de [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) en [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--). Stel het [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) van het oppervlak in op `Picture` en wijs een afbeelding toe. Stel zowel de [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) als het [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) van het oppervlak in op `Stretch` zodat één kopie van de afbeelding over het oppervlak wordt uitgerekt.

Sla [arrow.png](arrow.png) op in de werkmap. Het voorbeeld draait het diagram en verhoogt de maximale waarde op de verticale as zodat de vloer zichtbaar is tussen de kolommen. Vervolgens wordt de dia twee keer gekloond en wordt de pijl op een ander oppervlak op elke dia toegepast. Alle drie de diagrammen behouden dezelfde gegevens, kijkhoek en achtergrond.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint toont de drie dia's als volgt.

| Zijwand | Achterwand | Vloer |
| --- | --- | --- |
| ![Pijl wijst naar binnen het diagram langs de zijwand](side-wall.png) | ![Pijl wijst naar rechts over de achterwand](back-wall.png) | ![Pijl wijst naar rechts over de vloer tussen de kolommen](floor.png) |

## **Pas de hoogteverhoudingen van een 3D-diagram aan**

Gebruik [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) om de hoogte van een 3D-diagram in te stellen als een percentage van de breedte. Hiermee worden de verhoudingen van de 3D‑scène gewijzigd zonder het diagramobject op de dia te herschalen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) diagram met de standaardgegevens: drie reeksen en vier categorieën. Het slaat drie presentaties op met hoogteratio's van 50 %, 100 % en 200 %. De positie, breedte en hoogte van het diagram blijven vast. De gegevens, rotatie, diepte, reekstussenafstand en opmaak zijn in alle drie de bestanden identiek; alleen het hoogte‑percentage verandert.

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

De volgende afbeeldingen illustreren dezelfde hoogte‑instelling in het overeenkomstige .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een kleiner percentage levert een plattere scène op, terwijl een groter percentage een hogere scène binnen hetzelfde diagramobject oplevert. PowerPoint kan bovendien de as‑tic‑intervallen en label‑plaatsing aanpassen om de scène te laten passen.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D-kolomdiagram met hoogte ingesteld op 50 procent van de breedte](height_percent_50.png) | ![3D-kolomdiagram met hoogte ingesteld op 100 procent van de breedte](height_percent_100.png) | ![3D-kolomdiagram met hoogte ingesteld op 200 procent van de breedte](height_percent_200.png) |

Deze methoden regelen verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Hoogte van de 3D‑scène als percentage van de breedte. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Hoogte van het diagramobject op de dia, in points. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Diepte van de 3D‑scène als percentage van de breedte. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Tussenruimte tussen reeksen langs de diepte‑as, als percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief de cilinder‑, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑, gebieds‑, taart‑ en oppervlakdiagrammen. De vergelijking hierboven maakt gebruik van het geverifieerde `Column3D`‑type. De instelling verandert de weergave van een 2D‑`ClusteredColumn`‑diagram of een `BubbleWith3D`‑diagram niet; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/)‑klasse. Zie voor andere diagram‑opmaakinstellingen [Chart Formatting](/slides/nl/androidjava/chart-formatting/).

## **Pas de tussenruimte tussen reeksen aan**

Gebruik [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) om de afstand tussen gegevensreeksen langs de diepte‑as van een 3D‑diagram te regelen, uitgedrukt als percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de tussenruimte, terwijl hogere waarden de afstand vergroten. Bij een vaste diagramdiepte maakt een grotere tussenruimte de markers dunner langs de diepte‑as.

Benader de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). De instelling geldt voor elke reeks in die groep, niet alleen voor de reeks waarmee u toegang kreeg. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) retourneert de diepte‑tussenruimte en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief hun cilinder‑, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑ en gebieddiagrammen. Het uiterlijk hangt af van of de reeksen in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van tussenruimtes tussen afzonderlijke reeksen, gebruik `ChartType.Column3D` uit de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/)‑klasse.

Deze methoden regelen verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Tussenruimte tussen reeksen langs de diepte‑as, als percentage van de markerbreedte. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Tussenruimte tussen aangrenzende balk‑ of kolomgroepen, als percentage van de balk‑ of kolombreedte. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Totale diepte van het diagram, als percentage van de diagrambreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaarddiagramgegevens, die drie reeksen en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, tussenruimte‑breedte en diagramdiepte; alleen de tussenruimte‑diepte verandert.

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

De volgende afbeeldingen illustreren dezelfde tussenruimte‑diepte‑instellingen in het overeenkomstige .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Tussenruimte: 0% | Tussenruimte: 500% |
| --- | --- |
| ![3D-kolomdiagram zonder tussenruimte tussen reeksen langs de diepte-as](gap_depth_0.png) | ![3D-kolomdiagram met een tussenruimte van 500 procent tussen reeksen langs de diepte-as](gap_depth_500.png) |

## **Wijzig het 3D-reeks type en de balkvorm**

In een gegroepeerd cilinder‑diagram begint de eerste reeks met een cilindrische balkvorm. Het voorbeeld drukt de gehele getalwaarde af die wordt geretourneerd door [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) en [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) vóór en na elke wijziging. De tabel geeft de overeenkomende constantennamen weer.

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

| Wijziging voor de eerste reeks | Reeks type | Balkvorm |
| --- | --- | --- |
| Maak het diagram | `ClusteredCylinder` | `Cylinder` |
| Stel het reeks‑type in op `ClusteredCone` | `ClusteredCone` | `Cone` |
| Stel de balkvorm in op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` wijzigt tevens het reeks‑type naar `ClusteredColumn3D`. Als uw code vertakt op basis van het reeks‑type, roep dan `series.getType()` aan nadat u de vorm hebt gewijzigd. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `ClusteredCone`‑tak selecteren.

![PowerPoint-vergelijking die de eerste reeks toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **Veelgestelde vragen**

**Welke diagramtypes ondersteunen 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die via de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/)‑klasse worden aangeboden. Voor een exacte, actuele lijst, controleer de leden van [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) in de API‑documentatie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. U kunt een diagram exporteren naar een afbeelding met [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) of [render de volledige dia](/slides/nl/androidjava/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een raster‑preview nodig heeft of het diagram wilt insluiten in documenten, dashboards of webpagina’s zonder PowerPoint te vereisen.

**Hoe presteert het bouwen en renderen van grote 3D-diagrammen?**

De prestaties hangen af van het gegevensvolume en de visuele complexiteit. Voor de beste resultaten houdt u 3D‑effecten tot een minimum, vermijdt zware texturen op wanden en plotgebieden, beperkt het aantal gegevenspunten per reeks waar mogelijk, en rendert naar een output met een geschikte resolutie en afmetingen die passen bij de beoogde weergave‑ of afdrukvereisten.