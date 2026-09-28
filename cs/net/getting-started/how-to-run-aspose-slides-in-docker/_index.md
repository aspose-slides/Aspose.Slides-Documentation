---
title: Spustit Aspose.Slides pro .NET v Dockeru
linktitle: Docker
type: docs
weight: 140
url: /cs/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker kontejner
- vícefázová sestava
- obraz kontejneru
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- písma
- převod PDF
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvořte a spusťte konzolovou aplikaci Aspose.Slides pro .NET v Dockeru: vícefázový Dockerfile na oficiálních .NET obrazech, knihovny a písma Linuxu, které potřebuje, a jak zkopírovat vygenerované soubory do vašeho počítače."
---
## **Přehled**

Tento článek ukazuje, jak spustit Aspose.Slides pro .NET v kontejneru Docker. Vytvoříte malou konzolovou aplikaci, která vytvoří prezentaci s textovým polem a převede ji do PDF, zabalíte ji pomocí vícefázového Dockerfile na oficiálních .NET obrazech společnosti Microsoft, spustíte ji a zkopírujete vygenerované soubory do svého počítače. Článek také uvádí knihovny Linuxu a písma, které Aspose.Slides v kontejneru potřebuje, a končí variantou pro Alpine Linux.

Na svém počítači potřebujete pouze Docker. .NET SDK je součástí obrazu pro sestavení, takže jej nemusíte instalovat. Pro instalaci Dockeru viz [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Vyberte balíček a základní obraz**

Výchozí kontejnery .NET 10 jsou založeny na Ubuntu 24.04. Na těchto obrazech použijte balíček [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Vyžaduje knihovnu `fontconfig` a obraz .NET runtime neobsahuje ani tuto knihovnu, ani žádná písma, takže Dockerfile v tomto článku nainstaluje obojí.

Aspose.Slides.NET6.CrossPlatform nefunguje na Alpine Linux. Pro obrazy založené na Alpine použijte balíček [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) s `libgdiplus`, jak je popsáno v [Run on Alpine Linux](#run-on-alpine-linux). [Installation](/slides/cs/net/installation/) porovnává oba balíčky.

## **Vytvořte projekt**

Vytvořte složku s názvem *HelloSlidesDocker* a přidejte do ní následující tři soubory.

*HelloSlidesDocker.csproj* popisuje konzolovou aplikaci pro .NET 10, verzi kontejnerových obrazů použitých níže, a odkazuje na Aspose.Slides.NET6.CrossPlatform. Nastavte verzi balíčku na nejnovější uvedenou na [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

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

*Program.cs* vytváří [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/), přidává obdélník s textem na první snímek a ukládá prezentaci dvakrát metodou [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/): jako PPTX i jako PDF. Oba soubory jsou umístěny ve složce *output* pod pracovní složkou. Aplikace pak vypíše písma, která byla během renderování PDF nahrazena, pomocí [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/), abyste mohli zjistit, zda kontejner obsahuje písma použité v prezentaci.

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

*.dockerignore* udržuje složky *bin* a *obj* místní kompilace a výstup dřívějších spuštění mimo kontext Dockeru, takže obraz je vytvořen pouze ze zdrojových souborů.

```text
bin/
obj/
output/
```

## **Napište Dockerfile**

Přidejte soubor s názvem *Dockerfile* do stejné složky:

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

Soubor má dvě fáze:

- **Fáze sestavení** začíná z obrazu .NET SDK. Nejprve zkopíruje soubor projektu a obnoví balíčky NuGet, takže Docker tuto vrstvu znovu použije, dokud se soubor projektu nezmění. Poté zkopíruje zdrojový kód a publikujete aplikaci do */app*.
- **Fáze běhu** začíná z menšího obrazu .NET runtime, který neobsahuje SDK, a zkopíruje pouze publikovanou aplikaci. Nainstaluje dva balíčky:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform načítá tuto knihovnu při spuštění. Bez ní se aplikace zastaví s `DllNotFoundException`, která uvádí `libfontconfig.so.1`.
  - `fonts-dejavu-core`: obraz runtime neobsahuje žádná písma a Aspose.Slides potřebuje alespoň jedno nainstalované písmo pro vykreslení textu; bez nich se konverze zastaví s `InvalidOperationException: Cannot find any fonts installed on the system.` Text v písmenech, která nejsou nainstalována, je vykresleno náhradním písmem. Písma DejaVu jsou malá sada, která umožňuje vykreslování textu; pro vykreslování prezentací s originálními písmy viz [Deploy Fonts](/slides/cs/net/deploy-fonts/).

`--no-install-recommends` a odstranění seznamů balíčků udržují obraz malý. Poslední řádky vytvoří složku *output*, přiřadí ji ne‑root uživateli `app`, který je definován v oficiálních .NET obrazech (její ID uživatele je v proměnné `APP_UID`), a spustí aplikaci pod tímto uživatelem.

Pro aplikaci ASP.NET Core spusťte fázi běhu z `mcr.microsoft.com/dotnet/aspnet:10.0`. Je založena na stejném obrazu Ubuntu, takže jsou potřeba stejné balíčky.

## **Sestavte a spusťte kontejner**

Otevřete terminál ve složce *HelloSlidesDocker*. Sestavte obraz a poté z něj spusťte kontejner:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

První sestavení stáhne základní obrazy a balíčky NuGet, takže trvá déle než pozdější sestavení. Kontejner spustí aplikaci a zastaví se. Vytiskne:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

První řádek ukazuje, že text používá Calibri, výchozí písmo nové prezentace, a že Calibri není v obrazu nainstalováno, takže Aspose.Slides vykreslil text pomocí DejaVu Sans. Text v PDF je skutečný, vybratelný text v tomto písmu. Bez licence Aspose.Slides také přidává evaluační vodoznak ke každému uloženému snímku; viz [Licensing](/slides/cs/net/licensing/).

## **Zkopírujte výstup do svého počítače**

Soubory jsou ve složce */app/output* zastaveného kontejneru. Zkopírujte je do složky *output* na svém počítači a poté odstraňte kontejner:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Tyto dva příkazy fungují stejně v Bash, PowerShell i ve Windows Command Prompt.

V Linuxu můžete místo toho připojit složku ze svého počítače do kontejneru, takže aplikace přímo zapisuje soubory tam:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Volba `--user` spouští aplikaci s vašimi UID a GID, takže může zapisovat do vytvořené složky a soubory patří vám. `--rm` odstraní kontejner po jeho zastavení.

## **Spuštění na Alpine Linux**

Pro spuštění aplikace v obrazu založeném na Alpine přepněte na balíček Aspose.Slides.NET a změňte fázi běhu. Fáze sestavení zůstává stejná.

1. V souboru *HelloSlidesDocker.csproj* nahraďte odkaz na balíček:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

1. V souboru *Program.cs* přidejte tento příkaz po direktivách `using`, před první volání Aspose.Slides. Povolení podpory System.Drawing pro Linux, kterou používá Aspose.Slides.NET:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

1. V souboru *Dockerfile* nahraďte fázi běhu (vše od druhého řádku `FROM`) tímto:

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

Alpine fáze nainstaluje tři balíčky a změní jedno nastavení:

- `libgdiplus` je grafická knihovna, kterou Aspose.Slides.NET používá na Linuxu.
- `font-dejavu` poskytuje písma. Bez jakéhokoli písma se konverze zastaví s `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` a `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` poskytují data o kulturách. Alpine .NET obrazy běží ve výchozím režimu globalizace‑invariant, a v tomto režimu Aspose.Slides selže s `CultureNotFoundException` pro `en-US`.

Sestavte, spusťte a zkopírujte výstup stejnými příkazy jako výše. V tomto obrazu aplikace vytiskne pouze řádek `Saved`: s Aspose.Slides.NET na Linuxu fontconfig vybírá náhradu za chybějící písmo a [GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getsubstitutions/) jej neuvádí. [Deploy Fonts](/slides/cs/net/deploy-fonts/) ukazuje, jak zkontrolovat, které písmo je použito.

## **Často kladené otázky**

**Aplikace se zastaví s „Unable to load shared library 'libaspose.slides.drawing.capi…'“. Co chybí?**

Na obrazech Ubuntu a Debian je potřeba balíček `libfontconfig1`; zpráva uvádí `libfontconfig.so.1` jako soubor, který nelze otevřít. Na Alpine Linux zpráva znamená, že je používán Aspose.Slides.NET6.CrossPlatform; přepněte na Aspose.Slides.NET, jak je popsáno v [Run on Alpine Linux](#run-on-alpine-linux).

**Proč je text v PDF v jiném písmu než v PowerPointu?**

Písma, která prezentace používá, nejsou v obrazu nainstalována, takže Aspose.Slides vykresluje text náhradním písmem. Výstup aplikace pojmenovává každé nahrazené písmo. [Deploy Fonts](/slides/cs/net/deploy-fonts/) vysvětluje, jak nainstalovat písma do obrazu nebo je načíst ze složky aplikace.

**Potřebuji mít .NET SDK na svém počítači?**

Ne. Fáze sestavení kompiluje aplikaci uvnitř SDK obrazu. SDK potřebujete jen v případě, že chcete aplikaci sestavit a spustit i mimo Docker; viz [Installation](/slides/cs/net/installation/).