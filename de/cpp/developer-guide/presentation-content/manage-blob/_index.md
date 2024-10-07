---
title: Verwalten von BLOB
type: docs
weight: 10
url: /cpp/manage-blob/
keywords: "Blob hinzufügen, Blob exportieren, Bild als Blob hinzufügen, PowerPoint-Präsentation, C++, Aspose.Slides für C++"
description: "Blob zu einer PowerPoint-Präsentation in C++ hinzufügen. Blob exportieren. Bild als Blob hinzufügen"
---

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist normalerweise ein großes Element (Foto, Präsentation, Dokument oder Medium), das in binären Formaten gespeichert wird. 

Aspose.Slides für C++ ermöglicht es Ihnen, BLOBs für Objekte zu verwenden, um den Speicherverbrauch bei großen Dateien zu reduzieren. 

## **BLOB verwenden, um den Speicherverbrauch zu reduzieren**

### **Fügen Sie eine große Datei über BLOB zu einer Präsentation hinzu**

[Aspose.Slides](/slides/cpp/) für C++ ermöglicht es Ihnen, große Dateien (in diesem Fall eine große Videodatei) über einen Prozess, der BLOBs umfasst, hinzuzufügen, um den Speicherverbrauch zu reduzieren.

Dieser C++-Code zeigt Ihnen, wie Sie eine große Videodatei über den BLOB-Prozess zu einer Präsentation hinzufügen:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Lassen Sie uns das Video zur Präsentation hinzufügen - wir wählen das Verhalten "KeepLocked", da wir nicht 
// beabsichtigen, auf die Datei "veryLargeVideo.avi" zuzugreifen.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch 
// während des Lebenszyklus des pres-Objekts niedrig
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **Exportieren Sie eine große Datei über BLOB aus der Präsentation**
Aspose.Slides für C++ ermöglicht es Ihnen, große Dateien (in diesem Fall eine Audio- oder Videodatei) über einen Prozess, der BLOBs umfasst, aus Präsentationen zu exportieren. Zum Beispiel müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, möchten jedoch nicht, dass die Datei in den Arbeitsspeicher Ihres Computers geladen wird. Durch den Export der Datei über den BLOB-Prozess können Sie den Speicherverbrauch niedrig halten.

Dieser C++-Code demonstriert den beschriebenen Vorgang:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Erstellt eine Instanz der Präsentation, sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Lassen Sie uns jedes Video in eine Datei speichern. Um einen hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, 
// der verwendet wird, um die Daten vom Videostream der Präsentation in einen Stream für eine neu erstellte Videodatei zu übertragen.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Durchläuft die Videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir absichtlich darauf verzichtet haben, Methoden 
	// wie video->get_BinaryData aufzurufen - da diese Methode ein Byte-Array zurückgibt, das ein vollständiges Video enthält, was dann
	// dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video->GetStream, das Stream zurückgibt - und dies erfordert NICHT,
	// dass wir das gesamte Video in den Speicher laden.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Der Speicherverbrauch bleibt unabhängig von der Größe des Videos oder der Präsentation niedrig.
}

// Falls erforderlich, können Sie die gleichen Schritte für Audiodateien anwenden.
```

### **Bild als BLOB in der Präsentation hinzufügen**
Mit Methoden aus der [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) Schnittstelle und der [**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection) Klasse können Sie ein großes Bild als Stream hinzufügen, damit es als BLOB behandelt wird.

Dieser C++-Code zeigt Ihnen, wie Sie ein großes Bild über den BLOB-Prozess hinzufügen:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// Erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Lassen Sie uns das Bild zur Präsentation hinzufügen - wir wählen das Verhalten "KeepLocked", da wir nicht 
// beabsichtigen, auf die Datei "largeImage.png" zuzugreifen.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch 
// während des Lebenszyklus des pres-Objekts niedrig
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Speicher und große Präsentationen**

Typischerweise benötigen Computer viel temporären Speicher, um eine große Präsentation zu laden. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Datei (aus der die Präsentation geladen wurde) wird nicht mehr verwendet.

Betrachten Sie eine große PowerPoint-Präsentation (large.pptx), die eine 1,5 GB große Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem C++-Code beschrieben:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Aber diese Methode verbraucht etwa 1,6 GB temporären Speicher.

### **Laden Sie eine große Präsentation als BLOB**

Durch den Prozess, der einen BLOB umfasst, können Sie eine große Präsentation laden, während Sie wenig Speicher verwenden. Dieser C++-Code beschreibt die Implementierung, bei der der BLOB-Prozess verwendet wird, um eine große Präsentationsdatei (large.pptx) zu laden:

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

Wenn der BLOB-Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Wenn Sie möchten, dass die temporären Dateien in einem anderen Ordner gespeichert werden, können Sie die Einstellungen für die Speicherung mit `TempFilesRootPath` ändern:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}

Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides nicht automatisch einen Ordner, um temporäre Dateien zu speichern. Sie müssen den Ordner manuell erstellen.

{{% /alert %}}