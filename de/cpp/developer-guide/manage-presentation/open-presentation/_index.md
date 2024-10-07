---
title: Präsentation Öffnen - C++ PowerPoint API
linktitle: Präsentation Öffnen
type: docs
weight: 20
url: /cpp/open-presentation/
keywords: "PowerPoint öffnen, PPTX, PPT, Präsentation öffnen, Präsentation laden, C++, CPP"
description: "Öffnen oder Laden von Präsentationen PPT, PPTX, ODP in C++"
---

Neben der Erstellung von PowerPoint-Präsentationen von Grund auf ermöglicht Aspose.Slides das Öffnen bestehender Präsentationen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen über die Präsentation abrufen, die Präsentation bearbeiten (Inhalt auf den Folien), neue Folien hinzufügen oder vorhandene entfernen usw.

## Präsentation Öffnen

Um eine bestehende Präsentation zu öffnen, müssen Sie einfach die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse instanziieren und den Dateipfad (der Präsentation, die Sie öffnen möchten) an ihren Konstruktor übergeben.

Dieser C++-Code zeigt Ihnen, wie Sie eine Präsentation öffnen und auch die Anzahl der Folien herausfinden können:

```c++
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = u"";

// Instanziiert die Presentation-Klasse und übergibt den Dateipfad an ihren Konstruktor
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// Gibt die Gesamtanzahl der Folien in der Präsentation aus
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```

## **Passwortgeschützte Präsentation öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, können Sie das Passwort über die [get_Password()](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_password/) Eigenschaft (aus der [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) Klasse) übergeben, um die Präsentation zu entschlüsseln und zu laden. Dieser C++-Code demonstriert die Operation:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"IHR_PASSWORT");
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
// Führen Sie einige Arbeiten mit der entschlüsselten Präsentation durch
```

## Große Präsentation öffnen

Aspose.Slides bietet Optionen (insbesondere die [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) Eigenschaft) unter der [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) Klasse, um Ihnen zu ermöglichen, große Präsentationen zu laden.

Dieser C++-Code demonstriert eine Operation, bei der eine große Präsentation (sagen wir 2 GB groß) geladen wird:

```c++
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // wählen wir das Verhalten KeepLocked - die "veryLargePresentation.pptx" wird für die
    // Lebensdauer der Präsentationsinstanz gesperrt, aber wir müssen sie nicht in den Speicher laden oder
    // in die temporäre Datei kopieren
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // Die große Präsentation wurde geladen und kann verwendet werden, aber der Speicherverbrauch bleibt gering.

    // Änderungen an der Präsentation vornehmen.
    pres->get_Slides()->idx_get(0)->set_Name(u"Sehr große Präsentation");

    // Die Präsentation wird in die andere Datei gespeichert. Der Speicherverbrauch bleibt während der Operation gering
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // Das kann man nicht tun! Eine IO-Ausnahme wird ausgelöst, da die Datei gesperrt ist, während die pres-Objekte
    // nicht freigegeben werden
    File::Delete(pathToVeryLargePresentationFile);
}

// Es ist in Ordnung, dies hier zu tun. Die Quelldatei wird nicht vom pres-Objekt gesperrt
File::Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass der Inhalt der Präsentation kopiert wird, was zu langsamen Ladezeiten führt. Daher empfehlen wir dringend, dass Sie beim Laden einer großen Präsentation den Dateipfad der Präsentation und nicht ihren Stream verwenden.

Wenn Sie eine Präsentation erstellen möchten, die große Objekte (Video, Audio, große Bilder usw.) enthält, können Sie die [Blob-Funktion](https://docs.aspose.com/slides/cpp/manage-blob/) verwenden, um den Speicherverbrauch zu reduzieren.

{{%/alert %}} 


## Präsentation laden

Aspose.Slides stellt [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) mit einer einzelnen Methode zur Verfügung, um externe Ressourcen zu verwalten. Dieser C++-Code zeigt Ihnen, wie Sie das `IResourceLoadingCallback`-Interface verwenden:

```c++
// Der Pfad zum Dokumentenverzeichnis.
System::String dataDir = GetDataPath();

auto opts = System::MakeObject<LoadOptions>();
opts->set_ResourceLoadingCallback(System::MakeObject<ImageLoadingHandler>(dataDir));
auto presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", opts);
```

```c++
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ImageLoadingHandler(String dataDir)
        : m_dataDir(dataDir)
    {
    }

    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                System::ArrayPtr<uint8_t> imageBytes = File::ReadAllBytes(Path::Combine(m_dataDir, u"aspose-logo.jpg"));
                args->SetData(imageBytes);
                return ResourceLoadingAction::UserProvided;
            }
            catch (System::Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }

        if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Setzt die Ersatz-URL
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Alle anderen Bilder überspringen
        return ResourceLoadingAction::Skip;
    }

private:
    String m_dataDir;
};
```

<h2>Präsentation öffnen und speichern</h2>

<a name="cplusplus-open-save-presentation"><strong>Schritte: Präsentation in C++ öffnen und speichern</strong></a>

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse und übergeben Sie die Datei, die Sie öffnen möchten.

2. Speichern Sie die Präsentation.

   ```c++
   	const String outPath = u"../out/SaveToFile_out.ppt";
   	
   	SharedPtr<Presentation> pres = MakeObject<Presentation>();
   
   	// pres->get_ProtectionManager()->Encrypt(u"pass");
   	// ...arbeiten Sie hier..
   
   	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
   ```