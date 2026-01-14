---
title: BLOBs in Präsentationen mit Python verwalten für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/python-net/manage-blob/
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
- Aspose.Slides
description: "BLOB-Daten in Aspose.Slides für Python via .NET verwalten, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Präsentationsverarbeitung zu ermöglichen."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in Binärformaten gespeichert wird.

Aspose.Slides für Python via .NET ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird.

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/python-net/) für .NET ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) über einen BLOB‑basierten Prozess hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieser Python‑Code zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Wir fügen das Video zur Präsentation hinzu - wir haben das KeepLocked-Verhalten gewählt, weil wir
        # nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        # während des gesamten Lebenszyklus des pres-Objekts gering
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Große Datei über BLOB aus einer Präsentation exportieren**
Aspose.Slides für Python via .NET ermöglicht das Exportieren großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten aber nicht, dass die Datei in den Speicher Ihres Computers geladen wird. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch gering.

Dieser Python‑Code demonstriert die beschriebene Vorgangsweise:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
	# um die Daten vom Videostream der Präsentation zu einem Stream für die neu erstellte Videodatei zu übertragen.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Durchläuft die Videos
    index = 0
    # Falls nötig, können Sie die gleichen Schritte für Audiodateien anwenden. 
    for video in pres.videos:
		# Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst den Zugriff auf Eigenschaften vermieden haben
		# wie video.BinaryData - weil diese Eigenschaft ein Byte‑Array zurückgibt, das das gesamte Video enthält, was dann
		# bytes in den Speicher lädt. Wir verwenden video.GetStream, das einen Stream zurückgibt – und NICHT
		#  erfordert, dass wir das gesamte Video in den Speicher laden.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```


### **Bild als BLOB zur Präsentation hinzufügen**
Mit den Methoden der Klasse [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.

Dieser Python‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```py
import aspose.slides as slides

# erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```


## **Speicher und große Präsentationen**

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei, aus der die Präsentation geladen wurde, wird nicht mehr verwendet.

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standard‑Methode zum Laden der Präsentation wird in diesem Python‑Code beschrieben:
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


Diese Methode verbraucht jedoch rund 1,6 GB temporären Speicher.

### **Große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit wenig Speicher laden. Dieser Python‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


### **Ordner für temporäre Dateien ändern**

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Einstellung für den Speicherort mit `temp_files_root_path` ändern:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```


{{% alert title="Info" color="info" %}}
Wenn Sie `temp_files_root_path` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell erstellen.
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern mittels BLOB‑Verarbeitung behandelt. Diese Objekte unterliegen BLOB‑Richtlinien, die es Ihnen ermöglichen, den Speicherverbrauch zu steuern und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). Dort setzen Sie das In‑Memory‑Limit für BLOBs, erlauben oder verbieten temporäre Dateien, wählen den Root‑Pfad für temporäre Dateien und legen das Verhalten beim Sperren der Quelle fest.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit vs. Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, verursacht jedoch zusätzlichen I/O‑Aufwand. Passen Sie den Schwellenwert [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) an, um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu erreichen.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. mehrere Gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) wurden für solche Szenarien entwickelt: Das Aktivieren temporärer Dateien und die Nutzung von Source‑Locking können den Spitzen‑RAM‑Verbrauch erheblich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams statt aus Dateisystemen verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, wodurch der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.