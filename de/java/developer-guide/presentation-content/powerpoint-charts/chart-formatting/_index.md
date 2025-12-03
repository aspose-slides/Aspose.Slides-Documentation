---
title: Diagramme in Java formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/java/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schriftarteigenschaften
- Abgerundete Rahmen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie mehr über die Diagrammformatierung in Aspose.Slides für Java und verbessern Sie Ihre PowerPoint-Präsentation mit professionellem, ansprechendem Design."
---

## **Diagramm‑Entitäten formatieren**
Aspose.Slides for Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten formatiert werden, einschließlich Kategorien‑ und Werte‑Achse.

Aspose.Slides for Java bietet eine einfache API zum Verwalten verschiedener Diagramm‑Entitäten und zum Formatieren mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Folien‑Verweis anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. **Line format** für Hauptgitternetzlinien der Werte‑Achse festlegen
   1. **Line format** für Neben­gitternetzlinien der Werte‑Achse festlegen
   1. **Number Format** für die Werte‑Achse festlegen
   1. **Min, Max, Major and Minor units** für die Werte‑Achse festlegen
   1. **Text Properties** für die Werte‑Achsendaten festlegen
   1. **Title** für die Werte‑Achse festlegen
   1. **Line Format** für die Werte‑Achse festlegen
1. Greifen Sie auf die Kategorien‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. **Line format** für Hauptgitternetzlinien der Kategorien‑Achse festlegen
   1. **Line format** für Neben­gitternetzlinien der Kategorien‑Achse festlegen
   1. **Text Properties** für die Kategorien‑Achsendaten festlegen
   1. **Title** für die Kategorien‑Achse festlegen
   1. **Label Positioning** für die Kategorien‑Achse festlegen
   1. **Rotation Angle** für die Kategorien‑Achsen‑Beschriftungen festlegen
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Properties** dafür
1. Legenden des Diagramms anzeigen, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Sekundäre **Value Axis** aktivieren
   1. **Line Format** für die sekundäre Werte‑Achse festlegen
   1. **Number Format** für die sekundäre Werte‑Achse festlegen
   1. **Min, Max, Major and Minor units** für die sekundäre Werte‑Achse festlegen
1. Plotten Sie nun die erste Diagramm‑Serie auf der sekundären Werte‑Achse
1. Setzen Sie die Füllfarbe der Rückwand des Diagramms
1. Setzen Sie die Füllfarbe des Diagramm‑Plot‑Bereichs
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Beispielfragment hinzufügen
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Diagrammtitel festlegen
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Format der Hauptgitternetzlinien für die Werte‑Achse festlegen
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Format der Nebengitternetzlinien für die Werte‑Achse festlegen
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Zahlenformat für die Werte‑Achse festlegen
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Diagramm‑Maximal‑ und Minimalwerte festlegen
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Text‑Eigenschaften der Werte‑Achse festlegen
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Titel der Werte‑Achse festlegen
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Format der Hauptgitternetzlinien für die Kategorie‑Achse festlegen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Format der Nebengitternetzlinien für die Kategorie‑Achse festlegen
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Text‑Eigenschaften der Kategorie‑Achse festlegen
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Titel der Kategorie‑Achse festlegen
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Beschriftungsposition der Kategorie‑Achse festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Drehwinkel der Beschriftung der Kategorie‑Achse festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Text‑Eigenschaften der Legenden festlegen
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Legenden anzeigen, ohne das Diagramm zu überlappen
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Sekundäre Werte‑Achse festlegen
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Zahlenformat der sekundären Werte‑Achse festlegen
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Diagramm‑Maximal‑ und Minimalwerte festlegen
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Rückwandfarbe des Diagramms festlegen
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Plot‑Bereichsfarbe festlegen
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Präsentation speichern
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftarteigenschaften für Diagramm festlegen**
Aspose.Slides for Java unterstützt das Festlegen von schriftspezifischen Eigenschaften für Diagramme. Bitte folgen Sie den nachstehenden Schritten, um die Schriftarteigenschaften für ein Diagramm festzulegen.

- Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Objekt.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Schriftgröße festlegen.
- Modifizierte Präsentation speichern.

Untenstehendes Beispiel wird angegeben.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Numerische Formate festlegen**
Aspose.Slides for Java bietet eine einfache API zum Verwalten von Diagramm‑Datenformaten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Klasse.
1. Holen Sie sich einen Folien‑Verweis anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Setzen Sie das voreingestellte Zahlenformat aus den möglichen voreingestellten Werten.
1. Durchlaufen Sie jede Datenzelle jeder Diagramm‑Serie und setzen Sie das Diagramm‑Daten‑Zahlenformat.
1. Präsentation speichern.
1. Benutzerdefiniertes Zahlenformat festlegen.
1. Durchlaufen Sie die Datenzellen jeder Diagramm‑Serie und setzen Sie ein unterschiedliches Diagramm‑Daten‑Zahlenformat.
1. Präsentation speichern.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Auf die erste Folie der Präsentation zugreifen
    ISlide slide = pres.getSlides().get_Item(0);

    // Standard-Clustered-Column-Diagramm hinzufügen
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Auf die Diagramm-Serien-Sammlung zugreifen
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Durch jede Diagramm-Serie iterieren
    for (IChartSeries ser : series) 
    {
        // Durch jede Datenzelle in der Serie iterieren
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Das Zahlenformat festlegen
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    // Präsentation speichern
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Die möglichen voreingestellten Zahlenformat‑Werte zusammen mit ihrem Index sind unten aufgeführt:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Rahmen für Diagrammbereich festlegen**
Aspose.Slides for Java unterstützt das Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) wurden dem Interface [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) und der Klasse [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart) hinzugefügt.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)‑Objekt.
1. Fügen Sie ein Diagramm zur Folie hinzu.
1. Fülltyp und Füllfarbe des Diagramms festlegen
1. Eigenschaft für abgerundete Ecken auf **True** setzen.
1. Modifizierte Präsentation speichern.

Untenstehendes Beispiel wird angegeben. 
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Bereiche festlegen und gleichzeitig die Kontur undurchsichtig lassen?**

Ja. Transparenz der Füllung und Kontur werden separat konfiguriert. Das ist nützlich, um die Lesbarkeit von Gittern und Daten in dichten Visualisierungen zu verbessern.

**Wie gehe ich mit Datenbeschriftungen um, wenn sie sich überlappen?**

Die Schriftgröße reduzieren, nicht wesentliche Beschriftungskomponenten deaktivieren (z. B. Kategorien), den Beschriftungs‑Offset/Position einstellen, Beschriftungen ggf. nur für ausgewählte Punkte anzeigen oder das Format zu „Wert + Legende“ wechseln.

**Kann ich Farbverlauf‑ oder Muster‑Füllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Muster‑Füllungen sind in der Regel verfügbar. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Gitter und zum Text verringern.