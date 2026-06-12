---
title: Grafieklegenda's aanpassen in presentaties in .NET
linktitle: Grafieklegenda
type: docs
url: /nl/net/chart-legend/
keywords:
- grafieklegenda
- positie van de legenda
- lettergrootte
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas grafieklegenda's aan met Aspose.Slides voor .NET om PowerPoint-presentaties te optimaliseren met op maat gemaakte legendavormgeving."
---
## **Overzicht**

Aspose.Slides biedt opties om de legenda van grafieken in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe u de positie en grootte van een legenda kunt instellen, de lettergrootte voor de volledige legenda kunt bepalen en opmaak kunt toepassen op een enkel legendaitem.

Het behandelt ook verschillende gerelateerde aspecten in de FAQ, waaronder het gebruik van de niet‑overlegmodus zodat het plotgebied ruimte maakt voor de legenda, het laten afbreken of gebruiken van regeleinden voor lange legendalabels, en het laten erven van de legendavormgeving vanuit het presentatiethema wanneer er geen expliciete tekst‑ en vulinstellingen worden opgegeven.

## **Legenda‑positionering**
Om de legendaproperties in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
- Haal een referentie op van de dia.
- Voeg een grafiek toe aan de dia.
- Stel de eigenschappen van de legenda in.
- Schrijf de presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we de positie en grootte van de grafieklegenda ingesteld.

```c#
// Maak een instantie van de Presentation-klasse
Presentation presentation = new Presentation();

// Verkrijg een referentie naar de dia
ISlide slide = presentation.Slides[0];

// Voeg een gegroepeerde kolomgrafiek toe aan de dia
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Stel legenda-eigenschappen in
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Schrijf de presentatie naar schijf
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **Lettergrootte van een legenda instellen**
Aspose.Slides for .NET maakt het mogelijk om de lettergrootte van de legenda in te stellen. Volg de onderstaande stappen:

- Instantieer de `Presentation`‑klasse.
- Maak de standaardgrafiek aan.
- Stel de lettergrootte in.
- Stel de minimumaswaarde in.
- Stel de maximumaswaarde in.
- Schrijf de presentatie naar schijf.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Lettergrootte van een individueel legendaitem instellen**
Aspose.Slides for .NET maakt het mogelijk om de lettergrootte van individuele legendaitems in te stellen. Volg de onderstaande stappen:

- Instantieer de `Presentation`‑klasse.
- Maak de standaardgrafiek aan.
- Toegang tot legendaitem.
- Stel de lettergrootte in.
- Stel de minimumaswaarde in.
- Stel de maximumaswaarde in.
- Schrijf de presentatie naar schijf.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik de legenda inschakelen zodat de grafiek automatisch ruimte voor de legenda reserveert in plaats van deze te overlappen?**

Ja. Gebruik de niet‑overlegmodus ([Overlay](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/legend/overlay/)=`false`); in dit geval zal het plotgebied krimpen om de legenda te herbergen.

**Kan ik meerregelige legendalabels maken?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via newline‑tekens in de serienaam.

**Hoe laat ik de legenda de kleuren van het presentatiethema volgen?**

Stel geen expliciete kleuren, vullingen of lettertypen in voor de legenda of de tekst ervan. Ze erven dan van het thema en worden correct bijgewerkt wanneer het ontwerp verandert.