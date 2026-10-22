---
title: Zarządzanie skoroszytami wykresów w prezentacjach przy użyciu Java
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
- bufor wykresu
- odzyskiwanie skoroszytu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj Aspose.Slides for Java: z łatwością zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni skoroszytu, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny skoroszyt, odczytać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

W przypadku komórek skoroszytu reprezentujących brakujące dane, zobacz [Control the Display of Empty Cells](/slides/pl/java/chart-series/) dotyczące różnicy między pustą komórką a zerem oraz porównania wykresu liniowego dostępnych trybów wyświetlania.

## **Dołącz dane z ukrytych wierszy i kolumn**

Użyj [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw na `true`, aby rysować tylko widoczne komórki, lub na `false`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odsłania wierszy lub kolumn arkusza.

[Sample presentation](hidden-source-data.pptx) zawiera wykres słupkowy jako pierwszy kształt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera zakres źródłowy `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Sprzedaż detaliczna | C: Sprzedaż hurtowa (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych przez [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) i odczytaj [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) aby sprawdzić ich status ukrycia. Metoda ta zgłasza status ukrycia bez jego zmiany. W tym pliku B2 jest widoczne, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `false`, `true` i `true`.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony skoroszyt metodą [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) i wczytaj go ponownie metodą [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Przy uwzględnianiu wszystkich komórek użyj także [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) aby przywrócić pełny zakres, włączając ukrytą kategorię luty. Samo zmienienie flagi nie wystarczy, aby odświeżyć buforowane dane wykresu i etykiety kategorii w tym przykładzie.

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

            // Odśwież dane wykresu z osadzonego skoroszytu.
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

Przykład zapisuje dwie wersje prezentacji: jedną tylko z widocznymi wartościami sprzedaży detalicznej (10 i 20), oraz drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby wykreślania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych skoroszytach.

| Tylko widoczne komórki (`true`) | Wszystkie komórki (`false`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości sprzedaży detalicznej 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości sprzedaży detalicznej i hurtowej dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) kontroluje, jak wyświetlane są brakujące wartości; nie włącza ani nie wyłącza ukrytych danych źródłowych. Zobacz [Control the Display of Empty Cells](/slides/pl/java/chart-series/#control-the-display-of-empty-cells) dla przykładu.

## **Pobranie zakresu danych wykresu**

Przed aktualizacją danych skoroszytu w istniejącej prezentacji sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa każdy wykres. Metoda [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` wskazuje komórki od A1 do D5 włącznie. Znaki dolara oznaczają bezwzględne odwołania do wierszy i kolumn.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego skoroszytu. Jeśli wykres nie używa skoroszytu jako źródła danych, zgłasza `InvalidOperationException`. Więcej informacji znajdziesz w [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu oraz jego zakres źródłowy. Jeśli wykres nie używa skoroszytu, wypisuje komunikat i przechodzi do kolejnego wykresu.

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

## **Odczyt i zapis danych wykresu z skoroszytu**

Aspose.Slides for Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) i [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---), które pozwalają odczytywać i zapisywać skoroszyty danych wykresu (zawierające dane edytowane przy pomocy Aspose.Cells). **Uwaga**: dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład używa prezentacji z wykresem jako pierwszym kształtem na pierwszym slajdzie. Odczytuje osadzony skoroszyt do tablicy bajtów, Czyści istniejące serie i kategorie, i zapisuje ten sam skoroszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Sprawdź układ wykresu po modyfikacji skoroszytu**

Gdy zamienisz osadzony skoroszyt na zmodyfikowany, wykres zachowuje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować niepowodzenie [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) z błędem indeksu poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego skoroszytu z powrotem do wykresu. Przykład używa wykresu będącego pierwszym kształtem na pierwszym slajdzie. Komentarz wskazuje, gdzie miałoby nastąpić edytowanie skoroszytu; działający przykład zapisuje oryginalny skoroszyt z powrotem i w pamięci weryfikuje układ.

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

        // Modyfikuj bajty skoroszytu tutaj, na przykład przy użyciu Aspose.Cells.

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

Czyszczenie kolekcji usuwa przestarzałe odwołania danych przed zapisaniem skoroszytu. Przed użyciem wykresu odtwórz wymagane mapowania serii i kategorii dla zaktualizowanego skoroszytu.

## **Ustaw własne formaty liczbowe dla komórek skoroszytu**

Użyj [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) aby kontrolować, jak wartości liczbowe wyświetlają się w osadzonym skoroszycie wykresu. Na przykład raport może wymagać wyświetlenia współczynnika konwersji jako procentu z czterema miejscami po przecinku oraz współczynnika z pięcioma miejscami po przecinku. Zachowaj obie wartości jako liczby, aby były dostępne do obliczeń i rysowania wykresu.

Format liczbowy zmienia jedynie sposób wyświetlania, nie przechowywaną wartość. Format `0.0000%` wyświetla `0.125` jako `12.5000%`; nie zastępuje przechowywanej liczby `12.5`. Analogicznie, `0.00000` wyświetla `0.1234567` jako `0.12346` bez zaokrąglania przechowywanej wartości. Jeśli niestandardowy format jest pustym ciągiem (`""`), używany jest format zwrócony przez [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

Poniższy przykład tworzy wykres słupkowy i uzyskuje dostęp do jego komórek przez [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--). W arkuszu 0, B2 zawiera współczynnik konwersji, a C2 współczynnik. Obie komórki dostarczają wartości wykresu. Przykład włącza także etykiety wartości powiązane z formatami źródłowymi.

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

Formaty komórek skoroszytu są oddzielne od formatów ustawionych bezpośrednio na osiach wykresu lub etykietach danych. W tym przykładzie każda etykieta wyświetla wartość swojej komórki źródłowej, ponieważ [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) jest ustawione na `true`, a format liczbowy pochodzi ze źródła, ponieważ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) jest ustawione na `true`. Po zapisaniu i ponownym otwarciu prezentacji etykiety wyświetlają `12.5000%` i `0.12346`, jak pokazano poniżej. Pionowa oś używa własnego formatu liczbowego, ustawionego metodą [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) na `0.00`, przy czym [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) jest ustawione na `false`.

Aby sformatować etykietę danych niezależnie, ustaw jej flagę powiązania ze źródłem na `false` i przypisz format metodą [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Nie zmienia to formatu komórki skoroszytu. Na przykład niezależny format etykiety `0.00` wyświetli pierwszą wartość jako `0.13`, podczas gdy B2 nadal wyświetla `12.5000%`. Zobacz [Chart Data Labels](/slides/pl/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) dla bezpośredniego formatowania etykiet.

Obraz poniżej został wygenerowany z zapisanej prezentacji po jej ponownym otwarciu:

![Wykres słupkowy z etykietami powiązanymi ze źródłem, pokazującymi 12.5000% i 0.12346 oraz niezależnie sformatowaną oś liczbową.](custom-cell-formats.png)

## **Ustaw komórkę skoroszytu jako etykietę danych wykresu**

Możesz używać tekstu z komórek skoroszytu jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 jako pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

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

Metoda [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) zapewnia dostęp do arkuszy w skoroszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwy poszczególnych arkuszy na konsolę.

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

Wartości punktów serii mogą być również przechowywane bezpośrednio jako literały liczbowe. Zobacz [Set Series Values Using Numeric Literals](/slides/pl/java/chart-series/#set-series-values-using-numeric-literals) dla pełnego przykładu, który zapisuje i odczytuje je. Typ źródła wartości punktów jest oddzielny od wewnętrznej lub zewnętrznej konfiguracji skoroszytu wykresu; użycie literałów liczbowych nie usuwa automatycznie osadzonego skoroszytu.

Ten przykład tworzy trójwymiarowy wykres słupkowy z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa korzysta z literału ciągu znaków; druga używa komórki C1 w arkuszu 0. Wyliczenie [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

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

## **Wykryj nieobsługiwane formaty osadzonych skoroszytów**

Aspose.Slides nie obsługuje binarnego formatu skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) na interfejsie [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy. Ten przykład przegląda kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

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

        // Wczytaj lub zmodyfikuj obsługiwane dane skoroszytu wykresu tutaj.
    }
} finally {
    presentation.dispose();
}
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Utwórz zewnętrzny skoroszyt**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) i [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) aby wyeksportować osadzony skoroszyt wykresu do pliku i połączyć wykres z tym zewnętrznym skoroszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego skoroszyt. Zapis pliku kończy się przed przypisaniem zewnętrznego skoroszytu jako źródła danych wykresu, a następnie zapisuje powiązaną prezentację.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Ustaw zewnętrzny skoroszyt**

Używając metody [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może być również użyta do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został on przeniesiony).

Choć nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Ten przykład używa zewnętrznego skoroszytu, którego arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy skoroszyt i używa [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) aby zmapować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z połączonym wykresem.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) kontroluje, czy skoroszyt zostanie załadowany.

