---
title: Installatie
type: docs
weight: 70
url: /nl/nodejs-net/installation/
keywords:
- downloaden Aspose.Slides
- installeren Aspose.Slides
- Aspose.Slides installatie
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installeer Aspose.Slides for Node.js via .NET vanuit npm op Windows of Linux: vereisten, de edge-js-override, een eenmalige NuGet-herstel, en een eerste programma dat een presentatie maakt."
---
## **Overzicht**

Aspose.Slides for Node.js via .NET is het npm‑pakket `aspose.slides.via.net`. Het draait de Aspose.Slides .NET‑bibliotheek binnen Node.js via de [edge-js](https://github.com/agracio/edge-js)‑brug, dus een werkende installatie vereist zowel Node.js als .NET.

Dit artikel leidt je van een schone machine naar een eerste programma dat een presentatie maakt. Er zijn vier stappen: een project aanmaken met een edge-js‑override, het pakket van npm installeren, de .NET‑afhankelijkheden van het pakket één keer herstellen, en je script uitvoeren vanuit de projectmap.

## **Voorvereisten**

- **Node.js 22 of 24 LTS**, x64‑build, van [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 of later**, van [dotnet.microsoft.com](https://dotnet.microsoft.com/download). De .NET‑runtime alleen is niet voldoende: de herstelstap hieronder heeft de SDK nodig, en dat geldt ook voor de brug wanneer je script wordt uitgevoerd. Voer `dotnet --list-sdks` uit om te controleren welke SDK’s geïnstalleerd zijn.
- **Alleen op Linux**:
  - de bouw‑tools `python3`, `make` en `g++`, omdat npm edge-js compileert tijdens de installatie op Linux;
  - de fontconfig‑bibliotheek, die de native tekenbibliotheek van Aspose.Slides laadt.

Op Debian zijn dit de pakketten `python3`, `make`, `g++` en `libfontconfig1`.

De stappen in dit artikel zijn getest op de volgende platforms:

| Platform | Resultaat |
|---|---|
| Windows x64 met Node.js 22 of 24 | Werkt. Getest met de geïnstalleerde Microsoft Visual C++ Redistributable. |
| Linux x64 met Node.js 22 of 24, waarbij het systeem‑OpenSSL afkomstig is uit dezelfde release‑lijn als het OpenSSL ingebouwd in Node.js, zoals Debian 13 | Werkt. |
| Linux waarbij de twee OpenSSL‑versies verschillen, zoals Debian 12 | Node.js crasht met een segmentatiefout wanneer een presentatie wordt aangemaakt. |
| macOS | Niet geverifieerd. |

Op Linux, vergelijk de twee versies voordat je begint. Het eerste commando toont de OpenSSL‑versie die in Node.js is ingebouwd; het tweede toont de systeemversie. Gebruik een systeem waarbij beide beginnen met hetzelfde hoofd‑ en ondernummer, bijvoorbeeld `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Als het commando `openssl` niet wordt gevonden, installeer dan eerst het `openssl`‑pakket.

## **Project aanmaken**

Maak een map voor je project, initialiseert deze, en voeg een override toe die npm vertelt welke edge‑js‑release geïnstalleerd moet worden:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Het pakket vraagt om een oudere edge‑js‑release waarvan de vooraf gebouwde Windows‑binaries stoppen bij Node.js 20, dus zonder de override stopt het eerste script op Windows met "The edge module has not been pre-compiled for node.js version". Het commando schrijft de override naar de `overrides`‑sectie van `package.json`; voeg deze toe vóór je het pakket installeert.

## **Pakket installeren**

Installeer Aspose.Slides for Node.js via .NET vanuit npm:

```sh
npm install aspose.slides.via.net
```

Tijdens de installatie kopieert het pakket zijn native tekenbibliotheken (de bestanden waarvan de namen `aspose.slides.drawing.capi` bevatten) naar de projectmap, naast `package.json`.

Het pakket wordt ook gepubliceerd als een ZIP‑archief op [releases.aspose.com](https://releases.aspose.com/slides/nl/nodejs-net/). Dit artikel behandelt alleen installatie via npm.

## **De .NET‑afhankelijkheden herstellen**

Het pakket bevat de Aspose.Slides .NET‑assemblies, maar niet de 20 NuGet‑pakketten waar die assemblies van afhankelijk zijn. Tijdens uitvoering zoekt .NET ze in de NuGet‑pakketcache: `%USERPROFILE%\.nuget\packages` op Windows, `~/.nuget/packages` op Linux, of de map die is ingesteld in de `NUGET_PACKAGES`‑omgevingsvariabele. Als ze ontbreken, stopt het eerste script met "assembly specified in the dependencies manifest was not found".

Om de cache te vullen, maak een map genaamd `deps` in de projectmap en sla het volgende bestand daarin op als `deps.csproj`. Elk `PackageDownload`‑item downloadt één pakket op de exacte versie tussen haakjes; er wordt niets gebouwd.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Herstel het daarna vanuit de projectmap:

```sh
dotnet restore deps/deps.csproj
```

Deze stap moet je één keer per machine uitvoeren, niet één keer per project: de pakketten blijven in de NuGet‑cache en latere projecten op dezelfde machine gebruiken ze. Na het herstel kun je de map `deps` verwijderen.

## **Eerste programma uitvoeren**

Maak een bestand genaamd `hello.js` aan in de projectmap met de volgende code. Het maakt een presentatie, voegt een rechthoek met de tekst "Hello, World!" toe aan de eerste slide, en slaat het resultaat op als `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Een nieuwe presentatie bevat één lege dia.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Positie en grootte zijn in points (1/72 inch): x, y, breedte, hoogte.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Vrijgeven van het .NET-object dat de presentatie ondersteunt.
    presentation.dispose();
}
```

Voer het uit vanuit de projectmap:

```sh
node hello.js
```

Het script geeft `Saved hello.pptx` weer. Open `hello.pptx` om één slide te zien met een gevulde rechthoek die de tekst bevat. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe; zie [Evaluate Aspose.Slides](/slides/nl/nodejs-net/evaluate-aspose-slides/) en [Licensing](/slides/nl/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Voer je scripts uit vanuit de projectmap, degene die `package.json` bevat. Relatieve paden zoals `hello.pptx` worden ten opzichte van de huidige map opgelost, en op sommige machines kan een script dat vanuit een andere map wordt gestart geen presentatie maken.
{{% /alert %}}

De JavaScript‑API spiegelt Aspose.Slides voor .NET: klassen behouden hun .NET‑namen, eigenschappen en methoden gebruiken camelCase (`Slides` wordt `slides`, `AddAutoShape` wordt `addAutoShape`), en collectie‑items worden gelezen met `get(index)`. Er is geen aparte API‑referentie voor dit pakket, dus gebruik de [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/nl/net/) voor klasse‑ en lid‑details, bijvoorbeeld [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) en [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/shapecollection/addautoshape/).

## **Veelgestelde vragen**

**Wat betekent "The edge module has not been pre-compiled for node.js version"?**

npm heeft de oudere edge‑js‑release geïnstalleerd die het pakket vraagt. Voeg de override toe vanuit [Create a Project](#create-a-project) en voer `npm install` opnieuw uit.

**Wat betekent "assembly specified in the dependencies manifest was not found"?**

De .NET‑afhankelijkheden bevinden zich niet in de NuGet‑cache. Dezelfde uitvoering meldt ook "edge.initializeClrFunc is not a function". Volg [Restore the .NET Dependencies](#restore-the-net-dependencies) één keer, en voer daarna je script opnieuw uit.

**Wat betekent "The edge native module is not available" op Linux?**

edge‑js is niet gecompileerd tijdens `npm install`, bijvoorbeeld omdat `python3`, `make` of `g++` ontbreekt. npm meldt dit niet als een fout. Installeer de bouw‑tools en voer daarna `npm rebuild edge-js` uit in de projectmap.

**Waarom mislukt het aanmaken van een presentatie met een lege "Error"?**

Controleer op Linux of de fontconfig‑bibliotheek geïnstalleerd is (`libfontconfig1` op Debian); zonder deze kan de native tekenbibliotheek niet worden geladen. Controleer op elk systeem ook dat je het script vanuit de projectmap uitvoert.

**Waarom crasht Node.js met een segmentatiefout op Linux?**

Het systeem‑OpenSSL en het OpenSSL dat in Node.js is ingebouwd komen uit verschillende release‑lijnen. Vergelijk ze zoals weergegeven in [Prerequisites](#prerequisites) en gebruik een distributie of Node.js‑build waarin ze overeenkomen.

**Moet ik de NuGet‑herstel voor elk project herhalen?**

Nee. Het herstel vult de NuGet‑cache voor je gebruikersaccount, en elk project op die machine gebruikt dezelfde cache.