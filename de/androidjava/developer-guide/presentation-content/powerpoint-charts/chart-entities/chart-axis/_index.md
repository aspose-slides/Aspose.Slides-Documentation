---
title: Diagrammachsen in Präsentationen auf Android anpassen
linktitle: Diagrammachse
type: docs
url: /de/androidjava/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
- Maximalwert
- Minimalwert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie Aspose.Slides für Android über Java verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Diagrammachsen mit Aspose.Slides für Android über Java anpasst. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagramm‑Zeilen und -Spalten, die Achsensichtbarkeit, Kategorien‑Label‑ und Tick‑Mark‑Intervalle, Datums‑Kategorien und -Formatierung, Titelrotation, Achsenpositionierung, Anzeige­einheiten und logarithmische Skalierung.

## **Ermitteln Sie die Maximalwerte auf der vertikalen Achse von Diagrammen**

Erstellen Sie eine [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) auf, bevor Sie berechnete Achsenwerte auslesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) und [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) für die Achsen­grenzen sowie [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) und [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) für die Tick‑Intervalle. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) und [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) liefern Zeiteinheiten‑Skalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Daten zwischen Achsen austauschen**

Verwenden Sie [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) , um die Rollen von Reihen und Kategorien in Diagrammdaten zu vertauschen. Jede ehemalige Kategorie wird zu einer Reihe und jede ehemalige Reihe zu einer Kategorie. Dies ändert die Gruppierung der Daten; es vertauscht nicht die horizontale und vertikale Achse. Das Beispiel nutzt [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) , um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeile und der Kategorie‑Spalte, bevor Zeilen und Spalten vertauscht werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vertikale Achse für Liniendiagramme deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) mit `false` für die vertikale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Horizontale Achse für Liniendiagramme deaktivieren**

