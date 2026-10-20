---
title: Vormen herschalen op presentatiedia's in .NET
type: docs
weight: 130
url: /nl/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /nl/net/re-sizing-shapes-on-slide/
keywords:
- vorm herschalen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas eenvoudig de grootte van vormen aan op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor .NET—automatiseer dia‑lay-outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer je de diaformaat van een presentatie wijzigt, moet je mogelijk ook de vormen aanpassen en verplaatsen zodat ze passen binnen de nieuwe afmetingen. Dit artikel laat zien hoe je vormen handmatig schaalt en hoe je tabellen op dia's, masters en lay-outs behandelt.

## **Vormen aanpassen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldig je de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia‑breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogterechtlijnverhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, wijzigt het diaformaat naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) met [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) zodat de daaropvolgende lus de schaal bepaalt. De verhoudingen zijn dimensieloos; posities en afmetingen van vormen worden gemeten in punten. Verschillende breedte‑ en hoogteverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Bereken onafhankelijke horizontale en verticale schaalfactoren.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Tabellen vereisen afzonderlijke verwerking: schaal de kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan gevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay-outs evenals op individuele dia's voordat de aangepaste presentatie wordt opgeslagen. De hulpfunctie verwerkt elk [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) door [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) en [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) te schalen. Daarna schaalt het de positie van de tabel zonder de totale afmetingen apart te schalen.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Bereken onafhankelijke horizontale en verticale schaalfactoren.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Pas de grootte van vormen aan die gedefinieerd zijn op masters en lay-outs, evenals op individuele dia's.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Tabelafmetingen worden bepaald door kolombreedtes en rijhoogtes.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **Veelgestelde vragen**

**Waarom worden vormen vervormd of afgesneden na het aanpassen van een dia?**

Als je het diaformaat wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan vormen eveneens vervormen.

**Werkt de meegeleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de vormgrenzen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld verwerkt tabellen apart. Controleer de resulterende lay-out, met name tekst en tabellen, omdat deze voorbeelden de lettergroottes niet schalen en de tabelinhoud de rijhoogtes kan beperken.

**Hoe schaalt ik tabellen bij het aanpassen van een dia?**

Schaal de kolombreedtes met de breedteverhouding en de minimale rijhoogtes met de hoogteverhouding, schaal vervolgens de positie van de tabel, zoals weergegeven in het tweede voorbeeld.

**Werkt deze aanpassing ook voor masterslides en lay-outslides?**

Ja. Het tweede voorbeeld doorloopt [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) en de [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) van elke master en past dezelfde aanpassingslogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (portret/landschap) wijzigen samen met het aanpassen?**

Ja. Stel [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) in na het wijzigen van het diaformaat en vóór het lezen van de doeldimensies, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

Je kunt aangepaste dia‑afmetingen opgeven met [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). De ondersteunde afmetingen hangen ook af van het presentatie‑formaat en de toepassing die het bestand opent.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormd worden?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay-out binnen de nieuwe dia‑afmetingen te laten passen, gebruik je de kleinste van de breedte‑ en hoogteverhoudingen voor beide dimensies en posities. Dit behoudt de verhoudingen, maar kan zorgen voor ongebruikte ruimte langs één rand.