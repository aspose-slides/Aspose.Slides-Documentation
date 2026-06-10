---
title: Megakadályozza a prezentáció szerkesztését alakzatzárolással
linktitle: Megakadályozza a prezentáció szerkesztését
type: docs
weight: 60
url: /hu/java/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelme a szerkesztéstől
- alakzat zárolása
- pozíció zárolása
- kiválasztás zárolása
- méret zárolása
- csoportosítás zárolása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan zárolja vagy oldja fel az Aspose.Slides for Java az alakzatokat PPT, PPTX és ODP fájlokban, ezzel a prezentációkat védi, miközben szabályozott szerkesztést és gyorsabb szállítást tesz lehetővé."
---
## **Háttér**

Az Aspose.Slides gyakori felhasználása, hogy Microsoft PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse automatizált munkafolyamat részeként. Azok a felhasználók, akik az alkalmazásokban így használják az Aspose.Slides‑t, hozzáférnek a létrehozott prezentációkhoz, ezért a szerkesztés elleni védelem gyakori aggodalom. Fontos, hogy az automatikusan generált prezentációk megőrizzék eredeti formázásukat és tartalmukat.

Ez a cikk elmagyarázza, hogyan épülnek fel a prezentációk és a diák, valamint hogyan tud az Aspose.Slides for Java védelmet alkalmazni egy prezentációra, majd később eltávolítani azt. Fejlesztők számára lehetőséget biztosít arra, hogy szabályozzák a saját alkalmazásaik által generált prezentációk használatát.

## **Dia felépítése**

Egy prezentációs dia olyan komponensekből áll, mint az automatikus alakzatok, táblázatok, OLE-objektumok, csoportos alakzatok, képkockák, videokockák, összekötők és egyéb elemek, amelyeket a prezentáció építéséhez használnak. Az Aspose.Slides for Java‑ban a dia minden eleme egy olyan objektummal van reprezentálva, amely megvalósítja a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészt, vagy örökli egy osztályt, amely ezt teszi.

A PPTX szerkezete összetett, ezért a PPT‑től eltérően, ahol egy általános zárcsatorna használható minden alakzattípushoz, a különböző alakzattípusokhoz eltérő zárak szükségesek. A [IBaseShapeLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseshapelock/) interfész a PPTX általános zárolási osztálya. Az alábbi zár típusok támogatottak az Aspose.Slides for Java‑ban PPTX esetén:

- [IAutoShapeLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshapelock/) az automatikus alakzatokat zárolja.  
- [IConnectorLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iconnectorlock/) a csatlakozó alakzatokat zárolja.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igraphicalobjectlock/) a grafikus objektumokat zárolja.  
- [IGroupShapeLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igroupshapelock/) a csoportos alakzatokat zárolja.  
- [IPictureFrameLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframelock/) a képkockákat zárolja.  

A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektum összes alakzaton végzett művelet az egész prezentációra vonatkozik.

## **Védelem alkalmazása és eltávolítása**

A védelem alkalmazása biztosítja, hogy a prezentációt ne lehessen szerkeszteni. Ez hasznos technika a prezentáció tartalmának védelmére.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Java biztosítja a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészt a dia alakzataival való munkához.

Ahogy korábban említettük, minden alakzat osztálynak van egy hozzá tartozó alakzat-zár osztálya a védelemhez. Ebben a cikkben a NoSelect, NoMove és NoResize zárakra koncentrálunk. Ezek a zárak biztosítják, hogy az alakzatok ne legyenek kiválaszthatók (egérkattintással vagy más kiválasztási módszerrel), valamint ne legyenek áthelyezhetők vagy átméretezhetők.

Az alábbi kódminta a prezentáció összes alakzattípusára alkalmaz védelmet.

```java
// Példányosítsa a Presentation osztályt, amely egy PPTX fájlt képvisel.
Presentation presentation = new Presentation("Sample.pptx");

// Bejárja a prezentáció összes diáját.
for (ISlide slide : presentation.getSlides()) {

    // Bejárja a dia összes alakzatát.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Átalakítja az alakzatot autoshapre, és lekéri a alakzat zárolását.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Átalakítja az alakzatot csoportos alakzattá, és lekéri a alakzat zárolását.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Átalakítja az alakzatot csatlakozó alakzattá, és lekéri a alakzat zárolását.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Átalakítja az alakzatot képkockává, és lekéri a alakzat zárolását.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Mentse a prezentáció fájlt.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Védelem eltávolítása**

Az alakzat feloldásához állítsa a beállított zár értékét `false`‑ra. Az alábbi kódminta bemutatja, hogyan lehet feloldani a zárakat egy zárolt prezentációban.

```java
// Példányosítsa a Presentation osztályt, amely egy PPTX fájlt képvisel.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Bejárja a prezentáció összes diáját.
for (ISlide slide : presentation.getSlides()) {

    // Bejárja a dia összes alakzatát.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Átalakítja az alakzatot autoshapere, és lekéri a alakzat zárolását.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Átalakítja az alakzatot csoportos alakzattá, és lekéri a alakzat zárolását.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Átalakítja az alakzatot csatlakozó alakzattá, és lekéri a alakzat zárolását.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Átalakítja az alakzatot képkockává, és lekéri a alakzat zárolását.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Mentse a prezentáció fájlt.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Összefoglalás**

Az Aspose.Slides több lehetőséget kínál a prezentáció alakzatainak védelmére. Egyedi alakzatot is le lehet zárolni, vagy végig lehet iterálni a prezentáció összes alakzatán, és egyenként zárolni őket, így hatékonyan biztosítható a teljes fájl. A védelmet a zár értékének `false`‑ra állításával lehet eltávolítani.

## **GYIK**

**Kombinálhatok alakzat-zárakat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. A zárak korlátozzák a fájlban lévő objektumok szerkesztését, míg a [jelszóvédelem](/slides/hu/java/password-protected-presentation/) a megnyitás és/vagy a módosítások mentésének hozzáférését szabályozza. Ezek a mechanizmusok kiegészítik egymást és együtt működnek.

**Korlátozhatom a szerkesztést konkrét diákon anélkül, hogy mások érintettek lennének?**

Igen. Alkalmazzon zárakat a kiválasztott diák alakzataira; a többi dia továbbra szerkeszthető marad.

**Alkalmazhatók a zárak csoportos objektumokra és csatlakozókra?**

Igen. Dedikált zár típusok támogatottak a csoportok, csatlakozók, grafikus objektumok és egyéb alakzattípusok számára.