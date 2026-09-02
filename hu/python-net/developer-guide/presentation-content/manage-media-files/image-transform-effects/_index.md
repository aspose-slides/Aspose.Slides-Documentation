---
title: Képtranszformációs hatások kezelése prezentációkban Python‑nal
linktitle: Képtranszformációs hatások
type: docs
weight: 11
url: /hu/python-net/image-transform-effects/
keywords:
- képtranszformáció
- kép hatás
- fényerő
- kontraszt
- szürkeskála
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
- Aspose.Slides
description: "Alkalmazza, fűzze össze, vizsgálja, távolítsa el és ellenőrizze a képtranszformációs hatásokat a képkeretekhez az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides a képkorrekciókat képszorzási műveletek rendezett gyűjteményeként ábrázolja. Egy képkerethez indítsa a keret [Picture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picture/) objektumát, és érje el a [image_transform](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picture/image_transform/) tulajdonságát. A visszakapott [ImageTransformOperationCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/effects/imagetransformoperationcollection/) lehetővé teszi műveletek hozzáadását, felsorolását, vizsgálatát, eltávolítását és a gyűjtemény törlését az eredeti kép bájtjainak újbóli írása nélkül.

Ez a cikk egy teljes munkafolyamatot mutat be a fényerő és kontraszt, színátalakítások, elmosás, átlátszóság, rendezett hatláncok, hatékony értékek, eltávolítás és PPTX körkörös ellenőrzés terén.

## **A hatás tulajdonjogának és a kép újrahasználatának megértése**

Egy képernyőforrás és a megjelenítő kép külön objektumok:

- [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) tárolja vagy hivatkozik a prezentáció által birtokolt forráskép adataira.
- [Picture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picture/) a képtöltéshez tartozik, egy képernyőforrást hivatkozik, és tárolja a képtranszformációk gyűjteményét.
- [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) a diára helyezett alakzat, amely a megfelelő képkitöltést, geometriát, vágási beállításokat és egyéb keretszintű formázásokat birtokolja.

Ezért a képtranszformációs műveletek **nem** módosítják a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) bájtjait. Ha ugyanazt a `PPImage`-t többször átadják a [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_picture_frame/) metódusnak, minden új képkeret saját `Picture`-t és saját transzformációs gyűjteményt kap. A szürkeskála alkalmazása az egyik keretben **nem** teszi szürkeskálává a többi keretet, bár mindegyik ugyanazt a beágyazott képernyőforrást használja.

Ugyanez a `Picture.image_transform` modell más képkitöltéseknél is használatos, például alakzat vagy dia háttér esetén. Az alábbi példák a képkeretekre fókuszálnak.

## **Érvényes paramétertartományok és egységek használata**

A bemutatott módszerek a következő szemantikus tartományokat és egységeket alkalmazzák. Tartsa a megadott értékeket, még akkor is, ha egy adott könyvtárverzió nem utasítja el azonnal a tartományon kívüli értékeket; a célprezentáció formátuma normalizálhat, elhagyhat vagy elutasíthat érvénytelen adatot mentéskor vagy a PowerPoint fájl megnyitásakor.

