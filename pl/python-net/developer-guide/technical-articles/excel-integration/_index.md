---
title: Integracja danych Excel w prezentacjach PowerPoint
linktitle: Integracja Excel
type: docs
weight: 330
url: /pl/python-net/excel-integration/
keywords:
- Excel
- skoroszyt
- odczyt Excel
- integracja Excel
- źródło danych
- scalanie poczty
- import tabeli
- Excel do PowerPoint
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odczytuj dane z skoroszytów Excel w Aspose.Slides przy użyciu interfejsu API ExcelDataWorkbook. Ładuj arkusze i komórki oraz wykorzystuj ich wartości do generowania prezentacji PowerPoint opartych na danych."
---
## **Wprowadzenie**

Prezentacje PowerPoint to potężny sposób na wyświetlanie i przekazywanie informacji. Często są używane w połączeniu z skoroszytami Excel, gdzie Excel stanowi doskonałe źródło danych strukturalnych, a PowerPoint wyróżnia się wizualizacją tych danych dla odbiorców.

Istnieje wiele praktycznych scenariuszy, w których łączenie Excela i PowerPointa jest niezbędne: scalanie poczty (mail merge), wypełnianie tabel danych, generowanie jednego slajdu na rekord danych (batch slide generation), tworzenie materiałów szkoleniowych oraz konsolidacja wielu raportów Excel w jedną prezentację, by wymienić tylko niektóre.

Do tej pory implementacja takich funkcji przy użyciu API Aspose.Slides wymagała korzystania z rozwiązań firm trzecich, takich jak Aspose.Cells. Choć te narzędzia są solidne, mogą być zbyt skomplikowane i kosztowne dla użytkowników, którzy potrzebują jedynie podstawowej funkcjonalności integracji danych.

## **Jak to działa**

Aby ułatwić i usprawnić pracę z danymi Excel, Aspose.Slides wprowadziło nowe klasy służące do odczytu danych z skoroszytów Excel oraz importowania zawartości do prezentacji. Ta funkcja otwiera potężne nowe możliwości dla użytkowników API, którzy chcą wykorzystać Excel jako źródło danych w swoich przepływach pracy z prezentacjami.

Nowa funkcjonalność jest przeznaczona do ogólnego dostępu do danych i nie jest zintegrowana z modelem obiektowym dokumentu prezentacji (DOM). Oznacza to, że *nie pozwala na edytowanie ani zapisywanie plików Excel* — jej jedynym celem jest otwieranie skoroszytów i nawigowanie po ich zawartości w celu pobrania danych z komórek.

U podstaw tej funkcji znajduje się nowa klasa [ExcelDataWorkbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.excel/exceldataworkbook/). Ta klasa umożliwia załadowanie skoroszytu Excel z pliku lokalnego lub strumienia. Po załadowaniu udostępnia kilka przeciążeń metody [get_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides.excel/exceldataworkbook/get_cell/), które można używać do pobierania określonych komórek według ich pozycji (np. indeksy wiersza i kolumny lub nazwane zakresy).

