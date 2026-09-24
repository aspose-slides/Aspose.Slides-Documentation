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
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Node.js przy użyciu Java: bezproblemowo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni zeszytu, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu. Omówiono również pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny. W przypadku komórek zeszytu reprezentujących brakujące dane, zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/nodejs-java/chart-series/) aby poznać różnicę między pustą komórką a zerem oraz porównanie trybów wyświetlania w wykresie liniowym.

## **Read and Write Chart Data from a Workbook**

Aspose.Slides udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) które pozwalają odczytywać i zapisywać zeszyty danych wykresu (zawierające dane wykresu edytowane za pomocą Aspose.Cells). **Uwaga** że dane wykresu muszą być uporządkowane w ten sam sposób lub mieć strukturę podobną do źródła.

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

### **Validate Chart Layout After Workbook Modification**

Kiedy zamieniasz osadzony zeszyt na zmodyfikowany, wykres zachowuje swoje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować, że [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Chart#validateChartLayout--) zakończy się niepowodzeniem z błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego zeszytu z powrotem do wykresu.

```javascript
// Po zmodyfikowaniu strumienia zeszytu (np. przy użyciu Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Wyczyść istniejące odwołania do danych.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Usunięcie kolekcji zapewnia, że struktura danych wykresu jest spójna z nowym zeszytem, co pozwala `validateChartLayout` zakończyć bez błędów.

## **Ustaw komórkę WorkBook jako DataLabel wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres typu Bubble z pewnymi danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę workbook jako etykietę danych.
6. Zapisz prezentację.

Ten kod JavaScript pokazuje, jak ustawić komórkę workbook jako etykietę danych wykresu:

```javascript
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
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

## **Manage Worksheets**

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

## **Specify Data Source Type**

Ten kod JavaScript pokazuje, jak określić typ źródła danych:

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides nie obsługuje binarnego formatu zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy.

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
            // Osadzony zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue;
        }

        // Odczytaj lub zmodyfikuj tutaj dane zeszytu wykresu.
    }
} finally {
    presentation.dispose();
}
```

## **External Workbook**

Aspose.Slides obsługuje zewnętrzne zeszyty jako źródło danych dla wykresów.

### **Create External Workbook**

Używając metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz zarówno utworzyć od podstaw zewnętrzny zeszyt, jak i uczynić wewnętrzny zeszyt zewnętrznym.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream zwraca bajty zeszytu jako bufor Node.
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

### **Set External Workbook**

Za pomocą metody **`setExternalWorkbook`** możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może być także użyta do zaktualizowania ścieżki do zewnętrznego zeszytu (jeśli został przeniesiony). Chociaż nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana zostanie względna ścieżka do zewnętrznego zeszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Ten kod JavaScript pokazuje, jak ustawić zewnętrzny zeszyt:

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

Drugi parametr metody `setExternalWorkbook`, `updateChartData`, określa, czy zeszyt Excel zostanie załadowany.  
* Gdy `updateChartData` jest ustawione na `false`, aktualizowana jest tylko ścieżka do zeszytu — dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego zeszytu. Możesz użyć tego ustawienia, gdy docelowy zeszyt nie istnieje lub jest niedostępny.  
* Gdy `updateChartData` jest ustawione na `true`, dane wykresu zostają zaktualizowane z docelowego zeszytu.

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

### **Get Chart External Data Source Workbook Path**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) .
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Utwórz obiekt dla kształtu wykresu.
4. Utwórz obiekt dla typu źródła (`ChartDataSourceType`), które reprezentuje źródło danych wykresu.
5. Określ odpowiedni warunek na podstawie tego, że typ źródła jest taki sam jak typ danych zewnętrznego zeszytu.

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

### **Edit Chart Data**

Możesz edytować dane w zewnętrznych zeszytach w taki sam sposób, w jaki wprowadzasz zmiany w zawartości wewnętrznych zeszytów. Gdy nie można załadować zewnętrznego zeszytu, zostaje zgłoszony wyjątek.

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

### **Recover a Workbook from the Chart Cache**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/), skonfiguruj go przy pomocy [SpreadsheetOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/spreadsheetoptions/), i wywołaj [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) z wartością `true` przed otwarciem prezentacji.  

Poniższy przykład JavaScript otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego zeszytu i uzyskuje dostęp do odzyskanych danych poprzez [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    // Odczytaj lub zmodyfikuj tutaj dane odzyskanego zeszytu.
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny zeszyt jest niedostępny, a odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych do zewnętrznego zeszytu po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym zeszytem?**  
Tak. Wykres ma [data source type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych zeszytów są obsługiwane i jak są przechowywane?**  
Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona w ścieżkę bezwzględną. Jest to wygodne przy przenoszeniu projektów, jednak pamiętaj, że prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się na zasobach/udostępnieniach sieciowych?**  
Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest jednak obsługiwana – mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**  
Nie. Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) i używa go do odczytu danych. Zewnętrzny plik nie jest modyfikowany podczas zapisywania prezentacji.

**Co zrobić, gdy zewnętrzny plik jest chroniony hasłem?**  
Aspose.Slides nie akceptuje hasła przy łączeniu. Typowe podejście to usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/nodejs-java/)) i podlinkowanie do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**  
Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.