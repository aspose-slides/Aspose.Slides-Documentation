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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in C++ öffnen, Öffnungspasswörter angeben, das Laden von Ressourcen steuern und mit Aspose.Slides für C++ den Speicherverbrauch reduzieren."
---
## **Einleitung**

[Aspose.Slides für C++](https://products.aspose.com/slides/de/cpp/) kann PowerPoint‑ und OpenDocument‑Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie ihre Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im Originalformat oder in einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/) angepasst werden. Beispielsweise können Sie ein Öffnungspasswort angeben, große Binärobjekte außerhalb des Speichers behalten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad dem Konstruktor [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/). Entsorgen Sie die Präsentation nach Gebrauch, damit Dateihandles, temporäre Daten und andere Ressourcen umgehend freigegeben werden.

Das folgende C++‑Beispiel zeigt, wie man eine Präsentation öffnet und die Folienanzahl ermittelt:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungspasswort verschlüsselt den Inhalt der Präsentation. Um die komplette Präsentation zu laden, übergeben Sie das korrekte Passwort an [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) und übergeben Sie die Optionen dem Konstruktor [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/). Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Für Passwort‑Erkennung, Validierung und Verschlüsselungs‑Workflows siehe [Password‑Protect Presentations](/slides/de/cpp/password-protected-presentation/). Wenn eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteneigenschaften gespeichert wurde, können diese ohne Passwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/cpp/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) steuert, wie Aspose.Slides binäre Großobjekte wie Bilder, Audio und Video behandelt. Sie können die Quelldatei gesperrt lassen, temporäre Dateien erlauben und die Menge an im Speicher behaltenen BLOB‑Daten begrenzen.

Das folgende C++‑Codebeispiel demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Hinweis" %}}
Mit `PresentationLockingBehavior::KeepLocked` bleibt die Quelldatei gesperrt, bis das `Presentation`‑Objekt entsorgt wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange dieses Objekt lebt.

Aspose.Slides kann den Inhalt eines Eingabestreams beim Laden kopieren. Für große Präsentationen ist daher ein Dateipfad im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/cpp/manage-blob/) für zusätzliche Speicher‑ und Speicherverwaltungsoptionen.
{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) akzeptiert eine Implementierung von [IResourceLoadingCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/iresourceloadingcallback/). Der Callback kann Ersatzdaten bereitstellen, eine Ressource umleiten, den Standard‑Lader verwenden oder die Ressource überspringen. Dies ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemäß anwendungsspezifischen Sicherheits‑ oder Speicherregeln aufgelöst werden müssen.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benötigt oder nicht behalten möchte. Beispiele sind:

- VBA‑Projekte, verfügbar über [IPresentation::get_VbaProject](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_vbaproject/);
- eingebettete OLE‑Daten, verfügbar über [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- ActiveX‑Steuerungsdaten, verfügbar über [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/de/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Übergeben Sie `true` an [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/), um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu persistieren.

Diese Option reduziert die Exposition gegenüber unerwünschten eingebetteten Payloads, ist jedoch kein vollständiges Malware‑Erkennungs‑ oder Inhalts‑Sanitärsystem.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **FAQ**

**Wie kann ich feststellen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parser‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler separat von einem falschen Passwort‑Fehler, damit die Anwendung die Ursache genau melden kann.

**Was passiert, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann dennoch geladen werden, aber die Darstellung und der Export können Schriftarten substituieren. Sie können die [configure font substitution](/slides/de/cpp/font-substitution/) oder [provide custom fonts](/slides/de/cpp/custom-font/) nutzen, um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch deren eingebettete Medien?**

Eingebettete Audio‑ und Videodaten werden über das Präsentations‑Objektmodell verfügbar. Externe Ressourcen werden gemäß dem konfigurierten Ressourcen‑Ladeverhalten aufgelöst und können nicht verfügbar sein, wenn ihre Speicherorte nicht erreichbar sind.