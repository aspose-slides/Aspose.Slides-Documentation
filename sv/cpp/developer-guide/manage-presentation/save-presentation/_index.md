---
title: Spara presentationer i C++
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/cpp/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparningsprogress
- C++
- Aspose.Slides
description: "Spara PowerPoint- och OpenDocument-presentationer till filer eller strömmar i C++ med Aspose.Slides, och konfigurera PPTX-utdata samt rapportering av sparningsförlopp."
---
## **Översikt**

Efter att du har skapat en presentation eller [öppnat en befintlig](/slides/sv/cpp/open-presentation/), använd metoden [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) för att skriva resultatet. Aspose.Slides för C++ kan spara en presentation till en fil eller ström i PowerPoint-, OpenDocument-, PDF- och andra format. Följande avsnitt täcker de standardlagringsoperationer som finns och de alternativ som är tillgängliga för PPTX‑utdata.

## **Spara presentationer till filer**

För att spara en presentation till en fil, skicka utdata‑sökvägen och ett [SaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/)-värde till metoden [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/). Formatvärdet bestämmer vilken typ av fil som Aspose.Slides skapar.

Följande exempel skapar en presentation och sparar den som en PPTX‑fil:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Lägg till eller ändra presentationsinnehåll här.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Spara presentationer i deras ursprungliga format**

För exempel på fil‑ och strömdetektering, beteendet för nyskapade presentationer och skillnaden mellan käll‑ och utdataformat, se [Determine the Original Presentation Format](/slides/sv/cpp/detect-presentation-source-format/).

I ett batch‑bearbetningsprogram kan inmatningsformatet vara okänt i förväg. Efter att ha läst in en fil, läs dess ursprungliga format med [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_sourceformat/). Skicka det resulterande [SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sourceformat/)-värdet till [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/tosaveformat/) för att erhålla motsvarande [SaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/)-värde, och använd sedan [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) för att skriva den modifierade presentationen.

