---
title: Blob verwalten
type: docs
weight: 10
url: /python-net/manage-blob/
keywords: "Blob hinzufügen, Blob exportieren, Bild als Blob hinzufügen, PowerPoint-Präsentation, Python, Aspose.Slides für Python via .NET"
description: "Blob zur PowerPoint-Präsentation in Python hinzufügen. Blob exportieren. Bild als Blob hinzufügen"
---

### **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medien), das in binären Formaten gespeichert ist.

Aspose.Slides für Python via .NET ermöglicht Ihnen die Verwendung von BLOBs für Objekte auf eine Weise, die den Speicherverbrauch bei großen Dateien verringert.

# **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/python-net/) für .NET ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) über einen Prozess mit BLOBs hinzuzufügen, um den Speicherverbrauch zu verringern.

Dieses Python-Beispiel zeigt Ihnen, wie Sie eine große Videodatei über den BLOB-Prozess zu einer Präsentation hinzufügen:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Lassen Sie uns das Video in die Präsentation einfügen - wir haben das KeepLocked-Verhalten gewählt, da wir
        # nicht beabsichtigen, auf die "veryLargeVideo.avi"-Datei zuzugreifen.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        # während des Lebenszyklus des pres-Objekts niedrig
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Große Datei über BLOB aus der Präsentation exportieren**
Aspose.Slides für Python via .NET ermöglicht es Ihnen, große Dateien (in diesem Fall eine Audio- oder Videodatei) über einen Prozess mit BLOBs aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB-Prozess können Sie den Speicherverbrauch gering halten.

Dieser Python-Code zeigt die beschriebene Operation:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
    # Lassen Sie uns jedes Video in eine Datei speichern. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
    # um die Daten vom Videostream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
    # byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

    # Durchläuft die Videos
    index = 0
    # Falls erforderlich, können Sie dieselben Schritte für Audiodateien anwenden.
    for video in pres.videos:
        # Öffnet den Video-Stream der Präsentation. Bitte beachten Sie, dass wir absichtlich den Zugriff auf Eigenschaften
        # wie video.BinaryData vermieden haben - weil diese Eigenschaft ein Byte-Array zurückgibt, das ein vollständiges Video enthält, was dann
        # dazu führt, dass Bytes in den Arbeitsspeicher geladen werden. Wir verwenden video.GetStream, das Stream zurückgibt - und wir müssen NICHT
        # das gesamte Video in den Arbeitsspeicher laden.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index=index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Bild als BLOB in der Präsentation hinzufügen**
Mit Methoden aus der [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) Schnittstelle und der [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) Klasse können Sie ein großes Bild als Stream hinzufügen, um es als BLOB zu behandeln.

Dieser Python-Code zeigt Ihnen, wie Sie ein großes Bild über den BLOB-Prozess hinzufügen:

```py
import aspose.slides as slides

# Erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Speicher und große Präsentationen**

Typischerweise benötigen Computer, um eine große Präsentation zu laden, viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.

Betrachten Sie eine große PowerPoint-Präsentation (large.pptx), die eine 1,5 GB große Videodatei enthält. Die Standardmethode zum Laden der Präsentation ist in diesem Python-Code beschrieben:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
    pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Aber diese Methode verbraucht etwa 1,6 GB temporären Speicher.

### **Eine große Präsentation als BLOB laden**

Durch den Prozess mit einem BLOB können Sie eine große Präsentation laden, während Sie wenig Speicher verwenden. Dieser Python-Code beschreibt die Implementierung, bei der der BLOB-Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
    pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

#### **Ändern des Ordners für temporäre Dateien**

Wenn der BLOB-Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie möchten, dass die temporären Dateien in einem anderen Ordner gespeichert werden, können Sie die Einstellungen für den Speicherort mit `temp_files_root_path` ändern:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}

Wenn Sie `temp_files_root_path` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner, um temporäre Dateien zu speichern. Sie müssen den Ordner manuell erstellen.

{{% /alert %}}