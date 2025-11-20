---
title: Verwalten von Präsentationshintergründen in Python
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/python-net/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- Einfarbige Farbe
- Verlaufsfarbe
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mithilfe von Aspose.Slides für Python via .NET festlegen, mit Code-Tipps, um Ihre Präsentationen zu verbessern."
---

## **Übersicht**

Einfarbige Farben, Farbverläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation – auch wenn die Präsentation eine Masterfolie verwendet. Die Änderung wirkt nur auf die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) auf `SOLID`.
4. Verwenden Sie die Eigenschaft `solid_fill_color` auf [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine blaue einfarbige Farbe als Hintergrund für eine normale Folie festlegen:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Setze die Hintergrundfarbe der Folie auf Blau.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Einfarbigen Hintergrund für die Masterfolie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Farbe als Hintergrund für die Masterfolie in einer Präsentation. Die Masterfolie wirkt als Vorlage, die die Formatierung aller Folien steuert, sodass ein einfarbiger Hintergrund für die Masterfolie auf jede Folie angewendet wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) der Masterfolie (via `masters`) auf `OWN_BACKGROUND`.
3. Setzen Sie den Masterfolien‑Hintergrund-[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) auf `SOLID`.
4. Verwenden Sie die Eigenschaft `solid_fill_color` auf [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine einfarbige (forest green) Farbe als Hintergrund für eine Masterfolie festlegen:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Setze die Hintergrundfarbe der Masterfolie auf Waldgrün.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Verlaufshintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch einen allmählichen Farbwechsel entsteht. Als Folienhintergrund verwendet, können Verläufe Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht das Festlegen einer Verlauffarbe als Hintergrund für Folien.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) auf `GRADIENT`.
4. Verwenden Sie die Eigenschaft `gradient_format` auf [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), um Ihre bevorzugten Verlaufeinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine Verlauffarbe als Hintergrund für eine Folie festlegen:
```python
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Wende einen Verlaufseffekt auf den Hintergrund an.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlaufs‑Füllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergründe.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) der Folie auf `OWN_BACKGROUND`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) auf `PICTURE`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Eigenschaft `picture_fill_format` auf [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:
```python
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Setze die Bildhintergrund-Eigenschaften.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Lade das Bild.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Füge das Bild zur Bildsammlung der Präsentation hinzu.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```


Das folgende Codebeispiel zeigt, wie Sie den Hintergrund‑Fülltyp auf ein gekacheltes Bild setzen und die Kachel‑Eigenschaften ändern:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Setze das Bild, das für die Hintergrundfüllung verwendet wird.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Setze den Bildfüllmodus auf Kachel und passe die Kacheleigenschaften an.
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

Weiterlesen: [**Kachelbild als Textur**](/slides/de/python-net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, damit der Inhalt der Folie besser zur Geltung kommt. Der folgende Python‑Code zeigt, wie Sie die Transparenz für ein Folien‑Hintergrundbild ändern:
```python
transparency_value = 30  # Zum Beispiel.

# Rufe die Sammlung der Bild-Transformationsoperationen ab.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Finde einen bestehenden Transparenzeffekt mit festem Prozentsatz.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Setze den neuen Transparenzwert.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```


## **Wert des Folienhintergrunds abrufen**

Aspose.Slides stellt die [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/)-Klasse zum Abrufen der effektiven Hintergrundwerte einer Folie bereit. Diese Klasse gibt das effektive [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) und [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) frei.

Mit der `background`‑Eigenschaft der [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)-Klasse können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende Python‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie abrufen:
```python
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Rufe den effektiven Hintergrund ab, wobei Master, Layout und Theme berücksichtigt werden.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```


## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme-/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom entsprechenden [Layout](/slides/de/python-net/slide-layout/)/[Master](/slides/de/python-net/slide-master/) übernommen (d. h. vom [Theme‑Hintergrund](/slides/de/python-net/presentation-theme/)).

**Was passiert mit dem Hintergrund, wenn ich später das Theme der Präsentation ändere?**

Wenn eine Folie ihre eigene Füllung hat, bleibt diese unverändert. Wenn der Hintergrund vom [Layout](/slides/de/python-net/slide-layout/)/[Master](/slides/de/python-net/slide-master/) geerbt wird, wird er aktualisiert, um dem [neuen Theme](/slides/de/python-net/presentation-theme/) zu entsprechen.