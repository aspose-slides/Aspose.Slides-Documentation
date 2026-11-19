---
title: 3D-Diagramme in Präsentationen mit Java anpassen
linktitle: 3D-Diagramm
type: docs
url: /de/java/3d-chart/
keywords:
- 3D-Diagramm
- Rotation
- Tiefe
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen Sie 3D-Diagramme in PowerPoint-Präsentationen mit Aspose.Slides für Java. Passen Sie Rotation, Höhenverhältnisse, Diagrammtiefe und den Abstand zwischen Serien mit Java-Beispielen an."
---
## **Übersicht**

Aspose.Slides for Java ermöglicht Ihnen die Anpassung der Ansicht eines 3D‑Diagramms über die [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--)‑Methode. Dieser Artikel zeigt, wie man Rotation, Höhenverhältnisse, Tiefe, Rechtwinklige Achsen und den Abstand zwischen Serien anpasst und anschließend die Präsentation im PPTX‑Format speichert.

## **Rotation und Tiefe eines 3D‑Diagramms festlegen**

Das nachstehende Beispiel erstellt eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und verwendet [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) um ein gestapeltes 3D‑Säulendiagramm auf seiner ersten Folie hinzuzufügen. Es ersetzt die Standard‑Serien und -Kategorien durch zwei Serien mit jeweils drei Werten. Der Arbeitsblatt‑Index `0` identifiziert das erste Daten‑Arbeitsblatt des Diagramms; Zeile `0` enthält die Seriennamen und Spalte `0` die Kategorienamen.

Die Methoden [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) und [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) setzen die Rotation des Diagramms auf 40 bzw. 270 Grad. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) legt die Tiefe auf 150% seiner Breite fest, während [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) rechtwinklige Achsen anstelle von Perspektive aktiviert. Die resultierende Präsentation enthält das gefüllte Diagramm mit diesen 3D‑Ansichtseinstellungen.

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

## **Höhenverhältnisse eines 3D‑Diagramms anpassen**

Verwenden Sie [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-), um die Höhe eines 3D‑Diagramms als Prozentsatz seiner Breite festzulegen. Dadurch ändern sich die Proportionen der 3D‑Szene, ohne das Diagramm‑Objekt auf der Folie zu skalieren.

Das folgende Beispiel erstellt ein [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑Diagramm mit den Standarddaten: drei Serien und vier Kategorien. Es speichert drei Präsentationen mit Höhenverhältnissen von 50%, 100% und 200%. Position, Breite und Höhe des Diagramms bleiben unverändert. Daten, Rotation, Tiefe, Serienabstand und Formatierung sind in allen drei Dateien identisch; nur der Höhen‑Prozentsatz ändert sich.

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

Die folgenden Bilder zeigen die gleichen Höheneinstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert. Ein kleinerer Prozentsatz erzeugt eine flachere Szene, während ein größerer Prozentsatz eine höhere Szene innerhalb desselben Diagramm‑Objekts erzeugt. PowerPoint kann zudem die Achsen‑Tick‑Intervalle und die Beschriftungsposition an die Szene anpassen.

| Höhe: 50% | Höhe: 100% | Höhe: 200% |
| --- | --- | --- |
| ![3D‑Säulendiagramm mit einer Höhe von 50% seiner Breite](height_percent_50.png) | ![3D‑Säulendiagramm mit einer Höhe von 100% seiner Breite](height_percent_100.png) | ![3D‑Säulendiagramm mit einer Höhe von 200% seiner Breite](height_percent_200.png) |

Diese Methoden steuern unterschiedliche Aspekte des Diagramms:

| Methode | Auswirkung |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Höhe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Höhe des Diagramm‑Objekts auf der Folie, in Punkten. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Tiefe der 3D‑Szene als Prozentsatz ihrer Breite. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Marker‑Breite. |

Die Höhen‑Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑, Flächen‑, Kuchen‑ und Oberflächendiagramme. Der obige Vergleich verwendet den verifizierten Typ `Column3D`. Die Einstellung verändert das Erscheinungsbild eines 2D‑`ClusteredColumn`‑Diagramms oder eines `BubbleWith3D`‑Diagramms nicht; diese Namen sind Mitglieder der [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)-Klasse. Weitere Diagramm‑Erscheinungs‑Einstellungen finden Sie unter [Diagrammformatierung](/slides/de/java/chart-formatting/).

## **Abstand zwischen Serien anpassen**

Verwenden Sie [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-), um den Abstand zwischen Datenserien entlang der Tiefenachse eines 3D‑Diagramms zu steuern, ausgedrückt als Prozentsatz der Marker‑Breite. Verwenden Sie Werte von **0 bis 500**, inklusive: `0` entfernt den Abstand, während größere Werte den Abstand vergrößern. Bei fester Diagrammtiefe führt ein größerer Abstand dazu, dass die Marker entlang der Tiefenachse dünner werden.

Greifen Sie über [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) auf die Gruppe zu. Die Einstellung gilt für jede Serie in dieser Gruppe, nicht nur für die Serie, über die zugegriffen wird. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) gibt den Tiefen‑Abstand zurück und spiegelt die Einstellung der übergeordneten Gruppe wider.

