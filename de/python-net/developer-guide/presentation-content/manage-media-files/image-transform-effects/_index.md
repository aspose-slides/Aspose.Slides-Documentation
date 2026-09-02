---
title: Verwalten von Bildtransformations‑Effekten in Präsentationen mit Python
linktitle: Bildtransformations‑Effekte
type: docs
weight: 11
url: /de/python-net/image-transform-effects/
keywords:
- Bildtransformation
- Bildeffekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Farbton
- HSL
- Farbe​ersetzung
- Unschärfe
- Transparenz
- Alpha‑Effekt
- Effektkette
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Bildtransformations‑Effekte für Bildrahmen mit Aspose.Slides für Python via .NET anwenden, verketten, inspizieren, entfernen und verifizieren."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als eine geordnete Sammlung von Bildtransformations‑Operationen dar. Für einen Bildrahmen beginnen Sie mit dem **[Bild](https://reference.aspose.com/slides/de/python-net/aspose.slides/picture/)** des Rahmens und greifen auf dessen **[image_transform](https://reference.aspose.com/slides/de/python-net/aspose.slides/picture/image_transform/)**‑Eigenschaft zu. Die zurückgegebene **[ImageTransformOperationCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/effects/imagetransformoperationcollection/)** ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Leeren von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Arbeitsablauf für Helligkeit und Kontrast, Farbtransformationen, Unschärfe, Transparenz, geordnete Effektketten, effektive Werte, Entfernen und die PPTX‑Rundreise‑Verifikation.

