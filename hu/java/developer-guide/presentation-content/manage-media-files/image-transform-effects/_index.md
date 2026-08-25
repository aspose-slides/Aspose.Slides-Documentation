---
title: Képek transzformációs hatásainak kezelése prezentációkban Java-val
linktitle: Kép transzformációs hatások
type: docs
weight: 11
url: /hu/java/image-transform-effects/
keywords:
- képtranszformáció
- kép hatás
- fényerő
- kontraszt
- szürkeárnyalat
- duotone
- színárnyalat
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazza, láncolja, vizsgálja, távolítsa el és ellenőrizze a képek transzformációs hatásait a képkockákhoz az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides a képkorrekciókat a kép transzformációs műveletek rendezett gyűjteményeként ábrázolja. Képkockához kezdje a keret [ISlidesPicture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidespicture/) objektumával, és hívja meg a [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidespicture/#getImageTransform--) metódust. A visszakapott [IImageTransformOperationCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/) lehetővé teszi műveletek hozzáadását, felsorolását, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti kép bájtjait újraírná.

Ez a cikk egy teljes munkafolyamatot mutat be a fényerő‑kontraszt, színtranszformációk, elmosás, átlátszóság, rendezett hat láncok, effektív értékek, eltávolítás és PPTX körkörös ellenőrzés kezelésére.

## **A hatások tulajdonjogának és a képek újrafelhasználásának megértése**

Egy kép erőforrás és a azt megjelenítő kép különálló objektumok:

- [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forráskép adataira.
- [ISlidesPicture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidespicture/) egy képtöltéshez tartozik, és egy kép erőforrásra mutat, miközben a kép transzformációs gyűjteményt tárolja.
- [IPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipictureframe/) a dia alakja, amely a megfelelő képtöltést, geometriát, vágási beállításokat és egyéb keret‑szintű formázásokat birtokolja.

Ezért a kép transzformációs műveletek nem módosítják a [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) bájtjait. Ha ugyanazt az `IPPImage`‑t több alkalommal adjuk át a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódusnak, minden új képkocka saját `ISlidesPicture`‑t és saját transzformációs gyűjteményt kap. Az egyik keretre alkalmazott szürkeárnyalatos hatás nem teszi a többi keretet szürkeárnyalatosra, annak ellenére, hogy mindegyik ugyanazt a beágyazott kép erőforrást használja.

Ugyanezt a `ISlidesPicture.getImageTransform` modellt használják más képtöltések is, például alakzat vagy dia háttér. Az alábbi példák a képkockákra összpontosítanak.

## **Érvényes paraméter‑tartományok és egységek használata**

A bemutatott metódusok a következő szemantikai tartományokat és egységeket használják. Tartsa a paramétereket ebben a tartományban, még ha egy adott könyvtárverzió nem is utasítja el azonnal a határon kívüli értékeket; a célprezentáció formátuma normalizálhat, elhagyhat vagy elutasíthat érvénytelen adatokat mentéskor vagy a PowerPoint megnyitásakor.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100`‑tól `100`‑ig, százalék; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Nincs | Nincsenek numerikus paraméterek. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Két szín a sötét és világos pixelekhez. A `java.awt.Color` RGB és alfa csatornái `0`‑tól `255`‑ig terjednek. |
| [addTintEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | A színárnyalat `0` (inkl.)‑tól `360` (exkl.)‑ig fokban; az érték `-100`‑tól `100`‑ig százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | A színárnyalat `0`‑tól `360`‑ig fokban; a telítettség és fényerő `-100`‑tól `100`‑ig százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig. Az eredeti alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | A sugár nemnegatív és pontban mérve; a `grow` logikai érték meghatározza, hogy az elmosott tartalom kiterjedhet‑e az eredeti határokon kívülre. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nemnegatív százalék. Használja a `0`‑tól `100`‑ig terjedő tartományt az általános átlátszatlanság skálázásához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszatlanság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél nagyobb vagy egyenlő értékek opakévá. |

A fix alfa moduláció esetén a transzparencia és az átlátszatlanság kiegészítik egymást. Például a 35 % transzparencia az alfa moduláció 65 % értékének felel meg.

## **Fényerő és kontraszt alkalmazása**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) egy [IBrightnessContrast](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibrightnesscontrast/) műveletet ad vissza. Skáláris beállításait a művelet létrehozásakor adjuk meg. Az [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) csak olvasható, kiszámított értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 % fényerőt és 20 % kontrasztot ad hozzá, majd előnézetet jelenít meg anélkül, hogy módosítaná a beágyazott képet:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

A [BrightnessContrast](https://reference.aspose.com/slides/hu/java/com.aspose.slides/brightnesscontrast/) egy Office 2010 képhatás‑kiterjesztés, és kevésbé hordozható, mint a szabványos DrawingML luminancia hatás. Ha a fényerő és kontraszt PPTX körúton történő szerkeszthető maradása szükséges, használja a [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) metódust, és ellenőrizze az eredményt a fájl újranyitása után. A formátumkorlátozások része részletesebben kifejti ezt a különbséget.

## **Színtranszformációk alkalmazása**

A színhatásokat függetlenül lehet alkalmazni különböző képkockákra, amelyek ugyanazt a kép erőforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, színárnyalat (tint), HSL‑korrekció és színcserét alkalmaz.

[IDuotone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iduotone/) két önállóan szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket képezi. Ez ezért jó példát nyújt egy összetettebb beállításokkal rendelkező hatásra.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az [addColorReplaceEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) minden pixel színét egy fix színre cseréli, miközben megőrzi az alfat. Ez eltér az [addColorChangeEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)‑tól, amely egy forrás‑színt egy másikra mapolja, és mind a forrás, mind a cél színformátumát elérhetővé teszi.

## **Elmosás, átlátszóság és alfa hatások hozzáadása**

[addBlurEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) az összes színcsatornát, beleértve az alfat, érinti. Állítsa a `grow`‑t `true`‑ra, ha az elmosott szél meghaladhatja az eredeti kép határait.

Egységes átlátszósághoz használja a [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)‑t. Ez minden meglévő alfa értéket szorz, így a részben átlátszó pixelek arányosan különböznek. Az [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ezzel szemben egyetlen alfa értéket rendel minden pixelhez. Az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) egy küszöb alapján két szintre konvertálja az alfat.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Más, paraméter‑szabad alfa műveletek: az [addAlphaCeilingEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) minden nemnulla alfat teljesen átlátszatlanná teszi; az [addAlphaFloorEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) minden 100 % alatti alfat teljesen átlátszóvá alakítja; valamint az [addAlphaInverseEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) átalakítja az alfat `100% - alfa` értékre.

## **Rendezett hatlánc felépítése**

Minden `add...Effect` metódus új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezeték‑ként használja: az 0‑ás művelet kimenete az 1‑es művelet bemenete, stb. Ennek következtében ugyanazok a műveletek más sorrendben más képet eredményezhetnek.

Például a szürkeárnyalatos hatás, majd a tint eltávolítja a színinformációt, majd újraszínezi a fényerőt. A tint, majd a szürkeárnyalatos hatás visszavonja a tintet. Hasonlóan, az alfa‑helyettesítés felülírhatja a korábban számított alfa értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként ment, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és azok sorrendjét, majd a visszaolvasott eredményt megjeleníti:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely szín‑, alfa‑ és elmosás műveleteket külön láncokra korlátozna. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy fix színcserével eltűnik a korábbi színhatások által előállított RGB‑variáció; a duotone után alkalmazott szürkeárnyalat eltávolítja a kiválasztott két színt; továbbá az alfa‑ceil, floor, replace vagy bi‑level műveletek elvehetik a korábban létrehozott alfa‑részleteket. Építse a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig rendezetlen formázás‑jelzőként kezelje.

## **Szerkeszthető és effektív értékek vizsgálata**

A szerkeszthető művelet az objektum, amely az `ISlidesPicture.getImageTransform`‑ban van tárolva. A hatástól függően közvetlenül elérhetőek a módosítható tagok. Például az [IBlur](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iblur/) exponálja a `radius` és `grow` értékeket, az [IAlphaModulateFixed](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ialphamodulatefixed/) a `amount`‑ot, az [IAlphaBiLevel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ialphabilevel/) a `threshold`‑ot. A színhatások, például az [IDuotone](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iduotone/), mutatnak módosítható [IColorFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icolorformat/) objektumokat.

Néhány műveleti interfész, köztük az [IBrightnessContrast](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itint/) és [IAlphaReplace](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ialphareplace/), nem exponálja a létrehozási skalárokat írható tulajdonságként. Ezeknek a beállításainak módosításához távolítsa el a műveletet, és adjon hozzá egy újat a kívánt pozícióban.

A `getEffective()` által visszaadott effektív adatok számítottak és csak‑olvasásra alkalmasak. Hasznosak a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem jelentik a szerkeszthető felületet. Az alábbi példa felsorolja a láncot, és megvizsgálja az effektív értékeket, ahol az API biztosítja őket:

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

A paraméter‑szabad hatások, mint a szürkeárnyalat, alfa‑ceil vagy alfa‑inverse, szintén rendelkeznek effektív‑adat objektummal, de nincs kiírandó skalár beállítás. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja az [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) metódust egy művelet index szerinti eltávolításához. Mivel az indexek a törlés után eltolódnak, előbb keresse meg a célt, majd a felsorolás után távolítsa el. Az [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imagetransformoperationcollection/#clear--) minden láncot eltávolít a gyűjteményből.

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

A transzformációk eltávolítása vagy törlése csak a kép formázását módosítja. Nem törli, nem tömöríti újra, és nem változtatja meg a újrahasznosított [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) erőforrást.

## **Prezentációs formátumok és exportcélok figyelembe vétele**

A képtranszformációk a DrawingML‑ből származnak, ezért a PPTX a legmegfelelőbb szerkeszthető formátum a hatláncokhoz. Még PPTX‑ben sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminancia, szürkeárnyalat, duotone, tint, HSL, elmosás és gyakori alfa‑műveletek a legnagyobb eséllyel maradnak meg egy PPTX körúton. Mindig nyissa meg újra a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A [BrightnessContrast](https://reference.aspose.com/slides/hu/java/com.aspose.slides/brightnesscontrast/) egy Office 2010‑kiterjesztés, nem a szabványos DrawingML luminancia művelet. Memóriabeli rendereléshez használható, de nem garantált, hogy mentés és újbóli megnyitás után szerkeszthető [IBrightnessContrast](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibrightnesscontrast/) marad. Inkább használja a [addLuminanceEffect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)‑t a tartós fényerő‑kontraszt beállításokhoz.
- A bináris PPT formátum a teljes DrawingML hatmodell előtt létezett. PPT‑be mentéskor a nem támogatott műveletek elhagyhatók, a lánc egy támogatott részhalmazra csökkenthető, vagy az eredmény csak becslés lehet. Ne használja PPT‑t ellenőrző formátumként egy összetett szerkeszthető lánchoz.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenetek renderelése a támogatott láncot alkalmazza a megjelenéshez. Ezek a kimenetek nem tartalmaznak szerkeszthető `IImageTransformOperationCollection`‑t; a raszter formátumok a képet pixelekké lapítják, a dokumentum/vektorgenerátorok saját renderelési reprezentációt tárolják.
- A hatások nem teszik önállóvá a linkelt képet. A linkelt kép renderelése továbbra is a linkelt erőforrás rendelkezésre állásától függ a prezentáció betöltésekor.

Különböző prezentáció‑fogyasztók eltérően kezelhetik a szélsőséges eseteket, különösen ha több alfa‑ vagy szín‑kvantálási művelet kombinálódik. Kritikus kimenetek esetén tesztelje mind a szerkeszthető körutat, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amit a termelésben használ.

## **GYIK**

**Módosítják a képtranszformációs hatások a beágyazott kép adatokat?**

Nem. A műveletek az `ISlidesPicture`‑hez tartoznak, amelyet a képtöltés használ. Az alap‑`IPPImage` bájtjai változatlanok maradnak.

**Két képkocka, amely ugyanazt a képet használja, megosztja a hatásokat?**

Nem. Az `IPPImage` újrahasznosítása elkerüli a kép adat duplikációját, de minden képkocka külön `ISlidesPicture`‑t és külön kép‑transzformációs gyűjteményt kap.

**Kombinálhatók a szín, elmosás és alfa hatások?**

Igen. A gyűjtemény egyetlen rendezett láncban fogadja őket. Fontolja meg, hogy az egyes műveletek hogyan befolyásolják az előző művelet kimenetét, mivel a helyettesítő és küszöb műveletek elvehetik a korábbi szín‑ vagy alfárészleteket.

**Miért csak‑olvasásúak az effektív értékek?**

Az effektív adatok a rendereléshez használt számított értékeket képviselik, beleértve a feloldott színeket. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol módosítható tagok vannak; ellenkező esetben távolítsa el, és adjon hozzá egy újat a kívánt létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megőrzéséhez?**

Használja a PPTX‑et, és ellenőrizze a fájlt újbóli megnyitással. A régi PPT nem tudja teljesen ábrázolni a DrawingML hatmodelljét, a renderelt export formátumok pedig csak a megjelenést, nem a szerkeszthető transzformációkat őrzik meg.