Följande kompletta exempel bearbetar varje fil i en inmatningskatalog, uppdaterar dess titel och sparar den till en utdatakatalog i det format som den lästes in i:

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

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/tosaveformat/) mappar PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP och PowerPoint‑XML till deras motsvarande presentations‑sparaformat. Den mappar endast presentations‑källformat; den är inte avsedd för att välja exportformat såsom PDF, HTML, TIFF eller bilder. Att skicka ett ej‑stödd eller ogiltigt [SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sourceformat/)-värde resulterar i ett [ArgumentException](https://reference.aspose.com/slides/sv/cpp/system/argumentexception/).

Äldre PPT-, PPS- och POT‑filer använder samma binära behållare. När en sådan presentation laddas från en ström utan filändelse kan en PPS‑ eller POT‑fil därför identifieras som PPT. Om det krävs att bevara dessa äldre undertyper, behåll det ursprungliga filnamnet eller formatmetadata separat och använd dem när du väljer utdatas filnamn och format.

## **Spara presentationer till strömmar**

För att skriva en presentation utan att förlita sig på en slutgiltig filsökväg, skicka en skrivbar [Stream](https://reference.aspose.com/slides/sv/cpp/system.io/stream/) och ett [SaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/)-värde till metoden [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/). Detta tillvägagångssätt är användbart när utdata måste returneras från en webbtjänst, lagras i en databas eller bearbetas i minnet.

Följande exempel sparar en ny presentation till en filström:

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

## **Spara presentationer med en fördefinierad vytyp**

Du kan ange den vy som PowerPoint initialt öppnar en sparad presentation i. Anropa [ViewProperties::set_LastView](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/set_lastview/) med ett [ViewType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewtype/)-värde före sparning.

Följande exempel konfigurerar Slide Master‑vyn som den initiala vyn:

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

## **Spara presentationer i det strikta Office Open XML‑formatet**

För att skapa en PPTX‑fil som följer den strikta profilen för Office Open XML, skapa en instans av [PptxOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/) och anropa [PptxOptions::set_Conformance](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/set_conformance/) med `Conformance::Iso29500_2008_Strict`. Skicka sedan alternativen till metoden [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/).

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

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

Ett standard‑ZIP‑arkiv begränsar den komprimerade och okomprimerade storleken för varje post, den totala arkivstorleken och antalet poster. Eftersom en PPTX‑fil är ett ZIP‑arkiv kan en mycket stor presentation överskrida dessa begränsningar. ZIP64‑tillägg höjer de tillämpliga storleks‑ och postantal‑gränserna.

Use [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) to control whether Aspose.Slides writes ZIP64 extensions:

- `IfNecessary` använder ZIP64 endast när presentationen överskrider standard‑ZIP‑gränserna. Detta är standardläget.
- `Never` inaktiverar ZIP64‑tillägg.
- `Always` skriver alltid ZIP64‑tillägg.

Följande exempel aktiverar alltid ZIP64‑tillägg för den utgående presentationen:

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
Om `Zip64Mode` är satt till `Never` och presentationen inte får plats inom standard‑ZIP‑gränserna, kastar sparningsoperationen ett [PptxException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Spara presentationer i Office Open XML‑format med komprimeringsnivåer**

För PPTX‑utdata kan du balansera sparhastighet mot filstorlek genom att anropa [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). Uppräkningen [CompressionLevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/compressionlevel/) ger följande värden:

- `None` lagrar data utan kompression.
- `Level1` ger den snabbaste kompressionen och den största komprimerade utdata.
- `Level2` till `Level5` favoriserar gradvis mindre utdata framför sparhastigheten.
- `Level6` balanserar sparhastighet och filstorlek. Detta är standardnivån.
- `Level7` och `Level8` favoriserar ytterligare mindre utdata framför sparhastigheten.
- `Level9` ger den starkaste kompressionen och kräver mest bearbetningstid.

Följande exempel sparar en presentation utan kompression:

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

Följande exempel använder den maximala komprimeringsnivån:

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

## **Spara presentationer utan att uppdatera miniatyren**

När en presentation sparas som PPTX styr [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) dess dokumentminiatyr:

- `true` återskapar miniatyren under sparoperationen. Detta är standardvärdet.
- `false` bevarar den befintliga miniatyren. Om presentationen saknar miniatyr skapar Aspose.Slides ingen.

Följande exempel sparar en presentation utan att uppdatera dess miniatyr:

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
Att inaktivera miniatyruppdatering kan minska den tid som krävs för att spara en PPTX‑fil.
{{% /alert %}}

## **Spara framstegsuppdateringar i procent**

För att övervaka en sparoperation, implementera gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprogresscallback/) och skicka implementationen till [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides anropar sedan [IProgressCallback::Reporting](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprogresscallback/reporting/) med framstegsvärden under exporten.

Följande exempel rapporterar framstegen för en PDF‑export till konsolen:

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
Aspose tillhandahåller en gratis [PowerPoint Splitter](https://products.aspose.app/slides/sv/splitter) byggd med Aspose.Slides‑API:t. Den sparar valda bilder från en presentation som separata PPT‑ eller PPTX‑filer.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides inkrementell eller “snabb sparning”?**

Nej. Varje sparningsoperation skriver en komplett utdatafil istället för att bara uppdatera de ändrade delarna.

**Kan flera trådar spara samma Presentation‑instans?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/cpp/multithreading/). Åtkomst och sparning av varje instans får endast ske från en tråd åt gången.

**Vad händer med hyperlänkar och externt länkade filer när jag sparar en presentation?**

[Hyperlänkar](/slides/sv/cpp/manage-hyperlinks/) förblir i presentationen. Aspose.Slides kopierar inte externt länkade filer, så den sparade presentationen måste fortfarande kunna nå deras platser.

**Kan jag spara dokumentmetadata såsom författare, titel, företag och skapandedatum?**

Ja. Ställ in lämpliga [dokumentegenskaper](/slides/sv/cpp/presentation-properties/) innan sparning, så skriver Aspose.Slides dem till utdatafilen.