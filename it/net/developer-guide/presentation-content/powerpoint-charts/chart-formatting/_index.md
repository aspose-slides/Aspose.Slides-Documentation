---
title: Formattare i grafici di presentazione in .NET
linktitle: Formattazione del grafico
type: docs
weight: 60
url: /it/net/chart-formatting/
keywords:
- formattazione grafico
- formattazione del grafico
- entità del grafico
- proprietà del grafico
- impostazioni del grafico
- opzioni del grafico
- proprietà del carattere
- bordo arrotondato
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri la formattazione dei grafici in Aspose.Slides per .NET e migliora la tua presentazione PowerPoint con assi personalizzati, caratteri, formati numerici e bordi arrotondati del grafico."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico come assi, linee della griglia, titoli, legende, area del tracciato e riempimenti delle pareti per migliorare l'aspetto e la leggibilità dei dati del grafico.

Mostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi illustrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

Per riempimenti e contorni separati su intervalli in crescita e in calo, vedi l'[esempio di grafico azionario](/slides/it/net/create-chart/#create-stock-charts).

## **Formattare le Entità del Grafico**

Usa [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) per formattare titoli, assi, linee della griglia, legende e l'area del tracciato. Questo esempio crea un grafico a linee con marcatori e dati predefiniti, poi applica stili di testo e linea separati al suo asse dei valori e all'asse delle categorie. Le dimensioni dei caratteri e le larghezze delle linee sono specificate in punti; le etichette di categoria sono ruotate di 45°.

L'asse dei valori utilizza [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) indipendentemente dalle celle di origine. La sua scala va da –2 a 15, con intervalli principali di 2 e intervalli secondari di 0,5. L'esempio combina anche la formattazione percentuale con [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) impostata su migliaia, quindi adatta queste impostazioni al significato e alla magnitudine dei tuoi dati. La legenda rimane fuori dall'area del tracciato perché [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) è disabilitato. I riempimenti di parete posteriore e di pavimento sono configurati tramite [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) e [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), ma queste superfici sono visibili solo nei grafici 3D.

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

## **Imposta le Proprietà del Carattere per un Grafico**

Imposta la dimensione predefinita del carattere per il testo del grafico tramite [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). L'esempio crea un grafico a colonne raggruppate con un carattere da 20 pt e abilita le etichette dei valori per la prima serie tramite [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Gli elementi di testo con impostazioni di carattere esplicite possono sovrascrivere il valore predefinito del grafico.

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

## **Riutilizzare la Formattazione del Riquadro di Testo per una Legenda del Grafico**

Per abbinare una legenda a un'intestazione della diapositiva, imposta il carattere nel [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) del primo paragrafo. Chiama [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) sul [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) della legenda. Legge le impostazioni del riquadro di testo, la formattazione del primo paragrafo e le proprietà del carattere predefinite di quel paragrafo. La formattazione applicata direttamente a porzioni individuali o a paragrafi successivi rimane locale alla sorgente.

L'esempio utilizza un'intestazione in grassetto, Calibri da 26 pt, colorata di blu scuro come modello. Dopo aver stilizzato la legenda, usa [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) per applicare la stessa formattazione a una didascalia separata.

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

Nella presentazione salvata, la legenda e la didascalia corrispondono all'intestazione per dimensione, peso e colore. La legenda continua a visualizzare i nomi delle serie, e la didascalia conserva il proprio testo. Se una porzione nella didascalia ha già una dimensione del carattere esplicita, tale dimensione prevale sul valore predefinito del paragrafo copiato.

| Prima della copia | Dopo la copia |
| --- | --- |
| ![Grafico delle vendite trimestrali con etichette della legenda nere regolari e una didascalia nera](legend-formatting-before.png) | ![Lo stesso grafico con etichette della legenda più grandi, in grassetto e di colore blu navy, e una didascalia corrispondente](legend-formatting.png) |

## **Imposta il Formato Numerico**

Usa [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) per applicare un formato numerico integrato alle celle della cartella di lavoro del grafico. Questo esempio crea un grafico a colonne raggruppate con dati predefiniti basati su celle e applica l'indice di formato 10 (`0.00%`) a ciascuna cella del valore della serie. Questo modifica il modo in cui i valori vengono visualizzati nella cartella di lavoro senza alterare i numeri sottostanti; ad esempio, 0,25 viene mostrato come 25,00 %. I formati degli assi e delle etichette dei dati possono essere configurati separatamente.

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

La tabella seguente elenca gli indici dei formati numerici integrati con i corrispondenti formati Excel per la locale English (United States). Le stringhe di formato esatte e la loro visualizzazione possono variare a seconda dell'applicazione e della locale, in particolare per valute e date. Alcuni formati Excel differiscono anche dai valori predefiniti nello standard OOXML, come descritto nelle [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indice | Formato |
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

## **Imposta i Bordi Arrotondati dell'Area del Grafico**

Abilita [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) per arrotondare gli angoli dell'area del grafico. L'esempio crea un grafico a colonne raggruppate e utilizza [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) per dare al suo contorno un colore grigio solido e uno stile a linea singola prima di salvare la presentazione.

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

## **Modifica le Annotazioni dei Grafici Esistenti**

Un grafico può contenere forme personalizzate, come un'annotazione di testo che spiega lo stato di un report. Accedi a queste forme tramite [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), elencate anche sotto [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) nella Riferimento API del Grafico. La sua collezione [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) contiene le forme di proprietà del grafico.

Una casella di testo ordinaria posizionata sopra un grafico appartiene alla diapositiva, anche se sembra parte del grafico. Scorrendo [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) si trovano il grafico e le forme ordinarie della diapositiva, ma non le singole forme all'interno del grafico. Titoli del grafico ed etichette dei dati sono elementi separati del grafico, non annotazioni personalizzate in questa collezione.

Scarica [chart-annotations.pptx](chart-annotations.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene un grafico con un'annotazione non raggruppata che recita “Preliminary results”, una linea di proprietà del grafico e una casella di testo della diapositiva che recita “Slide overlay”. L'esempio trova il primo grafico su quella diapositiva e cambia l'annotazione in “Final results” quando il report è pronto per la pubblicazione. Verifica che la collezione non sia vuota e modifica solo un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) con un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) non nullo e con il testo atteso.

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

La linea e la casella di testo della diapositiva rimangono inalterate. Le immagini seguenti mostrano l'input e il risultato salvato e riaperto:

| Prima della modifica | Dopo la modifica |
| --- | --- |
| ![Annotazione del grafico con testo 'Risultati preliminari'](chart-annotations-before.png) | ![Annotazione del grafico con testo 'Risultati finali'](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
L'esempio esamina solo le forme di proprietà del grafico a livello superiore. Se un'annotazione si trova all'interno di un [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), ispeziona anche la collezione [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) di quel gruppo. Ripeti ricorsivamente per i gruppi nidificati, applicando gli stessi controlli di testo alle loro forme figlie. Un gruppo stesso è un contenitore; non trattarlo come una casella di testo.
{{% /alert %}}

## **Domande frequenti**

**Posso impostare riempimenti semitrasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno sono configurati separatamente. Questo è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Riduci la dimensione del carattere, disabilita componenti di etichetta non essenziali (ad esempio, le categorie), regola la posizione dell'etichetta, mostra le etichette solo per i punti selezionati se necessario, o passa al formato “value + legend”.

**Posso applicare riempimenti a gradiente o a motivi alle serie?**

Sì. Le serie supportano riempimenti solidi, a gradiente e a motivo. In pratica, usa i gradienti con parsimonia e evita combinazioni che riducono il contrasto con la griglia e il testo.