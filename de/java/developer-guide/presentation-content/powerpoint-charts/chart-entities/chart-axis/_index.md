---
title: Diagrammachsen in Präsentationen mit Java anpassen
linktitle: Diagrammachse
type: docs
url: /de/java/chart-axis/
keywords:
- Diagrammachse
- Vertikale Achse
- Horizontale Achse
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
- Java
- Aspose.Slides
description: "Entdecken Sie, wie Sie Aspose.Slides für Java verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Diagrammachsen mit Aspose.Slides für Java anpasst. Er behandelt berechnete Achsenwerte, das Vertauschen von Diagrammzeilen und -spalten, Achsensichtbarkeit, Kategorie‑Beschriftungs‑ und Teilstrich‑Intervalle, Datums‑Kategorien und -Formatierung, Titelrotation, Achsenpositionierung, Anzeige­einheiten und logarithmische Skalierung.

## **Maximale Werte auf der vertikalen Achse bei Diagrammen ermitteln**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und fügen Sie ein Flächendiagramm mit Standarddaten hinzu. Rufen Sie [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) auf, bevor Sie berechnete Achsenwerte auslesen, damit das Diagrammlayout aktuell ist.

Lesen Sie [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) und [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) für die Achsenbegrenzungen sowie [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) und [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) für die Teilstrich‑Intervalle. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) und [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) geben Zeiteinheiten‑Skalen zurück, die für Datumsachsen relevant sind. Das Beispiel speichert diese Werte in lokalen Variablen und speichert das Diagramm.

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

Verwenden Sie [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) , um die Rollen von Reihen und Spalten in Diagrammdaten zu vertauschen. Jede ehemalige Kategorie wird zu einer Serie und jede ehemalige Serie zu einer Kategorie. Dies ändert die Gruppierung der Daten; die horizontalen und vertikalen Achsen werden nicht vertauscht. Das Beispiel nutzt [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) , um die Standarddaten an `Sheet1!A1:D5` zu binden, einschließlich Kopfzeile und Kategoriespalte, bevor Zeilen und Spalten vertauscht werden. Es speichert ein Diagramm mit vier Serien und drei Kategorien.

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

Rufen Sie [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) mit `false` für die vertikale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter vertikaler Achse.

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

Rufen Sie [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) mit `false` für die horizontale Achse auf, um sie auszublenden. Das Beispiel erstellt ein Liniendiagramm mit Standarddaten und speichert es mit ausgeblendeter horizontaler Achse.

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

