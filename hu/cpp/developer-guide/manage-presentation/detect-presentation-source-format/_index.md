---
title: Az eredeti prezentáció formátumának meghatározása C++-ban
linktitle: Forrásformátum
type: docs
weight: 35
url: /hu/cpp/detect-presentation-source-format/
keywords:
- forrásformátum
- prezentáció formátumának felderítése
- PowerPoint
- OpenDocument
- prezentáció
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Olvassa be egy betöltött prezentáció eredeti formátumát C++-ban az Aspose.Slides for C++ segítségével, hasonlítsa össze a felismerő API-kat, és kezelje a fájlokat, streameket és a régi formátumokat."
---
## **Áttekintés**

Prezentáció betöltése után hívja meg a Presentation::get_SourceFormat metódust az eredeti formátum meghatározásához. A metódus az IPresentation::get_SourceFormat útján is elérhető. Használja, ha a későbbi feldolgozás a példány betöltésének formátumától függ.

A forrásformátum eltér a kimeneti fájlhoz kiválasztott SaveFormat‑tól. Más formátumba mentés nem változtatja meg a meglévő példány forrásformátumát.

## **Olvassa be egy fájl forrásformátumát**

Ez a példa egy meglévő `sample.pptx` fájlt igényel. Betölti a fájlt, és a fájlnév helyett a Presentation::get_SourceFormat használatával választja ki az alkalmazás feldolgozási szabályát. A bemeneti útvonalat módosítva próbáljon ki más formátumokat. A példa kiírja a kiválasztott szabályt; cserélje le az üzeneteket saját alkalmazáslogikájára.

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

## **Ismerje fel a támogatott értékeket**

A SourceFormat felsorolás a következő prezentációs formátumokat különbözteti meg. Az alábbi kiterjesztések konvencionálisak, nem az eredeti fájlnév újjáépítése.

| SourceFormat érték | Kiterjesztés | Formátum |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 bemutató |
| `Pptx` | `.pptx` | Office Open XML bemutató |
| `Pptm` | `.pptm` | Makróval ellátott Office Open XML bemutató |
| `Pps` | `.pps` | PowerPoint 97–2003 diavetítés |
| `Ppsx` | `.ppsx` | Office Open XML diavetítés |
| `Ppsm` | `.ppsm` | Makróval ellátott Office Open XML diavetítés |
| `Pot` | `.pot` | PowerPoint 97–2003 sablon |
| `Potx` | `.potx` | Office Open XML sablon |
| `Potm` | `.potm` | Makróval ellátott Office Open XML sablon |
| `Odp` | `.odp` | OpenDocument bemutató |
| `Otp` | `.otp` | OpenDocument bemutató sablon |
| `Fodp` | `.fodp` | Flat XML ODF bemutató |
| `Xml` | `.xml` | PowerPoint XML bemutató |

## **Olvassa be egy stream forrásformátumát**

Ez a példa egy meglévő `sample.pps` fájlt igényel. A fájl bájtjainak memóriastreambe olvasása olyan bemenetet szimulál, amely fájlnév nélkül érkezik, például adatbázisérték vagy feltöltött bájt tömb. A Presentation konstruktor csak a stream-et kapja.

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

A PPT, PPS és POT ugyanazt az alapvető bináris formátumot használja. Fájlúton történő betöltéskor a kiterjesztés segíthet megkülönböztetni a diavetítést vagy sablont. Fájlnév nélkül a régi PPS és POT tartalom a SourceFormat::Ppt‑ként jelentkezhet; a fentebb szereplő PPS példa a Ppt‑t jelzi.

Ha alkalmazásának meg kell őriznie a különbséget, tartsa meg az eredeti fájlnevet vagy az alttípus metaadatait külön. A kiterjesztés hasznos támpont lehet ezekhez a régi alttípusokhoz, de nem lehet az egyetlen alapja a tetszőleges prezentációs tartalom azonosításának.

## **Hasonlítsa össze a felismerést betöltés előtt és után**

Használja a PresentationFactory::GetPresentationInfo és az IPresentationInfo::get_LoadFormat metódusokat, amikor egy fájlt a teljes prezentációs objektummodell betöltése előtt kell ellenőrizni. Használja a Presentation::get_SourceFormat metódust, ha a példány már létezik.

