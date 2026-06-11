---
title: Optymalizacja obliczeń wykresów w prezentacjach w C++
linktitle: Obliczenia wykresów
type: docs
weight: 50
url: /pl/cpp/chart-calculations/
keywords:
- obliczenia wykresów
- elementy wykresu
- pozycja elementu
- rzeczywista pozycja
- element podrzędny
- element nadrzędny
- wartości wykresu
- rzeczywista wartość
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zrozum obliczenia wykresów, aktualizacje danych i kontrolę precyzji w Aspose.Slides dla C++ dla formatów PPT i PPTX, z praktycznymi przykładami kodu C++."
---
## **Przegląd**

Aspose.Slides udostępnia interfejsy API do pracy z obliczeniami wykresów i danymi układu w prezentacjach. Ten artykuł pokazuje, jak pobrać rzeczywiste wartości elementów wykresu, w tym rzeczywistą pozycję i rozmiar elementów implementujących `IActualLayout` oraz rzeczywiste wartości osi wykresu. Wyjaśnia także, że te wartości są wypełniane po walidacji układu wykresu.

Dodatkowo artykuł demonstruje, jak uzyskać rzeczywistą pozycję nadrzędnych elementów wykresu oraz jak ukrywać komponenty wykresu, takie jak tytuł, osie, legenda i linie siatki. Razem te przykłady pomagają przeglądać informacje o układzie wykresu i programowo kontrolować widoczność elementów wykresu w prezentacjach PowerPoint.

## **Obliczanie rzeczywistych wartości elementów wykresu**
Aspose.Slides for C++ udostępnia prosty interfejs API do pobierania tych właściwości. Pomoże to w obliczeniu rzeczywistych wartości elementów wykresu. Rzeczywiste wartości obejmują pozycję elementów implementujących interfejs IActualLayout (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) oraz rzeczywiste wartości osi (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Zapisywanie prezentacji
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Obliczanie rzeczywistej pozycji nadrzędnych elementów wykresu**
Aspose.Slides for C++ udostępnia prosty interfejs API do pobierania tych właściwości. Metody IActualLayout dostarczają informacji o rzeczywistej pozycji nadrzędnego elementu wykresu. Należy wcześniej wywołać metodę IChart::ValidateChartLayout(), aby wypełnić właściwości rzeczywistymi wartościami.

``` cpp
// Tworzenie pustej prezentacji
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Ukrywanie elementów wykresu**
Ten temat pomaga zrozumieć, jak ukrywać informacje w wykresie. Korzystając z Aspose.Slides for C++ możesz ukryć **Tytuł, Oś pionową, Oś poziomą** oraz **Linie siatki** w wykresie. Poniższy przykład kodu pokazuje, jak używać tych właściwości.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Ustaw zakres danych dla wykresu**
Aspose.Slides for C++ udostępnia najprostszy interfejs API do ustawiania zakresu danych dla wykresu w najłatwiejszy sposób. Aby ustawić zakres danych dla wykresu:

- Otwórz instancję klasy Presentation zawierającą wykres.
- Uzyskaj odniesienie do slajdu, używając jego indeksu.
- Przejdź przez wszystkie kształty, aby znaleźć pożądany wykres.
- Uzyskaj dostęp do danych wykresu i ustaw zakres.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższe przykłady kodu pokazują, jak zaktualizować wykres.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Czy zewnętrzne skoroszyty Excel mogą być używane jako źródło danych i jak to wpływa na przeliczanie?**

Tak. Wykres może odwoływać się do zewnętrznego skoroszytu: po połączeniu lub odświeżeniu zewnętrznego źródła, formuły i wartości są pobierane z tego skoroszytu, a wykres odzwierciedla aktualizacje podczas operacji otwierania/edycji. API pozwala określić [ścieżkę do zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) i zarządzać powiązanymi danymi.

**Czy mogę obliczyć i wyświetlić linie trendu bez własnej implementacji regresji?**

Tak. [Linie trendu](/slides/pl/cpp/trend-line/) (liniowe, wykładnicze i inne) są dodawane i aktualizowane przez Aspose.Slides; ich parametry są automatycznie przeliczane na podstawie danych serii, więc nie musisz samodzielnie implementować obliczeń.

**Jeśli prezentacja zawiera wiele wykresów z zewnętrznymi odnośnikami, czy mogę kontrolować, który skoroszyt używa każdy wykres do obliczonych wartości?**

Tak. Każdy wykres może wskazywać własny [zewnętrzny skoroszyt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), lub możesz utworzyć/zastąpić zewnętrzny skoroszyt dla każdego wykresu niezależnie od pozostałych.