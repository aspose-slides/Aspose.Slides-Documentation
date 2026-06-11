---
title: Integracja danych Excel w prezentacjach PowerPoint
linktitle: Integracja Excel
type: docs
weight: 330
url: /pl/nodejs-java/excel-integration/
keywords:
- Excel
- zeszyt
- odczyt Excel
- integracja Excel
- źródło danych
- scalanie korespondencji
- import tabeli
- Excel do PowerPoint
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Odczytuj dane z zeszytów Excel w JavaScript przy pomocy Aspose.Slides. Ładuj arkusze i komórki oraz używaj ich wartości do generowania prezentacji PowerPoint opartych na danych."
---
## **Wstęp**

Prezentacje PowerPoint są potężnym sposobem wyświetlania i przekazywania informacji. Często są używane w połączeniu z zeszytami Excel, gdzie Excel jest doskonałym źródłem danych strukturalnych, a PowerPoint wyróżnia się wizualizacją tych danych dla odbiorców.

Istnieje wiele praktycznych scenariuszy, w których łączenie Excela i PowerPointa jest niezbędne: scalanie korespondencji, wypełnianie tabel danych, generowanie jednego slajdu na rekord danych (tworzenie slajdów wsadowych), tworzenie materiałów szkoleniowych oraz konsolidowanie wielu raportów Excel w jednej prezentacji, by wymienić tylko niektóre.

Do tej pory implementacja takich funkcji przy użyciu API Aspose.Slides wymagała polegania na rozwiązaniach firm trzecich, takich jak Aspose.Cells. Choć te narzędzia są solidne, mogą być zbyt skomplikowane i kosztowne dla użytkowników, którzy potrzebują jedynie podstawowej funkcjonalności integracji danych.

## **Jak to działa**

Aby ułatwić i usprawnić pracę z danymi Excel, Aspose.Slides wprowadziło nowe klasy do odczytywania danych z zeszytów Excel i importowania treści do prezentacji. Ta funkcja otwiera nowe, potężne możliwości dla użytkowników API, którzy chcą wykorzystać Excel jako źródło danych w swoich przepływach pracy prezentacji.

Nowa funkcjonalność jest przeznaczona do ogólnego dostępu do danych i nie jest zintegrowana z Modelem Obiektowym Dokumentu Prezentacji (DOM). Oznacza to, że *nie umożliwia edycji ani zapisywania plików Excel* — jej jedynym celem jest otwieranie zeszytów i nawigowanie po ich zawartości w celu pobrania danych komórek.

