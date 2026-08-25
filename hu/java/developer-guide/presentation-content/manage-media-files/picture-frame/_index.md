---
title: Képkeretek kezelése prezentációkban Java használatával
linktitle: Képkeret
type: docs
weight: 10
url: /hu/java/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- linkelt kép
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
- méretarány
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, linkelése, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A képkeret egy diára helyezett alakzat, amely képet jelenít meg. Az Aspose.Slides-ben a kép erőforrás és a megjelenítő alakzat különálló objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) beágyazott kép erőforrásokat tartalmaz a [IImageCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagecollection/) révén, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgatását, vágását, kép effektjeit és egyéb keret‑szintű beállításokat.

Ez a szétválasztás akkor hasznos, ha ugyanaz a kép többször megjelenik. Adjunk a prezentációhoz egyszer képet, tartsuk meg a visszaadott [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/)-t, és használjuk azt a kép erőforrást képkeretek létrehozásakor.

A képkeretek raster (pl. PNG vagy JPEG) és vektor (SVG) képeket is tartalmazhatnak. Hivatkozhatnak linkelt képekre is a kép bitek prezentációba történő beágyazása helyett. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan legyen a kép tárolva a formázás vagy optimalizálás előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adjuk hozzá a kép adatát a prezentációhoz, és hozzunk létre egy képkeretet a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) segítségével. A kép a prezentáció csomagjának része lesz, így a prezentáció önálló marad, ha egy másik számítógépre helyezzük át.

Az alábbi példa egy JPEG képet ad hozzá, a kép natív méreteivel hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:

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

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg a beágyazott kép erőforrásban tárolt eredeti pixel méreteket. Ez a különbség későbbi vágás vagy tömörítés esetén fontos.

## **Relatív méretezés használata**

[IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) relatív szélesség‑ és magasság‑skálázást tesz lehetővé a keret számára a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) metódusokkal. Az `1.0` érték az eredeti kép 100%-át jelenti. A relatív skála hasznos, ha egy munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével a végleges méretek kézi kiszámítása helyett.

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

A relatív skála a keret skálázási beállításait módosítja; nem mintavételezi vagy tömöríti a beágyazott képet.

## **Beágyazott és linkelt képek**

A beágyazott kép a kép adatot a prezentáción belül tárolja, ezért a hordozhatóság és az előre látható renderelés szempontjából a legbiztonságosabb választás. A linkelt kép egy külső helyet tárol a [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) metódussal, ahelyett, hogy beágyazná a kép adatot ugyanúgy.

A linkelt képek csökkenthetik a PPTX‑ben tárolt képadat mennyiségét, de külső függőséget hoznak létre. A linkelt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely megnyitja vagy rendereli a prezentációt. Ha az útvonal megváltozik, a fájlt áthelyezik, vagy az erőforrás nem érhető el, a linkelt kép nem jelenhet meg a várt módon. Azoknál a prezentációknál, amelyeket e‑mailben kell küldeni, archiválni kell vagy elszigetelt környezetben kell renderelni, a beágyazott képek általában megbízhatóbbak.

### **Linkelt kép hozzáadása**

Az alábbi példa egy képkeretet hoz létre, és egy helyi képfájlra mutat. Csak a kép linkelésével foglalkozik; a videó linkelés egy külön média‑munkafolyamat, és szándékosan nincs keverve ebbe a példába.

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

Használjunk linkeket, ha a külső fájlkezelés szándékos. Ne használjuk őket pusztán a tömörítés helyettesítésére: egy kis PPTX, amelyben törött képfüggőségek vannak, általában kevésbé hasznos, mint egy nagyobb, önálló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyernénk ki egy meglévő prezentációból, ellenőrizzük, hogy az alakzat valóban egy [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/), és hogy beágyazott képet tartalmaz-e. A linkelt képkeretek nem feltétlenül tartalmaznak kép biteket, amelyeket ugyanígy ki lehetne nyerni.

### **Raster kép kinyerése**

A modern kép‑API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) használatával dolgozik, és nem igényli a régebbi Java kép‑wrappert. Az alábbi példa megtalálja az első beágyazott raster képet egy dián, és PNG‑ként menti el:

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

