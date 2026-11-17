---
title: Képtranszformációs hatások kezelése prezentációkban Python segítségével
linktitle: Képtranszformációs hatások
type: docs
weight: 11
url: /hu/python-java/image-transform-effects/
keywords:
- képtranszformáció
- kép hatás
- fényerő
- kontraszt
- szürkeárnyalatos
- duotone
- árnyalat
- HSL
- színcsere
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazza, láncolja, vizsgálja, távolítsa el és ellenőrizze a képtranszformációs hatásokat a képkeretekhez az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides a képi beállításokat képsortranszformációs műveletek rendezett gyűjteményeként ábrázolja. Egy képkockához kezdje a képkocka [Kép](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) elemével, majd férjen hozzá a [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform) metódushoz. A visszaadott [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) lehetővé teszi hatások hozzáadását, felsorolását, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti kép bájtjait újraírná.

Ez a cikk bemutat egy teljes munkafolyamatot a fényerő és kontraszt, színátalakítások, elmosás, átlátszóság, rendezett hatámláncok, hatékony értékek, eltávolítás és PPTX körkörös ellenőrzés kezelésére.

## **Értsd meg a hatás tulajdonjogát és a kép újrafelhasználását**

A kép erőforrás és a megjelenítő kép különálló objektumok:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forráskép adataira.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) egy képkitöltéshez tartozik, és egy képer erőforrásra hivatkozik, miközben tárolja a képtranszformációs gyűjteményt.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) a diavetítés alakja, amely birtokolja a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keretszintű formázásokat.

Ezért a képtranszformációs műveletek nem módosítják a [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) bájtjait. Ha ugyanazt a `PPImage`-t többször adjuk át a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) metódusnak, minden új képkeret saját `Picture`-t és saját transzformációs gyűjteményt kap. A szürkeárnyalatos átalakítás egy keretre nem teszi a többi keretet is szürkeárnyalatosra, még ha mindegyik ugyanazt a beágyazott képer erőforrást is újrahasználja.

Ugyanazt a `Picture.getImageTransform` modellt más képkitöltések is használják, például alakzat vagy dia háttér esetén. Az alábbi példák a képkeretekre koncentrálnak.

## **Használj érvényes paramétertartományokat és egységeket**

A bemutatott módszerek a következő szemantikai tartományokat és egységeket használják. Tartsd meg az értékeket ezekben a tartományokban, még ha egy adott könyvtárverzió nem is utasít el azonnal minden tartományon kívüli értéket; a céldokumentum formátuma normalizálhat, kihagyhat vagy elutasíthat érvénytelen adatokat mentéskor vagy amikor a PowerPoint megnyitja a fájlt.

