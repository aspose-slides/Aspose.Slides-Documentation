---
title: Beheer grafiekgegevensseries in presentaties in .NET
linktitle: Gegevensseries
type: docs
url: /nl/net/chart-series/
keywords:
- grafiekserie
- serie-overlap
- serie-kleur
- categorie-kleur
- serie-naam
- datumpunt
- serie-gap
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe je grafiekseries beheert in C# voor PowerPoint (PPT/PPTX) met praktische codevoorbeelden en best practices om je gegevenspresentaties te verbeteren."
---
## **Overzicht**

Dit artikel beschrijft de rol van [ChartSeries](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartseries/) in Aspose.Slides voor .NET, met focus op hoe gegevens worden gestructureerd en gevisualiseerd binnen presentaties. Deze objecten vormen de basis elementen die individuele sets van gegevenspunten, categorieën en weergave‑parameters in een diagram definiëren. Door met [ChartSeries](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartseries/) te werken, kunnen ontwikkelaars onderliggende gegevensbronnen naadloos integreren en volledige controle behouden over hoe informatie wordt weergegeven, wat resulteert in dynamische, data‑gedreven presentaties die inzichten en analyses helder overbrengen.

Een serie is een rij of kolom met getallen die in een grafiek worden weergegeven.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de overlap van de grafiekserie**

De [IChartSeriesOverlap](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/properties/overlap) eigenschap bepaalt hoe balken en kolommen overlappen in een 2D‑diagram door een bereik van -100 tot 100 op te geven. Omdat deze eigenschap gekoppeld is aan de serie‑groep en niet aan individuele grafiekseries, is hij alleen‑lezen op serieniveau. Om overlappingswaarden te configureren, gebruik je de `ParentSeriesGroup.Overlap` lees‑/schrijf‑eigenschap, die de opgegeven overlap toepast op alle series in die groep.

Hieronder staat een C#‑voorbeeld dat laat zien hoe je een presentatie maakt, een gegroepeerde kolomgrafiek toevoegt, de eerste grafiekserie benadert, de overlap‑instelling configureert en vervolgens het resultaat opslaat als een PPTX‑bestand:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een gegroepeerde kolomgrafiek toe met standaardgegevens.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Stel de overlap van de serie in.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Sla het presentatiebestand op naar schijf.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De overlap van de series](series_overlap.png)

## **Wijzig de vulkleur van de serie**

Aspose.Slides maakt het eenvoudig om de vulkleuren van grafiekseries aan te passen, waardoor je specifieke gegevenspunten kunt accentueren en visueel aantrekkelijke diagrammen kunt creëren. Dit gebeurt via het [IFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/iformat/) object, dat diverse vultypes, kleurconfiguraties en andere geavanceerde stijlopties ondersteunt. Nadat je een grafiek aan een dia hebt toegevoegd en de gewenste serie hebt benaderd, haal je de serie op en pas je de juiste vulkleur toe. Naast effen vullingen kun je ook verlopen of patroonvullingen gebruiken voor extra ontwerp‑flexibiliteit. Zodra je de kleuren volgens je vereisten hebt ingesteld, sla je de presentatie op om de bijgewerkte weergave te bevestigen.

Het volgende C#‑codevoorbeeld toont hoe je de kleur van de eerste serie wijzigt:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een gegroepeerde kolomgrafiek toe met standaardgegevens.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Stel de kleur van de eerste serie in.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Sla het presentatiebestand op naar schijf.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De kleur van de serie](series_color.png)

## **Wijzig de naam van de serie**

Aspose.Slides biedt een eenvoudige manier om de namen van grafiekseries te wijzigen, waardoor het makkelijker wordt om gegevens duidelijk en betekenisvol te labelen. Door de relevante werkbladcel in de diagramgegevens te benaderen, kunnen ontwikkelaars aanpassen hoe de data wordt gepresenteerd. Deze wijziging is vooral nuttig wanneer serienamen moeten worden bijgewerkt of verduidelijkt op basis van de context van de gegevens. Na het hernoemen van de serie kan de presentatie worden opgeslagen om de wijzigingen te bewaren.

