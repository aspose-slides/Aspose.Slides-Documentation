---
title: Správa efektů transformace obrazu v prezentacích s Pythonem
linktitle: Efekty transformace obrazu
type: docs
weight: 11
url: /cs/python-java/image-transform-effects/
keywords:
- transformace obrazu
- efekt obrázku
- jas
- kontrast
- škála šedi
- duotón
- odstín
- HSL
- náhrada barvy
- rozostření
- průhlednost
- alpha efekt
- řetězec efektů
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrazu pro rámečky obrázků s Aspose.Slides pro Python pomocí Java."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrázku. Pro rámeček obrázku začněte s rámečkem [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) a přistupte k [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform). Vrácená [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) vám umožní přidávat, procházet, kontrolovat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek ukazuje kompletní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstraňování a ověření zpětného průchodu PPTX.

## **Pochopte vlastnictví efektů a opětovné použití obrázků**

Zdrojový obrázek a obrázek, který jej zobrazuje, jsou různé objekty:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) patří do výplně obrázku a odkazuje na zdroj obrázku při ukládání kolekce transformací obrázku.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámečku.

Proto operace transformace obrázku nemění bajty v [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/). Když je stejný `PPImage` předán metodě [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) více než jednou, každý nový rámeček obrázku získá vlastní `Picture` a vlastní kolekci transformací. Aplikace odstínu šedé na jeden rámeček neovlivní ostatní rámečky, i když všechny používají stejný vložený zdroj obrázku.

Stejný model `Picture.getImageTransform` používají i jiné výplně obrázku, například tvar nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázku.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Dodržujte hodnoty v těchto rozsazích, i když konkrétní verze knihovny neodmítne okamžitě každou hodnotu mimo rozsah; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu nezměněnou. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Žádné | Žádné číselné parametry. Alfa zůstává nezměněna. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `java.awt.Color` používají `0` až `255`. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Odstín je od `0` (včetně) do `360` (vyloučeno) stupňů; množství je od `-100` do `100` procent. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Odstín je od `0` (včetně) do `360` (vyloučeno) stupňů; sytost a luminance jsou od `-100` do `100` procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující hodnoty alfa zůstávají nezměněny. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je logická hodnota, která určuje, zda rozostřený obsah může přesahovat původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je plně průhledné a `100` zachovává existující alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` až `100`, procento neprůhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` až `100`, procentní prahová hodnota alfa. Hodnoty pod tím se stanou průhlednými; hodnoty na nebo nad tím se stanou neprůhlednými. |

Pro pevnou modulaci alfa jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednost odpovídá hodnotě modulace alfa 65 %.

## **Použijte jas a kontrast**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) vrací operaci [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). Její skalární nastavení jsou zadána při vytvoření operace. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) vrací vypočítané hodnoty pouze ke čtení, které lze zkontrolovat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, pak zobrazí náhled bez úpravy vloženého obrázku:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) je rozšíření Office 2010 pro efekt obrázku a není tak přenositelný jako standardní efekt luminance v DrawingML. Když je potřeba, aby jas a kontrast zůstaly editovatelné po zpětném průchodu PPTX, použijte [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) a ověřte výsledek po opětovném otevření souboru. Část o omezeních formátu vysvětluje tento rozdíl podrobněji.

## **Použijte barevné transformace**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které používají jeden zdroj obrázku. Následující příklad vytvoří pět rámečků a použije šedou škálu, duotón, odstín, úpravu HSL a nahrazení barvy.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) obsahuje dva nezávisle upravitelné parametry barvy: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To z něj činí užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfa kanálu. Liší se od [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), který mapuje jednu zdrojovou barvu na jinou a vystavuje oba formáty barvy.

### **Použijte prah luminance**

Prahování luminance může usnadnit rozlišení slabých značek na naskenované stránce od pozadí. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) zachovává střední odstíny šedé. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) mapuje luminanci na černou nebo bílou, zatímco [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) aplikuje prah na neprůhlednost.

