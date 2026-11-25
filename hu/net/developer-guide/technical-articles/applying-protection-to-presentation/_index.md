---
title: Prezentáció szerkesztésének korlátozása alakzatzárolásokkal .NET-ben
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 70
url: /hu/net/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelem a szerkesztés ellen
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX prezentációkban az Aspose.Slides for .NET segítségével a kijelölés, mozgatás, átméretezés és csoportosítás korlátozása érdekében."
---
## **Háttér**

Az Aspose.Slides for .NET gyakori felhasználási módja, hogy PowerPoint (PPTX) prezentációkat hozzunk létre, frissítsünk és mentsünk egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a szándékolt elrendezést és a tartalmat.

Ez a cikk elmagyarázza, hogyan szerveződnek az alakzatok a diákon, és hogyan lehet alkalmazni és eltávolítani az alakzatzárolásokat egy PPTX prezentációban. Ezek a zárak lehetővé teszik, hogy korlátozzuk a konkrét szerkesztési műveleteket az egyes alakzatokon.

## **Dia felépítése**

Egy prezentációs dia olyan összetevőkből áll, mint az autoshapes, táblázatok, OLE-objektumok, csoportosított alakzatok, képkeretek, videokeretek, csatlakozók és egyéb elemek, amelyek a prezentáció felépítéséhez szükségesek. Az Aspose.Slides for .NET-ben a dia minden eleme egy olyan objektummal van reprezentálva, amely megvalósítja a [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interfészt, vagy örököl egy olyan osztályból, amely megvalósítja azt.

A különböző alakzattípusok különféle zárolási lehetőségeket kínálnak. A [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) interfész az alakzatzárolások alapinterfésze. Az Aspose.Slides for .NET a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) zárolja az autoshape‑okat.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) zárolja a csatlakozó alakzatokat.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) zárolja a csoportos alakzatokat.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) zárolja a képkereteket.  

A [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) zárolások alkalmazásához iteráljon a diákon, és állítsa be a megfelelő zárolásokat minden támogatott alakzatra.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők alakzatzárolásokat használnak az egyes szerkesztési műveletek korlátozására. A fájl titkosítás és a dokumentumszintű írásvédelme különálló [prezentációvédelmi beállítások](/slides/hu/net/password-protected-presentation/) beállítás.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for .NET biztosítja a [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interfészt a dia alakzataival való munka érdekében.

A példában a [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), a [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) és a [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) értéke `true`‑ra van állítva az autoshape‑eknél, valamint ekvivalens zárolások a csoportos alakzatoknál, csatlakozóknál és képkereteknél. A csatlakozók a [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/)‑t használják a mozgáshoz; a csoportok a [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/)‑t használják a csoportosítás korlátozásához.

A példa betölti egy meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és egy másolatot ment el a rendezett korlátozásokkal. Az négy kezelt típuson kívüli alakzatok változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekalakzatokat.

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

### **Védelem eltávolítása**

Egy alakzatzárolás eltávolításához állítsa annak értékét `false`‑ra. A következő példa betölt egy prezentációt alakzatzárolásokkal, és a [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), a [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), a [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) valamint a [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) segítségével törli a kijelölés, a mozgás és az átméretezés korlátozásait. Emellett törli az [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) beállítást, és elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Képvágás megőrzése**

Helyezze a `photo.jpg` nevű fényképet a munkakönyvtárba. A példa balról 12 % és jobbról 8 % vágást alkalmaz, majd a képkeretre beállítja a [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/)‑t. Ez a jelző korlátozza a további vágást és megőrzi a meglévő vágást.

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

`PictureLocked.pptx` a vágás zárolását `true`‑ként tárolja. PowerPointban a **Crop** parancs le van tiltva, amikor a fénykép ki van jelölve.

### **Diagram csoportos állapotának megtartása**

A példa egy téglalapot és egy nyilat csoportosít, majd a csoportra beállítja a [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/)‑t, hogy a diagram elemei együtt maradjanak. Más szerkesztési lehetőségek, például a csoport mozgatása vagy egy komponens kitöltésének módosítása, továbbra is elérhetők.

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

`DiagramLocked.pptx` az ungrouping zárolást `true`‑ként tárolja. PowerPointban a **Ungroup** parancs le van tiltva, amikor a teljes diagram ki van jelölve.

### **Létező alakzatzárolások jelentése**

Egy sablon áttekintéséhez nyissa meg, és olvassa el az egyes alakzatok zárolási objektumát. A [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) `true`, ha az objektum összes jelzője le van tiltva, és `false`, ha legalább egy engedélyezve van. Egy csoport és annak gyermekei külön zárolási objektummal rendelkeznek, ezért vizsgálja meg a gyermekeket még akkor is, ha a csoport nem rendelkezik zárolásokkal.

Ez a példa ellenőrzi a mozgást az autoshape‑eknél, a képkereteknél és a csoportoknál, a vágást a képeknél, valamint az ungrouping‑ot a csoportoknál. Jelentést készít a felismert jelzőkről, és megjelöli azokat az alakzattípusokat, amelyeket nem vizsgál.

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

Tegyük fel, hogy a `Sample.pptx` 1. diája tartalmaz egy `Layout` nevű csoportot, amelynek az ungrouping zárolva van, egy `Photo` nevű képet, amelynek a vágás zárolva van, és egy `Free` nevű, zárolás nélküli téglalapot. A jelentés kihagyja a `Free`‑t és ezeket a két sort írja ki:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

A jelentés a tárolt alakzatszintű szerkesztési jelzőket olvassa anélkül, hogy megváltoztatná vagy mentené a prezentációt. A dokumentumszintű írásvédelem egy külön beállítás, és minden jelző érvényesítése a szerkesztőtől függ.

## **Összegzés**

Az Aspose.Slides for .NET lehetővé teszi, hogy korlátozza a konkrét szerkesztési műveleteket egyes alakzatokon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon keresztül. Válassza ki az egyes alakzattípusok által támogatott zárolásokat, és állítsa az értéküket `false`‑ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok alakzatzárolásokat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. Az alakzatzárolások a konkrét szerkesztési műveleteket korlátozzák, míg a [jelszóvédelem](/slides/hu/net/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést konkrét diákon anélkül, hogy más diákat érintenék?**

Igen. Csak a kiválasztott diák alakzataira alkalmazza a zárolásokat. Ez nem módosítja a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat a csoporton belüli egyes alakzatokra?**

Iteráljon a csoport [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) gyűjteményén, és alkalmazza a megfelelő zárolásokat minden gyermekalakzatra. Ismételje meg ezt minden egymásba ágyazott csoportnál, a jelentés példájában bemutatott bejárást követve.