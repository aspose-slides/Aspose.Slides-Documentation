---
title: Gestire i workbook dei grafici nelle presentazioni con PHP
linktitle: Workbook del grafico
type: docs
weight: 70
url: /it/php-java/chart-workbook/
keywords:
- workbook del grafico
- dati del grafico
- cella del workbook
- etichetta dati
- foglio di lavoro
- origine dati
- workbook esterno
- dati esterni
- cache del grafico
- recupero del workbook
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri Aspose.Slides per PHP via Java: gestisci senza sforzo i workbook dei grafici in formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di workbook, utilizzare le celle del workbook come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'uso di workbook esterni come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

## **Leggere e Scrivere Dati del Grafico da un Workbook**
Aspose.Slides fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#writeWorkbookStream) che consentono di leggere e scrivere i workbook dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella della sorgente.

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Convalidare il Layout del Grafico Dopo la Modifica del Workbook**

Quando si sostituisce un workbook incorporato con uno modificato, il grafico mantiene le sue collezioni originali di serie e categorie. Questa discrepanza può causare il fallimento di [Chart::validateChartLayout](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/validatechartlayout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere il workbook aggiornato nel grafico.

```php
// Dopo aver modificato lo stream del workbook (ad es., usando Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Cancella i riferimenti ai dati esistenti.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

La cancellazione delle collezioni garantisce che la struttura dei dati del grafico sia coerente con il nuovo workbook, permettendo a `validateChartLayout` di completarsi senza errori.

## **Impostare una Cella del Workbook come Etichetta Dati del Grafico**

1. Crea un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/php-java/aspose.slides/presentation) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico a bolle con alcuni dati.
4. Accedi alle serie del grafico.
5. Imposta la cella del workbook come etichetta dati.
6. Salva la presentazione.

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Instanzia una classe di presentazione che rappresenta un file di presentazione
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gestire i Fogli di Lavoro**

Questo codice PHP dimostra un'operazione in cui il metodo [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#getWorksheets) viene utilizzato per accedere a una collezione di fogli di lavoro:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Specificare il Tipo di Origine Dati**

Questo codice PHP mostra come specificare un tipo per un'origine dati:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rilevare Formati di Workbook Incorporati Non Supportati**

Aspose.Slides non supporta il formato di workbook Excel binario (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `getEmbeddedWorkbookType` su [ChartData](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/php-java/aspose.slides/workbooktype/) per rilevare formati non supportati e saltare quei grafici.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # Il workbook incorporato è in formato .xlsb, che non è supportato.
      continue;
    }

    # Leggi o modifica i dati del workbook del grafico qui.
  }
} finally {
  $presentation->dispose();
}
```

## **Workbook Esterno**

Aspose.Slides supporta workbook esterni come origine dati per i grafici.

### **Creare un Workbook Esterno**

Utilizzando i metodi **`readWorkbookStream`** e **`setExternalWorkbook`**, è possibile creare un workbook esterno da zero o rendere un workbook interno esterno.

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Impostare un Workbook Esterno**

Utilizzando il metodo **`setExternalWorkbook`**, è possibile assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso del workbook esterno (se quest'ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook archiviati in posizioni remote o risorse, è comunque possibile utilizzare tali workbook come origine dati esterna. Se viene fornito un percorso relativo per un workbook esterno, viene convertito automaticamente in un percorso completo.

Questo codice PHP mostra come impostare un workbook esterno:

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Il parametro `ChartData` (sotto il metodo `setExternalWorkbook`) è usato per specificare se un workbook Excel verrà caricato o meno. 

* Quando il valore di `ChartData` è impostato a `false`, viene aggiornato solo il percorso del workbook — i dati del grafico non verranno caricati né aggiornati dal workbook di destinazione. Potrebbe essere utile utilizzare questa impostazione quando il workbook di destinazione è inesistente o non disponibile. 
* Quando il valore di `ChartData` è impostato a `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ottenere il Percorso del Workbook di Origine Dati Esterno di un Grafico**

1. Crea un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/php-java/aspose.slides/presentation) .
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Crea un oggetto per la forma del grafico.
4. Crea un oggetto per il tipo di sorgente (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
5. Specificare la condizione pertinente basata sul fatto che il tipo di sorgente sia lo stesso del tipo di origine dati del workbook esterno.

Questo codice PHP dimostra l'operazione:

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Salva la presentazione
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Modificare i Dati del Grafico**

È possibile modificare i dati nei workbook esterni allo stesso modo in cui si apportano modifiche al contenuto dei workbook interni. Quando un workbook esterno non può essere caricato, viene sollevata un'eccezione.

Questo codice PHP è un'implementazione del processo descritto:

```php
  # Crea un'istanza della classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Recuperare un Workbook dalla Cache del Grafico**

Se un grafico utilizza un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/), configuralo con [SpreadsheetOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/spreadsheetoptions/), e chiama [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) con `true` prima di aprire la presentazione.

Il seguente esempio PHP apre una presentazione il cui grafico fa riferimento a un workbook esterno non disponibile e accede ai dati recuperati tramite [Chart::getChartData](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/#getChartData) e [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Leggi o modifica i dati del workbook recuperato qui.
} finally {
    $presentation->dispose();
}
```

Se il workbook esterno non è disponibile e il recupero è disabilitato, Aspose.Slides solleva un'eccezione. Abilita il recupero solo quando l'uso dei dati del grafico nella cache è un'alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/getdatasourcetype/) e un [percorso a un workbook esterno](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/getexternalworkbookpath/); se la sorgente è un workbook esterno, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi ai workbook esterni e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, viene automaticamente convertito in un percorso assoluto. Questo è comodo per la portabilità del progetto; tuttavia, è da tenere presente che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso usare workbook situati su risorse di rete/condivisioni?**

Sì, tali workbook possono essere usati come origine dati esterna. Tuttavia, la modifica di workbook remoti direttamente da Aspose.Slides non è supportata: possono essere usati solo come sorgente.

**Aspose.Slides sovrascrive l'XLSX esterno quando salva la presentazione?**

No. La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/getexternalworkbookpath/) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato quando la presentazione viene salvata.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decriptata (ad esempio, usando [Aspose.Cells](/cells/php-java/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file si rifletterà in ciascun grafico al successivo caricamento dei dati.