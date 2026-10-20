---
title: Creare grafici Excel e incorporarli in presentazioni come oggetti OLE
type: docs
weight: 50
url: /it/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafico Excel
- incorporare grafico
- oggetto OLE
- PowerPoint
- presentazione
- Python
- Python via .NET
- Aspose.Slides
description: "Creare un grafico Excel con Aspose.Cells per Python via .NET e incorporare la cartella di lavoro in una presentazione PowerPoint con Aspose.Slides, includendo un'anteprima del grafico."
---
## **Panoramica**

Questo articolo mostra come creare un grafico a colonne di Excel con Aspose.Cells per Python via .NET e incorporare la sua cartella di lavoro in una presentazione PowerPoint con Aspose.Slides per Python via .NET. La cartella di lavoro incorporata contiene sia i dati di origine sia il grafico. Un'anteprima PNG separata visualizza il grafico sulla diapositiva prima che l'oggetto OLE venga attivato.

Il risultato è un oggetto Excel incorporato, non un grafico PowerPoint nativo. Modificare la cartella di lavoro tramite OLE richiede un'applicazione desktop che supporti l'attivazione OLE e un'installazione di Excel compatibile.

## **Prerequisiti**

Installa i pacchetti `aspose-cells-python` e `aspose-slides` nel tuo ambiente Python. Microsoft Office non è necessario per generare la presentazione con queste librerie.

Non sono richiesti file di input: l'esempio crea i dati e il grafico in memoria, quindi scrive `OutputChart.pptx` nella directory di lavoro corrente. Applica le licenze per entrambi i prodotti quando si esegue al di fuori della modalità di valutazione.

## **Come funziona l'incorporamento**

1. Crea una cartella di lavoro con un foglio di dati e un foglio di grafico.  
1. Rendi attivo il foglio di grafico in modo che la cartella di lavoro si apra sul grafico.  
1. Imposta l'intervallo di visualizzazione OLE della cartella di lavoro e renderizza il grafico in PNG.  
1. Salva la cartella di lavoro come XLSX in memoria e incorpora quei byte in una diapositiva.  
1. Assegna il PNG come anteprima dell'oggetto OLE e salva la presentazione come PPTX.

L'intervallo di visualizzazione della cartella di lavoro e il riquadro sulla diapositiva hanno ruoli diversi. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) utilizza indici di riga e colonna iniziali/finali basati su zero. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) invece utilizza la riga superiore, colonna sinistra, riga inferiore e colonna destra. L'esempio utilizza l'indice di riga 55 e l'indice di colonna 25 come confini in basso a destra; questi valori sono scelte di layout, non il numero di righe o colonne di dati.

Il riquadro della diapositiva utilizza punti. L'esempio lo adatta all'interno della diapositiva e lo centra preservando il rapporto d'aspetto del PNG, invece di allungare l'anteprima per riempire la diapositiva.

## **Crea e incorpora il grafico**

Il seguente esempio completo popola `DataSheet` con quattro righe e cinque colonne di valori. Ogni riga diventa una serie del grafico. `ChartSheet` è selezionato come foglio attivo prima di salvare la cartella di lavoro.

La cartella di lavoro viene salvata esplicitamente come XLSX, corrispondente all'estensione `xlsx` passata a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). Il PNG viene caricato direttamente dal suo stream senza una conversione bitmap intermedia. Assegnandolo tramite [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) si sostituisce il segnaposto OLE predefinito.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

    # Genera l'anteprima del grafico e serializza la cartella di lavoro modificabile separatamente.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Adatta l'anteprima all'interno della diapositiva senza modificare il rapporto d'aspetto.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Risultato previsto**

`OutputChart.pptx` contiene una diapositiva con una cartella di lavoro Excel incorporata e un'anteprima del grafico. La cartella di lavoro contiene i dati originali e un grafico a colonne con quattro serie. L'anteprima è centrata sulla diapositiva e mantiene le sue proporzioni.

![Grafico a colonne di Excel visualizzato come anteprima di una cartella di lavoro incorporata](excel-chart-ole-preview.png)

In un ambiente PowerPoint desktop compatibile con Excel disponibile, fai doppio clic sull'oggetto per attivare e modificare la cartella di lavoro incorporata. L'attivazione e la modifica dipendono dal supporto OLE dell'applicazione host e dalle impostazioni di sicurezza.

## **FAQ**

**Perché è necessaria un'immagine di anteprima?**

La cartella di lavoro incorporata e la sua anteprima nella diapositiva sono contenuti separati. Fornisci un'immagine del grafico in modo che la diapositiva mostri il grafico invece del segnaposto predefinito "EMBEDDED OLE OBJECT". Vedi [Object Preview Issue when Adding OleObjectFrame](/slides/it/python-net/object-preview-issue-when-adding-oleobjectframe/).

**L'anteprima si aggiorna automaticamente quando modifico la cartella di lavoro nel codice?**

Considera l'anteprima come un'istantanea. Quando aggiorni i dati della cartella di lavoro programmaticamente, rigenera l'immagine del grafico e sostituisci l'anteprima così come i dati della cartella di lavoro incorporata.

**Posso usare XLS invece di XLSX?**

Sì. Salva la cartella di lavoro in formato XLS e usa `xls` come estensione dei dati incorporati. L'estensione deve corrispondere al formato reale della cartella di lavoro; cambiare solo l'estensione non converte i dati.

**Perché l'oggetto potrebbe cambiare dimensione dopo l'attivazione?**

L'applicazione host può aggiornare la presentazione dell'oggetto OLE quando attiva la cartella di lavoro. L'intervallo di visualizzazione OLE della cartella di lavoro e le dimensioni del riquadro della diapositiva sono entrambi importanti. Vedi [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/it/python-net/working-solution-for-worksheet-resizing/).

## **Sezioni correlate**

- [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/it/python-net/working-solution-for-worksheet-resizing/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/it/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE Objects](/slides/it/python-net/manage-ole/)