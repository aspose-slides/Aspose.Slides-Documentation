---
title: Beheer chart-werkboeken in presentaties met PHP
linktitle: Chart-werkboek
type: docs
weight: 70
url: /nl/php-java/chart-workbook/
keywords:
- chart-werkboek
- chart-gegevens
- werkboekcel
- datalabel
- werkblad
- gegevensbron
- extern werkboek
- externe data
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek Aspose.Slides voor PHP via Java: beheert moeiteloos chart-werkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met chart‑werkboeken in Aspose.Slides kunt werken. Het laat zien hoe u chart‑gegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als chart‑datacontlabels, werkbladcollecties kunt benaderen en het type gegevensbron voor chart‑waarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als chart‑gegevensbronnen. De voorbeelden laten zien hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een chart is gekoppeld opvraagt en chart‑gegevens bewerkt wanneer het werkboek beschikbaar is.

## **Lezen en schrijven van chart‑gegevens vanuit een werkboek**
Aspose.Slides biedt de [readWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#readWorkbookStream) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#writeWorkbookStream) methoden die u toestaan chart‑gegevenswerkboeken te lezen en te schrijven (bevat chart‑gegevens die bewerkt zijn met Aspose.Cells). **Opmerking** dat de chart‑gegevens op dezelfde manier moet worden georganiseerd of een structuur moet hebben die vergelijkbaar is met de bron.

This PHP code demonstrates a sample operation:

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

## **Een werkboekcel instellen als chart‑datacontlabel**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/php-java/aspose.slides/presentation) klasse.
1. Haal een referentie naar een slide op via de index.
1. Voeg een bubbel‑chart toe met enige data.
1. Benader de chart‑series.
1. Stel de werkboekcel in als een datalabel.
1. Sla de presentatie op.

This PHP code shows you to set a workbook cell as a chart data label:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Instantieert een presentatieklasse die een presentatiebestand voorstelt
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

This PHP code demonstrates an operation where the [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#getWorksheets) method is used to access a worksheet collection:

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

This PHP code shows you how to specify a type for a data source:

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

Aspose.Slides ondersteunt het Excel‑binaire werkboek (.xlsb)‑formaat dat in sommige charts kan worden ingesloten niet. U kunt de `getEmbeddedWorkbookType`‑methode op [ChartData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die charts over te slaan.

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
      # Ingesloten werkboek is in .xlsb-formaat, wat niet wordt ondersteund.
      continue;
    }

    # Lees hier of bewerk de chart-werkboekgegevens.
  }
} finally {
  $presentation->dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt externe werkboeken als gegevensbron voor charts.

### **Een extern werkboek maken**

Met de **`readWorkbookStream`**- en **`setExternalWorkbook`**-methoden kunt u ofwel een extern werkboek vanaf nul maken of een intern werkboek extern maken.

This PHP code demonstrates the external workbook creation process:

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

Met de **`setExternalWorkbook`**‑methode kunt u een extern werkboek aan een chart toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als dit later verplaatst is).

Hoewel u de data in werkboeken die op een externe locatie of resource staan niet kunt bewerken, kunt u die werkboeken nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

This PHP code shows you how to set an external workbook:

```php
  # Maakt een instantie van de Presentation-klasse
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

* Wanneer de `ChartData`‑waarde op `false` wordt gezet, wordt alleen het pad van het werkboek bijgewerkt — de chart‑gegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek. U kunt deze instelling gebruiken wanneer het doel‑werkboek niet bestaat of niet beschikbaar is. 
* Wanneer de `ChartData`‑waarde op `true` wordt gezet, worden de chart‑gegevens bijgewerkt vanuit het doel‑werkboek.

```php
  # Maakt een instantie van de Presentation-klasse
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

### **Het pad van het externe gegevensbron‑werkboek van een chart ophalen**

1. Maak een instantie van de [Presentation](https://apireference.aspose.com/slides/nl/php-java/aspose.slides/presentation) klasse.
1. Haal een referentie naar een slide op via de index.
1. Creëer een object voor de chart‑vorm.
1. Creëer een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de chart vertegenwoordigt.
1. Specificeer de relevante voorwaarde op basis van het feit dat het bron‑type gelijk is aan het type van de externe werkboek‑gegevensbron.

This PHP code demonstrates the operation:

```php
  # Maakt een instantie van de Presentation-klasse
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

### **Chart‑gegevens bewerken**

U kunt de data in externe werkboeken op dezelfde manier bewerken als u veranderingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

This PHP code is an implementation of the described process:

```php
  # Maakt een instantie van de Presentation-klasse
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

## **FAQ**

**Kan ik bepalen of een specifieke chart gekoppeld is aan een extern of een ingesloten werkboek?**

Ja. Een chart heeft een [data source type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getdatasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getexternalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om zeker te zijn dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkmiddelen/‑shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand over bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getexternalworkbookpath/) op en gebruikt die voor het lezen van gegevens. Het externe bestand zelf wordt niet aangepast wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord beveiligd is?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een veelgebruikte aanpak is om de beveiliging van tevoren te verwijderen of een gedecodeerde kopie (bijvoorbeeld met [Aspose.Cells](/cells/php-java/)) klaar te hebben en naar die kopie te linken.

**Kunnen meerdere charts naar hetzelfde externe werkboek verwijzen?**

Ja. Elke chart slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, zal een bijwerking van dat bestand in elke chart zichtbaar worden bij de volgende keer dat de gegevens worden geladen.