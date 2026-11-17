---
title: Bildtransformations-Effekte in Präsentationen mit Python verwalten
linktitle: Bildtransformations-Effekte
type: docs
weight: 11
url: /de/python-net/image-transform-effects/
keywords:
- Bildtransformation
- Bild-Effekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Tönung
- HSL
- Farbersatz
- Unschärfe
- Transparenz
- Alpha-Effekt
- Effektkette
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Anwenden, verketten, inspizieren, entfernen und verifizieren von Bildtransformations-Effekten für Bildrahmen mit Aspose.Slides für Python über .NET."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformationsoperationen dar. Für einen Bildrahmen beginnen Sie mit dem [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) des Rahmens und greifen auf dessen [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) Eigenschaft zu. Die zurückgegebene [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Löschen von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Workflow für Helligkeit und Kontrast, Farbtransformationen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, Entfernen und PPTX‑Rundtrip‑Verifizierung.

## **Verständnis von Effekt‑Eigentümerschaft und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie darstellt, sind unterschiedliche Objekte:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) speichert oder referenziert die Quellbilddaten, die zur Präsentation gehören.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformationssammlung speichert.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und andere Rahmen‑Formatierungen besitzt.

Daher ändern Bildtransformationsoperationen nicht die Bytes in [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). Wenn dasselbe `PPImage` mehrmals an [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `Picture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht zu Graustufen, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Das gleiche `Picture.image_transform`‑Modell wird auch von anderen Bildfüllungen verwendet, z. B. einer Form oder Folien‑Hintergrund. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwendung gültiger Parameterbereiche und Einheiten**

Die demonstrierten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie die Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden außerhalb des Bereichs liegenden Wert ablehnt; das Ziel‑Präsentationsformat kann ungültige Daten beim Speichern normalisieren, weglassen oder ablehnen, wenn PowerPoint die Datei öffnet.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle verwenden `0` bis `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Farbton ist `0` (inklusive) bis `360` (exklusiv) Grad; Betrag ist `-100` bis `100` Prozent. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Farbton ist `0` (inklusive) bis `360` (exklusiv) Grad; Sättigung und Luminanz sind `-100` bis `100` Prozent. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Radius ist nichtnegativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der steuert, ob unscharfer Inhalt über die ursprünglichen Grenzen hinaus erweitert werden darf. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Nichtnegatives Prozent. Verwenden Sie `0` bis `100` für die übliche Deckkraftskalierung: `0` ist vollständig transparent und `100` erhält das vorhandene Alpha. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` bis `100` Prozent Deckkraft. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` bis `100` Prozent Alpha‑Schwellenwert. Werte darunter werden transparent; Werte gleich oder darüber werden opa­k. |

Bei fester Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Zum Beispiel entspricht 35 % Transparenz einem Alpha‑Modulationswert von 65 %.

## **Helligkeit und Kontrast anwenden**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) gibt eine [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/)‑Operation zurück. Ihre skalar­en Einstellungen werden beim Erstellen der Operation übergeben. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) liefert berechnete schreibgeschützte Werte, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 % und rendert anschließend eine Vorschau, ohne das eingebettete Bild zu ändern:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Bildeffekt‑Erweiterung und weniger portabel als der standardmäßige DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einem PPTX‑Rundtrip editierbar bleiben müssen, verwenden Sie [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) und prüfen Sie das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt zu Formatbeschränkungen erklärt diesen Unterschied ausführlicher.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Tönung, HSL‑Anpassung und Farb­ersatz an.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) enthält zwei unabhängig editierbare Farbparameter: `color1` ordnet dunkle Pixel zu, während `color2` helle Pixel zuordnet. Das macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner skalarer Wert.

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

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) ersetzt die Farbe jedes Pixels durch eine feste Farbe und behält dabei das Alpha bei. Es unterscheidet sich von [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), das eine Quellfarbe in eine andere umwandelt und sowohl Quell‑ als auch Ziel­farbformate bereitstellt.

