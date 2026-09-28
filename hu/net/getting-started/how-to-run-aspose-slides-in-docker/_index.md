---
title: "Az Aspose.Slides for .NET futtatása Dockerben"
linktitle: "Docker"
type: docs
weight: 140
url: /hu/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker konténer
- többlépcsős felépítés
- konténerkép
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- betűtípusok
- PDF konverzió
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET konzolos alkalmazás felépítése és futtatása Dockerben: egy többlépcsős Dockerfile a hivatalos .NET képeken, a szükséges Linux könyvtárak és betűtípusok, valamint a generált fájlok gépére másolásának módja."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan futtatható az Aspose.Slides for .NET egy Docker konténerben. Készít egy kis konzolos alkalmazást, amely létrehoz egy prezentációt szövegdobozzal, és PDF-re konvertálja, többfázisú Dockerfile-lal csomagolja a Microsoft hivatalos .NET képeire, futtatja, és átmásolja a generált fájlokat a gépedre. A cikk felsorolja a Linux könyvtárakat és betűtípusokat is, amelyekre az Aspose.Slidesnek szüksége van a konténerben, és egy Alpine Linux változattal zárul.

A gépeden csak a Dockerra van szükség. A .NET SDK a build képen része, így nem kell telepíteni. A Docker telepítéséhez lásd [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Válaszd ki a csomagot és az alapképet**

Az alapértelmezett .NET 10 konténerképek az Ubuntu 24.04-en alapulnak. Ezeken a képeken a [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) csomagot kell használni. Ez `fontconfig` könyvtárat igényel, és a .NET runtime kép sem tartalmazza azt a könyvtárat, sem betűtípusokat, ezért a cikkben szereplő Dockerfile mindkettőt telepíti.

Az Aspose.Slides.NET6.CrossPlatform nem fut Alpine Linuxon. Alpine-alapú képekhez használja a [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) csomagot `libgdiplus`-szal, ahogyan a [Run on Alpine Linux](#run-on-alpine-linux) leírja. A [Telepítés](/slides/hu/net/installation/) összehasonlítja a két csomagot.

## **Projekt létrehozása**

Hozzon létre egy *HelloSlidesDocker* nevű mappát, és adja hozzá a következő három fájlt.

*HelloSlidesDocker.csproj* egy .NET 10 konzolos alkalmazást ír le, a lent használt konténerképek verzióját, és hivatkozik az Aspose.Slides.NET6.CrossPlatform csomagra. Állítsa be a csomag verzióját a [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) oldalon felsorolt legújabbra.

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
  </ItemGroup>

</Project>
```

*Program.cs* létrehoz egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) objektumot, hozzáad egy szöveget tartalmazó téglalapot az első diájához, és kétszer menti a prezentációt a [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) metódussal: PPTX‑ként és PDF‑ként. Mindkét fájl az *output* mappába kerül a munkakönyvtár alatt. Az alkalmazás ezután felsorolja a PDF renderelése közben helyettesített betűtípusokat a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) használatával, így láthatja, hogy a konténer rendelkezik‑e a prezentáció által használt betűtípusokkal.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* a helyi build *bin* és *obj* mappáit, valamint a korábbi futások kimenetét tartja távol a Docker build kontextustól, így a kép csak a forrásfájlokból épül.

```text
bin/
obj/
output/
```

## **Dockerfile írása**

Adjon hozzá egy *Dockerfile* nevű fájlt ugyanabba a mappába:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
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
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

A fájl két szakaszból áll:

- **A build szakasz** a .NET SDK képből indul. Elsőként másolja a projektfájlt, és visszaállítja a NuGet csomagokat, így a Docker újrahasználja ezt a réteget amíg a projektfájl nem változik. Ezután másolja a forráskódot, és kiadja az alkalmazást a */app* könyvtárba.
- **A runtime szakasz** a kisebb .NET runtime képből indul, amely nem tartalmaz SDK‑t, és csak a kiadott alkalmazást másolja be. Két csomagot telepít:
  - `libfontconfig1`: az Aspose.Slides.NET6.CrossPlatform ennek a könyvtárnak a betöltésével indul. Nélküle az alkalmazás `DllNotFoundException` hibával áll le, amely a `libfontconfig.so.1` fájlt említi.
  - `fonts-dejavu-core`: a runtime kép nem tartalmaz betűtípusokat, és az Aspose.Slidesnek legalább egy telepített betűtípusra van szüksége a szöveg rajzolásához; nincsenek ilyenek, a konverzió `InvalidOperationException: Cannot find any fonts installed on the system.` hibával áll le. A nem telepített betűtípusok helyett helyettesítő betűtípussal rajzol. A DejaVu betűtípusok egy kis készletet biztosítanak, amely lehetővé teszi a szöveg megjelenítését; a prezentációk eredeti betűtípusaival való megjelenítéshez lásd a [Deploy Fonts](/slides/hu/net/deploy-fonts/) útmutatót.

  `--no-install-recommends` és a csomaglisták eltávolítása segít a kép méretének csökkentésében. Az utolsó sorok létrehozzák az *output* mappát, a nem root `app` felhasználóhoz rendelik (amely a hivatalos .NET képekben a `APP_UID` változóban szerepel), és a felhasználóként futtatják az alkalmazást.

ASP.NET Core alkalmazás esetén a runtime szakaszt indítsa a `mcr.microsoft.com/dotnet/aspnet:10.0` képből. Ez ugyanazon Ubuntu képen alapul, ezért ugyanazok a csomagok szükségesek.

## **Konténer felépítése és futtatása**

Nyisson egy terminált a *HelloSlidesDocker* mappában. Építse fel a képet, majd futtasson egy konténert belőle:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Az első build letölti az alapképeket és a NuGet csomagokat, ezért hosszabb ideig tart, mint a későbbi buildek. A konténer lefuttatja az alkalmazást és leáll. Kiírja a következőt:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Az első sor azt mutatja, hogy a szöveg a Calibri-t használja, amely egy új prezentáció alapértelmezett betűtípusa, és hogy a Calibri nincs telepítve a képen, így az Aspose.Slides a szöveget DejaVu Sans-szal rajzolta. A PDF-ben a szöveg valós, kiválasztható szöveg ebben a betűtípusban. Licenc nélkül az Aspose.Slides minden mentett diára egy értékelő vízjelet ad hozzá; lásd [Licenc](/slides/hu/net/licensing/).

## **Kimenet másolása a gépre**

A fájlok a leállított konténer */app/output* mappájában vannak. Másolja őket egy *output* mappába a gépén, majd távolítsa el a konténert:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Ez a két parancs ugyanúgy működik Bash‑ben, PowerShell‑ben és a Windows Parancssorban.

Linuxon helyette egy mappát csatolhat a gépéről a konténerbe, így az alkalmazás közvetlenül oda írja a fájlokat:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

A `--user` kapcsoló az alkalmazást az Ön felhasználói és csoport‑azonosítóival futtatja, így írni tud a létrehozott mappába, és a fájlok az Önhöz tartoznak. A `--rm` a konténert a leálláskor eltávolítja.

## **Futtatás Alpine Linuxon**

Az alkalmazás Alpine‑alapú képen való futtatásához váltsunk az Aspose.Slides.NET csomagra, és módosítsuk a runtime szakaszt. A build szakasz változatlan marad.

1. A *HelloSlidesDocker.csproj*-ben cserélje ki a csomagra hivatkozást:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

1. A *Program.cs*-ben adja hozzá ezt a kifejezést a `using` direktívák után, az első Aspose.Slides hívás előtt. Ez engedélyezi a System.Drawing támogatást Linuxon, amelyet az Aspose.Slides.NET használ:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

1. A *Dockerfile*-ban cserélje ki a runtime szakaszt (mindennel, ami a második `FROM` sortól kezdődik) a következőre:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Az Alpine szakasz három csomagot telepít és egy beállítást módosít:

- `libgdiplus` a grafikai könyvtár, amelyet az Aspose.Slides.NET Linuxon használ.
- `font-dejavu` betűtípusokat biztosít. Nincs betűtípus, a konverzió `System.ArgumentException: Font '?' cannot be found` hibával áll le.
- `icu-libs` és `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` biztosítják a kulturális adatokat. Az Alpine .NET képek alapértelmezés szerint a globalizáció‑invariáns módban futnak, ebben a módban az Aspose.Slides `CultureNotFoundException` hibával áll le az `en-US` esetén.

Építse, futtassa, és másolja a kimenetet a fenti ugyanazokkal a parancsokkal. Ezen a képen az alkalmazás csak a `Saved` sort írja ki: Linuxon az Aspose.Slides.NET esetén a fontconfig választja ki a hiányzó betűtípus helyettesítőjét, és a [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) nem sorolja fel. A [Betűtípusk telepítése](/slides/hu/net/deploy-fonts/) bemutatja, hogyan ellenőrizhető, mely betűtípust használták.

## **GYIK**

**Az alkalmazás leáll a „Unable to load shared library 'libaspose.slides.drawing.capi…'” hibaüzenettel. Mi hiányzik?**

Ubuntu és Debian képeken a `libfontconfig1` csomagra van szükség; az üzenet a `libfontconfig.so.1` fájlt sorolja fel, amelyet nem sikerült megnyitni. Alpine Linuxon az üzenet azt jelenti, hogy az Aspose.Slides.NET6.CrossPlatform van használatban; váltsunk az Aspose.Slides.NET-re, amint a [Run on Alpine Linux](#run-on-alpine-linux) leírása tartalmaz.

**Miért más betűtípusban jelenik meg a PDF szövege, mint a PowerPointban?**

A prezentáció által használt betűtípusok nincsenek telepítve a képen, ezért az Aspose.Slides helyettesítő betűtípussal rajzolja a szöveget. Az alkalmazás kimenete felsorolja az egyes helyettesített betűtípusokat. A [Betűtípusk telepítése](/slides/hu/net/deploy-fonts/) bemutatja, hogyan telepíthetők a betűtípusok a képre vagy hogyan tölthetők be az alkalmazás mappájából.

**Szükségem van a .NET SDK-ra a gépemen?**

Nem. A build szakasz a SDK képen belül fordítja le az alkalmazást. A SDK csak akkor szükséges, ha a Dockeron kívül is szeretné felépíteni és futtatni az alkalmazást; lásd a [Telepítés](/slides/hu/net/installation/) oldalt.