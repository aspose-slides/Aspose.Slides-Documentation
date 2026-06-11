---
title: Dostosowywanie osi wykresu w prezentacjach przy użyciu C++
linktitle: Oś wykresu
type: docs
url: /pl/cpp/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosuj oś
- manipuluj osią
- zarządzaj osią
- właściwości osi
- wartość maksymalna
- wartość minimalna
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla C++ do dostosowywania osi wykresu w prezentacjach PowerPoint przeznaczonych do raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides. Pokazuje, jak uzyskać rzeczywiste wartości osi, zamienić dane między osiami, ukryć pionową lub poziomą oś w wykresach liniowych, zmienić typ osi kategorii, ustawić format daty dla wartości osi kategorii, obrócić tytuł osi, ustawić pozycję osi oraz wyświetlić etykietę jednostki na osi wartości.

## **Uzyskaj maksymalne wartości na osi pionowej**
Aspose.Slides for C++ umożliwia pobranie minimalnych i maksymalnych wartości na osi pionowej. Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Pobierz rzeczywistą maksymalną wartość na osi.
5. Pobierz rzeczywistą minimalną wartość na osi.
6. Pobierz rzeczywistą jednostkę główną osi.
7. Pobierz rzeczywistą jednostkę pomocniczą osi.
8. Pobierz rzeczywistą skalę jednostki głównej osi.
9. Pobierz rzeczywistą skalę jednostki pomocniczej osi.

Ten przykładowy kod — implementacja powyższych kroków — pokazuje, jak uzyskać wymagane wartości w C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Zapisuje prezentację
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Zamień dane między osiami**
Aspose.Slides umożliwia szybkie zamienienie danych między osiami — dane przedstawione na osi pionowej (y) przenoszone są na oś poziomą (x) i odwrotnie.

Ten kod C++ pokazuje, jak wykonać zamianę danych między osiami w wykresie:

``` cpp
// Tworzy pustą prezentację
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Przełącza wiersze i kolumny
chart->get_ChartData()->SwitchRowColumn();

// Zapisuje prezentację
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Ukryj oś pionową w wykresach liniowych**

Ten kod C++ pokazuje, jak ukryć oś pionową w wykresie liniowym:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Ukryj oś poziomą w wykresach liniowych**

Ten kod pokazuje, jak ukryć oś poziomą w wykresie liniowym:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Zmień oś kategorii**

Za pomocą metody **set_CategoryAxisType()** możesz określić preferowany typ osi kategorii (**date** lub **text**). Ten kod w C++ demonstruje operację: 

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Ustaw format daty dla wartości osi kategorii**
Aspose.Slides for C++ umożliwia ustawienie formatu daty dla wartości osi kategorii. Operacja jest pokazana w tym kodzie C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Ustaw kąt obrotu tytułu osi**
Aspose.Slides for C++ umożliwia ustawienie kąta obrotu tytułu osi wykresu. Ten kod C++ demonstruje operację:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Ustaw pozycję osi na osi kategorii lub wartości**
Aspose.Slides for C++ umożliwia ustawienie pozycji osi w osi kategorii lub wartości. Ten kod C++ pokazuje, jak wykonać to zadanie:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Włącz wyświetlanie etykiety jednostki na osi wartości wykresu**
Aspose.Slides for C++ umożliwia skonfigurowanie wykresu tak, aby wyświetlał etykietę jednostki na osi wartości wykresu. Ten kod C++ demonstruje operację:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Osie oferują [ustawienie przecięcia](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/axis/set_crosstype/): możesz wybrać przecięcie w zerze, w maksymalnej kategorii/wartości lub w określonej wartości numerycznej. Jest to przydatne do przesunięcia osi X w górę lub w dół lub do podkreślenia linii bazowej.

**Jak mogę pozycjonować etykiety podziałek względem osi (obok, na zewnątrz, wewnątrz)?**

Ustaw [pozycję etykiety](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/axis/set_majortickmark/) na “cross”, “outside” lub “inside”. To wpływa na czytelność i pomaga zaoszczędzić miejsce, szczególnie w małych wykresach.