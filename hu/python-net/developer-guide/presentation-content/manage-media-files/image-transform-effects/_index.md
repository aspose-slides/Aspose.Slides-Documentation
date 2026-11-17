---
title: Képelmosási hatások kezelése bemutatókban Python használatával
linktitle: Képelmosási hatások
type: docs
weight: 11
url: /hu/python-net/image-transform-effects/
keywords:
- képelmosás
- képhatás
- fényerő
- kontraszt
- szürkeárnyalatos
- duotone
- színeltolás
- HSL
- színhelyettesítés
- elmosás
- átlátszóság
- alfa hatás
- hatáslánc
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Alkalmazza, láncolja, ellenőrizze, távolítsa el és ellenőrizze a képelmosási hatásokat képkockákra az Aspose.Slides for Python segítségével .NET-en keresztül."
---
## **Áttekintés**

Az Aspose.Slides a képelmosásokat egy rendezett gyűjteményként ábrázolja, amely képek átalakítási műveleteket tartalmaz. Egy képkockához kezdje a keret [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) objektumával, és érje el a [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) tulajdonságát. A visszaadott [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) lehetővé teszi műveletek hozzáadását, felsorolását, vizsgálatát, eltávolítását és törlését anélkül, hogy az eredeti képadatokat újraírná.

Ez a cikk bemutat egy komplett munkafolyamatot a fényerő- és kontraszt-szabályozáshoz, színátalakításokhoz, homályosításhoz, átlátszósághoz, rendezett hatásláncokhoz, tényleges értékekhez, eltávolításhoz és PPTX körkörös ellenőrzéshez.

## **Értsd meg a hatás tulajdonjogát és a kép újrafelhasználását**

Egy képernyő erőforrás és a megjelenítő kép külön objektumok:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) tárolja vagy hivatkozik a bemutató által birtokolt forrásképadatokra.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) egy képtöltéshez tartozik, és egy képernyő erőforrásra hivatkozik, miközben a képátalakítási gyűjteményt tárolja.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) a dián lévő alakzat, amely a megfelelő képtöltést, geometriát, vágóbeállításokat és egyéb keret‑szintű formázást birtokolja.

Ezért a képátalakítási műveletek **nem** módosítják a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) bájtjait. Ha ugyanazt a `PPImage`‑t több alkalommal adjuk át a [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) metódusnak, minden új képkocka saját `Picture`‑t és saját átalakítási gyűjteményt kap. Egy keretre alkalmazott szürkeárnyalatos hatás nem lesz hatással a többi keretre, még ha mind ugyanazt a beágyazott képernyő erőforrást is újrahasználják.

Ugyanez a `Picture.image_transform` modell más képtöltéseknél is használható, például alakzat vagy dia háttér esetén. Az alábbi példák a képkockákra összpontosítanak.

## **Használj érvényes paramétertartományokat és egységeket**

