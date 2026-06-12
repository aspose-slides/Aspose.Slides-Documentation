---
title: Správa rámů obrázků v prezentacích pomocí JavaScriptu
linktitle: Rám obrázku
type: docs
weight: 10
url: /cs/nodejs-java/picture-frame/
keywords:
- rám obrázku
- přidat rám obrázku
- vytvořit rám obrázku
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrový obrázek
- vektorový obrázek
- oříznout obrázek
- oříznutá oblast
- vlastnost StretchOff
- formátování rámu obrázku
- vlastnosti rámu obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- průhlednost obrázku
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přidejte rámy obrázků do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Java. Zefektivněte svůj pracovní postup a vylepšete návrhy snímků."
---
## **Úvod**

Rám obrázku je tvar, který obsahuje obrázek – je to jako obrázek v rámečku.  

Obrázek můžete do snímku přidat prostřednictvím rámu obrázku. Tímto způsobem můžete formátovat obrázek úpravou rámu obrázku.

{{% alert  title="Tip" color="primary" %}} 
Aspose poskytuje zdarma konvertory —[JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt) —které umožňují rychle vytvořit prezentace z obrázků. 
{{% /alert %}} 

## **Vytvoření rámu obrázku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Vytvořte objekt `PPImage` přidáním obrázku do [ImagesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ImageCollection), která je součástí objektu prezentace a bude použita k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFrame) založený na šířce a výšce obrázku, pomocí metody `addPictureFrame`, která je dostupná u objektu tvaru přiřazeného k referencovanému snímku.
6. Přidejte rámy obrázku (obsahující obrázek) na snímek.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit rám obrázku:

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var sld = pres.getSlides().get_Item(0);
    // Vytvoří instanci třídy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Přidá rámy obrázku se stejnou výškou a šířkou jako obrázek
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Zapíše soubor PPTX na disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Rámky obrázku vám umožňují rychle vytvářet snímky prezentací založené na obrázcích. Když kombinujete rám obrázku s možnostmi uložení Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu a konvertovat obrázky z jednoho formátu do druhého.

## **Vytvoření rámu obrázku s relativním měřítkem**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace.
4. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do [ImagesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ImageCollection), která je součástí objektu prezentace a bude použita k vyplnění tvaru.
5. Zadejte relativní šířku a výšku obrázku v rámci obrázku.
6. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit rám obrázku s relativním měřítkem:

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var sld = pres.getSlides().get_Item(0);
    // Vytvoří instanci třídy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Přidá rámy obrázku s výškou a šířkou odpovídající obrázku
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Nastavení relativního měřítka šířky a výšky
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Zapíše soubor PPTX na disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Extrahování rastrových obrázků z rámů obrázku**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFrame) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený příklad kódu ukazuje, jak extrahovat obrázek z dokumentu „sample.pptx“ a uložit jej ve formátu PNG.

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

## **Extrahování SVG obrázků z rámů obrázku**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides pro Node.js přes Java vám umožní načíst původní vektorové obrázky v plné věrnosti.  
Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/), ověřit, zda podkladový [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) obsahuje SVG obsah, a poté uložit tento obrázek na disk nebo do proudu v jeho nativním SVG formátu.

Následující příklad kódu ukazuje, jak extrahovat SVG obrázek z rámu obrázku:

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

## **Získání průhlednosti obrázku**

Aspose.Slides vám umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento JavaScriptový kód demonstruje operaci:

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

## **Formátování rámu obrázku**

Aspose.Slides poskytuje mnoho možností formátování, které lze použít na rám obrázku. Pomocí těchto možností můžete upravit rám obrázku tak, aby vyhovoval konkrétním požadavkům.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do [ImagesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ImageCollection), která je součástí objektu prezentace a bude použita k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte `PictureFrame` založený na šířce a výšce obrázku, pomocí metody [addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) vystavené objektem [Shapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection) přiřazeným k referencovanému snímku.
6. Přidejte rám obrázku (obsahující obrázek) na snímek.
7. Nastavte barvu čáry rámu obrázku.
8. Nastavte šířku čáry rámu obrázku.
9. Otočte rám obrázku zadáním kladné nebo záporné hodnoty.  
   * Kladná hodnota otáčí obrázek ve směru hodinových ručiček.  
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.
10. Přidejte rám obrázku (obsahující obrázek) na snímek.
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód demonstruje proces formátování rámu obrázku:

```javascript
// Vytvoří instanci třídy Presentation, která představuje PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var sld = pres.getSlides().get_Item(0);
    // Vytvoří instanci třídy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Přidá rámy obrázku s výškou a šířkou odpovídající obrázku
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Aplikuje určité formátování na PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Zapíše soubor PPTX na disk
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose nedávno vyvinul [zdarma nástroj Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, [vytvořit mřížky z fotografií](https://products.aspose.app/slides/cs/collage/photo-grid), můžete použít tuto službu. 
{{% /alert %}}

## **Přidání obrázku jako odkazu**

Aby se předešlo velké velikosti prezentace, můžete přidávat obrázky (nebo videa) prostřednictvím odkazů místo jejich vložení přímo do prezentace. Tento JavaScriptový kód ukazuje, jak přidat obrázek a video do zástupného symbolu:

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

## **Oříznutí obrázku**

Tento JavaScriptový kód ukazuje, jak oříznout existující obrázek na snímku:

```javascript
var pres = new aspose.slides.Presentation();
// Vytvoří nový objekt obrázku
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
    // Přidá PictureFrame na snímek
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Ořízne obrázek (procentuální hodnoty)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Uloží výsledek
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranění oříznutých oblastí obrázku**