Każde wywołanie [get_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) zwraca instancję klasy [ExcelDataCell](https://reference.aspose.com/slides/pl/python-net/aspose.slides.excel/exceldatacell/). Obiekt ten reprezentuje pojedynczą komórkę w skoroszycie Excel i daje dostęp do jej wartości w prosty i intuicyjny sposób.

#### **Import wykresu Excel**

Kolejnym krokiem rozszerzania funkcjonalności jest klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/python-net/aspose.slides.importing/excelworkbookimporter/). Ta klasa narzędziowa zapewnia funkcję importu zawartości z skoroszytu Excel do prezentacji. Zawiera kilka przeciążeń metody [add_chart_from_workbook](https://reference.aspose.com/slides/pl/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/), które pomagają pobrać wybrany wykres z określonego skoroszytu Excel i dodać go na koniec podanej kolekcji kształtów w zadanych współrzędnych.

Krótko mówiąc, jest to lekki i prosty interfejs API do odczytu danych Excel — dokładnie to, czego potrzebuje wielu programistów, bez obciążenia pełnoprawną biblioteką przetwarzania arkuszy kalkulacyjnych.

## **Zacznijmy kodować**

### **Przykład scenariusza scalania poczty (Mail Merge)**

W poniższym przykładzie zaimplementujemy prosty scenariusz mail merge, generując wiele prezentacji na podstawie danych przechowywanych w skoroszycie Excel.

Aby rozpocząć, potrzebujemy dwóch rzeczy:
1. Skoroszyt Excel zawierający dane

![Przykład danych Excel](example1_image0.png)

2. Szablon prezentacji PowerPoint

![Przykład szablonu PowerPoint](example1_image1.png)

```py
import aspose.slides as slides

# Wczytaj skoroszyt Excel z danymi pracowników.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Wczytaj szablon prezentacji.
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # Iteruj przez wiersze Excela (z pominięciem nagłówka w wierszu 0).
    for row_index in range(1, 5):

        # Utwórz nową prezentację dla każdego rekordu pracownika.
        with slides.Presentation() as employee_presentation:

            # Usuń domyślny pusty slajd.
            employee_presentation.slides.remove_at(0)

            # Sklonuj slajd szablonu do nowej prezentacji.
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # Pobierz akapity z docelowego kształtu (zakłada się użycie indeksu kształtu 1).
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # Zastąp symbole zastępcze danymi z Excela.
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # Zapisz spersonalizowaną prezentację do oddzielnego pliku.
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![Wynik](example1_image2.png)

### **Przykład tabeli Excel**

W drugim przykładzie po prostu kopiujemy dane z tabeli Excel i wyświetlamy je na slajdzie PowerPoint w bardziej atrakcyjnej wizualnie formie.

W tym przykładzie ponownie używamy tego samego skoroszytu Excel z pierwszego przykładu, który zawiera prostą tabelę pracowników.

```py
# Wczytaj skoroszyt Excel zawierający dane pracowników.
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Utwórz nową prezentację PowerPoint.
with slides.Presentation() as presentation:

    # Dodaj kształt tabeli do pierwszego slajdu.
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # Wypełnij tabelę PowerPoint danymi ze skoroszytu Excel.
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # Zapisz powstałą prezentację do pliku.
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![Wynik](example2_image0.png)

### **Przykład importu wykresu Excel**

W tym przykładzie importujemy wykres z pierwszego arkusza skoroszytu Excel używanego w poprzednim przykładzie. Wykres będzie powiązany z zewnętrznym skoroszytem w powstałej prezentacji.

Najpierw dodajemy wykres kołowy do skoroszytu Excel na podstawie tabeli pracowników.

![Przykład wykresu Excel](example3_image0.png)

```py
# Utwórz nową prezentację PowerPoint.
with slides.Presentation() as presentation:
    # Pobierz kolekcję kształtów pierwszego slajdu.
    shapes = presentation.slides[0].shapes

    # Zaimportuj wykres o nazwie "Chart 1" z pierwszego arkusza skoroszytu i dodaj go do kolekcji kształtów.
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Zapisz powstałą prezentację do pliku.
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![Wynik](example3_image1.png)

### **Przykład importu wszystkich wykresów Excel**

Wyobraźmy sobie, że masz skoroszyt Excel pełen wykresów i musisz je wszystkie zaimportować do prezentacji. Każdy wykres powinien zostać umieszczony na nowym slajdzie.

Poniższy kod iteruje po wszystkich arkuszach w źródłowym pliku Excel, wyodrębnia wykresy z każdego arkusza i dodaje każdy wykres do osobnego slajdu używając pustego układu slajdu. W powstałej prezentacji będą osadzone tylko dane wykresu, a nie cały skoroszyt.

```py
# Wczytaj skoroszyt Excel zawierający dane pracowników.
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Utwórz nową prezentację PowerPoint.
with slides.Presentation() as presentation:
    # Pobierz układ pustego slajdu.
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Pobierz nazwy wszystkich arkuszy znajdujących się w skoroszycie Excel.
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # Pobierz słownik mapujący indeksy wykresów na ich nazwy dla arkusza.
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # Dodaj nowy slajd używając układu pustego.
            slide = presentation.slides.add_empty_slide(blank_layout)

            # Zaimportuj określony wykres ze skoroszytu Excel do kolekcji kształtów slajdu.
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # Zapisz powstałą prezentację do pliku.
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **Podsumowanie**

Ten mechanizm, dostępny bezpośrednio w Aspose.Slides, łączy pracę z danymi Excel i prezentacjami w jednym miejscu. Umożliwia tworzenie slajdów z wykresami wizualnymi oraz danymi przedstawionymi jako tabele Excel — bez dodatkowych bibliotek czy skomplikowanych integracji.