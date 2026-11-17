---
title: Beheer afbeeldingstransformatie‑effecten in presentaties met Python
linktitle: Afbeeldingstransformatie‑effecten
type: docs
weight: 11
url: /nl/python-java/image-transform-effects/
keywords:
- afbeeldingstransformatie
- afbeeldingseffect
- helderheid
- contrast
- grijswaarden
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alpha‑effect
- effectketen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas afbeeldingstransformatie‑effecten toe, verbind ze, inspecteer, verwijder en verifieer ze voor afbeeldingskaders met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides stelt beeldaanpassingen voor als een geordende verzameling van afbeeldingstransformatie‑operaties. Voor een afbeeldingskader begin je met de [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) van het kader en roep je [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform) aan. De geretourneerde [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) stelt je in staat om effecten toe te voegen, te doorlopen, te inspecteren, te verwijderen en te wissen zonder de oorspronkelijke afbeeldings‑bytes opnieuw te schrijven.

Dit artikel toont een volledige workflow voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effecten‑ketens, effectieve waarden, verwijdering en PPTX‑rondreistrajectverificatie.

## **Begrijp effect‑eigendom en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) slaat de bronafbeeldingsdata op of verwijst ernaar die eigendom is van de presentatie.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) behoort tot een afbeelding‑vulling en verwijst naar een afbeeldingsbron terwijl deze de collectie van afbeeldingstransformaties opslaat.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) is de dia‑vorm die de bijbehorende afbeelding‑vulling, geometrie, bijsnijd‑instellingen en andere op frame‑niveau opmaak bezit.

Daarom wijzigen afbeeldingstransformatie‑operaties de bytes in [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) niet. Wanneer dezelfde `PPImage` meer dan één keer aan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) wordt doorgegeven, ontvangt elk nieuw afbeeldingskader zijn eigen `Picture` en zijn eigen transformaties‑collectie. Het toepassen van grijswaarden op één kader maakt de andere kaders niet grijs, zelfs wanneer ze allemaal dezelfde ingebedde afbeeldingsbron hergebruiken.

Hetzelfde `Picture.getImageTransform`‑model wordt ook gebruikt door andere afbeeldingvullingen, zoals een vorm of dia‑achtergrond. De voorbeelden hieronder richten zich op afbeeldingskaders.

## **Gebruik geldige parameterbereiken en eenheden**

De gedemonstreerde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie niet onmiddellijk elke out‑of‑range‑waarde afwijst; het doel‑presentatie‑formaat kan ongeldige gegevens normaliseren, weglaten of afwijzen tijdens het opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat het onderdeel ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Geen | Geen numerieke parameters. Alpha blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfacanalen in `java.awt.Color` gebruiken `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; hoeveelheid (`amount`) is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alpha‑waarden blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in punten; `grow` is een Boolean die bepaalt of vervaagde inhoud buiten de oorspronkelijke grenzen mag uitsteken. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Niet‑negatief percentage. Gebruik `0` tot `100` voor gewone opaciteits‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` tot `100`, procent opacity. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` tot `100`, procent alpha‑drempel. Waarden eronder worden transparant; waarden gelijk aan of hoger worden ondoorzichtig. |

Voor vaste alpha‑modulatie zijn transparantie en opacity complementair. Bijvoorbeeld, 35% transparantie komt overeen met een alpha‑modulatie‑waarde van 65%.

## **Helderheid en contrast toepassen**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) retourneert een [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/)‑operatie. De scalar‑instellingen worden meegegeven bij het creëren van de operatie. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) geeft berekende alleen‑lees waarden terug die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15% en het contrast met 20%, en rendert vervolgens een voorbeeld zonder de ingebedde afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) is een Office 2010 afbeelding‑effect extensie en is minder draagbaar dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑rondreis, gebruik dan [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) en verifieer het resultaat na het opnieuw openen van het bestand. De sectie over format‑beperkingen legt dit onderscheid uitgebreider uit.

## **Kleurtransformaties toepassen**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeeldingskaders die één afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf kaders en past grijswaarden, duotone, tint, HSL‑aanpassing en kleurvervanging toe.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` wijst donkere pixels toe, terwijl `color2` lichte pixels toewijst. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan één enkele scalar‑waarde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) vervangt de kleur van elke pixel door één vaste kleur, terwijl alpha behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), dat één bronkleur naar een andere mapt en zowel bron‑ als doelformaten toont.

