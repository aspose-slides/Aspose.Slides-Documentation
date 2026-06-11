---
title: Tworzenie wykresów przy użyciu VSTO i Aspose.Slides dla .NET
linktitle: Utwórz wykres
type: docs
weight: 80
url: /pl/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- tworzenie wykresu
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zautomatyzować tworzenie wykresów PowerPoint w języku C#. Ten przewodnik krok po kroku pokazuje, dlaczego Aspose.Slides dla .NET jest szybszą i bardziej wydajną alternatywą dla Microsoft.Office.Interop."
---
## **Przegląd**

Ten artykuł pokazuje, jak programowo tworzyć i dostosowywać wykresy w prezentacjach Microsoft PowerPoint przy użyciu C#. Dzięki Aspose.Slides dla .NET możesz automatyzować generowanie profesjonalnych, opartych na danych wykresów bez korzystania z Microsoft Office ani bibliotek Interop. API oferuje bogaty zestaw funkcji do tworzenia wykresów kolumnowych, kołowych, liniowych i innych — z pełną kontrolą nad wyglądem, danymi i układem. Niezależnie od tego, czy generujesz raporty, pulpity nawigacyjne czy prezentacje biznesowe, Aspose.Slides pomaga dostarczać wysokiej jakości wizualizacje bezpośrednio z aplikacji .NET.

## **Przykład VSTO**

Ten sekcja demonstruje, jak utworzyć wykres w prezentacji Microsoft PowerPoint przy użyciu **VSTO (Visual Studio Tools for Office)**. Dzięki VSTO możesz programowo generować i dostosowywać wykresy, łącząc automatyzację PowerPointa i Excela. Przykład pokazuje, jak dodać **3D wykres kolumnowy grupowany**, wypełnić go danymi z arkusza Excel, dostosować formatowanie i układ oraz zapisać końcową prezentację — wszystko z poziomu aplikacji .NET.

1. Utwórz instancję prezentacji Microsoft PowerPoint.
1. Dodaj pusty slajd do prezentacji.
1. Dodaj wykres kolumnowy grupowany 3D i uzyskaj do niego dostęp.
1. Utwórz nową instancję skoroszytu Microsoft Excel i załaduj dane wykresu.
1. Uzyskaj dostęp do arkusza danych wykresu przy użyciu instancji skoroszytu Excel.
1. Ustaw zakres wykresu w arkuszu i usuń serie 2 i 3 z wykresu.
1. Zmodyfikuj dane kategorii wykresu w arkuszu danych wykresu.
1. Zmodyfikuj dane serii 1 w arkuszu danych wykresu.
1. Uzyskaj dostęp do tytułu wykresu i ustaw jego właściwości czcionki.
1. Uzyskaj dostęp do osi wartości wykresu i ustaw jednostkę główną, jednostkę podrzędną, wartość maksymalną i minimalną.
1. Uzyskaj dostęp do osi głębokości (serii) wykresu i usuń ją — w tym przykładzie używana jest tylko jedna seria.
1. Ustaw kąty obrotu wykresu w kierunkach X i Y.
1. Zapisz prezentację.
1. Zamknij instancje Microsoft Excel i PowerPoint.

