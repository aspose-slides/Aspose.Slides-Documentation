---
title: Bepaal het originele presentatieformaat in C++
linktitle: Bronformaat
type: docs
weight: 35
url: /nl/cpp/detect-presentation-source-format/
keywords:
- bronformaat
- detecteer presentatieformaat
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Lees het originele formaat van een geladen presentatie in C++ met Aspose.Slides voor C++, vergelijk detectie‑API's en verwerk bestanden, streams en legacy‑formaten."
---
## **Overzicht**

Na het laden van een presentatie, roep je [Presentation::get_SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_sourceformat/) aan om het oorspronkelijke formaat te bepalen. De methode is ook beschikbaar via [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_sourceformat/). Gebruik deze wanneer verdere verwerking afhankelijk is van het formaat waaruit de huidige instantie is geladen.

Het bronformaat verschilt van het [SaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/) dat voor een uitvoerbestand is geselecteerd. Opslaan naar een ander formaat wijzigt het bronformaat van de bestaande instantie niet.

## **Lees het bronformaat van een bestand**

Dit voorbeeld vereist een bestaand `sample.pptx`‑bestand. Het laadt het bestand en selecteert een toepassingsverwerkingsbeleid met behulp van [Presentation::get_SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_sourceformat/), in plaats van de bestandsnaam. Verander het invoerpad om andere formaten te proberen. Het voorbeeld print het geselecteerde beleid; vervang de berichten door jouw toepassingslogica.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Herken de ondersteunde waarden**

De enumeratie [SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sourceformat/) onderscheidt de volgende presentatief formaten. De onderstaande extensies zijn conventionele extensies, geen reconstructie van de oorspronkelijke bestandsnaam.

| SourceFormat‑waarde | Extensie | Formaat |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentatie 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentatie |
| `Pptm` | `.pptm` | Macro‑ingeschakelde Office Open XML‑presentatie |
| `Pps` | `.pps` | PowerPoint‑diavoorstelling 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑diavoorstelling |
| `Ppsm` | `.ppsm` | Macro‑ingeschakelde Office Open XML‑diavoorstelling |
| `Pot` | `.pot` | PowerPoint‑sjabloon 97–2003 |
| `Potx` | `.potx` | Office Open XML‑sjabloon |
| `Potm` | `.potm` | Macro‑ingeschakelde Office Open XML‑sjabloon |
| `Odp` | `.odp` | OpenDocument‑presentatie |
| `Otp` | `.otp` | OpenDocument‑presentatiesjabloon |
| `Fodp` | `.fodp` | Flat XML ODF‑presentatie |
| `Xml` | `.xml` | PowerPoint XML‑presentatie |

## **Lees het bronformaat van een stream**

Dit voorbeeld vereist een bestaand `sample.pps`‑bestand. Het inlezen van de bytes in een geheugen‑stream modelleert invoer ontvangen zonder bestandsnaam, zoals een databankwaarde of een geüploadde byte‑array. De constructor van [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) ontvangt alleen de stream.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS en POT gebruiken hetzelfde onderliggende binaire formaat. Bij het laden via een bestandspad kan de extensie helpen om een diavoorstelling of sjabloon te onderscheiden. Zonder bestandsnaam kan legacy‑PPS‑ en‑POT‑inhoud gerapporteerd worden als `SourceFormat::Ppt`; het PPS‑voorbeeld hierboven rapporteert `Ppt`.

Als je toepassing het onderscheid moet behouden, bewaar dan de oorspronkelijke bestandsnaam of sub‑type‑metadata apart. Een extensie is een handige hint voor deze legacy‑subtypes, maar mag niet de enige basis vormen om willekeurige presentatiew inhoud te identificeren.

## **Vergelijk detectie vóór en na het laden**

Gebruik [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationfactory/getpresentationinfo/) en [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/get_loadformat/) wanneer je een bestand moet inspecteren voordat je het volledige presentatiedatamodel laadt. Gebruik [Presentation::get_SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_sourceformat/) wanneer de instantie al bestaat.

