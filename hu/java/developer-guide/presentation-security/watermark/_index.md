---
title: Vízjelek hozzáadása prezentációkhoz Java-ban
linktitle: Vízjel
type: docs
weight: 40
url: /hu/java/watermark/
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
- Java
- Aspose.Slides
description: "Szöveges és képes vízjelek kezelése PowerPoint és OpenDocument prezentációkban Java segítségével, hogy jelezze a vázlatot, bizalmas információt, szerzői jogot stb."
---
## **Bevezetés**

**A vízjel** egy prezentációban szöveg vagy kép pecsét, amelyet egy dián vagy az összes dián használunk. Általában a vízjelet arra használják, hogy jelezze, hogy a bemutató vázlat (például egy „Draft” vízjel), bizalmas információt tartalmaz (például egy „Confidential” vízjel), hogy melyik céghez tartozik (például egy „Company Name” vízjel), a szerző azonosítására stb. A vízjel segít megelőzni a szerzői jogi jogsértéseket azzal, hogy jelzi, hogy a prezentációt nem szabad másolni. A vízjelek a PowerPoint és az OpenOffice prezentációs formátumokban egyaránt használatosak. Az Aspose.Slides-ben hozzáadhat vízjelet a PowerPoint PPT, PPTX és OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/java/) dokumentációban többféle módon hozhat létre vízjeleket PowerPoint vagy OpenOffice dokumentumokban, és módosíthatja azok tervezését és viselkedését. A közös vonás, hogy szöveges vízjelek hozzáadásához a [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) interfészt kell használni, képes vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) osztályt vagy egy kép kitöltését a vízjel alakzatra. A `PictureFrame` megvalósítja a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészt, így használhatja az alakzat objektum minden rugalmas beállítását. Mivel az `ITextFrame` nem alakzat és beállításai korlátozottak, egy [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) objektumba van becsomagolva.

Két módon alkalmazható a vízjel: egyetlen diára vagy az összes prezentációs diára. A Diamester használatos a vízjel minden diára való alkalmazásához – a vízjel a Diamesterhez kerül hozzáadva, ott teljesen megtervezve, és az összes diára alkalmazva, anélkül, hogy befolyásolná a vízjel egyedi diákon való módosításának engedélyét.

A vízjelet általában úgy tekintik, hogy más felhasználók számára nem szerkeszthető. A vízjel (vagy pontosabban a vízjel szülő alakzata) szerkesztésének megakadályozásához az Aspose.Slides alakzat-zárolási funkciót biztosít. Egy adott alakzatot le lehet zárni egy normál dián vagy egy Diamesteren. Ha a vízjel alakzat a Diamesteren le van zárva, akkor minden prezentációs dián le lesz zárva.

Megadhat egy nevet a vízjelnek, így a jövőben, ha törölni szeretné, név szerint megtalálhatja a diák alakzatai között.

A vízjelet bármilyen módon megtervezheti; azonban általában vannak közös jellemzők a vízjelekben, mint a középre igazítás, forgatás, előre helyezés stb. Az alábbi példákban megvizsgáljuk, hogyan használhatók ezek.

## **Szöveges Vízjel**

### **Szöveges Vízjel hozzáadása egy diához**

