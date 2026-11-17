---
title: Spravujte efekty transformace obrazu v prezentacích v Pythonu
linktitle: Efekty transformace obrazu
type: docs
weight: 11
url: /cs/python-net/image-transform-effects/
keywords:
- transformace obrazu
- efekt obrázku
- jas
- kontrast
- odstín šedi
- duotón
- tónování
- HSL
- nahrazení barvy
- rozmazání
- průhlednost
- efekt alfa
- řetězec efektů
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Použijte, řetězujte, kontrolujte, odstraňujte a ověřujte efekty transformace obrazu pro rámečky obrázků s Aspose.Slides pro Python prostřednictvím .NET."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s rámcem [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) a přistupte k jeho [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) vlastnosti. Vrácená [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) vám umožní přidávat, enumerovat, kontrolovat, odstraňovat a vymazat efekty bez přepisování původních bajtů obrázku.

Tento článek demonstruje kompletní pracovní postup pro jas a kontrast, barevné transformace, rozmazání, průhlednost, uspořádané řetězce efektů, efektivní hodnoty, odstraňování a ověření PPTX při zpětném načtení.

## **Pochopte vlastnictví efektů a opětovné použití obrázku**

Obrazový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) patří k výplni obrázku a odkazuje na obrazový zdroj, přičemž uchovává kolekci transformací obrazu.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámce.

Proto operace transformace obrazu nemodifikují bajty v [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). Když je stejný `PPImage` předán metodě [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) více než jednou, každý nový rámeček obrázku získá vlastní `Picture` a vlastní kolekci transformací. Aplikování odstínu šedi na jeden rámec neovlivní ostatní rámečky, i když všechny používají stejný vložený obrazový zdroj.

