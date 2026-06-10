---
title: "Vízjelek hozzáadása prezentációkhoz JavaScriptben"
linktitle: "Vízjel"
type: docs
weight: 40
url: /hu/nodejs-java/watermark/
keywords:
- "vízjel"
- "szöveges vízjel"
- "képes vízjel"
- "vízjel hozzáadása"
- "vízjel módosítása"
- "vízjel eltávolítása"
- "vízjel törlése"
- "vízjel hozzáadása PPT-hez"
- "vízjel hozzáadása PPTX-hez"
- "vízjel hozzáadása ODP-hez"
- "vízjel eltávolítása PPT-ből"
- "vízjel eltávolítása PPTX-ből"
- "vízjel eltávolítása ODP-ből"
- "vízjel törlése PPT-ből"
- "vízjel törlése PPTX-ből"
- "vízjel törlése ODP-ből"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Kezelje a szöveges és képes vízjeleket PowerPoint és OpenDocument prezentációkban Node.js környezetben, hogy jelölje a vázlatot, bizalmas információkat, szerzői jogi védelmet és egyebeket."
---
## **Bevezetés**

**A vízjel** egy prezentációban egy szöveges vagy képes bélyeg, amelyet egy dián vagy az összes dián használnak. Általában a vízjelet arra használják, hogy jelezze, a prezentáció egy vázlat (például „Draft” vízjel), hogy bizalmas információkat tartalmaz („Confidential” vízjel), megadja, melyik céghez tartozik („Company Name” vízjel), az előadó azonosítására stb. A vízjel segít megelőzni a szerzői jogi megsértéseket, jelezve, hogy a prezentációt nem szabad másolni. A vízjelek a PowerPoint és az OpenOffice prezentációs formátumokban is használatosak. Az Aspose.Slides segítségével vízjelet adhat hozzá a PowerPoint PPT, PPTX és OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/nodejs-java/) különböző módokat kínál a vízjelek létrehozására PowerPoint vagy OpenOffice dokumentumokban, valamint azok tervezésének és viselkedésének módosítására. A közös vonás, hogy szöveges vízjelek hozzáadásához a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) típust kell használni, képes vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) osztályt vagy egy kép kitöltését a vízjel alakzatban. A `PictureFrame` megvalósítja a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) típust, lehetővé téve az alakzat objektum összes rugalmas beállításának használatát. Mivel a `TextFrame` nem alakzat, és beállításai korlátozottak, egy [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumba van becsomagolva.

Két módon lehet vízjelet alkalmazni: egyetlen diára vagy az összes prezentációs diára. A Dia Mester (Slide Master) használatos a vízjel az összes diára történő alkalmazásához – a vízjel a Slide Masterhez kerül hozzáadásra, ott teljesen megtervezve, és minden diára alkalmazásra kerül anélkül, hogy befolyásolná a vízjel egyedi diákon történő módosításának engedélyét.

A vízjelet általában úgy tekintik, hogy más felhasználók nem szerkeszthetik. A vízjel (pontosabban a vízjel szülő alakzata) szerkesztésének megakadályozásához az Aspose.Slides alakzat-zárolási funkciót biztosít. Egy adott alakzatot zárolhat a normál dián vagy a Slide Masteren. Ha a vízjel alakzat a Slide Masteren van zárolva, akkor az minden prezentációs dián zárolva lesz.

Beállíthat nevet a vízjelnek, így a jövőben, ha törölni szeretné, a név alapján megtalálhatja a diák alakzatai között.

A vízjelet bármilyen módon megtervezheti; általában azonban a vízjelek közös jellemzőkkel rendelkeznek, mint a középre igazítás, forgatás, előre helyezés stb. Az alábbi példákban megvizsgáljuk, hogyan használhatók ezek.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása a diára**
A szöveges vízjel PPT, PPTX vagy ODP fájlokhoz először egy alakzatot kell a diára tenni, majd egy szövegkeretet ehhez az alakzathoz hozzáadni. A szövegkeret a [**TextFrame**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame) típussal van reprezentálva. Ez a típus nem örököl a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape) osztályból, amely széles körű tulajdonságokkal rendelkezik a vízjel rugalmas pozicionálásához. Ezért a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/TextFrame) objektum egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) objektumba van beágyazva. A vízjel szövegének hozzáadásához az alakzathoz használja a [**addTextFrame**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) metódust, amelybe a vízjel szöveget adja át:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- How to use [TextFrame](/slides/hu/nodejs-java/text-formatting/).
{{% /alert %}}

