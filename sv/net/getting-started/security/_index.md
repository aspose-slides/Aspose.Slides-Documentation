---
title: Säkerhet
type: docs
weight: 160
url: /sv/net/security/
keywords:
- säkerhet
- beroenden
- tredjepartskomponenter
- NuGet
- sårbarhetsskanning
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska hur Aspose.Slides för .NET bearbetar presentationer, vilka NuGet-paket den är beroende av för varje målramverk, och vilka tredjepartskomponenter den inkluderar."
---
## **Säkerhet i Aspose.Slides**

Aspose tillämpar bästa praxis när de utvecklar sina produkter.

* Aspose.Slides för .NET används för att manipulera presentationer och konvertera dem till andra format. Det kör inga skript i presentationer. Aspose.Slides analyserar presentationsstrukturen och låter slutanvändarens kod manipulera objektmodellen på ett bekvämt sätt.
* Aspose.Slides fungerar som ett bibliotek som analyserar och tolkar dokument utan att köra fjärrkod. Alla Aspose‑produkter körs på dina maskiner. De överför inga data till Aspose. Det enda undantaget är en [licens med mätning](https://purchase.aspose.com/faqs/licensing/metered): om du använder en, bearbetas endast information om din API‑användning.
* Aspose‑komponenter körs i samma användarkontext som vanliga applikationer. Därför utgör Aspose‑komponenter ingen risk för viktiga systemresurser. Dessutom, när en Aspose‑komponent öppnar ett dokument, körs makron inte automatiskt.
* Riskerna som är inneboende i eller förknippade med Microsoft Office‑paketet gäller inte för Aspose‑komponenter, så Aspose‑produkter är mycket säkra.

## **NuGet‑beroenden**

Aspose.Slides för .NET är beroende av paket som Microsoft publicerar på NuGet. Beroendena skiljer sig åt beroende på paket och mål‑ramverk:

| Paket | Mål‑ramverk | Beroenden |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

Avsnittet **Dependencies** på [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) och [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)‑sidorna på NuGet listar den lägsta versionen av varje beroende för varje utgåva.

När du lägger till Aspose.Slides i ett projekt återställer NuGet också beroendena för dessa paket. För att lista varje paket som ditt projekt återställer, inklusive dessa transitiva beroenden, kör detta kommando i projektmappen:

```bash
dotnet list package --include-transitive
```

För att kontrollera samma uppsättning paket mot kända sårbarheter, kör:

```bash
dotnet list package --vulnerable --include-transitive
```

För andra sätt att granska NuGet‑paket, se [Granska paketberoenden för säkerhetssårbarheter](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Tredjepartskomponenter**

Aspose.Slides innehåller kod från tredjeparts‑öppen‑källkomponenter. De är en del av produkten, inte separata NuGet‑paket, så verktyg som bara läser NuGet‑beroenden listar dem inte. Båda paketen innehåller filen *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, som listar komponenterna och deras licenser:

| Komponent | Licens angiven i notisen |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**Vilka system används för att övervaka sårbarheter i Aspose‑kod?**

Vi kör en statisk kodanalys för varje Aspose.Slides‑utgåva. Vi kan tillhandahålla säkerhetsrapporter som visar att Aspose.Slides‑koden klarar OWASP Top 10.

**Använder Aspose.Slides externa paket?**

Ja. Den är beroende av Microsoft‑NuGet‑paketen som listas i [NuGet‑beroenden](#nuget-dependencies), och den inkluderar tredjepartskomponenterna som listas i [Tredjepartskomponenter](#third-party-components). Ta med båda i din säkerhetsgranskning, och använd `dotnet list package --vulnerable --include-transitive` för att kontrollera de NuGet‑paket som ditt projekt återställer.