| **Művelet** | **Paraméterek** | **Érvényes tartomány és egység** |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` és `100` között, százalékban; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | Nincs numerikus paraméter. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Két szín a sötét és világos pixelekhez. Az `java.awt.Color` RGB és alfa csatornái `0` és `255` között vannak. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Az árnyalat `0`-tól (inkl.) `360`-ig (exkl.), fokban; az mennyiség `-100` és `100` között, százalékban. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Az árnyalat `0`-tól (inkl.) `360`-ig (exkl.), fokban; a telítettség és a fényesség `-100` és `100` között, százalékban. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | A helyettesítő szín csatornaértékei `0` és `255` között vannak. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | A sugár nemnegatív és pontban mérve; a `grow` egy logikai érték, amely azt szabályozza, hogy az elmosott tartalom kiterjeszthető-e az eredeti határokon kívülre. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Nemnegatív százalék. Használd a `0`-tól `100`-ig terjedőt a szokásos átlátszatlanság skálázáshoz: `0` teljesen átlátszó, `100` megőrzi a meglévő alfa értéket. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` és `100` között, százalékos átlátszatlanság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` és `100` között, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél nagyobb vagy egyenlő értékek átlátszatlanná. |

Rögzített alfa moduláció esetén az átlátszóság és az átlátszatlanság egymást kiegészítik. Például a 35 % átlátszóság egy 65 % alfa modulációs mennyiségnek felel meg.

## **Fényerő és kontraszt alkalmazása**

Az [ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) egy [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) műveletet ad vissza. A skalár beállításai a művelet létrehozásakor kerülnek megadásra. A [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) kiszámított, csak olvasható értékeket ad vissza, amelyeket meg lehet vizsgálni vagy naplózni.

Az alábbi példa 15 % -kal növeli a fényerőt és 20 % -kal a kontrasztot, majd előnézetet jelenít meg anélkül, hogy a beágyazott képet módosítaná:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) egy Office 2010 képhasználati hatásbővítmény, és kevésbé hordozható, mint a szabványos DrawingML fényerő hatás. Ha a fényerő és a kontraszt PPTX körkörös után is szerkeszthetőnek kell maradnia, használja a [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) metódust, és ellenőrizze az eredményt a fájl újra megnyitása után. A formátumkorlátozások szakasz részletesebben kifejti ezt a különbséget.

## **Színátalakítások alkalmazása**

Színhatásokat függetlenül lehet alkalmazni különböző képkeretekre, amelyek ugyanazt a képforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, színezés, HSL beállítás és színcserét alkalmaz.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) két egymástól függetlenül szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket térképezi. Ez hasznos példává teszi azt a hatást, amelynek beállításai bonyolultabbak, mint egy egyszerű skalár érték.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) minden pixel színét egy rögzített színre cseréli, miközben megőrzi az alfat. Ez eltér a [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) művelettől, amely egy forrás színt egy másikra térképezi, és mind a forrás, mind a cél színformátumot elérhetővé teszi.

### **Fényerő küszöb alkalmazása**

Egy fényerő küszöb segíthet a gyengén látható jelek megkülönböztetésében a szkennelt oldalon a háttértől. 

[addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) megőrzi a köztes szürke árnyalatokat. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) a fényerőt feketére vagy fehérre térképezi, míg a [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) egy küszöböt alkalmaz az átlátszatlanságra.

A fényerő küszöb 0 % és 100 % között terjed, mindkét értéket beleértve. A küszöbnél alacsonyabb pixelek feketék lesznek. A küszöbnél nagyobb vagy egyenlő pixelek fehérek lesznek. A küszöb növelése több árnyalatot feketére változtat, mivel több pixel esik a vágási pont alá.

Töltse le a [grayscale-swatches.png](grayscale-swatches.png) fájlt a munkakönyvtárba. Minden címke az eredeti szürke szintet mutatja 0–255 skálán. A példa az eredetit két másolat mellé helyezi, és minden másolat küszöbét a prezentációba menti.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nyissa meg a kimeneti prezentációt a PowerPointban, hogy összehasonlítsa a három keretet. A 96 felirattal ellátott mintának körülbelül 38 % fényerője van (96 a 255‑ből). A 20 % küszöbnél fehér, a 60 % küszöbnél fekete lesz.

![Eredeti szürkeárnyalatos minták a fekete‑fehér eredmények mellett 20 % és 60 % fényerő küszöbök esetén](luminance-threshold.png)

## **Elmosás, átlátszóság és alfa hatások hozzáadása**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) minden színcsatornát, beleértve az alfat is, érint. Állítsa a `grow` értékét `True`-ra, ha az elmosott él kiterjedhet az eredeti kép határain túlra.

Egyenletes átlátszóság esetén használja a [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) metódust. Minden meglévő alfa értéket megszorozza, így a részlegesen átlátszó pixelek arányosan különböznek. A [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) ehelyett egyetlen alfa értéket rendel minden pixelhez. A [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) egy küszöb alapján két szintre konvertálja az alfat.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Más, paraméter nélküli alfa műveletek közé tartozik a [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), amely minden nem nulla alfat teljesen átlátszatlanná teszi; a [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), amely minden 100 % alatti alfat teljesen átlátszóvá alakít; valamint a [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), amely az alfat `100% - alpha` értékre módosítja.

## **Rendezett hatámlánc felépítése**

Minden `add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezetéknek tekinti: az 0‑ás művelet kimenete lesz az 1‑es művelet bemenete, és így tovább. Ennek következtében ugyanazok a műveletek más sorrendben különböző képet eredményezhetnek.

Például a szürkeárnyalatos hatás tint után történő alkalmazása először eltávolítja a színinformációt, majd átszínezi a fényerő eredményt. A tint után következő szürkeárnyalatos visszaállítja a tintet. Hasonlóan, az alfa helyettesítés felülírhatja a korábbi műveletek által számított alfa értékeket, míg az alfa moduláció megőrzi azok relatív különbségét.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX formátumban menti, majd újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és azok sorrendjét, és megjeleníti az újból megnyitott eredményt:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

A gyűjtemény nem alkalmaz kompatibilitási mátrixot, amely szín-, alfa- és elmosási műveleteket külön láncokra korlátozna. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy rögzített színcsere eltávolítja az előző színhatások által létrehozott RGB-variációkat; a duotone után alkalmazott szürkeárnyalatos eltávolítja a két kiválasztott színt; valamint az alfa ceiling, floor, replacement vagy bi-level műveletek eldobhatják a korábban létrehozott alfa részleteket. Építse fel a láncot a kívánt pixel-feldolgozási sorrend szerint, ahelyett, hogy elemeit rendezetlen formázási jelzőknek tekintené.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Szerkeszthető és hatékony értékek vizsgálata**

Egy szerkeszthető művelet a `Picture.getImageTransform` tárolja. A hatástól függően közvetlenül elérhetővé teheti az írásra alkalmas tagokat. Például a [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) a szerkeszthető `radius` és `grow` értékeket mutatja, az [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) a szerkeszthető `amount` mezőt, az [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) a szerkeszthető `threshold` mezőt. A színhatások, mint a [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/), módosítható [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) objektumokat tesznek elérhetővé.

