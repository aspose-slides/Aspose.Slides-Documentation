---
title: Formatowanie wykresów prezentacji w .NET
linktitle: Formatowanie wykresu
type: docs
weight: 60
url: /pl/net/chart-formatting/
keywords:
- format wykresu
- formatowanie wykresu
- element wykresu
- właściwości wykresu
- ustawienia wykresu
- opcje wykresu
- właściwości czcionki
- zaokrąglone obramowanie
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla .NET i podnieś swoją prezentację PowerPoint dzięki niestandardowym osią, czcionkom, formatom liczb oraz zaokrąglonym obramowaniom wykresu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Pokazuje również, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępnie zdefiniowane formaty liczbowe do danych wykresu oraz włączyć zaokrąglone rogi obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresu w prezentacji.

Aby uzyskać oddzielne wypełnienia i obramowania na przedziałach rosnących i malejących, zobacz [przykład wykresu giełdowego](/slides/pl/net/create-chart/#create-stock-charts).

## **Formatuj elementy wykresu**

Użyj [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) do formatowania tytułów wykresu, osi, linii siatki, legend oraz obszaru wykresu. Ten przykład tworzy wykres liniowy z markerami i domyślnymi danymi, a następnie stosuje oddzielne style tekstu i linii do osi wartości i osi kategorii. Rozmiary czcionek i szerokości linii podane są w punktach; etykiety kategorii są obrócone o 45 stopni.

Oś wartości używa [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) niezależnie od komórek źródłowych. Jej skala przebiega od -2 do 15, z głównymi przedziałami co 2 i mniejszymi przedziałami co 0,5. Przykład łączy również formatowanie procentowe z [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) ustawionym na tysiące, więc dostosuj te ustawienia do znaczenia i wielkości swoich danych. Legenda pozostaje poza obszarem wykresu, ponieważ [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) jest wyłączony. Wypełnienia tylnej ściany i podłogi są konfigurowane za pomocą [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) i [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), ale te powierzchnie są widoczne tylko w wykresach 3D.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Ustaw właściwości czcionki dla wykresu**

Ustaw domyślny rozmiar czcionki dla tekstu wykresu za pomocą [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). Przykład tworzy grupowy wykres słupkowy z czcionką 20 punktów i włącza etykiety wartości dla pierwszej serii przy użyciu [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Elementy tekstowe z własnymi explicite ustawionymi czcionkami mogą nadpisać domyślne ustawienia wykresu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Ponowne użycie formatowania ramki tekstu dla legendy wykresu**

Aby dopasować legendę do nagłówka slajdu, ustaw czcionkę w [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) pierwszego akapitu. Wywołaj [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) na [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) legendy. Odczytuje on ustawienia ramki tekstowej, formatowanie pierwszego akapitu oraz domyślne właściwości czcionki tego akapitu. Formatowanie zastosowane bezpośrednio do pojedynczych fragmentów lub do późniejszych akapitów pozostaje lokalne dla źródła.

Przykład używa pogrubionego, 26‑punktowego nagłówka w czcionce Calibri w kolorze granatowym jako szablonu. Po sformatowaniu legendy, używa [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/), aby zastosować to samo formatowanie do osobnego podpisu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

W zapisanej prezentacji legenda i podpis odpowiadają nagłówkowi pod względem rozmiaru, grubości i koloru. Legenda nadal wyświetla nazwy serii, a podpis zachowuje własny tekst. Jeśli fragment w podpisie ma już explicite ustawiony rozmiar czcionki, ten rozmiar ma pierwszeństwo przed skopiowanym domyślnym rozmiarem akapitu.

| Przed kopiowaniem | Po skopiowaniu |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **Ustaw format liczbowy**

Użyj [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/), aby zastosować wbudowany format liczbowy do komórek skoroszytu wykresu. Ten przykład tworzy grupowy wykres słupkowy z domyślnymi danymi opartymi na komórkach i stosuje indeks formatu 10 (`0.00%`) do każdej komórki wartości serii. Zmienia to sposób wyświetlania wartości w skoroszycie bez zmiany podstawowych liczb; na przykład 0,25 jest wyświetlane jako 25,00%. Formatowanie osi i etykiet danych można konfigurować osobno.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Poniższa tabela zawiera wbudowane indeksy formatów liczbowych wraz z reprezentatywnymi formatami Excel dla ustawień regionalnych angielskich (Stany Zjednoczone). Dokładne ciągi formatów i ich wyświetlanie mogą się różnić w zależności od aplikacji i ustawień regionalnych, szczególnie w przypadku walut i dat. Niektóre formaty Excel różnią się również od domyślnych w standardzie OOXML, co opisano w [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indeks | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Ustaw zaokrąglone krawędzie obszaru wykresu**

Włącz [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/), aby zaokrąglić rogi obszaru wykresu. Przykład tworzy grupowy wykres słupkowy i używa [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/), aby nadać jego obramowaniu jednolity szary kolor i styl jednej linii przed zapisaniem prezentacji.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Edytuj istniejące adnotacje wykresu**

Wykres może zawierać niestandardowe kształty, takie jak adnotacja tekstowa wyjaśniająca status raportu. Dostęp do tych kształtów uzyskuje się przez [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), wymienione również pod [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) w dokumentacji API wykresu. Jego kolekcja [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) zawiera kształty należące do wykresu.

Zwykłe pole tekstowe umieszczone nad wykresem należy do slajdu, nawet jeśli wygląda jak część wykresu. Iterowanie przez [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) znajduje wykres i zwykłe kształty slajdu, ale nie wymienia poszczególnych kształtów wewnątrz wykresu. Tytuły wykresów i etykiety danych są oddzielnymi elementami wykresu, a nie niestandardowymi adnotacjami w tej kolekcji.

Pobierz [chart-annotations.pptx](chart-annotations.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera wykres z niegrupowaną adnotacją o treści „Preliminary results”, linią należącą do wykresu oraz zwykłym polem tekstowym slajdu o treści „Slide overlay”. Przykład znajduje pierwszy wykres na tym slajdzie i zmienia adnotację na „Final results”, gdy raport jest gotowy do publikacji. Sprawdza, czy kolekcja nie jest pusta i edytuje jedynie [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) posiadający nie‑nullowy [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) i oczekiwany tekst.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

Linia i pole tekstowe slajdu pozostają niezmienione. Poniższe obrazy przedstawiają wejście oraz zapisany, ponownie otwarty wynik:

| Przed edycją | Po edycji |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Przykład sprawdza tylko kształty na najwyższym poziomie należące do wykresu. Jeśli adnotacja znajduje się wewnątrz [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), należy również przejrzeć kolekcję [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) tej grupy. Powtarzaj to rekurencyjnie dla zagnieżdżonych grup, stosując te same kontrole tekstu do ich podrzędnych kształtów. Grupa sama w sobie jest kontenerem; nie traktuj jej jak pola tekstowego.
{{% /alert %}}

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów, zachowując nieprzezroczyste obramowanie?**

Tak. Przezroczystość wypełnienia i obramowanie są konfigurowane osobno. Jest to przydatne do poprawy czytelności siatki i danych w gęstych wizualizacjach.

**Jak mogę poradzić sobie z etykietami danych, gdy nakładają się na siebie?**

Zmniejsz rozmiar czcionki, wyłącz nieistotne elementy etykiet (np. kategorie), dostosuj pozycję etykiety, wyświetlaj etykiety tylko dla wybranych punktów w razie potrzeby lub zmień format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe do serii?**

Tak. Serie obsługują wypełnienia jednolite, gradientowe i wzorcowe. W praktyce stosuj gradienty oszczędnie i unikaj kombinacji, które zmniejszają kontrast z siatką i tekstem.