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
- uppdatera miniatyrbild
- sparande framsteg
- C++
- Aspose.Slides
description: "Upptäck hur du sparar presentationer i C++ med Aspose.Slides—exportera till PowerPoint eller OpenDocument samtidigt som du behåller layouter, teckensnitt och effekter."
---
## **Översikt**

[Öppna presentationer i C++](/slides/sv/cpp/open-presentation/) beskriver hur man använder klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) för att öppna en presentation. Den här artikeln förklarar hur man skapar och sparar presentationer. Klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) innehåller en presentations innehåll. Oavsett om du skapar en presentation från början eller ändrar en befintlig, vill du spara den när du är klar. Med Aspose.Slides för C++ kan du spara till en **fil** eller **ström**. Den här artikeln förklarar de olika sätten att spara en presentation.

## **Spara presentationer till filer**

Spara en presentation till en fil genom att anropa `Save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/). Skicka filnamnet och sparaformatet till metoden. Följande exempel visar hur man sparar en presentation med Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Gör lite arbete här...

// Spara presentationen till en fil.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Spara presentationer till strömmar**

Du kan spara en presentation till en ström genom att skicka en utgångsström till `Save`‑metoden i klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/). En presentation kan skrivas till många strömtyper. I exemplet nedan skapar vi en ny presentation och sparar den till en filström.

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

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Spara presentationen till strömmen.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Spara presentationer med en fördefinierad vytyp**

Aspose.Slides låter dig ange den initiala vyn som PowerPoint använder när den genererade presentationen öppnas via klassen [ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/). Använd metoden [set_LastView](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/set_lastview/) med ett värde från uppräkningen [ViewType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewtype/).

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

## **Spara presentationer i det strikt Office Open XML-formatet**

Aspose.Slides låter dig spara en presentation i det strikta Office Open XML-formatet. Använd klassen [PptxOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/) och ange dess conformance‑egenskap när du sparar. Om du ställer in `Conformance.Iso29500_2008_Strict` sparas utdatafilen i det strikta Office Open XML-formatet.

Exemplet nedan skapar en presentation och sparar den i det strikta Office Open XML-formatet.

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

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>();

// Spara presentationen i det strikta Office Open XML-formatet.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Spara presentationer i Office Open XML-format i Zip64-läge**

En Office Open XML‑fil är ett ZIP‑arkiv som har begränsningar på 4 GB (2^32 byte) för den okomprimerade storleken på någon fil, den komprimerade storleken på någon fil och den totala storleken på arkivet, samt begränsar arkivet till 65 535 (2^16‑1) filer. ZIP64‑formatutökningar höjer dessa begränsningar till 2^64.

Metoden [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) låter dig välja när ZIP64‑formatutökningar ska användas vid sparande av en Office Open XML‑fil.

Denna metod kan användas med följande lägen:

- `IfNecessary` använder ZIP64‑formatutökningar endast om presentationen överskrider begränsningarna ovan. Detta är standardläget.
- `Never` använder aldrig ZIP64‑formatutökningar.
- `Always` använder alltid ZIP64‑formatutökningar.

Följande kod demonstrerar hur man sparar en presentation som en PPTX‑fil med ZIP64‑formatutökningar aktiverade:

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

{{% alert title="NOTE" color="warning" %}}
När du sparar med `Zip64Mode.Never` kastas ett [PptxException](https://reference.aspose.com/slides/sv/cpp/aspose.slides/pptxexception/) om presentationen inte kan sparas i ZIP32‑format.
{{% /alert %}}

## **Spara presentationer i Office Open XML-format med komprimeringsnivåer**

När du arbetar med stora presentationer kan du justera komprimeringsnivån för att balansera filstorlek och bearbetningstid. Beroende på dina krav kan du föredra snabbare bearbetning eller mindre utdatas filer.

Aspose.Slides tillhandahåller metoden [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) som låter dig ange komprimeringsnivån som används när en presentation sparas i Office Open XML‑format.

Följande komprimeringsnivåer är tillgängliga:

- **None**: Ingen komprimering tillämpas. Filer lagras som de är.
- **Level1:** Den snabbaste komprimeringen med lägst komprimeringsförhållande.
- **Level2:** Snabbare komprimering med något bättre komprimeringsförhållande än **Level1**.
- **Level3:** Ger bättre komprimering än **Level2** med måttlig påverkan på bearbetningstid.
- **Level4:** Ger bättre komprimering än **Level3**.
- **Level5:** Ger förbättrad komprimering jämfört med **Level4** med extra bearbetningstid.
- **Level6:** Standardkomprimering som ger en bra balans mellan bearbetningshastighet och filstorlek. Detta är *standardkomprimeringsnivån*.
- **Level7:** Ger bättre komprimering än **Level6** med långsammare bearbetning.
- **Level8:** Ger bättre kompression än **Level7**.
- **Level9:** Maximal kompression. Ger den minsta filstorleken på bekostnad av längst bearbetningstid.

Följande exempel demonstrerar hur man sparar en presentation som en PPTX‑fil *utan kompression*:

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

Detta exempel visar hur man sparar en presentation som en PPTX‑fil med *maximal kompression*:

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

## **Spara presentationer utan att uppdatera miniatyrbilden**

Metoden [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) styr generering av miniatyrbild när en presentation sparas till PPTX:

- Om den är satt till `true` uppdateras miniatyrbilden under sparandet. Detta är standard.
- Om den är satt till `false` bevaras den befintliga miniatyrbilden. Om presentationen saknar miniatyrbild genereras ingen.

I koden nedan sparas presentationen till PPTX utan att uppdatera dess miniatyrbild.

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

{{% alert title="Info" color="info" %}}
Detta alternativ hjälper till att minska tiden som krävs för att spara en presentation i PPTX‑format.
{{% /alert %}}

## **Spara framdriftsuppdateringar i procent**

Gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprogresscallback/) används via metoden `set_ProgressCallback` som exponeras av gränssnittet [ISaveOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isaveoptions/) och den abstrakta klassen [SaveOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveoptions/). Tilldela en implementation av [IProgressCallback](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iprogresscallback/) med `set_ProgressCallback` för att ta emot sparande‑framstegsuppdateringar i procent.

Följande kodsnuttar visar hur man använder `IProgressCallback`.

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
        // Använd procentvärdet för framsteg här.
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

// Den progressåteruppringningsklassen som definierades ovan.
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

{{% alert title="Info" color="info" %}}
Aspose har utvecklat en [gratis PowerPoint Splitter-app](https://products.aspose.app/slides/sv/splitter) med sitt eget API. Appen låter dig dela upp en presentation i flera filer genom att spara valda bilder som nya PPTX‑ eller PPT‑filer.
{{% /alert %}}

## **FAQ**

**Stöds "snabb sparning" (inkrementell sparning) så att bara ändringar skrivs?**

Nej. Sparning skapar hela målfilen varje gång; inkrementell ”snabb sparning” stöds inte.

**Är det trådsäkert att spara samma Presentation‑instans från flera trådar?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑instans är [inte trådsäker](/slides/sv/cpp/multithreading/); spara den från en enda tråd.

**Vad händer med hyperlänkar och externt länkade filer vid sparande?**

[Hyperlinks](/slides/sv/cpp/manage-hyperlinks/) bevaras. Externt länkade filer (t.ex. videor via relativa sökvägar) kopieras inte automatiskt — se till att de refererade sökvägarna förblir tillgängliga.

**Kan jag ange/spara dokumentmetadata (författare, titel, företag, datum)?**

Ja. Standard [document properties](/slides/sv/cpp/presentation-properties/) stöds och kommer att skrivas till filen vid sparande.