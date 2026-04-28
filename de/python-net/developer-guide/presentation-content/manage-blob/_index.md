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
description: "BLOB-Daten in Aspose.Slides für Python via .NET verwalten, um PowerPoint- und OpenDocument-Dateioperationen für eine effiziente Präsentationsverarbeitung zu optimieren."
---
## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides for Python via .NET ermöglicht es Ihnen, BLOBs für Objekte zu verwenden, um den Speicherverbrauch zu reduzieren, wenn große Dateien beteiligt sind. 

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Große Datei per BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/python-net/) für .NET ermöglicht es, große Dateien (in diesem Fall eine große Videodatei) über einen mit BLOBs verbundenen Prozess hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieses Python‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Lassen Sie uns das Video zur Präsentation hinzufügen - wir haben das KeepLocked-Verhalten gewählt, weil wir
        # nicht beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
        # während des gesamten Lebenszyklus des pres-Objekts niedrig 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **Große Datei per BLOB aus einer Präsentation exportieren**
Aspose.Slides for Python via .NET ermöglicht es, große Dateien (in diesem Fall eine Audio‑ oder Videodatei) über einen mit BLOBs verbundenen Prozess aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Speicher Ihres Computers geladen wird. Durch das Exportieren der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch gering. 

Dieser Python‑Code demonstriert den beschriebenen Vorgang:

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
    # Falls nötig, können Sie dieselben Schritte für Audiodateien anwenden. 
    for video in pres.videos:
		# Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst darauf verzichtet haben, Eigenschaften zuzugreifen
		# wie video.BinaryData – weil diese Eigenschaft ein Byte‑Array mit dem gesamten Video zurückgibt, was dann
		# dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video.GetStream, das einen Stream zurückgibt – und NICHT
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

### **Bild als BLOB in Präsentation hinzufügen**
Mit Methoden der Klasse [**ImageCollection**](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird. 

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

In der Regel benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB große Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem Python‑Code beschrieben:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher. 

### **Große Präsentation als BLOB laden**

Durch den mit BLOB verbundenen Prozess können Sie eine große Präsentation mit wenig Speicher laden. Dieser Python‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

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

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner ablegen möchten, können Sie die Speichereinstellungen mit `temp_files_root_path` ändern:

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

### **Präsentationsobjekte freigeben, um Speicher freizugeben**

Beim Verarbeiten großer Präsentationen sollten Sie sicherstellen, dass die `Presentation`‑Instanz ordnungsgemäß freigegeben wird, damit der von ihr belegte Speicher freigegeben wird. Empfohlen wird die Verwendung des Kontextmanagers (`with slides.Presentation(...) as presentation:`) wie in den obigen Beispielen gezeigt; er schließt die Präsentation automatisch und gibt nicht verwaltete Ressourcen frei, wenn der Block beendet wird.

Wenn Sie eine Präsentation ohne `with`‑Block erstellen, rufen Sie nach der Verwendung explizit `presentation.dispose()` auf und entfernen Sie alle verbleibenden Referenzen, damit der Python‑Garbage‑Collector den Speicher zurückgewinnen kann.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")
# ...die Präsentation verarbeiten...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)
# Ressourcen explizit freigeben.
presentation.dispose()
```

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei wird beim Laden oder Speichern im BLOB‑Handling berücksichtigt. Diese Objekte werden von BLOB‑Richtlinien gesteuert, die es ermöglichen, die Speichernutzung zu verwalten und bei Bedarf in temporäre Dateien auszulagern. 

**Wo konfiguriere ich BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen den Root‑Pfad für temporäre Dateien und bestimmen das Sperrverhalten der Quelle. 

**Wirken sich BLOB‑Einstellungen auf die Leistung aus, und wie balanciere ich Geschwindigkeit und Speicher?**

Ja. Das Halten von BLOB im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; durch Senken des Speicherlimits wird mehr Arbeit auf temporäre Dateien verlagert, wodurch RAM reduziert wird, jedoch zusätzliche I/O‑Last entsteht. Passen Sie den Schwellenwert [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/de/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) an, um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu erzielen. 

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und die Verwendung von Source‑Locking können den Spitzen‑RAM‑Verbrauch erheblich reduzieren und die Verarbeitung sehr großer Decks stabilisieren. 

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateien verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, sodass die Speichernutzung während der Verarbeitung vorhersehbar bleibt.