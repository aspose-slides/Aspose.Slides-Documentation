---
title: Creare grafici Excel e incorporarli in presentazioni come oggetti OLE
type: docs
weight: 30
url: /it/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- grafico Excel
- incorporare grafico
- oggetto OLE
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea grafici Excel e incorporali come oggetti OLE in presentazioni PowerPoint e OpenDocument con Python. Guida passo passo con esempi di codice."
---
## **Contesto**

In PowerPoint, l'utilizzo di grafici modificabili per visualizzare i dati in modo grafico è una pratica comune. Aspose supporta la creazione di grafici Excel con Aspose.Cells per Python via Java, e questi grafici possono poi essere incorporati come oggetti OLE nelle diapositive PowerPoint tramite Aspose.Slides per Python via Java. Questo articolo descrive i passaggi necessari e fornisce un esempio di codice Python per creare un grafico Excel e incorporarlo come oggetto OLE in una presentazione PowerPoint utilizzando Aspose.Cells e Aspose.Slides.

## **Passaggi richiesti**

La seguente sequenza di passaggi è necessaria per creare e incorporare un grafico Excel come oggetto OLE in una diapositiva PowerPoint:

1. Creare un grafico Excel con Aspose.Cells.  
1. Impostare le dimensioni OLE del grafico Excel con Aspose.Cells.  
1. Ottenere un'immagine del grafico Excel con Aspose.Cells.  
1. Incorporare il grafico Excel come oggetto OLE in una presentazione PPTX con Aspose.Slides.  
1. Sostituire l'immagine "EMBEDDED OLE OBJECT" con l'immagine ottenuta al punto 3 per risolvere il [problema di anteprima dell'oggetto](/slides/it/python-java/object-preview-issue-when-adding-oleobjectframe/).  
1. Salvare la presentazione su disco in formato PPTX.

## **Implementazione dei passaggi richiesti**

L'implementazione Python dei passaggi sopra è la seguente:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # Un array di nomi di celle.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Un array di dati delle celle.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Aggiungi un nuovo foglio di lavoro per popolare le celle con i dati.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Popola il foglio dati con i dati.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Aggiungi un foglio dei grafici.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Aggiungi un grafico al foglio dei grafici con le serie di dati dal foglio dati.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Imposta il foglio dei grafici come foglio attivo.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Descrivi la cartella di lavoro come dati OLE incorporati.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Crea una cartella di lavoro.
workbook = Workbook()

# Aggiungi un grafico Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Imposta le dimensioni OLE del grafico.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Ottieni l'immagine del grafico e salvala in uno stream.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Salva la cartella di lavoro in uno stream.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Crea una presentazione.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi la cartella di lavoro a una diapositiva.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Salva la presentazione su disco.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La presentazione creata con il metodo sopra conterrà il grafico Excel come oggetto OLE che può essere attivato facendo doppio clic sul frame dell'oggetto OLE.

## **Conclusione**

Utilizzando Aspose.Cells per Python via Java insieme ad Aspose.Slides per Python via Java, possiamo creare qualsiasi grafico Excel supportato da Aspose.Cells e incorporare il grafico come oggetto OLE in una diapositiva PowerPoint. È anche possibile definire le dimensioni OLE del grafico Excel. Gli utenti finali possono quindi modificare il grafico Excel come qualsiasi altro oggetto OLE.

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento dei grafici in PPTX](/slides/it/python-java/working-solution-for-chart-resizing-in-pptx/)  
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Quali librerie vengono utilizzate per creare e incorporare il grafico Excel?**

Aspose.Cells per Python via Java crea il grafico Excel, e Aspose.Slides per Python via Java lo incorpora come oggetto OLE in una diapositiva PowerPoint.

**Come possono gli utenti modificare il grafico Excel incorporato?**

Gli utenti possono fare doppio clic sul frame dell'oggetto OLE per attivare il grafico e modificarlo come qualsiasi altro oggetto OLE.

**Come viene sostituita l'anteprima predefinita dell'oggetto OLE?**

L'esempio ottiene un'immagine del grafico Excel con Aspose.Cells e la utilizza per sostituire l'immagine "EMBEDDED OLE OBJECT".