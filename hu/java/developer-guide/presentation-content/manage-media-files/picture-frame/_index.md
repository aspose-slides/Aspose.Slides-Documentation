---
title: Képkockák kezelése prezentációkban Java használatával
linktitle: Képkocka
type: docs
weight: 10
url: /hu/java/picture-frame/
keywords:
- képkocka
- képkocka hozzáadása
- képkocka létrehozása
- beágyazott kép
- csatolt kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkocka formázása
- relatív méretezés
- kép hatás
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: Képkockák létrehozása, formázása, csatolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Java segítségével.
---
## **Áttekintés**

A képkocka egy diára helyezett alakzat, amely képet jelenít meg. Az Aspose.Slides‑ben a képernyő erőforrás és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) beágyazott képernyő erőforrásokat tárol a [IImageCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagecollection/) segítségével, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgását, vágását, képhatásait és egyéb keretszintű beállításait.

Ez a szétválasztás akkor hasznos, amikor ugyanaz a kép többször jelenik meg. A képet egyszer adjuk hozzá a prezentációhoz, tartsuk meg a visszakapott [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/), és használjuk ezt a képernyő erőforrást képkockák létrehozásakor.

A képkockák raszteres képeket (például PNG vagy JPEG) és vektoros SVG képeket is tartalmazhatnak. A beágyazott képadat helyett hivatkozhatnak csatolt képekre is. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan legyen a kép tárolva, mielőtt formázást vagy optimalizálást alkalmaznánk.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adjuk hozzá a képadatot a prezentációhoz, és hozzunk létre egy képkockát a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódussal. A kép a prezentációcsomag része lesz, így a prezentáció önálló marad, ha másik számítógépre helyezzük.

A következő példa egy JPEG képet ad hozzá, a kép natív méreteivel hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A képkocka szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti, beágyazott képernyő erőforrásban tárolt pixelméreteket. Ez a különbség későbbi vágás vagy tömörítés esetén fontos.

## **Relatív méretezés használata**

[IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) relatív szélesség‑ és magasság‑skálázást biztosít a kerethez a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) metódusokkal. Az `1.0` érték az eredeti képméret 100 %-át jelenti. A relatív skálázás akkor hasznos, ha a munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével a végleges méretek kézi kiszámítása helyett.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A relatív skála a keret skála beállításait módosítja; nem próbálja újramintavételezni vagy tömöríteni a beágyazott képet.

## **Beágyazott és csatolt képek**

A beágyazott kép a képadatot a prezentáción belül tárolja, ezért a legbiztonságosabb választás a hordozhatóság és az előre kiszámítható megjelenítés szempontjából. A csatolt kép a [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) metódussal egy külső helyet tárol ahelyett, hogy a képadatot ugyanúgy beágyazná.

A csatolt képek csökkenthetik a PPTX‑ben tárolt képadatok mennyiségét, de külső függőséget hoznak létre. A csatolt fájlnak elérhetőnek kell maradnia azon alkalmazás számára, amely a prezentációt megnyitja vagy rendereli. Ha az elérési út megváltozik, a fájlt áthelyezik, vagy az erőforrás nem érhető el, a csatolt kép nem jelenhet meg a várt módon. Azoknál a prezentációknál, amelyeket e‑mailben kell küldeni, archiválni vagy elszigetelt környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Csatolt kép hozzáadása**

Az alábbi példa egy képkockát hoz létre, és egy helyi képfájlra mutat. A példa csak a kép csatolásával foglalkozik; a videó csatolás egy külön média‑munkafolyamat, amelyet szándékosan nem keverünk ebbe a példába.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Használjunk hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használjuk őket csak a tömörítés helyettesítésére: egy kis PPTX, amelyben törött képfüggőségek vannak, általában kevésbé hasznos, mint egy nagyobb, önálló prezentáció.

## **Képek kinyerése képkockákból**

Mielőtt képet nyernénk ki egy meglévő prezentációból, ellenőrizzük, hogy a alakzat valóban [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/), és tartalmaz-e beágyazott képet. A csatolt képkockák esetleg nem tartalmaznak olyan képadatot, amely ugyanúgy kinyerhető lenne.

### **Raszteres kép kinyerése**

