---
title: Integracja danych Excel w prezentacjach PowerPoint
linktitle: Integracja Excela
type: docs
weight: 330
url: /pl/php-java/excel-integration/
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
- PHP
- Aspose.Slides
description: "Odczyt danych z zeszytów Excel przy użyciu Aspose.Slides dla PHP poprzez Java. Ładuj arkusze i komórki oraz używaj wartości do generowania prezentacji PowerPoint opartych na danych."
---
## **Wprowadzenie**

Prezentacje PowerPoint to potężny sposób na wyświetlanie i przekazywanie informacji. Często są używane w połączeniu z zeszytami Excel, gdzie Excel stanowi doskonałe źródło danych strukturalnych, a PowerPoint wyróżnia się wizualizacją tych danych dla odbiorców.

Istnieje wiele praktycznych scenariuszy, w których łączenie Excela i PowerPointa jest niezbędne: scalanie korespondencji, wypełnianie tabel danych, generowanie jednego slajdu na każdy rekord danych (generowanie slajdów wsadowych), tworzenie materiałów szkoleniowych oraz konsolidowanie wielu raportów Excel w jednej prezentacji, by wymienić tylko niektóre.

Do tej pory implementacja takich funkcji przy użyciu API Aspose.Slides wymagała polegania na rozwiązaniach firm trzecich, takich jak Aspose.Cells. Choć te narzędzia są solidne, mogą być zbyt skomplikowane i kosztowne dla użytkowników, którzy potrzebują jedynie podstawowej funkcjonalności integracji danych.

## **Jak to działa**

Aby ułatwić i usprawnić pracę z danymi Excel, Aspose.Slides wprowadziło nowe klasy do odczytywania danych z zeszytów Excel i importowania treści do prezentacji. Ta funkcja otwiera potężne nowe możliwości dla użytkowników API, którzy chcą wykorzystać Excel jako źródło danych w swoich przepływach pracy prezentacji.

Nowa funkcjonalność jest przeznaczona do uniwersalnego dostępu do danych i nie jest zintegrowana z Modelem Obiektu Dokumentu Prezentacji (DOM). Oznacza to, że *nie pozwala na edytowanie ani zapisywanie plików Excel* — jej jedynym celem jest otwieranie zeszytów i nawigowanie po ich zawartości w celu pobrania danych z komórek.

