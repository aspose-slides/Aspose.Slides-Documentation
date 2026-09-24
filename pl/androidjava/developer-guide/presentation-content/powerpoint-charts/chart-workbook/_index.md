---
title: "Zarządzanie zeszytami wykresów w prezentacjach na Androidzie"
linktitle: "Zeszyt wykresu"
type: docs
weight: 70
url: /pl/androidjava/chart-workbook/
keywords:
- "zeszyt wykresu"
- "dane wykresu"
- "komórka zeszytu"
- "etykieta danych"
- "arkusz"
- "źródło danych"
- "zewnętrzny zeszyt"
- "zewnętrzne dane"
- "pamięć podręczna wykresu"
- "odzyskiwanie zeszytu"
- "PowerPoint"
- "prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Odkryj Aspose.Slides dla Androida w Javie: bezproblemowo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swoich prezentacjach."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu poprzez strumienie zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówione są także prace z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, uzyskać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

W przypadku komórek zeszytu, które reprezentują brakujące dane, zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/androidjava/chart-series/) – różnica między pustą komórką a zerem oraz porównanie trybów wyświetlania w wykresie liniowym.

## **Odczyt i zapis danych wykresu z zeszytu**
Aspose.Slides udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) oraz [WriteWorkbookStream](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) umożliwiające odczyt i zapis zeszytów danych wykresu (zawierających dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga**, dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Poniższy kod Java demonstruje przykładową operację:

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

### **Walidacja układu wykresu po modyfikacji zeszytu**

Po zastąpieniu osadzonego zeszytu zmodyfikowanym, wykres zachowuje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować błąd w metodzie [IChart.validateChartLayout](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChart#validateChartLayout--) z powodu indeksu poza zakresem. Usuń istniejące serie i kategorie przed zapisaniem zaktualizowanego zeszytu z powrotem do wykresu.

```java
// Po modyfikacji strumienia zeszytu (np. przy użyciu Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Usuń istniejące odwołania do danych.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Czyszczenie kolekcji zapewnia, że struktura danych wykresu jest zgodna z nowym zeszytem, co pozwala metodzie `validateChartLayout` zakończyć działanie bez błędów.

## **Ustawienie komórki zeszytu jako etykiety danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Pobierz odniesienie do slajdu poprzez jego indeks.
1. Dodaj wykres bąbelkowy z pewnymi danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę zeszytu jako etykietę danych.
1. Zapisz prezentację.

Poniższy kod Java pokazuje, jak ustawić komórkę zeszytu jako etykietę danych wykresu:

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

Poniższy kod Java demonstruje operację, w której metoda [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) jest używana do uzyskania dostępu do kolekcji arkuszy:

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

Poniższy kod Java pokazuje, jak określić typ dla źródła danych:

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

## **Wykrywanie nieobsługiwanych formatów osadzonych zeszytów**

Aspose.Slides nie obsługuje formatu binarnego zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` na interfejsie [IChartData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartData) razem z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/WorkbookType), aby wykryć nieobsługiwane formaty i pominąć takie wykresy.

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
            // Zagnieżdżony zeszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue;
        }

        // Odczytaj lub zmodyfikuj tutaj dane zeszytu wykresu.
    }
} finally {
    presentation.dispose();
}
```

## **Zewnętrzny zeszyt**

Aspose.Slides obsługuje używanie zewnętrznych zeszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego zeszytu**

Przy użyciu metod **`readWorkbookStream`** i **`setExternalWorkbook`** możesz zarówno utworzyć zewnętrzny zeszyt od podstaw, jak i uczynić istniejący zeszyt wewnętrzny zewnętrznym.

Poniższy kod Java demonstruje proces tworzenia zewnętrznego zeszytu:

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

### **Ustawienie zewnętrznego zeszytu**

Przy użyciu metody **`setExternalWorkbook`** możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może również służyć do aktualizacji ścieżki do zewnętrznego zeszytu (jeśli został on przeniesiony).

Choć nie można edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, wciąż można ich używać jako zewnętrznego źródła danych. Jeśli podana zostanie względna ścieżka do zewnętrznego zeszytu, zostanie ona automatycznie przekształcona w pełną ścieżkę.

Poniższy kod Java pokazuje, jak ustawić zewnętrzny zeszyt:

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

Parametr `updateChartData` (w metodzie `setExternalWorkbook`) określa, czy workbook Excela ma zostać załadowany.

* Gdy wartość `updateChartData` jest ustawiona na `false`, aktualizowana jest tylko ścieżka zeszytu – dane wykresu nie zostaną załadowane ani zaktualizowane z docelowego zeszytu. Użyj tej opcji, gdy docelowy zeszyt nie istnieje lub jest niedostępny.  
* Gdy wartość `updateChartData` jest ustawiona na `true`, dane wykresu zostaną zaktualizowane z docelowego zeszytu.

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

### **Uzyskanie ścieżki zewnętrznego źródła danych zeszytu wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Pobierz odniesienie do slajdu poprzez jego indeks.
1. Utwórz obiekt dla kształtu wykresu.
1. Utwórz obiekt dla typu źródła (`ChartDataSourceType`), które reprezentuje źródło danych wykresu.
1. Określ odpowiedni warunek w zależności od tego, czy typ źródła jest taki sam jak typ zewnętrznego źródła danych zeszytu.

Poniższy kod Java demonstruje tę operację:

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

Możesz edytować dane w zewnętrznych zeszytach w taki sam sposób, w jaki wprowadzasz zmiany w zawartości wewnętrznych zeszytów. Gdy nie uda się załadować zewnętrznego zeszytu, zostanie zgłoszony wyjątek.

Poniższy kod Java jest implementacją opisanego procesu:

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

### **Odzyskiwanie zeszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu na podstawie danych zapisanych w pamięci podręcznej prezentacji. Utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/), skonfiguruj go przy pomocy [SpreadsheetOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/spreadsheetoptions/), a przed otwarciem prezentacji wywołaj metodę [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) z wartością `true`.

Poniższy przykład w Javie otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego zeszytu, i uzyskuje odzyskane dane poprzez [IChart.getChartData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichart/#getChartData--) oraz [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Odczytaj lub zmodyfikuj tutaj dane odzyskanego zeszytu.
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym zeszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) oraz [ścieżkę do zewnętrznego zeszytu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych zeszytów i jak są przechowywane?**

Tak. Podanie względnej ścieżki powoduje jej automatyczną konwersję na ścieżkę bezwzględną. Ułatwia to przenoszenie projektu, jednak należy pamiętać, że prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać zeszytów znajdujących się na zasobach sieciowych/udostępnionych?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak bezpośrednia edycja zdalnych zeszytów z poziomu Aspose.Slides nie jest obsługiwana – mogą być wykorzystywane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Nie. Prezentacja przechowuje [odwołanie do pliku zewnętrznego](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) i używa go do odczytu danych. Sam zewnętrzny plik nie jest modyfikowany podczas zapisu prezentacji.

**Co zrobić, jeśli zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła przy tworzeniu odwołania. Typowym rozwiązaniem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/androidjava/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własne odwołanie. Jeśli wszystkie wskazują na ten sam plik, jego aktualizacja zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.