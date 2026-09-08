---
title: Képtranszformációs hatások kezelése prezentációkban Python nyelven
linktitle: Képtranszformációs hatások
type: docs
weight: 11
url: /hu/python-java/image-transform-effects/
keywords:
- képtranszformáció
- képhatás
- fényerő
- kontraszt
- szürkeárnyalat
- duotone
- színárnyalat
- HSL
- színhelyettesítés
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazzon, láncba rendezzen, vizsgáljon, távolítson el és ellenőrizzen képtranszformációs hatásokat képkeretekhez az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides a képmódosításokat rendezett gyűjteményként jeleníti meg, amely képtranszformációs műveleteket tartalmaz. Képkeret esetén kezdje a keret [Picture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/) -ával, és érje el a [Picture.getImageTransform](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#getImageTransform). A visszakapott [ImageTransformOperationCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/) lehetővé teszi a hatások hozzáfűzését, felsorolását, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti képadatokat újraírná.

Ez a cikk bemutat egy teljes munkafolyamatot a fényerő és kontraszt, színtranszformációk, elmosás, átlátszóság, rendezett hatásláncok, hatékony értékek, eltávolítás és PPTX körkörös ellenőrzés számára.

## **A hatás tulajdonjogának és a kép újrafelhasználásának megértése**

Egy képernyőforrás és a megjelenítő kép különálló objektumok:

- [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forráskép adataira.
- [Picture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/) egy képkitöltéshez tartozik, és egy képernyőforrást hivatkozik, miközben a képtranszformációs gyűjteményt tárolja.
- [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) a dián lévő alakzat, amely a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keret‑szintű formázásokat birtokolja.

Ezért a képtranszformációs műveletek nem módosítják a [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) bájtjait. Ha ugyanazt a `PPImage`‑t több alkalommal adjuk át a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addPictureFrame) metódusnak, minden új képkeret saját `Picture`‑t és saját transzformációs gyűjteményt kap. A szürkeárnyalatos hatás alkalmazása egy keretre nem teszi a többi keretet szürkeárnyalatosvá, még akkor sem, ha mindegyik ugyanazt a beágyazott képernyőforrást használja.

Ugyanez a `Picture.getImageTransform` modell más képkitöltéseknél is használható, például alakzat vagy diák háttér esetén. Az alábbi példák a képkeretekre összpontosítanak.

## **Érvényes paramétertartományok és egységek használata**

A bemutatott metódusok a következő szemantikai tartományokat és egységeket használják. Tartsuk a értékeket ezekben a tartományokban, még ha egy adott könyvtárverzió nem is utasítja el azonnal az out‑of‑range értékeket; a célnyelvi prezentációformátum normalizálhat, elhagyhat vagy elutasíthat érvénytelen adatot mentéskor vagy amikor a PowerPoint megnyitja a fájlt.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` és `100` között, százalék; `0` változatlanul hagyja az összetevőt. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | Nincs numerikus paraméter. Az alfa változatlan. |
| [addDuotoneEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Két szín a sötét és a világos képpontokhoz. Az RGB és alfa csatornák a `java.awt.Color`‑ban `0` és `255` között vannak. |
| [addTintEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | A színárnyalat `0`‑tól (inkluzívan) `360`‑ig (exkluzívan), fokban; az mennyiség `-100` és `100` között, százalék. |
| [addHSLEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | A színárnyalat `0`‑tól (inkluzívan) `360`‑ig (exkluzívan), fokban; a telítettség és a fényerő `-100` és `100` között, százalék. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | A helyettesítő szín csatornaértékei `0` és `255` között vannak. A meglévő alfa értékek változatlanok. |
| [addBlurEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | A sugár nemnegatív és pontokban van megadva; a `grow` egy logikai érték, amely meghatározza, hogy a elmosott tartalom kiterjedhet‑e az eredeti határokon kívül. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Nemnegatív százalék. Használja a `0` és `100` közötti értékeket az átlátszatlanság szokásos skálázásához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfacéket. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` és `100` közötti, százalékos átlátszatlanság. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` és `100` közötti, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbön vagy afelett lévő értékek átlátszatlanná. |

A fix alfa moduláció esetén az átlátszóság és az opacitás komplementer egységek. Például a 35 % átlátszóság a 65 % alfa‑modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) egy [BrightnessContrast](https://reference.aspose.com/slides/hu/python-java/aspose.slides/brightnesscontrast/) műveletet ad vissza. Skalár beállításait a művelet létrehozásakor adjuk meg. A [BrightnessContrast.getEffective](https://reference.aspose.com/slides/hu/python-java/aspose.slides/brightnesscontrast/#getEffective) számított csak‑olvasású értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 %‑kal növeli a fényerőt és 20 %‑kal a kontrasztot, majd előnézetet renderel a beágyazott kép módosítása nélkül:

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

A [BrightnessContrast](https://reference.aspose.com/slides/hu/python-java/aspose.slides/brightnesscontrast/) egy Office 2010 kép‑hatás kiterjesztés, és kevésbé hordozható, mint a szabványos DrawingML luminance hatás. Ha a fényerő és kontraszt szerkeszthetőnek kell maradnia egy PPTX körutazás után, használja a [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) metódust, és ellenőrizze az eredményt a fájl újranyitása után. A formátumkorlátozások szakaszban részletesebben kifejtésre kerül ez a különbség.

## **Színtranszformációk alkalmazása**

A színeffekteket külön‑külön alkalmazhatja különböző képkeretekre, melyek ugyanazt a képernyőforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, tint, HSL‑korrekció és színhelyettesítés hatásokat alkalmaz.

[Duotone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/duotone/) két önállóan szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket térképezi. Ez egy jó példa egy olyan hatásra, amelynek beállításai bonyolultabbak egy egyszerű skalárértékhez képest.

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

Az [addColorReplaceEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) minden pixel színét egy rögzített színre cseréli, miközben megtartja az alfacéket. Ez eltér a [addColorChangeEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect)‑től, amely egy forrás‑színt egy másikra képezi, és mindkét színformátumot ki is mutatja.

## **Elmosás, átlátszóság és alfa hatások hozzáadása**

[addBlurEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) az összes színcsatornát, köztük az alfacset is érinti. Állítsa a `grow`‑t `True`‑ra, ha az elmosott él kiterjedhet az eredeti kép határain kívülre.

Az egységes átlátszósághoz használja a [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect)‑et. Minden meglévő alfa‑értéket megszoroz, így a részben átlátszó pixelek arányosan különböznek továbbra is. Az [addAlphaReplaceEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) ehelyett egyetlen alfa‑értéket rendel minden pixelhez. Az [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) az alfacet két szintre konvertál egy küszöb alapján.

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

Paraméter‑szabad alfa‑műveletek közé tartozik még a [addAlphaCeilingEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), amely minden nem‑nulla alfacetet teljesen opaká tesz; a [addAlphaFloorEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), amely minden 100 % alatti alfacetet teljesen átlátszóvá tesz; valamint a [addAlphaInverseEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), amely az alfacetet `100% - alpha`‑ra változtatja.

## **Rendezett hatáslánc felépítése**

Minden `add...Effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezeték‑ként használja: az 0‑ás művelet kimenete lesz az 1‑es bemenete, és így tovább. Ennek következtében ugyanazok a műveletek más sorrendben más képet eredményezhetnek.

Például a szürkeárnyalat elsőként alkalmazott tint után először a színinformációt távolítja el, majd a luminancia eredményt színezi újra. A tint előbb, szürkeárnyalat később alkalmazva a tintet ismét eltávolítja. Hasonlóképpen, az alfa‑helyettesítés felülírhatja a korábbi műveletek által kiszámított alfa‑értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és a sorrendet, majd a megnyitott eredményt rendereli:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely szín‑, alfa‑ és elmosás‑műveleteket külön láncokra korlátozna. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy fix színhelyettesítés eltávolítja a korábbi színes hatások által előállított RGB‑variációt; a duotone után alkalmazott szürkeárnyalat eltávolítja a két kiválasztott színt; az alfa‑ceiling, floor, replacement vagy bi‑level műveletek eldobhatják a korábban létrehozott alfa‑részleteket. Építse a láncot a kívánt pixel‑feldolgozási sorrend alapján, ne pedig rendezetlen formázási jelzőként tekintsen a benne lévő elemekre.

## **Szerkeszthető és hatékony értékek ellenőrzése**

A szerkeszthető művelet az objektum, amely a `Picture.getImageTransform`‑ban tárolódik. A hatástól függően közvetlenül exposálhat írható tagokat. Például a [Blur](https://reference.aspose.com/slides/hu/python-java/aspose.slides/blur/) exponálja a írható `radius` és `grow` értékeket, az [AlphaModulateFixed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/alphamodulatefixed/) egy írható `amount`‑ot, az [AlphaBiLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/alphabilevel/) egy írható `threshold`‑ot. A [Duotone](https://reference.aspose.com/slides/hu/python-java/aspose.slides/duotone/) színhatás [ColorFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/colorformat/) objektumokat exponál.

Néhány művelet‑osztály, köztük a [BrightnessContrast](https://reference.aspose.com/slides/hu/python-java/aspose.slides/brightnesscontrast/), a [HSL](https://reference.aspose.com/slides/hu/python-java/aspose.slides/hsl/), a [Tint](https://reference.aspose.com/slides/hu/python-java/aspose.slides/tint/) és a [AlphaReplace](https://reference.aspose.com/slides/hu/python-java/aspose.slides/alphareplace/), nem exponálja a létrehozási skalárokat írható tulajdonságként. Ezek módosításához távolítsa el a műveletet, és adjon hozzá egy helyettesítőt a kívánt pozícióban.

A `getEffective` által visszaadott hatékony adat kiszámított és csak‑olvasású. Hasznos a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek megismeréséhez, de nem egy újabb szerkesztési felület. Az alábbi példa felsorolja a láncot, és ellenőrzi a hatékony értékeket, ahol az API biztosítja őket:

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

Paraméter‑szabad hatások, mint a szürkeárnyalat, alfa‑ceiling vagy alfa‑inverse, szintén rendelkeznek hatékony‑adat objektummal, de nincs kiírandó skalár beállításuk. Jelenlétük és pozíciójuk a gyűjteményben a lényeges információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja a [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#removeAt)‑t egy művelet index szerinti eltávolításához. Mivel az indexek az eltávolítás után eltolódnak, előbb keresse meg a célt, majd a felsorolás után távolítsa el. A [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#clear) teljes lánc eltávolításához használható.

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

A transzformációk eltávolítása vagy törlése csak a kép formázását változtatja meg. Nem törli, nem tömöríti újra és nem módosítja a felhasznált [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) erőforrást.

## **A prezentációformátumok és exportcélok szem előtt tartása**

A képtranszformációk a DrawingML‑ből származnak, így a PPTX a legmegfelelőbb szerkeszthető formátum a hatásláncok számára. Még PPTX‑ben sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminance, szürkeárnyalat, duotone, tint, HSL, elmosás és a gyakori alfa‑műveletek a legnagyobb eséllyel maradnak meg egy PPTX körutazás után. Mindig nyissa újra a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés elvárás.
- A [BrightnessContrast](https://reference.aspose.com/slides/hu/python-java/aspose.slides/brightnesscontrast/) egy Office 2010 kiterjesztés, nem a szabványos DrawingML luminance művelet. Memóriában történő rendereléshez használható, de nem garantált, hogy szerkeszthető [BrightnessContrast]‑ként marad a PPTX mentése és újranyitása után. Tartós fényerő‑ és kontraszt‑beállításokhoz előnyben részesítse a [addLuminanceEffect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect)‑et.
- A bináris PPT formátum a teljes DrawingML hatásmodellt megelőzi. PPT‑be mentés elhagyhat nem támogatott műveleteket, csökkentheti a láncot egy támogatott részhalmazra, vagy csak közelítheti a megjelenést. Ne használja a PPT‑t ellenőrzési formátumként összetett szerkeszthető lánc esetén.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenetre való renderelés a támogatott láncot alkalmazza a megjelenésre. Ezek a kimenetek nem tartalmaznak szerkeszthető `ImageTransformOperationCollection`‑t; a raszteres formátumok eredményt pixelekre lapítják, a dokumentum‑/vektoral exportok saját renderelési reprezentációt tárolnak.
- A hatások nem teszik önállóvá a hivatkozott képet. Egy hivatkozott kép renderelése továbbra is a hivatkozott erőforrás rendelkezésre állásától függ a prezentáció betöltésekor.

Különböző prezentáció‑fogyasztók eltérően renderelhetik a szélsőséges eseteket, különösen ha több alfa‑ vagy szín‑kvantálási művelet kombinálódik. Kritikus kimenet esetén tesztelje mind a szerkeszthető körutazást, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amelyet a gyártásban használ.

## **GYIK**

**Módosítják a képtranszformációs hatások a beágyazott képadatot?**

Nem. A műveletek a képkitöltéshez használt `Picture`‑hez tartoznak. A mögöttes `PPImage` bájtjai változatlanok maradnak.

**Két képkeret, amely ugyanazt a képet újrahasználja, megosztja a hatásokat?**

Nem. A `PPImage` újrahasználata elkerüli a duplikált képadatot, de minden képkeret általában külön `Picture`‑t és képtranszformációs gyűjteményt kap.

**Kombinálhatók-e a szín, elmosás és alfa hatások?**

Igen. A gyűjtemény egyetlen rendezett láncban fogadja őket. Figyelje meg, hogy az egyes műveletek hogyan befolyásolják az előző kimenetét, mivel a helyettesítő és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak‑olvasásúak a hatékony értékek?**

A hatékony adat a rendereléshez használt kiszámított értékeket képviseli, beleértve a feloldott színeket is. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol írható tagok vannak; egyébként távolítsa el, és adjon hozzá egy új, a kívánt paraméterekkel rendelkező helyettesítőt.

**Mely formátumot használjam a transzformációs lánc megőrzéséhez?**

Használjon PPTX‑et, és ellenőrizze a fájlt az újranyitás után. A régi PPT nem képes a teljes DrawingML hatásmodellt ábrázolni, és a renderelt export formátumok csak a megjelenést, nem pedig a szerkeszthető transzformációkat őrzik meg.