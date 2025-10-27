---
title: Verwalten von Präsentationshintergründen in Python
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/python-net/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- Volltonfarbe
- Verlauffarbe
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python via .NET festlegen, inklusive Code‑Tipps zur Verbesserung Ihrer Präsentationen."
---

## **Übersicht**

Volltonfarben, Verläufe und Bilder werden häufig als Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint background](powerpoint-background.png)

## **Festlegen eines Volltonfarb-Hintergrunds für eine normale Folie**

Aspose.Slides ermöglicht es Ihnen, eine Volltonfarbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung gilt nur für die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) des Folienhintergrunds auf `SOLID`.
4. Verwenden Sie die Eigenschaft `solid_fill_color` von [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), um die Volltonfarbe des Hintergrunds anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine blaue Volltonfarbe als Hintergrund für eine normale Folie festlegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set the background color of the slide to blue.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Save the presentation to disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen eines Volltonfarb-Hintergrunds für die Masterfolie**

Aspose.Slides ermöglicht es Ihnen, eine Volltonfarbe als Hintergrund für die Masterfolie einer Präsentation festzulegen. Die Masterfolie dient als Vorlage, die die Formatierung aller Folien steuert. Wenn Sie also eine Volltonfarbe für den Hintergrund der Masterfolie wählen, gilt sie für jede Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) der Masterfolie (über `masters`) auf `OWN_BACKGROUND`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) des Masterfolienhintergrunds auf `SOLID`.
4. Verwenden Sie die Eigenschaft `solid_fill_color` von [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), um die Volltonfarbe des Hintergrunds anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine Volltonfarbe (Waldgrün) als Hintergrund für die Masterfolie festlegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Set the background color for the Master slide to Forest Green.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Save the presentation to disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen eines Verlaufshintergrunds für eine Folie**

Ein Verlauf ist ein grafischer Effekt, der durch einen allmählichen Farbwechsel entsteht. Als Folienhintergrund können Verläufe Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht es Ihnen, eine Verlaufsfarbe als Hintergrund für Folien festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) des Folienhintergrunds auf `GRADIENT`.
4. Verwenden Sie die Eigenschaft `gradient_format` von [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), um Ihre gewünschten Verlaufseinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine Verlaufsfarbe als Hintergrund für eine Folie festlegen:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Apply a gradient effect to the background.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Save the presentation to disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Bild als Folienhintergrund festlegen**

Zusätzlich zu Vollton‑ und Verlaufsfüllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergrund.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) des Folienhintergrunds auf `PICTURE`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Eigenschaft `picture_fill_format` von [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set background image properties.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Add the image to the presentation's image collection.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Save the presentation to disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Das folgende Code‑Beispiel zeigt, wie Sie den Hintergrund‑Fülltyp auf ein gekacheltes Bild setzen und die Kachel‑Eigenschaften anpassen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Set the image used for the background fill.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Set the picture fill mode to Tile and adjust the tile properties.
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

Lesen Sie mehr: [**Tile Picture As Texture**](/slides/de/python-net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, damit der Inhalt der Folie besser hervorsticht. Der folgende Python‑Code zeigt, wie Sie die Transparenz eines Folienhintergrundbildes ändern:

```python
transparency_value = 30  # For example.

# Get the collection of picture transform operations.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Find an existing fixed-percentage transparency effect.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Set the new transparency value.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Den Hintergrundwert einer Folie abrufen**

Aspose.Slides stellt die Klasse [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) zur Verfügung, um die effektiven Hintergrundwerte einer Folie abzurufen. Diese Klasse gibt das effektive [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) und [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) zurück.

Über die `background`‑Eigenschaft der Klasse [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende Python‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie abrufen:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Retrieve the effective background, taking into account master, layout, and theme.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Themen‑/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom zugehörigen [Layout](/slides/de/python-net/slide-layout/)/[Master](/slides/de/python-net/slide-master/) übernommen (d. h. vom [Themen‑Hintergrund](/slides/de/python-net/presentation-theme/)).

**Was geschieht mit dem Hintergrund, wenn ich später das Thema der Präsentation ändere?**

Hat eine Folie ihre eigene Füllung, bleibt diese unverändert. Wird der Hintergrund vom [Layout](/slides/de/python-net/slide-layout/)/[Master](/slides/de/python-net/slide-master/) geerbt, wird er an das [neue Thema](/slides/de/python-net/presentation-theme/) angepasst.