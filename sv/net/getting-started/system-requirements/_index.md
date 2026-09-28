---
title: Systemkrav
type: docs
weight: 60
url: /sv/net/system-requirements/
keywords:
- systemkrav
- stödda plattformar
- målramverk
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Kontrollera vad Aspose.Slides för .NET behöver innan du installerar det: vilka ramverk varje NuGet‑paket riktar sig mot, de stödjade operativsystemen och processorerna samt vilka bibliotek och typsnitt som Linux kräver."
---
## **Introduktion**

Aspose.Slides för .NET är ett fristående bibliotek: det kräver inte Microsoft PowerPoint eller Microsoft Office. Det publiceras som två NuGet‑paket, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) och [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Båda tillhandahåller samma Aspose.Slides‑namnrymder och klasser; de skiljer sig åt i vilka ramverk de riktar sig mot och i hur de ritar bilder, vilket avgör var de körs och vad de behöver.

Denna artikel listar vilka .NET‑versioner och plattformar varje paket stödjer samt vilka systembibliotek och typsnitt som Linux behöver, och avslutas med ett kort program som kontrollerar din konfiguration. För att lägga till ett paket i ett projekt, se [Installation](/slides/sv/net/installation/).

## **Stödda .NET‑versioner**

Varje paket innehåller en build av Aspose.Slides per mål‑ramverk, och NuGet väljer den build som matchar ditt projekts mål‑ramverk.

| Paket | Mål‑ramverk i paketet | Ditt projekt kan rikta mot |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 eller senare; .NET 6 eller senare, inklusive .NET 8, .NET 9 och .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 eller senare, inklusive .NET 8, .NET 9 och .NET 10 |

`netstandard2.0`‑builden låter ett .NET Standard 2.0‑klassbibliotek referera till Aspose.Slides.NET. En applikation som använder ett sådant bibliotek kör den build som matchar applikationens eget mål‑ramverk: en .NET 8‑applikation kör exempelvis `net6.0`‑builden.

## **Stödda operativsystem och processorer**

**Aspose.Slides.NET** innehåller endast processor‑oberoende (AnyCPU) hanterad kod, så den körs på den processorarkitektur som .NET‑körningsmiljön som laddar den har. Den ritar bilder via Microsofts System.Drawing.Common‑bibliotek, vilket Microsoft endast stödjer [på Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). På Linux behöver Aspose.Slides.NET därför `libgdiplus`‑biblioteket och en start‑switch, beskrivet i [Linux](#linux). Den körs på Linux‑distributioner som tillhandahåller `libgdiplus`, såsom Debian, Ubuntu och Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** ritar bilder med sin egen grafikmotor. Motorn är ett inbyggt bibliotek som paketet innehåller i en build per plattform, så paketet körs endast på följande plattformar:

| Operativsystem | Processorer | Anteckningar |
|---|---|---|
| Windows | x86, x64 | Windows på ARM64 stöds inte. |
| Linux | x64, ARM64 | Kräver glibc 2.23 eller senare på x64 och glibc 2.39 eller senare på ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform kör inte på Alpine Linux eller andra distributioner som byggts på musl istället för glibc, eller på distributioner med en äldre glibc, såsom CentOS 7. Använd Aspose.Slides.NET på dessa system.

På Windows använder Aspose.Slides.NET6.CrossPlatform‑biblioteket Microsoft Visual C++‑runtime (*MSVCP140.dll* och *VCRUNTIME140.dll*, samt *VCRUNTIME140_1.dll* på x64). Om dessa filer saknas på målmaskinen, installera [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Båda paketen kräver ytterligare systembibliotek på Linux. Utan dem misslyckas det första exemplet i [Create Presentations](/slides/sv/net/create-presentation/) med ett undantag istället för att spara filen. Kommandona nedan är för Debian och Ubuntu; på dessa distributioner medför varje bibliotek även DejaVu‑typsnitten (`fonts-dejavu-core`), så text renderas utan ytterligare typsnittspaket.

### **Aspose.Slides.NET6.CrossPlatform**

Paketets Linux‑bibliotek kräver `fontconfig`‑biblioteket:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Utan det misslyckas skapandet av en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) med ett `TypeInitializationException` vars inre `DllNotFoundException` rapporterar att `libfontconfig.so.1` inte kan öppnas.

Minimalbasbilder kan också sakna `fontconfig`. AWS Lambda‑basbilden för .NET 8 innehåller till exempel varken `fontconfig` eller några typsnitt. I en container‑image byggd på den, kör `dnf install -y fontconfig`, vilket också installerar Noto Sans‑typsnitten.

### **Aspose.Slides.NET**

Paketet kräver två saker på Linux:

1. `libgdiplus`‑biblioteket:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. `System.Drawing.EnableUnixSupport`‑switchen, som aktiveras i början av din applikation innan något Aspose.Slides‑anrop. I ett *Program.cs* med top‑level‑satser, placera den efter `using`‑direktiven:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Utan `libgdiplus` misslyckas sparandet av en presentation med ett `TypeInitializationException` vars inre `DllNotFoundException` rapporterar att `libgdiplus` inte kan laddas. Utan switchen blir det inre undantaget `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Varning" %}}
Switchen fungerar endast med System.Drawing.Common 6, den version som Aspose.Slides.NET är beroende av. Microsoft tog bort den i System.Drawing.Common 7. Om ditt projekt refererar till System.Drawing.Common 7 eller senare, direkt eller via ett annat paket, misslyckas Aspose.Slides.NET på Linux med `PlatformNotSupportedException` även om `libgdiplus` är installerat och switchen är aktiverad. Använd i så fall Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

På Alpine Linux, använd Aspose.Slides.NET med switchen som beskrivs ovan. Alpine‑bilder innehåller vanligtvis inga typsnitt, och `libgdiplus` ensamt installerar inga, så installera `libgdiplus` tillsammans med minst ett typsnittspaket. Utan typsnitt misslyckas sparandet av en presentation med följande fel:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Alternativ 1: DejaVu-typsnitt**

Det rekommenderade alternativet är paketet `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

På nuvarande Alpine‑utgåvor installerar `ttf-dejavu` paketet `font-dejavu`, som även installerar `fontconfig` och de typsnittverktyg som det beror på.

**Alternativ 2: Microsoft‑kärntypsnitt**

Om dina presentationer använder Microsoft‑typsnitt som Arial, Times New Roman, Courier New eller Verdana, installera Microsoft‑kärntypsnitten istället. `update-ms-fonts`‑steget laddar ner typsnitten medan bilden byggs, så byggprocessen behöver internetåtkomst:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Stöd för globalisering**

Båda paketen kräver .NET‑globaliseringsstöd, vilket .NET på Linux tillhandahåller via ICU‑biblioteken. I [globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), misslyckas skapandet av en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) med `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Vissa container‑bilder sätter på detta läge. .NET‑runtime‑bilderna för Alpine Linux (`runtime-deps`, `runtime` och `aspnet`) sätter till exempel `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` och innehåller inte ICU. I en bild byggd på dem, installera ICU och stäng av läget:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Se även till att din projektfil inte sätter egenskapen `InvariantGlobalization` till `true`.

## **Kontrollera din konfiguration**

För att kontrollera att ett paket och dess krav är på plats, kör ett program som sparar en presentation och renderar en bild till en bildfil. Sparande och rendering använder grafikbiblioteket och typsnitten, vilket är vad Linux‑kraven ovan tillhandahåller.

Skapa en konsolapplikation och lägg till paketet enligt [Installation](/slides/sv/net/installation/), ersätt innehållet i *Program.cs* med koden nedan och kör `dotnet run`. Om du använder Aspose.Slides.NET på Linux, lägg till `System.Drawing.EnableUnixSupport`‑switch‑satsen som visas i [Linux](#linux) efter `using`‑direktiven. Programmet använder top‑level‑satser och `using`‑deklarationer, vilket kräver C# 9 eller senare. Projekt som riktar sig mot .NET 6 eller senare använder en nyare C#‑version som standard; i ett projekt som riktar sig mot .NET Framework, lägg till `<LangVersion>latest</LangVersion>` i en `PropertyGroup` i projektfilen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Programmet lägger till en rektangel med text på den första bilden och sparar presentationen som *hello.pptx* med metoden [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Det renderar sedan bilden med [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) och sparar resultatet som *hello.png* med [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) i formatet [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). Skalningsfaktorn 1 renderar en pixel per punkt, så den standard 720 × 540‑punkt‑bilden blir en 720 × 540‑pixel‑bild, med texten synlig i rektangeln. Utan en licens har båda filerna också ett evalueringsvattenmärke; se [Licensing](/slides/sv/net/licensing/). Om ett krav saknas, avbryts programmet med ett av undantagen som beskrivs i [Linux](#linux).

## **Utvecklingsverktyg**

Du kan bygga applikationer som använder Aspose.Slides med vilket verktyg som helst som stödjer ditt projekts mål‑ramverk: .NET‑SDK och dess `dotnet`‑kommandoradsgränssnitt på Windows, Linux och macOS, eller Visual Studio på Windows. [Installation](/slides/sv/net/installation/) beskriver båda.

## **FAQ**

**Behöver jag Microsoft PowerPoint installerat för konverteringar och rendering?**

Nej, PowerPoint krävs inte. Aspose.Slides är en fristående motor för [creating](/slides/sv/net/create-presentation/), modifiering, [converting](/slides/sv/net/convert-presentation/) och [rendering](/slides/sv/net/convert-powerpoint-to-png/) av presentationer.

**Vilket paket bör jag använda?**

Använd Aspose.Slides.NET på Windows och Aspose.Slides.NET6.CrossPlatform på Linux och macOS. På Alpine Linux, på Linux‑system vars glibc är äldre än de versioner som listas ovan, och i projekt som riktar sig mot .NET Framework, använd Aspose.Slides.NET. Lägg endast till ett av de två paketen i ett projekt.

**Vilka typsnitt behövs för korrekt rendering?**

Typsnitten som används i presentationen, eller lämpliga ersättningar, måste finnas tillgängliga i operativsystemet. På Linux och macOS, installera de typsnittspaket som dina presentationer behöver för att få en konsekvent rendering. På Alpine Linux, installera minst ett typsnittspaket utöver `libgdiplus`, enligt beskrivningen i [Alpine Linux](#alpine-linux).

**Varför renderas ett anpassat typsnitt som en reserv eller saknad text på Linux?**

Om fontfilen har inkonsekventa eller korrumperade name‑table‑poster kan Linux‑font‑matchningsstacken (FreeType/fontconfig) välja en ogiltig post, vilket gör att typsnittet blir oidentifierat. Att använda en fontversion med korrigerade name‑table‑poster eller att installera ett konsekvent ersättnings‑typsnitt löser problemet.