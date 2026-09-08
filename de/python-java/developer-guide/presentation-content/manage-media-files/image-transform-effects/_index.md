---
title: Bildtransformation-Effekte in Präsentationen mit Python
linktitle: Bildtransformation-Effekte
type: docs
weight: 11
url: /de/python-java/image-transform-effects/
keywords:
- Bildtransformation
- Bildeffekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Farbton
- HSL
- Farbersetzung
- Unschärfe
- Transparenz
- Alpha-Effekt
- Effektkette
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Bildtransformations-Effekte für Bildrahmen mit Aspose.Slides für Python über Java anwenden, verketten, prüfen, entfernen und verifizieren."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformationsoperationen dar. Für einen Bildrahmen beginnen Sie mit dem Rahmen‑[Picture](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/) und greifen Sie auf [Picture.getImageTransform](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#getImageTransform) zu. Die zurückgegebene [ImageTransformOperationCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Prüfen, Entfernen und Löschen von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel zeigt einen vollständigen Workflow für Helligkeit und Kontrast, Farbtransformationen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, Entfernen und eine PPTX‑Round‑Trip‑Verifikation.

## **Verstehen von Effektbesitz und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) speichert oder referenziert die Quelldaten des Bildes, die der Präsentation gehören.
- [Picture](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformationssammlung speichert.
- [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und weitere rahmenbezogene Formatierungen besitzt.

Daher ändern Bildtransformationsoperationen die Bytes in [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) nicht. Wenn dasselbe `PPImage` mehr als einmal an [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addPictureFrame) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `Picture` und seine eigene Transformationssammlung. Die Anwendung von Graustufen auf einen Rahmen macht die anderen Rahmen nicht graustufig, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Dasselbe `Picture.getImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, etwa von einer Form‑ oder Folienhintergrundfüllung. Die folgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden Sie gültige Parameterbereiche und Einheiten**

Die gezeigten Methoden nutzen die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden außerhalb liegenden Wert ablehnt; das Ziel‑Präsentationsformat kann ungültige Daten beim Speichern normalisieren, weglassen oder ablehnen, oder PowerPoint kann die Datei beim Öffnen ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [addDuotoneEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle in `java.awt.Color` verwenden Werte von `0` bis `255`. |
| [addTintEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Farbton ist `0` inklusiv bis `360` exklusiv, in Grad; Betrag ist `-100` bis `100`, Prozent. |
| [addHSLEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Farbton ist `0` inklusiv bis `360` exklusiv, in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Bestehende Alpha‑Werte bleiben unverändert. |
| [addBlurEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Radius ist nichtnegativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der steuert, ob verschwommener Inhalt über die ursprünglichen Grenzen hinausgehen darf. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Nichtnegatives Prozent. Verwenden Sie `0` bis `100` für normale Deckkraftskalierung: `0` ist vollständig transparent und `100` erhält das vorhandene Alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` bis `100`, Prozent Deckkraft. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` bis `100`, Prozent Alpha‑Schwelle. Werte darunter werden transparent; Werte gleich oder darüber undurchsichtig. |

Für feste Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Beispiel: 35 % Transparenz entsprechen einer Alpha‑Modulationsmenge von 65 %.

## **Helligkeit und Kontrast anwenden**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) gibt eine [BrightnessContrast](https://reference.aspose.com/slides/de/python-java/aspose.slides/brightnesscontrast/)‑Operation zurück. Ihre skalaren Einstellungen werden beim Erzeugen der Operation übergeben. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/de/python-java/aspose.slides/brightnesscontrast/#getEffective) liefert berechnete schreibgeschützte Werte, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 %, danach wird eine Vorschau gerendert, ohne das eingebettete Bild zu ändern:

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

[BrightnessContrast](https://reference.aspose.com/slides/de/python-java/aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der standardisierte DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einem PPTX‑Round‑Trip editierbar bleiben müssen, verwenden Sie [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) und prüfen Sie das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt zu Format‑Beschränkungen erklärt diesen Unterschied ausführlicher.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erzeugt fünf Rahmen und wendet Graustufen, Duotone, Farbton, HSL‑Anpassung und Farbersetzung an.

[Duotone](https://reference.aspose.com/slides/de/python-java/aspose.slides/duotone/) enthält zwei unabhängig editierbare Farbparameter: `color1` ordnet dunklen Pixeln zu, `color2` ordnet hellen Pixeln zu. Das macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) ersetzt die Farbe jedes Pixels durch eine feste Farbe, wobei Alpha erhalten bleibt. Es unterscheidet sich von [addColorChangeEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), das eine Quellfarbe auf eine Ziel­farbe abbildet und beide Farbformate offenlegt.

## **Unschärfe, Transparenz und Alpha‑Effekte hinzufügen**

[addBlurEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) wirkt auf alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `True`, wenn die unscharfen Kanten über die ursprünglichen Bildgrenzen hinausreichen dürfen.

Für gleichmäßige Transparenz verwenden Sie [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Es multipliziert jeden vorhandenen Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) weist hingegen allen Pixeln denselben Alpha‑Wert zu. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) wandelt Alpha basierend auf einer Schwelle in zwei Stufen um.

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

Weitere parameter‑freie Alpha‑Operationen sind [addAlphaCeilingEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), das jedes nicht‑null Alpha vollständig undurchsichtig macht; [addAlphaFloorEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), das jedes Alpha unter 100 % vollständig transparent macht; und [addAlphaInverseEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), das Alpha zu `100% - alpha` ändert.

## **Eine geordnete Effektkette erstellen**

Jede `add...Effect`‑Methode hängt eine neue Operation an das Ende der Sammlung an. Der Renderer nutzt die Sammlung als geordnete Pipeline: Die Ausgabe von Operation 0 wird zur Eingabe von Operation 1 usw. Daher kann dieselben Operationen in anderer Reihenfolge unterschiedliche Bilder erzeugen.

Beispielsweise entfernt Graustufen gefolgt von Farbton zuerst chromatische Informationen und recoloriert dann das Luminanz‑Ergebnis. Farbton gefolgt von Graustufen entfernt den Farbton wieder. Ebenso kann Alpha‑Ersetzung Alpha‑Werte überschreiben, die durch frühere Operationen berechnet wurden, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geladene Ergebnis:

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

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Unschärfe‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, jedoch sind nicht alle Kombinationen sinnvoll. Eine feste Farbersetzung entfernt RGB‑Variationen, die frühere Farbeffekte erzeugt haben; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling, Floor, Replacement oder BiLevel können Alpha‑Details, die zuvor erstellt wurden, verwerfen. Bauen Sie die Kette nach der gewünschten Pixel‑Verarbeitungssequenz, nicht nach ungeordneten Formatierungs‑Flags.

## **Bearbeitbare und effektive Werte inspizieren**

Eine editierbare Operation ist das Objekt, das in `Picture.getImageTransform` gespeichert ist. Je nach Effekt kann es schreibbare Member direkt offenlegen. Beispielsweise offenbart [Blur](https://reference.aspose.com/slides/de/python-java/aspose.slides/blur/) die schreibbaren Werte `radius` und `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/de/python-java/aspose.slides/alphamodulatefixed/) einen schreibbaren `amount` und [AlphaBiLevel](https://reference.aspose.com/slides/de/python-java/aspose.slides/alphabilevel/) einen schreibbaren `threshold`. Farbeffekte wie [Duotone](https://reference.aspose.com/slides/de/python-java/aspose.slides/duotone/) geben veränderbare [ColorFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/colorformat/)‑Objekte zurück.

Einige Operationsklassen, darunter [BrightnessContrast](https://reference.aspose.com/slides/de/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/de/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/de/python-java/aspose.slides/tint/) und [AlphaReplace](https://reference.aspose.com/slides/de/python-java/aspose.slides/alphareplace/), stellen ihre Erstellungs‑Skalare nicht als schreibbare Eigenschaften zur Verfügung. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation ein.

Effektive Daten, die von `getEffective` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, stellen jedoch keine weitere Bearbeitungsoberfläche dar. Das folgende Beispiel enumeriert die Kette und inspiziert effektive Werte, sofern die entsprechende API sie bereitstellt:

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

Parameter‑freie Effekte wie Graustufen, Alpha Ceiling und Alpha Inverse besitzen ebenfalls ein effektives Datenobjekt, jedoch gibt es keine skalaren Einstellungen zum Ausgeben. Ihr Vorhandensein und ihre Position in der Sammlung sind die relevanten Informationen.

## **Bildtransformationen entfernen oder löschen**

Verwenden Sie [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#removeAt), um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach einer Entfernung verschieben, suchen Sie zuerst das Ziel und entfernen es nach dem Durchlaufen der Sammlung. Mit [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#clear) entfernen Sie die gesamte Kette.

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

Das Entfernen oder Löschen von Transformationen ändert nur die Bildformatierung. Es löscht, komprimiert oder verändert nicht die wiederverwendete [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)‑Ressource.

## **Präsentationsformate und Exportziele berücksichtigen**

Bildtransformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX hat nicht jede Operation dieselbe Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Farbton, HSL, Unschärfe und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Round‑Trip zu überstehen. Öffnen Sie die erzeugte Datei immer erneut und prüfen Sie die Sammlung, wenn die Erhaltung erforderlich ist.
- [BrightnessContrast](https://reference.aspose.com/slides/de/python-java/aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und nicht das Standard‑DrawingML‑Luminanz‑Feature. Es kann für In‑Memory‑Rendering verwendet werden, ist jedoch nicht garantiert, dass es nach dem Speichern und erneuten Öffnen von PPTX als editierbares [BrightnessContrast] erhalten bleibt. Nutzen Sie stattdessen [addLuminanceEffect](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) für dauerhafte Helligkeits‑ und Kontrasteinstellungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effektmodell. Beim Speichern nach PPT können nicht unterstützte Operationen weggelassen, die Kette auf ein unterstütztes Subset reduziert oder das Aussehen approximiert werden. Verwenden Sie PPT nicht als Verifikationsformat für eine komplexe editierbare Kette.
- Das Rendering zu PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Bild an. Diese Ausgaben enthalten keine editierbare `ImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑/Vektor‑Exporte speichern ihre eigene Rendering‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendering eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Round‑Trip als auch das finale Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion eingesetzt wird.

## **FAQ**

**Ändern Bildtransformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zum `Picture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `PPImage`‑Bytes bleiben unverändert.

**Teilen sich zwei Bildrahmen, die dieselbe Bildressource wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden eines `PPImage` vermeidet doppelte Bilddaten, aber jeder Bildrahmen besitzt normalerweise ein separates `Picture` und eine separate Transformationssammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformationssammlung gespeicherte Operation dort, wo schreibbare Member existieren; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erstellungs‑Parametern ein.

**Welches Format sollte ich verwenden, um eine Transformationskette zu erhalten?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das alte PPT‑Format kann das vollständige DrawingML‑Effektmodell nicht darstellen, und gerenderte Exportformate erhalten nur das Aussehen, nicht editierbare Transformations‑Operationen.