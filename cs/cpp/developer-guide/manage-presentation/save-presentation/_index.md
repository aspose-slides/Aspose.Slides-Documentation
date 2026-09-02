---
title: Ukládání prezentací v C++
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/cpp/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do streamu
- předdefinovaný typ zobrazení
- Přísný formát Office Open XML
- režim Zip64
- obnovení náhledu
- průběh ukládání
- C++
- Aspose.Slides
description: "Objevte, jak ukládat prezentace v C++ pomocí Aspose.Slides — exportovat do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Open Presentations in C++](/slides/cs/cpp/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro C++ můžete uložit do **souboru** nebo **streamu**. Tento článek vysvětluje různé způsoby uložení prezentace.

## **Uložit prezentace do souborů**

Uložení prezentace do souboru provedete voláním metody `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Předáte název souboru a formát uložení metodě. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Proveďte zde nějakou práci...

// Uložte prezentaci do souboru.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Uložit prezentace do streamů**

Můžete uložit prezentaci do streamu předáním výstupního streamu metodě `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů streamů. V následujícím příkladu vytvoříme novou prezentaci a uložíme ji do souborového streamu.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Uložte prezentaci do streamu.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Uložit prezentace s předdefinovaným typem zobrazení**

Aspose.Slides vám umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, prostřednictvím třídy [ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/). Použijte metodu [set_LastView](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/set_lastview/) s hodnotou z výčtu [ViewType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewtype/).

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Uložit prezentace ve formátu Strict Office Open XML**

Aspose.Slides vám umožňuje uložit prezentaci ve formátu Strict Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/) a nastavte její vlastnost conformance při ukládání. Pokud nastavíte `Conformance.Iso29500_2008_Strict`, výstupní soubor se uloží ve formátu Strict Office Open XML.

Příklad níže vytvoří prezentaci a uloží ji ve formátu Strict Office Open XML.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Uložte prezentaci ve formátu Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Uložit prezentace ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je ZIP archiv, který omezuje 4 GB (2^32 bajtů) limity na nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru a celkovou velikost archivu, a také omezuje archiv na 65 535 (2^16‑1) souborů. ZIP64 formátová rozšíření tyto limity zvyšují na 2^64.

Metoda [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) vám umožňuje vybrat, kdy použít rozšíření formátu ZIP64 při ukládání souboru Office Open XML.

Tato metoda může být použita s následujícími režimy:

- `IfNecessary` používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- `Never` nikdy nepoužívá rozšíření ZIP64.
- `Always` vždy používá rozšíření ZIP64.

Následující kód ukazuje, jak uložit prezentaci jako soubor PPTX s povolenými rozšířeními ZIP64:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="POZNÁMKA" color="warning" %}}
Když uložíte s `Zip64Mode.Never`, vyvolá se [PptxException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxexception/) pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Uložit prezentace ve formátu Office Open XML s úrovněmi komprese**

Při práci s velkými prezentacemi můžete upravit úroveň komprese, aby byl vyvážen velikost souboru a doba zpracování. V závislosti na požadavcích můžete preferovat rychlejší zpracování nebo menší výstupní soubory.

Aspose.Slides poskytuje metodu [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/), která vám umožňuje určit úroveň komprese při ukládání prezentace ve formátu Office Open XML.

K dispozici jsou následující úrovně komprese:

- **None**: Žádná komprese. Soubory jsou uloženy tak, jak jsou.
- **Level1:** Nejrychlejší komprese s nejnižším poměrem komprese.
- **Level2:** Rychlejší komprese s mírně lepším poměrem než **Level1**.
- **Level3:** Poskytuje lepší kompresi než **Level2** s mírným dopadem na dobu zpracování.
- **Level4:** Poskytuje lepší kompresi než **Level3**.
- **Level5:** Poskytuje vylepšenou kompresi oproti **Level4** s dodatečnou dobou zpracování.
- **Level6:** Standardní komprese, která nabízí dobrý poměr mezi rychlostí zpracování a velikostí souboru. Toto je *výchozí úroveň komprese*.
- **Level7:** Poskytuje lepší kompresi než **Level6** s pomalejším zpracováním.
- **Level8:** Poskytuje lepší kompresi než **Level7**.
- **Level9:** Maximální komprese. Produkuje nejmenší velikost souboru za cenu nejdelší doby zpracování.

Následující příklad ukazuje, jak uložit prezentaci jako soubor PPTX *bez komprese*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Tento příklad ukazuje, jak uložit prezentaci jako soubor PPTX s *maximální kompresí*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Uložit prezentace bez obnovení náhledu**

Metoda [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) řídí generování náhledu při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, náhled se během ukládání obnoví. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, aktuální náhled se zachová. Pokud prezentace nemá náhled, žádný se nevygeneruje.

V následujícím kódu je prezentace uložena do PPTX bez obnovení jejího náhledu.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Informace" color="info" %}}
Tato volba pomáhá snížit dobu potřebnou k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládat průběh jako procenta**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprogresscallback/) se používá prostřednictvím metody `set_ProgressCallback` vystavené rozhraním [ISaveOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isaveoptions/) a abstraktní třídou [SaveOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/). Přiřaďte implementaci [IProgressCallback] pomocí `set_ProgressCallback`, abyste získali aktualizace průběhu ukládání v procentech.

Následující úryvky kódu ukazují, jak použít `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Použijte zde hodnotu procenta postupu.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Třída zpětného volání postupu definovaná výše.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Informace" color="info" %}}
Aspose vyvinulo [bezplatnou aplikaci PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) používající své vlastní API. Aplikace umožňuje rozdělit prezentaci do více souborů uložením vybraných snímků jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), aby se zapisovaly jen změny?**

Ne. Ukládání vždy vytvoří celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné (thread‑safe) ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) není [thread‑safe](/slides/cs/cpp/multithreading/); ukládejte ji z jediného vlákna.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při ukládání?**

[Hyperlinks](/slides/cs/cpp/manage-hyperlinks/) jsou zachovány. Externě propojené soubory (např. videa pomocí relativních cest) se automaticky nekopírují — ujistěte se, že odkazované cesty zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [document properties](/slides/cs/cpp/presentation-properties/) jsou podporovány a budou při ukládání zapsány do souboru.