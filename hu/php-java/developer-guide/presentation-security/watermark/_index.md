---
title: Vízjelek hozzáadása prezentációkhoz PHP-ben
linktitle: Vízjel
type: docs
weight: 40
url: /hu/php-java/watermark/
keywords:
- vízjel
- szöveges vízjel
- képes vízjel
- vízjel hozzáadása
- vízjel módosítása
- vízjel eltávolítása
- vízjel törlése
- vízjel hozzáadása PPT-hez
- vízjel hozzáadása PPTX-hez
- vízjel hozzáadása ODP-hez
- vízjel eltávolítása PPT-ből
- vízjel eltávolítása PPTX-ből
- vízjel eltávolítása ODP-ből
- vízjel törlése PPT-ből
- vízjel törlése PPTX-ből
- vízjel törlése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Szöveges és képes vízjelek kezelése PowerPoint és OpenDocument prezentációkban PHP használatával, hogy vázlatot, bizalmas információt, szerzői jogi védelmet és egyebeket jelöljen."
---
## **Bevezetés**

**A vízjel** egy prezentációban szöveges vagy képes pecsét, amely egy dián vagy az összes prezentációs dián használható. Általában a vízjelet arra használják, hogy jelezze, hogy a prezentáció vázlat (például „Draft” vízjel), bizalmas információt tartalmaz („Confidential” vízjel), megadja, melyik vállalathoz tartozik („Company Name” vízjel), azonosítsa a prezentáció szerzőjét stb. A vízjel segít megakadályozni a szerzői jogi megsértéseket azzal, hogy jelzi, a prezentációt nem szabad másolni. A vízjelek a PowerPoint és az OpenOffice prezentációs formátumokban egyaránt használatosak. Az Aspose.Slides‑ben vízjelet adhat hozzá a PowerPoint PPT, PPTX és az OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/php-java/)‑ban többféle módon hozhat létre vízjeleket PowerPoint vagy OpenOffice dokumentumokban, és módosíthatja azok formáját és viselkedését. A közös pont az, hogy szöveges vízjelek hozzáadásához a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) osztályt kell használni, képes vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) osztályt, vagy egy kép kitöltésével a vízjel alakzatot. A `PictureFrame` a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályt valósítja meg, lehetővé téve az alakzat objektum minden rugalmas beállításának használatát. Mivel az `ITextFrame` nem alakzat, és beállításai korlátozottak, egy [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumba van becsomagolva.

Két módon lehet vízjelet alkalmazni: egyetlen diára vagy az összes prezentációs diára. A Diamester (Slide Master) használható a vízjel minden diára történő alkalmazásához – a vízjelet a Diamesterhez adják, ott teljesen megtervezik, és minden diára alkalmazzák, anélkül, hogy befolyásolja az egyes diákon a vízjel módosításának jogát.

A vízjelet általában úgy tekintik, hogy más felhasználók nem szerkeszthetik. A vízjel (pontosabban a vízjel szülő alakzata) szerkesztésének megakadályozásához az Aspose.Slides alakzatzárolási funkciót biztosít. Egy adott alakzatot zárolhatunk egy normál dián vagy a Diamesteren. Ha a vízjel alakzat a Diamesteren van zárolva, akkor minden prezentációs dián zárolt lesz.

Megadhatja a vízjel nevét, így a jövőben, ha törölni szeretné, a dia alakzatai között név alapján megtalálhatja.

A vízjelet bármilyen módon megtervezheti; azonban általában vannak közös jellemzők, mint a középre igazítás, forgatás, elülső pozíció stb. Az alábbi példákban bemutatjuk, hogyan használhatók ezek.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása egy diára**

A szöveges vízjel PPT, PPTX vagy ODP formátumban való hozzáadásához először alakzatot kell hozzáadni a diához, majd szöveges keretet ehhez az alakzathoz. A szöveges keretet a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) osztály képviseli. Ez a típus nem örököl a [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) osztályból, amelynek széles tulajdonságkészlete van a vízjel rugalmas pozicionálásához. Ezért a [TextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframe/) objektum egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) objektumba van becsomagolva. A vízjel szövegének hozzáadásához az alakzathoz használja a [addTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#addTextFrame) metódust az alábbiak szerint.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Lásd még" %}} 
- [Hogyan használjuk a TextFrame osztályt](/slides/hu/php-java/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása egy prezentációhoz**

Ha a teljes prezentációhoz (azaz egyszerre az összes diára) szeretne szöveges vízjelet hozzáadni, adja hozzá a [MasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/)‑hez. A logika ugyanaz, mint egyetlen diára történő vízjel hozzáadásakor – hozzon létre egy [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) objektumot, majd a [addTextFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#addTextFrame) metódussal adja hozzá a vízjelet.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Lásd még" %}} 
- [Hogyan használjuk a Diamestert](/slides/hu/php-java/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltő- és vonalszínekkel van formázva. A következő kódsorok átlátszóvá teszik az alakzatot.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **A szöveges vízjel betűtípusának beállítása**

Az alább látható módon megváltoztathatja a szöveges vízjel betűtípusát.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **A vízjel szövegének színének beállítása**

A vízjel szövegének színének beállításához használja ezt a kódot:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Szöveges vízjel középre helyezése**

Lehetőség van a vízjel középre helyezésére egy dián, ehhez a következőket teheti:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

Az alábbi kép mutatja a végső eredményt.

![A szöveges vízjel](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása egy prezentációhoz**

Képes vízjel hozzáadásához egy prezentációs diához a következőket teheti:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Vízjel szerkesztés elleni zárolása**

Ha szükséges megakadályozni a vízjel szerkesztését, használja a [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/#getAutoShapeLock) metódust az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kijelöléstől, átméretezéstől, áthelyezéstől, más elemekkel való csoportosítástól, a szöveg szerkesztésétől, és még sok mástól:

```php
// Zárolja a vízjel alakzatot a módosítástól
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Vízjel előre hozása**

Az Aspose.Slides‑ban az alakzatok Z-sorrendjét a [ShapeCollection.reorder](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#reorder) metódussal állíthatja be. Ehhez a metódust a prezentáció diáinak listájáról kell meghívni, és átadni a alakzat hivatkozását és a sorrendi számát. Így egy alakzatot előre hozhat, vagy hátra küldhet a dián. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció előterébe kell helyezni:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **A vízjel forgatásának beállítása**

Az alábbi kódrészlet bemutatja, hogyan állítható be a vízjel forgása úgy, hogy átlósan helyezkedjen el a dián:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **A vízjel nevének beállítása**

Az Aspose.Slides lehetővé teszi egy alakzat nevének beállítását. A forma nevét felhasználva a jövőben módosíthatja vagy törölheti azt. A vízjel alakzat nevének beállításához adja át a [AutoShape.setName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#setName) metódusnak:

```php
$watermarkShape->setName("watermark");
```

### **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [AutoShape.getName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getName) metódust a dia alakzatai között való megtaláláshoz. Ezután adja át a vízjel alakzatot a [ShapeCollection.remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#remove) metódusnak:

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **GYIK**

**Mi az a vízjel és miért kellene használnom?**

A vízjel egy szöveges vagy képes átfedés, amely a diákra kerül, és segít megvédeni a szellemi tulajdont, erősíti a márka felismerhetőségét, vagy megakadályozza a prezentációk jogosulatlan használatát.

**Hozzáadhatok vízjelet az összes diához egy prezentációban?**

Igen, az Aspose.Slides lehetővé teszi, hogy programozott módon vízjelet adjon minden diához egy prezentációban. Végig iterálhat a diákon, és egyenként alkalmazhatja a vízjel beállításait.

**Hogyan állíthatom be a vízjel átlátszóságát?**

A vízjel átlátszóságát a forma kitöltési beállításainak ([getFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getfillformat/)) módosításával állíthatja be. Ez biztosítja, hogy a vízjel finom legyen, és ne vonja el a figyelmet a dia tartalmáról.

**Milyen képformátumok támogatottak a vízjelekhez?**

Az Aspose.Slides számos képformátumot támogat, például PNG, JPEG, GIF, BMP, SVG és továbbiakat.

**Testreszabhatom a szöveges vízjel betűtípusát és stílusát?**

Igen, tetszőleges betűtípust, méretet és stílust választhat, hogy illeszkedjen a prezentáció tervezéséhez és megőrizze a márka konzisztenciáját.

**Hogyan változtathatom meg egy vízjel pozícióját vagy tájolását?**

A vízjel pozícióját és tájolását programozottan a forma koordinátáinak, méretének és forgatási tulajdonságainak módosításával állíthatja be.