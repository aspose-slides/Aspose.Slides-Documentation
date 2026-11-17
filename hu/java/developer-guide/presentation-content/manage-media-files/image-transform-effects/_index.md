---
title: Képtranszformációs hatások kezelése prezentációkban Java-val
linktitle: Képtranszformációs hatások
type: docs
weight: 11
url: /hu/java/image-transform-effects/
keywords:
- képtranszformáció
- képeffektus
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
- hatéklánc
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alkalmazza, láncolja, ellenőrizze, távolítsa el és ellenőrizze a képtranszformációs hatásokat képkockákhoz az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Aspose.Slides a képmódosításokat egy rendezett képtranszformációs műveletgyűjteményként ábrázolja. Képkockához kezdje a keret [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) objektumával, és érje el az [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--) metódust. A visszakapott [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) lehetővé teszi hatások hozzáfűzését, felsorolását, vizsgálatát, eltávolítását és törlését az eredeti képadatok újraírása nélkül.

Ez a cikk bemutat egy teljes munkafolyamatot a fényerő és kontraszt, színtranszformációk, elmosás, átlátszóság, rendezett effektláncok, hatékony értékek, eltávolítás és PPTX körkörös ellenőrzés kezelésére.

## **Megérteni az effektusok tulajdonjogát és a kép újrafelhasználását**

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) eltárolja vagy hivatkozik a prezentáció által birtokolt forráskép adataira.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) egy képkitöltéshez tartozik, hivatkozik egy képernyelő erőforrásra, miközben tárolja a képtranszformációs gyűjteményt.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) a dia alakzat, amely a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keret szintű formázást tartalmazza.

Ezért a képtranszformációs műveletek nem módosítják a [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) bájtjait. Ha ugyanaz az `IPPImage` több alkalommal kerül átadásra az [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) metódusnak, minden új képkocka saját `ISlidesPicture`-t és saját transzformációs gyűjteményt kap. A grayscale alkalmazása egy keretre nem teszi a többi keretet szürkeárnyalatosá, még ha mind ugyanazt a beágyazott kép erőforrást is újrahasználnak.

Ugyanez az `ISlidesPicture.getImageTransform` modell más képkitöltéseknél is használatos, például alakzat vagy dia háttér esetén. Az alábbi példák a képkockákra koncentrálnak.

## **Használjon érvényes paramétertartományokat és egységeket**

