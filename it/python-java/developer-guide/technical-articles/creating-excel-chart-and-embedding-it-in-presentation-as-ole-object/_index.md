---
title: Crea grafici Excel e incorporali in presentazioni come oggetti OLE
type: docs
weight: 30
url: /it/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- grafico Excel
- incorporare grafico
- oggetto OLE
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea un grafico Excel con Aspose.Cells per Python tramite Java e incorpora la cartella di lavoro in una presentazione PowerPoint con Aspose.Slides, includendo un'anteprima del grafico."
---
## **Panoramica**

Questo articolo mostra come creare un grafico a colonne Excel con Aspose.Cells per Python tramite Java e incorporare la sua cartella di lavoro in una presentazione PowerPoint con Aspose.Slides per Python tramite Java. La cartella di lavoro incorporata contiene sia i dati di origine sia il grafico. Un'anteprima PNG separata visualizza il grafico sulla diapositiva prima che l'oggetto OLE venga attivato.

Il risultato è un oggetto Excel incorporato, non un grafico PowerPoint nativo. Modificare la cartella di lavoro tramite OLE richiede un'applicazione desktop che supporti l'attivazione OLE e un'installazione di Excel compatibile.

## **Prerequisiti**

Installa i pacchetti Python `aspose-cells` e `aspose-slides-java` e un runtime Java compatibile. Importa entrambi i pacchetti prima di avviare la JVM in modo che le loro librerie Java siano disponibili per JPype. Microsoft Office non è necessario per generare la presentazione con queste librerie.

Non sono richiesti file di input: l'esempio crea i dati e il grafico in memoria, quindi scrive `OutputChart.pptx` nella directory di lavoro corrente. Applica le licenze per entrambi i prodotti quando si esegue al di fuori della modalità di valutazione.

## **Come funziona l'incorporamento**

1. Crea una cartella di lavoro con un foglio di dati e un foglio del grafico.
1. Imposta il foglio del grafico come attivo in modo che la cartella di lavoro si apra sul grafico.
1. Imposta l'intervallo di visualizzazione OLE della cartella di lavoro e genera il grafico in PNG.
1. Salva la cartella di lavoro come XLSX in memoria e incorpora tali byte in una diapositiva.
1. Assegna il PNG come anteprima dell'oggetto OLE e salva la presentazione come PPTX.

L'intervallo di visualizzazione della cartella di lavoro e il riquadro sulla diapositiva hanno ruoli diversi. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) accetta indici di riga e colonna di inizio/fine basati su zero. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) invece accetta la riga superiore, la colonna sinistra, la riga inferiore e la colonna destra. L'esempio utilizza l'indice di riga 55 e l'indice di colonna 25 come limiti in basso a destra; questi valori sono scelte di layout, non il numero di righe o colonne di dati.

Il riquadro della diapositiva utilizza punti. L'esempio lo adatta all'interno della diapositiva e lo centra preservando il rapporto d'aspetto del PNG, invece di allungare l'anteprima per riempire la diapositiva.

## **Crea e incorpora il grafico**

Il seguente esempio completo popola `DataSheet` con quattro righe e cinque colonne di valori. Ogni riga diventa una serie del grafico. `ChartSheet` è selezionato come foglio attivo prima di salvare la cartella di lavoro.

La cartella di lavoro viene salvata esplicitamente come XLSX, corrispondente all'estensione `xlsx` passata a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). I flussi di byte array Java mantengono la cartella di lavoro e l'immagine in memoria e forniscono i byte array richiesti dalle API Java. Il PNG è caricato direttamente dai suoi byte senza una conversione bitmap intermedia. Assegnandolo tramite [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) si sostituisce il segnaposto OLE predefinito.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Genera l'anteprima del grafico e serializza separatamente la cartella di lavoro modificabile.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Adatta l'anteprima alla diapositiva senza modificare il rapporto d'aspetto.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Risultato previsto**

`OutputChart.pptx` contiene una diapositiva con una cartella di lavoro Excel incorporata e un'anteprima del grafico. La cartella di lavoro contiene i dati originali e un grafico a colonne con quattro serie. L'anteprima è centrata sulla diapositiva e ne conserva le proporzioni.

![Grafico a colonne Excel visualizzato come anteprima di una cartella di lavoro incorporata](excel-chart-ole-preview.png)

In un ambiente PowerPoint desktop compatibile con Excel disponibile, fai doppio clic sull'oggetto per attivare e modificare la cartella di lavoro incorporata. L'attivazione e la modifica dipendono dal supporto OLE dell'applicazione host e dalle impostazioni di sicurezza.

## **FAQ**

**Perché è necessaria un'immagine di anteprima?**

La cartella di lavoro incorporata e la sua anteprima sulla diapositiva sono contenuti separati. Fornisci un'immagine del grafico in modo che la diapositiva mostri il grafico invece del segnaposto predefinito "EMBEDDED OLE OBJECT". Vedi [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/python-java/object-preview-issue-when-adding-oleobjectframe/).

**L'anteprima si aggiorna automaticamente quando modifico la cartella di lavoro nel codice?**

L'anteprima è un'istantanea. Quando si aggiornano i dati della cartella di lavoro programmaticamente, è necessario rigenerare l'immagine del grafico e sostituire l'anteprima così come i dati della cartella di lavoro incorporata.

**Posso usare XLS invece di XLSX?**

Sì. Salva la cartella di lavoro in formato XLS e usa `xls` come estensione dei dati incorporati. L'estensione deve corrispondere al formato effettivo della cartella di lavoro; cambiare solo l'estensione non converte i dati.

**Perché l'oggetto potrebbe cambiare dimensione dopo l'attivazione?**

L'applicazione host può aggiornare la presentazione dell'oggetto OLE quando attiva la cartella di lavoro. Sia l'intervallo di visualizzazione OLE della cartella di lavoro sia le dimensioni del riquadro della diapositiva sono importanti. Vedi [Soluzione funzionante per il ridimensionamento del grafico in PPTX](/slides/it/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento del grafico in PPTX](/slides/it/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/python-java/object-preview-issue-when-adding-oleobjectframe/)