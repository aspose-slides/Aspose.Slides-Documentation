---
title: Beveiliging
type: docs
weight: 160
url: /nl/net/security/
keywords:
- beveiliging
- afhankelijkheden
- componenten van derden
- NuGet
- kwetsbaarheidsscan
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk hoe Aspose.Slides for .NET presentaties verwerkt, van welke NuGet-pakketten het afhankelijk is voor elk doel-framework, en welke componenten van derden het bevat."
---
## **Beveiliging in Aspose.Slides**

Aspose past best practices toe bij het ontwikkelen van zijn producten.

* Aspose.Slides for .NET wordt gebruikt om presentaties te manipuleren en ze naar andere formaten te converteren. Het voert geen scripts uit in presentaties. Aspose.Slides analyseert de presentatiestructuur en laat de code van de eindgebruiker het objectmodel op een handige manier manipuleren.
* Aspose.Slides fungeert als een bibliotheek die documenten analyseert en interpreteert zonder externe code uit te voeren. Alle Aspose‑producten draaien op uw machines. Ze verzenden geen gegevens naar Aspose. De enige uitzondering is een [metered license](https://purchase.aspose.com/faqs/licensing/metered): als u er een gebruikt, worden alleen uw API‑gebruikgegevens verwerkt.
* Aspose‑componenten draaien in dezelfde gebruikerscontext als reguliere toepassingen. Daarom vormen Aspose‑componenten geen risico voor vitale systeembronnen. Bovendien worden macro's niet automatisch uitgevoerd wanneer een Aspose‑component een document opent.
* De risico's die inherent zijn aan of geassocieerd zijn met het Microsoft Office‑pakket zijn niet van toepassing op Aspose‑componenten, waardoor Aspose‑producten zeer veilig zijn.

## **NuGet-afhankelijkheden**

Aspose.Slides for .NET hangt af van pakketten die Microsoft publiceert op NuGet. De afhankelijkheden verschillen per pakket en doel‑framework:

| Pakket | Doel‑framework | Afhankelijkheden |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

De **Afhankelijkheden**‑sectie van de [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) en [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) pagina's op NuGet vermeldt de minimale versie van elke afhankelijkheid voor elke release.

Wanneer u Aspose.Slides aan een project toevoegt, herstelt NuGet ook de afhankelijkheden van deze pakketten. Om elk pakket dat uw project herstelt, inclusief deze transitieve afhankelijkheden, te tonen, voert u dit commando uit in de projectmap:

```bash
dotnet list package --include-transitive
```

Om dezelfde set pakketten te controleren op bekende kwetsbaarheden, voert u uit:

```bash
dotnet list package --vulnerable --include-transitive
```

Voor andere manieren om NuGet‑pakketten te auditen, zie [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Derde‑partij componenten**

Aspose.Slides bevat code van derden open‑source componenten. Ze maken deel uit van het product, niet van aparte NuGet‑pakketten, dus tools die alleen NuGet‑afhankelijkheden lezen, geven ze niet weer. Beide pakketten bevatten het bestand *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, waarin de componenten en hun licenties staan vermeld:

| Component | Vermelde licentie |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD‑style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD‑style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **Veelgestelde vragen**

**Welke systemen worden gebruikt om kwetsbaarheden in de Aspose‑code te monitoren?**

We voeren een statische code‑analyse uit voor elke Aspose.Slides‑release. We kunnen beveiligingsrapporten leveren die aantonen dat de Aspose.Slides‑code voldoet aan de OWASP Top 10.

**Gebruikt Aspose.Slides externe pakketten?**

Ja. Het hangt af van de Microsoft NuGet‑pakketten die in [NuGet‑afhankelijkheden](#nuget-dependencies) staan vermeld, en het bevat de derde‑partij componenten die in [Derde‑partij componenten](#third-party-components) zijn opgesomd. Neem beide op in uw beveiligingsreview, en gebruik `dotnet list package --vulnerable --include-transitive` om de NuGet‑pakketten te controleren die uw project herstelt.