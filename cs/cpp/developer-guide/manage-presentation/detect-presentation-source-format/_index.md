---
title: "Určete původní formát prezentace v C++"
linktitle: "Zdrojový formát"
type: docs
weight: 35
url: /cs/cpp/detect-presentation-source-format/
keywords:
- "zdrojový formát"
- "detekce formátu prezentace"
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Přečtěte původní formát načtené prezentace v C++ s Aspose.Slides pro C++, porovnejte API pro detekci a pracujte se soubory, streamy a staršími formáty."
---
## **Přehled**

Po načtení prezentace zavolejte [Presentation::get_SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_sourceformat/) pro určení jejího původního formátu. Metoda je také dostupná přes [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_sourceformat/). Použijte ji, když následné zpracování závisí na formátu, ze kterého byla aktuální instance načtena.

Zdrojový formát se liší od [SaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/) vybraného pro výstupní soubor. Uložení do jiného formátu nemění zdrojový formát existující instance.

## **Čtení zdrojového formátu souboru**

Tento příklad vyžaduje existující soubor `sample.pptx`. Načte soubor a pomocí [Presentation::get_SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_sourceformat/) vybere politiku zpracování aplikace, místo názvu souboru. Změňte vstupní cestu a vyzkoušejte další formáty. Příklad vypisuje vybranou politiku; nahraďte zprávy logikou vaší aplikace.

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

## **Rozpoznání podporovaných hodnot**

Výčtová [SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sourceformat/) rozlišuje následující formáty prezentací. Níže uvedené přípony jsou konvenční, nejsou rekonstrukcí původního názvu souboru.

| Hodnota SourceFormat | Přípona | Formát |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 prezentace |
| `Pptx` | `.pptx` | Office Open XML prezentace |
| `Pptm` | `.pptm` | Office Open XML prezentace s povolenými makry |
| `Pps` | `.pps` | PowerPoint 97–2003 prezentace snímků |
| `Ppsx` | `.ppsx` | Office Open XML prezentace snímků |
| `Ppsm` | `.ppsm` | Office Open XML prezentace snímků s makry |
| `Pot` | `.pot` | PowerPoint 97–2003 šablona |
| `Potx` | `.potx` | Office Open XML šablona |
| `Potm` | `.potm` | Office Open XML šablona s makry |
| `Odp` | `.odp` | OpenDocument prezentace |
| `Otp` | `.otp` | OpenDocument šablona prezentace |
| `Fodp` | `.fodp` | Flat XML ODF prezentace |
| `Xml` | `.xml` | PowerPoint XML prezentace |

## **Čtení zdrojového formátu ze streamu**

Tento příklad vyžaduje existující soubor `sample.pps`. Načtení jeho bajtů do paměťového streamu modeluje vstup přijatý bez názvu souboru, například hodnotu z databáze nebo nahraný pole bajtů. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) přijímá pouze stream.

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

PPT, PPS a POT používají stejný podkladový binární formát. Při načítání podle cesty souboru může přípona pomoci rozlišit prezentaci snímků nebo šablonu. Bez názvu souboru může být starší obsah PPS a POT hlášen jako `SourceFormat::Ppt`; výše uvedený příklad PPS hlásí `Ppt`.

Pokud vaše aplikace musí zachovat toto rozlišení, uložte původní název souboru nebo metadata podtypu zvlášť. Přípona je užitečná nápověda pro tyto starší podtypy, ale neměla by být jediným základem pro identifikaci libovolného obsahu prezentace.

## **Porovnání detekce před a po načtení**

Použijte [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationfactory/getpresentationinfo/) a [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentationinfo/get_loadformat/) když potřebujete zkontrolovat soubor před načtením jeho úplného objektového modelu prezentace. Použijte [Presentation::get_SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_sourceformat/) když instance již existuje.

Tento příklad vyžaduje `sample.pptx` a vypisuje `Pptx` pro oba testy. V produkci zvolte API vhodné pro vaše zpracovatelská stádia; již načtená prezentace nepotřebuje druhou kontrolu jen pro získání jejího zdrojového formátu.

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

Výsledky mají různé výčtové typy: [LoadFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadformat/) a [SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sourceformat/). Nekomparujte je přetypováním jejich číselných hodnot ani nepředpokládejte, že každý formát má stejné výsledky detekce. PowerPoint XML může být před načtením hlášen jako `LoadFormat::Unknown` a po načtení jako `SourceFormat::Xml`.

## **Udržujte zdrojové a výstupní formáty oddělené**

Tento příklad vyžaduje `sample.pptx` a zapíše `converted.odp`. Vypisuje `Pptx` jak před, tak po uložení původní instance. Pouze nová instance načtená z ODP výstupu hlásí `Odp`.

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

Prezentace vytvořená od začátku pomocí `MakeObject<Presentation>()` hlásí `SourceFormat::Pptx`. Nemá vstupní soubor: toto je výchozí hodnota pro nově vytvořenou instanci, ne důkaz, že byl načten soubor PPTX. Sledujte, zda vaše aplikace vytvořila nebo načetla instanci, pokud je toto rozlišení důležité.

## **Mapování zdrojového formátu na příponu**

Následující příklad vyžaduje `sample.pptx`. Mapuje každou aktuálně podporovanou [SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sourceformat/) hodnotu na konvenční příponu, aniž by parsoval vstupní název souboru. Náhradní řešení zabraňuje tichému přiřazení přípony k neznámé hodnotě.

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

Toto mapování neprovádí konverzi souboru ani neobnovuje starší podtyp PPS/POT ztracený během načítání streamu. Pro skutečné ukládání vyberte explicitně [SaveFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/), nebo použijte konverzi uvedenou v [Ukládání prezentací v jejich původním formátu](/slides/cs/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Ověření formátů ukládáním a opětovným otevřením**

Tento samostatný příklad vytvoří prezentaci a zapíše tři soubory do pracovního adresáře, přepisuje soubory se stejnými názvy. Každý výstup znovu otevře jak podle cesty, tak přes paměťový stream. Pro PPTX a ODP oba způsoby hlásí uložený formát. Pro PPS načtení podle cesty hlásí `Pps`, zatímco načtení stejných bajtů bez názvu souboru hlásí `Ppt`.

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

Následující tabulka shrnuje identifikaci zdrojového formátu pro prezentace s odpovídajícími příponami:

| Uložený formát | SourceFormat z cesty souboru | SourceFormat z bezejmenného streamu |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Stejně jako cesta souboru |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Stejně jako cesta souboru |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Stejně jako cesta souboru |
| ODP, OTP | `Odp`, `Otp` respectively | Stejně jako cesta souboru |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Starší obsah PPS/POT je pro bezejmenné streamy normalizován na `Ppt`. Tabulka popisuje identifikaci formátu, nikoli zachování všech funkcí prezentace během konverze.

## **FAQ**

**Mění uložení do ODP zdrojový formát prezentace načtené z PPTX?**

Ne. Stávající instance stále hlásí `Pptx`. Instance načtená ze souboru ODP, který byl uložen, hlásí `Odp`.

**Dokáže stream vždy rozlišit starší prezentaci, prezentaci snímků a šablonu?**

Ne. PPT, PPS a POT sdílejí binární formát. Uložte název souboru nebo metadata podtypu zvlášť, pokud je toto rozlišení vyžadováno.

**Které API mám použít, pokud je prezentace již načtena?**

Přečtěte [Presentation::get_SourceFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_sourceformat/). Použijte [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationfactory/getpresentationinfo/) pro inspekci před načtením.