A bemutatott módszerek a következő szemantikai tartományokat és egységeket használják. Tartsa be ezeket a tartományokat akkor is, ha egy adott könyvtárverzió nem utasítja el azonnal a tartományon kívüli értékeket; a céldokumentum formátuma normalizálhat, kihagyhat vagy elutasíthat hibás adatot mentéskor vagy a PowerPoint megnyitásakor.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100`‑tól `100`‑ig, százalék; `0` változatlan komponens. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Nincs numerikus paraméter. Alfa változatlan. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Két szín a sötét és a világos pixelekhez. RGB és alfa csatornák `0`‑tól `255`‑ig. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Árnyalat `0`‑tól `360`‑ig (kizárólag), fokban; mennyiség `-100`‑tól `100`‑ig, százalék. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Árnyalat `0`‑tól `360`‑ig, fokban; telítettség és világosság `-100`‑tól `100`‑ig, százalék. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig. A meglévő alfa értékek változatlanok. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | A sugár nemnegatív, pontban mérve; `grow` logikai érték, amely azt szabályozza, hogy a homályos tartalom átléphet‑e az eredeti határokon kívülre. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Nemnegatív százalék. Használja a `0`‑tól `100`‑ig terjedő tartományt az átlátszóság skálázásához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszóság. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbnél nagyobb vagy egyenlő értékek átlátszatlanok. |

A fix alfa moduláció esetén a transzparencia és az opacitás komplementer egymásnak. Például a 35 % átlátszóság egy 65 % alfa modulációs értékkel felel meg.

## **Fényerő és kontraszt alkalmazása**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) egy [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) műveletet ad vissza. Skaláris beállításait a művelet létrehozásakor adjuk meg. A [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) számított, csak‑olvasásra szánt értékeket ad, amelyeket vizsgálhat vagy naplózhat.

Az alábbi példa 15 %‑kal növeli a fényerőt és 20 %‑kal a kontrasztot, majd előnézetet készít anélkül, hogy módosítaná a beágyazott képet:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) egy Office 2010 kép‑effekt kiterjesztés, és kevésbé hordozható, mint a szabványos DrawingML világosság‑effekt. Ha a fényerő és a kontraszt szerkeszthető maradjon egy PPTX körkörös mentés után, használja a [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) metódust, és ellenőrizze az eredményt a fájl újbóli megnyitása után. A formátum‑korlátok részben részletesebb magyarázatot talál.

## **Színátalakítások alkalmazása**

A színhatások függetlenül alkalmazhatók különböző képkockákra, amelyek ugyanazt a kép‑erőforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeárnyalatos, duotone, színeltolás, HSL‑korrekció és színhelyettesítés hatásokat alkalmaz.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) két függetlenül szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket térképezi. Ez egy jó példa egy olyan hatásra, amely beállításai összetettebbek egyetlen skalár értéknél.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) minden pixel színét egy rögzített színre cseréli, miközben megőrzi az alfat. Ez eltér a [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)‑tól, amely egy forrás‑színt egy másikra térképez, és mindkét színformátumot ki is mutatja.

### **Luminancia küszöb alkalmazása**

A luminancia küszöb segíthet a szkennelt oldal gyenge jeleinek kiemelésében a háttérrel szemben. A [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) megőrzi a köztes szürkeárnyalatokat. A [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) a luminanciát fekete‑fehérre képezi, míg a [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) az alfa értékeket küszöbölve módosítja.

A luminancia‑küszöb 0 %‑tól 100 %‑ig terjed, mindkét határérték beleértve. Az alatta lévő pixelek fekete lesznek, a küszöbnél nagyobb vagy egyenlő pixelek fehér. A küszöb növelése több árnyalatot tesz feketévé, mivel több pixel esik a határ alá.

Töltse le a [grayscale-swatches.png](grayscale-swatches.png) fájlt a munkakönyvtárba. Minden címke a 0‑tól 255‑ig terjedő eredeti szürke szintet mutatja. A példa az eredetit két másolattal helyezi egymás mellé, és minden másolat küszöbértékét a bemutatóban menti.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Nyissa meg a kimeneti bemutatót PowerPoint‑ban, hogy összehasonlítsa a három keretet. A 96‑os színmintának körülbelül 38 % luminanciája van (96/255). A 20 %‑os küszöbön fehér, a 60 %‑osnál fekete lesz.

![Eredeti szürkeárnyalatos színminták a fekete‑fehér eredményekkel 20 % és 60 % luminancia‑küszöbön](luminance-threshold.png)

## **Homály, átlátszóság és alfa hatások hozzáadása**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) az összes színcsatornát, beleértve az alfat is, érinti. Állítsa `grow`‑t `True`‑ra, ha a homályos él kiterjedhet az eredeti kép határain kívülre.

Egységes átlátszósághoz használja a [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/)‑et. Ez minden meglévő alfa értéket megszoroz, így a részben átlátszó pixelek arányosan változnak. A [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) ehelyett egyetlen alfa értéket rendel az összes pixelhez. A [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) két szintre konvertálja az alfat egy küszöb alapján.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

A paraméter‑szabad alfa műveletek közé tartozik a [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), amely minden nemnulla alfat teljesen átlátszatlanná teszi; a [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), amely minden 100 % alatti alfat teljesen átlátszóvá alakít; és az [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), amely az alfat `100% - alpha`‑ra változtatja.

## **Rendezett hatáslánc felépítése**

Minden `add_..._effect` metódus egy új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt rendezett csővezeték‑ként használja: a 0‑s művelet kimenete lesz az 1‑es bemenete, és így tovább. Ennek következtében a műveletek ugyanazok más sorrendben különböző képet eredményezhetnek.

Például a szürkeárnyalatos hatás után a színeltolás először a színinformációt távolítja el, majd a luminancia‑eredményt színezi újra. A színeltolás után a szürkeárnyalatos visszatörli a színeltolást. Hasonlóan, az alfa‑helyettesítés felülírhatja a korábbi műveletek által kiszámolt alfa értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy műveletből álló láncot épít, PPTX‑ként menti, újra megnyitja a bemutatót, ellenőrzi a művelettípusokat és azok sorrendjét, majd megjeleníti az újra‑megnyitott eredményt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

A gyűjtemény nem alkalmaz olyan kompatibilitási mátrixot, amely szín, alfa és homály műveleteket külön láncokra korlátozna. Kombinálhatók, de nem minden kombináció hasznos. Egy fix színhelyettesítés eltávolítja az előző színhatások által előállított RGB‑variációt; a szürkeárnyalatos duotone után eltávolítja a két kiválasztott színt; az alfa‑célpont, -padló, -helyettesítés vagy -két‑szintű műveletek elpusztíthatják a korábban létrehozott alfa‑részleteket. Építse fel a láncot a kívánt pixel‑feldolgozási sorrend szerint, ne pedig rendezetlen formázási jelzőként kezelje.

<!-- visual-explanation:image-transform-effects:start -->
[![Ugyanaz a kép először szürkeárnyalatos, majd színeltolás, illetve fordítva. A két végső szürkeárnyalatos kép más‑más tónusú.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*A fenti Aspose.Slides for .NET 26.11 renderben a 220°‑os színeltolás 25 %‑on a szürkeárnyalatos képet változatlanul hagyja. Ugyanazon színeltolás alkalmazása a szürkeárnyalatos előtt más‑más tónusokat eredményez.*
<!-- visual-explanation:image-transform-effects:end -->

## **Szerkeszthető és tényleges értékek vizsgálata**

Egy szerkeszthető művelet az a objektum, amely a `Picture.image_transform`‑ban tárolva van. A hatástól függően közvetlenül elérhetőek lehetnek írható tagok. Például a [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) írható `radius` és `grow` tulajdonságokat nyújt, az [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) írható `amount` tulajdonságot, az [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) pedig írható `threshold` tulajdonságot. A [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) színhatások módosítható [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) objektumokat adnak.

Néhány művelet, köztük a [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), a [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), a [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/) és az [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/) nem exponálja a létrehozási skalárokat írható tulajdonságként. Ezeknek a beállításainak megváltoztatásához távolítsa el a műveletet, és adjon hozzá egy újat a kívánt helyen.

A `get_effective()` által visszaadott tényleges adat kiszámított és csak‑olvasásra szánt. Hasznos a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek olvasásához, de nem egy újabb szerkesztési felület. Az alábbi példa felsorolja a láncot, és megvizsgálja a tényleges értékeket, ahol az adott API biztosítja őket:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Paraméter‑szabad hatások, például a szürkeárnyalatos, alfa‑célpont és alfa‑inverz, szintén rendelkeznek tényleges‑adat objektummal, de nincs kiírandó skalár beállítás. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képátalakítások eltávolítása vagy törlése**

Használja a [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) metódust egy művelet index szerinti eltávolításához. Mivel az indexek eltávolítás után eltolódnak, először keresse meg a célt, majd a felsorolás után távolítsa el. A `clear()` az egész láncot eltávolítja.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Az átalakítások eltávolítása vagy törlése csak a kép formázását változtatja meg. Nem törli, tömöríti újra vagy egyébként módosítja a újra‑használt [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) erőforrást.

## **Vegyél figyelembe bemutatóformátumokat és exportcélokat**

A képátalakítások a DrawingML‑ből származnak, ezért a PPTX a leginkább szerkeszthető formátum a hatásláncok számára. Még PPTX‑nél sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminancia, szürkeárnyalatos, duotone, tint, HSL, blur és a gyakori alfa műveletek a legnagyobb eséllyel maradnak meg egy PPTX körkörös mentés után. Mindig nyissa meg a generált fájlt újra, és ellenőrizze a gyűjteményt, ha a megőrzés követelmény.
- A [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) egy Office 2010‑es kiterjesztés, nem pedig a szabványos DrawingML luminancia művelet. Memóriabeli rendereléshez használható, de nem garantált, hogy PPTX mentés és újra‑megnyitás után szerkeszthető `BrightnessContrast` műveletként marad. Inkább a [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/)‑et válassza a tartós fényerő‑kontraszt beállításokhoz.
- A bináris PPT formátum az egész DrawingML hatásmodellt megelőzte. PPT‑be mentés elhagyhat nem támogatott műveleteket, csökkentheti a láncot egy támogatott részhalmazra, vagy közelítheti a megjelenést. Ne használja a PPT‑t ellenőrzési formátumként összetett szerkeszthető lánc esetén.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy egyéb vizuális kimenetek a támogatott láncot alkalmazzák a megjelenésre. Ezek a kimenetek nem tartalmazzák a szerkeszthető `ImageTransformOperationCollection`‑t; a raszteres formátumok az eredményt pixelekre lapítják, a dokumentum‑ vagy vektorgyorsítók pedig saját renderelési reprezentációt tárolják.
- A hatások nem teszik önállóvá a hivatkozott képet. Egy hivatkozott kép renderelése továbbra is a hivatkozott erőforrás elérhetőségétől függ, amikor a bemutatót betöltik.

Különböző bemutatófogyasztók más‑más módon jeleníthetik meg a szélsőséges eseteket, különösen ha több alfa vagy szín‑kvantáló művelet van kombinálva. Kritikus kimenet esetén tesztelje mind a szerkeszthető körkörös mentést, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amelyet a termelésben használ.

## **Gyakran Ismételt Kérdések**

**Módosítják a képátalakítási hatások a beágyazott képadatokat?**

Nem. A műveletek a kép‑kitöltéshez használt `Picture`‑hoz tartoznak. Az alatta lévő `PPImage` bájtok változatlanok maradnak.

**Megosztják a két, ugyanazt a képet újrahasznosító képkocka a hatásokat?**

Nem. Egy `PPImage` újrahasznosítása elkerüli a duplikált képadatot, de minden képkocka általában külön `Picture`‑t és képátalakítási gyűjmentet kap.

**Kombinálhatók a szín, blur és alfa hatások?**

Igen. A gyűjtemény egy rendezett láncban fogadja őket. Fontolja meg, hogy az egyes műveletek hogyan hatnak az előző kimenetére, mivel a helyettesítő és küszöb‑műveletek eldobhatják a korábbi szín‑ vagy alfa‑részleteket.

**Miért csak‑olvasásra szánt a tényleges érték?**

A tényleges adat a rendereléshez használt, kiszámított értékeket tartalmazza, beleértve a feloldott színeket is. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol írható tagok vannak; különben távolítsa el, és adjon hozzá egy újat az új létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megőrzéséhez?**

Használja a PPTX‑et, és ellenőrizze a fájlt újra megnyitva. A régi PPT nem képes a teljes DrawingML hatásmodellt ábrázolni, a renderelt exportformátumok pedig csak a megjelenést, nem a szerkeszthető transzformációs műveleteket őrzik meg.