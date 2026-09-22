---
title: Určete původní formát prezentace v .NET
linktitle: Zdrojový formát
type: docs
weight: 35
url: /cs/net/detect-presentation-source-format/
keywords:
- zdrojový formát
- zjištění formátu prezentace
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Přečtěte původní formát načtené prezentace v C# pomocí Aspose.Slides pro .NET, porovnejte API pro detekci a pracujte se soubory, streamy a staršími formáty."
---
## **Přehled**

Po načtení prezentace přečtěte pouze pro čtení vlastnost [Presentation.SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sourceformat/) pro určení jejího původního formátu. Vlastnost je také k dispozici přes [IPresentation.SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/sourceformat/). Použijte ji, když následné zpracování závisí na formátu, ze kterého byla aktuální instance načtena.

Zdrojový formát se liší od [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/) vybraného pro výstupní soubor. Uložení do jiného formátu nezmění zdrojový formát existující instance.

## **Přečtení zdrojového formátu souboru**

Tento příklad vyžaduje existující soubor `sample.pptx`. Načte soubor a vybere politiku zpracování aplikace pomocí [Presentation.SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sourceformat/), místo názvu souboru. Změňte vstupní cestu a vyzkoušejte jiné formáty. Příklad vypíše vybranou politiku; nahraďte zprávy logikou vaší aplikace.

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

## **Rozpoznání podporovaných hodnot**

Výčtová položka [SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/sourceformat/) rozlišuje následující formáty prezentací. Níže uvedené přípony jsou konvenční, nejedná se o rekonstrukci původního názvu souboru.

| SourceFormat value | Extension | Formát |
| --- | --- | --- |
| `Ppt` | `.ppt` | Prezentace PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Prezentace Office Open XML |
| `Pptm` | `.pptm` | Prezentace Office Open XML s makry |
| `Pps` | `.pps` | Promítání PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Promítání Office Open XML |
| `Ppsm` | `.ppsm` | Promítání Office Open XML s makry |
| `Pot` | `.pot` | Šablona PowerPoint 97–2003 |
| `Potx` | `.potx` | Šablona Office Open XML |
| `Potm` | `.potm` | Šablona Office Open XML s makry |
| `Odp` | `.odp` | Prezentace OpenDocument |
| `Otp` | `.otp` | Šablona prezentace OpenDocument |
| `Fodp` | `.fodp` | Prezentace Flat XML ODF |
| `Xml` | `.xml` | Prezentace PowerPoint XML |

## **Přečtení zdrojového formátu ze streamu**

Tento příklad vyžaduje existující soubor `sample.pps`. Načtení jeho bajtů do paměťového streamu modeluje vstup přijatý bez názvu souboru, například jako hodnota v databázi nebo nahraný pole bajtů. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) přijímá pouze stream.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS a POT používají stejný základní binární formát. Při načítání podle cesty k souboru může přípona pomoci rozlišit promítání nebo šablonu. Bez názvu souboru může být starší obsah PPS a POT hlášen jako `SourceFormat.Ppt`; výše uvedený příklad PPS hlásí `Ppt`.

Pokud vaše aplikace musí zachovat toto rozlišení, uchovejte původní název souboru nebo metadata podtypu odděleně. Přípona je užitečná nápověda pro tyto starší podtypy, ale neměla by být jediným základem pro identifikaci libovolného obsahu prezentace.

## **Porovnání detekce před a po načtení**

Použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) a [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentationinfo/loadformat/), když potřebujete soubor zkontrolovat před načtením jeho kompletního objektového modelu prezentace. Použijte [Presentation.SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sourceformat/) když instance již existuje.

Tento příklad vyžaduje `sample.pptx` a pro obě kontroly vypíše `Pptx`. Ve výrobě zvolte API vhodné pro vaše zpracovatelské fáze; již načtená prezentace nepotřebuje druhou kontrolu jen za účelem získání svého zdrojového formátu.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Výsledky mají různé typy výčtů: [LoadFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/loadformat/) a [SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/sourceformat/). Nekomparujte je přetypováním jejich číselných hodnot ani nepředpokládejte, že každý formát má stejné výsledky detekce. V testu uložení a opětovného načtení popsaném níže byl PowerPoint XML před načtením hlášen jako `LoadFormat.Unknown` a po načtení jako `SourceFormat.Xml`.

## **Udržujte zdrojové a výstupní formáty oddělené**

Tento příklad vyžaduje `sample.pptx` a zapisuje `converted.odp`. Vypíše `Pptx` jak před, tak po uložení původní instance. Pouze nová instance načtená z výstupu ODP hlásí `Odp`.

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

Prezentace vytvořená od nuly pomocí `new Presentation()` hlásí `SourceFormat.Pptx`. Nemá žádný vstupní soubor: tato hodnota je výchozí pro nově vytvořenou instanci, ne důkaz, že byl načten soubor PPTX. Sledujte, zda vaše aplikace vytvořila nebo načetla instanci, pokud je toto rozlišení důležité.

## **Mapování zdrojového formátu na příponu**

Následující příklad vyžaduje `sample.pptx`. Mapuje každou aktuálně podporovanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/sourceformat/) na konvenční příponu, aniž by parsoval vstupní název souboru. Náhradní řešení zabraňuje tichému přiřazení přípony neznámé hodnotě.

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

Toto mapování neprovádí konverzi souboru ani neobnovuje starší podtyp PPS/POT ztracený během načítání ze streamu. Pro skutečné ukládání vyberte explicitně [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/), nebo použijte konverzi uvedenou v [Save Presentations in Their Original Format](/slides/cs/net/save-presentation/#save-presentations-in-their-original-format).

## **Ověření formátů uložením a opětovným otevřením**

Tento samostatný příklad vytvoří prezentaci a zapíše tři soubory do pracovního adresáře, přepisuje soubory se stejnými názvy. Každý výstup znovu otevře jak podle cesty, tak přes paměťový stream. Pro PPTX a ODP oba způsoby hlásí uložený formát. Pro PPS načtení podle cesty hlásí `Pps`, zatímco načtení stejných bajtů bez názvu souboru hlásí `Ppt`.

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

Stejná kontrola se všemi výše uvedenými formáty vygenerovala následující výsledky pro prezentace s odpovídajícími příponami:

| Uložený formát | SourceFormat z cesty k souboru | SourceFormat z nepojmenovaného streamu |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Stejně jako z cesty k souboru |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Stejně jako z cesty k souboru |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Stejně jako z cesty k souboru |
| ODP, OTP | `Odp`, `Otp` respectively | Stejně jako z cesty k souboru |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

V těchto kontrolách byla jedinou normalizací zdrojového formátu převod PPS/POT na `Ppt` pro nepojmenované streamy. Tabulka popisuje identifikaci formátu, nikoli zachování všech funkcí prezentace během konverze.

## **Často kladené otázky**

**Mění uložení do ODP zdrojový formát prezentace načtené z PPTX?**

Ne. Existující instance stále hlásí `Pptx`. Instance načtená ze souboru ODP, který byl uložen, hlásí `Odp`.

**Dokáže stream vždy rozlišit starší prezentaci, promítání a šablonu?**

Ne. PPT, PPS a POT sdílejí binární formát. Uchovejte název souboru nebo metadata podtypu odděleně, pokud je toto rozlišení vyžadováno.

**Které API mám použít, pokud je prezentace již načtena?**

Přečtěte [Presentation.SourceFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sourceformat/). Použijte [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationfactory/getpresentationinfo/) pro kontrolu před načtením.