---
title: Megelőzni a prezentáció szerkesztését alakzatzárolásokkal .NET‑ben
linktitle: Megelőzni a prezentáció szerkesztését
type: docs
weight: 70
url: /hu/net/applying-protection-to-presentation/
keywords:
- szerkesztés megelőzése
- védelem a szerkesztés ellen
- alakzat zárolása
- pozíció zárolása
- kiválasztás zárolása
- méret zárolása
- csoportosítás zárolása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan zárolja vagy oldja fel az Aspose.Slides for .NET a PPT, PPTX és ODP fájlokban lévő alakzatokat, ezzel biztosítva a prezentációkat, miközben szabályozott szerkesztést tesz lehetővé."
---
## **Háttér**

Az Aspose.Slides gyakori felhasználási módja, hogy automatizált munkafolyamat részeként Microsoft PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és menten. Az ilyen módon Aspose.Slides‑et használó alkalmazások felhasználói hozzáférnek a generált prezentációkhoz, így a szerkesztés elleni védelem gyakori aggodalom. Fontos, hogy az automatikusan előállított prezentációk megőrizzék az eredeti formázásukat és tartalmukat.

Ez a cikk bemutatja, hogyan épülnek fel a prezentációk és diák, valamint hogyan alkalmazhat és távolíthat el védelmet egy prezentációnál az Aspose.Slides for .NET segítségével. Fejlesztők számára lehetőséget ad a generált prezentációk felhasználásának szabályozására.

## **Dia felépítése**

Egy prezentációs dia olyan komponensekből áll, mint az automatikus alakzatok, táblázatok, OLE-objektumok, csoportos alakzatok, képkeretek, videokeretek, kapcsolók és egyéb elemek, amelyek a prezentáció építéséhez szükségesek. Az Aspose.Slides for .NET‑ben a dia minden eleme egy olyan objektummal van reprezentálva, amely megvalósítja a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészt, vagy ebből származik.

A PPTX felépítése összetett, ezért a PPT‑től eltérően, ahol egy általános zárolás használható minden alakzattípusra, a különböző alakzattípusok különböző zárolásokat igényelnek. Az [IBaseShapeLock](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseshapelock/) interfész a PPTX általános zárolásosztálya. Az Aspose.Slides for .NET a PPTX‑hez a következő zárolástípusokat támogatja:

- [IAutoShapeLock](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshapelock/) zárolja az automatikus alakzatokat.  
- [IConnectorLock](https://reference.aspose.com/slides/hu/net/aspose.slides/iconnectorlock/) zárolja a kapcsoló alakzatokat.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/hu/net/aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.  
- [IGroupShapeLock](https://reference.aspose.com/slides/hu/net/aspose.slides/igroupshapelock/) zárolja a csoportos alakzatokat.  
- [IPictureFrameLock](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframelock/) zárolja a képkereteket.  

A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektumban végzett bármely művelet minden alakzatobjektumra alkalmazva lesz a teljes prezentációra.

## **Védelem alkalmazása és eltávolítása**

A védelem alkalmazása megakadályozza, hogy a prezentációt szerkesszék. Ez hasznos módszer a prezentáció tartalmának védelmére.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for .NET a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészt biztosítja a diákon lévő alakzatok kezeléséhez.

Ahogy korábban említettük, minden alakzat osztálynak van egy hozzá tartozó alakzat-zároló osztálya a védelemhez. Ez a cikk a NoSelect, NoMove és NoResize zárolásokra összpontosít. Ezek a zárolások biztosítják, hogy az alakzatok ne legyenek kiválaszthatók (egérkattintással vagy egyéb kiválasztási módszerekkel), valamint ne legyenek mozgathatók vagy átméretezhetők.

Az alábbi kópminták a prezentáció összes alakzattípusára alkalmazzák a védelmet.

```cs
// Példányosítja a PPTX fájlt képviselő Presentation osztályt.
using Presentation presentation = new Presentation("Sample.pptx");

// Bejárja a prezentáció összes diáját.
foreach (ISlide slide in presentation.Slides)
{
    // Bejárja a dia összes alakzatát.
    foreach (IShape shape in slide.Shapes)
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

// Mentése a prezentáció fájlnak.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Védelem eltávolítása**

Egy alakzat feloldásához állítsuk a alkalmazott zárolás értékét `false`‑ra. Az alábbi kópminta bemutatja, hogyan oldhatók fel az alakzatok egy zárolt prezentációban.

```cs
// Példányosítja a PPTX fájlt képviselő Presentation osztályt.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Bejárja a prezentáció összes diáját.
foreach (ISlide slide in presentation.Slides)
{
    // Bejárja a dia összes alakzatát.
    foreach (IShape shape in slide.Shapes)
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

// A prezentáció fájl mentése.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Összegzés**

Az Aspose.Slides több lehetőséget kínál az alakzatok prezentációban történő védelmére. Zárolhat egyetlen alakzatot, vagy végigiterálhat a prezentáció összes alakzatán, és mindegyiket egyenként zárolhatja, ezzel hatékonyan biztosítva a teljes fájl védelmét. A védelem eltávolítható a zárolás értékét `false`‑ra állítva.

## **GYIK**

**Összevonhatók a shape zárolások és a jelszóvédelem egyetlen prezentációban?**

Igen. A zárolások korlátozzák az objektumok szerkesztését a fájlon belül, míg a [jelszóvédelem](/slides/hu/net/password-protected-presentation/) a megnyitáshoz és/vagy a módosítások mentéséhez való hozzáférést szabályozza. Ezek a mechanizmusok kiegészítik egymást és együtt működnek.

**Korlátozható a szerkesztés csak bizonyos diákon, anélkül hogy a többit befolyásolná?**

Igen. Alkalmazzon zárolásokat a kiválasztott diák alakzataira; a többi dia szerkeszthető marad.

**A shape zárolások érvényesek csoportos objektumokra és kapcsolókra is?**

Igen. Dedikált zárolástípusok állnak rendelkezésre csoportokra, kapcsolókra, grafikus objektumokra és egyéb alakzattípusokra.