A modern kép‑API közvetlenül az [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) típust használja, és nem igényli a régebbi Java kép‑csomagolót. A következő példa megtalálja az első beágyazott raszteres képet egy dián, és PNG‑képként menti el:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Az [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/#save-java.lang.String-int-) metódus segítségével a kinyert képet a kívánt kimeneti formátumba konvertáljuk. Ha a prezentációban tárolt enkódolt bájtokra van szükség, nem konvertált raszteres fájlra, akkor használjuk a kép erőforrás bináris adatait.

### **SVG kép kinyerése**

SVG kép esetén az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) objektumot ad vissza. Ez lehetővé teszi, hogy közvetlenül lekérdezzük az SVG adatot a rasterizálás nélkül.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Az SVG tartalom SVG‑ként való megtartása megőrzi a vektoros forrást a prezentáción belül. A PNG vagy JPEG‑s raster exportok szükségszerűen a vektoros tartalmat képpontokká alakítják. A PDF vagy SVG diakivitel is egy renderelési művelet, ezért az exportált graphics‑et nem szabad a beágyazott SVG‑bitenkénti másolatának tekinteni; használjuk a beágyazott [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/#getSvgData--) adatot, ha az eredeti vektoros erőforrásra van szükség.

## **Kép vágása**

A vágás meghatározza, hogy a kép mely része látható a kereten belül. Az [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) vágási értékei a forráskép méretének százalékában vannak megadva. A vágás kezdetben nem törli a rejtett képpontokat a beágyazott képből; csak a látható régiót változtatja.

Az alábbi példa biztonságosan megtalál egy képkockát, és alkalmazza a vágási értékeket:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Mivel a rejtett képadatok még mindig jelen vannak, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszavonhatóság, a vágott területeket a következő szakaszban fizikai törléssel csökkenthetjük.

## **Vágott képadatok eltávolítása**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) eltávolítja a jelenlegi vágási téglalap kívül eső képadatokat, és visszaadja a keletkezett képernyő erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után a törölt pixelek már nem állnak rendelkezésre a későbbi „uncrop” művelethez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

A metódus új képernyő erőforrást adhat a prezentációhoz. Ha az eredeti képet más képkockák is használják, azoknak továbbra is szükségük van a meglévő erőforrásra, így a vágott területek törlése nem feltétlenül csökkenti a képek számát. WMF vagy EMF tartalom vágása ezzel a módszerrel a vágott eredményt PNG‑re rasterizálja.

## **Raszteres képek tömörítése**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) csökkenti a raszteres kép felbontását a kép megjelenített méretéhez képest. Ugyanebben a műveletben eltávolíthatóak a vágott régiók is. A metódus `true` értékkel tér vissza, ha a képet átméretezték vagy levágták, és `false`‑val, ha nincs szükség változtatásra.

Használjunk előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Egy egyedi, pozitív DPI‑érték is megadható, ha konkrét cél felbontás szükséges.

A tömörítés raszteres képekre vonatkozik. SVG és metafájl tartalom nem csökken ezen raszteres tömörítési munkafolyamat során. Emellett ne feledjük, hogy az alacsonyabb felbontású és a törölt vágott részek nem állíthatók vissza az optimalizált prezentációból. Válasszunk célfelbontást a legnagyobb megjelenítési vagy exportálási méret alapján, nem pedig a legkisebb DPI‑t globálisan alkalmazva.

## **Kép‑transzformációs hatások kezelése**

A teljes munkafolyamat, amely fényerő, kontraszt, színátalakítás, elmosás, alfa‑hatás, sorozatos láncok, ellenőrzés, eltávolítás és round‑trip ellenőrzés lefedi, megtalálható a [Kép‑transzformációs hatások](/java/image-transform-effects/) oldalon.

## **Képkocka geometria zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframelock/) beállításai szabályozzák, hogy mely szerkesztési műveletek legyenek letiltva a képkockán. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) megőrzi az alakzat arányait átméretezéskor.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A zárolás a képkocka alakzatra vonatkozik. Nem kényszeríti a forrásképet újramintavételezésre vagy állandóan ugyanolyan oldalarányra módosításra.

## **A StretchOffset értékek módosítása**

Ha a kép kitöltési módja a \"stretch\", akkor a [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) stretch‑offset értékei a kitöltő téglalapot a képkocka keretehez viszonyítva definiálják. A pozitív százalékos értékek befelé tolják az éleket, a negatívak kifelé.

Ez különbözik a vágástól. A vágási értékek azt határozzák meg, hogy a forráskép mely része látható; a stretch‑offsetok a látható kép kitöltésének téglalapját módosítják.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Használjuk a stretch‑offsetokat a kitöltési pozíció meghatározásához. A vágási tulajdonságokat akkor alkalmazzuk, ha a forráskép széleket szeretnénk elrejteni.

## **Tárolás, fájlméret és exportálási megfontolások**

A fő kompromisszumok könnyebben kezelhetők, ha a képtárolás és a képkocka‑formázás különállóan történik:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a legmegbízhatóbbak a megosztás és a szerver‑oldali renderelés során, de a nagy raszteres képek növelik a PPTX méretét és a memóriahasználatot.
- **Csatolt képek** kisebb csomagot eredményezhetnek, de a prezentáció függ a külső fájlok elérhetőségétől a tárolt útvonalakon vagy helyeken.
- **Vágás** kezdetben nem destruktív. A rejtett pixelek beágyazottak maradnak, amíg a vágott területeket explicit módon nem töröljük vagy nem távolítjuk el a tömörítés során.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raszteres képeknél, de árul a forrás felbontásáért. A képernyőn ténylegesen megjelenített méret ismerete után alkalmazandó.
- **SVG képek** esetén maradjanak SVG‑ként, ha a vektoros megőrzés fontos. A beágyazott SVG közvetlen kinyerése akkor hasznos, ha magára a vektoros erőforrásra van szükség. A raster diakivitelek (PNG, JPEG) mindig a megjelenített diát konvertálják pixelekké.
- **Ismétlődő képek** esetén a [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) erőforrás újrahasználata ajánlott ahelyett, hogy ugyanazt a fájlt többször betöltenénk a munkafolyamatba.

Nagyméretű prezentációk esetén a képoptimalizálás általában akkor a leghatékonyabb, ha szelektíven történik: tartsuk a logókat és diagramokat vektoros tartalomként, a fényképeket a tényleges megjelenítési méret szerint tömörítsük, a vágott pixeleket csak akkor távolítsuk el, ha későbbi szerkesztésre nincs szükség, és kerüljük a külső hivatkozásokat, kivéve ha a függőségkezelés része a telepítési tervnek.

## **GYIK**

**Mi a különbség a képkocka és a képernyő erőforrás között?**

Az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) egy a prezentációhoz társított képernyő erőforrást képvisel. Az [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) egy dián elhelyezett alakzat, amely képet jelenít meg, és a keretszintű geometriát és formázást (méret, forgatás, vágási értékek, hatások, zárolások) tárolja.

