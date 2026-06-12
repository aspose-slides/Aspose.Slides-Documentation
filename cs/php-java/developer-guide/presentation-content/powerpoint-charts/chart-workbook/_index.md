---
title: Spravujte sešity grafů v prezentacích pomocí PHP
linktitle: Sešit grafu
type: docs
weight: 70
url: /cs/php-java/chart-workbook/
keywords:
- sešit grafu
- data grafu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Objevte Aspose.Slides pro PHP prostřednictvím Javy: snadno spravujte sešity grafů ve formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a určovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími sešity jako zdroji dat pro grafy. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#readWorkbookStream) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/#writeWorkbookStream), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka** že data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento PHP kód ukazuje ukázkovou operaci:

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

## **Nastavení buňky sešitu jako popisku dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte bublinový graf s některými daty.
4. Přistupte k sériím grafu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

Tento PHP kód ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Vytvoří instanci třídy prezentace, která reprezentuje soubor prezentace
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

Tento PHP kód demonstruje operaci, kde je metoda [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#getWorksheets) použita k přístupu ke kolekci listů:

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

Tento PHP kód ukazuje, jak určit typ pro zdroj dat:

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

## **Detekce nepodporovaných vložených formátů sešitu**

Aspose.Slides nepodporuje formát binárního sešitu Excel (.xlsb), který může být vložen v některých grafech. Můžete použít metodu `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a vynechání těchto grafů.

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

    # Zde přečtěte nebo upravte data sešitu grafu.
  }
} finally {
  $presentation->dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje externí sešity jako zdroj dat pro grafy.

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

Pomocí metody **`setExternalWorkbook`** můžete přiřadit externí sešit k grafu jako jeho zdroj dat. Tuto metodu lze také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity i nadále používat jako externí zdroj dat. Pokud je poskytnuta relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

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

Parametr `ChartData` (pod metodou `setExternalWorkbook`) se používá k určení, zda bude excelový sešit načten, či nikoliv.

* Když je hodnota `ChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu – data grafu nebudou načtena ani aktualizována z cílového sešitu. Toto nastavení můžete použít v situaci, kdy cílový sešit neexistuje nebo není dostupný. 
* Když je hodnota `ChartData` nastavena na `true`, data grafu se aktualizují z cílového sešitu.

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

### **Získání cesty k externímu sešitu zdroje dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Vytvořte objekt pro tvar grafu.
4. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat grafu.
5. Zadejte relevantní podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu.

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

### **Úprava dat grafu**

Data v externích sešitech můžete upravovat stejným způsobem, jako provádíte změny v obsahu interních sešitů. Pokud se externí sešit načíst nepodaří, je vyvolána výjimka.

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

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getdatasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu, abyste se ujistili, že je používán externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; však si uvědomte, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu používat sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getexternalworkbookpath/) a používá jej pro čtení dat. Samotný externí soubor není při ukládání prezentace upravován.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides při odkazu heslo nepřijímá. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/php-java/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.