## **Verständnis von Effektbesitz und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- **[PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)** speichert oder referenziert die Quelldaten des Bildes, die zur Präsentation gehören.
- **[Picture](https://reference.aspose.com/slides/de/python-net/aspose.slides/picture/)** gehört zu einer Bildfüllung, verweist auf eine Bildressource und enthält die Bildtransformations‑Sammlung.
- **[PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/)** ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Beschneidungseinstellungen und weitere rahmenspezifische Formatierungen besitzt.

Daher ändern Bildtransformations‑Operationen die Bytes in **[PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)** nicht. Wenn dasselbe `PPImage` mehr als einmal an **[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/)** übergeben wird, erhält jeder neue Bildrahmen sein eigenes `Picture` und seine eigene Transformations‑Sammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht graustufig, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Das gleiche **Picture.image_transform**‑Modell wird auch von anderen Bildfüllungen verwendet, etwa einer Form oder einem Folienhintergrund. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwendung gültiger Parameterbereiche und Einheiten**

Die demonstrierten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie die Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden Werte‑Außerhalb‑Bereich ablehnt; das Ziel‑Präsentationsformat kann ungültige Daten beim Speichern normalisieren, weglassen oder ablehnen, oder PowerPoint kann die Datei beim Öffnen ablehnen.

| Vorgang | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` belässt die Komponente unverändert. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [add_duotone_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle verwenden `0` bis `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Farbton ist `0` inkl. bis `360` excl., in Grad; Menge ist `-100` bis `100`, Prozent. |
| [add_hsl_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Farbton ist `0` inkl. bis `360` excl., in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [add_color_replace_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Bestehende Alpha‑Werte bleiben unverändert. |
| [add_blur_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Radius ist nicht negativ und wird in Punkt gemessen; `grow` ist ein Boolescher Wert, der steuert, ob verwischter Inhalt über die ursprünglichen Grenzen hinausreichen darf. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Nicht‑negative Prozentzahl. Verwenden Sie `0` bis `100` für gewöhnliche Opazitäts‑Skalierung: `0` ist völlig transparent und `100` erhält das bestehende Alpha. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` bis `100`, Prozent‑Opazität. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwelle. Werte darunter werden transparent; Werte darüber oder gleich werden undurchsichtig. |

Für feste Alpha‑Modulation sind Transparenz und Opazität komplementär. Beispiel: 35 % Transparenz entsprechen einer Alpha‑Modulations‑Menge von 65 %.

## **Anwenden von Helligkeit und Kontrast**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) liefert eine **[BrightnessContrast](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/brightnesscontrast/)**‑Operation. Ihre Skalar‑Einstellungen werden beim Erzeugen der Operation übergeben. **[BrightnessContrast.get_effective](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/brightnesscontrast/get_effective/)** gibt berechnete, nur‑lesbare Werte zurück, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 %, dann rendert es eine Vorschau, ohne das eingebettete Bild zu verändern:

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

[BrightnessContrast](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der standardmäßige DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einer PPTX‑Rundreise editierbar bleiben müssen, verwenden Sie **[ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/)** und prüfen Sie das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt *Formatbeschränkungen* erklärt diesen Unterschied ausführlicher.

## **Anwenden von Farbtransformationen**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Farbton, HSL‑Anpassung und Farbersetzung an.

**[Duotone](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/duotone/)** enthält zwei unabhängig editierbare Farbparameter: `color1` ordnet dunklen Pixeln zu, während `color2` hellen Pixeln zugeordnet wird. Damit ist es ein nützliches Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

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

[add_color_replace_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) ersetzt die Farbe jedes Pixels durch eine feste Farbe und erhält dabei den Alpha‑Wert. Das unterscheidet sich von **[add_color_change_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)**, das eine Quellfarbe einer Ziel­farbe zuordnet und beide Farbformate offenlegt.

## **Hinzufügen von Unschärfe, Transparenz und Alpha‑Effekten**

[add_blur_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) wirkt auf alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `True`, wenn die verwischte Kante über die ursprünglichen Bildgrenzen hinausragen kann.

Für einheitliche Transparenz verwenden Sie **[add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/)**. Dieser multipliziert jeden vorhandenen Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. **[add_alpha_replace_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/)** hingegen weist allen Pixeln denselben Alpha‑Wert zu. **[add_alpha_bi_level_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/)** wandelt Alpha anhand einer Schwelle in zwei Stufen um.

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

Weitere parameterfreie Alpha‑Operationen sind **[add_alpha_ceiling_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)** (macht jedes nicht‑null Alpha vollständig undurchsichtig), **[add_alpha_floor_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)** (macht jedes Alpha unter 100 % vollständig transparent) und **[add_alpha_inverse_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)** (setzt Alpha auf `100% - alpha`).

## **Erstellen einer geordneten Effektkette**

Jede **add_…_effect**‑Methode fügt am Ende der Sammlung eine neue Operation hinzu. Der Renderer nutzt die Sammlung als geordnete Pipeline: Der Ausgang von Operation 0 wird zum Eingang von Operation 1 usw. Folglich kann dieselbe Menge von Operationen in anderer Reihenfolge ein unterschiedliches Bild erzeugen.

Beispiel: Graustufen gefolgt von Farbton entfernt zunächst chromatische Informationen und färbt dann das Luminanz‑Ergebnis ein. Farbton gefolgt von Graustufen entfernt den Farbton erneut. Ebenso kann Alpha‑Ersetzung Alpha‑Werte überschreiben, die durch frühere Operationen berechnet wurden, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geöffnete Ergebnis:

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

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Unschärfe‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, wobei Kombinationen nicht immer sinnvoll sind. Eine feste Farbersetzung entfernt RGB‑Variationen, die durch frühere Farbeffekte erzeugt wurden; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling, Floor, Replacement oder Bi‑Level können Alpha‑Details verwerfen, die vorher erzeugt wurden. Bauen Sie die Kette entsprechend der gewünschten Pixel‑Verarbeitungs‑Sequenz, anstatt ihre Elemente als ungeordnete Formatierungs‑Flags zu behandeln.

## **Inspizieren editierbarer und effektiver Werte**

Eine editierbare Operation ist das in **Picture.image_transform** gespeicherte Objekt. Je nach Effekt kann es direkt schreibbare Member exponieren. Zum Beispiel exponiert **[Blur](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/blur/)** die schreibbaren Eigenschaften `radius` und `grow`, **[AlphaModulateFixed](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/alphamodulatefixed/)** die schreibbare Eigenschaft `amount` und **[AlphaBiLevel](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/alphabilevel/)** die schreibbare Eigenschaft `threshold`. Farbeffekte wie **[Duotone](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/duotone/)** exponieren veränderbare **[ColorFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/colorformat/)**‑Objekte.

Einige Operationen, darunter **[BrightnessContrast](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/brightnesscontrast/)**, **[HSL](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/hsl/)**, **[Tint](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/tint/)** und **[AlphaReplace](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/alphareplace/)**, geben ihre Erzeugungs‑Skalarwerte nicht als schreibbare Eigenschaften frei. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `get_effective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, stellen jedoch keine weitere Bearbeitungsoberfläche dar. Das folgende Beispiel enumeriert die Kette und inspiziert effektive Werte, sofern die entsprechende API sie bereitstellt:

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

Parameterfreie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein Effektiv‑Daten‑Objekt, jedoch gibt es keine skalaren Einstellungen zum Ausgeben. Ihre Präsenz und Position in der Sammlung sind die relevanten Informationen.

## **Entfernen oder Leeren von Bildtransformierungen**

Verwenden Sie **[ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/)**, um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach einem Entfernen verschieben, suchen Sie zuerst das Ziel und entfernen es nach dem Durchlauf. Verwenden Sie `clear()` um die gesamte Kette zu entfernen.

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

Das Entfernen oder Leeren von Transformierungen ändert nur die Bildformatierung. Es löscht, komprimiert oder verändert nicht die wiederverwendete **[PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)**‑Ressource.

## **Berücksichtigung von Präsentationsformaten und Exportzielen**

Bildtransformierungen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst mit PPTX hat nicht jede Operation identische Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Farbton, HSL, Unschärfe und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Rundtrip zu überstehen. Öffnen Sie die erzeugte Datei stets erneut und prüfen Sie die Sammlung, wenn die Erhaltung ein Muss ist.
- **[BrightnessContrast](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/brightnesscontrast/)** ist eine Office‑2010‑Erweiterung und nicht die standardmäßige DrawingML‑Luminanz‑Operation. Sie kann für In‑Memory‑Renderings verwendet werden, ist jedoch nicht garantiert als editierbare `BrightnessContrast`‑Operation nach dem Speichern und erneuten Öffnen von PPTX erhalten zu bleiben. Verwenden Sie lieber **[add_luminance_effect](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/)** für persistente Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effekt‑Modell. Beim Speichern nach PPT können nicht unterstützte Operationen weggelassen, die Kette auf ein unterstütztes Subset reduziert oder das Aussehen approximiert werden. Verwenden Sie PPT nicht als Verifikationsformat für eine komplexe editierbare Kette.
- Das Rendern zu PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare **ImageTransformOperationCollection**; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑ bzw. Vektor‑Exporte speichern ihre eigene Render‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, besonders wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Rundtrip als auch das endgültige Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion eingesetzt wird.

## **FAQ**

**Modifizieren Bildtransformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zum `Picture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `PPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dieselbe Bildressource wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden eines `PPImage` vermeidet doppelte Bilddaten, aber jeder Bildrahmen besitzt in der Regel ein separates `Picture` und eine eigene Transformations‑Sammlung.

**Können Farb‑, Unschärfe‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer einzigen geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ausgang der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die zum Rendern verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformations‑Sammlung gespeicherte Operation, sofern schreibbare Member existieren; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erzeugungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformations‑Kette zu erhalten?**

Verwenden Sie PPTX und verifizieren Sie die Datei, indem Sie sie erneut öffnen. Das ältere PPT‑Format kann das vollständige DrawingML‑Effekt‑Modell nicht darstellen, und gerenderte Exportformate erhalten nur das Aussehen, nicht die editierbaren Transformations‑Operationen.