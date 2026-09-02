---
title: Képkeretek kezelése prezentációkban Androidon
linktitle: Képkeret
type: docs
weight: 10
url: /hu/androidjava/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- kapcsolt kép
- kép kinyerése
- raster kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív méretezés
- kép hatás
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Android segítségével Java nyelven."
---
## **Áttekintés**

A képkeret egy diára helyezett alakzat, amely megjelenít egy képet. Az Aspose.Slides-ben a képernyöforrás és a azt megjelenítő alakzat külön objektumok: egy [Prezentáció](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) beágyazott képforrásokat birtokol az [IImageCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagecollection/)-en keresztül, míg egy [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) vezérli a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb keret szintű beállításait.

Ez a szétválasztás hasznos, ha ugyanaz a kép többször is megjelenik. Add hozzá a képet egyszer a prezentációhoz, tartsd meg a visszakapott [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/)-et, és használd ezt a képforrást a képkeretek létrehozásakor.

Az képkeretek rasterképeket, például PNG vagy JPEG formátumot, valamint vektor SVG képeket is tartalmazhatnak. Emellett hivatkozhatnak kapcsolt képekre is, ahelyett, hogy a kép bájtjait a prezentációba tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan legyen a kép tárolva a formázás vagy optimalizálás előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén add hozzá a kép adatokat a prezentációhoz, és hozz létre egy képkeretet az [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) segítségével. A kép a prezentációcsomag részévé válik, így a prezentáció önálló marad, ha egy másik számítógépre kerül.

A következő példa egy JPEG képet ad hozzá, a kép natív méreteiben hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:

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

A képkeret szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti pixeles méreteket, amelyek a beágyazott képforrásban tárolódnak. Ez a különbség későbbi vágás vagy tömörítés esetén válik fontosá.

## **Relatív méretezés használata**

Az [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) a keret relatív szélesség- és magasságméretezését a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) metódusokon keresztül teszi elérhetővé. Az `1.0` érték az eredeti kép 100%-ának felel meg. A relatív méretezés hasznos, ha egy munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével, ahelyett, hogy manuálisan számolná ki a végső méreteket.

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

A relatív méretezés módosítja a keret méretezési beállításait; nem végzi el a beágyazott kép átmintavételezését vagy tömörítését.

## **Beágyazott és kapcsolt képek**

Egy beágyazott kép a kép adatokat a prezentáción belül tárolja, ezért a legbiztonságosabb választás a hordozhatóság és a kiszámítható megjelenítés szempontjából. Egy kapcsolt kép egy külső helyet tárol az [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) metóduson keresztül, ahelyett, hogy ugyanúgy beágyazná a kép adatokat.

A kapcsolt képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget vezetnek be. A kapcsolt fájlnak elérhetőnek kell maradnia az alkalmazás számára, amely megnyitja vagy rendereli a prezentációt. Ha az útvonal megváltozik, a fájl áthelyeződik, vagy az erőforrás nem érhető el, a kapcsolt kép nem jelenhet meg a várt módon. Olyan prezentációk esetén, amelyeket e-mailben kell elküldeni, archiválni vagy elszigetelt környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Kapcsolt kép hozzáadása**

A következő példa létrehoz egy képkeretet, és egy helyi képfájlra irányítja azt. Csak képhivatkozásra vonatkozik; a videohivatkozás egy külön média munkafolyamat, és szándékosan nincs keverve ebbe a példába.

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

Használj linkeket, ha a külső fájlkezelés szándékos. Ne használd őket pusztán tömörítés helyettesítésére: egy kis PPTX törött képfüggőségekkel általában kevésbé hasznos, mint egy nagyobb önálló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyernél ki egy meglévő prezentációból, ellenőrizd, hogy az alakzat valóban [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/)‑e, és tartalmaz‑e beágyazott képet. A kapcsolt képkeretek nem feltétlenül tartalmaznak olyan képbyte‑okat, amelyeket ugyanígy ki lehetne nyerni.

### **Rasterkép kinyerése**

