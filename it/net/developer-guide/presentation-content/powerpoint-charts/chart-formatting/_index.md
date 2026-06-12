---
title: Formattare i grafici delle presentazioni in .NET
linktitle: Formattazione del grafico
type: docs
weight: 60
url: /it/net/chart-formatting/
keywords:
- formattare grafico
- formattazione grafico
- entità grafico
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
description: "Scopri la formattazione dei grafici in Aspose.Slides per .NET e migliora la tua presentazione PowerPoint con uno stile professionale e accattivante."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come assi, linee della griglia, titoli, legende, area del grafico e riempimenti delle pareti, per migliorare l'aspetto e la leggibilità dei dati.

Dimostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti e personalizzati ai dati del grafico e abilitare gli angoli arrotondati per l'area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati nei grafici di una presentazione.

## **Formattare le Entità del Grafico**
Aspose.Slides per .NET consente agli sviluppatori di aggiungere grafici personalizzati alle diapositive da zero. Questo articolo spiega come formattare diverse entità del grafico, inclusi gli assi di categoria e di valore.

Aspose.Slides per .NET fornisce un'API semplice per gestire le varie entità del grafico e formattarle con valori personalizzati:

1. Creare un'istanza della classe **Presentation**.
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti insieme a qualsiasi tipo desiderato (in questo esempio useremo ChartType.LineWithMarkers).
1. Accedere all'Asse dei Valori del grafico e impostare le seguenti proprietà:
   1. Impostare il **formato linea** per le linee della griglia principale dell'Asse dei Valori
   1. Impostare il **formato linea** per le linee della griglia secondaria dell'Asse dei Valori
   1. Impostare il **formato numerico** per l'Asse dei Valori
   1. Impostare **Min, Max, unità Principali e Secondarie** per l'Asse dei Valori
   1. Impostare le **Proprietà del Testo** per i dati dell'Asse dei Valori
   1. Impostare il **Titolo** per l'Asse dei Valori
   1. Impostare il **Formato Linea** per l'Asse dei Valori
1. Accedere all'Asse di Categoria del grafico e impostare le seguenti proprietà:
   1. Impostare il **formato linea** per le linee della griglia principale dell'Asse di Categoria
   1. Impostare il **formato linea** per le linee della griglia secondaria dell'Asse di Categoria
   1. Impostare le **Proprietà del Testo** per i dati dell'Asse di Categoria
   1. Impostare il **Titolo** per l'Asse di Categoria
   1. Impostare il **Posizionamento delle Etichette** per l'Asse di Categoria
   1. Impostare l'**Angolo di Rotazione** per le etichette dell'Asse di Categoria
1. Accedere alla Legenda del grafico e impostare le **Proprietà del Testo** per essa
1. Mostrare le legende del grafico senza sovrapposizione al grafico
1. Accedere al **Secondario Asse dei Valori** del grafico e impostare le seguenti proprietà:
   1. Abilitare il **Secondario Asse dei Valori**
   1. Impostare il **Formato Linea** per il Secondario Asse dei Valori
   1. Impostare il **Formato Numerico** per il Secondario Asse dei Valori
   1. Impostare **Min, Max, unità Principali e Secondarie** per il Secondario Asse dei Valori
1. Tracciare ora la prima serie del grafico sul Secondario Asse dei Valori
1. Impostare il colore di riempimento della parete posteriore del grafico
1. Impostare il colore di riempimento dell'area del grafico
1. Scrivere la presentazione modificata in un file PPTX

