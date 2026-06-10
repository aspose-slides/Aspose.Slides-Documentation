---
title: Vízjelek hozzáadása prezentációkhoz Androidon
linktitle: Vízjel
type: docs
weight: 40
url: /hu/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Kezelje a szöveges és képes vízjeleket PowerPoint és OpenDocument prezentációkban Androidon Java nyelven, hogy jelezze a vázlatot, a bizalmas információkat és egyebeket."
---
## **Bevezetés**

**A vízjel** egy prezentációban szöveges vagy képes bélyegző, amely egy dián vagy az összes dián jelenik meg. Általában a vízjelet arra használják, hogy jelezzék, hogy a prezentáció vázlat (például egy „Draft” vízjel), bizalmas információkat tartalmaz („Confidential” vízjel), hogy melyik céghez tartozik („Company Name” vízjel), vagy hogy ki a szerző, stb. A vízjel segít megelőzni a szerzői jogok megsértését, mivel jelzi, hogy a prezentációt nem szabad másolni. A vízjelek a PowerPoint és az OpenOffice prezentációs formátumokban is használhatók. Az Aspose.Slides segítségével vízjelet adhat hozzá PowerPoint PPT, PPTX és OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/android-java/) különböző módokat kínál vízjelek létrehozására PowerPoint vagy OpenOffice dokumentumokban, valamint azok megjelenésének és viselkedésének módosítására. A közös pont, hogy szöveges vízjelek hozzáadásához a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) interfészt kell használni, képes vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) osztályt vagy egy alakzat kitöltését képpel. A `PictureFrame` megvalósítja a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) interfészt, így az alakzat objektum összes rugalmas beállítása elérhető. Mivel az `ITextFrame` nem alakzat, és beállításai korlátozottak, egy [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) objektumba van csomagolva.

Kétféleképpen alkalmazható a vízjel: egyetlen diára vagy az összes prezentációs diára. A Slide Master segítségével a vízjel az összes diára alkalmazható – a vízjel a Slide Masterhez adódik, ott teljesen megtervezhető, és minden diára kiterjed anélkül, hogy befolyásolná a vízjel egyedi diákról való módosítási engedélyét.

A vízjelet általában úgy tekintik, hogy más felhasználók számára nem szerkeszthető. A vízjel (pontosabban a vízjel szülő alakzata) szerkesztésének megakadályozására az Aspose.Slides alakzat-zárolási funkciót kínál. Egy adott alakzat lezárható egy normál dián vagy a Slide Masteren. Ha a vízjel alakzata a Slide Masteren van lezárva, akkor az minden prezentációs dián lezárva lesz.

A vízjelnek nevet is adhat, így a jövőben, ha törölni szeretné, a név alapján könnyen megtalálható a diák alakzatai között.

A vízjelet tetszőlegesen megtervezheti; a gyakorlatban azonban gyakori jellemzői a középre igazítás, forgatás, előre helyezés stb. Az alábbi példákban bemutatjuk, hogyan használhatók ezek.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása egy diához**

Szöveges vízjel hozzáadásához PPT, PPTX vagy ODP formátumban először alakzatot adunk a diához, majd egy szövegkeretet ehhez az alakzathoz. A szövegkeret a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) interfész által van képviselve. Ez a típus nem örököl a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/)‑ből, amely széles körű tulajdonságokkal rendelkezik a vízjel rugalmas elhelyezéséhez. Ezért a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumba van csomagolva. A vízjel szövegének hozzáadásához használja a [addTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metódust az alább látható módon.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Lásd még" %}} 
- [A TextFrame osztály használata](/slides/hu/androidjava/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása a prezentációhoz**

Ha a teljes prezentációra (azaz egyszerre az összes diára) szeretne szöveges vízjelet hozzáadni, tegye azt a [MasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterslide/)‑ba. A logika megegyezik egy diára történő hozzáadással – hozzon létre egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot, majd a [addTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metódussal adja hozzá a vízjelet.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Lásd még" %}} 
- [A Slide Master használata](/slides/hu/androidjava/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonalszínekkel van formázva. Az alábbi kódrészlet átlátszóvá teszi az alakzatot.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **A szöveges vízjel betűtípusának beállítása**

Az alábbiak szerint módosíthatja a szöveges vízjel betűtípusát.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **A vízjel szövegszínének beállítása**

A vízjel szövegszínét a következő kóddal állíthatja be:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Szöveges vízjel középre igazítása**

A vízjel középre helyezhető a dián, ezt az alábbiak szerint teheti meg:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Az alábbi kép mutatja a végleges eredményt.

![A szöveges vízjel](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása a prezentációhoz**

Képes vízjel egy prezentációs diára a következő módon adható hozzá:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Vízjel szerkesztésének letiltása**

Ha meg kell akadályozni a vízjel szerkesztését, használja a [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) metódust az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, csoportosítástól, a szöveg szerkesztésétől és egyéb műveletektől:

```java
// Zárolja a vízjel alakzatot a módosítástól
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Vízjel előre hozása**

Az Aspose.Slides-ben az alakzatok Z-sorrendjét a [IShapeCollection.reorder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) metódussal állítható be. Ehhez a prezentáció diái listájától kell meghívni a metódust, és átadni az alakzat referenciáját valamint a kívánt sorrendi számot. Így a alakzatot előre vagy hátra helyezheti a dián. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció előterébe szeretné helyezni:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **A vízjel forgatásának beállítása**

Az alábbi kódrészlet bemutatja, hogyan állítható be a vízjel forgása, hogy átlósan helyezkedjen el a dián:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Név megadása a vízjelnek**

Az Aspose.Slides lehetővé teszi az alakzat nevének beállítását. A név használatával a jövőben könnyen elérhető a módosítás vagy törlés céljából. A vízjel alakzat nevének beállításához rendelje a [IAutoShape.setName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) metódushoz:

```java
watermarkShape.setName("watermark");
```

### **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [IAutoShape.getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getName--) metódust a diák alakzatai közül való megtalálásához. Ezután adja át a vízjel alakzatot a [IShapeCollection.remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) metódusnak:

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

**Mi az a vízjel, és miért kellene használni?**

A vízjel egy szöveges vagy képes átfedés, amely a diákra kerül, segít megvédeni a szellemi tulajdont, erősíti a márkaazonosítást, vagy megakadályozza a prezentációk jogosulatlan felhasználását.

**Hozzáadhatok vízjelet az összes diához a prezentációban?**

Igen, az Aspose.Slides programozott módon lehetővé teszi a vízjel hozzáadását minden diához. Az összes diát végigjárva egyesével alkalmazhatja a vízjel beállításait.

**Hogyan állíthatom be a vízjel átlátszóságát?**

Az alakzat kitöltési beállításait ([getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getFillFormat--)) módosítva állíthatja be a vízjel átlátszóságát. Így a vízjel diszkrét marad, és nem vonja el a figyelmet a dia tartalmáról.

**Milyen képformátumok támogatottak a vízjelekhez?**

Az Aspose.Slides számos képformátumot támogat, például PNG, JPEG, GIF, BMP, SVG és továbbiakat.

**Testreszabhatom a szöveges vízjel betűtípusát és stílusát?**

Igen, bármely betűtípust, méretet és stílust kiválaszthat a prezentáció tervezéséhez és a márkakövetkezetesség fenntartásához.

**Hogyan változtathatom meg a vízjel pozícióját vagy orientációját?**

Programozottan módosíthatja az alakzat koordinátáit, méretét és forgatási tulajdonságait a vízjel pozíciójának és orientációjának beállításához.