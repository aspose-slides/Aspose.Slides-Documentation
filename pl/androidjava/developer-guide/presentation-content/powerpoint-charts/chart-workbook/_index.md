---
title: Zarządzanie zeszytami wykresów w prezentacjach na Androidzie
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
- zewnętrzne dane
- pamięć podręczna wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj Aspose.Slides for Android via Java: łatwo zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni zeszytu, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Opisuje również pracę z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, pobrać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

Dla komórek zeszytu, które reprezentują brakujące dane, zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/androidjava/chart-series/) – różnica między pustą komórką a zerem oraz porównanie wykresu liniowego dostępnych trybów wyświetlania.

## **Dołącz dane z ukrytych wierszy i kolumn**

Użyj [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) aby kontrolować, czy wykres plotuje dane z ukrytych wierszy i kolumn arkusza. Ustaw `true`, aby plotować tylko widoczne komórki, lub `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje plotowanie wykresu; nie ukrywa ani nie odkrywa wierszy lub kolumn arkusza.

[Sample presentation](hidden-source-data.pptx) zawiera wykres kolumnowy jako pierwszy kształt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych przez [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) i odczytaj [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) aby sprawdzić ich status ukrycia. Ta metoda zgłasza status ukrycia bez jego zmiany. W tym przykładzie B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `false`, `true` i `true`.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia plotowania: zachowaj osadzony zeszyt przy pomocy [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) i wczytaj go ponownie przy użyciu [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Przy uwzględnianiu wszystkich komórek użyj także [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) aby przywrócić pełny zakres, w tym ukrytą kategorię luty. Samo zmienienie flagi nie wystarczy, aby odświeżyć pamięć podręczną danych wykresu i etykiet kategorii w tym przykładzie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Odśwież dane wykresu z osadzonego zeszytu.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Przywróć pełny zakres źródłowy, w tym ukryte kategorie.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Przykład zapisuje dwie wersje prezentacji: jedną tylko z widocznymi wartościami detalicznymi (10 i 20), a drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby plotowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych zeszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) kontroluje, jak wyświetlane są brakujące wartości; nie włącza i nie wyłącza ukrytych danych źródłowych. Zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/androidjava/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Pobierz zakres danych wykresu**

Przed aktualizacją danych zeszytu w istniejącej prezentacji sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa każdy wykres. Metoda [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5 włącznie. Znaki dolara wskazują absolutne odwołania wierszy i kolumn.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego zeszytu. Jeśli wykres nie używa zeszytu jako źródła danych, zgłasza `InvalidOperationException`. Więcej informacji znajdziesz w [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu i jego zakres źródłowy. Jeśli wykres nie używa zeszytu, wypisuje komunikat i przechodzi do kolejnego wykresu.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Odczyt i zapis danych wykresu z zeszytu**

Aspose.Slides for Android via Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) i [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---), które pozwalają odczytywać i zapisywać zeszyty danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga**, dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Przykład używa prezentacji z wykresem jako pierwszym kształtem na pierwszym slajdzie. Odczytuje osadzony zeszyt do tablicy bajtów, czyści istniejące serie i kategorie, a następnie zapisuje ten sam zeszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Sprawdź układ wykresu po modyfikacji zeszytu**

Gdy zamieniasz osadzony zeszyt na zmodyfikowany, wykres zachowuje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować, że [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) zakończy się błędem „index out of range”. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego zeszytu z powrotem do wykresu. Ten przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie. Komentarz wskazuje miejsce, w którym odbywa się edycja zeszytu; uruchamiany przykład zapisuje oryginalny zeszyt z powrotem i w pamięci weryfikuje układ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Modyfikuj bajty zeszytu tutaj, na przykład przy użyciu Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Wyczyszczenie kolekcji usuwa przestarzałe odwołania danych przed zapisaniem zeszytu. Przed użyciem wykresu odtwórz wszelkie wymagane mapowania serii i kategorii dla zaktualizowanego zeszytu.

## **Ustaw niestandardowe formaty liczb dla komórek zeszytu**

Użyj [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) aby kontrolować, jak wartości liczbowe wyświetlane są w osadzonym zeszycie wykresu. Na przykład raport może wymagać wyświetlenia współczynnika konwersji jako procentu z czterema miejscami po przecinku oraz współczynnika wyświetlanego z pięcioma miejscami po przecinku. Zachowaj obie wartości jako numeryczne, aby pozostały dostępne do obliczeń i plotowania wykresu.

Format liczby zmienia jedynie wyświetlanie, nie zapisaną wartość. Format `0.0000%` wyświetla `0.125` jako `12.5000%`; nie zastępuje przechowywanej liczby `12.5`. Podobnie, `0.00000` wyświetla `0.1234567` jako `0.12346` bez zaokrąglania przechowywanej wartości. Jeśli niestandardowy format jest pustym ciągiem (`""`), używany jest format zwrócony przez [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

Poniższy przykład tworzy wykres kolumnowy i uzyskuje dostęp do jego komórek przez [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--). W arkuszu 0, B2 zawiera współczynnik konwersji, a C2 współczynnik. Obie komórki dostarczają wartości wykresu. Przykład także włącza etykiety wartości powiązane z formatami źródłowymi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Formaty komórek zeszytu są oddzielne od formatów ustawionych bezpośrednio na osiach wykresu lub etykietach danych. W tym przykładzie każda etykieta wyświetla wartość swojej komórki źródłowej, ponieważ [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ustawiono na `true`, oraz podąża za formatem liczbowym źródła, ponieważ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) ustawiono na `true`. Po zapisaniu i ponownym otwarciu prezentacji etykiety wyświetlają `12.5000%` i `0.12346`, jak pokazano poniżej. Pionowa oś używa własnego formatu liczby, ustawionego przy pomocy [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) jako `0.00`, przy czym [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) jest ustawione na `false`.

Aby sformatować etykietę danych niezależnie, ustaw jej flagę powiązania ze źródłem na `false` i przypisz format przy pomocy [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Nie zmienia to formatu komórki zeszytu. Na przykład niezależny format etykiety `0.00` wyświetli pierwszą wartość jako `0.13`, podczas gdy B2 nadal wyświetla `12.5000%`. Zobacz [Chart Data Labels](/slides/pl/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) po bezpośrednie formatowanie etykiet.

Obraz poniżej został wygenerowany z zapisanej prezentacji po jej ponownym otwarciu:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Ustaw komórkę zeszytu jako etykietę danych wykresu**

Możesz używać tekstu z komórek zeszytu jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zarządzaj arkuszami**

Metoda [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) zapewnia dostęp do arkuszy w zeszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwy poszczególnych arkuszy w konsoli.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Określ typ źródła danych**

Wartości punktów serii mogą być także przechowywane bezpośrednio jako literały liczbowe. Zobacz [Set Series Values Using Numeric Literals](/slides/pl/androidjava/chart-series/#set-series-values-using-numeric-literals) po kompletny przykład zapisu i odczytu. Typ źródła punktów jest oddzielny od wewnętrznej lub zewnętrznej konfiguracji zeszytu wykresu; użycie literałów liczbowych samo w sobie nie usuwa osadzonego zeszytu.

Ten przykład tworzy trójwymiarowy wykres kolumnowy z domyślnymi danymi i ustawia nazwy dwóch serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału łańcuchowego; druga używa komórki C1 w arkuszu 0. Wyliczenie [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wykryj nieobsługiwane formaty osadzonych zeszytów**

Aspose.Slides nie obsługuje formatu binarnego zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) na [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) razem z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy. Ten przykład sprawdza kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty nie będące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym zeszytem .xlsb.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Odczytaj lub zmodyfikuj obsługiwane dane zeszytu wykresu tutaj.
    }
} finally {
    presentation.dispose();
}
```