### **Een luminantiedrempel toepassen**

Een luminantiedrempel kan vage vlekken op een gescande pagina gemakkelijker van de achtergrond onderscheiden. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) behoudt tussenliggende grijstinten. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) zet luminantie om in zwart of wit, terwijl [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) een drempel op de opacity toepast.

De luminantiedrempel varieert van 0% tot 100%, inclusief. Pixels onder de drempel worden zwart. Pixels op of boven de drempel worden wit. Het verhogen van de drempel maakt meer tinten zwart omdat meer ervan onder de afkapwaarde vallen.

Download [grayscale-swatches.png](grayscale-swatches.png) naar de werkmap. Elk label geeft het oorspronkelijke grijsniveau op een schaal van 0 tot 255 weer. Het voorbeeld plaatst het origineel naast twee kopieën en slaat de drempel van elke kopie op in de presentatie.

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

Open de gegenereerde presentatie in PowerPoint om de drie kaders te vergelijken. De swatch met label 96 heeft ongeveer 38% luminantie (96 van 255). Hij wordt wit bij de 20%‑drempel en zwart bij de 60%‑drempel.

![Originele grijstinten naast de zwart‑wit resultaten bij luminantiedrempels van 20% en 60%](luminance-threshold.png)

## **Vervaging, transparantie en alpha‑effecten toevoegen**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) beïnvloedt alle kleurkanalen, inclusief alpha. Zet `grow` op `True` wanneer de vervaagde rand buiten de oorspronkelijke afbeelding kan uitsteken.

Voor uniforme transparantie gebruik je [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Het vermenigvuldigt elke bestaande alpha‑waarde, zodat deels transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) kent in plaats daarvan één alpha‑waarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) zet alpha om in twee niveaus op basis van een drempel.

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

Andere parameter‑vrije alpha‑operaties omvatten [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), die elke niet‑nul alpha volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), die elke alpha onder 100% volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), die alpha wijzigt naar `100% - alpha`.

## **Een geordende effectketen bouwen**

