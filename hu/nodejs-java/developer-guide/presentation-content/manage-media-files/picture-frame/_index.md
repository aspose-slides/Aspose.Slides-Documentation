---
title: Képkeretek kezelése prezentációkban JavaScript segítségével
linktitle: Képkeret
type: docs
weight: 10
url: /hu/nodejs-java/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raster kép
- vektor kép
- kép körbevágása
- körbevágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- kép hatás
- arány
- kép átlátszósága
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Adj hozzá képkereteket PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Node.js via Java segítségével. Egyszerűsítsd a munkafolyamatot és javítsd a diaterveket."
---
## **Bevezetés**

A képkeret egy olyan alakzat, amely egy képet tartalmaz – hasonló egy képkockához.  

Képet egy diára egy képkereten keresztül adhat hozzá. Így a képformázást a képkeret formázásával végezheti el.

{{% alert  title="Tip" color="primary" %}} 
Az Aspose ingyenes konvertereket biztosít – a [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és a [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) – amelyek lehetővé teszik a felhasználók számára, hogy gyorsan prezentációkat készítsenek képekből. 
{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Hozzon létre egy `PPImage` objektumot a prezentáció objektumhoz tartozó [ImagesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ImageCollection) kép hozzáadásával, amelyet az alakzat kitöltésére használ.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFrame) a kép szélessége és magassága alapján a hivatkozott diahoz tartozó alakzatobjektum által biztosított `addPictureFrame` metódus segítségével.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Írja a módosított prezentációt PPTX fájlként.  

Ez a JavaScript kód megmutatja, hogyan hozhat létre egy képkeretet:

```javascript
// Példányosítja a PPTX fájlt képviselő Presentation osztályt
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Példányosítja az Image osztályt
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Hozzáad egy képkeretet a képnek megfelelő magassággal és szélességgel
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // A PPTX fájlt lemezre írja
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

A képkeretek lehetővé teszik, hogy gyorsan készítsen prezentációs diát képek alapján. Ha a képkeretet az Aspose.Slides mentési beállításaival kombinálja, kezelheti a bemeneti/kimeneti műveleteket a képek formátumának átalakításához.

## **Képkeret létrehozása relatív méretezéssel**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képkollekciójának.  
4. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PPImage) objektumot a prezentáció objektumhoz tartozó [ImagesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ImageCollection) kép hozzáadásával, amelyet az alakzat kitöltésére használ.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja a módosított prezentációt PPTX fájlként.  

Ez a JavaScript kód megmutatja, hogyan hozhat létre egy képkeretet relatív méretezéssel:

```javascript
// Példányosítja a PPTX-et képviselő Presentation osztályt
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Példányosítja az Image osztályt
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Hozzáad egy képkeretet, amelynek magassága és szélessége megegyezik a képpel
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Relatív méretezés szélesség és magasság beállítása
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // A PPTX fájlt lemezre írja
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Raster képek kinyerése képkeretekből**

Kivonhat raster képeket a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFrame) objektumokból, és elmentheti őket PNG, JPG és más formátumokban. Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy képet a "sample.pptx" dokumentumból, és mentheti PNG formátumban.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **SVG képek kinyerése képkeretekből**

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyek [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) alakzatokba vannak helyezve, az Aspose.Slides for Node.js via Java lehetővé teszi, hogy a eredeti vektor képeket teljes hűséggel lekérdezze. A dia alakzategyeségének bejárásával azonosíthatja minden [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/), ellenőrizheti, hogy a mögöttes [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) SVG tartalmat tartalmaz‑e, majd elmentheti a képet lemezre vagy folyamra natív SVG formátumban.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Kép átlátszóságának lekérdezése**

