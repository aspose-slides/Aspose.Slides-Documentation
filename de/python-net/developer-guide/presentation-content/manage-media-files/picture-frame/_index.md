---
title: Bildrahmen in Präsentationen mit Python verwalten
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
- Zugechnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmen-Formatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Bildrahmen in Präsentationen erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren mit Aspose.Slides für Python über .NET."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die das Bild darstellt, separate Objekte: Eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/), während ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) die Position, Größe, Linienformatierung, Drehung, Beschnitt, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehrmals angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) und verwenden Sie diese Bildressource beim Erzeugen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können außerdem auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, daher ist es sinnvoll, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Einbetten und Formatieren eines Bildes**

Für ein eingebettetes Bild fügen Sie die Bilddaten der Präsentation hinzu und erstellen einen Bildrahmen mit [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbstständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen in den nativen Abmessungen des Bildes und wendet Linienformatierung sowie Rotation an:

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

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmen­größe ändert nicht die ursprünglichen Pixeldimensionen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird später beim Beschneiden oder Komprimieren eines Bildes wichtig.

## **Relative Skalierung verwenden**

[PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) stellt [relative_scale_width](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/relative_scale_width/) und [relative_scale_height](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/relative_scale_height/) für den Rahmen bereit. Ein Wert von `1.0` entspricht 100 % der Originalgröße des Bildes. Relative Skalierung ist nützlich, wenn ein Workflow die Beziehung zur Originalbildgröße erhalten soll, anstatt die endgültigen Abmessungen manuell zu berechnen.

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

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist damit die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert über den [Picture](https://reference.aspose.com/slides/de/python-net/aspose.slides/picture/) Link‑Pfad einen externen Speicherort, anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die im PPTX gespeicherte Datenmenge reduzieren, führen jedoch zu einer externen Abhängigkeit. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, zugänglich bleiben. Ändert sich der Pfad, wird die Datei verschoben oder die Ressource ist nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail verschickt, archiviert oder in isolierten Umgebungen gerendert werden müssen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich das Verknüpfen von Bildern; das Verknüpfen von Videos ist ein separater Medien‑Workflow und wird in diesem Beispiel bewusst nicht gemischt.

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

Verwenden Sie Links, wenn ein externes Dateimanagement beabsichtigt ist. Nutzen Sie sie nicht nur als Ersatz für Kompression: ein kleines PPTX mit defekten Bildabhängigkeiten ist meist weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor ein Bild aus einer vorhandenen Präsentation extrahiert wird, prüfen Sie, ob eine Form tatsächlich ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Rasterbild extrahieren**

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

Das Speichern über [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) konvertiert das extrahierte Bild in das angeforderte Ausgabeformat. Wenn Sie die codierten Bytes benötigen, die in der Präsentation gespeichert sind, anstatt einer konvertierten Rasterdatei, verwenden Sie stattdessen die Eigenschaft [PPImage.binary_data](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/binary_data/).

### **SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) ein [SvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

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

SVG‑Inhalt als SVG zu erhalten bewahrt die Vektorquelle innerhalb der Präsentation. Raster‑Exporte wie PNG oder JPEG rendern diesen Vektorinhalt zwangsläufig zu Pixeln. PDF‑ oder SVG‑Folien‑Export ist ebenfalls ein Rendering‑Vorgang, sodass die exportierten Grafiken nicht als exakte Kopie des original eingebetteten SVG betrachtet werden sollten; verwenden Sie das eingebettete [SvgImage.svg_data](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/svg_data/), wenn die ursprüngliche Vektorressource selbst benötigt wird.

## **Ein Bild zuschneiden**

Das Zuschneiden ändert, welcher Bildteil im Rahmen sichtbar ist. Die Zuschneide‑Werte auf [PictureFillFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/) sind Prozentsätze der Abmessungen des Quellbildes. Das Zuschneiden löscht die verborgenen Pixel des eingebetteten Bildes zunächst nicht; es ändert nur den sichtbaren Bereich.

Das folgende Beispiel findet sicher einen Bildrahmen und wendet Zuschneide‑Werte an:

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

Da die verborgenen Bilddaten weiterhin vorhanden sind, kann der Zuschnitt später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Wiederherstellbarkeit, können die beschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) entfernt Bilddaten außerhalb des aktuellen Zuschnitts‑Rechtecks und gibt die resultierende Bildressource zurück. Das kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel für ein späteres Aufheben des Zuschnitts nicht mehr zur Verfügung.

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

Die Methode kann der Präsentation eine neue Bildressource hinzufügen. Wird das Originalbild auch von anderen Bildrahmen verwendet, benötigen diese weiterhin ihre bestehende Ressource, sodass das Löschen von zugeschnittenen Bereichen nicht zwangsläufig die Gesamtzahl der Bilder reduziert. Das Beschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rasterisiert das Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/compress_image/) reduziert die Auflösung von Rasterbildern im Verhältnis zur Größe, in der das Bild angezeigt wird. Es kann dabei auch zugeschnittene Regionen entfernen. Die Methode liefert `True`, wenn das Bild skaliert oder beschnitten wurde, und `False`, wenn keine Änderung nötig war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/picturescompression/)‑Wert, wenn eine Standard‑Zielauflösung ausreicht:

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

