---
title: Presentaties openen in C++
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/cpp/open-presentation/
keywords:
- PowerPoint openen
- OpenDocument openen
- presentatie openen
- PPTX openen
- PPT openen
- ODP openen
- presentatie laden
- PPTX laden
- PPT laden
- ODP laden
- beveiligde presentatie
- grote presentatie
- externe bron
- binaire object
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument‑presentaties kunt openen in C++, openingswachtwoorden kunt opgeven, het laden van bronnen kunt beheren en het geheugenverbruik kunt verminderen met Aspose.Slides voor C++."
---
## **Inleiding**

[Aspose.Slides for C++](https://products.aspose.com/slides/nl/cpp/) kan PowerPoint- en OpenDocument-presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kunt u de structuur inspecteren, dia's bewerken, bronnen beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan aangepast worden via de [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/) klasse. Bijvoorbeeld kunt u een openingswachtwoord opgeven, grote binaire objecten buiten het geheugen houden, externe bronnen beheren of ingebedde binaire gegevens weglaten.

## **Presentaties openen**

Na het laden van een bestand of stream, kunt u [bepalen wat het oorspronkelijke presentatieformaat is](/slides/nl/cpp/detect-presentation-source-format/) om te kiezen hoe uw applicatie het verwerkt.

Om een bestaande presentatie te openen, geeft u het bestands­pad door aan de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) constructor. Maak de presentatie vrij na gebruik zodat bestands‑handles, tijdelijke gegevens en andere bronnen onmiddellijk worden vrijgegeven.

Het volgende C++‑voorbeeld toont hoe u een presentatie opent en het aantal dia's opvraagt:

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

## **Wachtwoord‑beveiligde presentaties openen**

Een openingswachtwoord versleutelt de inhoud van de presentatie. Om de volledige presentatie te laden, geeft u het juiste wachtwoord door aan [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/) en geeft u de opties door aan de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) constructor. Het laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

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

Voor wachtwoorddetectie, validatie en versleutelingsworkflows, zie [Password-Protect Presentations](/slides/nl/cpp/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen zonder wachtwoord gelezen worden; zie [Manage Presentation Properties](/slides/nl/cpp/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) regelt hoe Aspose.Slides binaire grote objecten zoals afbeeldingen, audio en video behandelt. U kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen worden bewaard beperken.

De volgende C++‑code demonstreert het laden van een grote presentatie (bijvoorbeeld 2 GB):

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
Met `PresentationLockingBehavior::KeepLocked` blijft het bronbestand vergrendeld tot het `Presentation`‑object wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet zolang dat object bestaat.
{{% /alert %}}

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad doorgaans efficiënter dan een stream. Zie [Manage BLOBs](/slides/nl/cpp/manage-blob/) voor extra opslag‑ en geheugen‑beheeropties.

## **Externe bronnen beheren**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) accepteert een implementatie van [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iresourceloadingcallback/). De callback kan vervangende gegevens leveren, een bron omleiden, de standaardloader gebruiken of de bron overslaan. Dit is handig wanneer presentaties externe afbeeldingen bevatten die moeten worden opgezocht volgens toepassingsspecifieke beveiligings‑ of opslagregels.

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

## **Presentaties laden zonder ingebedde binaire objecten**

Een presentatie kan ingebedde binaire gegevens bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden zijn:

- VBA‑projecten, beschikbaar via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_vbaproject/);
- ingebedde OLE‑gegevens, beschikbaar via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- ActiveX‑controlgegevens, beschikbaar via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Geef `true` door aan [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) om deze binaire gegevens tijdens het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar is geen volledige malware‑detectie‑ of content‑sanitisatiesysteem.

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

**Hoe kan ik zien dat een bestand corrupt is en niet geopend kan worden?**

Aspose.Slides geeft tijdens het laden een parse‑ of formaat‑exception. Verwerk die fout apart van een onjuist‑wachtwoord‑fout zodat de applicatie de oorzaak nauwkeurig kan melden.

**Wat gebeurt er als verplichte lettertypen ontbreken?**

De presentatie kan nog steeds geladen worden, maar weergave en export kunnen lettertypen substitueren. U kunt [lettertype‑substitutie configureren](/slides/nl/cpp/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/cpp/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video zijn beschikbaar via het presentatiemodel. Externe bronnen worden opgezocht volgens het geconfigureerde gedrag voor resource‑loading en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.