---
title: Installation
type: docs
weight: 70
url: /sv/nodejs-net/installation/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- installation av Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installera Aspose.Slides för Node.js via .NET från npm på Windows eller Linux: förutsättningar, edge-js-överskrivning, en engångs-NuGet-återställning och ett första program som skapar en presentation."
---
## **Översikt**

Aspose.Slides för Node.js via .NET är npm‑paketet `aspose.slides.via.net`. Det kör Aspose.Slides .NET‑biblioteket inuti Node.js via [edge-js](https://github.com/agracio/edge-js)-bryggan, så en fungerande installation kräver både Node.js och .NET.

Denna artikel tar dig från en ren maskin till ett första program som skapar en presentation. Det finns fyra steg: skapa ett projekt med en edge‑js‑överskrivning, installera paketet från npm, återställa paketets .NET‑beroenden en gång, och köra ditt skript från projektmappen.

## **Förutsättningar**

- **Node.js 22 eller 24 LTS**, x64‑byggnad, från [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 eller senare**, från [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Endast .NET‑runtime är inte tillräckligt: återställningssteget nedan kräver SDK:n, och även bryggan när ditt skript körs. Kör `dotnet --list-sdks` för att kontrollera vilka SDK:er som är installerade.
- **Endast på Linux**:
  - byggverktygen `python3`, `make` och `g++`, eftersom npm kompilerar edge‑js under installation på Linux;
  - fontconfig‑biblioteket, som Aspose.Slides inhemska ritningsbibliotek laddar.

  På Debian är detta paketen `python3`, `make`, `g++` och `libfontconfig1`.

De steg som beskrivs i den här artikeln har testats på följande plattformar:

| Plattform | Resultat |
|---|---|
| Windows x64 med Node.js 22 eller 24 | Fungerar. Testat med Microsoft Visual C++ Redistributable installerad. |
| Linux x64 med Node.js 22 eller 24, där system‑OpenSSL kommer från samma utgivningslinje som OpenSSL som är inbyggd i Node.js, exempelvis Debian 13 | Fungerar. |
| Linux där de två OpenSSL‑versionerna skiljer sig, exempelvis Debian 12 | Node.js kraschar med ett segmenteringsfel när en presentation skapas. |
| macOS | Ej verifierad. |

På Linux, jämför de två versionerna innan du börjar. Det första kommandot skriver ut OpenSSL‑versionen som är inbyggd i Node.js; det andra skriver ut systemversionen. Använd ett system där båda börjar med samma huvud‑ och undernummer, till exempel `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Om kommandot `openssl` inte hittas, installera paketet `openssl` först.

## **Skapa ett projekt**

Skapa en mapp för ditt projekt, initiera den och lägg till en överskrivning som talar om för npm vilken edge‑js‑release som ska installeras:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Paketet begär en äldre edge‑js‑release vars förkompilerade Windows‑binärer slutar vid Node.js 20, så utan överskrivningen stoppar det första skriptet på Windows med "The edge module has not been pre-compiled for node.js version". Kommandot skriver överskrivningen till `overrides`‑sektionen i `package.json`; lägg till den innan du installerar paketet.

## **Installera paketet**

Installera Aspose.Slides för Node.js via .NET från npm:

```sh
npm install aspose.slides.via.net
```

Under installationen kopierar paketet sina inhemska ritningsbibliotek (filerna vars namn innehåller `aspose.slides.drawing.capi`) till projektmappen, bredvid `package.json`.

Paketet publiceras också som ett ZIP‑arkiv på [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/). Denna artikel behandlar endast installation från npm.

## **Återställ .NET‑beroenden**

Paketet innehåller Aspose.Slides .NET‑assemblyn, men inte de 20 NuGet‑paket som dessa assemblyn beror på. Vid körning letar .NET efter dem i NuGet‑paketcachen: `%USERPROFILE%\.nuget\packages` på Windows, `~/.nuget/packages` på Linux, eller mappen som anges i miljövariabeln `NUGET_PACKAGES`. Om de saknas stoppar det första skriptet med "assembly specified in the dependencies manifest was not found".

För att fylla cachen, skapa en mapp med namnet `deps` i projektmappen och spara följande fil i den som `deps.csproj`. Varje `PackageDownload`‑objekt laddar ner ett paket med exakt den version som står i hakparenteserna; inget byggs.

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

Återställ sedan den från projektmappen:

```sh
dotnet restore deps/deps.csproj
```

Du behöver detta steg en gång per maskin, inte en gång per projekt: paketen ligger kvar i NuGet‑cachen, och senare projekt på samma maskin använder dem. Efter återställningen kan du ta bort `deps`‑mappen.

## **Kör ett första program**

Skapa en fil med namn `hello.js` i projektmappen med följande kod. Den skapar en presentation, lägger till en rektangel med texten "Hello, World!" på den första bilden och sparar resultatet som `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// En ny presentation innehåller en tom bild.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Position och storlek är i punkter (1/72 tum): x, y, bredd, höjd.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Frigör .NET-objektet som ligger bakom presentationen.
    presentation.dispose();
}
```

Kör den från projektmappen:

```sh
node hello.js
```

Skriptet skriver ut `Saved hello.pptx`. Öppna `hello.pptx` för att se en bild med en fylld rektangel som innehåller texten. Utan licens lägger Aspose.Slides också till ett utvärderingsvattenmärke; se [Evaluate Aspose.Slides](/slides/sv/nodejs-net/evaluate-aspose-slides/) och [Licensing](/slides/sv/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Kör dina skript från projektmappen, den som innehåller `package.json`. Relativa sökvägar som `hello.pptx` löses mot den aktuella mappen, och på vissa maskiner kan ett skript som startas från en annan mapp inte skapa en presentation.
{{% /alert %}}

JavaScript‑API:n speglar Aspose.Slides för .NET: klasser behåller sina .NET‑namn, egenskaper och metoder använder camelCase (`Slides` blir `slides`, `AddAutoShape` blir `addAutoShape`), och samlingsobjekt läses med `get(index)`. Det finns ingen separat API‑referens för detta paket, så använd [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) för klass‑ och medlemsdetaljer, till exempel [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **FAQ**

**Vad betyder "The edge module has not been pre-compiled for node.js version"?**

npm installerade den äldre edge‑js‑release som paketet begär. Lägg till överskrivningen från [Create a Project](#create-a-project) och kör `npm install` igen.

**Vad betyder "assembly specified in the dependencies manifest was not found"?**

.NET‑beroenden finns inte i NuGet‑cachen. Samma körning rapporterar även "edge.initializeClrFunc is not a function". Följ [Restore the .NET Dependencies](#restore-the-net-dependencies) en gång, och kör sedan ditt skript igen.

**Vad betyder "The edge native module is not available" på Linux?**

edge‑js kompilerades inte under `npm install`, till exempel för att `python3`, `make` eller `g++` saknades. npm rapporterar inte detta som ett fel. Installera byggverktygen och kör sedan `npm rebuild edge-js` i projektmappen.

**Varför misslyckas skapandet av en presentation med ett tomt "Error"?**

På Linux, kontrollera att fontconfig‑biblioteket är installerat (`libfontconfig1` på Debian); utan det kan det inhemska ritningsbiblioteket inte laddas. På alla system, kontrollera även att du kör skriptet från projektmappen.

**Varför kraschar Node.js med ett segmenteringsfel på Linux?**

System‑OpenSSL och OpenSSL som är inbyggd i Node.js kommer från olika utgivningslinjer. Jämför dem enligt [Prerequisites](#prerequisites) och använd en distribution eller ett Node.js‑build där de matchar.

**Behöver jag upprepa NuGet‑återställningen för varje projekt?**

Nej. Återställningen fyller NuGet‑cachen för ditt användarkonto, och varje projekt på den maskinen använder samma cache.