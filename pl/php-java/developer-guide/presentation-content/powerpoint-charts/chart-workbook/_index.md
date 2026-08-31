---
title: Zarządzaj skoroszytami wykresów w prezentacjach przy użyciu PHP
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/php-java/chart-workbook/
keywords:
- skoroszyt wykresu
- dane wykresu
- komórka skoroszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny skoroszyt
- zewnętrzne dane
- pamięć podręczna wykresu
- odtwarzanie skoroszytu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Poznaj Aspose.Slides dla PHP poprzez Java: bezproblemowo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni skoroszytów, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje również pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

## **Odczyt i zapis danych wykresu ze skoroszytu**
Aspose.Slides udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#writeWorkbookStream), które umożliwiają odczyt i zapis skoroszytów danych wykresu (zawierających dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga**, dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten kod PHP przedstawia przykładową operację:

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

### **Walidacja układu wykresu po modyfikacji skoroszytu**

Kiedy zamieniasz osadzony skoroszyt na zmodyfikowany, wykres zachowuje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować, że [Chart::validateChartLayout](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/validatechartlayout/) zakończy się błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego skoroszytu z powrotem do wykresu.

```php
// Po zmodyfikowaniu strumienia skoroszytu (np. przy użyciu Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Wyczyść istniejące odwołania do danych.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Czyszczenie kolekcji zapewnia spójność struktury danych wykresu z nowym skoroszytem, co pozwala `validateChartLayout` zakończyć się bez błędów.

## **Ustawienie komórki skoroszytu jako etykiety danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/php-java/aspose.slides/presentation).  
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.  
1. Dodaj wykres bąbelkowy z danymi.  
1. Uzyskaj dostęp do serii wykresu.  
1. Ustaw komórkę skoroszytu jako etykietę danych.  
1. Zapisz prezentację.

Ten kod PHP pokazuje, jak ustawić komórkę skoroszytu jako etykietę danych wykresu:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Instancjonuje klasę prezentacji, która reprezentuje plik prezentacji
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

Ten kod PHP demonstruje użycie metody [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#getWorksheets) do uzyskania dostępu do kolekcji arkuszy:

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

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/) w połączeniu z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać te wykresy.

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

    # Tutaj odczytaj lub zmodyfikuj dane skoroszytu wykresu.
  }
} finally {
  $presentation->dispose();
}
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje zewnętrzne skoroszyty jako źródło danych dla wykresów.

### **Utworzenie zewnętrznego skoroszytu**

Korzystając z metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz albo utworzyć od zera zewnętrzny skoroszyt, albo uczynić wewnętrzny skoroszyt zewnętrznym.

Ten kod PHP demonstruje proces tworzenia zewnętrznego skoroszytu:

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

### **Ustawienie zewnętrznego skoroszytu**

Za pomocą metody **`setExternalWorkbook`** możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może również służyć do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został on przeniesiony).

Choć nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Ten kod PHP pokazuje, jak ustawić zewnętrzny skoroszyt:

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

Parametr `ChartData` (w metodzie `setExternalWorkbook`) określa, czy skoroszyt Excela ma zostać załadowany.

* Gdy wartość `ChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka do skoroszytu — dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego skoroszytu. Użyj tej opcji, gdy docelowy skoroszyt nie istnieje lub jest niedostępny.  
* Gdy wartość `ChartData` jest ustawiona na `true`, dane wykresu zostaną zaktualizowane z docelowego skoroszytu.

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

### **Pobranie ścieżki zewnętrznego źródła danych skoroszytu wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/php-java/aspose.slides/presentation).  
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.  
1. Utwórz obiekt dla kształtu wykresu.  
1. Utwórz obiekt dla typu źródła (`ChartDataSourceType`), które reprezentuje źródło danych wykresu.  
1. Określ odpowiedni warunek w zależności od tego, czy typ źródła jest taki sam jak typ zewnętrznego źródła skoroszytu.

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

Możesz edytować dane w zewnętrznych skoroszytach tak samo, jak zmieniasz zawartość wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje zgłoszony wyjątek.

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

### **Odzyskiwanie skoroszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych przechowywanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/), skonfiguruj je przy użyciu [SpreadsheetOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/spreadsheetoptions/), a następnie wywołaj [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład PHP otwiera prezentację, której wykres odnosi się do niedostępnego zewnętrznego skoroszytu, i uzyskuje odzyskane dane za pomocą [Chart::getChartData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/#getChartData) oraz [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Odczytaj lub zmodyfikuj tutaj dane odzyskanego skoroszytu.
} finally {
    $presentation->dispose();
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny, a odzyskiwanie jest wyłączone, Aspose.Slides zgłosi wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany ze zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getdatasourcetype/) oraz [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych skoroszytów i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona w ścieżkę bezwzględną. Ułatwia to przenoszalność projektu; pamiętaj jednak, że prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udostępnionych?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Edytowanie zdalnych skoroszytów bezpośrednio z poziomu Aspose.Slides nie jest obsługiwane — mogą być wykorzystywane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [link do pliku zewnętrznego](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getexternalworkbookpath/) i używa go do odczytu danych. Sam plik zewnętrzny nie jest modyfikowany podczas zapisu prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła podczas łączenia. Typowym podejściem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/php-java/)) i podlinkowanie do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie odwołują się do tego samego pliku, jego aktualizacja zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.