Prahová hodnota luminance je od 0 % do 100 %, včetně. Pixely pod prahem se stanou černými. Pixely na nebo nad prahem se stanou bílými. Zvýšením prahu se více odstínů změní na černou, protože více z nich spadne pod hranici.

Stáhněte soubor [grayscale-swatches.png](grayscale-swatches.png) do pracovního adresáře. Každý popisek udává původní úroveň šedi na stupnici od 0 do 255. Příklad umístí originál vedle dvou kopií a uloží prah každé kopie v prezentaci.

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

Otevřete výstupní prezentaci v PowerPointu a porovnejte tři rámečky. Vzorek označený 96 má přibližně 38 % luminance (96 z 255). Při prahu 20 % se změní na bílou a při prahu 60 % na černou.

![Původní šedé vzorky vedle černobílých výsledků při prahových hodnotách luminance 20 % a 60 %](luminance-threshold.png)

## **Přidejte rozostření, průhlednost a alfa efekty**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) ovlivňuje všechny barevné kanály, včetně alfa. Nastavte `grow` na `True`, pokud může rozostřený okraj přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Násobí každou existující hodnotu alfa, takže částečně průhledné pixely zůstávají úměrně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) místo toho přiřadí jednu hodnotu alfa všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) převádí alfa na dvě úrovně na základě prahu.

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

Další operace alfa bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), která nastaví každou nenulovou alfa hodnotu na plně neprůhlednou; [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), která nastaví každou alfa pod 100 % na plně průhlednou; a [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), která mění alfa na `100% - alpha`.

## **Sestavte řazený řetězec efektů**

Každá metoda `add...Effect` připojí novou operaci na konec kolekce. Vykreslovací engine používá kolekci jako uspořádaný potrubní řetězec: výstup operace 0 se stane vstupem operace 1 a tak dále. V důsledku toho může stejná sada operací v jiném pořadí vytvořit odlišný obrázek.

Například šedá škála následovaná odstínem nejprve odstraní chromatickou informaci a pak přebarevní výsledek luminance. Opačný pořad – odstín a pak šedá škála – odstraní odstín znovu. Podobně nahrazení alfa může přepsat hodnoty alfa vypočítané dřívějšími operacemi, zatímco modulace alfa zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, znovu otevře prezentaci, ověří jak typy operací, tak jejich pořadí, a vykreslí výsledek po opětovném otevření:

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

Kolekce neukládá kompatibilní matici, která by omezovala barevné, alfa a rozostřovací operace na samostatné řetězce. Mohou být kombinovány, ale ne všechny kombinace jsou užitečné. Pevná náhrada barvy odstraní variaci RGB vytvořenou předchozími barevnými efekty; šedá škála po duotóne odstraní obě vybrané barvy; a operace alfa ceiling, floor, replacement nebo bi‑level mohou vyřadit alfa detail vytvořený dříve. Sestavujte řetězec podle požadované sekvence zpracování pixelů, místo aby jste je považovali za neuspořádané příznaky formátování.

