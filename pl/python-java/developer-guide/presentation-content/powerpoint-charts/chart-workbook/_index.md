---
title: Zarządzanie skoroszytami wykresów w prezentacjach przy użyciu Pythona via Java
linktitle: Skoroszyt wykresu
type: docs
weight: 70
url: /pl/python-java/chart-workbook/
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
- Python
- Java
- Aspose.Slides
description: "Poznaj Aspose.Slides dla Pythona via Java: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pomocą strumieni skoroszytu, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady pokazują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu powiązanego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

Dla komórek skoroszytu reprezentujących brakujące dane, zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/python-java/chart-series/) w celu poznania różnicy między pustą komórką a zerem oraz porównania wykresu liniowego dostępnych trybów wyświetlania.

## **Dołączanie danych z ukrytych wierszy i kolumn**

Użyj [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly), aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw `True`, aby rysować tylko widoczne komórki, lub `False`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odsłania wierszy ani kolumn arkusza.

[przykładową prezentację](hidden-source-data.pptx) zawiera wykres kolumnowy jako pierwszy kształt na pierwszym slajdzie. Wbudowany arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych za pomocą [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook), a następnie odczytaj [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden), aby sprawdzić ich status ukrycia. Ta metoda zwraca status ukrycia bez jego zmiany. W tym przykładzie B2 jest widoczne, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `False`, `True` i `True`.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj wbudowany skoroszyt przy użyciu [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream), a następnie wczytaj go ponownie przy pomocy [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Przy uwzględnianiu wszystkich komórek użyj także [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), aby przywrócić pełny zakres, w tym ukrytą kategorię luty. Samo zmienienie flagi nie wystarczy, aby odświeżyć buforowane dane wykresu i etykiety kategorii w tym przykładzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Odśwież dane wykresu z osadzonego skoroszytu.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Przywróć pełny zakres źródłowy, w tym ukryte kategorie.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Przykład zapisuje dwie wersje prezentacji: jedną tylko z widocznymi wartościami detalicznymi (10 i 20) oraz drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu wbudowanych skoroszytach.

| Tylko widoczne komórki (`True`) | Wszystkie komórki (`False`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości detaliczne 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości detaliczne i hurtowe dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) steruje sposobem wyświetlania brakujących wartości; nie włącza ani nie wyłącza ukrytych danych źródłowych. Zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/python-java/chart-series/#control-the-display-of-empty-cells) dla przykładu.

## **Pobranie zakresu danych wykresu**

Przed aktualizacją danych skoroszytu w istniejącej prezentacji, sprawdź zakresy źródłowe, aby określić, które komórki arkusza używa każdy wykres. Metoda [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5, włącznie. Znaki dolara wskazują odniesienia bezwzględne do wierszy i kolumn.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego skoroszytu. Jeśli wykres nie używa skoroszytu jako źródła danych, zgłasza `InvalidOperationException`. Więcej informacji znajdziesz w [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdej slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu oraz jego zakres źródłowy. Jeśli wykres nie używa skoroszytu, wypisuje komunikat i przechodzi do kolejnego wykresu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Odczyt i zapis danych wykresu ze skoroszytu**

Aspose.Slides for Python via Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream), które pozwalają odczytywać i zapisywać skoroszyty danych wykresu (zawierające dane wykresu edytowane przy użyciu Aspose.Cells). **Uwaga** dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład używa prezentacji, w której wykres jest pierwszym kształtem na pierwszym slajdzie. Odczytuje wbudowany skoroszyt do tablicy bajtów, usuwa istniejące serie i kategorie oraz zapisuje ten sam skoroszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Sprawdzenie układu wykresu po modyfikacji skoroszytu**

Gdy zastąpisz wbudowany skoroszyt zmodyfikowanym, wykres zachowuje pierwotne kolekcje serii i kategorii. To niezgodność może spowodować, że [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) zakończy się niepowodzeniem z błędem poza zakresem indeksu. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego skoroszytu z powrotem do wykresu. Ten przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie. Komentarz wskazuje, gdzie miałoby nastąpić edytowanie skoroszytu; działający przykład zapisuje oryginalny skoroszyt z powrotem i w pamięci weryfikuje układ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Zmodyfikuj bajty skoroszytu tutaj, na przykład przy użyciu Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Wyczyszczenie kolekcji usuwa przestarzałe odwołania do danych przed zapisaniem skoroszytu. Przed użyciem wykresu odbuduj wymagane mapowania serii i kategorii dla zaktualizowanego skoroszytu.

## **Ustawianie niestandardowych formatów liczbowych dla komórek skoroszytu**

Użyj [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat), aby kontrolować, jak wartości liczbowe wyświetlane są w wbudowanym skoroszycie wykresu. Na przykład raport może wymagać wyświetlenia wskaźnika konwersji jako procentu z czterema miejscami po przecinku oraz współczynnika z pięcioma miejscami po przecinku. Zachowaj obie wartości jako liczbowe, aby pozostały dostępne do obliczeń i rysowania wykresu.

Format liczbowy zmienia jedynie sposób wyświetlania, a nie przechowywaną wartość. Format `0.0000%` wyświetla `0.125` jako `12.5000%`; nie zamienia przechowywanej liczby na `12.5`. Podobnie, `0.00000` wyświetla `0.1234567` jako `0.12346` bez zaokrąglania przechowywanej wartości. Jeśli niestandardowy format jest pustym ciągiem (`""`), używany jest format zwrócony przez [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat).

Poniższy przykład tworzy wykres kolumnowy i uzyskuje dostęp do jego komórek poprzez [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). W arkuszu 0, B2 zawiera wskaźnik konwersji, a C2 współczynnik. Obie komórki dostarczają wartości wykresu. Przykład dodatkowo włącza etykiety wartości powiązane z formatami źródłowymi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Formaty komórek skoroszytu są oddzielne od formatów ustawianych bezpośrednio na osiach wykresu lub etykietach danych. W tym przykładzie każda etykieta wyświetla wartość swojej komórki źródłowej, ponieważ [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) jest ustawione na `True`, a format liczbowy jest powiązany ze źródłem, ponieważ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) jest ustawione na `True`. Po zapisaniu i ponownym otwarciu prezentacji etykiety wyświetlają `12.5000%` i `0.12346`, jak pokazano poniżej. Pionowa oś używa własnego formatu liczbowego, przypisanego metodą [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) jako `0.00`, przy czym [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) jest ustawione na `False`.

Aby sformatować etykietę danych niezależnie, ustaw jej flagę powiązania ze źródłem na `False` i przypisz format metodą [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). Nie zmienia to formatu komórki skoroszytu. Na przykład niezależny format etykiety `0.00` wyświetla pierwszą wartość jako `0.13`, podczas gdy B2 nadal wyświetla `12.5000%`. Zobacz [Etykiety danych wykresu](/slides/pl/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) w celu bezpośredniego formatowania etykiet.

Poniższy obraz został wygenerowany z zapisanej prezentacji po jej ponownym otwarciu:

![Wykres kolumnowy z etykietami powiązanymi ze źródłem, pokazującymi 12,5000% i 0,12346 oraz niezależnie sformatowaną osią liczbową.](custom-cell-formats.png)

## **Ustawienie komórki skoroszytu jako etykiety danych wykresu**

Możesz używać tekstu z komórek skoroszytu jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z domyślnymi danymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 dla pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zarządzanie arkuszami**

Metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) zapewnia dostęp do arkuszy w skoroszycie wykresu. Ten przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwę każdego arkusza w konsoli.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Określenie typu źródła danych**

