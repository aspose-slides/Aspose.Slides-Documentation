---
title: Integrare i dati Excel nelle presentazioni PowerPoint
linktitle: Integrazione Excel
type: docs
weight: 330
url: /it/java/excel-integration/
keywords:
- Excel
- cartella di lavoro
- leggere Excel
- integrare Excel
- fonte dati
- stampa unione
- importare tabella
- Excel in PowerPoint
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Leggi i dati dalle cartelle di lavoro Excel in Aspose.Slides usando l'API ExcelDataWorkbook. Carica fogli e celle e usa i valori per generare presentazioni PowerPoint basate sui dati."
---
## **Introduzione**

Le presentazioni PowerPoint sono un modo potente per visualizzare e comunicare informazioni. Sono spesso utilizzate in combinazione con le cartelle di lavoro Excel, dove Excel funge da eccellente fonte di dati strutturati e PowerPoint si distingue nella visualizzazione di tali dati per un pubblico.

Esistono molti scenari pratici in cui combinare Excel e PowerPoint è essenziale: stampa unione, popolamento di tabelle dati, generazione di una diapositiva per record di dati (generazione batch di diapositive), creazione di materiale formativo e consolidamento di più report Excel in una singola presentazione, per citarne alcuni.

Fino a ora, implementare tali funzionalità con l'API Aspose.Slides richiedeva l'uso di soluzioni di terze parti come Aspose.Cells. Sebbene questi strumenti siano robusti, possono risultare eccessivamente complessi e costosi per gli utenti che necessitano solo di funzionalità di integrazione dati di base.

## **Come funziona**

Per semplificare e rendere più fluido il lavoro con i dati Excel, Aspose.Slides ha introdotto nuove classi per leggere i dati da cartelle di lavoro Excel e importare contenuti in una presentazione. Questa funzione apre nuove possibilità potenti per gli utenti dell'API che desiderano sfruttare Excel come fonte di dati all'interno dei loro flussi di lavoro di presentazione.

La nuova funzionalità è progettata per l'accesso generico ai dati e non è integrata nel Presentation Document Object Model (DOM). Questo significa *che non consente la modifica o il salvataggio di file Excel* — il suo unico scopo è aprire le cartelle di lavoro e navigare nel loro contenuto per recuperare i dati delle celle.

Al centro di questa funzionalità c'è la nuova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/exceldataworkbook/). Questa classe consente di caricare una cartella di lavoro Excel da un file locale o da uno stream. Una volta caricata, fornisce diverse sovraccarichi del metodo [getCell](https://reference.aspose.com/slides/it/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) che è possibile utilizzare per recuperare celle specifiche in base alla loro posizione (ad esempio indici di riga e colonna o intervalli nominati).

Ogni chiamata a [getCell](https://reference.aspose.com/slides/it/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) restituisce un'istanza della classe [ExcelDataCell](https://reference.aspose.com/slides/it/java/com.aspose.slides/exceldatacell/). Questo oggetto rappresenta una singola cella nella cartella di lavoro Excel e fornisce l'accesso al suo valore in modo semplice e intuitivo.

#### **Importa un grafico Excel**

Il passo successivo per estendere la funzionalità è la classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/it/java/com.aspose.slides/excelworkbookimporter/). Questa classe di utilità fornisce funzionalità per importare contenuti da una cartella di lavoro Excel in una presentazione. Contiene diversi sovraccarichi del metodo [addChartFromWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) che aiutano a recuperare il grafico selezionato dalla cartella di lavoro Excel specificata e ad aggiungerlo alla fine della collezione di forme fornita alle coordinate specificate.

In sintesi, si tratta di un'API leggera e diretta per la lettura dei dati Excel — esattamente ciò di cui molti sviluppatori hanno bisogno senza l'overhead di una libreria completa di elaborazione di fogli di calcolo.

## **Scriviamo del codice**

### **Esempio di scenario di stampa unione**

