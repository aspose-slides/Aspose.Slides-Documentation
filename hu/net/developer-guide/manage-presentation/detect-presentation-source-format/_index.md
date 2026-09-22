---
title: Az eredeti prezentációs formátum meghatározása .NET-ben
linktitle: Forrásformátum
type: docs
weight: 35
url: /hu/net/detect-presentation-source-format/
keywords:
- forrásformátum
- prezentáció formátumának észlelése
- PowerPoint
- OpenDocument
- prezentáció
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Olvassa el egy betöltött prezentáció eredeti formátumát C#-ban az Aspose.Slides for .NET segítségével, hasonlítsa össze az észlelési API‑kat, és kezelje a fájlokat, adatfolyamokat és régi formátumokat."
---
## **Áttekintés**

A prezentáció betöltése után olvassa el csak olvasható [Presentation.SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sourceformat/) tulajdonságot, hogy meghatározza az eredeti formátumát. A tulajdonság elérhető az [IPresentation.SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/sourceformat/) néven is. Használja, amikor a későbbi feldolgozás a formátumtól függ, ahonnan a jelenlegi példány betöltődött.

A forrásformátum különbözik a kimeneti fájlhoz kiválasztott [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/)‑tól. Más formátumba mentés nem változtatja meg a meglévő példány forrásformátumát.

## **A fájl forrásformátumának olvasása**

Ehhez a példához szükség van egy meglévő `sample.pptx` fájlra. A fájlt betölti, és az alkalmazás feldolgozási szabályát a [Presentation.SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sourceformat/) használatával választja ki, a fájlnév helyett. Módosítsa a bemeneti útvonalat más formátumok kipróbálásához. A példa kiírja a kiválasztott szabályt; cserélje le az üzeneteket saját alkalmazáslogikájára.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **A támogatott értékek felismerése**

A [SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/sourceformat/) felsorolás megkülönbözteti a következő prezentációformátumokat. Az alábbi kiterjesztések konvencionálisak, nem az eredeti fájlnév újraalkotása.

| SourceFormat érték | Kiterjesztés | Formátum |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 prezentáció |
| `Pptx` | `.pptx` | Office Open XML prezentáció |
| `Pptm` | `.pptm` | Makróval bővített Office Open XML prezentáció |
| `Pps` | `.pps` | PowerPoint 97–2003 diavetítés |
| `Ppsx` | `.ppsx` | Office Open XML diavetítés |
| `Ppsm` | `.ppsm` | Makróval bővített Office Open XML diavetítés |
| `Pot` | `.pot` | PowerPoint 97–2003 sablon |
| `Potx` | `.potx` | Office Open XML sablon |
| `Potm` | `.potm` | Makróval bővített Office Open XML sablon |
| `Odp` | `.odp` | OpenDocument prezentáció |
| `Otp` | `.otp` | OpenDocument prezentáció sablon |
| `Fodp` | `.fodp` | Flat XML ODF prezentáció |
| `Xml` | `.xml` | PowerPoint XML prezentáció |

## **A forrásformátum olvasása adatfolyamból**

Ehhez a példához egy meglévő `sample.pps` fájl szükséges. A fájl bájtjainak memóriatömbe beolvasása olyan bemenetet modellez, amely fájlnév nélkül érkezik, például adatbázis‑érték vagy feltöltött bájt tömb. A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) konstruktor csak a folyamatot kapja meg.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

A PPT, PPS és POT ugyanazt a bináris formátumot használja. Fájlúton történő betöltéskor a kiterjesztés segíthet megkülönböztetni a diavetítést vagy sablont. Fájlnév nélkül a régi PPS és POT tartalom `SourceFormat.Ppt`‑ként jelenthető; a fenti PPS példa `Ppt`‑t jelent.

Ha az alkalmazásnak meg kell őriznie a különbséget, akkor tartsa meg eredeti fájlnevét vagy alkategória metaadatait külön. A kiterjesztés hasznos jelzés ezen régi alkategóriák esetén, de nem lehet az egyetlen alap az előre nem definiált prezentációtartalom azonosításához.

## **Az észlelés összehasonlítása betöltés előtt és után**

Használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/) és az [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationinfo/loadformat/) elemeket, amikor a fájlt a teljes prezentációs objektummodell betöltése előtt kell ellenőrizni. Használja a [Presentation.SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sourceformat/)‑t, ha a példány már létezik.

