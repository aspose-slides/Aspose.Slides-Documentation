---
title: Systeemvereisten
type: docs
weight: 60
url: /nl/net/system-requirements/
keywords:
- systeemvereisten
- ondersteunde platformen
- doelframeworks
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
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Controleer wat Aspose.Slides for .NET nodig heeft voordat u het installeert: de frameworkdoelen van elk NuGet-pakket, de ondersteunde besturingssystemen en processors, en de bibliotheken en lettertypen die Linux vereist."
---
## **Inleiding**

Aspose.Slides for .NET is een zelfstandige bibliotheek: hij heeft geen Microsoft PowerPoint of Microsoft Office nodig. Hij wordt gepubliceerd als twee NuGet‑pakketten, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) en [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Beide leveren dezelfde Aspose.Slides‑namespaces en -klassen; ze verschillen in de doel‑frameworks en in hoe ze dia's tekenen, wat bepaalt waar ze draaien en wat ze nodig hebben.

Dit artikel geeft een overzicht van de .NET‑versies en platformen die elk pakket ondersteunt, van de systeem‑libraries en lettertypen die Linux nodig heeft, en eindigt met een kort programma dat uw installatie controleert. Zie [Installation](/slides/nl/net/installation/) voor het toevoegen van een pakket aan een project.

## **Ondersteunde .NET‑versies**

Elk pakket bevat één build van Aspose.Slides per doel‑framework, en NuGet selecteert de build die overeenkomt met het doel‑framework van uw project.

| Pakket | Doel‑frameworks in het pakket | Uw project kan targeten |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 of later; .NET 6 of later, inclusief .NET 8, .NET 9 en .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 of later, inclusief .NET 8, .NET 9 en .NET 10 |

De `netstandard2.0`‑build maakt het mogelijk dat een .NET Standard 2.0 class library Aspose.Slides.NET referereert. Een applicatie die zo’n library gebruikt, draait de build die overeenkomt met het eigen doel‑framework van de applicatie: een .NET 8‑applicatie draait bijvoorbeeld de `net6.0`‑build.

## **Ondersteunde besturingssystemen en processors**

**Aspose.Slides.NET** bevat alleen processor‑onafhankelijke (AnyCPU) managed code, dus hij draait op de processorarchitectuur van de .NET‑runtime die hem laadt. Hij tekent dia's via Microsoft’s System.Drawing.Common‑bibliotheek, die Microsoft **alleen op Windows** ondersteunt. Op Linux heeft Aspose.Slides.NET daarom de `libgdiplus`‑bibliotheek en een opstart‑schakelaar nodig, beschreven onder [Linux](#linux). Hij draait op Linux‑distributies die `libgdiplus` leveren, zoals Debian, Ubuntu en Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** tekent dia's met zijn eigen grafische engine. De engine is een native bibliotheek die het pakket in één build per platform bevat, dus het pakket draait alleen op deze platformen:

| Besturingssysteem | Processors | Opmerkingen |
|---|---|---|
| Windows | x86, x64 | Windows op ARM64 wordt niet ondersteund. |
| Linux | x64, ARM64 | Vereist glibc 2.23 of later op x64 en glibc 2.39 of later op ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform draait niet op Alpine Linux of andere distributies gebaseerd op musl in plaats van glibc, noch op distributies met een oudere glibc, zoals CentOS 7. Gebruik in die gevallen Aspose.Slides.NET.

Op Windows gebruikt de native bibliotheek van Aspose.Slides.NET6.CrossPlatform de Microsoft Visual C++‑runtime (*MSVCP140.dll* en *VCRUNTIME140.dll*, plus *VCRUNTIME140_1.dll* op x64). Als deze bestanden ontbreken op de doelmachine, installeer dan de [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Beide pakketten hebben extra systeem‑libraries nodig op Linux. Zonder deze faalt het eerste voorbeeld in [Create Presentations](/slides/nl/net/create-presentation/) met een exceptie in plaats van het bestand op te slaan. De onderstaande commando’s gelden voor Debian en Ubuntu; op deze distributies brengt elke library ook de DejaVu‑lettertypen (`fonts-dejavu-core`) mee, zodat tekst wordt gerenderd zonder extra lettertype‑pakketten.

### **Aspose.Slides.NET6.CrossPlatform**

De Linux‑library van het pakket vereist de `fontconfig`‑library:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Zonder deze library mislukt het aanmaken van een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) met een `TypeInitializationException` waarvan de interne `DllNotFoundException` meldt dat `libfontconfig.so.1` niet geopend kan worden.

Minimale basis‑images bevatten `fontconfig` soms ook niet. De AWS Lambda‑basis‑image voor .NET 8 bijvoorbeeld bevat noch `fontconfig` noch enige lettertypen. Installeer in een container‑image die hierop is gebaseerd `dnf install -y fontconfig`, waarmee ook de Noto Sans‑lettertypen worden geïnstalleerd.

### **Aspose.Slides.NET**

Het pakket vereist twee dingen op Linux:

1. De `libgdiplus`‑library:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. De `System.Drawing.EnableUnixSupport`‑schakelaar, ingeschakeld aan het begin van uw applicatie vóór enige Aspose.Slides‑aanroep. In een *Program.cs* met top‑level statements plaatst u deze na de `using`‑directives:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Zonder `libgdiplus` faalt het opslaan van een presentatie met een `TypeInitializationException` waarvan de interne `DllNotFoundException` meldt dat `libgdiplus` niet geladen kan worden. Zonder de schakelaar is de interne exceptie `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
De schakelaar werkt alleen met System.Drawing.Common 6, de versie waarop Aspose.Slides.NET vertrouwt. Microsoft heeft deze verwijderd in System.Drawing.Common 7. Als uw project System.Drawing.Common 7 of hoger refereert, direct of via een ander pakket, faalt Aspose.Slides.NET op Linux met `PlatformNotSupportedException` zelfs als `libgdiplus` is geïnstalleerd en de schakelaar is ingeschakeld. Gebruik in dat geval Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Gebruik op Alpine Linux Aspose.Slides.NET met de hierboven beschreven schakelaar. Alpine‑images bevatten doorgaans geen lettertypen, en `libgdiplus` alleen installeert er ook geen, dus installeer `libgdiplus` samen met ten minste één lettertype‑pakket. Zonder lettertypen faalt het opslaan van een presentatie met deze fout:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Optie 1: DejaVu‑lettertypen**

De aanbevolen optie is het `ttf-dejavu`‑pakket:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Op huidige Alpine‑releases installeert `ttf-dejavu` het `font-dejavu`‑pakket, dat tevens `fontconfig` en de daarop afhankelijke font‑tools installeert.

**Optie 2: Microsoft‑kernlettertypen**

Als uw presentaties Microsoft‑lettertypen gebruiken zoals Arial, Times New Roman, Courier New of Verdana, installeer dan de Microsoft‑kernlettertypen. De stap `update-ms-fonts` downloadt de lettertypen tijdens de image‑build, dus de build heeft internettoegang nodig:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Globalisatie‑ondersteuning**

Beide pakketten hebben .NET‑globalisatie‑ondersteuning nodig, die .NET op Linux levert via de ICU‑libraries. In [globalization‑invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) leidt het aanmaken van een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) tot `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Sommige container‑images schakelen deze modus in. De .NET‑runtime‑images voor Alpine Linux (`runtime-deps`, `runtime` en `aspnet`) stellen bijvoorbeeld `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` in en bevatten geen ICU. Installeer in een image die hierop is gebaseerd ICU en schakel de modus uit:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Zorg er bovendien voor dat uw project‑bestand de eigenschap `InvariantGlobalization` niet op `true` zet.

## **Controleer uw installatie**

Om te controleren of een pakket en de vereisten aanwezig zijn, draait u een programma dat een presentatie opslaat en een dia rendert naar een afbeelding. Opslaan en renderen gebruiken respectievelijk de grafische library en de lettertypen, hetgeen de Linux‑vereisten hierboven leveren.

Maak een console‑applicatie en voeg het pakket toe zoals beschreven in [Installation](/slides/nl/net/installation/), vervang de inhoud van *Program.cs* door de code hieronder, en voer `dotnet run` uit. Als u Aspose.Slides.NET op Linux gebruikt, voeg dan de `System.Drawing.EnableUnixSupport`‑schakelaar toe zoals beschreven onder [Linux](#linux) na de `using`‑directives. Het programma maakt gebruik van top‑level statements en `using`‑declaraties, die C# 9 of later vereisen. Projecten die .NET 6 of hoger targeten, gebruiken standaard een nieuwere C#‑versie; in een project dat .NET Framework target, voeg `<LangVersion>latest</LangVersion>` toe aan een `PropertyGroup` in het project‑bestand.

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

Het programma voegt een rechthoek met tekst toe aan de eerste dia en slaat de presentatie op als *hello.pptx* met de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/)‑methode. Vervolgens rendert het de dia met [GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/getimage/) en slaat het resultaat op als *hello.png* met [IImage.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/save/) in het [ImageFormat.Png](https://reference.aspose.com/slides/nl/net/aspose.slides/imageformat/)-formaat. De schaalfactoren van 1 renderen één pixel per punt, dus de standaard 720 × 540‑punt dia wordt een 720 × 540‑pixel afbeelding, met de tekst zichtbaar binnen de rechthoek. Zonder licentie dragen beide bestanden een evaluatiewatermerk; zie [Licensing](/slides/nl/net/licensing/). Als een vereiste ontbreekt, stopt het programma met een van de in [Linux](#linux) beschreven excepties.

## **Ontwikkel­tools**

U kunt applicaties die Aspose.Slides gebruiken bouwen met elk hulpmiddel dat uw project‑doelframework ondersteunt: de .NET‑SDK en de `dotnet`‑command‑line interface op Windows, Linux en macOS, of Visual Studio op Windows. [Installation](/slides/nl/net/installation/) beschrijft beide.

## **FAQ**

**Heb ik Microsoft PowerPoint nodig voor conversies en rendering?**

Nee, PowerPoint is niet vereist. Aspose.Slides is een zelfstandige engine voor [het maken](/slides/nl/net/create-presentation/), aanpassen, [converteren](/slides/nl/net/convert-presentation/) en [renderen](/slides/nl/net/convert-powerpoint-to-png/) van presentaties.

**Welk pakket moet ik gebruiken?**

Gebruik Aspose.Slides.NET op Windows en Aspose.Slides.NET6.CrossPlatform op Linux en macOS. Op Alpine Linux, op Linux‑systemen waarvan de glibc ouder is dan de hierboven genoemde versies, en in projecten die .NET Framework targeten, gebruikt u Aspose.Slides.NET. Voeg slechts één van de twee pakketten toe aan een project.

**Welke lettertypen zijn nodig voor correcte rendering?**

De lettertypen die in de presentatie worden gebruikt, of geschikte vervangers, moeten beschikbaar zijn in het besturingssysteem. Installeer op Linux en macOS de lettertype‑pakketten die uw presentaties nodig hebben voor consistente weergave. Op Alpine Linux installeert u ten minste één lettertype‑pakket naast `libgdiplus`, zoals beschreven onder [Alpine Linux](#alpine-linux).

**Waarom wordt een aangepast lettertype op Linux als fallback of ontbrekende tekst weergegeven?**

Als het lettertype‑bestand inconsistente of beschadigde name‑table‑records bevat, kan de Linux‑font‑matching‑stack (FreeType/fontconfig) een ongeldige invoer selecteren, waardoor het lettertype niet wordt herkend. Het gebruik van een versie met gecorrigeerde name‑table‑records of het installeren van een consistente vervanging lost het probleem op.