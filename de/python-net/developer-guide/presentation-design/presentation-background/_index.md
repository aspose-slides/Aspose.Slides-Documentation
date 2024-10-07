---
title: Präsentationshintergrund
type: docs
weight: 20
url: /python-net/presentation-background/
keywords: "PowerPoint-Hintergrund, Hintergrund festlegen, Python, Aspose.Slides für Python über .NET"
description: "Hintergrund in PowerPoint-Präsentation in Python festlegen"
---

Einfarbige Farben, Farbverläufe und Bilder werden häufig als Hintergrundbilder für Folien verwendet. Sie können den Hintergrund entweder für eine **normale Folie** (einzelne Folie) oder eine **Masterfolie** (mehrere Folien auf einmal) festlegen.

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Einfarbige Farbe als Hintergrund für normale Folie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen (auch wenn diese Präsentation eine Masterfolie enthält). Die Änderung des Hintergrunds betrifft nur die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) Enum für den Folienhintergrund auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) bereitgestellt wird, um eine einfarbige Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine einfarbige Farbe (blau) als Hintergrund für eine normale Folie festlegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation() as pres:
    # Setzt die Hintergrundfarbe für die erste ISlide auf Blau
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    # Schreibt die Präsentation auf die Festplatte
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Einfarbige Farbe als Hintergrund für Masterfolie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für die Masterfolie in einer Präsentation festzulegen. Die Masterfolie fungiert als Vorlage, die die Formatierungseinstellungen für alle Folien enthält und steuert. Daher wird, wenn Sie eine einfarbige Farbe als Hintergrund für die Masterfolie auswählen, dieser neue Hintergrund für alle Folien verwendet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) Enum für die Masterfolie (`Masters`) auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) Enum für den Masterfolienhintergrund auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) bereitgestellt wird, um eine einfarbige Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine einfarbige Farbe (tannen grün) als Hintergrund für eine Masterfolie in einer Präsentation festlegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation() as pres:
    # Setzt die Hintergrundfarbe für die Master ISlide auf Tannen Grün
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Schreibt die Präsentation auf die Festplatte
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Farbverlauf als Hintergrund für Folie festlegen**

Ein Farbverlauf ist ein grafischer Effekt, der auf einer allmählichen Farbänderung basiert. Farbverläufe, die als Hintergründe für Folien verwendet werden, verleihen Präsentationen ein künstlerisches und professionelles Aussehen. Aspose.Slides ermöglicht es Ihnen, eine Farbverlauf-Farbe als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) Enum für den Masterfolienhintergrund auf `Gradient`.
4. Verwenden Sie die [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) bereitgestellt wird, um Ihre bevorzugte Verlaufseinstellung anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine Farbverlauf-Farbe als Hintergrund für eine Folie festlegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # Wendet den Farbverlaufseffekt auf den Hintergrund an
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Schreibt die Präsentation auf die Festplatte
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bild als Hintergrund für Folie festlegen**

Neben einfarbigen Farben und Farbverläufen ermöglicht es Aspose.Slides auch, Bilder als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) Enum für den Masterfolienhintergrund auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) bereitgestellt wird, um das Bild als Hintergrund festzulegen.
7. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # Setzt die Bedingungen für das Hintergrundbild
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Lädt das Bild
    img = draw.Bitmap(path + "Tulips.jpg")

    # Fügt das Bild der Bildsammlung der Präsentation hinzu
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # Schreibt die Präsentation auf die Festplatte
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz eines Folienhintergrundbilds anpassen, um die Inhalte der Folie hervorzuheben. Dieser Python-Code zeigt Ihnen, wie Sie die Transparenz für ein Folienhintergrundbild ändern:

```python
transparencyValue = 30 # zum Beispiel

# Holt eine Sammlung von Bildtransformationsoperationen
imageTransform = pres.slides[0].background.fill_format.picture_fill_format.picture.image_transform

transparencyOperation = None
# Findet einen Transparenzeffekt mit festem Prozentsatz.
for operation in imageTransform:
    if type(operation) is slides.AlphaModulateFixed:
        transparencyOperation = operation
        break

# Setzt den neuen Transparenzwert.
if transparencyOperation is None:
    imageTransform.add_alpha_modulate_fixed_effect(100 - transparencyValue)
else:
    transparencyOperation.amount = (100 - transparencyValue)
```

## **Wert des Folienhintergrunds abrufen**

Aspose.Slides bietet die [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) Schnittstelle, um Ihnen zu ermöglichen, die effektiven Werte der Folienhintergründe abzurufen. Diese Schnittstelle enthält Informationen über das effektive [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) und das effektive [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties).

Mit der [Background](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/#properties) Eigenschaft der [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) Klasse können Sie den effektiven Wert für einen Folienhintergrund abrufen.

Dieser Python-Code zeigt Ihnen, wie Sie den effektiven Hintergrundwert einer Folie abrufen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("Füllfarbe: " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("Fülltyp: " + str(effBackground.fill_format.fill_type))
```