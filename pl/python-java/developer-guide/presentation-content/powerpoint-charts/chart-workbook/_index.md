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
description: "Odkryj Aspose.Slides dla Pythona via Java: łatwo zarządzaj skoroszytami wykresów w formatach PowerPoint i OpenDocument, aby usprawnić dane w swojej prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z skoroszytami wykresów w Aspose.Slides. Pokazuje, jak odczytywać i zapisywać dane wykresu przy użyciu strumieni skoroszytu, używać komórek skoroszytu jako etykiet danych wykresu, uzyskiwać dostęp do kolekcji arkuszy oraz określać typ źródła danych dla wartości wykresu.

Omówiono także pracę z zewnętrznymi skoroszytami jako źródłami danych wykresu. Przykłady demonstrują, jak utworzyć i przypisać zewnętrzny skoroszyt, pobrać ścieżkę zewnętrznego skoroszytu połączonego z wykresem oraz edytować dane wykresu, gdy skoroszyt jest dostępny.

Dla komórek skoroszytu, które reprezentują brakujące dane, zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/python-java/chart-series/) – różnica między pustą komórką a zerem oraz porównanie wykresu liniowego dostępnych trybów wyświetlania.

## **Uwzględnianie danych z ukrytych wierszy i kolumn**

Użyj [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly), aby kontrolować, czy wykres rysuje dane z ukrytych wierszy i kolumn arkusza. Ustaw `True`, aby rysować tylko widoczne komórki, lub `False`, aby uwzględnić zarówno widoczne, jak i ukryte komórki. To ustawienie kontroluje rysowanie wykresu; nie ukrywa ani nie odsłania wierszy lub kolumn arkusza.

[Przykładowa prezentacja](hidden-source-data.pptx) zawiera wykres słupkowy jako pierwszy kształt na pierwszym slajdzie. Osadzony arkusz, `Sheet1`, zawiera następujący zakres źródłowy, `A1:C4`. Wiersz 3 i kolumna C są ukryte, ale ich komórki nadal zawierają wartości.

| Wiersz arkusza | A: Miesiąc | B: Detal | C: Hurt (ukryta kolumna) |
| --- | --- | --- | --- |
| 2 | Styczeń | 10 | 30 |
| 3 (ukryty wiersz) | Luty | 40 | 60 |
| 4 | Marzec | 20 | 50 |

Uzyskaj dostęp do komórek źródłowych przez [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) i odczytaj [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden), aby sprawdzić ich status ukrycia. Ta metoda zwraca status ukrycia bez jego zmiany. W tym pliku B2 jest widoczny, B3 należy do ukrytego wiersza, a C2 do ukrytej kolumny; przykład wypisuje kolejno `False`, `True` i `True`.