A modern kép API közvetlenül az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/)‑et használja, és nem igényli a régebbi Java képburkolót. A következő példa megtalálja a első beágyazott rasterképet egy dián, és PNG‑ként menti el:

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

Az [IImage.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) segítségével történő mentés a kinyert képet a kért kimeneti formátumba konvertálja. Ha a prezentációban tárolt kódolt byte‑okra van szükséged egy konvertált rasterfájl helyett, akkor a képforrás bináris adatait használd.

### **SVG kép kinyerése**

SVG kép esetén az [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) objektumot tesz elérhetővé. Ez lehetővé teszi, hogy közvetlenül lekérd az SVG adatot, ahelyett, hogy előbb rasterizálnád a képet.

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

Az SVG tartalom SVGként tartása megőrzi a vektor forrást a prezentáción belül. A raster exportok, mint a PNG vagy JPEG, kötelezően a vektort pixelekké alakítják. A PDF vagy SVG diakivitel szintén egy renderelési művelet, ezért az exportált grafikákat nem szabad az eredeti beágyazott SVG bájt‑bájt másolatának tekinteni; használd a beágyazott [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/#getSvgData--) adatot, ha az eredeti vektor erőforrásra van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. Az [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) vágásértékei a forráskép méreteinek százalékai. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

A következő példa biztonságosan megtalálja egy képkeretet, és alkalmazza a vágási értékeket:

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

Mivel a rejtett képadatok még jelen vannak, a vágás később módosítható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszafordíthatóság, a vágott területek fizikailag eltávolíthatók a következő szakaszban leírt módon.

## **Vágott képadatok eltávolítása**

Az [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) eltávolítja a jelenlegi vágási téglalapon kívüli képadatokat, és visszaadja az eredményül kapott képforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után a eltávolított pixelek már nem állnak rendelkezésre egy későbbi visszavágásra.

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

Az eljárás új képforrást is hozzáadhat a prezentációhoz. Ha az eredeti képet más képkeretek is használják, azoknak továbbra is szükségük van a meglévő erőforrásra, így a vágott területek törlése nem feltétlenül csökkenti a képek teljes számát. WMF vagy EMF tartalom vágása ezzel a módszerrel a vágott eredményt PNG‑re rasterizálja.

## **Rasterképek tömörítése**

Az [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) csökkenti a rasterkép felbontását a kép megjelenítési méretéhez képest. Ugyanabban a műveletben eltávolíthatja a vágott területeket is. A metódus `true` értéket ad vissza, ha a képet átméretezték vagy vágta, és `false` értéket, ha nem volt szükség változtatásra.

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

Egy egyedi pozitív DPI érték is megadható előre definiált érték helyett, ha konkrét célfonatlanság szükséges.

A tömörítés rasterképekre van tervezve. SVG és metafájl tartalmat ez a raster tömörítési munkafolyamat nem csökkenti. Emellett ne feledd, hogy az alacsonyabb felbontás és a törölt vágott területek nem állíthatók vissza az optimalizált prezentációból. Válassz célfelbontást a kép ténylegesen legnagyobb megtekintési vagy exportálási mérete alapján, ahelyett, hogy globálisan a legalacsonyabb DPI‑t alkalmaznád.

## **Képhatások vizsgálata**

A képhatásokat a keret által használt képen tárolják. A képtranszformáció-gyűjtemény tartalmazhat olyan hatásokat, mint a fix alfa moduláció az átlátszósághoz és a luminancia a fényerő és kontraszt szabályozásához. Az alábbi példa biztonságosan beolvassa mindkét típusú hatást a dián lévő első képkeretből:

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
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ezek a hatások megváltoztatják, hogyan jelenik meg a kép a keretben; nem írják felül az eredeti beágyazott kép byte‑okat.

## **Képkeret geometria zárolása**

Az [IPictureFrameLock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/) beállításai szabályozzák, mely szerkesztési műveletek vannak letiltva egy képkeretnél. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) a méretezés során megtartja az alakzat arányait.

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

A zárolás a képkeret alakzatra vonatkozik. Nem kényszeríti a forrásképet átmintavételezésre vagy állandóan ugyanarra az arányra módosításra.