## **Eine Kategorienachse ändern**

Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) , um eine Datums‑ oder Text‑Kategorienachse auszuwählen. Dieses Beispiel erfordert `ExistingChart.pptx`, wobei das Diagramm das erste Shape auf der ersten Folie ist und die Kategoriespalten numerische Excel‑Datumswerte enthalten. Es ändert die horizontale Achse zu einer Datumsachse. Durch Aufruf von [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) mit `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) mit `1` und [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) mit `TimeUnitType.Months` werden Hauptteilstriche im Abstand von einem Monat gesetzt.

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

## **Kategorieachsen‑Beschriftungs‑Intervalle steuern**

Wenn ein Diagramm viele Kategorien enthält, reduzieren Sie die Anzahl sichtbarer Achsenbeschriftungen, ohne Kategorien oder Datenpunkte zu entfernen. Rufen Sie [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) mit `false` auf und übergeben Sie das gewünschte Kategorie‑Intervall an [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Für Textkategorien in ihrer normalen Reihenfolge beginnt die Zählung bei der ersten Kategorie:

| Intervall | Im Beispiel angezeigte Beschriftungen |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Ein Intervall von `3` zeigt jede dritte Beschriftung an und lässt jeweils zwei Beschriftungen zwischen den angezeigten verborgen. Es werden keine zugehörigen Spalten entfernt. Automatischer Abstand wählt ein Intervall basierend auf dem verfügbaren Platz; er zeigt nicht zwangsläufig jede Beschriftung an.

Teilstriche verfügen über separate Steuerelemente. Rufen Sie [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) mit `false` auf und nutzen Sie [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-), um ihr Intervall festzulegen. Beispielsweise hält `1` einen Teilstrich bei jedem Kategorie‑Intervall, während Beschriftungen nur jede dritte Kategorie erscheinen. Verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) mit einem sichtbaren Stil, damit Sie das Ergebnis sehen können. Durch erneutes Setzen eines automatischen Abstandes mit `true` lässt das Diagramm das Intervall erneut bestimmen.

Das folgende eigenständige Beispiel erstellt 24 Kategorien und eine Serie, speichert dann drei Folien in `CategoryAxisIntervals.pptx`: automatischer Abstand, manueller Beschriftungsabstand mit unabhängigen Teilstrichen und wiederhergestellter automatischer Abstand. Die beiden Kopien behalten die ursprünglichen Diagrammdaten. Keine Eingabe‑Präsentation ist erforderlich. Der horizontale Beschriftungstext macht den Unterschied in der Dichte leicht erkennbar.

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

    // Folie 2: jede dritte Beschriftung anzeigen, aber einen Teilstrich für jede Kategorie beibehalten.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Folie 3: das Diagramm beide Intervalle erneut wählen lassen.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatischer Abstand (Folie 1):** In dieser Darstellung wird jede zweite Kategorien­beschriftung angezeigt und auf zwei Zeilen umgebrochen. Das automatische Ergebnis kann je nach Diagrammgröße, Schriftarten und Renderer variieren.

![Automatischer Kategorie‑Beschriftungsabstand mit allen 24 Spalten sichtbar](category-axis-automatic.png)

**Manueller Abstand (Folie 2):** Jede dritte Beschriftung wird in einer Zeile angezeigt, während Teilstriche bei jedem Kategorie‑Intervall verbleiben. Alle 24 Spalten, einschließlich derjenigen ohne Beschriftungen, bleiben mit den gleichen Werten sichtbar. Folie 3 stellt das oben gezeigte automatische Aussehen wieder her.

![Manueller Kategorie‑Beschriftungsintervall von drei mit allen 24 Spalten sichtbar](category-axis-manual.png)

### **Die richtige Achse und das Intervall auswählen**

Verwenden Sie dieses Kategorien‑Zähl‑Intervall für eine Text‑Kategorienachse, etwa bei der Kategorienachse von Säulen‑, Linien‑, Flächen‑ oder Balkendiagrammen. In einem Säulendiagramm ist sie die horizontale Achse. In einem horizontalen Balkendiagramm ist die Kategorienachse vertikal, sodass diese Einstellungen auf die Achse angewendet werden, die von [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) zurückgegeben wird. Der Teilstrich‑Abstand gilt auch für eine Serienachse in Diagrammen, die eine solche besitzen.

Verwenden Sie den Kategorien‑Beschriftungs‑Abstand nicht, um die numerische Skala einer Werteachse festzulegen. Auf einer Werteachse gibt [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) einen Unterschied in den Werten an: Zum Beispiel erzeugt eine Haupteinheit von `10` Teilstriche bei 0, 10, 20 usw., wenn die Achse bei Null beginnt. Ein Kategorien‑Beschriftungs‑Intervall von `3` zählt dagegen Kategorienpositionen, unabhängig von deren Datenwerten. Streu‑ und Blasendiagramme verwenden Werteachsen statt einer Text‑Kategorienachse. Für eine Datumsachse verwenden Sie zeitbasierte Haupteinheiten und Skalen, wie in [Eine Kategorienachse ändern](#change-a-category-axis) beschrieben.

## **Datumsformat für Kategorienachsenwerte festlegen**

Das Beispiel ersetzt die Standarddiagrammdaten durch vier Jahreswerte. Datumswerte werden als OLE‑Automation‑Seriennummern im ersten Tabellenblatt (Index `0`) gespeichert, berechnet als Anzahl der Tage seit dem 30. Dezember 1899. Verwenden Sie [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) mit `CategoryAxisType.Date`, rufen Sie [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) mit `false` auf und übergeben Sie `yyyy` an [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-), damit die Kategorienbeschriftungen vierstellige Jahreszahlen unabhängig von der Zellenformatierung anzeigen.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
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

Rufen Sie [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) mit `true` für die vertikale Achse auf, geben Sie den Titeltext an und verwenden Sie [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) , um den Titel zu drehen. Der Winkel wird in Grad gemessen; dieses Beispiel speichert ein Säulendiagramm mit um 90 Grad rotiertem Wertachsentitel.

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

## **Achsenposition für eine Kategorie‑ oder Werteachse festlegen**

Verwenden Sie [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-), um zu steuern, ob die Werteachse die Kategorienachse zwischen Kategorien oder an Kategorien‑Teilstrichen kreuzt. Diese Einstellung gilt für Kategorienachsen. Das Beispiel setzt sie auf `true` für die horizontale Kategorienachse eines Säulendiagramms und speichert das Ergebnis.

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

## **Anzeige­einheit auf einer Werteachse festlegen**

Verwenden Sie [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-), um die Beschriftungen einer Werteachse zu skalieren, ohne die zugrunde liegenden Daten zu ändern. Mit [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) auf `Millions` wird ein Wert von 60 000 000 als 60 angezeigt. Das Beispiel erstellt ein Säulendiagramm und wendet die Millionen‑Anzeige­einheit auf seine vertikale Achse an.

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

Eine logarithmische Werteachse ist nützlich, wenn positive Werte mehrere Größenordnungen umfassen. Zum Beispiel kann ein Dienst über fünf Zeitabschnitte 10, 100, 1 000, 10 000 und 100 000 Anfragen erhalten. Auf einer linearen Skala erscheinen die kleineren Werte nahe beieinander bei Null. Eine logarithmische Skala erleichtert den Vergleich ihres relativen Wachstums: gleiche Abstände repräsentieren gleiche Verhältnisse statt gleicher Differenzen.

Rufen Sie [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) mit `true` für die Werteachse auf und verwenden Sie [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-), um die Basis zu wählen. Dadurch ändert sich die Darstellung der vorhandenen Werte; die Daten werden nicht geändert und es wird keine logarithmische Trendlinie hinzugefügt. Eine Trendlinie stellt eine angepasste Beziehung in den Daten dar und ist ein separates Feature.

### **Werteachse und Basis auswählen**

Bei einem Linien‑ oder Säulendiagramm wird die Werteachse von [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) zurückgegeben. Bei einem horizontalen Balkendiagramm von [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Streu‑ und Blasendiagramme besitzen zwei Werteachsen, sodass Sie die horizontale Achse für X‑Werte, die vertikale Achse für Y‑Werte oder beide wählen. Wenden Sie keine logarithmische Skalierung auf eine Kategorienachse an.

Die Standard‑Logarithmus‑Basis ist `10`. Für PPTX‑Diagramme verwenden Sie eine Basis von `2` bis `1000` (einschließlich); gebrochene Basen wie `2.5` werden ebenfalls unterstützt. Mit Basis `10` sind aufeinanderfolgende Potenzen wie 10, 100, 1 000 und 10 000 gleichmäßig verteilt.

### **Lineare und logarithmische Skalierung vergleichen**

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit den fünf Anforderungszahlen auf der ersten Folie, dupliziert diese Folie und aktiviert auf der zweiten eine logarithmische Werteachse mit Basis 10. Beide Folien behalten dieselben Daten.

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

    // Behalte die erste Folie linear und ändere nur die Skalierung der Wertachse der Kopie.
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

**Lineare Skalierung (Folie 1):** Gleiche vertikale Abstände stehen für gleiche Differenzen der Anforderungszahlen. Der größte Wert dominiert das Diagramm, sodass die kleineren Werte schwer zu unterscheiden sind.

![Liniendiagramm in PowerPoint, das fünf Anforderungszahlen auf einer linearen Werteachse zeigt](value-axis-linear.png)

**Logarithmische Skalierung (Folie 2):** Gleiche vertikale Abstände stehen für gleiche Verhältnisse. Jede Periode hat zehnmal so viele Anfragen wie die vorherige, sodass die Punkte auf einer Basis‑10‑Skala eine gerade ansteigende Linie bilden. Die Achsenbeschriftungen zeigen weiterhin die ursprünglichen Anforderungszahlen.

![Die gleichen fünf Anforderungszahlen in PowerPoint auf einer logarithmischen Werteachse mit Basis 10](value-axis-logarithmic.png)

### **Umgang mit Null‑ und Negativwerten**

Eine logarithmische Skala kann ausschließlich streng positive Werte anzeigen. Überprüfen Sie die Daten, bevor Sie sie aktivieren. Wenn Null‑ oder Negativwerte bedeutungsvoll sind, behalten Sie eine lineare Skala bei oder zeigen Sie sie separat an. Wenn das Ausschließen dieser Werte für die Analyse sinnvoll ist, erläutern Sie das Weglassen. Ersetzen Sie sie nicht stillschweigend durch kleine positive Zahlen, da dies die Datenbedeutung ändert. Jeder manuell konfigurierte Minimal‑ oder Maximalwert einer logarithmischen Achse muss ebenfalls positiv sein.

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Verwenden Sie [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-), um das Kreuzungsverhalten auszuwählen. Um einen numerischen Kreuzungswert anzugeben, nutzen Sie [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Diese Einstellungen ermöglichen es Ihnen, die Achsenkreuzung an eine passende Basis zu verschieben.

**Wie kann ich Teilstrich‑Beschriftungen relativ zur Achse positionieren?**

Rufen Sie [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) mit einem der Werte aus [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` oder `None` auf. Um die Teilstriche selbst zu steuern, verwenden Sie [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) oder [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); diese sind von der Beschriftungspositionierung getrennt.