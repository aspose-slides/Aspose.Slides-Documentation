---
title: Prezentáció szerkesztésének korlátozása alakzatzárakkal .NET-ben
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 70
url: /hu/net/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védés a szerkesztéstől
- alakzat zárolása
- pozíció zárolása
- kiválasztás zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan zárolhatja és oldhatja fel az alakzatokat PPTX prezentációkban az Aspose.Slides for .NET segítségével, hogy korlátozza a kiválasztást, mozgatást, átméretezést és a csoportosítást."
---
## **Háttér**

Az Aspose.Slides for .NET gyakori felhasználási módja, hogy PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk bemutatja, hogyan rendeződnek az alakzatok a diákon, és hogyan alkalmazhatók és távolíthatók el az alakzatzárak egy PPTX prezentációban. Ezek a zárak lehetővé teszik, hogy egyes alakzatok szerkesztési műveleteit korlátozza.

## **Dia felépítése**

A prezentációs dia olyan összetevőkből áll, mint az autóalakzatok, táblázatok, OLE-objektumok, csoportosított alakzatok, képkockák, videokockák, csatlakozók és egyéb elemek, amelyek a prezentáció építéséhez szükségesek. Az Aspose.Slides for .NET-ben a dia minden eleme egy olyan objektummal van reprezentálva, amely implementálja a [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interfészt, vagy egy olyan osztályból származik, amely ezt teszi.

Különböző alakzat típusok különböző zárolási beállításokat kínálnak. A [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) interfész az alakzatzárak alapinterfésze. Az Aspose.Slides for .NET a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) zárolja az autóalakzatokat.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) zárolja a csatlakozó alakzatokat.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) zárolja a csoportos alakzatokat.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) zárolja a képkockákat.  

A [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) teljesen történő zárolásához iterálja végig a diákat, és állítsa be a megfelelő zárakat minden támogatott alakzaton.

## **Zárolás alkalmazása és eltávolítása**

Az alakzatzárak korlátozzák az olyan műveleteket, mint az alakzatok kiválasztása, mozgatása és átméretezése. Nem teszik a teljes prezentációt szerkeszthetetlenné.

### **Zárolás alkalmazása PPTX alakzatokra**

Az Aspose.Slides for .NET a [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interfészt biztosítja a diákon lévő alakzatokkal való munkához.

A példa a [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) és a [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) értékét `true`-ra állítja az autóalakzatoknál, hasonló zárakat alkalmazva a csoportos alakzatoknál, csatlakozóknál és képkockáknál. A csatlakozók a [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/)‑t használják a mozgáshoz; a csoportok pedig a [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/)‑t a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és elment egy másolatot a felvitt korlátozásokkal. A négy kezelt típuson kívüli alakzatok változatlanul maradnak. A ciklus nem járja be a csoporton belüli gyermekalkzatokat.

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

### **Zárolás eltávolítása**

Az alakzatzár eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy prezentációt alakzatzárakkal, és törli a kiválasztási, mozgási és átméretezési korlátozásokat a [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) és [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) segítségével. Emellett törli a [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) beállítást, és elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Összegzés**

Az Aspose.Slides for .NET lehetővé teszi, hogy egyes alakzatok szerkesztési műveleteit korlátozza, vagy ugyanazokat a korlátozásokat alkalmazza a diákon. Válassza ki az egyes alakzat típusok által támogatott zárolásokat, és állítsa értéküket `false`-ra, ha el akarja távolítani ezeket a korlátozásokat.

## **GYIK**

**Can I combine shape locks and password protection in the same presentation?**

Igen. Az alakzatzárak a specifikus szerkesztési műveleteket korlátozzák, míg a [password protection](/slides/hu/net/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Can I restrict editing on specific slides without affecting others?**

Igen. Csak a kiválasztott diák alakzataira alkalmazzon zárakat. Ez nem módosítja a többi dia zárbeállításait.

**How can I apply locks to individual shapes inside a group?**

Iteráljon a csoport [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) gyűjteményén, és alkalmazza a megfelelő zárakat minden gyermekalakzatra. Ismételje meg ezt minden beágyazott csoportra is. A fenti példák csak a dia alakzatgyűjteményét dolgozzák fel, így nem állítanak be zárakat az egyes csoporttagokra.