### **Luminanz‑Schwelle anwenden**

Eine Luminanz‑Schwelle kann schwache Markierungen auf einer gescannten Seite leichter vom Hintergrund unterscheiden. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) bewahrt Zwischentöne von Grau. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) ordnet die Luminanz Schwarz oder Weiß zu, während [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) eine Schwelle auf die Deckkraft anwendet.

Die Luminanz‑Schwelle reicht von 0 % bis 100 %, inklusive. Pixel unterhalb der Schwelle werden schwarz. Pixel bei oder über der Schwelle werden weiß. Das Anheben der Schwelle macht mehr Grautöne schwarz, weil mehr von ihnen unter den Grenzwert fallen.

Laden Sie [grayscale-swatches.png](grayscale-swatches.png) in das Arbeitsverzeichnis herunter. Jede Beschriftung gibt den ursprünglichen Grauwert auf einer Skala von 0 bis 255 an. Das Beispiel platziert das Original neben zwei Kopien und speichert die Schwelle jeder Kopie in der Präsentation.

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

Öffnen Sie die Ausgabepräsentation in PowerPoint, um die drei Rahmen zu vergleichen. Das Farbfeld mit der Beschriftung 96 hat etwa 38 % Luminanz (96 von 255). Es wird bei einer Schwelle von 20 % weiß und bei 60 % schwarz.

![Originale Graustufenfarbfelder neben den Schwarz‑Weiß‑Ergebnissen bei Luminanz‑Schwellen von 20 % und 60 %](luminance-threshold.png)

## **Unschärfe, Transparenz und Alpha‑Effekte hinzufügen**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) wirkt sich auf alle Farbkanäle, einschließlich Alpha, aus. Setzen Sie `grow` auf `True`, wenn die unscharfe Kante über die ursprünglichen Bildgrenzen hinausreichen kann.

Für einheitliche Transparenz verwenden Sie [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Es multipliziert jeden vorhandenen Alpha‑Wert, sodass halbtransparente Pixel proportional unterschiedlich bleiben. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) weist hingegen allen Pixeln einen Alpha‑Wert zu. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) wandelt Alpha in zwei Stufen basierend auf einer Schwelle um.

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

Weitere parameterfreie Alpha‑Operationen umfassen [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), das jedes von Null verschiedene Alpha vollständig undurchsichtig macht; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), das jedes Alpha unter 100 % vollständig transparent macht; und [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), das Alpha zu `100% - alpha` ändert.

## **Eine geordnete Effektkette erstellen**

Jede `add_..._effect`‑Methode fügt der Sammlung am Ende eine neue Operation hinzu. Der Renderer nutzt die Sammlung als geordnete Pipeline: Die Ausgabe von Operation 0 wird zum Eingang von Operation 1 und so weiter. Folglich kann dieselben Operationen in anderer Reihenfolge ein anderes Bild erzeugen.

Beispielsweise entfernt Graustufen gefolgt von Tönung zuerst chromatische Informationen und färbt dann das Luminanz‑Ergebnis um. Tönung gefolgt von Graustufen entfernt die Tönung erneut. Ebenso kann Alpha‑Ersetzung Alpha‑Werte, die von früheren Operationen berechnet wurden, überschreiben, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel erstellt eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geöffnete Ergebnis:

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

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Unschärfe‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, aber Kombinationen sind nicht immer sinnvoll. Ein fester Farb­ersatz entfernt RGB‑Variationen, die durch frühere Farbeffekte erzeugt wurden; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling-, Floor‑, Ersetzungs‑ oder Bi‑Level‑Operationen können Alpha‑Details, die zuvor erstellt wurden, verwerfen. Erstellen Sie die Kette gemäß der gewünschten Pixel‑Verarbeitungssequenz, anstatt ihre Elemente als ungeordnete Formatierungs‑Flags zu behandeln.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Editierbare und effektive Werte inspizieren**

