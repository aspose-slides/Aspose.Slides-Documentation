---
title: Správa efektů transformace obrazu v prezentacích pomocí Pythonu
linktitle: Efekty transformace obrazu
type: docs
weight: 11
url: /cs/python-net/image-transform-effects/
keywords:
- transformace obrazu
- efekt obrázku
- jas
- kontrast
- stupně šedi
- duotón
- odstín
- HSL
- náhrada barvy
- rozostření
- průhlednost
- efekt alfa
- řetězec efektů
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Používejte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrazu pro rámečky obrázků pomocí Aspose.Slides pro Python přes .NET."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázku jako uspořádanou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s [Picture](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picture/) snímku a přistupte k jeho vlastnosti [image_transform](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picture/image_transform/). Vrácený [ImageTransformOperationCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/) vám umožní přidávat, enumerovat, zkoumat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek ukazuje kompletní workflow pro jas a kontrast, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstraňování a ověření PPTX round‑trip.

## **Pochopení vlastnictví efektu a opětovného použití obrázku**

Zdroj obrázku a obrázek, který jej zobrazuje, jsou různé objekty:

- [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) ukládá nebo odkazuje na zdrojová data obrázku, která patří prezentaci.
- [Picture](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picture/) patří k výplni obrázku a odkazuje na zdroj obrázku při ukládání kolekce transformací obrazu.
- [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) je tvar snímku, který vlastní odpovídající výplň obrázku, geometrii, nastavení ořezu a další formátování úrovně rámečku.

Proto operace transformace obrazu nemění bajty v [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/). Když je stejný `PPImage` předán metodě [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_picture_frame/) více než jednou, každý nový rámeček obrázku získá svůj vlastní `Picture` a vlastní kolekci transformací. Aplikace stupně šedi na jeden rámeček neovlivní ostatní rámečky, i když všechny používají stejný vložený zdroj obrázku.

Stejný model `Picture.image_transform` používají také jiné výplně obrázků, například tvar nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázků.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Udržujte hodnoty v těchto rozsazích i když konkrétní verze knihovny neodmítne okamžitě každou hodnotu mimo rozsah; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu data normalizovat, vynechat nebo odmítnout.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu beze změny. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Žádné číselné parametry. Alfa zůstává beze změny. |
| [add_duotone_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa používají hodnoty `0` až `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Odtížení je `0` inkluzivně až `360` exklusivně, ve stupních; množství je `-100` až `100`, procent. |
| [add_hsl_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Odtížení je `0` inkluzivně až `360` exklusivně, ve stupních; sytost a luminance jsou `-100` až `100`, procent. |
| [add_color_replace_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující alfa zůstává beze změny. |
| [add_blur_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je logická hodnota, která určuje, zda může rozostřený obsah přesáhnout původní okraje. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je zcela průhledné a `100` zachovává existující alfu. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` až `100`, procento neprůhlednosti. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` až `100`, procento prahu alfy. Hodnoty pod prahem se stávají průhlednými; hodnoty na prahu nebo nad ním jsou neprůhledné. |

Pro pevnou modulaci alfy jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednosti odpovídá modulaci alfy ve výši 65 %.

## **Použít jas a kontrast**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) vrací operaci [BrightnessContrast](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/brightnesscontrast/). Její skalární nastavení jsou zadána při vytvoření operace. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) vrací vypočtené jen pro čtení hodnoty, které lze zkontrolovat nebo zalogovat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, pak vykreslí náhled bez úpravy vloženého obrázku:

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

[BrightnessContrast](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 pro efekty obrázku a není tak přenositelné jako standardní DrawingML efekt luminance. Když je potřeba, aby jas a kontrast zůstaly editovatelné po PPTX round‑trip, použijte [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) a ověřte výsledek po opětovném otevření souboru. Část o omezeních formátu podrobněji vysvětluje tento rozdíl.

## **Použít barevné transformace**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které používají jeden zdroj obrázku. Následující příklad vytvoří pět rámečků a použije stupně šedi, duotón, odstín, úpravu HSL a náhradu barvy.

[Duotone](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/duotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[add_color_replace_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) nahrazuje barvu každého pixelu jednou pevnou barvou a zachovává alfu. Liší se od [add_color_change_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), který mapuje jednu zdrojovou barvu na jinou a odhaluje oba formáty barvy zdroje i cíle.

## **Přidat rozostření, průhlednost a alfa efekty**

[add_blur_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) ovlivňuje všechny barevné kanály, včetně alfy. Nastavte `grow` na `True`, když rozostřený okraj může přesáhnout původní okraje obrázku.

Pro jednotnou průhlednost použijte [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Násobí každou existující alfu, takže částečně průhledné pixely zůstávají úměrně odlišné. [add_alpha_replace_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) naopak přiřadí jednu hodnotu alfy všem pixelům. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) převádí alfu na dvě úrovně na základě prahu.

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

Další efekty alfy bez parametrů zahrnují [add_alpha_ceiling_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), který činí každou nenulovou alfu plně neprůhlednou; [add_alpha_floor_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), který činí každou alfu pod 100 % zcela průhlednou; a [add_alpha_inverse_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), který mění alfu na `100% - alpha`.

## **Sestavit řazený řetězec efektů**

Každá metoda `add_..._effect` přidá novou operaci na konec kolekce. Renderér používá kolekci jako uspořádané potrubí: výstup operace 0 se stane vstupem operace 1 a tak dále. Výsledkem je, že stejné operace v jiném pořadí mohou vytvořit odlišný obrázek.

Například stupně šedi následované odstínem nejprve odstraní chromatické informace a poté přebarevní výsledek luminance. Odstín následovaný stupněm šedi opět odstraní odstín. Podobně nahrazení alfy může přepsat hodnoty alfy vypočítané dříve, zatímco modulace alfy zachová jejich relativní rozdíly.

Následující příklad sestaví řetězec čtyř operací, uloží jej jako PPTX, znovu otevře prezentaci, zkontroluje typy operací i jejich pořadí a vykreslí znovuotevřený výsledek:

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

Kolekce neukládá kompatibilní matici, která by omezovala barvy, alfu a rozostření na oddělené řetězce. Mohou být kombinovány, i když kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraňuje RGB variaci vytvořenou předchozími barevnými efekty; stupně šedi po duotóne odstraňuje dvě vybrané barvy; a operace alfy typu ceiling, floor, replacement nebo bi‑level mohou zrušit detal alfa vytvořený dříve. Sestavte řetězec podle požadovaného pořadí zpracování pixelů, místo aby byl vnímán jako neuspořádaná sada formátovacích příznaků.

## **Zkoumat editovatelné a efektivní hodnoty**

Editovatelná operace je objekt uložený v `Picture.image_transform`. V závislosti na efektu může přímo exponovat zapisovatelné členy. Například [Blur](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/blur/) exponuje zapisovatelné vlastnosti `radius` a `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/alphamodulatefixed/) exponuje zapisovatelnou vlastnost `amount` a [AlphaBiLevel](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/alphabilevel/) exponuje zapisovatelnou vlastnost `threshold`. Barevné efekty jako [Duotone](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/duotone/) exponují mutable objekty [ColorFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/colorformat/).

