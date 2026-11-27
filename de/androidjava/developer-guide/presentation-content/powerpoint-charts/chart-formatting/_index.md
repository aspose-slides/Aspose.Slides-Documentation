---
title: Diagramme in Präsentationen auf Android formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/androidjava/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagramm-Eigenschaften
- Diagramm-Einstellungen
- Diagramm-Optionen
- Schrift-Eigenschaften
- Abgerundete Kontur
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für Android mit Java formatieren und verbessern Sie Ihre PowerPoint-Präsentation mit benutzerdefinierten Achsen, Schriften, Zahlenformaten und abgerundeten Diagramm-Konturen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagramme in PowerPoint‑Präsentationen mit Aspose.Slides formatiert werden. Er zeigt, wie wichtige Diagrammelemente wie Achsen, Gitternetzlinien, Titel, Legenden, der Plot‑Bereich und Wandfüllungen angepasst werden können, um das Aussehen und die Lesbarkeit der Diagrammdaten zu verbessern.

Er demonstriert außerdem, wie Schriftattribute für Diagrammtext festgelegt, vordefinierte Zahlenformate auf Diagrammdaten angewendet und abgerundete Ecken für den Diagrammbereich aktiviert werden. Zusammen zeigen diese Beispiele, wie sowohl der visuelle Stil als auch die Datenpräsentation von Diagrammen in einer Präsentation gesteuert werden können.

