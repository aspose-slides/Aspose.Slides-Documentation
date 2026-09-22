---
title: Bestäm det ursprungliga presentationsformatet i C++
linktitle: Källformat
type: docs
weight: 35
url: /sv/cpp/detect-presentation-source-format/
keywords:
- källformat
- identifiera presentationsformat
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Läs det ursprungliga formatet för en inläst presentation i C++ med Aspose.Slides för C++, jämför identifierings-API:er och hantera filer, strömmar och äldre format."
---
## **Översikt**

Efter att ha läst in en presentation, anropa [Presentation::get_SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_sourceformat/) för att avgöra dess ursprungliga format. Metoden är också tillgänglig via [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_sourceformat/). Använd den när efterföljande bearbetning beror på formatet som den aktuella instansen lästes in från.

Källformatet är annorlunda än det [SaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/) som valts för en utdatasfil. Att spara till ett annat format ändrar inte källformatet för den befintliga instansen.

## **Läs källformatet för en fil**

Det här exemplet kräver en befintlig fil `sample.pptx`. Den laddar filen och väljer en applikationsbearbetningspolicy med [Presentation::get_SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_sourceformat/), istället för filnamnet. Ändra inmatningssökvägen för att prova andra format. Exemplet skriver ut den valda policyn; ersätt meddelandena med din applikationslogik.

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

## **Känna igen de stödjade värdena**

Uppräkningen [SourceFormat] särskiljer följande presentationsformat. Följande filändelser är konventionella, inte en återuppbyggnad av det ursprungliga filnamnet.

| SourceFormat‑värde | Filändelse | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003‑presentation |
| `Pptx` | `.pptx` | Office Open XML‑presentation |
| `Pptm` | `.pptm` | Makroaktiverad Office Open XML‑presentation |
| `Pps` | `.pps` | PowerPoint 97–2003‑bildspel |
| `Ppsx` | `.ppsx` | Office Open XML‑bildspel |
| `Ppsm` | `.ppsm` | Makroaktiverat Office Open XML‑bildspel |
| `Pot` | `.pot` | PowerPoint 97–2003‑mall |
| `Potx` | `.potx` | Office Open XML‑mall |
| `Potm` | `.potm` | Makroaktiverad Office Open XML‑mall |
| `Odp` | `.odp` | OpenDocument‑presentation |
| `Otp` | `.otp` | OpenDocument‑mall för presentation |
| `Fodp` | `.fodp` | Flat XML ODF‑presentation |
| `Xml` | `.xml` | PowerPoint XML‑presentation |

## **Läs källformatet för en ström**

Det här exemplet kräver en befintlig fil `sample.pps`. Att läsa dess bytes in i en minnesström modellerar indata som mottagits utan filnamn, t.ex. ett databasvärde eller en uppladdad byte‑array. Konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) tar endast emot strömmen.

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

PPT, PPS och POT använder samma underliggande binära format. När du laddar via filväg kan filändelsen hjälpa till att skilja på ett bildspel eller en mall. Utan ett filnamn kan äldre PPS‑ och POT‑innehåll rapporteras som `SourceFormat::Ppt`; PPS‑exemplet ovan rapporterar `Ppt`.

Om din applikation måste bevara skillnaden, behåll det ursprungliga filnamnet eller metadata för undertyp separat. En filändelse är en användbar ledtråd för dessa äldre undertyper, men bör inte vara det enda underlaget för att identifiera godtyckligt presentationsinnehåll.

## **Jämför identifiering före och efter inläsning**

Använd [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationfactory/getpresentationinfo/) och [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentationinfo/get_loadformat/) när du behöver inspektera en fil innan du läser in hela presentationsobjektmodellen. Använd [Presentation::get_SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_sourceformat/) när instansen redan finns.

Det här exemplet kräver `sample.pptx` och skriver ut `Pptx` för båda kontrollerna. I produktion, välj det API som passar din bearbetningsstadium; en redan inläst presentation behöver inte en andra inspektion enbart för att få dess källformat.

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

Resultaten har olika uppräkningstyper: [LoadFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadformat/) och [SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sourceformat/). Jämför dem inte genom att kasta deras numeriska värden eller anta att varje format har identiska identifieringsresultat. PowerPoint XML kan rapporteras som `LoadFormat::Unknown` före inläsning och `SourceFormat::Xml` efter inläsning.

## **Håll käll- och utdataformat separata**

Det här exemplet kräver `sample.pptx` och skriver `converted.odp`. Det skriver ut `Pptx` både före och efter att ha sparat den ursprungliga instansen. Endast den nya instansen som läses in från ODP‑utdata rapporterar `Odp`.

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

En presentation som skapas från grunden med `MakeObject<Presentation>()` rapporterar `SourceFormat::Pptx`. Den har ingen indatafil: detta är standardvärdet för en nyinstans, inte bevis på att en PPTX‑fil laddades. Följ om din applikation skapade eller läste in instansen separat om den skillnaden är viktig.

## **Karta ett källformat till en filändelse**

Följande exempel kräver `sample.pptx`. Det mappar varje för närvarande stödjad [SourceFormat]-värde till en konventionell filändelse, utan att analysera indatafilnamnet. Fallback‑metoden undviker att tyst tilldela en filändelse till ett okänt värde.

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

Denna mappning konverterar inte en fil eller återställer en äldre PPS‑/POT‑undertyp som förlorats vid strömläsning. För faktisk sparning, välj ett [SaveFormat] explicit, eller använd konverteringen som visas i [Save Presentations in Their Original Format](/slides/sv/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Verifiera format genom att spara och öppna igen**

Det här fristående exemplet skapar en presentation och skriver tre filer i arbetskatalogen, och skriver över filer med samma namn. Det öppnar varje utdata både via sökväg och genom en minnesström. För PPTX och ODP rapporterar båda vägarna det sparade formatet. För PPS rapporterar inläsning via sökväg `Pps`, medan inläsning av samma bytes utan ett filnamn rapporterar `Ppt`.

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

Följande tabell sammanfattar identifiering av källformat för presentationer med matchande filändelser:

| Sparat format | SourceFormat från en filsökväg | SourceFormat från en namnlös ström |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Äldre PPS‑/POT‑innehåll normaliseras till `Ppt` för namnlösa strömmar. Tabellen beskriver formatidentifiering, inte bevarande av varje presentationsfunktion under konvertering.

## **FAQ**

**Ändrar sparning till ODP källformatet för en presentation som laddats från PPTX?**

Nej. Den befintliga instansen rapporterar fortfarande `Pptx`. En instans som läses in från den sparade ODP‑filen rapporterar `Odp`.

**Kan en ström alltid skilja på en äldre presentation, bildspel och mall?**

Nej. PPT, PPS och POT delar det binära formatet. Behåll filnamn eller metadata för undertyp separat när den skillnaden krävs.

**Vilket API bör jag använda om presentationen redan är inläst?**

Läs [Presentation::get_SourceFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_sourceformat/). Använd [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationfactory/getpresentationinfo/) för inspektion innan inläsning.