Kompression ist für Rasterbilder gedacht. SVG‑ und Metadatei‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie auch daran, dass eine niedrigere Auflösung und gelöschte zugeschnittene Regionen nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich angezeigt oder exportiert wird, anstatt global die niedrigste DPI anzuwenden.

## **Bild-Transformations‑Effekte verwalten**

Für einen vollständigen Workflow, der Helligkeit, Kontrast, Farbtransformationen, Weichzeichnen, Alpha‑Effekte, geordnete Ketten, Inspektion, Entfernung und Rundreise‑Verifizierung abdeckt, siehe [Image Transform Effects](/slides/de/python-net/image-transform-effects/).

## **Geometrie des Bildrahmens sperren**

Die [PictureFrameLock](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframelock/)‑Einstellungen bestimmen, welche Bearbeitungsvorgänge für einen Bildrahmen deaktiviert sind. Beispielsweise bewahrt die [aspect_ratio_locked](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/)‑Eigenschaft die Proportionen der Form beim Skalieren.

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

Die Sperre gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht dazu, neu gesampelt oder dauerhaft auf dasselbe Seitenverhältnis geändert zu werden.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüll‑Modus „stretch“ ist, definieren die Stretch‑Offset‑Werte auf [PictureFillFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/) das Füll‑Rechteck relativ zum Begrenzungsrahmen des Bildrahmens. Positive Prozentsätze erzeugen einen Einzug von einer Kante, während negative Prozentsätze ein Herausstechen erzeugen.

Das unterscheidet sich vom Zuschneiden. Zuschneide‑Werte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

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

Verwenden Sie Stretch‑Offsets für die Positionierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Bildränder zu verbergen.

## **Speicherung, Dateigröße und Export‑Überlegungen**

Die wichtigsten Kompromisse lassen sich leichter handhaben, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt betrachtet werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, jedoch erhöhen große Rasterbilder die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, aber die Präsentation hängt von externen Dateien ab, die an den gespeicherten Pfaden oder Speicherorten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die verborgenen Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern erheblich reduzieren, kostet aber an Originalauflösung. Sie sollte erst nach Festlegung der tatsächlichen Anzeigegröße auf der Folie angewendet werden.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektor‑Erhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folien‑Exporte konvertieren stets die gerenderte Folie zu Pixeln.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Präsentations‑Workflow zu laden.

Für große Präsentationen ist Bildoptimierung meist am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektor‑Inhalt behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, zugeschnittene Pixel nur entfernen, wenn eine spätere Bearbeitung nicht mehr erforderlich ist, und externe Links vermeiden, sofern das Abhängigkeits‑Management nicht Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie sowie Formatierung wie Größe, Drehung, Zuschneide‑Werte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern von Bilddateien aus der PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Reduziert das Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneide‑Einstellungen verbergen Teile des Quellbildes, behalten jedoch die darunterliegenden Pixel bei. Verwenden Sie [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) oder Bildkompression mit Entfernen zugeschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen zugeschnittener Regionen verwirft Bilddaten. Bewahren Sie das ursprüngliche Quellbild außerhalb der Präsentation auf, falls später eine hochauflösende Bearbeitung nötig sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Bewahren Sie SVG‑Inhalt als SVG, wenn die Vektor‑Genauigkeit wichtig ist. Das eingebettete [SvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folien‑Bildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Member verwenden. `isinstance(shape, slides.PictureFrame)` verhindert ungültige Casts und ermöglicht dem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.