Stejný model `Picture.image_transform` je také používán u dalších výplní obrázků, například u tvaru nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázků.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Uchovávejte hodnoty v těchto rozsazích, i když konkrétní verze knihovny okamžitě neodmítne každou hodnotu mimo rozsah; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechá komponentu beze změny. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Žádné číselné parametry. Alfa zůstává nezměněna. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa používají hodnoty od `0` do `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Odstín je od `0` (včetně) do `360` (exkluzivně), ve stupních; množství je od `-100` do `100`, procent. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Odstín je od `0` (včetně) do `360` (exkluzivně), ve stupních; sytost a luminance jsou od `-100` do `100`, procent. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Stávající hodnoty alfa zůstávají nezměněny. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je Boolean, který určuje, zda může rozmazaný obsah přesáhnout původní hranice. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je zcela průhledné a `100` zachovává stávající alfu. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` až `100`, procenta neprůhlednosti. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` až `100`, procentní prahová hodnota alfa. Hodnoty pod tímto prahem se stanou průhlednými; hodnoty na nebo nad prahem se stanou neprůhlednými. |

Pro pevnou modulaci alfa jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednost odpovídá hodnotě modulace alfa 65 %.

## **Použijte jas a kontrast**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) vrací operaci [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/). Jeho skalární nastavení jsou poskytnuta při vytvoření operace. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) vrací vypočtené hodnoty jen pro čtení, které lze prohlédnout nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vygeneruje náhled bez úpravy vloženého obrázku:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 pro efekty obrázků a není tak přenositelné jako standardní efekt luminance v DrawingML. Když musí jaz a kontrast zůstat editovatelné po zpětném načtení PPTX, použijte [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) a ověřte výsledek po opětovném otevření souboru. Oddíl o omezeních formátu podrobněji vysvětluje tento rozdíl.

## **Použijte barevné transformace**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázků, které používají stejný obrazový zdroj. Následující příklad vytvoří pět rámečků a použije odstín šedi, duotón, tónování, úpravu HSL a nahrazení barvy.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) nahrazuje barvu každého pixelu pevnou barvou a zachovává alfu. Liší se od [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), který mapuje jednu zdrojovou barvu na jinou a odhaluje oba formáty barvy – zdrojovou i cílovou.

### **Aplikujte prahovou hodnotu jasu**

Prahová hodnota jasu může usnadnit rozlišení slabých značek na naskenované stránce od pozadí. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) zachovává mezistupně šedi. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) mapuje luminanci na černou nebo bílou, zatímco [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) aplikuje prah na neprůhlednost.

Prahová hodnota jasu se pohybuje od 0 % do 100 %, včetně. Pixely pod prahem se stanou černými. Pixely na nebo nad prahem se stanou bílými. Zvyšování prahu převádí více odstínů na černou, protože více z nich spadne pod limit.

Stáhněte [grayscale-swatches.png](grayscale-swatches.png) do pracovního adresáře. Každý popisek udává původní úroveň šedi na stupnici od 0 do 255. Příklad umístí originál vedle dvou kopií a uloží prah každé kopie do prezentace.

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

Otevřete výstupní prezentaci v PowerPointu a porovnejte tři rámečky. Swatch označený 96 má přibližně 38 % luminance (96 z 255). Při 20 % prahu se změní na bílou a při 60 % prahu na černou.

![Původní šedé vzorky vedle černobílých výsledků při prahových hodnotách jasu 20% a 60%](luminance-threshold.png)

## **Přidejte rozmazání, průhlednost a alfa efekty**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) postihuje všechny barevné kanály, včetně alfa. Nastavte `grow` na `True`, když může rozmazaný okraj zasahovat mimo původní hranice obrázku.

Pro jednotnou průhlednost použijte [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Násobí každou existující hodnotu alfa, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) místo toho přiřadí jednu hodnotu alfa všem pixelům. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) převádí alfu na dvě úrovně na základě prahu.

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

Další operace alfa bez parametrů zahrnují [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), která činí každou nenulovou alfu plně neprůhlednou; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), která činí každou alfu pod 100 % zcela průhlednou; a [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), která mění alfu na `100% - alfa`.

## **Vytvořte uspořádaný řetězec efektů**

Každá metoda `add_..._effect` přidá novou operaci na konec kolekce. Vykreslovací engine používá kolekci jako uspořádaný pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. V důsledku toho může mít stejná posloupnost operací v jiném pořadí jiný výsledek.

Například odstín šedi následovaný tónováním nejprve odstraní chromatickou informaci a pak zbarví výsledek luminance. Tónování následované odstínem šedi zase tónování odstraňuje. Podobně nahrazení alfa může přepsat hodnoty alfa spočítané dřívějšími operacemi, zatímco modulace alfa zachovává jejich relativní rozdíly.

Následující příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, znovu otevře prezentaci, ověří typy operací i jejich pořadí a vykreslí výsledek po opětovném otevření:

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

Kolekce neukládá kompatibilitní matici, která by omezovala barevné, alfa a rozmazávací operace na oddělené řetězce. Mohou být kombinovány, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraňuje variace RGB vytvořené předchozími barevnými efekty; odstín šedi po duotónu odstraňuje dvě vybrané barvy; a operace alfa ceiling, floor, replacement nebo bi‑level mohou zahodit alfa detail vytvořený dříve. Sestavujte řetězec podle požadovaného pořadí zpracování pixelů místo toho, abyste je vnímali jako neřízené příznaky formátování.

<!-- visual-explanation:image-transform-effects:start -->
[![Stejný obrázek prochází nejprve převodem na odstíny šedi a pak tónováním, a naopak tónováním a pak převodem na odstíny šedi. Dvě výsledné šedé obrázky mají odlišné tóny.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*V tomto ilustračním vykreslení Aspose.Slides pro .NET 26.11 zůstane šedý obrázek nezměněn při tónování 220° s 25 %. Použití stejného tónování před převodem na odstíny šedi produkuje odlišné tóny.*
<!-- visual-explanation:image-transform-effects:end -->

## **Prohlédněte upravitelná a efektivní hodnoty**

Upravitelná operace je objekt uložený v `Picture.image_transform`. V závislosti na efektu může přímo odhalovat zapisovatelná členství. Například [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) odhaluje zapisovatelné vlastnosti `radius` a `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) odhaluje zapisovatelnou vlastnost `amount` a [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) odhaluje zapisovatelnou vlastnost `threshold`. Barevné efekty jako [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) odhalují mutovatelné objekty [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/).

