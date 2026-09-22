---
title: Öppna presentationer i C++
linktitle: Öppna presentation
type: docs
weight: 20
url: /sv/cpp/open-presentation/
keywords:
- öppna PowerPoint
- öppna OpenDocument
- öppna presentation
- öppna PPTX
- öppna PPT
- öppna ODP
- ladda presentation
- ladda PPTX
- ladda PPT
- ladda ODP
- skyddad presentation
- stor presentation
- extern resurs
- binärt objekt
- C++
- Aspose.Slides
description: "Lär dig hur du öppnar PowerPoint‑ och OpenDocument‑presentationer i C++, anger öppningslösenord, styr resurshämtning och minskar minnesanvändning med Aspose.Slides för C++."
---
## **Introduktion**

[Aspose.Slides for C++](https://products.aspose.com/slides/sv/cpp/) kan läsa in PowerPoint‑ och OpenDocument‑presentationer från filer och strömmar. När en presentation har lästs in kan du undersöka dess struktur, redigera bilder, hantera resurser och spara den i originalformatet eller ett annat stödd format.

Laddningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/). Till exempel kan du ange ett öppningslösenord, hålla stora binära objekt utanför minnet, styra externa resurser eller utelämna inbäddade binära data.

## **Öppna presentationer**

Efter att ha läst in en fil eller ström kan du [fastställa dess ursprungliga presentationsformat](/slides/sv/cpp/detect-presentation-source-format/) för att välja hur din applikation bearbetar den.

För att öppna en befintlig presentation, skicka dess filsökväg till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/). Avsluta presentationen efter användning så att filhandtag, temporära data och andra resurser frigörs omedelbart.

Följande C++‑exempel visar hur man öppnar en presentation och får dess bildantal:

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

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, skicka det korrekta lösenordet till [LoadOptions::set_Password](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_password/) och skicka alternativet till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/). Inläsning misslyckas när lösenordet saknas eller är felaktigt.

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

För lösenorddetektering, validering och krypteringsarbetsflöden, se [Password-Protect Presentations](/slides/sv/cpp/password-protected-presentation/). Om en krypterad presentation medvetet sparats med offentliga dokumentegenskaper, kan dessa egenskaper läsas utan lösenord; se [Manage Presentation Properties](/slides/sv/cpp/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) styr hur Aspose.Slides hanterar stora binära objekt som bilder, ljud och video. Du kan behålla källfilen låst, tillåta tillfälliga filer och begränsa mängden BLOB‑data som behålls i minnet.

Följande C++‑kod demonstrerar inläsning av en stor presentation (till exempel 2 GB):

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
Med `PresentationLockingBehavior::KeepLocked` förblir källfilen låst tills `Presentation`‑objektet avslutas. Flytta, skriv över eller ta inte bort källfilen medan objektet är aktivt.

Aspose.Slides kan kopiera innehållet i en indataström under inläsning. För stora presentationer är en filsökväg därför vanligtvis mer effektiv än en ström. Se [Manage BLOBs](/slides/sv/cpp/manage-blob/) för ytterligare lagrings- och minneshanteringsalternativ.
{{% /alert %}}

## **Styr externa resurser**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) accepterar en implementering av [IResourceLoadingCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iresourceloadingcallback/). Återanropet kan tillhandahålla ersättningsdata, omdirigera en resurs, använda standardladdaren eller hoppa över resursen. Detta är användbart när presentationer innehåller externa bilder som måste lösas enligt applikationsspecifika säkerhets- eller lagringsregler.

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

## **Läs in presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddad binär data som en applikation inte behöver eller inte vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_vbaproject/);
- inbäddad OLE‑data, tillgänglig via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- ActiveX‑kontrolldata, tillgänglig via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/sv/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Skicka `true` till [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) för att ta bort denna binära data vid inläsning. Spara den inlästa presentationen för att behålla det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade data, men det är inte ett fullständigt system för malware‑detektion eller innehållssanering.

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

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Aspose.Slides kastar ett parsnings‑ eller formatfel under inläsning. Hantera detta misslyckande separat från ett felaktigt lösenord‑fel så att applikationen kan rapportera orsaken korrekt.

**Vad händer om nödvändiga teckensnitt saknas?**

Presentationen kan fortfarande läsas in, men rendering och export kan ersätta teckensnitt. Du kan [configure font substitution](/slides/sv/cpp/font-substitution/) eller [provide custom fonts](/slides/sv/cpp/custom-font/) för att göra resultatet mer förutsägbart.

**Laddar inläsning av en presentation även dess inbäddade media?**

Inbäddat ljud och video blir tillgängliga via presentationsobjektmodellen. Externa resurser löses upp enligt den konfigurerade resursningsläsningsbeteendet och kan vara otillgängliga om deras platser inte kan nås.