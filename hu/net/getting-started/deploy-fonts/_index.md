---
title: Betűtípusok telepítése az Aspose.Slides-hez Linuxon és Dockerben
linktitle: Betűtípusok telepítése
type: docs
weight: 145
url: /hu/net/deploy-fonts/
keywords:
- betűtípusok telepítése
- betűtípusok telepítése
- betűtípusok Dockerben
- betűtípusok Linuxon
- hiányzó betűtípusok
- betűtípus helyettesítés
- Microsoft alapbetűtípusok
- ttf-mscorefonts-installer
- egyedi betűtípusok
- alapértelmezett betűtípus
- szerver
- konténer
- PDF konverzió
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Betűtípusok telepítése az Aspose.Slides for .NET-hez Linux szervereken és Docker konténerekben: ellenőrizze, mely betűtípusok lesznek helyettesítve, telepítse a betűtípus csomagokat Debianra, Ubuntura és Alpine-ra, adja hozzá saját betűtípus fájljait, és állítson be alapértelmezett betűtípust."
---
## **Áttekintés**

Az Aspose.Slides a rendelkezésére álló betűtípusokkal rajzolja a szöveget, amikor egy bemutatót renderel, például amikor diákot konvertál PDF-re vagy képekké. Egy Windows asztali gépen általában megtalálhatók a bemutatók által használt betűtípusok. Linux szervereken és konténerekben általában kevés vagy egyáltalán nincs betűtípus, ezért az Aspose.Slides helyettesítő betűtípussal rajzolja a szöveget. A helyettesítő betűtípus más betűalakokat és szélességeket használ, ezért a sorok másként törhetnek, a szöveg kilóghat a formájából, és a helyettesítőben hiányzó karakterek nem jelennek meg megfelelően. Ha egyáltalán nincs betűtípus telepítve, a konverzió hibával leáll.

Ez a cikk bemutatja, hogyan ellenőrizhető, mely betűtípusokat helyettesíti az Aspose.Slides, hogyan telepíthetőek betűtípusok Debianra, Ubuntu-ra és Alpine Linuxra, hogyan adhatók hozzá saját betűtípusfájlok, és hogyan állítható be a hiányzó betűtípus helyett használandó betűtípus. A példák Dockerben futnak a hivatalos .NET képeken, ahogyan a [Futtassa az Aspose.Slides for .NET-et Dockerben](/slides/hu/net/how-to-run-aspose-slides-in-docker/) cikkben. A csomagparancsok Dockerfile utasítások; egy Linux szerveren ugyanazokat a parancsokat futtassa rootként.

A betűtípus API-val kapcsolatban, például a betűtípusok beágyazásához egy prezentációba és a helyettesítési szabályokhoz, lásd a [PowerPoint betűtípusok](/slides/hu/net/powerpoint-fonts/) oldalt.

## **Ellenőrizze, mely betűtípusok vannak helyettesítve**

A következő konzolalkalmazás jelzi, hogy az Aspose.Slides mely betűtípusokat helyettesíti a jelenlegi környezetben. Hozzon létre egy *FontCheck* nevű mappát, és adja hozzá az alábbi fájlokat.

