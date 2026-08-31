---
title: "Správa sešitů diagramů v prezentacích pomocí PHP"
linktitle: "Sešit diagramu"
type: docs
weight: 70
url: /cs/php-java/chart-workbook/
keywords:
  - "sešit diagramu"
  - "data diagramu"
  - "buňka sešitu"
  - "popisek dat"
  - "list"
  - "zdroj dat"
  - "externí sešit"
  - "externí data"
  - "vyrovnávací paměť diagramu"
  - "obnova sešitu"
  - "PowerPoint"
  - "prezentace"
  - "PHP"
  - "Aspose.Slides"
description: "Objevte Aspose.Slides pro PHP prostřednictvím Javy: snadno spravujte sešity diagramů ve formátech PowerPoint a OpenDocument a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s diagramy v sešitech v Aspose.Slides. Ukazuje, jak číst a zapisovat data diagramu prostřednictvím proudů sešitu, používat buňky sešitu jako popisky dat diagramu, přistupovat k kolekcím listů a určit typ zdroje dat pro hodnoty diagramu.

Také popisuje práci s externími sešity jako zdroji dat diagramu. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s diagramem a upravit data diagramu, když je sešit k dispozici.

## **Čtení a zápis dat diagramu ze sešitu**
Aspose.Slides poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#readWorkbookStream) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#writeWorkbookStream), které umožňují číst a zapisovat sešity dat diagramu (obsahující data diagramu upravená pomocí Aspose.Cells). **Poznámka**: data diagramu musejí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento PHP kód ukazuje vzorovou operaci:

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

### **Ověření rozvržení diagramu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, diagram si zachová původní kolekce řad a kategorií. Tento nesoulad může způsobit, že [Chart::validateChartLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/validatechartlayout/) selže s chybou index‑out‑of‑range. Před zápisem aktualizovaného sešitu zpět do diagramu vymažte existující řady a kategorie.

```php
// Po úpravě proudu sešitu (např. pomocí Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Vymazat existující odkazy na data.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Vyprázdnění kolekcí zajistí, že struktura dat diagramu bude konzistentní s novým sešitem, což umožní `validateChartLayout` dokončit běh bez chyb.

## **Nastavení buňky sešitu jako popisku dat diagramu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte bublinový diagram s nějakými daty.
1. Přistupte k řadám diagramu.
1. Nastavte buňku sešitu jako popisek dat.
1. Uložte prezentaci.

Tento PHP kód ukazuje, jak nastavit buňku sešitu jako popisek dat diagramu:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Vytvoří instanci třídy prezentace, která představuje soubor prezentace
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

## **Správa listů**

Tento PHP kód demonstruje operaci, při které je použita metoda [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#getWorksheets) k přístupu ke kolekci listů:

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

## **Určení typu zdroje dat**

Tento PHP kód ukazuje, jak specifikovat typ pro zdroj dat:

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

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který lze vložit do některých diagramů. K detekci nepodporovaných formátů a jejich přeskočení můžete použít metodu `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/workbooktype/).

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
      # Vložený sešit je ve formátu .xlsb, který není podporován.
      continue;
    }

    # Zde přečtěte nebo upravte data sešitu diagramu.
  }
} finally {
  $presentation->dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje externí sešity jako zdroj dat pro diagramy.

### **Vytvoření externího sešitu**

Pomocí metod **`readWorkbookStream`** a **`setExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

Tento PHP kód demonstruje proces vytvoření externího sešitu:

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

### **Nastavení externího sešitu**

Pomocí metody **`setExternalWorkbook`** můžete přiřadit externí sešit k diagramu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když není možné upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity nadále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento PHP kód ukazuje, jak nastavit externí sešit:

```php
  # Vytvoří instanci třídy Presentation
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

Parametr `ChartData` (u metody `setExternalWorkbook`) slouží k určení, zda bude Excel sešit načten nebo ne.

* Když je hodnota `ChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu — data diagramu nebudou načtena ani aktualizována ze cílového sešitu. Toto nastavení je užitečné, když cílový sešit neexistuje nebo není dostupný.
* Když je hodnota `ChartData` nastavena na `true`, data diagramu se aktualizují ze cílového sešitu.

```php
  # Vytvoří instanci třídy Presentation
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

### **Získání cesty k externímu zdroji dat sešitu diagramu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Vytvořte objekt pro tvar diagramu.
1. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat diagramu.
1. Specifikujte příslušnou podmínku na základě toho, že typ zdroje je stejný jako typ externího zdroje dat sešitu.

Tento PHP kód demonstruje operaci:

```php
  # Vytvoří instanci třídy Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Uloží prezentaci
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Úprava dat diagramu**

Data v externích sešitech můžete upravovat stejným způsobem jako v interních sešitech. Když se externí sešit načíst nepodaří, je vyvolána výjimka.

Tento PHP kód je implementací popsaného postupu:

```php
  # Vytvoří instanci třídy Presentation
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

### **Obnovení sešitu z vyrovnávací paměti diagramu**

Pokud diagram používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může obnovit sešit diagramu z dat uložených ve vyrovnávací paměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/), nakonfigurujte jej pomocí [SpreadsheetOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/spreadsheetoptions/), a před otevřením prezentace zavolejte [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) s `true`.

Následující PHP příklad otevírá prezentaci, jejíž diagram odkazuje na nedostupný externí sešit, a přistupuje k obnoveným datům přes [Chart::getChartData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/#getChartData) a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Zde přečtěte nebo upravte data obnoveného sešitu.
} finally {
    $presentation->dispose();
}
```

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyhodí výjimku. Obnovení povolte pouze tehdy, když je použití dat z vyrovnávací paměti přijatelnou záložní možností, protože vyrovnávací paměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní diagram propojen s externím nebo vloženým sešitem?**

Ano. Diagram má [typ zdroje dat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getdatasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je použita externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou ukládány?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; buďte však vědomi, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu používat sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity lze použít jako externí zdroj dat. Přímé úpravy vzdálených sešitů z Aspose.Slides však nejsou podporovány — lze je jen použít jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace uloží [odkaz na externí soubor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getexternalworkbookpath/) a používá jej k čtení dat. Externí soubor samotný není při ukládání prezentace změněn.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/php-java/)) a odkazovat na tuto kopii.

**Mohou více diagramů odkazovat na stejný externí sešit?**

Ano. Každý diagram uchovává svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, jeho aktualizace se projeví v každém diagramu při dalším načtení dat.