Az Aspose.Slides lehetővé teszi, hogy lekérdezze egy képre alkalmazott átlátszósági hatást. Ez a JavaScript kód bemutatja a műveletet:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget biztosít, amelyeket egy képkeretre alkalmazhat. Ezekkel a lehetőségekkel módosíthatja a képkeretet, hogy megfeleljen a konkrét követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PPImage) objektumot a prezentáció objektumhoz tartozó [ImagesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ImageCollection) kép hozzáadásával, amelyet az alakzat kitöltésére használ.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame` a kép szélessége és magassága alapján a [addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) metódus segítségével, amely a hivatkozott diahoz tartozó [Shapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) objektumon keresztül érhető el.  
6. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalszélességét.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az óramutató járásával megegyező irányba forgatja a képet.  
   * A negatív érték az óramutató járásával ellentétes irányba forgatja a képet.  
10. Adjon hozzá a képkeretet (amely a képet tartalmazza) a diához.  
11. Írja a módosított prezentációt PPTX fájlként.  

Ez a JavaScript kód bemutatja a képkeret formázási folyamatát:

```javascript
// Példányosítja a PPTX-et képviselő Presentation osztályt
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Példányosítja az Image osztályt
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Hozzáad egy képkeretet, amelynek magassága és szélessége megegyezik a képpel
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Alkalmaz némi formázást a PictureFrameEx-re
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // A PPTX fájlt lemezre írja
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}} 
Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha valaha is [JPEG/JPEG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG képeket kell egyesítenie, [rácsokat kell létrehoznia fényképekből](https://products.aspose.app/slides/hu/collage/photo-grid), használhatja ezt a szolgáltatást. 
{{% /alert %}}

## **Kép hozzáadása hivatkozásként**

A nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) hivatkozásokon keresztül adhat hozzá ahelyett, hogy a fájlokat közvetlenül beágyazná a prezentációba. Ez a JavaScript kód megmutatja, hogyan adhat képet és videót egy helyőrzőhöz:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kép körbevágása**

Ez a JavaScript kód megmutatja, hogyan vághat körbe egy meglévő képet egy dián:

```javascript
var pres = new aspose.slides.Presentation();
// Új kép objektumot hoz létre
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Képkeretet ad hozzá egy diához
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Kivágja a képet (százalék értékek)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Elmenti az eredményt
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Képkeret körbevágott területeinek törlése**

Ha a keretben lévő kép körbevágott területeit szeretné törölni, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) metódust. Ez a metódus a körbevágott képet vagy a kiinduló képet adja vissza, ha a vágás nem szükséges.

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Lekéri a PictureFrame-et az első diáról
    var picFrame = slide.getShapes().get_Item(0);
    // Törli a PictureFrame kép körbevágott területeit és visszaadja a körbevágott képet
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Elmenti az eredményt
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) metódus a körbevágott képet a prezentáció képkollekciójába helyezi. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/)‑ben van használva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a létrejött prezentáció képeinek száma növekedni fog.  

Ez a metódus a vágási művelet során WMF/EMF metafájlokat raster PNG képpé konvertál. 
{{% /alert %}}

## **Képek tömörítése**

Képet tömöríthet egy prezentációban a [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) metódus használatával.  
Ez a metódus a képet a forma mérete és a megadott felbontás alapján csökkentve tömöríti, a körbevágott területek törlésének lehetőségével.  

A kép méretét és felbontását úgy állítja be, ahogy a PowerPoint **Picture Format → Compress Pictures → Resolution** funkciója is teszi.  

A következő JavaScript példák bemutatják, hogyan tömöríthet egy képet egy prezentációban célfelbontás megadásával és opcionálisan a körbevágott területek eltávolításával:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Tömöríti a képet 150 DPI (web felbontás) célfelbontással és eltávolítja a körbevágott területeket.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Ellenőrzi a tömörítés eredményét.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vagy egy másik előre definiált DPI érték használatával:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Tömöríti a képet 96 DPI-re (e-mail felbontás), eltávolítva a körbevágott területeket.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
A metódus a képet alacsonyabb felbontásra konvertálja a forma mérete és a megadott DPI alapján. A körbevágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem lesz alkalmazva. Emellett a JPEG minőség megmarad vagy a felbontás alapján enyhén csökken, ahogy a PowerPoint a nagy felbontású JPEG‑eket kezeli. 
{{% /alert %}}

## **Méretarány zárolása**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa a méretarányát még a kép méretének módosítása után is, használhatja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) metódust a *Lock Aspect Ratio* beállítás megtételéhez.

Ez a JavaScript kód megmutatja, hogyan zárolhatja egy alakzat méretarányát:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // Állítsa be az alakzatot, hogy a méretezéskor megőrizze az arányt
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
Ez a *Lock Aspect Ratio* beállítás csak az alakzat méretarányát őrzi meg, nem a benne lévő képet. 
{{% /alert %}}

## **StretchOff tulajdonság használata**

A [setStretchOffsetLeft](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) és [setStretchOffsetBottom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) metódusokkal a [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFillFormat) osztályból megadhat egy kitöltő téglalapot.  

Ha egy képhez nyújtás van megadva, egy forrástéglalap méreteződik a megadott kitöltő téglalapra. A kitöltő téglalap minden élét egy százalékos eltolás definiálja a forma határoló dobozának megfelelő élétől. A pozitív százalék befelé tolást, a negatív százalék pedig kifelé tolást jelent.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltési típusát.  
6. Állítsa be az alakzat képkitöltési módját.  
7. Adjon hozzá egy képet az alakzat kitöltéséhez.  
8. Határozza meg a kép eltolásait a forma határoló dobozának megfelelő élétől.  
9. Írja a módosított prezentációt PPTX fájlként.  

Ez a JavaScript kód demonstrál egy folyamatot, amelyben a StretchOff tulajdonságot használják:

```javascript
// Példányosítja a Prseetation osztályt, amely egy PPTX fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var slide = pres.getSlides().get_Item(0);
    // Példányosítja az ImageEx osztályt
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // AutoShape-et ad hozzá, mely Rectangle típusú
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Beállítja az alakzat kitöltési típusát
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Beállítja az alakzat képkitöltési módját
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Beállítja a képet az alakzat kitöltéséhez
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Meghatározza a kép eltolásait az alakzat határoló dobozának megfelelő élétől
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // A PPTX fájlt lemezre írja
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Hogyan deríthetem ki, hogy mely képformátumok támogatottak a PictureFrame számára?**  
Az Aspose.Slides támogatja mind a raster (PNG, JPEG, BMP, GIF stb.), mind a vektor (például SVG) képeket a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedi a diák és a képkonverziós motor képességeit.  

**Hogyan befolyásolja a több tucat nagy méretű kép hozzáadása a PPTX méretét és teljesítményét?**  
A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozásként való hozzáadása csökkenti a prezentáció méretét, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetőséget biztosít képek hivatkozásként történő hozzáadására a fájlméret csökkentése érdekében.  

**Hogyan zárolhatok egy képobjektumot a véletlen áthelyezéstől/méretezéstől?**  
Használja a [shape locks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) funkciót egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) esetén (például a mozgatás vagy a méretezés letiltásával). A zárolási mechanizmus több alakzat típusra is alkalmazható, beleértve a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/)‑t.  

**Megmarad-e az SVG vektor hűsége, ha egy prezentációt PDF‑be/képekbe exportálok?**  
Az Aspose.Slides lehetővé teszi egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/)‑ből történő SVG kinyerését eredeti vektorként. PDF‑re vagy raster formátumokra ([PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) vagy [PNG](/slides/hu/nodejs-java/convert-powerpoint-to-png/)) történő exportálás esetén az eredmény rasterizálódhat az exportálási beállításoktól függően; az, hogy az eredeti SVG vektorként van tárolva, a kinyerési viselkedés erősíti meg.