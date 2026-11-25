---
title: 3D-Diagramme in Präsentationen mit JavaScript anpassen
linktitle: 3D-Diagramm
type: docs
url: /de/nodejs-java/3d-chart/
keywords:
- 3D-Diagramm
- Drehung
- Tiefe
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für Node.js über Java. Passen Sie Drehung, Höhenverhältnisse, Diagrammtiefe und den Abstand zwischen Serien mit JavaScript-Beispielen an."
---
## **Übersicht**

Aspose.Slides für Node.js über Java ermöglicht es Ihnen, die Ansicht eines 3D‑Diagramms über die Methode [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) anzupassen. Dieser Artikel demonstriert, wie man Drehung, Höhenverhältnisse, Tiefe, rechtwinklige Achsen und den Abstand zwischen Serien anpasst und die Präsentation anschließend im PPTX‑Format speichert.

## **Drehung und Tiefe eines 3D‑Diagramms festlegen**

Das untenstehende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) und verwendet [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/), um ein gestapeltes 3D‑Säulendiagramm zu seiner ersten Folie hinzuzufügen. Es ersetzt die Standard‑Serien und -Kategorien durch zwei Serien mit jeweils drei Werten. Der Arbeitsblatt‑Index `0` identifiziert das erste Datenarbeitsblatt des Diagramms; Zeile `0` enthält die Seriennamen und Spalte `0` die Kategorienamen.

Die Methoden [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) und [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) setzen die Drehung des Diagramms auf 40 bzw. 270 Grad. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) legt die Tiefe auf 150 % seiner Breite fest, während [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) rechtwinklige Achsen anstelle von Perspektive aktiviert. Die resultierende Präsentation enthält das befüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

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

## **Bildfüllung auf einer 3D‑Diagrammoberfläche anwenden**

Sie können die [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), die [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) und den [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) eines 3D‑Diagramms unabhängig voneinander füllen. Setzen Sie den [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) der Oberfläche auf `Picture` und weisen Sie ein Bild zu. Setzen Sie sowohl den [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) als auch den [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) der Oberfläche auf `Stretch`, um eine Kopie des Bildes über die gesamte Oberfläche zu strecken.

Speichern Sie [arrow.png](arrow.png) im Arbeitsverzeichnis. Das Beispiel dreht das Diagramm und erhöht den Maximalwert der vertikalen Achse, sodass der Boden zwischen den Säulen sichtbar ist. Anschließend wird die Folie zweimal dupliziert und der Pfeil auf jeweils einer anderen Oberfläche jeder Folie angewendet. Alle drei Diagramme behalten dieselben Daten, den Betrachtungswinkel und den Hintergrund.

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

Microsoft PowerPoint zeigt die drei Folien wie folgt an.

| Seitenwand | Rückwand | Boden |
| --- | --- | --- |
| ![Pfeil, der in das Diagramm entlang der Seitenwand zeigt](side-wall.png) | ![Pfeil, der nach rechts über die Rückwand zeigt](back-wall.png) | ![Pfeil, der nach rechts über den Boden zwischen den Säulen zeigt](floor.png) |

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Dies ändert die Proportionen der 3D‑Szene, ohne das Diagrammobjekt auf der Folie zu skalieren.

Das folgende Beispiel erstellt ein [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑Diagramm mit den Standarddaten: drei Serien und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50 %, 100 % und 200 %. Position, Breite und Höhe des Diagramms bleiben unverändert. Die Daten, Drehung, Tiefe, Serienabstand und Formatierung sind in allen drei Dateien identisch; nur der Höhenprozentsatz ändert sich.

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

Die folgenden Bilder zeigen dieselben Höheneinstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, während ein größerer Prozentsatz eine höhere Szene innerhalb desselben Diagrammobjekts erzeugt. PowerPoint kann außerdem die Achsen‑Tick‑Intervalle und die Beschriftungspositionen anpassen, um die Szene zu passen.

| Höhe: 50 % | Höhe: 100 % | Höhe: 200 % |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50 % seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100 % seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200 % seiner Breite](height_percent_200.png) |

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Auswirkung |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Höhe des Diagrammobjekts auf der Folie, in Punkten. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Marker‑Breite. |

