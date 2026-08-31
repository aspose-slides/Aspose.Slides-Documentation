---
title: Zarządzanie skoroszytami wykresów w prezentacjach w Javie
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Javy: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni skoroszytów, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Artykuł opisuje również pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

## **Odczyt i zapis danych wykresu ze skoroszytu**
Aspose.Slides udostępnia metody [ReadWorkbookStream](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartData#readWorkbookStream--) i [WriteWorkbookStream](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) umożliwiające odczyt i zapis skoroszytów danych wykresu (zawierających dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga** że dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

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

### **Sprawdź układ wykresu po modyfikacji skoroszytu**

Gdy zastąpisz osadzony skoroszyt zmodyfikowanym, wykres zachowuje pierwotne kolekcje serii i kategorii. Ta niezgodność może spowodować, że [IChart.validateChartLayout](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/#validateChartLayout--) zgłosi `ArgumentOutOfRangeException` (parameter: index). Aby uniknąć wyjątku, przed zapisem zaktualizowanego skoroszytu do wykresu wyczyść istniejące serie i kategorie **przed** zapisem.

```java
// Po modyfikacji strumienia skoroszytu (np. przy użyciu Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Wyczyść istniejące odwołania do danych.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Wyczyszczenie kolekcji zapewnia, że struktura danych wykresu jest zgodna z nowym skoroszytem, co pozwala metodzie `validateChartLayout` zakończyć działanie bez błędów.

## **Ustaw komórkę skoroszytu jako etykietę danych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Pobierz referencję slajdu po jego indeksie.
1. Dodaj wykres bąbelkowy z danymi.
1. Uzyskaj dostęp do serii wykresu.
1. Ustaw komórkę skoroszytu jako etykietę danych.
1. Zapisz prezentację.

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

Poniższy kod w języku Java pokazuje użycie metody [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) do uzyskania dostępu do kolekcji arkuszy:

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

## **Określ typ źródła danych**

Ten kod w języku Java pokazuje, jak określić typ źródła danych:

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

## **Wykryj nieobsługiwane wbudowane formaty skoroszytów**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody `getEmbeddedWorkbookType` na interfejsie [IChartData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartData) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/WorkbookType), aby wykryć nieobsługiwane formaty i pominąć takie wykresy.

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
            // Osadzony skoroszyt jest w formacie .xlsb, który nie jest obsługiwany.
            continue;
        }

        // Odczytaj lub zmodyfikuj dane skoroszytu wykresu tutaj.
    }
} finally {
    presentation.dispose();
}
```

## **Zewnętrzny skoroszyt**

{{% alert color="info" %}} 
W [Aspose.Slides 19.4](https://docs.aspose.com/slides/pl/java/aspose-slides-for-java-19-4-release-notes/) wprowadzono obsługę zewnętrznych skoroszytów jako źródła danych dla wykresów.
{{% /alert %}} 

### **Utwórz zewnętrzny skoroszyt**

Korzystając z metod **`readWorkbookStream`** i **`setExternalWorkbook`**, możesz albo stworzyć zewnętrzny skoroszyt od podstaw, albo uczynić istniejący wewnętrzny skoroszyt zewnętrznym.

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

### **Ustaw zewnętrzny skoroszyt**

Za pomocą metody **`setExternalWorkbook`** możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda może również służyć do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został on przeniesiony).

Choć nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, nadal możesz używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podana zostanie względna ścieżka do zewnętrznego skoroszytu, zostanie ona automatycznie przekształcona na pełną ścieżkę.

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

Drugi parametr (`boolean`) metody `setExternalWorkbook` określa, czy skoroszyt Excel zostanie załadowany.

* Gdy wartość jest ustawiona na `false`, aktualizowana jest tylko ścieżka do skoroszytu – dane wykresu nie będą ładowane ani aktualizowane z docelowego skoroszytu. Użyj tej opcji, gdy docelowy skoroszyt jest nieistniejący lub niedostępny.  
* Gdy wartość jest ustawiona na `true`, dane wykresu zostaną zaktualizowane z docelowego skoroszytu.

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

### **Uzyskaj ścieżkę skoroszytu źródła danych zewnętrznych wykresu**

1. Utwórz instancję klasy [Presentation](https://apireference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Pobierz referencję slajdu po jego indeksie.
1. Utwórz obiekt dla kształtu wykresu.
1. Utwórz obiekt dla typu źródła (`ChartDataSourceType`) reprezentującego źródło danych wykresu.
1. Określ odpowiedni warunek w zależności od tego, czy typ źródła jest taki sam jak typ zewnętrznego skoroszytu.

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

### **Edytuj dane wykresu**

Możesz edytować dane w zewnętrznych skoroszytach tak samo, jak zmieniasz zawartość wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostanie zgłoszony wyjątek.

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

### **Odzyskaj skoroszyt z pamięci podręcznej wykresu**

Jeśli wykres korzysta z zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/), skonfiguruj je przy użyciu [SpreadsheetOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/spreadsheetoptions/), i wywołaj [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) z wartością `true` przed otwarciem prezentacji.

Poniższy przykład w Javie otwiera prezentację, której wykres odwołuje się do niedostępnego zewnętrznego skoroszytu, i uzyskuje odzyskane dane przez [IChart.getChartData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/#getChartData--) oraz [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Odczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłosi wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**  
Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#getDataSourceType--) oraz [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych skoroszytów i w jaki sposób są przechowywane?**  
Tak. Po podaniu względnej ścieżki jest ona automatycznie konwertowana na ścieżkę bezwzględną. Dzięki temu projekt jest przenośny; należy jednak pamiętać, że prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udostępnionych?**  
Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być wykorzystywane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisie prezentacji?**  
Nie. Prezentacja przechowuje [odwołanie do pliku zewnętrznego](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) i używa go jedynie do odczytu danych. Plik zewnętrzny nie jest modyfikowany podczas zapisu prezentacji.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**  
Aspose.Slides nie akceptuje hasła przy tworzeniu odwołania. Typowym rozwiązaniem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](/cells/java/)) i odwołanie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**  
Tak. Każdy wykres przechowuje własne odwołanie. Jeśli wszystkie wskazują na ten sam plik, zmiana tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.