Nel seguente esempio, implementeremo un semplice scenario di stampa unione generando più presentazioni in base ai dati memorizzati in una cartella di lavoro Excel.

Per iniziare, servono due elementi:
1. Una cartella di lavoro Excel contenente i dati

![Esempio di dati Excel](example1_image0.png)

2.  Modello di presentazione PowerPoint

![Esempio di modello PowerPoint](example1_image1.png)

```java
// Carica la cartella di lavoro Excel con i dati dei dipendenti.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Carica il modello di presentazione.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Itera le righe Excel (escludendo l'intestazione alla riga 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Crea una nuova presentazione per ciascun record dipendente.
        Presentation employeePresentation = new Presentation();

        try {
            // Rimuovi la diapositiva vuota predefinita.
            employeePresentation.getSlides().removeAt(0);

            // Clona la diapositiva modello nella nuova presentazione.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Ottieni i paragrafi dalla forma target (si assume che l'indice forma 1 sia usato).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Sostituisci i segnaposto con i dati di Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Salva la presentazione personalizzata in un file separato.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Risultato](example1_image2.png)

### **Esempio di tabella Excel**

Nel secondo esempio, copiamo semplicemente i dati da una tabella Excel e li visualizziamo su una diapositiva PowerPoint in un formato più accattivante.

In questo esempio, riutilizziamo la stessa cartella di lavoro Excel del primo esempio, che contiene una semplice tabella dipendenti.

```java
// Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Crea una nuova presentazione PowerPoint.
Presentation presentation = new Presentation();

try {
    // Aggiungi una forma tabella alla prima diapositiva.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Riempie la tabella PowerPoint con i dati dalla cartella di lavoro Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Salva la presentazione risultante in un file.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Risultato](example2_image0.png)

### **Esempio di importazione di un grafico Excel**

In questo esempio, importiamo un grafico dal primo foglio di lavoro della cartella Excel usata nell'esempio precedente. Il grafico sarà collegato alla cartella di lavoro esterna nella presentazione risultante.

Per prima cosa, aggiungiamo un grafico a torta alla cartella di lavoro Excel basato sulla tabella dei dipendenti.

![Esempio di grafico Excel](example3_image0.png)

```java
// Crea una nuova presentazione PowerPoint.
Presentation presentation = new Presentation();
try {
    // Ottieni la collezione di forme della prima diapositiva.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importa il grafico denominato "Chart 1" dal primo foglio della cartella di lavoro e aggiungilo alla collezione di forme.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Salva la presentazione risultante in un file.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Risultato](example3_image1.png)

### **Esempio di importazione di tutti i grafici Excel**

Immaginiamo di avere una cartella di lavoro Excel piena di grafici e di doverli importare tutti in una presentazione. Ogni grafico dovrebbe essere posizionato su una nuova diapositiva.

Il codice seguente itera su tutti i fogli di lavoro nel file Excel sorgente, estrae i grafici da ciascun foglio e aggiunge ogni grafico a una diapositiva separata usando un layout di diapositiva vuoto. Nella presentazione risultante, verranno incorporati solo i dati del grafico, non l'intera cartella di lavoro.

```java
// Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Crea una nuova presentazione PowerPoint.
Presentation presentation = new Presentation();
try {
    // Recupera il layout vuoto della diapositiva.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Ottieni i nomi di tutti i fogli di lavoro contenuti nella cartella di lavoro Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Recupera una mappa che associa gli indici dei grafici ai nomi dei grafici per il foglio di lavoro.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Aggiungi una nuova diapositiva usando il layout vuoto.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importa il grafico specificato dalla cartella di lavoro Excel nella collezione di forme della diapositiva.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Salva la presentazione risultante in un file.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riepilogo**

Questo meccanismo, disponibile direttamente in Aspose.Slides, combina la gestione dei dati Excel e delle presentazioni in un unico punto. Consente di creare diapositive con grafici visuali e dati presentati come tabelle Excel — senza librerie aggiuntive o integrazioni complesse.