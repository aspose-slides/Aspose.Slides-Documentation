---
title: Verwalten von Präsentations‑BLOBs in Python via Java für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/python-java/manage-blob/
keywords:
- großes Objekt
- großes Element
- große Datei
- BLOB hinzufügen
- BLOB exportieren
- Bild als BLOB hinzufügen
- Speicher reduzieren
- Speicherauslastung
- große Präsentation
- temporäre Datei
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für Python via Java, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu gewährleisten."
---
## **Übersicht**

Aspose.Slides bietet BLOB-basierte Verarbeitung für große Binärdaten in Präsentationen, um den Speicherverbrauch beim Arbeiten mit großen Bildern, Audio‑, Video‑ und Präsentationsdateien zu reduzieren.

Dieser Artikel zeigt, wie Sie BLOB-basierte Verarbeitung nutzen, um große Medien zu einer Präsentation hinzuzufügen, große Medien aus einer Präsentation zu exportieren und große Präsentationen effizienter zu laden. Außerdem wird erklärt, wie temporäre Dateien während der Verarbeitung verwendet werden können und wie Sie den Ordner ändern, in dem sie gespeichert werden.

## **Über BLOB**

**BLOB** (**Binäres Großes Objekt**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird.

Aspose.Slides for Python via Java ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird.

{{% alert color="info" title="Note" %}}
Um bestimmte Einschränkungen beim Umgang mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zum Kopieren des Präsentationsinhalts und verursacht ein langsames Laden. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht den Stream zu verwenden.
{{% /alert %}}

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/python-java/) für Python via Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Vorgang, um den Speicherverbrauch zu senken.

Dieser Python‑Code zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Erstelle eine neue Präsentation, zu der das Video hinzugefügt wird.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Halte den Stream gesperrt, weil wir nicht beabsichtigen, die Videodatei zu öffnen.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Speichere die Präsentation, während der Speicherverbrauch niedrig bleibt.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Eine große Datei über BLOB aus einer Präsentation exportieren**
Aspose.Slides for Python via Java ermöglicht das Exportieren großer Dateien (z. B. einer Audio‑ oder Videodatei) über einen BLOB‑basierten Vorgang aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten die Datei aber nicht im Speicher Ihres Computers laden. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig.

Dieser Python‑Code demonstriert den beschriebenen Vorgang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Sperre die Quelldatei, anstatt sie in den Speicher zu laden.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Übertrage Videodaten über einen Puffer, um den Speicherverbrauch gering zu halten.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Verwende den Stream, anstatt das gesamte Video in ein Byte-Array zu laden.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Falls nötig, wende die gleichen Schritte auf Audiodateien an.
finally:
    presentation.dispose()
```

### **Ein Bild als BLOB zu einer Präsentation hinzufügen**
Mit Methoden der Klasse [ImageCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.

Dieser Python‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Erstelle eine neue Präsentation, zu der das Bild hinzugefügt wird.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Halte den Stream gesperrt, weil wir nicht beabsichtigen, die Bilddatei zu öffnen.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Speichere die Präsentation, während der Speicherverbrauch niedrig bleibt.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Speicher und große Präsentationen**

Typischerweise benötigen Computer beim Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei, aus der die Präsentation geladen wurde, wird nicht mehr verwendet.

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem Python‑Code beschrieben:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher.

### **Eine große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit geringem Speicherverbrauch laden. Dieser Python‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Den Ordner für temporäre Dateien ändern**

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Temp‑Ordner. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Einstellungen mit [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) ändern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
Wenn Sie [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) verwenden, erstellt Aspose.Slides den Ordner für temporäre Dateien nicht automatisch. Sie müssen den Ordner manuell anlegen.
{{% /alert %}}

### **Präsentationsobjekte freigeben, um Speicher zu räumen**

Beim Verarbeiten großer Präsentationen stellen Sie sicher, dass die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz ordnungsgemäß freigegeben wird, damit der belegte Speicher wieder freigegeben wird. Rufen Sie [Presentation.dispose](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#dispose) auf, nachdem Sie die Präsentation nicht mehr benötigen, um nicht verwaltete Ressourcen freizugeben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...die Präsentation verarbeiten...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Ressourcen explizit freigeben.
    presentation.dispose()
```

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern BLOB‑verarbeitet. Diese Objekte unterliegen BLOB‑Richtlinien, die Ihnen ermöglichen, den Speicherverbrauch zu verwalten und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/). Dort setzen Sie das In‑Memory‑Limit für BLOBs, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Verhalten der Quellen‑Sperrung.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie finde ich das richtige Gleichgewicht zwischen Geschwindigkeit und Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, verursacht jedoch zusätzlichen I/O‑Aufwand. Nutzen Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory), um das optimale Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. mehrere Gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Nutzung von Quellen‑Sperrungen können den Spitzen‑RAM‑Verbrauch erheblich senken und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateisystemen verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Sperrmodus), und temporäre Dateien werden verwendet, wenn dies erlaubt ist, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.