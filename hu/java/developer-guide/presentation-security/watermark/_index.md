---
title: Vízjelek hozzáadása prezentációkhoz Java nyelven
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
description: "Kezelje a szöveges és képes vízjeleket PowerPoint és OpenDocument prezentációkban Java nyelven, hogy jelezze a vázlatot, bizalmas információkat, szerzői jogot és egyebeket."
---
## **Bevezetés**

**A vízjel** egy prezentációban egy szöveges vagy képes pecsét, amelyet egy diára vagy az összes diához alkalmaznak. Általában a vízjelet arra használják, hogy jelezzék, hogy a prezentáció vázlat (például „Draft” vízjel), bizalmas információkat tartalmaz („Confidential” vízjel), megmutassák, melyik céghez tartozik („Company Name” vízjel), azonosítsák a szerzőt stb. A vízjel segít megelőzni a szerzői jog megsértését, mivel jelzi, hogy a prezentációt nem szabad másolni. A vízjelek a PowerPoint és az OpenOffice prezentációs formátumokban egyaránt használhatók. Az Aspose.Slides‑ben hozzáadhat vízjelet a PowerPoint PPT, PPTX és OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/java/)-ben többféle módon hozhat létre vízjeleket PowerPoint vagy OpenOffice dokumentumokban, és módosíthatja azok megjelenését és viselkedését. A közös vonás, hogy szöveges vízjel hozzáadásához az [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) interfészt kell használni, képes vízjelhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pictureframe/) osztályt vagy egy kép kitöltését a vízjel alakzatra. A `PictureFrame` a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) interfészt valósítja meg, így az alakzat összes rugalmas beállítását használhatja. Mivel az `ITextFrame` nem alakzat, be van csomagolva egy [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) objektumba.

Két módon alkalmazható a vízjel: egyetlen diára vagy az összes diára. A Slide Master segítségével a vízjel az összes diára kiterjeszthető – a vízjel a Slide Master‑hez kerül hozzáadásra, ott teljesen megtervezve, és minden diához hozzáadódik anélkül, hogy befolyásolná a vízjel egyedi diákra vonatkozó módosítási jogosultságát.

A vízjelet általában nem szerkeszthetővé teszik más felhasználók számára. A vízjel (vagy inkább a vízjel szülő alakzata) szerkesztésének megakadályozásához az Aspose.Slides alakzatzár funkciót kínál. Egy adott alakzat lezárható egy normál dián vagy a Slide Master‑en. Ha a vízjel alakzat a Slide Master‑en van lezárva, akkor az összes dián le lesz zárva.

Megadhat egy nevet a vízjelnek, így a későbbiekben a név alapján könnyen megtalálhatja és törölheti a diák alakzatai között.

A vízjelet bármilyen módon megtervezheti; általában közös jellemzők vannak, mint például középre igazítás, elforgatás, előre helyezés stb. Az alábbi példákban ezeket a lehetőségeket mutatjuk be.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása egy diához**

