---
title: Zintegruj dane Excel w prezentacjach PowerPoint
linktitle: Integracja Excela
type: docs
weight: 330
url: /pl/net/excel-integration/
keywords:
- Excel
- zeszyt
- odczyt Excel
- integracja Excela
- źródło danych
- korespondencja seryjna
- import tabeli
- Excel w PowerPoint
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odczytuj dane z zeszytów Excel w Aspose.Slides przy użyciu API ExcelDataWorkbook. Ładuj arkusze i komórki oraz używaj ich wartości do generowania prezentacji PowerPoint opartych na danych."
---
## **Wprowadzenie**

Prezentacje PowerPoint są potężnym sposobem na wyświetlanie i komunikowanie informacji. Często używa się ich w połączeniu z zeszytami Excel, gdzie Excel jest doskonałym źródłem danych strukturalnych, a PowerPoint wyróżnia się wizualizacją tych danych dla odbiorców.

Istnieje wiele praktycznych scenariuszy, w których łączenie Excela i PowerPointa jest niezbędne: korespondencja seryjna, wypełnianie tabel danych, generowanie jednego slajdu na rekord danych (generowanie slajdów w partiach), tworzenie materiałów szkoleniowych oraz konsolidacja wielu raportów Excel w jednej prezentacji, by wymienić tylko niektóre.

Do tej pory wdrażanie takich funkcji przy użyciu API Aspose.Slides wymagało korzystania z rozwiązań innych firm, takich jak Aspose.Cells. Choć narzędzia te są solidne, mogą być zbyt skomplikowane i kosztowne dla użytkowników, którzy potrzebują tylko podstawowej funkcjonalności integracji danych.

## **Jak to działa**

Aby ułatwić i usprawnić pracę z danymi Excel, Aspose.Slides wprowadziło nowe klasy do odczytywania danych z zeszytów Excel i importowania treści do prezentacji. Funkcja ta otwiera potężne nowe możliwości dla użytkowników API, którzy chcą wykorzystać Excel jako źródło danych w swoich procesach tworzenia prezentacji.

Nowa funkcjonalność jest przeznaczona do ogólnego dostępu do danych i nie jest zintegrowana z Modelem Obiektowym Dokumentu Prezentacji (DOM). Oznacza to, że *nie pozwala na edytowanie ani zapisywanie plików Excel* — jej jedynym celem jest otwieranie zeszytów i nawigowanie po ich zawartości w celu pobrania danych komórek.

