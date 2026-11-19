---
title: Pas 3D‑grafieken aan in presentaties met JavaScript
linktitle: 3D‑grafiek
type: docs
url: /nl/nodejs-java/3d-chart/
keywords:
- 3D‑grafiek
- rotatie
- diepte
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak 3D‑grafieken in PowerPoint‑presentaties met Aspose.Slides voor Node.js via Java. Stel rotatie, hoogteverhoudingen, grafiekdiepte en de afstand tussen series in met JavaScript‑voorbeelden."
---
## **Overzicht**

Aspose.Slides for Node.js via Java stelt u in staat de weergave van een 3D‑grafiek aan te passen via de [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) methode. Dit artikel laat zien hoe u rotatie, hoogteverhoudingen, diepte, rechthoekige assen en de afstand tussen reeksen kunt aanpassen, en vervolgens de presentatie opslaat in PPTX‑indeling.

## **Stel de rotatie en diepte van een 3D‑grafiek in**

Het voorbeeld hieronder maakt een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) aan en gebruikt [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) om een gestapelde 3D‑kolomgrafiek toe te voegen aan de eerste dia. Het vervangt de standaardreeksen en –categorieën door twee reeksen met elk drie waarden. Werkbladindex `0` geeft het eerste gegevenswerkblad van de grafiek aan; rij `0` bevat de reeksnamen en kolom `0` bevat de categorie‑labels.

De methoden [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) en [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) stellen de rotatie van de grafiek in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) zet de diepte op 150 % van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) rechtehoeksassen inschakelt in plaats van perspectief. De resulterende presentatie bevat de gevulde grafiek met deze 3D‑weergave‑instellingen.

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

## **Pas de hoogteverhoudingen van een 3D‑grafiek aan**

Gebruik [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) om de hoogte van een 3D‑grafiek in te stellen als een percentage van de breedte. Dit wijzigt de verhoudingen van de 3D‑scene zonder de grootte van het grafiekobject op de dia aan te passen.

Het volgende voorbeeld maakt een grafiek van het type [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) met de standaardgegevens: drie reeksen en vier categorieën. Het slaat drie presentaties op met hoogteverhoudingen van 50 %, 100 % en 200 %. De positie, breedte en hoogte van de grafiek blijven gelijk. De gegevens, rotatie, diepte, reeksen‑afstand en opmaak zijn in alle drie bestanden identiek; alleen het hoogte‑percentage verandert.

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

De volgende afbeeldingen illustreren dezelfde hoogte‑instellingen in het equivalent .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een kleiner percentage levert een plattere scene op, terwijl een groter percentage een hogere scene binnen hetzelfde grafiekobject oplevert. PowerPoint kan ook de interval‑instellingen van de as‑tic‑marks en de plaatsing van de labels aanpassen om in de scene te passen.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D‑kolomgrafiek met hoogte ingesteld op 50 procent van de breedte](height_percent_50.png) | ![3D‑kolomgrafiek met hoogte ingesteld op 100 procent van de breedte](height_percent_100.png) | ![3D‑kolomgrafiek met hoogte ingesteld op 200 procent van de breedte](height_percent_200.png) |

Deze methoden regelen verschillende aspecten van de grafiek:

| Methode | Effect |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Hoogte van de 3D‑scene als percentage van de breedte. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Hoogte van het grafiekobject op de dia, in punten. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Diepte van de 3D‑scene als percentage van de breedte. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Afstand tussen reeksen langs de diepte‑as, als percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafgrafieken, inclusief de varianten cylinder, kegel en piramide, evenals 3D‑lijn‑, vlak‑, taart‑ en oppervlak‑grafieken. De bovenstaande vergelijking maakt gebruik van het geverifieerde type `Column3D`. De instelling wijzigt niet het uiterlijk van een 2D‑`ClusteredColumn`‑grafiek of een `BubbleWith3D`‑grafiek; deze namen behoren tot de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑klasse. Voor andere grafiek‑opmaakinstellingen, zie [Grafiekopmaak](/slides/nl/nodejs-java/chart-formatting/).