A szöveges vízjel hozzáadásához PPT, PPTX vagy ODP formátumban először egy alakzatot kell hozzáadni a diához, majd egy szövegtáblázatot (text frame) ehhez az alakzathoz. A szövegtáblázatot az [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) interfész képviseli. Ez a típus nem öröklődik az [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/)‑ből, amely számos pozicionálási tulajdonságot biztosít a vízjel rugalmas elhelyezéséhez. Ezért az [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumba van csomagolva. A vízjel szövegének hozzáadásához használd a [addTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metódust az alábbiak szerint.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Lásd még" %}} 
- [A TextFrame osztály használata](/slides/hu/java/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása a teljes prezentációhoz**

Ha a teljes prezentációhoz (azaz egyszerre az összes diához) szeretnél szöveges vízjelet hozzáadni, tedd azt a [MasterSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterslide/)-hez. A logika megegyezik egyetlen diához való hozzáadással – hozz létre egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot, majd a [addTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metódussal add hozzá a vízjelet.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Lásd még" %}} 
- [A Slide Master használata](/slides/hu/java/slide-master/)
{{% /alert %}}

### **A vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonalszínnel rendelkezik. Az alábbi kódsorok átlátszóvá teszik az alakzatot.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **A szöveges vízjel betűtípusának beállítása**

Az alábbiak szerint módosíthatod a szöveges vízjel betűtípusát.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **A vízjel szövegszínének beállítása**

A vízjel szövegének színét a következő kóddal állíthatod be:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **A szöveges vízjel középre helyezése**

A vízjelet középre helyezheted a dián, az alábbi módon:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Az alábbi kép mutatja a végleges eredményt.

![The text watermark](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása a prezentációhoz**

Képes vízjel hozzáadásához egy prezentációs diára kövesd az alábbi lépéseket:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **A vízjel szerkesztés elleni zárolása**

Ha meg kell akadályozni, hogy a vízjelet szerkesszék, használd az [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) metódust az alakzaton. Ezzel a tulajdonsággal megvédheted az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, csoportosítástól, a szöveg szerkesztés elleni zárolástól és még sok mást:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Zárolja a vízjel alakzatot a módosítástól
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **A vízjel előre hozatala**

Az Aspose.Slides‑ben az alakzatok Z-sorrendjét a [IShapeCollection.reorder](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) metódussal állíthatod be. Ehhez a metódust a prezentáció diáinak listájáról kell meghívni, és átadni az alakzat referenciáját és a kívánt sorrend számát. Így a vízjelet előre vagy hátra helyezheted a dián. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció előterébe szeretnéd tenni:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **A vízjel elforgatásának beállítása**

Az alábbi kódrészlet megmutatja, hogyan állítható be a vízjel elforgatása, hogy átlósan helyezkedjen el a dián:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Név megadása a vízjelnek**

Az Aspose.Slides lehetővé teszi egy alakzat nevének beállítását. A név használatával a jövőben könnyen elérheted, módosíthatod vagy törölheted az alakzatot. A vízjel alakzat nevének beállításához rendeld hozzá a [IAutoShape.setName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setName-java.lang.String-) metódust:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használd az [IAutoShape.getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getName--) metódust a diák alakzatai között történő kereséshez. Ezután add át a megtalált vízjel alakzatot a [IShapeCollection.remove](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) metódusnak:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **GYIK**

### Mi a vízjel és miért kellene használnom?

A vízjel egy szöveges vagy képes átfedés, amely a diákra kerül, segít megvédeni a szellemi tulajdont, erősíti a márka felismerhetőségét, vagy megakadályozza a prezentációk jogosulatlan használatát.

### Hozzáadhatok vízjelet az összes diához egy prezentációban?

Igen, az Aspose.Slides lehetővé teszi, hogy programozott módon vízjelet adj hozzá minden diához egy prezentációban. Egyszerűen végigiterálhatsz az összes dián, és egyenként alkalmazhatod a vízjel beállításait.

### Hogyan állíthatom be a vízjel átlátszóságát?

Az átlátszóságot a alakzat kitöltési beállításainak módosításával szabályozhatod ([getFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getFillFormat--)). Így a vízjel visszafogott lesz, és nem vonja el a figyelmet a diá tartalmáról.

### Milyen képformátumokat támogat a vízjelhez?

Az Aspose.Slides számos képformátumot támogat, például PNG, JPEG, GIF, BMP, SVG és még sok más.

### Testreszabhatom a szöveges vízjel betűtípusát és stílusát?

Igen, tetszőleges betűtípust, méretet és stílust választhatsz, hogy a vízjel illeszkedjen a prezentáció tervezéséhez és a márka konzisztenciájához.

### Hogyan változtathatom meg a vízjel pozícióját vagy orientációját?

Programozottan módosíthatod a vízjel pozícióját és orientációját az alakzat koordinátáinak, méretének és elforgatási tulajdonságainak megváltoztatásával.