Elke `add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van operatie 0 wordt de input van operatie 1, enzovoort. Daardoor kan dezelfde reeks operaties in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijswaarden gevolgd door tint verwijdert eerst chromatische informatie en kleurt vervolgens het luminantieresultaat. Tint gevolgd door grijswaarden verwijdert de tint opnieuw. Evenzo kan alpha‑vervanging alpha‑waarden die door eerdere operaties zijn berekend overschrijven, terwijl alpha‑modulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de soorten operaties als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur-, alpha- en vervagingsoperaties tot afzonderlijke ketens beperkt. Ze kunnen worden gecombineerd, maar combinaties zijn niet altijd zinvol. Een vaste kleurvervanging verwijdert de RGB‑variatie die door eerdere kleureffecten is gecreëerd; grijswaarden na duotone verwijdert de twee geselecteerde kleuren; en alpha‑ceiling, floor, replacement of bi‑level‑operaties kunnen eerder gecreëerde alpha‑details wegdoen. Bouw de keten volgens de gewenste pixelverwerkingsvolgorde in plaats van de items te beschouwen als ongeordende opmaak‑vlaggen.

<!-- visual-explanation:image-transform-effects:start -->
[![Dezelfde afbeelding gaat eerst door grijswaarden dan tint, en tint dan grijswaarden. De twee uiteindelijke grijswaarden‑afbeeldingen hebben verschillende tinten.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In deze illustratieve Aspose.Slides for .NET 26.11 rendering, een tint van 220° op 25% laat de grijswaarden‑afbeelding ongewijzigd. Het toepassen van dezelfde tint vóór grijswaarden produceert verschillende tinten.*
<!-- visual-explanation:image-transform-effects:end -->

## **Bewerkbare en effectieve waarden inspecteren**

Een bewerkbare operatie is het object dat wordt opgeslagen in `Picture.getImageTransform`. Afhankelijk van het effect kan het direct beschrijfbare leden blootstellen. Bijvoorbeeld, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) biedt beschrijfbare `radius`‑ en `grow`‑waarden, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) biedt een beschrijfbare `amount`, en [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) biedt een beschrijfbare `threshold`. Kleureffecten zoals [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) geven mutabele [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/)‑objecten.

Sommige operatiewlassen, waaronder [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/) en [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), blootstellen hun creatie‑scalars niet als beschrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanging toe op de vereiste positie.

Effectieve data die door `getEffective` wordt teruggegeven, is berekend en alleen‑lees. Het is nuttig voor het oplossen van themagevoelige kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar het is geen extra bewerkingsoppervlak. Het volgende voorbeeld doorloopt de keten en inspecteert effectieve waarden waar de corresponderende API ze levert:

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

Parameter‑vrije effecten zoals grijswaarden, alpha‑ceiling en alpha‑inverse hebben nog steeds een effectieve‑data‑object, maar er zijn geen scalar‑instellingen om weer te geven. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Afbeeldingstransformaties verwijderen of wissen**

Gebruik [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) om één operatie op index te verwijderen. Omdat indexen verschuiven na verwijdering, zoek je eerst het doel en verwijder je het na de doorloop. Gebruik [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de afbeelding‑opmaak. Het verwijdert, recomprimeert of wijzigt niet de hergebruikte [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) bron.

## **Overweeg presentatieformaten en exportdoelen**

Afbeeldingstransformaties ontstaan in DrawingML, dus PPTX is het voorkeursbewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie dezelfde draagbaarheid:

- Standaard DrawingML‑operaties zoals luminantie, grijswaarden, duotone, tint, HSL, vervaging en veelvoorkomende alpha‑operaties hebben de grootste kans om een PPTX‑rondreis te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑operatie. Het kan worden gebruikt voor in‑memory rendering, maar het is niet gegarandeerd dat het als een bewerkbare [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) blijft na het opslaan en opnieuw openen van PPTX. Geef de voorkeur aan [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) voor permanente helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan als PPT kan niet‑ondersteunde operaties weglaten, een keten terugbrengen tot een ondersteund subset, of de weergave benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele output past de ondersteunde keten toe op de gerenderde weergave. Die outputs bevatten geen bewerkbare `ImageTransformOperationCollection`; rasterformaten vlakken het resultaat af tot pixels, en document‑/vector‑exports slaan hun eigen renderrepresentatie op.
- Effecten maken een gekoppelde afbeelding niet zelf‑voorzienend. Het renderen van een gekoppelde afbeelding blijft afhankelijk van de beschikbaarheid van de gekoppelde bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen anders renderen, vooral wanneer meerdere alpha‑ of kleur‑kwantisatie‑operaties worden gecombineerd. Voor kritische output, test zowel de bewerkbare rondreis als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen afbeeldingstransformatie‑effecten de ingebedde afbeeldingsdata?**

Nee. De operaties behoren tot de `Picture` die wordt gebruikt voor de afbeelding‑vulling. De onderliggende `PPImage`‑bytes blijven ongewijzigd.

**Zullen twee afbeeldingskaders die dezelfde afbeelding hergebruiken hun effect delen?**

Nee. Het hergebruiken van een `PPImage` vermijdt dubbele afbeeldingsdata, maar elk afbeeldingskader heeft normaal gezien een afzonderlijke `Picture` en een eigen transformaties‑collectie.

**Kunnen kleur-, vervaging‑ en alpha‑effecten gecombineerd worden?**

Ja. De collectie accepteert ze in één geordende keten. Overweeg wat elke operatie doet met de output van de vorige, omdat vervangings‑ en drempel‑operaties eerdere kleur‑ of alfadeel kunnen verwijderen.

**Waarom zijn effectieve waarden alleen‑lees?**

Effectieve data vertegenwoordigt berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die in de transformaties‑collectie is opgeslagen waar beschrijfbare leden bestaan; anders verwijder je deze en voeg je een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transformatieketen te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Legacy PPT kan het volledige DrawingML‑effectmodel niet weergeven, en gerenderde exportformaten behouden alleen de weergave en niet de bewerkbare transformaties.