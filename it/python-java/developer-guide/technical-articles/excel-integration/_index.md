---
title: Integra dati Excel nelle presentazioni PowerPoint
linktitle: Integrazione Excel
type: docs
weight: 330
url: /it/python-java/excel-integration/
keywords:
- Excel
- cartella di lavoro
- leggere Excel
- integrare Excel
- origine dati
- stampa unione
- importare tabella
- Excel in PowerPoint
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Leggi i dati dalle cartelle di lavoro Excel in Aspose.Slides per Python tramite Java usando l'API ExcelDataWorkbook. Carica fogli e celle e utilizza i valori per generare presentazioni PowerPoint guidate dai dati."
---
## **Introduzione**

Le presentazioni PowerPoint sono un modo potente per visualizzare e comunicare informazioni. Spesso vengono usate in combinazione con le cartelle di lavoro Excel, dove Excel funge da eccellente fonte di dati strutturati e PowerPoint eccelle nella visualizzazione di tali dati per il pubblico.

Esistono molti scenari pratici in cui combinare Excel e PowerPoint è fondamentale: unioni di stampa, popolamento di tabelle dati, generazione di una diapositiva per ogni record (generazione batch di diapositive), creazione di materiale formativo e consolidamento di più report Excel in un'unica presentazione, solo per citarne alcuni.

Finora, implementare tali funzionalità con l'API Aspose.Slides richiedeva l'uso di soluzioni di terze parti come Aspose.Cells. Sebbene questi strumenti siano robusti, possono risultare eccessivamente complessi e costosi per gli utenti che hanno bisogno solo di funzionalità di integrazione dati di base.

## **Come funziona**

Per semplificare e rendere più fluido il lavoro con i dati Excel, Aspose.Slides ha introdotto nuove classi per leggere dati dalle cartelle di lavoro Excel e importare contenuti in una presentazione. Questa funzionalità apre potenti nuove possibilità per gli utenti dell'API che desiderano utilizzare Excel come fonte di dati nei loro flussi di lavoro di presentazione.

La nuova funzionalità è progettata per l'accesso generale ai dati e non è integrata nel Presentation Document Object Model (DOM). Ciò significa che *non consente di modificare o salvare file Excel* — il suo unico scopo è aprire le cartelle di lavoro e navigare nel loro contenuto per recuperare i dati delle celle.

Al centro di questa funzionalità c'è la nuova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/exceldataworkbook/). Questa classe consente di caricare una cartella di lavoro Excel da un file locale o da uno stream. Una volta caricata, fornisce diverse overload del metodo [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/exceldataworkbook/#getCell), che è possibile utilizzare per recuperare celle specifiche in base alla loro posizione (ad es., indici di riga e colonna o intervalli denominati).

Ogni chiamata a [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/exceldataworkbook/#getCell) restituisce un oggetto [ExcelDataCell](https://reference.aspose.com/slides/it/python-java/aspose.slides/exceldatacell/). Questo oggetto rappresenta una singola cella nella cartella di lavoro Excel e ti consente di accedere al suo valore in modo semplice e intuitivo.

#### **Importa un grafico Excel**

Il passo successivo per estendere la funzionalità è la classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/it/python-java/aspose.slides/excelworkbookimporter/). Questa classe di utilità fornisce la possibilità di importare contenuti da una cartella di lavoro Excel in una presentazione. Contiene diverse overload del metodo [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), che ti aiutano a recuperare il grafico selezionato dalla cartella di lavoro Excel specificata e aggiungerlo alla fine della collezione di forme indicata nelle coordinate specificate.

#### **Importa una tabella Excel**

La classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/it/python-java/aspose.slides/excelworkbookimporter/) contiene anche diverse overload del metodo [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Questi metodi consentono di importare un intervallo di celle specificato da un foglio di lavoro specifico e aggiungerlo come tabella alla fine della collezione di forme indicata nelle coordinate specificate.

In breve, è un'API leggera e semplice per leggere dati Excel — esattamente ciò di cui molti sviluppatori hanno bisogno senza l'overhead di una libreria completa di elaborazione di fogli di calcolo.

## **Facciamo codice**

### **Esempio di scenario di stampa unione**

Nel seguente esempio, implementeremo un semplice scenario di stampa unione generando più presentazioni basate sui dati memorizzati in una cartella di lavoro Excel.

Per iniziare, ci servono due cose:

1. Una cartella di lavoro Excel contenente i dati

![Excel data example](example1_image0.png)

2. Un modello di presentazione PowerPoint

![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Carica la cartella di lavoro Excel con i dati dei dipendenti.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Carica il modello di presentazione.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Scorri le righe di Excel (escludendo l'intestazione alla riga 0).
    for row_index in range(1, 5):

        # Crea una presentazione per ogni record dipendente.
        employee_presentation = Presentation()

        try:
            # Rimuovi la diapositiva vuota predefinita.
            employee_presentation.getSlides().removeAt(0)

            # Clona la diapositiva modello nella presentazione.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Ottieni i paragrafi dalla forma di destinazione (si presume che l'indice forma 1 sia usato).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Sostituisci i segnaposto con i dati da Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Salva la presentazione personalizzata in un file separato.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Result](example1_image2.png)

### **Esempio di tabella Excel**

Nel secondo esempio, copiamo semplicemente i dati da una tabella Excel e li visualizziamo su una diapositiva PowerPoint in un formato più accattivante.

In questo esempio, riutilizziamo la stessa cartella di lavoro Excel del primo esempio, che contiene una semplice tabella dipendenti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Crea una presentazione PowerPoint.
presentation = Presentation()

try:
    # Aggiungi una forma tabella alla prima diapositiva.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Riempi la tabella PowerPoint con i dati dalla cartella di lavoro Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Salva la presentazione risultante in un file.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example2_image0.png)

### **Esempio di importazione di un grafico Excel**

In questo esempio, importiamo un grafico dal primo foglio di lavoro della cartella Excel usata nell'esempio precedente. Il grafico sarà collegato alla cartella di lavoro esterna nella presentazione risultante.

Prima, aggiungiamo un grafico a torta alla cartella di lavoro Excel basato sulla tabella dipendenti.

![Excel Chart example](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Crea una presentazione PowerPoint.
presentation = Presentation()
try:
    # Ottieni la collezione di forme della prima diapositiva.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Importa il grafico denominato "Chart 1" dal primo foglio della cartella di lavoro e aggiungilo alla collezione di forme.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Salva la presentazione risultante in un file.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example3_image1.png)

### **Esempio di importazione di tutti i grafici Excel**

Immaginiamo di avere una cartella di lavoro Excel piena di grafici e di doverli importare tutti in una presentazione. Ogni grafico dovrebbe essere collocato su una nuova diapositiva.

Il codice seguente itera attraverso tutti i fogli di lavoro nel file Excel di origine, estrae i grafici da ciascun foglio e aggiunge ogni grafico a una diapositiva separata utilizzando un layout diapositiva vuoto. Nella presentazione risultante, verranno incorporati solo i dati del grafico, non l'intera cartella di lavoro.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Crea una presentazione PowerPoint.
presentation = Presentation()
try:
    # Recupera il layout diapositiva vuoto.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Rimuovi la diapositiva predefinita in modo che il risultato contenga una diapositiva per ogni grafico.
    presentation.getSlides().removeAt(0)

    # Ottieni i nomi di tutti i fogli di lavoro contenuti nella cartella di lavoro Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Recupera una mappa che associa gli indici dei grafici ai nomi dei grafici per il foglio di lavoro.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Aggiungi una diapositiva usando il layout vuoto.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Importa il grafico specificato dalla cartella di lavoro Excel nella collezione di forme della diapositiva.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Salva la presentazione risultante in un file.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Esempio di importazione di una tabella Excel**

In questo esempio, importiamo una tabella formattata da un foglio di lavoro Excel direttamente in una presentazione PowerPoint.

Il foglio di lavoro Excel di origine contiene una tabella formattata con i dati dei dipendenti:

![Excel Table example](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Crea una presentazione PowerPoint.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva e la sua collezione di forme.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Importa la tabella dal primo foglio della cartella di lavoro e aggiungila alla collezione di forme.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Salva la presentazione risultante in un file.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example4_image1.png)

## **Riepilogo**

Questo meccanismo, disponibile direttamente in Aspose.Slides, combina il lavoro con i dati Excel e le presentazioni in un unico posto. Consente di creare diapositive con grafici visivi e dati presentati come tabelle Excel — senza librerie aggiuntive o integrazioni complesse.