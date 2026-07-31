---
title: Integracja danych Excel w prezentacjach PowerPoint
linktitle: Integracja Excel
type: docs
weight: 330
url: /pl/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
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
- .NET
- C#
- Aspose.Slides
description: "Odczytuj dane z skoroszytów Excel w Aspose.Slides przy użyciu API ExcelDataWorkbook. Ładuj arkusze i komórki oraz wykorzystuj ich wartości do generowania prezentacji PowerPoint opartych na danych."
---
## **Wprowadzenie**

Prezentacje PowerPoint to potężny sposób wyświetlania i przekazywania informacji. Często są używane razem z skoroszytami Excel, gdzie Excel stanowi doskonałe źródło danych strukturalnych, a PowerPoint wyróżnia się wizualizacją tych danych dla odbiorców.

Istnieje wiele praktycznych scenariuszy, w których połączenie Excela i PowerPointa jest niezbędne: scalanie korespondencji, wypełnianie tabel danych, generowanie jednego slajdu na rekord danych (generowanie slajdów wsadowych), tworzenie materiałów szkoleniowych oraz konsolidacja wielu raportów Excel w jedną prezentację, aby wymienić tylko niektóre.

Do tej pory wprowadzanie takich funkcji przy użyciu API Aspose.Slides wymagało polegania na rozwiązaniach firm trzecich, takich jak Aspose.Cells. Chociaż te narzędzia są solidne, mogą być zbyt skomplikowane i kosztowne dla użytkowników, którzy potrzebują tylko podstawowej funkcjonalności integracji danych.

## **Jak to działa**

Aby ułatwić i usprawnić pracę z danymi Excel, Aspose.Slides wprowadziło nowe klasy do odczytywania danych ze skoroszytów Excel i importowania treści do prezentacji. Ta funkcja otwiera potężne nowe możliwości dla użytkowników API, którzy chcą wykorzystać Excel jako źródło danych w swoich przepływach pracy związanych z prezentacjami.

Nowa funkcjonalność została zaprojektowana do ogólnego dostępu do danych i nie jest zintegrowana z Modelem Obiektów Dokumentu Prezentacji (DOM). Oznacza to, że *nie umożliwia edytowania ani zapisywania plików Excel* — jej jedynym celem jest otwieranie skoroszytów i nawigowanie po ich zawartości w celu pobrania danych komórek.