```c#
EnsurePowerPointIsRunning(true, true);

// Utwórz obiekt slajdu.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Uzyskaj dostęp do pierwszego slajdu prezentacji.
objSlide = objPres.Slides[1];

// Zaznacz pierwszy slajd i ustaw jego układ.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Dodaj domyślny wykres do slajdu.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Uzyskaj dostęp do dodanego wykresu.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Uzyskaj dostęp do danych wykresu.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Utwórz instancję skoroszytu Excel do pracy z danymi wykresu.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Uzyskaj dostęp do arkusza danych wykresu.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Ustaw zakres danych dla wykresu.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Zastosuj określony zakres do tabeli danych wykresu.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Ustaw wartości dla kategorii i odpowiednich danych serii.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Ustaw tytuł wykresu.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Uzyskaj dostęp do osi wartości wykresu.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Ustaw wartości jednostek osi.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Uzyskaj dostęp do osi głębokości wykresu.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Ustaw obrót wykresu.
ppChart.Rotation = 20;   // Wartość Y
ppChart.Elevation = 15;  // Wartość X
ppChart.RightAngleAxes = false;

// Zapisz prezentację jako plik PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Zamknij skoroszyt i prezentację.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Spróbuj uzyskać dostęp do własności Name. Jeśli zostanie zgłoszony wyjątek, uruchom nową instancję programu PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation jest używane, aby zapewnić, że prezentacja jest załadowana.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide jest używane, aby zapewnić, że w prezentacji znajduje się co najmniej jeden slajd.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

Wynik:

![Wykres utworzony przy użyciu VSTO](chart-created-using-VSTO.png)

## **Przykład Aspose.Slides dla .NET**

Poniższy przykład pokazuje, jak utworzyć prosty wykres w prezentacji PowerPoint przy użyciu Aspose.Slides dla .NET. Ten kod demonstruje, jak dodać **3D wykres kolumnowy grupowany**, wypełnić go przykładowymi danymi i dostosować jego wygląd. Dzięki kilku liniom kodu możesz dynamicznie generować wykresy i integrować je w swoich prezentacjach bez użycia Microsoft Office.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odniesienie do pierwszego slajdu.
1. Dodaj wykres kolumnowy grupowany 3D i uzyskaj do niego dostęp.
1. Uzyskaj dostęp do danych wykresu.
1. Usuń nieużywane Serie 2 i Serie 3.
1. Zmodyfikuj kategorie wykresu, aktualizując etykiety.
1. Zaktualizuj wartości Serii 1.
1. Uzyskaj dostęp do tytułu wykresu i ustaw jego właściwości czcionki.
1. Skonfiguruj oś wartości wykresu, w tym jednostkę główną, jednostkę podrzędną, wartości maksymalną i minimalną.
1. Ustaw kąty obrotu wykresu na osiach X i Y.
1. Zapisz prezentację w formacie PPTX.

```cs
// Utwórz pustą prezentację.
using (Presentation presentation = new Presentation())
{
    // Uzyskaj dostęp do pierwszego slajdu.
    ISlide slide = presentation.Slides[0];

    // Dodaj domyślny wykres.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Pobierz dane wykresu.
    IChartData chartData = chart.ChartData;

    // Usuń dodatkowe domyślne serie.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Zmień nazwy kategorii wykresu.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Ustaw indeks arkusza danych wykresu.
    int worksheetIndex = 0;

    // Pobierz skoroszyt danych wykresu.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Zmień wartości serii wykresu.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Ustaw tytuł wykresu.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Ustaw opcje osi.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Ustaw obrót wykresu.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Zapisz prezentację jako plik PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Wykres utworzony przy użyciu Aspose.Slides dla .NET](chart-created-using-aspose-slides.png)

## **FAQ**

**Czy mogę tworzyć inne typy wykresów, takie jak wykresy kołowe, liniowe lub słupkowe, przy użyciu Aspose.Slides?**

Tak. Aspose.Slides dla .NET obsługuje szeroką gamę [typów wykresów](/slides/pl/net/create-chart/), w tym wykresy kołowe, liniowe, słupkowe, wykresy rozrzutu, wykresy bąbelkowe i inne. Żądany typ wykresu można określić przy użyciu wyliczenia [ChartType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/charttype/) podczas dodawania wykresu.

**Czy mogę zastosować własne style lub motywy do wykresu?**

Tak. Możesz w pełni dostosować wygląd wykresu, w tym kolory, czcionki, wypełnienia, kontury, linie siatki i układ. Jednak zastosowanie motywów Office dokładnie tak, jak są widoczne w PowerPoint, wymaga ręcznego ustawiania poszczególnych stylów.

**Czy mogę wyeksportować wykres jako osobny obraz, niezależnie od slajdu?**

Tak, Aspose.Slides umożliwia wyeksportowanie dowolnego kształtu — w tym wykresów — jako osobnego obrazu (np. PNG, JPEG) przy użyciu metody `GetImage` na [kształcie](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) wykresu.