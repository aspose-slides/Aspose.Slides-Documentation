---
title: Integrare i dati di Excel nelle presentazioni PowerPoint
linktitle: Integrazione Excel
type: docs
weight: 330
url: /it/cpp/excel-integration/
keywords:
- Excel
- cartella di lavoro
- leggere Excel
- integrare Excel
- fonte dati
- unione di stampa
- importare tabella
- Excel in PowerPoint
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Leggi i dati dalle cartelle di lavoro Excel in Aspose.Slides utilizzando l'API ExcelDataWorkbook. Carica fogli e celle e usa i valori per generare presentazioni PowerPoint basate sui dati."
---
## **Introduzione**

Le presentazioni PowerPoint sono un modo potente per visualizzare e comunicare informazioni. Spesso vengono utilizzate in combinazione con le cartelle di lavoro Excel, dove Excel funge da eccellente fonte di dati strutturati e PowerPoint eccelle nella visualizzazione di tali dati per un pubblico.

Esistono molti scenari pratici in cui combinare Excel e PowerPoint è essenziale: unioni di stampa (mail merge), popolamento di tabelle dati, generazione di una diapositiva per ogni record (generazione batch di diapositive), creazione di materiali di formazione e consolidamento di più report Excel in un'unica presentazione, per citarne alcuni.

Fino a poco tempo fa, implementare tali funzionalità con l'API Aspose.Slides richiedeva l'uso di soluzioni di terze parti come Aspose.Cells. Sebbene questi strumenti siano robusti, possono risultare eccessivamente complessi e costosi per gli utenti che hanno bisogno solo di funzionalità di integrazione dati di base.

## **Come funziona**

Per semplificare e rendere più fluido il lavoro con i dati di Excel, Aspose.Slides ha introdotto nuove classi per leggere i dati da cartelle di lavoro Excel e importare contenuti in una presentazione. Questa funzionalità apre nuove e potenti possibilità per gli utenti dell'API che desiderano sfruttare Excel come fonte di dati nei loro flussi di lavoro di presentazione.

La nuova funzionalità è progettata per l'accesso generico ai dati e non è integrata nel modello a oggetti del documento di presentazione (DOM). Ciò significa *che non consente di modificare o salvare file Excel* — il suo unico scopo è aprire le cartelle di lavoro e navigare nel loro contenuto per recuperare i dati delle celle.

