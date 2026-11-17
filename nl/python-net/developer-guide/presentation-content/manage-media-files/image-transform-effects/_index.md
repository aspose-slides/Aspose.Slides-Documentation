---
title: Beheer afbeeldingstransformatie‑effecten in presentaties met Python
linktitle: Afbeeldingstransformatie‑effecten
type: docs
weight: 11
url: /nl/python-net/image-transform-effects/
keywords:
- beeldtransformatie
- afbeeldingseffect
- helderheid
- contrast
- grijstint
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alfa‑effect
- effectketen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Pas afbeeldingstransformatie‑effecten toe, koppel ze, inspecteer, verwijder en verifieer ze voor afbeeldingframes met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides stelt afbeeldingsaanpassingen voor als een geordende collectie van beeldtransformatie‑operaties. Voor een afbeeldingframe begin je met het frame‑[Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) en krijg je toegang tot de eigenschap [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/). De geretourneerde [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) stelt je in staat om effecten toe te voegen, te doorlopen, te inspecteren, te verwijderen en te wissen zonder de oorspronkelijke afbeeldingsbytes opnieuw te schrijven.

Dit artikel toont een volledige workflow voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX‑round‑trip‑verificatie.

## **Begrijpen van effect‑eigendom en afbeelding‑hergebruik**

Een afbeeldingbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) slaat de bron‑afbeeldingsdata op of verwijst ernaar en behoort toe aan de presentatie.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) maakt deel uit van een afbeeldingsvulling en verwijst naar een afbeeldingbron terwijl het de beeldtransformatie‑collectie opslaat.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) is de slide‑vorm die de relevante afbeeldingsvulling, geometrie, bijsnij‑instellingen en andere frame‑niveau‑formattering bezit.

Daarom wijzigen beeldtransformatie‑operaties de bytes in [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) niet. Wanneer dezelfde `PPImage` meer dan één keer wordt doorgegeven aan [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/), ontvangt elk nieuw afbeeldingframe zijn eigen `Picture` en zijn eigen transformatie‑collectie. Het toepassen van grijstinten op één frame maakt de andere frames niet grijs, ook al gebruiken ze allemaal dezelfde ingebedde afbeeldingbron.

Hetzelfde `Picture.image_transform`‑model wordt ook gebruikt door andere afbeeldingsvullingen, zoals een vorm of slide‑achtergrond. De voorbeelden hieronder richten zich op afbeeldingframes.

## **Gebruik geldige parameterreeksen en eenheden**

De gedemonstreerde methoden gebruiken de volgende semantische reeksen en eenheden. Houd waarden binnen deze reeksen, zelfs als een bepaalde bibliotheekversie niet elke out‑of‑range‑waarde meteen afwijst; het doelformaat kan tijdens het opslaan of bij het openen in PowerPoint gegevens normaliseren, weglaten of afwijzen.

| Operation | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat het onderdeel ongewijzigd. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Geen numerieke parameters. Alfa blijft ongewijzigd. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfakanalen gebruiken `0` tot `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Tint (hue) is `0` inclusief tot `360` exclusief, in graden; hoeveelheid is `-100` tot `100`, procent. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Tint (hue) is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | De vervangende kleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfawaarden blijven ongewijzigd. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in points; `grow` is een Boolean die bepaalt of vervaagde inhoud buiten de oorspronkelijke grenzen mag uitsteken. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Niet‑negatief percentage. Gebruik `0` tot `100` voor normale opaciteits‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` tot `100`, procent opaciteit. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` tot `100`, procent alfa‑drempel. Waarden eronder worden transparant; waarden op of boven de drempel worden ondoorzichtig. |

Voor vaste alfamodulatie zijn transparantie en opaciteit complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfamodulatie‑waarde van 65 %.

## **Helderheid en contrast toepassen**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) retourneert een [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/)‑operatie. De scalare instellingen worden meegegeven bij het maken van de operatie. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) retourneert berekende alleen‑lezen waarden die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, en rendert vervolgens een preview zonder de ingebedde afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) is een Office 2010‑afbeeldingseffect‑extensie en minder draagbaar dan het standaard DrawingML‑luminantieveffect. Wanneer helderheid en contrast bewerkbaar moeten blijven na een PPTX‑round‑trip, gebruik dan [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) en verifieer het resultaat na het heropenen van het bestand. De sectie over format‑beperkingen legt dit onderscheid uitgebreider uit.

## **Kleurtransformaties toepassen**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeeldingframes die één afbeeldingbron hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijstinten, duotone, tint, HSL‑aanpassing en kleurvervanging toe.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` mappt donkere pixels, terwijl `color2` lichte pixels mappt. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele scalare waarde.

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

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) vervangt de kleur van elke pixel door één vaste kleur terwijl alfa wordt behouden. Het verschilt van [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), dat één bronkleur naar een andere mappt en zowel bron‑ als doelkleuropties exposeert.

