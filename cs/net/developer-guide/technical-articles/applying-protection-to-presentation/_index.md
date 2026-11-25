---
title: Omezit úpravy prezentace pomocí zámků tvarů v .NET
linktitle: Omezit úpravy prezentace
type: docs
weight: 70
url: /cs/net/applying-protection-to-presentation/
keywords:
- zabránit úpravám
- chránit před úpravami
- uzamknout tvar
- uzamknout pozici
- uzamknout výběr
- uzamknout změnu velikosti
- uzamknout seskupování
- PowerPoint
- PPTX
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak uzamknout a odemknout tvary v PPTX prezentacích pomocí Aspose.Slides pro .NET, abyste omezili výběr, pohyb, změnu velikosti a seskupování."
---
## **Pozadí**

Běžné použití Aspose.Slides for .NET je vytváření, aktualizace a ukládání prezentací PowerPoint (PPTX) jako součást automatizovaného pracovního postupu. Když uživatelé obdrží tyto prezentace, omezení změn tvarů může pomoci zachovat zamýšlené rozložení a obsah.

Tento článek vysvětluje, jak jsou tvary na snímcích organizovány a jak aplikovat a odebrat zámky tvarů v PPTX prezentaci. Tyto zámky vám umožní omezit konkrétní operace úprav u jednotlivých tvarů.

## **Složení snímku**

Snímek prezentace se skládá ze součástí, jako jsou automatické tvary, tabulky, OLE objekty, seskupené tvary, rámečky obrázků, rámečky videa, spojnice a další prvky používané k vytvoření prezentace. V Aspose.Slides for .NET je každý prvek na snímku reprezentován objektem, který implementuje rozhraní [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) nebo dědí z třídy, která to dělá.

Různé typy tvarů nabízejí různé možnosti zamykání. Rozhraní [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) je základním rozhraním pro zámky tvarů. Aspose.Slides for .NET poskytuje následující rozhraní zámků:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) zamyká automatické tvary.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) zamyká tvary spojnic.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) zamyká grafické objekty.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) zamyká seskupené tvary.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) zamyká rámečky obrázků.  

Pro aplikaci zámků v celé [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), iterujte přes její snímky a nastavte odpovídající zámky na každý podporovaný tvar.

## **Použití a odebrání ochrany**

Kompatibilní editory prezentací používají zámky tvarů k omezení jednotlivých operací úprav. Šifrování souboru a ochrana zápisu na úrovni dokumentu jsou samostatná [nastavení ochrany prezentace](/slides/cs/net/password-protected-presentation/).

### **Aplikovat ochranu na PPTX tvary**

Aspose.Slides for .NET poskytuje rozhraní [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pro práci s tvary na snímku.

Příklad nastavuje [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) a [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) na `true` pro automatické tvary, s ekvivalentními zámky pro seskupené tvary, spojnice a rámečky obrázků. Spojnice používají [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) pro pohyb; skupiny také používají [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) k omezení seskupování.

Příklad načte existující PPTX prezentaci, prověří tvary v kolekci tvarů každého snímku a uloží kopii s těmito aplikovanými omezeními. Tvary mimo čtyři zpracovávané typy zůstávají nezměněny. Smyčka neprochází podřízené tvary uvnitř skupiny.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Odebrat ochranu**

Pro odebrání zámku tvaru nastavte jeho hodnotu na `false`. Následující příklad načte prezentaci se zámky tvarů a vymaže omezení výběru, pohybu a změny velikosti pomocí [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), a [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Také vymaže [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) a uloží kopii prezentace. Ostatní nastavení zámků zůstávají beze změny.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Zachovat ořez obrázku**

Umístěte fotografii pojmenovanou `photo.jpg` do pracovního adresáře. Příklad ořízne 12 % zleva a 8 % zprava, poté nastaví [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) na rámeček obrázku. Tento příznak omezuje další ořez a zachovává stávající ořez.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` ukládá zámek ořezu jako `true`. V PowerPointu je příkaz **Crop** zakázán, když je vybrána fotografie.

### **Udržet diagram seskupený**

Příklad seskupí obdélník a šipku a poté nastaví [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) na samotnou skupinu, aby komponenty diagramu zůstaly pohromadě. Ostatní úpravy, jako přesunutí skupiny nebo změna výplně komponenty, zůstávají dostupné.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` ukládá zámek rozdělení jako `true`. V PowerPointu je příkaz **Ungroup** zakázán, když je vybrán celý diagram.

### **Nahlásit existující zámky tvarů**

Pro revizi šablony ji otevřete a načtěte objekt zámku pro každý tvar. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) je `true`, když jsou všechny příznaky v tomto objektu vypnuté, a `false`, když je alespoň jeden zapnutý. Skupina a její podřízené prvky mají samostatné objekty zámků, proto prohlédněte podřízené prvky i když skupina nemá žádné zámky.

Tento příklad kontroluje pohyb u automatických tvarů, rámečků obrázků a skupin, ořez u obrázků a rozdělení u skupin. Zpráva uvádí rozpoznané příznaky a označuje typy tvarů, které nezkoumá.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Předpokládejme, že snímek 1 souboru `Sample.pptx` obsahuje skupinu pojmenovanou `Layout` s uzamčeným rozdělením, obrázek pojmenovaný `Photo` uvnitř ní s uzamčeným ořezu a odemčený obdélník pojmenovaný `Free`. Zpráva přeskočí `Free` a vypíše tyto dva řádky:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Zpráva načítá uložené příznaky úprav na úrovni tvaru, aniž by je měnila nebo ukládala prezentaci. Ochrana zápisu na úrovni dokumentu je samostatné nastavení a vynucení každého příznaku závisí na editoru.

## **Závěr**

Aspose.Slides for .NET vám umožňuje omezit konkrétní operace úprav u jednotlivých tvarů nebo aplikovat stejné omezení napříč snímky. Vyberte zámky podporované každým typem tvaru a nastavte jejich hodnoty na `false`, když potřebujete tato omezení odebrat.

## **Často kladené otázky**

**Mohu kombinovat zámky tvarů a ochranu heslem ve stejné prezentaci?**

Ano. Zámky tvarů omezují konkrétní operace úprav, zatímco [ochranu heslem](/slides/cs/net/password-protected-presentation/) může omezit otevření nebo úpravu prezentace. Můžete použít obojí ve stejném souboru.

**Mohu omezit úpravy na konkrétních snímcích bez ovlivnění ostatních?**

Ano. Použijte zámky pouze na tvary na vybraných snímcích. Tím se nezmění nastavení zámků na ostatních snímcích.

**Jak mohu aplikovat zámky na jednotlivé tvary uvnitř skupiny?**

Iterujte přes kolekci [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) skupiny a aplikujte odpovídající zámky na každý podřízený tvar. Opakujte to pro jakékoli vnořené skupiny podle průchodu v příkladu pro hlášení.