A szöveges vízjel PPT, PPTX vagy ODP formátumban történő hozzáadásához először alakzatot kell hozzáadni a diához, majd szövegtáblát ehhez az alakzathoz. A szövegtábla a [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) interfész által van képviselve. Ez a típus nem öröklődik a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/)‑től, amely széleskörű tulajdonságokkal rendelkezik a vízjel rugalmas elhelyezéséhez. Ezért a [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumba van becsomagolva. A vízjelszöveg hozzáadásához az alakzathoz használja a [addTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metódust az alábbiak szerint.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Lásd még" %}} 
- [A TextFrame osztály használata](/slides/hu/java/text-formatting/)
{{% /alert %}}

### **Szöveges Vízjel hozzáadása egy prezentációhoz**

Ha szöveges vízjelet szeretne hozzáadni a teljes prezentációhoz (azaz egyszerre az összes diára), akkor a [MasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterslide/)-hez adja hozzá. A logika ugyanaz, mint egyetlen diához történő vízjel hozzáadásakor – hozzon létre egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/)‑objektumot, majd a [addTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-)‑metódussal adja hozzá a vízjelet.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Lásd még" %}} 
- [A Diamester használata](/slides/hu/java/slide-master/)
{{% /alert %}}

### **A Vízjel Alakzat Átlátszóságának Beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonal színekkel van formázva. A következő kódsorok teszik az alakzatot átlátszóvá.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **A Szöveges Vízjel Betűtípusának Beállítása**

Módosíthatja a szöveges vízjel betűtípusát az alábbiak szerint.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **A Vízjel Szöveg Színének Beállítása**

A vízjel szöveg színének beállításához használja ezt a kódot:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Szöveges Vízjel Középre Igazítása**

Lehetséges a vízjelet a dián középre helyezni, ehhez a következőt teheti:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

![A szöveges vízjel](text_watermark.png)

## **Képes Vízjel**

### **Képes Vízjel hozzáadása egy prezentációhoz**

Hogy képes vízjelet adjunk hozzá egy prezentációs diához, a következőket tehetjük:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Vízjel Zárolása a Szerkesztéstől**

Ha szükséges megakadályozni a vízjel szerkesztését, használja a [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) metódust az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, más elemekkel való csoportosítástól, a szöveg szerkesztésétől, és még sok mástól:

```java
// Zárolja a vízjel alakzatot a módosítástól
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Vízjel Előre Hozása**

Az Aspose.Slides-ben az alakzatok Z-sorrendet a [IShapeCollection.reorder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) metódussal állíthatja be. Ehhez a metódust a prezentáció diái listájáról kell meghívni, és átadni az alakzat hivatkozását és a kívánt sorrend számát a metódusnak. Így lehet egy alakzatot előre hozni vagy hátra küldeni a dián. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció előtt szeretné elhelyezni:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Vízjel Forgatásának Beállítása**

Itt egy kódrészlet, amely bemutatja, hogyan állítható be a vízjel forgatása, hogy átlósan helyezkedjen el a dián:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Vízjel Nevének Beállítása**

Az Aspose.Slides lehetővé teszi egy alakzat nevének beállítását. A forma nevének használatával a jövőben elérheti azt módosításra vagy törlésre. A vízjel alakzat nevének beállításához adja át a [IAutoShape.setName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setName-java.lang.String-) metódusnak:

```java
watermarkShape.setName("watermark");
```

### **Vízjel Eltávolítása**

A vízjel alakzat eltávolításához használja a [IAutoShape.getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getName--) metódust, hogy megtalálja azt a diák alakzatai között. Ezután adja át a vízjel alakzatot a [IShapeCollection.remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) metódusnak:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **GYIK**

**Mi a vízjel és miért kellene használnom?**

A vízjel egy szöveges vagy képes átfedés, amely a diákra kerül, és segít megvédeni a szellemi tulajdont, növelni a márka ismertségét vagy megakadályozni a prezentációk jogosulatlan használatát.

**Hozzáadhatok vízjelet az összes diához egy prezentációban?**

Igen, az Aspose.Slides lehetővé teszi, hogy programozottan vízjelet adjunk minden diához egy prezentációban. Végigiterálhat az összes dián, és egyenként alkalmazhatja a vízjel beállításokat.

**Hogyan állíthatom be a vízjel átlátszóságát?**

Az átlátszóságot a forma kitöltési beállításainak módosításával ([getFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getFillFormat--)) szabályozhatja. Ez biztosítja, hogy a vízjel finom legyen, és ne vonja el a figyelmet a diák tartalmáról.

**Milyen képformátumok támogatottak a vízjelekhez?**

Az Aspose.Slides számos képformátumot támogat, például PNG, JPEG, GIF, BMP, SVG és továbbiakat.

**Testreszabhatom a szöveges vízjel betűtípusát és stílusát?**

Igen, választhat bármilyen betűtípust, méretet és stílust, hogy illeszkedjen a prezentáció tervezéséhez és megőrizze a márka egységességét.

**Hogyan változtathatom meg a vízjel pozícióját vagy tájolását?**

Programozottan módosíthatja a vízjel pozícióját és tájolását a forma koordinátáinak, méretének és forgatási tulajdonságainak módosításával.