---
title: Diagramme in Python formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/python-java/chart-formatting/
keywords:
- diagramm formatieren
- diagrammformatierung
- diagramm-Entität
- diagrammeigenschaften
- diagrammeinstellungen
- diagrammoptionen
- schrifteigenschaften
- abgerundete rahmen
- PowerPoint
- präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme mit Aspose.Slides für Python via Java formatieren und verleihen Sie Ihrer PowerPoint-Präsentation ein professionelles, ansprechendes Design."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagramme in PowerPoint‑Präsentationen mithilfe von Aspose.Slides formatiert werden. Er zeigt, wie wichtige Diagrammelemente wie Achsen, Gitternetzlinien, Titel, Legenden, der Zeichenbereich und Wandfüllungen angepasst werden können, um das Aussehen und die Lesbarkeit der Diagrammdaten zu verbessern.

Außerdem wird demonstriert, wie Schriftarteigenschaften für Diagrammtext festgelegt, voreingestellte und benutzerdefinierte Zahlenformate auf Diagrammdaten angewendet und abgerundete Ecken für den Diagrammbereich aktiviert werden. Diese Beispiele zeigen, wie sowohl der visuelle Stil als auch die Datenpräsentation von Diagrammen in einer Präsentation gesteuert werden können.

## **Diagramm‑Entitäten formatieren**
Aspose.Slides for Python via Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten formatiert werden, einschließlich der Kategorie‑ und Werteachsen.

