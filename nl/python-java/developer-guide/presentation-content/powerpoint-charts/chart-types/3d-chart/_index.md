---
title: Aangepaste 3D‑grafieken in presentaties met Python
linktitle: 3D‑grafiek
type: docs
url: /nl/python-java/3d-chart/
keywords:
- 3D‑grafiek
- rotatie
- diepte
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak 3D‑grafieken in PowerPoint‑presentaties met Aspose.Slides for Python via Java. Pas rotatie, hoogteratio’s, grafiekdiepte en de tussenruimte tussen series aan met Python‑voorbeelden."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt u in staat de weergave van een 3D‑grafiek aan te passen via de [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) methode. In dit artikel wordt getoond hoe u rotatie, hoogteratio’s, diepte, rechthoekige assen en de tussenruimte tussen series kunt aanpassen, en vervolgens de presentatie opslaat in PPTX‑formaat.

## **De rotatie en diepte van een 3D‑grafiek instellen**

Het onderstaande voorbeeld maakt een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) aan en gebruikt [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) om een gestapelde 3D‑kolomgrafiek toe te voegen aan de eerste dia. Het vervangt de standaard series en categorieën door twee series met elk drie waarden. Werkblad‑index `0` identificeert het eerste gegevens‑werkblad van de grafiek; rij `0` bevat de serienamen en kolom `0` bevat de categorielabels.

De [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) en [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) methoden stellen de rotatie van de grafiek in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) zet de diepte op 150 % van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) rechte‑hoeks assen inschakelt in plaats van perspectief. De resulterende presentatie bevat de gevulde grafiek met deze 3D‑weergave‑instellingen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **De hoogteratio’s van een 3D‑grafiek aanpassen**

Gebruik [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) om de hoogte van een 3D‑grafiek in te stellen als een percentage van de breedte. Dit wijzigt de verhoudingen van de 3D‑scene zonder de afmetingen van het grafiekobject op de dia te wijzigen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) grafiek met de standaardgegevens: drie series en vier categorieën. Het slaat drie presentaties op met hoogteratio’s van 50 %, 100 % en 200 %. De positie, breedte en hoogte van de grafiek blijven vast. De gegevens, rotatie, diepte, tussenruimte tussen series en opmaak zijn in alle drie bestanden identiek; alleen het hoogteratio wijzigt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De volgende afbeeldingen illustreren dezelfde hoogte‑instellingen in het gelijkwaardige .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een kleiner percentage levert een plattere scene op, terwijl een groter percentage een hogere scene oplevert binnen hetzelfde grafiekobject. PowerPoint kan ook de as‑stapintervallen en label‑plaatsing aanpassen om de scene passend te maken.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D kolomgrafiek met hoogte ingesteld op 50 procent van de breedte](height_percent_50.png) | ![3D kolomgrafiek met hoogte ingesteld op 100 procent van de breedte](height_percent_100.png) | ![3D kolomgrafiek met hoogte ingesteld op 200 procent van de breedte](height_percent_200.png) |

Deze methoden regelen verschillende aspecten van de grafiek:

| Methode | Effect |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | Hoogte van de 3D‑scene als percentage van de breedte. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Hoogte van het grafiekobject op de dia, in punten. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Diepte van de 3D‑scene als percentage van de breedte. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Tussenruimte tussen series langs de diepte‑as, als percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafgrafieken, inclusief cilindrische, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑, gebieds‑, taart‑ en oppervlak‑grafieken. De bovenstaande vergelijking gebruikt het geverifieerde type `Column3D`. De instelling verandert niet het uiterlijk van een 2D‑grafiek `ClusteredColumn` of een `BubbleWith3D`‑grafiek; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) klasse. Voor andere grafiek‑opmaak‑instellingen, zie [Grafiekopmaak](/slides/nl/python-java/chart-formatting/).

## **De tussenruimte tussen series aanpassen**

Gebruik [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) om de afstand tussen dataseries langs de diepte‑as van een 3D‑grafiek te regelen, uitgedrukt als een percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de tussenruimte, terwijl grotere waarden de afstand vergroten. Bij een vaste grafiekdiepte maakt een grotere tussenruimte de markers dunner langs de diepte‑as.

Toegang tot de groep verkrijg je via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup). De instelling geldt voor elke serie in die groep, niet alleen voor de serie die werd gebruikt om er toegang toe te krijgen. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) retourneert de diepte‑tussenruimte en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom‑ en staafgrafieken, inclusief hun cilindrische, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑ en gebiedsgrafieken. Het uiterlijk hangt af van of de series in diepte, gegroepeerd of gestapeld worden weergegeven. Voor een duidelijke vergelijking van tussenruimtes tussen afzonderlijke series, gebruik `ChartType.Column3D` uit de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) klasse.

Deze methoden regelen verschillende aspecten van de grafiek:

| Methode | Effect |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Tussenruimte tussen series langs de diepte‑as, als percentage van de markerbreedte. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Tussenruimte tussen aangrenzende staaf‑ of kolom‑clusters, als percentage van de staaf‑ of kolom‑breedte. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Algemene grafiekdiepte, als percentage van de grafiekbreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaard grafiekgegevens, die drie series en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, tussenruimte‑breedte en grafiekdiepte; alleen de tussenruimte‑diepte wijzigt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De volgende afbeeldingen illustreren dezelfde tussenruimte‑diepte‑instellingen in het gelijkwaardige .NET‑voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Tussenruimte‑diepte: 0% | Tussenruimte‑diepte: 500% |
| --- | --- |
| ![3D kolomgrafiek zonder tussenruimte tussen series langs de diepte‑as](gap_depth_0.png) | ![3D kolomgrafiek met een tussenruimte van 500 procent tussen series langs de diepte‑as](gap_depth_500.png) |

## **Het 3D‑serietype en de staafvorm wijzigen**

In een gegroepeerde cilindrische grafiek begint de eerste serie met een cilindrische staafvorm. Het voorbeeld print de gehele getallen die worden geretourneerd door [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) en [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) vóór en na elke wijziging. De tabel geeft de bijbehorende constante namen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Wijziging van de eerste serie | Serietype | Staafvorm |
| --- | --- | --- |
| Maak de grafiek | `ClusteredCylinder` | `Cylinder` |
| Stel het serietype in op `ClusteredCone` | `ClusteredCone` | `Cone` |
| Stel de staafvorm in op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` verandert ook het serietype in `ClusteredColumn3D`. Als uw code vertakt op basis van het serietype, roep dan `series.getType()` aan na het wijzigen van de vorm. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `ClusteredCone`‑vertakking selecteren.

![PowerPoint‑vergelijking die de eerste serie toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **Veelgestelde vragen**

**Welke grafiektype‑s ondersteunen de 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomgrafieken, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die via de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) klasse beschikbaar zijn. Voor een exacte, actuele lijst, controleer de leden van [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑grafiek krijgen voor een rapport of het web?**

Ja. U kunt een grafiek exporteren naar een afbeelding met [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) of [render de volledige dia](/slides/nl/python-java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een raster‑preview nodig heeft of de grafiek wilt insluiten in documenten, dashboards of webpagina's zonder PowerPoint te vereisen.

**Hoe presteert het bouwen en renderen van grote 3D‑grafieken?**

De prestaties hangen af van het gegevensvolume en de visuele complexiteit. Voor optimale resultaten houdt u 3D‑effecten minimaal, vermijdt u zware texturen op wanden en plot‑gebieden, beperkt u het aantal gegevenspunten per serie waar mogelijk, en rendert u naar een output van geschikte grootte (resolutie en afmetingen) die aansluit bij de beoogde weergave‑ of afdrukbehoeften.