Některé operace, včetně [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), a [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), neodhalují své vytvořené skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odeberte operaci a přidejte náhradu na požadovanou pozici.

Efektivní data vrácená metodou `get_effective()` jsou vypočtená a jen pro čtení. Hodí se k rozlišení barvy závislé na motivu a ke čtení normalizovaných hodnot, které renderer používá, ale nejedná se o další editační povrch. Následující příklad enumeruje řetězec a kontroluje efektivní hodnoty tam, kde odpovídající API poskytuje data:

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

Efekty bez parametrů, jako odstín šedi, alfa ceiling a alfa inverse, stále mají objekt efektivních dat, ale nemají skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležitou informací.

## **Odeberte nebo vymažte transformace obrazu**

Použijte [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) k odebrání jedné operace podle indexu. Protože se indexy po odebrání posouvají, nejprve najděte cílový prvek a po enumeraci jej odeberte. Použijte `clear()` k odstranění celého řetězce.

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

Odebrání nebo vymazání transformací mění pouze formátování obrázku. Neodstraňuje, nekombinuje ani jinak nemění znovu použité [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) zdroje.

## **Zvažte formáty prezentací a cíle exportu**

Transformace obrazu pocházejí z DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I u PPTX však ne každá operace má stejnou přenositelnost:

- Standardní operace DrawingML jako luminance, odstín šedi, duotón, tónování, HSL, rozmazání a běžné alfa operace mají největší šanci přežít PPTX round‑trip. Vždy po uložení souboru otevřete znovu a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) je rozšíření Office 2010 místo standardní operace luminance DrawingML. Lze jej použít pro renderování v paměti, ale není garantováno, že po uložení a opětovném otevření PPTX zůstane editovatelnou operací `BrightnessContrast`. Upřednostněte [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) pro trvalé úpravy jasu a kontrastu.
- Binární formát PPT existoval před úplným modelem efektů DrawingML. Ukládání do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovaný podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiného vizuálního výstupu použije podporovaný řetězec na vygenerovaný vzhled. Tyto výstupy neobsahují editovatelnou `ImageTransformOperationCollection`; rastrové formáty výsledek zploští do pixelů a exporty dokumentů nebo vektorů ukládají vlastní reprezentaci renderování.
- Efekty nečiní propojený obrázek samostatně uzavřeným. Renderování propojeného obrázku i nadále závisí na tom, že je propojený zdroj dostupný při načítání prezentace.

Různí spotřebitelé prezentací mohou renderovat okrajové případy odlišně, zejména když je kombinováno několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy otestujte jak editovatelný round‑trip, tak finální exportní formát se stejnou verzí Aspose.Slides používanou ve výrobě.

## **Často kladené otázky**

**Mění efekty transformace obrazu vložená data obrázku?**

Ne. Operace patří k `Picture` používanému výplní obrázku. Základní bajty `PPImage` zůstávají beze změny.

**Budou dva rámečky obrázku, které používají stejný obrázek, sdílet své efekty?**

Ne. Použití `PPImage` eliminuje duplicitní data obrázku, ale každý rámeček obrázku obvykle má vlastní `Picture` a vlastní kolekci transformací obrazu.

**Lze kombinovat barevné, rozmazávací a alfa efekty?**

Ano. Kolekce je přijme v jednom uspořádaném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože operace nahrazení a prahování mohou zahodit předchozí barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty jen pro čtení?**

Efektivní data představují vypočtené hodnoty používané při renderování, včetně rozlišených barev. Upravte operaci uloženou v kolekci, kde existují zapisovatelné členy; jinak ji odeberte a přidejte náhradu s novými parametry vytvoření.

**Který formát mám použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nedokáže představit celý model efektů DrawingML a exportní formáty zachovávají pouze vzhled, nikoli editovatelné operace transformace obrazu.