---
title: Diagrammachsen in Präsentationen unter Android anpassen
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

Dieser Artikel erklärt, wie man Diagrammachsen mit Aspose.Slides für Android über Java anpasst. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammzeilen und -spalten, die Sichtbarkeit von Achsen, Intervall von Kategorienbeschriftungen und Tick‑Marken, Datums­kategorien und deren Formatierung, die Drehung von Titeln, die Positionierung von Achsen, Anzeige­einheiten und logarithmische Skalierung.

## **Maximalwerte auf der vertikalen Achse von Diagrammen erhalten**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) auf, bevor Sie berechnete Achsenwerte auslesen, damit das Diagrammlayout auf dem neuesten Stand ist.

Lesen Sie [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) und [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) für die Achsenbegrenzungen und [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) sowie [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) für die Tick‑Intervalle. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) und [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) liefern Zeiteinheiten‑Skalen, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

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

Verwenden Sie [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) , um die Rollen von Reihen und Kategorien in Diagrammdaten auszutauschen. Jede frühere Kategorie wird zu einer Reihe und jede frühere Reihe zu einer Kategorie. Dies ändert die Gruppierung der Daten; die horizontalen und vertikalen Achsen werden nicht vertauscht. Das Beispiel nutzt [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) , um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich der Kopfzeile und der Kategorie‑Spalte, bevor Zeilen und Spalten getauscht werden. Es speichert ein Diagramm mit vier Reihen und drei Kategorien.

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

## **Plotreihenfolge einer Achse umkehren**

Verwenden Sie [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) , um eine Kategorien‑ oder Werteachse umzukehren. Beispielsweise kann ein horizontales Balkendiagramm Projektphasen von oben nach unten in derselben Reihenfolge wie das Arbeitsblatt anzeigen: Planung, Entwicklung, Testen. Das Umkehren einer Achse ändert die Plot‑Richtung; sie sortiert oder rearrangiert die Arbeitsmappendaten nicht. Im Vergleich dazu tauscht [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) die Rollen von Reihen und Kategorien aus.

