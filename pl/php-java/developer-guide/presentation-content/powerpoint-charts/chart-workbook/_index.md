---
title: "Zarządzanie arkuszami wykresów w prezentacjach przy użyciu PHP"
linktitle: "Arkusz wykresu"
type: docs
weight: 70
url: /pl/php-java/chart-workbook/
keywords:
- "arkusz wykresu"
- "dane wykresu"
- "komórka arkusza"
- "etykieta danych"
- "arkusz kalkulacyjny"
- "źródło danych"
- "zewnętrzny arkusz"
- "zewnętrzne dane"
- "pamięć podręczna wykresu"
- "odzyskiwanie arkusza"
- "PowerPoint"
- "prezentacja"
- "PHP"
- "Aspose.Slides"
description: "Odkryj Aspose.Slides dla PHP przy użyciu Java: bezproblemowo zarządzaj arkuszami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z arkuszami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni arkuszy, używać komórek arkusza jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje również pracę z zewnętrznymi arkuszami jako źródłem danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny arkusz, pobrać ścieżkę zewnętrznego arkusza powiązanego z wykresem oraz edytować dane wykresu, gdy arkusz jest dostępny.

## **Odczyt i zapis danych wykresu z arkusza**
Aspose.Slides udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#writeWorkbookStream), które pozwalają odczytywać i zapisywać arkusze danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga**: dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten kod PHP demonstruje przykładową operację:

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

## **Ustawienie komórki WorkBook jako etykiety danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
2. Pobierz odwołanie do slajdu za pomocą jego indeksu.
3. Dodaj wykres bąbelkowy z danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę arkusza jako etykietę danych.
6. Zapisz prezentację.

Ten kod PHP pokazuje, jak ustawić komórkę arkusza jako etykietę danych wykresu:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
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

## **Zarządzanie arkuszami**

Ten kod PHP demonstruje operację, w której metoda [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#getWorksheets) jest używana do uzyskania dostępu do kolekcji arkuszy:

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

## **Określenie typu źródła danych**

Ten kod PHP pokazuje, jak określić typ źródła danych:

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

## **Wykrywanie nieobsługiwanych formatów osadzonych arkuszy**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` w klasie [ChartData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/) razem z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy.

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
      # Osadzony skoroszyt jest w formacie .xlsb, który nie jest obsługiwany.
      continue;
    }

    # Odczytaj lub zmodyfikuj tutaj dane skoroszytu wykresu.
  }
} finally {
  $presentation->dispose();
}
```

## **Zewnętrzny arkusz**

Aspose.Slides obsługuje zewnętrzne arkusze jako źródło danych dla wykresów.

### **Utworzenie zewnętrznego arkusza**

Korzystając z metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz utworzyć zewnętrzny arkusz od podstaw lub uczynić istniejący arkusz wewnętrzny zewnętrznym.

Ten kod PHP demonstruje proces tworzenia zewnętrznego arkusza:

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

### **Ustawienie zewnętrznego arkusza**

Korzystając z metody **`setExternalWorkbook`**, możesz przypisać zewnętrzny arkusz do wykresu jako jego źródło danych. Metoda ta może być także użyta do zaktualizowania ścieżki do zewnętrznego arkusza (jeśli został przeniesiony).

Choć nie możesz edytować danych w arkuszach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać takich arkuszy jako zewnętrznego źródła danych. Jeśli zostanie podana względna ścieżka do zewnętrznego arkusza, zostanie ona automatycznie przekształcona na pełną ścieżkę.

Ten kod PHP pokazuje, jak ustawić zewnętrzny arkusz:

```php
  # Tworzy instancję klasy Presentation
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

Parametr `ChartData` (w metodzie `setExternalWorkbook`) służy do określenia, czy skoroszyt Excel zostanie załadowany.

* Gdy wartość `ChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka do arkusza — dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego arkusza. Użyj tego ustawienia, gdy docelowy arkusz nie istnieje lub jest niedostępny.
* Gdy wartość `ChartData` jest ustawiona na `true`, dane wykresu zostaną zaktualizowane z docelowego arkusza.

```php
  # Tworzy instancję klasy Presentation
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

### **Pobranie ścieżki zewnętrznego źródła danych arkusza wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
2. Pobierz odwołanie do slajdu za pomocą jego indeksu.
3. Utwórz obiekt dla kształtu wykresu.
4. Utwórz obiekt dla typu źródła (`ChartDataSourceType`), który reprezentuje źródło danych wykresu.
5. Określ odpowiedni warunek w zależności od tego, czy typ źródła jest taki sam jak typ zewnętrznego źródła danych arkusza.

Ten kod PHP demonstruje operację:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Zapisuje prezentację
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych arkuszach tak samo, jak w wewnętrznych. Gdy zewnętrzny arkusz nie może zostać załadowany, zostaje wyrzucony wyjątek.

Ten kod PHP jest implementacją opisanego procesu:

```php
  # Tworzy instancję klasy Presentation
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

### **Odzyskanie arkusza z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego arkusza, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć arkusz wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/), skonfiguruj go przy użyciu [SpreadsheetOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/spreadsheetoptions/), i wywołaj [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład w PHP otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego arkusza, i uzyskuje dostęp do odzyskanych danych za pomocą [Chart::getChartData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/#getChartData) oraz [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Odczytaj lub zmodyfikuj tutaj odzyskane dane skoroszytu.
} finally {
    $presentation->dispose();
}
```

Jeśli zewnętrzny arkusz jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym arkuszu po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym arkuszem?**

Tak. Wykres ma [typ źródła danych](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getdatasourcetype/) oraz [ścieżkę do zewnętrznego arkusza](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródłem jest zewnętrzny arkusz, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych arkuszy i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona na ścieżkę bezwzględną. Jest to wygodne przy przenoszeniu projektu; jednak prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać arkuszy znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie arkusze mogą być używane jako zewnętrzne źródło danych. Jednak bezpośrednia edycja zdalnych arkuszy z poziomu Aspose.Slides nie jest obsługiwana — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Nie. Prezentacja przechowuje [odnośnik do pliku zewnętrznego](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/) i używa go do odczytu danych. Sam plik zewnętrzny nie jest modyfikowany przy zapisie prezentacji.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła przy tworzeniu odnośnika. Typowym rozwiązaniem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/php-java/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego arkusza?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, jego aktualizacja zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.