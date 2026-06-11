---
title: Integracja danych Excel w prezentacjach PowerPoint
linktitle: Integracja Excel
type: docs
weight: 330
url: /pl/java/excel-integration/
keywords:
- Excel
- zeszyt
- odczyt Excel
- integracja Excel
- źródło danych
- łączenie korespondencji
- import tabeli
- Excel do PowerPoint
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Odczytuj dane z zeszytów Excel w Aspose.Slides przy użyciu interfejsu API ExcelDataWorkbook. Ładuj arkusze i komórki oraz wykorzystuj wartości do generowania prezentacji PowerPoint opartych na danych."
---
## **Wprowadzenie**

Prezentacje PowerPoint to potężny sposób na wyświetlanie i przekazywanie informacji. Często są używane w połączeniu z zeszytami Excel, gdzie Excel służy jako doskonałe źródło danych strukturalnych, a PowerPoint doskonale wizualizuje te dane przed odbiorcą.

Istnieje wiele praktycznych scenariuszy, w których łączenie Excela i PowerPointa jest niezbędne: scalanie poczty, wypełnianie tabel danych, generowanie jednego slajdu na rekord danych (generowanie wsadowe slajdów), tworzenie materiałów szkoleniowych oraz konsolidacja wielu raportów Excel w jednej prezentacji, by wymienić tylko niektóre.

Do tej pory wdrożenie takich funkcji przy użyciu API Aspose.Slides wymagało korzystania z rozwiązań firm trzecich, takich jak Aspose.Cells. Choć te narzędzia są solidne, mogą być zbyt skomplikowane i kosztowne dla użytkowników, którzy potrzebują jedynie podstawowej funkcjonalności integracji danych.

## **Jak to działa**

Aby praca z danymi z Excela była łatwiejsza i bardziej zoptymalizowana, Aspose.Slides wprowadziło nowe klasy do odczytu danych z zeszytów Excel oraz importowania ich treści do prezentacji. Ta funkcja otwiera nowe, potężne możliwości dla użytkowników API, którzy chcą wykorzystać Excel jako źródło danych w swoich przepływach pracy z prezentacjami.

Nowa funkcjonalność jest przeznaczona do ogólnego dostępu do danych i nie jest zintegrowana z Modelem Obiektowym Dokumentu Prezentacji (DOM). Oznacza to, że *nie pozwala na edycję ani zapisywanie plików Excel* — jej jedynym celem jest otwieranie zeszytów i nawigowanie po ich zawartości w celu pobrania danych z komórek.

