---
title: 3D-diagrammen aanpassen in presentaties met JavaScript
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
description: "Maak 3D-diagrammen in PowerPoint-presentaties met Aspose.Slides voor Node.js via Java. Pas rotatie, hoogteverhoudingen, diepte van het diagram en de tussenruimte tussen reeksen aan met JavaScript-voorbeelden."
---
## **Overzicht**

Aspose.Slides for Node.js via Java stelt je in staat om de weergave van een 3D-diagram aan te passen via de [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) methode. Dit artikel laat zien hoe je rotatie, hoogteverhoudingen, diepte, rechthoekige assen en de tussenruimte tussen reeksen kunt aanpassen, en vervolgens de presentatie opslaat in PPTX-formaat.

## **Instellen van de rotatie en diepte van een 3D-diagram**

Het onderstaande voorbeeld maakt een [Presentatie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) en gebruikt [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) om een gestapeld 3D‑kolomdiagram toe te voegen aan de eerste dia. Het vervangt de standaardreeksen en -categorieën door twee reeksen met elk drie waarden. Werkblad‑index `0` geeft het eerste gegevenswerkblad van het diagram aan; rij `0` bevat de reeksnamen en kolom `0` bevat de categorielabels.

De [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) en [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) methoden stellen de rotatie van het diagram in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) stelt de diepte in op 150 % van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) rechthoekige assen inschakelt in plaats van perspectief. De resulterende presentatie bevat het gevulde diagram met deze 3D‑weergave‑instellingen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een afbeeldingvulling toepassen op een 3D-diagramoppervlak**

Je kunt de [zijwand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [achterwand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/), en [vloer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) van een 3D-diagram onafhankelijk vullen. Stel het [vullingstype](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) in op `Picture` en wijs een afbeelding toe. Stel zowel de [afbeeldingsvullingsmodus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) als het [afbeeldingstype](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) van het oppervlak in op `Stretch` zodat één exemplaar van de afbeelding over het oppervlak wordt uitgerekt.

Sla [arrow.png](arrow.png) op in de werkmap. Het voorbeeld roteert het diagram en verhoogt de maximale waarde op de verticale as zodat de vloer zichtbaar is tussen de kolommen. Vervolgens wordt de dia twee keer gekloond en wordt de pijl op een ander oppervlak op elke dia toegepast. Alle drie de diagrammen behouden dezelfde gegevens, kijkhoek en achtergrond.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint toont de drie dia's als volgt.

| Zijwand | Achterwand | Vloer |
| --- | --- | --- |
| ![Pijl die in het diagram wijst langs de zijwand](side-wall.png) | ![Pijl die naar rechts wijst langs de achterwand](back-wall.png) | ![Pijl die naar rechts wijst over de vloer tussen de kolommen](floor.png) |

## **Hoogteverhoudingen van een 3D-diagram aanpassen**

Gebruik [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) om de hoogte van een 3D-diagram in te stellen als een percentage van de breedte. Dit wijzigt de verhoudingen van de 3D‑scene zonder de grootte van het diagramobject op de dia aan te passen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) diagram met de standaardgegevens: drie reeksen en vier categorieën. Het slaat drie presentaties op met hoogteverhoudingen van 50 %, 100 % en 200 %. De positie, breedte en hoogte van het diagram blijven vast. De gegevens, rotatie, diepte, reekstussenruimte en opmaak zijn identiek in alle drie de bestanden; alleen het hoogtepercentage wijzigt.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

De volgende afbeeldingen illustreren dezelfde hoogte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een lager percentage levert een plattere scene op, terwijl een hoger percentage een hogere scene binnen hetzelfde diagramobject produceert. PowerPoint kan ook de as‑tik‑intervallen en labelplaatsing aanpassen om de scene te laten passen.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D‑kolomdiagram met hoogte ingesteld op 50 % van de breedte](height_percent_50.png) | ![3D‑kolomdiagram met hoogte ingesteld op 100 % van de breedte](height_percent_100.png) | ![3D‑kolomdiagram met hoogte ingesteld op 200 % van de breedte](height_percent_200.png) |

Deze methoden regelen verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Hoogte van de 3D‑scene als een percentage van de breedte. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Hoogte van het diagramobject op de dia, in punten. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Diepte van de 3D‑scene als een percentage van de breedte. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Afstand tussen reeksen langs de diepte‑as, als een percentage van de marker‑breedte. |