Dit voorbeeld vereist `sample.pptx` en print `Pptx` voor beide controles. In productie kies je de API die past bij je verwerkingsstadium; een reeds geladen presentatie heeft geen tweede inspectie nodig uitsluitend om het bronformaat te verkrijgen.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

De resultaten hebben verschillende enumeratietypen: [LoadFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadformat/) en [SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sourceformat/). Vergelijk ze niet door hun numerieke waarden te casten of veronderstel dat elk formaat identieke detectieresultaten heeft. PowerPoint XML kan gerapporteerd worden als `LoadFormat::Unknown` vóór het laden en `SourceFormat::Xml` na het laden.

## **Houd bron- en uitvoerformaten gescheiden**

Dit voorbeeld vereist `sample.pptx` en schrijft `converted.odp`. Het print `Pptx` zowel vóór als na het opslaan van de oorspronkelijke instantie. Alleen de nieuwe instantie geladen vanuit de ODP‑uitvoer rapporteert `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Een presentatie die vanaf nul is aangemaakt met `MakeObject<Presentation>()` rapporteert `SourceFormat::Pptx`. Het heeft geen invoerbestand: dit is de standaardwaarde voor een nieuw aangemaakte instantie, niet het bewijs dat er een PPTX‑bestand is geladen. Houd bij of je toepassing de instantie heeft aangemaakt of geladen, als dat onderscheid van belang is.

## **Map een bronformaat naar een extensie**

Het volgende voorbeeld vereist `sample.pptx`. Het map elk momenteel ondersteund [SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sourceformat/)‑waarde naar een conventionele extensie, zonder de invoer‑bestandsnaam te analyseren. De fallback voorkomt het stilzwijgend toewijzen van een extensie aan een niet‑herkende waarde.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Deze mapping zet geen bestand om of herstelt geen legacy‑PPS/POT‑subtype dat verloren ging tijdens het laden van een stream. Voor daadwerkelijk opslaan, selecteer expliciet een [SaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/), of gebruik de conversie die wordt getoond in [Save Presentations in Their Original Format](/slides/nl/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Verifieer formaten door op te slaan en opnieuw te openen**

Dit zelfstandige voorbeeld maakt een presentatie aan en schrijft drie bestanden in de werkmap, waarbij bestanden met dezelfde naam worden overschreven. Het opent elke uitvoer opnieuw, zowel via pad als via een geheugen‑stream. Voor PPTX en ODP rapporteren beide routes het opgeslagen formaat. Voor PPS meldt laden via pad `Pps`, terwijl het laden van dezelfde bytes zonder bestandsnaam `Ppt` meldt.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

De onderstaande tabel vat de bronformaat‑identificatie samen voor presentaties met overeenkomende extensies:

| Opgeslagen formaat | SourceFormat vanaf een bestandspad | SourceFormat vanaf een naamloze stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectievelijk | Hetzelfde als het bestandspad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectievelijk | Hetzelfde als het bestandspad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectievelijk | Hetzelfde als het bestandspad |
| ODP, OTP | `Odp`, `Otp` respectievelijk | Hetzelfde als het bestandspad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Legacy PPS/POT‑inhoud wordt genormaliseerd naar `Ppt` voor naamloze streams. De tabel beschrijft de formaatidentificatie, niet het behoud van elke presentatiefunctie tijdens conversie.

## **FAQ**

**Verandert opslaan naar ODP het bronformaat van een presentatie die geladen is vanuit PPTX?**

Nee. De bestaande instantie rapporteert nog steeds `Pptx`. Een instantie die is geladen vanuit het opgeslagen ODP‑bestand rapporteert `Odp`.

**Kan een stream altijd een legacy‑presentatie, diavoorstelling en sjabloon onderscheiden?**

Nee. PPT, PPS en POT delen hetzelfde binaire formaat. Bewaar de bestandsnaam of sub‑type‑metadata apart wanneer dat onderscheid vereist is.

**Welke API moet ik gebruiken als de presentatie al geladen is?**

Lees [Presentation::get_SourceFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_sourceformat/). Gebruik [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationfactory/getpresentationinfo/) voor inspectie vóór het laden.