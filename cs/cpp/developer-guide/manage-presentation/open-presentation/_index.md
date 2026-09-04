---
title: Otevírání prezentací v C++
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/cpp/open-presentation/
keywords:
- otevřít PowerPoint
- otevřít OpenDocument
- otevřít prezentaci
- otevřít PPTX
- otevřít PPT
- otevřít ODP
- načíst prezentaci
- načíst PPTX
- načíst PPT
- načíst ODP
- chráněná prezentace
- velká prezentace
- externí zdroj
- binární objekt
- C++
- Aspose.Slides
description: "Naučte se, jak v C++ otevírat prezentace PowerPoint a OpenDocument, zadávat otevírací hesla, řídit načítání zdrojů a snižovat využití paměti pomocí Aspose.Slides pro C++."
---
## **Úvod**

[Aspose.Slides for C++](https://products.aspose.com/slides/cs/cpp/) může načíst prezentace PowerPoint a OpenDocument ze souborů a proudů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/). Například můžete zadat otevírací heslo, uchovávat velké binární objekty mimo paměť, řídit externí zdroje nebo vynechat vložená binární data.

## **Otevírání prezentací**

Pro otevření existující prezentace předáte její cestu k souboru konstruktoru [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Po použití prezentaci uvolněte, aby byly rychle uvolněny souborové handly, dočasná data a další zdroje.

Následující příklad v C++ ukazuje, jak otevřít prezentaci a získat počet snímků:

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

## **Otevírání prezentací chráněných heslem**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace předáte správné heslo metodě [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/) a předáte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Načítání selže, pokud heslo chybí nebo je nesprávné.

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

Pro detekci hesla, validaci a šifrovací pracovní postupy viz [Ochrana prezentací heslem](/slides/cs/cpp/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti číst bez hesla; viz [Správa vlastností prezentace](/slides/cs/cpp/presentation-properties/).

## **Otevírání velkých prezentací**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) řídí, jak Aspose.Slides zachází s velkými binárními objekty, jako jsou obrázky, audio a video. Můžete udržet zdrojový soubor zamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující kód v C++ ukazuje načtení velké prezentace (například 2 GB):

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

{{% alert color="info" title="Poznámka" %}}
S `PresentationLockingBehavior::KeepLocked` zdrojový soubor zůstává zamčený, dokud není objekt `Presentation` uvolněn. Nehýbejte, nepřepisujte ani nesmažte zdrojový soubor, dokud je tento objekt aktivní.

Aspose.Slides může při načítání kopírovat obsah vstupního proudu. Pro velké prezentace je cesta k souboru obecně efektivnější než proud. Viz [Správa BLOB](/slides/cs/cpp/manage-blob/) pro další možnosti úložiště a správy paměti.
{{% /alert %}}

## **Řízení externích zdrojů**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) přijímá implementaci [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iresourceloadingcallback/). Callback může poskytnout náhradní data, přesměrovat zdroj, použít výchozí načítání nebo zdroj přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které je třeba řešit podle specifických bezpečnostních nebo úložných pravidel aplikace.

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

## **Načítání prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje nebo nechce zachovat. Příklady zahrnují:

- projekty VBA, dostupné přes [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_vbaproject/);
- vložená data OLE, dostupná přes [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- data ovládacích prvků ActiveX, dostupná přes [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Při načítání předáte `true` metodě [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/), aby se tato binární data odstranila. Uložte načtenou prezentaci, aby se výsledek sanitizoval.

Tato možnost snižuje riziko nechtěných vložených nákladů, ale není kompletním systémem pro detekci malwaru nebo sanitaci obsahu.

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

## **Často kladené otázky**

**Jak rozpoznat, že soubor je poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyhodí výjimku při parsování nebo formátu. Tuto chybu ošetřete odděleně od chyby nesprávného hesla, aby aplikace mohla přesně oznámit příčinu.

**Co se stane, pokud chybí požadovaná písma?**

Prezentace se i tak může načíst, ale při vykreslování a exportu může dojít k substituci písem. Můžete [nastavit substituci písem](/slides/cs/cpp/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/cpp/custom-font/), aby byl výstup předvídatelnější.

**Načítá se při načítání prezentace také její vložená média?**

Vložený audio a video jsou dostupné prostřednictvím modelu objektů prezentace. Externí zdroje jsou řešeny podle nastaveného chování načítání zdrojů a mohou být nedostupné, pokud není možné přistupovat k jejich umístěním.