De hoogte‑instelling heeft invloed op 3D‑kolom‑ en staafdiagrammen, inclusief cilinder-, kegel- en piramide‑varianten, evenals 3D‑lijn-, vlak-, taart‑ en oppervlakdiagrammen. De bovenstaande vergelijking maakt gebruik van het geverifieerde `Column3D`‑type. De instelling wijzigt het uiterlijk van een 2D‑`ClusteredColumn`‑diagram of een `BubbleWith3D`‑diagram niet; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑klasse. Voor andere diagram‑opmaak‑instellingen, zie [Diagramopmaak](/slides/nl/nodejs-java/chart-formatting/).

## **Tussenruimte tussen reeksen aanpassen**

Gebruik [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) om de afstand tussen gegevensreeksen langs de diepte‑as van een 3D‑diagram te regelen, uitgedrukt als een percentage van de marker‑breedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de tussenruimte, terwijl hogere waarden de afstand vergroten. Bij een vaste diagramdiepte maakt een grotere tussenruimte de markers dunner langs de diepte‑as.

Benader de groep via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). De instelling geldt voor elke reeks in die groep, niet alleen voor de reeks die wordt gebruikt om toegang te krijgen. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) retourneert de diepte‑tussenruimte en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling heeft invloed op 3D‑kolom‑ en staafdiagrammen, inclusief hun cilinder-, kegel- en piramide‑varianten, evenals 3D‑lijn‑ en vlakdiagrammen. Het uiterlijk hangt af van of de reeksen in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van tussenruimtes tussen afzonderlijke reeksen, gebruik `ChartType.Column3D` uit de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑klasse.

Deze methoden regelen verschillende aspecten van het diagram:

| Methode | Effect |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Afstand tussen reeksen langs de diepte‑as, als een percentage van de marker‑breedte. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Afstand tussen aangrenzende staaf‑ of kolomcluster, als een percentage van de staaf‑ of kolombreedte. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Totale diagramdiepte, als een percentage van de diagrambreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaarddiagramgegevens, die drie reeksen en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, tussenruimte‑breedte en diagramdiepte; alleen de tussenruimte‑diepte wijzigt.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

De volgende afbeeldingen illustreren dezelfde tussenruimte‑diepte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Tussenruimte‑diepte: 0% | Tussenruimte‑diepte: 500% |
| --- | --- |
| ![3D‑kolomdiagram zonder tussenruimte tussen reeksen langs de diepte‑as](gap_depth_0.png) | ![3D‑kolomdiagram met een tussenruimte van 500 % tussen reeksen langs de diepte‑as](gap_depth_500.png) |

## **Het 3D‑serietype en de balkvorm wijzigen**

In een gegroepeerd cilinder‑diagram begint de eerste reeks met een cilindrische balkvorm. Het voorbeeld drukt de gehele getallen af die worden geretourneerd door [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) en [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) vóór en na elke wijziging. De tabel geeft de bijbehorende constantenamen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Wijziging van de eerste reeks | Serietype | Balkvorm |
| --- | --- | --- |
| Maak het diagram | `ClusteredCylinder` | `Cylinder` |
| Stel het serietype in op `ClusteredCone` | `ClusteredCone` | `Cone` |
| Stel de balkvorm in op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` wijzigt ook het serietype naar `ClusteredColumn3D`. Als je code vertakt op basis van het serietype, roep dan `series.getType()` aan na het wijzigen van de vorm. Een waarde die vooraf is gecached, zou nog steeds de `ClusteredCone`‑vertakking selecteren.

![PowerPoint‑vergelijking die de eerste reeks toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **FAQ**

**Welke diagramtypen ondersteunen de 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die worden blootgelegd via de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑klasse. Voor een exacte, up‑to‑date lijst, bekijk de leden van [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) in de API‑referentie van je geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. Je kunt een diagram exporteren naar een afbeelding met [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) of [render de gehele dia](/slides/nl/nodejs-java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer je een raster‑preview nodig hebt of het diagram wilt insluiten in documenten, dashboards of webpagina's zonder PowerPoint te vereisen.

**Hoe presteert het bouwen en renderen van grote 3D-diagrammen?**

De prestaties hangen af van de hoeveelheid gegevens en de visuele complexiteit. Voor optimale resultaten, houd 3D‑effecten minimaal, vermijd zware texturen op wanden en plot‑gebieden, beperk het aantal gegevenspunten per reeks waar mogelijk, en render naar een passend formaat (resolutie en afmetingen) dat aansluit bij de gewenste weergave‑ of afdrukbehoeften.