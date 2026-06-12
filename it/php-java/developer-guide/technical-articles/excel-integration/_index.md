---
title: Integra i dati Excel nelle presentazioni PowerPoint
linktitle: Integrazione Excel
type: docs
weight: 330
url: /it/php-java/excel-integration/
keywords:
- Excel
- cartella di lavoro
- leggi Excel
- integrare Excel
- fonte dati
- stampa unione
- importa tabella
- Excel in PowerPoint
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Leggi i dati dalle cartelle di lavoro Excel utilizzando Aspose.Slides per PHP via Java. Carica fogli e celle e usa i valori per generare presentazioni PowerPoint basate sui dati."
---
## **Introduzione**

Le presentazioni PowerPoint sono un modo potente per visualizzare e comunicare informazioni. Spesso vengono usate in combinazione con le cartelle di lavoro Excel, dove Excel funge da eccellente fonte di dati strutturati e PowerPoint eccelle nella visualizzazione di tali dati per il pubblico.

Esistono molti scenari pratici in cui combinare Excel e PowerPoint è fondamentale: unioni di stampa, popolamento di tabelle dati, generazione di una diapositiva per ogni record (generazione batch di diapositive), creazione di materiale formativo e consolidamento di più report Excel in un'unica presentazione, per citarne alcuni.

Fino a ora, implementare tali funzionalità con l'API Aspose.Slides richiedeva l'uso di soluzioni di terze parti come Aspose.Cells. Sebbene questi strumenti siano robusti, possono risultare eccessivamente complessi e costosi per gli utenti che necessitano solo di funzionalità di integrazione dati di base.

## **Come funziona**

Per semplificare e rendere più fluido il lavoro con i dati Excel, Aspose.Slides ha introdotto nuove classi per leggere i dati dalle cartelle di lavoro Excel e importare contenuti in una presentazione. Questa funzionalità apre potenti nuove possibilità per gli utenti dell'API che desiderano sfruttare Excel come fonte di dati nei loro flussi di lavoro di presentazione.

La nuova funzionalità è progettata per l'accesso generico ai dati e non è integrata nel Presentation Document Object Model (DOM). Ciò significa che *non consente la modifica o il salvataggio dei file Excel* — il suo unico scopo è aprire le cartelle di lavoro e navigare nel loro contenuto per recuperare i dati delle celle.

Al centro di questa funzionalità c'è la nuova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/exceldataworkbook/). Questa classe consente di caricare una cartella di lavoro Excel da un file locale o da uno stream. Una volta caricata, fornisce diverse sovraccarichi del metodo [getCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/exceldataworkbook/#getCell), che è possibile utilizzare per recuperare celle specifiche in base alla loro posizione (ad esempio, indici di riga e colonna o intervalli denominati).

Ogni chiamata a [getCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/exceldataworkbook/#getCell) restituisce un'istanza della classe [ExcelDataCell](https://reference.aspose.com/slides/it/php-java/aspose.slides/exceldatacell/). Questo oggetto rappresenta una singola cella nella cartella di lavoro Excel e fornisce l'accesso al suo valore in modo semplice e intuitivo.

#### **Importa un grafico Excel**

Il passo successivo per estendere la funzionalità è la classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/it/php-java/aspose.slides/excelworkbookimporter/). Questa classe di utilità fornisce la possibilità di importare contenuti da una cartella di lavoro Excel in una presentazione. Contiene diversi sovraccarichi del metodo [addChartFromWorkbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), che ti aiutano a recuperare il grafico selezionato dalla cartella di lavoro Excel specificata e ad aggiungerlo alla fine della collezione di forme fornita alle coordinate specificate.

In sintesi, è un'API leggera e semplice per leggere dati Excel — esattamente ciò di cui molti sviluppatori hanno bisogno senza l'overhead di una completa libreria di elaborazione di fogli di calcolo.

## **Scriviamo del codice**

### **Esempio di scenario di unione di stampa**

