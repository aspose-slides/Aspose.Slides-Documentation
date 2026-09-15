---
title: Integracja danych Excel w prezentacjach PowerPoint
linktitle: Integracja Excel
type: docs
weight: 330
url: /pl/python-java/excel-integration/
keywords:
- Excel
- skoroszyt
- odczyt Excel
- integracja Excel
- źródło danych
- scalanie korespondencji
- import tabeli
- Excel do PowerPoint
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Odczytaj dane z zeszytów Excel w Aspose.Slides dla Pythona poprzez Javę, używając API ExcelDataWorkbook. Wczytaj arkusze i komórki oraz użyj ich wartości do generowania prezentacji PowerPoint opartych na danych."
---
## **Wprowadzenie**

Prezentacje PowerPoint to potężny sposób wyświetlania i przekazywania informacji. Często są używane w połączeniu z zeszytami Excel, gdzie Excel jest doskonałym źródłem danych strukturalnych, a PowerPoint wyróżnia się wizualizacją tych danych dla odbiorców.

Istnieje wiele praktycznych scenariuszy, w których łączenie Excela i PowerPointa jest niezbędne: scalanie korespondencji, wypełnianie tabel danych, generowanie jednego slajdu na rekord danych (generowanie slajdów wsadowych), tworzenie materiałów szkoleniowych oraz konsolidowanie wielu raportów Excel w jednej prezentacji, by wymienić tylko niektóre.

Do tej pory implementacja takich funkcji przy użyciu API Aspose.Slides wymagała korzystania z rozwiązań zewnętrznych, takich jak Aspose.Cells. Choć narzędzia te są solidne, mogą być zbyt skomplikowane i kosztowne dla użytkowników, którzy potrzebują jedynie podstawowej funkcjonalności integracji danych.

## **Jak to działa**

Aby ułatwić i usprawnić pracę z danymi Excel, Aspose.Slides wprowadziło nowe klasy do odczytywania danych z zeszytów Excel i importowania zawartości do prezentacji. Ta funkcja otwiera potężne nowe możliwości dla użytkowników API, którzy chcą wykorzystać Excel jako źródło danych w swoich przepływach pracy związanych z prezentacjami.

Nowa funkcjonalność jest przeznaczona do ogólnego dostępu do danych i nie jest zintegrowana z modelem obiektowym dokumentu prezentacji (DOM). Oznacza to, że *nie umożliwia edytowania ani zapisywania plików Excel* — jej jedynym celem jest otwieranie zeszytów i nawigowanie po ich zawartości w celu pobrania danych komórek.

