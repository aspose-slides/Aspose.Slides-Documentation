---
title: Optimaliseer grafiekberekeningen voor presentaties in .NET
linktitle: Grafiekberekeningen
type: docs
weight: 50
url: /nl/net/chart-calculations/
keywords:
- grafiekberekeningen
- grafiekelementen
- elementpositie
- werkelijke positie
- kindelement
- ouderelement
- grafiekwaarden
- werkelijke waarde
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Begrijp grafiekberekeningen, gegevensupdates en precisiebeheer in Aspose.Slides voor .NET voor PPT en PPTX, met praktische C# code‑voorbeelden."
---
## **Overzicht**

Aspose.Slides biedt API's voor het werken met grafiekberekeningen en layout‑gegevens in presentaties. Dit artikel laat zien hoe u de werkelijke waarden van grafiekelementen kunt opvragen, inclusief de exacte positie en grootte van elementen die `IActualLayout` implementeren en de werkelijke waarden van grafiekassen. Het legt ook uit dat deze waarden worden ingevuld nadat de grafieklayout is gevalideerd.

Bovendien toont het artikel hoe u de feitelijke positie van bovenliggende grafiekelementen kunt verkrijgen en hoe u grafiekonderdelen zoals de titel, assen, legenda en rasterlijnen kunt verbergen. Samen helpen deze voorbeelden u om lay‑outinformatie van grafieken te inspecteren en de zichtbaarheid van grafiekelementen in PowerPoint‑presentaties programmatisch te beheren.

## **Werkelijke waarden van grafiekelementen berekenen**
Aspose.Slides for .NET biedt een eenvoudige API om deze eigenschappen op te halen. Dit helpt u de werkelijke waarden van grafiekelementen te berekenen. De werkelijke waarden omvatten de positie van elementen die de IActualLayout‑interface implementeren (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) en de werkelijke aswaarden (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Presentatie opslaan
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Werkelijke positie van bovenliggende grafiekelementen berekenen**
Aspose.Slides for .NET biedt een eenvoudige API om deze eigenschappen op te halen. De eigenschappen van IActualLayout geven informatie over de feitelijke positie van het bovenliggende grafiekelement. Het is noodzakelijk om eerst de methode IChart.ValidateChartLayout() aan te roepen zodat de eigenschappen worden gevuld met werkelijke waarden.

```c#
// Lege presentatie maken
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

## **Grafiekelementen verbergen**
Dit onderwerp helpt u te begrijpen hoe u informatie in een grafiek kunt verbergen. Met Aspose.Slides for .NET kunt u **Titel, verticale as, horizontale as** en **rasterlijnen** uit de grafiek verbergen. De onderstaande code‑voorbeeld toont hoe u deze eigenschappen gebruikt.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // Grafiektitel verbergen
    chart.HasTitle = false;

    /// Waardenas verbergen
    chart.Axes.VerticalAxis.IsVisible = false;

    // Zichtbaarheid van categorisatie-as
    chart.Axes.HorizontalAxis.IsVisible = false;

    // Legenda verbergen
    chart.HasLegend = false;

    // Hoofd rasterlijnen verbergen
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

    // Lijnkleur van serie instellen
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Werken externe Excel‑werkboeken als gegevensbron en hoe beïnvloedt dat de herberekening?**

Ja. Een grafiek kan een extern werkboek refereren: wanneer u de externe bron aansluit of verversen, worden formules en waarden uit dat werkboek gehaald, en de grafiek geeft de updates weer tijdens openen/bewerken. De API laat u [de externe werkboek]https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/setexternalworkbook/ specificeren en de gekoppelde gegevens beheren.

**Kan ik trendlijnen berekenen en weergeven zonder zelf regressie te implementeren?**

Ja. [Trendlijnen](/slides/nl/net/trend-line/) (lineair, exponentieel en andere) worden door Aspose.Slides toegevoegd en bijgewerkt; hun parameters worden automatisch herberekend op basis van de seriedata, zodat u geen eigen berekeningen hoeft te implementeren.

**Als een presentatie meerdere grafieken met externe koppelingen bevat, kan ik bepalen welk werkboek elke grafiek gebruikt voor berekende waarden?**

Ja. Elke grafiek kan naar zijn eigen [externe werkboek]https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/setexternalworkbook/ wijzen, of u kunt per grafiek een extern werkboek maken/vervangen, onafhankelijk van de andere.