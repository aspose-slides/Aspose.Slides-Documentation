---
title: Integracja danych Excel w prezentacjach PowerPoint
linktitle: Integracja Excel
type: docs
weight: 330
url: /pl/cpp/excel-integration/
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
- C++
- Aspose.Slides
description: "Odczytuj dane z zeszytów Excel w Aspose.Slides za pomocą API ExcelDataWorkbook. Ładuj arkusze i komórki oraz używaj wartości do generowania prezentacji PowerPoint opartych na danych."
---
## **Wstęp**

Prezentacje PowerPoint to potężny sposób na wyświetlanie i przekazywanie informacji. Często są używane w połączeniu z zeszytami Excel, gdzie Excel stanowi doskonałe źródło danych strukturalnych, a PowerPoint świetnie wizualizuje te dane dla odbiorców.

Istnieje wiele praktycznych scenariuszy, w których łączenie Excela i PowerPointa jest niezbędne: scalanie korespondencji, wypełnianie tabel danymi, generowanie jednego slajdu na rekord danych (generowanie wsadowe slajdów), tworzenie materiałów szkoleniowych oraz konsolidacja wielu raportów Excel w jedną prezentację, aby wymienić tylko kilka.

## **Jak to działa**

Aby ułatwić i usprawnić pracę z danymi Excel, Aspose.Slides wprowadziło nowe klasy do odczytywania danych z zeszytów Excel i importowania ich do prezentacji. Ta funkcja otwiera potężne nowe możliwości dla użytkowników API, którzy chcą wykorzystać Excel jako źródło danych w swoich przepływach pracy z prezentacjami.

Nowa funkcjonalność jest przeznaczona do ogólnego dostępu do danych i nie jest zintegrowana z modelem obiektów dokumentu prezentacji (DOM). Oznacza to, że *nie pozwala na edytowanie ani zapisywanie plików Excel* — jej jedynym celem jest otwieranie zeszytów i nawigowanie po ich zawartości w celu pobrania danych komórek.

W rdzeniu tej funkcji znajduje się nowa klasa [ExcelDataWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.excel/exceldataworkbook/). Klasa ta pozwala wczytać zeszyt Excel z lokalnego pliku lub strumienia. Po załadowaniu udostępnia kilka przeciążeń metody [GetCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides.excel/exceldataworkbook/getcell/), które można wykorzystać do pobierania konkretnych komórek według ich położenia (np. indeksów wiersza i kolumny lub nazwanych zakresów).

Każde wywołanie [GetCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides.excel/exceldataworkbook/getcell/) zwraca instancję klasy [ExcelDataCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides.excel/exceldatacell/). Obiekt ten reprezentuje pojedynczą komórkę w zeszycie Excel i zapewnia dostęp do jej wartości w prosty i intuicyjny sposób.

#### **Import wykresu Excel**

