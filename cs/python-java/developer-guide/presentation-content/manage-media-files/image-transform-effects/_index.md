---
title: Spravovat efekty transformace obrázku v prezentacích s Pythonem
linktitle: Efekty transformace obrázku
type: docs
weight: 11
url: /cs/python-java/image-transform-effects/
keywords:
- transformace obrázku
- efekt obrázku
- jas
- kontrast
- odstín šedi
- duotón
- tónování
- HSL
- náhrada barvy
- rozmazání
- průhlednost
- efekt alfa
- řetězec efektů
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrázku. Pro rámeček obrázku začněte s [Picture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/) rámce a přistupte k [Picture.getImageTransform](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#getImageTransform). Vrácená [ImageTransformOperationCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/) vám umožní přidávat, procházet, inspektovat, odstraňovat a mazat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek demonstruje kompletní workflow pro jas a kontrast, barevné transformace, rozmazání, transparentnost, řetězce efektů v určeném pořadí, efektivní hodnoty, odstraňování a ověření PPTX round‑trip.

## **Pochopení vlastnictví efektu a opětovného použití obrázku**

Obrazový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) ukládá nebo odkazuje na zdrojová data obrázku, která vlastní prezentace.
- [Picture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/) patří do výplně obrázku a odkazuje na obrazový zdroj, zatímco uchovává kolekci transformací obrázku.
- [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámce.

Proto operace transformace obrázku nemodifikují bajty v [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/). Když je stejný `PPImage` předán metodě [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addPictureFrame) více než jednou, každý nový rámeček obrázku získá svůj vlastní `Picture` a vlastní kolekci transformací. Použití odstínu šedi na jednom rámci neovlivní ostatní rámečky, i když všechny používají stejný vložený obrazový zdroj.

Stejný model `Picture.getImageTransform` používají také jiné výplně obrázku, například tvar nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázků.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Udržujte hodnoty v těchto rozsazích, i když konkrétní verze knihovny neodmítne okamžitě každou hodnotu mimo rozsah; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu beze změny. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Žádné | Žádné číselné parametry. Alfa zůstává beze změny. |
| [addDuotoneEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `java.awt.Color` používají hodnoty `0` až `255`. |
| [addTintEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Hue je `0` inkluzivně až `360` exkluzivně, ve stupních; amount je `-100` až `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Hue je `0` inkluzivně až `360` exkluzivně, ve stupních; saturation a luminance jsou `-100` až `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující alfa hodnoty zůstávají beze změny. |
| [addBlurEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Radius je nezáporný a měří se v bodech; `grow` je Boolean, který určuje, zda rozmazaný obsah může přesáhnout původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je úplně průhledné a `100` zachovává existující alfu. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` až `100`, procenta neprůhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` až `100`, procenta alfa prahu. Hodnoty pod prahem se stávají průhlednými; hodnoty na prahu nebo nad ním se stávají neprůhlednými. |

Pro pevnou modulaci alfy jsou transparentnost a neprůhlednost komplementární. Například 35 % transparentnosti odpovídá modulaci alfy ve výši 65 %.

## **Použijte jas a kontrast**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) vrací operaci [BrightnessContrast](https://reference.aspose.com/slides/cs/python-java/aspose.slides/brightnesscontrast/). Její skalární nastavení jsou zadána při vytvoření operace. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/brightnesscontrast/#getEffective) vrací vypočtené hodnoty jen pro čtení, které lze inspektovat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled, aniž by změnil vložený obrázek:

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

[BrightnessContrast](https://reference.aspose.com/slides/cs/python-java/aspose.slides/brightnesscontrast/) je rozšíření efektu obrázku pro Office 2010 a není tak přenositelné jako standardní efekt luminance v DrawingML. Když musí být jas a kontrast po PPTX round‑tripu zachovány editovatelné, použijte [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) a po opětovném otevření souboru ověřte výsledek. Část o omezeních formátu podrobně vysvětluje tento rozdíl.

## **Použijte barevné transformace**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázků, které používají jeden obrazový zdroj. Následující příklad vytvoří pět rámců a aplikuje odstín šedi, duotón, tónování, úpravu HSL a náhradu barvy.

[Duotone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/duotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To jej činí užitečným příkladem efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) nahrazuje barvu každého pixelu jednou pevnou barvou a zachovává alfu. Liší se od [addColorChangeEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), který mapuje jednu zdrojovou barvu na jinou a vystavuje oba formáty zdrojové i cílové barvy.

## **Přidejte rozmazání, transparentnost a alfa efekty**

[addBlurEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) ovlivňuje všechny barevné kanály, včetně alfy. Nastavte `grow` na `True`, když rozmazaný okraj může přesáhnout původní hranice obrázku.

Pro jednotnou transparentnost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Násobí každou existující alfa hodnotu, takže částečně průhledné pixely zůstávají úměrně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) místo toho přiřadí jednu alfa hodnotu všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) převádí alfu na dvě úrovně podle prahu.

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

Další efekty alfy bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), který dělá každou nenulovou alfu plně neprůhlednou; [addAlphaFloorEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), který dělá každou alfu pod 100 % plně průhlednou; a [addAlphaInverseEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), který mění alfu na `100% - alpha`.

## **Vytvořte řetězec efektů v určeném pořadí**

Každá metoda `add...Effect` přidá novou operaci na konec kolekce. Renderér používá kolekci jako uspořádaný pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. Výsledkem je, že stejné operace v jiném pořadí mohou vytvořit odlišný obrázek.

Například odstín šedi následovaný tónováním nejprve odstraní chromatické informace a pak přebarví výsledek luminance. Tónování následované odstínem šedi odstraní tónování zpět. Podobně náhrada alfy může přepsat alfa hodnoty vypočtené předchozími operacemi, zatímco modulace alfy zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, znovu otevře prezentaci, zkontroluje typy operací i jejich pořadí a vykreslí výsledek po opětovném otevření:

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

Kolekce neukládá kompatibilní matici, která by omezovala barevné, alfa a rozmazávací operace do oddělených řetězců. Lze je kombinovat, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraňuje variaci RGB vytvořenou předchozími barevnými efekty; odstín šedi po duotónu odstraňuje dvě vybrané barvy; a operace alfa ceiling, floor, replacement nebo bi‑level mohou zahodit alfa detail vytvořený dříve. Sestavte řetězec podle požadovaného pořadí zpracování pixelů, místo aby byly položky považovány za neuspořádané příznaky formátování.

## **Prozkoumejte editovatelné a efektivní hodnoty**

Editovatelná operace je objekt uložený v `Picture.getImageTransform`. V závislosti na efektu může přímo vystavovat zapisovatelné členy. Například [Blur](https://reference.aspose.com/slides/cs/python-java/aspose.slides/blur/) vystavuje zapisovatelné hodnoty `radius` a `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/alphamodulatefixed/) vystavuje zapisovatelný `amount` a [AlphaBiLevel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/alphabilevel/) vystavuje zapisovatelný `threshold`. Barevné efekty jako [Duotone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/duotone/) vystavují měnitelné objekty [ColorFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/colorformat/).

Některé třídy operací, včetně [BrightnessContrast](https://reference.aspose.com/slides/cs/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tint/) a [AlphaReplace](https://reference.aspose.com/slides/cs/python-java/aspose.slides/alphareplace/), neexponují své vytvořené skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte náhradu na požadovanou pozici.

Efektivní data vrácená metodou `getEffective` jsou vypočtená a jen pro čtení. Jsou užitečná pro řešení tématem podmíněných barev a čtení normalizovaných hodnot, které renderér používá, ale nejsou dalším editovacím povrchem. Následující příklad prochází řetězec a inspektuje efektivní hodnoty, pokud je příslušné API poskytuje:

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

Efekty bez parametrů, jako odstín šedi, alfa ceiling a alfa inverse, stále mají objekt efektivních dat, ale neexistují skalární nastavení k výpisu. Jejich přítomnost a pozice v kolekci jsou důležité informace.

## **Odstraňte nebo vymažte transformace obrázku**

Použijte [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) pro odstranění jedné operace podle indexu. Protože se indexy po odstranění posouvají, nejprve vyhledejte cíl a až po procházení jej odstraňte. Použijte [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#clear) pro odstranění celého řetězce.

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

Odstranění nebo vymazání transformací mění pouze formátování obrázku. Neodstraňuje, nekomprimuje ani jinak nemění znovu použitý zdroj [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/).

## **Zvažte formáty prezentací a cílové exporty**

Transformace obrázků pocházejí z DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX ne každá operace má stejnou přenositelnost:

- Standardní operace DrawingML, jako luminance, odstín šedi, duotón, tónování, HSL, rozmazání a běžné alfa operace, mají nejlepší šanci přežít PPTX round‑trip. Vždy po vygenerování souboru jej znovu otevřete a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/cs/python-java/aspose.slides/brightnesscontrast/) je rozšíření Office 2010, nikoli standardní operace luminance v DrawingML. Lze jej použít pro renderování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný [BrightnessContrast](https://reference.aspose.com/slides/cs/python-java/aspose.slides/brightnesscontrast/). Pro trvalé úpravy jasu a kontrastu upřednostněte [addLuminanceEffect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect).
- Binární formát PPT předchází úplnému modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako formát pro ověření složitého editovatelného řetězce.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů aplikuje podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelnou `ImageTransformOperationCollection`; rastrové formáty výsledek vyhlazují do pixelů a dokumentové/vektorové exporty ukládají vlastní reprezentaci renderování.
- Efekty nečiní spojený obrázek samostatně uzavřeným. Renderování spojeného obrázku stále závisí na dostupnosti spojeného zdroje při načítání prezentace.

Různí spotřebitelé prezentací mohou vykreslovat okrajové případy odlišně, zejména když jsou kombinovány několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy testujte jak editovatelný round‑trip, tak konečný exportní formát se stejnou verzí Aspose.Slides používanou ve výrobě.

## **Často kladené otázky**

**Modifikují efekty transformace obrázku vložená data obrázku?**

Ne. Operace patří do `Picture` použitého ve výplni obrázku. Underlying `PPImage` bajty zůstávají beze změny.

**Budou dva rámečky obrázku, které používají stejný obraz, sdílet své efekty?**

Ne. Opakované použití `PPImage` zabraňuje duplicitním datům obrázku, ale každý rámec obrázku má obvykle samostatný `Picture` a kolekci transformací obrázku.

**Lze kombinovat barevné, rozmazávací a alfa efekty?**

Ano. Kolekce je přijímá v jednom řetězci v určeném pořadí. Zvažte, co každá operace dělá s výstupem předchozí, protože operace náhrady a prahu mohou odstranit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty jen pro čtení?**

Efektivní data představují vypočtené hodnoty používané při renderování, včetně rozřešených barev. Upravte operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte náhradu s novými parametry při vytvoření.

**Jaký formát bych měl použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Legacy PPT nemůže představovat úplný model efektů DrawingML a exportní formáty zachovávají vzhled spíše než editovatelné transformace.