<!-- visual-explanation:image-transform-effects:start -->
[![Stejný obrázek prochází šedou škálou, potom odstínem, a alternativně odstínem, potom šedou škálou. Dvě konečné šedé obrázky mají odlišné tóny.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*V tomto ilustračním renderu Aspose.Slides pro .NET 26.11 zůstane při 220° odstínu s 25 % šedá škála nezměněna. Aplikace stejného odstínu před šedou škálou vytváří jiné tóny.*
<!-- visual-explanation:image-transform-effects:end -->

## **Prozkoumejte editovatelné a efektivní hodnoty**

Editovatelný efekt je objekt uložený v `Picture.getImageTransform`. V závislosti na efektu může přímo odhalovat zapisovatelné členy. Například [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) odhaluje zapisovatelné hodnoty `radius` a `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) odhaluje zapisovatelný `amount` a [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) odhaluje zapisovatelný `threshold`. Barevné efekty jako [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) odhalují měnitelné objekty [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/).

Některé třídy operací, včetně [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/), a [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), neodhalují své vytváěcí skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odeberte operaci a přidejte novou na požadované pozici.

Efektivní data vrácená metodou `getEffective` jsou vypočítaná a jen ke čtení. Hodí se k rozpoznání barev závislých na motivu a k načtení normalizovaných hodnot, které renderer používá, ale nejsou dalším editovacím rozhraním. Následující příklad prochází řetězec a kontroluje efektivní hodnoty tam, kde je příslušné API poskytuje:

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

Efekty bez parametrů, jako šedá škála, alfa ceiling a alfa inverse, stále mají objekt efektivních dat, ale neexistují žádná skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležitou informací.

## **Odstraňte nebo vymažte transformace obrázků**

Použijte [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) k odebrání jedné operace podle indexu. Protože se indexy po odebrání posouvají, nejprve vyhledejte cíl a poté jej po procházení odeberte. Použijte [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) k odebrání celého řetězce.

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

Odebrání nebo vymazání transformací mění jen formátování obrázku. Neodstraňuje, nekomprimuje ani jinak nemění znovu použité zdroje [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/).

## **Zvažte formáty prezentací a cíle exportu**

Transformace obrázků vznikají v DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však ne každá operace má stejnou přenositelnost:

- Standardní operace DrawingML, jako jsou luminance, šedá škála, duotón, odstín, HSL, rozostření a běžné alfa operace, mají největší šanci přežít zpětný průchod PPTX. Vždy po uložení souboru znovu otevřete a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) je rozšíření Office 2010, nikoli standardní operace luminance v DrawingML. Lze jej použít pro vykreslování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). Pro trvalé úpravy jasu a kontrastu upřednostněte [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect).
- Binární formát PPT předchází kompletnímu modelu efektů DrawingML. Ukládání do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovaný podmnožinu nebo přibližně napodobit vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Vykreslování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů aplikuje podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelnou `ImageTransformOperationCollection`; rastrové formáty výsledek rozplátí do pixelů a exporty dokumentu/vektoru ukládají vlastní reprezentaci vykreslení.
- Efekty nezpůsobí, že propojený obrázek bude samostatný. Vykreslování propojeného obrázku stále závisí na dostupnosti propojeného zdroje při načtení prezentace.

Různí spotřebitelé prezentací mohou renderovat hraniční případy odlišně, zejména když jsou kombinovány více alfa nebo barevně kvantizačních operací. Pro kritické výstupy testujte jak editovatelný zpětný průchod, tak finální exportní formát stejnou verzí Aspose.Slides používanou ve výrobě.

## **Často kladené otázky**

**Mění efekty transformace obrázku vložená data obrázku?**

Ne. Operace patří k `Picture` použitému ve výplni obrázku. Bajty podkladového `PPImage` zůstávají nezměněny.

**Sdílejí dva rámečky obrázku, které používají stejný obrázek, své efekty?**

Ne. Opakovaným použitím `PPImage` se předejde duplicitě dat obrázku, ale každý rámeček obrázku má obvykle vlastní `Picture` a vlastní kolekci transformací obrázku.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom řazeném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože operace nahrazení a prahování mohou odstranit dřívější barevný nebo alfa detail.

**Proč jsou efektivní hodnoty jen ke čtení?**

Efektivní data představují vypočítané hodnoty použité při vykreslování, včetně rozpoznaných barev. Upravit můžete pouze operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odeberte a přidejte novou s novými parametry tvorby.

**Jaký formát použít k zachování řetězce transformací?**

Použijte PPTX a ověřte soubor opětovným otevřením. Starší PPT nedokáže reprezentovat celý model efektů DrawingML a výstupní formáty zachovávají jen vzhled, nikoli editovatelné operace transformace.