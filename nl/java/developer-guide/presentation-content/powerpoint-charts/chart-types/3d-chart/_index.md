---
title: Aanpassen van 3D-grafieken in presentaties met Java
linktitle: 3D-grafiek
type: docs
url: /nl/java/3d-chart/
keywords:
- 3D-grafiek
- rotatie
- diepte
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak 3D-grafieken in PowerPoint-presentaties met Aspose.Slides voor Java. Pas rotatie, hoogteverhoudingen, grafiekdiepte en afstand tussen series aan met Java-voorbeelden."
---
## **Overzicht**

Aspose.Slides for Java laat u de weergave van een 3D-grafiek aanpassen via de [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) methode. Dit artikel toont hoe u rotatie, hoogtegraden, diepte, rechthoeken assen en afstand tussen series kunt aanpassen, en vervolgens de presentatie opslaat in PPTX-formaat.

## **Stel de rotatie en diepte van een 3D-grafiek in**

Het onderstaande voorbeeld maakt een [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) aan en gebruikt [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) om een gestapelde 3D-kolomgrafiek aan de eerste dia toe te voegen. Het vervangt de standaard series en categorieën door twee series met elk drie waarden. Werkblad-index `0` identificeert het eerste gegevens-werkblad van de grafiek; rij `0` bevat de serienaam, en kolom `0` bevat de categorielabels.

De methoden [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) en [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) stellen de rotatie van de grafiek in op respectievelijk 40 en 270 graden. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) zet de diepte op 150% van de breedte, terwijl [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) rechthoeken assen inschakelt in plaats van perspectief. De resulterende presentatie bevat de gevulde grafiek met deze 3D-weergave-instellingen.

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

## **Pas een afbeelding-vulling toe op een 3D-grafiekoppervlak**

Een 3D-grafiek heeft drie oppervlakken die u onafhankelijk kunt vullen: de [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) en de [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--). Stel het [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) van het oppervlak in op `Picture` en wijs een afbeelding toe. Stel zowel de [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) als het [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) van het oppervlak in op `Stretch` om één exemplaar van de afbeelding over het oppervlak te laten passen.

Sla [arrow.png](arrow.png) op in de werkmap. Het voorbeeld roteert de grafiek en verhoogt de maximale waarde op de verticale as zodat de vloer tussen de kolommen zichtbaar is. Daarna klont het de dia tweemaal en past de pijl toe op een ander oppervlak op elke dia. Alle drie de grafieken behouden dezelfde gegevens, kijkhoek en achtergrond.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
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

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

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

Microsoft PowerPoint toont de drie dia’s als volgt.

| Zijwand | Achterwand | Vloer |
| --- | --- | --- |
| ![Pijl die naar het diagram wijst langs de zijwand](side-wall.png) | ![Pijl die naar rechts wijst over de achterwand](back-wall.png) | ![Pijl die naar rechts wijst over de vloer tussen de kolommen](floor.png) |

## **Pas de hoogtegraden van een 3D-grafiek aan**

Gebruik [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) om de hoogte van een 3D-grafiek in te stellen als percentage van de breedte. Hiermee verandert u de verhoudingen van de 3D-scene zonder het grafiekobject op de dia te wijzigen.

Het volgende voorbeeld maakt een [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) grafiek met de standaardgegevens: drie series en vier categorieën. Het slaat drie presentaties op met hoogtegraden van 50%, 100% en 200%. De positie, breedte en hoogte van de grafiek blijven gelijk. De gegevens, rotatie, diepte, series-afstand en opmaak zijn identiek in alle drie de bestanden; alleen het hoogte-percentage wijzigt.

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

De volgende afbeeldingen illustreren dezelfde hoogte-instellingen in het equivalente .NET-voorbeeld en zijn geëxporteerd met Microsoft PowerPoint. Een kleiner percentage levert een plattere scene op, een groter percentage een hogere scene binnen hetzelfde grafiekobject. PowerPoint kan ook de as-tikintervallen en labelplaatsing aanpassen om de scene te laten passen.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D-kolomgrafiek met hoogte ingesteld op 50% van de breedte](height_percent_50.png) | ![3D-kolomgrafiek met hoogte ingesteld op 100% van de breedte](height_percent_100.png) | ![3D-kolomgrafiek met hoogte ingesteld op 200% van de breedte](height_percent_200.png) |

Deze methoden sturen verschillende aspecten van de grafiek aan:

| Methode | Effect |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Hoogte van de 3D-scene als percentage van de breedte. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Hoogte van het grafiekobject op de dia, in points. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Diepte van de 3D-scene als percentage van de breedte. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Afstand tussen series langs de diepte-as, als percentage van de marker-breedte. |