### **Luminantiedrempel toepassen**

Een luminantiedrempel kan zwakke markeringen op een gescande pagina beter van de achtergrond onderscheiden. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) behoudt tussenliggende grijstinten. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) mappt luminantie naar zwart of wit, terwijl [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) een drempel op opaciteit toepast.

De luminantiedrempel varieert van 0 % tot 100 %, inclusief. Pixels onder de drempel worden zwart. Pixels op of boven de drempel worden wit. Het verhogen van de drempel maakt meer tinten zwart omdat meer ervan onder de cutoff vallen.

Download [grayscale-swatches.png](grayscale-swatches.png) naar de werkmap. Elke label geeft het oorspronkelijke grijsniveau weer op een schaal van 0 tot 255. Het voorbeeld plaatst het origineel naast twee kopieën en slaat de drempel van elke kopie op in de presentatie.

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

Open de output‑presentatie in PowerPoint om de drie frames te vergelijken. Het swatch‑label 96 heeft ongeveer 38 % luminantie (96 van de 255). Het wordt wit bij de 20 % drempel en zwart bij de 60 % drempel.

![Originele grijstinten naast de zwart‑witte resultaten bij luminantiedrempels van 20% en 60%](luminance-threshold.png)

## **Vervaag, transparantie en alfa‑effecten toevoegen**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) beïnvloedt alle kleurkanalen, inclusief alfa. Stel `grow` in op `True` wanneer de vervaagde rand buiten de oorspronkelijke afbeelding kan uitsteken.

Voor uniforme transparantie, gebruik [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Het vermenigvuldigt elke bestaande alfa‑waarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) kent in plaats daarvan één alfa‑waarde toe aan alle pixels. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) zet alfa om naar twee niveaus op basis van een drempel.

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

Andere parameter‑vrije alfabewerkingen omvatten [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), die elke niet‑nul alfa volledig ondoorzichtig maakt; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), die elke alfa onder 100 % volledig transparant maakt; en [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), die alfa verandert in `100% - alpha`.

## **Een geordende effectketen opbouwen**

Elke `add_..._effect`‑methode voegt een nieuwe operatie toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van operatie 0 wordt de input van operatie 1, enzovoort. Daardoor kan dezelfde reeks operaties in een andere volgorde een ander beeld opleveren.

Zo verwijdert grijstinten gevolgd door tint eerst chromatische informatie en kleurt vervolgens het luminantieresultaat opnieuw. Tint gevolgd door grijstinten verwijdert de tint weer. Evenzo kan een alfareplacement alfa‑waarden die door eerdere operaties zijn berekend overschrijven, terwijl alfamodulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de operatietypen als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alfa‑ en vervagingsoperaties tot aparte ketens beperkt. Ze kunnen gecombineerd worden, maar combinaties zijn niet altijd nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is geproduceerd; grijstinten na duotone verwijderen de twee geselecteerde kleuren; en alfa‑ceiling, floor, replacement of bi‑level‑operaties kunnen alfadetail die eerder is gecreëerd weggooien. Bouw de keten volgens de gewenste pixelverwerkingsvolgorde op in plaats van de items te behandelen als ongeordende formatteervlaggen.

