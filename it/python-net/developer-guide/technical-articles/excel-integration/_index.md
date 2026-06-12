---
title: Integra dati Excel nelle presentazioni PowerPoint
linktitle: Integrazione Excel
type: docs
weight: 330
url: /it/python-net/excel-integration/
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
- Aspose.Slides
description: "Leggi i dati da cartelle di lavoro Excel in Aspose.Slides usando l'API ExcelDataWorkbook. Carica fogli e celle e utilizza i valori per generare presentazioni PowerPoint basate sui dati."
---
## **Introduzione**

Le presentazioni PowerPoint sono un modo potente per visualizzare e comunicare informazioni. Spesso vengono utilizzate insieme a cartelle di lavoro Excel, dove Excel è una fonte eccellente di dati strutturati e PowerPoint eccelle nel visualizzare tali dati per un pubblico.

Esistono molti scenari pratici in cui combinare Excel e PowerPoint è essenziale: unioni di stampa, popolamento di tabelle di dati, generazione di una diapositiva per ogni record di dati (generazione batch di diapositive), creazione di materiali formativi e consolidamento di più report Excel in un'unica presentazione, per citarne alcuni.

Fino a ora, implementare tali funzionalità con l'API Aspose.Slides richiedeva l'uso di soluzioni di terze parti come Aspose.Cells. Sebbene questi strumenti siano solidi, possono risultare eccessivamente complessi e costosi per gli utenti che hanno bisogno solo di funzionalità di integrazione dati di base.

## **Come funziona**

Per semplificare e rendere più fluido il lavoro con i dati Excel, Aspose.Slides ha introdotto nuove classi per leggere dati da cartelle di lavoro Excel e importare contenuti in una presentazione. Questa funzionalità apre nuove possibilità potenti per gli utenti dell'API che vogliono sfruttare Excel come fonte di dati all'interno dei loro flussi di lavoro di presentazione.

La nuova funzionalità è progettata per l'accesso generico ai dati e non è integrata nel modello a oggetti del documento di presentazione (DOM). Ciò significa *che non consente di modificare o salvare file Excel* — il suo unico scopo è aprire le cartelle di lavoro e navigare nel loro contenuto per recuperare i dati delle celle.

Al centro di questa funzionalità c'è la nuova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.excel/exceldataworkbook/). Questa classe permette di caricare una cartella di lavoro Excel da un file locale o da uno stream. Una volta caricata, fornisce diverse sovraccariche del metodo [get_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides.excel/exceldataworkbook/get_cell/), che è possibile utilizzare per recuperare celle specifiche in base alla loro posizione (ad es. indici di riga e colonna o intervalli nominati).

Ogni chiamata a [get_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) restituisce un'istanza della classe [ExcelDataCell](https://reference.aspose.com/slides/it/python-net/aspose.slides.excel/exceldatacell/). Questo oggetto rappresenta una singola cella nella cartella di lavoro Excel e fornisce l'accesso al suo valore in modo semplice e intuitivo.

#### **Importa un grafico Excel**

Il passo successivo per estendere la funzionalità è la classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/it/python-net/aspose.slides.importing/excelworkbookimporter/). Questa classe di utilità fornisce funzionalità per importare contenuti da una cartella di lavoro Excel in una presentazione. Contiene diverse sovraccariche del metodo [add_chart_from_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/), che aiutano a recuperare il grafico selezionato dalla cartella di lavoro Excel specificata e ad aggiungerlo alla fine della collezione di forme indicata alle coordinate specificate.

In breve, è un'API leggera e diretta per la lettura dei dati Excel — esattamente ciò di cui molti sviluppatori hanno bisogno senza l'overhead di una libreria completa di elaborazione di fogli di calcolo.

## **Scriviamo codice**

### **Esempio di scenario di unione di stampa**

Nel seguente esempio, implementeremo un semplice scenario di unione di stampa generando più presentazioni in base ai dati memorizzati in una cartella di lavoro Excel.

