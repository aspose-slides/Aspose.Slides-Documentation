---
title: Képkeretek kezelése prezentációkban JavaScript használatával
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
- raszteres kép
- vektorkép
- kép vágása
- levágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- kép effektus
- oldalarány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Adjon hozzá képkereteket PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for Node.js via Java segítségével. Egyszerűsítse munkafolyamatát és javítsa a diák tervezését."
---
## **Bevezetés**

A képkeret olyan alakzat, amely képet tartalmaz – ez olyan, mint egy kép egy keretben.  
Képet egy diára képkeret segítségével adhat hozzá. Így a képet a képkeret formázásával formázhatja.

{{% alert  title="Tip" color="primary" %}} 
Aspose ingyenes konvertálókat kínál — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyek lehetővé teszik, hogy a felhasználók gyorsan prezentációkat hozzanak létre képekből. 
{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy `PPImage` objektumot a prezentációhoz kapcsolódó [ImagesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ImageCollection) kép hozzáadásával, amelyet az alakzat kitöltésére használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFrame) objektumot a kép szélessége és magassága alapján a `addPictureFrame` metódus segítségével, amely a hivatkozott diához tartozó alakzat objektumon keresztül érhető el.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a JavaScript kód megmutatja, hogyan hozhat létre képkeretet:

```javascript
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt reprezentál
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Példányosítja az Image osztályt
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Képkeretet ad hozzá a kép megfelelő magasságával és szélességével
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // A PPTX fájlt a lemezre írja
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

A képkeretek lehetővé teszik, hogy gyorsan prezentációs diákat hozzunk létre képek alapján. Amikor a képkeretet kombinálja az Aspose.Slides mentési beállításaival, manipulálhatja a bemenet/kimenet műveleteket a képek formátumok közötti konvertálásához.

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív méretezésének módosításával összetettebb képkeretet hozhat létre.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy `PPImage` objektumot a prezentációhoz kapcsolódó [ImagesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ImageCollection) kép hozzáadásával, amelyet az alakzat kitöltésére használnak.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a JavaScript kód megmutatja, hogyan hozhat létre képkeretet relatív méretezéssel:

```javascript
// Példányosítja a Presentation osztályt, amely a PPTX-et reprezentálja
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Példányosítja az Image osztályt
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Képkeretet ad hozzá a kép magasságával és szélességével megegyező méretekkel
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Relatív skála beállítása szélesség és magasság szerint
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // A PPTX fájlt a lemezre írja
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Raster képek kinyerése képkeretekből**

Raster képeket tud kinyerni a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFrame) objektumokból, és PNG, JPG, illetve egyéb formátumokban menteni őket. Az alábbi kódpélda bemutatja, hogyan lehet egy képet kinyerni a "sample.pptx" dokumentumból, és PNG formátumban menteni.

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

Amikor egy prezentáció SVG grafikát tartalmaz, amely [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) alakzatokba van ágyazva, az Aspose.Slides for Node.js Java-n keresztül lehetővé teszi, hogy az eredeti vektor képeket teljes hűséggel lekérje. A dia alakzat-gyűjteményének bejárásával azonosíthatja minden egyes [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) objektumot, ellenőrizheti, hogy a hozzá tartozó [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) SVG tartalmat tartalmaz-e, majd elmentheti a képet a lemezre vagy áramlásba natív SVG formátumban.

Ezen kódpélda bemutatja, hogyan lehet SVG képet kinyerni egy képkeretből:

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

## **Kép átlátszóságának lekérése**

Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott átlátszósági hatást. Ez a JavaScript kód bemutatja a műveletet:

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

## **Kép fényerő és kontrasztjának lekérése**

Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott fényerő és kontraszt hatást. A [Luminance](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/luminance/) osztály képviseli ezt a képtranszformációs hatást.

