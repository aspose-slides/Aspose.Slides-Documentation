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
- grijswaarde
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
description: "Pas afbeeldingstransformatie‑effecten toe, maak ketens, inspecteer, verwijder en verifieer ze voor afbeeldingsframes met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt beeldaanpassingen als een geordende collectie van afbeeldings‑transformatie‑bewerkingen. Voor een afbeeldingsframe begin je met het frame’s [Picture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picture/) en roep je [Picture.getImageTransform](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picture/#getImageTransform) aan. De geretourneerde [ImageTransformOperationCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/) stelt je in staat om effecten toe te voegen, te enumereren, te inspecteren, te verwijderen en te wissen zonder de originele afbeeldingsbytes opnieuw te schrijven.

Dit artikel toont een volledige workflow voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX‑round‑trip‑verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [PPImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/) slaat of verwijst naar de bron‑afbeeldingsdata die eigendom is van de presentatie.
- [Picture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/picture/) behoort tot een afbeeldingsvulling en verwijst naar een afbeeldingsbron terwijl het de afbeeldings‑transform‑collectie opslaat.
- [PictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pictureframe/) is de dia‑vorm die de relevante afbeeldingsvulling, geometrie, uitsnijdingsinstellingen en andere opmaak op frame‑niveau bezit.

Daarom wijzigen afbeeldings‑transform‑bewerkingen de bytes in [PPImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/) niet. Wanneer dezelfde `PPImage` meer dan eens wordt doorgegeven aan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addPictureFrame), krijgt elk nieuw afbeeldingsframe zijn eigen `Picture` en eigen transform‑collectie. Het toepassen van grijswaarde op één frame maakt de andere frames niet grijs, ook al hergebruiken ze dezelfde ingebedde afbeeldingsbron.

Hetzelfde `Picture.getImageTransform`‑model wordt ook gebruikt door andere afbeeldingsvullingen, zoals een vorm‑ of dia‑achtergrond. De onderstaande voorbeelden focussen op afbeeldingsframes.

## **Gebruik geldige parameterbereiken en eenheden**

De getoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd je aan deze bereiken, zelfs als een bepaalde bibliotheekversie een out‑of‑range‑waarde niet onmiddellijk afwijst; het doel‑presentatieformaat kan de gegevens normaliseren, weglaten of afwijzen tijdens opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat de component ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | Geen numerieke parameters. Alfa blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfacanalen in `java.awt.Color` gebruiken `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; hoeveelheid (`amount`) is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Tint is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfabewerkingen blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in punten; `grow` is een Boolean die bepaalt of vervaagd materiaal buiten de originele grenzen mag uitbreiden. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Niet‑negatief percentage. Gebruik `0` tot `100` voor gewone opaciteit‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` tot `100`, procent opacity. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` tot `100`, procent alfa‑drempel. Waarden onder de drempel worden transparant; waarden gelijk aan of hoger worden ondoorzichtig. |

Voor vaste alfamodulatie zijn transparantie en opacity complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfamodulatie‑waarde van 65 %.

## **Pas helderheid en contrast toe**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) retourneert een [BrightnessContrast](https://reference.aspose.com/slides/nl/python-java/aspose.slides/brightnesscontrast/) bewerking. De scalaire instellingen worden opgegeven wanneer de bewerking wordt aangemaakt. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nl/python-java/aspose.slides/brightnesscontrast/#getEffective) retourneert berekende alleen‑lezen waarden die geïnspecteerd of gelogd kunnen worden.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 % en rendert vervolgens een voorbeeld zonder de ingebedde afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/nl/python-java/aspose.slides/brightnesscontrast/) is een Office 2010‑afbeeldingseffect‑extensie en minder draagbaar dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑round‑trip, gebruik dan [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) en verifieer het resultaat na het heropenen van het bestand. De sectie over format‑beperkingen legt dit onderscheid uitgebreider uit.

## **Pas kleurtransformaties toe**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeeldingsframes die één afbeeldingsbron hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijswaarde, duotoon, tint, HSL‑aanpassing en kleurvervanging toe.

[Duotone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/duotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` mappt donkere pixels, terwijl `color2` lichte pixels mappt. Dit maakt het een bruikbaar voorbeeld van een effect waarvan de instellingen complexer zijn dan één enkele scalaire waarde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) vervangt de kleur van elke pixel door één vaste kleur, terwijl alfa behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), dat één bronkleur naar een andere mappt en zowel bron‑ als doelformaat van kleuren blootlegt.

## **Voeg vervaging, transparantie en alfadeffecten toe**

[addBlurEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) beïnvloedt alle kleurkanalen, inclusief alfa. Stel `grow` in op `True` wanneer de vervaagde rand buiten de originele afbeeldingsgrenzen kan uitbreiden.

Voor uniforme transparantie, gebruik [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Het vermenigvuldigt elke bestaande alfabare, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) kent in plaats daarvan één alfawaarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) converteert alfa naar twee niveaus op basis van een drempel.

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

Andere alfa‑bewerkingen zonder parameters zijn onder meer [addAlphaCeilingEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), dat elke niet‑nul alfa volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), dat elke alfa onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), dat alfa verandert naar `100% - alpha`.

## **Bouw een geordende effectketen**

