---
title: Spravovat SmartArt v prezentacích PowerPoint v .NET
linktitle: Spravovat SmartArt
type: docs
weight: 10
url: /cs/net/manage-smartart/
keywords:
- SmartArt
- Text SmartArtu
- typ rozvržení
- skrytá vlastnost
- organizační diagram
- obrázkový organizační diagram
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se vytvářet a upravovat SmartArt v PowerPointu pomocí Aspose.Slides pro .NET s přehlednými ukázkami kódu v C#, které urychlují návrh snímků a automatizaci."
---
## **Přehled**

SmartArt je diagram PowerPointu složený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro .NET můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, zkoumat skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet obrázkové organizační diagramy.

## **Získání textu z objektu SmartArt**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Chcete-li přečíst viditelný text, projděte [ISmartArt.AllNodes](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartart/allnodes/), poté přečtěte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) vrácený pomocí [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartartshape/textframe/).

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

## **Změna typu rozvržení objektu SmartArt**

Rozvržení SmartArt určuje, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, změní ji na hodnotu `BasicProcess` a uloží prezentaci.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Kontrola, zda je uzel SmartArt skrytý**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartartnode/ishidden/) naznačuje, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře, i když vybrané rozvržení nezobrazuje je jako viditelné prvky diagramu.

Následující příklad přidá uzel k objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, a zkontroluje skrytý stav uzlu.

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

## **Získání nebo nastavení rozvržení organizačního diagramu**

Pro diagramy SmartArt, které používají rozvržení organizačního diagramu, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) určuje, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit podřízené uzly, aby visely vlevo, vpravo nebo na obou stranách, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení pro první uzel na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

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

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt navržené pro hierarchické diagramy, které obsahují zástupné obrázky. Při přidávání objektu SmartArt na snímek použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo obrácení pro jazyky RTL?**

Ano. Vlastnost [IsReversed](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartart/isreversed/) přepíná směr diagramu z zleva‑doprava na zprava‑doleva, nebo zpět, pokud vybrané rozvržení SmartArt podporuje obrácení.

**Jak mohu zkopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/net/shape-manipulations/) pomocí [ShapeCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/shapecollection/addclone/) nebo [klonovat celý snímek](/slides/cs/net/clone-slides/), který SmartArt obsahuje. Obě metody zachovávají velikost, pozici a formátování.

**Jak vykreslím SmartArt do rastrového obrázku pro náhled nebo webový export?**

[Vykreslete snímek](/slides/cs/net/convert-powerpoint-to-png/) nebo celou prezentaci do PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Nastavte jedinečný [AlternativeText](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/alternativetext/) nebo [Name](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/name/) na tvar SmartArt, vyhledejte tuto hodnotu v [Slide.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslide/shapes/), a poté ověřte, že odpovídající tvar je [ISmartArt](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/ismartart/).