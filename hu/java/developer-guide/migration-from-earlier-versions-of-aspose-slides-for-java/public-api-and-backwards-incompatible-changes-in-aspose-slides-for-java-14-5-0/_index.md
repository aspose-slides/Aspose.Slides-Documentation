---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.5.0-ban
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és a visszafelé nem kompatibilis változásokat, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) osztályt, metódust, tulajdonságot stb., valamint minden új [korlátozást](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) és egyéb [változást](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/), amelyet az Aspose.Slides for Java 14.5.0 API hozott be.

{{% /alert %}} 
## **Nyilvános API és visszafelé nem kompatibilis változások**
### **Hozzáadott osztályok és metódusok**
#### **Hozzáadva az Aspose.Slides.IPresentationInfo interfész és a PresentationInfo osztályok**
Az előadás információit reprezentálja.

A Boolean isEncrypted() metódus True értéket ad, ha egy előadás titkosított, ellenkező esetben False értéket ad.

A LoadFormat getLoadFormat() metódus visszaadja az előadás típusát.
#### **Hozzáadva az Aspose.Slides.IShape.isGrouped() metódus**
Az Aspose.Slides.IShape.isGrouped() metódus meghatározza, hogy a forma csoportosított‑e.
#### **Hozzáadva az Aspose.Slides.IShape.getParentGroup() metódus**
Az Aspose.Slides.IShape.getParentGroup() metódus visszaadja a szülő GroupShape objektumot, ha a forma csoportosított. Egyébként null értéket ad.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.addGroupShape() metódus**
Az Aspose.Slides.IShapeCollection.addGroupShape() metódus új GroupShape‑t hoz létre, és a gyűjtemény végére adja hozzá.

A GroupShape keretmérete és pozíciója a tartalomhoz lesz igazítva, amikor új forma kerül a GroupShape‑ba.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.clear() metódus**
Az Aspose.Slides.IShapeCollection.clear() metódus eltávolítja az összes formát a gyűjteményből.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.insertGroupShape(int) metódus**
Az Aspose.Slides.IShapeCollection.insertGroupShape(int) metódus új GroupShape‑t hoz létre, és a megadott indexen szúrja be a gyűjteménybe.
A GroupShape keretmérete és pozíciója a tartalomhoz lesz igazítva, amikor új forma kerül a GroupShape‑ba.
#### **Hozzáadva az IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) metódusok**
Ezek a metódusok lehetővé teszik a fejlesztők számára, hogy egy prezentáció fájl/stream információit megkapják anélkül, hogy a teljes prezentációt betöltenék.
#### **Hozzáadva az IPresentationFactory PresentationFactory.getInstance() metódus**
Lehetővé teszi a gyári funkcionalitás használatát példányosítás nélkül.
### **Korlátozások**
#### **Korlátozások lettek bevezetve az IShape.getFrame() nem definiált értékek használatára**
Az a kód, amely megpróbál egy nem definiált keretet hozzárendelni az IShape.setFrame(IShapeFrame) metódushoz, általános esetben nem értelmezhető (különösen akkor, ha a szülő GroupShape több szinten van beágyazva más {{GroupShape}}‑okba). Például:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

vagy

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Az ilyen kód félreérthető helyzetekhez vezethet. Ezért korlátozások kerültek bevezetésre a IShape.Frame nem definiált értékek használatára. Az x, y, width, height, flipH, flipV és rotationAngle értékeknek definiáltnak kell lenniük (nem Float.NaN vagy NullableBool.NotDefined). A fenti példakód most ArgumentException‑t dob.
Ez az alábbi felhasználási esetekre vonatkozik:

``` java

 IShape shape = ...;

shape.setFrame(...); // nem lehet meghatározatlan

IShapeCollection shapes = ...;

// x, y, width, height paraméterek nem lehetnek Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}
```

Az IShape.getRawFrame() keret azonban lehet nem definiált. Ez akkor értelmes, ha egy forma egy helykitöltőhöz van kapcsolva. Ilyenkor a nem definiált forma keretértékeket a szülő helykitöltő forma felülírja. Ha nincs szülő helykitöltő forma, akkor alapértelmezett értékeket használ, amikor a hatékony keretet az IShape.getRawFrame() alapján számítja ki. Az alapértelmezett értékek 0 és NullableBool.False az x, y, width, height, flipH, flipV és rotationAngle esetén. Például:

``` java

 IShape shape = ...; // a forma helykitöltőhöz van kapcsolva

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// most a forma az x, y, height, flipH, flipV értékeket a helykitöltőtől örökli, és felülírja a width=100 és rotationAngle=0 értékeket.
```
### **Módosított tulajdonságok**
#### **Módosítva az Aspose.Slides.IShapeCollection.getParent() metódus típus és neve**
Az Aspose.Slides.IShapeCollection.Parent tulajdonság típusa ISlideComponent‑ról az új IGroupShape interfészre változott. Az IGroupShape interfész az ISlideComponent leszármazottja, ezért a meglévő kódnak nem kell módosulnia.

Az Aspose.Slides.IShapeCollection.getParent() metódus neve getParent‑ról getParentGroup®‑ra változott.
#### **Módosítva az Aspose.Slides.IShapeFrame.getFlipH() és .getFlipV() metódusok típusa**
Az Aspose.Slides.IShapeFrame.getFlipH() metódus típusa bool‑ról NullableBool-ra változott.

Az IShape.getFrame() metódus az IShapeFrame hatékony példányát adja vissza (minden tulajdonsága definiált hatékony értékkel rendelkezik).

Az IShape.getRawFrame() metódus egy IShapeFrame példányt ad vissza, amelynek egyes tulajdonságai lehetnek nem definiáltak (különösen a FlipH vagy FlipV lehet NullableBool.NotDefined).