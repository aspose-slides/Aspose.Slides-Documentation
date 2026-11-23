---
title: Prezentáció szerkesztésének korlátozása formazárolásokkal .NET-ben
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 70
url: /hu/net/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelem a szerkesztéstől
- forma zárolása
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
description: "Ismerje meg, hogyan zárolhat és oldhat fel formákat PPTX prezentációkban az Aspose.Slides for .NET használatával, hogy korlátozza a kijelölést, mozgást, átméretezést és a csoportosítást."
---
## **Háttér**

Az Aspose.Slides for .NET gyakori felhasználási módja, hogy PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, a formák módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak a formák szervezve a diákon, valamint hogyan lehet alkalmazni és eltávolítani a formazárakat egy PPTX prezentációban. Ezek az zárak lehetővé teszik, hogy egyes formákon korlátozza a specifikus szerkesztési műveleteket.

## **Dia felépítése**

Egy prezentációs diát olyan komponensek alkotják, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított formák, képkeretek, videókeretek, összekötők és más elemek, amelyek a prezentáció felépítésére szolgálnak. Az Aspose.Slides for .NET-ben a dián lévő minden elem egy olyan objektummal van reprezentálva, amely megvalósítja a [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interfészt vagy egy olyan osztályból származik, amely ezt megteszi.

Az egyes forma típusok különböző zárolási lehetőségeket biztosítanak. A [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) interfész a formazárak alap interfésze. Az Aspose.Slides for .NET a következő zár interfészeket kínálja:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) zárolja az automatikus alakzatokat.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) zárolja az összekötő alakzatokat.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) zárolja a csoportosított formákat.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) zárolja a képkereteket.  

Ahhoz, hogy a zárakat egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) során alkalmazzuk, iteráljunk a diáikon, és állítsuk be a megfelelő zárolásokat minden támogatott formára.

## **Zárolás alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők formazárakat használnak az egyedi szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írási védelem külön [presentation protection settings](/slides/hu/net/password-protected-presentation/).

### **Zárolás alkalmazása PPTX formákra**

Az Aspose.Slides for .NET biztosítja az [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interfészt a dián lévő formákkal való munkához.

A példában a [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), a [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) és a [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) értéke `true`-ra van állítva az automatikus alakzatoknál, a csoportosított formák, összekötők és képkeretek esetében ekvivalens zárolásokkal. Az összekötők a [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) használatával mozgathatók; a csoportok pedig a [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) használatával korlátozzák a csoportosítást.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az egyes diák forma gyűjteményében lévő formákat, és egy másolatot ment el a felvett korlátozásokkal. A négy kezelt típuson kívüli formák változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekformákat.

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

A formazár eltávolításához állítsa az értékét `false`-ra. A következő példában egy formazárolt prezentációt tölt be, és törli a kiválasztás, mozgás és átméretezés korlátozásait a [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) és [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) segítségével. Emellett törli a [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) értékét is, és elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Kép vágásának megőrzése**

Helyezzen egy `photo.jpg` nevű fényképet a munkakönyvtárba. A példa 12%-kal vágja le a bal oldalt és 8%-kal a jobb oldalt, majd a képkereten a [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) beállítást állítja true-ra. Ez a jelző korlátozza a további vágást, és megőrzi a meglévő vágást.

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

`PictureLocked.pptx` a vágászárat `true` értékkel tárolja. PowerPointban a **Crop** parancs le van tiltva, amikor a fénykép ki van jelölve.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyilat csoportosít, majd a csoportra a [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) beállítással megakadályozza a csoport szétbontását, így a diagram elemei együtt maradnak. Más szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

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

`DiagramLocked.pptx` a szétbontászárat `true` értékkel tárolja. PowerPointban a **Ungroup** parancs le van tiltva, amikor a teljes diagram ki van jelölve.

### **Összegzés**

Az Aspose.Slides for .NET lehetővé teszi, hogy egyes formákon specifikus szerkesztési műveleteket korlátozzon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon át. Válassza ki a forma típusonként támogatott zárolásokat, és állítsa az értéküket `false`-ra, ha el kell távolítania ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok formazárakat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. A formazárak specifikus szerkesztési műveleteket korlátoznak, míg a [password protection](/slides/hu/net/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést bizonyos diákon anélkül, hogy a többit befolyásolnám?**

Igen. Csak a kiválasztott diákon lévő formákra alkalmazza a zárolásokat. Ez nem módosítja a többi dia zárolási beállításait.

**Hogyan tudok zárolásokat alkalmazni egy csoporton belüli egyedi formákra?**

Iteráljon a csoport [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) gyűjteményén, és alkalmazza a megfelelő zárolásokat minden egyes gyermekformára. Ismételje meg ezt minden egymásba ágyazott csoportra. A fenti példák csak a dia forma gyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyes csoporttagokon.