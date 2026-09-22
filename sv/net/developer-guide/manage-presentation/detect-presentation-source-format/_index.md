---
title: Bestäm det ursprungliga presentationsformatet i .NET
linktitle: Källformat
type: docs
weight: 35
url: /sv/net/detect-presentation-source-format/
keywords:
- källformat
- detektera presentationsformat
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Läs det ursprungliga formatet för en inläst presentation i C# med Aspose.Slides för .NET, jämför detekterings-API:er och hantera filer, strömmar och äldre format."
---
## **Översikt**

Efter att en presentation har laddats, läs den skrivskyddade [Presentation.SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sourceformat/) egenskapen för att bestämma dess ursprungliga format. Egenskapen är också tillgänglig via [IPresentation.SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/sourceformat/). Använd den när efterföljande bearbetning beror på det format som den aktuella instansen laddades från.

Källformatet skiljer sig från det [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/) som valts för en utdatafil. Att spara till ett annat format ändrar inte källformatet för den befintliga instansen.

## **Läs källformatet för en fil**

Detta exempel kräver en befintlig `sample.pptx`-fil. Det laddar filen och väljer en applikationsprocesspolicy med hjälp av [Presentation.SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sourceformat/), snarare än filnamnet. Ändra inmatningssökvägen för att prova andra format. Exemplet skriver ut den valda policyn; ersätt meddelandena med din applikationslogik.

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

## **Känna igen de stödjade värdena**

Enumet [SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/sourceformat/) skiljer mellan följande presentationsformat. Nedanstående filändelser är konventionella, inte en återuppbyggnad av det ursprungliga filnamnet.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentation 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentation |
| `Pptm` | `.pptm` | Makroaktiverad Office Open XML‑presentation |
| `Pps` | `.pps` | PowerPoint‑bildspel 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑bildspel |
| `Ppsm` | `.ppsm` | Makroaktiverat Office Open XML‑bildspel |
| `Pot` | `.pot` | PowerPoint‑mall 97–2003 |
| `Potx` | `.potx` | Office Open XML‑mall |
| `Potm` | `.potm` | Makroaktiverad Office Open XML‑mall |
| `Odp` | `.odp` | OpenDocument‑presentation |
| `Otp` | `.otp` | OpenDocument‑mall för presentation |
| `Fodp` | `.fodp` | Platt XML ODF‑presentation |
| `Xml` | `.xml` | PowerPoint‑XML‑presentation |

## **Läs källformatet för en ström**

Detta exempel kräver en befintlig `sample.pps`-fil. Att läsa dess byte till en minnesström modellerar indata som mottas utan filnamn, exempelvis ett databasvärde eller en uppladdad byte‑array. [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-konstruktorn tar bara emot strömmen.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS och POT använder samma underliggande binära format. Vid inläsning via filsökväg kan filändelsen hjälpa till att skilja ett bildspel eller en mall. Utan ett filnamn kan äldre PPS‑ och POT‑innehåll rapporteras som `SourceFormat.Ppt`; PPS‑exemplet ovan rapporterar `Ppt`.

Om din applikation måste bevara skillnaden, spara det ursprungliga filnamnet eller subtyp‑metadata separat. En filändelse är en användbar ledtråd för dessa äldre subtyper, men bör inte vara det enda underlaget för att identifiera godtyckligt presentationsinnehåll.

## **Jämför identifiering före och efter inläsning**

Använd [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/getpresentationinfo/) och [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentationinfo/loadformat/) när du behöver undersöka en fil innan du laddar dess fullständiga presentationsobjektmodell. Använd [Presentation.SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sourceformat/) när instansen redan finns.

Detta exempel kräver `sample.pptx` och skriver ut `Pptx` för båda kontrollerna. I produktion, välj det API som passar ditt bearbetningsstadium; en redan inläst presentation behöver inte en andra inspektion enbart för att få sitt källformat.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Resultaten har olika enum‑typer: [LoadFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/loadformat/) och [SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/sourceformat/). Jämför dem inte genom att kasta deras numeriska värden eller anta att varje format har identiska identifieringsresultat. I spar‑och‑öppna‑kontrollen som beskrivs nedan rapporterades PowerPoint XML som `LoadFormat.Unknown` före inläsning och `SourceFormat.Xml` efter inläsning.

## **Håll käll- och utdataformat separata**

Detta exempel kräver `sample.pptx` och skriver `converted.odp`. Det skriver ut `Pptx` både före och efter att den ursprungliga instansen sparats. Endast den nya instansen som laddas från ODP‑utdata rapporterar `Odp`.

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

En presentation som skapas från grunden med `new Presentation()` rapporterar `SourceFormat.Pptx`. Den har ingen indatafil: detta är standardvärdet för en nyinstans, inte ett bevis på att en PPTX‑fil laddades. Håll reda på om din applikation skapade eller laddade instansen separat om den skillnaden är viktig.

## **Mappa ett källformat till en filändelse**

Följande exempel kräver `sample.pptx`. Det mappar varje för närvarande stödjad [SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/sourceformat/)‑värde till en konventionell filändelse, utan att analysera indatafilens namn. Fallback‑mekanismen undviker att tyst tilldela en filändelse till ett ej känt värde.

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

Denna mappning konverterar inte en fil eller återställer en äldre PPS/POT‑subtyp som gick förlorad vid ströminläsning. För faktiskt sparande, välj ett [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/) explicit, eller använd konverteringen som visas i [Save Presentations in Their Original Format](/slides/sv/net/save-presentation/#save-presentations-in-their-original-format).

## **Verifiera format genom att spara och öppna igen**

Detta fristående exempel skapar en presentation och skriver tre filer i arbetskatalogen, vilket skriver över filer med samma namn. Det öppnar varje utdata både via sökväg och genom en minnesström. För PPTX och ODP rapporterar båda vägarna det sparade formatet. För PPS rapporterar inläsning via sökväg `Pps`, medan inläsning av samma byte utan filnamn rapporterar `Ppt`.

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

Samma kontroll med alla ovanstående format gav dessa resultat för genererade presentationer med matchande filändelser:

| Sparat format | SourceFormat från en filsökväg | SourceFormat från en namnlös ström |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respektive | Samma som filsökväg |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respektive | Samma som filsökväg |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respektive | Samma som filsökväg |
| ODP, OTP | `Odp`, `Otp` respektive | Samma som filsökväg |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

I dessa kontroller var den enda normaliseringen av källformat PPS/POT till `Ppt` för namnlösa strömmar. Tabellen beskriver formatidentifiering, inte bevarande av varje presentationsfunktion under konvertering.

## **Vanliga frågor**

**Ändrar sparande till ODP källformatet för en presentation som laddats från PPTX?**

Nej. Den befintliga instansen rapporterar fortfarande `Pptx`. En instans som laddas från den sparade ODP‑filen rapporterar `Odp`.

**Kan en ström alltid skilja en äldre presentation, ett bildspel och en mall?**

Nej. PPT, PPS och POT delar det binära formatet. Spara filnamn eller subtyp‑metadata separat när den skillnaden krävs.

**Vilket API ska jag använda om presentationen redan är inläst?**

Läs [Presentation.SourceFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sourceformat/). Använd [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/sv/net/aspose.slides/presentationfactory/getpresentationinfo/) för inspektion före inläsning.