Wartości punktów serii mogą być również przechowywane bezpośrednio jako literały numeryczne. Zobacz [Ustawianie wartości serii przy użyciu literałów numerycznych](/slides/pl/python-java/chart-series/#set-series-values-using-numeric-literals) po kompletny przykład, który je zapisuje i odczytuje. Typ źródła wartości punktów jest oddzielny od konfiguracji wewnętrznego lub zewnętrznego skoroszytu wykresu; użycie literałów numerycznych nie usuwa wbudowanego skoroszytu.

Ten przykład tworzy trójwymiarowy wykres kolumnowy z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału łańcuchowego; druga używa komórki C1 w arkuszu 0. Enum [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wykrywanie nieobsługiwanych formatów wbudowanych skoroszytów**

Aspose.Slides nie obsługuje binarnego formatu skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) wraz z enumem [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć te wykresy. Ten przykład sprawdza kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z wbudowanym skoroszytem .xlsb.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Odczytaj lub zmodyfikuj tutaj obsługiwane dane skoroszytu wykresu
finally:
    presentation.dispose()
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego skoroszytu**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) i [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), aby wyeksportować wbudowany skoroszyt wykresu do pliku i powiązać wykres z tym zewnętrznym skoroszytem.

Ten przykład tworzy wykres kołowy z domyślnymi danymi i eksportuje jego skoroszyt. Zapis pliku zostaje zakończony przed przypisaniem zewnętrznego skoroszytu jako źródła danych wykresu, po czym zapisuje połączoną prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ustawienie zewnętrznego skoroszytu**

Używając metody [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda ta może być również użyta do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został przeniesiony).

Choć nie możesz edytować danych w skoroszytach przechowywanych w lokalizacjach zdalnych lub zasobach, wciąż możesz używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podana zostanie względna ścieżka do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona w pełną ścieżkę.

Ten przykład używa zewnętrznego skoroszytu, którego arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy skoroszyt i przy użyciu [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) mapuje A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z połączonym wykresem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) kontroluje, czy skoroszyt jest ładowany.