Die Höheinstellung wirkt sich auf 3D‑Säulen- und Balkendiagramme aus, einschließlich Zylinder-, Kegel- und Pyramiden‑Varianten, sowie auf 3D‑Linien-, Flächen-, Kreis- und Oberflächendiagramme. Der obige Vergleich verwendet den verifizierten Typ `Column3D`. Die Einstellung ändert das Aussehen eines 2D‑`ClusteredColumn`‑Diagramms oder eines `BubbleWith3D`‑Diagramms nicht; diese Namen sind Mitglieder der Klasse [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Weitere Einstellungen für das Diagrammaussehen finden Sie unter [Diagrammformatierung](/slides/de/nodejs-java/chart-formatting/).

## **Abstand zwischen Serien anpassen**

Verwenden Sie [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/), um den Abstand zwischen Datenserien entlang der Tiefenachse eines 3D‑Diagramms zu steuern, ausgedrückt als Prozentsatz der Marker‑Breite. Verwenden Sie Werte von **0 bis 500**, inklusiv: `0` entfernt den Abstand, während höhere Werte den Abstand vergrößern. Bei fester Diagrammtiefe lässt ein größerer Abstand die Marker entlang der Tiefenachse dünner erscheinen.

Greifen Sie über [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) auf die Gruppe zu. Die Einstellung gilt für jede Serie in dieser Gruppe, nicht nur für die Serie, über die sie aufgerufen wurde. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) gibt den Tiefenabstand zurück und spiegelt die Einstellung der übergeordneten Gruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen- und Balkendiagramme aus, einschließlich ihrer Zylinder-, Kegel- und Pyramiden‑Varianten, sowie auf 3D‑Linien- und Flächendiagramme. Das Aussehen hängt davon ab, ob die Serien in der Tiefe, gruppiert oder gestapelt angeordnet sind. Für einen klaren Vergleich der Abstände zwischen einzelnen Serien verwenden Sie `ChartType.Column3D` aus der Klasse [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Diese Methoden steuern verschiedene Aspekte des Diagramms:

| Methode | Auswirkung |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Marker‑Breite. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Abstand zwischen benachbarten Balken‑ oder Säulen‑Gruppen, als Prozentsatz der Balken‑ oder Säulenbreite. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Gesamttiefe des Diagramms, als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standard‑Diagrammdaten, die drei Serien und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Drehung, Lückenbreite und Diagrammtiefe; nur die Lückentiefe ändert sich.

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

Die folgenden Bilder zeigen dieselben Lückentiefe‑Einstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert.

| Lückentiefe: 0 % | Lückentiefe: 500 % |
| --- | --- |
| ![3D‑Säulendiagramm ohne Abstand zwischen Serien entlang der Tiefenachse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einem 500‑Prozent‑Abstand zwischen Serien entlang der Tiefenachse](gap_depth_500.png) |

## **3D‑Serientyp und Balkenform ändern**

In einem gruppierten Zylinder‑Diagramm beginnt die erste Serie mit einer zylindrischen Balkenform. Das Beispiel gibt die von [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) und [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) zurückgegebenen Ganzzahlen vor und nach jeder Änderung aus. Die Tabelle liefert die entsprechenden Konstantennamen.

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

| Ändern der ersten Serie | Serientyp | Balkenform |
| --- | --- | --- |
| Diagramm erstellen | `ClusteredCylinder` | `Cylinder` |
| Serientyp auf `ClusteredCone` setzen | `ClusteredCone` | `Cone` |
| Balkenform auf `Box` setzen | `ClusteredColumn3D` | `Box` |

Das Setzen der Form auf `Box` ändert zudem den Serientyp zu `ClusteredColumn3D`. Wenn Ihr Code abhängig vom Serientyp verzweigt, rufen Sie `series.getType()` nach dem Ändern der Form auf. Ein vorher zwischengespeicherter Wert würde weiterhin den `ClusteredCone`‑Zweig auswählen.

![PowerPoint‑Vergleich, der die erste Serie von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, darunter Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Klasse [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) zugänglich sind. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) in ein Bild exportieren oder die gesamte Folie mit [die gesamte Folie rendern](/slides/de/nodejs-java/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Das ist nützlich, wenn Sie eine Rastervorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen auf Wänden und Plot‑Bereichen, begrenzen nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in einer angemessenen Ausgabegröße (Auflösung und Abmessungen), die dem Zielanzeigegerät oder den Druckanforderungen entspricht.