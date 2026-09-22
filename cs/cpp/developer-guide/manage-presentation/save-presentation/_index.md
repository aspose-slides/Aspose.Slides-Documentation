---
title: Uložit prezentace v C++
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
- prezentace do proudu
- předdefinovaný typ zobrazení
- přísný formát Office Open XML
- režim Zip64
- obnovení miniatury
- průběh ukládání
- C++
- Aspose.Slides
description: "Uložte prezentace PowerPoint a OpenDocument do souborů nebo proudů v C++ pomocí Aspose.Slides a nakonfigurujte výstup PPTX a reportování průběhu."
---
## **Přehled**

Po vytvoření prezentace nebo [otevření existující](/slides/cs/cpp/open-presentation/), použijte metodu [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) k zápisu výsledku. Aspose.Slides pro C++ může uložit prezentaci do souboru nebo proudu v formátech PowerPoint, OpenDocument, PDF a dalších. Následující sekce popisují standardní operace ukládání a možnosti dostupné pro výstup PPTX.

## **Uložit prezentace do souborů**

Chcete‑li uložit prezentaci do souboru, předávejte cestu k výstupu a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/) metodě [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/). Hodnota formátu určuje typ souboru, který Aspose.Slides vytvoří.

Následující příklad vytvoří prezentaci a uloží ji jako soubor PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Přidejte nebo upravte obsah prezentace zde.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Uložit prezentace v jejich původním formátu**

Pro příklady detekce souboru a proudu, chování nově vytvořených prezentací a rozdíl mezi zdrojovým a výstupním formátem viz [Determine the Original Presentation Format](/slides/cs/cpp/detect-presentation-source-format/).

V aplikaci pro hromadné zpracování nemusí být vstupní formát znám předem. Po načtení souboru přečtěte jeho původní formát pomocí [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_sourceformat/). Výslednou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sourceformat/) předávejte metodě [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/tosaveformat/) a získáte odpovídající hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/), kterou následně použijete v [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) k zápisu upravené prezentace.

