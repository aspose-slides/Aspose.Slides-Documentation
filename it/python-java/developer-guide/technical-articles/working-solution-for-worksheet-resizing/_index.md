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
- foglio di lavoro
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Correggi il ridimensionamento OLE del foglio di lavoro Excel nelle presentazioni: due modi per mantenere i frame degli oggetti coerenti—scala il frame o il foglio—nei formati PPT e PPTX."
---
{{% alert color="info" title="Nota" %}}

È stato osservato che i fogli di lavoro Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite i componenti Aspose vengono ridimensionati a una scala non specificata dopo la prima attivazione. Questo comportamento crea una differenza visiva evidente nella presentazione tra gli stati pre‑ e post‑attivazione dell'oggetto OLE. Abbiamo esaminato dettagliatamente il problema e fornito una soluzione, descritta in questo articolo.

{{% /alert %}}

## **Contesto**

Nell'articolo [Gestire OLE](/slides/it/python-java/manage-ole/), abbiamo spiegato come aggiungere un frame OLE a una presentazione PowerPoint usando Aspose.Slides for Python via Java. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/python-java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato un'immagine dell'area del foglio di lavoro selezionata al frame OLE. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l'immagine del foglio, il workbook di Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate al vero workbook di Excel e poi tornare alla diapositiva facendo clic al di fuori del workbook attivato. Le dimensioni del frame OLE cambieranno quando l'utente ritorna alla diapositiva. Il fattore di ridimensionamento varierà in base alle dimensioni del frame OLE e del workbook Excel incorporato.

## **Cause del ridimensionamento**

Poiché il workbook di Excel dispone della propria dimensione della finestra, tenta di mantenere la sua dimensione originale alla prima attivazione. D'altra parte, il frame OLE ha le proprie dimensioni. Secondo Microsoft, quando il workbook di Excel è attivato, Excel e PowerPoint negoziano la dimensione per garantire che mantenga le proporzioni corrette come parte del processo di incorporamento. Il ridimensionamento avviene in base alle differenze tra la dimensione della finestra di Excel e le dimensioni e la posizione del frame OLE.

## **Soluzione funzionante**

Esistono due possibili soluzioni per evitare l'effetto di ridimensionamento.

- Scala le dimensioni del frame OLE nella presentazione PowerPoint per corrispondere all'altezza e alla larghezza del numero desiderato di righe e colonne nel frame OLE.
- Mantieni costanti le dimensioni del frame OLE e scala le dimensioni delle righe e colonne partecipanti in modo da adattarle alle dimensioni del frame OLE selezionato.

### **Scala le dimensioni del frame OLE**

In questo approccio, impareremo come impostare le dimensioni del frame OLE del workbook Excel incorporato per corrispondere alla dimensione cumulativa delle righe e colonne partecipanti nel foglio di lavoro Excel.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, le dimensioni del frame OLE verranno prima calcolate sulla base dell'altezza cumulativa delle righe e della larghezza cumulativa delle colonne partecipanti nel workbook. Successivamente, imposteremo le dimensioni del frame OLE su questo valore calcolato. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle porzioni desiderate delle righe e colonne nel workbook e la imposteremo come immagine del frame OLE.

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

    # Imposta la dimensione visualizzata quando il workbook è usato come oggetto OLE in PowerPoint.
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

        # Usa il workbook modificato.
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

### **Scala le dimensioni dell'intervallo di celle**

In questo approccio, impareremo come scalare le altezze delle righe partecipanti e le larghezze delle colonne partecipanti per corrispondere a una dimensione personalizzata del frame OLE.

Supponiamo di avere un foglio Excel modello e di volerlo aggiungere a una presentazione come frame OLE. In questo scenario, imposteremo le dimensioni del frame OLE e scaleremo le dimensioni delle righe e colonne che partecipano all'area del frame OLE. Salveremo poi il workbook in uno stream per applicare le modifiche e lo converteremo in un array di byte per aggiungerlo al frame OLE. Per evitare il messaggio rosso "EMBEDDED OLE OBJECT" per il frame OLE in PowerPoint, cattureremo anche un'immagine delle porzioni desiderate delle righe e colonne nel workbook e la imposteremo come immagine del frame OLE.

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

    # Imposta la dimensione visualizzata quando il workbook è usato come oggetto OLE in PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Scala l'intervallo di celle per adattarlo alle dimensioni del frame.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Usa il workbook modificato.
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

Esistono due approcci per risolvere il problema di ridimensionamento del foglio di lavoro. La scelta dell'approccio appropriato dipende dai requisiti specifici e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo, sia che le presentazioni siano create da un modello sia da zero. Inoltre, non vi è alcun limite alle dimensioni del frame OLE in questa soluzione.

{{% /alert %}}

## **FAQ**

**Perché un foglio di lavoro Excel incorporato cambia dimensione alla prima attivazione in PowerPoint?**

Ciò avviene perché Excel tenta di mantenere la dimensione originale della finestra quando viene attivato, mentre il frame OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto d'aspetto, il che può causare il ridimensionamento.

**È possibile prevenire completamente questo problema di ridimensionamento?**

Sì. Ridimensionando il frame OLE per adattarlo alla dimensione dell'intervallo di celle di Excel o ridimensionando l'intervallo di celle per adattarlo alla dimensione desiderata del frame OLE, si può evitare il ridimensionamento indesiderato.

**Quale metodo di scaling dovrei utilizzare, scaling del frame OLE o scaling dell'intervallo di celle?**

Seleziona **scaling del frame OLE** se desideri mantenere le dimensioni originali delle righe e colonne di Excel. Seleziona **scaling dell'intervallo di celle** se desideri una dimensione fissa per il frame OLE nella tua presentazione.

**Queste soluzioni funzioneranno se la presentazione è basata su un modello?**

Sì. Entrambe le soluzioni funzionano per presentazioni create da modelli e da zero.

**Esiste un limite alle dimensioni del frame OLE quando si usano questi metodi?**

No. Puoi impostare il frame OLE a qualsiasi dimensione, purché tu regoli correttamente lo scaling.

**C'è un modo per evitare il testo segnaposto "EMBEDDED OLE OBJECT" in PowerPoint?**

Sì. Catturando un'istantanea dell'intervallo di celle Excel di destinazione e impostandola come immagine segnaposto del frame OLE, puoi visualizzare un'immagine di anteprima personalizzata al posto del segnaposto predefinito.

## **Articoli correlati**

[Creare un grafico Excel e incorporarlo in una presentazione come oggetto OLE](/slides/it/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)