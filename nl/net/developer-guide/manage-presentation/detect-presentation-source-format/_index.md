---
title: Bepaal het oorspronkelijke presentatiesformaat in .NET
linktitle: Bronformaat
type: docs
weight: 35
url: /nl/net/detect-presentation-source-format/
keywords:
- bronformaat
- detecteer presentatiesformaat
- PowerPoint
- OpenDocument
- presentatie
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Lees het oorspronkelijke formaat van een geladen presentatie in C# met Aspose.Slides voor .NET, vergelijk detectie‑API's en verwerk bestanden, streams en legacy‑formaten."
---
## **Overzicht**

Na het laden van een presentatie, lees de alleen‑lees [Presentation.SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sourceformat/) eigenschap om het oorspronkelijke formaat te bepalen. De eigenschap is ook beschikbaar via [IPresentation.SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/sourceformat/). Gebruik deze wanneer de daaropvolgende verwerking afhangt van het formaat waarvan de huidige instantie is geladen.

Het bronformaat verschilt van het [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/) dat voor een uitvoerbestand is geselecteerd. Opslaan naar een ander formaat wijzigt het bronformaat van de bestaande instantie niet.

## **Lees het bronformaat van een bestand**

Dit voorbeeld vereist een bestaand `sample.pptx` bestand. Het laadt het bestand en selecteert een verwerkingsbeleid voor de applicatie met behulp van [Presentation.SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sourceformat/), in plaats van de bestandsnaam. Verander het invoerpad om andere formaten te proberen. Het voorbeeld toont het geselecteerde beleid; vervang de berichten door je applicatielogica.

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

## **Herken de ondersteunde waarden**

De [SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/sourceformat/) enumeratie onderscheidt de volgende presentatieformaten. De onderstaande extensies zijn conventionele extensies, geen reconstructie van de oorspronkelijke bestandsnaam.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentatie 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentatie |
| `Pptm` | `.pptm` | Macro‑ondersteunde Office Open XML‑presentatie |
| `Pps` | `.pps` | PowerPoint‑diavoorstelling 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑diavoorstelling |
| `Ppsm` | `.ppsm` | Macro‑ondersteunde Office Open XML‑diavoorstelling |
| `Pot` | `.pot` | PowerPoint‑sjabloon 97–2003 |
| `Potx` | `.potx` | Office Open XML‑sjabloon |
| `Potm` | `.potm` | Macro‑ondersteunde Office Open XML‑sjabloon |
| `Odp` | `.odp` | OpenDocument‑presentatie |
| `Otp` | `.otp` | OpenDocument‑presentatiesjabloon |
| `Fodp` | `.fodp` | Flat XML ODF‑presentatie |
| `Xml` | `.xml` | PowerPoint XML‑presentatie |

## **Lees het bronformaat van een stream**

Dit voorbeeld vereist een bestaand `sample.pps` bestand. Het lezen van de bytes naar een geheugen‑stream modelleert invoer die zonder bestandsnaam wordt ontvangen, bijvoorbeeld een database‑waarde of een geüploadde byte‑array. De [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) constructor ontvangt alleen de stream.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS en POT gebruiken hetzelfde onderliggende binaire formaat. Bij het laden via een bestandspad kan de extensie helpen om een diavoorstelling of sjabloon te onderscheiden. Zonder bestandsnaam kan legacy‑PPS‑ en‑POT‑inhoud gerapporteerd worden als `SourceFormat.Ppt`; het PPS‑voorbeeld hierboven rapporteert `Ppt`.

Als je applicatie het onderscheid moet behouden, bewaar dan de oorspronkelijke bestandsnaam of sub‑type‑metadata apart. Een extensie is een handige hint voor deze legacy‑subtypen, maar mag niet de enige basis zijn om willekeurige presentatiedata te identificeren.

## **Vergelijk detectie vóór en na het laden**

Gebruik [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) en [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentationinfo/loadformat/) wanneer je een bestand moet inspecteren vóórdat je het volledige presentatie‑objectmodel laadt. Gebruik [Presentation.SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sourceformat/) wanneer de instantie al bestaat.

Dit voorbeeld vereist `sample.pptx` en toont `Pptx` voor beide controles. In productie kies je de API die past bij je verwerkingsfase; een reeds geladen presentatie heeft geen tweede inspectie nodig uitsluitend om het bronformaat op te vragen.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