Für getrennte Füllungen und Konturen bei steigenden und fallenden Intervallen siehe das [Beispiel für Aktienchart](/slides/de/androidjava/create-chart/#create-stock-charts).

## **Diagramm‑Entitäten formatieren**

Verwenden Sie [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/), um Diagrammtitel, Achsen, Gitternetzlinien, Legenden und den Plot‑Bereich zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Markierungen und Standarddaten und wendet dann getrennte Text‑ und Linienstile auf seine Werte‑ und Kategorienachsen an. Schriftgrößen und Linienbreiten werden in Punkt angegeben; Kategorielabels werden um 45 Grad gedreht.

Die Werte‑Achse verwendet [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) unabhängig von den Quellzellen. Ihr Wertebereich reicht von –2 bis 15, mit Hauptintervallen von 2 und Nebenintervallen von 0,5. Das Beispiel kombiniert außerdem Prozentformatierung mit [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) auf Tausend, passen Sie diese Einstellungen also an die Bedeutung und Größe Ihrer Daten an. Die Legende bleibt außerhalb des Plot‑Bereichs, weil [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) mit `false` aufgerufen wird. Hinter‑Wand‑ und Bodenfüllungen werden über [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) und [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) konfiguriert, diese Flächen sind jedoch nur in 3D‑Diagrammen sichtbar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Schriftattribute für ein Diagramm festlegen**

Legen Sie die Standardschriftgröße für Diagrammtext über [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) fest. Das Beispiel erstellt ein gruppiertes Säulendiagramm mit einer 20‑Punkt‑Schrift und aktiviert Wertbeschriftungen für die erste Serie über [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Textelemente mit eigenen expliziten Schrifteinstellungen können den Diagramm‑Standard überschreiben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Textfeld‑Formatierung für Diagrammlegende wiederverwenden**

Um eine Legende an eine Folientitel‑Schrift anzupassen, setzen Sie die Schrift des Titels über [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) im ersten Absatz. Rufen Sie [copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) für das Format auf, das von der Legende über [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) zurückgegeben wird. Es kopiert die Textfeld‑Einstellungen, die Formatierung des ersten Absatzes und die Standard‑Schrifteigenschaften dieses Absatzes. Formatierungen, die direkt auf einzelne Portionen oder spätere Absätze angewendet werden, bleiben lokal beim Ursprung.

Das Beispiel verwendet einen fettgedruckten, 26‑Punkt‑Calibri‑Titel in Marineblau als Vorlage. Nach der Formatierung der Legende wird [copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) aufgerufen, um dieselbe Formatierung auf eine separate Beschriftung anzuwenden.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In der gespeicherten Präsentation stimmen Legende und Beschriftung in Größe, Gewicht und Farbe mit dem Titel überein. Die Legende zeigt weiterhin die Seriennamen, und die Beschriftung behält ihren eigenen Text. Hat ein Abschnitt in der Beschriftung bereits eine explizite Schriftgröße, so hat diese Vorrang vor dem kopierten Absatz‑Standard.

| Vor dem Kopieren | Nach dem Kopieren |
| --- | --- |
| ![Quartalsverkaufsdiagramm mit normalen schwarzen Legendenbeschriftungen und einer schwarzen Beschriftung](legend-formatting-before.png) | ![Dasselbe Diagramm mit größeren, fettgedruckten marineblauen Legendenbeschriftungen und einer passenden Beschriftung](legend-formatting.png) |

## **Numerisches Format festlegen**

Verwenden Sie [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-), um ein integriertes Zahlenformat auf Diagramm‑Arbeitsblattzellen anzuwenden. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm mit Standard‑, zellbasierten Daten und wendet Format‑Index 10 (`0.00%`) auf jede Zelle der Serienwerte an. Dadurch ändert sich die Anzeige der Werte im Arbeitsblatt, ohne die zugrunde liegenden Zahlen zu verändern; zum Beispiel wird 0,25 als 25,00 % angezeigt. Achsen‑ und Datenbeschriftungsformate können separat konfiguriert werden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die folgende Tabelle listet integrierte Zahlenformat‑Indizes mit repräsentativen Excel‑Formaten für das englische (USA) Gebietsschema auf. Die genauen Formatzeichenfolgen und ihre Anzeige können je nach Anwendung und Gebietsschema variieren, insbesondere bei Währung und Datumsangaben. Einige Excel‑Formate unterscheiden sich auch von den Vorgaben im OOXML‑Standard, wie in den [Microsoft‑Hinweisen zur Zahlenformat‑Implementierung](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) beschrieben.

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Abgerundete Rahmen für den Diagrammbereich festlegen**

Rufen Sie [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) mit `true` auf, um die Ecken des Diagrammbereichs abzurunden. Das Beispiel erstellt ein gruppiertes Säulendiagramm und verwendet [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--), um seiner Kontur eine durchgehend graue Farbe und einen ein‑Linien‑Stil zu geben, bevor die Präsentation gespeichert wird.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vorhandene Diagramm‑Anmerkungen bearbeiten**

Ein Diagramm kann benutzerdefinierte Formen enthalten, etwa eine Textanmerkung, die den Status eines Berichts erklärt. Greifen Sie über [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) darauf zu, also auch über [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) in der Diagramm‑API‑Referenz. Die Sammlung, die von [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) zurückgegeben wird, enthält die dem Diagramm gehörenden Formen.

Ein gewöhnliches Textfeld, das über einem Diagramm platziert wird, gehört zur Folie, selbst wenn es wie ein Teil des Diagramms aussieht. Das Durchlaufen von [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) findet das Diagramm und normale Folienformen, jedoch nicht die einzelnen Formen innerhalb des Diagramms. Diagrammtitel und Datenbeschriftungen sind separate Diagrammelemente, keine benutzerdefinierten Anmerkungen in dieser Sammlung.

Laden Sie [chart-annotations.pptx](chart-annotations.pptx) herunter und legen Sie es im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält ein Diagramm mit einer nicht gruppierten Anmerkung „Preliminary results“, einer dem Diagramm zugehörigen Linie und einem normalen Folientextfeld „Slide overlay“. Das Beispiel findet das erste Diagramm auf dieser Folie und ändert die Anmerkung zu „Final results“, sobald der Bericht veröffentlicht werden soll. Es prüft, ob die Sammlung leer ist, und bearbeitet nur ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) mit einem nicht‑null‑Textfeld, das von [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) zurückgegeben wird und den erwarteten Text enthält.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

Die Linie und das Folientextfeld bleiben unverändert. Die folgenden Bilder zeigen die Eingabe und das gespeicherte, wiedergeöffnete Ergebnis:

| Vor dem Bearbeiten | Nach dem Bearbeiten |
| --- | --- |
| ![Diagramm‑Anmerkung mit dem Text Vorläufige Ergebnisse](chart-annotations-before.png) | ![Diagramm‑Anmerkung mit dem Text Endgültige Ergebnisse](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Das Beispiel prüft nur die Formen, die direkt dem Diagramm gehören. Befindet sich eine Anmerkung innerhalb einer [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), prüfen Sie auch die [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--)‑Sammlung dieser Gruppe. Wiederholen Sie dies rekursiv für verschachtelte Gruppen und wenden Sie dieselben Textprüfungen auf die Kindformen an. Eine Gruppe selbst ist ein Container; behandeln Sie sie nicht als Textfeld.
{{% /alert %}}

## **FAQ**

**Kann ich halbtransparente Füllungen für Säulen/Flächen festlegen, während die Umrandung undurchsichtig bleibt?**

Ja. Transparenz der Füllung und die Kontur werden getrennt konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitternetzes und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit Datenbeschriftungen umgehen, wenn sie überlappen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), passen Sie die Beschriftungsposition an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie zum Format „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Reihen anwenden?**

Ja. Reihen unterstützen einheitliche, Verlauf‑ und Musterfüllungen. In der Praxis sollten Verläufe sparsam verwendet und Kombinationen vermieden werden, die den Kontrast zum Gitternetz und zum Text verringern.