Néhány művelet osztály, köztük a [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/) és [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), nem teszék elérhetővé a létrehozásuk során megadott skalárokat szerkeszthető tulajdonságként. Ezeknek a beállításoknak a módosításához távolítsa el a műveletet, és a kívánt helyen adjon hozzá egy helyettesítőt.

A `getEffective` által visszaadott hatékony adatok számított és csak olvasható értékek. Hasznosak a témafüggő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy további szerkesztő felületet jelentenek. Az alábbi példa felsorolja a láncot és vizsgálja az effektív értékeket, ahol az adott API biztosítja őket:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

A paraméter nélküli hatások, mint a szürkeárnyalatos, alfa ceiling és alfa inverse, továbbra is rendelkeznek hatékony adatobjektummal, de nincs kiírandó skalár beállítás. A jelenlétük és a gyűjteményen belüli pozíciójuk a fontos információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja az [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) metódust egy művelet index szerinti eltávolításához. Mivel az indexek eltolódnak az eltávolítás után, előbb keresse meg a célt, majd a felsorolás után távolítsa el. Használja az [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) metódust a teljes lánc eltávolításához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A transzformációk eltávolítása vagy törlése csak a kép formázását módosítja. Nem törli, nem tömöríti újra, és nem változtatja meg a újrahasznált [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) erőforrást.

## **Vegye figyelembe a prezentáció formátumokat és export célpontokat**

A képtranszformációk a DrawingML-ből származnak, ezért a PPTX a preferált szerkeszthető formátum a hatámláncokhoz. Még PPTX esetén sem minden művelet rendelkezik azonos hordozhatósággal:

- Az olyan szabványos DrawingML műveletek, mint a fényerő, szürkeárnyalatos, duotone, tint, HSL, elmosás és a gyakori alfa műveletek a legnagyobb eséllyel maradnak meg egy PPTX körkörös után. Mindig nyissa meg újra a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) egy Office 2010 kiegészítő, nem a szabványos DrawingML fényerő művelet. Memóriában történő rendereléshez használható, de nem garantált, hogy szerkeszthető [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) marad a PPTX mentése és újra megnyitása után. Inkább a [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) használata javasolt a tartós fényerő és kontraszt beállításokhoz.
- A bináris PPT formátum megelőzi a teljes DrawingML hatásmodellt. PPT-be mentés esetén a nem támogatott műveletek kimaradhatnak, a lánc egy támogatott részhalmazra csökkenhet, vagy a megjelenést közelítheti. Ne használja a PPT-t ellenőrzési formátumként egy összetett szerkeszthető lánchoz.
- A PNG, JPEG, TIFF, PDF, SVG, HTML vagy egyéb vizuális kimenetre történő renderelés a támogatott láncot alkalmazza a megjelenésre. Ezek a kimenetek nem tartalmaznak szerkeszthető `ImageTransformOperationCollection`-t; a raszteres formátumok az eredményt pixelekre lapítják, a dokumentum/vektoral exportok a saját renderelési reprezentációikat tárolják.
- A hatások nem teszik a hivatkozott képet önállóvá. A hivatkozott kép renderelése továbbra is függ a hivatkozott erőforrás elérhetőségétől, amikor a prezentáció betöltődik.

Különböző prezentációs fogyasztók eltérően renderelhetik a szélhelyzeteket, különösen ha több alfa vagy színkvantálási művelet kombinálódik. Kritikus kimenet esetén tesztelje mind a szerkeszthető körkörös folyamatot, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, mint a termelésben.

## **GYIK**

**Módosítják a képtranszformációs hatások a beágyazott kép adatokat?**

Nem. A műveletek a képkitöltés által használt `Picture`-hez tartoznak. A mögöttes `PPImage` bájtok változatlanok maradnak.

**Megosztják-e a két képkeret, amely ugyanazt a képet használja, a hatásokat?**

Nem. A `PPImage` újrahasználata elkerüli a duplikált képadatot, de minden képkeret általában külön `Picture`-t és képtranszformációs gyűjteményt kap.

**Kombinálhatók a szín, elmosás és alfa hatások?**

Igen. A gyűjtemény egy rendezett láncban fogadja őket. Vegye figyelembe, hogy minden művelet mit tesz az előző kimenetével, mivel a helyettesítő és küszöb műveletek eldobhatják a korábbi szín- vagy alfa részleteket.

**Miért csak olvashatóak a hatékony értékek?**

A hatékony adatok a rendereléshez használt számított értékeket, köztük a feloldott színeket képviselik. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol vannak írható tagok; egyébként távolítsa el, és adjon hozzá egy helyettesítőt új létrehozási paraméterekkel.

**Milyen formátumot használjak a transzformációs lánc megőrzéséhez?**

Használjon PPTX-et, és ellenőrizze a fájlt újbóli megnyitással. A régi PPT nem képes a teljes DrawingML hatásmodellt ábrázolni, és a renderelt export formátumok csak a megjelenést őrzik meg, nem a szerkeszthető transzformációs műveleteket.