U podstaw tej funkcji znajduje się nowa klasa [ExcelDataWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.excel/exceldataworkbook/). Klasa ta umożliwia wczytanie zeszytu Excel z lokalnego pliku lub strumienia. Po wczytaniu zapewnia kilka przeciążeń metody [GetCell](https://reference.aspose.com/slides/pl/net/aspose.slides.excel/exceldataworkbook/getcell/), które można wykorzystać do pobierania konkretnych komórek według ich pozycji (np. indeksów wiersza i kolumny lub nazwanych zakresów).

Każde wywołanie [GetCell](https://reference.aspose.com/slides/pl/net/aspose.slides.excel/exceldataworkbook/getcell/) zwraca instancję klasy [ExcelDataCell](https://reference.aspose.com/slides/pl/net/aspose.slides.excel/exceldatacell/). Obiekt ten reprezentuje pojedynczą komórkę w zeszycie Excel i zapewnia dostęp do jej wartości w prosty i intuicyjny sposób.

#### **Importowanie wykresu Excel**

Kolejnym krokiem w rozszerzaniu funkcjonalności jest klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/net/aspose.slides.import/excelworkbookimporter/). Ta klasa narzędziowa zapewnia funkcję importowania treści z zeszytu Excel do prezentacji. Zawiera kilka przeciążeń metody [AddChartFromWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), które pomagają pobrać wybrany wykres z określonego zeszytu Excel i dodać go na koniec podanej kolekcji kształtów w określonych współrzędnych.

Krótko mówiąc, jest to lekki i prosty interfejs API do odczytu danych Excel — dokładnie to, czego potrzebuje wielu programistów, bez dodatkowego obciążenia wynikającego z użycia pełnej biblioteki przetwarzania arkuszy kalkulacyjnych.

## **Zacznijmy kodować**

### **Przykład scenariusza korespondencji seryjnej**

W poniższym przykładzie zaimplementujemy prosty scenariusz korespondencji seryjnej, generując wiele prezentacji na podstawie danych przechowywanych w zeszycie Excel.

Aby rozpocząć, potrzebujemy dwóch rzeczy:
1. Zeszyt Excel zawierający dane

![Excel data example](example1_image0.png)

2. Szablon prezentacji PowerPoint

![PowerPoint template example](example1_image1.png)

```csharp
// Wczytaj zeszyt Excel z danymi pracowników.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Wczytaj szablon prezentacji.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Iteruj przez wiersze Excela (z wykluczeniem nagłówka w wierszu 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Utwórz nową prezentację dla każdego rekordu pracownika.
    using Presentation employeePresentation = new Presentation();

    // Usuń domyślny pusty slajd.
    employeePresentation.Slides.RemoveAt(0);

    // Sklonuj slajd szablonu do nowej prezentacji.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Pobierz akapity z docelowego kształtu (zakłada, że używany jest indeks kształtu 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Zastąp podstawki danymi z Excela.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Zapisz spersonalizowaną prezentację do osobnego pliku.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Wynik](example1_image2.png)

### **Przykład tabeli Excel**

W drugim przykładzie po prostu kopiujemy dane z tabeli Excel i wyświetlamy je na slajdzie PowerPoint w bardziej atrakcyjnej wizualnie formie.

W tym przykładzie ponownie używamy tego samego zeszytu Excel z pierwszego przykładu, który zawiera prostą tabelę pracowników.

```csharp
// Wczytaj zeszyt Excel zawierający dane pracowników.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Utwórz nową prezentację PowerPoint.
using Presentation presentation = new Presentation();

// Dodaj kształt tabeli do pierwszego slajdu.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Wypełnij tabelę PowerPoint danymi z zeszytu Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Zapisz powstałą prezentację do pliku.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Wynik](example2_image0.png)

### **Przykład importowania wykresu Excel**

W tym przykładzie importujemy wykres z pierwszego arkusza zeszytu Excel użytego w poprzednim przykładzie. Wykres będzie łączył się z zewnętrznym zeszytem w powstałej prezentacji.

Najpierw dodajemy wykres kołowy do zeszytu Excel na podstawie tabeli pracowników.

![Przykład wykresu Excel](example3_image0.png)

```csharp
// Utwórz nową prezentację PowerPoint.
using Presentation presentation = new Presentation();

// Pobierz kolekcję kształtów pierwszego slajdu.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Zaimportuj wykres o nazwie "Chart 1" z pierwszego arkusza zeszytu i dodaj go do kolekcji kształtów.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Zapisz powstałą prezentację do pliku.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Wynik](example3_image1.png)

### **Przykład importowania wszystkich wykresów Excel**

Wyobraźmy sobie, że masz zeszyt Excel pełen wykresów i musisz je wszystkie zaimportować do prezentacji. Każdy wykres powinien być umieszczony na nowym slajdzie.

Poniższy kod iteruje po wszystkich arkuszach w źródłowym pliku Excel, wyodrębnia wykresy z każdego arkusza i dodaje każdy wykres do osobnego slajdu za pomocą pustego układu slajdu. W powstałej prezentacji zostaną osadzone jedynie dane wykresu, a nie cały zeszyt.

```csharp
// Wczytaj zeszyt Excel zawierający dane pracowników.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Utwórz nową prezentację PowerPoint.
using Presentation presentation = new Presentation();

// Pobierz układ pustego slajdu.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Pobierz nazwy wszystkich arkuszy zawartych w zeszycie Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Pobierz słownik mapujący indeksy wykresów na ich nazwy dla arkusza.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Dodaj nowy slajd używając układu pustego.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Zaimportuj określony wykres z zeszytu Excel do kolekcji kształtów slajdu.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Zapisz powstałą prezentację do pliku.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Podsumowanie**

Ten mechanizm, dostępny bezpośrednio w Aspose.Slides, łączy pracę z danymi Excel i prezentacjami w jednym miejscu. Umożliwia tworzenie slajdów z wykresami wizualnymi oraz danymi przedstawionymi jako tabele Excel — bez dodatkowych bibliotek czy skomplikowanych integracji.