Ez a példa `sample.pptx`‑et igényel, és mindkét ellenőrzésnél `Pptx`‑et ír ki. Éles környezetben válassza a feldolgozási szakasznak megfelelő API‑t; egy már betöltött prezentációnak nincs szüksége második ellenőrzésre csak a forrásformátum lekérdezéséhez.

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

Az eredmények különböző enumerációs típusúak: LoadFormat és SourceFormat. Ne hasonlítsa őket a numerikus értékek átalakításával, és ne feltételezze, hogy minden formátumnak azonos felismerési eredménye van. A PowerPoint XML betöltés előtt LoadFormat::Unknown‑ként, betöltés után pedig SourceFormat::Xml‑ként jelentkezhet.

## **Tartsa külön a forrás- és kimeneti formátumokat**

Ez a példa `sample.pptx`‑et igényel, és `converted.odp`‑t ír. Mind a mentés előtt, mind után `Pptx`‑et ír ki az eredeti példányból. Csak az ODP kimenetből betöltött új példány jelzi az `Odp`‑t.

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

A MakeObject<Presentation>()‑val nulláról létrehozott prezentáció a SourceFormat::Pptx‑et jelzi. Nincs bemeneti fájlja: ez az újonnan létrehozott példány alapértelmezett értéke, nem bizonyítja, hogy PPTX fájlt töltöttek be. Ha ez a különbség fontos, kövesse nyomon, hogy az alkalmazás létrehozta vagy betöltötte a példányt.

## **Térképezze a forrásformátumot egy kiterjesztésre**

A következő példa `sample.pptx`‑et igényel. Minden jelenleg támogatott SourceFormat értéket egy konvencionális kiterjesztésre térképez, a bemeneti fájlnév elemzése nélkül. A tartalék elkerüli, hogy egy fel nem ismerett értékhez csendben kiterjesztést rendeljünk.

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

Ez a térképezés nem konvertál fájlt, vagy nem állítja vissza a stream betöltése közben elveszett régi PPS/POT alttípust. Valódi mentéshez válasszon egy SaveFormat‑ot kifejezetten, vagy használja a [Prezentációk mentése eredeti formátumban](/slides/hu/cpp/save-presentation/#save-presentations-in-their-original-format) átváltást.

## **Ellenőrizze a formátumokat mentéssel és újranyitással**

Ez az önálló példa egy prezentációt hoz létre, és három fájlt ír a munkakönyvtárba, felülírva az azonos nevű fájlokat. Minden kimenetet újból megnyit fájlúton és memóriastreamen keresztül is. PPTX és ODP esetén mindkét mód a mentett formátumot jelzi. PPS esetén a fájlúton történő betöltés `Pps`‑t, míg a fájlnév nélküli bájtok betöltése `Ppt`‑t ad.

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

Az alábbi táblázat összegzi a forrásformátum azonosítást a megfelelő kiterjesztésű prezentációk esetén:

| Mentett formátum | SourceFormat fájlúton | SourceFormat névtelen streame |
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

A régi PPS/POT tartalom a névtelen streameknél `Ppt`‑re normalizálódik. A táblázat a formátum azonosítását írja le, nem pedig minden prezentációs jellemző megőrzését az átalakítás során.

## **GYIK**

**Megváltozik-e a forrásformátum, ha egy PPTX‑ből betöltött prezentációt ODP‑be mentünk?**

Nem. A meglévő példány továbbra is `Pptx`‑et jelent. A mentett ODP fájlból betöltött példány `Odp`‑t jelent.

**Képes egy stream mindig megkülönböztetni a régi prezentációt, diavetítést és sablont?**

Nem. A PPT, PPS és POT ugyanazt a bináris formátumot használja. Ha a különbség fontos, tartsa meg a fájlnevet vagy az alttípus metaadatait külön.

**Melyik API‑t kell használni, ha a prezentáció már be van töltve?**

Olvassa a Presentation::get_SourceFormat metódust. Használja a PresentationFactory::GetPresentationInfo‑t a betöltés előtti ellenőrzéshez.