De resultaten hebben verschillende enumeratietypen: [LoadFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/loadformat/) en [SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/sourceformat/). Vergelijk ze niet door hun numerieke waarden te casten of te veronderstellen dat elk formaat identieke detectieresultaten heeft. In de controle van opslaan‑en‑opnieuw‑laden die hieronder wordt beschreven, werd PowerPoint XML gerapporteerd als `LoadFormat.Unknown` vóór het laden en `SourceFormat.Xml` na het laden.

## **Houd bron- en uitvoerformaten gescheiden**

Dit voorbeeld vereist `sample.pptx` en schrijft `converted.odp`. Het toont `Pptx` zowel vóór als na het opslaan van de oorspronkelijke instantie. Alleen de nieuwe instantie die uit de ODP‑uitvoer wordt geladen, rapporteert `Odp`.

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

Een presentatie die vanaf nul wordt gemaakt met `new Presentation()` rapporteert `SourceFormat.Pptx`. Het heeft geen invoerbestand: dit is de standaardwaarde voor een nieuw aangemaakte instantie, niet het bewijs dat er een PPTX‑bestand is geladen. Houd bij of je applicatie de instantie heeft aangemaakt of geladen, als dat onderscheid van belang is.

## **Koppel een bronformaat aan een extensie**

Het onderstaande voorbeeld vereist `sample.pptx`. Het koppelt elke momenteel ondersteunde [SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/sourceformat/) waarde aan een conventionele extensie, zonder de invoer‑bestandsnaam te parseren. De fallback voorkomt dat stilzwijgend een extensie wordt toegewezen aan een niet‑herkende waarde.

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

Deze koppeling converteert geen bestand of herstelt geen legacy‑PPS‑/‑POT‑subtype dat verloren ging tijdens het laden van een stream. Voor daadwerkelijk opslaan, selecteer expliciet een [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/), of gebruik de conversie die wordt getoond in [Presentaties opslaan in hun oorspronkelijke formaat](/slides/nl/net/save-presentation/#save-presentations-in-their-original-format).

## **Verifieer formaten door op te slaan en opnieuw te openen**

Dit zelfstandige voorbeeld maakt een presentatie en schrijft drie bestanden in de werkmap, waarbij bestanden met dezelfde namen worden overschreven. Het opent elke uitvoer opnieuw, zowel via een pad als via een geheugen‑stream. Voor PPTX en ODP rapporteren beide routes het opgeslagen formaat. Voor PPS rapporteert laden via een pad `Pps`, terwijl laden van dezelfde bytes zonder bestandsnaam `Ppt` rapporteert.

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

Dezelfde controle met alle hierboven genoemde formaten leverde de volgende resultaten op voor gegenereerde presentaties met overeenkomende extensies:

| Opgeslagen formaat | SourceFormat van een bestandspad | SourceFormat van een naamloze stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectievelijk | Zelfde als bestandspad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectievelijk | Zelfde als bestandspad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectievelijk | Zelfde als bestandspad |
| ODP, OTP | `Odp`, `Otp` respectievelijk | Zelfde als bestandspad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

In deze controles was de enige bronformaat‑normalisatie PPS/POT naar `Ppt` voor naamloze streams. De tabel beschrijft formatidentificatie, niet de behoud van elke presentatiefunctie tijdens conversie.

## **Veelgestelde vragen**

**Verandert opslaan naar ODP het bronformaat van een presentatie geladen vanuit PPTX?**

Nee. De bestaande instantie rapporteert nog steeds `Pptx`. Een instantie die is geladen vanuit het opgeslagen ODP‑bestand rapporteert `Odp`.

**Kan een stream altijd een legacy‑presentatie, diavoorstelling en sjabloon onderscheiden?**

Nee. PPT, PPS en POT delen hetzelfde binaire formaat. Bewaar de bestandsnaam of sub‑type‑metadata apart wanneer dat onderscheid vereist is.

**Welke API moet ik gebruiken als de presentatie al geladen is?**

Lees [Presentation.SourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sourceformat/). Gebruik [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/presentationfactory/getpresentationinfo/) voor inspectie vóór het laden.