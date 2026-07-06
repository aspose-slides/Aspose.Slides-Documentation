---
title: Spravujte rámečky obrázků v prezentacích pomocí JavaScriptu
linktitle: Rámeček obrázku
type: docs
weight: 10
url: /cs/nodejs-java/picture-frame/
keywords:
- rámeček obrázku
- přidat rámeček obrázku
- vytvořit rámeček obrázku
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrový obrázek
- vektorový obrázek
- oříznout obrázek
- oříznutá oblast
- vlastnost StretchOff
- formátování rámečku obrázku
- vlastnosti rámečku obrázku
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
description: "Přidejte rámečky obrázků do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js via Java. Zjednodušte svůj pracovní postup a vylepšete design snímků."
---
## **Úvod**

Rámeček obrázku je tvar, který obsahuje obrázek – je to jako obrázek v rámu.  

Můžete přidat obrázek na snímek pomocí rámečku obrázku. Tímto způsobem můžete formátovat obrázek formátováním rámečku obrázku.

{{% alert  title="Tip" color="primary" %}} 
Aspose poskytuje zdarma převodníky – [JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt) – které umožňují rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

## **Vytvořit rámeček obrázku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Vytvořte objekt `PPImage` přidáním obrázku do [ImagesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ImageCollection) spojené s objektem prezentace, který bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFrame) na základě šířky a výšky obrázku pomocí metody `addPictureFrame` vystavené objektem tvaru přidruženého k odkazovanému snímku.
6. Přidejte rámeček obrázku (obsahující obrázek) na snímek.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit rámeček obrázku:

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var sld = pres.getSlides().get_Item(0);
    // Vytvoří instanci třídy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Přidá rámeček obrázku se stejnou výškou a šířkou jako obrázek
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

Rámečky obrázku vám umožňují rychle vytvářet snímky prezentace na základě obrázků. Když kombinujete rámeček obrázku s možnostmi ukládání Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu pro převod obrázků z jednoho formátu do druhého.

## **Vytvořit rámeček obrázku s relativním měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější rámeček obrázku. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace.
4. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do [ImagesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ImageCollection) spojené s objektem prezentace, který bude použit k vyplnění tvaru.
5. Zadejte relativní šířku a výšku obrázku v rámečku obrázku.
6. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit rámeček obrázku s relativním měřítkem:

