---
title: "Vormen verkleinen op presentatiedia's in .NET"
type: docs
weight: 130
url: /nl/net/re-sizing-shapes-on-slide/
keywords:
- vorm verkleinen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Verklein gemakkelijk vormen op PowerPoint- en OpenDocument-dias met Aspose.Slides voor .NET--automatiseer dia lay‑outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Een van de meest voorkomende vragen van Aspose.Slides voor .NET‑klanten is hoe vormen te verkleinen zodat, wanneer de dia‑grootte verandert, de gegevens niet worden afgesneden. Dit korte technische artikel laat zien hoe u dat kunt doen.

## **Vormen verkleinen**

Om te voorkomen dat vormen scheef komen te staan wanneer de dia‑grootte verandert, werkt u de positie en afmetingen van elke vorm bij zodat ze passen bij de nieuwe dia‑indeling.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Laad het presentatiebestand.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Haal de oorspronkelijke dia‑grootte op.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Verander de dia‑grootte zonder bestaande vormen te schalen.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Haal de nieuwe dia‑grootte op.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Verklein en verplaats vormen op elke dia.
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

{{% alert color="info" %}}
Als een dia een tabel bevat, werkt de bovenstaande code niet correct. In dat geval moet elke cel in de tabel worden verkleind.
{{% /alert %}}

Gebruik de volgende code aan uw kant om dia's die tabellen bevatten te verkleinen. Voor tabellen schaalt u de individuele rijhoogtes en kolombreedtes in plaats van de breedte en hoogte van de vorm—als u beide schaalt, wordt de tabel tweemaal geschaald en schuift hij van de dia.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
            if (shape is ITable)
            {
                // Schaal de tabelgrootte via de rijen en kolommen.
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
            else
            {
                // Schaal de vormgrootte.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Schaal de vormpositie.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Veelgestelde vragen**

### Waarom zijn vormen vervormd of afgeknipt na het verkleinen van een dia?

Bij het verkleinen van een dia behouden vormen hun oorspronkelijke positie en grootte tenzij de schaal expliciet wordt aangepast. Dit kan ertoe leiden dat inhoud wordt bijgesneden of dat vormen scheef komen te staan.

### Werkt de meegeleverde code voor alle type vormen?

Het basisvoorbeeld werkt voor de meeste vormtypen (tekstvakken, afbeeldingen, diagrammen, enz.). Voor tabellen moet u echter rijen en kolommen apart behandelen, omdat de hoogte en breedte van een tabel worden bepaald door de afmetingen van de individuele cellen.

### Hoe verklein ik tabellen bij het verkleinen van een dia?

U moet door alle rijen en kolommen van de tabel itereren en hun hoogte en breedte evenredig aanpassen, zoals getoond in het tweede code‑voorbeeld.

### Werkt deze verkleining voor master‑dia's en layout‑dia's?

Ja, maar u moet ook door [Masters](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/masters/) en [LayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/layoutslides/) itereren en dezelfde schaallogica op hun vormen toepassen om consistentie door de hele presentatie te waarborgen.

### Kan ik de oriëntatie van een dia (portret/landscape) wijzigen samen met het verkleinen?

Ja. U kunt [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/nl/net/aspose.slides/islidesize/orientation/) instellen om de oriëntatie te wijzigen. Zorg ervoor dat u de schaallogica dienovereenkomstig aanpast om de lay‑out te behouden.

### Is er een limiet aan de dia‑grootte die ik kan instellen?

Aspose.Slides ondersteunt aangepaste formaten, maar zeer grote afmetingen kunnen de prestaties of de compatibiliteit met sommige versies van PowerPoint beïnvloeden.

### Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormen?

U kunt de eigenschap `AspectRatioLocked` van de vorm controleren vóór het schalen. Als deze vergrendeld is, past u de breedte of hoogte evenredig aan in plaats van ze afzonderlijk te schalen.