Některé operace, včetně [BrightnessContrast](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/tint/) a [AlphaReplace](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/alphareplace/), neexponují své tvorbové skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte náhradu na požadované místo.

Efektivní data vrácená metodou `get_effective()` jsou vypočtená a jen pro čtení. Jsou užitečná pro rozlišení tematem podmíněných barev a čtení normalizovaných hodnot, které renderér používá, ale nejsou dalším povrchem pro editaci. Následující příklad enumeruje řetězec a zkoumá efektivní hodnoty, kde je odpovídající API poskytuje:

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

Efekty bez parametrů, jako stupně šedi, alfa ceiling a alfa inverse, mají stále objekt efektivních dat, ale neexistují žádná skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležitou informací.

## **Odstranit nebo vymazat transformace obrazu**

Použijte [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) k odebrání jedné operace podle indexu. Protože se po odstranění indexy posunou, nejprve vyhledejte cíl a pak jej po enumeraci odstraňte. Použijte `clear()` k odstranění celého řetězce.

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

Odstranění nebo vymazání transformací mění pouze formátování obrázku. Neodstraňuje, nekomeprimuje ani jinak nemění znovupoužívaný zdroj [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/).

## **Zvážit formáty prezentace a cílové exporty**

Transformace obrazu vznikají v DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však ne každá operace má stejnou přenositelnost:

- Standardní DrawingML operace jako luminance, stupně šedi, duotón, odstín, HSL, rozostření a běžné alfa operace mají největší šanci přežít PPTX round‑trip. Vždy po vygenerování souboru otevřete znovu a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 a nikoli standardní DrawingML operace luminance. Lze jej použít pro renderování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný operací `BrightnessContrast`. Upřednostněte [add_luminance_effect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) pro trvalé úpravy jasu a kontrastu.
- Binární formát PPT předchází plnému modelu efektů DrawingML. Ukládání do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako formát pro ověření komplexního editovatelného řetězce.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů aplikuje podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelný `ImageTransformOperationCollection`; rastrové formáty výsledek spláchnou do pixelů a dokumentové nebo vektorové exporty ukládají vlastní reprezentaci renderování.
- Efekty nečiní propojený obrázek samostatně použitelým. Renderování propojeného obrázku stále závisí na tom, že propojený zdroj je dostupný při načtení prezentace.

Různí spotřebitelé prezentací mohou vykreslovat okrajové případy odlišně, zejména když je kombinováno několik alfa nebo barevných kvantizačních operací. Pro kritický výstup testujte jak editovatelný round‑trip, tak i finální exportovací formát se stejnou verzí Aspose.Slides, jaká se používá ve výrobě.

## **Často kladené otázky**

**Mění efekty transformace obrazu vložená data obrázku?**

Ne. Operace patří k `Picture` použitém ve výplni obrázku. Bity podkladového `PPImage` zůstávají beze změny.

**Budou dva rámečky obrázku, které používají stejný zdroj, sdílet své efekty?**

Ne. Opakované použití `PPImage` zabraňuje duplicitním datům obrázku, ale každý rámeček obrázku má obvykle samostatný `Picture` a vlastní kolekci transformací obrazu.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom řazeném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože operace nahrazení a prahu mohou odstranit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty jen pro čtení?**

Efektivní data představují vypočtené hodnoty používané při renderování, včetně rozlišených barev. Editujte operaci uloženou v kolekci transformací tam, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte náhradu s novými parametry tvorby.

**Který formát použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nemůže představovat kompletní model efektů DrawingML a renderované exportní formáty zachovávají jen vzhled, nikoli editovatelné operace transformace.