---
title: Verwalten von Bildrahmen in Präsentationen mit Python
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/python-java/picture-frame/
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
- Zuge‑schnittene Bereiche löschen
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
- Java
- Aspose.Slides
description: "Erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren Sie Bildrahmen in Präsentationen mit Aspose.Slides für Python über Java."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die es anzeigt, separate Objekte: Eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [ImageCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/), während ein [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) die Position, Größe, Linienformatierung, Drehung, Beschnitt, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehr als einmal angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/), und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können außerdem auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor dem Anwenden von Formatierungen oder Optimierungen zu entscheiden, wie das Bild gespeichert werden soll.

## **Einbetten und Formatieren eines Bildes**

Für ein eingebettetes Bild fügen Sie die Bilddaten zur Präsentation hinzu und erstellen einen Bildrahmen mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addPictureFrame). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbstständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen in den nativen Abmessungen des Bildes und wendet Linienformatierung sowie Drehung an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmengröße ändert nicht die ursprünglichen Pixeldimensionen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn ein Bild später beschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) stellt die relative Breiten- und Höhen­skalierung für den Rahmen über [setRelativeScaleWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) und [setRelativeScaleHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) bereit. Ein Wert von `1.0` entspricht 100 % der ursprünglichen Bildgröße. Relative Skalierung ist nützlich, wenn ein Workflow die Beziehung zur Quellbildgröße beibehalten muss, anstatt die Endabmessungen manuell zu berechnen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie führt kein Resampling oder keine Kompression des eingebetteten Bildes durch.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert einen externen Speicherort über die Methode [Picture.setLinkPathLong](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#setLinkPathLong) anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die im PPTX gespeicherte Datenmenge reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, erreichbar bleiben. Ändert sich der Pfad, wird die Datei verschoben oder ist die Ressource nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail versendet, archiviert oder in isolierten Umgebungen gerendert werden müssen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist ihn auf eine lokale Bilddatei. Es behandelt ausschließlich die Bildverknüpfung; die Verknüpfung von Videos ist ein separater Medien‑Workflow und wird in diesem Beispiel bewusst nicht kombiniert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Verwenden Sie Verknüpfungen, wenn die externe Dateiverwaltung beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: ein kleines PPTX mit defekten Bildabhängigkeiten ist in der Regel weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob eine Form tatsächlich ein [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) ist und ob sie ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Rasterbild extrahieren**

Die moderne Bild‑API arbeitet direkt mit Rasterbildern und erfordert nicht den älteren Java‑Bild‑Wrapper. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Das Speichern des Rasterbildes konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die in der Präsentation gespeicherten kodierten Bytes benötigen, anstatt einer konvertierten Rasterdatei, verwenden Sie stattdessen die Binärdaten der Bildressource.

### **SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) ein [SvgImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, statt das Bild zuerst zu rasterisieren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Das Beibehalten von SVG‑Inhalt als SVG bewahrt die Vektorquelle innerhalb der Präsentation. Rasterexporte wie PNG oder JPEG rendern diesen Vektorinhalt zwingend zu Pixeln. PDF‑ oder SVG‑Folienexport ist ebenfalls ein Rendering‑Vorgang, sodass die exportierten Grafiken nicht als exakte Kopie des ursprünglich eingebetteten SVG behandelt werden sollten; verwenden Sie die eingebetteten [SvgImage.getSvgData](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/#getSvgData)-Daten, wenn die originale Vektorressource selbst benötigt wird.

## **Bild zuschneiden**

Das Zuschneiden ändert, welcher Teil eines Bildes im Rahmen sichtbar ist. Die Zuschneidewerte in [PictureFillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/) sind Prozentsätze der Abmessungen des Quellbildes. Beim Zuschneiden werden die verborgenen Pixel des eingebetteten Bildes zunächst nicht gelöscht; es wird nur der sichtbare Bereich geändert.

Das folgende Beispiel findet sicher einen Bildrahmen und wendet Zuschneidewerte an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Da die verborgenen Bilddaten weiterhin vorhanden sind, kann das Zuschneiden später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Umkehrbarkeit, können die beschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Beschnittene Bilddaten entfernen**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) entfernt Bilddaten außerhalb des aktuellen Beschnittrechtecks und gibt die resultierende Bildressource zurück. Dies kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation sind die entfernten Pixel für ein späteres Entzuschneiden nicht mehr verfügbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Methode kann der Präsentation eine neue Bildressource hinzufügen. Wenn das Originalbild von anderen Bildrahmen ebenfalls verwendet wird, benötigen diese Rahmen weiterhin ihre bestehende Ressource, sodass das Löschen beschnittener Bereiche nicht zwingend die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das beschnittene Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#compressImage) reduziert die Auflösung von Rasterbildern relativ zur Größe, in der das Bild angezeigt wird. Es kann außerdem beschnittene Bereiche im selben Vorgang entfernen. Die Methode gibt `True` zurück, wenn das Bild in Größe oder Beschnitt geändert wurde, und `False`, wenn keine Änderung notwendig war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturescompression/)‑Wert, wenn eine Standard‑Zielauflösung ausreicht:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ein benutzerdefinierter positiver DPI‑Wert kann anstelle eines vordefinierten Werts übergeben werden, wenn ein spezifisches Ziel erforderlich ist.