W sercu tej funkcji znajduje się nowa klasa [ExcelDataWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/exceldataworkbook/). Klasa ta pozwala wczytać zeszyt Excel z lokalnego pliku lub strumienia. Po załadowaniu udostępnia kilka przeciążeń metody [getCell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/exceldataworkbook/#getCell), które można używać do pobierania konkretnych komórek według ich położenia (np. indeksów wiersza i kolumny lub nazwanych zakresów).

Każde wywołanie [getCell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/exceldataworkbook/#getCell) zwraca instancję klasy [ExcelDataCell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/exceldatacell/). Ten obiekt reprezentuje pojedynczą komórkę w zeszycie Excel i zapewnia dostęp do jej wartości w prosty i intuicyjny sposób.

#### **Import wykresu Excel**

Kolejnym krokiem w rozszerzaniu funkcjonalności jest klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/excelworkbookimporter/). Ta klasa narzędziowa zapewnia funkcję importowania treści z zeszytu Excel do prezentacji. Zawiera kilka przeciążeń metody [addChartFromWorkbook](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), które pomagają pobrać wybrany wykres z określonego zeszytu Excel i dodać go na koniec podanej kolekcji kształtów w określonych współrzędnych.

Krótko mówiąc, jest to lekki i prosty interfejs API do odczytu danych Excel — dokładnie to, czego potrzebuje wielu programistów, bez obciążenia wynikającego z pełnej biblioteki przetwarzania arkuszy kalkulacyjnych.

## **Zacznijmy kodować**

### **Przykład scenariusza scalania korespondencji**

W poniższym przykładzie zaimplementujemy prosty scenariusz scalania korespondencji, generując wiele prezentacji na podstawie danych przechowywanych w zeszycie Excel.

Aby rozpocząć, potrzebujemy dwóch rzeczy:
1. Zeszyt Excel zawierający dane

![Excel data example](example1_image0.png)

2. Szablon prezentacji PowerPoint

![PowerPoint template example](example1_image1.png)

```js
// Załaduj zeszyt Excel z danymi pracowników.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Załaduj szablon prezentacji.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Przejdź przez wiersze Excel (z wyłączeniem nagłówka w wierszu 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Utwórz nową prezentację dla każdego rekordu pracownika.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Usuń domyślny pusty slajd.
            employeePresentation.getSlides().removeAt(0);

            // Sklonuj slajd szablonu do nowej prezentacji.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Pobierz akapity z docelowego kształtu (zakłada, że używany jest indeks kształtu 1).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Zastąp symbole zastępcze danymi z Excela.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Zapisz spersonalizowaną prezentację do oddzielnego pliku.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
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

W tym przykładzie ponownie używamy tego samego zeszytu Excel z pierwszego przykładu, który zawiera prostą tabelę pracowników.

```js
// Załaduj zeszyt Excel zawierający dane pracowników.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Utwórz nową prezentację PowerPoint.
let presentation = new aspose.slides.Presentation();

try {
    // Dodaj kształt tabeli do pierwszego slajdu.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Wypełnij tabelę PowerPoint danymi z zeszytu Excel.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Zapisz powstałą prezentację do pliku.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Wynik](example2_image0.png)

### **Przykład importu wykresu Excel**

W tym przykładzie importujemy wykres z pierwszego arkusza zeszytu Excel użytego w poprzednim przykładzie. Wykres będzie powiązany z zewnętrznym zeszytem w wynikowej prezentacji.

Najpierw dodajemy wykres kołowy do zeszytu Excel na podstawie tabeli pracowników.

![Przykład wykresu Excel](example3_image0.png)

```js
// Utwórz nową prezentację PowerPoint.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz kolekcję kształtów pierwszego slajdu.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Zaimportuj wykres o nazwie "Chart 1" z pierwszego arkusza zeszytu i dodaj go do kolekcji kształtów.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Zapisz powstałą prezentację do pliku.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Wynik](example3_image1.png)

### **Przykład importu wszystkich wykresów Excel**

Wyobraźmy sobie, że masz zeszyt Excel pełen wykresów i musisz zaimportować je wszystkie do prezentacji. Każdy wykres powinien być umieszczony na nowym slajdzie.

Poniższy kod iteruje przez wszystkie arkusze w źródłowym pliku Excel, wyodrębnia wykresy z każdego arkusza i dodaje każdy wykres do oddzielnego slajdu przy użyciu pustego układu slajdu. W wynikowej prezentacji zostaną osadzone tylko dane wykresu, a nie cały zeszyt.

```js
// Załaduj zeszyt Excel zawierający dane pracowników.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Utwórz nową prezentację PowerPoint.
let presentation = new aspose.slides.Presentation();
try {
    // Pobierz pusty układ slajdu.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Pobierz nazwy wszystkich arkuszy zawartych w zeszycie Excel.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Pobierz mapę, która odwzorowuje indeksy wykresów na nazwy wykresów dla arkusza.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Dodaj nowy slajd używając pustego układu.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Zaimportuj określony wykres z zeszytu Excel do kolekcji kształtów slajdu.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Zapisz powstałą prezentację do pliku.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Podsumowanie**

Ten mechanizm, dostępny bezpośrednio w Aspose.Slides, łączy pracę z danymi Excel i prezentacjami w jednym miejscu. Pozwala tworzyć slajdy z wykresami wizualnymi i danymi prezentowanymi jako tabele Excel — bez dodatkowych bibliotek ani skomplikowanych integracji.