U podstaw tej funkcji leży nowa klasa [ExcelDataWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/exceldataworkbook/). Klasa ta pozwala wczytać zeszyt Excel z lokalnego pliku lub strumienia. Po wczytaniu udostępnia kilka przeciążeń metody [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/exceldataworkbook/#getCell), które można używać do pobierania konkretnych komórek według ich pozycji (np. indeksy wiersza i kolumny lub nazwane zakresy).

Każde wywołanie [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/exceldataworkbook/#getCell) zwraca obiekt [ExcelDataCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/exceldatacell/). Obiekt ten reprezentuje pojedynczą komórkę w zeszycie Excel i daje dostęp do jej wartości w prosty i intuicyjny sposób.

#### **Importowanie wykresu Excel**

Kolejnym krokiem w rozszerzaniu funkcjonalności jest klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/excelworkbookimporter/). Ta klasa narzędziowa zapewnia możliwość importowania zawartości z zeszytu Excel do prezentacji. Zawiera kilka przeciążeń metody [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), które pomagają pobrać wybrany wykres z określonego zeszytu Excel i dodać go na koniec podanej kolekcji kształtów w określonych współrzędnych.

#### **Importowanie tabeli Excel**

Klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/excelworkbookimporter/) zawiera również kilka przeciążeń metody [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/pl/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Metody te umożliwiają import określonego zakresu komórek z określonego arkusza i dodanie go jako tabeli na koniec podanej kolekcji kształtów w określonych współrzędnych.

Krótko mówiąc, jest to lekki i prosty interfejs API do odczytywania danych Excel — dokładnie to, czego potrzebuje wielu programistów, bez obciążenia pełną biblioteką przetwarzania arkuszy kalkulacyjnych.

## **Zacznijmy kodować**

### **Przykład scenariusza scalania korespondencji**

Aby rozpocząć, potrzebujemy dwóch rzeczy:

1. Zeszyt Excel zawierający dane

![Przykład danych Excel](example1_image0.png)

2. Szablon prezentacji PowerPoint

![Przykład szablonu PowerPoint](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Załaduj skoroszyt Excel z danymi pracowników.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Załaduj szablon prezentacji.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Przejdź przez wiersze Excela (z pominięciem nagłówka w wierszu 0).
    for row_index in range(1, 5):

        # Utwórz prezentację dla każdego rekordu pracownika.
        employee_presentation = Presentation()

        try:
            # Usuń domyślny pusty slajd.
            employee_presentation.getSlides().removeAt(0)

            # Sklonuj slajd szablonu do prezentacji.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Pobierz akapity z docelowego kształtu (zakłada się, że używany jest indeks kształtu 1).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Zastąp znaczniki danymi z Excela.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Zapisz spersonalizowaną prezentację do osobnego pliku.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Wynik](example1_image2.png)

### **Przykład tabeli Excel**

W drugim przykładzie po prostu kopiujemy dane z tabeli Excel i wyświetlamy je na slajdzie PowerPoint w bardziej atrakcyjnej wizualnie formie.

W tym przykładzie ponownie używamy tego samego zeszytu Excel z pierwszego przykładu, który zawiera prostą tabelę pracowników.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Załaduj skoroszyt Excel zawierający dane pracowników.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Utwórz prezentację PowerPoint.
presentation = Presentation()

try:
    # Dodaj kształt tabeli do pierwszego slajdu.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Wypełnij tabelę PowerPoint danymi ze skoroszytu Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Zapisz powstałą prezentację do pliku.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Wynik](example2_image0.png)

### **Przykład importowania wykresu Excel**

W tym przykładzie importujemy wykres z pierwszego arkusza zeszytu Excel użytego w poprzednim przykładzie. Wykres będzie połączony z zewnętrznym zeszytem w powstałej prezentacji.

Najpierw dodajemy wykres kołowy do zeszytu Excel na podstawie tabeli pracowników.

![Przykład wykresu Excel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Utwórz prezentację PowerPoint.
presentation = Presentation()
try:
    # Pobierz kolekcję kształtów pierwszego slajdu.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Zaimportuj wykres o nazwie "Chart 1" z pierwszego arkusza skoroszytu i dodaj go do kolekcji kształtów.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Zapisz powstałą prezentację do pliku.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Wynik](example3_image1.png)

### **Przykład importowania wszystkich wykresów Excel**

Wyobraźmy sobie, że masz zeszyt Excel pełen wykresów i musisz je wszystkie zaimportować do prezentacji. Każdy wykres powinien być umieszczony na nowym slajdzie.

Poniższy kod iteruje przez wszystkie arkusze w źródłowym pliku Excel, wyodrębnia wykresy z każdego arkusza i dodaje każdy wykres do osobnego slajdu używając układu pustego slajdu. W powstałej prezentacji zostaną osadzone jedynie dane wykresu, nie cały zeszyt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Załaduj skoroszyt Excel zawierający dane pracowników.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Utwórz prezentację PowerPoint.
presentation = Presentation()
try:
    # Pobierz układ pustego slajdu.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Usuń domyślny slajd, aby wynik zawierał po jednym slajdzie na wykres.
    presentation.getSlides().removeAt(0)

    # Pobierz nazwy wszystkich arkuszy znajdujących się w skoroszycie Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Pobierz mapę, która mapuje indeksy wykresów na nazwy wykresów dla arkusza.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Dodaj slajd używając układu pustego.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Zaimportuj wskazany wykres ze skoroszytu Excel do kolekcji kształtów slajdu.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Zapisz powstałą prezentację do pliku.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Przykład importowania tabeli Excel**

W tym przykładzie importujemy sformatowaną tabelę z arkusza Excel bezpośrednio do prezentacji PowerPoint.

Źródłowy arkusz Excel zawiera sformatowaną tabelę z danymi pracowników:

![Przykład tabeli Excel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Utwórz prezentację PowerPoint.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd i jego kolekcję kształtów.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Zaimportuj tabelę z pierwszego arkusza skoroszytu i dodaj ją do kolekcji kształtów.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Zapisz powstałą prezentację do pliku.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Wynik](example4_image1.png)

## **Podsumowanie**

Ten mechanizm, dostępny bezpośrednio w Aspose.Slides, łączy pracę z danymi Excel i prezentacjami w jednym miejscu. Pozwala tworzyć slajdy z wykresami wizualnymi oraz danymi przedstawionymi jako tabele Excel — bez dodatkowych bibliotek czy skomplikowanych integracji.