W sercu tej funkcji znajduje się nowa klasa [ExcelDataWorkbook](https://reference.aspose.com/slides/pl/java/com.aspose.slides/exceldataworkbook/). Ta klasa umożliwia załadowanie zeszytu Excel z lokalnego pliku lub strumienia. Po załadowaniu udostępnia kilka przeciążeń metody [getCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-), którą można użyć do pobrania konkretnych komórek według ich pozycji (np. indeksów wiersza i kolumny lub nazwanych zakresów).

Każde wywołanie [getCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) zwraca instancję klasy [ExcelDataCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/exceldatacell/). Obiekt ten reprezentuje pojedynczą komórkę w zeszycie Excel i daje dostęp do jej wartości w prosty i intuicyjny sposób.

#### **Import wykresu z Excela**

Kolejnym krokiem w rozszerzaniu funkcjonalności jest klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/excelworkbookimporter/). Ta klasa pomocnicza zapewnia funkcjonalność importowania zawartości z zeszytu Excel do prezentacji. Zawiera kilka przeciążeń metody [addChartFromWorkbook](https://reference.aspose.com/slides/pl/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-), która pomaga pobrać wybrany wykres z określonego zeszytu Excel i dodać go na koniec podanej kolekcji kształtów w określonych współrzędnych.

Krótko mówiąc, jest to lekka i prosta w użyciu API do odczytu danych z Excela — dokładnie to, czego potrzebuje wielu programistów, bez obciążenia całej biblioteki przetwarzania arkuszy kalkulacyjnych.

## **Zacznijmy kodować**

### **Przykład scenariusza scalania poczty**

W poniższym przykładzie zaimplementujemy prosty scenariusz Mail Merge, generując wiele prezentacji na podstawie danych przechowywanych w zeszycie Excel.

Aby rozpocząć, potrzebujemy dwóch rzeczy:
1. Zeszytu Excel zawierającego dane

![Przykład danych Excel](example1_image0.png)

2. Szablonu prezentacji PowerPoint

![Przykład szablonu PowerPoint](example1_image1.png)

```java
// Załaduj zeszyt Excel z danymi pracowników.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Załaduj szablon prezentacji.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iteruj po wierszach Excela (z pominięciem nagłówka w wierszu 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Utwórz nową prezentację dla każdego rekordu pracownika.
        Presentation employeePresentation = new Presentation();

        try {
            // Usuń domyślny pusty slajd.
            employeePresentation.getSlides().removeAt(0);

            // Sklonuj slajd szablonu do nowej prezentacji.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Pobierz akapity z docelowego kształtu (zakłada, że używany jest indeks kształtu 1).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Zastąp symbole zastępcze danymi z Excela.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Zapisz spersonalizowaną prezentację do osobnego pliku.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Wynik](example1_image2.png)

### **Przykład tabeli Excel**

W drugim przykładzie po prostu kopiujemy dane z tabeli Excel i wyświetlamy je na slajdzie PowerPoint w bardziej atrakcyjnej wizualnie formie.

W tym przykładzie ponownie wykorzystujemy ten sam zeszyt Excel z pierwszego przykładu, który zawiera prostą tabelę pracowników.

```java
// Załaduj zeszyt Excel zawierający dane pracowników.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Utwórz nową prezentację PowerPoint.
Presentation presentation = new Presentation();

try {
    // Dodaj kształt tabeli do pierwszego slajdu.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Wypełnij tabelę PowerPoint danymi z zeszytu Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Zapisz powstałą prezentację do pliku.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Wynik](example2_image0.png)

### **Przykład importu wykresu z Excela**

W tym przykładzie importujemy wykres z pierwszego arkusza zeszytu Excel użytego w poprzednim przykładzie. Wykres będzie powiązany z zewnętrznym zeszytem w wynikowej prezentacji.

Najpierw dodajemy wykres kołowy do zeszytu Excel na podstawie tabeli pracowników.

![Przykład wykresu Excel](example3_image0.png)

```java
// Utwórz nową prezentację PowerPoint.
Presentation presentation = new Presentation();
try {
    // Pobierz kolekcję kształtów pierwszego slajdu.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importuj wykres o nazwie "Chart 1" z pierwszego arkusza zeszytu i dodaj go do kolekcji kształtów.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Zapisz powstałą prezentację do pliku.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Wynik](example3_image1.png)

### **Przykład importu wszystkich wykresów Excel**

Załóżmy, że masz zeszyt Excel pełen wykresów i potrzebujesz zaimportować je wszystkie do prezentacji. Każdy wykres powinien być umieszczony na nowym slajdzie.

Poniższy kod iteruje po wszystkich arkuszach w źródłowym pliku Excel, wyodrębnia wykresy z każdego arkusza i dodaje każdy wykres do osobnego slajdu przy użyciu układu slajdu pustego. W wynikowej prezentacji osadzone będą tylko dane wykresu, a nie cały zeszyt.

```java
// Załaduj zeszyt Excel zawierający dane pracowników.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Utwórz nową prezentację PowerPoint.
Presentation presentation = new Presentation();
try {
    // Pobierz układ pustego slajdu.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Pobierz nazwy wszystkich arkuszy zawartych w zeszycie Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Pobierz mapę, która mapuje indeksy wykresów na nazwy wykresów dla arkusza.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Dodaj nowy slajd przy użyciu pustego układu.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importuj określony wykres z zeszytu Excel do kolekcji kształtów slajdu.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Zapisz powstałą prezentację do pliku.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Podsumowanie**

Ten mechanizm, dostępny bezpośrednio w Aspose.Slides, łączy pracę z danymi Excel i prezentacjami w jednym miejscu. Umożliwia tworzenie slajdów z wizualnymi wykresami i danymi prezentowanymi jako tabele Excel — bez dodatkowych bibliotek czy skomplikowanych integracji.