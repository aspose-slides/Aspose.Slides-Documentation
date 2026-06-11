---
title: Dostosowywanie obszarów wykresów w prezentacjach w С++
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
- С++
- Aspose.Slides
description: "Odkryj, jak dostosować obszary wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla С++. Łatwo ulepszaj wygląd swoich slajdów."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z obszarem wykresu w Aspose.Slides. Wyjaśnia, jak uzyskać rzeczywistą pozycję i rozmiar obszaru wykresu, walidując układ wykresu, a następnie odczytując jego wartości X, Y, szerokości i wysokości. Pokazuje także, jak skonfigurować tryb układu obszaru wykresu, gdy układ jest ustawiany ręcznie, używając `LayoutTargetType` do określenia, czy obszar wykresu jest obliczany na podstawie swojego wewnętrznego regionu, czy zewnętrznego regionu wraz z osiami i etykietami osi.

## **Pobranie szerokości i wysokości obszaru wykresu**
Aspose.Slides for C++ udostępnia prosty interfejs API dla .

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Wywołaj metodę IChart::ValidateChartLayout() przed uzyskaniem rzeczywistych wartości.
5. Pobiera rzeczywistą pozycję X (lewy) elementu wykresu względem lewego górnego rogu wykresu.
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
Aspose.Slides for C++ udostępnia prosty interfejs API do ustawiania trybu układu obszaru wykresu. Właściwość **LayoutTargetType** została dodana do klas **ChartPlotArea** i **IChartPlotArea**. Jeśli układ obszaru wykresu jest definiowany ręcznie, ta właściwość określa, czy układać obszar wykresu wewnątrz (bez osi i etykiet osi) czy na zewnątrz (z uwzględnieniem osi i etykiet osi). Dostępne są dwa możliwe wartości, które są zdefiniowane w enumeracji **LayoutTargetType**.

- **LayoutTargetType.Inner** – określa, że rozmiar obszaru wykresu określa rozmiar obszaru wykresu, bez znaczników podziałki i etykiet osi.
- **LayoutTargetType.Outer** – określa, że rozmiar obszaru wykresu określa rozmiar obszaru wykresu, znaczników podziałki i etykiet osi.

Przykładowy kod znajduje się poniżej.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**W jakich jednostkach zwracane są ActualX, ActualY, ActualWidth i ActualHeight?**

W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Czym różni się obszar wykresu (Plot Area) od obszaru wykresu (Chart Area) pod względem zawartości?**

Obszar wykresu (Plot Area) to region rysowania danych (serie, linie siatki, linie trendu itp.); Obszar wykresu (Chart Area) obejmuje elementy otaczające (tytuł, legendę itp.). W wykresach 3D obszar wykresu (Plot Area) obejmuje również ściany/podłogę oraz osie.

**Jak interpretowane są X, Y, Width i Height obszaru wykresu (Plot Area), gdy układ jest ręczny?**

Są to ułamki (0‑1) całkowitego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone i używane są podane ułamki.

**Dlaczego pozycja obszaru wykresu (Plot Area) zmieniła się po dodaniu/przeniesieniu legendy?**

Legenda znajduje się w obszarze wykresu (Chart Area) poza obszarem wykresu (Plot Area), ale wpływa na układ i dostępną przestrzeń, dlatego obszar wykresu może się przesunąć, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów w PowerPoint.)