---
title: Verwaltung von Präsentationshintergründen in Python über Java
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/python-java/presentation-background/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für Python über Java festlegen, inklusive Code-Tipps zur Optimierung Ihrer Präsentationen."
---
## **Einführung**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt gleichzeitig für mehrere Folien) festlegen.

![PowerPoint background](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung gilt nur für die ausgewählte Folie.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/python-java/aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/) auf `Solid` .
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getsolidfillcolor) auf [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/) , um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine blaue einfarbige Farbe als Hintergrund für eine normale Folie festlegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Setze die Hintergrundfarbe der Folie auf Blau.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Speichere die Präsentation auf die Festplatte.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Einfarbigen Hintergrund für eine Masterfolie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für die Masterfolie in einer Präsentation festzulegen. Die Masterfolie fungiert als Vorlage, die die Formatierung für alle Folien steuert, sodass wenn Sie eine einfarbige Farbe für den Hintergrund der Masterfolie wählen, sie für jede Folie gilt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/python-java/aspose.slides/backgroundtype/) der Masterfolie (via [getMasters](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getmasters)) auf `OwnBackground` .
3. Setzen Sie den Hintergrund der Masterfolie [FillType](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/) auf `Solid` .
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getsolidfillcolor) , um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine einfarbige (grüne) Farbe als Hintergrund für eine Masterfolie festlegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Setze die Hintergrundfarbe der Masterfolie auf Grün.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Speichere die Präsentation auf die Festplatte.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verlaufshintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch einen allmählichen Farbwechsel entsteht. Als Folienhintergrund verwendet, können Verläufe Präsentationen künstlerischer und professioneller erscheinen lassen. Aspose.Slides ermöglicht es Ihnen, einen Farbverlauf als Hintergrund für Folien festzulegen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/python-java/aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/) auf `Gradient` .
4. Verwenden Sie die Methode [getGradientFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getgradientformat) auf [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/) , um Ihre bevorzugten Verlaufs‑Einstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine Farbverlauf‑Farbe als Hintergrund für eine Folie festlegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Wende einen Verlaufseffekt auf den Hintergrund an.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Füge die Verlaufsfarben hinzu. Ohne Verlaufsstopps fällt der Hintergrund auf eine Standard-Schwarz-zu-Weiß-Skala zurück.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Speichere die Präsentation auf die Festplatte.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ein Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und verlaufenden Füllungen ermöglicht Ihnen Aspose.Slides, Bilder als Folienhintergründe zu verwenden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/python-java/aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/) auf `Picture` .
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Methode [getPictureFillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getpicturefillformat) auf [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/) , um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Hintergrundbild-Eigenschaften festlegen.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Bild laden.
    image = Images.fromFile("Tulips.jpg")
    # Bild zur Bildsammlung der Präsentation hinzufügen.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Präsentation auf der Festplatte speichern.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das folgende Codebeispiel zeigt, wie Sie den Fülltyp des Hintergrunds auf ein gekacheltes Bild setzen und die Kachel‑Eigenschaften ändern:

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Bild für die Hintergrundfüllung festlegen.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Bildfüllmodus auf Kachel setzen und die Kacheleigenschaften anpassen.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Hinweis" %}}
Mehr lesen: [Tile Picture as Texture](/slides/de/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, damit der Inhalt der Folie besser hervorsticht. Der folgende Python‑Code zeigt, wie Sie die Transparenz für ein Folienhintergrund‑Bild ändern können:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Zum Beispiel.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Die Sammlung der Bildtransformationsoperationen abrufen.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Vorhandenen Transparenzeffekt mit festem Prozentsatz finden.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Den neuen Transparenzwert setzen.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Den Hintergrundwert einer Folie abrufen**

Aspose.Slides ermöglicht es Ihnen, die effektiven Hintergrundwerte einer Folie über die Methode [getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/background/#geteffective) auf [Background](https://reference.aspose.com/slides/de/python-java/aspose.slides/background/) abzurufen. Die zurückgegebenen Daten enthalten die effektiven Füll‑ und Effektformate.

Über die Methode [getBackground](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getbackground) der Klasse [BaseSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/) können Sie den Hintergrund einer Folie erhalten.

Das folgende Python‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie abrufen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Effektiven Hintergrund abrufen, unter Berücksichtigung von Master, Layout und Theme.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme‑/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird erneut vom entsprechenden [Layout](/slides/de/python-java/slide-layout/)/[Master](/slides/de/python-java/slide-master/) (also dem [Theme‑Hintergrund](/slides/de/python-java/presentation-theme/)) geerbt.

**Was passiert mit dem Hintergrund, wenn ich das Theme der Präsentation später ändere?**

Hat eine Folie eine eigene Füllung, bleibt diese unverändert. Wird der Hintergrund vom [Layout](/slides/de/python-java/slide-layout/)/[Master](/slides/de/python-java/slide-master/) geerbt, wird er aktualisiert, um dem [neuen Theme](/slides/de/python-java/presentation-theme/) zu entsprechen.