W sercu tej funkcji znajduje się nowa klasa [ExcelDataWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.excel/exceldataworkbook/). Ta klasa pozwala wczytać skoroszyt Excel z lokalnego pliku lub strumienia. Po wczytaniu udostępnia kilka przeciążeń metody [GetCell](https://reference.aspose.com/slides/pl/net/aspose.slides.excel/exceldataworkbook/getcell/), które można wykorzystać do pobierania konkretnych komórek według ich pozycji (np. indeksy wiersza i kolumny lub nazwane zakresy).

Każde wywołanie [GetCell](https://reference.aspose.com/slides/pl/net/aspose.slides.excel/exceldataworkbook/getcell/) zwraca instancję klasy [ExcelDataCell](https://reference.aspose.com/slides/pl/net/aspose.slides.excel/exceldatacell/). Ten obiekt reprezentuje pojedynczą komórkę w skoroszycie Excel i zapewnia dostęp do jej wartości w prosty i intuicyjny sposób.

#### **Importowanie wykresu Excel**

Kolejnym krokiem w rozszerzaniu funkcjonalności jest klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/net/aspose.slides.import/excelworkbookimporter/). Ta klasa pomocnicza zapewnia funkcję importowania treści ze skoroszytu Excel do prezentacji. Zawiera kilka przeciążeń metody [AddChartFromWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), które pomagają pobrać wybrany wykres z określonego skoroszytu Excel i dodać go na koniec podanej kolekcji kształtów w określonych współrzędnych.

#### **Importowanie tabeli Excel**

Klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/net/aspose.slides.import/excelworkbookimporter/) zawiera także kilka przeciążeń metody [AddTableFromWorkbook](https://reference.aspose.com/slides/pl/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Metody te umożliwiają import określonego zakresu komórek z określonego arkusza i dodanie go jako tabeli na koniec podanej kolekcji kształtów w określonych współrzędnych.

Krótko mówiąc, jest to lekki i prosty interfejs API do odczytu danych Excel — dokładnie to, czego potrzebuje wielu programistów, bez obciążenia pełnoprawną biblioteką przetwarzania arkuszy kalkulacyjnych.

## **Zacznijmy kodować**

### **Przykład scenariusza scalania korespondencji**

W poniższym przykładzie zaimplementujemy prosty scenariusz scalania korespondencji, generując wiele prezentacji na podstawie danych przechowywanych w skoroszycie Excel.

Aby rozpocząć, potrzebujemy dwóch rzeczy:
1. Skoroszyt Excel zawierający dane

![Przykład danych Excel](example1_image0.png)

2. Szablon prezentacji PowerPoint

![Przykład szablonu PowerPoint](example1_image1.png)

```csharp
// Załaduj skoroszyt Excel z danymi pracowników.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Załaduj szablon prezentacji.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Iteruj po wierszach Excel (z wyjątkiem nagłówka w wierszu 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Utwórz nową prezentację dla każdego rekordu pracownika.
    using Presentation employeePresentation = new Presentation();

    // Usuń domyślny pusty slajd.
    employeePresentation.Slides.RemoveAt(0);

    // Sklonuj slajd szablonu do nowej prezentacji.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Pobierz akapity z docelowego kształtu (zakłada się, że używany jest indeks kształtu 1).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Zastąp symbole zastępcze danymi z Excela.
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

W tym przykładzie ponownie używamy tego samego skoroszytu Excel z pierwszego przykładu, który zawiera prostą tabelę pracowników.

```csharp
// Załaduj skoroszyt Excel zawierający dane pracowników.
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

// Wypełnij tabelę PowerPoint danymi ze skoroszytu Excel.
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

### **Przykład importu wykresu Excel**

W tym przykładzie importujemy wykres z pierwszego arkusza skoroszytu Excel użytego w poprzednim przykładzie. Wykres będzie odwoływał się do zewnętrznego skoroszytu w powstałej prezentacji.

Najpierw dodajemy wykres kołowy do skoroszytu Excel na podstawie tabeli pracowników.

![Przykład wykresu Excel](example3_image0.png)

```csharp
// Utwórz nową prezentację PowerPoint.
using Presentation presentation = new Presentation();

// Pobierz kolekcję kształtów pierwszego slajdu.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importuj wykres o nazwie "Chart 1" z pierwszego arkusza skoroszytu i dodaj go do kolekcji kształtów.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Zapisz powstałą prezentację do pliku.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Wynik](example3_image1.png)

### **Przykład importu wszystkich wykresów Excel**

Wyobraź sobie, że masz skoroszyt Excel pełen wykresów i potrzebujesz zaimportować je wszystkie do prezentacji. Każdy wykres powinien być umieszczony na nowym slajdzie.

Poniższy kod iteruje przez wszystkie arkusze w źródłowym pliku Excel, wyodrębnia wykresy z każdego arkusza i dodaje każdy wykres do osobnego slajdu przy użyciu pustego układu slajdu. W powstałej prezentacji zostaną osadzone tylko dane wykresu, a nie cały skoroszyt.

```csharp
// Załaduj skoroszyt Excel zawierający dane pracowników.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Utwórz nową prezentację PowerPoint.
using Presentation presentation = new Presentation();

// Pobierz pusty układ slajdu.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Pobierz nazwy wszystkich arkuszy zawartych w skoroszycie Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Pobierz słownik mapujący indeksy wykresów na nazwy wykresów dla arkusza.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Dodaj nowy slajd używając pustego układu.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importuj określony wykres ze skoroszytu Excel do kolekcji kształtów slajdu.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Zapisz powstałą prezentację do pliku.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Przykład importu tabeli Excel**

W tym przykładzie importujemy sformatowaną tabelę z arkusza Excel bezpośrednio do prezentacji PowerPoint.

Źródłowy arkusz Excel zawiera sformatowaną tabelę z danymi pracowników:

![Przykład tabeli Excel](example4_image0.png)

```csharp
// Utwórz nową prezentację PowerPoint.
using Presentation presentation = new Presentation();

// Pobierz kolekcję kształtów pierwszego slajdu.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importuj tabelę z pierwszego arkusza skoroszytu i dodaj ją do kolekcji kształtów.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Zapisz powstałą prezentację do pliku.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Wynik](example4_image1.png)

## **Podsumowanie**

Ten mechanizm, dostępny bezpośrednio w Aspose.Slides, łączy pracę z danymi Excel i prezentacjami w jednym miejscu. Umożliwia tworzenie slajdów z wykresami wizualnymi i danymi przedstawionymi jako tabele Excel — bez dodatkowych bibliotek ani skomplikowanych integracji.