---
title: Plotgebieden van presentatiediagrammen aanpassen in .NET
linktitle: Plotgebied
type: docs
url: /nl/net/chart-plot-area/
keywords:
- diagram
- plotgebied
- breedte van plotgebied
- hoogte van plotgebied
- grootte van plotgebied
- lay-out-modus
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van diagrammen in PowerPoint-presentaties kunt aanpassen met Aspose.Slides voor .NET. Verbeter moeiteloos de visuele presentatie van uw dia's."
---
## **Overzicht**

Dit artikel laat zien hoe u met het plot‑gebied van een grafiek in Aspose.Slides kunt werken. Het legt uit hoe u de daadwerkelijke positie en afmeting van het plot‑gebied kunt verkrijgen door de grafiek‑lay‑out te valideren en vervolgens de X‑, Y‑, breedte‑ en hoogte‑waarden uit te lezen.

Het toont ook hoe u de lay‑out‑modus van het plot‑gebied kunt configureren wanneer de lay‑out handmatig wordt ingesteld, met behulp van `LayoutTargetType` om te bepalen of het plot‑gebied wordt berekend op basis van het binnenste gedeelte of van het buitenste gedeelte, inclusief assen en as‑labels.

## **Breedte en hoogte van een grafiek‑plot‑gebied ophalen**
Aspose.Slides voor .NET biedt een eenvoudige API voor .

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
1. Open de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Roep de methode IChart.ValidateChartLayout() aan voordat u de werkelijke waarden opvraagt.
1. Haalt de werkelijke X‑positie (links) van het grafiekelement op ten opzichte van de linkerbovenhoek van de grafiek.
1. Haalt de werkelijke bovenkant van het grafiekelement op ten opzichte van de linkerbovenhoek van de grafiek.
1. Haalt de werkelijke breedte van het grafiekelement op.
1. Haalt de werkelijke hoogte van het grafiekelement op.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Presentatie opslaan met diagram
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **De lay‑out‑modus van een grafiek‑plot‑gebied instellen**
Aspose.Slides voor .NET biedt een eenvoudige API om de lay‑out‑modus van het plot‑gebied van een grafiek in te stellen. Eigenschap **LayoutTargetType** is toegevoegd aan de klassen **ChartPlotArea** en **IChartPlotArea**. Als de lay‑out van het plot‑gebied handmatig wordt gedefinieerd, geeft deze eigenschap aan of het plot‑gebied wordt gelayout op basis van de binnenkant (exclusief assen en as‑labels) of buitenkant (inclusief assen en as‑labels). Er zijn twee mogelijke waarden die zijn gedefinieerd in de **LayoutTargetType**‑enum.

- **LayoutTargetType.Inner** – geeft aan dat de grootte van het plot‑gebied de grootte van het plot‑gebied bepaalt, exclusief de tick‑markeringen en as‑labels.
- **LayoutTargetType.Outer** – geeft aan dat de grootte van het plot‑gebied de grootte van het plot‑gebied, de tick‑markeringen en de as‑labels bepaalt.

Voorbeeldcode staat hieronder.

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

**In welke eenheden worden ActualX, ActualY, ActualWidth en ActualHeight geretourneerd?**

In punten; 1 inch = 72 punten. Dit zijn de coördinaateenheden van Aspose.Slides.

**Hoe verschilt het plot‑gebied van het grafiek‑gebied qua inhoud?**

Het plot‑gebied is het tekengebied voor de gegevens (reeksen, rasterlijnen, trendlijnen, enz.); het grafiek‑gebied omvat de omringende elementen (titel, legenda, enz.). Bij 3D‑grafieken omvat het plot‑gebied ook de wanden/vloer en de assen.

**Hoe worden de X‑, Y‑, breedte‑ en hoogte‑waarden van het plot‑gebied geïnterpreteerd wanneer de lay‑out handmatig is?**

Het zijn fracties (0–1) van de totale grootte van de grafiek; in deze modus is automatisch positioneren uitgeschakeld en worden de ingestelde fracties toegepast.

**Waarom veranderde de positie van het plot‑gebied na het toevoegen/verplaatsen van de legenda?**

De legenda bevindt zich in het grafiek‑gebied buiten het plot‑gebied, maar beïnvloedt de lay‑out en de beschikbare ruimte, waardoor het plot‑gebied kan verschuiven wanneer automatisch positioneren actief is. (Dit is het standaardgedrag van PowerPoint‑grafieken.)