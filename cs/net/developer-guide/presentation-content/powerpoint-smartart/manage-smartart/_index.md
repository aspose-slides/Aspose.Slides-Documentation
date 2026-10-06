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

SmartArt je diagram PowerPointu složený z uzlů, tvarů uzlů a rozvržení. S Aspose.Slides pro .NET můžete vytvářet SmartArt, číst text z jeho uzlů, měnit jeho rozvržení, zkoumat skryté uzly, konfigurovat rozvržení organizačních diagramů a vytvářet diagramy organizačních schémat s obrázky.

## **Získání textu z objektu SmartArt**

Uzel SmartArt může obsahovat jeden nebo více tvarů. Pro čtení textu z tvarů uzlu iterujte přes [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), poté přečtěte [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), který vrací [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

Příklad vyžaduje prezentaci s alespoň jedním snímkem a objektem SmartArt jako prvním tvarem na tomto snímku. Vytiskne každý dostupný textový rámec do konzole.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Změna typu rozvržení objektu SmartArt**

Rozvržení SmartArt řídí, jak jsou uzly uspořádány a propojeny. Následující příklad vytvoří objekt SmartArt s hodnotou [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, změní ji na hodnotu `BasicProcess` a uloží prezentaci. Pozice a velikost předávané metodě [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) jsou měřeny v bodech. Nastavte [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/), abyste změnili rozvržení.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Zkontrolovat, zda je uzel SmartArt skrytý**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) udává, zda je uzel skrytý v datovém modelu SmartArt. Skryté uzly mohou existovat ve struktuře, i když vybrané rozvržení nezobrazuje je jako viditelné prvky diagramu.

Následující příklad přidá uzel k objektu SmartArt, který používá hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, a zkontroluje skrytý stav přidaného uzlu. Vytiskne zprávu, pokud je uzel skrytý, a uloží diagram.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Získání nebo nastavení rozvržení organizačního diagramu**

U diagramů SmartArt, které používají rozvržení organizačního diagramu, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) určuje, jak jsou podřízené uzly uspořádány pod nadřazeným uzlem. Například můžete nastavit podřízené uzly, aby visely zleva, zprava nebo z obou stran, v závislosti na vybraném [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/).

Následující příklad vytvoří organizační diagram a nastaví rozvržení prvního uzlu na hodnotu [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. Nulový index `0` vybere první uzel nejvyšší úrovně; jeho podřízené uzly použijí vybrané uspořádání. Upravená prezentace je následně uložena.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Vytvoření obrázkového organizačního diagramu**

Obrázkový organizační diagram je rozvržení SmartArt určené pro hierarchické diagramy, které obsahují zástupné obrázky. Použijte hodnotu [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` při přidávání objektu SmartArt na snímek. Tento příklad uloží diagram se zástupnými obrázky; nezaplní zástupné obrázky skutečnými obrázky.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Převod starých diagramů na skupiny tvarů**

Při modernizaci existující prezentace můžete potřebovat aktualizovat organizační diagram původně vytvořený v PowerPointu 97–2003. Aspose.Slides představuje tyto staré diagramy jako objekty [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Použijte [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/), abyste diagram převedli na skupinu tvarů, což vám umožní editovat jednotlivé vizuální prvky. Další podrobnosti najdete v [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/).

Převod přidá novou skupinu do kolekce tvarů, aniž by odstranil původní diagram. Po úspěšném převodu odstraňte originál pomocí [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/), aby nedošlo k duplicitnímu obsahu. Shromážděte staré diagramy do pole před jejich převodem, aby přidávání a odstraňování tvarů nerušilo iteraci.

Následující příklad otevře prezentaci, prohledá každý snímek, převede diagramy na skupiny tvarů a uloží aktualizovanou prezentaci jako PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Uložená prezentace obsahuje editovatelné skupiny tvarů místo převedených starých diagramů, přičemž žádné původní diagramy již nezůstávají. Otevřete PPTX v PowerPointu a upravte jednotlivé prvky v každé skupině, jako je jejich text, výplň nebo pozice.

## **Často kladené otázky**

**Podporuje SmartArt zrcadlení nebo převracení pro RTL jazyky?**

Ano. Vlastnost [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) přepíná směr diagramu zleva doprava na zprava doleva nebo zpět, pokud vybrané rozvržení SmartArt podporuje převrácení.

**Jak mohu kopírovat SmartArt na stejný snímek nebo do jiné prezentace při zachování formátování?**

Můžete [klonovat tvar SmartArt](/slides/cs/net/shape-manipulations/) pomocí [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) nebo [klonovat celý snímek](/slides/cs/net/clone-slides/), který SmartArt obsahuje. Oba přístupy zachovají velikost, pozici i formátování.

**Jak mohu vykreslit SmartArt do rastrového obrázku pro náhled nebo webový export?**

[Vykreslete snímek](/slides/cs/net/convert-powerpoint-to-png/) nebo celou prezentaci do formátu PNG nebo JPEG. SmartArt je vykreslen jako součást snímku.

**Jak mohu najít konkrétní objekt SmartArt na snímku, pokud jich je několik?**

Nastavte jedinečnou hodnotu [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) nebo [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) na tvaru SmartArt, vyhledejte tuto hodnotu v [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), a poté ověřte, že odpovídající tvar je [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).