* Gdy `updateChartData` ma wartość `False`, aktualizowana jest tylko ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `updateChartData` ma wartość `True`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje przykładowy adres URL z `updateChartData` ustawionym na `False`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pobranie ścieżki skoroszytu źródła danych zewnętrznych wykresu**

Aby zidentyfikować skoroszyt powiązany z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i pobierz jego ścieżkę.

Ten przykład sprawdza pierwszy kształt na pierwszym slajdzie prezentacji z powiązanym zewnętrznym skoroszytem. Jeśli jest to wykres połączony z zewnętrznym skoroszytem, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) w konsoli. Następnie zapisuje kopię prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Edycja danych wykresu**

Możesz edytować dane w zewnętrznych skoroszytach tak samo, jak wprowadzasz zmiany w zawartości wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zostaje rzucony wyjątek.

Ten przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie i jest połączony z dostępnym zewnętrznym skoroszytem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może aktualizować powiązany zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny skoroszyt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Odzyskanie skoroszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego skoroszytu, który jest nieobecny lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu na podstawie danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), wywołaj [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) i ustaw [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) na `True` przed otwarciem prezentacji.

Poniższy przykład w Pythonie odzyskuje dane skoroszytu dla wykresu, który jest pierwszym kształtem na pierwszym slajdzie i odwołuje się do niedostępnego zewnętrznego skoroszytu. Dostęp do odzyskanych danych uzyskuje się przez [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) oraz [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Odczytaj lub zmodyfikuj tutaj odzyskane dane skoroszytu.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides rzuca wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych wykresu z bufora jest akceptowalnym rozwiązaniem awaryjnym, ponieważ bufor może nie zawierać zmian wprowadzonych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres ma [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) oraz [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych skoroszytów i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona w ścieżkę bezwzględną. Prezentacja przechowuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji linku.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX podczas zapisywania prezentacji?**

Prezentacja przechowuje [link do pliku zewnętrznego](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Edycja danych wykresu powiązanych z komórkami może również aktualizować powiązany lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła przy łączeniu. Typowe podejście to usunięcie ochrony z wyprzedzeniem lub przygotowanie odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) i podłączenie się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.