### **Szöveges vízjel hozzáadása a prezentációhoz**

Ha a teljes prezentációhoz (azaz egyszerre az összes diához) szeretne szöveges vízjelet adni, tegye azt a [**MasterSlide**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterSlide)hez. A logika ugyanaz, mint egyetlen diára történő vízjel hozzáadásánál – hozzon létre egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) objektumot, majd a [**addTextFrame**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) metódussal adja hozzá a vízjelet:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/hu/nodejs-java/slide-master/)[Slide Master](/slides/hu/nodejs-java/slide-master/)
{{% /alert %}}

### **Vízjel alakzat átlátszóságának beállítása**

Alapértelmezésben a téglalap alakzat töltő- és vonalszínekkel van formázva. Az alábbi kódsorok az alakzatot átlátszóvá teszik.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **A szöveges vízjel betűtípusának beállítása**

Az alábbiak szerint módosíthatja a szöveges vízjel betűtípusát.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **A vízjel szövegének színének beállítása**

A vízjel szövegének színét a következő kóddal állíthatja be:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Szöveges vízjel központosítása**
Lehetséges a vízjelet középre helyezni a dián, ehhez tegye a következőket:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Az alábbi kép mutatja a végső eredményt.

![A szöveges vízjel](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása egy prezentációhoz**

A képes vízjel minden prezentációs diához való hozzáadásához a következőt teheti:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Vízjel szerkesztés elleni zárolása**

Ha szükséges megakadályozni a vízjel szerkesztését, használja a [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape#getShapeLock--) metódust az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, más elemekkel való csoportosítástól, a szöveg szerkesztésétől és még sok mástól:

```javascript
// Zárolja a vízjel alakzatot a módosítástól
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Vízjel előre hozása**

Az Aspose.Slides-ben az alakzatok Z-sorrendjét a [**SlideCollection.reorder**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) metódussal állíthatja be. Ehhez a prezentáció diák listájából hívja meg a metódust, és adja át az alakzat hivatkozását és a kívánt sorrendi számot. Így előre hozhat egy alakzatot vagy a hátoldalra helyezheti a dián. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció előteré kell helyezni:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Vízjel forgatásának beállítása**

Az alábbi kódrészlet bemutatja, hogyan állíthatja be a vízjel forgását, hogy átlósan helyezkedjen el a dián:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Vízjel nevének beállítása**

Az Aspose.Slides lehetővé teszi az alakzat nevének beállítását. A név használatával a későbbiekben módosíthatja vagy törölheti azt. A vízjel alakzat nevének beállításához rendelje a [**AutoShape.getName**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getName--) metódushoz:

```javascript
watermarkShape.setName("watermark");
```

### **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja az [AutoShape.getName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getName--) metódust a diák alakzatai között történő megtalálásához. Ezután adja át a vízjel alakzatot a [**ShapeCollection.remove**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) metódusnak:

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **GYIK**

**Mi az a vízjel, és miért kellene használnom?**

A vízjel egy szöveges vagy képes átfedés, amely a diákra kerül, és segít megvédeni a szellemi tulajdont, erősíti a márka ismertségét, vagy megakadályozza a prezentációk jogosulatlan felhasználását.

**Hozzáadhatok vízjelet a prezentáció minden diájához?**

Igen, az Aspose.Slides lehetővé teszi a vízjel minden diára történő felvitelét. A diákon végig iterálva egyenként alkalmazhatja a vízjel beállításait.

**Hogyan állíthatom be a vízjel átlátszóságát?**

Az átlátszóságot a alakzat [fill settings](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getfillformat/) módosításával állíthatja be, így a vízjel diszkrét marad és nem vonja el a figyelmet a dia tartalmáról.

**Milyen képformátumok támogatottak a vízjelekhez?**

Az Aspose.Slides több képformátumot támogat, úgymint PNG, JPEG, GIF, BMP, SVG és még sok más.

**Testreszabhatom a szöveges vízjel betűtípusát és stílusát?**

Igen, bármely betűtípust, méretet és stílust választhat, hogy az megfeleljen a prezentáció tervezésének és a márkakövetkezetességnek.

**Hogyan változtathatom meg a vízjel pozícióját vagy tájolását?**

A pozíciót és a tájolást az alakzat koordinátáinak, méretének és forgatási tulajdonságainak módosításával állíthatja be.