Ez a példa `sample.pptx`‑t igényel, és mindkét ellenőrzésnél `Pptx`‑et ír ki. Éles környezetben válassza a feldolgozási szakasznak megfelelő API‑t; egy már betöltött prezentációnak nem szükséges második ellenőrzés a forrásformátum lekéréséhez.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Az eredmények különböző felsorolástípusok: [LoadFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/loadformat/) és [SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/sourceformat/). Ne hasonlítsa őket numerikus értékük átalakításával, és ne feltételezze, hogy minden formátumnak azonos észlelési eredménye van. Az alább leírt mentés‑és‑újratöltés ellenőrzésnél a PowerPoint XML betöltés előtt `LoadFormat.Unknown`‑ként, betöltés után pedig `SourceFormat.Xml`‑ként jelent meg.

## **A forrás- és kimeneti formátumok külön tartása**

Ez a példa `sample.pptx`‑t igényel, és `converted.odp`‑t ír. Mind a mentés előtt, mind után `Pptx`‑et ír ki az eredeti példányról. Csak az ODP kimenetből betöltött új példány `Odp`‑ként jelentkezik.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

A `new Presentation()`‑val fejlesztett prezentáció `SourceFormat.Pptx`‑et jelent. Nincs bemeneti fájlja: ez az újonnan létrehozott példány alapértelmezett értéke, nem bizonyítja, hogy PPTX fájlt töltöttek be. Kövesse nyomon, hogy az alkalmazás létrehozta vagy betöltötte a példányt, ha ez a különbség fontos.

## **Forrásformátum leképezése kiterjesztésre**

A következő példa `sample.pptx`‑t igényel. Minden jelenleg támogatott [SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/sourceformat/) értéket leképez egy konvencionális kiterjesztésre, a bemeneti fájlnév elemzése nélkül. A tartalék megakadályozza a nem felismert értékhez csendes kiterjesztés hozzárendelését.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Ez a leképezés nem konvertál fájlt, és nem állítja vissza a stream‑betöltés során elveszett régi PPS/POT alkategóriát. A tényleges mentéshez válasszon egy [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) értéket kifejezetten, vagy használja a [Save Presentations in Their Original Format](/slides/hu/net/save-presentation/#save-presentations-in-their-original-format) példában bemutatott konverziót.

## **Formátumok ellenőrzése mentéssel és újranyitással**

Ez az önálló példa prezentációt hoz létre, és három fájlt ír a munkakönyvtárba, felülírva az azonos nevű fájlokat. Minden kimenetet újra megnyit fájlúton és memóriatömben egyaránt. PPTX‑nél és ODP‑nél mindkét útvonal a mentett formátumot jelzi. PPS‑nél a fájlúton történő betöltés `Pps`‑t ad, míg névtelen bájtok betöltése `Ppt`‑t jelent.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

Az előbb felsorolt összes formátummal végzett ellenőrzés a megfelelő kiterjesztésű generált prezentációkra a következő eredményeket adta:

| Mentett formátum | SourceFormat fájlútról | SourceFormat névtelen folyamatról |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` | Ugyanaz, mint fájlúton |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` | Ugyanaz, mint fájlúton |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` | Ugyanaz, mint fájlúton |
| ODP, OTP | `Odp`, `Otp` | Ugyanaz, mint fájlúton |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Ezekben az ellenőrzésekben az egyetlen forrásformátum normalizálás a nameless stream‑ek esetén a PPS/POT → `Ppt` volt. A táblázat a formátum azonosítását írja le, nem pedig minden prezentációs funkció megőrzését átalakítás során.

## **GYIK**

**Megváltozik-e az ODP-be mentés során a PPTX‑ből betöltött prezentáció forrásformátuma?**

Nem. A meglévő példány továbbra is `Pptx`‑et jelent. A mentett ODP fájlból betöltött példány `Odp`‑t jelent.

**Képes egy adatfolyam mindig megkülönböztetni a régi prezentációt, diavetítést és sablont?**

Nem. A PPT, PPS és POT ugyanazt a bináris formátumot használja. Ha a különbség fontos, tartsa meg a fájlnevet vagy az alkategória metaadatait külön.

**Melyik API‑t kell használni, ha a prezentáció már betöltődött?**

Olvassa a [Presentation.SourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sourceformat/). Használja a [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/getpresentationinfo/)‑t az betöltés előtti ellenőrzéshez.