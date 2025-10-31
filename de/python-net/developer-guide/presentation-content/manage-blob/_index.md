---
title: Verwalten von BLOBs in Präsentationen mit Python für effiziente Speichernutzung
linktitle: Verwalten von BLOB
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
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für Python via .NET, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Handhabung von Präsentationen zu ermöglichen."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in Binärformaten gespeichert wird. 

Aspose.Slides for Python via .NET ermöglicht die Verwendung von BLOBs für Objekte, um den Speicherverbrauch zu reduzieren, wenn große Dateien beteiligt sind. 

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Große Datei per BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/python-net/) für .NET ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu senken.

Dieses Python‑Beispiel zeigt, wie Sie eine große Videodatei per BLOB‑Prozess zu einer Präsentation hinzufügen:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Fügen wir das Video zur Präsentation hinzu – wir wählen das Verhalten KeepLocked, weil wir
        # nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der
        # Speicherverbrauch dank des Lebenszyklus‑Objekts pres niedrig
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Große Datei per BLOB aus einer Präsentation exportieren**
Aspose.Slides for Python via .NET erlaubt das Exportieren großer Dateien (z. B. einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Zum Beispiel möchten Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, ohne dass die Datei in den Arbeitsspeicher geladen wird. Durch den Export über den BLOB‑Prozess halten Sie den Speicherverbrauch niedrig. 

Der folgende Python‑Code demonstriert den beschriebenen Vorgang:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Jeder Video‑Clip wird in eine Datei gespeichert. Um hohen Speicherverbrauch zu verhindern,
	# benötigen wir einen Puffer, der dazu dient, die Daten aus dem Video‑Stream der Präsentation
	# in einen Stream für die neu erstellte Videodatei zu übertragen.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Durchläuft die Videos
    index = 0
    # Bei Bedarf können Sie dieselben Schritte für Audiodateien ausführen. 
    for video in pres.videos:
		# Öffnet den Video‑Stream der Präsentation. Bitte beachten Sie, dass wir bewusst darauf verzichtet haben,
		# Eigenschaften wie video.BinaryData zu verwenden – diese Eigenschaft liefert ein Byte‑Array mit dem kompletten Video,
		# was dann dazu führt, dass Bytes in den Arbeitsspeicher geladen werden. Wir verwenden video.GetStream,
		# das einen Stream zurückgibt – und NICHT erfordert, das gesamte Video in den Speicher zu laden.
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

### **Bild als BLOB in Präsentation hinzufügen**
Mit den Methoden des [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)-Interfaces und der [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)-Klasse können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird. 

Dieses Python‑Beispiel zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:

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

Typischerweise benötigen Computer beim Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Arbeitsspeicher geladen und die Datei, aus der die Präsentation geladen wurde, wird nicht weiter verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standard‑Methode zum Laden der Präsentation wird in folgendem Python‑Code beschrieben:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Doch diese Methode verbraucht etwa 1,6 GB temporären Speicher. 

### **Große Präsentation als BLOB laden**

Durch den BLOB‑basierten Prozess können Sie eine große Präsentation mit geringem Speicherverbrauch laden. Dieser Python‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:

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

Wenn der BLOB‑Prozess verwendet wird, legt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien an. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speicher‑Einstellungen mit `temp_files_root_path` ändern:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}

Wenn Sie `temp_files_root_path` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell anlegen. 

{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei selbst unterliegt der BLOB‑Verarbeitung, wenn sie geladen oder gespeichert wird. Diese Objekte werden durch BLOB‑Richtlinien gesteuert, die Ihnen ermöglichen, den Speicherverbrauch zu verwalten und bei Bedarf auf temporäre Dateien auszulagern.

**Wo konfiguriere ich BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOBs fest, erlauben oder verbieten temporäre Dateien, bestimmen den Stammordner für temporäre Dateien und wählen das Lock‑Verhalten der Quelle.

**Beeinflussen BLOB‑Einstellungen die Performance und wie balanciere ich Geschwindigkeit vs. Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht aber den RAM‑Verbrauch; ein niedrigeres Speicherlimit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, kostet jedoch zusätzliche I/O. Stimmen Sie den Schwellenwert [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) auf das richtige Gleichgewicht für Ihren Workload und Ihre Umgebung ab.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Größe)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) wurden für solche Szenarien entwickelt: Durch Aktivieren temporärer Dateien und die Nutzung von Lock‑Verhalten lässt sich der Spitzen‑RAM‑Verbrauch deutlich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams statt aus Datei‑Pfade verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und locken (abhängig vom gewählten Lock‑Modus), und temporäre Dateien werden verwendet, wenn erlaubt, wodurch der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.