<!-- visual-explanation:image-transform-effects:start -->
[![Dezelfde afbeelding gaat eerst door grijstinten en daarna tint, en vervolgens tint en daarna grijstinten. De twee uiteindelijke grijstint‑afbeeldingen hebben verschillende tinten.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
<!-- visual-explanation:image-transform-effects:end -->

## **Bewerkbare en effectieve waarden inspecteren**

Een bewerkbare operatie is het object dat is opgeslagen in `Picture.image_transform`. Afhankelijk van het effect kan het direct bewerkbare leden blootleggen. Bijvoorbeeld, [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) exposeert schrijfbare `radius`‑ en `grow`‑eigenschappen, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) exposeert een schrijfbare `amount`‑eigenschap, en [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) exposeert een schrijfbare `threshold`‑eigenschap. Kleureffecten zoals [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) exposen mutabele [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/)‑objecten.

Sommige operaties, waaronder [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/) en [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), exposen hun creatiescalaars niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanging toe op de gewenste positie.

Effectieve data die wordt geretourneerd door `get_effective()` is berekend en alleen‑lezen. Het is nuttig voor het oplossen van themagebonden kleuren en voor het lezen van de genormaliseerde waarden die de renderer gebruikt, maar het is geen extra bewerkingsoppervlak. Het volgende voorbeeld doorloopt de keten en inspecteert effectieve waarden waar de bijbehorende API ze aanbiedt:

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

Parameter‑vrije effecten zoals grijstinten, alfa‑ceiling en alfa‑inverse hebben nog steeds een effectieve‑databron, maar er zijn geen scalare instellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Beeldtransformaties verwijderen of wissen**

Gebruik [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) om één operatie op index te verwijderen. Omdat indexen na verwijdering verschuiven, zoek je eerst het doel en verwijder je het na het doorlopen. Gebruik `clear()` om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de afbeelding‑formattering. Het verwijdert, recomprimeert of wijzigt de hergebruikte [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑resource niet.

## **Overweeg presentatiesformaten en exportdoelen**

Beeldtransformaties komen voort uit DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie identieke draagbaarheid:

- Standaard DrawingML‑operaties zoals luminantie, grijstinten, duotone, tint, HSL, vervaging en gangbare alfa‑operaties hebben de grootste kans om een PPTX‑round‑trip te overleven. Open het gegenereerde bestand altijd opnieuw en inspecteer de collectie wanneer behoud vereist is.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑operatie. Het kan gebruikt worden voor in‑memory rendering, maar het is niet gegarandeerd dat het na opslaan en heropenen van PPTX als een bewerkbare `BrightnessContrast`‑operatie blijft bestaan. Geef de voorkeur aan [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan als PPT kan niet‑ondersteunde operaties weglaten, een keten reduceren tot een ondersteunde subset, of het uiterlijk benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Rendering naar PNG, JPEG, TIFF, PDF, SVG, HTML of een andere visuele output past de ondersteunde keten toe op het gerenderde uiterlijk. Die outputs bevatten geen bewerkbare `ImageTransformOperationCollection`; rasterformaten flattenen het resultaat tot pixels, en document‑ of vector‑exports slaan hun eigen weergave‑representatie op.
- Effecten maken een gelinkte afbeelding niet zelf‑voorzienend. Het renderen van een gelinkte afbeelding blijft afhankelijk van de beschikbaarheid van de gelinkte bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen anders renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisatie‑operaties gecombineerd worden. Voor kritieke output, test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Veranderen beeldtransformatie‑effecten de ingebedde afbeeldingsdata?**

Nee. De operaties behoren tot de `Picture` die door de afbeeldingsvulling wordt gebruikt. De onderliggende `PPImage`‑bytes blijven ongewijzigd.

**Zullen twee afbeeldingframes die dezelfde afbeelding hergebruiken dezelfde effecten delen?**

Nee. Het hergebruiken van een `PPImage` voorkomt dubbele afbeeldingsdata, maar elk afbeeldingframe heeft normaal gezien een afzonderlijk `Picture` en een eigen beeldtransformatie‑collectie.

**Kunnen kleur‑, vervagings‑ en alfadeffecten worden gecombineerd?**

Ja. De collectie accepteert ze in één geordende keten. Houd rekening met wat elke operatie doet met de output van de vorige, omdat vervangings‑ en drempeloperaties eerder kleur‑ of alfadeel kunnen weggooien.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data vertegenwoordigt berekende waarden die voor rendering worden gebruikt, inclusief opgezochte kleuren. Bewerk de operatie die in de transformatie‑collectie is opgeslagen waar schrijfbare leden bestaan; anders verwijder je deze en voeg je een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transformatiereeks te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Het legacy‑PPT‑formaat kan het volledige DrawingML‑effectmodel niet weergeven, en render‑exportformaten behouden alleen het uiterlijk, niet de bewerkbare transformatie‑operaties.