**Be kell-e ágyazni vagy csatolni a képeket?**

Ágyazzuk be a képeket, ha a prezentációnak hordozhatónak, archiválhatónak vagy külső erőforrások hozzáférése nélkül kell renderelődjön. Csak akkor csatoljunk képeket, ha a képfájlok külső tárolása szándékos, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti-e a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások csak elrejtik a forráskép részeit, de a pixeleket megtartják. Használjuk a [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) vagy a képtömörítést vágott területek eltávolításával, ha ezeket a pixeleket véglegesen el lehet dobni.

**Visszaállítható-e a kép minősége a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raszteres felbontást, a vágott területek eltávolítása pedig véglegesen törli a képadatot. Ha később nagy felbontású szerkesztésre van szükség, a forrásképet tartsuk meg a prezentáción kívül.

**Hogyan kezeljük az SVG képeket?**

Tartsuk meg az SVG tartalmat SVG‑ként, ha a vektoros hűség lényeges. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) közvetlenül kinyerhető. Egy diához PNG vagy JPEG‑re való raster exportálás a SVG‑t pixelekre konvertálja.

**Hogyan kerülhető el a nem biztonságos cast használata meglévő diák olvasásakor?**

Ellenőrizzük az alakzat típusát, mielőtt képkocka‑specifikus tagokat használnánk. Egy `instanceof` ellenőrzés a [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) ellen biztosítja, hogy a cast érvényes, és lehetővé teszi a kód számára, hogy kezelje azokat a diákot, amelyek nem tartalmaznak képkockákat.