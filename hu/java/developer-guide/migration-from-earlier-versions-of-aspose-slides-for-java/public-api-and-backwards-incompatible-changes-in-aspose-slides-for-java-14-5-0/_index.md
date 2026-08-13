---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 14.5.0-ban
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for Java-ban, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 
Ez az oldal felsorolja az összes hozzáadott osztályt, metódust, tulajdonságot és így tovább, valamint az új korlátozásokat és egyéb változásokat, amelyeket az Aspose.Slides for Java 14.5.0 API bevezetett.
{{% /alert %}} 
## **Nyilvános API és visszafelé nem kompatibilis változások**
### **Hozzáadott osztályok és metódusok**
#### **Hozzáadva az Aspose.Slides.IPresentationInfo interfész és a PresentationInfo osztályok**
Az előadás információit reprezentálja.

A Boolean isEncrypted() metódus True értéket ad, ha az előadás titkosított, egyébként False értéket ad.

A LoadFormat getLoadFormat() metódus visszaadja az előadás típusát.
#### **Hozzáadva az Aspose.Slides.IShape.isGrouped() metódus**
Az Aspose.Slides.IShape.isGrouped() metódus meghatározza, hogy a forma csoportosított-e.
#### **Hozzáadva az Aspose.Slides.IShape.getParentGroup() metódus**
Az Aspose.Slides.IShape.getParentGroup() metódus visszaadja a szülő GroupShape objektumot, ha a forma csoportosított. Ellenkező esetben null értéket ad vissza.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.addGroupShape() metódus**
Az Aspose.Slides.IShapeCollection.addGroupShape() metódus új GroupShape objektumot hoz létre, és a gyűjtemény végéhez adja hozzá.

A GroupShape keret mérete és pozíciója a tartalomhoz igazodik, amikor új forma kerül a GroupShape-be.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.clear() metódus**
Az Aspose.Slides.IShapeCollection.clear() metódus eltávolítja az összes formát a gyűjteményből.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.insertGroupShape(int) metódus**
Az Aspose.Slides.IShapeCollection.insertGroupShape(int) metódus új GroupShape objektumot hoz létre, és a megadott indexnél illeszti be a gyűjteménybe.

A GroupShape keret mérete és pozíciója a tartalomhoz igazodik, amikor új forma kerül a GroupShape-be.
#### **Hozzáadva az IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) metódusok**
Ezek a metódusok lehetővé teszik a fejlesztők számára, hogy információt kapjanak egy előadásfájlról/fájlról beolvasás nélkül, a teljes prezentáció betöltése nélkül.
#### **Hozzáadva az IPresentationFactory PresentationFactory.getInstance() metódus**
Lehetővé teszi a gyár funkcióinak használatát példányosítás nélkül.
### **Korlátozások**
#### **Korlátozások kerültek bevezetésre a IShape.getFrame() számára meghatározatlan értékek használatára**
Az a kód, amely megpróbál meghatározatlan keretet rendelni az IShape.setFrame(IShapeFrame) metódushoz, általános esetben nem értelmezhető (különösen, ha a szülő GroupShape többszörösen be van ágyazva más {{GroupShape}}kbe). Például:
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // ArgumentException-t dob: a keret értékeknek definiáltnak kell lenniük.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```
vagy
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ArgumentException-t dob: az x, y, szélesség és magasság értékeknek definiáltnak kell lenniük.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```
Az ilyen kód félreérthető helyzetekhez vezethet. Ezért korlátozások kerültek bevezetésre a IShape.Frame meghatározatlan értékeinek használatára. Az x, y, szélesség, magasság, flipH, flipV és rotationAngle értékeknek definiáltnak kell lenniük (nem Float.NaN vagy NullableBool.NotDefined). A fenti példakód most ArgumentException kivételt dob.
Ez az alábbi felhasználási esetekre vonatkozik:
``` java
// Az IShape.setFrame(IShapeFrame) metódusnak átadott keret nem tartalmazhat meghatározatlan értékeket.

// A következő IShapeCollection metódusok x, y, szélesség és magasság paraméterei
// nem lehetnek Float.NaN értékek sem:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```
De az IShape.getRawFrame() keret lehet meghatározatlan. Ez akkor érthető, ha egy forma egy helykitöltőhöz van kapcsolva. Ebben az esetben a meghatározatlan formakeret értékeket a szülő helykitöltő forma felülírja. Ha nincs szülő helykitöltő forma a forma számára, akkor alapértelmezett értékeket használ, amikor a hatékony keretet az IShape.getRawFrame() alapján értékeli ki. Az alapértelmezett értékek 0 és NullableBool.False az x, y, szélesség, magasság, flipH, flipV és rotationAngle esetén. Például:
``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // A forma egy helykitöltőhöz van kapcsolva.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Most a forma örökli az x, y, magasság, flipH és flipV értékeket a helykitöltőtől
    // és felülírja a szélességet = 100 és a rotationAngle = 0 értékeket.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Módosított tulajdonságok**
#### **Megváltozott a típus és a név az Aspose.Slides.IShapeCollection.getParent() metódusnál**
Az Aspose.Slides.IShapeCollection.Parent tulajdonság típusa ISlideComponent-ról az új IGroupShape interfészre változott. Az IGroupShape interfész az ISlideComponent leszármazottja, így a meglévő kód nem igényel módosítást.

Az Aspose.Slides.IShapeCollection.getParent() metódus neve getParent-ról getParentGroup-ra módosult.
#### **A Aspose.Slides.IShapeFrame.getFlipH() és .getFlipV() metódusok típusának módosítása**
Az Aspose.Slides.IShapeFrame.getFlipH() metódus típusa bool-ról NullableBool-ra változott.

Az IShape.getFrame() metódus visszaadja az IShapeFrame hatékony példányát (mindez tulajdonságai definiált hatékony értékekkel rendelkeznek).

Az IShape.getRawFrame() metódus egy IShapeFrame példányt ad vissza, amelynek minden tulajdonsága lehet meghatározatlan érték (különösen a FlipH vagy FlipV értéke NullableBool.NotDefined lehet).