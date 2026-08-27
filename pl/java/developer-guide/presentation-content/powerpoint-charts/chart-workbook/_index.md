---
title: Zarządzanie arkuszami wykresów w prezentacjach przy użyciu Java
linktitle: Arkusz wykresu
type: docs
weight: 70
url: /pl/java/chart-workbook/
keywords:
- arkusz wykresu
- dane wykresu
- komórka arkusza
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny arkusz
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie arkusza
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Java: łatwo zarządzaj arkuszami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Omówienie**

Ten artykuł wyjaśnia, jak pracować z arkuszami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni arkuszy, używać komórek arkusza jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi arkuszami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny arkusz, pobrać ścieżkę zewnętrznego arkusza powiązanego z wykresem oraz edytować dane wykresu, gdy arkusz jest dostępny.

## **Odczyt i zapis danych wykresu z arkusza**

Aspose.Slides udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartData#readWorkbookStream--) i [WriteWorkbookStream](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) umożliwiające odczyt i zapis arkuszy danych wykresu (zawierających dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** że dane wykresu muszą być zorganizowane w taki sam sposób lub mieć strukturę podobną do źródła.

Ten kod Java przedstawia przykładową operację:

```java
import com.aspose.slides.*;

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

### **Walidacja układu wykresu po modyfikacji arkusza**

Gdy zamienisz osadzony arkusz na zmodyfikowany, wykres zachowuje swoje oryginalne kolekcje serii i kategorii. Ta niespójność może spowodować, że `chart.validateChartLayout()` rzuci `ArgumentOutOfRangeException` (parametr: index). Aby uniknąć wyjątku, wyczyść istniejące serie i kategorie **przed** zapisaniem zaktualizowanego arkusza z powrotem do wykresu.

```java
// Po zmodyfikowaniu strumienia arkusza (np. przy użyciu Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Wyczyść istniejące odwołania do danych.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Zapisz zaktualizowany arkusz z powrotem do wykresu.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Teraz walidacja przebiega pomyślnie.
chart.validateChartLayout();
```

Wyczyszczenie kolekcji zapewnia, że struktura danych wykresu jest zgodna z nowym arkuszem, co pozwala `validateChartLayout()` zakończyć się bez błędów.

## **Ustawienie komórki arkusza jako etykiety danych wykresu**

1. Utwórz egzemplarz klasy [Presentation](https://apireference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj wykres bąbelkowy z danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę arkusza jako etykietę danych.
1. Zapisz prezentację.

Ten kod Java pokazuje, jak ustawić komórkę arkusza jako etykietę danych wykresu:

```java
import com.aspose.slides.*;

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

Ten kod Java demonstruje operację, w której metoda [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) jest używana do uzyskania dostępu do kolekcji arkuszy:

```java
import com.aspose.slides.*;

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

Ten kod Java pokazuje, jak określić typ źródła danych:

```java
import com.aspose.slides.*;

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

## **Wykrywanie nieobsługiwanych formatów osadzonych arkuszy**

Aspose.Slides nie obsługuje binarnego formatu arkusza Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` na [IChartData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartData) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/WorkbookType), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Osadzony arkusz jest w formacie .xlsb, który nie jest obsługiwany.
            continue;
        }

        // Odczytaj lub zmodyfikuj tutaj dane arkusza wykresu.
    }
} finally {
    presentation.dispose();
}
```

## **Zewnętrzny arkusz**

{{% alert color="info" %}} 
W [Aspose.Slides 19.4](https://docs.aspose.com/slides/pl/java/aspose-slides-for-java-19-4-release-notes/) wprowadziliśmy obsługę zewnętrznych arkuszy jako źródła danych dla wykresów.
{{% /alert %}} 

### **Utworzenie zewnętrznego arkusza**

Korzystając z metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz utworzyć zewnętrzny arkusz od podstaw lub uczynić wewnętrzny arkusz zewnętrznym.

Ten kod Java demonstruje proces tworzenia zewnętrznego arkusza:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

### **Ustawienie zewnętrznego arkusza**

Korzystając z metody **`setExternalWorkbook`**, możesz przypisać zewnętrzny arkusz do wykresu jako jego źródło danych. Metoda ta może być również użyta do zaktualizowania ścieżki do zewnętrznego arkusza (jeśli został przeniesiony).

Chociaż nie możesz edytować danych w arkuszach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich arkuszy jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego arkusza, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten kod Java pokazuje, jak ustawić zewnętrzny arkusz:

```java
import com.aspose.slides.*;

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

Drugi (`boolean`) parametr metody `setExternalWorkbook` służy do określenia, czy arkusz Excel ma być wczytany, czy nie.

* Gdy jego wartość jest ustawiona na `false`, aktualizowana jest tylko ścieżka do arkusza — dane wykresu nie będą wczytywane ani aktualizowane z docelowego arkusza. Użycie tej opcji ma sens, gdy docelowy arkusz nie istnieje lub jest niedostępny. 
* Gdy jego wartość jest ustawiona na `true`, dane wykresu są aktualizowane z docelowego arkusza.

```java
import com.aspose.slides.*;

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

### **Pobranie ścieżki zewnętrznego arkusza źródła danych wykresu**

1. Utwórz egzemplarz klasy [Presentation](https://apireference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Pobierz odwołanie do slajdu za pomocą jego indeksu.
1. Utwórz obiekt dla kształtu wykresu.
1. Utwórz obiekt dla typu źródła (`ChartDataSourceType`), który reprezentuje źródło danych wykresu.
1. Określ odpowiedni warunek, bazując na tym, czy typ źródła jest taki sam jak typ źródła danych zewnętrznego arkusza.

Ten kod Java demonstruje tę operację:

```java
import com.aspose.slides.*;

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

Możesz edytować dane w zewnętrznych arkuszach w taki sam sposób, jak wprowadzasz zmiany w zawartości wewnętrznych arkuszy. Gdy zewnętrzny arkusz nie może zostać wczytany, rzucany jest wyjątek.

Ten kod Java jest implementacją opisanego procesu:

```java
import com.aspose.slides.*;

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

### **Odzyskiwanie arkusza z pamięci podręcznej wykresu**

Jeśli wykres korzysta z zewnętrznego arkusza, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć arkusz wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/), skonfiguruj go przy użyciu [SpreadsheetOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/spreadsheetoptions/), i wywołaj [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład Java otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego arkusza i uzyskuje dostęp do odzyskanych danych za pośrednictwem [IChart.getChartData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/#getChartData--) i [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Odczytaj lub zmodyfikuj tutaj dane odzyskanego arkusza.
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny arkusz jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides rzuca wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym arkuszu po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym arkuszem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#getDataSourceType--) oraz [ścieżkę do zewnętrznego arkusza](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jeśli źródłem jest zewnętrzny arkusz, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy względne ścieżki do zewnętrznych arkuszy są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Ułatwia to przenoszenie projektu; jednak pamiętaj, że prezentacja zapisze ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać arkuszy znajdujących się na zasobach/udostępnieniach sieciowych?**

Tak, takie arkusze mogą być używane jako zewnętrzne źródło danych. Jednak edytowanie zdalnych arkuszy bezpośrednio z Aspose.Slides nie jest obsługiwane — mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [odwołanie do zewnętrznego pliku](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) i używa go do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany przy zapisywaniu prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy tworzeniu odwołania. Powszechnym rozwiązaniem jest wcześniejsze usunięcie zabezpieczenia lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/java/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego arkusza?**

Tak. Każdy wykres przechowuje własne odwołanie. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.