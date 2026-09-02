---
title: Képkeretek kezelése bemutatókban Androidon
linktitle: Képkeret
type: docs
weight: 10
url: /hu/androidjava/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- csatolt kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív méretezés
- kép effektus
- oldalarány
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése bemutatókban az Aspose.Slides for Android Java használatával."
---
## **Áttekintés**

A képkeret egy diára helyezett alakzat, amely egy képet jelenít meg. Az Aspose.Slides-ben a kép erőforrás és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) saját beágyazott kép erőforrásokat a [IImageCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagecollection/) segítségével, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgását, vágását, képhatásait és egyéb képkeret szintű beállításait.

Ez a szétválasztás hasznos, ha ugyanaz a kép többször jelenik meg. Adja hozzá a képet egyszer a bemutatóhoz, tartsa meg a visszaadott [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/), és használja azt a kép erőforrást képkeretek létrehozásakor.

A képkeretek raszteres képeket, például PNG vagy JPEG, valamint vektor SVG képeket is tartalmazhatnak. Hivatkozhatnak csatolt képekre is, ahelyett, hogy a kép bájtjait a bemutatóban tárolnák. A választás hatással van a hordozhatóságra, a fájlméretre, a kinyerésre és az export viselkedésére, ezért célszerű eldönteni, hogyan legyen a kép tárolva, mielőtt formázást vagy optimalizálást alkalmazna.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adja hozzá a kép adatát a bemutatóhoz, és hozzon létre egy képkeretet a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) segítségével. A kép a bemutató csomag részévé válik, így a bemutató önálló marad, amikor egy másik számítógépre helyezik át.

Az alábbi példa egy JPEG képet ad hozzá, a kép natív méreteivel hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:

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

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti, a beágyazott kép erőforrásban tárolt képpontdimenziókat. Ez a különbség későbbi képmetszés vagy tömörítés során válik fontosá.

## **Relatív méretezés használata**

[IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) a keret relatív szélesség‑ és magasság‑méretezését a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) metódusokkal teszi elérhetővé. Az `1.0` érték az eredeti képméret 100 %-ának felel meg. A relatív méretezés akkor hasznos, ha egy munkafolyamatnak meg kell tartania a kapcsolatot a forráskép méretével a végső méretek kézi kiszámítása helyett.

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

A relatív méretezés a keret méretezési beállításait módosítja; nem végez újramintavételezést vagy tömörítést a beágyazott képen.

## **Beágyazott és csatolt képek**

Egy beágyazott kép a kép adatát a bemutatóban tárolja, ezért a legbiztonságosabb választás a hordozhatóság és az előre megjósolható megjelenítés szempontjából. Egy csatolt kép egy külső helyet tárol a [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) metóduson keresztül, ahelyett, hogy beágyazná a kép adatát ugyanúgy.

A csatolt képek csökkenthetik a PPTX‑ben tárolt képadatok mennyiségét, de külső függőséget is bevezetnek. A csatolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely a bemutatót megnyitja vagy rendereli. Ha az elérési út megváltozik, a fájl áthelyeződik, vagy az erőforrás nem elérhető, a csatolt kép lehet, hogy nem jelenik meg a várttól eltérően. Azoknál a bemutatóknál, amelyeket e‑mailben kell elküldeni, archiválni kell, vagy elszigetelt környezetben kell renderelni, a beágyazott képek általában megbízhatóbbak.

### **Csatolt kép hozzáadása**

Az alábbi példa egy képkeretet hoz létre, és egy helyi képfájlra irányítja. Csak a kép‑csatolással foglalkozik; a videó‑csatolás egy külön média‑munkafolyamat, és szándékosan nincs keverve ebben a példában.

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

Használja a hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használja őket csupán a tömörítés helyettesítésére: egy kis PPTX törött kép‑függőségekkel általában kevésbé hasznos, mint egy nagyobb önálló bemutató.

## **Képek kinyerése a képkeretekből**

Mielőtt képet nyerne ki egy meglévő bemutatóból, ellenőrizze, hogy az alakzat valóban [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/)‑e, és tartalmaz‑e beágyazott képet. A csatolt képkeretek esetleg nem tartalmaznak képbájtokat, amelyeket ugyanúgy ki lehetne nyerni.

