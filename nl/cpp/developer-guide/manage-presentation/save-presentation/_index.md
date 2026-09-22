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
- Strikt Office Open XML‑formaat
- Zip64‑modus
- miniatuur vernieuwen
- voortgang bij opslaan
- C++
- Aspose.Slides
description: "PowerPoint- en OpenDocument‑presentaties opslaan naar bestanden of streams in C++ met Aspose.Slides, en PPTX‑uitvoer en voortgangsrapportage configureren."
---
## **Overzicht**

Nadat u een presentatie hebt gemaakt of [open een bestaande](/slides/nl/cpp/open-presentation/), gebruikt u de [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode om het resultaat op te slaan. Aspose.Slides voor C++ kan een presentatie opslaan naar een bestand of stream in PowerPoint, OpenDocument, PDF en andere indelingen. De volgende secties behandelen de standaard opslagbewerkingen en de beschikbare opties voor PPTX‑uitvoer.

## **Presentaties opslaan naar bestanden**

Om een presentatie op te slaan naar een bestand, geeft u het uitvoerpad en een [SaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/)‑waarde door aan de [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode. De formatwaarde bepaalt het type bestand dat Aspose.Slides maakt.

Het volgende voorbeeld maakt een presentatie en slaat deze op als een PPTX‑bestand:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Voeg presentatie-inhoud toe of wijzig deze hier.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Presentaties opslaan in hun oorspronkelijke formaat**

Voor voorbeelden van bestand‑ en streamdetectie, het gedrag van nieuw gemaakte presentaties en het onderscheid tussen bron‑ en uitvoerformaten, zie [Bepaal het oorspronkelijke presentatie‑formaat](/slides/nl/cpp/detect-presentation-source-format/).

In een batch‑verwerkingsapplicatie is het invoerformaat mogelijk niet vooraf bekend. Na het laden van een bestand, lees je het oorspronkelijke formaat met [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_sourceformat/). Geef de resulterende [SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sourceformat/)‑waarde door aan [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/tosaveformat/) om de bijbehorende [SaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/)‑waarde te verkrijgen, en gebruik vervolgens [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) om de gewijzigde presentatie op te slaan.

Het volgende volledige voorbeeld verwerkt elk bestand in een invoermap, werkt de titel bij en slaat het op naar een uitvoermap in het formaat waarin het was geladen:

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

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.util/slideutil/tosaveformat/) mappt PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP en PowerPoint XML naar hun overeenkomstige presentatie‑opslaformaten. Het mappt alleen bronformaten van presentaties; het is niet bedoeld om exportformaten zoals PDF, HTML, TIFF of afbeeldingen te selecteren. Het doorgeven van een niet‑ondersteunde of ongeldige [SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sourceformat/)‑waarde leidt tot een [ArgumentException](https://reference.aspose.com/slides/nl/cpp/system/argumentexception/).

Legacy‑PPT, PPS‑ en POT‑bestanden gebruiken dezelfde binaire container. Wanneer zo’n presentatie wordt geladen vanuit een stream zonder bestandsextensie, kan een PPS‑ of POT‑bestand daarom worden geïdentificeerd als PPT. Indien het behouden van deze legacy‑subtypes vereist is, bewaar dan de oorspronkelijke bestandsnaam of format‑metadata apart en gebruik deze bij het kiezen van de uitvoerbestandsnaam en -formaat.

## **Presentaties opslaan naar streams**

Om een presentatie te schrijven zonder een definitief bestandspad, geef je een schrijfbare [Stream](https://reference.aspose.com/slides/nl/cpp/system.io/stream/) en een [SaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/)‑waarde door aan de [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode. Deze aanpak is handig wanneer de uitvoer moet worden geretourneerd vanuit een webservice, opgeslagen in een database, of in het geheugen wordt verwerkt.

Het volgende voorbeeld slaat een nieuwe presentatie op naar een bestands‑stream:

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

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

U kunt de weergave opgeven waarin PowerPoint een opgeslagen presentatie aanvankelijk opent. Roep [ViewProperties::set_LastView](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/set_lastview/) aan met een [ViewType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewtype/)‑waarde vóór het opslaan.

Het volgende voorbeeld configureert de Slide Master‑weergave als de initiële weergave:

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

Om een PPTX‑bestand te maken dat voldoet aan het Strict‑profiel van Office Open XML, maak je een [PptxOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pptxoptions/)‑instantie aan en roep je [PptxOptions::set_Conformance](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pptxoptions/set_conformance/) aan met `Conformance::Iso29500_2008_Strict`. Geef vervolgens de opties door aan de [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode.

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

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een standaard ZIP‑archief beperkt de gecomprimeerde en ongecomprimeerde grootte van elk item, de totale archiefgrootte en het aantal items. Omdat een PPTX‑bestand een ZIP‑archief is, kan een zeer grote presentatie deze limieten overschrijden. Zip64‑extensies verhogen de toepasselijke grootte‑ en item‑limieten.

Gebruik [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) om te bepalen of Aspose.Slides Zip64‑extensies schrijft:

- `IfNecessary` gebruikt Zip64 alleen wanneer de presentatie de standaard ZIP‑limieten overschrijdt. Dit is de standaardmodus.
- `Never` schakelt Zip64‑extensies uit.
- `Always` schrijft altijd Zip64‑extensies.

Het volgende voorbeeld schakelt Zip64‑extensies altijd in voor de uitvoerpresentatie:

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
Als `Zip64Mode` is ingesteld op `Never` en de presentatie niet binnen de standaard ZIP‑limieten past, gooit de opslaan‑operatie een [PptxException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Voor PPTX‑uitvoer kunt u de opslagsnelheid afwegen tegen de bestandsgrootte door [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) aan te roepen. De enumeratie [CompressionLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/compressionlevel/) biedt de volgende waarden:

- `None` slaat gegevens op zonder compressie.
- `Level1` biedt de snelste compressie en de grootste gecomprimeerde output.
- `Level2` tot en met `Level5` geven geleidelijk de voorkeur aan een kleinere output boven opslagsnelheid.
- `Level6` balanceert opslagsnelheid en bestandsgrootte. Dit is het standaardniveau.
- `Level7` en `Level8` geven nog meer de voorkeur aan een kleinere output dan aan opslagsnelheid.
- `Level9` biedt de sterkste compressie en vereist de meeste verwerkingsduur.

Het volgende voorbeeld slaat een presentatie op zonder compressie:

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

Het volgende voorbeeld gebruikt het maximale compressieniveau:

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

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

Wanneer een presentatie wordt opgeslagen als PPTX, regelt [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) de miniatuurfoto van het document:

- `true` regenereert de miniatuur tijdens de opslaan‑operatie. Dit is de standaardwaarde.
- `false` behoudt de bestaande miniatuur. Als de presentatie geen miniatuur heeft, genereert Aspose.Slides er geen.

Het volgende voorbeeld slaat een presentatie op zonder de miniatuur te vernieuwen:

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
Het uitschakelen van het vernieuwen van de miniatuur kan de tijd die nodig is om een PPTX‑bestand op te slaan, verminderen.
{{% /alert %}}

## **Opslagvoortgang in percentage**

Om een opslaan‑operatie te volgen, implementeer je de [IProgressCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprogresscallback/) interface en geef je de implementatie door aan [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides roept vervolgens [IProgressCallback::Reporting](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprogresscallback/reporting/) aan met voortgangswaarden tijdens de export.

Het volgende voorbeeld rapporteert de voortgang van een PDF‑export naar de console:

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
Aspose biedt een gratis [PowerPoint Splitter](https://products.aspose.app/slides/nl/splitter) aan, gebouwd met de Aspose.Slides‑API. Het slaat geselecteerde dia's uit een presentatie op als afzonderlijke PPT‑ of PPTX‑bestanden.
{{% /alert %}}

## **Veelgestelde vragen**

**Ondersteunt Aspose.Slides incrementeel of “fast save”?**

Nee. Elke opslaan‑operatie schrijft een compleet uitvoerbestand in plaats van alleen de gewijzigde delen bij te werken.

**Kunnen meerdere threads dezelfde Presentation‑instantie opslaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)-instantie [is niet thread‑safe](/slides/nl/cpp/multithreading/). Toegang en opslaan van elke instantie gebeurt slechts vanuit één thread tegelijk.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden wanneer ik een presentatie opsla?**

[Hyperlinks](/slides/nl/cpp/manage-hyperlinks/) blijven in de presentatie. Aspose.Slides kopieert geen extern gelinkte bestanden, dus de opgeslagen presentatie moet nog steeds toegang hebben tot hun locaties.

**Kan ik documentmetadata zoals auteur, titel, bedrijf en aanmaakdatum opslaan?**

Ja. Stel de juiste [document properties](/slides/nl/cpp/presentation-properties/) in vóór het opslaan, en Aspose.Slides schrijft ze naar het uitvoerbestand.