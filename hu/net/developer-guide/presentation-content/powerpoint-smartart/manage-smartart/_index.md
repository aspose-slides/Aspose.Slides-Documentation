---
title: SmartArt kezelése PowerPoint prezentációkban .NET-ben
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/net/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezés típusa
- rejtett tulajdonság
- szervezeti diagram
- képes szervezeti diagram
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan építhet és szerkeszthet PowerPoint SmartArt-ot az Aspose.Slides for .NET segítségével, világos C# kódpéldákkal, amelyek felgyorsítják a dia tervezését és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint-diagram, amely csomópontokból, csomópont alakzatokból és egy elrendezésből áll. Az Aspose.Slides for .NET segítségével létrehozhat SmartArt-ot, olvashat szöveget a csomópontjaitól, megváltoztathatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti diagram elrendezéseket, és létrehozhat képes szervezeti diagramokat.

## **Szöveg lekérése SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A látható szöveg olvasásához iteráljon a [ISmartArt.AllNodes](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartart/allnodes/), majd olvassa el a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/), amelyet az [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartartshape/textframe/) visszaad.

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

## **A SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés szabályozza, hogyan vannak a csomópontok elrendezve és összekapcsolva. A következő példában egy SmartArt objektumot hozunk létre a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` értékkel, ezt a `BasicProcess` értékre módosítjuk, majd elmentjük a bemutatót.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

Az [ISmartArtNode.IsHidden](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartartnode/ishidden/) azt jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemekként.

A következő példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` értéket használja, és ellenőrzi a csomópont rejtett állapotát.

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

## **A szervezeti diagram elrendezés lekérése vagy beállítása**

A szervezeti diagram elrendezést használó SmartArt diagramok esetén az [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) meghatározza, hogy a gyermekcsomópontok hogyan vannak elrendezve egy szülőcsomópont alatt. Például a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/organizationchartlayouttype/) függvényében beállíthatja, hogy a gyermekcsomópontok balról, jobbról vagy mindkét oldalon függjenek.

A következő példa egy szervezeti diagramot hoz létre, és az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` értékre állítja.

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

## **Képes szervezeti diagram létrehozása**

A képes szervezeti diagram egy SmartArt elrendezés, amely hierarchiai diagramokhoz készült, és képpel helyettesítő elemeket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` értéket a SmartArt objektum diára való hozzáadásakor.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy megfordítást RTL nyelvekhez?**

Igen. Az [IsReversed](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartart/isreversed/) tulajdonság megfordítja a diagram irányát balról jobbra vagy jobbról balra, amennyiben a kiválasztott SmartArt elrendezés támogatja a megfordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik bemutatóba a formázás megőrzése mellett?**

A [SmartArt alakzat klónozásával](/slides/hu/net/shape-manipulations/) a [ShapeCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/shapecollection/addclone/) vagy a SmartArt-ot tartalmazó teljes dia [klónozásával](/slides/hu/net/clone-slides/) másolhatja. Mindkét módszer megőrzi a méretet, pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képre előnézethez vagy webes exporthoz?**

[Renderelje a diát](/slides/hu/net/convert-powerpoint-to-png/) vagy a teljes bemutatót PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok meg egy adott SmartArt objektumot egy dián, ha több is van?**

Állítson be egy jellegzetes [AlternativeText](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/alternativetext/) vagy [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/name/) értéket a SmartArt alakzaton, keresse meg ezt az értéket a [Slide.Shapes](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslide/shapes/) között, majd ellenőrizze, hogy a megtalált alakzat egy [ISmartArt](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/ismartart/).