Hieronder staat een C#‑codefragment dat dit proces in actie laat zien.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een gegroepeerde kolomgrafiek toe met standaardgegevens.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Stel de naam van de eerste serie in.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Sla het presentatiebestand op naar schijf.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Het volgende C#‑codevoorbeeld laat een alternatieve manier zien om de serienaam te wijzigen:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een gegroepeerde kolomgrafiek toe met standaardgegevens.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Stel de naam van de eerste serie in.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Sla het presentatiebestand op naar schijf.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De serienaam](series_name.png)

## **Haal de automatische vulkleur van de serie op**

Aspose.Slides voor .NET stelt je in staat de automatische vulkleur voor grafiekseries binnen een plot‑gebied op te halen. Nadat je een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse hebt gemaakt, kun je de gewenste dia op index verkrijgen en een diagram toevoegen met het type dat je verkiest (bijvoorbeeld `ChartType.ClusteredColumn`). Door de series in het diagram te benaderen, kun je de automatische vulkleur verkrijgen.

De C#‑code hieronder toont dit proces gedetailleerd.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Voeg een gegroepeerde kolomgrafiek toe met standaardgegevens.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Haal de vulkleur van de serie op.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Uitvoer:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Stel omgekeerde vulkleur in voor een grafiekserie**

Wanneer je gegevensserie zowel positieve als negatieve waarden bevat, kan het kleuren van elke kolom of balk op dezelfde manier het diagram moeilijk leesbaar maken. Aspose.Slides voor .NET laat je een omgekeerde vulkleur toewijzen — een aparte vulkleur die automatisch wordt toegepast op datapunten die onder nul liggen — zodat negatieve waarden in één oogopslag opvallen. In dit gedeelte leer je hoe je die optie inschakelt, een geschikte kleur kiest en de bijgewerkte presentatie opslaat.

Het volgende code‑voorbeeld demonstreert de werking:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Voeg nieuwe categorieën toe.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Voeg een nieuwe serie toe.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Vul de seriedata.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Stel de kleurinstellingen voor de serie in.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De omgekeerde effen vulkleur](inverted_solid_fill_color.png)

Je kunt de vulkleur voor één enkel datumpunt in plaats van de hele serie omkeren. Benader simpelweg het gewenste `IChartDataPoint` en stel de `InvertIfNegative` eigenschap in op true.

Het volgende code‑voorbeeld laat zien hoe je dit doet:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Keer de kleur om wanneer het datumpunt op index 2 negatief is.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Wis specifieke waarden van datapunten**

Soms bevat een diagram testwaarden, uitschieters of verouderde items die je moet verwijderen zonder de hele serie opnieuw op te bouwen. Aspose.Slides voor .NET laat je elk datumpunt op index richten, de inhoud ervan wissen en de plot direct vernieuwen zodat de resterende punten verschuiven en de assen automatisch opnieuw schalen.

Het volgende code‑voorbeeld toont de bewerking:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Instellen van de gatbreedte van de serie**

De gatbreedte bepaalt de hoeveelheid lege ruimte tussen aangrenzende kolommen of balken — grotere gaten benadrukken afzonderlijke categorieën, terwijl kleinere gaten een dichter, compacter uiterlijk geven. Met Aspose.Slides voor .NET kun je deze parameter voor een volledige serie fijn afstellen, zodat je precies de visuele balans verkrijgt die je presentatie vereist zonder de onderliggende gegevens te wijzigen.

Het volgende code‑voorbeeld laat zien hoe je de gatbreedte voor een serie instelt:

```cs
ushort gapWidth = 30;

// Maak een lege presentatie.
using (Presentation presentation = new Presentation())
{
    // Benader de eerste dia.
    ISlide slide = presentation.Slides[0];

    // Voeg een diagram toe met standaardgegevens.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Sla de presentatie op naar schijf.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Stel de GapWidth‑waarde in.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Sla de presentatie op naar schijf.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![De gatbreedte](gap_width.png)

## **Veelgestelde vragen**

**Is er een limiet aan hoeveel series een enkele grafiek kan bevatten?**

Aspose.Slides legt geen vaste limiet op aan het aantal series dat je toevoegt. De praktische grens wordt bepaald door de leesbaarheid van het diagram en door het beschikbare geheugen van je applicatie.

**Wat als de kolommen binnen een cluster te dicht bij elkaar of te ver uit elkaar staan?**

Pas de `GapWidth` instelling voor die serie (of de bovenliggende serie‑groep) aan. Een hogere waarde vergroot de ruimte tussen kolommen, een lagere waarde brengt ze dichter bij elkaar.