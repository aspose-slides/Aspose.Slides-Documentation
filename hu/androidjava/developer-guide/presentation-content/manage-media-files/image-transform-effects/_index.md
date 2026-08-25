---
title: Képtovábbítási hatások kezelése prezentációkban Androidon
linktitle: Képtovábbítási hatások
type: docs
weight: 11
url: /hu/androidjava/image-transform-effects/
keywords:
- képtovábbítás
- képhatás
- fényerő
- kontraszt
- szürkeárnyalatos
- duotone
- színtónus
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alkalmazza, láncolja, vizsgálja, távolítsa el és ellenőrizze a képtovábbítási hatásokat képkockákhoz az Aspose.Slides for Android Java használatával."
---
## **Áttekintés**

Az Aspose.Slides a képmódosításokat egy rendezett képtovábbítási műveletgyűjteményként ábrázolja. Képkockához kezdje a keret [ISlidesPicture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidespicture/) elérésével, majd hívja meg a [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) metódust. A visszakapott [IImageTransformOperationCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/) lehetővé teszi a hatások hozzáadását, felsorolását, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti kép bájtjait újraírná.

Ez a cikk bemutat egy teljes munkafolyamatot a fényerő és kontraszt, színtranszformációk, elmosás, átlátszóság, rendezett hatásláncok, hatékony értékek, eltávolítás és PPTX körkörös ellenőrzés használatára.

## **Értsük meg a hatás tulajdonjogát és a kép újrafelhasználását**

Egy képernyöforrás és a megjelenítő kép különböző objektumok:

- [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) tárolja vagy hivatkozik a bemutató által birtokolt forráskép adataira.
- [ISlidesPicture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidespicture/) egy képtöltéshez tartozik, és egy képernyöforrásra hivatkozik, miközben a képtovábbítási gyűjteményt tárolja.
- [IPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipictureframe/) a dián lévő alakzat, amely a megfelelő képtöltést, geometriát, vágási beállításokat és egyéb keretszintű formázást birtokolja.

Ezért a képtovábbítási műveletek nem módosítják a [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) bájtjait. Ha ugyanazt az `IPPImage`-t több alkalommal adjuk át a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódusnak, minden új képkocka saját `ISlidesPicture`-et és saját transzformációs gyűjteményt kap. A szürkeárnyalatos átalakítás egy keretre nem teszi a többi keretet szürkeárnyalatosra, még akkor sem, ha mindegyik ugyanazt a beágyazott képernyöforrást használja.

Ugyanezt a `ISlidesPicture.getImageTransform` modellt más képtöltések is használják, például alakzat vagy dia háttér. Az alábbi példák a képkockákra fókuszálnak.

## **Érvényes paramétertartományok és egységek használata**

A bemutatott módszerek a következő szemantikai tartományokat és egységeket használják. Tartsa a értékeket ezekben a tartományokban, még akkor sem, ha egy adott könyvtárverzió nem utasítja el azonnal a határon kívüli értékeket; a céldokumentum formátuma normalizálhat, elhagyhat vagy elutasíthat érvénytelen adatokat mentéskor vagy amikor a PowerPoint megnyitja a fájlt.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100`‑tól `100`‑ig, százalék; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Nincs | Nincsenek numerikus paraméterek. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Két szín a sötét és világos pixelekhez. Az `android.graphics.Color` által használt RGB és alfa csatorna értékek `0`‑tól `255`‑ig terjednek. |
| [addTintEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | A színárnyalat `0`‑tól `360`‑ig (kizáró) fok, a mennyiség `-100`‑tól `100`‑ig, százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | A színárnyalat `0`‑tól `360`‑ig (kizáró) fok; a telítettség és világosság `-100`‑tól `100`‑ig, százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | A csere szín csatornaértékei `0`‑tól `255`‑ig. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | A sugár nemnegatív és pontban mérve; a `grow` egy Boolean, amely meghatározza, hogy a elmosott tartalom kilóghat-e az eredeti határokon kívülre. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nemnegatív százalék. Használja a `0`‑tól `100`‑ig tartományt a szokásos átlátszatlanság skálázásához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfát. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszatlanság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél vagy fölötte lévők átlátszatlanok. |

Rögzített alfa moduláció esetén az átlátszóság és az átlátszatlanság kiegészítőek. Például a 35 % átlátszóság egy 65 % alfa modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) egy [IBrightnessContrast](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibrightnesscontrast/) műveletet ad vissza. Skalár beállításait a művelet létrehozásakor adjuk meg. Az [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) számított csak‑olvasásra szánt értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 % fényerőt és 20 % kontrasztot ad hozzá, majd előnézetet jelenít meg anélkül, hogy módosítaná a beágyazott képet:

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

A [BrightnessContrast](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/brightnesscontrast/) egy Office 2010 képhatás‑kiterjesztés, és kevésbé hordozható, mint a szabványos DrawingML fényerő hatás. Ha a fényerő és kontraszt szerkeszthető maradjon egy PPTX körutazás után, használja a [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) metódust, és ellenőrizze az eredményt a fájl újranyitása után. A formátumkorlátozások szakaszban részletesebben ismertetjük ezt a különbséget.

## **Színtranszformációk alkalmazása**

A színhatások függetlenül alkalmazhatók különböző képkockákra, amelyek ugyanazt a képernyöforrást használják. Az alábbi példa öt keretet hoz létre, és alkalmaz rájuk szürkeárnyalatos, duotone, színtónus, HSL módosítást és színcserét.

[IDuotone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iduotone/) két függetlenül szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` pedig a világos pixeleket jelöli. Ez egy hasznos példa olyan hatásra, amelynek beállításai összetettebbek, mint egyetlen skalárérték.

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

