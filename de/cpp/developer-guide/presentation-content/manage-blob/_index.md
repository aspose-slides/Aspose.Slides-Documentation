---
title: Verwalten von Präsentations-BLOBs in C++ für effiziente Speichernutzung
linktitle: BLOB verwalten
type: docs
weight: 10
url: /de/cpp/manage-blob/
keywords:
- großes Objekt
- großer Gegenstand
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
- C++
- Aspose.Slides
description: "Verwalten Sie BLOB-Daten in Aspose.Slides für C++, um PowerPoint- und OpenDocument-Dateioperationen für eine effiziente Präsentationsverarbeitung zu optimieren."
---
## **Übersicht**

Aspose.Slides bietet eine BLOB-basierte Verarbeitung großer Binärdaten in Präsentationen, um den Speicherverbrauch bei der Arbeit mit großen Bildern, Audio‑, Video‑ und Präsentationsdateien zu reduzieren.

Dieser Artikel zeigt, wie Sie die BLOB-basierte Verarbeitung verwenden, um große Medien zu einer Präsentation hinzuzufügen, große Medien aus einer Präsentation zu exportieren und große Präsentationen effizienter zu laden. Er erklärt außerdem, wie temporäre Dateien während der Verarbeitung verwendet werden können und wie Sie den Ordner ändern, in dem sie gespeichert werden.

## **Über BLOB**

**BLOB** (**Binary Large Object**) ist in der Regel ein großes Element (Foto, Präsentation, Dokument oder Medium), das im Binärformat gespeichert wird. 

Aspose.Slides for C++ ermöglicht die Verwendung von BLOBs für Objekte, wodurch der Speicherverbrauch reduziert wird, wenn große Dateien beteiligt sind. 

## **BLOB zur Reduzierung des Speicherverbrauchs verwenden**

### **Eine große Datei über BLOB zu einer Präsentation hinzufügen**

[Aspose.Slides](/slides/de/cpp/) for C++ ermöglicht das Hinzufügen großer Dateien (in diesem Fall einer großen Videodatei) über einen BLOB‑basierten Prozess, um den Speicherverbrauch zu senken.

Der folgende C++‑Code zeigt, wie Sie eine große Videodatei über den BLOB‑Prozess zu einer Präsentation hinzufügen:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Erstellt eine neue Präsentation, zu der das Video hinzugefügt wird
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Fügen wir das Video zur Präsentation hinzu – wir haben das KeepLocked‑Verhalten gewählt, weil wir
// nicht beabsichtigen, die Datei "veryLargeVideo.avi" zu öffnen.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch
// niedrig während des gesamten Lebenszyklus des pres-Objekts 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Eine große Datei über BLOB aus einer Präsentation exportieren**
Aspose.Slides for C++ ermöglicht den Export großer Dateien (z. B. einer Audio‑ oder Videodatei) über einen BLOB‑basierten Prozess aus Präsentationen. Beispielsweise müssen Sie möglicherweise eine große Mediendatei aus einer Präsentation extrahieren, ohne dass die Datei in den Speicher Ihres Computers geladen wird. Durch den Export über den BLOB‑Prozess bleibt der Speicherverbrauch niedrig. 

Der folgende C++‑Code demonstriert die beschriebene Operation:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Erstellt eine Instanz von Presentation und sperrt die Datei "hugePresentationWithAudiosAndVideos.pptx" file.

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Speichern wir jedes Video in eine Datei. Um hohen Speicherverbrauch zu vermeiden, benötigen wir einen Puffer, der verwendet wird
// um die Daten vom Videostream der Präsentation in einen Stream für die neu erstellte Videodatei zu übertragen.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
    auto video = pres->get_Videos()->idx_get(index);

    // Öffnet den Videostream der Präsentation. Bitte beachten Sie, dass wir absichtlich vermieden, Methoden zu nutzen
    // wie video->get_BinaryData - weil diese Methode ein Byte-Array mit dem gesamten Video zurückgibt, was dann
    // dazu führt, dass Bytes in den Speicher geladen werden. Wir verwenden video->GetStream, das einen Stream zurückgibt - und NICHT
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