A bemutatott módszerek a következő szemantikai tartományokat és egységeket használják. Tartsa a értékeket ezekben a tartományokban akkor is, ha egy adott könyvtárverzió nem utasítja el azonnal a tartományon kívüli értékeket; a céldokumentum-formátum normalizálhatja, elhagyhatja vagy elutasíthatja a hibás adatokat mentéskor vagy amikor a PowerPoint megnyitja a fájlt.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` és `100` között, százalék; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Nincs numerikus paraméter. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Két szín a sötét és a világos pixelekhez. Az `java.awt.Color` RGB és alfa csatornái `0` és `255` között használhatók. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | A színárnyalat `0` (inkl.) és `360` (exkl.) fok között; az amount `-100` és `100` között, százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | A színárnyalat `0` (inkl.) és `360` (exkl.) fok között; a telítettség és a fényerő `-100` és `100` között, százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | A helyettesítő szín csatornaértékei `0` és `255` között vannak. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | A sugár nemnegatív, pontban mérve; a `grow` egy Boolean, amely szabályozza, hogy az elmosott tartalom kiterjedhet-e az eredeti határokon kívül. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nemnegatív százalék. Használjon `0` és `100` közötti értéket az általános átlátszatlanság skálázásához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` és `100` között, százalékos átlátszóság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` és `100` között, százalékos alfa küszöb. Az alatti értékek átlátszóvá válnak, a küszöbnél nagyobb vagy egyenlő értékek átlátszatlanok. |

Rögzített alfa moduláció esetén az átlátszóság és az átlátszatlanság komplementer egymásnak. Például a 35 % átlátszóság 65 % alfa modulációs értékkel ekvivalens.

## **Fényerő és kontraszt alkalmazása**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) egy [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) műveletet ad vissza. Skalár beállításait a művelet létrehozásakor adjuk meg. A [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) számított csak‑olvasásra szánt értékeket ad vissza, melyek ellenőrizhetők vagy naplózhatók.

A következő példa 15 % fényerővel és 20 % kontraszttal növeli ezeket, majd előnézetet renderel a beágyazott kép módosítása nélkül:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) egy Office 2010 képeffektus kiterjesztés, és kevésbé hordozható, mint a szabványos DrawingML luminancia effektus. Ha a fényerő és kontraszt PPTX körutazás után is szerkeszthető maradjon, használja az [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) metódust, és ellenőrizze az eredményt a fájl újranyitása után. A formátumkorlátozások szakasz részletesebben magyarázza ezt a különbséget.

## **Színtranszformációk alkalmazása**

A színhatások függetlenül alkalmazhatók különböző képkockákra, amelyek ugyanazt a kép erőforrást használják. A következő példa öt keretet hoz létre, és rájuk alkalmazza a grayscale, duotone, tint, HSL módosítást és a színcserét.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) két önállóan szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket térképezi. Ez hasznos példává teszi egy olyan effektust, amelynek beállításai bonyolultabbak egyetlen skalár értéknél.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) minden pixel színét egy fix színre cseréli, miközben megőrzi az alfat. Ez eltér a [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) módtól, amely egy forrás színt egy másikra térképez, és mind a forrás, mind a cél színformátumot láthatóvá teszi.

### **Luminancia küszöb alkalmazása**

A luminancia küszöb segíthet a beolvasott oldal gyenge jelzéseit a háttértől könnyebben elkülöníteni. Az [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) megőrzi a köztes szürkeárnyalatokat. Az [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) a luminanciát fekete vagy fehér színre térképezi, míg az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) átlátszóságra alkalmazza a küszöböt.

A luminancia küszöb 0 % és 100 % között (beleértve) terjed. A küszöbnél alacsonyabb pixelek feketék lesznek. A küszöbnél nagyobb vagy egyenlő pixelek fehérek lesznek. A küszöb emelése több árnyalatot tesz feketévé, mivel több esik a határ alá.

Töltse le a [grayscale-swatches.png](grayscale-swatches.png) fájlt a munkakönyvtárba. Minden címke az eredeti szürke szintet mutatja 0-tól 255-ig skálán. A példa az eredetit két másolat mellé helyezi, és minden másolat küszöbét elmenti a prezentációba.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Nyissa meg a kimeneti prezentációt a PowerPoint‑ban, hogy összehasonlítsa a három keretet. A 96 címkéjű mintadarab körülbelül 38 % luminanciával rendelkezik (96/255). 20 % küszöbön fehér, 60 % küszöbön fekete lesz.

![Eredeti szürkeárnyalatos minták a fekete-fehér eredményekkel a 20 % és 60 % luminancia küszöbök mellett](luminance-threshold.png)

## **Elmosás, átlátszóság és alfa hatások hozzáadása**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) minden színcsatornát, beleértve az alfat, érint. Állítsa a `grow` értékét `true`‑ra, ha az elmosott szél a képkép eredeti határain túl terjedhet.

Egyenletes átlátszósághoz használja a [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)‑t. Minden meglévő alfa értéket megszorozik, így a részben átlátszó pixelek arányosan különböznek. A [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ehelyett egyetlen alfa értéket ad minden pixelnek. Az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) egy küszöb alapján két szintre konvertálja az alfat.

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

A többi paraméter nélküli alfa művelet közé tartozik a [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) , amely minden nem nulla alfat teljesen átlátszatlanná teszi; a [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) , amely minden 100 % alatti alfat teljesen átlátszóvá alakítja; és a [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) , amely az alfat `100% - alpha` értékre módosítja.

## **Rendezett effektlánc felépítése**

Minden `add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezetéknek tekinti: az 0‑ás művelet kimenete lesz az 1‑es művelet bemenete, stb. Ennek következtében ugyanazok a műveletek más sorrendben más képet eredményezhetnek.

Például a grayscale, majd tint először eltávolítja a színinformációt, majd a luminancia eredményt újraszínezi. A tint, majd grayscale visszavonja a tintet. Hasonlóképpen, az alfa csere felülírhatja a korábbi műveletek által számított alfa értékeket, míg az alfa moduláció megőrzi azok relatív különbségét.

A következő példa egy négy műveletből álló láncot épít fel, PPTX‑ként elmenti, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és sorrendet, majd rendereli az újranyitott eredményt:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely a szín, alfa és elmosás műveleteket külön láncokra korlátozná. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy rögzített színcsere eltávolítja az előző színhatások által előállított RGB variációt; a duotone utáni grayscale eltávolítja a két kiválasztott színt; az alfa ceiling, floor, replacement vagy bi-level műveletek eldobhatják a korábban létrehozott alfa részleteket. Építse a láncot a kívánt képpont‑feldolgozási sorrend szerint, ne pedig rendezetlen formázási zászlóként kezelje az elemeket.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Szerkeszthető és hatékony értékek ellenőrzése**

Egy szerkeszthető művelet a `ISlidesPicture.getImageTransform`‑ben tárolt objektum. Az effektustól függően közvetlenül elérhetőek írható tagok. Például a [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) írható `radius` és `grow` értékeket nyújt, az [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) egy írható `amount`‑ot, és az [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) egy írható `threshold`‑ot. A színhatások, mint az [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) módosítható [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) objektumokat exponálnak.