Ez a JavaScript kód bemutatja, hogyan lehet lekérni a fényerő és a kontraszt beállításait egy képkeretből:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket a képkeretre lehet alkalmazni. Ezekkel a beállításokkal módosíthatja a képkeretet, hogy megfeleljen a speciális követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy `PPImage` objektumot a prezentációhoz kapcsolódó [ImagesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ImageCollection) kép hozzáadásával, amelyet az alakzat kitöltésére használnak.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame` objektumot a kép szélessége és magassága alapján a [addPictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) metódus segítségével, amely a hivatkozott diához tartozó [Shapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) objektumon keresztül érhető el.  
6. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalvastagságát.  
9. Forgassa el a képkeretet, pozitív vagy negatív értéket megadva.  
   * A pozitív érték a képet az óramutató járásával megegyező irányba forgatja.  
   * A negatív érték a képet az óramutató járásával ellentétes irányba forgatja.  
10. Adjon hozzá egy képkeretet (amely a képet tartalmazza) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a JavaScript kód bemutatja a képkeret formázási folyamatát:

```javascript
// Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
var pres = new aspose.slides.Presentation();
try {
    // Lekéri az első diát
    var sld = pres.getSlides().get_Item(0);
    // Példányosítja az Image osztályt
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Képkeretet ad hozzá a kép magasságával és szélességével megegyezően
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Alkalmaz némi formázást a PictureFrameEx-re
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // A PPTX fájlt a lemezre írja
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha valaha is [JPG/JPEG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG képeket szeretne egyesíteni, illetve [rácsokat szeretne készíteni fotókból](https://products.aspose.app/slides/hu/collage/photo-grid), használhatja ezt a szolgáltatást. 

{{% /alert %}}

## **Kép hozzáadása hivatkozásként**

A nagy prezentációs méretek elkerülése érdekében képeket (vagy videókat) hivatkozásokon keresztül adhat hozzá ahelyett, hogy a fájlokat közvetlenül beágyazná a prezentációkba. Ez a JavaScript kód bemutatja, hogyan adhat képet és videót egy helykitöltőbe:

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

## **Kép vágása**

Ez a JavaScript kód bemutatja, hogyan vághat le egy meglévő képet a dián:

```javascript
var pres = new aspose.slides.Presentation();
// Létrehoz egy új képobjektumot
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
    // Képkeretet ad egy diához
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Levágja a képet (százalék értékek)
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

## **Képkeret levágott területeinek törlése**

Ha törölni szeretné a képkeretben levágott területeket, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) metódust. Ez a metódus a levágott képet vagy az eredeti képet adja vissza, ha a vágás nem szükséges.

Ez a JavaScript kód bemutatja a műveletet:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Lekéri a PictureFrame-et az első diáról
    var picFrame = slide.getShapes().get_Item(0);
    // Törli a PictureFrame kép levágott területeit, és visszaadja a levágott képet
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

A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) metódus hozzáadja a levágott képet a prezentáció képgyűjteményéhez. Ha a kép csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/)‑ben van használva, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a kész prezentációban lévő képek száma nőni fog.

A metódus a vágási művelet során WMF/EMF metafájlokat raszteres PNG képpé konvertál. 

{{% /alert %}}

## **Képek tömörítése**

Egy képet a prezentációban tömöríthet a [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) metódussal. Ez a metódus a képet a alakzat mérete és a megadott felbontás alapján csökkentve tömöríti, a levágott területek törlésének lehetőségével.

Ez a képméretet és felbontást úgy állítja be, mint a PowerPoint **Picture Format → Compress Pictures → Resolution** funkciója.

A következő JavaScript példák bemutatják, hogyan lehet egy képet tömöríteni a prezentációban célfelbontás megadásával, és opcionálisan a levágott területek eltávolításával:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Tömöríti a képet 150 DPI (web felbontás) célfelbontással és eltávolítja a levágott területeket.
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

    // Tömöríti a képet 96 DPI-re (e-mail felbontás), eltávolítva a levágott területeket.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

A metódus a képet az alakzat mérete és a megadott DPI alapján alacsonyabb felbontásra konvertálja. A levágott területek is törölhetők a fájlméret optimalizálása érdekében. Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. Emellett a JPEG minősége a felbontás alapján megmarad vagy enyhén csökken, hasonlóan ahhoz, ahogy a PowerPoint a nagy felbontású JPEG‑eket kezeli.

{{% /alert %}}

## **Arányok zárolása**

Ha egy képet tartalmazó alakzatot szeretne megőrizni az arányait, még akkor is, ha a kép méreteit megváltoztatja, használhatja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) metódust az *Arányok zárolása* beállítás beállításához.

Ez a JavaScript kód megmutatja, hogyan lehet zárolni egy alakzat arányait:

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
    // Állítsa be az alakzatot, hogy a méretezéskor megőrizze az oldalarányt
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Ez az *Arányok zárolása* beállítás csak az alakzat arányát őrzi meg, nem a benne lévő képet. 
{{% /alert %}}

## **StretchOff tulajdonság használata**

A [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PictureFillFormat) osztály [setStretchOffsetLeft]..., [setStretchOffsetTop]..., [setStretchOffsetRight]... és [setStretchOffsetBottom]... metódusainak használatával megadhat egy kitöltő téglalapot.

Ha egy kép nyújtását határozza meg, a forrástéglalap a megadott kitöltő téglalap méretéhez lesz méretezve. A kitöltő téglalap minden élét a forma határdobozának megfelelő élétől mért százalékos eltolás definiálja. A pozitív százalék beavatkozik (inset), a negatív százalék pedig kiinduló pontot (outset) jelöl.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be az alakzat kitöltési típusát.  
6. Állítsa be az alakzat képtöltési módját.  
7. Adjon meg egy képet, amely kitölti az alakzatot.  
8. Adja meg a kép eltolásait a forma határoló dobozának megfelelő élétől.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a JavaScript kód bemutat egy olyan folyamatot, amelyben a StretchOff tulajdonságot használják:

```javascript
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
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
    // AutoShape-et ad a diához, téglalap típusú
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Beállítja az alakzat kitöltési típusát
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Beállítja az alakzat képkitöltési módját
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Beállítja a képet, hogy kitöltse az alakzatot
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Megadja a kép eltolásait a alakzat határdobozának megfelelő élétől
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // A PPTX fájlt a lemezre írja
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Hogyan tudom megtudni, hogy mely képformátumok támogatottak a PictureFrame esetén?**  
Az Aspose.Slides támogat mind raszteres képeket (PNG, JPEG, BMP, GIF stb.), mind vektor képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/)‑hez rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedésben van a dia- és képkonvertáló motor képességeivel.

**Hogyan befolyásolja a PPTX méretét és teljesítményét a tucatnyi nagy kép hozzáadása?**  
A nagy képek beágyazása megnöveli a fájlméretet és a memóriahasználatot; a képek hivatkozásként való hozzáadása segít csökkenteni a prezentáció méretét, de megköveteli, hogy a külső fájlok elérhetők maradjanak. Az Aspose.Slides lehetővé teszi a képek hivatkozásként történő hozzáadását a fájlméret csökkentése érdekében.

**Hogyan tudom zárolni egy képtárgyat a véletlen mozgatás/átméretezés ellen?**  
Használjon [shape locks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltásával). A zárolási mechanizmus többféle alakzattípushoz támogatott, beleértve a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/)‑t is.

**Megmarad-e az SVG vektor hűsége, amikor a prezentációt PDF/ képek formátumba exportáljuk?**  
Az Aspose.Slides lehetővé teszi egy SVG kinyerését a [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) objektumból eredeti vektor formátumban. A [PDF-be exportálás](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) vagy [raszteres formátumokba](/slides/hu/nodejs-java/convert-powerpoint-to-png/) esetén az eredmény a export beállításaitól függően raszterizálódhat; az eredeti SVG vektorként való tárolása a kinyerési viselkedés által bizonyított.