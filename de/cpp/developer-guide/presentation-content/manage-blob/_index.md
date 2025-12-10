---
title: Verwalten von Präsentations-BLOBs in C++ für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für C++, um PowerPoint- und OpenDocument-Dateioperationen zu optimieren und die Präsentationsverarbeitung effizient zu gestalten."
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das in Binärformaten gespeichert wird. 

Aspose.Slides for C++ ermöglicht die Verwendung von BLOBs für Objekte in einer Weise, die den Speicherverbrauch reduziert, wenn große Dateien beteiligt sind. 

## **Verwenden Sie BLOB, um den Speicherverbrauch zu reduzieren**

### **Fügen Sie einer Präsentation über BLOB eine große Datei hinzu**

[Aspose.Slides](/slides/de/cpp/) for C++ ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen Prozess mit BLOBs, um den Speicherverbrauch zu reduzieren.

Dieser C++‑Code zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:
```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Erzeugt eine neue Präsentation, zu der das Video hinzugefügt wird
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Fügen wir das Video zur Präsentation hinzu – wir haben das KeepLocked‑Verhalten gewählt, weil wir
// nicht beabsichtigen, die Datei "veryLargeVideo.avi" zu öffnen.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
// niedrig während des gesamten Lebenszyklus des pres‑Objekts
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **Exportieren Sie eine große Datei über BLOB aus einer Präsentation**
Aspose.Slides for C++ ermöglicht das Exportieren großer Dateien (in diesem Fall einer Audio‑ oder Videodatei) über einen Prozess mit BLOBs aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten aber nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch das Exportieren der Datei über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig. 

Dieser C++‑Code demonstriert den beschriebenen Vorgang:
```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Erstellt eine Instanz von Presentation und sperrt die "hugePresentationWithAudiosAndVideos.pptx" Datei.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Speichern wir jedes Video in einer Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
// um die Daten vom Videostream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Durchläuft die Videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir absichtlich vermieden haben, Methoden
	// wie video->get_BinaryData aufzurufen - weil diese Methode ein Byte‑Array mit dem gesamten Video zurückgibt, was dann
	// dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video->GetStream, das einen Stream zurückgibt - und das NICHT
	// erfordert, dass das gesamte Video in den Speicher geladen wird.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Der Speicherverbrauch bleibt niedrig, unabhängig von der Größe des Videos oder der Präsentation,
}

// Falls nötig, können Sie die gleichen Schritte für Audiodateien anwenden.
```


### **Fügen Sie einer Präsentation ein Bild als BLOB hinzu**
Mit Methoden aus dem Interface [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) und der Klasse [**ImageCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection) können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird. 

Dieser C++‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:
```cpp
const String pathToLargeImage = u"large_image.jpg";

// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Fügen wir das Bild zur Präsentation hinzu – wir wählen das KeepLocked-Verhalten, weil wir
// NICHT beabsichtigen, die Datei "largeImage.png" zu öffnen.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
// niedrig während des gesamten Lebenszyklus des pres-Objekts
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```


## **Speicher und große Präsentationen**

In der Regel benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem C++‑Code beschrieben:
```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


Diese Methode verbraucht jedoch etwa 1,6 GB temporären Speicher. 

### **Laden Sie eine große Präsentation als BLOB**

Durch den Prozess mit einem BLOB können Sie eine große Präsentation laden und dabei wenig Speicher verwenden. Dieser C++‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


#### **Ändern Sie den Ordner für temporäre Dateien**

Wird der BLOB‑Prozess verwendet, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie die temporären Dateien in einem anderen Ordner speichern möchten, können Sie die Speichereinstellungen über `TempFilesRootPath` ändern:
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```


{{% alert title="Info" color="info" %}}
Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner zum Speichern temporärer Dateien. Sie müssen den Ordner manuell erstellen. 
{{% /alert %}}

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio und Video werden als BLOB behandelt. Auch die gesamte Präsentationsdatei unterliegt dem BLOB‑Handling, wenn sie geladen oder gespeichert wird. Diese Objekte werden von BLOB‑Richtlinien gesteuert, die Ihnen ermöglichen, die Speichernutzung zu verwalten und bei Bedarf in temporäre Dateien auszulagern.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Verhalten beim Quell‑Locking.

**Beeinflussen BLOB‑Einstellungen die Leistung und wie finde ich das Gleichgewicht zwischen Geschwindigkeit und Speicher?**

Ja. Das Halten von BLOB im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicher‑Limit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, kostet aber zusätzlichen I/O‑Aufwand. Verwenden Sie die Methode [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) , um für Ihren Arbeitslast und Ihre Umgebung das richtige Gleichgewicht zu finden.

**Helfen BLOB‑Optionen beim Öffnen extrem großer Präsentationen (z. B. Gigabyte‑Dateien)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Durch das Aktivieren temporärer Dateien und die Nutzung von Source‑Locking kann der maximale RAM‑Verbrauch deutlich reduziert und die Verarbeitung sehr großer Präsentationen stabilisiert werden.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Dateien auf der Festplatte verwenden?**

Ja. Die gleichen Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (abhängig vom gewählten Sperrmodus), und temporäre Dateien werden verwendet, wenn sie erlaubt sind, wodurch die Speichernutzung während der Verarbeitung vorhersehbar bleibt.