## **Pas de afstand tussen reeksen aan**

Gebruik [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) om de afstand tussen datagegevensreeksen langs de diepte‑as van een 3D‑grafiek te regelen, uitgedrukt als een percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de kloof, terwijl hogere waarden de afstand vergroten. Met een vaste grafiekdiepte maakt een grotere kloof de markers dunner langs de diepte‑as.

Toegang tot de groep krijg je via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). De instelling geldt voor elke reeks in die groep, niet alleen voor de reeks die is gebruikt om er toegang toe te krijgen. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) retourneert de diepte‑kloof en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom‑ en staafgrafieken, inclusief hun cylinder-, kegel- en piramide‑varianten, evenals 3D‑lijn‑ en vlak‑grafieken. Het uiterlijk hangt af van of de reeksen in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van kloven tussen afzonderlijke reeksen, gebruik `ChartType.Column3D` uit de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑klasse.

Deze methoden regelen verschillende aspecten van de grafiek:

| Methode | Effect |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Afstand tussen reeksen langs de diepte‑as, als percentage van de markerbreedte. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Afstand tussen aangrenzende staaf‑ of kolomgroepen, als percentage van de staaf‑ of kolombreedte. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Totale grafiekdiepte, als percentage van de grafiekbreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaardgrafiekgegevens, die drie reeksen en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, kloofbreedte en grafiekdiepte; alleen de kloofdiepte wijzigt.

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

De volgende afbeeldingen illustreren dezelfde kloofdiepte‑instellingen in het equivalente .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Kloofdiepte: 0% | Kloofdiepte: 500% |
| --- | --- |
| ![3D‑kolomgrafiek zonder kloof tussen reeksen langs de diepte‑as](gap_depth_0.png) | ![3D‑kolomgrafiek met een kloof van 500 procent tussen reeksen langs de diepte‑as](gap_depth_500.png) |

## **Wijzig het 3D‑reeks‑type en de staafvorm**

In een gegroepeerde cilindergrafiek begint de eerste reeks met een cilindrische staafvorm. Het voorbeeld drukt de gehele getallen af die worden geretourneerd door [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) en [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) vóór en na elke wijziging. De tabel geeft de bijbehorende constante namen.

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

| Wijziging van de eerste reeks | Reekstype | Staafvorm |
| --- | --- | --- |
| Maak de grafiek | `ClusteredCylinder` | `Cylinder` |
| Stel het reekstype in op `ClusteredCone` | `ClusteredCone` | `Cone` |
| Stel de staafvorm in op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` wijzigt tevens het reekstype naar `ClusteredColumn3D`. Als uw code vertakt op basis van het reekstype, roep dan `series.getType()` aan na het wijzigen van de vorm. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `ClusteredCone`‑vertakking selecteren.

![PowerPoint‑vergelijking die de eerste reeks toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **FAQ**

**Welke grafiektype ondersteunen de 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomgrafieken, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die beschikbaar zijn via de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑klasse. Voor een exacte, up-to-date lijst, bekijk de leden van [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑grafiek krijgen voor een rapport of het web?**

Ja. U kunt een grafiek exporteren naar een afbeelding met [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) of [render the entire slide](/slides/nl/nodejs-java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is nuttig wanneer u een raster‑preview nodig heeft of de grafiek wilt insluiten in documenten, dashboards of webpagina's zonder PowerPoint.

**Hoe presteert het bouwen en renderen van grote 3D‑grafieken?**

De prestaties hangen af van de hoeveelheid gegevens en de visuele complexiteit. Voor optimale resultaten, houd 3D‑effecten minimaal, vermijd zware texturen op wanden en plotgebieden, beperk het aantal datapunten per reeks waar mogelijk, en render naar een passend formaat (resolutie en afmetingen) dat overeenkomt met de beoogde weergave of afdrukbehoefte.