Az [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/#save-java.lang.String-int-) segítségével a kinyert kép a kért kimeneti formátumba konvertálódik. Ha a prezentációban tárolt kódolt bitekre van szükség, nem a konvertált raster fájlra, akkor a kép erőforrás bináris adatát kell használni.

### **SVG kép kinyerése**

SVG kép esetén a [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) objektumot biztosít. Ennek segítségével közvetlenül lekérhetjük az SVG adatot anélkül, hogy a képet előbb rasterizálnánk.

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

Az SVG tartalom SVG‑ként való megőrzése a vektor forrást a prezentáción belül tartja meg. A raster exportok, például PNG vagy JPEG, a vektor tartalmat pixelekké renderelik. A PDF vagy SVG dia export is egy renderelési művelet, ezért az exportált grafika nem tekinthető pontos bit‑másolatnak az eredeti beágyazott SVG‑ből; a beágyazott [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/#getSvgData--) adatot kell használni, ha magára a vektor erőforrásra van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. Az [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) vágási értékei a forráskép méreteinek százalékai. A vágás eleinte nem törli a rejtett pixeleket a beágyazott képből; csak a látható részt módosítja.

Az alábbi példa biztonságosan megtalál egy képkeretet, és alkalmazza a vágási értékeket:

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

Mivel a rejtett képadat továbbra is jelen van, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszafordíthatóság, a vágott területek fizikai eltávolítása a következő szakaszban leírtak szerint történhet.

## **Vágott képadatok eltávolítása**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) eltávolítja a kép adatát a jelenlegi vágási téglalapon kívül, és visszaadja a keletkezett kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után az eltávolított pixelek már nem állnak rendelkezésre egy későbbi „vágás visszavonása” művelethez.

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

A metódus új kép erőforrást adhat a prezentációhoz. Ha az eredeti képet más képkeretek is használják, azoknak továbbra is a saját erőforrásukra van szükségük, ezért a vágott területek törlése nem feltétlenül csökkenti a képek összes számát. WMF vagy EMF tartalom ilyen módszerrel történő vágása a vágott eredményt PNG‑be rasterizálja.

## **Raster képek tömörítése**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) csökkenti a raster kép felbontását a kép megjelenítési méretéhez képest. Ugyanazon művelet során eltávolíthatja a vágott területeket is. A metódus `true`‑t ad vissza, ha a kép át lett méretezve vagy vágva, és `false`‑t, ha nem volt szükség változtatásra.

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

Egy saját, pozitív DPI érték is megadható egy előre definiált helyett, ha konkrét cél szükséges.

A tömörítés raster képekre szánt. SVG és metafájl tartalom nem csökken ezen raster tömörítési munkafolyamat által. Ne feledjük, hogy az alacsonyabb felbontás és a törölt vágott területek nem állíthatók vissza az optimalizált prezentációból. Válasszunk célfelbontást a legnagyobb méret alapján, amelyen a képet ténylegesen megtekintik vagy exportálják, ahelyett, hogy globálisan a legalacsonyabb DPI‑t alkalmaznánk.

## **Képtranszformációs effektusok kezelése**

Egy teljes munkafolyamat, amely fényerőt, kontrasztot, színátalakításokat, elmosódást, alfa‑effekteket, rendezett láncokat, ellenőrzést, eltávolítást és körkörös ellenőrzést tartalmaz, megtalálható a [Image Transform Effects](/slides/hu/java/image-transform-effects/) oldalon.

## **Képkeret geometria zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframelock/) beállításai szabályozzák, hogy a képkeret mely szerkesztési műveletek esetén legyen letiltva. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) megőrzi az alakzat arányait, amikor méreteződik.

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

A zárolás a képkeret alakzatára vonatkozik. Nem kényszeríti a forrásképet a mintavételezésre vagy állandó átalakításra ugyanarra az arányra.

## **StretchOffset értékek módosítása**

Ha a kép kitöltési mód a nyújtás, akkor az [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) stretch‑offset értékei a képkitöltő téglalapot a képkeret határoló dobozához képest definiálják. A pozitív százalékok belülre tolnak egy élről, míg a negatív százalékok kifelé tolnak.

Ez különbözik a vágástól. A vágási értékek meghatározzák, hogy a forráskép mely része legyen látható; a stretch offsetek a téglalapot változtatják, amelybe a látható képkitöltés nyújtásra kerül.

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

Használjuk a stretch offseteket a kitöltés elhelyezéséhez. Használjuk a vágási tulajdonságokat, ha a cél a forráskép éleinek elrejtése.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a kép tárolását és a képkeret formázását külön kezeljük:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a megosztás és szerver‑oldali renderelés szempontjából a legmegbízhatóbbak, de a nagy raster képek növelik a PPTX méretét és memóriahasználatát.
- **Linkelt képek** kisebbre tartják a csomagot, de a prezentáció a külső fájlok elérhetőségétől függ a tárolt utak vagy helyek szerint.
- **Vágás** eleve nem destruktív. A rejtett pixelek addig be vannak ágyazva, amíg a vágott területeket kifejezetten nem töröljük vagy nem távolítjuk el a tömörítés során.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raster képek esetén, de feláldozza a forrás felbontást. Azt a dián megjelenített méret ismerté válása után kell alkalmazni.
- **SVG képek** maradjanak SVG‑ként, ha a vektor megőrzése fontos. A beágyazott SVG közvetlen kinyerése akkor szükséges, amikor magára a vektor erőforrásra van szükség. A raster dia exportok mindig a renderelt diát pixelekké konvertálják.
- **Ismétlődő képek** esetén használjuk újra a meglévő [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) erőforrást, ha lehetséges, ahelyett, hogy ugyanazt a fájlt többször betöltenénk a prezentációs munkafolyamatba.

Nagy prezentációk esetén a képoptimalizálás általában akkor a leghatékonyabb, ha szelektíven hajtjuk végre: a logókat és diagramokat vektor tartalomként tartsuk meg, a fényképeket a tényleges megjelenítési méretüknek megfelelően tömörítsük, csak akkor távolítsuk el a vágott pixeleket, ha későbbi szerkesztés nem szükséges, és kerüljük a külső linkeket, hacsak a függőségkezelés nem része a telepítési tervnek.

## **GYIK**

**Mi a különbség a képkeret és a kép erőforrás között?**

Az [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) egy a prezentációhoz társított kép erőforrást képvisel. Az [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) egy dia alakzata, amely képet jelenít meg, és a keret‑szintű geometriát és formázást tárolja, mint a méret, forgatás, vágási értékek, effektusok és zárolások.

**Beágyazzam vagy linkeljem a képeket?**

Beágyazzuk a képeket, ha a prezentációnak hordozhatónak, archiváltnak vagy külső erőforrások nélkül kell renderelődnie. Linkeljük őket csak akkor, ha a képfájlok külső tárolása szándékos, és a külső helyeket megbízhatóan tudjuk fenntartani.

**Csökkenti-e a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a mögöttes pixeleket megtartják. Használjuk a [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) vagy a kép tömörítését vágott‑terület‑eltávolítással, ha ezeket a pixeleket véglegesen el akarjuk dobni.

**Vissza tudom állítani a kép minőségét a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a vágott területek eltávolítása elpusztítja a kép adatot. Ha később nagy felbontású szerkesztésre lehet szükség, tartsuk meg az eredeti forrásképet a prezentáción kívül.

**Hogyan kell kezelni az SVG képeket?**

Tartsuk meg az SVG tartalmat SVG‑ként, ha a vektor pontosság fontos. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) közvetlenül kiolvasható. A dia raster formátumba (PNG vagy JPEG) történő renderelése a SVG‑t pixelekké rasterizálja.

**Hogyan kerülhetem el a nem biztonságos cast‑eket a meglévő diák olvasásakor?**

Ellenőrizzük az alakzat típusát, mielőtt képkeret‑specifikus tagokat használnánk. Egy `instanceof` ellenőrzés a [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) ellen biztosítja, hogy elkerüljük az érvénytelen cast‑eket, és a kód képes legyen kezelni a képkeretet nem tartalmazó diákat.