Kolejnym krokiem w rozszerzaniu funkcjonalności jest klasa [ExcelWorkbookImporter](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/excelworkbookimporter/). Ta klasa narzędziowa zapewnia funkcję importowania zawartości z zeszytu Excel do prezentacji. Zawiera kilka przeciążeń metody [AddChartFromWorkbook](https://reference.aspose.com/slides/pl/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), które pomagają pobrać wybrany wykres z określonego zeszytu Excel i dodać go na koniec podanej kolekcji kształtów w określonych współrzędnych.

Krótko mówiąc, jest to lekka i prosta w użyciu API do odczytywania danych Excel — dokładnie to, czego potrzebuje wielu programistów, bez narzutu pełnej biblioteki przetwarzania arkuszy kalkulacyjnych.

## **Zacznijmy kodować**

### **Przykład scenariusza scalania korespondencji**

W poniższym przykładzie zaimplementujemy prosty scenariusz scalania korespondencji, generując wiele prezentacji na podstawie danych przechowywanych w zeszycie Excel.

Aby rozpocząć, potrzebujemy dwóch rzeczy:
1. Zeszyt Excel zawierający dane

![Przykład danych Excel](example1_image0.png)

2. Szablon prezentacji PowerPoint

![Przykład szablonu PowerPoint](example1_image1.png)

```cpp
// Załaduj skoroszyt Excela z danymi pracowników.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Załaduj szablon prezentacji.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Przejdź przez wiersze Excela (z wyłączeniem nagłówka w wierszu 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Utwórz nową prezentację dla każdego rekordu pracownika.
    auto employeePresentation = MakeObject<Presentation>();

    // Usuń domyślny pusty slajd.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Sklonuj slajd szablonu do nowej prezentacji.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Pobierz akapity z docelowego kształtu (zakłada się, że używany jest indeks kształtu 1).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Zastąp symbole zastępcze danymi z Excela.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Zapisz spersonalizowaną prezentację do osobnego pliku.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Wynik](example1_image2.png)

### **Przykład tabeli Excel**

W drugim przykładzie po prostu kopiujemy dane z tabeli Excel i wyświetlamy je na slajdzie PowerPoint w bardziej atrakcyjnej wizualnie formie.

W tym przykładzie ponownie używamy tego samego zeszytu Excel z pierwszego przykładu, który zawiera prostą tabelę pracowników.

```cpp
// Załaduj skoroszyt Excela zawierający dane pracowników.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Utwórz nową prezentację PowerPoint.
auto presentation = MakeObject<Presentation>();

// Dodaj kształt tabeli do pierwszego slajdu.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Wypełnij tabelę PowerPoint danymi z skoroszytu Excela.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Zapisz powstałą prezentację do pliku.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Wynik](example2_image0.png)

### **Przykład importu wykresu Excel**

W tym przykładzie importujemy wykres z pierwszego arkusza zeszytu Excel używanego w poprzednim przykładzie. Wykres będzie linkował do zewnętrznego zeszytu w powstałej prezentacji.

Najpierw dodajemy wykres kołowy do zeszytu Excel na podstawie tabeli pracowników.

![Przykład wykresu Excel](example3_image0.png)

```cpp
// Utwórz nową prezentację PowerPoint.
auto presentation = MakeObject<Presentation>();

// Pobierz kolekcję kształtów z pierwszego slajdu.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Importuj wykres o nazwie "Chart 1" z pierwszego arkusza skoroszytu i dodaj go do kolekcji kształtów.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Zapisz powstałą prezentację do pliku.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Wynik](example3_image1.png)

### **Przykład importu wszystkich wykresów Excel**

Wyobraźmy sobie, że masz zeszyt Excel pełen wykresów i musisz wszystkie zaimportować do prezentacji. Każdy wykres powinien znajdować się na nowym slajdzie.

Poniższy kod iteruje przez wszystkie arkusze w źródłowym pliku Excel, wyodrębnia wykresy z każdego arkusza i dodaje każdy wykres do osobnego slajdu, używając układu pustego slajdu. W powstałej prezentacji osadzone będą tylko dane wykresu, a nie cały zeszyt.

```cpp
// Załaduj skoroszyt Excela zawierający dane pracowników.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Utwórz nową prezentację PowerPoint.
auto presentation = MakeObject<Presentation>();

// Pobierz układ pustego slajdu.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Pobierz nazwy wszystkich arkuszy zawartych w skoroszycie Excela.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Pobierz słownik mapujący indeksy wykresów na nazwy wykresów dla arkusza.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Dodaj nowy slajd używając układu pustego.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Zaimportuj określony wykres ze skoroszytu Excela do kolekcji kształtów slajdu.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Zapisz powstałą prezentację do pliku.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Podsumowanie**

Ten mechanizm, dostępny bezpośrednio w Aspose.Slides, łączy pracę z danymi Excel i prezentacjami w jednym miejscu. Umożliwia tworzenie slajdów z wykresami wizualnymi i danymi przedstawionymi jako tabele Excel — bez dodatkowych bibliotek ani skomplikowanych integracji.