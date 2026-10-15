---
title: Personalizza gli assi dei grafici nelle presentazioni in .NET
linktitle: Asse del grafico
type: docs
url: /it/net/chart-axis/
keywords:
- asse del grafico
- asse verticale
- asse orizzontale
- personalizzare asse
- manipolare asse
- gestire asse
- proprietà dell'asse
- valore massimo
- valore minimo
- linea dell'asse
- formato data
- titolo dell'asse
- posizione dell'asse
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come utilizzare Aspose.Slides per .NET per personalizzare gli assi dei grafici nelle presentazioni PowerPoint per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi dei grafici con Aspose.Slides per .NET. Copre i valori calcolati degli assi, lo scambio di righe e colonne del grafico, la visibilità dell'asse, gli intervalli delle etichette di categoria e dei segni di graduazione, le categorie e la formattazione delle date, la rotazione del titolo, il posizionamento dell'asse, le unità di visualizzazione e la scala logaritmica.

## **Ottenere i valori massimi sull'asse verticale nei grafici**

Create a [Presentazione](https://reference.aspose.com/slides/net/aspose.slides/presentation/) and add an area chart with default data. Call [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) before reading calculated axis values so that the chart layout is up to date.

Leggi [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) e [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) per i limiti dell'asse, e [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) e [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) per gli intervalli dei segni di graduazione. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) e [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) forniscono scale di unità di tempo, rilevanti per gli assi delle date. L'esempio memorizza questi valori in variabili locali e salva il grafico.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Scambiare i dati tra gli assi**

Utilizza [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) per scambiare i ruoli delle serie e delle categorie nei dati del grafico. Ogni categoria precedente diventa una serie, e ogni serie precedente diventa una categoria. Questo cambia il modo in cui i dati sono raggruppati; non scambia gli assi orizzontale e verticale. L'esempio utilizza [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) per associare i dati predefiniti a `Sheet1!A1:D5`, includendo la riga di intestazione e la colonna delle categorie, prima di scambiare righe e colonne. Salva un grafico con quattro serie e tre categorie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Invertire l'ordine di tracciamento di un asse**

Utilizza [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) per invertire un asse di categoria o di valore. Per esempio, un grafico a barre orizzontali può mostrare le fasi del progetto dall'alto verso il basso nello stesso ordine del foglio di lavoro: Pianificazione, Sviluppo, Test. L'inversione di un asse cambia la direzione di tracciamento; non ordina né riordina i dati del foglio di lavoro. In confronto, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) scambia i ruoli delle serie e delle categorie.

L'esempio seguente crea un grafico a barre orizzontali con tre fasi e una serie. Salva una presentazione con tre diapositive: ordine normale, categorie invertite e valori invertiti. Ogni copia utilizza lo stesso set di dati, e solo un asse è invertito in ogni copia.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Diapositiva 2: visualizza la prima categoria in alto.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Mantieni l'asse dei valori orizzontale in basso.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Diapositiva 3: inverte solo la scala numerica orizzontale.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

