---
title: Zarządzanie zeszytami wykresów w prezentacjach przy użyciu Pythona poprzez Javę
linktitle: Zeszyt wykresu
type: docs
weight: 70
url: /pl/python-java/chart-workbook/
keywords:
- zeszyt wykresu
- dane wykresu
- komórka zeszytu
- etykieta danych
- arkusz
- źródło danych
- zewnętrzny zeszyt
- zewnętrzne dane
- bufor wykresu
- odzyskiwanie zeszytu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Odkryj Aspose.Slides dla Pythona poprzez Javę: bez wysiłku zarządzaj zeszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z zeszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu za pośrednictwem strumieni zeszytów, używać komórek zeszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówione są także prace z zewnętrznymi zeszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny zeszyt, uzyskać ścieżkę zewnętrznego zeszytu powiązanego z wykresem oraz edytować dane wykresu, gdy zeszyt jest dostępny.

W celu obsługi komórek zeszytu reprezentujących brakujące dane, zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/python-java/chart-series/) – opis różnicy między pustą komórką a zerem oraz porównanie wykresu liniowego dostępnych trybów wyświetlania.

## **Uwzględnianie danych z ukrytych wierszy i kolumn**

Użyj [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly), aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw na `True`, aby rysować tylko widoczne komórki, lub `False`, aby uwzględnić zarówno widoczne, jak i ukryte. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odsłania wierszy czy kolumn arkusza.

Pobierz [hidden-source-data.pptx](hidden-source-data.pptx) i umieść go w katalogu roboczym. Na pierwszym slajdzie znajduje się wykres słupkowy jako pierwszy obiekt. Osadzony arkusz `Sheet1` zawiera zakres źródłowy `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych poprzez [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getChartDataWorkbook) i odczytaj [ChartDataCell.isHidden](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdatacell/#isHidden), aby sprawdzić ich stan ukrycia. Metoda zwraca status ukrycia bez jego zmiany. W tym pliku B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `False`, `True` i `True`.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony zeszyt przy użyciu [readWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#readWorkbookStream) i wczytaj go ponownie przy pomocy [writeWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#writeWorkbookStream). Przy uwzględnianiu wszystkich komórek, użyj także [setRange](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setRange), aby przywrócić pełny zakres, włączając ukrytą kategorię luty. Sama zmiana flagi nie odświeża buforowanych danych wykresu i etykiet kategorii w tym przykładzie.

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

            # Odśwież dane wykresu z osadzonego zeszytu.
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

Przykład zapisuje `hidden_cells_True.pptx` z jedynie widocznymi wartościami Detalu (10 i 20) oraz `hidden_cells_False.pptx` ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych zeszytach.

| Tylko widoczne komórki (`True`) | Wszystkie komórki (`False`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości Detalu 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości Detalu i Hurtu dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setDisplayBlanksAs) kontroluje, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontroluj wyświetlanie pustych komórek](/slides/pl/python-java/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Odczyt i zapis danych wykresu z zeszytu**

Aspose.Slides for Python via Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#writeWorkbookStream), które umożliwiają odczyt i zapis zeszytów danych wykresu (zawierających dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga**: dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Przykład otwiera `chart.pptx`, który musi zawierać wykres jako pierwszy obiekt na pierwszym slajdzie. Odczytuje osadzony zeszyt do tablicy bajtów, czyści istniejące serie i kategorie oraz zapisuje ten sam zeszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Weryfikacja układu wykresu po modyfikacji zeszytu**

Kiedy zastępujesz osadzony zeszyt zmodyfikowanym, wykres zachowuje oryginalne kolekcje serii i kategorii. To niezgodność może spowodować błąd [Chart.validateChartLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#validateChartLayout) z komunikatem o indeksie poza zakresem. Wyczyść istniejące serie i kategorie przed zapisaniem zaktualizowanego zeszytu do wykresu. Przykład wymaga `chart.pptx` z wykresem jako pierwszym obiektem na pierwszym slajdzie. Komentarz wskazuje miejsce, w którym miałoby nastąpić edytowanie zeszytu; działający przykład zapisuje oryginalny zeszyt z powrotem i weryfikuje układ w pamięci.

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

        # Modyfikuj bajty zeszytu tutaj, na przykład przy użyciu Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Czyszczenie kolekcji usuwa nieaktualne odniesienia do danych przed zapisem zeszytu. Przed użyciem wykresu odbuduj wymagane mapowania serii i kategorii dla zaktualizowanego zeszytu.

## **Ustawienie komórki zeszytu jako etykiety danych wykresu**

Możesz używać tekstu z komórek zeszytu jako etykiet danych wykresu. Poniższe kroki pokazują, jak połączyć etykiety w wykresie bąbelkowym z komórkami jego zeszytu danych.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu przez indeks zerowy.
3. Dodaj wykres bąbelkowy z domyślnymi danymi.
4. Uzyskaj dostęp do serii wykresu.
5. Ustaw komórkę zeszytu jako etykietę danych.
6. Zapisz prezentację.

Przykład otwiera `chart2.pptx`, który musi zawierać przynajmniej jeden slajd, i dodaje wykres bąbelkowy z domyślnymi danymi. Używa komórek A10:A12 w arkuszu 0 jako pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje wynik jako `resultchart.pptx`.

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

Metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdataworkbook/#getWorksheets) zapewnia dostęp do arkuszy w zeszycie wykresu. Przykład tworzy wykres kołowy z domyślnymi danymi i wypisuje nazwy wszystkich arkuszy w konsoli.

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

Przykład tworzy wykres kolumnowy 3D z domyślnymi danymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa pochodzi z literału tekstowego; druga z komórki C1 w arkuszu 0. Typ źródła określa enumeracja [DataSourceType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/datasourcetype/). Wynik jest zapisywany jako `pres.pptx`.

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

## **Wykrywanie nieobsługiwanych formatów osadzonych zeszytów**

Aspose.Slides nie obsługuje binarnego formatu zeszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody [getEmbeddedWorkbookType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na [ChartData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/) razem z enumeracją [WorkbookType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/workbooktype/), aby wykryć nieobsługiwane formaty i pominąć takie wykresy. Przykład przegląda obiekty na pierwszym slajdzie `sample.pptx`, pomija obiekty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym zeszytem .xlsb.

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
        # Odczytaj lub zmodyfikuj obsługiwane dane zeszytu wykresu tutaj.
finally:
    presentation.dispose()
```

