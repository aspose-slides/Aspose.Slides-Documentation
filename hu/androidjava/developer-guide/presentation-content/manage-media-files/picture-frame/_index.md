---
title: Képkockák kezelése prezentációkban Androidon
linktitle: Képkocka
type: docs
weight: 10
url: /hu/androidjava/picture-frame/
keywords:
- képkocka
- képkocka hozzáadása
- képkocka létrehozása
- beágyazott kép
- csatolt kép
- kép kinyerése
- raster kép
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
- Android
- Java
- Aspose.Slides
description: "Képkockák létrehozása, formázása, csatolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Android segítségével Java nyelven."
---
## **Áttekintés**

A képkocka egy diára helyezett alakzat, amely képet jelenít meg. Az Aspose.Slides-ban a képernyő erőforrás és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) beágyazott kép erőforrásokat birtokol a [IImageCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagecollection/) segítségével, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb keretszintű beállításokat.

Ez a felosztás akkor hasznos, ha ugyanaz a kép több alkalommal jelenik meg. Add a képet egyszer a prezentációhoz, tartsd meg a visszaadott [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/), és használd azt a kép erőforrásként képkockák létrehozásakor.

A képkockák raster (PNG vagy JPEG) és vektor (SVG) képeket is tartalmazhatnak. Hivatkozhatnak csatolt képekre is ahelyett, hogy a képadatokat a prezentációban tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan legyen a kép tárolva, mielőtt formázást vagy optimalizálást alkalmaznánk.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén add hozzá a képadatokat a prezentációhoz, és hozz létre egy képkockát a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) segítségével. A kép a prezentáció csomag részévé válik, így a prezentáció önálló marad, amikor egy másik számítógépre kerül.

Az alábbi példa JPEG képet ad hozzá, egy keretet hoz létre a kép natív méreteiben, és vonalformázást valamint forgatást alkalmaz:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

A képkocka szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti, a beágyazott kép erőforrásban tárolt pixelméreteket. Ez a különbség később fontos lesz vágás vagy tömörítés esetén.

## **Relatív méretezés használata**

[IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) a keret relatív szélesség- és magasságméretezését teszi lehetővé a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) metódusokkal. Az `1.0` érték az eredeti kép 100%-ának felel meg. A relatív méretezés akkor hasznos, ha egy munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével, a végső méretek kézi kiszámítása helyett.

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

A relatív méretezés a keret méretezési beállításait módosítja; nem próbálja újramintavételezni vagy tömöríteni a beágyazott képet.

## **Beágyazott és csatolt képek**

A beágyazott kép a képadatokat a prezentáción belül tárolja, így a hordozhatóság és az előre kiszámítható megjelenítés szempontjából a legbiztonságosabb választás. A csatolt kép egy külső helyet tárol a [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) metódus segítségével, ahelyett, hogy beágyazná a képadatokat ugyanúgy.

A csatolt képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget hoznak létre. A csatolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely megnyitja vagy megjeleníti a prezentációt. Ha az elérési út megváltozik, a fájl áthelyeződik, vagy az erőforrás nem érhető el, a csatolt kép nem jelenik meg a várttal megegyezően. Azokban a prezentációkban, amelyeket e‑mailben, archiválásban vagy izolált környezetben kell megjeleníteni, a beágyazott képek általában megbízhatóbbak.

### **Csatolt kép hozzáadása**

Az alábbi példa egy képkockát hoz létre, és helyi képfájlra mutat. Csak a kép csatolásával foglalkozik; a videó csatolás egy külön média munkafolyamat, és szándékosan nincs keverve ebben a példában.

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

Használj hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használd őket pusztán a tömörítés helyettesítésére: egy kis PPTX törött képfüggőségekkel általában kevésbé hasznos, mint egy nagyobb, önálló prezentáció.

## **Képek kinyerése képkockákból**

Mielőtt képet nyernél ki egy meglévő prezentációból, ellenőrizd, hogy az alakzat valóban egy [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/), és tartalmaz-e beágyazott képet. A csatolt képkockák nem biztos, hogy képadatokat tartalmaznak, amelyeket ugyanúgy ki lehet nyerni.

