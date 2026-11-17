---
title: Képátalakítási hatások kezelése prezentációkban Androidon
linktitle: Képátalakítási hatások
type: docs
weight: 11
url: /hu/androidjava/image-transform-effects/
keywords:
- képátalakítás
- képhatás
- fényerő
- kontraszt
- szürkeárnyalat
- kétárnyalatos
- színárnyalat
- HSL
- színhelyettesítés
- elmosás
- átlátszóság
- alfa hatás
- hatáklánc
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazza, láncolja, ellenőrizze, távolítsa el, és ellenőrizze a képátalakítási hatásokat képkockákra az Aspose.Slides for Android segítségével Java nyelven."
---
## **Áttekintés**

Az Aspose.Slides a képek módosításait rendezett képarány-műveletgyűjteményként ábrázolja. Egy képkockához kezdje a keret [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) lekérésével, majd hívja meg a [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) metódust. A visszaadott [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) lehetővé teszi műveletek hozzáadását, felsorolasát, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti kép bájtjait újraírná.

Ez a cikk egy teljes munkafolyamatot mutat be a fényerő és kontraszt, színátalakítások, elmosás, átlátszóság, rendezett hatákláncok, tényleges értékek, eltávolítás és PPTX körútfeldolgozás ellenőrzése terén.

## **A hatás tulajdonjogának és a kép újrafelhasználásának megértése**

Egy képernyőforrás és a megjelenítő kép külön objektumok:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forrásképadatokra.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) egy képtöltéshez tartozik, és egy képernyőforrásra hivatkozik, miközben a képarány-művelet-gyűjteményt tárolja.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) a dia alakzata, amely a megfelelő képtöltést, geometriát, vágásbeállításokat és egyéb keretszintű formázásokat birtokolja.

Ezért a képarány-műveletek **nem** módosítják a [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) bájtjait. Amikor ugyanazt az `IPPImage`‑t többször adjuk át a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódusnak, minden új képkeret saját `ISlidesPicture`‑t és saját átalakítási gyűjteményt kap. Az egyik keretre alkalmazott szürkeárnyalatos hatás **nem** teszi a többi keretet szürkeárnyalatosra, annak ellenére, hogy mind ugyanazt a beágyazott képernyőforrást használják.

Ugyanez a `ISlidesPicture.getImageTransform` modell más képtöltéseknél is használható, például alakzat vagy dia háttér esetén. Az alábbi példák a képkeretekre összpontosítanak.

## **Érvényes paramétertartományok és egységek használata**

