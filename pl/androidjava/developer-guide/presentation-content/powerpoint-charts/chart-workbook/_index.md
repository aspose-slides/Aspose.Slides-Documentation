---
title: Zarządzaj zeszytami wykresów w prezentacjach na Androidzie
linktitle: Zeszyt wykresu
type: docs
weight: 70
url: /pl/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Androida w Javie: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje również pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

## **Odczyt i zapis danych wykresu z zeszytu**
Aspose.Slides provides the [ReadWorkbookStream](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) and [WriteWorkbookStream](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

Ten kod w języku Java demonstruje przykładową operację:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw komórkę WorkBook jako etykietę danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj wykres bąbelkowy z danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę zeszytu jako etykietę danych.
1. Zapisz prezentację.

Ten kod w języku Java pokazuje, jak ustawić komórkę zeszytu jako etykietę danych wykresu:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarządzanie arkuszami**

Ten kod w języku Java demonstruje operację, w której metoda [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) jest używana do uzyskania dostępu do kolekcji arkuszy:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Określenie typu źródła danych**

Ten kod w języku Java pokazuje, jak określić typ źródła danych:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wykrywanie nieobsługiwanych formatów osadzonych zeszytów**

Aspose.Slides nie obsługuje formatu Excela binarnego (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` na [IChartData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartData) together with the [WorkbookType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/WorkbookType) enumeration to detect unsupported formats and skip those charts.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Osadzony zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
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

### **Utworzenie zewnętrznego zeszytu**

Korzystając z metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz utworzyć zewnętrzny zeszyt od podstaw lub zamienić wewnętrzny zeszyt w zewnętrzny.

Ten kod w języku Java demonstruje proces tworzenia zewnętrznego zeszytu:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ustawienie zewnętrznego zeszytu**

Korzystając z metody **`setExternalWorkbook`**, możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Ta metoda może również służyć do aktualizacji ścieżki do zewnętrznego zeszytu (jeśli został on przeniesiony).

Chociaż nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana zostanie względna ścieżka do zewnętrznego zeszytu, zostanie ona automatycznie przekształcona na pełną ścieżkę.

Ten kod w języku Java pokazuje, jak ustawić zewnętrzny zeszyt:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Parametr `ChartData` (w metodzie `setExternalWorkbook`) służy do określenia, czy skoroszyt Excela ma być wczytany.

* Gdy wartość `ChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka do zeszytu — dane wykresu nie będą wczytywane ani aktualizowane z docelowego zeszytu. Użyj tego ustawienia, gdy docelowy zeszyt nie istnieje lub jest niedostępny.
* Gdy wartość `ChartData` jest ustawiona na `true`, dane wykresu są aktualizowane z docelowego zeszytu.

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Pobranie ścieżki zewnętrznego zeszytu źródła danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Utwórz obiekt dla kształtu wykresu.
1. Utwórz obiekt typu źródła (`ChartDataSourceType`), który reprezentuje źródło danych wykresu.
1. Określ odpowiedni warunek, bazując na tym, że typ źródła jest taki sam jak typ zewnętrznego zeszytu.

Ten kod w języku Java demonstruje tę operację:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Zapisuje prezentację
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych zeszytach tak samo, jak zmieniasz zawartość zeszytów wewnętrznych. Gdy zewnętrzny zeszyt nie może być wczytany, zostaje zgłoszony wyjątek.

Ten kod w języku Java jest implementacją opisanego procesu:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym zeszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) oraz [ścieżkę do zewnętrznego zeszytu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych zeszytów i jak są one przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostanie ona automatycznie przekształcona na ścieżkę bezwzględną. Jest to wygodne przy przenoszeniu projektów; jednak pamiętaj, że prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się na zasobach/udziałach sieciowych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [link do zewnętrznego pliku](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) i używa go do odczytu danych. Zewnętrzny plik nie jest modyfikowany przy zapisywaniu prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowym rozwiązaniem jest usunięcie ochrony przed użyciem lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](/cells/androidjava/)) i połączenie się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.