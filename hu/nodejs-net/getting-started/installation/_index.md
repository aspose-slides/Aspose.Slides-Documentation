---
title: Telepítés
type: docs
weight: 70
url: /hu/nodejs-net/installation/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides telepítés
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Telepítse az Aspose.Slides for Node.js via .NET csomagot npm‑ről Windowsra vagy Linuxra: előkövetelmények, az edge-js felülbírálás, egy egyszeri NuGet helyreállítás, valamint egy első program, amely prezentációt hoz létre."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via .NET a `aspose.slides.via.net` npm csomag. A Aspose.Slides .NET könyvtárat futtatja Node.js-ben a [edge-js](https://github.com/agracio/edge-js) hídon keresztül, így egy működő telepítéshez mind a Node.js, mind a .NET szükséges.

Ez a cikk egy tiszta gépről elvisz egy első programhoz, amely prezentációt hoz létre. Négy lépés van: egy projekt létrehozása edge-js felülbírálással, a csomag telepítése npm‑ből, a csomag .NET függőségeinek egyszeri helyreállítása, és a script futtatása a projektmappából.

## **Előkövetelmények**

- **Node.js 22 vagy 24 LTS**, x64 build, a [nodejs.org](https://nodejs.org/en/download) oldalról.
- **.NET SDK 8 vagy újabb**, a [dotnet.microsoft.com](https://dotnet.microsoft.com/download) oldalról. A .NET futtatókörnyezet önmagában nem elegendő: az alábbi helyreállítási lépéshez a SDK‑ra van szükség, és a hídnak is a script futtatásakor. A telepített SDK‑k listájához futtassa a `dotnet --list-sdks` parancsot.
- **Csak Linuxon**:
  - a build‑eszközök `python3`, `make` és `g++`, mert az npm a telepítés során lefordítja az edge‑js‑t Linuxon;
  - a fontconfig könyvtár, amelyet az Aspose.Slides natív rajzkönyvtára betölt.

  Debianon ezek a csomagok: `python3`, `make`, `g++` és `libfontconfig1`.

Az ebben a cikkben leírt lépéseket az alábbi platformokon teszteltük:

| Platform | Eredmény |
|---|---|
| Windows x64 Node.js 22 vagy 24 | Működik. A Microsoft Visual C++ Redistributable telepítve van. |
| Linux x64 Node.js 22 vagy 24, ahol a rendszer OpenSSL ugyanabból a kiadássorozatból származik, mint a Node.js‑be beépített OpenSSL, például Debian 13 | Működik. |
| Linux, ahol a két OpenSSL verzió eltér, például Debian 12 | Node.js összeomlik szegmenshibával, amikor prezentációt hoznak létre. |
| macOS | Nem ellenőrizve. |

Linuxon hasonlítsa össze a két verziót a kezdés előtt. Az első parancs kiírja a Node.js‑be beépített OpenSSL verziót; a második a rendszer verzióját. Olyan rendszert használjon, ahol mindkettő ugyanazzal a fő‑ és alverzióval indul, például `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Ha a `openssl` parancs nem található, először telepítse az `openssl` csomagot.

## **Projekt létrehozása**

Hozzon létre egy mappát a projekthez, inicializálja, és adjon meg egy felülbírálást, amely megmondja az npm‑nek, melyik edge‑js kiadást telepítse:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

A csomag egy régebbi edge‑js kiadást kér, amelynek előre lefordított Windows‑binárisai csak a Node.js 20‑ig tartanak, így felülbírálás nélkül az első Windows‑script a „The edge module has not been pre-compiled for node.js version” hibaüzenettel leáll. A parancs a felülbírálást a `package.json` `overrides` szekciójába írja; adja hozzá a csomag telepítése előtt.

## **A csomag telepítése**

Telepítse az Aspose.Slides for Node.js via .NET csomagot npm‑ből:

```sh
npm install aspose.slides.via.net
```

A telepítés során a csomag a natív rajzkönyvtárakat (azok a fájlok, amelyek nevében `aspose.slides.drawing.capi` szerepel) a projekt mappájába másolja, a `package.json` mellé.

A csomag ZIP‑archívumként is elérhető a [releases.aspose.com](https://releases.aspose.com/slides/hu/nodejs-net/) oldalon. Ez a cikk csak az npm‑es telepítést tárgyalja.

## **A .NET függőségek helyreállítása**

A csomag tartalmazza az Aspose.Slides .NET assembly‑ket, de nem a 20 NuGet csomagot, amelyektől ezek függnek. Futtás közben a .NET ezeket a NuGet csomaggyűjtőben keresi: `%USERPROFILE%\.nuget\packages` Windowson, `~/.nuget/packages` Linuxon, vagy a `NUGET_PACKAGES` környezeti változóban megadott mappában. Ha hiányoznak, az első script a „assembly specified in the dependencies manifest was not found” hibaüzenettel leáll.

A gyorsítótár feltöltéséhez hozzon létre egy `deps` nevű mappát a projektben, és mentse el a következő fájlt `deps.csproj` néven. Minden `PackageDownload` elem letölti a zárójelben megadott pontos verziójú csomagot; semmi sem épül fel.

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

Ezután helyreállíthatja a projektmappából:

```sh
dotnet restore deps/deps.csproj
```

Ezt a lépést gépenként egyszer kell elvégezni, nem projektenként: a csomagok a NuGet gyorsítótárban maradnak, és későbbi projektek ugyanazon a gépen használják őket. A helyreállítás után törölheti a `deps` mappát.

## **Első program futtatása**

Hozzon létre egy `hello.js` nevű fájlt a projektmappában a következő kóddal. A kód prezentációt hoz létre, egy „Hello, World!” feliratú téglalapot ad az első diahoz, és `hello.pptx`‑ként menti az eredményt:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Egy új prezentáció egy üres diát tartalmaz.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // A pozíció és méret pontban van megadva (1/72 hüvelyk): x, y, szélesség, magasság.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Felszabadítjuk a prezentációt alátámasztó .NET objektumot.
    presentation.dispose();
}
```

Futtassa a projektmappából:

```sh
node hello.js
```

A script kiírja a `Saved hello.pptx` üzenetet. Nyissa meg a `hello.pptx`‑t, hogy egy diát lásson egy kitöltött téglalappal, amely a szöveget tartalmazza. Licenc nélkül az Aspose.Slides értékelő vízjelet is hozzáad; lásd a [Evaluate Aspose.Slides](/slides/hu/nodejs-net/evaluate-aspose-slides/) és a [Licensing](/slides/hu/nodejs-net/licensing/) oldalakat.

{{% alert color="info" title="Note" %}}
Futtassa a scriptjeit a projektmappából, azaz abból, amelyik a `package.json`‑t tartalmazza. A relatív útvonalak, például a `hello.pptx`, az aktuális mappához viszonyítva vannak feloldva, és néhány gépen egy másik mappából indított script nem képes prezentációt létrehozni.
{{% /alert %}}

A JavaScript API tükrözi az Aspose.Slides for .NET API‑t: az osztályok megtartják .NET nevüket, a tulajdonságok és metódusok camelCase formátumúak (`Slides` → `slides`, `AddAutoShape` → `addAutoShape`), a gyűjteményelemeket `get(index)`‑szel lehet beolvasni. Nincs külön API‑referencia ehhez a csomaghoz, ezért használja az [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/hu/net/) oldalt az osztály‑ és tag‑részletekhez, például a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) és a [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/shapecollection/addautoshape/) oldalt.

## **GYIK**

**Mi jelentése a „The edge module has not been pre-compiled for node.js version” üzenetnek?**

Az npm a csomag által kért régebbi edge‑js kiadást telepítette. Adja hozzá a felülbírálást a [Projekt létrehozása](#create-a-project) szakaszból, majd futtassa újra az `npm install` parancsot.

**Mi jelentése a „assembly specified in the dependencies manifest was not found” üzenetnek?**

A .NET függőségek nincsenek a NuGet gyorsítótárban. Ugyanebben a futtatásban megjelenik a „edge.initializeClrFunc is not a function” is. Kövesse a [A .NET függőségek helyreállítása](#restore-the-net-dependencies) útmutatót egyszer, majd futtassa újra a scriptet.

**Mi jelentése a „The edge native module is not available” üzenetnek Linuxon?**

Az `npm install` során az edge‑js nem lett lefordítva, például a `python3`, `make` vagy `g++` hiánya miatt. Az npm ezt nem jelzi hibaként. Telepítse a build‑eszközöket, majd futtassa az `npm rebuild edge-js` parancsot a projektmappában.

**Miért sikertelen a prezentáció létrehozása egy üres „Error” üzenettel?**

Linuxon ellenőrizze, hogy a fontconfig könyvtár telepítve van‑e (`libfontconfig1` Debianon); enélkül a natív rajzkönyvtár nem tud betöltődni. Bármely rendszeren ellenőrizze, hogy a scriptet a projektmappából indítja‑e.

**Miért omlik össze a Node.js szegmenshibával Linuxon?**

A rendszer OpenSSL és a Node.js‑be beépített OpenSSL különböző kiadássorozatból származik. Hasonlítsa össze őket a [Előkövetelmények](#prerequisites) szakaszban leírt módon, és használjon olyan disztribúciót vagy Node.js buildet, ahol egyeznek.

**Újra kell-e futtatni a NuGet helyreállítást minden projektnél?**

Nem. A helyreállítás a felhasználói fiók NuGet gyorsítótárát tölti fel, és a gépen lévő minden projekt ugyanazt a gyorsítótárat használja.