## **StretchOffset értékek módosítása**

Ha a képtöltés módja a nyújtás (stretch), akkor az [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) stretch‑offset értékei a kitöltési téglalapot a képkeret határoló dobozához képest definiálják. A pozitív százalékok szélről befelé hoznak, míg a negatív százalékok kifelé tologatnak.

Ez különbözik a vágástól. A vágási értékek kiválasztják a forráskép látható részét; a stretch offsetok megváltoztatják azt a téglalapot, amelybe a látható képkitöltés nyújtva van.

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

Használd a stretch offsetokat a kitöltés elhelyezéséhez. Használd a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a kép tárolás és a képkeret formázása külön-külön kerül kezelve:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a legmegbízhatóbbak a megosztás és a szerveroldali renderelés esetén, de a nagy rasterképek növelik a PPTX méretét és a memóriahasználatot.
- **Kapcsolt képek** kisebb csomagot eredményezhetnek, de a prezentáció a tárolt útvonalakon vagy helyeken elérhető külső fájloktól függ.
- **Vágás** kezdetben nem destruktív. A rejtett pixelek addig beágyazva maradnak, amíg a vágott területeket kifejezetten nem törlik vagy nem távolítják el tömörítés közben.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretes rasterképek esetén, de a forrásfelbontást feláldozza. A kívánt diával megjelenített méret ismerete után kell alkalmazni.
- **SVG képek** SVGként kell maradjanak, ha fontos a vektor megőrzése. Nyerd ki a beágyazott SVG‑t közvetlenül, ha a vektor erőforrásra van szükség. A raster diakivitálások mindig a megjelenített diát pixelekké konvertálják.
- **Ismétlődő képek** esetén használj már meglévő [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) erőforrást, ha lehetséges, ahelyett, hogy ugyanazt a fájlt többször betöltenéd a prezentáció munkafolyamatába.

Nagy prezentációk esetén a képoptimalizálás általában akkor a leghatékonyabb, ha célzottan történik: tartsd a logókat és diagramokat vektor tartalomként, tömörítsd a fényképeket a valós megjelenítési méretük szerint, csak akkor távolítsd el a vágott pixeleket, ha későbbi szerkesztés nem szükséges, és kerüld a külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervezésnek.

## **GYIK**

**Mi a különbség egy képkeret és egy képforrás között?**

Az [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) egy a prezentációhoz kapcsolódó képforrást képvisel. Az [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) egy dián lévő alakzat, amely képet jelenít meg, és keret‑szintű geometriát és formázást tárol, például méretet, forgatást, vágási értékeket, hatásokat és zárolásokat.

**Be kellene‑e ágyaznom vagy kapcsolnom a képeket?**

Ágyazd be a képeket, ha a prezentációnak hordozhatónak, archiváltnak vagy külső erőforrások hozzáférése nélkül renderelhetőnek kell lennie. Kapcsold a képeket csak akkor, ha szándékos a képfájlok a PPTX‑en kívül tartása, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti‑e a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de megőrzik az alatta lévő pixeleket. Használd az [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--)‑t vagy a képtömörítést vágott terület eltávolításával, ha ezek a pixelek véglegesen eldobhatók.

**Vissza tudom állítani a kép minőségét a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a vágott területek eltávolítása eldobja a képadatokat. Tartsd meg az eredeti forrásképet a prezentáción kívül, ha később nagy felbontású szerkesztésre lehet szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsd az SVG tartalmat SVGként, ha a vektorgyűjthetőség fontos. A beágyazott [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) közvetlenül kinyerhető. A dia rasterformátumba (például PNG vagy JPEG) való renderelése rasterizálja az SVG‑t a dia képének részeként.

**Hogyan kerülhetem el a nem biztonságos castolásokat meglévő diák olvasásakor?**

Ellenőrizd az alakzat típusát, mielőtt képkeret‑specifikus tagokat használnál. Az `instanceof` ellenőrzés az [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/)‑re elkerüli az érvénytelen castokat, és lehetővé teszi a kód számára, hogy kezelje azokat a diák, amelyek nem tartalmaznak képkereteket.