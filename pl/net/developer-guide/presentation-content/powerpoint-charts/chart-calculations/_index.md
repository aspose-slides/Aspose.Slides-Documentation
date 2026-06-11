---
title: Optymalizacja obliczeń wykresów dla prezentacji w .NET
linktitle: Obliczenia wykresów
type: docs
weight: 50
url: /pl/net/chart-calculations/
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
- .NET
- C#
- Aspose.Slides
description: "Zrozum obliczenia wykresów, aktualizacje danych i kontrolę precyzji w Aspose.Slides for .NET dla PPT i PPTX, z praktycznymi przykładami kodu C#."
---
## **Przegląd**

Aspose.Slides udostępnia interfejsy API do pracy z obliczeniami wykresów i danymi układu w prezentacjach. Ten artykuł pokazuje, jak pobrać rzeczywiste wartości elementów wykresu, w tym rzeczywistą pozycję i rozmiar elementów implementujących `IActualLayout` oraz rzeczywiste wartości osi wykresu. Wyjaśnia również, że te wartości są wypełniane po przeprowadzeniu walidacji układu wykresu.

Ponadto artykuł demonstruje, jak uzyskać rzeczywistą pozycję nadrzędnych elementów wykresu oraz jak ukrywać komponenty wykresu, takie jak tytuł, osie, legenda i linie siatki. Razem te przykłady pomagają sprawdzić informacje o układzie wykresu i kontrolować widoczność elementów wykresu w prezentacjach PowerPoint programowo.

## **Obliczanie rzeczywistych wartości elementów wykresu**
Aspose.Slides for .NET udostępnia prosty interfejs API do pobierania tych właściwości. Pomoże to w obliczaniu rzeczywistych wartości elementów wykresu. Rzeczywiste wartości obejmują pozycję elementów implementujących interfejs IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) oraz rzeczywiste wartości osi (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Zapisywanie prezentacji
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Obliczanie rzeczywistej pozycji elementów nadrzędnych wykresu**
Aspose.Slides for .NET udostępnia prosty interfejs API do pobierania tych właściwości. Właściwości IActualLayout dostarczają informacji o rzeczywistej pozycji nadrzędnego elementu wykresu. Należy wcześniej wywołać metodę IChart.ValidateChartLayout(), aby wypełnić właściwości rzeczywistymi wartościami.

```c#
 // Tworzenie pustej prezentacji
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **Ukrywanie elementów wykresu**
Ten temat pomaga zrozumieć, jak ukrywać informacje na wykresie. Korzystając z Aspose.Slides for .NET możesz ukryć **Tytuł, Oś pionową, Oś poziomą** oraz **Linie siatki** na wykresie. Poniższy przykład kodu pokazuje, jak używać tych właściwości.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Ukrywanie tytułu wykresu
    chart.HasTitle = false;

    ///Ukrywanie osi wartości
    chart.Axes.VerticalAxis.IsVisible = false;

    //Widoczność osi kategorii
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Ukrywanie legendy
    chart.HasLegend = false;

    //Ukrywanie głównych linii siatki
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Ustawianie koloru linii serii
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy zewnętrzne skoroszyty Excel działają jako źródło danych i jak to wpływa na ponowne obliczenia?**

Tak. Wykres może odwoływać się do zewnętrznego skoroszytu: gdy podłączasz lub odświeżasz zewnętrzne źródło, formuły i wartości są pobierane z tego skoroszytu, a wykres odzwierciedla aktualizacje podczas operacji otwierania/edycji. API pozwala [określić ścieżkę zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/setexternalworkbook/) i zarządzać powiązanymi danymi.

**Czy mogę obliczyć i wyświetlić linie trendu bez własnej implementacji regresji?**

Tak. [Linie trendu](/slides/pl/net/trend-line/) (liniowe, wykładnicze i inne) są dodawane i aktualizowane przez Aspose.Slides; ich parametry są automatycznie przeliczane na podstawie danych serii, więc nie musisz implementować własnych obliczeń.

**Jeśli prezentacja zawiera wiele wykresów z zewnętrznymi odnośnikami, czy mogę kontrolować, który skoroszyt używa każdy wykres do obliczonych wartości?**

Tak. Każdy wykres może odwoływać się do własnego [zewnętrznego skoroszytu](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chartdata/setexternalworkbook/), albo można utworzyć/ zamienić zewnętrzny skoroszyt dla każdego wykresu niezależnie od pozostałych.