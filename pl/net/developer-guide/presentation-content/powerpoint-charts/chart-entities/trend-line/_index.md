---
title: Dodaj linie trendu do wykresów prezentacji w .NET
linktitle: Linia trendu
type: docs
url: /pl/net/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej ruchomej
- wielomianowa linia trendu
- potęgowa linia trendu
- niestandardowa linia trendu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy pomocy Aspose.Slides for .NET — praktyczny przewodnik, aby przyciągnąć uwagę odbiorców."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z różnymi typami linii trendu, w tym wykładniczym, liniowym, logarytmicznym, średnią ruchomą, wielomianowym i potęgowym.

Opisuje także, jak dodać własną linię do wykresu, wstawiając kształt linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu „forward” i „backward” oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**
Aspose.Slides for .NET zapewnia prosty interfejs API do zarządzania różnymi liniami trendu wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj wykres z domyślnymi danymi oraz wybranym typem (w tym przykładzie użyto ChartType.ClusteredColumn).
1. Dodaj wykładniczą linię trendu dla serii wykresu 1.
1. Dodaj liniową linię trendu dla serii wykresu 1.
1. Dodaj logarytmiczną linię trendu dla serii wykresu 2.
1. Dodaj linię trendu średniej ruchomej dla serii wykresu 2.
1. Dodaj wielomianową linię trendu dla serii wykresu 3.
1. Dodaj potęgową linię trendu dla serii wykresu 3.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

The following code is used to create a chart with Trend Lines.

```c#
// Tworzenie pustej prezentacji
Presentation pres = new Presentation();

// Tworzenie wykresu słupkowego grupowanego
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Dodawanie wykładniczej linii trendu dla serii wykresu 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Dodawanie liniowej linii trendu dla serii wykresu 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Dodawanie logarytmicznej linii trendu dla serii wykresu 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Dodawanie linii trendu średniej ruchomej dla serii wykresu 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Dodawanie wielomianowej linii trendu dla serii wykresu 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Dodawanie potęgowej linii trendu dla serii wykresu 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Zapisywanie prezentacji
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Dodaj własną linię**
Aspose.Slides for .NET zapewnia prosty interfejs API do dodawania własnych linii w wykresie. Aby dodać prostą, zwykłą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy Presentation
- Uzyskaj referencję do slajdu, używając jego indeksu
- Utwórz nowy wykres przy użyciu metody AddChart udostępnionej przez obiekt Shapes
- Dodaj AutoShape typu Linia przy użyciu metody AddAutoShape udostępnionej przez obiekt Shapes
- Ustaw kolor linii kształtu.
- Zapisz zmodyfikowaną prezentację jako plik PPTX

The following code is used to create a chart with Custom Lines.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Co oznaczają „forward” i „backward” w kontekście linii trendu?**

Są to długości linii trendu projekowane w przód/tył: dla wykresów punktowych (XY) – w jednostkach osi; dla wykresów innych niż punktowe – w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu będzie zachowana podczas eksportu prezentacji do formatu PDF lub SVG, lub przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/)/[SVG](/slides/pl/net/render-a-slide-as-an-svg-image/) oraz renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest także metoda do [eksportowania obrazu wykresu](/slides/pl/net/create-shape-thumbnails/).