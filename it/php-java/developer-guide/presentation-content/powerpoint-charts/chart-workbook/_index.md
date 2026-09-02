---
title: Gestire le cartelle di lavoro dei grafici nelle presentazioni con PHP
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/php-java/chart-workbook/
keywords:
- cartella di lavoro grafico
- dati del grafico
- cella della cartella di lavoro
- etichetta dati
- foglio di lavoro
- origine dati
- cartella di lavoro esterna
- dati esterni
- cache del grafico
- recupero della cartella di lavoro
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri Aspose.Slides per PHP via Java: gestisci facilmente le cartelle di lavoro dei grafici in formato PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'utilizzo di cartelle di lavoro esterne come origini dati per i grafici. Gli esempi mostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e Scrivere i Dati del Grafico da una Cartella di Lavoro**

Aspose.Slides fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#writeWorkbookStream) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti i dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile all'origine.

Questo codice PHP dimostra un'operazione di esempio:

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

## **Impostare una Cella WorkBook come Etichetta Dati del Grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/php-java/aspose.slides/presentation).
2. Ottenere il riferimento di una diapositiva tramite il suo indice.
3. Aggiungere un grafico a bolle con alcuni dati.
4. Accedere alla serie del grafico.
5. Impostare la cella della cartella di lavoro come etichetta dati.
6. Salvare la presentazione.

Questo codice PHP mostra come impostare una cella della cartella di lavoro come etichetta dati del grafico:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Istanzia una classe di presentazione che rappresenta un file di presentazione
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

Questo codice PHP dimostra un'operazione in cui il metodo [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdataworkbook/#getWorksheets) è utilizzato per accedere a una collezione di fogli di lavoro:

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

## **Rilevare Formati di Cartella di Lavoro Incorporati Non Supportati**

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `getEmbeddedWorkbookType` su [ChartData](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/php-java/aspose.slides/workbooktype/) per rilevare i formati non supportati e ignorare quei grafici.

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

## **Cartella di Lavoro Esterna**

Aspose.Slides supporta le cartelle di lavoro esterne come origine dati per i grafici.

### **Creare una Cartella di Lavoro Esterna**

Utilizzando i metodi **`readWorkbookStream`** e **`setExternalWorkbook`**, è possibile creare una cartella di lavoro esterna da zero o rendere esterna una cartella di lavoro interna.

Questo codice PHP dimostra il processo di creazione della cartella di lavoro esterna:

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

### **Impostare una Cartella di Lavoro Esterna**

Utilizzando il metodo **`setExternalWorkbook`**, è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Sebbene non sia possibile modificare i dati nelle cartelle di lavoro archiviate in posizioni o risorse remote, è comunque possibile utilizzare tali cartelle di lavoro come origine dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, viene convertito automaticamente in un percorso assoluto.

Questo codice PHP mostra come impostare una cartella di lavoro esterna:

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

Il parametro `ChartData` (sotto il metodo `setExternalWorkbook`) è usato per specificare se una cartella di lavoro Excel verrà caricata o meno. 

* Quando il valore di `ChartData` è impostato su `false`, viene aggiornato solo il percorso della cartella di lavoro — i dati del grafico non verranno caricati o aggiornati dalla cartella di lavoro di destinazione. Potrebbe essere utile utilizzare questa impostazione quando la cartella di lavoro di destinazione è inesistente o non disponibile. 
* Quando il valore di `ChartData` è impostato su `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

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

### **Ottenere il Percorso della Cartella di Lavoro Fonte Dati Esterna di un Grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/php-java/aspose.slides/presentation).
2. Ottenere il riferimento di una diapositiva tramite il suo indice.
3. Creare un oggetto per la forma del grafico.
4. Creare un oggetto per il tipo sorgente (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
5. Specificare la condizione pertinente in base al fatto che il tipo sorgente sia lo stesso del tipo di origine dati della cartella di lavoro esterna.

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

È possibile modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui si apportano modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene sollevata un'eccezione.

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

### **Recuperare una Cartella di Lavoro dalla Cache del Grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Creare [LoadOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/), configurarlo con [SpreadsheetOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/spreadsheetoptions/), e chiamare [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) con `true` prima di aprire la presentazione.

Il seguente esempio PHP apre una presentazione il cui grafico fa riferimento a una cartella di lavoro esterna non disponibile e accede ai dati recuperati tramite [Chart::getChartData](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/#getChartData) e [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

Se la cartella di lavoro esterna è non disponibile e il recupero è disabilitato, Aspose.Slides solleva un'eccezione. Abilitare il recupero solo quando l'utilizzo dei dati del grafico memorizzati nella cache è un'opzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/getdatasourcetype/) e un [path to an external workbook](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/getexternalworkbookpath/); se l'origine è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi alle cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, viene automaticamente convertito in un percorso assoluto. Questo è comodo per la portabilità del progetto; tuttavia, è necessario tenere presente che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso utilizzare cartelle di lavoro situate su risorse o condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica delle cartelle di lavoro remote direttamente da Aspose.Slides non è supportata: possono essere utilizzate solo come sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno durante il salvataggio della presentazione?**

No. La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/getexternalworkbookpath/) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato quando la presentazione viene salvata.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password al momento del collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, utilizzando [Aspose.Cells](/cells/php-java/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ogni grafico al successivo caricamento dei dati.