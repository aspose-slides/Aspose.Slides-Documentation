---
title: Hantera presentationsbakgrunder i Python
linktitle: Bildbakgrund
type: docs
weight: 20
url: /sv/python-net/presentation-background/
keywords:
- presentationsbakgrund
- bildbakgrund
- solid färg
- gradientfärg
- bildbakgrund
- bakgrundstransparent
- bakgrundsegenskaper
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du sätter dynamiska bakgrunder i PowerPoint- och OpenDocument-filer med Aspose.Slides för Python via .NET, med kodtips för att förbättra dina presentationer."
---
## **Introduktion**

Solida färger, gradienter och bilder används ofta som bakgrund för bilder. Du kan ställa in bakgrunden för en **normal bild** (en enstaka bild) eller en **masterbild** (gäller för flera bilder samtidigt).

![PowerPoint-bakgrund](powerpoint-background.png)

## **Ställ in en solid färgbakgrund för en normal bild**

Aspose.Slides låter dig ange en solid färg som bakgrund för en specifik bild i en presentation—även om presentationen använder en masterbild. Ändringen gäller endast den valda bilden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/backgroundtype/) till `OWN_BACKGROUND`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `SOLID`.
4. Använd egenskapen `solid_fill_color` på [FillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/) för att ange den solida bakgrundsfärgen.
5. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du ställer in en blå solid färg som bakgrund för en normal bild:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ställ in bakgrundsfärgen på bilden till blå.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Spara presentationen till disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in en solid färgbakgrund för masterbilden**

Aspose.Slides låter dig ange en solid färg som bakgrund för masterbilden i en presentation. Masterbilden fungerar som en mall som styr formatering för alla bilder, så när du väljer en solid färg för masterbildens bakgrund gäller den för varje bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Ställ in masterbildens [BackgroundType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/backgroundtype/) (via `masters`) till `OWN_BACKGROUND`.
3. Ställ in masterbildens bakgrund [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `SOLID`.
4. Använd egenskapen `solid_fill_color` på [FillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/) för att ange den solida bakgrundsfärgen.
5. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du ställer in en solid färg (skoggrön) som bakgrund för en masterbild:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Ställ in bakgrundsfärgen för masterbilden till skogsgrön.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Spara presentationen till disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in en gradientbakgrund för en bild**

En gradient är en grafisk effekt som skapas av en gradvis färgförändring. När den används som bildbakgrund kan gradienter göra presentationer mer konstnärliga och professionella. Aspose.Slides låter dig ange en gradientfärg som bakgrund för bilder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/backgroundtype/) till `OWN_BACKGROUND`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `GRADIENT`.
4. Använd egenskapen `gradient_format` på [FillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/) för att konfigurera dina önskade gradientinställningar.
5. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du anger en gradientfärg som bakgrund för en bild:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Applicera en gradienteffekt på bakgrunden.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Spara presentationen till disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in en bild som bakgrund för en bild**

Förutom solida och gradientfyllningar låter Aspose.Slides dig använda bilder som bildbakgrunder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Ställ in bildens [BackgroundType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/backgroundtype/) till `OWN_BACKGROUND`.
3. Ställ in bildbakgrundens [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `PICTURE`.
4. Läs in bilden du vill använda som bildbakgrund.
5. Lägg till bilden i presentationens bildsamling.
6. Använd egenskapen `picture_fill_format` på [FillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/) för att tilldela bilden som bakgrund.
7. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du anger en bild som bakgrund för en bild:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ställ in bakgrundsbildens egenskaper.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Läs in bilden.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Lägg till bilden i presentationens bildsamling.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Spara presentationen till disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Följande kodexempel visar hur du ställer in bakgrundens fyllningstyp till en kaklad bild och modifierar kaklingsegenskaperna:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Ange bilden som används för bakgrundsfyllning.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Ange bildfyllningsläget till Kakla och justera kakleegenskaperna.
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
Läs mer: [**Kakelbild som textur**](/slides/sv/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ändra bakgrundsbildens transparens**

Du kanske vill justera transparensen för en bildbakgrund för att få bildens innehåll att framträda tydligare. Följande Python‑kod visar hur du ändrar transparensen för en bildbakgrund:

```python
transparency_value = 30  # Till exempel.

# Hämta samlingen av bildtransformationsoperationer.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Hitta en befintlig fast-procent transparenseffekt.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Ställ in det nya transparensvärdet.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Hämta bildens bakgrundsvärde**

Aspose.Slides tillhandahåller klassen [IBackgroundEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ibackgroundeffectivedata/) för att hämta en bilds effektiva bakgrundsvärden. Denna klass exponerar den effektiva [FillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/) och [EffectFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/effectformat/).

Genom att använda klassens [BaseSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/) `background`‑egenskap kan du erhålla den effektiva bakgrunden för en bild.

Följande Python‑exempel visar hur du får en bilds effektiva bakgrundsvärde:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Hämta den effektiva bakgrunden, med hänsyn till master, layout och tema.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **Vanliga frågor**

**Kan jag återställa en anpassad bakgrund och återställa temats/layoutebakgrund?**

Ja. Ta bort bildens anpassade fyllning så ärvs bakgrunden återigen från motsvarande [layout](/slides/sv/python-net/slide-layout/)/[master](/slides/sv/python-net/slide-master/) bild (dvs. [tema‑bakgrund](/slides/sv/python-net/presentation-theme/)).

**Vad händer med bakgrunden om jag ändrar presentationens tema senare?**

Om en bild har sin egen fyllning förblir den oförändrad. Om bakgrunden ärvs från [layout](/slides/sv/python-net/slide-layout/)/[master](/slides/sv/python-net/slide-master/) uppdateras den så att den matchar det [nya temat](/slides/sv/python-net/presentation-theme/).