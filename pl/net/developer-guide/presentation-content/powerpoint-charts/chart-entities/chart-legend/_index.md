---
title: Dostosowywanie legend wykresów w prezentacjach w .NET
linktitle: Legenda wykresu
type: docs
url: /pl/net/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides dla .NET, aby zoptymalizować prezentacje PowerPoint poprzez spersonalizowane formatowanie legend."
---
## **Przegląd**

Aspose.Slides for .NET oferuje opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak pozycjonować i zmieniać rozmiar legendy, ustawić rozmiar czcionki dla całej legendy, sformatować pojedynczy wpis legendy oraz ukrywać lub przywracać wybrane pozycje.

FAQ opisuje powiązane zachowania, w tym rezerwowanie miejsca dla legendy, wyświetlanie etykiet wieloliniowych oraz dziedziczenie formatowania z motywu prezentacji.

## **Pozycjonowanie legendy**

Użyj właściwości legendy [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) i [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) aby określić jej pozycję i rozmiar jako ułamki wymiarów wykresu.

Ten przykład tworzy prezentację i dodaje wykres kolumnowy grupowany z danymi domyślnymi do pierwszego slajdu. Dzielenie żądanych przesunięć i wymiarów legendy przez szerokość i wysokość wykresu konwertuje je na wartości względne: legenda jest odsunięta o 50 punktów od lewego górnego narożnika wykresu i ma wymiary 100 × 100 punktów.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Ustaw rozmiar czcionki legendy**

Użyj [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) legendy, aby uzyskać dostęp do formatowania tekstu i ustaw [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) w punktach.

Ten przykład tworzy wykres z danymi domyślnymi i ustawia tekst legendy na 20 punktów. Wyłącza również automatyczne granice dla osi pionowej i ustawia jej zakres od –5 do 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Ustaw rozmiar czcionki pojedynczego wpisu legendy**

Użyj kolekcji [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) legendy, aby uzyskać dostęp do formatowania konkretnego wpisu. Indeksy wpisów są zerowe, więc indeks `1` odnosi się do drugiego wpisu.

Ten przykład tworzy wykres kolumnowy grupowany, którego dane domyślne zawierają przynajmniej dwie serie. Formatuje drugi wpis legendy jako pogrubiony, pochylony i niebieski tekst o rozmiarze 20 punktów.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Ukryj pojedyncze wpisy legendy**

Aby wykluczyć pomocniczą serię z legendy, pozostawiając jej dane widoczne, ustaw [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) na `true` za pomocą [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Ukryje to tylko wybrany wpis legendy; nie usuwa serii ani jej punktów danych. Ustawienie [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) na `false` ukrywa natomiast całą legendę.

Poniższy przykład tworzy wykres kolumnowy grupowany z wieloma seriami przy użyciu danych domyślnych. Ukrywa drugi wpis legendy serii (indeks `1`) i zapisuje prezentację. Następnie przywraca wpis, ustawiając `Hide` na `false`, i zapisuje drugą kopię. Kolumny pozostają widoczne w obu plikach.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Przywróć ten sam wpis bez zmiany danych wykresu.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Porównanie poniżej pokazuje ten sam wykres ze wszystkimi widocznymi wpisami legendy oraz z ukrytym drugim wpisem. Kolumny drugiej serii pozostają niezmienione.

![Porównanie wykresu ze wszystkimi widocznymi wpisami legendy oraz z ukrytym wpisem Seria 2; wszystkie kolumny pozostają widoczne.](hide-legend-entry.png)

W wykresach kolumnowych, słupkowych i liniowych wpisy legendy identyfikują serie. W wykresach kołowych identyfikują pojedyncze punkty danych (wycinki), więc należy użyć [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) na wybranym wycinku. Dokumentacja API opisuje tę właściwość punktu danych dla typów wykresów `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` i `BarOfPie`. Nie należy zakładać, że dotyczy ona wykresów pierścieniowych, które nie są wymienione w tej liście.

## **FAQ**

**Czy mogę sprawić, że wykres zarezerwuje miejsce dla legendy zamiast nakładać ją na wykres?**  
Tak. Ustaw [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) na `false`, aby zarezerwować miejsce dla legendy zamiast pozwalać jej nachodzić na obszar wykresu.

**Czy mogę tworzyć wieloliniowe etykiety legendy?**  
Tak. Długie etykiety mogą się zawijać, gdy dostępna szerokość jest niewystarczająca. Można również używać znaków nowej linii w nazwach serii, aby wymusić podział na linie.

**Jak sprawić, aby legenda korzystała ze schematu kolorów motywu prezentacji?**  
Pozostaw kolory, wypełnienia i czcionki legendy nieustawione, aby mogła dziedziczyć formatowanie z motywu. Jawne formatowanie nadpisuje odpowiadające ustawienia motywu.