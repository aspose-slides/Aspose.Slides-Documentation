---
title: Soluzione funzionante per il ridimensionamento del foglio di lavoro
type: docs
weight: 20
url: /it/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- immagine di anteprima
- ridimensionamento immagine
- Excel
- foglio di calcolo
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Risolvi il ridimensionamento OLE dei fogli di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="info" title="Nota" %}}

Le schede di Excel incorporate come oggetti OLE in una presentazione PowerPoint utilizzando i componenti Aspose possono ridimensionarsi in modo imprevisto dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente tra l'oggetto OLE prima e dopo l'attivazione. Questo articolo spiega il problema e descrive due modi per risolverlo.

{{% /alert %}}

## **Contesto**

Nell'articolo [Manage OLE](/slides/it/python-java/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint utilizzando Aspose.Slides per Python via Java. Per affrontare il [object preview issue](/slides/it/python-java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame dell'oggetto OLE. Nella presentazione di output, quando fai doppio clic sul frame dell'oggetto OLE che mostra l'immagine del foglio di lavoro, il cartellino di Excel viene attivato. Gli utenti finali possono apportare tutte le modifiche desiderate al vero cartellino di Excel e poi tornare alla diapositiva facendo clic al di fuori del cartellino di Excel attivato. Le dimensioni del frame dell'oggetto OLE cambieranno quando l'utente tornerà alla diapositiva. Il fattore di ridimensionamento varierà a seconda delle dimensioni del frame dell'oggetto OLE e del foglio di lavoro Excel incorporato.

## **Causa del ridimensionamento**

Poiché il cartellino di Excel ha la propria dimensione della finestra, tenta di mantenere la sua dimensione originale alla prima attivazione. D'altra parte, il frame dell'oggetto OLE ha la propria dimensione. Secondo Microsoft, quando il cartellino di Excel è attivato, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e le dimensioni e la posizione del frame dell'oggetto OLE.

## **Soluzione funzionante**

Esistono due soluzioni possibili per evitare l'effetto di ridimensionamento.

- Ridimensiona il frame OLE nella presentazione PowerPoint per corrispondere all'altezza e alla larghezza totali delle righe e colonne selezionate.
- Mantieni costante la dimensione del frame OLE e ridimensiona le righe e le colonne selezionate per adattarle al suo interno.

### **Ridimensiona le dimensioni del frame OLE**

Questo approccio imposta le dimensioni del frame OLE per corrispondere all'altezza e alla larghezza totali delle righe e colonne selezionate nel foglio di lavoro Excel incorporato.

L'esempio carica un cartellino Excel esistente e seleziona le prime 10 righe e le prime 13 colonne del suo primo foglio di lavoro usando indici a base zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definisce l'intervallo visualizzato. L'anteprima è renderizzata a 96 DPI e le sue dimensioni in pixel vengono convertite in punti usando 72 punti per pollice. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) incorpora il cartellino modificato in un frame con quelle dimensioni. L'anteprima è assegnata tramite [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) per sostituire il segnaposto "EMBEDDED OLE OBJECT" nella presentazione salvata.

L'helper di anteprima imposta [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) sull'intervallo selezionato e rimuove i margini, le intestazioni e i piè di pagina. Con [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) abilitato, [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) renderizza l'intervallo come immagine PNG. L'helper restituisce un nuovo flusso di input contenente l'immagine PNG, posizionato all'inizio per l'uso nella presentazione.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Imposta la dimensione visualizzata quando il cartellino viene usato come oggetto OLE in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Ottieni la larghezza e l'altezza dell'immagine OLE in punti.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Usa il cartellino modificato.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Aggiungi l'immagine OLE alle risorse della presentazione.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Crea il frame dell'oggetto OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Ridimensiona le dimensioni dell'intervallo di celle**

Questo approccio dimensiona le altezze delle righe selezionate e le larghezze delle colonne selezionate per corrispondere a una dimensione personalizzata del frame OLE.

L'esempio carica un cartellino Excel esistente e seleziona le prime 10 righe e le prime 13 colonne del suo primo foglio di lavoro usando indici a base zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definisce l'intervallo visualizzato, e l'helper scale_cell_range dimensiona quell'intervallo per adattarlo a un frame largo 400 punti e alto 100 punti. Dopo aver salvato il cartellino modificato in un flusso, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) lo incorpora nella dimensione specificata. Un'anteprima renderizzata a 96 DPI è assegnata tramite [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), così la presentazione salvata mostra le celle selezionate invece del segnaposto predefinito.

L'helper di scaling calcola rapporti separati di larghezza e altezza per l'intervallo selezionato, preservando le larghezze relative delle sue colonne e le altezze relative delle sue righe. Converte le dimensioni calcolate da punti a pollici prima di applicarle con [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) e [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). L'intervallo selezionato deve avere larghezza e altezza non zero.

Questo helper di anteprima renderizza l'intervallo ridimensionato usando [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Limita [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) a quell'intervallo, rimuove i margini, le intestazioni e i piè di pagina, e restituisce un flusso PNG posizionato all'inizio.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # L'ampiezza e l'altezza previste dell'intervallo di celle sono in punti.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Imposta la dimensione visualizzata quando il cartellino viene usato come oggetto OLE in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Dimensiona l'intervallo di celle per adattarlo alla dimensione del frame.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Usa il cartellino modificato.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Aggiungi l'immagine OLE alle risorse della presentazione.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Crea il frame dell'oggetto OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Conclusione**

{{% alert color="info" title="Nota" %}} 

Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. Scegli l'approccio che meglio si adatta ai tuoi requisiti e caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello o da zero. Inoltre, non vi è alcun limite alle dimensioni del frame dell'oggetto OLE in questa soluzione.

{{% /alert %}}

## **Domande frequenti**

**Perché un foglio di lavoro Excel incorporato cambia dimensione quando viene attivato per la prima volta in PowerPoint?**

Ciò accade perché Excel tenta di mantenere la dimensione originale della finestra quando viene attivato, mentre il frame dell'oggetto OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile evitare del tutto questo problema di ridimensionamento?**

Sì. Ridimensionando il frame OLE per adattarlo alle dimensioni dell'intervallo di celle Excel o ridimensionando l'intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, è possibile evitare il ridimensionamento indesiderato.

**Quale metodo di ridimensionamento dovrei usare, il ridimensionamento del frame OLE o il ridimensionamento dell'intervallo di celle?**

Seleziona **ridimensionamento del frame OLE** se desideri mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **ridimensionamento dell'intervallo di celle** se desideri una dimensione fissa per il frame OLE nella tua presentazione.

**Queste soluzioni funzioneranno se la mia presentazione è basata su un modello?**

Sì. Entrambe le soluzioni funzionano per le presentazioni create da modelli e da zero.

**Esiste un limite alle dimensioni del frame OLE quando si utilizzano questi metodi?**

No. Puoi impostare il frame dell'oggetto OLE di qualsiasi dimensione, purché la scala sia impostata correttamente.

**C'è un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**

Sì. Scattando un'istantanea dell'intervallo di celle Excel di destinazione e impostandola come immagine segnaposto del frame OLE, è possibile visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Aggiornare automaticamente gli oggetti OLE usando un add-in MS PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)