*FontCheck.csproj* hivatkozik az [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) csomagra, amely Debianra és Ubuntu-ra vonatkozik. Emellett egy opcionális *fonts* mappa fájljait másolja az alkalmazás kimenetébe; a [Betűtípusok betöltése az alkalmazás mappájából](#load-fonts-from-the-application-folder) szekció használja.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* egy szövegdobozt ad hozzá minden betűtípusnévhez egy diára, és a [LatinFont](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/latinfont/) tulajdonságon keresztül állítja be a betűtípust. A betűtípusnevek a parancssorból származnak; argumentumok nélkül az alkalmazás a Calibri, Arial és Times New Roman betűtípusokat ellenőrzi. Kiírja a mappákat, amelyekben az Aspose.Slides betűtípusokat keres ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/getfontfolders/)), rendereli a diát a *output/fonts.pdf* fájlba, és kiírja a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getsubstitutions/) által jelentett helyettesítéseket. A két opcionális lépés a kezdetnél, egy *fonts* mappa betöltése és egy `DEFAULT_FONT` változó olvasása, később kerül részletezésre ebben a cikkben.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// A ellenőrzendő betűtípusok: a parancssori argumentumok, vagy három általános Office betűtípus.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Betöltse a betűtípus fájlokat az alkalmazás mellé elhelyezett fonts mappából, ha létezik.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Használja a DEFAULT_FONT környezeti változóban megadott betűtípust, ha be van állítva, a hiányzó betűtípusú szöveghez.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* kizárja a helyi build eredményeket a build kontextusból:

```text
bin/
obj/
output/
```

*Dockerfile* felépíti az alkalmazást a .NET SDK képpel, és a .NET runtime képen futtatja. A runtime szakasz telepíti a `libfontconfig1`-et, amelyet az Aspose.Slides.NET6.CrossPlatform igényel, valamint a DejaVu betűtípusokat. A [Futtassa az Aspose.Slides for .NET-et Dockerben](/slides/hu/net/how-to-run-aspose-slides-in-docker/) minden utasítást részletez.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Építse fel a képet, és futtassa az ellenőrzést:

```bash
docker build -t font-check .
docker run --rm font-check
```

A képen csak a DejaVu betűtípusok vannak, ezért mindhárom betűtípus a DejaVu Sans-ra lesz cserélve:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Az ön saját prezentációinak betűtípusainak ellenőrzéséhez adja át a neveket argumentumként, például `docker run --rm font-check "Segoe UI" Consolas`. A *output/fonts.pdf* konténerből történő másolásához használja a [Kimenet másolása a gépére](/slides/hu/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) parancsokat.

## **Betűtípusok telepítése Debianra és Ubuntu-ra**

### **Microsoft Core betűtípusok**

`ttf-mscorefonts-installer` csomag letölti és telepíti a Microsoft core betűtípusokat a webhez, köztük az Arial, Times New Roman, Courier New, Verdana, Georgia és Trebuchet MS betűtípusokat. A betűtípusok a Microsoft felhasználói licencszerződése (EULA) alatt vannak, és a csomag csak akkor telepíti őket, ha az EULA elfogadásra került. Egy Docker build nem tud válaszolni a kérdésre, ezért a telepítő elutasítja az EULA-t és nem telepít betűtípusokat, miközben az `apt-get install` mégis sikeresnek jelzi. Fogadja el az EULA-t a `debconf-set-selections` paranccsal **mielőtt** a csomagot telepítené.

A *Dockerfile*-ban cserélje le a runtime szakaszban a csomagokat telepítő `RUN` utasítást a következőre:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Építse fel újra a képet, és futtassa az ellenőrzést ugyanazokkal a két paranccsal. Az Arial és a Times New Roman most már telepítve van:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Az Aspose.Slides által létrehozott prezentációk alapértelmezett betűtípusa, a Calibri, nem része a core betűtípusoknak, ezért továbbra is helyettesítve lesz. Lásd a [Alapértelmezett betűtípus beállítása hiányzó betűtípusokhoz](#set-a-default-font-for-missing-fonts) szekciót.

Debianon a csomag a `contrib` tárolókomponensben található, amelyet a Debian képek alapértelmezésben nem engedélyeznek; az alapértelmezett .NET 8 és .NET 9 képek Debian 12 alapúak. Engedélyezze a `contrib`-ot ugyanabban az utasításban:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Az Ubuntu-alapú .NET 10 képek már engedélyezik a `multiverse`-t, az Ubuntu komponensét, amely tartalmazza a csomagot.

### **Egyéb betűtípuscsomagok**

Debian és Ubuntu szabad licence alatt álló betűtípusokat is csomagol, például:

| Csomag | Betűtípusok |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, and Mono, with the same metrics as Arial, Times New Roman, and Courier New |
| `fonts-crosextra-carlito` | Carlito, with the same metrics as Calibri |
| `fonts-crosextra-caladea` | Caladea, with the same metrics as Cambria |

Telepítse őket az `apt-get install` paranccsal ugyanabban a `RUN` utasításban. Az Aspose.Slides.NET6.CrossPlatform nem alkalmazza a Linux betűtípus konfiguráció aliasait: a `fonts-liberation` telepítése után is az Arial szöveg általános helyettesítő betűtípussal jelenik meg, nem a Liberation Sans-szal. Egy metrikailag kompatibilis betűtípus használatához egy hiányzó helyett, állítsa be alapértelmezett betűtípusként ([alapértelmezett betűtípus](#set-a-default-font-for-missing-fonts)), vagy adjon hozzá egy [betűtípus helyettesítési szabályt](/slides/hu/net/font-substitution/).

## **Saját betűtípusfájlok hozzáadása**

Azok a betűtípusok, amelyeket a disztribúciók nem csomagolnak, például a szervezete betűtípusai vagy egyéb olyan betűtípusok, amelyeket a szerveren használhat licenc alapján, hozzáadhatók betűtípusfájlokként. Helyezze a betűtípusfájlokat, például *.ttf* fájlokat, egy *fonts* nevű mappába a *FontCheck* mappán belül. Az alábbi példák a Carlito fájlokat használják, egy Calibri-hez hasonló metrikájú betűtípus, amelyet letölthet a [Google Fonts](https://fonts.google.com/specimen/Carlito) oldalról.

### **A betűtípusok telepítése egy rendszer betűtípus mappába**

Az Aspose.Slides a `Font folders` sorban kiírt mappákban lévő betűtípusokat olvassa. A betűtípusok minden alkalmazás számára történő telepítéséhez a képen, másolja őket a */usr/local/share/fonts* könyvtárba, amely a helyi telepítésű betűtípusok mappája. Adja hozzá ezt az utasítást a *Dockerfile* runtime szakaszához, a csomagokat telepítő `RUN` utasítás után:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Betűtípusok betöltése az alkalmazás mappájából**

A betűtípusok a képbe való telepítése helyett csatolhatók az alkalmazáshoz, és betölthetők a [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) metódussal. Ekkor a betűtípusok csak az Aspose.Slides számára lesznek elérhetők, és az alkalmazással együtt kerülnek telepítésre. A *FontCheck* ezt teszi: a *FontCheck.csproj* másolja a *fonts* mappát az alkalmazás kimenetébe, a *Program.cs* pedig a `LoadExternalFonts`-nek átadja ezt a mappát a prezentáció létrehozása előtt. A [Egyedi betűtípus](/slides/hu/net/custom-font/) leírja a betűtípusok más módon történő biztosítását, például memóriából történő betöltést.

Építse újra a képet, majd ellenőrizze a Calibri és a Carlito betűtípusokat:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Az alkalmazás mappa most már megjelenik a betűtípus mappák között, és a Carlito már nem lesz helyettesítve:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Alapértelmezett betűtípus beállítása hiányzó betűtípusokhoz**

Ha egy betűtípus hiányzik, az Aspose.Slides egy saját maga által választott helyettesítőt használ. A saját helyettesítő beállításához állítsa be a [DefaultRegularFont](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/defaultregularfont/) tulajdonságot a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) osztályban, és adja át ezeket az opciókat a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) konstruktorának. A *FontCheck* a `DEFAULT_FONT` környezeti változóból olvassa a betűtípus nevét. Carlito betöltése után használja azt hiányzó betűtípusokhoz:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

A Calibri most már Carlito-val van megrajzolva, amelynek karakterei ugyanolyan szélességűek, mint a Calibri-é, így a szöveg megtartja a sortöréseket:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Az alapértelmezett betűtípus minden hiányzó betűtípust lecserél. Az egyes betűtípusok leképezéséhez, például az Arial-t a Liberation Sans-re és a Calibri-t a Carlito-ra, használja a [betűtípus helyettesítési szabályokat](/slides/hu/net/font-substitution/). A szabályok megváltoztatják a renderelt kimenetet, de a `GetSubstitutions` nem tükrözi őket, ezért ellenőrizze a betűtípusokat a kimeneti fájlban. Ázsiai szöveg esetén állítsa be a [DefaultAsianFont](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/defaultasianfont/) értéket is; lásd a [Alapértelmezett betűtípus](/slides/hu/net/default-font/) oldalt.

## **Betűtípusok telepítése Alpine Linuxon**

Alpine Linuxon használja az Aspose.Slides.NET csomagot; a [Futtatás Alpine Linuxon](/slides/hu/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) felsorolja a projekt módosításait. Végezze el ugyanazokat a módosításokat a *FontCheck*-en: cserélje ki a csomagreferenciát, adja hozzá a `SetSwitch` utasítást a *Program.cs*-hez, és használja ezt a runtime szakaszt, amely telepíti a Microsoft core betűtípusokat is:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` letölti és telepíti ugyanazokat a Microsoft core betűtípusokat, mint a Debian és Ubuntu csomag, és az EULA ugyanúgy érvényes. Az `fc-cache` frissíti a betűtípus gyorsítótárát.

Az Aspose.Slides.NET Linuxon a betűtípus konfigurációs könyvtár (fontconfig) választja ki a helyettesítőt egy hiányzó betűtípusra, és a `GetSubstitutions` nem jelenti azt, ezért a *FontCheck* azt írja ki, hogy `No font substitutions.` Ahhoz, hogy megtekintse, mely betűtípus használatos egy betűtípus névhez, kérdezze meg a fontconfig-ot a konténerben:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

A Microsoft core betűtípusok telepítése után az Arial lett használva az Arial helyett:

```text
Arial.ttf: "Arial" "Regular"
```

Ezek nélkül, ha a `RUN` utasítás csak a `icu-libs libgdiplus font-dejavu` csomagokat telepíti, ugyanaz a parancs a következőt írja ki:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **GYIK**

**Miért néz ki másképp egy prezentáció, amikor szerveren konvertálják?**

A szerveren nincsenek meg a prezentáció által használt betűtípusok, ezért az Aspose.Slides helyettesítő betűtípussal rajzolja a szöveget, amelynek karakterei más szélességűek. Futtassa a *FontCheck*-et a prezentáció betűtípusneveivel, hogy lássa, mely betűtípusok helyettesítve vannak, majd telepítse ezeket a betűtípusokat vagy töltse be őket az alkalmazás mappájából.

**A build telepítette a ttf-mscorefonts-installer csomagot, de az Arial még mindig helyettesítve van. Miért?**

Az EULA nem lett elfogadva a csomag telepítése előtt, ezért a telepítő kihagyta a betűtípusokat. Adja hozzá a `debconf-set-selections` parancsot az `apt-get install` előtt, ahogy a [Microsoft Core betűtípusok](#microsoft-core-fonts) részben látható, majd építse újra a képet.

**A PDF-et megnyitó számítógépnek szüksége van a betűtípusokra?**

Nem. Ezekben a példákban a PDF tartalmazza azokat a betűtípusokat, amelyekkel a szöveg meg lett rajzolva, így minden számítógépen egyformán néz ki. A betűtípusokra csak ott van szükség, ahol az Aspose.Slides rendereli a prezentációt.