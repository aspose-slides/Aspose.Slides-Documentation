---
title: Verwalten von Bildrahmen in Präsentationen mit Python
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/python-net/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- eingebettetes Bild
- verknüpftes Bild
- Bild extrahieren
- Rasterbild
- SVG-Bild
- Bild zuschneiden
- Beschnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmenformatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: Erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren von Bildrahmen in Präsentationen mit Aspose.Slides für Python über .NET.
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die das Bild darstellt, getrennte Objekte: Eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/), während ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) die Position, Größe, Linienformatierung, Drehung, Zuschnitt, Bildeffekte und weitere rahmenbezogene Einstellungen steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehr als einmal angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können außerdem auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Hinzufügen und Formatieren eines eingebetteten Bildes**

Für ein eingebettetes Bild fügen Sie die Bilddaten zur Präsentation hinzu und erstellen einen Bildrahmen mit [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen in den nativen Abmessungen des Bildes und wendet Linienformatierung und Drehung an:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Der Bildrahmen steuert die angezeigte Geometrie; die Änderung der Rahmen­größe ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später beschnitten oder komprimiert wird.

## **Verwendung relativer Skalierung**

[PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) stellt [relative_scale_width](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/relative_scale_width/) und [relative_scale_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/relative_scale_height/) für den Rahmen bereit. Ein Wert von `1.0` entspricht 100 % der ursprünglichen Bildgröße. Relative Skalierung ist nützlich, wenn ein Workflow die Beziehung zur Quellbildgröße erhalten soll, anstatt die Endabmessungen manuell zu berechnen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie resampelt oder komprimiert das eingebettete Bild nicht.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert einen externen Pfad über den [Picture](https://reference.aspose.com/slides/de/python-net/aspose.slides/picture/)-Link, anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können den Datenumfang der PPTX reduzieren, bringen jedoch eine externe Abhängigkeit mit sich. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, erreichbar bleiben. Ändert sich der Pfad, wird die Datei verschoben oder die Ressource ist nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail verschickt, archiviert oder in isolierten Umgebungen gerendert werden sollen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Hinzufügen eines verknüpften Bildes**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich das Verknüpfen von Bildern; das Verknüpfen von Videos ist ein separater Medien‑Workflow und wird hier bewusst nicht gemischt.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Verwenden Sie Verknüpfungen, wenn die externe Dateiverwaltung beabsichtigt ist. Nutzen Sie sie nicht bloß als Ersatz für Kompression: Eine kleine PPTX mit defekten Bildabhängigkeiten ist meist weniger nützlich als eine größere, eigenständige Präsentation.

## **Extrahieren von Bildern aus Bildrahmen**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob die Form tatsächlich ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Extrahieren eines Rasterbildes**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) direkt. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Das Speichern über [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die im Präsentationspaket gespeicherten codierten Bytes benötigen statt einer konvertierten Rasterdatei, verwenden Sie stattdessen die Eigenschaft [PPImage.binary_data](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/binary_data/).

### **Extrahieren eines SVG‑Bildes**

Für ein SVG‑Bild stellt [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) ein [SvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Das Beibehalten von SVG‑Inhalt als SVG bewahrt die Vektor‑Quelle innerhalb der Präsentation. Rasterexporte wie PNG oder JPEG rendern diesen Vektorinhalt notwendigerweise zu Pixeln. PDF‑ oder SVG‑Folienexporte sind ebenfalls Render‑Operationen, sodass die exportierten Grafiken nicht als exakte Kopie des ursprünglichen eingebetteten SVG betrachtet werden sollten; verwenden Sie das eingebettete [SvgImage.svg_data](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/svg_data/), wenn die originale Vektor‑Ressource selbst benötigt wird.

## **Zuschneiden eines Bildes**

Zuschneiden ändert, welcher Bildteil im Rahmen sichtbar ist. Die Zuschneidewerte auf [PictureFillFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/) sind Prozentsätze der Quellbildabmessungen. Zuschneiden entfernt die ausgeblendeten Pixel des eingebetteten Bildes zunächst nicht; es ändert nur den sichtbaren Bereich.

Das folgende Beispiel findet einen Bildrahmen sicher und wendet Zuschneidewerte an:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Da die ausgeblendeten Bilddaten weiterhin vorhanden sind, können die Zuschneidewerte später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Rückgängigmachbarkeit, können die zugeschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Entfernen zugeschnittener Bilddaten**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) entfernt Bilddaten außerhalb des aktuellen Zuschneiderahmens und gibt die resultierende Bildressource zurück. Dies kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel nicht mehr für ein späteres „Uncrop“ zur Verfügung.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Die Methode kann der Präsentation eine neue Bildressource hinzufügen. Wird das ursprüngliche Bild zudem von anderen Bildrahmen verwendet, benötigen diese weiterhin ihre bestehende Ressource, sodass das Löschen zugeschnittener Bereiche nicht zwangsläufig die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das Ergebnis zu PNG.

## **Komprimieren von Rasterbildern**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/compress_image/) reduziert die Rasterbildauflösung relativ zu der Größe, in der das Bild angezeigt wird. Es kann zudem zugeschnittene Bereiche im selben Vorgang entfernen. Die Methode gibt `True` zurück, wenn das Bild skaliert oder zugeschnitten wurde, und `False`, wenn keine Änderung nötig war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/picturescompression/)-Wert, wenn eine standardisierte Zielauflösung ausreicht:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Statt eines Enum‑Werts kann ein benutzerdefinierter positiver DPI‑Wert übergeben werden, wenn ein konkretes Ziel erforderlich ist.

Kompression ist für Rasterbilder vorgesehen. SVG‑ und Metafile‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie außerdem daran, dass niedrigere Auflösung und gelöschte zugeschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie die Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich betrachtet oder exportiert wird, anstatt global die niedrigste DPI zu verwenden.

## **Untersuchen von Bildeffekten**

Bildeffekte werden auf dem Bild gespeichert, das vom Rahmen verwendet wird. Die Bild‑Transformationssammlung kann Effekte wie feste Alphamodulation für Transparenz und Luminanz für Helligkeit und Kontrast enthalten. Das folgende Beispiel liest beide Effektarten sicher vom ersten Bildrahmen einer Folie aus:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/alphamodulatefixed/) und [Luminance](https://reference.aspose.com/slides/de/python-net/aspose.slides.effects/luminance/) ändern die Darstellung des Bildes im Rahmen; sie überschreiben nicht die ursprünglichen eingebetteten Bildbytes.

## **Sperren der Geometrie des Bildrahmens**

Die [PictureFrameLock](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframelock/)-Einstellungen steuern, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Beispielsweise bewahrt die Eigenschaft [aspect_ratio_locked](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) die Proportionen der Form, wenn sie skaliert wird.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Die Sperre gilt für die Form des Bildrahmens. Sie zwingt das Quellbild nicht zu einer Resampling‑ oder permanenten Änderung des Seitenverhältnisses.

## **Anpassen der StretchOffset‑Werte**

Wenn der Bildfüllmodus „stretch“ (Dehnen) ist, definieren die Stretch‑Offset‑Werte auf [PictureFillFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Innenabstand vom Rand, während negative Prozentsätze einen Außenabstand erzeugen.

Das unterscheidet sich vom Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gedehnt wird.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie die Zuschneideeigenschaften, wenn das Ziel darin besteht, Bildrandbereiche zu verbergen.

## **Speicherung, Dateigröße und Exportüberlegungen**

Die wichtigsten Kompromisse lassen sich besser managen, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt behandelt werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, aber große Rasterbilder erhöhen die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, jedoch hängt die Präsentation von externen Dateien ab, die an den gespeicherten Pfaden oder Standorten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die verborgenen Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei zu großen Rasterbildern erheblich reduzieren, geht jedoch zulasten der Quellauflösung. Sie sollte erst angewendet werden, wenn die beabsichtigte Größe auf der Folie bekannt ist.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektortreue wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folienexporte konvertieren immer die gerenderte Folie zu Pixeln.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)-Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Präsentations‑Workflow zu laden.

Bei großen Präsentationen ist die Bildoptimierung in der Regel am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektor‑Inhalt behalten, Fotos entsprechend ihrer tatsächlichen Anzeigegröße komprimieren, zugeschnittene Pixel nur entfernen, wenn eine spätere Bearbeitung nicht mehr nötig ist, und externe Links nur verwenden, wenn das Abhängigkeits‑Management Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) repräsentiert eine Bildressource, die der Präsentation zugeordnet ist. Ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie sowie Formatierung wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern der Bilddateien aus der PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Reduziert Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneideinstellungen verbergen Bildteile, behalten jedoch die zugrunde liegenden Pixel. Verwenden Sie [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) oder Bildkompression mit Entfernung zugeschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden dürfen.

**Kann ich die Bildqualität nach einer Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen zugeschnittener Bereiche verwirft Bilddaten. Bewahren Sie das Originalbild außerhalb der Präsentation auf, wenn später hochauflösend bearbeitet werden muss.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalt als SVG, wenn die Vektortreue wichtig ist. Das eingebettete [SvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Member verwenden. `isinstance(shape, slides.PictureFrame)` vermeidet ungültige Casts und ermöglicht es dem Code, Folien zu verarbeiten, die keinen Bildrahmen enthalten.