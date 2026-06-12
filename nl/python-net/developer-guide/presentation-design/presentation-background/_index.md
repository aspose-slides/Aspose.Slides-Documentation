---
title: Beheer van presentatie-achtergronden in Python
linktitle: Dia-achtergrond
type: docs
weight: 20
url: /nl/python-net/presentation-background/
keywords:
- presentatie-achtergrond
- dia-achtergrond
- solide kleur
- verloopkleur
- afbeeldingsachtergrond
- achtergrondtransparantie
- achtergrondinstellingen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe je dynamische achtergronden instelt in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor Python via .NET, met code-tips om je presentaties te verbeteren."
---
## **Inleiding**

Solide kleuren, verlopen en afbeeldingen worden vaak gebruikt als dia‑achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (één enkele dia) of een **masterdia** (geldt voor meerdere dia’s tegelijk).

![PowerPoint-achtergrond](powerpoint-background.png)

## **Een solide kleurachtergrond instellen voor een normale dia**

Aspose.Slides stelt je in staat om een ​​solide kleur als achtergrond in te stellen voor een specifieke dia in een presentatie — zelfs als de presentatie een masterdia gebruikt. De wijziging geldt alleen voor de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/backgroundtype/) van de dia in op `OWN_BACKGROUND`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de dia‑achtergrond in op `SOLID`.
4. Gebruik de `solid_fill_color`‑eigenschap van [FillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/) om de solide achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

De volgende Python‑voorbeeld laat zien hoe je een blauwe solide kleur als achtergrond voor een normale dia instelt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Stel de achtergrondkleur van de dia in op blauw.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Sla de presentatie op naar schijf.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Een solide kleurachtergrond instellen voor de masterdia**

Aspose.Slides stelt je in staat om een ​​solide kleur als achtergrond voor de masterdia in een presentatie in te stellen. De masterdia fungeert als een sjabloon dat de opmaak voor alle dia’s bepaalt, zodat een gekozen solide kleur voor de achtergrond van de masterdia van toepassing is op elke dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/backgroundtype/) van de masterdia in (via `masters`) op `OWN_BACKGROUND`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de masterdia‑achtergrond in op `SOLID`.
4. Gebruik de `solid_fill_color`‑eigenschap van [FillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/) om de solide achtergrondkleur op te geven.
5. Sla de aangepaste presentatie op.

De volgende Python‑voorbeeld laat zien hoe je een solide kleur (bosgroen) als achtergrond voor de masterdia instelt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Stel de achtergrondkleur voor de masterdia in op bosgroen.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Sla de presentatie op naar schijf.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Een verlopen achtergrond instellen voor een dia**

Een verlopen is een grafisch effect dat ontstaat door een geleidelijke kleurschakeling. Als dia‑achtergrond kunnen verlopen presentaties een meer artistieke en professionele uitstraling geven. Aspose.Slides maakt het mogelijk om een ​​verlopen kleur als achtergrond voor dia’s in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/backgroundtype/) van de dia in op `OWN_BACKGROUND`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de dia‑achtergrond in op `GRADIENT`.
4. Gebruik de `gradient_format`‑eigenschap van [FillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/) om de gewenste verlopeninstellingen te configureren.
5. Sla de aangepaste presentatie op.

De volgende Python‑voorbeeld toont hoe je een verlopen kleur als achtergrond voor een dia instelt:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Pas een verloop effect toe op de achtergrond.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Sla de presentatie op naar schijf.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Een afbeelding als dia‑achtergrond instellen**

Naast solide en verlopen vullingen, kun je met Aspose.Slides afbeeldingen als dia‑achtergronden gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/backgroundtype/) van de dia in op `OWN_BACKGROUND`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de dia‑achtergrond in op `PICTURE`.
4. Laad de afbeelding die je wilt gebruiken als dia‑achtergrond.
5. Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
6. Gebruik de `picture_fill_format`‑eigenschap van [FillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de aangepaste presentatie op.

De volgende Python‑voorbeeld laat zien hoe je een afbeelding als achtergrond voor een dia instelt:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Stel de eigenschappen van de achtergrondafbeelding in.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Laad de afbeelding.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Sla de presentatie op naar schijf.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

De volgende code‑voorbeeld toont hoe je het vultype van de achtergrond instelt op een getegelde afbeelding en de tegel‑eigenschappen aanpast:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Stel de afbeelding in die wordt gebruikt voor de achtergrondvulling.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Stel de beeldvullingsmodus in op Tegel en pas de tegel eigenschappen aan.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}

Lees meer: [**Tile Picture As Texture**](/slides/nl/python-net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **De transparantie van de achtergrondafbeelding aanpassen**

Je wilt wellicht de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia beter naar voren komt. De volgende Python‑code laat zien hoe je de transparantie van een dia‑achtergrondafbeelding wijzigt:

```python
transparency_value = 30  # Bijvoorbeeld.

# Haal de collectie van picture transform operaties op.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Zoek een bestaand vaste-percentage transparantie-effect.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Stel de nieuwe transparatiewaarde in.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **De achtergrondwaarde van een dia ophalen**

Aspose.Slides biedt de [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ibackgroundeffectivedata/)‑klasse om de effectieve achtergrondwaarden van een dia op te halen. Deze klasse levert de effectieve [FillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/) en [EffectFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/effectformat/).

Via de `background`‑eigenschap van de [BaseSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/)‑klasse kun je de effectieve achtergrond van een dia verkrijgen.

De volgende Python‑voorbeeld toont hoe je de effectieve achtergrondwaarde van een dia ophaalt:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Haal de effectieve achtergrond op, rekening houdend met master, layout en thema.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Kan ik een aangepaste achtergrond resetten en het thema/lay‑out‑achtergrond herstellen?**

Ja. Verwijder de aangepaste vulling van de dia, dan wordt de achtergrond weer geërfd van de overeenkomstige [layout](/slides/nl/python-net/slide-layout/)/[master](/slides/nl/python-net/slide-master/)‑dia (d.w.z. de [themabackground](/slides/nl/python-net/presentation-theme/)).

**Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?**

Heeft een dia een eigen vulling, dan blijft deze ongewijzigd. Als de achtergrond wordt geërfd van de [layout](/slides/nl/python-net/slide-layout/)/[master](/slides/nl/python-net/slide-master/), dan past deze zich aan op het [nieuwe thema](/slides/nl/python-net/presentation-theme/).