De hoogte-instelling beïnvloedt 3D-kolom- en staafgrafieken, inclusief cilindrische, kegel- en piramidevarianten, evenals 3D-lijn-, gebieds-, taart- en oppervlakgrafieken. De bovenstaande vergelijking maakt gebruik van het gecontroleerde `Column3D`-type. De instelling verandert de weergave van een 2D-`ClusteredColumn`-grafiek of een `BubbleWith3D`-grafiek; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑klasse. Voor andere grafiek-opmaakopties, zie [Chart Formatting](/slides/nl/java/chart-formatting/).

## **Pas de afstand tussen series aan**

Gebruik [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) om de afstand tussen dataseries langs de diepte-as van een 3D-grafiek te regelen, uitgedrukt als percentage van de marker-breedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de afstand, terwijl hogere waarden de ruimte vergroten. Bij een vaste grafiekdiepte maakt een grotere afstand de markers dunner langs de diepte-as.

Benader de groep via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). De instelling geldt voor elke serie in die groep, niet alleen voor de serie die u gebruikt om er toegang toe te krijgen. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) retourneert de diepte-gap en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D-kolom- en staafgrafieken, inclusief hun cilindrische, kegel- en piramidevarianten, evenals 3D-lijn- en gebiedsgrafieken. Het uiterlijk hangt af of de series in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van gaten tussen afzonderlijke series, gebruik `ChartType.Column3D` uit de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑klasse.

Deze methoden sturen verschillende aspecten van de grafiek aan:

| Methode | Effect |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Afstand tussen series langs de diepte-as, als percentage van de marker-breedte. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Afstand tussen aangrenzende staaf- of kolomclusters, als percentage van de staaf- of kolombreedte. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Totale grafiekdiepte, als percentage van de grafiekbreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaardgrafiekgegevens, met drie series en vier categorieën. Het slaat twee presentaties op met identieke gegevens, rotatie, gat-breedte en grafiekdiepte; alleen de gat-diepte wijzigt.

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

De volgende afbeeldingen illustreren dezelfde gat-diepte-instellingen in het equivalente .NET-voorbeeld en zijn geëxporteerd met Microsoft PowerPoint.

| Gat-diepte: 0% | Gat-diepte: 500% |
| --- | --- |
| ![3D-kolomgrafiek zonder gat tussen series langs de diepte-as](gap_depth_0.png) | ![3D-kolomgrafiek met een gat van 500% tussen series langs de diepte-as](gap_depth_500.png) |

## **Wijzig het 3D-serietype en de staafvorm**

In een gegroepeerde cilindergrafiek start de eerste serie met een cilindrische staafvorm. Het voorbeeld drukt de gehele waarden af die worden geretourneerd door [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) en [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) vóór en na elke wijziging. De tabel geeft de overeenkomstige constante namen.

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
| Maak de grafiek | `ClusteredCylinder` | `Cylinder` |
| Stel het serietype in op `ClusteredCone` | `ClusteredCone` | `Cone` |
| Stel de staafvorm in op `Box` | `ClusteredColumn3D` | `Box` |

Het instellen van de vorm op `Box` wijzigt ook het serietype naar `ClusteredColumn3D`. Als uw code van het serietype afhankelijk is, roep dan `series.getType()` aan na het wijzigen van de vorm. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `ClusteredCone`-tak selecteren.

![PowerPoint-vergelijking die de eerste serie toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **FAQ**

**Welke grafiektype's ondersteunen 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D-varianten van kolomgrafieken, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100% Stacked Column 3D, evenals gerelateerde 3D-typen die beschikbaar zijn via de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑klasse. Voor een exacte, up-to-date lijst, raadpleeg de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑leden in de API-referentie van uw geïnstalleerde versie.

**Kan ik een raster-afbeelding van een 3D-grafiek krijgen voor een rapport of het web?**

Ja. U kunt een grafiek exporteren naar een afbeelding met [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) of [render de volledige dia](/slides/nl/java/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een raster-preview nodig heeft of de grafiek wilt insluiten in documenten, dashboards of webpagina's zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D-grafieken?**

De prestatie hangt af van het gegevensvolume en de visuele complexiteit. Voor de beste resultaten, houd 3D-effecten minimaal, vermijd zware texturen op muren en plot-gebieden, beperk het aantal gegevenspunten per serie waar mogelijk, en render naar een passend formaat (resolutie en afmetingen) afgestemd op de beoogde weergave- of afdrukbehoefte.