---
title: Zabezpečení
type: docs
weight: 160
url: /cs/net/security/
keywords:
- zabezpečení
- závislosti
- komponenty třetích stran
- NuGet
- skenování zranitelností
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte, jak Aspose.Slides pro .NET zpracovává prezentace, na jaké NuGet balíčky se pro každý cílový framework spoléhá, a které komponenty třetích stran zahrnuje."
---
## **Zabezpečení v Aspose.Slides**

Aspose při vývoji svých produktů používá osvědčené postupy.

* Aspose.Slides pro .NET slouží k manipulaci s prezentacemi a k jejich konverzi do jiných formátů. Nespouští skripty v prezentacích. Aspose.Slides analyzuje strukturu prezentace a umožňuje kódu koncového uživatele pohodlně pracovat s objektovým modelem.
* Aspose.Slides funguje jako knihovna, která analyzuje a interpretuje dokumenty bez vykonávání vzdáleného kódu. Všechny produkty Aspose běží na vašich strojích. Nepřenášejí žádná data do Aspose. Jedinou výjimkou je [metered licence](https://purchase.aspose.com/faqs/licensing/metered): pokud ji používáte, zpracovává se pouze informace o využití vašeho API.
* Komponenty Aspose běží ve stejném uživatelském kontextu jako běžné aplikace. Proto komponenty Aspose neohrožují kritické systémové prostředky. Navíc když komponenta Aspose otevře dokument, makra se nespustí automaticky.
* Rizika spojená s balíčkem Microsoft Office se na komponenty Aspose nevztahují, takže produkty Aspose jsou velmi bezpečné.

## **Závislosti NuGet**

Aspose.Slides pro .NET závisí na balíčcích, které Microsoft zveřejňuje na NuGet. Závislosti se liší podle balíčku a cílového frameworku:

| Balíček | Cílový framework | Závislosti |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

Oddíl **Závislosti** na stránkách [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) a [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) na NuGet uvádí minimální verzi každé závislosti pro každé vydání.

Když přidáte Aspose.Slides do projektu, NuGet také obnoví závislosti těchto balíčků. Pro výpis všech balíčků, které váš projekt obnoví, včetně těchto tranzitivních závislostí, spusťte tento příkaz ve složce projektu:

```bash
dotnet list package --include-transitive
```

Pro kontrolu stejné sady balíčků proti známým zranitelnostem spusťte:

```bash
dotnet list package --vulnerable --include-transitive
```

Další způsoby auditu balíčků NuGet najdete v [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Komponenty třetích stran**

Aspose.Slides obsahuje kód z otevřených komponent třetích stran. Jsou součástí produktu, nikoli samostatných balíčků NuGet, takže nástroje, které čtou pouze závislosti NuGet, je neuvádějí. Oba balíčky obsahují soubor *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, který uvádí komponenty a jejich licence:

| Komponenta | Licence uvedená v oznámení |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **Často kladené otázky**

**Jaké systémy se používají ke sledování zranitelností v kódu Aspose?**

Provádíme statickou analýzu kódu pro každé vydání Aspose.Slides. Můžeme poskytnout bezpečnostní zprávy, které dokazují, že kód Aspose.Slides splňuje OWASP Top 10.

**Používá Aspose.Slides externí balíčky?**

Ano. Závisí na balíčcích Microsoft NuGet uvedených v [Závislosti NuGet](#nuget-dependencies) a obsahuje komponenty třetích stran uvedené v [Komponenty třetích stran](#third-party-components). Zahrňte oba do svého bezpečnostního auditu a použijte `dotnet list package --vulnerable --include-transitive` pro kontrolu balíčků NuGet, které váš projekt obnoví.