Následující kompletní příklad zpracuje každý soubor ve vstupním adresáři, aktualizuje jeho název a uloží jej do výstupního adresáře ve formátu, ze kterého byl načten:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.util/slideutil/tosaveformat/) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP a PowerPoint XML na jejich odpovídající formáty ukládání prezentací. Mapuje pouze zdrojové formáty prezentací; není určeno k výběru exportních formátů jako PDF, HTML, TIFF nebo obrázky. Předání nepodporované nebo neplatné hodnoty [SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sourceformat/) vyvolá [ArgumentException](https://reference.aspose.com/slides/cs/cpp/system/argumentexception/).

Legacy soubory PPT, PPS a POT používají stejný binární kontejner. Když je taková prezentace načtena z proudu bez přípony souboru, může být PPS nebo POT identifikován jako PPT. Pokud je vyžadováno zachování těchto legacy podtypů, uchovejte původní název souboru nebo metadata formátu odděleně a použijte je při výběru výstupního názvu souboru a formátu.

## **Uložit prezentace do proudů**

Chcete‑li zapsat prezentaci bez použití konečné cesty k souboru, předávejte zapisovatelný [Stream](https://reference.aspose.com/slides/cs/cpp/system.io/stream/) a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/) metodě [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/). Tento přístup je užitečný, když má výstup být vrácen z webové služby, uložen v databázi nebo zpracován v paměti.

Následující příklad uloží novou prezentaci do souborového proudu:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Uložit prezentace s předdefinovaným typem zobrazení**

Můžete určit pohled, ve kterém PowerPoint při otevření uložené prezentace nejprve zobrazí. Zavolejte [ViewProperties::set_LastView](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/set_lastview/) s hodnotou [ViewType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewtype/) před uložením.

Následující příklad nastaví zobrazení Slide Master jako výchozí:

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

## **Uložit prezentace ve Strict Office Open XML formátu**

Chcete‑li vytvořit soubor PPTX, který odpovídá přísnému profilu Office Open XML, vytvořte instanci [PptxOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/) a zavolejte [PptxOptions::set_Conformance](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/set_conformance/) s `Conformance::Iso29500_2008_Strict`. Poté předávejte možnosti metodě [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/).

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Uložit prezentace v Office Open XML formátu v režimu Zip64**

Standardní ZIP archiv omezuje komprimovanou i nekomprimovanou velikost každé položky, celkovou velikost archivu a počet položek. Protože je soubor PPTX ZIP archivem, velmi velká prezentace může tato omezení překročit. Rozšíření ZIP64 zvyšují platné limity velikosti a počtu položek.

Použijte [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) k nastavení, zda Aspose.Slides zapíše rozšíření ZIP64:

- `IfNecessary` používá ZIP64 jen když prezentace překročí standardní limity ZIP. Toto je výchozí režim.
- `Never` zakáže rozšíření ZIP64.
- `Always` vždy zapíše rozšíření ZIP64.

Následující příklad vždy povolí rozšíření ZIP64 pro výstupní prezentaci:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}

Pokud je `Zip64Mode` nastaven na `Never` a prezentace se nevejde do standardních limitů ZIP, operace ukládání vyvolá [PptxException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxexception/).

{{% /alert %}}

## **Uložit prezentace v Office Open XML formátu s úrovněmi komprese**

Pro výstup PPTX můžete vyvážit rychlost ukládání a velikost souboru voláním [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). Výčtová hodnota [CompressionLevel](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/compressionlevel/) poskytuje tyto možnosti:

- `None` ukládá data bez komprese.
- `Level1` poskytuje nejrychlejší kompresi a největší komprimovaný výstup.
- `Level2` až `Level5` postupně upřednostňují menší výstup před rychlostí ukládání.
- `Level6` vyvažuje rychlost ukládání a velikost souboru. Toto je výchozí úroveň.
- `Level7` a `Level8` dále upřednostňují menší výstup před rychlostí.
- `Level9` poskytuje nejsilnější kompresi a vyžaduje nejvíce času na zpracování.

Následující příklad uloží prezentaci bez komprese:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Následující příklad použije maximální úroveň komprese:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Uložit prezentace bez obnovení miniatury**

Při uložení prezentace jako PPTX řídí její miniaturu metoda [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/):

- `true` obnoví miniaturu během operace ukládání. Toto je výchozí hodnota.
- `false` zachová existující miniaturu. Pokud prezentace nemá miniaturu, Aspose.Slides ji nevygeneruje.

Následující příklad uloží prezentaci bez obnovení miniatury:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Zakázání obnovení miniatury může zkrátit čas potřebný k uložení souboru PPTX.

{{% /alert %}}

## **Ukládat průběžné aktualizace v procentech**

Pro sledování operace ukládání implementujte rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprogresscallback/) a předávejte implementaci metodě [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides pak během exportu volá [IProgressCallback::Reporting](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprogresscallback/reporting/) s hodnotami průběhu.

Následující příklad vypisuje průběh exportu PDF do konzole:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose poskytuje zdarma [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) postavený na API Aspose.Slides. Umožňuje uložit vybrané snímky z prezentace jako samostatné soubory PPT nebo PPTX.

{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides inkrementální nebo „rychlé“ ukládání?**

Ne. Každá operace ukládání zapíše kompletní výstupní soubor místo aktualizace pouze změněných částí.

**Může více vláken ukládat stejnou instanci Presentation?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) **není thread‑safe** (/slides/cs/cpp/multithreading/). Přístup a ukládání každé instance provádějte pouze z jednoho vlákna najednou.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při uložení prezentace?**

[Hypertextové odkazy](/slides/cs/cpp/manage-hyperlinks/) zůstávají v prezentaci. Aspose.Slides nekopíruje externě propojené soubory, takže uložená prezentace musí i nadále mít přístup k jejich umístěním.

**Mohu uložit metadata dokumentu, jako jsou autor, název, společnost a datum vytvoření?**

Ano. Nastavte příslušné [vlastnosti dokumentu](/slides/cs/cpp/presentation-properties/) před uložením a Aspose.Slides je zapíše do výstupního souboru.