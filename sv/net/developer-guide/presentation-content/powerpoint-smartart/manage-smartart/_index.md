---
title: Hantera SmartArt i PowerPoint-presentationer i .NET
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/net/manage-smartart/
keywords:
- SmartArt
- SmartArt-text
- layouttyp
- dold egenskap
- organisationsschema
- bildorganisationsschema
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig att skapa och redigera PowerPoint SmartArt med Aspose.Slides för .NET med tydliga C#-kodexempel som påskyndar bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint-diagram som består av noder, nodformer och en layout. Med Aspose.Slides för .NET kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, undersöka dolda noder, konfigurera organisationsschemalayouter och skapa bild‑organisationsscheman.

## **Hämta text från ett SmartArt‑objekt**

En SmartArt‑nod kan innehålla en eller flera former. För att läsa den synliga texten, iterera genom [ISmartArt.AllNodes](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/ismartart/allnodes/), och läs sedan [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) som returneras av [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/ismartartshape/textframe/).

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

## **Ändra layouttypen för ett SmartArt‑objekt**

SmartArt‑layouten styr hur noder ordnas och kopplas ihop. Följande exempel skapar ett SmartArt‑objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`‑värdet, ändrar det till `BasicProcess`‑värdet och sparar presentationen.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Kontrollera om en SmartArt‑nod är dold**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/ismartartnode/ishidden/) visar om noden är dold i SmartArt‑datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramelement.

Följande exempel lägger till en nod i ett SmartArt‑objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`‑värdet och kontrollerar nodens dolda status.

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

## **Hämta eller ange organisationsschemalayout**

För SmartArt‑diagram som använder en organisationsschemalayout definierar [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) hur barnnoder ordnas under en föräldranod. Till exempel kan du ange att barnnoder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/organizationchartlayouttype/).

Följande exempel skapar ett organisationsschema och anger layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`‑värdet.

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

## **Skapa ett bild‑organisationsschema**

Ett bild‑organisationsschema är en SmartArt‑layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart`‑värdet när du lägger till SmartArt‑objektet på en bild.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Stöder SmartArt spegling eller omvändning för RTL-språk?**

Ja. Egenskapen [IsReversed](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/smartart/isreversed/) byter diagramriktning från vänster‑till‑höger till höger‑till‑vänster, eller tillbaka, när den valda SmartArt‑layouten stödjer omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/net/shape-manipulations/) med [ShapeCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/shapecollection/addclone/) eller [klona hela bilden](/slides/sv/net/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbuttag?**

[Rendera bilden](/slides/sv/net/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt‑objekt på en bild om det finns flera?**

Ange ett distinkt [AlternativeText](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/alternativetext/)‑ eller [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/name/)‑värde på SmartArt‑formen, sök efter det värdet i [Slide.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides/baseslide/shapes/), och kontrollera sedan att den matchande formen är ett [ISmartArt](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/ismartart/).