```javascript
// Vytvoří instanci třídy Presentation, která představuje PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var sld = pres.getSlides().get_Item(0);
    // Vytvoří instanci třídy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Přidá rámeček obrázku s výškou a šířkou ekvivalentní obrázku
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Nastavuje relativní míru výšky a šířky
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

## **Extrahovat rastrové obrázky z rámečků obrázku**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFrame) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený příklad kódu ukazuje, jak extrahovat obrázek z dokumentu "sample.pptx" a uložit jej ve formátu PNG.

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

## **Extrahovat SVG obrázky z rámečků obrázku**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides pro Node.js via Java vám umožňuje získat původní vektorové obrázky s plnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/), zkontrolovat, zda podkladový [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) obsahuje SVG data, a poté tento obrázek uložit na disk nebo do proudu v jeho nativním SVG formátu.

Následující příklad kódu ukazuje, jak extrahovat SVG obrázek z rámečku obrázku:

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

## **Získat průhlednost obrázku**

Aspose.Slides vám umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento JavaScriptový kód ukazuje operaci:

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

## **Získat jas a kontrast obrázku**

Aspose.Slides vám umožňuje získat efekt jasu a kontrastu aplikovaný na obrázek. Třída [Luminance](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/luminance/) představuje tento transformace obrázku.

Tento JavaScriptový kód ukazuje, jak získat nastavení jasu a kontrastu z rámečku obrázku:

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

## **Formátování rámečku obrázku**

Aspose.Slides poskytuje mnoho možností formátování, které lze použít na rámeček obrázku. Pomocí těchto možností můžete upravit rámeček obrázku tak, aby splňoval specifické požadavky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do [ImagesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ImageCollection) spojené s objektem prezentace, který bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte `PictureFrame` na základě šířky a výšky obrázku pomocí metody [addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) vystavené objektu [Shapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection) přidruženému k odkazovanému snímku.
6. Přidejte rámeček obrázku (obsahující obrázek) na snímek.
7. Nastavte barvu čáry rámečku obrázku.
8. Nastavte šířku čáry rámečku obrázku.
9. Otočte rámeček obrázku zadáním kladné nebo záporné hodnoty.
   * Kladná hodnota otáčí obrázek po směru hodinových ručiček. 
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.
10. Přidejte rámeček obrázku (obsahující obrázek) na snímek.
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje proces formátování rámečku obrázku:

```javascript
// Vytvoří instanci třídy Presentation, která představuje PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získá první snímek
    var sld = pres.getSlides().get_Item(0);
    // Vytvoří instanci třídy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Přidá rámeček obrázku s výškou a šířkou ekvivalentní obrázku
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
Aspose nedávno vyvinul [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, [vytvořit mřížky z fotografií](https://products.aspose.app/slides/cs/collage/photo-grid), můžete tento servis použít. 
{{% /alert %}}

## **Přidat obrázek jako odkaz**

Aby se předešlo velkým velikostem prezentace, můžete přidávat obrázky (nebo videa) pomocí odkazů místo přímého vložení souborů do prezentace. Tento JavaScriptový kód ukazuje, jak přidat obrázek a video do zástupce:

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

## **Oříznout obrázek**

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
    // Přidá rámeček obrázku na snímek
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Ořízne obrázek (hodnoty v procentech)
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

## **Smazat oříznuté oblasti obrázku**

Pokud chcete smazat oříznuté oblasti obrázku obsaženého v rámečku, můžete použít metodu [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Tato metoda vrací oříznutý obrázek nebo původní obrázek, pokud ořez není potřeba.

Tento JavaScriptový kód ukazuje operaci:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Získá rámeček obrázku z prvního snímku
    var picFrame = slide.getShapes().get_Item(0);
    // Smaže oříznuté oblasti obrázku v rámečku obrázku a vrátí oříznutý obrázek
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
Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek používán pouze v zpracovaném [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/), může tato úprava snížit velikost prezentace. V opačném případě se počet obrázků v výsledné prezentaci zvýší.

Metoda převádí metafily WMF/EMF na rastrový PNG obrázek během operace ořezávání. 
{{% /alert %}}

## **Komprimovat obrázky**

Obrázek v prezentaci můžete komprimovat pomocí metody [PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) . Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s volbou smazat oříznuté oblasti.

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Picture Format → Compress Pictures → Resolution**.

Následující příklady v JavaScriptu ukazují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelným odstraněním oříznutých oblastí:

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

Nebo použitím jiné předdefinované hodnoty DPI:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Komprimuje obrázek na 96 DPI (rozlišení pro e‑mail), odstraněním oříznutých oblastí.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také smazat pro optimalizaci velikosti souboru. Pokud je obrázek metafile (WMF/EMF) nebo SVG, komprese se nepoužije. Kvalita JPEG se zachová nebo mírně sníží podle rozlišení, podobně jako PowerPoint zachází s vysokým rozlišením JPEGu. 
{{% /alert %}}

## **Uzamknout poměr stran**

Pokud chcete, aby tvar obsahující obrázek zachoval svůj poměr stran i po změně rozměrů obrázku, můžete použít metodu [setAspectRatioLocked](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) pro nastavení volby *Lock Aspect Ratio*.

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
Nastavení *Lock Aspect Ratio* zachovává pouze poměr stran tvaru, nikoli obrázek, který tvar obsahuje. 
{{% /alert %}}

## **Použít vlastnost StretchOff**

Pomocí metod [setStretchOffsetLeft](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) a [setStretchOffsetBottom](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) ze třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PictureFillFormat) můžete určit výplňový obdélník.

Když je pro obrázek zadáno natažení, zdrojový obdélník se škáluje tak, aby odpovídal zadanému výplňovému obdélníku. Každý okraj výplňového obdélníku je definován procentuálním posunem od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento určuje vnitřní odsazení, záporné procento pak vnější výstupek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte obdélník `AutoShape`. 
4. Vytvořte obrázek.
5. Nastavte typ výplně tvaru.
6. Nastavte režim výplně obrázkem tvaru.
7. Přidejte nastavený obrázek pro výplň tvaru.
8. Zadejte posuny obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje proces, ve kterém je použita vlastnost StretchOff:

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
    // Nastaví obrázek k vyplnění tvaru
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

## **Často kladené dotazy**

**Jak zjistit, které formáty obrázků jsou podporovány pro PictureFrame?**

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF, atd.), tak vektorové obrázky (například SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/). Seznam podporovaných formátů se obecně překrývá s možnostmi enginu pro konverzi snímků a obrázků.

**Jak ovlivní přidání desítek velkých obrázků velikost a výkon souboru PPTX?**

Vkládání velkých obrázků zvyšuje velikost souboru a využití paměti; propojení obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly dostupné. Aspose.Slides poskytuje možnost přidávat obrázky pomocí odkazu, čímž snižuje velikost souboru.

**Jak mohu uzamknout objekt obrázku před nechtěným přesouváním/změnou velikosti?**

Použijte [zámky tvarů](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) pro [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) (například zakázání přesunu nebo změny velikosti). Mechanismus zamykání je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/).

**Je zachována vektorová věrnost SVG při exportu prezentace do PDF/obrázků?**

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) jako původní vektor. Při [exportu do PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) nebo [rasterových formátů](/slides/cs/nodejs-java/convert-powerpoint-to-png/) může být výsledek rastrován v závislosti na nastaveních exportu; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním extrakce.