W rdzeniu tej funkcji znajduje się nowa klasa [ExcelDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/exceldataworkbook/). Klasa ta pozwala załadować zeszyt Excel z lokalnego pliku lub strumienia. Po załadowaniu udostępnia kilka przeciążeń metody [getCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/exceldataworkbook/#getCell), które można wykorzystać do pobierania konkretnych komórek według ich położenia (np. indeksów wiersza i kolumny lub nazwanych zakresów).

Każde wywołanie [getCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/exceldataworkbook/#getCell) zwraca instancję klasy [ExcelDataCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/exceldatacell/). Obiekt ten reprezentuje pojedynczą komórkę w zeszycie Excel i zapewnia dostęp do jej wartości w prosty i intuicyjny sposób.

#### **Importuj wykres Excel**

Kolejnym krokiem w rozszerzaniu funkcjonalności jest klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/excelworkbookimporter/). Ta klasa narzędziowa zapewnia możliwość importowania treści z zeszytu Excel do prezentacji. Zawiera kilka przeciążeń metody [addChartFromWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), które pomagają pobrać wybrany wykres z określonego zeszytu Excel i dodać go na koniec podanej kolekcji kształtów we wskazanych współrzędnych.

Krótko mówiąc, jest to lekki i prosty interfejs API do odczytu danych Excel — dokładnie to, czego potrzebuje wielu programistów, bez obciążenia pełną biblioteką przetwarzania arkuszy kalkulacyjnych.

## **Zacznijmy kodować**

### **Przykład scenariusza scalania korespondencji**

W poniższym przykładzie zaimplementujemy prosty scenariusz scalania korespondencji, generując wiele prezentacji na podstawie danych przechowywanych w zeszycie Excel.

Aby rozpocząć, potrzebujemy dwóch rzeczy:
1. Zeszyt Excel zawierający dane

![Przykład danych Excel](example1_image0.png)

2. Szablon prezentacji PowerPoint

![Przykład szablonu PowerPoint](example1_image1.png)

```php
// Wczytaj zeszyt Excel z danymi pracowników.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Wczytaj szablon prezentacji.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iteruj przez wiersze Excela (z pominięciem nagłówka w wierszu 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Utwórz nową prezentację dla każdego rekordu pracownika.
        $employeePresentation = new Presentation();

        try {
            // Usuń domyślny pusty slajd.
            $employeePresentation->getSlides()->removeAt(0);

            // Sklonuj slajd szablonu do nowej prezentacji.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Pobierz akapity z docelowego kształtu (zakłada, że używany jest indeks kształtu 1).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Zastąp symbole zastępcze danymi z Excela.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Zapisz spersonalizowaną prezentację do osobnego pliku.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Wynik](example1_image2.png)

### **Przykład tabeli Excel**

W drugim przykładzie po prostu kopiujemy dane z tabeli Excel i wyświetlamy je na slajdzie PowerPoint w bardziej atrakcyjnej wizualnie formie.

W tym przykładzie ponownie używamy tego samego zeszytu Excel z pierwszego przykładu, który zawiera prostą tabelę pracowników.

```php
// Wczytaj zeszyt Excel zawierający dane pracowników.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Utwórz nową prezentację PowerPoint.
$presentation = new Presentation();

try {
    // Dodaj kształt tabeli do pierwszego slajdu.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Wypełnij tabelę PowerPoint danymi z zeszytu Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Zapisz wynikową prezentację do pliku.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Wynik](example2_image0.png)

### **Przykład importu wykresu Excel**

W tym przykładzie importujemy wykres z pierwszego arkusza zeszytu Excel użytego w poprzednim przykładzie. Wykres będzie połączony z zewnętrznym zeszytem w wynikowej prezentacji.

Najpierw dodajemy wykres kołowy do zeszytu Excel na podstawie tabeli pracowników.

![Przykład wykresu Excel](example3_image0.png)

```php
// Utwórz nową prezentację PowerPoint.
$presentation = new Presentation();
try {
    // Pobierz kolekcję kształtów pierwszego slajdu.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Zaimportuj wykres o nazwie "Chart 1" z pierwszego arkusza zeszytu i dodaj go do kolekcji kształtów.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Zapisz wynikową prezentację do pliku.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Wynik](example3_image1.png)

### **Przykład importu wszystkich wykresów Excel**

Wyobraźmy sobie, że masz zeszyt Excel pełen wykresów i musisz je wszystkie zaimportować do prezentacji. Każdy wykres powinien być umieszczony na nowym slajdzie.

Poniższy kod iteruje przez wszystkie arkusze w źródłowym pliku Excel, wyodrębnia wykresy z każdego arkusza i dodaje każdy wykres do oddzielnego slajdu przy użyciu pustego układu slajdu. W wynikowej prezentacji zostaną osadzone tylko dane wykresu, a nie cały zeszyt.

```php
// Wczytaj zeszyt Excel zawierający dane pracowników.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Utwórz nową prezentację PowerPoint.
$presentation = new Presentation();
try {
    // Pobierz układ pustego slajdu.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Pobierz nazwy wszystkich arkuszy zawartych w zeszycie Excel.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Pobierz mapę, która mapuje indeksy wykresów na nazwy wykresów dla arkusza.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Dodaj nowy slajd używając układu pustego.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Zaimportuj określony wykres z zeszytu Excel do kolekcji kształtów slajdu.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Zapisz wynikową prezentację do pliku.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Podsumowanie**

Ten mechanizm, dostępny bezpośrednio w Aspose.Slides, łączy pracę z danymi Excel i prezentacjami w jednym miejscu. Umożliwia tworzenie slajdów z wykresami wizualnymi oraz danymi przedstawionymi jako tabele Excel — bez dodatkowych bibliotek czy skomplikowanych integracji.