* Gdy `updateChartData` ma wartość `false`, aktualizowana jest jedynie ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `updateChartData` ma wartość `true`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje adres URL zastępczy z `updateChartData` ustawionym na `false`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

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

### **Pobierz ścieżkę skoroszytu zewnętrznego źródła danych wykresu**

Aby zidentyfikować skoroszyt powiązany z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i odczytaj jego ścieżkę.

Ten przykład przegląda pierwszy kształt na pierwszym slajdzie prezentacji z powiązanym zewnętrznym skoroszytem. Jeśli jest to wykres połączony z zewnętrznym skoroszytem, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) na konsolę. Następnie zapisuje kopię prezentacji.

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

Możesz edytować dane w zewnętrznych skoroszytach tak samo, jak wprowadzane zmiany w zawartości wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje rzucony wyjątek.

Ten przykład używa wykresu będącego pierwszym kształtem na pierwszym slajdzie i połączonego z dostępnym zewnętrznym skoroszytem. Ustawia wartość komórkową pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może zaktualizować powiązany zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny skoroszyt.

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

### **Odzyskaj skoroszyt z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest nieobecny lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), wywołaj [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), i ustaw [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) na `true` przed otwarciem prezentacji.

Poniższy przykład w Javie odzyskuje dane skoroszytu dla wykresu będącego pierwszym kształtem na pierwszym slajdzie i odwołującego się do niedostępnego zewnętrznego skoroszytu. Dostęp do odzyskanych danych uzyskuje poprzez [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) i [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Wczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides rzuca wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest dopuszczalnym rozwiązaniem awaryjnym, ponieważ bufor może nie zawierać zmian wprowadzonych do zewnętrznego skoroszytu po ostatniej aktualizacji prezentacji.

## **Najczęściej zadawane pytania**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres ma [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) oraz [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy ścieżki względne do zewnętrznych skoroszytów są obsługiwane i jak są przechowywane?**

Tak. Jeśli podasz ścieżkę względną, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji łącza.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udostępnionych?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana — mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisywaniu prezentacji?**

Prezentacja przechowuje [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Edycja danych wykresu opartych na komórkach może również zaktualizować powiązany lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, jeśli plik zewnętrzny jest chroniony hasłem?**

Aspose.Slides nie przyjmuje hasła przy łączeniu. Typowym podejściem jest usunięcie ochrony wcześniej lub przygotowanie odszyfrowanej kopii (na przykład przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/java/)) i połączenie się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własne łącze. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym ładowaniu danych.