| Művelet | Paraméterek | Érvényes tartomány és egység |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100`‑tól `100`‑ig, százalék; `0` változatlanul hagyja az alkotót. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Nincs | Nincs numerikus paraméter. Az alfa változatlan. |
| [add_duotone_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Két szín a sötét és világos pixelekhez. Az RGB és alfa csatornák `0`‑tól `255`‑ig terjednek. |
| [add_tint_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | A színárnyalat `0` (záró) és `360` (nyitó) fok között, fokban; az mennyiség `-100`‑tól `100`‑ig, százalék. |
| [add_hsl_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | A színárnyalat `0`‑tól `360`‑ig, fokban; a telítettség és a fényesség `-100`‑tól `100`‑ig, százalék. |
| [add_color_replace_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | A helyettesítő szín csatornaértékei `0`‑tól `255`‑ig. A meglévő alfa értékek változatlanok. |
| [add_blur_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | A sugár nemnegatív és pontban van megadva; a `grow` logikai érték, amely azt szabályozza, hogy elmosott tartalom túlnyúlhat‑e az eredeti határokon. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Nemnegatív százalék. Használja a `0`‑tól `100`‑ig terjedő tartományt az általános átlátszatlanság skálázásához: `0` teljesen átlátszó, `100` megőrzi a meglévő alfat. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0`‑tól `100`‑ig, százalékos átlátszatlanság. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0`‑tól `100`‑ig, százalékos alfa küszöb. Az alatta lévő értékek átlátszóvá válnak; a küszöbön vagy fölötte lévők átlátszatlanok. |

A fix alfa moduláció esetén az átlátszóság és az átlátszatlanság kiegészítőek. Például a 35 % átlátszóság egy 65 % alfa modulációs értéknek felel meg.

## **Fényerő és kontraszt alkalmazása**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) egy [BrightnessContrast](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/brightnesscontrast/) műveletet ad vissza. A skalár beállításokat a művelet létrehozásakor adjuk meg. A [BrightnessContrast.get_effective](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) kiszámított, csak olvasható értékeket ad, amelyeket ellenőrizhet vagy naplózhat.

Az alábbi példa 15 %‑kal növeli a fényerőt és 20 %‑kal a kontrasztot, majd előnézetet renderel anélkül, hogy módosítaná a beágyazott képet:

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

A [BrightnessContrast](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/brightnesscontrast/) az Office 2010 kép‑effektus kiterjesztése, és kevésbé hordozható, mint a szabványos DrawingML fényerő‑effektus. Ha a fényerő és kontraszt szerkeszthetőnek kell maradnia egy PPTX körkörös mentés után, használja a [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) metódust, és ellenőrizze az eredményt a fájl újra megnyitása után. A formátumkorlátozások szekció részletesebben ismerteti ezt a különbséget.

## **Színátalakítások alkalmazása**

A szín‑effektusok függetlenül alkalmazhatók különböző képkeretekre, amelyek ugyanazt a képernyőforrást használják. Az alábbi példa öt keretet hoz létre, és szürkeskálát, duotont, színátmenetet, HSL‑korrekciót és színcsere‑effektust alkalmaz.

A [Duotone](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/duotone/) két függetlenül szerkeszthető színparamétert tartalmaz: a `color1` a sötét pixeleket, a `color2` a világos pixeleket térképezi. Ez egy jó példa olyan hatásra, amelynek beállításai összetettebbek, mint egy egyszerű skalárérték.

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

Az [add_color_replace_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) minden pixel színét egy fix színre cseréli, miközben megőrzi az alfat. Ez különbözik az [add_color_change_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)‑től, amely egy forrás‑színt egy másikra térképezi, és mind a forrás, mind a cél színformátumát ki is teszi.

## **Elmosás, átlátszóság és alfa‑effektusok hozzáadása**

Az [add_blur_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) minden színcsatornára, beleértve az alfat is, hat. Állítsa a `grow` értékét `True`‑ra, ha az elmosott él túlnyúlhat az eredeti kép határain.

Egyenletes átlátszósághoz használja a [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/)‑t. Ez minden meglévő alfa‑értéket megszoroz, így a részben átlátszó pixelek arányosan különböznek. Az [add_alpha_replace_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) ehelyett egyetlen alfa‑értéket rendel minden pixelhez. Az [add_alpha_bi_level_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) két szintre konvertálja az alfat egy küszöb alapján.

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

A paraméter‑nélküli alfa‑operációk közé tartozik még a [add_alpha_ceiling_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), amely minden nem nulla alfat teljesen átlátszatlanná teszi; a [add_alpha_floor_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), amely minden alfatot 100 % alatti értéknél teljesen átlátszóvá változtat; valamint a [add_alpha_inverse_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), amely az alfat `100% - alfa` értékre állítja.

## **Rendezett hatlánc felépítése**

Minden `add_..._effect` metódus új műveletet fűz a gyűjtemény végéhez. A renderelő a gyűjteményt egy rendezett csővezetékként használja: a 0‑s művelet kimenete a 1‑es bemenete, és így tovább. Ennek következtében a műveletek különböző sorrendben történő elrendezése más képet eredményezhet.

Például a szürkeskála, majd a színátmenet először eltávolítja a kromatikus információt, majd a fényességet színezi újra. A színátmenet, majd a szürkeskála visszaállítja a színátmenetet. Hasonlóképpen, az alfa‑csere felülírhatja a korábbi műveletek által kiszámított alfa‑értékeket, míg az alfa‑moduláció megőrzi azok relatív különbségeit.

Az alábbi példa egy négy‑műveletes láncot épít fel, PPTX‑ként menti, újra megnyitja a prezentációt, ellenőrzi a művelettípusokat és azok sorrendjét, majd a megnyitott eredményt rendereli:

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

A gyűjtemény nem kényszerít kompatibilitási mátrixot, amely szín, alfa és elmosás műveleteket külön láncokra korlátozna. Kombinálhatók, de a kombinációk nem mindig hasznosak. Egy fix színcsere eltávolítja a korábbi szín‑effektusok által generált RGB‑variációt; a szürkeskála duoton után eltávolítja a két kiválasztott színt; az alfa‑plafon, -padló, -csere vagy -két‑szintű műveletek eldobhatják a korábban létrehozott alfa‑részleteket. Építse fel a láncot a kívánt pixel‑feldolgozási sorozat szerint, és ne tekintse elemeit rendezetlen formázási jelzőknek.

## **Szerkeszthető és hatékony értékek vizsgálata**

A szerkeszthető művelet az a objektum, amely a `Picture.image_transform`‑ben tárolódik. A hatástól függően közvetlenül is elérhetők írható tagok. Például a [Blur](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/blur/) a `radius` és `grow` tulajdonságokat teszi írhatóvá, az [AlphaModulateFixed](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/alphamodulatefixed/) az `amount`‑ot, az [AlphaBiLevel](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/alphabilevel/) a `threshold`‑ot. A [Duotone](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/duotone/) szín‑effektus pedig módosítható [ColorFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/colorformat/) objektumokat jelenít meg.

Néhány művelet, például a [BrightnessContrast](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/brightnesscontrast/), a [HSL](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/hsl/), a [Tint](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/tint/) és az [AlphaReplace](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/alphareplace/), nem teszik írhatóvá a létrehozáskor megadott skalár‑értékeket. Ezek beállításához távolítsa el a műveletet, és a kívánt pozícióban adjon hozzá egy újat.

A `get_effective()` által visszaadott hatékony adat kiszámított és csak‑olvasásra alkalmas. Hasznos a téma‑függő színek feloldásához és a renderelő által használt normalizált értékek megismeréséhez, de nem egy újabb szerkesztési felület. Az alábbi példa felsorolja a láncot, és ott vizsgálja a hatékony értékeket, ahol a megfelelő API ezt biztosítja:

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

A paraméter‑nélküli hatások, mint a szürkeskála, alfa‑plafon vagy alfa‑inverz, szintén rendelkeznek hatékony‑adat objektummal, de nincs kiírható skalár‑beállításuk. Jelenlétük és pozíciójuk a gyűjteményben a fontos információ.

## **Képtranszformációk eltávolítása vagy törlése**

Használja a [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) metódust egy művelet index szerinti eltávolításához. Mivel az indexek az eltávolítás után eltolódnak, először keresse meg a célt, majd a felsorolás után távolítsa el. A `clear()` a teljes lánc eltávolítására szolgál.

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

A transzformációk eltávolítása vagy törlése csak a kép formázását módosítja. Nem törli, nem tömöríti újra, és nem változtatja meg a újrahasznált [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) forrását.

## **Prezentációs formátumok és exportcélok figyelembevétele**

A képtranszformációk a DrawingML‑ből származnak, ezért a PPTX a leginkább szerkeszthető formátum a hatláncok számára. Még PPTX‑nél sem minden művelet rendelkezik azonos hordozhatósággal:

- A szabványos DrawingML műveletek, mint a luminancia, szürkeskála, duotone, tint, HSL, elmosás és a gyakori alfa‑műveletek, a legnagyobb eséllyel maradnak meg egy PPTX körkörös mentés után. Mindig nyissa meg újra a generált fájlt, és ellenőrizze a gyűjteményt, ha a megőrzés kötelező.
- A [BrightnessContrast](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/brightnesscontrast/) egy Office 2010 kiterjesztés, nem a szabványos DrawingML luminancia‑művelet. Memóriában történő rendereléshez használható, de nem garantált, hogy a PPTX‑mentés és újra‑megnyitás után szerkeszthető `BrightnessContrast` műveletként marad. Tartós fényerő‑ és kontraszt‑korrekcióhoz részesítse előnyben az [add_luminance_effect](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/)‑et.
- A bináris PPT formátum előzi a teljes DrawingML‑effektus modellt. PPT‑re mentéskor a nem támogatott műveletek kihagyásra, a lánc támogatott részhalmazra csökkentésére vagy a megjelenés közelítésére kerülhet sor. Ne használja a PPT‑t ellenőrző formátumként összetett szerkeszthető láncok esetén.
- PNG, JPEG, TIFF, PDF, SVG, HTML vagy más vizuális kimenetek a támogatott láncot alkalmazzák a megjelenő képhez. Ezek a kimenetek nem tartalmazzák a szerkeszthető `ImageTransformOperationCollection`‑t; a raszter formátumok a végeredményt pixelekké lapítják, a dokumentum‑ vagy vektor‑exportok pedig saját renderelési reprezentációt tárolnak.
- Az effektek nem teszik magukévá a linkelt képet. Egy linkelt kép renderelése továbbra is a linkelt erőforrás rendelkezésre állásától függ a prezentáció betöltésekor.

Különböző prezentáció‑fogyasztók eltérően renderelhetik a szélsőséges eseteket, különösen ha több alfa‑ vagy szín‑kvantálási műveletet kombinálnak. Kritikus kimenetek esetén tesztelje mind a szerkeszthető körkörös mentést, mind a végső export formátumot ugyanazzal az Aspose.Slides verzióval, amelyet a termelésben használ.

## **GYIK**

**Módosítják a képtranszformációs hatások a beágyazott kép adatokat?**

Nem. A műveletek a képkitöltéshez tartozó `Picture`‑hez tartoznak. A mögöttes `PPImage` bájtjai változatlanok maradnak.

**Két képkeret, amely ugyanazt a képet használja, megosztja a hatásokat?**

Nem. A `PPImage` újrahasználata elkerüli a duplikált képadatok tárolását, de minden képkeret általában külön `Picture`‑t és külön képtranszformációs gyűjteményt kap.

**Kombinálhatók a szín, elmosás és alfa hatások?**

Igen. A gyűjtemény engedélyezi őket egy rendezett láncban. Fontolja meg, hogy az egyes műveletek hogyan befolyásolják az előző kimenetét, mivel a csere‑ és küszöb‑műveletek eldobhatják az előző szín‑ vagy alradet.

**Miért csak‑olvasásúak a hatékony értékek?**

A hatékony adatok a rendereléshez használt, kiszámított értékeket képviselik, beleértve a feloldott színeket is. Szerkessze a transzformációs gyűjteményben tárolt műveletet, ahol írható tagok vannak; egyébként távolítsa el, és adjon hozzá egy újat az új létrehozási paraméterekkel.

**Melyik formátumot használjam a transzformációs lánc megőrzéséhez?**

Használjon PPTX‑et, és ellenőrizze a fájlt a újra‑megnyitással. A régi PPT nem képes a teljes DrawingML‑effektus modellt ábrázolni, és a renderelt export formátumok csak a megjelenést, nem a szerkeszthető transzformációs műveleteket őrzik meg.