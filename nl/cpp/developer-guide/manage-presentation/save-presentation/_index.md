---
title: Presentaties opslaan in C++
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/cpp/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- voorgedefinieerd weergavetype
- Strikt Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- opslaan voortgang
- C++
- Aspose.Slides
description: "Ontdek hoe u presentaties kunt opslaan in C++ met Aspose.Slides—exporteer naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open Presentations in C++](/slides/nl/cpp/open-presentation/) beschrijft hoe u de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe u presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse bevat de inhoud van een presentatie. Of u nu een presentatie vanaf nul maakt of een bestaande wijzigt, wilt u deze opslaan zodra u klaar bent. Met Aspose.Slides for C++ kunt u opslaan naar een **bestand** of **stream**. Dit artikel legt de verschillende manieren uit om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Bewaar een presentatie in een bestand door de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse aan te roepen. Geef de bestandsnaam en het opslaanformaat door aan de methode. Het volgende voorbeeld laat zien hoe u een presentatie opslaat met Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Maak een instantie van de Presentation-klasse die een presentatiedossier vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Voer hier wat werk uit...
// Sla de presentatie op naar een bestand.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Presentaties opslaan naar streams**

U kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `Save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse. Een presentatie kan naar veel verschillende stream‑typen worden geschreven. In het onderstaande voorbeeld maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

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

// Maak een instantie van de Presentation-klasse die een presentatiedossier vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Sla de presentatie op naar de stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Aspose.Slides laat u de initiële weergave instellen die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) klasse. Gebruik de [set_LastView](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/set_lastview/) methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewtype/) enumeratie.

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

## **Presentaties opslaan in het strikte Office Open XML‑formaat**

Aspose.Slides maakt het mogelijk een presentatie op te slaan in het strikte Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pptxoptions/) klasse en stel de eigenschap `Conformance` in bij het opslaan. Als u `Conformance.Iso29500_2008_Strict` instelt, wordt het uitvoerbestand opgeslagen in het strikte Office Open XML‑formaat.

Het onderstaande voorbeeld maakt een presentatie en slaat deze op in het strikte Office Open XML‑formaat.

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

// Maak een instantie van de Presentation-klasse die een presentatiedossier vertegenwoordigt.
auto presentation = MakeObject<Presentation>();

// Sla de presentatie op in het strikte Office Open XML-formaat.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat limieten van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en beperkt het archief tot 65 535 (2^16−1) bestanden. De ZIP64‑formatuitleidingen verhogen deze limieten tot 2^64.

De [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) methode laat u kiezen wanneer u ZIP64‑formatuitleidingen wilt gebruiken bij het opslaan van een Office Open XML‑bestand.

Deze methode kan worden gebruikt met de volgende modi:

- `IfNecessary` gebruikt ZIP64‑formatuitleidingen alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- `Never` gebruikt nooit ZIP64‑formatuitleidingen.
- `Always` gebruikt altijd ZIP64‑formatuitleidingen.

De volgende code toont hoe u een presentatie opslaat als een PPTX‑bestand met ingeschakelde ZIP64‑formatuitleidingen:

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
Wanneer u opslaat met `Zip64Mode.Never`, wordt er een [PptxException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxexception/) gegooid als de presentatie niet in ZIP32‑formaat kan worden opgeslagen.
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Bij het werken met grote presentaties kunt u het compressieniveau aanpassen om een balans te vinden tussen bestandsgrootte en verwerkingstijd. Afhankelijk van uw eisen kunt u kiezen voor snellere verwerking of kleinere uitvoerbestanden.

Aspose.Slides biedt de [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) methode, waarmee u het compressieniveau kunt opgeven dat wordt gebruikt bij het opslaan van een presentatie in Office Open XML‑formaat.

De volgende compressieniveaus zijn beschikbaar:

- **None**: Geen compressie wordt toegepast. Bestanden worden ongewijzigd opgeslagen.
- **Level1:** De snelste compressie met de laagste compressieverhouding.
- **Level2:** Snellere compressie met een iets betere compressieverhouding dan **Level1**.
- **Level3:** Biedt betere compressie dan **Level2** met een matige impact op verwerkingstijd.
- **Level4:** Biedt betere compressie dan **Level3**.
- **Level5:** Biedt verbeterde compressie ten opzichte van **Level4** met extra verwerkingstijd.
- **Level6:** Standaardcompressie die een goede balans biedt tussen verwerking snelheid en bestandsgrootte. Dit is het *standaard compressieniveau*.
- **Level7:** Biedt betere compressie dan **Level6** met tragere verwerking.
- **Level8:** Biedt betere compressie dan **Level7**.
- **Level9:** Maximale compressie. Produceert de kleinste bestandsgrootte ten koste van de langste verwerkingstijd.

Het volgende voorbeeld toont hoe u een presentatie opslaat als een PPTX‑bestand *zonder compressie*:

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

Dit voorbeeld toont hoe u een presentatie opslaat als een PPTX‑bestand met *maximale compressie*:

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

## **Presentaties opslaan zonder miniatuur te vernieuwen**

De [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) methode regelt de generatie van de miniatuur bij het opslaan van een presentatie naar PPTX:

- Als deze op `true` is ingesteld, wordt de miniatuur tijdens het opslaan vernieuwd. Dit is de standaardwaarde.
- Als deze op `false` is ingesteld, wordt de huidige miniatuur bewaard. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de onderstaande code wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

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
Deze optie helpt de tijd die nodig is om een presentatie op te slaan in PPTX‑formaat te verkorten.
{{% /alert %}}

## **Opslaan voortgangsupdates in procent**

De [IProgressCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprogresscallback/) interface wordt gebruikt via de `set_ProgressCallback`‑methode die wordt blootgesteld door de [ISaveOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isaveoptions/) interface en de abstracte [SaveOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveoptions/) klasse. Ken een [IProgressCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprogresscallback/) implementatie toe met `set_ProgressCallback` om voortgangsupdates tijdens het opslaan te ontvangen als een percentage.

De volgende code‑fragmenten tonen hoe `IProgressCallback` te gebruiken.

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
        // Gebruik hier de voortgangspercentagewaarde.
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

// De voortgangs‑callback‑klasse die hierboven is gedefinieerd.
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
Aspose heeft een [gratis PowerPoint Splitter‑applicatie](https://products.aspose.app/slides/nl/splitter) ontwikkeld met behulp van haar eigen API. De app maakt het mogelijk een presentatie te splitsen in meerdere bestanden door geselecteerde dia’s op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “fast save” (incrementeel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Bij elk opslaan wordt het volledige doelbestand opnieuw aangemaakt; incrementeel “fast save” wordt niet ondersteund.

**Is het thread‑veilig om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) instantie [is niet thread‑veilig](/slides/nl/cpp/multithreading/); sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gekoppelde bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/cpp/manage-hyperlinks/) worden behouden. Extern gekoppelde bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd — zorg ervoor dat de verwezen paden toegankelijk blijven.

**Kan ik documentmetadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/cpp/presentation-properties/) worden ondersteund en bij het opslaan in het bestand geschreven.