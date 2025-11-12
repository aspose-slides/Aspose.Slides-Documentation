---
title: "Verwalten von Präsentationshintergründen in Python"
linktitle: "Folienhintergrund"
type: docs
weight: 20
url: /de/python-net/presentation-background/
keywords:
- "Präsentationshintergrund"
- "Folienhintergrund"
- "Einfarbige Farbe"
- "Verlaufsfarbe"
- "Bildhintergrund"
- "Hintergrundtransparenz"
- "Hintergrundeigenschaften"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python über .NET festlegen, inklusive Code-Tipps zur Verbesserung Ihrer Präsentationen."
---

## **Übersicht**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides erlaubt es, eine einfarbige Hintergrundfarbe für eine bestimmte Folie in einer Präsentation festzulegen – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung gilt nur für die ausgewählte Folie.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Setzen Sie den [BackgroundType] der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den [FillType] des Folienhintergrunds auf `SOLID`.
4. Verwenden Sie die Eigenschaft `solid_fill_color` von [FillFormat], um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine blaue einfarbige Hintergrundfarbe für eine normale Folie festlegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellen einer Instanz der Presentation‑Klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Setzen der Hintergrundfarbe der Folie auf Blau.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Speichern der Präsentation auf dem Datenträger.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Einfarbigen Hintergrund für die Masterfolie festlegen**

Aspose.Slides erlaubt es, eine einfarbige Hintergrundfarbe für die Masterfolie einer Präsentation festzulegen. Die Masterfolie dient als Vorlage, die die Formatierung aller Folien steuert, sodass eine einfarbige Hintergrundfarbe der Masterfolie auf jeder Folie erscheint.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Setzen Sie den [BackgroundType] der Masterfolie (via `masters`) auf `OWN_BACKGROUND`.
3. Setzen Sie den [FillType] des Masterfolien‑Hintergrunds auf `SOLID`.
4. Verwenden Sie die Eigenschaft `solid_fill_color` von [FillFormat], um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine einfarbige Hintergrundfarbe (Waldgrün) für eine Masterfolie festlegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellen einer Instanz der Presentation‑Klasse.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Setzen der Hintergrundfarbe der Masterfolie auf Waldgrün.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Speichern der Präsentation auf dem Datenträger.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Verlaufs‑Hintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch einen allmählichen Farbwechsel entsteht. Als Folienhintergrund können Verläufe Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht das Festlegen eines Verlaufs als Hintergrund für Folien.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Setzen Sie den [BackgroundType] der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den [FillType] des Folienhintergrunds auf `GRADIENT`.
4. Verwenden Sie die Eigenschaft `gradient_format` von [FillFormat], um Ihre gewünschten Verlaufseinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie einen Farbverlauf als Hintergrund für eine Folie festlegen:

```python
import aspose.slides as slides

# Erzeugen einer Instanz der Presentation‑Klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Anwenden eines Farbverlaufs‑Effekts auf den Hintergrund.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Speichern der Präsentation auf dem Datenträger.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und verlaufsbasierten Füllungen erlaubt Aspose.Slides die Verwendung von Bildern als Folienhintergründe.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Setzen Sie den [BackgroundType] der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den [FillType] des Folienhintergrunds auf `PICTURE`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Eigenschaft `picture_fill_format` von [FillFormat], um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```python
import aspose.slides as slides

# Erstellen einer Instanz der Presentation‑Klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Festlegen der Hintergrund‑Bildeigenschaften.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Bild laden.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Bild zur Bildsammlung der Präsentation hinzufügen.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Speichern der Präsentation auf dem Datenträger.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Das folgende Code‑Beispiel zeigt, wie Sie den Hintergrund‑Fülltyp auf ein gekacheltes Bild setzen und die Kacheleigenschaften anpassen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Bild festlegen, das für die Hintergrundfüllung verwendet wird.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Den Bildfüllmodus auf Kachel setzen und die Kacheleigenschaften anpassen.
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
Mehr erfahren: [**Kachelbild als Textur**](/slides/de/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Sie möchten möglicherweise die Transparenz eines Folienhintergrundbildes anpassen, damit der Inhalt der Folie besser zur Geltung kommt. Der folgende Python‑Code zeigt, wie Sie die Transparenz eines Folienhintergrundbildes ändern:

```python
transparency_value = 30  # Zum Beispiel.

# Bild‑Transformations‑Operationen sammeln.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Vorhandenen Transparenzeffekt mit fester Prozentzahl finden.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Neuen Transparenzwert festlegen.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Wert des Folienhintergrunds abrufen**

Aspose.Slides stellt die Klasse [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) bereit, um die effektiven Hintergrundwerte einer Folie abzurufen. Diese Klasse gibt das effektive [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) und [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) zurück.

Über die `background`‑Eigenschaft der Klasse [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende Python‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie erhalten:

```python
import aspose.slides as slides

# Erstellen einer Instanz der Presentation‑Klasse.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Abrufen des effektiven Hintergrunds unter Berücksichtigung von Master, Layout und Thema.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme-/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom jeweiligen [layout](/slides/de/python-net/slide-layout/)/[master](/slides/de/python-net/slide-master/) (d.h. dem [theme background](/slides/de/python-net/presentation-theme/)) übernommen.

**Was passiert mit dem Hintergrund, wenn ich später das Theme der Präsentation ändere?**

Wenn eine Folie eine eigene Füllung hat, bleibt diese unverändert. Wird der Hintergrund vom [layout](/slides/de/python-net/slide-layout/)/[master](/slides/de/python-net/slide-master/) übernommen, wird er an das [new theme](/slides/de/python-net/presentation-theme/) angepasst.