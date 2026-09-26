---
title: Installatie
type: docs
weight: 70
url: /nl/net/installation/
keywords:
- Installeer Aspose.Slides
- Download Aspose.Slides
- Gebruik Aspose.Slides
- Aspose.Slides installatie
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Installeer Aspose.Slides voor .NET via NuGet op Windows, Linux en macOS: kies tussen de twee pakketten, voeg er één toe met de .NET CLI of Visual Studio, en installeer de Linux-vereisten."
---
## **Overzicht**

Dit artikel legt uit hoe je Aspose.Slides voor .NET toevoegt aan een project op Windows, Linux en macOS. Aspose.Slides wordt gedistribueerd via NuGet. Je kunt het toevoegen met de .NET CLI op elk besturingssysteem, of met de NuGet Package Manager of de Package Manager Console in Visual Studio op Windows. Het artikel legt ook uit welke van de twee NuGet‑pakketten je moet kiezen en wat Linux er extra bij nodig heeft.

Voor je begint, bekijk de ondersteunde besturingssystemen, .NET‑implementaties en extra afhankelijkheden in [Systeemeisen](/slides/nl/net/system-requirements/) .

## **Kies een pakket**

Aspose.Slides voor .NET wordt gepubliceerd als twee NuGet‑pakketten. Beide leveren dezelfde Aspose.Slides‑namespaces en -klassen, zodat je code niet verandert wanneer je van pakket wisselt; alleen de pakketreferentie en de platformvereisten verschillen.

| Pakket | Gebruik voor | Extra vereisten |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows‑ en .NET Framework‑applicaties | Op Linux en macOS: de `libgdiplus`‑bibliotheek, en de `System.Drawing.EnableUnixSupport`‑schakelaar ingeschakeld bij het opstarten van de applicatie |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 of hoger op Windows, Linux en macOS | Op Linux: de `fontconfig`‑bibliotheek, als deze nog niet geïnstalleerd is |

Als je het niet zeker weet, gebruik dan Aspose.Slides.NET op Windows en Aspose.Slides.NET6.CrossPlatform op Linux en macOS. Op Alpine Linux en op Linux‑systemen waarvan de glibc ouder is dan 2.23 (x64) of 2.39 (ARM64), gebruik je Aspose.Slides.NET. [Systeemeisen](/slides/nl/net/system-requirements/) geeft de ondersteunde platforms per pakket weer.

## **Installeren met de .NET CLI**

Deze stappen werken op Windows, Linux en macOS met .NET SDK 6 of hoger. Maak een console‑applicatie:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Voeg daarna het pakket toe voor jouw platform. Voeg slechts één van de twee pakketten toe aan een project.

- Op Windows: `dotnet add package Aspose.Slides.NET`
- Op Linux en macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (op Linux eerst de vereiste installeren; zie [Linux](#linux))

Om te controleren of het pakket werkt, vervang je de inhoud van *Program.cs* door het eerste voorbeeld in [Presentaties maken](/slides/nl/net/create-presentation/) en voer je `dotnet run` uit. Het slaat *hello.pptx* op in de projectmap.

## **Windows**

### **Methode 1: Aspose.Slides installeren of bijwerken via NuGet Package Manager**

1. Open Microsoft Visual Studio.  
2. Maak een console‑applicatie of open een bestaand project.  
3. Klik in **Solution Explorer** met de rechtermuisknop op het project en kies **Manage NuGet Packages** (of ga naar **Project** > **Manage NuGet Packages**).  
4. Selecteer **Browse** en zoek naar *Aspose.Slides*.  
{{% image img="installation_1.png" alt="Aspose.Slides‑installatie via NuGet Package Manager – 1" %}}
5. Klik op **Aspose.Slides.NET** en daarna op **Install**.  
   * Als je Aspose.Slides al geïnstalleerd hebt en wilt bijwerken, klik je in plaats daarvan op **Update**.

Het pakket wordt gedownload en in je project opgenomen.

### **Methode 2: Aspose.Slides installeren of bijwerken via de Package Manager Console**

Zo verwijs je naar het [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)‑pakket via de Package Manager Console:

1. Open Microsoft Visual Studio.  
2. Maak een console‑applicatie of open een bestaand project.  
3. Ga naar **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
![Opening the Package Manager Console](installation_2.png)
4. Voer dit commando uit: `Install-Package Aspose.Slides.NET`  
![Running the Install-Package command](installation_3.png)
De nieuwste release wordt in je project geïnstalleerd.

Het bericht **Installing Aspose.Slides.NET** verschijnt onderaan het venster.  
![Installation progress in the Package Manager Console](installation_4.png)

Wanneer de download voltooid is, verschijnen bevestigingsberichten. Het pakket wordt gedistribueerd onder de [Aspose‑licentie]((https://about.aspose.com/legal/eula)).  
![Installation confirmation messages](installation_5.png)

Aspose.Slides staat nu in je project en wordt verwezen.  
![Aspose.Slides referenced in the project](installation_6.png)

Om het pakket bij te werken, voer je `Update-Package Aspose.Slides.NET` uit in de Package Manager Console.

## **Linux**

Gebruik de .NET CLI‑stappen hierboven. Kies het pakket en installeer de vereiste via de pakketbeheerder van je distributie. Op Debian en Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: installeer `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: installeer `libgdiplus` en activeer Unix‑ondersteuning voor System.Drawing voordat je applicatie Aspose.Slides gebruikt.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  Voeg deze instructie toe aan het begin van je applicatie, vóór elke Aspose.Slides‑aanroep. In een *Program.cs* met top‑level statements zet je hem na de `using`‑directives:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Gebruik dit pakket op Alpine Linux en op systemen waarvan de glibc te oud is voor Aspose.Slides.NET6.CrossPlatform.

De lettertypen die in je presentaties worden gebruikt, of geschikte vervangers, moeten op het systeem geïnstalleerd zijn zodat tekst correct wordt weergegeven. [Systeemeisen](/slides/nl/net/system-requirements/) beschrijft de pakketten die Aspose.Slides.NET nodig heeft op Alpine Linux, inclusief lettertypen.

## **macOS**

Gebruik de .NET CLI‑stappen hierboven met het **Aspose.Slides.NET6.CrossPlatform**‑pakket, dat zowel Intel (x86_64) als Apple‑silicon (ARM64) Macs ondersteunt:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Is er een gratis versie of een proefbeperking?**

Ja. Zonder licentie draait Aspose.Slides in evaluatiemodus: er wordt een evaluatiewatermerk aan elke dia toegevoegd en tekst die uit presentaties wordt gelezen wordt afgekapt. Om deze beperkingen te verwijderen, pas je een geldige [licentie](/slides/nl/net/licensing/) toe.