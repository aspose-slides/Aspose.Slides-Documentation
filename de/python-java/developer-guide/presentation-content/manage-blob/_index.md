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
- Speicherverbrauch
- große Präsentation
- temporäre Datei
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für Python via Java, um PowerPoint‑ und OpenDocument‑Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu ermöglichen."
---
## **Überblick**

Aspose.Slides bietet eine BLOB‑basierte Verarbeitung großer Binärdaten in Präsentationen, um den Speicherverbrauch bei großen Bildern, Audios, Videos und Präsentationsdateien zu reduzieren.

Dieser Artikel zeigt, wie man die BLOB‑Verarbeitung verwendet, um große Medien zu einer Präsentation hinzuzufügen, große Medien aus einer Präsentation zu exportieren und große Präsentationen effizienter zu laden. Außerdem wird erklärt, wie temporäre Dateien während der Verarbeitung verwendet werden können und wie man den Ordner ändert, in dem sie gespeichert werden.

## **Über BLOB**

Ein **BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird.

Aspose.Slides for Python via Java ermöglicht die Verwendung von BLOBs für Objekte auf eine Weise, die den Speicherverbrauch bei großen Dateien reduziert.

{{% alert color="info" title="Note" %}}
Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt zum Kopieren der Präsentationsinhalte und verursacht langsames Laden. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht ihren Stream zu verwenden.
{{% /alert %}}

## **BLOBs zur Reduzierung des Speicherverbrauchs verwenden**

### **Eine große Datei über BLOBs zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/python-java/) for Python via Java ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu reduzieren.

Dieser Python‑Code zeigt, wie man eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügt:

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
        # Halte den Stream gesperrt, da wir nicht beabsichtigen, auf die Videodatei zuzugreifen.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Speichere die Präsentation, während der Speicherverbrauch niedrig bleibt.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Eine große Datei aus einer Präsentation über BLOBs exportieren**
Aspose.Slides for Python via Java ermöglicht den Export großer Dateien (z. B. einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise kann es erforderlich sein, eine große Mediendatei aus einer Präsentation zu extrahieren, ohne dass die Datei in den Arbeitsspeicher des Computers geladen wird. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch gering.

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
    # Übertrage Videodaten über einen Puffer, um den Speicherverbrauch niedrig zu halten.
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
    # Bei Bedarf dieselben Schritte auf Audiodateien anwenden.
finally:
    presentation.dispose()
```

### **Ein Bild als BLOB zu einer Präsentation hinzufügen**
Mit Methoden der Klasse [ImageCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.

Dieser Python‑Code zeigt, wie man ein großes Bild über den BLOB‑Prozess hinzufügt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Eine neue Präsentation erstellen, zu der das Bild hinzugefügt wird.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Den Stream gesperrt lassen, da wir nicht beabsichtigen, auf die Bilddatei zuzugreifen.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Die Präsentation speichern, während der Speicherverbrauch niedrig gehalten wird.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Speicher und große Präsentationen**

In der Regel benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.

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

Durch die Verwendung der BLOB‑Verarbeitung können Sie eine große Präsentation mit wenig Speicher laden. Dieser Python‑Code zeigt, wie man BLOB‑Verarbeitung nutzt, um eine große Präsentationsdatei (large.pptx) zu laden:

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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Einstellungen für den Speicher mit [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) ändern:

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
Wenn Sie [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell anlegen.
{{% /alert %}}

### **Präsentationsobjekte freigeben, um Speicher zu entlasten**

Beim Verarbeiten großer Präsentationen sollte die [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Instanz ordnungsgemäß freigegeben werden, damit der von ihr belegte Speicher freigegeben wird. Rufen Sie nach der Verwendung der Präsentation [Presentation.dispose](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#dispose) auf, um nicht verwaltete Ressourcen freizugeben.

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

Große Binärobjekte wie Bilder, Audio und Video werden als BLOBs behandelt. Auch die gesamte Präsentationsdatei nutzt BLOB‑Verarbeitung, wenn sie geladen oder gespeichert wird. Diese Objekte unterliegen BLOB‑Richtlinien, die Ihnen erlauben, den Speicherverbrauch zu steuern und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/). Dort setzen Sie das Speicherlimit für BLOBs, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Verhalten der Quellen‑Sperrung.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit vs. Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicherlimit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, verursacht aber zusätzlichen I/O‑Aufwand. Verwenden Sie die Methode [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory), um das optimale Gleichgewicht für Ihren Anwendungsfall zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Größe)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/blobmanagementoptions/) ist für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Nutzung von Quellen‑Sperren können den Spitzen‑RAM‑Verbrauch erheblich senken und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateien verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.