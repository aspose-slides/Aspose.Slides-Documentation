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
- Binärobjekt
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument‑Präsentationen in C++ öffnen, Öffnungspasswörter angeben, das Laden von Ressourcen steuern und mit Aspose.Slides für C++ den Speicherverbrauch reduzieren."
---
## **Einleitung**

[Aspose.Slides für C++](https://products.aspose.com/slides/de/cpp/) kann PowerPoint‑ und OpenDocument‑Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie deren Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im ursprünglichen oder einem anderen unterstützten Format speichern.

Das Laden‑Verhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/) angepasst werden. Beispielsweise können Sie ein Öffnungskennwort angeben, große Binärobjekte außerhalb des Speichers halten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Nach dem Laden einer Datei oder eines Streams können Sie [das ursprüngliche Präsentationsformat bestimmen](/slides/de/cpp/detect-presentation-source-format/), um zu entscheiden, wie Ihre Anwendung damit umgeht.

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad dem Konstruktor von [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/). Entsorgen Sie das Presentation‑Objekt nach Gebrauch, damit Dateihandles, temporäre Daten und andere Ressourcen sofort freigegeben werden.

Das folgende C++‑Beispiel zeigt, wie eine Präsentation geöffnet und die Folienzahl ermittelt wird:

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

Ein Öffnungskennwort verschlüsselt den Inhalt der Präsentation. Um die gesamte Präsentation zu laden, übergeben Sie das korrekte Kennwort an [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) und übergeben Sie die Optionen dem Konstruktor von [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/). Das Laden schlägt fehl, wenn das Kennwort fehlt oder falsch ist.

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

Für Kennwort‑Erkennung, -Validierung und Verschlüsselungs‑Workflows siehe [Password‑Protect Presentations](/slides/de/cpp/password-protected-presentation/). Wurde eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteigenschaften gespeichert, können diese ohne Kennwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/cpp/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) steuert, wie Aspose.Slides große binäre Objekte wie Bilder, Audio und Video behandelt. Sie können die Quelldatei gesperrt halten, temporäre Dateien zulassen und die Menge der im Speicher behaltenen BLOB‑Daten begrenzen.

Der folgende C++‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

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

{{% alert color="info" title="Note" %}}
Mit `PresentationLockingBehavior::KeepLocked` bleibt die Quelldatei gesperrt, bis das `Presentation`‑Objekt entsorgt wird. Verschieben, Überschreiben oder Löschen der Quelldatei ist nicht erlaubt, solange das Objekt lebt.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Für große Präsentationen ist daher ein Dateipfad im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/cpp/manage-blob/) für weitere Speicher‑ und Speicherverwaltungsoptionen.
{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) akzeptiert eine Implementierung von [IResourceLoadingCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/iresourceloadingcallback/). Der Callback kann Ersatzdaten bereitstellen, eine Ressource umleiten, den Standard‑Lader verwenden oder die Ressource überspringen. Dies ist nützlich, wenn Präsentationen externe Bilder enthalten, die nach anwendungsspezifischen Sicherheits‑ oder Speicherregeln aufgelöst werden müssen.

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

Setzen Sie `true` für [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/), um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu persistieren.

Diese Option reduziert die Gefahr unerwünschter eingebetteter Payloads, stellt aber kein vollständiges Malware‑Erkennungs‑ oder Inhalts‑Sanitärsystem dar.

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

Aspose.Slides wirft beim Laden eine Parsing‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler separat von einem falschen Kennwort‑Fehler, damit die Anwendung die Ursache genau melden kann.

**Was passiert, wenn erforderliche Schriften fehlen?**

Die Präsentation kann trotzdem geladen werden, aber Rendering und Export können Schriften substituieren. Sie können [Schrift‑Substitution konfigurieren](/slides/de/cpp/font-substitution/) oder [benutzerdefinierte Schriften bereitstellen](/slides/de/cpp/custom-font/), um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch deren eingebettete Medien?**

Eingebettete Audio‑ und Videodateien werden über das Objektmodell der Präsentation verfügbar. Externe Ressourcen werden gemäß dem konfigurierten Ressourc‑Lade‑Verhalten aufgelöst und können nicht verfügbar sein, wenn deren Speicherorte nicht erreichbar sind.