Das folgende Beispiel erstellt ein horizontales Balkendiagramm mit drei Phasen und einer Reihe. Es speichert eine Präsentation mit drei Folien: normale Reihenfolge, umgekehrte Kategorien und umgekehrte Werte. Jede Kopie verwendet denselben Datensatz, und in jeder Kopie ist nur eine Achse umgekehrt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Folie 2: Zeige die erste Kategorie oben an.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Behalte die horizontale Werteachse unten.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Folie 3: Drehe nur die horizontale numerische Skala um.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Umkehren einer Achse kann auch die senkrechte Achse auf die gegenüberliegende Seite des Diagramms verschieben. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) steuert, wo die andere Achse die konfigurierten Achse schneidet. In Folie 2 bewirkt ein Aufruf mit `CrossesType.Maximum` auf der umgekehrten Kategorienachse, dass die horizontale Werteachse unten bleibt. Für einen bestimmten Schnittpunkt verwenden Sie [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Überprüfen Sie die Schnitt‑Einstellungen beim Ändern der Richtung, insbesondere wenn das Diagramm bereits einen benutzerdefinierten Schnittpunkt besitzt. Rufen Sie `setPlotOrderReversed` mit `false` auf, um die normale Plot‑Richtung wiederherzustellen; die Schnitt‑Einstellungen sind separat.

| Normale Reihenfolge (Folie 1) | Umgekehrte Kategorien (Folie 2) | Umgekehrte Werte (Folie 3) |
| --- | --- | --- |
| ![Horizontales Balkendiagramm mit normaler Kategorien‑ und Werteachsenreihenfolge](axis-order-normal.png) | ![Horizontales Balkendiagramm mit von oben nach unten angezeigten Kategorien](axis-order-categories-reversed.png) | ![Horizontales Balkendiagramm mit umgekehrter Werteachse und Null rechts](axis-order-values-reversed.png) |
| Kategorien laufen von unten nach oben; Werte steigen von links nach rechts. | Planung, Entwicklung und Testen laufen von oben nach unten. Werte und Reihenfolge der Arbeitsmappendaten bleiben unverändert. | Kategorien behalten ihre normale Reihenfolge bei; Werte steigen von rechts nach links. Die Kategorienachse schneidet bei Null rechts. |

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

## **Kategorienachse ändern**

Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) , um eine Datums‑ oder Text‑Kategorienachse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm das erste Shape auf der ersten Folie ist und die Zellen der Kategorie numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Ein Aufruf von [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) mit `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) mit `1` und [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) mit `TimeUnitType.Months` legt Hauptticks im Abstand von einem Monat fest.

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

## **Intervall für Kategorienachsen‑Beschriftungen steuern**

Wenn ein Diagramm viele Kategorien enthält, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Rufen Sie [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) mit `false` auf und übergeben Sie dann das gewünschte Kategorienintervall an [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt zwischen den angezeigten Beschriftungen zwei ausgeblendet. Es entfernt die entsprechenden Spalten nicht. Automatischer Abstand wählt ein Intervall basierend auf dem verfügbaren Platz; er zeigt nicht zwingend jede Beschriftung an.

Tick‑Marks haben separate Steuerungen. Rufen Sie [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) mit `false` auf und verwenden Sie [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) , um ihr Intervall festzulegen. Beispielsweise sorgt `1` dafür, dass bei jedem Kategorienintervall ein Tick‑Mark gesetzt wird, während Beschriftungen nur bei jeder dritten Kategorie erscheinen. Verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) mit einem sichtbaren Stil, damit Sie das Ergebnis sehen können. Wenn einer der automatischen Abstand‑Setter wieder mit `true` aufgerufen wird, lässt das Diagramm das Intervall erneut automatisch wählen.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Reihe und speichert anschließend drei Folien in `CategoryAxisIntervals.pptx`: automatischer Abstand, manueller Beschriftungsabstand mit unabhängigen Tick‑Marks und wiederhergestellter automatischer Abstand. Die beiden Kopien behalten die ursprünglichen Diagrammdaten bei. Keine Eingabepräsentation ist erforderlich. Der horizontale Beschriftungstext macht den Unterschied in der Dichte leicht erkennbar.

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

    // Folie 2: Zeige jede dritte Beschriftung, aber behalte für jede Kategorie einen Tick-Mark bei.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Folie 3: Lassen Sie das Diagramm beide Intervalle erneut auswählen.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatischer Abstand (Folie 1):** In dieser Darstellung wird jede zweite Kategorienbeschriftung angezeigt und auf zwei Zeilen umgebrochen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Kategorienbeschriftungsabstand mit allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Tick‑Marks bei jedem Kategorienintervall verbleiben. Alle 24 Spalten, einschließlich der ohne Beschriftungen, bleiben mit den gleichen Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Erscheinungsbild wieder her.

![Manueller Kategorienbeschriftungsintervall von drei mit allen 24 Spalten sichtbar](category-axis-manual.png)

### **Die richtige Achse und das richtige Intervall wählen**

Verwenden Sie dieses Kategorien‑Zähl‑Intervall für eine Text‑Kategorienachse, z. B. die Kategorienachse eines Säulen‑, Linien‑, Flächen‑ oder Balkendiagramms. In einem Säulendiagramm ist sie die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, daher wenden Sie diese Einstellungen auf die Achse an, die von [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) zurückgegeben wird. Der Tick‑Mark‑Abstand gilt ebenfalls für eine Serienachse in Diagrammen, die eine besitzen.

Verwenden Sie den Kategorien‑Beschriftungsabstand nicht, um die numerische Skala einer Werteachse festzulegen. Auf einer Werteachse gibt [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) eine Differenz der Werte an: Ein Hauptintervall von `10` erzeugt beispielsweise Ticks bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungsintervall von `3` zählt dagegen Kategorienpositionen, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitbasierte Haupteinheiten und Skalen, wie in [Change a Category Axis](#change-a-category-axis) beschrieben.

## **Datumsformat für Kategorienachsen‑Werte festlegen**

Das Beispiel ersetzt die Standarddiagrammdaten durch vier Jahreswerte. Daten werden als OLE‑Automation‑Seriennummern im ersten Arbeitsblatt (Index `0`) gespeichert, berechnet als die Anzahl der Tage seit dem 30. Dezember 1899 für diese Daten. Beide Kalender verwenden UTC und werden vor dem Setzen der Daten zurückgesetzt, sodass Sommerzeit und die aktuelle Uhrzeit die Berechnung nicht beeinflussen. Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) mit `CategoryAxisType.Date`, rufen Sie [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) mit `false` auf und übergeben Sie `yyyy` an [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), damit die Kategorienbeschriftungen vierstellige Jahreszahlen unabhängig von der Zellenformatierung anzeigen.

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

## **Drehwinkel für den Diagrammachsentitel festlegen**

Rufen Sie [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) mit `true` für die vertikale Achse auf, geben Sie den Titeltext an und verwenden Sie [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) , um den Titel zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm mit einem um 90 Grad gedrehten Werteachsentitel.

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

## **Achsenposition bei einer Kategorien‑ oder Werteachse festlegen**

Verwenden Sie [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) , um zu steuern, ob die Werteachse die Kategorienachse zwischen den Kategorien oder an den Kategorien‑Tick‑Marks schneidet. Diese Einstellung gilt für Kategorienachsen. Das Beispiel setzt sie auf `true` bei der horizontalen Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

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

## **Anzeigeeinheit einer Diagramm‑Werteachse festlegen**

Verwenden Sie [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) , um die Beschriftungen einer Werteachse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) auf `Millions` gesetzt wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeigeeinheit auf seine vertikale Achse an.

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

## **Logarithmische Werteachse konfigurieren**

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Beispielsweise könnte ein Dienst über fünf Zeiträume 10, 100, 1 000, 10 000 und 100 000 Anfragen erhalten. Bei einer linearen Skala erscheinen die kleineren Werte dicht beieinander nahe Null. Eine logarithmische Skala erleichtert den Vergleich ihres relativen Wachstums: gleiche Abstände repräsentieren gleiche Verhältnisse statt gleicher Differenzen.

Rufen Sie [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) mit `true` für die Werteachse auf und verwenden Sie [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) , um die Basis zu wählen. Dadurch wird die Darstellung der vorhandenen Werte geändert; die Daten werden nicht geändert und es wird keine logarithmische Trendlinie hinzugefügt. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist eine separate Funktion.

### **Werteachse und Basis wählen**

Bei einem Linien‑ oder Säulendiagramm wird die Werteachse von [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) zurückgegeben. Bei einem horizontalen Balkendiagramm wird sie von [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) zurückgegeben. Streu‑ und Blasendiagramme besitzen zwei Werteachsen, daher wählen Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide. Wenden Sie keine logarithmische Skalierung auf eine Kategorienachse an.

Die Standard‑logarithmische Basis ist `10`. Für PPTX‑Diagramme verwenden Sie eine Basis von `2` bis `1000` (einschließlich); Bruchbasen wie `2.5` werden ebenfalls unterstützt. Mit Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anfragenzahlen auf der ersten Folie, dupliziert diese Folie und aktiviert auf der zweiten eine logarithmische Werteachse mit Basis 10. Beide Folien behalten dieselben Daten.

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

    // Behalte die erste Folie linear und ändere nur die Skala der Werteachse der Kopie.
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

**Lineare Skala (Folie 1):** Gleiche vertikale Abstände stehen für gleiche Unterschiede in den Anfragenzahlen. Der größte Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint mit fünf Anfragenzahlen auf einer linearen Werteachse](value-axis-linear.png)

**Logarithmische Skala (Folie 2):** Gleiche vertikale Abstände stehen für gleiche Verhältnisse. Jeder Zeitraum hat zehnmal so viele Anfragen wie der vorherige, sodass die Punkte auf der Basis‑10‑Skala eine gerade steigende Linie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anfragenzahlen.

![Die gleichen fünf Anfragenzahlen in PowerPoint auf einer logarithmischen Werteachse mit Basis 10](value-axis-logarithmic.png)

### **Umgang mit Null‑ und Negativwerten**

Eine logarithmische Skala kann nur strikt positive Werte anzeigen. Prüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte sinnvoll sind, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat. Wenn das Ausschließen dieser Werte für die Analyse geeignet ist, erklären Sie das Weglassen. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Bedeutung der Daten ändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert für eine logarithmische Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Verwenden Sie [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) , um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, verwenden Sie [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Diese Einstellungen ermöglichen es Ihnen, den Achsenkreuzungspunkt auf eine geeignete Basislinie zu verschieben.

**Wie kann ich Tick‑Beschriftungen relativ zur Achse positionieren?**

Rufen Sie [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) unter Verwendung von [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) auf: `Low`, `High`, `NextTo` oder `None`. Um die Tick‑Marks selbst zu steuern, verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) oder [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); diese sind unabhängig von der Positionierung der Beschriftungen.