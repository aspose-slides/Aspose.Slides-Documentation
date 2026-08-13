---
title: Publikus API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.5.0-ban
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és visszafelé nem kompatibilis változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) osztályt, metódust, tulajdonságot stb., valamint az új [korlátozásokat](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) és egyéb [változásokat](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) a Aspose.Slides for .NET 14.5.0 API-val.

{{% /alert %}} 
## **Publikus API és visszafelé nem kompatibilis változások**
### **Hozzáadott interfészek, osztályok, tulajdonságok és metódusok**
#### **Hozzáadva az Aspose.Slides.IPresentationInfo interfész és a PresentationInfo osztály**
A prezentáció információit képviseli.

- Az IsEncrypted logikai (Boolean) tulajdonság True értéket ad, ha a prezentáció titkosított, egyébként False értéket ad.
- A LoadFormat tulajdonság visszaadja a prezentáció típusát.
#### **Hozzáadva az Aspose.Slides.IShape.IsGrouped tulajdonság**
- Az Aspose.Slides.IShape.IsGrouped tulajdonság meghatározza, hogy egy alakzat csoportosított-e.
#### **Hozzáadva az Aspose.Slides.IShape.ParentGroup tulajdonság**
- Az Aspose.Slides.IShape.ParentGroup tulajdonság visszaadja a szülő GroupShape objektumot, ha az alakzat csoportosított. Különben null értéket ad.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.AddGroupShape() metódus**
- Az Aspose.Slides.IShapeCollection.AddGroupShape() metódus egy új GroupShape-et hoz létre, és a gyűjtemény végéhez adja.
- A GroupShape keretmérete és pozíciója a tartalomhoz igazodik, amikor új alakzat kerül hozzá.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.Clear() metódus**
- Az Aspose.Slides.IShapeCollection.Clear() metódus eltávolítja az összes alakzatot a gyűjteményből.
#### **Hozzáadva az Aspose.Slides.IShapeCollection.InsertGroupShape(int) metódus**
- Az Aspose.Slides.IShapeCollection.InsertGroupShape(int) metódus egy új GroupShape-et hoz létre, és a megadott indexpozícióba illeszti a gyűjteménybe.
- A GroupShape keretmérete és pozíciója a tartalomhoz igazodik, amikor új alakzat kerül hozzá.
#### **Hozzáadva az IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) metódusok**
- Ezek a metódusok lehetővé teszik egy prezentáció fájl vagy adatfolyam információinak lekérését a teljes betöltés nélkül.
#### **Hozzáadva az IPresentationFactory PresentationFactory.Instance tulajdonság**
- Ez a tulajdonság lehetővé teszi a fejlesztők számára a gyári funkcionalitás használatát példányosítás nélkül.
### **Korlátozások**
#### **Korlátozások az IShape.Frame-re**
Korlátozások kerültek bevezetésre az IShape.Frame undefined (nem definiált) értékek használatára. Az a kód, amely megpróbál egy undefined keretet hozzárendelni az IShape.Frame-hez, a legtöbb esetben értelmetlen (különösen akkor, ha a szülő GroupShape több szintben be van ágyazva más {{GroupShape}}-ekbe). Például:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// ArgumentException-t dob: a keretértékeknek definiáltnak kell lenniük.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

vagy

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// ArgumentException-t dob: az x, y, szélesség és magasság értékeknek definiálva kell lenniük.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Az ilyen kód nem egyértelmű helyzetekhez vezethet. Ezért korlátozások lettek bevezetve az IShape.Frame nem definiált értékeinek használatára. Az x, y, width, height, flipH, flipV és rotationAngle értékeket definiálni kell (és nem lehetnek float.NaN vagy NullableBool.NotDefined). A fenti példakód most ArgumentException kivételt dob.
Ez az alábbi felhasználási esetekre vonatkozik:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Az x, y, szélesség és magasság paraméterek nem lehetnek float.NaN, és a flipH, flipV
// nem lehet NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Ugyanez a korlátozás minden alakzatot létrehozó metódusra érvényes:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Azonban az IShape.RawFrame keret tulajdonságai lehetnek nem definiáltak. Ez akkor érthető, ha egy alakzat egy helyőrzőhöz van kapcsolva. Ebben az esetben a nem definiált alakzatteret értékeket a szülő helyőrző alakzat felülírja. Ha nincs szülő helyőrző alakzat, akkor az alakzat az alapértelmezett értékeket használja, amikor a hatékony keretet az IShape.RawFrame alapján számítja ki. Az alapértelmezett értékek 0 és NullableBool.False az x, y, width, height, flipH, flipV és rotationAngle esetében. Például:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Az alakzat egy helyőrzőhöz van kapcsolva
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // most az alakzat örökli az x, y, magasság, flipH, flipV értékeket a helyőrzőtől, és felülírja a szélességet=100 és a rotationAngle=0‑t.
}
``` 
### **Módosított tulajdonságok**
#### **Módosítva az Aspose.Slides.IShapeCollection.Parent tulajdonság neve és típusa**
- Az Aspose.Slides.IShapeCollection.Parent tulajdonság típusa ISlideComponent-ról az új IGroupShape interfészre változott. Az IGroupShape interfész az ISlideComponent leszármazottja, ezért a meglévő kódnak nem igényel módosítást.
- Az Aspose.Slides.IShapeCollection.Parent tulajdonság neve Parent-ról ParentGroup-ra változott.
#### **Módosítva az Aspose.Slides.IShapeFrame.FlipH, .FlipV tulajdonságok típusa**
- Az Aspose.Slides.IShapeFrame.FlipH tulajdonság típusa bool-ról NullableBool-ra változott.
- Az IShape.Frame tulajdonság egy hatékony IShapeFrame példányt ad vissza (amelynek minden tulajdonsága definiált hatékony értékkel rendelkezik).
- Az IShape.RawFrame tulajdonság egy IShapeFrame példányt ad vissza, amelynek minden egyes tulajdonsága lehet nem definiált érték (különösen a FlipH vagy a FlipV értéke lehet NullableBool.NotDefined).