Aspose.Slides for Python via Java stellt eine einfache API zum Verwalten verschiedener Diagramm‑Entitäten und deren Formatierung mit benutzerdefinierten Werten bereit:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.  
1. Greifen Sie über den Index auf eine Folie zu.  
1. Fügen Sie ein Diagramm des gewünschten Typs mit Standarddaten hinzu (dieses Beispiel verwendet [ChartType.LineWithMarkers](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#LineWithMarkers)).  
1. Greifen Sie auf die Werteachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:  
   1. **Linienformat** für die Hauptgitternetzlinien der Werteachse festlegen.  
   1. **Linienformat** für die Untergitterlinien der Werteachse festlegen.  
   1. **Zahlenformat** für die Werteachse festlegen.  
   1. **Minimum, Maximum, Haupt‑ und Untereinheiten** für die Werteachse festlegen.  
   1. **Texteigenschaften** für die Daten der Werteachse festlegen.  
   1. **Titel** für die Werteachse festlegen.  
1. Greifen Sie auf die Kategorienachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:  
   1. **Linienformat** für die Hauptgitternetzlinien der Kategorienachse festlegen.  
   1. **Linienformat** für die Untergitterlinien der Kategorienachse festlegen.  
   1. **Texteigenschaften** für die Daten der Kategorienachse festlegen.  
   1. **Titel** für die Kategorienachse festlegen.  
   1. **Beschriftungspositionierung** für die Kategorienachse festlegen.  
   1. **Drehwinkel** für die Beschriftungen der Kategorienachse festlegen.  
1. Greifen Sie auf die Diagrammlegende zu und setzen Sie deren **Texteigenschaften**.  
1. Zeigen Sie die Diagrammlegende an, ohne das Diagramm zu überlappen.  
1. Greifen Sie auf die **sekundäre Werteachse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:  
   1. Die sekundäre **Werteachse** aktivieren.  
   1. **Linienformat** für die sekundäre Werteachse festlegen.  
   1. **Zahlenformat** für die sekundäre Werteachse festlegen.  
   1. **Minimum, Maximum, Haupt‑ und Untereinheiten** für die sekundäre Werteachse festlegen.  
1. Plotten Sie die erste Diagramm‑Serie auf der sekundären Werteachse.  
1. Setzen Sie die Füllfarbe der hinteren Wand des Diagramms.  
1. Setzen Sie die Füllfarbe des Zeichenbereichs des Diagramms.  
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Erstelle eine Instanz der Presentation-Klasse
presentation = Presentation()
try:
    # Greife auf die erste Folie zu
    slide = presentation.getSlides().get_Item(0)

    # Füge das Beispiel-Diagramm hinzu
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Diagrammtitel festlegen
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Format der Hauptgitternetzlinien für die Werteachse festlegen
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Format der Untergitternetzlinien für die Werteachse festlegen
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Zahlenformat der Werteachse festlegen
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Maximale und minimale Werte des Diagramms festlegen
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Texteigenschaften der Werteachse festlegen
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Titel der Werteachse festlegen
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Format der Hauptgitternetzlinien für die Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Format der Untergitternetzlinien für die Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Texteigenschaften der Kategorienachse festlegen
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Titel der Kategorie festlegen
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Position der Kategorienachsenbeschriftung festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Drehwinkel der Kategorienachsenbeschriftung festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Texteigenschaften der Legende festlegen
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Diagrammlegende anzeigen, ohne das Diagramm zu überlappen

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Sekundäre Werteachse festlegen
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Zahlenformat der sekundären Werteachse festlegen
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Maximale und minimale Werte des Diagramms festlegen
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Farbe der Diagramm‑Rückwand festlegen
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Farbe des Zeichenbereichs festlegen
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Präsentation speichern
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Schriftarteigenschaften für ein Diagramm festlegen**
Aspose.Slides for Python via Java unterstützt das Festlegen von Schriftarteigenschaften für Diagramme. Führen Sie die folgenden Schritte aus, um die Schriftarteigenschaften zu setzen:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.  
- Fügen Sie der Folie ein Diagramm hinzu.  
- Schriftgröße festlegen.  
- Die modifizierte Präsentation speichern.

Das folgende Beispiel demonstriert diese Schritte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

    # Erstelle eine Instanz der Presentation-Klasse
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zahlenformat festlegen**
Aspose.Slides for Python via Java bietet eine einfache API zum Verwalten von Diagrammdatenformaten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.  
1. Greifen Sie über den Index auf eine Folie zu.  
1. Fügen Sie ein Diagramm des gewünschten Typs mit Standarddaten hinzu (dieses Beispiel verwendet [ChartType.ClusteredColumn](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/#ClusteredColumn)).  
1. Das voreingestellte Zahlenformat aus den möglichen Vorgabewerten festlegen.  
1. Durchlaufen Sie die Datenzellen jeder Diagrammserie und setzen Sie deren Zahlenformat.  
1. Die Präsentation speichern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Erstelle eine Instanz der Presentation-Klasse
presentation = Presentation()
try:
    # Greife auf die erste Folie der Präsentation zu
    slide = presentation.getSlides().get_Item(0)

    # Füge ein Standard-Clustered-Column-Diagramm hinzu
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Greife auf die Diagramm-Serien-Sammlung zu
    chart_series_collection = chart.getChartData().getSeries()

    # Durchlaufe jede Diagrammserie
    for chart_series in chart_series_collection:
        # Durchlaufe jeden Datenpunkt in der Serie
        for data_point in chart_series.getDataPoints():
            # Setze das Zahlenformat
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Speichere die Präsentation
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die verfügbaren voreingestellten Zahlenformate und ihre Indizes sind unten aufgeführt:

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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Ränder für den Diagrammbereich festlegen**
Aspose.Slides for Python via Java unterstützt abgerundete Ecken für den Diagrammbereich über die Methoden [hasRoundedCorners](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#hasRoundedCorners) und [setRoundedCorners](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#setRoundedCorners) der [Chart](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/)‑Klasse.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.  
1. Fügen Sie der Folie ein Diagramm hinzu.  
1. Legen Sie den Fülltyp und den Stil der Diagrammrandlinie fest.  
1. Abgerundete Ecken aktivieren.  
1. Die modifizierte Präsentation speichern.

Das folgende Beispiel demonstriert diese Schritte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Erstelle eine Instanz der Presentation-Klasse
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Flächen festlegen und dabei die Kontur deckend lassen?**

Ja. Transparenz der Füllung und Kontur werden separat konfiguriert. Das ist nützlich, um die Lesbarkeit von Gittern und Daten in dichten Visualisierungen zu verbessern.

**Wie gehe ich mit überlappenden Datenbeschriftungen um?**

Verringern Sie die Schriftgröße, deaktivieren Sie nicht erforderliche Beschriftungskomponenten (z. B. Kategorien), passen Sie den Versatz/ die Position der Beschriftung an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie zum Format „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Musterfüllungen sind in der Regel verfügbar. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zu Gittern und Text verringern.