Eine editierbare Operation ist das in `Picture.image_transform` gespeicherte Objekt. Je nach Effekt kann es direkt beschreibbare Member bereitstellen. Zum Beispiel stellt [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) die beschreibbaren Eigenschaften `radius` und `grow` bereit, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) stellt die beschreibbare Eigenschaft `amount` bereit, und [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) stellt die beschreibbare Eigenschaft `threshold` bereit. Farbeffekte wie [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) stellen veränderbare [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/)‑Objekte bereit.

Einige Operationen, darunter [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), und [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), stellen ihre Erstellungs‑Skalare nicht als beschreibbare Eigenschaften bereit. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der erforderlichen Position einen Ersatz hinzu.

Die von `get_effective()` zurückgegebenen effektiven Daten sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, jedoch keine weitere Bearbeitungsoberfläche. Das folgende Beispiel enumeriert die Kette und inspiziert effektive Werte, sofern die entsprechende API sie bereitstellt:

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

Parameterfreie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen weiterhin ein effektives Datenobjekt, jedoch gibt es keine skalaren Einstellungen zum Ausgeben. Ihre Existenz und Position in der Sammlung sind die relevanten Informationen.

## **Bildtransformierungen entfernen oder löschen**

Verwenden Sie [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/), um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach einer Entfernung verschieben, suchen Sie zunächst das Ziel und entfernen es nach der Aufzählung. Verwenden Sie `clear()` , um die gesamte Kette zu entfernen.

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

Das Entfernen oder Löschen von Transformierungen ändert nur die Bildformatierung. Es löscht, komprimiert nicht neu oder ändert die wiederverwendete [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑Ressource nicht.

## **Präsentationsformate und Exportziele berücksichtigen**

Bildtransformierungen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX hat nicht jede Operation die gleiche Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Tönung, HSL, Unschärfe und gängige Alpha‑Operationen haben die höchste Wahrscheinlichkeit, einen PPTX‑Rundtrip zu überstehen. Öffnen Sie die erzeugte Datei immer erneut und prüfen Sie die Sammlung, wenn die Bewahrung erforderlich ist.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und nicht die standardmäßige DrawingML‑Luminanz‑Operation. Sie kann für In‑Memory‑Rendering verwendet werden, aber es ist nicht garantiert, dass sie nach dem Speichern und erneuten Öffnen von PPTX als editierbare `BrightnessContrast`‑Operation erhalten bleibt. Verwenden Sie bevorzugt [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) für dauerhafte Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effektmodell. Das Speichern als PPT kann nicht unterstützte Operationen weglassen, eine Kette auf ein unterstütztes Teilset reduzieren oder das Aussehen approximieren. Verwenden Sie PPT nicht als Verifizierungsformat für eine komplexe editierbare Kette.
- Das Rendern zu PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Aussehen an. Diese Ausgaben enthalten keine editierbare `ImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑ oder Vektor‑Exportformate speichern ihre eigene Render‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Rundtrip als auch das endgültige Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion verwendet wird.

## **FAQ**

**Ändern Bildtransformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zum `Picture`, das für die Bildfüllung verwendet wird. Die zugrunde liegenden `PPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dasselbe Bild wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden eines `PPImage` verhindert doppelte Bilddaten, aber jeder Bildrahmen hat normalerweise ein separates `Picture` und eine eigene Bildtransformationssammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ausgang der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten stellen berechnete Werte dar, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformationssammlung gespeicherte Operation, wenn beschreibbare Member existieren; andernfalls entfernen Sie sie und fügen Sie einen Ersatz mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformationskette zu erhalten?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das alte PPT‑Format kann das vollständige DrawingML‑Effektmodell nicht darstellen, und gerenderte Exportformate bewahren das Aussehen, nicht jedoch editierbare Transformationsoperationen.