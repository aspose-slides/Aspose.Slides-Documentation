---
title: Beheer grafiek-werkboeken in presentaties met PHP
linktitle: Grafiek-werkboek
type: docs
weight: 70
url: /nl/php-java/chart-workbook/
keywords:
- grafiek-werkboek
- grafiekgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekcache
- werkboekherstel
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek Aspose.Slides voor PHP via Java: beheer moeiteloos grafiek-werkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiek‑datumnamen, werkbladcollecties kunt benaderen en het type gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als grafiek‑gegevensbronnen. De voorbeelden tonen hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een grafiek is gekoppeld kunt ophalen, en grafiekgegevens kunt bewerken wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**
Aspose.Slides biedt de [readWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#readWorkbookStream) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#writeWorkbookStream) methoden die u in staat stellen grafiekgegevens‑werkboeken te lezen en te schrijven (bevat grafiekgegevens bewerkt met Aspose.Cells). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten worden georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

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

### **Grafiekindeling valideren na wijziging van het werkboek**

Wanneer u een ingesloten werkboek vervangt door een gewijzigde versie, behoudt de grafiek zijn oorspronkelijke series‑ en categoriecollecties. Deze mismatch kan ervoor zorgen dat [Chart::validateChartLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/validatechartlayout/) faalt met een index‑out‑of‑range‑fout. Maak de bestaande series en categorieën leeg voordat u het bijgewerkte werkboek terugschrijft naar de grafiek.

```php
// Na het aanpassen van de werkboek‑stream (bijvoorbeeld met Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Verwijder bestaande gegevens‑referenties.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Het leegmaken van de collecties zorgt ervoor dat de grafiekgegevensstructuur consistent is met het nieuwe werkboek, waardoor `validateChartLayout` zonder fouten kan worden voltooid.

## **Een werkboekcel instellen als grafiekgegevens‑label**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Haal de referentie van een dia op via de index.  
1. Voeg een Bubbel‑grafiek toe met enkele gegevens.  
1. Benader de grafiekseries.  
1. Stel de werkboekcel in als data‑label.  
1. Sla de presentatie op.  

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Instantieert een presentatie‑klasse die een presentatie‑bestand vertegenwoordigt
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

## **Werkbladen beheren**

Deze PHP‑code demonstreert een bewerking waarbij de [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#getWorksheets) methode wordt gebruikt om een werkbladcollectie te benaderen:

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

## **Het type gegevensbron opgeven**

Deze PHP‑code laat zien hoe u een type voor een gegevensbron opgeeft:

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

## **Niet‑ondersteunde ingesloten werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. U kunt de `getEmbeddedWorkbookType`‑methode op [ChartData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/) gebruiken in combinatie met de [WorkbookType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/workbooktype/)‑enumeratie om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
      # Ingesloten werkboek is in .xlsb-formaat, wat niet ondersteund wordt.
      continue;
    }

    # Lees of bewerk hier de grafiek-werkboekgegevens.
  }
} finally {
  $presentation->dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt externe werkboeken als gegevensbron voor grafieken.

### **Een extern werkboek maken**

Met behulp van de **`readWorkbookStream`**‑ en **`setExternalWorkbook`**‑methoden kunt u een extern werkboek vanaf nul maken of een intern werkboek extern maken.

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

### **Een extern werkboek instellen**

Met de **`setExternalWorkbook`**‑methode kunt u een extern werkboek aan een grafiek toewijzen als diens gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe werkboek bij te werken (indien het laatste is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds als externe gegevensbron gebruiken. Als er een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

```php
  # Maakt een instantie van de Presentation‑klasse
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

De `ChartData`‑parameter (onder de `setExternalWorkbook`‑methode) wordt gebruikt om op te geven of een Excel‑werkboek wel of niet wordt geladen.

* Wanneer de `ChartData`‑waarde is ingesteld op `false`, wordt alleen het pad van het werkboek bijgewerkt — de grafiekgegevens worden niet geladen of geüpdatet vanuit het doel‑werkboek. U kunt deze instelling gebruiken wanneer het doel‑werkboek niet bestaat of niet beschikbaar is.  
* Wanneer de `ChartData`‑waarde is ingesteld op `true`, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

```php
  # Maakt een instantie van de Presentation‑klasse
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

### **Het pad van het externe gegevensbron‑werkboek van een grafiek ophalen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Haal de referentie van een dia op via de index.  
1. Maak een object voor de grafiekvorm.  
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.  
1. Specificeer de relevante voorwaarde op basis van het feit dat het bron‑type hetzelfde is als het type van de externe werkboek‑gegevensbron.  

```php
  # Maakt een instantie van de Presentation‑klasse
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Slaat de presentatie op
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

```php
  # Maakt een instantie van de Presentation‑klasse
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

### **Een werkboek herstellen uit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren uit de gegevens die in de presentatie zijn gecached. Maak [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/), configureer deze met [SpreadsheetOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/spreadsheetoptions/), en roep [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) aan met `true` voordat u de presentatie opent.

Het volgende PHP‑voorbeeld opent een presentatie waarvan de grafiek een niet‑beschikbaar extern werkboek referereert en de herstelde gegevens benadert via [Chart::getChartData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/#getChartData) en [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Lees of bewerk hier de herstelde werkboekgegevens.
} finally {
    $presentation->dispose();
}
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getdatasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getexternalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om er zeker van te zijn dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; houd er echter rekening mee dat de presentatie het absolute pad in het PPTX‑bestand opslaat.

**Kan ik werkboeken gebruiken die zich op netwerklocaties / shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het rechtstreeks bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getexternalworkbookpath/) op en gebruikt deze om gegevens te lezen. Het externe bestand zelf wordt niet aangepast wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de bescherming vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/php-java/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, zal een update van dat bestand bij de volgende lading van de gegevens in elke grafiek zichtbaar zijn.