Nel seguente esempio, implementeremo un semplice scenario di unione di stampa generando più presentazioni basate sui dati contenuti in una cartella di lavoro Excel.

Per iniziare, abbiamo bisogno di due cose:
1. Una cartella di lavoro Excel contenente i dati

![Esempio di dati Excel](example1_image0.png)

2. Modello di presentazione PowerPoint

![Esempio di modello PowerPoint](example1_image1.png)

```php
// Carica la cartella di lavoro Excel con i dati dei dipendenti.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Carica il modello di presentazione.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Scorri le righe Excel (esclusa l'intestazione alla riga 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Crea una nuova presentazione per ogni record dipendente.
        $employeePresentation = new Presentation();

        try {
            // Rimuovi la diapositiva vuota predefinita.
            $employeePresentation->getSlides()->removeAt(0);

            // Clona la diapositiva modello nella nuova presentazione.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Ottieni i paragrafi dalla forma di destinazione (si assume che l'indice forma 1 sia usato).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Sostituisci i segnaposto con i dati da Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Save the personalized presentation to a separate file.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Risultato](example1_image2.png)

### **Esempio di tabella Excel**

Nel secondo esempio, copiamo semplicemente i dati da una tabella Excel e li visualizziamo su una diapositiva PowerPoint in un formato più gradevole dal punto di vista visivo.

In questo esempio, riutilizziamo la stessa cartella di lavoro Excel del primo esempio, che contiene una semplice tabella dei dipendenti.

```php
// Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Crea una nuova presentazione PowerPoint.
$presentation = new Presentation();

try {
    // Aggiungi una forma tabella alla prima diapositiva.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Compila la tabella PowerPoint con i dati dalla cartella di lavoro Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Salva la presentazione risultante in un file.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Risultato](example2_image0.png)

### **Esempio di importazione di un grafico Excel**

In questo esempio, importiamo un grafico dal primo foglio di lavoro della cartella di lavoro Excel usata nell'esempio precedente. Il grafico sarà collegato alla cartella di lavoro esterna nella presentazione risultante.

Per prima cosa, aggiungiamo un grafico a torta alla cartella di lavoro Excel basato sulla tabella dei dipendenti.

![Esempio di grafico Excel](example3_image0.png)

```php
// Crea una nuova presentazione PowerPoint.
$presentation = new Presentation();
try {
    // Ottieni la collezione di forme della prima diapositiva.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Importa il grafico denominato "Chart 1" dal primo foglio della cartella di lavoro e aggiungilo alla collezione di forme.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Salva la presentazione risultante in un file.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Risultato](example3_image1.png)

### **Esempio di importazione di tutti i grafici Excel**

Immaginiamo di avere una cartella di lavoro Excel piena di grafici e di doverli importare tutti in una presentazione. Ogni grafico dovrebbe essere inserito su una nuova diapositiva.

Il codice seguente itera attraverso tutti i fogli di lavoro nel file Excel di origine, estrae i grafici da ciascun foglio e aggiunge ogni grafico a una diapositiva separata utilizzando un layout di diapositiva vuota. Nella presentazione risultante, saranno incorporati solo i dati del grafico, non l'intera cartella di lavoro.

```php
// Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Crea una nuova presentazione PowerPoint.
$presentation = new Presentation();
try {
    // Recupera il layout diapositiva vuoto.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Ottieni i nomi di tutti i fogli di lavoro contenuti nella cartella di lavoro Excel.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Recupera una mappa che associa gli indici dei grafici ai nomi dei grafici per il foglio di lavoro.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Aggiungi una nuova diapositiva usando il layout vuoto.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Importa il grafico specificato dalla cartella di lavoro Excel nella collezione di forme della diapositiva.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Salva la presentazione risultante in un file.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Riepilogo**

Questo meccanismo, disponibile direttamente in Aspose.Slides, combina la gestione dei dati Excel e delle presentazioni in un unico luogo. Consente di creare diapositive con grafici visivi e dati presentati come tabelle Excel — senza librerie aggiuntive o integrazioni complesse.