Diese Einstellung wirkt sich auf 3D‑Säulen‑ und Balkendiagramme aus, einschließlich ihrer Zylinder‑, Kegel‑ und Pyramiden‑Varianten, sowie auf 3D‑Linien‑ und Flächendiagramme. Das Erscheinungsbild hängt davon ab, ob die Serien in der Tiefe angeordnet, gruppiert oder gestapelt sind. Für einen klaren Vergleich der Abstände zwischen einzelnen Serien verwenden Sie `ChartType.Column3D` aus der [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)-Klasse.

| Methode | Auswirkung |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Abstand zwischen Serien entlang der Tiefenachse, als Prozentsatz der Marker‑Breite. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, als Prozentsatz der Balken‑ oder Säulen‑Breite. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Gesamttiefe des Diagramms als Prozentsatz der Diagrammbreite. |

Das folgende eigenständige Beispiel verwendet die Standard‑Diagrammdaten, die drei Serien und vier Kategorien enthalten. Es speichert zwei Präsentationen mit identischen Daten, Rotation, Abstand‑Breite und Diagrammtiefe; nur der Abstand‑Tiefe ändert sich.

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

Die folgenden Bilder zeigen die gleichen Abstand‑Tiefe‑Einstellungen im entsprechenden .NET‑Beispiel und wurden mit Microsoft PowerPoint exportiert.

| Tiefenabstand: 0% | Tiefenabstand: 500% |
| --- | --- |
| ![3D‑Säulendiagramm ohne Abstand zwischen Serien entlang der Tiefenachse](gap_depth_0.png) | ![3D‑Säulendiagramm mit einem 500% Abstand zwischen Serien entlang der Tiefenachse](gap_depth_500.png) |

## **3D‑Serientyp und Balkenform ändern**

In einem gruppierten Zylinderdiagramm beginnt die erste Serie mit einer zylindrischen Balkenform. Das Beispiel gibt die von [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) und [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) zurückgegebenen Ganzzahlen vor und nach jeder Änderung aus. Die Tabelle enthält die entsprechenden Konstantennamen.

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

| Änderung an der ersten Serie | Serientyp | Balkenform |
| --- | --- | --- |
| Diagramm erstellen | `ClusteredCylinder` | `Cylinder` |
| Serientyp auf `ClusteredCone` setzen | `ClusteredCone` | `Cone` |
| Balkenform auf `Box` setzen | `ClusteredColumn3D` | `Box` |

Das Festlegen der Form auf `Box` ändert auch den Serientyp zu `ClusteredColumn3D`. Wenn Ihr Code abhängig vom Serientyp verzweigt, rufen Sie nach der Änderung der Form `series.getType()` auf. Ein vor der Zuweisung zwischengespeicherter Wert würde weiterhin den `ClusteredCone`‑Zweig auswählen.

![PowerPoint‑Vergleich, der die erste Serie von links nach rechts als Zylinder, Kegel und rechteckige Säulen zeigt](series-shapes.png)

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, zusammen mit verwandten 3D‑Typen, die über die [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)-Klasse bereitgestellt werden. Für eine exakte, aktuelle Liste prüfen Sie die Mitglieder der [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)-Klasse in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm mit [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) in ein Bild exportieren oder die gesamte Folie mit [die gesamte Folie rendern](/slides/de/java/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Dies ist nützlich, wenn Sie eine Raster‑Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen an Wänden und Plot‑Bereichen, begrenzen nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in einer angemessenen Ausgabegröße (Auflösung und Abmessungen), die zum Ziel‑Display oder Druckbedarf passt.