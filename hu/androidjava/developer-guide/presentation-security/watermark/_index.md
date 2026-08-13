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
description: "Kezelje a szöveges és képes vízjeleket PowerPoint és OpenDocument prezentációkban Androidon Java nyelven, hogy vázlatot, bizalmas információkat és egyebet jelezzen."
---
## **Bevezetés**

**A vízjel** egy prezentációban szöveges vagy képes pecsét, amelyet egy diára vagy az összes diára alkalmaznak. Általában a vízjelet arra használják, hogy jelezze, a prezentáció vázlat (például „Draft” vízjel), hogy bizalmas információkat tartalmaz („Confidential” vízjel), megadja, melyik céghez tartozik („Company Name” vízjel), azonosítsa a prezentáció szerzőjét stb. A vízjel segít megakadályozni a szerzői jogok megsértését azzal, hogy jelzi, a prezentációt nem szabad másolni. A vízjeleket mind a PowerPoint, mind az OpenOffice prezentációformátumokban használják. Az Aspose.Slides segítségével vízjelet adhat hozzá a PowerPoint PPT, PPTX és OpenOffice ODP fájlformátumokhoz.

Az [**Aspose.Slides**](https://products.aspose.com/slides/hu/android-java/) különböző módokat kínál a vízjelek létrehozására PowerPoint vagy OpenOffice dokumentumokban, és azok kialakításának és viselkedésének módosítására. A közös vonás, hogy szöveges vízjelek hozzáadásához a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) interfészt kell használni, képes vízjelekhez pedig a [PictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pictureframe/) osztályt vagy egy kép feltöltését a vízjel alakzatra. A `PictureFrame` megvalósítja a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) interfészt, így az alakzat összes rugalmas beállítását használhatja. Mivel az `ITextFrame` nem alakzat, és beállításai korlátozottak, egy [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) objektumba van becsomagolva.

Két módon alkalmazható a vízjel: egyetlen diára vagy az összes prezentációs diára. A Dia Mester (Slide Master) használható a vízjel alkalmazására az összes dián – a vízjelet a Slide Masterhez adjuk, ott teljesen megtervezzük, és minden diára alkalmazzuk anélkül, hogy befolyásolná a vízjel egyes diákon történő módosítási jogát.

A vízjelet általában úgy tekintik, hogy más felhasználók számára nem szerkeszthető. A vízjel (vagy inkább a vízjel szülő alakzata) szerkesztésének megakadályozására az Aspose.Slides alakzatzárolási funkciót kínál. Egy adott alakzat zárolható egy normál dián vagy a Slide Masteren. Ha a vízjel alakzat a Slide Masteren zárolva van, akkor minden prezentációs dián zárolt lesz.

Beállíthat egy nevet a vízjelnek, így a jövőben, ha törölni szeretné, a dia alakzatai között név alapján megtalálhatja.

A vízjelet bármilyen módon megtervezheti; ugyanakkor általában vannak közös jellemzők, mint a középre igazítás, forgatás, előtér pozíció stb. Az alábbi példákban megvizsgáljuk, hogyan használhatók ezek.

## **Szöveges vízjel**

### **Szöveges vízjel hozzáadása diára**

A szöveges vízjel PPT, PPTX vagy ODP formátumban történő hozzáadásához először alakzatot kell hozzáadni a diához, majd egy szövegkeretet ehhez az alakzathoz. A szövegkeret a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) interfészt képviseli. Ez a típus nem örököl a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/)‑től, amely széles körű tulajdonságokkal rendelkezik a vízjel rugalmas elhelyezéséhez. Ezért a [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumba van becsomagolva. A vízjelszöveg hozzáadásához az alakzathoz használja a [addTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metódust az alábbiak szerint.

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
- [A TextFrame osztály használata](/slides/hu/androidjava/text-formatting/)
{{% /alert %}}

### **Szöveges vízjel hozzáadása prezentációhoz**

Ha a teljes prezentációhoz (azaz egyszerre az összes diára) szeretne szöveges vízjelet adni, akkor azt a [MasterSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterslide/)‑hez kell hozzáadni. A logika ugyanaz, mint egyetlen diára történő vízjel hozzáadásakor – hozzon létre egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) objektumot, majd a [addTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) metódussal adja hozzá a vízjelet.

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
- [A Slide Master használata](/slides/hu/androidjava/slide-master/)
{{% /alert %}}

### **Vízjel alakzat átlátszóságának beállítása**

Alapértelmezés szerint a téglalap alakzat kitöltési és vonalszínekkel van formázva. A következő kódsorok átlátszóvá teszik az alakzatot.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **A szöveges vízjel betűtípusának beállítása**

Az alábbiakban látható módon megváltoztathatja a szöveges vízjel betűtípusát.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **A vízjel szövegszínének beállítása**

A vízjel szövegszínének beállításához használja ezt a kódot:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Szöveges vízjel középre helyezése**

Lehetséges a vízjelet a dián középre helyezni, ehhez tegye a következőt:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

![A szöveges vízjel](text_watermark.png)

## **Képes vízjel**

### **Képes vízjel hozzáadása prezentációhoz**

Képes vízjel prezentációs diára való hozzáadásához tegye a következőt:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Vízjel zárolása a szerkesztéstől**

Ha szükséges megakadályozni a vízjel szerkesztését, használja a [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) metódust az alakzaton. Ezzel a tulajdonsággal megvédheti az alakzatot a kiválasztástól, átméretezéstől, áthelyezéstől, más elemekkel való csoportosítástól, szövegének szerkesztésétől és még sok mást:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Zárolja a vízjel alakzat módosítását
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Vízjel előre hozatala**

Az Aspose.Slides-ben az alakzatok Z-sorrendjét a [IShapeCollection.reorder](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) metódussal állíthatja be. Ehhez a prezentáció diáinak listájáról kell meghívni ezt a metódust, és átadni az alakzat hivatkozását valamint a kívánt sorrendi számot. Így egy alakzatot előre hozhat a dián, vagy hátra küldhet. Ez a funkció különösen hasznos, ha a vízjelet a prezentáció előterébe kell helyezni:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Vízjel forgásának beállítása**

Az alábbi kódrészlet mutatja, hogyan állítható be a vízjel forgása úgy, hogy átlósan helyezkedjen el a dián:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Név beállítása a vízjelhez**

Az Aspose.Slides lehetővé teszi egy alakzat nevének beállítását. A név használatával a jövőben hozzáférhet a vízjelhez módosítás vagy törlés céljából. A vízjel alakzat nevének beállításához rendelje hozzá a [IAutoShape.setName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) metódust:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Vízjel eltávolítása**

A vízjel alakzat eltávolításához használja a [IAutoShape.getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getName--) metódust a dia alakzatai közül való megtalálásához. Ezután adja át a vízjel alakzatot a [IShapeCollection.remove](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) metódusnak:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

### Mi a vízjel és miért kellene használni?

A vízjel egy szöveges vagy képes átfedés, amely a diákra kerül, és segít megvédeni a szellemi tulajdont, erősíti a márkaismertséget, vagy megakadályozza a prezentációk jogosulatlan használatát.

### Hozzáadhatok-e vízjelet minden diához egy prezentációban?

Igen, az Aspose.Slides lehetővé teszi, hogy programozott módon vízjelet adjunk minden diához egy prezentációban. Végigiterálhat az összes dián, és egyenként alkalmazhatja a vízjel beállításait.

### Hogyan állítható be a vízjel átlátszósága?

A vízjel átlátszóságát a forma kitöltési beállításainak módosításával állíthatja ([getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getFillFormat--)), így a vízjel finom lesz, és nem vonja el a figyelmet a dia tartalmától.

### Milyen képformátumok támogatottak a vízjelekhez?

Az Aspose.Slides számos képformátumot támogat, például PNG, JPEG, GIF, BMP, SVG és egyebek.

### Testreszabhatom a szöveges vízjel betűtípusát és stílusát?

Igen, bármilyen betűtípust, méretet és stílust választhat, hogy illeszkedjen a prezentáció tervezéséhez és megőrizze a márka konzisztenciáját.

### Hogyan változtathatom meg egy vízjel pozícióját vagy tájolását?

A vízjel pozícióját és tájolását programozottan a forma koordinátáinak, méretének és forgatási tulajdonságainak módosításával változtathatja.