Az [addColorReplaceEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) minden pixel színét egy fix színre cseréli, miközben megőrzi az alfát. Ez eltér a [addColorChangeEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) módszertől, amely egy forrás színt egy másikra képezi át, és mind a forrás, mind a cél színformátumát felfedi.

## **Elmosás, átlátszóság és alfa hatások hozzáadása**

[addBlurEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) minden színcsatornára, beleértve az alfát is, hat. Állítsa a `grow` értékét `true`‑ra, ha az elmosott él túlnyúlhat az eredeti kép határain.

Az egységes átlátszósághoz használja a [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) metódust. Ez minden meglévő alfa értéket megszoroz, így a részben átlátszó pixelek arányosan különböznek. Az [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ehelyett egyetlen alfa értéket ad minden pixelnek. Az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) az alfát egy küszöb alapján két szintre konvertálja.

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

Más paraméter‑mentes alfa műveletek közé tartozik az [addAlphaCeilingEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) (minden nemnulla alfát teljesen átlátszatlanná tesz), az [addAlphaFloorEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) (minden 100 % alatti alfát teljesen átlátszóvá tesz) és az [addAlphaInverseEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) (az alfa értékét `100% - alfa`-ra változtatja).

## **Rendezett hatáslánc felépítése**

Minden `add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezetékként használja: a 0‑számú művelet kimenete lesz az 1‑es bemenete, és így tovább. Ennek következtében a műveletek más sorrendben történő alkalmazása más képet eredményezhet.

Például a szürkeárnyalatos, majd színtónus először eltávolítja a kromatikus információt, majd újraszínezi a világosságot. A színtónus után szürkeárnyalatos újra eltávolítja a színtónust. Hasonlóképpen, az alfa csere felülírhatja a korábbi műveletek által számított alfa értékeket, míg az alfa moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újból megnyitja a bemutatót, ellenőrzi mind a művelettípusokat, mind a sorrendet, és megjeleníti a megnyitott eredményt:

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

A gyűjtemény nem támaszt olyan kompatibilitási mátrixot, amely a szín, alfa és elmosás műveleteket külön láncokra korlátozná. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy rögzített színcsere eltávolítja az előző színhatások által létrehozott RGB variációt; a szürkeárnyalatos duotone után eltávolítja a két kiválasztott színt; az alfa ceiling, floor, replacement vagy bi‑level műveletek az előzőleg létrehozott alfa részleteket eldobhatják. Építse fel a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig rendezetlen formázási jelzőként tekintsen rá.

## **Szerkeszthető és hatékony értékek ellenőrzése**

Egy szerkeszthető művelet az az objektum, amely a `ISlidesPicture.getImageTransform`‑ben tárolódik. A hatástól függően közvetlenül elérhetőek lehetnek írható tagok. Például az [IBlur](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iblur/) írható `radius` és `grow` értékeket mutat, az [IAlphaModulateFixed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ialphamodulatefixed/) írható `amount`‑ot, az [IAlphaBiLevel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ialphabilevel/) írható `threshold`‑ot. A színhatások, mint az [IDuotone](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iduotone/), módosítható [IColorFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icolorformat/) objektumokat jelenítenek meg.

Néhány művelet‑interfész, köztük az [IBrightnessContrast](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itint/) és [IAlphaReplace](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ialphareplace/), nem teszi írhatóvá a létrehozáskor megadott skalárokat. Ezek beállításainak módosításához távolítsa el a műveletet, és adjon hozzá egy újat a kívánt pozícióban.

A `getEffective()` által visszaadott hatékony adat számított és csak‑olvasásra szánt. Hasznos a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy másik szerkesztési felület. Az alábbi példa felsorolja a láncot, és ellenőrzi a hatékony értékeket, ahol a megfelelő API biztosítja őket:

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

Paraméter‑mentes hatások, mint a szürkeárnyalatos, alfa ceiling vagy alfa inverse, továbbra is rendelkeznek hatékony‑adat objektummal, de nincs kiírandó skalár beállításuk. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képtovábbítások eltávolítása vagy törlése**

Használja az [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) metódust egy művelet index szerinti eltávolításához. Mivel az indexek az eltávolítás után elcsúsznak, először keresse meg a célt, majd a felsorolás után távolítsa el. Használja az [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) metódust a teljes lánc eltávolításához.

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

A transzformációk eltávolítása vagy törlése csak a kép formázását változtatja meg. Nem törli, nem tömöríti újra, és nem módosítja a újrahasznosított [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) erőforrást.

## **A bemutatóformátumok és exportcélok figyelembevétele**

A képtovábbítások a DrawingML‑ből származnak, ezért a PPTX az előnyben részesített szerkeszthető formátum a hatásláncokhoz. Még PPTX‑ben sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminance, szürkeárnyalatos, duotone, színtónus, HSL, elmosás és a gyakori alfa műveletek, a legnagyobb eséllyel maradnak meg egy PPTX körutazás után. Mindig nyissa meg újra a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A [BrightnessContrast](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/brightnesscontrast/) egy Office 2010 kiterjesztés, nem a szabványos DrawingML luminance művelet. Memóriabeli renderelésre használható, de nem garantált, hogy szerkeszthető [IBrightnessContrast](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibrightnesscontrast/) marad a PPTX mentése és újranyitása után. Használja az [addLuminanceEffect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)‑t a tartós fényerő‑ és kontraszt‑állításokhoz.
- A bináris PPT formátum a teljes DrawingML hatásmodell előtt létezett. PPT‑be mentés elhagyhat nem támogatott műveleteket, csökkentheti a láncot egy támogatott részhalmazra, vagy közelítheti a megjelenést. Ne használja a PPT‑t ellenőrző formátumként egy összetett szerkeszthető lánchoz.
- A PNG, JPEG, TIFF, PDF, SVG, HTML vagy egyéb vizuális kimenetek a támogatott láncot alkalmazzák a megjelenített eredményre. Ezek a kimenetek nem tartalmaznak szerkeszthető `IImageTransformOperationCollection`‑t; a raszteres formátumok a végeredményt pixelekre lapítják, a dokumentum/vector exportok pedig saját renderelési reprezentációt tárolnak.
- A hatások nem teszik önállóvá a hivatkozott képet. Egy hivatkozott kép renderelése továbbra is a hivatkozott erőforrás elérhetőségétől függ, amikor a bemutatót betöltik.

Különböző bemutató‑fogyasztók eltérően jeleníthetik meg a szélsőséges eseteket, különösen ha több alfa vagy szín‑kvantálás művelet kombinálódik. Kritikus kimenetek esetén tesztelje mind a szerkeszthető körutazást, mind a végső exportformátumot ugyanazzal az Aspose.Slides verzióval, amelyet a termelésben használ.

## **GYIK**

**Módosítják a képtovábbítási hatások a beágyazott kép adatokat?**

Nem. A műveletek az `ISlidesPicture`‑hez tartoznak, amelyet a képtöltés használ. Az alapul szolgáló `IPPImage` bájtjai változatlanok maradnak.

**Két képkocka, amely ugyanazt a képet használja, megosztja a hatásokat?**

Nem. Az `IPPImage` újrafelhasználása elkerüli a képadatok duplikálását, de minden képkocka általában saját `ISlidesPicture`‑et és képtovábbítási gyűjteményt kap.

**Kombinálhatók a szín-, elmosás- és alfa‑hatások?**

Igen. A gyűjtemény egy rendezett láncban fogadja őket. Vegye figyelembe, hogy az egyes műveletek hogyan hatnak az előző kimenetére, mivel a csere‑ és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak‑olvasásúak a hatékony értékek?**

A hatékony adatok a rendereléshez használt számított értékeket tartalmazzák, beleértve a feloldott színeket. Szerkessze azt a műveletet, amely a transzformációs gyűjteményben van, ahol vannak írható tagok; egyébként távolítsa el, és adjon hozzá egy újat az új létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megőrzéséhez?**

Használja a PPTX‑et, és ellenőrizze a fájlt az újbóli megnyitással. A régi PPT nem képes a teljes DrawingML hatásmodellt ábrázolni, míen a renderelt exportformátumok csak a megjelenést őrzik meg, nem pedig a szerkeszthető transzformációs műveleteket.