Pokud chcete odstranit oříznuté oblasti obrázku obsaženého v rámečku, můžete použít metodu [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--). Tato metoda vrátí oříznutý obrázek nebo původní obrázek, pokud ořez není potřebný.

Tento JavaScriptový kód demonstruje operaci:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Získá PictureFrame z prvního snímku
    var picFrame = slide.getShapes().get_Item(0);
    // Odstraní oříznuté oblasti obrázku v PictureFrame a vrátí oříznutý obrázek
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Uloží výsledek
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit pouze v zpracovaném [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/), může toto nastavení snížit velikost prezentace. V opačném případě se počet obrázků v výsledné prezentaci zvýší.  

Metoda při operaci ořezávání převádí WMF/EMF metafily na rastrový PNG obrázek. 
{{% /alert %}}

## **Komprese obrázků**

Můžete komprimovat obrázek v prezentaci pomocí metody [PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-).  
Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s možností odstranit oříznuté oblasti.  

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Formát obrázku → Komprimovat obrázky → Rozlišení**.  

Následující JavaScriptové ukázky demonstrují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelným odstraněním oříznutých oblastí:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Komprimuje obrázek s cílovým rozlišením 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Zkontroluje výsledek komprese.
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

Nebo pomocí jiného předdefinovaného DPI:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Komprimuje obrázek na 96 DPI (rozlišení pro e-mail), odstraňuje oříznuté oblasti.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také odstranit pro optimalizaci velikosti souboru.  
Pokud je obrázek metafilem (WMF/EMF) nebo SVG, komprese se neuplatní. Kvalita JPEG je zachována nebo mírně snížena podle rozlišení, podobně jako PowerPoint zachází s vysoké rozlišení JPEG obrázky. 
{{% /alert %}}

## **Uzamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval svůj poměr stran i po změně rozměrů obrázku, můžete použít metodu [setAspectRatioLocked](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) k nastavení volby *Lock Aspect Ratio*.

Tento JavaScriptový kód ukazuje, jak uzamknout poměr stran tvaru:

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
    // nastavit tvar tak, aby při změně velikosti zachoval poměr stran
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 
Nastavení *Lock Aspect Ratio* zachovává pouze poměr stran tvaru, nikoli obrázek, který obsahuje. 
{{% /alert %}}

## **Použití vlastnosti StretchOff**

Pomocí metod [setStretchOffsetLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) a [setStretchOffsetBottom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat) můžete určit výplňový obdélník.  

Když je pro obrázek zadáno roztažení, zdrojový obdélník se škáluje tak, aby zaplnil určený výplňový obdélník. Každý okraj výplňového obdélníku je definován procentuálním posunem od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento určuje vnitřní posun, záporné procento vnější posun.  

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).  
2. Získejte referenci na snímek pomocí jeho indexu.  
3. Přidejte obdélník `AutoShape`.  
4. Vytvořte obrázek.  
5. Nastavte typ výplně tvaru.  
6. Nastavte režim výplně obrázkem tvaru.  
7. Přidejte obrázek pro výplň tvaru.  
8. Zadejte posuny obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru.  
9. Uložte upravenou prezentaci jako soubor PPTX.  

Tento JavaScriptový kód demonstruje proces, ve kterém je použita vlastnost StretchOff:

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var slide = pres.getSlides().get_Item(0);
    // Vytvoří instanci třídy ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Přidá AutoShape nastavený na obdélník
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Nastaví typ výplně tvaru
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Nastaví režim výplně obrázkem tvaru
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Nastaví obrázek pro výplň tvaru
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Určuje posuny obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Zapíše soubor PPTX na disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jak zjistit, které formáty obrázků jsou podporovány pro PictureFrame?**  

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (např. SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/). Seznam podporovaných formátů obecně překrývá možnosti enginu pro snímky a konverzi obrázků.

**Jak ovlivní přidání desítek velkých obrázků velikost a výkon PPTX?**  

Vkládání velkých obrázků zvyšuje velikost souboru a využití paměti; prolinkování obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly dostupné. Aspose.Slides poskytuje možnost přidávat obrázky jako odkazy ke snížení velikosti souboru.

**Jak mohu uzamknout objekt obrázku před neúmyslným přesouváním/změnou velikosti?**  

Použijte [uzamčení tvarů](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) pro [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) (např. zakázat přesouvání nebo změnu velikosti). Mechanismus uzamčení je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/).

**Zůstane vektorová věrnost SVG při exportu prezentace do PDF/obrázků?**  

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) jako původní vektor. Při [exportu do PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) nebo [rastrových formátů](/slides/cs/nodejs-java/convert-powerpoint-to-png/) může být výsledek rasterizován v závislosti na nastavení exportu; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním extrakce.