Al centro di questa funzionalità c’è la nuova classe [ExcelDataWorkbook](https://reference.aspose.com/slides/it/cpp/aspose.slides.excel/exceldataworkbook/) . Questa classe consente di caricare una cartella di lavoro Excel da un file locale o da uno stream. Una volta caricata, fornisce diverse sovraccarichi del metodo [GetCell](https://reference.aspose.com/slides/it/cpp/aspose.slides.excel/exceldataworkbook/getcell/) , che è possibile utilizzare per recuperare celle specifiche in base alla loro posizione (ad esempio, indici di riga e colonna o intervalli denominati).

Ogni chiamata a [GetCell](https://reference.aspose.com/slides/it/cpp/aspose.slides.excel/exceldataworkbook/getcell/) restituisce un'istanza della classe [ExcelDataCell](https://reference.aspose.com/slides/it/cpp/aspose.slides.excel/exceldatacell/) . Questo oggetto rappresenta una singola cella nella cartella di lavoro Excel e fornisce accesso al suo valore in modo semplice e intuitivo.

#### **Importa un grafico Excel**

Il passo successivo per estendere la funzionalità è la classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/it/cpp/aspose.slides.import/excelworkbookimporter/) . Questa classe di utilità fornisce funzionalità per importare contenuti da una cartella di lavoro Excel in una presentazione. Contiene diversi sovraccarichi del metodo [AddChartFromWorkbook](https://reference.aspose.com/slides/it/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) , che aiuta a recuperare il grafico selezionato dalla cartella di lavoro Excel specificata e ad aggiungerlo alla fine della collezione di forme fornita alle coordinate specificate.

In breve, è un'API leggera e semplice per la lettura dei dati di Excel — esattamente ciò di cui molti sviluppatori hanno bisogno senza l'overhead di una libreria completa per l'elaborazione dei fogli di calcolo.

## **Scriviamo il codice**

### **Esempio di scenario Mail Merge**

Nel seguente esempio implementeremo uno scenario semplice di Mail Merge generando più presentazioni basate sui dati memorizzati in una cartella di lavoro Excel.

Per iniziare, abbiamo bisogno di due cose:
1. Una cartella di lavoro Excel contenente i dati

![Esempio di dati Excel](example1_image0.png)

2. Modello di presentazione PowerPoint

![Esempio di modello PowerPoint](example1_image1.png)

```cpp
// Carica la cartella di lavoro Excel con i dati dei dipendenti.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Carica il modello di presentazione.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Scorri le righe di Excel (escludendo l'intestazione alla riga 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Crea una nuova presentazione per ogni record dipendente.
    auto employeePresentation = MakeObject<Presentation>();

    // Rimuovi la diapositiva vuota predefinita.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Clona la diapositiva modello nella nuova presentazione.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Ottieni i paragrafi dalla forma target (si assume che l'indice forma 1 sia utilizzato).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Sostituisci i segnaposto con i dati provenienti da Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Salva la presentazione personalizzata in un file separato.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Risultato](example1_image2.png)

### **Esempio di tabella Excel**

Nel secondo esempio copiamo semplicemente i dati da una tabella Excel e li visualizziamo su una diapositiva PowerPoint in un formato più accattivante dal punto di vista visivo.

In questo esempio riutilizziamo la stessa cartella di lavoro Excel del primo esempio, che contiene una semplice tabella dipendenti.

```cpp
// Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Crea una nuova presentazione PowerPoint.
auto presentation = MakeObject<Presentation>();

// Aggiungi una forma tabella alla prima diapositiva.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Riempie la tabella PowerPoint con i dati dalla cartella di lavoro Excel.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Salva la presentazione risultante in un file.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Risultato](example2_image0.png)

### **Esempio di importazione di un grafico Excel**

In questo esempio importiamo un grafico dal primo foglio di lavoro della cartella di lavoro Excel usata nell'esempio precedente. Il grafico sarà collegato alla cartella di lavoro esterna nella presentazione risultante.

Innanzitutto, aggiungiamo un grafico a torta alla cartella di lavoro Excel basato sulla tabella dei dipendenti.

![Esempio di grafico Excel](example3_image0.png)

```cpp
// Crea una nuova presentazione PowerPoint.
auto presentation = MakeObject<Presentation>();

// Ottieni la collezione di forme della prima diapositiva.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Importa il grafico denominato "Chart 1" dal primo foglio della cartella di lavoro e aggiungilo alla collezione di forme.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Salva la presentazione risultante in un file.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Risultato](example3_image1.png)

### **Esempio di importazione di tutti i grafici Excel**

Immaginiamo di avere una cartella di lavoro Excel piena di grafici e di doverli importare tutti in una presentazione. Ogni grafico dovrebbe essere posizionato su una nuova diapositiva.

Il codice seguente itera su tutti i fogli di lavoro nel file Excel di origine, estrae i grafici da ciascun foglio e aggiunge ogni grafico a una diapositiva separata utilizzando un layout di diapositiva vuoto. Nella presentazione risultante verranno incorporati solo i dati del grafico, non l'intera cartella di lavoro.

```cpp
// Carica la cartella di lavoro Excel contenente i dati dei dipendenti.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Crea una nuova presentazione PowerPoint.
auto presentation = MakeObject<Presentation>();

// Recupera il layout della diapositiva vuota.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Ottieni i nomi di tutti i fogli di lavoro contenuti nella cartella di lavoro Excel.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Recupera un dizionario che mappa gli indici dei grafici ai nomi dei grafici per il foglio di lavoro.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Aggiungi una nuova diapositiva usando il layout vuoto.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Importa il grafico specificato dalla cartella di lavoro Excel nella collezione di forme della diapositiva.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Salva la presentazione risultante in un file.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Riepilogo**

Questo meccanismo, disponibile direttamente in Aspose.Slides, combina il lavoro con i dati Excel e le presentazioni in un unico posto. Consente di creare diapositive con grafici visivi e dati presentati come tabelle Excel — senza librerie aggiuntive o integrazioni complesse.