A bemutatott metódusok a következő szemantikai tartományokat és egységeket használják. Tartsa a értékeket ezen tartományokon belül, még ha egy adott könyvtárverzió nem is utasítja el azonnal a tartományon kívüli értékeket; a célprezentáció formátuma normalizálhat, kihagyhat vagy elutasíthat érvénytelen adatokat mentéskor vagy a PowerPoint fájl megnyitásakor.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` és `100` között, százalék; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Nincs | Nincsenek numerikus paraméterek. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Két szín a sötét és világos pixelekhez. Az `android.graphics.Color` által használt RGB és alfa csatorna értékek `0`‑tól `255`‑ig terjednek. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Árnyalat: `0` (inkl.)‑tól `360` (exkl.)‑ig, fokban; mennyiség: `-100`‑tól `100`‑ig, százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Árnyalat: `0` (inkl.)‑tól `360` (exkl.)‑ig, fokban; telítettség és fényerő: `-100`‑tól `100`‑ig, százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Sugár: nemnegatív, pontban mérve; `grow` egy logikai érték, amely vezérli, hogy a elmosott tartalom kiterjeszthető‑e az eredeti határokon kívülre. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nemnegatív százalék. Használja a `0`‑tól `100`‑ig tartományt a hagyományos átlátszóság‑skálázáshoz: `0` teljesen átlátszó, `100` megőrzi a meglévő alfabétát. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszóság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél vagy fölötte lévő értékek átlátszatlanok. |

Az állandó alfa‑moduláció esetén az átlátszóság és az opacitás kiegészítőek. Például a 35 % átlátszóság egy 65 % alfa‑modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

Az [IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) egy [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) műveletet ad vissza. Skalár beállításai a művelet létrehozásakor kerülnek megadásra. A [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) kiszámított, csak‑olvasásra szánt értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 % fényerőt és 20 % kontrasztot ad hozzá, majd előnézetet renderel anélkül, hogy módosítaná a beágyazott képet:

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
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

A [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) egy Office 2010 kép‑hatásbővítmény, és kevésbé hordozható, mint a szabványos DrawingML luminance hatás. Ha a fényerő és kontraszt szerkeszthetőnek kell maradnia egy PPTX körúton, használja a [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) metódust, és ellenőrizze az eredményt a fájl újbóli megnyitása után. A formátum‑korlátozások szekció részletesebben kifejti ezt a különbséget.

## **Színátalakítások alkalmazása**

A színhatásokat függetlenül alkalmazhatja különböző képkeretekre, amelyek ugyanazt a képernyőforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, színárnyalat, HSL‑beállítás és színhelyettesítés hatásokat alkalmaz rájuk.

Az [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) két függetlenül szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket képezi. Ez egy jó példa egy olyan hatásra, amelynek beállításai összetettebbek, mint egy egyszerű skalár érték.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) minden pixel színét egy rögzített színre cseréli, miközben megőrzi az alfabétát. Ez különbözik a [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) módszertől, amely egy forrás‑színt egy másikra képezi, és mindkét színformátumot exponálja.

### **Luminancia küszöb alkalmazása**

A luminancia‑küszöb segíthet a beolvasott oldal halvány jeleit a háttértől elkülöníteni. Az [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) megőrzi a köztes szürke árnyalatokat. Az [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) a luminanciát feketére vagy fehérre képezi, míg az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) egy átlátszósági küszöböt alkalmaz.

A luminancia‑küszöb 0 %‑tól 100 %-ig, inkluzívan terjed. A küszöbnél alacsonyabb pixelek fekete lesznek, a küszöbnél vagy felette lévők fehér. A küszöb emelése több árnyalatot feketévé tesz, mert több pixel esik a határ alá.

Töltse le a [grayscale‑swatches.png](grayscale-swatches.png) fájlt a munkakönyvtárba. Minden címke az eredeti szürke szintet mutatja 0‑tól 255‑ig skálázva. A példa az eredetit helyezi el két másolat mellé, és minden másolat küszöbét a prezentációban elmenti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nyissa meg a kimeneti prezentációt PowerPointban a három keret összehasonlításához. A 96‑os jelölt mintaszín körülbelül 38 % luminanciát tartalmaz (96/255). 20 % küszöbnél fehér, 60 % küszöbnél feketére vált.

![Eredeti szürkeárnyalatos minták a fekete‑fehér eredményekkel a 20 % és 60 % luminancia‑küszöbökön](luminance-threshold.png)

## **Elmosás, átlátszóság és alfa‑hatások hozzáadása**

Az [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) minden színcsatornát, beleértve az alfabétát is, érinti. Állítsa a `grow` paramétert `true`‑ra, ha az elmosott él a kép eredeti határain kívülre terjedhet.

Egységes átlátszóság esetén használja az [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) metódust. Ez minden létező alfa‑értéket megszoroz, így a részben átlátszó pixelek arányosan különböznek továbbra is. Az [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ehelyett egyetlen alfa‑értéket ad minden pixelnek. Az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) két szintre konvertálja az alfabétát egy küszöb alapján.

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

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

További paraméter‑nélküli alfa‑műveletek: az [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) minden nem‑nulla alfabétát teljesen átlátszatlanná tesz; az [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) minden 100 % alatti alfabétát teljesen átlátszóvá alakítja; valamint az [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) az alfabétát `100% - alpha` képlettel változtatja meg.

## **Rendezett hatáklánc felépítése**

Minden `add...Effect` metódus új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt egy rendezett csővezetékként használja: a 0‑s művelet kimenete lesz az 1‑es bemenete, stb. Ennek következtében a műveletek más sorrendben más képet eredményezhetnek.

Például a szürkeárnyalatos hatás, majd a színárnyalat előbb eltávolítja a kromatikus információt, majd újraszínezi a luminancia‑eredményt. A színárnyalat, majd a szürkeárnyalatos hatás viszont a színárnyalatot újból eltávolítja. Hasonlóképpen, az alfa‑helyettesítés felülírhatja a korábbi műveletek által kiszámított alfa‑értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy műveletből álló láncot hoz létre, PPTX‑ként menti, újból megnyitja a prezentációt, ellenőrzi a művelettípusokat és a sorrendet, majd a megnyitott eredményt rendereli:

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
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely a szín‑, alfa‑ és elmosás‑műveleteket külön láncokra korlátozná. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy fix színhelyettesítés eltávolítja az előző színhatások által létrehozott RGB‑variációt; a szürkeárnyalatos duotone után eltávolítja a két kiválasztott színt; az alfa‑ceiling, floor, replace vagy bi‑level műveletek eltüntethetik a korábban létrehozott alfa‑részleteket. Építse fel a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig rendezetlen formázási jelzők halmazaként kezelje.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Ebben az illusztrációban az Aspose.Slides for .NET 26.11 renderje mutatja, hogy egy 220°‑os színárnyalat 25 %-on a szürkeárnyalatos képet változatlanul hagyja. Az ugyanaz a színárnyalat alkalmazása szürkeárnyalatos előtt más tónusokat eredményez.*
<!-- visual-explanation:image-transform-effects:end -->

## **A szerkeszthető és tényleges értékek ellenőrzése**

Egy szerkeszthető művelet az `ISlidesPicture.getImageTransform`‑ben tárolt objektum. A hatástól függően közvetlenül felülírható tagokat exponálhat. Például az [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) felülírható `radius` és `grow` értékeket, az [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) egy felülírható `amount`‑ot, az [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) pedig egy felülírható `threshold`‑ot. A [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) színhatások módosítható [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) objektumokat exponálnak.

Néhány művelet‑interfész, többek között az [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/) és [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/) nem exponálja a létrehozási skalárokat felülírható tulajdonságként. Ezeknek a beállításainak módosításához távolítsa el a műveletet, és a kívánt pozícióban adjon hozzá egy újat.

A `getEffective()`‑vel visszaadott tényleges adatok számítottak és csak‑olvasásra szántak. Hasznosak a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy további szerkesztési felületet jelentenek. Az alábbi példa felsorolja a láncot, és ahol az API lehetővé teszi, ellenőrzi a tényleges értékeket:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A paraméter‑nélküli hatások, mint a szürkeárnyalatos, alfa‑ceiling, vagy alfa‑inverse, szintén rendelkeznek tényleges‑adat objektummal, de nincs scalar beállításuk, amit ki lehetne nyomtatni. Jelenlétük és pozíciójuk a gyűjteményben a lényeges információ.

## **Kép‑átalakítások eltávolítása vagy törlése**

Használja az [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) metódust egy művelet index szerinti eltávolításához. Mivel az indexek az eltávolítás után eltolódnak, először keresse meg a célt, majd a felsorolás után távolítsa el. A [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) segítségével törölheti az egész láncot.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Az átalakítások eltávolítása vagy törlése csak a kép formázását változtatja meg. Nem törli, nem tömöríti újra, és nem módosítja a felhasznált [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) forrásforrást.

## **Prezentációs formátumok és exportcélok figyelembevétele**

A kép‑átalakítások a DrawingML‑ből származnak, ezért a PPTX a leginkább szerkeszthető formátum a hatákláncokhoz. Még PPTX‑ben sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML‑műveletek, mint a luminance, szürkeárnyalatos, duotone, színárnyalat, HSL, elmosás és a gyakori alfa‑műveletek, a legjobb eséllyel maradnak meg egy PPTX körúton. Mindig nyissa meg a létrehozott fájlt újra, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) egy Office 2010‑bővítmény, nem a szabványos DrawingML luminance művelet. Memóriában történő rendereléshez használható, de nem garantált, hogy szerkeszthető [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) marad a PPTX mentése és újra megnyitása után. A tartós fényerő‑ és kontraszt‑beállításokhoz részesítse előnyben az [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) használatát.
- A bináris PPT formátum a teljes DrawingML‑hatásképesség előtt létezett. PPT‑be mentés esetén a nem támogatott műveletek elhagyhatók, a lánc egy támogatott részhalmazra csökkenthető, vagy a megjelenés közelítőleg ábrázolható. Ne használja a PPT‑t ellenőrzési formátumként egy összetett szerkeszthető lánc esetén.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenetek a támogatott láncot alkalmazzák a renderelt megjelenésre. Ezek a kimenetek nem tartalmaznak szerkeszthető `IImageTransformOperationCollection`‑t; a raszteres formátumok az eredményt pixelekké lapítják, a dokumentum/vektor exportok a saját renderelési ábrázolásukat tárolják.
- A hatások nem teszik önállóvá a hivatkozott képet. Egy hivatkozott kép renderelése továbbra is a hivatkozott erőforrás elérhetőségétől függ, amikor a prezentáció betöltődik.

Különböző prezentációs fogyasztók eltérően renderelhetik a szélsőséges eseteket, különösen ha több alfa‑ vagy szín‑kvantálási műveletet kombinálnak. Kritikus kimenetek esetén tesztelje mind a szerkeszthető körutat, mind a végleges export formátumot ugyanazzal az Aspose.Slides verzióval, amelyet a termelésben használ.

## **GYIK**

**Módosítják a kép‑átalakítási hatások a beágyazott kép adatát?**

Nem. A műveletek a képtöltéshez használt `ISlidesPicture`‑hez tartoznak. Az alapul szolgáló `IPPImage`‑bájtok változatlanok maradnak.

**Két képkeret, amely ugyanazt a képet újrahasználja, megosztja a hatásokat?**

Nem. Az `IPPImage` újrahasználata elkerüli a képadatok duplikálását, de minden képkeret általában külön `ISlidesPicture`‑t és kép‑átalakítási gyűjteményt kap.

**Kombinálhatóak a szín, elmosás és alfa hatások?**

Igen. A gyűjtemény egy rendezett láncban fogadja őket. Fontolja meg, hogy az egyes műveletek hogyan befolyásolják az előző kimenetét, mivel a helyettesítő és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alfarészleteket.

**Miért csak‑olvasásúak a tényleges értékek?**

A tényleges adatok a rendereléshez használt számított értékeket képviselik, beleértve a feloldott színeket is. Szerkessze a transform‑gyűjteményben tárolt műveletet, ahol felülírható tagok léteznek; egyébként távolítsa el, és adjon hozzá egy újat a kívánt létrehozási paraméterekkel.

**Melyik formátumot használjam a hatáklánc megőrzéséhez?**

Használja a PPTX‑et, és ellenőrizze a fájlt az újbóli megnyitással. A régi PPT nem képes a teljes DrawingML‑hatásmodellt ábrázolni, a renderelt export formátumok pedig csak a megjelenést őrzik meg, nem a szerkeszthető átalakítási műveleteket.