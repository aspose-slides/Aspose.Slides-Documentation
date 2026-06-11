---
title: Dostosuj obszary wykresów prezentacji w Pythonie
linktitle: Obszar wykresu
type: docs
url: /pl/python-net/chart-plot-area/
keywords:
- wykres
- obszar wykresu
- szerokość obszaru wykresu
- wysokość obszaru wykresu
- rozmiar obszaru wykresu
- tryb układu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj, jak dostosować obszary wykresów w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona przez .NET. Popraw wygląd swoich slajdów bez wysiłku."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z obszarem wykresu w Aspose.Slides. Wyjaśnia, jak uzyskać rzeczywistą pozycję i rozmiar obszaru wykresu, walidując układ wykresu, a następnie odczytując jego wartości X, Y, szerokości i wysokości.

Pokazuje również, jak skonfigurować tryb układu obszaru wykresu, gdy układ jest ustawiany ręcznie, używając `LayoutTargetType` do określenia, czy obszar wykresu jest obliczany na podstawie jego wewnętrznego regionu, czy zewnętrznego regionu wraz z osiami i etykietami osi.

## **Pobranie szerokości i wysokości obszaru wykresu**
Aspose.Slides for Python via .NET udostępnia prosty interfejs API dla .NET.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Wywołaj metodę IChart.ValidateChartLayout() przed pobraniem rzeczywistych wartości.
1. Pobiera rzeczywistą lokalizację X (lewy) elementu wykresu względem lewego górnego narożnika wykresu.
1. Pobiera rzeczywistą pozycję górną elementu wykresu względem lewego górnego narożnika wykresu.
1. Pobiera rzeczywistą szerokość elementu wykresu.
1. Pobiera rzeczywistą wysokość elementu wykresu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Zapisz prezentację z wykresem
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawienie trybu układu obszaru wykresu**
Aspose.Slides for Python via .NET udostępnia prosty interfejs API do ustawiania trybu układu obszaru wykresu. Właściwość **LayoutTargetType** została dodana do klas **ChartPlotArea** i **IChartPlotArea**. Jeśli układ obszaru wykresu jest definiowany ręcznie, właściwość ta określa, czy układać obszar wykresu wewnątrz (bez osi i etykiet osi) czy na zewnątrz (z uwzględnieniem osi i etykiet osi). Dostępne są dwa możliwe wartości, które są zdefiniowane w wyliczeniu **LayoutTargetType**.

- **LayoutTargetType.Inner** – określa, że rozmiar obszaru wykresu ma określać rozmiar obszaru wykresu, nie obejmując znaczników i etykiet osi.
- **LayoutTargetType.Outer** – określa, że rozmiar obszaru wykresu ma określać rozmiar obszaru wykresu, znaczniki i etykiety osi.

Przykładowy kod znajduje się poniżej.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**W jakich jednostkach zwracane są actual_x, actual_y, actual_width i actual_height?**

W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Czym różni się obszar wykresu (Plot Area) od obszaru wykresu (Chart Area) pod względem zawartości?**

Obszar wykresu (Plot Area) to region rysowania danych (serie, linie siatki, linie trendu itp.); obszar wykresu (Chart Area) obejmuje elementy otaczające (tytuł, legendę itp.). W wykresach 3D obszar wykresu (Plot Area) zawiera także ściany/podłogę oraz osie.

**Jak interpretowane są wartości X, Y, Width i Height obszaru wykresu, gdy układ jest ustawiony ręcznie?**

Są to ułamki (0–1) całkowitego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone i używane są podane przez Ciebie ułamki.

**Dlaczego po dodaniu/przesunięciu legendy pozycja obszaru wykresu uległa zmianie?**

Legenda znajduje się w obszarze wykresu poza obszarem wykresu (Plot Area), ale wpływa na układ i dostępną przestrzeń, dlatego obszar wykresu może się przesunąć, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów w programie PowerPoint.)