W tym przykładzie odśwież dane wykresu po zmianie ustawienia rysowania: zachowaj osadzony skoroszyt przy użyciu [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) i wczytaj go ponownie za pomocą [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Przy uwzględnianiu wszystkich komórek użyj także [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), aby przywrócić pełny zakres, włączając ukrytą kategorię luty. Same zmiany flagi nie odświeżają pamięci podręcznej danych i etykiet kategorii w tym przykładzie.

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

Przykład zapisuje dwie wersje prezentacji: jedną z tylko widocznymi wartościami detalicznymi (10 i 20), a drugą ze wszystkimi sześcioma wartościami. Poniższe obrazy ilustrują dwa tryby rysowania. Wiersz 3 i kolumna C pozostają ukryte w obu osadzonych skoroszytach.

| Tylko widoczne komórki (`True`) | Wszystkie komórki (`False`) |
| --- | --- |
| ![Tylko widoczne komórki: wartości detaliczne 10 i 20 dla stycznia i marca.](hidden_cells_True.png) | ![Wszystkie komórki: wartości detaliczne i hurtowe dla stycznia, lutego i marca.](hidden_cells_False.png) |

Ukryta komórka zawierająca wartość różni się od pustej komórki. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) kontroluje, jak wyświetlane są brakujące wartości; nie obejmuje ani nie wyklucza ukrytych danych źródłowych. Zobacz [Kontrolowanie wyświetlania pustych komórek](/slides/pl/python-java/chart-series/#control-the-display-of-empty-cells) po przykład.

## **Pobieranie zakresu danych wykresu**

Przed aktualizacją danych skoroszytu w istniejącej prezentacji sprawdź zakresy źródłowe, aby zidentyfikować, które komórki arkusza używa każdy wykres. Metoda [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) zwraca bieżący zakres danych jako formułę kwalifikowaną arkuszem, np. `Sheet1!$A$1:$D$5`. Tutaj `Sheet1` to nazwa arkusza, `!` oddziela ją od zakresu komórek, a `$A$1:$D$5` określa komórki od A1 do D5 włącznie. Znaki dolarowe oznaczają odwołania bezwzględne do wiersza i kolumny.

Metoda odczytuje bieżący zakres bez zmiany wykresu ani jego skoroszytu. Jeśli wykres nie używa skoroszytu jako źródła danych, rzuca `InvalidOperationException`. Więcej informacji znajdziesz w [odwołaniu API ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Ten przykład otwiera prezentację i sprawdza kształty bezpośrednio na każdym slajdzie pod kątem wykresów. Wypisuje nazwę każdego wykresu i jego zakres źródłowy. Jeśli wykres nie używa skoroszytu, wypisuje komunikat i przechodzi do kolejnego wykresu.

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

## **Odczyt i zapis danych wykresu z skoroszytu**

Aspose.Slides for Python via Java udostępnia metody [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) i [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream), które pozwalają odczytywać i zapisywać skoroszyty danych wykresu (zawierające dane wykresu edytowane przy pomocy Aspose.Cells). **Uwaga**, dane wykresu muszą być zorganizowane w ten sam sposób lub mieć strukturę podobną do źródła.

Ten przykład używa prezentacji z wykresem jako pierwszym kształtem na pierwszym slajdzie. Odczytuje osadzony skoroszyt do tablicy bajtów, usuwa istniejące serie i kategorie, a następnie zapisuje ten sam skoroszyt z powrotem. Zmiany pozostają w pamięci; przykład nie zapisuje prezentacji.

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

### **Walidacja układu wykresu po modyfikacji skoroszytu**

Gdy zastąpisz osadzony skoroszyt zmodyfikowanym, wykres zachowuje oryginalne kolekcje serii i kategorii. Taka niespójność może spowodować niepowodzenie [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) z błędem indeksu poza zakresem. Usuń istniejące serie i kategorie przed zapisaniem zaktualizowanego skoroszytu do wykresu. Ten przykład używa wykresu, który jest pierwszym kształtem na pierwszym slajdzie. Komentarz wskazuje miejsce, w którym mogłoby nastąpić edytowanie skoroszytu; uruchamialny przykład zapisuje oryginalny skoroszyt z powrotem i waliduje układ w pamięci.

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

        # Zmodyfikuj bajty skoroszytu tutaj, na przykład używając Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Usunięcie kolekcji usuwa przestarzałe referencje danych przed zapisaniem skoroszytu. Zbuduj ponownie wymagane mapowania serii i kategorii dla zaktualizowanego skoroszytu przed użyciem wykresu.

## **Ustawienie komórki skoroszytu jako etykiety danych wykresu**

Możesz używać tekstu z komórek skoroszytu jako etykiet danych wykresu.

Ten przykład dodaje wykres bąbelkowy z danymi domyślnymi do pierwszego slajdu istniejącej prezentacji. Używa komórek A10:A12 w arkuszu 0 jako pierwszych trzech etykiet w pierwszej serii, włącza etykiety z komórek i zapisuje zaktualizowaną prezentację.

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

Metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) zapewnia dostęp do arkuszy w skoroszycie wykresu. Ten przykład tworzy wykres kołowy z danymi domyślnymi i wypisuje każdą nazwę arkusza w konsoli.

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

Ten przykład tworzy wykres kolumnowy 3D z danymi domyślnymi i ustawia dwie nazwy serii przy użyciu różnych źródeł danych. Pierwsza nazwa używa literału łańcucha; druga używa komórki C1 w arkuszu 0. Wyliczenie [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) wybiera źródło dla każdej nazwy. Przykład zapisuje prezentację z zaktualizowanymi nazwami serii.

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

## **Wykrywanie nieobsługiwanych formatów osadzonych skoroszytów**

Aspose.Slides nie obsługuje formatu binarnego skoroszytu Excel (.xlsb), który może być osadzony w niektórych wykresach. Możesz użyć metody [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) wraz z wyliczeniem [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/), aby wykrywać nieobsługiwane formaty i pomijać takie wykresy. Ten przykład sprawdza kształty na pierwszym slajdzie istniejącej prezentacji, pomija kształty niebędące wykresami i wypisuje komunikat diagnostyczny dla każdego wykresu z osadzonym skoroszytem .xlsb.

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
        # Odczytaj lub zmodyfikuj obsługiwane dane skoroszytu wykresu tutaj.
finally:
    presentation.dispose()
```

## **Zewnętrzny skoroszyt**

Aspose.Slides obsługuje używanie zewnętrznych skoroszytów jako źródła danych dla wykresów.

### **Utworzenie zewnętrznego skoroszytu**

Użyj [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) i [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), aby wyeksportować osadzony skoroszyt wykresu do pliku i połączyć wykres z tym zewnętrznym skoroszytem.

Ten przykład tworzy wykres kołowy z danymi domyślnymi i eksportuje jego skoroszyt. Zapis pliku zostaje zakończony przed przypisaniem zewnętrznego skoroszytu jako źródła danych wykresu, po czym zapisuje połączoną prezentację.

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

Używając metody [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), możesz przypisać zewnętrzny skoroszyt do wykresu jako jego źródło danych. Metoda może także służyć do aktualizacji ścieżki do zewnętrznego skoroszytu (jeśli został przeniesiony).

Choć nie możesz edytować danych w skoroszytach przechowywanych w zdalnych lokalizacjach lub zasobach, możesz nadal używać takich skoroszytów jako zewnętrznego źródła danych. Jeśli podano względną ścieżkę do zewnętrznego skoroszytu, zostaje ona automatycznie przekształcona w pełną ścieżkę.

Ten przykład używa zewnętrznego skoroszytu, którego arkusz o nazwie `Sheet1` zawiera nazwę serii w B1, nazwy kategorii w A2:A4 i wartości liczbowe w B2:B4. Przykład tworzy wykres kołowy, łączy skoroszyt i używa [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), aby mapować A1:B4 na jedną serię i trzy kategorie. Zapisuje prezentację z połączonym wykresem.

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

* Gdy `updateChartData` jest `False`, aktualizowana jest tylko ścieżka do skoroszytu. Dane wykresu nie są ładowane ani aktualizowane z docelowego skoroszytu, więc skoroszyt może być niedostępny.
* Gdy `updateChartData` jest `True`, dane wykresu są aktualizowane z docelowego skoroszytu.

Poniższy przykład przypisuje adres URL zastępczy z `updateChartData` ustawionym na `False`. Zachowuje domyślne dane wykresu kołowego i zapisuje prezentację bez ładowania niedostępnego skoroszytu.

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

### **Uzyskanie ścieżki zewnętrznego skoroszytu źródła danych wykresu**

Aby zidentyfikować skoroszyt połączony z wykresem, sprawdź, czy wykres używa zewnętrznego źródła danych i pobierz jego ścieżkę.

Ten przykład analizuje pierwszy kształt na pierwszym slajdzie prezentacji z połączonym zewnętrznym skoroszytem. Jeśli jest to wykres połączony z zewnętrznym skoroszytem, przykład wypisuje [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) w konsoli. Następnie zapisuje kopię prezentacji.

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

Możesz edytować dane w zewnętrznych skoroszytach w taki sam sposób, w jaki modyfikujesz zawartość wewnętrznych skoroszytów. Gdy zewnętrzny skoroszyt nie może zostać załadowany, zgłaszany jest wyjątek.

Ten przykład używa wykresu będącego pierwszym kształtem na pierwszym slajdzie i połączonego z dostępnym zewnętrznym skoroszytem. Ustawia wartość opartą na komórce pierwszego punktu danych w pierwszej serii na 100 i zapisuje zaktualizowaną prezentację. Edycja wartości komórek może aktualizować połączony zewnętrzny plik XLSX, więc użyj kopii, jeśli musisz zachować oryginalny skoroszyt.

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

Jeśli wykres używa zewnętrznego skoroszytu, który jest brakujący lub niedostępny, Aspose.Slides może odtworzyć skoroszyt wykresu z danych zapisanych w pamięci podręcznej prezentacji. Utwórz [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), wywołaj [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) i ustaw [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) na `True` przed otwarciem prezentacji.

Poniższy przykład w Pythonie odzyskuje dane skoroszytu dla wykresu będącego pierwszym kształtem na pierwszym slajdzie i odwołującego się do niedostępnego zewnętrznego skoroszytu. Uzyskuje dostęp do odzyskanych danych poprzez [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) i [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Odczytaj lub zmodyfikuj odzyskane dane skoroszytu tutaj.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Jeśli zewnętrzny skoroszyt jest niedostępny i odzyskiwanie jest wyłączone, Aspose.Slides zgłasza wyjątek. Włącz odzyskiwanie tylko wtedy, gdy użycie danych z pamięci podręcznej wykresu jest akceptowalnym rozwiązaniem awaryjnym, ponieważ pamięć podręczna może nie zawierać zmian dokonanych w zewnętrznym skoroszycie po ostatniej aktualizacji prezentacji.

## **FAQ**

**Czy mogę określić, czy konkretny wykres jest połączony z zewnętrznym czy osadzonym skoroszytem?**

Tak. Wykres posiada [typ źródła danych](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) oraz [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); jeśli źródłem jest zewnętrzny skoroszyt, możesz odczytać pełną ścieżkę, aby upewnić się, że używany jest plik zewnętrzny.

**Czy obsługiwane są względne ścieżki do zewnętrznych skoroszytów i jak są przechowywane?**

Tak. Jeśli podasz względną ścieżkę, zostaje ona automatycznie przekształcona w ścieżkę bezwzględną. Prezentacja zapisuje ścieżkę bezwzględną w pliku PPTX, więc przeniesienie skoroszytu może wymagać aktualizacji łącza.

**Czy mogę używać skoroszytów znajdujących się na zasobach sieciowych/udziałach?**

Tak, takie skoroszyty mogą być używane jako zewnętrzne źródło danych. Jednak edycja zdalnych skoroszytów bezpośrednio z Aspose.Slides nie jest obsługiwana – mogą być używane jedynie jako źródło.

**Czy Aspose.Slides nadpisuje zewnętrzny plik XLSX przy zapisie prezentacji?**

Prezentacja zapisuje [łącze do zewnętrznego pliku](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Edycja danych wykresu opartych o komórki może również aktualizować połączony lokalny plik XLSX. Użyj kopii skoroszytu, jeśli oryginał musi pozostać niezmieniony.

**Co zrobić, jeśli zewnętrzny plik jest chroniony hasłem?**

Aspose.Slides nie przyjmuje hasła podczas łączenia. Typowe podejście polega na usunięciu ochrony wcześniej lub przygotowaniu odszyfrowanej kopii (np. przy użyciu [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) i połączeniu się z tą kopią.

**Czy wiele wykresów może odwoływać się do tego samego zewnętrznego skoroszytu?**

Tak. Każdy wykres przechowuje własne łącze. Jeśli wszystkie wskazują na ten sam plik, aktualizacja tego pliku będzie odzwierciedlona w każdym wykresie przy następnym wczytaniu danych.