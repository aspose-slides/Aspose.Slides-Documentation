---
title: Creare grafici usando VSTO e Aspose.Slides per .NET
linktitle: Crea grafico
type: docs
weight: 80
url: /it/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- creare grafico
- migrazione
- VSTO
- automazione Office
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come automatizzare la creazione di grafici PowerPoint in C#. Questa guida passo passo mostra perché Aspose.Slides per .NET è un'alternativa più veloce e più potente a Microsoft.Office.Interop."
---
## **Panoramica**

Questo articolo dimostra come creare e personalizzare grafici nelle presentazioni Microsoft PowerPoint in modo programmatico usando C#. Con Aspose.Slides per .NET, è possibile automatizzare la generazione di grafici professionali e basati sui dati senza fare affidamento su Microsoft Office o sulle librerie Interop. L'API fornisce un ricco insieme di funzionalità per creare grafici a colonne, a torta, a linee e altro ancora — il tutto con pieno controllo su aspetto, dati e layout. Che si stiano generando report, dashboard o presentazioni aziendali, Aspose.Slides ti consente di fornire visualizzazioni di alta qualità direttamente dalle tue applicazioni .NET.

## **Esempio VSTO**

Questa sezione dimostra come creare un grafico in una presentazione Microsoft PowerPoint usando **VSTO (Visual Studio Tools for Office)**. Con VSTO, è possibile generare e personalizzare programmaticamente i grafici combinando l'automazione di PowerPoint e Excel. L'esempio fornito mostra come aggiungere un **grafico a colonne raggruppate 3D**, popolarlo con dati da un foglio di lavoro Excel, regolare la formattazione e il layout, e salvare la presentazione finale — il tutto all'interno di un'applicazione .NET.

1. Crea un'istanza di una presentazione Microsoft PowerPoint.  
1. Aggiungi una diapositiva vuota alla presentazione.  
1. Aggiungi un grafico a colonne raggruppate 3D e accedilo.  
1. Crea una nuova istanza di cartella di lavoro Microsoft Excel e carica i dati del grafico.  
1. Accedi al foglio di dati del grafico usando l'istanza della cartella di lavoro Excel.  
1. Imposta l'intervallo del grafico nel foglio di lavoro e rimuovi le serie 2 e 3 dal grafico.  
1. Modifica i dati delle categorie del grafico nel foglio di dati del grafico.  
1. Modifica i dati della serie 1 nel foglio di dati del grafico.  
1. Accedi al titolo del grafico e imposta le sue proprietà relative al carattere.  
1. Accedi all'asse dei valori del grafico e imposta l'unità principale, l'unità secondaria, il valore massimo e il valore minimo.  
1. Accedi all'asse di profondità (serie) del grafico e rimuovilo — in questo esempio è utilizzata una sola serie.  
1. Imposta gli angoli di rotazione del grafico nelle direzioni X e Y.  
1. Salva la presentazione.  
1. Chiudi le istanze di Microsoft Excel e PowerPoint.

```c#
EnsurePowerPointIsRunning(true, true);

// Istanziare un oggetto slide.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Accedere alla prima slide della presentazione.
objSlide = objPres.Slides[1];

// Selezionare la prima slide e impostarne il layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Aggiungere un grafico predefinito alla slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Accedere al grafico aggiunto.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Accedere ai dati del grafico.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Creare un'istanza della cartella di lavoro Excel per lavorare con i dati del grafico.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Accedere al foglio di lavoro dei dati per il grafico.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Impostare l'intervallo di dati per il grafico.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Applicare l'intervallo specificato alla tabella dei dati del grafico.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Impostare i valori per le categorie e i dati delle rispettive serie.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Impostare il titolo del grafico.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Accedere all'asse dei valori del grafico.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Impostare i valori per le unità dell'asse.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Accedere all'asse di profondità del grafico.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Impostare la rotazione del grafico.
ppChart.Rotation = 20;   // Valore Y
ppChart.Elevation = 15;  // Valore X
ppChart.RightAngleAxes = false;

// Salvare la presentazione come file PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Chiudere la cartella di lavoro e la presentazione.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Provare ad accedere alla proprietà Name. Se genera un'eccezione, avviare una nuova istanza di PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation viene usato per garantire che una presentazione sia caricata.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide viene usato per garantire che ci sia almeno una slide nella presentazione.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

Il risultato:

![Il grafico creato con VSTO](chart-created-using-VSTO.png)

## **Esempio Aspose.Slides per .NET**

L'esempio seguente mostra come creare un grafico semplice in una presentazione PowerPoint usando Aspose.Slides per .NET. Questo codice dimostra come aggiungere un **grafico a colonne raggruppate 3D**, popolarlo con dati di esempio e personalizzarne l'aspetto. Con poche righe di codice, è possibile generare grafici in modo dinamico e integrarli nelle presentazioni senza utilizzare Microsoft Office.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).  
1. Ottieni un riferimento alla prima diapositiva.  
1. Aggiungi un grafico a colonne raggruppate 3D e accedilo.  
1. Accedi ai dati del grafico.  
1. Rimuovi le serie 2 e 3 inutilizzate.  
1. Modifica le categorie del grafico aggiornando le etichette.  
1. Aggiorna i valori della serie 1.  
1. Accedi al titolo del grafico e imposta le sue proprietà del carattere.  
1. Configura l'asse dei valori del grafico, includendo l'unità principale, l'unità secondaria, i valori massimo e minimo.  
1. Imposta gli angoli di rotazione del grafico sugli assi X e Y.  
1. Salva la presentazione in formato PPTX.

```cs
// Crea una presentazione vuota.
using (Presentation presentation = new Presentation())
{
    // Accedi alla prima diapositiva.
    ISlide slide = presentation.Slides[0];

    // Aggiungi un grafico predefinito.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Ottieni i dati del grafico.
    IChartData chartData = chart.ChartData;

    // Rimuovi le serie predefinite aggiuntive.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Modifica i nomi delle categorie del grafico.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Imposta l'indice del foglio di lavoro dei dati del grafico.
    int worksheetIndex = 0;

    // Ottieni la cartella di lavoro dei dati del grafico.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Modifica i valori delle serie del grafico.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Imposta il titolo del grafico.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Imposta le opzioni dell'asse.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Imposta la rotazione del grafico.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Salva la presentazione come file PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Il risultato:

![Il grafico creato con Aspose.Slides per .NET](chart-created-using-aspose-slides.png)

## **FAQ**

**Posso creare altri tipi di grafici come a torta, a linee o a barre con Aspose.Slides?**

Sì. Aspose.Slides per .NET supporta un'ampia gamma di [tipi di grafico](/slides/it/net/create-chart/), tra cui grafici a torta, grafici a linee, grafici a barre, diagrammi a dispersione, grafici a bolle e altro. È possibile specificare il tipo di grafico desiderato utilizzando l'enumerazione [ChartType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/charttype/) quando si aggiunge un grafico.

**Posso applicare stili o temi personalizzati al grafico?**

Sì. È possibile personalizzare completamente l'aspetto del grafico, inclusi colori, caratteri, riempimenti, contorni, linee di griglia e layout. Tuttavia, l'applicazione di temi di Office esattamente come visualizzati in PowerPoint richiede l'impostazione manuale dei singoli stili.

**Posso esportare il grafico come immagine separatamente dalla diapositiva?**

Sì, Aspose.Slides consente di esportare qualsiasi forma — inclusi i grafici — come immagine separata (ad esempio PNG, JPEG) utilizzando il metodo `GetImage` sulla [shape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/) del grafico.