### **Raszteres kép kinyerése**

A modern kép‑API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/)‑t használja, és nem igényli a régebbi Java kép‑burkolót. Az alábbi példa megtalálja az első beágyazott raszteres képet egy dián, és PNG‑ként menti el:

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

Az [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) használata a kinyert képet a kért kimeneti formátumba konvertálja. Ha a bemutatóban tárolt kódolt bájtokra van szüksége a konvertált raszteres fájl helyett, használja a kép erőforrás bináris adatát.

### **SVG kép kinyerése**

SVG kép esetén a [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) objektumot tesz elérhetővé. Ennek segítségével a SVG adatot közvetlenül lekérheti anélkül, hogy a képet előbb rasterizálná.

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

Az SVG tartalom SVG‑ként történő megőrzése megőrzi a vektor forrást a bemutatóban. A PNG vagy JPEG‑hez hasonló raszteres exportok szükségszerűen a vektor tartalmat pixelekre konvertálják. A PDF vagy SVG diakivitel szintén egy renderelési művelet, ezért a exportált grafika nem tekinthető bit‑pontos másolatnak az eredeti beágyazott SVG‑ből; használja a beágyazott [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/#getSvgData--) adatot, ha a vektor erőforrásra van szükség.

## **Kép vágása**

A vágás meghatározza, a kép mely része látható a kereten belül. Az [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) vágási értékei a forráskép méretének százalékai. A vágás eleinte nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

Az alábbi példa biztonságosan megtalál egy képkeretet, és alkalmaz vágási értékeket:

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

Mivel a rejtett képadatok továbbra is jelen vannak, a vágás később megváltoztatható anélkül, hogy az eredeti pixeleket elveszítené. Ha a fájlméret fontosabb, mint a visszavonhatóság, a vágott területek fizikai eltávolítása a következő szakaszban leírtak szerint végezhető.

## **Vágott képadatok eltávolítása**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) eltávolítja a képadatokat a jelenlegi vágási téglalapon kívül, és visszaadja a keletkezett kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a bemutató mentése után az eltávolított pixelek már nem állnak rendelkezésre a későbbi „vágás visszavonása” művelethez.

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

A metódus új kép erőforrást adhat hozzá a bemutatóhoz. Ha az eredeti képet más képkeretek is használják, azoknak továbbra is a meglévő erőforrásra van szükségük, ezért a vágott területek törlése nem feltétlenül csökkenti a képek összes számát. WMF vagy EMF tartalom vágása ezzel a módszerrel a vágott eredményt PNG‑be rasterizálja.

## **Raszteres képek tömörítése**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) csökkenti a raszteres kép felbontását a megjelenített mérethez képest. Ugyanabban a műveletben eltávolíthatja a vágott területeket is. A metódus `true`‑t ad vissza, ha a kép átméretezésre vagy vágásra került, és `false`‑t, ha nincs szükség változtatásra.

Használjon egy előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

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

Egy egyedi pozitív DPI érték is megadható egy előre definiált érték helyett, ha egy konkrét célra van szükség.

A tömörítés raszteres képekre szánt. SVG‑ és metafájl‑tartalmat ez a raszteres tömörítési munkafolyamat nem csökkent. Ne feledje, hogy az alacsonyabb felbontású és a törölt vágott területek már nem állíthatók vissza az optimalizált bemutatóból. A célfelbontást a legnagyobb, valós megtekintési vagy exportálási méret alapján válassza, ne pedig a legalacsonyabb DPI‑t alkalmazza globálisan.

## **Képek transzformációs hatásainak kezelése**

A teljes munkafolyamat, amely magában foglalja a fényerő, kontraszt, színtranszformációk, elmosódás, alfa‑effektek, sorrendbe rendezett láncok, ellenőrzés, eltávolítás és visszafordítható ellenőrzés részleteit, lásd a [Image Transform Effects](/androidjava/image-transform-effects/) oldalon.

## **Képkeret geometria zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/) beállításai szabályozzák, hogy mely szerkesztési műveletek vannak letiltva egy képkeretnél. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) megőrzi az alakzat arányait méretezés közben.

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

A zárolás a képkeret alakzatra vonatkozik. Nem kényszeríti a forrásképet újramintavételezésre vagy állandóan ugyanarra az arányra módosításra.

## **StretchOffset értékek beállítása**

Ha a kép kitöltési módja „stretch”, akkor a [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) stretch‑offset értékei a képkeret határoló téglalapjához viszonyítva definiálják a kitöltő téglalapot. A pozitív százalékok a széltől befelé húznak, míg a negatív százalékok kifelé nyújtanak.

Ez eltér a vágástól. A vágási értékek azt határozzák meg, a forráskép mely része látható; a stretch‑offsetok a látható kitöltés téglalapját módosítják.

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

Használja a stretch‑offsetokat a kitöltés elhelyezéséhez. Használja a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a kép tárolását és a képkeret formázását külön kezeljük:

- **Beágyazott képek** önállóvá teszik a bemutatót, és a legmegbízhatóbbak a megosztás és a szerveroldali renderelés esetén, de a nagy raszteres képek növelik a PPTX méretét és memóriahasználatát.
- **Csatolt képek** kisebb csomagméretet eredményezhetnek, de a bemutató függ a külső fájlok elérhetőségétől a tárolt útvonalakon vagy helyeken.
- **Vágás** eleinte nem destruktív. A rejtett pixelek addig beágyazva maradnak, amíg a vágott területek explicit módon nincsenek törölve vagy a tömörítés során nem kerülnek eltávolításra.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raszteres képek esetén, de a forrásfelbontást feláldozza. A vágott képméretre felmérés után alkalmazandó.
- **SVG képek** esetén maradjon SVG, ha a vektor megőrzése fontos. A beágyazott SVG‑t közvetlenül nyerje ki, ha maga a vektor erőforrás szükséges. A raszteres diakiexportok mindig a renderelt diát pixelekre konvertálják.
- **Ismétlődő képek** esetén használja újra a már létező [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) erőforrást, ahelyett, hogy ugyanazt a fájlt többször betöltené a munkafolyamatba.

Nagy bemutatók esetén a képoptimalizálás általában a szelektív alkalmazáskor a leghatékonyabb: a logókat és diagramokat vektor tartalomként tartsa, a fényképeket a tényleges megjelenítési méretük szerint tömörítse, a vágott pixeleket csak akkor távolítsa el, ha a későbbi szerkesztés már nem szükséges, és kerülje a külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervezésnek.

## **Gyakran ismételt kérdések**

**Mi a különbség egy képkeret és egy kép erőforrás között?**

Az [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) egy a bemutatóhoz kapcsolódó kép erőforrást képviseli. Az [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) egy dián lévő alakzat, amely képet jelenít meg, és tárolja a keretszintű geometriát és formázást, például a méretet, forgatást, vágási értékeket, hatásokat és zárásokat.

**Beágyazzam vagy csatoljam a képeket?**

Beágyazza a képeket, ha a bemutatónak hordozhatónak, archiváltnak vagy külső erőforrások nélkül rendereltnek kell lennie. Csak akkor csatolja a képeket, ha a kép fájlok külső tárolása szándékos, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a pixeleket megőrzik. Használja a [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) vagy a képtömörítést vágott‑terület-eltávolítással, ha ezeket a pixeleket véglegesen el kell távolítani.

**Vissza tudom állítani a kép minőségét a tömörítés után?**

Nem. A tömörítés csökkenti a tárolt raszteres felbontást, és a vágott területek eltávolítása törli a kép adatát. Ha később nagy felbontású szerkesztésre van szükség, tartsa meg az eredeti forrásképet a bemutatón kívül.

**Hogyan kell kezelni az SVG képeket?**

Ha a vektor pontossága fontos, a SVG tartalmat SVG‑ként tartsa meg. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) közvetlenül kinyerhető. A diát PNG‑ vagy JPEG‑hez raszterizálva exportálni a SVG‑t a dia képként pixelekre alakítja.

**Hogyan kerülhetem el a nem biztonságos cast‑eket meglévő diák olvasásakor?**

Ellenőrizze az alakzat típusát, mielőtt a képkeret‑specifikus tagokat használná. Egy `instanceof` ellenőrzés a [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) ellen szűri a hibás cast‑eket, és lehetővé teszi a kód számára, hogy a nem képkeret tartalmazó diasorokkal is megfelelően eljárjon.