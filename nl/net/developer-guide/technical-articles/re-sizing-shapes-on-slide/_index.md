---
title: Vormen verkleinen op presentatiedia's in .NET
type: docs
weight: 130
url: /nl/net/resizing-shapes-on-slide/
aliases:
  - /nl/net/re-sizing-shapes-on-slide/
  /net/re-sizing-shapes-on-slide/
keywords:
- vorm verkleinen
- vormgrootte wijzigen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Verklein gemakkelijk vormen op PowerPoint- en OpenDocument-dia's met Aspose.Slides voor .NET - automatiseer dia‑lay‑outaanpassingen en verhoog de productiviteit."
---
## **Overzicht**

Wanneer u de diaformaat van een presentatie wijzigt, moet u mogelijk ook de vormen verkleinen en opnieuw positioneren zodat ze passen binnen de nieuwe afmetingen. Dit artikel toont hoe u vormen handmatig kunt schalen en hoe u tabellen op dia's, masters en lay‑outs kunt behandelen.

## **Vormen verkleinen**

Om de relatieve positie en grootte van elke vorm te behouden, vermenigvuldigt u de horizontale coördinaten en de breedte met de verhouding van de nieuwe dia‑breedte ten opzichte van de oorspronkelijke breedte. Pas de overeenkomstige hoogteverhouding toe op de verticale coördinaten en de hoogte.

Het eerste voorbeeld laadt een presentatie waarvan de dia's geen tabellen bevatten, verandert de dia‑grootte naar A4 en slaat het resultaat op. Het gebruikt [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) met [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) zodat de daaropvolgende lus de schaal bepaalt. De verhoudingen zijn eenheidsloos; vormposities en -afmetingen worden gemeten in punten. Verschillende breedte‑ en hoogteverhoudingen kunnen vormen vervormen, en het wijzigen van de afmetingen van een vorm schaalt de lettergroottes niet.

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
Tabellen vereisen afzonderlijke verwerking: schaal hun kolombreedtes en rijhoogtes in plaats van de totale breedte en hoogte van de tabel toe te wijzen. Rijhoogtes kunnen groter blijven dan aangevraagd als de celinhoud meer ruimte nodig heeft.
{{% /alert %}}

Het tweede voorbeeld ondersteunt tabellen en verwerkt vormen op masters en lay‑outs, evenals individuele dia's, vóór het opslaan van de verkleinde presentatie. De helper behandelt elke [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) door [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) en [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) te schalen. Vervolgens schaalt hij de positie van de tabel zonder de totale afmetingen apart te schalen.

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

// Schaal vormen die gedefinieerd zijn op masters en lay‑outs evenals individuele dia's.
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
            // Tabelafmetingen worden gecontroleerd door kolombreedtes en rijhoogtes.
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

## **FAQ**

**Waarom zijn vormen vervormd of afgesneden na het verkleinen van een dia?**

Als u de dia‑grootte wijzigt zonder de vormen te schalen, behouden ze hun oorspronkelijke posities en afmetingen en kunnen ze buiten de dia uitsteken. Het schalen van breedte en hoogte met verschillende verhoudingen kan ook vormen vervormen.

**Werkt de geleverde code voor alle vormtypen?**

Het eerste voorbeeld wijzigt de grenzen van vormen direct en is bedoeld voor dia's zonder tabellen. Het tweede voorbeeld behandelt tabellen afzonderlijk. Controleer de resulterende lay‑out, met name tekst en tabellen, omdat deze voorbeelden geen lettergroottes schalen en tabelinhoud de rijhoogtes kan beperken.

**Hoe kan ik tabellen verkleinen bij het verkleinen van een dia?**

Schaal kolombreedtes met de breedteverhouding en minimale rijhoogtes met de hoogteverhouding, en schaal vervolgens de positie van de tabel, zoals weergegeven in het tweede voorbeeld.

**Zal dit verkleinen werken voor masterdia's en lay‑outdia's?**

Ja. Het tweede voorbeeld doorloopt [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) en elke [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) van de master en past dezelfde verkleinlogica toe op hun vormen.

**Kan ik de oriëntatie van een dia (portret/landscape) wijzigen tegelijk met het verkleinen?**

Ja. Stel [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) in nadat u de dia‑grootte hebt gewijzigd en voordat u de doelafmetingen leest, zodat de schaalfactoren de uiteindelijke oriëntatie weerspiegelen.

**Is er een limiet aan de dia‑grootte die ik kan instellen?**

U kunt aangepaste dia‑afmetingen opgeven met [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). De ondersteunde afmetingen zijn ook afhankelijk van het presentatieformaat en de applicatie die wordt gebruikt om het bestand te openen.

**Hoe kan ik voorkomen dat vormen met een vaste beeldverhouding vervormen?**

Gebruik dezelfde schaalfactor voor breedte en hoogte. Om de oorspronkelijke lay‑out binnen de nieuwe dia‑afmetingen te laten passen, gebruikt u de kleinste van de breedte‑ en hoogteverhoudingen voor zowel afmetingen als posities. Dit behoudt de verhoudingen, maar kan onbenutte ruimte langs één rand achterlaten.