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
- Speichernutzung
- große Präsentation
- temporäre Datei
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für Python via .NET, um PowerPoint- und OpenDocument-Dateioperationen für eine effiziente Präsentationsverarbeitung zu optimieren."
---
## **Übersicht**

Aspose.Slides bietet eine BLOB-basierte Verarbeitung für große Binärdaten in Präsentationen, um den Speicherverbrauch beim Arbeiten mit großen Bildern, Audios, Videos und Präsentationsdateien zu reduzieren.

Dieser Artikel zeigt, wie Sie die BLOB-basierte Verarbeitung nutzen, um große Medien zu einer Präsentation hinzuzufügen, große Medien aus einer Präsentation zu exportieren und große Präsentationen effizienter zu laden. Er erklärt außerdem, wie temporäre Dateien während der Verarbeitung verwendet werden können und wie Sie den Ordner ändern, in dem sie gespeichert werden.

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides for Python via .NET ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch bei großen Dateien reduziert wird. 

## **Verwenden Sie BLOB, um den Speicherverbrauch zu reduzieren**

### **Große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/python-net/) für .NET ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu senken.

Dieses Python‑Beispiel zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:

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
        # niedrig während des gesamten Lebenszyklus des pres-Objekts 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Große Datei über BLOB aus einer Präsentation exportieren**
Aspose.Slides for Python via .NET ermöglicht das Exportieren großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, ohne dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig. 

Dieses Python‑Codebeispiel demonstriert die beschriebene Operation:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Speichern wir jedes Video in einer Datei. Um einen hohen Speicherverbrauch zu verhindern, benötigen wir einen Puffer, der verwendet wird
	# um die Daten vom Videostream der Präsentation zu einem Stream für eine neu erstellte Videodatei zu übertragen.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Durchläuft die Videos
    index = 0
    # Falls erforderlich, können Sie dieselben Schritte für Audiodateien anwenden. 
    for video in pres.videos:
		# Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir bewusst das Zugreifen auf Eigenschaften vermieden haben
		# wie video.BinaryData - weil diese Eigenschaft ein Byte-Array mit dem gesamten Video zurückgibt, das dann
		# Bytes in den Speicher lädt. Wir verwenden video.GetStream, das einen Stream zurückgibt - und dies NICHT
		#  erfordert, dass das gesamte Video in den Speicher geladen wird.
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
Mit Methoden aus der [**ImageCollection**](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/)‑Klasse können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird. 

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

Typischerweise erfordern das Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei, aus der die Präsentation geladen wurde, wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem Python‑Code beschrieben:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher. 

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

Wenn der BLOB‑Prozess verwendet wird, legt Ihr Computer temporäre Dateien im Standard‑Ordner für temporäre Dateien an. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie den Speicherort über `temp_files_root_path` ändern:

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

### **Präsentationsobjekte freigeben, um Speicher zu entlasten**

Beim Verarbeiten großer Präsentationen sollten Sie sicherstellen, dass die [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz ordnungsgemäß freigegeben wird, damit der belegte Speicher wieder freigegeben wird. Der empfohlene Weg ist die Verwendung des Kontextmanagers (`with slides.Presentation(...) as presentation:`), wie in den obigen Beispielen gezeigt; er schließt die Präsentation automatisch und gibt nicht verwaltete Ressourcen frei, wenn der Block beendet wird.

Erstellen Sie eine Präsentation ohne `with`‑Block, rufen Sie explizit `presentation.dispose()` auf, nachdem Sie sie nicht mehr benötigen, und entfernen Sie alle verbleibenden Referenzen, damit der Python‑Garbage‑Collector den Speicher zurückgewinnen kann.

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

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei nutzt BLOB‑Verarbeitung beim Laden oder Speichern. Diese Objekte unterliegen BLOB‑Richtlinien, mit denen Sie die Speichernutzung verwalten und bei Bedarf auf temporäre Dateien auslagern können.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/) mit [BlobManagementOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen das Root‑Verzeichnis für temporäre Dateien und bestimmen das Verhalten beim Source‑Locking.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie balanciere ich Geschwindigkeit gegen Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicherlimit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, erzeugt jedoch zusätzlichen I/O‑Aufwand. Passen Sie den Schwellenwert [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/de/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) an, um das richtige Gleichgewicht für Ihre Arbeitslast und Umgebung zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabytes)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und das Verwenden von Source‑Locking können den Spitzen‑RAM‑Verbrauch deutlich reduzieren und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Datei‑Systemen verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Locking‑Modus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.