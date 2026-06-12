---
title: Vormen schalen op presentatiedia's in .NET
type: docs
weight: 130
url: /nl/net/re-sizing-shapes-on-slide/
keywords:
- vorm schalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Gemakkelijk vormen schalen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor .NET - automatiseer dia-indelingaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Een van de meest voorkomende vragen van Aspose.Slides for .NET klanten is hoe ze vormen kunnen schalen zodat, wanneer de dia‑grootte verandert, de gegevens niet worden afgesneden. Dit korte technische artikel laat zien hoe je dat doet.

## **Vormen schalen**

Om te voorkomen dat vormen uit positie raken wanneer de dia‑grootte verandert, moet je de positie en afmetingen van elke vorm bijwerken zodat ze passen bij de nieuwe dia‑indeling.

```c#
// Laad het presentatiebestand.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Haal de oorspronkelijke dia-grootte op.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Verander de dia-grootte zonder de bestaande vormen te schalen.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Haal de nieuwe dia-grootte op.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Formaat en positie van vormen op elke dia aanpassen.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Schaal de vormgrootte.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Schaal de vormpositie.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Als een dia een tabel bevat, werkt de bovenstaande code niet correct. In dat geval moet elke cel in de tabel worden geschaald.
{{% /alert %}}

Gebruik de volgende code om dia's die tabellen bevatten te schalen. Voor tabellen is het instellen van de breedte of hoogte een speciaal geval: je moet de hoogtes van individuele rijen en de breedtes van kolommen aanpassen om de totale grootte van de tabel te wijzigen.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Haal de oorspronkelijke dia-grootte op.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Verander de dia-grootte zonder bestaande vormen te schalen.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Haal de nieuwe dia-grootte op.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Schaal de vormgrootte.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Schaal de vormpositie.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Schaal de vormgrootte.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Schaal de vormpositie.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Schaal de vormgrootte.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Schaal de vormpositie.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Veelgestelde vragen**

**Waarom zijn vormen vervormd of afgesneden na het schalen van een dia?**

Wanneer je een dia schaalt, behouden vormen hun oorspronkelijke positie en grootte tenzij de schaal expliciet wordt aangepast. Dit kan ertoe leiden dat inhoud wordt bijgesneden of dat vormen uit positie raken.

**Werkt de meegeleverde code voor alle type vormen?**

Het basisvoorbeeld werkt voor de meeste vormen (tekstvakken, afbeeldingen, grafieken, enz.). Voor tabellen moet je echter rijen en kolommen apart behandelen, omdat de hoogte en breedte van een tabel bepaald wordt door de afmetingen van de individuele cellen.

**Hoe schaalt ik tabellen bij het schalen van een dia?**

Je moet door alle rijen en kolommen van de tabel lopen en hun hoogte en breedte proportioneel aanpassen, zoals weergegeven in het tweede code‑voorbeeld.

**Werkt deze schaalmethode voor master‑dia's en lay‑outdia's?**

Ja, maar je moet ook door [Mastern](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/masters/) en [Lay-outdia's](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/layoutslides/) lopen en dezelfde schaallogica toepassen op hun vormen om consistentie door de volledige presentatie te waarborgen.

**Kan ik de oriëntatie van een dia (portret/landschap) wijzigen tegelijk met het schalen?**

Ja. Je kunt [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/orientation/) instellen om de oriëntatie te wijzigen. Zorg ervoor dat je de schaallogica dienovereenkomstig aanpast om de lay-out te behouden.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

Aspose.Slides ondersteunt aangepaste groottes, maar zeer grote afmetingen kunnen de prestaties beïnvloeden of de compatibiliteit met sommige versies van PowerPoint beperken.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd raken?**

Controleer de `AspectRatioLocked`‑eigenschap van de vorm voordat je schaalt. Als deze vergrendeld is, pas dan de breedte of hoogte proportioneel aan in plaats van ze afzonderlijk te schalen.