Per iniziare, abbiamo bisogno di due cose:
1. Una cartella di lavoro Excel contenente i dati

![Esempio di dati Excel](example1_image0.png)

2. Un modello di presentazione PowerPoint

![Esempio di modello PowerPoint](example1_image1.png)

```py
import aspose.slides as slides

# Carica la cartella di lavoro Excel con i dati dei dipendenti.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Carica il modello di presentazione.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Scorri le righe di Excel (escludendo l'intestazione alla riga 0).
    for row_index in range(1, 5):

        # Crea una nuova presentazione per ogni record dipendente.
        with slides.Presentation() as employee_presentation:

            # Rimuovi la diapositiva vuota predefinita.
            employee_presentation.slides.remove_at(0)

            # Clona la diapositiva modello nella nuova presentazione.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Ottieni i paragrafi dalla forma di destinazione (si assume che l'indice forma 1 sia usato).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Sostituisci i segnaposto con i dati di Excel.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Salva la presentazione personalizzata in un file separato.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Risultato](example1_image2.png)

### **Esempio di tabella Excel**

Nel secondo esempio, copiamo semplicemente i dati da una tabella Excel e li visualizziamo su una diapositiva PowerPoint in un formato più accattivante.

In questo esempio, riusiamo la stessa cartella di lavoro Excel del primo esempio, che contiene una semplice tabella dipendenti.

```py
# Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Crea una nuova presentazione PowerPoint.
with slides.Presentation() as presentation:

    # Aggiungi una forma tabella alla prima diapositiva.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Riempi la tabella PowerPoint con i dati dalla cartella di lavoro Excel.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Salva la presentazione risultante in un file.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Risultato](example2_image0.png)

### **Esempio di importazione di un grafico Excel**

In questo esempio, importiamo un grafico dal primo foglio di lavoro della cartella di lavoro Excel usata nell'esempio precedente. Il grafico sarà collegato al file Excel esterno nella presentazione risultante.

Per prima cosa, aggiungiamo un grafico a torta alla cartella di lavoro Excel basato sulla tabella dei dipendenti.

![Esempio di grafico Excel](example3_image0.png)

```py
# Crea una nuova presentazione PowerPoint.
with slides.Presentation() as presentation:
    # Ottieni la raccolta di forme della prima diapositiva.
    shapes = presentation.slides[0].shapes

    # Importa il grafico denominato "Chart 1" dal primo foglio della cartella di lavoro e aggiungilo alla raccolta di forme.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Salva la presentazione risultante in un file.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Risultato](example3_image1.png)

### **Esempio di importazione di tutti i grafici Excel**

Immaginiamo di avere una cartella di lavoro Excel piena di grafici e di doverli importare tutti in una presentazione. Ogni grafico dovrebbe essere collocato su una nuova diapositiva.

Il codice seguente itera su tutti i fogli di lavoro nel file Excel di origine, estrae i grafici da ciascun foglio e aggiunge ogni grafico a una diapositiva separata utilizzando un layout di diapositiva vuoto. Nella presentazione risultante, verranno incorporati solo i dati del grafico, non l'intera cartella di lavoro.

```py
# Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Crea una nuova presentazione PowerPoint.
with slides.Presentation() as presentation:
    # Recupera il layout della diapositiva vuota.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Ottieni i nomi di tutti i fogli di lavoro contenuti nella cartella di lavoro Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Recupera un dizionario che mappa gli indici dei grafici ai loro nomi per il foglio di lavoro.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Aggiungi una nuova diapositiva usando il layout vuoto.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Importa il grafico specificato dalla cartella di lavoro Excel nella raccolta di forme della diapositiva.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Salva la presentazione risultante in un file.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Riepilogo**

Questo meccanismo, disponibile direttamente in Aspose.Slides, combina la gestione dei dati Excel e delle presentazioni in un unico luogo. Consente di creare diapositive con grafici visuali e dati presentati come tabelle Excel — senza librerie aggiuntive o integrazioni complesse.