Néhány művelet interfész, többek között a [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/) és [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/) nem teszi elérhetővé a létrehozáskor használt skalárokat írható tulajdonságként. Ezek beállításainak módosításához távolítsa el a műveletet, és a szükséges pozícióba adjon hozzá egy újat.

A `getEffective()` által visszaadott hatékony adatok számított, csak‑olvasásra szántak. Hasznosak a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy további szerkesztési felület. A következő példa felsorolja a láncot, és ellenőrzi a hatékony értékeket, ahol a megfelelő API biztosítja őket:

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

Paraméter nélküli hatások, mint a grayscale, alfa ceiling és alfa inverse is rendelkeznek hatékony adatobjektummal, de nincs kiírandó skalár beállítás. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja a [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-)‑t egy művelet index szerinti eltávolításához. Mivel az indexek a törlés után eltolódnak, előbb keresse meg a célt, majd a felsorolás után távolítsa el. Használja az [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--)‑t a teljes lánc eltávolításához.

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

A transzformációk eltávolítása vagy törlése csak a kép formázását változtatja. Nem törli, nem tömöríti újra, és egyébként nem módosítja az újrahasznált [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) erőforrást.

## **Fontolja meg a prezentáció formátumait és exportcéljait**

Az image transzformációk a DrawingML‑ből származnak, ezért a PPTX a preferált szerkeszthető formátum az effektusláncokhoz. Még PPTX‑nél sem minden művelet rendelkezik azonos hordozhatósággal:

- A standard DrawingML műveletek, mint a luminancia, grayscale, duotone, tint, HSL, blur és a közös alfa műveletek a legnagyobb eséllyel maradnak meg egy PPTX körutazás során. Mindig nyissa meg újra a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés kötelező.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) egy Office 2010 kiterjesztés, nem a szabványos DrawingML luminancia művelet. Memória‑szintű rendereléshez használható, de nem garantált, hogy szerkeszthető [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) marad a PPTX mentése és újranyitása után. Tartós fényerő‑kontraszt beállításokhoz válassza a [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)‑t.
- A bináris PPT formátum a teljes DrawingML effektus modell előtt létezett. PPT‑be mentés elhagyhat nem támogatott műveleteket, csökkentheti a láncot egy támogatott részre, vagy becsléssel állíthatja elő a megjelenést. Ne használja a PPT‑t verifikációs formátumnak összetett szerkeszthető lánc esetén.
- A PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenetek a támogatott láncot alkalmazzák a renderelt megjelenésre. Ezek a kimenetek nem tartalmaznak szerkeszthető `IImageTransformOperationCollection`‑t; a raszteres formátumok lapokra lapítják az eredményt, a dokumentum/vektor exportok saját renderelési reprezentációt tárolnak.
- Az effektusok nem teszik a hivatkozott képet önállóvá. A hivatkozott kép renderelése továbbra is függ a hivatkozott erőforrás elérhetőségétől a prezentáció betöltésekor.

## **GYIK**

**Módosítják a képtranszformációs hatások a beágyazott kép adatokat?**  
Nem. A műveletek a képkitöltés által használt `ISlidesPicture`‑hez tartoznak. Az alatta lévő `IPPImage` bájtok változatlanok maradnak.

**Két képkocka, amely ugyanazt a képet újrahasználja, megosztja-e a hatásokat?**  
Nem. Az `IPPImage` újrahasználata elkerüli a kép duplikációját, de minden képkocka általában külön `ISlidesPicture`‑t és képtranszformációs gyűjteményt kap.

**Kombinálhatók a szín, elmosás és alfa hatások?**  
Igen. A gyűjtemény egy rendezett láncban fogadja őket. Fontolja meg, hogy az egyes műveletek mit tesznek az előző kimenetével, mivel a csere‑ és küszöb műveletek eldobhatják a korábbi szín‑ vagy alfa részleteket.

**Miért csak‑olvasásúak a hatékony értékek?**  
A hatékony adatok a rendereléshez használt számított értékeket tartalmazzák, beleértve a feloldott színeket is. Szerkessze azt a műveletet, amely a transzformációs gyűjteményben tárolva van, ahol vannak írható tagok; egyébként távolítsa el, és adjon hozzá egy újat új létrehozási paraméterekkel.

**Melyik formátumot kell használnom a transzformációs lánc megőrzéséhez?**  
Használja a PPTX‑t, és ellenőrizze a fájlt újra megnyitva. A régi PPT nem képes a teljes DrawingML effektusmodellt ábrázolni, és a renderelt export formátumok csak a megjelenést őrzik meg, nem a szerkeszthető transzformációs műveleteket.