### **Raster kép kinyerése**

A modern kép API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) használatát javasolja, és nem igényli a régi Java képburkolót. Az alábbi példa megtalálja a dián az első beágyazott raster képet, és PNG‑ként menti el:

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

Az [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metódussal a kinyert képet a kért kimeneti formátumba konvertálod. Ha a prezentációban tárolt kódolt bájtokra van szükséged, a konvertált raster fájl helyett a kép erőforrás bináris adatait használd.

### **SVG kép kinyerése**

SVG képnél a [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) objektumot tesz elérhetővé. Ez lehetővé teszi a SVG adat közvetlen visszakeresését a rasterizálás előtt.

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

Az SVG tartalom SVG‑ként való megtartása megőrzi a vektor forrást a prezentációban. A PNG vagy JPEG‑hez hasonló raster exportok szükségszerűen a vektort pixelre renderelik. A PDF vagy SVG diák exportja szintén egy renderelési művelet, ezért az exportált grafika nem tekinthető az eredeti beágyazott SVG pontos másolatának; amikor a tényleges vektor erőforrásra van szükség, használd a beágyazott [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/#getSvgData--) adatot.

## **Kép vágása**

A vágás meghatározza, a kép mely része látható a kereten belül. Az [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) vágási értékei a forráskép méretének százalékában vannak megadva. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható régiót változtatja meg.

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

Mivel a rejtett képadatok továbbra is jelen vannak, a vágás később módosítható anélkül, hogy az eredeti pixelek elvesznének. Ha a fájlméret fontosabb, mint a visszavonhatóság, a vágott területeket fizikailag eltávolíthatod a következő szakaszban leírt módon.

## **Vágott képadatok eltávolítása**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) eltávolítja a képadatokat a jelenlegi vágás téglalapján kívül, és visszaadja a kapott kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után a törölt pixelek már nem állnak rendelkezésre egy későbbi „vágás visszavonása” művelethez.

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

A metódus új kép erőforrást adhat hozzá a prezentációhoz. Ha az eredeti képet más képkockák is használják, ezeknek továbbra is a meglévő erőforrásra van szükségük, így a vágott területek törlése nem feltétlenül csökkenti a képek teljes számát. WMF vagy EMF tartalom vágása ezzel a módszerrel a vágott eredményt PNG‑re rasterizálja.

## **Raster képek tömörítése**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) csökkenti a raster kép felbontását a kép megjelenítési méretéhez viszonyítva. Ugyanabban a műveletben eltávolíthatja a vágott régiókat is. A metódus `true` értékkel tér vissza, ha a képet átméretezték vagy levágták, és `false` értékkel, ha nincs szükség változtatásra.

Használj előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

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

Egy egyedi, pozitív DPI érték is megadható, ha specifikus célra van szükség.

A tömörítés raster képekre vonatkozik. SVG és metafájl tartalom nem csökken ezzel a raster tömörítési munkafolyamattal. Ne feledd, hogy az alacsonyabb felbontású és a törölt vágott területek nem állíthatók vissza a optimalizált prezentációból. Válassz célfelbontást a legnagyobb, ténylegesen megtekintett vagy exportált méret alapján, ne pedig a legalacsonyabb DPI-t globálisan alkalmazd.

## **Képtranszformációs hatások kezelése**

A teljes munkafolyamat – fényerő, kontraszt, színátalakítás, elmosás, alfa hatások, rendezett láncok, ellenőrzés, eltávolítás és körkörös ellenőrzés – megtalálható a [Image Transform Effects](/slides/hu/androidjava/image-transform-effects/) oldalon.

## **Képkocka geometria zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/) beállítások szabályozzák, mely szerkesztési műveletek legyenek letiltva egy képkockán. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) megőrzi az alakzat arányait átméretezés közben.

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

A zár az egész képkocka alakzatra vonatkozik. Nem kényszeríti a forrásképet újramintavételezésre vagy állandóan ugyanarra az arányra módosításra.

## **StretchOffset értékek módosítása**

Ha a képkitöltés módja a nyújtás, a [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) stretch‑offset értékei határozzák meg a kitöltő téglalapot a képkocka keretéhez képest. A pozitív százalékok belülre húznak egy széltől, a negatív százalékok pedig kifelé tolnak.

Ez különbözik a vágástól. A vágási értékek meghatározzák, a forráskép mely része látható; a stretch‑offsetok a látható kép kitöltésének téglalapját módosítják.

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

Használd a stretch‑offsetokat a kitöltés elhelyezéséhez. A vágási tulajdonságokat akkor alkalmazd, ha a forráskép széleit szeretnéd elrejteni.

## **Tárolás, fájlméret és export szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a kép tárolását és a képkocka formázását külön kezeljük:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a legmegbízhatóbbak a megosztás és a szerveroldali megjelenítés szempontjából, de a nagy raster képek megnövelik a PPTX méretét és a memóriahasználatot.
- **Csatolt képek** kisebb csomagot eredményezhetnek, de a prezentáció függ a külső fájlok elérhetőségétől a megadott útvonalakon vagy helyeken.
- **Vágás** eleve nem destruktív. A rejtett pixelek addig beágyazva maradnak, amíg a vágott területeket kifejezetten nem törlik vagy a tömörítés során nem távolítják el.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raster képeknél, de feláldozza a forrásfelbontást. Akkor alkalmazd, amikor a dia mérete ismert.
- **SVG képek** esetén maradjunk SVG‑ként, ha a vektor megőrzése fontos. A beágyazott SVG közvetlen kinyerése akkor szükséges, amikor magát a vektor erőforrást akarjuk.
- **Ismétlődő képek** esetén használjuk újra a meglévő [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) erőforrást ahelyett, hogy ugyanazt a fájlt többször betöltenénk a prezentáció munkafolyamatába.

Nagy prezentációk esetén a képoptimalizálás leginkább szelektíven hatékony: tartsuk logókat és diagramokat vektor tartalomként, tömörítsük a fényképeket a valódi megjelenítési méretük szerint, csak akkor távolítsuk el a vágott pixeleket, ha a későbbi szerkesztés nem szükséges, és kerüljük a külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervnek.

## **GYIK**

**Mi a különbség a képkocka és a kép erőforrás között?**

Egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) kép erőforrást képvisel, amely a prezentációhoz van társítva. Egy [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) egy dián elhelyezett alakzat, amely képet jelenít meg, és keretszintű geometriát és formázást tárol, például méretet, forgatást, vágási értékeket, hatásokat és zárolásokat.

**Érdemes beágyazni vagy csatolni a képeket?**

Beágyazz képeket, ha a prezentációnak hordozhatónak, archiválhatónak vagy külső erőforrások nélkül renderelendőnek kell lennie. Csak akkor csatolj képeket, ha szándékosan kívánod a képfájlokat a PPTX‑en kívül tartani, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti-e a vágás a PPTX fájlméretét?**

Nem magától. A normál vágási beállítások elrejtik a forráskép részeit, de megtartják az alatta lévő pixeleket. A [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) vagy a vágott területek eltávolításával végzett képkompresszió használható, ha ezeket a pixeleket véglegesen el akarod dobni.

**Visszaállítható-e a képminőség a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a vágott területek eltávolítása elpusztítja a képadatokat. Ha később nagy felbontású szerkesztésre van szükség, tartsd meg a forrásképet a prezentáción kívül.

**Hogyan kezeljem az SVG képeket?**

Tartsd meg az SVG tartalmat SVG‑ként, ha a vektor pontosság számít. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) közvetlenül kinyerhető. Egy dia raster formátumba (PNG vagy JPEG) történő exportálása rasterizálja az SVG‑t a dia képének részeként.

**Hogyan kerülhetem el a nem biztonságos cast műveleteket létező diák olvasásakor?**

Ellenőrizd az alakzat típusát, mielőtt a képkocka‑specifikus tagokat használnád. Egy `instanceof` ellenőrzés a [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) ellen biztosítja, hogy elkerüld a hibás cast-et, és lehetővé teszi a kód számára, hogy kezelje azokat a diákot, amelyek nem tartalmaznak képkockákat.