Elke `add...Effect`‑methode voegt een nieuwe bewerking toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de uitvoer van bewerking 0 wordt de invoer van bewerking 1, enzovoort. Daardoor kan dezelfde set bewerkingen in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijswaarde gevolgd door tint verwijdert eerst chromatische informatie en kleurt daarna het luminantie‑resultaat. Tint gevolgd door grijswaarde verwijdert de tint weer. Evenzo kan alfavervanging alfa‑waarden die door eerdere bewerkingen zijn berekend, overschrijven, terwijl alfamodulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier bewerkingen, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de bewerkingstypen als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alfa‑ en vervagingsbewerkingen tot aparte ketens beperkt. Ze kunnen gecombineerd worden, maar combinaties zijn niet altijd zinvol. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is gecreëerd; grijswaarde na duotoon verwijdert de twee geselecteerde kleuren; en alfa‑ceiling, -floor, -replace of -bilevel kunnen alfa‑details die eerder zijn gemaakt weggooien. Bouw de keten op volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items te zien als ongeordende opmaak‑vlaggen.

## **Inspecteer bewerkbare en effectieve waarden**

Een bewerkbare bewerking is het object dat is opgeslagen in `Picture.getImageTransform`. Afhankelijk van het effect kan het schrijfbare leden direct blootleggen. Bijvoorbeeld, [Blur](https://reference.aspose.com/slides/nl/python-java/aspose.slides/blur/) biedt schrijfbare `radius`‑ en `grow`‑waarden, [AlphaModulateFixed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/alphamodulatefixed/) biedt een schrijfbare `amount`, en [AlphaBiLevel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/alphabilevel/) biedt een schrijfbare `threshold`. Kleureffecten zoals [Duotone](https://reference.aspose.com/slides/nl/python-java/aspose.slides/duotone/) geven wijzigbare [ColorFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/colorformat/)‑objecten.

Sommige bewerkingsklassen, waaronder [BrightnessContrast](https://reference.aspose.com/slides/nl/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nl/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tint/) en [AlphaReplace](https://reference.aspose.com/slides/nl/python-java/aspose.slides/alphareplace/), onthullen hun creatiescalars niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de bewerking en voeg je een vervanging toe op de gewenste positie.

Effectieve data die door `getEffective` wordt geretourneerd, is berekend en alleen‑lezen. Het is nuttig voor het oplossen van themagerelateerde kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar het is geen bewerkingsoppervlak. Het volgende voorbeeld doorloopt de keten en inspecteert effectieve waarden waar de bijbehorende API ze levert:

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

Effecten zonder parameters zoals grijswaarde, alfa‑ceiling en alfa‑inverse hebben nog steeds een effectief‑datobject, maar er zijn geen scalaire instellingen om af te drukken. Hun aanwezigheid en positie in de collectie vormen de belangrijke informatie.

## **Verwijder of wis afbeeldingstransformaties**

Gebruik [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) om één bewerking op basis van index te verwijderen. Omdat indices verschuiven na een verwijdering, zoek je eerst het doel en verwijder je het daarna na enumeratie. Gebruik [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#clear) om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de afbeeldingsopmaak. Het verwijdert, recomprimeert of wijzigt de hergebruikte [PPImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/ppimage/) bron niet.

## **Overweeg presentatie‑formaten en export‑doelen**

Afbeeldings‑transformaties ontstaan in DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke bewerking identieke draagbaarheid:

- Standaard DrawingML‑bewerkingen zoals luminantie, grijswaarde, duotoon, tint, HSL, vervaging en gangbare alfa‑bewerkingen hebben de grootste kans om een PPTX‑round‑trip te overleven. Open altijd het gegenereerde bestand opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/nl/python-java/aspose.slides/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑bewerking. Het kan worden gebruikt voor in‑memory rendering, maar het is niet gegarandeerd dat het na opslaan en heropenen van PPTX bewerkbaar blijft als [BrightnessContrast]. Geef de voorkeur aan [addLuminanceEffect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binair PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde bewerkingen weglaten, een keten reduceren tot een ondersteunde subset, of het uiterlijk benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele outputs past de ondersteunde keten toe op het gerenderde uiterlijk. Die outputs bevatten geen bewerkbare `ImageTransformOperationCollection`; rasterformaten flatten het resultaat naar pixels, en document‑/vector‑exports slaan hun eigen renderrepresentatie op.
- Effecten maken een gelinkte afbeelding niet zelf‑containend. Het renderen van een gelinkte afbeelding hangt nog steeds af van de beschikbaarheid van de gelinkte bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen verschillend renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisatie‑bewerkingen gecombineerd zijn. Voor kritische output, test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen afbeeldingstransformatie‑effecten de ingebedde afbeeldingsdata?**

Nee. De bewerkingen behoren tot de `Picture` die wordt gebruikt door de afbeeldingsvulling. De onderliggende `PPImage`‑bytes blijven ongewijzigd.

**Delen twee afbeeldingsframes die dezelfde afbeelding hergebruiken hun effectinstellingen?**

Nee. Het hergebruiken van een `PPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeeldingsframe heeft normaal gesproken een eigen `Picture` en eigen transformatiescollectie.

**Kunnen kleur-, vervagings‑ en alfaseffecten worden gecombineerd?**

Ja. De collectie accepteert ze in één geordende keten. Overweeg wat elke bewerking doet met de uitvoer van de vorige, want vervangings‑ en drempel‑bewerkingen kunnen eerdere kleur‑ of alfadeelgegevens verwijderen.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die worden gebruikt voor rendering, inclusief opgeloste kleuren. Bewerk de bewerking die in de transformatiescollectie is opgeslagen waar schrijfbare leden bestaan; verwijder anders de bewerking en voeg een vervanging met nieuwe creatie‑parameters toe.

**Welk formaat moet ik gebruiken om een transformatieketen te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Het legacy‑PPT‑formaat kan het volledige DrawingML‑effectmodel niet weergeven, en gerenderde exportformaten behouden alleen het uiterlijk, niet de bewerkbare transformatiebewerkingen.