L'inversione di un asse può anche spostare l'asse perpendicolare sul lato opposto del grafico. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) controlla dove l'altro asse incrocia l'asse configurato. Nella diapositiva 2, impostandolo su `Maximum` sull'asse di categoria invertito mantiene l'asse di valore orizzontale in basso. Per un punto di incrocio specifico, utilizza [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Controlla le impostazioni di incrocio quando cambi direzione, specialmente se il grafico ha già un punto di incrocio personalizzato. Imposta `IsPlotOrderReversed` nuovamente a `false` per ripristinare la direzione di tracciamento normale; le impostazioni di incrocio sono separate.

| Ordine normale (diapositiva 1) | Categorie invertite (diapositiva 2) | Valori invertiti (diapositiva 3) |
| --- | --- | --- |
| ![Grafico a barre orizzontali con ordine normale di assi di categoria e valore](axis-order-normal.png) | ![Grafico a barre orizzontali con categorie visualizzate dall'alto verso il basso](axis-order-categories-reversed.png) | ![Grafico a barre orizzontali con asse di valore invertito e zero a destra](axis-order-values-reversed.png) |
| Le categorie vanno dal basso verso l'alto; i valori aumentano da sinistra a destra. | Pianificazione, Sviluppo e Test vanno dall'alto verso il basso. I valori e l'ordine delle righe del foglio di lavoro rimangono invariati. | Le categorie mantengono il loro ordine normale; i valori aumentano da destra a sinistra. L'asse di categoria incrocia a zero a destra. |

## **Disabilitare l'asse verticale per i grafici a linee**

Imposta [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) a `false` sull'asse verticale per nasconderlo. L'esempio crea un grafico a linee con dati predefiniti e lo salva con l'asse verticale nascosto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Disabilitare l'asse orizzontale per i grafici a linee**

Imposta [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) a `false` sull'asse orizzontale per nasconderlo. L'esempio crea un grafico a linee con dati predefiniti e lo salva con l'asse orizzontale nascosto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Modificare un asse di categoria**

Imposta [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) per scegliere un asse di categoria data o di testo. Questo esempio richiede `ExistingChart.pptx`, con un grafico come prima forma nella prima diapositiva e celle di categoria contenenti valori data Excel numerici. Cambia l'asse orizzontale in un asse di data. Impostando [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) a `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) a `1` e [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) a mesi, posiziona i segni maggiori a intervalli di un mese.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Controllare gli intervalli delle etichette dell'asse di categoria**

Quando un grafico ha molte categorie, riduci il numero di etichette dell'asse visibili senza rimuovere categorie o punti dati. Imposta [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) a `false`, poi imposta [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) all'intervallo di categoria desiderato. Per le categorie di testo nel loro ordine normale, il conteggio inizia dalla prima categoria:

| Intervallo | Etichette visualizzate nell'esempio |
| --- | --- |
| `1` | Categoria 1, Categoria 2, Categoria 3, ... Categoria 24 |
| `2` | Categoria 1, Categoria 3, Categoria 5, ... Categoria 23 |
| `3` | Categoria 1, Categoria 4, Categoria 7, ... Categoria 22 |

Un intervallo di `3` visualizza ogni terza etichetta, lasciando nascoste due etichette tra quelle visualizzate. Non elimina le colonne corrispondenti. La spaziatura automatica sceglie un intervallo in base allo spazio disponibile; non visualizza necessariamente tutte le etichette.

I segni di graduazione hanno controlli separati. Imposta [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) a `false` e utilizza [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) per impostare il loro intervallo. Per esempio, `1` mantiene un segno di graduazione ad ogni intervallo di categoria mentre le etichette appaiono solo ogni terza categoria. Imposta [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) su uno stile visibile così da vedere il risultato. Impostare nuovamente qualsiasi proprietà di spaziatura automatica a `true` permette al grafico di scegliere nuovamente quell'intervallo.

L'esempio autonomo seguente crea 24 categorie e una serie, quindi salva tre diapositive in `CategoryAxisIntervals.pptx`: spaziatura automatica, spaziatura manuale delle etichette con segni di graduazione indipendenti e spaziatura automatica ripristinata. Le due copie conservano i dati originali del grafico. Non è necessaria alcuna presentazione di input. Il testo delle etichette orizzontali rende evidente la differenza di densità.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Diapositiva 2: mostra ogni terza etichetta, ma mantieni un segno di graduazione per ogni categoria.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Diapositiva 3: lascia che il grafico scelga di nuovo entrambi gli intervalli.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Spaziatura automatica (diapositiva 1):** In questa visualizzazione, ogni seconda etichetta di categoria è visualizzata e avvolge su due linee. Il risultato automatico può variare con la dimensione del grafico, i font e il renderer.

![Spaziatura automatica delle etichette di categoria con tutte le 24 colonne visibili](category-axis-automatic.png)

**Spaziatura manuale (diapositiva 2):** Ogni terza etichetta è visualizzata su una linea, mentre i segni di graduazione rimangono ad ogni intervallo di categoria. Tutte le 24 colonne, incluse quelle senza etichette, rimangono visibili con gli stessi valori. La diapositiva 3 ripristina l'aspetto automatico mostrato sopra.

![Intervallo manuale delle etichette di categoria di tre con tutte le 24 colonne visibili](category-axis-manual.png)

### **Scegliere l'asse corretto e l'intervallo**

Utilizza questo intervallo di conteggio delle categorie per un asse di categoria testuale, come l'asse di categoria di un grafico a colonne, linee, area o barre. In un grafico a colonne, è l'asse orizzontale. In un grafico a barre orizzontali, l'asse di categoria è verticale, quindi applica queste impostazioni a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). La spaziatura dei segni di graduazione si applica anche a un asse di serie nei grafici che ne hanno uno.

Non utilizzare la spaziatura delle etichette di categoria per impostare la scala numerica di un asse di valore. Su un asse di valore, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) specifica una differenza di valori: per esempio, un'unità maggiore di `10` produce segni a 0, 10, 20, ecc. quando l'asse parte da zero. Un intervallo di etichette di categoria di `3` conta invece le posizioni delle categorie, indipendentemente dai loro valori. I grafici a dispersione e a bolle utilizzano assi di valore anziché un asse di categoria testuale. Per un asse di data, utilizza unità maggiori e scale basate sul tempo come descritto in [Change a Category Axis](#change-a-category-axis).

## **Impostare il formato data per i valori dell'asse di categoria**

L'esempio sostituisce i dati predefiniti del grafico con quattro valori annuali. Le date sono memorizzate come numeri seriali OLE Automation nel primo foglio di lavoro (indice `0`). Imposta [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) su un asse di data, disabilita [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) e assegna `yyyy` a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) affinché le etichette di categoria mostrino gli anni a quattro cifre indipendentemente dalla formattazione delle celle.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Impostare un angolo di rotazione per il titolo di un asse del grafico**

Abilita [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) sull'asse verticale, fornisci il testo del titolo e imposta [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) per ruotare il titolo. L'angolo è misurato in gradi; questo esempio salva un grafico a colonne con il titolo dell'asse dei valori ruotato di 90 gradi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Impostare la posizione dell'asse su un asse di categoria o di valore**

Utilizza [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) per controllare se l'asse di valore incrocia l'asse di categoria tra le categorie o sui segni di categoria. Questa proprietà si applica agli assi di categoria. L'esempio lo imposta a `true` sull'asse di categoria orizzontale di un grafico a colonne e salva il risultato.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Impostare l'unità di visualizzazione su un asse di valore del grafico**

Imposta [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) per scalare le etichette su un asse di valore senza modificare i dati sottostanti. Con [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) impostato su `Millions`, un valore di 60.000.000 viene visualizzato come 60. L'esempio crea un grafico a colonne e applica l'unità di visualizzazione milioni al suo asse verticale.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Configurare un asse di valore logaritmico**

Un asse di valore logaritmico è utile quando valori positivi coprono diversi ordini di grandezza. Per esempio, un servizio potrebbe ricevere 10, 100, 1.000, 10.000 e 100.000 richieste in cinque periodi. Su una scala lineare, i valori più piccoli appaiono molto vicini vicino a zero. Una scala logaritmica rende più facile confrontare la loro crescita relativa: distanze uguali rappresentano rapporti uguali anziché differenze uguali.

Imposta [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) a `true` sull'asse di valore e utilizza [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) per scegliere la base. Questo cambia il modo in cui i valori esistenti sono visualizzati; non cambia i dati né aggiunge una linea di tendenza logaritmica. Una linea di tendenza rappresenta una relazione adattata nei dati ed è una funzione separata.

### **Scegliere l'asse di valore e la base**

Per un grafico a linee o a colonne, l'asse di valore è [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Per un grafico a barre orizzontali, è [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). I grafici a dispersione e a bolle hanno due assi di valore, quindi scegli l'asse orizzontale per i valori X, l'asse verticale per i valori Y, o entrambi. Non applicare la scala logaritmica a un asse di categoria.

La base logaritmica predefinita è `10`. Per i grafici PPTX, usa una base da `2` a `1000`, inclusi; le basi frazionarie come `2.5` sono supportate. Con base `10`, le potenze successive come 10, 100, 1.000 e 10.000 sono equidistanti.

### **Confrontare la scala lineare e logaritmica**

L'esempio autonomo seguente crea un grafico a linee con i cinque conteggi di richieste nella prima diapositiva, quindi clona quella diapositiva e abilita un asse di valore logaritmico base-10 nella seconda. Entrambe le diapositive mantengono gli stessi dati.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Mantieni la prima diapositiva lineare e modifica solo la scala dell'asse dei valori della copia.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Scala lineare (diapositiva 1):** Distanze verticali uguali rappresentano differenze uguali nei conteggi delle richieste. Il valore più grande domina il grafico, rendendo difficile distinguere i valori più piccoli.

![Grafico a linee in PowerPoint che mostra cinque conteggi di richieste su un asse di valore lineare](value-axis-linear.png)

**Scala logaritmica (diapositiva 2):** Distanze verticali uguali rappresentano rapporti uguali. Ogni periodo ha dieci volte più richieste del precedente, così i punti formano una linea crescente su scala logaritmica base-10. Le etichette dell'asse mostrano ancora i conteggi originali delle richieste.

![Gli stessi cinque conteggi di richieste in PowerPoint su un asse di valore logaritmico base-10](value-axis-logarithmic.png)

### **Gestire valori zero e negativi**

Una scala logaritmica può visualizzare solo valori strettamente positivi. Controlla i dati prima di abilitarla. Se zero o valori negativi sono significativi, mantieni una scala lineare o mostrali separatamente. Se escludere tali valori è appropriato per l'analisi, spiega l'omissione. Non sostituirli silenziosamente con numeri positivi piccoli, poiché ciò cambia il significato dei dati. Qualsiasi minimo o massimo configurato manualmente per un asse logaritmico deve essere anch'esso positivo.

## **FAQ**

**Come impostare il valore in cui un asse incrocia l'altro (incrocio dell'asse)?**

Utilizza [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) per selezionare il comportamento di incrocio. Per specificare un valore numerico di incrocio, imposta [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Queste impostazioni ti consentono di spostare l'incrocio dell'asse a una linea di base adeguata.

**Come posso posizionare le etichette dei segni di graduazione rispetto all'asse?**

Imposta [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) usando [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, o `None`. Per controllare i segni di graduazione stessi, utilizza [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) o [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); questi sono separati dal posizionamento delle etichette.