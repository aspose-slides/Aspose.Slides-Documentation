---
title: Plattformsoberoende paket för .NET 6 och senare
linktitle: Plattformsoberoende paket
type: docs
weight: 235
url: /sv/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- plattformoberoende
- .NET 6-stöd
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
description: "Lär dig när du ska använda paketet Aspose.Slides.NET6.CrossPlatform: varför det finns, vilka plattformar det körs på och vad det behöver på Linux istället för libgdiplus."
---
## **Introduktion**

Aspose.Slides för .NET publiceras som två NuGet‑paket. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) ritar bilder genom Microsofts System.Drawing.Common‑bibliotek. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) ritar dem med sin egen grafikmotor istället. Den här artikeln förklarar varför det andra paketet finns, var det körs, vad det kräver på Linux och hur det samexisterar med System.Drawing.Common i ett projekt.

## **Varför ett separat paket**

Från och med .NET 6 stödjer Microsoft System.Drawing.Common [endast på Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Som en följd av detta behöver Aspose.Slides.NET på Linux växeln `System.Drawing.EnableUnixSupport` utöver biblioteket `libgdiplus`, och det misslyckas där om projektet refererar System.Drawing.Common 7 eller senare. [System Requirements](/slides/sv/net/system-requirements/) beskriver dessa villkor.

Aspose.Slides.NET6.CrossPlatform använder inte System.Drawing.Common eller `libgdiplus`. Dess grafikmotor är ett inbyggt bibliotek som paketet innehåller i en byggnad per stödjad plattform. Båda paketen levererar samma Aspose.Slides‑namnrymder och klasser, så byte från det ena till det andra ändrar bara paketreferensen, inte din kod.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafik | System.Drawing.Common | Inbyggd grafikmotor i paketet |
| Målramsverk | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux‑krav | `libgdiplus` och växeln `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Stöds | Stöds inte |

## **Stödda plattformar**

Aspose.Slides.NET6.CrossPlatform fungerar med .NET 6 och senare versioner på följande plattformar:

- **Windows**: x86 och x64. Det inbyggda biblioteket använder Microsoft Visual C++‑runtime; se [System Requirements](/slides/sv/net/system-requirements/).
- **Linux**: x64 med glibc 2.23 eller senare, och ARM64 med glibc 2.39 eller senare.
- **macOS**: x64 (Intel) och ARM64 (Apple silicon).

Det kör inte på Windows på ARM64, på Alpine Linux eller andra distributioner som bygger på musl istället för glibc, eller på distributioner med en äldre glibc, såsom CentOS 7. Använd Aspose.Slides.NET på dessa system.

## **Installera på Linux**

På Linux kräver paketet biblioteket `fontconfig`, men inte `libgdiplus`. På Debian och Ubuntu, installera `fontconfig` och lägg sedan till paketet i ditt projekt:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

På Debian och Ubuntu installerar `libfontconfig1` också DejaVu‑typsnitten, så text renderas utan ytterligare typsnittspaket. Utan `fontconfig` misslyckas skapandet av en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) med ett `TypeInitializationException` vars inre `DllNotFoundException` rapporterar att `libfontconfig.so.1` inte kan öppnas. [System Requirements](/slides/sv/net/system-requirements/) innehåller ett kort program som kontrollerar installationen.

## **Moln och container‑värdar**

Eftersom det inte behöver `libgdiplus` är Aspose.Slides.NET6.CrossPlatform paketet att använda på Linux‑värdar där du inte kan installera `libgdiplus`. Det kräver fortfarande `fontconfig` och typsnitt, vilket minimala bas‑images kan sakna. AWS Lambda‑bas‑image för .NET 8 innehåller till exempel ingen av dem. I en container‑image byggd på den, kör `dnf install -y fontconfig`, vilket också installerar Noto Sans‑typsnitten.

För guider till specifika molnplattformar, se [Aspose.Slides on Cloud Platforms](/slides/sv/net/slides-on-cloud-platforms/).

## **Använda System.Drawing.Common i samma projekt (CS0433)**

Ett projekt som använder Aspose.Slides.NET6.CrossPlatform kan också referera System.Drawing.Common, direkt eller via ett annat paket. Den aktuella versionen av Aspose.Slides exponerar inga publika typer i `System`‑namnrymder, så de två biblioteken konflikterar inte, och du kan importera `Aspose.Slides`‑ och `System.Drawing`‑namnrymderna i samma fil.

Om kompilatorn rapporterar fel CS0433 eftersom en typ som `Image` eller `Graphics` finns i både Aspose.Slides och System.Drawing.Common, använder ditt projekt en äldre version av Aspose.Slides. Uppdatera paketet till den senaste versionen. Aspose.Slides returnerar renderade bilder som [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)-objekt, vilka beskrivs i [Modern API](/slides/sv/net/modern-api/).

## **FAQ**

**Behöver jag ändra min kod när jag byter från Aspose.Slides.NET till Aspose.Slides.NET6.CrossPlatform?**

Nej. Båda paketen levererar samma Aspose.Slides‑namnrymder och klasser, så du ersätter bara paketreferensen. Aspose.Slides.NET6.CrossPlatform behöver inte växeln `System.Drawing.EnableUnixSupport`. Lägg bara till ett av de två paketen i ett projekt.

**Kan jag använda Aspose.Slides.NET6.CrossPlatform i ett .NET Framework‑projekt?**

Nej. Paketet riktar sig endast mot .NET 6 och senare. För .NET Framework 4.6.2 och senare, använd Aspose.Slides.NET.