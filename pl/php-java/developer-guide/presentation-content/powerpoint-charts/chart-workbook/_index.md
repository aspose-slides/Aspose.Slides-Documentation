---
title: Zarządzanie zeszytami wykresów w prezentacjach przy użyciu PHP
linktitle: Zeszyt wykresu
type: docs
weight: 70
url: /pl/php-java/chart-workbook/
keywords:
- zeszyt wykresu
- dane wykresu
- komórka zeszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny zeszyt
- dane zewnętrzne
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj Aspose.Slides dla PHP poprzez Java: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówione jest również korzystanie z zewnętrznych zeszytów jako źródeł danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

## **Odczyt i zapis danych wykresu z zeszytu**
Aspose.Slides udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#writeWorkbookStream), które umożliwiają odczytywanie i zapisywanie zeszytów danych wykresu (zawierających dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga**, że dane wykresu muszą być zorganizowane w taki sam sposób lub mieć strukturę podobną do źródła.

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

## **Ustaw komórkę zeszytu jako etykietę danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/php-java/aspose.slides/presentation) .
1. Uzyskaj referencję slajdu poprzez jego indeks.
1. Dodaj wykres typu Bubble z pewnymi danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę zeszytu jako etykietę danych.
1. Zapisz prezentację.

Ten kod PHP pokazuje, jak ustawić komórkę zeszytu jako etykietę danych wykresu:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Tworzy instancję klasy prezentacji reprezentującej plik prezentacji
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

Ten kod PHP pokazuje, jak określić typ dla źródła danych:

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

## **Wykrywanie nieobsługiwanych wbudowanych formatów zeszytów**

Aspose.Slides nie obsługuje binarnego formatu zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/) razem z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć takie wykresy.

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
      # Osadzony zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
      continue;
    }

    # Odczytaj lub zmodyfikuj dane zeszytu wykresu tutaj.
  }
} finally {
  $presentation->dispose();
}
```

## **Zewnętrzny zeszyt**

Aspose.Slides obsługuje zewnętrzne zeszyty jako źródło danych dla wykresów.

### **Utworzenie zewnętrznego zeszytu**

Korzystając z metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz utworzyć zewnętrzny zeszyt od podstaw lub uczynić wewnętrzny zeszyt zewnętrznym.

Ten kod PHP demonstruje proces tworzenia zewnętrznego zeszytu:

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

### **Ustawienie zewnętrznego zeszytu**

Używając metody **`setExternalWorkbook`**, możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może być również użyta do aktualizacji ścieżki do zewnętrznego zeszytu (jeśli został przeniesiony).

Chociaż nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana jest względna ścieżka do zewnętrznego zeszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten kod PHP pokazuje, jak ustawić zewnętrzny zeszyt:

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

Parametr `ChartData` (w metodzie `setExternalWorkbook`) służy do określenia, czy zeszyt Excel zostanie załadowany.

* Gdy wartość `ChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka do zeszytu — dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego zeszytu. Możesz użyć tego ustawienia w sytuacji, gdy docelowy zeszyt nie istnieje lub jest niedostępny. 
* Gdy wartość `ChartData` jest ustawiona na `true`, dane wykresu są aktualizowane z docelowego zeszytu.

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

### **Pobranie ścieżki zewnętrznego zeszytu źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/php-java/aspose.slides/presentation) .
1. Uzyskaj referencję slajdu poprzez jego indeks.
1. Utwórz obiekt dla kształtu wykresu.
1. Utwórz obiekt dla typu źródła (`ChartDataSourceType`), które reprezentuje źródło danych wykresu.
1. Określ odpowiedni warunek, bazując na tym, że typ źródła jest taki sam jak typ zewnętrznego źródła danych zeszytu.

Ten kod PHP demonstruje tę operację:

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

Możesz edytować dane w zewnętrznych zeszytach w taki sam sposób, w jaki zmieniasz zawartość wewnętrznych zeszytów. Gdy zewnętrzny zeszyt nie może zostać załadowany, rzucany jest wyjątek.

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

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym zeszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getdatasourcetype/) oraz [ścieżkę do zewnętrznego zeszytu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródło jest zewnętrznym zeszytem, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych zeszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona na ścieżkę bezwzględną. Jest to wygodne w kontekście przenoszenia projektu; jednak pamiętaj, że prezentacja zapisze ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się w zasobach sieciowych/udostępnionych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edytowanie zdalnych zeszytów bezpośrednio z poziomu Aspose.Slides nie jest obsługiwane — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [odnośnik do zewnętrznego pliku](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/), którego używa do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany podczas zapisywania prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowe rozwiązanie to usunięcie ochrony z wyprzedzeniem lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/php-java/)) i podlinkowanie do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, jego aktualizacja zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.