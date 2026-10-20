---
title: Crea grafici Excel e incorporali nelle presentazioni come oggetti OLE
type: docs
weight: 50
url: /it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafico Excel
- incorporare grafico
- oggetto OLE
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Crea un grafico Excel con Aspose.Cells per .NET e incorpora la cartella di lavoro in una presentazione PowerPoint con Aspose.Slides, includendo un'anteprima del grafico."
---
## **Panoramica**

Questo articolo mostra come creare un grafico a colonne di Excel con Aspose.Cells per .NET e incorporare la sua cartella di lavoro in una presentazione PowerPoint con Aspose.Slides per .NET. La cartella di lavoro incorporata contiene sia i dati di origine sia il grafico. Un'anteprima PNG separata visualizza il grafico nella diapositiva prima che l'oggetto OLE sia attivato.

Il risultato è un oggetto Excel incorporato, non un grafico PowerPoint nativo. Modificare la cartella di lavoro tramite OLE richiede un'applicazione desktop che supporti l'attivazione OLE e un'installazione di Excel compatibile.

## **Prerequisiti**

Aggiungi riferimenti ad Aspose.Cells per .NET e Aspose.Slides per .NET nel tuo progetto C#. L'esempio utilizza le istruzioni di livello superiore e richiede C# 9 o versioni successive. Microsoft Office non è necessario per generare la presentazione con queste librerie.

Non sono richiesti file di input: l'esempio crea i dati e il grafico in memoria, quindi scrive `OutputChart.pptx` nella directory di lavoro corrente. Applica le licenze per entrambi i prodotti quando si esegue al di fuori della modalità di valutazione.

## **Come funziona l'incorporamento**

1. Crea una cartella di lavoro con un foglio di dati e un foglio grafico.  
1. Rendi attivo il foglio grafico in modo che la cartella di lavoro si apra sul grafico.  
1. Imposta l'intervallo di visualizzazione OLE della cartella di lavoro e rendi il grafico in PNG.  
1. Salva la cartella di lavoro come XLSX in memoria e incorpora quei byte in una diapositiva.  
1. Assegna il PNG come anteprima dell'oggetto OLE e salva la presentazione come PPTX.

L'intervallo di visualizzazione della cartella di lavoro e il riquadro sulla diapositiva hanno ruoli diversi. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) utilizza indici di riga e colonna di inizio/fine basati su zero. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) invece utilizza la riga superiore, la colonna sinistra, la riga inferiore e la colonna destra. L'esempio utilizza l'indice di riga 55 e l'indice di colonna 25 come confini in basso a destra; questi valori sono scelte di layout, non il numero di righe o colonne dei dati.

Il riquadro della diapositiva utilizza i punti. L'esempio lo adatta all'interno della diapositiva e lo centra mantenendo le proporzioni del PNG, invece di allungare l'anteprima per riempire la diapositiva.

## **Crea e incorpora il grafico**

Il seguente esempio completo popola `DataSheet` con quattro righe e cinque colonne di valori. Ogni riga diventa una serie del grafico. `ChartSheet` è selezionato come foglio attivo prima di salvare la cartella di lavoro.

La cartella di lavoro viene salvata esplicitamente come XLSX, corrispondente all'estensione `xlsx` passata a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). Il PNG è caricato direttamente dal suo stream senza una conversione bitmap intermedia. L'assegnazione tramite [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) sostituisce il segnaposto OLE predefinito.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Renderizza l'anteprima del grafico e serializza separatamente la cartella di lavoro modificabile.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Risultato previsto**

`OutputChart.pptx` contiene una diapositiva con una cartella di lavoro Excel incorporata e un'anteprima del grafico. La cartella di lavoro contiene i dati originali e un grafico a colonne con quattro serie. L'anteprima è centrata sulla diapositiva e ne mantiene le proporzioni.

![Grafico a colonne di Excel visualizzato come anteprima di una cartella di lavoro incorporata](excel-chart-ole-preview.png)

In un ambiente PowerPoint desktop compatibile con Excel disponibile, fai doppio clic sull'oggetto per attivare e modificare la cartella di lavoro incorporata. L'attivazione e la modifica dipendono dal supporto OLE dell'applicazione host e dalle impostazioni di sicurezza.

## **FAQ**

**Perché è necessaria un'immagine di anteprima?**  
La cartella di lavoro incorporata e la sua anteprima nella diapositiva sono contenuti separati. Fornisci un'immagine del grafico in modo che la diapositiva mostri il grafico invece del segnaposto predefinito "EMBEDDED OLE OBJECT". Vedi [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/).

**L'anteprima si aggiorna automaticamente quando modifico la cartella di lavoro nel codice?**  
Considera l'anteprima come un'istantanea. Quando aggiorni i dati della cartella di lavoro programmaticamente, rigenera l'immagine del grafico e sostituisci l'anteprima così come i dati della cartella di lavoro incorporata.

**Posso usare XLS invece di XLSX?**  
Sì. Salva la cartella di lavoro in formato XLS e usa `xls` come estensione dei dati incorporati. L'estensione deve corrispondere al formato effettivo della cartella di lavoro; modificare solo l'estensione non converte i dati.

**Perché l'oggetto potrebbe cambiare dimensione dopo l'attivazione?**  
L'applicazione host può aggiornare la presentazione dell'oggetto OLE quando attiva la cartella di lavoro. L'intervallo di visualizzazione OLE della cartella di lavoro e le dimensioni del riquadro della diapositiva sono entrambi importanti. Vedi [Soluzione funzionante per il ridimensionamento dei grafici in PPTX](/slides/it/net/working-solution-for-chart-resizing-in-pptx/).

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento dei grafici in PPTX](/slides/it/net/working-solution-for-chart-resizing-in-pptx/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/)
- [Aggiornamento automatico degli oggetti OLE utilizzando un componente aggiuntivo PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)