## **Zewnętrzny zeszyt**

Aspose.Slides obsługuje użycie zewnętrznych zeszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego zeszytu**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#readWorkbookStream) i [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook), aby wyeksportować osadzony zeszyt wykresu do pliku i powiązać wykres z tym zewnętrznym zeszytem.

Przykład tworzy wykres kołowy z domyślnymi danymi, zapisuje jego zeszyt jako `externalWorkbook1.xlsx` i kończy zapis pliku przed przypisaniem go jako źródła danych wykresu. Powiązana prezentacja jest zapisywana jako `externalWorkbook.pptx`.

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

### **Ustawienie zewnętrznego zeszytu**

Za pomocą metody [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook) możesz przypisać zewnętrzny zeszyt do wykresu jako jego źródło danych. Metoda ta może być także użyta do zaktualizowania ścieżki do zewnętrznego zeszytu (jeśli został on przeniesiony).

Nie możesz edytować danych w zeszytach przechowywanych w zdalnych lokalizacjach lub zasobach, ale nadal możesz używać takich zeszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego zeszytu, zostaje ona automatycznie przekształcona na pełną ścieżkę.

Przykład wymaga `externalWorkbook.xlsx` w katalogu roboczym. Jego arkusz o nazwie `Sheet1` musi zawierać nazwę serii w B1, nazwy kategorii w A2:A4 oraz wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy zeszyt i używa [setRange](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setRange), aby mapować A1:B4 na jedną serię i trzy kategorie. Wynik jest zapisywany jako `Presentation_with_externalWorkbook.pptx`.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#setExternalWorkbook) kontroluje, czy zeszyt jest ładowany.

