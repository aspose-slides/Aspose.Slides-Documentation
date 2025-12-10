---
title: Präsentationen in C++ öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/cpp/open-presentation/
keywords:
- PowerPoint öffnen
- OpenDocument öffnen
- Präsentation öffnen
- PPTX öffnen
- PPT öffnen
- ODP öffnen
- Präsentation laden
- PPTX laden
- PPT laden
- ODP laden
- geschützte Präsentation
- große Präsentation
- externe Ressource
- binäres Objekt
- C++
- Aspose.Slides
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für C++ – schnell, zuverlässig und voll funktionsfähig."
---

## **Übersicht**

Neben dem Erstellen von PowerPoint-Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen darüber abrufen, Folieninhalt bearbeiten, neue Folien hinzufügen, vorhandene entfernen und mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse und übergeben den Dateipfad an ihren Konstruktor.

Das folgende C++-Beispiel zeigt, wie man eine Präsentation öffnet und die Folienanzahl ermittelt:
```cpp
// Instanziieren Sie die Presentation‑Klasse und übergeben Sie einen Dateipfad an ihren Konstruktor.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) Methode der [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) Klasse, um sie zu entschlüsseln und zu laden. Der folgende C++-Code demonstriert diesen Vorgang:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Operationen an der entschlüsselten Präsentation durchführen.

presentation->Dispose();
```


## **Große Präsentationen öffnen**

Aspose.Slides bietet Optionen – insbesondere die [get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) Methode in der [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) Klasse – um das Laden großer Präsentationen zu unterstützen.

Der folgende C++-Code demonstriert das Laden einer großen Präsentation (zum Beispiel 2 GB):
```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Wählen Sie das KeepLocked‑Verhalten—die Präsentationsdatei bleibt für die Lebensdauer von
// der Presentation‑Instanz gesperrt, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// Die große Präsentation wurde geladen und kann verwendet werden, während der Speicherverbrauch niedrig bleibt.

// Änderungen an der Präsentation vornehmen.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Speichern Sie die Präsentation in einer anderen Datei. Der Speicherverbrauch bleibt bei diesem Vorgang niedrig.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Nicht tun! Eine Ein‑/Ausgabe‑Ausnahme wird ausgelöst, weil die Datei gesperrt bleibt, bis das Präsentationsobjekt entsorgt wird.
File::Delete(filePath);

presentation->Dispose();

// Es ist hier in Ordnung. Die Quelldatei ist nicht mehr durch das Präsentationsobjekt gesperrt.
File::Delete(filePath);
```


{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird und das Laden verlangsamen kann. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation anstelle eines Streams zu verwenden.

Beim Erstellen einer Präsentation, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie [BLOB management](/slides/de/cpp/manage-blob/) nutzen, um den Speicherverbrauch zu reduzieren.
{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt das [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) Interface bereit, mit dem Sie externe Ressourcen verwalten können. Der folgende C++-Code zeigt, wie das `IResourceLoadingCallback` Interface verwendet wird:
```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Laden Sie ein Ersatzbild.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Setzen Sie eine Ersatz-URL.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Überspringen Sie alle anderen Bilder.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint-Präsentation kann die folgenden Arten von eingebetteten Binärobjekten enthalten:

- VBA-Projekt (zugänglich über [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Durch die Verwendung der Methode [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) können Sie eine Präsentation ohne eingebettete Binärobjekte laden.

Diese Methode ist nützlich, um potenziell schädliche Binärinhalte zu entfernen. Der folgende C++-Code demonstriert, wie man eine Präsentation ohne eingebettete Binärinhalte lädt:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Vorgänge an der Präsentation ausführen.

presentation->Dispose();
```


## **FAQ**

**Wie kann ich feststellen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Beim Laden erhalten Sie eine Parsing-/Formatvalidierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, aber später [rendering/export](/slides/de/cpp/convert-presentation/) kann Schriftarten ersetzen. [Configure font substitutions](/slides/de/cpp/font-substitution/) oder [add the required fonts](/slides/de/cpp/custom-font/) zur Laufzeitumgebung hinzufügen.

**Wie verhält es sich mit eingebetteten Medien (Video/Audio) beim Öffnen?**

Sie werden als Präsentationsressourcen verfügbar. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung zugänglich sind; andernfalls kann [rendering/export](/slides/de/cpp/convert-presentation/) die Medien weglassen.