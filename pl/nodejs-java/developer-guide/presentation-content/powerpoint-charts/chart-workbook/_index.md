---
title: Zarządzanie zeszytami wykresów w prezentacjach przy użyciu JavaScript
linktitle: Zeszyt wykresu
type: docs
weight: 70
url: /pl/nodejs-java/chart-workbook/
keywords:
- zeszyt wykresu
- dane wykresu
- komórka zeszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny zeszyt
- dane zewnętrzne
- pamięć podręczna wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Node.js poprzez Java: bez wysiłku zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono również pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

## **Odczyt i zapis danych wykresu z zeszytu**

Aspose.Slides udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) pozwalające odczytywać i zapisywać zeszyty danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** że dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten kod JavaScript demonstruje przykładową operację:

```javascript
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

## **Ustaw komórkę WorkBook jako etykietę danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Dodaj wykres bąbelkowy z pewnymi danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę zeszytu jako etykietę danych.
6. Zapisz prezentację.

Ten kod JavaScript pokazuje, jak ustawić komórkę zeszytu jako etykietę danych wykresu:

```javascript
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

## **Określ typ źródła danych**

Ten kod JavaScript pokazuje, jak określić typ dla źródła danych:

```javascript
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

## **Wykryj nieobsługiwane wbudowane formaty zeszytów**

Aspose.Slides nie obsługuje binarnego formatu zeszytu Excel (.xlsb), który może być wbudowany w niektóre wykresy. Możesz użyć metody `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać te wykresy.

```js
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
            // Wbudowany zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue;
        }

        // Odczytaj lub zmodyfikuj tutaj dane zeszytu wykresu.
    }
} finally {
    presentation.dispose();
}
```

## **Zewnętrzny zeszyt**

Aspose.Slides obsługuje zewnętrzne zeszyty jako źródło danych dla wykresów.

### **Utwórz zewnętrzny zeszyt**

Korzystając z metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz utworzyć zewnętrzny zeszyt od podstaw lub uczynić wewnętrzny zeszyt zewnętrznym.

Ten kod JavaScript demonstruje proces tworzenia zewnętrznego zeszytu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ustaw zewnętrzny zeszyt**

Za pomocą metody **`setExternalWorkbook`** możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może być również użyta do aktualizacji ścieżki do zewnętrznego zeszytu (jeśli ten został przeniesiony).

Chociaż nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana jest względna ścieżka do zewnętrznego zeszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten kod JavaScript pokazuje, jak ustawić zewnętrzny zeszyt:

```javascript
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

Parametr `ChartData` (w metodzie `setExternalWorkbook`) służy do określenia, czy zeszyt Excel ma być wczytany.

- Gdy wartość `ChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka zeszytu — dane wykresu nie będą wczytywane ani aktualizowane z docelowego zeszytu. Możesz użyć tego ustawienia w sytuacji, gdy docelowy zeszyt nie istnieje lub jest niedostępny.  
- Gdy wartość `ChartData` jest ustawiona na `true`, dane wykresu są aktualizowane z docelowego zeszytu.

```javascript
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

### **Uzyskaj ścieżkę zewnętrznego źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Utwórz obiekt dla kształtu wykresu.
4. Utwórz obiekt typu źródła (`ChartDataSourceType`), który reprezentuje źródło danych wykresu.
5. Określ odpowiedni warunek, bazując na tym, że typ źródła jest taki sam jak typ źródła danych zewnętrznego zeszytu.

Ten kod JavaScript demonstruje tę operację:

```javascript
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

Możesz edytować dane w zewnętrznych zeszytach w ten sam sposób, w jaki wprowadzasz zmiany w zawartości wewnętrznych zeszytów. Gdy zewnętrzny zeszyt nie może zostać wczytany, zostaje zgłoszony wyjątek.

Ten kod JavaScript jest implementacją opisanego procesu:

```javascript
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

### **Odzyskaj zeszyt z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych zbuforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/), skonfiguruj go przy użyciu [SpreadsheetOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/spreadsheetoptions/), i wywołaj [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład JavaScript otwiera prezentację, w której wykres odwołuje się do niedostępnego zewnętrznego zeszytu, i uzyskuje dostęp do odzyskanych danych za pośrednictwem [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Odczytaj lub zmodyfikuj tutaj odzyskane dane zeszytu.
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy wbudowanym zeszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) oraz [ścieżkę do zewnętrznego zeszytu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych zeszytów są obsługiwane i w jaki sposób są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona na ścieżkę bezwzględną. Jest to wygodne w kontekście przenośności projektu; jednak należy pamiętać, że prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się na zasobach/udostępnieniach sieciowych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edytowanie zdalnych zeszytów bezpośrednio z poziomu Aspose.Slides nie jest obsługiwane — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [odniesienie do zewnętrznego pliku](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) i używa go do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany podczas zapisywania prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie przyjmuje hasła podczas tworzenia odnośnika. Typowe rozwiązanie to usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/nodejs-java/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny odnośnik. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.