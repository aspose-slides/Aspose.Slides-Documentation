---
title: Dostosowanie obszarów kreślenia wykresów w prezentacjach w .NET
linktitle: Obszar kreślenia
type: docs
url: /pl/net/chart-plot-area/
keywords:
- wykres
- obszar kreślenia
- szerokość obszaru kreślenia
- wysokość obszaru kreślenia
- rozmiar obszaru kreślenia
- tryb układu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dostosować obszary kreślenia wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET. Popraw wygląd swoich slajdów bez wysiłku."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z obszarem kreślenia wykresu w Aspose.Slides. Wyjaśnia, jak uzyskać rzeczywistą pozycję i rozmiar obszaru kreślenia, walidując układ wykresu, a następnie odczytując wartości X, Y, szerokości i wysokości. Pokazuje także, jak skonfigurować tryb układu obszaru kreślenia, gdy układ jest ustawiany ręcznie, używając `LayoutTargetType` do określenia, czy obszar kreślenia jest obliczany na podstawie swojego wewnętrznego regionu, czy zewnętrznego regionu wraz z osiami i etykietami osi.

## **Uzyskaj szerokość i wysokość obszaru kreślenia wykresu**
Aspose.Slides for .NET udostępnia prosty interfejs API.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Wywołaj metodę IChart.ValidateChartLayout() przed pobraniem rzeczywistych wartości.
5. Pobiera rzeczywistą pozycję X (lewy) elementu wykresu względem lewego górnego rogu wykresu.
6. Pobiera rzeczywistą pozycję górną elementu wykresu względem lewego górnego rogu wykresu.
7. Pobiera rzeczywistą szerokość elementu wykresu.
8. Pobiera rzeczywistą wysokość elementu wykresu.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Zapisz prezentację z wykresem
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **Ustaw tryb układu obszaru kreślenia wykresu**
Aspose.Slides for .NET udostępnia prosty interfejs API do ustawiania trybu układu obszaru kreślenia wykresu. Właściwość **LayoutTargetType** została dodana do klas **ChartPlotArea** i **IChartPlotArea**. Jeśli układ obszaru kreślenia jest definiowany ręcznie, ta właściwość określa, czy układać obszar kreślenia według jego wnętrza (nie uwzględniając osi i etykiet osi) czy zewnętrza (uwzględniając oś i etykiety osi). Dostępne są dwie możliwe wartości, zdefiniowane w wyliczeniu **LayoutTargetType**.

- **LayoutTargetType.Inner** - określa, że rozmiar obszaru kreślenia określa rozmiar samego obszaru kreślenia, nie uwzględniając znaczników podziałki i etykiet osi.
- **LayoutTargetType.Outer** - określa, że rozmiar obszaru kreślenia określa rozmiar obszaru kreślenia, znaczników podziałki i etykiet osi.

Przykładowy kod znajduje się poniżej.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**W jakich jednostkach zwracane są ActualX, ActualY, ActualWidth i ActualHeight?**

W punktach; 1 cal = 72 punkty. Są to jednostki współrzędnych Aspose.Slides.

**Czym różni się obszar kreślenia od obszaru wykresu pod względem zawartości?**

Obszar kreślenia to region rysowania danych (serie, linie siatki, linie trendu itp.); obszar wykresu obejmuje elementy otaczające (tytuł, legendę itp.). W wykresach 3D obszar kreślenia obejmuje również ściany/podłogę oraz osie.

**Jak interpretowane są X, Y, Width i Height obszaru kreślenia, gdy układ jest ręczny?**

Są to ułamki (0–1) całkowitego rozmiaru wykresu; w tym trybie automatyczne pozycjonowanie jest wyłączone i używane są ustawione przez Ciebie ułamki.

**Dlaczego pozycja obszaru kreślenia zmieniła się po dodaniu/przeniesieniu legendy?**

Legenda znajduje się w obszarze wykresu poza obszarem kreślenia, ale wpływa na układ i dostępną przestrzeń, więc obszar kreślenia może się przemieścić, gdy włączone jest automatyczne pozycjonowanie. (Jest to standardowe zachowanie wykresów w programie PowerPoint.)