## **Zewnętrzny zeszyt**

Aspose.Slides obsługuje używanie zewnętrznych zeszytów jako źródła danych dla wykresów.

### **Utwórz zewnętrzny zeszyt**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) i [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) aby wyeksportować osadzony zeszyt wykresu do pliku i powiązać wykres z tym zewnętrznym zeszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego zeszyt. Najpierw zapisuje plik, a dopiero potem przypisuje zewnętrzny zeszyt jako źródło danych wykresu, po czym zapisuje połączoną prezentację.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Ustaw zewnętrzny zeszyt**

Używając metody [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może być także użyta do aktualizacji ścieżki do zewnętrznego zeszytu (jeśli został przeniesiony).

Choć nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podana jest względna ścieżka do zewnętrznego zeszytu, zostaje ona automatycznie przekonwertowana na ścieżkę pełną.

Ten przykład używa zewnętrznego zeszytu, którego arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy zeszyt i używa [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) aby mapować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z połączonym wykresem.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) określa, czy zeszyt ma zostać załadowany.

* Gdy `updateChartData` jest `false`, aktualizowana jest tylko ścieżka zeszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego zeszytu, więc zeszyt może być niedostępny.
* Gdy `updateChartData` jest `true`, dane wykresu są aktualizowane z docelowego zeszytu.

Poniższy przykład przypisuje przykładowy adres URL z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego zeszytu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pobierz ścieżkę zewnętrznego zeszytu danych wykresu**

Aby zidentyfikować zeszyt powiązany z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i pobierz jego ścieżkę zeszytu.

Ten przykład bada pierwszy kształt na pierwszym slajdzie prezentacji z podłączonym zewnętrznym zeszytem. Jeśli jest to wykres powiązany z zewnętrznym zeszytem, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) w konsoli. Następnie zapisuje kopię prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Edytuj dane wykresu**

Możesz edytować dane w zewnętrznych zeszytach w taki sam sposób, w jaki modyfikujesz zawartość wewnętrznych zeszytów. Gdy zewnętrzny zeszyt nie może być załadowany, zostaje zgłoszony wyjątek.

Ten przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie i jest powiązany z dostępnym zewnętrznym zeszytem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może aktualizować podłączony zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny zeszyt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Odzyskaj zeszyt z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), wywołaj [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), i ustaw [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) na `true` przed otwarciem prezentacji.

Poniższy przykład w Javie odzyskuje dane zeszytu dla wykresu, który jest pierwszym kształtem na pierwszym slajdzie i odwołuje się do niedostępnego zewnętrznego zeszytu. Uzyskuje dostęp do odzyskanych danych przez [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) i [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Odczytaj lub zmodyfikuj odzyskane dane zeszytu tutaj.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides rzuca wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z pamięci podręcznej jest dopuszczalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym zeszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) oraz [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych zeszytów i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona w ścieżkę bezwzględną. Prezentacja przechowuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie zeszytu może wymagać aktualizacji łącza.

**Czy mogę używać zeszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie zeszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Edycja danych wykresu opartej na komórkach może również zaktualizować powiązany lokalny plik XLSX. Użyj kopii zeszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, jeśli zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie akceptuje hasła przy łączeniu. Typowym podejściem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/java/)) i podłączenie do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własne łącze. Jeśli wszystkie wskazują ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.