Rufen Sie [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) mit `false` für die horizontale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eine Kategorie‑Achse ändern**

Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) , um einen Datums‑ oder Text‑Kategorie‑Achsentyp auszuwählen. Dieses Beispiel benötigt `ExistingChart.pptx`, wobei das Diagramm das erste Shape auf der ersten Folie ist und die Kategoriezellen numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Durch Aufruf von [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) mit `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) mit `1` und [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) mit `TimeUnitType.Months` werden Hauptticks im Abstand von einem Monat platziert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Intervall für Kategorie‑Achsen‑Label steuern**

Wenn ein Diagramm viele Kategorien hat, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Rufen Sie [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) mit `false` auf und übergeben Sie dann das gewünschte Kategorienintervall an [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwei Beschriftungen zwischen den angezeigten verborgen. Es entfernt nicht die entsprechenden Spalten. Das automatische Abstandswählen wählt ein Intervall basierend auf dem verfügbaren Platz; es zeigt nicht zwingend jede Beschriftung an.

Tick‑Marks haben separate Steuerungen. Rufen Sie [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) mit `false` auf und verwenden Sie [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) , um ihr Intervall festzulegen. Zum Beispiel hält `1` einen Tick‑Mark bei jedem Kategorienintervall, während Beschriftungen nur jede dritte Kategorie erscheinen. Verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) mit einem sichtbaren Stil, damit Sie das Ergebnis sehen können. Wenn Sie einen der automatischen Abstand‑Setzer erneut mit `true` aufrufen, lässt das Diagramm das Intervall wieder selbst wählen.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Reihe, speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatischer Abstand, manueller Beschriftungsabstand mit unabhängigen Tick‑Marks und wiederhergestellter automatischer Abstand. Die beiden Kopien enthalten die ursprünglichen Diagrammdaten. Keine Eingabe‑Präsentation ist erforderlich. Der horizontale Beschriftungstext macht den Unterschied in der Dichte leicht erkennbar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Folie 2: jede dritte Beschriftung anzeigen, aber für jede Kategorie einen Tick-Mark beibehalten.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Folie 3: das Diagramm beide Intervalle erneut auswählen lassen.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatischer Abstand (Folie 1):** Bei dieser Darstellung wird jede zweite Kategorienbeschriftung angezeigt und auf zwei Zeilen umgebrochen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Abstand der Kategorienbeschriftungen bei allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Tick‑Marks bei jedem Kategorienintervall bleiben. Alle 24 Spalten, einschließlich der ohne Beschriftungen, bleiben mit denselben Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Aussehen wieder her.

![Manueller Kategorienbeschriftungsintervall von drei bei allen 24 Spalten sichtbar](category-axis-manual.png)

### **Wählen Sie die richtige Achse und das Intervall**

Verwenden Sie dieses Kategorien‑Zähl‑Intervall für eine Text‑Kategorie‑Achse, z. B. die Kategorie‑Achse eines Säulen‑, Linien‑, Flächen- oder Balkendiagramms. In einem Säulendiagramm ist sie die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorie‑Achse vertikal, sodass Sie diese Einstellungen auf die Achse anwenden, die von [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) zurückgegeben wird. Der Abstand von Tick‑Marks gilt auch für eine Reihen‑Achse in Diagrammen, die eine solche besitzen.

Verwenden Sie den Kategorien‑Label‑Abstand nicht, um die numerische Skala einer Werte‑Achse zu setzen. Auf einer Werte‑Achse legt [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) einen Unterschied in den Werten fest: Zum Beispiel erzeugt eine Haupteinheit von `10` Ticks bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Label‑Intervall von `3` zählt dagegen die Positionen der Kategorien, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Werte‑Achsen anstelle einer Text‑Kategorie‑Achse. Für eine Datumsachse verwenden Sie zeitbasierte Haupteinheiten und Skalen, wie im Abschnitt [Change a Category Axis](#change-a-category-axis) beschrieben.

## **Datumsformat für Kategorie‑Achsenwerte festlegen**

Das Beispiel ersetzt die Standarddiagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert, berechnet als die Anzahl der Tage seit dem 30. Dezember 1899 für diese Daten. Beide Kalender verwenden UTC und werden vor dem Setzen der Daten zurückgesetzt, sodass Sommerzeit und die aktuelle Tageszeit die Berechnung nicht beeinflussen. Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) mit `CategoryAxisType.Date`, rufen Sie [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) mit `false` auf und übergeben Sie `yyyy` an [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) , damit die Kategorien‑Beschriftungen vierstellige Jahreszahlen unabhängig vom Zellenformat anzeigen.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Drehwinkel für einen Diagrammachsentitel festlegen**

Rufen Sie [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) mit `true` an der vertikalen Achse auf, geben Sie den Titeltext an und verwenden Sie [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) , um den Titel zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm mit einem um 90 Grad gedrehten Werte‑Achsentitel.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Achsenposition auf einer Kategorie‑ oder Werte‑Achse festlegen**

Verwenden Sie [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) , um zu steuern, ob die Werte‑Achse die Kategorie‑Achse zwischen Kategorien oder an den Kategorie‑Tick‑Marks schneidet. Diese Einstellung gilt für Kategorie‑Achsen. Das Beispiel setzt sie auf `true` bei der horizontalen Kategorie‑Achse eines Säulendiagramms und speichert das Ergebnis.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Anzeigeeinheit auf einer Diagramm‑Werte‑Achse festlegen**

Verwenden Sie [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) , um die Beschriftungen einer Werte‑Achse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) auf `Millions` gesetzt, wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeigeeinheit auf dessen vertikale Achse an.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Logarithmische Werte‑Achse konfigurieren**

Eine logarithmische Werte‑Achse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Zum Beispiel könnte ein Dienst über fünf Zeiträume 10, 100, 1 000, 10 000 und 100 000 Anfragen erhalten. Auf einer linearen Skala erscheinen die kleineren Werte dicht beieinander nahe Null. Eine logarithmische Skala erleichtert den Vergleich ihres relativen Wachstums: gleiche Abstände repräsentieren gleiche Verhältnisse statt gleicher Differenzen.

Rufen Sie [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) mit `true` an der Werte‑Achse auf und verwenden Sie [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) , um die Basis zu wählen. Dies ändert, wie die vorhandenen Werte angezeigt werden; es ändert nicht die Daten und fügt keine logarithmische Trendlinie hinzu. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Wählen Sie die Werte‑Achse und die Basis**

Bei einem Linien‑ oder Säulendiagramm wird die Werte‑Achse von [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) zurückgegeben. Bei einem horizontalen Balkendiagramm wird sie von [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) zurückgegeben. Streu‑ und Blasendiagramme haben zwei Werte‑Achsen, sodass Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide wählen. Wenden Sie die logarithmische Skalierung nicht auf eine Kategorie‑Achse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme verwenden Sie eine Basis zwischen `2` und `1000` (einschließlich); Bruchbasen wie `2.5` werden ebenfalls unterstützt. Mit Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragen‑Zahlen auf der ersten Folie, dupliziert diese Folie und aktiviert auf der zweiten eine logarithmische Werte‑Achse zur Basis 10. Beide Folien behalten dieselben Daten bei.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Die erste Folie linear lassen und nur die Wertachsen‑Skala der Kopie ändern.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lineare Skalierung (Folie 1):** Gleiche vertikale Abstände entsprechen gleichen Unterschieden in den Anfragen‑Zahlen. Der größte Wert dominiert das Diagramm, wodurch die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint, das fünf Anfragen‑Zahlen auf einer linearen Werte‑Achse zeigt](value-axis-linear.png)

**Logarithmische Skalierung (Folie 2):** Gleiche vertikale Abstände entsprechen gleichen Verhältnissen. Jede Periode hat zehnmal so viele Anfragen wie die vorherige, sodass die Punkte auf der Basis‑10‑Skala eine gerade ansteigende Linie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anfragen‑Zahlen.

![Die gleichen fünf Anfragen‑Zahlen in PowerPoint auf einer logarithmischen Werte‑Achse zur Basis 10](value-axis-logarithmic.png)

### **Umgang mit Null‑ und Negativwerten**

Eine logarithmische Skala kann nur strikt positive Werte anzeigen. Prüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte bedeutungsvoll sind, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat an. Wenn das Ausschließen dieser Werte für die Analyse sinnvoll ist, erklären Sie die Auslassung. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Bedeutung der Daten verändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert einer logarithmischen Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Verwenden Sie [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) , um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, benutzen Sie [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) . Diese Einstellungen ermöglichen es Ihnen, das Achsenkreuz an einen geeigneten Basiswert zu verschieben.

**Wie kann ich Tick‑Beschriftungen relativ zur Achse positionieren?**

Rufen Sie [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) unter Verwendung von [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) : `Low`, `High`, `NextTo` oder `None` auf. Um die Tick‑Marks selbst zu steuern, verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) oder [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) ; diese sind von der Beschriftungspositionierung getrennt.