* Gdy `updateChartData` ma wartość `False`, aktualizowana jest jedynie ścieżka zeszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego zeszytu, więc zeszyt może być niedostępny.
* Gdy `updateChartData` ma wartość `True`, dane wykresu są aktualizowane z docelowego zeszytu.

Poniższy przykład przypisuje adres URL zastępczy z `updateChartData` ustawionym na `False`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego zeszytu.

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

### **Pobranie ścieżki zewnętrznego zeszytu źródłowego wykresu**

Aby zidentyfikować zeszyt powiązany z wykresem, najpierw sprawdź, czy wykres używa zewnętrznego źródła danych. Jeśli tak, możesz odczytać ścieżkę zeszytu, wykonując poniższe kroki.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu przez indeks zerowy.
3. Sprawdź, czy pierwszy obiekt jest wykresem.
4. Odczytaj typ źródła danych wykresu.
5. Jeśli źródłem jest zewnętrzny zeszyt, odczytaj jego ścieżkę.

Przykład otwiera `externalWorkbook.pptx`, utworzony we wcześniejszym przykładzie, i przegląda pierwszy obiekt na pierwszym slajdzie. Jeśli jest to wykres powiązany z zewnętrznym zeszytem, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) w konsoli. Następnie zapisuje kopię prezentacji jako `Result.pptx`.

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

Możesz edytować dane w zewnętrznych zeszytach tak samo, jak w wewnętrznych. Gdy zewnętrzny zeszyt nie może zostać załadowany, wyrzucany jest wyjątek.

Przykład wymaga `presentation.pptx` z wykresem jako pierwszym obiektem na pierwszym slajdzie oraz dostępnego zewnętrznego zeszytu. Ustawia wartość komórki pierwszego punktu danych w pierwszej serii na 100 i zapisuje prezentację jako `presentation_out.pptx`. Edycja wartości komórek może aktualizować powiązany zewnętrzny plik XLSX, dlatego używaj kopii, jeśli trzeba zachować oryginalny zeszyt.

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

### **Odzyskiwanie zeszytu z pamięci podręcznej wykresu**

Jeśli wykres używa zewnętrznego zeszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć zeszyt wykresu z danych buforowanych w prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/), wywołaj [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) i ustaw [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pl/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) na `True` przed otwarciem prezentacji.

Poniższy przykład w Pythonie otwiera `presentation.pptx`, którego pierwszy obiekt na pierwszym slajdzie musi być wykresem odwołującym się do niedostępnego zewnętrznego zeszytu, i uzyskuje odzyskane dane poprzez [Chart.getChartData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#getChartData) oraz [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Odczytaj lub zmodyfikuj odzyskane dane zeszytu tutaj.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Jeśli zewnętrzny zeszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides wyrzuca wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie buforowanych danych wykresu jest dopuszczalnym rozwiązaniem, ponieważ bufor może nie zawierać zmian wprowadzonych w zewnętrznym zeszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest powiązany z zewnętrznym, czy osadzonym zeszytem?**

Tak. Wykres posiada [data source type](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getDataSourceType) oraz [path to an external workbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); jeśli źródłem jest zewnętrzny zeszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych zeszytów i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona na ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, dlatego przeniesienie zeszytu może wymagać aktualizacji linku.

**Czy mogę używać zeszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie zeszyty mogą służyć jako zewnętrzne źródło danych. Jednak edycja zdalnych zeszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być używane wyłącznie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisie prezentacji?**

Prezentacja przechowuje [link do pliku zewnętrznego](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Edycja danych wykresu powiązanych z komórkami może również zaktualizować powiązany lokalny plik XLSX. Użyj kopii zeszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, gdy zewnętrzny plik jest zabezpieczony hasłem?**

Aspose.Slides nie przyjmuje hasła przy tworzeniu linku. Często usuwana jest ochrona wcześniej lub przygotowywana jest odszyfrowana kopia (na przykład przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) i linkuje się do tej kopii.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego zeszytu?**

Tak. Każdy wykres przechowuje własny link. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku zostanie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.