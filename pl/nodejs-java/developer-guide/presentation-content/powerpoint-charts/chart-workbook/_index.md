---
title: Zarządzanie skoroszytami wykresów w prezentacjach przy użyciu JavaScript
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/nodejs-java/chart-workbook/
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
- odzyskiwanie skoroszytu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Node.js poprzez Java: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w prezentacjach."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni skoroszytu, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono również pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

## **Odczyt i zapis danych wykresu ze skoroszytu**

Aspose.Slides udostępnia metodę [readWorkbookStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) oraz [writeWorkbookStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) pozwalające na odczyt i zapis skoroszytów danych wykresu (zawierających dane wykresu edytowane w Aspose.Cells). **Uwaga** że dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten kod JavaScript demonstruje przykładową operację:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Sprawdź układ wykresu po modyfikacji skoroszytu**

Kiedy zamieniasz osadzony skoroszyt na zmodyfikowany, wykres zachowuje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować błąd w [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Chart#validateChartLayout--) z powodu indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego skoroszytu z powrotem do wykresu.

```javascript
// Po zmodyfikowaniu strumienia skoroszytu (np. przy użyciu Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Wyczyść istniejące odwołania do danych.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Wyczyszczenie kolekcji zapewnia, że struktura danych wykresu jest zgodna z nowym skoroszytem, co pozwala metodzie `validateChartLayout` zakończyć działanie bez błędów.

## **Ustaw komórkę skoroszytu jako etykietę danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) .
2. Pobierz referencję slajdu za pomocą jego indeksu.
3. Dodaj wykres bąbelkowy z danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę skoroszytu jako etykietę danych.
6. Zapisz prezentację.

Ten kod JavaScript pokazuje, jak ustawić komórkę skoroszytu jako etykietę danych wykresu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zarządzanie arkuszami**

Ten kod JavaScript demonstruje operację, w której metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) jest używana do uzyskania dostępu do kolekcji arkuszy:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Określenie typu źródła danych**

Ten kod JavaScript pokazuje, jak określić typ dla źródła danych:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` klasy [ChartData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/workbooktype/) w celu wykrycia nieobsługiwanych formatów i pominięcia takich wykresów.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Osadzony skoroszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue;
        }

        // Odczytaj lub zmodyfikuj tutaj dane skoroszytu wykresu.
    }
} finally {
    presentation.dispose();
}
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje zewnętrzne skoroszyty jako źródło danych dla wykresów.

### **Utwórz zewnętrzny skoroszyt**

Używając metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz utworzyć zewnętrzny skoroszyt od podstaw lub uczynić istniejący wewnętrzny skoroszyt zewnętrznym.

Ten kod JavaScript demonstruje proces tworzenia zewnętrznego skoroszytu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream zwraca bajty skoroszytu jako bufor Node.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ustaw zewnętrzny skoroszyt**

Metodą **`setExternalWorkbook`** możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może być również użyta do zaktualizowania ścieżki do zewnętrznego skoroszytu (jeśli został on przeniesiony).

Chociaż nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Ten kod JavaScript pokazuje, jak ustawić zewnętrzny skoroszyt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Drugi parametr metody `setExternalWorkbook`, `updateChartData`, określa, czy skoroszyt Excel zostanie załadowany.

* Gdy `updateChartData` ma wartość `false`, aktualizowana jest tylko ścieżka do skoroszytu – dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego skoroszytu. Użyj tej opcji, gdy docelowy skoroszyt nie istnieje lub jest niedostępny.
* Gdy `updateChartData` ma wartość `true`, dane wykresu zostaną zaktualizowane z docelowego skoroszytu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Pobierz ścieżkę skoroszytu zewnętrznego źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) .
2. Pobierz referencję slajdu za pomocą jego indeksu.
3. Utwórz obiekt dla kształtu wykresu.
4. Utwórz obiekt dla typu źródła (`ChartDataSourceType`), które reprezentuje źródło danych wykresu.
5. Określ odpowiedni warunek, gdy typ źródła jest taki sam jak typ źródła danych zewnętrznego skoroszytu.

Ten kod JavaScript demonstruje tę operację:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Zapisuje prezentację
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Edytuj dane wykresu**

Możesz edytować dane w zewnętrznych skoroszytach w taki sam sposób, w jaki wprowadzasz zmiany w zawartości wewnętrznych skoroszytów. Gdy nie można załadować zewnętrznego skoroszytu, zostaje zgłoszone wyjątkowe zdarzenie.

Ten kod JavaScript jest implementacją opisanego procesu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Odzyskaj skoroszyt z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/), skonfiguruj go przy użyciu [SpreadsheetOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/spreadsheetoptions/), i wywołaj [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład JavaScript otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego skoroszytu i uzyskuje dostęp do odzyskanych danych poprzez [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Odczytaj lub zmodyfikuj tutaj dane odzyskanego skoroszytu.
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest dopuszczalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych skoroszytów i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona w ścieżkę bezwzględną. Jest to wygodne przy przenoszeniu projektu; jednak pamiętaj, że prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) i używa go do odczytu danych. Zewnętrzny plik nie jest modyfikowany podczas zapisywania prezentacji.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła podczas tworzenia łącza. Typowe rozwiązanie to usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/nodejs-java/)) i podłączenie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własne łącze. Jeśli wszystkie odwołują się do tego samego pliku, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.