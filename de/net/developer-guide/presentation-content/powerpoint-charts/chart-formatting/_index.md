---
title: Diagramme in Präsentationen in .NET formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/net/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schrifteigenschaften
- Abgerundete Kontur
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für .NET formatieren und Ihre PowerPoint-Präsentation mit benutzerdefinierten Achsen, Schriften, Zahlenformaten und abgerundeten Diagrammkanten verbessern."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagramme in PowerPoint‑Präsentationen mithilfe von Aspose.Slides formatiert werden. Er zeigt, wie wichtige Diagrammelemente wie Achsen, Gitternetzlinien, Titel, Legenden, der Plot‑Bereich und Wand‑Füllungen angepasst werden können, um das Erscheinungsbild und die Lesbarkeit von Diagrammdaten zu verbessern.

Er demonstriert außerdem, wie Schriftarteigenschaften für Diagrammtext festgelegt, vordefinierte Zahlenformate auf Diagrammdaten angewendet und abgerundete Ecken für den Diagrammbereich aktiviert werden. Zusammen zeigen diese Beispiele, wie sowohl der visuelle Stil als auch die Datenpräsentation von Diagrammen in einer Präsentation gesteuert werden können.

Für separate Füllungen und Konturen bei steigenden und fallenden Intervallen siehe das [Beispiel für Aktiendiagramm](/slides/de/net/create-chart/#create-stock-charts).

## **Diagramm‑Entitäten formatieren**

Verwenden Sie [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/), um Diagrammtitel, Achsen, Gitternetzlinien, Legenden und den Plot‑Bereich zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Markierungen und Standarddaten und wendet anschließend separate Text‑ und Linien‑Stile auf seine Werte‑ und Kategorienachsen an. Schriftgrößen und Linienbreiten werden in Punkt angegeben; Kategorienbeschriftungen werden um 45 Grad gedreht.

Die Werte‑Achse verwendet [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) unabhängig von den Quellzellen. Ihr Maßstab reicht von ‑2 bis 15, mit Hauptintervallen von 2 und Nebenintervallen von 0,5. Das Beispiel kombiniert außerdem Prozentformatierung mit [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) auf Tausende eingestellt; passen Sie diese Einstellungen an die Bedeutung und Größe Ihrer Daten an. Die Legende bleibt außerhalb des Plot‑Bereichs, weil [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) deaktiviert ist. Rückwand‑ und Boden‑Füllungen werden über [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) und [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) konfiguriert, aber diese Flächen sind nur in 3D‑Diagrammen sichtbar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Schriftarteigenschaften für ein Diagramm festlegen**

Setzen Sie die Standardschriftgröße für Diagrammtext über [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). Das Beispiel erstellt ein gruppiertes Säulendiagramm mit einer 20‑Punkt‑Schrift und aktiviert Werte‑Beschriftungen für die erste Serie über [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Textelemente mit eigenen expliziten Schriftsystemen können die Diagramm‑Standardwerte überschreiben.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Textfeldformatierung für eine Diagramm‑Legende wiederverwenden**

Um eine Legende an eine Folien‑Überschrift anzupassen, setzen Sie die Schrift im [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) des ersten Absatzes. Rufen Sie [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) für das [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) der Legende auf. Es liest die Textrahmen‑Einstellungen, die Formatierung des ersten Absatzes und die Standardschrift dieser Absatzes. Formatierungen, die direkt auf einzelne Abschnitte oder auf spätere Absätze angewendet werden, bleiben lokal für die Quelle.

Das Beispiel verwendet eine fette, 26‑Punkt‑Calibri‑Überschrift in Marineblau als Vorlage. Nach der Gestaltung der Legende wird [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) verwendet, um dieselbe Formatierung auf eine separate Beschriftung anzuwenden.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

In der gespeicherten Präsentation stimmen Legende und Beschriftung in Größe, Gewicht und Farbe mit der Überschrift überein. Die Legende zeigt weiterhin die Seriennamen an, und die Beschriftung behält ihren eigenen Text. Wenn ein Abschnitt in der Beschriftung bereits eine explizite Schriftgröße hat, hat diese Größe Vorrang vor dem kopierten Absatz‑Standard.

| Vor dem Kopieren | Nach dem Kopieren |
| --- | --- |
| ![Quartalsverkaufs‑Diagramm mit regulären schwarzen Legendenbeschriftungen und einer schwarzen Beschriftung](legend-formatting-before.png) | ![Das gleiche Diagramm mit größeren, fett gedruckten marineblauen Legendenbeschriftungen und einer passenden Beschriftung](legend-formatting.png) |

## **Numerisches Format festlegen**

Verwenden Sie [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/), um ein integriertes Zahlenformat auf Diagramm‑Arbeitsmappenzellen anzuwenden. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm mit Standard‑, zellbasierten Daten und wendet Formatindex 10 (`0.00%`) auf jede Serienwertzelle an. Dadurch ändert sich die Anzeige der Werte in der Arbeitsmappe, ohne die zugrunde liegenden Zahlen zu ändern; zum Beispiel wird 0,25 als 25,00 % angezeigt. Achsen‑ und Datenbeschriftungsformate können separat konfiguriert werden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0,00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Die folgende Tabelle listet integrierte Zahlenformat‑Indizes mit repräsentativen Excel‑Formaten für das englische (Vereinigte Staaten) Gebietsschema. Die genauen Formatzeichenfolgen und deren Anzeige können je nach Anwendung und Gebietsschema variieren, insbesondere bei Währungen und Datumsangaben. Einige Excel‑Formate unterscheiden sich zudem von den Vorgaben im OOXML‑Standard, wie in den [Hinweisen zu Microsofts Implementierung von Zahlenformaten](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) beschrieben.

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

## **Abgerundete Ränder für den Diagrammbereich festlegen**

Aktivieren Sie [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/), um die Ecken des Diagrammbereichs abzurunden. Das Beispiel erstellt ein gruppiertes Säulendiagramm und verwendet [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/), um dessen Kontur eine einheitliche graue Farbe und einen einfachen Linienstil zu geben, bevor die Präsentation gespeichert wird.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Vorhandene Diagramm‑Anmerkungen bearbeiten**

Ein Diagramm kann benutzerdefinierte Formen enthalten, beispielsweise eine Textanmerkung, die den Status eines Berichts erklärt. Greifen Sie über [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) darauf zu, auch unter [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) im Diagramm‑API‑Referenzhandbuch aufgeführt. Seine [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑Sammlung enthält die diagrammbesitzenden Formen.

Ein gewöhnliches Textfeld, das über einem Diagramm platziert wird, gehört zur Folie, selbst wenn es wie ein Teil des Diagramms aussieht. Das Durchlaufen von [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) findet das Diagramm und die normalen Folienformen, jedoch nicht die einzelnen Formen innerhalb des Diagramms. Diagrammtitel und Datenbeschriftungen sind separate Diagrammelemente, keine benutzerdefinierten Anmerkungen in dieser Sammlung.

Laden Sie [chart-annotations.pptx](chart-annotations.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält ein Diagramm mit einer nicht gruppierten Anmerkung, die „Vorläufige Ergebnisse“ lautet, einer diagrammbesitzenden Linie und einem normalen Folientextfeld, das „Folien‑Overlay“ anzeigt. Das Beispiel findet das erste Diagramm auf dieser Folie und ändert die Anmerkung zu „Endgültige Ergebnisse“, wenn der Bericht zur Veröffentlichung bereit ist. Es prüft, ob die Sammlung leer ist, und bearbeitet nur ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) mit einem nicht‑null‑[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) und dem erwarteten Text.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

Die Linie und das Folientextfeld bleiben unverändert. Die folgenden Bilder zeigen die Eingabe und das gespeicherte, wiedergeöffnete Ergebnis:

| Vor dem Bearbeiten | Nach dem Bearbeiten |
| --- | --- |
| ![Diagrammannmerkung mit dem Text Vorläufige Ergebnisse](chart-annotations-before.png) | ![Diagrammannmerkung mit dem Text Endgültige Ergebnisse](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Das Beispiel prüft nur die obersten diagrammbesitzenden Formen. Befindet sich eine Anmerkung innerhalb einer [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), prüfen Sie auch die [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)‑Sammlung dieser Gruppe. Wiederholen Sie dies rekursiv für verschachtelte Gruppen und wenden Sie dieselben Textprüfungen auf die Kindformen an. Eine Gruppe selbst ist ein Container; behandeln Sie sie nicht als Textfeld.
{{% /alert %}}

## **FAQ**

**Kann ich halbtransparente Füllungen für Säulen/Flächen setzen und gleichzeitig die Kontur undurchsichtig lassen?**

Ja. Die Transparenz der Füllung und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Rasters und der Daten in dichten Visualisierungen zu verbessern.

**Wie gehe ich mit Datenbeschriftungen um, wenn sie sich überlagern?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), passen Sie die Beschriftungsposition an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, oder wechseln Sie zum Format „Wert + Legende“.

**Kann ich Farbverlauf‑ oder Muster‑Füllungen auf Serien anwenden?**

Ja. Serien unterstützen einfarbige, Verlauf‑ und Muster‑Füllungen. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Raster und zum Text verringern.