Kompression ist für Rasterbilder gedacht. SVG‑ und Metadatei‑Inhalte werden durch diesen Rasterkompressions‑Workflow nicht reduziert. Denken Sie zudem daran, dass niedrigere Auflösungen und gelöschte Beschnittbereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich betrachtet oder exportiert wird, anstatt global die niedrigste DPI anzuwenden.

## **Bildtransformations‑Effekte verwalten**

Für einen vollständigen Workflow, der Helligkeit, Kontrast, Farbtransformationen, Weichzeichnung, Alpha‑Effekte, geordnete Ketten, Inspektion, Entfernung und Rundreise‑Verifizierung abdeckt, siehe [Image Transform Effects](/slides/de/python-java/image-transform-effects/).

## **Geometrie des Bildrahmens sperren**

Die [PictureFrameLock](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframelock/)‑Einstellungen steuern, welche Bearbeitungsvorgänge für einen Bildrahmen deaktiviert sind. Zum Beispiel bewahrt [setAspectRatioLocked](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) die Proportionen der Form, während sie skaliert wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Sperre gilt für die Form des Bildrahmens. Sie zwingt das Quellbild nicht zu einem Resampling oder einer dauerhaften Änderung auf dasselbe Seitenverhältnis.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüllmodus Stretch ist, definieren die Stretch‑Offset‑Werte in [PictureFillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/) das Füllrechteck relativ zum Begrenzungsrahmen des Bildrahmens. Positive Prozentsätze erzeugen einen Einzug von einer Kante, während negative Prozentsätze einen Ausriss erzeugen.

Dies unterscheidet sich vom Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Kanten des Quellbildes zu verbergen.

## **Speicher, Dateigröße und Exportüberlegungen**

Die Hauptkompromisse lassen sich leichter handhaben, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt behandelt werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, jedoch vergrößern große Rasterbilder die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, jedoch hängt die Präsentation von externen Dateien ab, die an den gespeicherten Pfaden oder Standorten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht-destruktiv. Die verborgenen Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei zu großen Rasterbildern erheblich reduzieren, geht jedoch die Quellauflösung zugunsten der Dateigröße ein. Sie sollte nach Bekanntwerden der beabsichtigten Foliengröße angewendet werden.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektor‑Erhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folienexporte konvertieren die gerenderte Folie immer zu Pixeln.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Präsentations‑Workflow zu laden.

Bei großen Präsentationen ist die Bildoptimierung in der Regel am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektorinhalt behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, beschnittene Pixel nur entfernen, wenn eine spätere Bearbeitung nicht erforderlich ist, und externe Verknüpfungen vermeiden, sofern das Abhängigkeits‑Management nicht Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) stellt eine Bildressource dar, die mit der Präsentation verbunden ist. Ein [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie und Formatierung wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verlinken?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern der Bilddateien aus dem PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Verringert das Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneideinstellungen verbergen Teile des Quellbildes, behalten jedoch die zugrunde liegenden Pixel. Verwenden Sie [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) oder Bildkompression mit Entfernen beschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Die Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen beschnittener Bereiche verwirft Bilddaten. Bewahren Sie das ursprüngliche Quellbild außerhalb der Präsentation auf, falls später eine Bearbeitung in hoher Auflösung erforderlich sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalt als SVG, wenn die Vektortreue wichtig ist. Das eingebettete [SvgImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/svgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rastert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Member verwenden. Ein `isinstance`‑Check gegen [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) verhindert ungültige Casts und ermöglicht es dem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.