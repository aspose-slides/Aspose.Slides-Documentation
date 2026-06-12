---
title: SmartArt beheren in PowerPoint-presentaties in .NET
linktitle: SmartArt beheren
type: docs
weight: 10
url: /nl/net/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organigram
- picture-organigram
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint‑SmartArt kunt bouwen en bewerken met Aspose.Slides voor .NET aan de hand van heldere C#‑codevoorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint-diagram dat bestaat uit knooppunten, knooppuntvormen en een lay-out. Met Aspose.Slides for .NET kunt u SmartArt maken, tekst lezen van de knooppunten, de lay-out wijzigen, verborgen knooppunten inspecteren, lay-outs voor organigrammen configureren en picture‑organigrammen maken.

## **Tekst ophalen van een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meer vormen bevatten. Om de zichtbare tekst te lezen, doorloop [ISmartArt.AllNodes](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartart/allnodes/), lees vervolgens het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) dat wordt geretourneerd door [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Lay-outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay-out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartartlayouttype/)‑waarde `BasicBlockList`, wijzigt deze naar de waarde `BasicProcess` en slaat de presentatie op.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartartnode/ishidden/) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de geselecteerde lay-out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartartlayouttype/)‑waarde `RadialCycle` gebruikt en controleert de verborgenstatus van het knooppunt.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Lay-out voor organigram ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑lay-out gebruiken, definieert [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) hoe kindknooppunten onder een ouderknooppunt worden gerangschikt. U kunt bijvoorbeeld kindknooppunten laten hangen aan de linker-, rechter- of beide kanten, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organigram en stelt de lay-out voor het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/organizationchartlayouttype/)‑waarde `LeftHanging`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Een picture‑organigram maken**

Een picture‑organigram is een SmartArt‑lay-out ontworpen voor hiërarchiediagrammen die afbeeldingsplaatsaanduidingen bevatten. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartartlayouttype/)‑waarde `PictureOrganizationChart` bij het toevoegen van het SmartArt‑object aan een dia.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De eigenschap [IsReversed](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartart/isreversed/) schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links (of terug), wanneer de geselecteerde SmartArt‑lay-out omkering ondersteunt.

**Hoe kan ik SmartArt naar dezelfde dia of naar een andere presentatie kopiëren terwijl de opmaak behouden blijft?**

U kunt de SmartArt‑vorm [klonen](/slides/nl/net/shape-manipulations/) met [ShapeCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/shapecollection/addclone/) of de hele dia [klonen](/slides/nl/net/clone-slides/) die de SmartArt bevat. Beide benaderingen behouden grootte, positie en opmaak.

**Hoe rendere ik SmartArt naar een rasterafbeelding voor voorbeeld of web‑export?**

[Render de dia](/slides/nl/net/convert-powerpoint-to-png/) of de hele presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere zijn?**

Geef de SmartArt‑vorm een onderscheidende [AlternativeText](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/alternativetext/)‑ of [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/name/)‑waarde, zoek die waarde in [Slide.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslide/shapes/), en controleer vervolgens of de overeenkomstige vorm een [ISmartArt](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartart/) is.