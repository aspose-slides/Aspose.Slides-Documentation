---
title: BLOBs in Präsentationen mit Python verwalten für effiziente Speicherverwendung
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
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für Python via .NET, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und eine effiziente Präsentationsbearbeitung zu ermöglichen."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Objekt (Foto, Präsentation, Dokument oder Medien), das in binären Formaten gespeichert wird.  

Aspose.Slides für Python via .NET ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird.  

## **Verwenden Sie BLOB, um den Speicherverbrauch zu reduzieren**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/python-net/) für .NET erlaubt das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen Vorgang mit BLOBs, um den Speicherverbrauch zu senken.  

Dieses Python‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Erzeugt eine neue Präsentation, zu der das Video hinzugefügt wird
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Fügen wir das Video zur Präsentation hinzu - wir haben das KeepLocked-Verhalten gewählt, weil wir
        # nicht beabsichtigen, die Datei "veryLargeVideo.avi" zuzugreifen.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        # durch den Lebenszyklus des pres-Objekts niedrig 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Große Datei über BLOB aus einer Präsentation exportieren**

Aspose.Slides für Python via .NET ermöglicht das Exportieren großer Dateien (z. B. einer Audio‑ oder Videodatei) über einen BLOB‑basierten Vorgang aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, ohne dass die Datei in den Arbeitsspeicher geladen wird. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig.  

Der folgende Python‑Code demonstriert die beschriebene Operation:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
	# um die Daten vom Videostream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Durchläuft die Videos
    index = 0
    # Falls nötig, können Sie die gleichen Schritte für Audiodateien anwenden. 
    for video in pres.videos:
		# Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst darauf verzichtet haben, Eigenschaften zuzugreifen
		# wie video.BinaryData – weil diese Eigenschaft ein Byte-Array mit dem gesamten Video zurückgibt, das dann
		# Bytes in den Speicher lädt. Wir verwenden video.GetStream, das einen Stream zurückgibt – und NICHT
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


### **Bild als BLOB in einer Präsentation hinzufügen**

Mit den Methoden der Schnittstelle [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird.  

Dieses Python‑Beispiel zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
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

Typischerweise erfordern das Laden großer Präsentationen viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Arbeitsspeicher geladen und die ursprüngliche Datei wird nicht mehr verwendet.  

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem Python‑Code beschrieben:
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher.  

### **Große Präsentation als BLOB laden**

Durch den BLOB‑basierten Vorgang können Sie eine große Präsentation mit geringem Speicherverbrauch laden. Der folgende Python‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:
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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Temp‑Ordner. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speicheroptionen über `temp_files_root_path` ändern:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```


{{% alert title="Info" color="info" %}}
Wenn Sie `temp_files_root_path` verwenden, erstellt Aspose.Slides den Ordner für temporäre Dateien nicht automatisch. Sie müssen den Ordner manuell anlegen.  
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**  

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei unterliegt der BLOB‑Verarbeitung beim Laden oder Speichern. Diese Objekte werden von BLOB‑Richtlinien gesteuert, mit denen Sie die Speichernutzung verwalten und bei Bedarf in temporäre Dateien auslagern können.  

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**  

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen den Root‑Pfad für temporäre Dateien und bestimmen das Locking‑Verhalten der Quelle.  

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit und Speicher?**  

Ja. Das Behalten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, führt aber zu zusätzlichem I/O. Passen Sie den Schwellenwert [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) an, um das optimale Gleichgewicht für Ihre Arbeitslast und Umgebung zu erzielen.  

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. mehrere Gigabyte)?**  

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Durch Aktivieren temporärer Dateien und das Verwenden von Source‑Locking kann der Spitzen‑RAM‑Verbrauch deutlich reduziert und die Verarbeitung sehr großer Decks stabilisiert werden.  

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateisystemen verwenden?**  

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Locking‑Modus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, sodass die Speichernutzung während der Verarbeitung vorhersehbar bleibt.