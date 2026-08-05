---
title: Dostosowywanie obszarów wykresów w prezentacjach w C++
linktitle: Obszar wykresu
type: docs
url: /pl/cpp/chart-plot-area/
keywords:
- wykres
- obszar wykresu
- szerokość obszaru wykresu
- wysokość obszaru wykresu
- rozmiar obszaru wykresu
- tryb układu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dostosować obszary wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++. Popraw wygląd swoich slajdów bez wysiłku."
---
## **Przegląd**

W tym artykule pokazano, jak pracować z obszarem wykresu w Aspose.Slides. Wyjaśniono, jak uzyskać rzeczywistą pozycję i rozmiar obszaru wykresu, najpierw walidując układ wykresu, a następnie odczytując jego wartości X, Y, szerokości i wysokości.

Pokazano także, jak skonfigurować tryb układu obszaru wykresu, gdy układ jest ustawiany ręcznie, używając `LayoutTargetType` do określenia, czy obszar wykresu jest obliczany na podstawie swojego wewnętrznego regionu, czy zewnętrznego regionu wraz z osiami i etykietami osi.

## **Uzyskanie szerokości i wysokości obszaru wykresu**
Aspose.Slides for C++ udostępnia prosty interfejs API dla .

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Wywołaj metodę IChart::ValidateChartLayout() przed pobraniem rzeczywistych wartości.
5. Pobiera rzeczywistą pozycję X (lewo) elementu wykresu względem lewego górnego rogu wykresu.
6. Pobiera rzeczywistą pozycję górną elementu wykresu względem lewego górnego rogu wykresu.
7. Pobiera rzeczywistą szerokość elementu wykresu.
8. Pobiera rzeczywistą wysokość elementu wykresu.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Zapisz prezentację z wykresem
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Ustawienie trybu układu obszaru wykresu**
Aspose.Slides for C++ udostępnia prosty interfejs API do ustawiania trybu układu obszaru wykresu. Właściwość **LayoutTargetType** została dodana do klas **ChartPlotArea** i **IChartPlotArea**. Jeśli układ obszaru wykresu jest definiowany ręcznie, ta właściwość określa, czy układ obszaru wykresu ma być oparty na jego wnętrzu (bez uwzględniania osi i etykiet osi) czy na zewnętrzu (z uwzględnieniem osi i etykiet osi). Istnieją dwa możliwe wartości zdefiniowane w wyliczeniu **LayoutTargetType**.

- **LayoutTargetType.Inner** – określa, że rozmiar obszaru wykresu ma określać rozmiar obszaru wykresu, nie wliczając znaczników i etykiet osi.
- **LayoutTargetType.Outer** – określa, że rozmiar obszaru wykresu ma określać rozmiar obszaru wykresu, znaczników oraz etykiet osi.

Poniżej znajduje się przykładowy kod.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**W jakich jednostkach zwracane są ActualX, ActualY, ActualWidth i ActualHeight?**

W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Czym różni się Obszar wykresu od Obszaru wykresu pod względem zawartości?**

Obszar wykresu to region rysowania danych (serie, linie siatki, linie trendu itp.); Obszar wykresu (Chart Area) obejmuje elementy otaczające (tytuł, legendę itp.). W wykresach 3D Obszar wykresu obejmuje również ściany/podłogę i osie.

**Jak interpretowane są wartości X, Y, Width i Height Obszaru wykresu, gdy układ jest ręczny?**

Są to ułamki (0–1) całkowitego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone i używane są ustawione przez użytkownika ułamki.

**Dlaczego pozycja Obszaru wykresu zmieniła się po dodaniu lub przeniesieniu legendy?**

Legenda znajduje się w obszarze wykresu poza Obszarem wykresu, ale wpływa na układ i dostępną przestrzeń, więc Obszar wykresu może się przesunąć, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów w PowerPoint.)