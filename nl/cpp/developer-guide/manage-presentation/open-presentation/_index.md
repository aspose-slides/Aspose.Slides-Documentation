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
- binair object
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument‑presentaties in C++ kunt openen, openingswachtwoorden kunt opgeven, het laden van resources kunt beheersen en het geheugenverbruik kunt verminderen met Aspose.Slides voor C++."
---
## **Inleiding**

[Aspose.Slides for C++](https://products.aspose.com/slides/nl/cpp/) kan PowerPoint- en OpenDocument‑presentaties laden vanuit bestanden en streams. Nadat een presentatie is geladen, kunt u de structuur inspecteren, dia’s bewerken, bronnen beheren en deze opslaan in het oorspronkelijke of een ander ondersteund formaat.

Het laadgedrag kan worden aangepast via de klasse [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/). Bijvoorbeeld kunt u een openings‑wachtwoord opgeven, grote binaire objecten buiten het geheugen houden, externe bronnen beheersen of ingebedde binaire data weglaten.

## **Presentaties openen**

Om een bestaande presentatie te openen, geeft u het bestandspad door aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/). Maak de presentatie vrij nadat u deze hebt gebruikt zodat bestands‑handles, tijdelijke gegevens en andere bronnen meteen worden vrijgegeven.

Het volgende C++‑voorbeeld toont hoe u een presentatie opent en het aantal dia’s ophaalt:

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

Een openingswachtwoord codeert de inhoud van de presentatie. Om de volledige presentatie te laden, geeft u het juiste wachtwoord door aan [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/) en geeft u de opties door aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/). Laden mislukt wanneer het wachtwoord ontbreekt of onjuist is.

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

Voor wachtwoorddetectie, -validatie en encryptieworkflows, zie [Wachtwoord‑beveiligde presentaties](/slides/nl/cpp/password-protected-presentation/). Als een versleutelde presentatie opzettelijk is opgeslagen met openbare documenteigenschappen, kunnen die eigenschappen worden gelezen zonder wachtwoord; zie [Presentatie‑eigenschappen beheren](/slides/nl/cpp/presentation-properties/).

## **Grote presentaties openen**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) bepaalt hoe Aspose.Slides binaire grote objecten zoals afbeeldingen, audio en video verwerkt. U kunt het bronbestand vergrendeld houden, tijdelijke bestanden toestaan en de hoeveelheid BLOB‑gegevens die in het geheugen worden bewaard beperken.

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
Met `PresentationLockingBehavior::KeepLocked` blijft het bronbestand vergrendeld totdat het `Presentation`‑object wordt vrijgegeven. Verplaats, overschrijf of verwijder het bronbestand niet zolang dat object actief is.

Aspose.Slides kan de inhoud van een invoerstroom kopiëren tijdens het laden. Voor grote presentaties is een bestandspad daarom over het algemeen efficiënter dan een stream. Zie [BLOB‑beheer](/slides/nl/cpp/manage-blob/) voor extra opslag‑ en geheugenbeheermogelijkheden.
{{% /alert %}}

## **Externe bronnen beheren**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) accepteert een implementatie van [IResourceLoadingCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iresourceloadingcallback/). De callback kan vervangende gegevens leveren, een bron omleiden, de standaardloader gebruiken of de bron overslaan. Dit is nuttig wanneer presentaties externe afbeeldingen bevatten die moeten worden opgelost volgens toepassingsspecifieke beveiligings‑ of opslagregels.

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

Een presentatie kan ingebedde binaire gegevens bevatten die een applicatie niet nodig heeft of niet wil behouden. Voorbeelden omvatten:
- VBA‑projecten, beschikbaar via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_vbaproject/);
- ingebedde OLE‑gegevens, beschikbaar via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- ActiveX‑besturingsgegevens, beschikbaar via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Geef `true` door aan [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) om deze binaire gegevens tijdens het laden te verwijderen. Sla de geladen presentatie op om het opgeschoonde resultaat te behouden.

Deze optie vermindert de blootstelling aan ongewenste ingebedde payloads, maar vormt geen volledig malware‑detectie‑ of inhouds‑sanitisatiesysteem.

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

Aspose.Slides gooit tijdens het laden een parser‑ of format‑exception. Verwerk die fout afzonderlijk van een onjuist‑wachtwoord‑fout, zodat de applicatie de oorzaak accuraat kan rapporteren.

**Wat gebeurt er als vereiste lettertypen ontbreken?**

De presentatie kan nog steeds worden geladen, maar weergave en export kunnen lettertypen vervangen. U kunt [lettertype‑substitutie configureren](/slides/nl/cpp/font-substitution/) of [aangepaste lettertypen leveren](/slides/nl/cpp/custom-font/) om de output voorspelbaarder te maken.

**Laadt het laden van een presentatie ook de ingebedde media?**

Ingebedde audio en video worden beschikbaar via het presentatiemodel. Externe bronnen worden opgelost volgens het geconfigureerde resource‑laadgedrag en kunnen onbeschikbaar zijn als hun locaties niet toegankelijk zijn.