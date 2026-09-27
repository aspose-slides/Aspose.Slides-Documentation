---
title: Instalace
type: docs
weight: 70
url: /cs/nodejs-net/installation/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- instalace Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Nainstalujte Aspose.Slides pro Node.js přes .NET z npm na Windows nebo Linux: předpoklady, přepsání edge-js, jednorázová obnova NuGet a první program, který vytvoří prezentaci."
---
## **Přehled**

Aspose.Slides pro Node.js přes .NET je npm balíček `aspose.slides.via.net`. Spouští knihovnu Aspose.Slides .NET uvnitř Node.js pomocí mostu [edge-js](https://github.com/agracio/edge-js), takže funkční instalace vyžaduje jak Node.js, tak .NET.

Tento článek vás provede od čistého počítače až po první program, který vytvoří prezentaci. Existují čtyři kroky: vytvořit projekt s přepsáním edge-js, nainstalovat balíček z npm, jednorázově obnovit .NET závislosti balíčku a spustit skript z adresáře projektu.

## **Požadavky**

- **Node.js 22 nebo 24 LTS**, 64‑bitová verze, z [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 nebo novější**, z [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Pouze runtime .NET není dostatečný: krok obnovení níže potřebuje SDK a most ho také potřebuje při spuštění skriptu. Pro ověření nainstalovaných SDK spusťte `dotnet --list-sdks`.
- **Pouze na Linuxu**:
  - nástroje pro kompilaci `python3`, `make` a `g++`, protože npm během instalace na Linuxu kompiluje edge-js;
  - knihovnu fontconfig, kterou načítá nativní kreslicí knihovna Aspose.Slides.

  Na Debianu jsou to balíčky `python3`, `make`, `g++` a `libfontconfig1`.

Testované platformy:

| Platforma | Výsledek |
|---|---|
| Windows x64 s Node.js 22 nebo 24 | Funguje. Testováno s nainstalovaným Microsoft Visual C++ Redistributable. |
| Linux x64 s Node.js 22 nebo 24, kde systémové OpenSSL je ze stejné řady jako OpenSSL zabudované v Node.js, například Debian 13 | Funguje. |
| Linux, kde se verze OpenSSL liší, například Debian 12 | Node.js se při vytváření prezentace zhroutí s chybou segmentační poruchy. |
| macOS | Neověřeno. |

Na Linuxu porovnejte obě verze před zahájením. První příkaz vypíše verzi OpenSSL zabudovanou v Node.js; druhý verzi systému. Použijte systém, kde obě začínají stejnými hlavními a podřízenými čísly, například `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Pokud příkaz `openssl` není nalezen, nejprve nainstalujte balíček `openssl`.

## **Vytvoření projektu**

Vytvořte složku pro svůj projekt, inicializujte ji a přidejte přepis, který npm řekne, kterou verzi edge-js má nainstalovat:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Balíček žádá o starší verzi edge-js, jejíž předkompilované binárky pro Windows končí u Node.js 20, takže bez přepisu první skript na Windows selže s hláškou „The edge module has not been pre-compiled for node.js version“. Příkaz zapíše přepis do sekce `overrides` v souboru `package.json`; přidejte jej před instalací balíčku.

## **Instalace balíčku**

Nainstalujte Aspose.Slides pro Node.js přes .NET z npm:

```sh
npm install aspose.slides.via.net
```

Během instalace balíček kopíruje své nativní kreslicí knihovny (soubory, jejichž název obsahuje `aspose.slides.drawing.capi`) do složky projektu vedle `package.json`.

Balíček je také zveřejněn jako ZIP archiv na [releases.aspose.com](https://releases.aspose.com/slides/cs/nodejs-net/). Tento článek pokrývá instalaci pouze z npm.

## **Obnova .NET závislostí**

Balíček obsahuje .NET sestavení Aspose.Slides, ale ne 20 NuGet balíčků, na kterých tato sestavení závisí. V runtime .NET je hledá v cache NuGet balíčků: `%USERPROFILE%\.nuget\packages` na Windows, `~/.nuget/packages` na Linuxu nebo ve složce nastavené proměnnou prostředí `NUGET_PACKAGES`. Pokud chybí, první skript selže s hláškou „assembly specified in the dependencies manifest was not found“.

Pro naplnění cache vytvořte ve složce projektu podsložku `deps` a uložte do ní následující soubor jako `deps.csproj`. Každá položka `PackageDownload` stáhne jeden balíček ve verzi uvedené v hranatých závorkách; nic se nekompiluje.

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

Poté ji obnovte ze složky projektu:

```sh
dotnet restore deps/deps.csproj
```

Tento krok je potřeba provést jen jednou na počítači, ne pro každý projekt: balíčky zůstávají v cache NuGet a další projekty na stejném počítači je používají. Po obnovení můžete složku `deps` smazat.

## **Spuštění prvního programu**

Vytvořte v adresáři projektu soubor `hello.js` s následujícím kódem. Vytvoří prezentaci, přidá obdélník s textem „Hello, World!“ na první snímek a uloží výsledek jako `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Nová prezentace obsahuje jeden prázdný snímek.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozice a velikost jsou v bodech (1/72 palce): x, y, šířka, výška.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Uvolněte .NET objekt, který podporuje prezentaci.
    presentation.dispose();
}
```

Spusťte jej z adresáře projektu:

```sh
node hello.js
```

Skript vypíše `Saved hello.pptx`. Otevřete `hello.pptx` a uvidíte jeden snímek s vyplněným obdélníkem, který obsahuje text. Bez licence Aspose.Slides také přidá vodotisk s hodnocením; viz [Evaluate Aspose.Slides](/slides/cs/nodejs-net/evaluate-aspose-slides/) a [Licensing](/slides/cs/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Spouštějte své skripty z adresáře projektu, tedy toho, který obsahuje `package.json`. Relativní cesty jako `hello.pptx` jsou vyhodnoceny vůči aktuální složce a na některých počítačích skript spuštěný z jiné složky nemůže vytvořit prezentaci.
{{% /alert %}}

JavaScriptové API odráží Aspose.Slides pro .NET: třídy si ponechávají své .NET názvy, vlastnosti a metody používají camelCase (`Slides` se mění na `slides`, `AddAutoShape` na `addAutoShape`) a položky kolekcí se čtou pomocí `get(index)`. Pro tento balíček neexistuje samostatná reference API, takže použijte [Aspose.Slides pro .NET API reference](https://reference.aspose.com/slides/cs/net/) pro podrobnosti o třídách a členech, například [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/shapecollection/addautoshape/).

## **Často kladené otázky**

**Co znamená „The edge module has not been pre-compiled for node.js version“?**

npm nainstaloval starší verzi edge-js, o kterou balíček žádá. Přidejte přepis z [Create a Project](#create-a-project) a znovu spusťte `npm install`.

**Co znamená „assembly specified in the dependencies manifest was not found“?**

.NET závislosti nejsou v cache NuGet. Stejný běh také hlásí „edge.initializeClrFunc is not a function“. Postupujte podle [Restore the .NET Dependencies](#restore-the-net-dependencies) jednorázově a poté skript znovu spusťte.

**Co znamená „The edge native module is not available“ na Linuxu?**

edge-js nebyl během `npm install` zkompilován, například protože chyběl `python3`, `make` nebo `g++`. npm to nehlásí jako chybu. Nainstalujte nástroje pro kompilaci a poté v adresáři projektu spusťte `npm rebuild edge-js`.

**Proč selhává vytvoření prezentace s prázdnou „Error“?**

Na Linuxu zkontrolujte, že je nainstalována knihovna fontconfig (`libfontconfig1` na Debianu); bez ní se nativní kreslicí knihovna nemůže načíst. Na jakémkoli systému také ověřte, že skript spouštíte z adresáře projektu.

**Proč Node.js padá s segmentační poruchou na Linuxu?**

Systémové OpenSSL a OpenSSL zabudované v Node.js jsou z různých řad vydání. Porovnejte je, jak je uvedeno v [Prerequisites](#prerequisites), a použijte distribuci nebo sestavení Node.js, kde se shodují.

**Musím opakovat obnovení NuGet pro každý projekt?**

Ne. Obnovení naplní cache NuGet pro váš uživatelský účet a každý projekt na tomto počítači používá stejnou cache.