```c#
// Creazione della presentazione// Creazione della presentazione
Presentation pres = new Presentation();

// Accesso alla prima diapositiva
ISlide slide = pres.Slides[0];

// Aggiunta del grafico di esempio
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Impostazione del titolo del grafico
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Impostazione del formato delle linee della griglia principale per l'asse dei valori
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Impostazione del formato delle linee della griglia secondaria per l'asse dei valori
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Impostazione del formato numerico dell'asse dei valori
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Impostazione dei valori massimo e minimo del grafico
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Impostazione delle proprietà del testo dell'asse dei valori
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Impostazione del titolo dell'asse dei valori
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Impostazione del formato della linea dell'asse dei valori: ora obsoleta
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Impostazione del formato delle linee della griglia principale per l'asse di categoria
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Impostazione del formato delle linee della griglia secondaria per l'asse di categoria
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Impostazione delle proprietà del testo dell'asse di categoria
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Impostazione del titolo della categoria
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Impostazione della posizione delle etichette dell'asse di categoria
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Impostazione dell'angolo di rotazione delle etichette dell'asse di categoria
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Impostazione delle proprietà del testo delle legende
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Impostare la visualizzazione delle legende del grafico senza sovrapporre il grafico

chart.Legend.Overlay = true;
            
// Tracciamento della prima serie sull'asse dei valori secondario
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Impostazione del colore della parete posteriore del grafico
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Impostazione del colore dell'area del grafico
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Impostare le Proprietà del Carattere per un Grafico**
Aspose.Slides per .NET offre il supporto per impostare le proprietà relative al carattere del grafico. Segui i passaggi seguenti per impostare le proprietà del carattere.

- Istanziate un oggetto della classe `Presentation`.
- Aggiungete un grafico alla diapositiva.
- Impostate l'altezza del carattere.
- Salvate la presentazione modificata.

Di seguito è riportato un esempio.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```

## **Impostare il Formato Numerico**
Aspose.Slides per .NET fornisce un'API semplice per gestire il formato dei dati del grafico:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico con dati predefiniti insieme a qualsiasi tipo desiderato (questo esempio utilizza **ChartType.ClusteredColumn**).
1. Impostare il formato numerico predefinito tra i valori predefiniti disponibili.
1. Scorrere le celle dei dati del grafico in ogni serie e impostare il formato numerico dei dati.
1. Salvare la presentazione.
1. Impostare il formato numerico personalizzato.
1. Scorrere le celle dei dati del grafico in ogni serie e impostare un formato numerico diverso per i dati.
1. Salvare la presentazione.

```c#
// Instanziare la presentazione// Instanziare la presentazione
Presentation pres = new Presentation();

// Accedere alla prima diapositiva della presentazione
ISlide slide = pres.Slides[0];

// Aggiunta di un grafico a colonne raggruppate predefinito
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accesso alla collezione di serie del grafico
IChartSeriesCollection series = chart.ChartData.Series;

// Impostazione del formato numerico predefinito
// Scorrere tutte le serie del grafico
foreach (ChartSeries ser in series)
{
    // Scorrere tutte le celle di dati nella serie
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Impostazione del formato numerico
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Salvataggio della presentazione
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

I valori di formato numerico predefiniti disponibili, con il relativo indice, sono i seguenti:

|**0**|Generale|
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

## **Impostare Bordi Arrotondati per l'Area del Grafico**
Aspose.Slides per .NET offre il supporto per impostare l'area del grafico. Le proprietà **IChart.HasRoundedCorners** e **Chart.HasRoundedCorners** sono state aggiunte in Aspose.Slides.

1. Istanziate un oggetto della classe `Presentation`.
1. Aggiungete un grafico alla diapositiva.
1. Impostate il tipo di riempimento e il colore di riempimento del grafico.
1. Impostate la proprietà degli angoli arrotondati su True.
1. Salvate la presentazione modificata.

Di seguito è riportato un esempio.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Posso impostare riempimenti semi‑trasparenti per colonne/aree mantenendo il bordo opaco?**

Sì. La trasparenza del riempimento e il contorno vengono configurati separatamente. Questa opzione è utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Ridurre la dimensione del carattere, disabilitare componenti di etichetta non essenziali (ad esempio, le categorie), impostare lo spostamento/posizione dell'etichetta, mostrare le etichette solo per i punti selezionati, o passare al formato “valore + legenda”.

**Posso applicare riempimenti a gradiente o pattern alle serie?**

Sì. Sono generalmente disponibili riempimenti solidi e a gradiente/pattern. In pratica, usate i gradienti con parsimonia e evitate combinazioni che riducono il contrasto con la griglia e il testo.