---
title: Cross-Platform pakket voor .NET 6 en later
linktitle: Cross-Platform pakket
type: docs
weight: 235
url: /nl/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- cross-platform
- ondersteuning voor .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Leer wanneer u het Aspose.Slides.NET6.CrossPlatform-pakket moet gebruiken: waarom het bestaat, op welke platformen het draait en wat het nodig heeft op Linux in plaats van libgdiplus."
---
## **Inleiding**

Aspose.Slides for .NET wordt gepubliceerd als twee NuGet‑pakketten. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) tekent dia's via de System.Drawing.Common‑bibliotheek van Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) tekent ze in plaats daarvan met zijn eigen grafische engine. Dit artikel legt uit waarom het tweede pakket bestaat, waar het draait, wat het nodig heeft op Linux, en hoe het naast System.Drawing.Common in één project kan bestaan.

## **Waarom een apart pakket**

Vanaf .NET 6 ondersteunt Microsoft System.Drawing.Common **alleen op Windows**(https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Daardoor heeft Aspose.Slides.NET op Linux de schakelaar `System.Drawing.EnableUnixSupport` nodig naast de `libgdiplus`‑bibliotheek, en zal het falen als het project System.Drawing.Common 7 of hoger gebruikt. [System Requirements](/slides/nl/net/system-requirements/) beschrijft deze voorwaarden.

Aspose.Slides.NET6.CrossPlatform gebruikt geen System.Drawing.Common of `libgdiplus`. Zijn grafische engine is een native bibliotheek die het pakket in één build per ondersteund platform bevat. Beide pakketten leveren dezelfde Aspose.Slides‑namespaces en -klassen, dus overschakelen verandert alleen de pakket‑referentie, niet je code.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafische weergave | System.Drawing.Common | Native grafische engine opgenomen in het pakket |
| Doel‑frameworks | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux‑vereisten | `libgdiplus` en de `System.Drawing.EnableUnixSupport`‑schakelaar | `fontconfig` |
| Alpine Linux | Ondersteund | Niet ondersteund |

## **Ondersteunde platformen**

Aspose.Slides.NET6.CrossPlatform werkt met .NET 6 en latere versies op de volgende platformen:

- **Windows**: x86 en x64. De native bibliotheek gebruikt de Microsoft Visual C++‑runtime; zie [System Requirements](/slides/nl/net/system-requirements/).
- **Linux**: x64 met glibc 2.23 of later, en ARM64 met glibc 2.39 of later.
- **macOS**: x64 (Intel) en ARM64 (Apple silicon).

Het draait niet op Windows op ARM64, op Alpine Linux of andere distributies die op musl in plaats van glibc zijn gebaseerd, of op distributies met een oudere glibc, zoals CentOS 7. Gebruik Aspose.Slides.NET op die systemen.

## **Installeren op Linux**

Op Linux vereist het pakket de `fontconfig`‑bibliotheek, maar niet `libgdiplus`. Op Debian en Ubuntu installeer je `fontconfig` en voeg je daarna het pakket toe aan je project:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Op Debian en Ubuntu installeert `libfontconfig1` tevens de DejaVu‑lettertypen, zodat tekst wordt gerenderd zonder extra lettertype‑pakketten. Zonder `fontconfig` mislukt het aanmaken van een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) met een `TypeInitializationException` waarvan de onderliggende `DllNotFoundException` aangeeft dat `libfontconfig.so.1` niet geopend kan worden. [System Requirements](/slides/nl/net/system-requirements/) bevat een kort programma dat de installatie controleert.

## **Cloud‑ en container‑hosts**

Omdat het geen `libgdiplus` nodig heeft, is Aspose.Slides.NET6.CrossPlatform het pakket om te gebruiken op Linux‑hosts waar je `libgdiplus` niet kunt installeren. Het heeft wel `fontconfig` en lettertypen nodig, die minimale basis‑images vaak missen. De AWS Lambda‑basis‑image voor .NET 8 bevat bijvoorbeeld geen van beide. In een container‑image die daarop is gebaseerd, voer je `dnf install -y fontconfig` uit, waarmee ook de Noto Sans‑lettertypen worden geïnstalleerd.

Voor handleidingen voor specifieke cloudplatformen, zie [Aspose.Slides on Cloud Platforms](/slides/nl/net/slides-on-cloud-platforms/).

## **System.Drawing.Common gebruiken in hetzelfde project (CS0433)**

Een project dat Aspose.Slides.NET6.CrossPlatform gebruikt, kan ook System.Drawing.Common refereren, direct of via een ander pakket. De huidige versie van Aspose.Slides exposeert geen publieke types in `System`‑namespaces, zodat de twee bibliotheken niet conflicteren, en je kunt de `Aspose.Slides`‑ en `System.Drawing`‑namespaces in hetzelfde bestand importeren.

Als de compiler fout CS0433 rapporteert omdat een type zoals `Image` of `Graphics` zowel in Aspose.Slides als in System.Drawing.Common bestaat, dan gebruikt je project een oudere versie van Aspose.Slides. Update het pakket naar de nieuwste versie. Aspose.Slides levert gerenderde afbeeldingen als [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)-objecten, die worden beschreven in [Modern API](/slides/nl/net/modern-api/).

## **FAQ**

**Moet ik mijn code aanpassen wanneer ik overschakel van Aspose.Slides.NET naar Aspose.Slides.NET6.CrossPlatform?**

Nee. Beide pakketten leveren dezelfde Aspose.Slides‑namespaces en -klassen, dus je vervangt alleen de pakket‑referentie. Aspose.Slides.NET6.CrossPlatform heeft de `System.Drawing.EnableUnixSupport`‑schakelaar niet nodig. Voeg slechts één van de twee pakketten toe aan een project.

**Kan ik Aspose.Slides.NET6.CrossPlatform gebruiken in een .NET Framework‑project?**

Nee. Het pakket richt zich uitsluitend op .NET 6 en latere versies. Voor .NET Framework 4.6.2 en hoger gebruik je Aspose.Slides.NET.