// Falls nötig, können Sie dieselben Schritte für Audiodateien anwenden.
```

### **Ein Bild als BLOB zu einer Präsentation hinzufügen**
Mit den Methoden aus dem Interface [**IImageCollection**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_image_collection) und der Klasse [**ImageCollection**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.image_collection) können Sie ein großes Bild als Stream hinzufügen, sodass es als BLOB behandelt wird. 

Der folgende C++‑Code zeigt, wie Sie ein großes Bild über den BLOB‑Prozess hinzufügen:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// erstellt eine neue Präsentation, zu der das Bild hinzugefügt wird.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Fügen wir das Bild zur Präsentation hinzu – wir wählen das KeepLocked‑Verhalten, weil wir
// NICHT beabsichtigen, die Datei "largeImage.png" zu öffnen.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Speichert die Präsentation. Während eine große Präsentation ausgegeben wird, bleibt der Speicherverbrauch 
// niedrig während des gesamten Lebenszyklus des pres‑Objekts
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Speicher und große Präsentationen**

Typischerweise benötigen Computer zum Laden einer großen Präsentation viel temporären Speicher. Der gesamte Inhalt der Präsentation wird in den Speicher geladen und die Quelldatei, aus der die Präsentation geladen wurde, wird nicht mehr verwendet. 

Betrachten Sie eine große PowerPoint‑Präsentation (large.pptx), die eine 1,5 GB‑Videodatei enthält. Die Standardmethode zum Laden der Präsentation wird in diesem C++‑Code beschrieben:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Diese Methode verbraucht jedoch rund 1,6 GB temporären Speicher. 

### **Eine große Präsentation als BLOB laden**

Über einen BLOB‑basierten Prozess können Sie eine große Präsentation laden und dabei wenig Speicher verwenden. Dieser C++‑Code beschreibt die Implementierung, bei der der BLOB‑Prozess zum Laden einer großen Präsentationsdatei (large.pptx) verwendet wird:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Ordner für temporäre Dateien ändern**

Wenn der BLOB‑Prozess verwendet wird, erstellt Ihr Computer temporäre Dateien im Standardordner für temporäre Dateien. Möchten Sie die temporären Dateien in einem anderen Ordner speichern, können Sie die Einstellung für den Speicherort mit `TempFilesRootPath` ändern:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Wenn Sie `TempFilesRootPath` verwenden, erstellt Aspose.Slides keinen Ordner zum Speichern temporärer Dateien automatisch. Sie müssen den Ordner manuell anlegen. 
{{% /alert %}}

### **Präsentationsobjekte freigeben, um Speicher zu löschen**

Beim Verarbeiten großer Präsentationen sollten Sie sicherstellen, dass die [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz ordnungsgemäß freigegeben wird, damit der belegte Speicher wieder freigegeben wird. Rufen Sie nach dem Gebrauch der Präsentation `Dispose()` auf, um nicht verwaltete Ressourcen zu löschen.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...Verarbeitung der Präsentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Ressourcen explizit freigeben.
presentation->Dispose();
```

## **FAQ**

**Welche Daten in einer Aspose.Slides‑Präsentation werden als BLOB behandelt und von BLOB‑Optionen gesteuert?**

Große Binärobjekte wie Bilder, Audio‑ und Videodateien werden als BLOB behandelt. Auch die gesamte Präsentationsdatei unterliegt der BLOB‑Verarbeitung, wenn sie geladen oder gespeichert wird. Diese Objekte werden durch BLOB‑Richtlinien geregelt, mit denen Sie die Speichernutzung steuern und bei Bedarf auf temporäre Dateien auslagern können.

**Wo konfiguriere ich die BLOB‑Verarbeitungsregeln beim Laden einer Präsentation?**

Verwenden Sie [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/) zusammen mit [BlobManagementOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/blobmanagementoptions/). Dort legen Sie das In‑Memory‑Limit für BLOB fest, erlauben oder verbieten temporäre Dateien, wählen den Stammordner für temporäre Dateien und bestimmen das Verhalten beim Sperren der Quelle.

**Beeinflussen BLOB‑Einstellungen die Performance und wie finde ich das richtige Gleichgewicht zwischen Geschwindigkeit und Speicher?**

Ja. Das Halten von BLOBs im Speicher maximiert die Geschwindigkeit, erhöht jedoch den RAM‑Verbrauch; ein niedrigeres Speicherlimit verlagert mehr Arbeit auf temporäre Dateien, reduziert den RAM‑Verbrauch, führt aber zu zusätzlichem I/O. Nutzen Sie die Methode [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/de/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/), um das optimale Gleichgewicht für Ihren Anwendungsfall und Ihre Umgebung zu finden.

**Hilft BLOB bei der Öffnung extrem großer Präsentationen (z. B. mehrere Gigabyte)?**

Ja. [BlobManagementOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/blobmanagementoptions/) sind für solche Szenarien konzipiert: Das Aktivieren temporärer Dateien und das Verwenden von Source‑Locking können den Spitzen‑RAM‑Verbrauch deutlich senken und die Verarbeitung sehr großer Decks stabilisieren.

**Kann ich BLOB‑Richtlinien beim Laden aus Streams anstelle von Festplattendateien verwenden?**

Ja. dieselben Regeln gelten für Streams: Die Präsentationsinstanz kann den Eingabestream besitzen und sperren (je nach gewähltem Sperrmodus), und temporäre Dateien werden verwendet, sofern sie erlaubt sind, sodass der Speicherverbrauch während der Verarbeitung vorhersehbar bleibt.