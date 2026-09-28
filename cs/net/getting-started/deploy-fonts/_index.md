---
title: Nasazení fontů pro Aspose.Slides na Linuxu a v Dockeru
linktitle: Nasadit fonty
type: docs
weight: 145
url: /cs/net/deploy-fonts/
keywords:
- nasazení fontů
- instalace fontů
- fonty v Dockeru
- fonty na Linuxu
- chybějící fonty
- náhrada fontů
- základní fonty Microsoftu
- ttf-mscorefonts-installer
- vlastní fonty
- výchozí font
- server
- kontejner
- převod PDF
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Nasazení fontů pro Aspose.Slides pro .NET na Linuxových serverech a v Docker kontejnerech: zkontrolujte, která fonty jsou nahrazena, nainstalujte balíčky fontů na Debian, Ubuntu a Alpine, přidejte vlastní soubory fontů a nastavte výchozí font."
---
## **Přehled**

Aspose.Slides vykresluje text pomocí písem, která má k dispozici při renderování prezentace, například při převodu snímků do PDF nebo do obrázků. Windowsová pracovní stanice obvykle obsahuje písma, která prezentace používají. Linuxové servery a kontejnery obvykle mají málo písem nebo žádná, takže Aspose.Slides vykresluje text náhradním písmem. Náhrada má jiné tvary a šířky písmen, takže řádky se mohou zalamovat jinak a text může přesahovat svůj tvar, a znaky, které náhrada postrádá, nejsou vykresleny správně. Pokud není nainstalováno žádné písmo, konverze se zastaví s chybou.

Tento článek ukazuje, jak zjistit, která písma Aspose.Slides nahrazuje, jak nainstalovat písma na Debianu, Ubuntu a Alpine Linux, jak přidat vlastní soubory písem a jak nastavit písmo, které se použije, když chybí písmo. Příklady běží v Dockeru na oficiálních .NET obrazech, stejně jako v [Run Aspose.Slides for .NET in Docker](/slides/cs/net/how-to-run-aspose-slides-in-docker/). Příkazy balíčků jsou instrukce Dockerfile; na Linuxovém serveru spusťte stejné příkazy jako root.

Pro samotné API písem, například vkládání písem do prezentace a pravidla pro záložní a nahrazovací písma, viz [PowerPoint Fonts](/slides/cs/net/powerpoint-fonts/).

## **Kontrola, která písma jsou nahrazena**

Následující konzolová aplikace hlásí písma, která Aspose.Slides nahrazuje v aktuálním prostředí. Vytvořte složku pojmenovanou *FontCheck* a přidejte do ní soubory níže.

*FontCheck.csproj* odkazuje na [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), balíček pro Debian a Ubuntu. Také kopíruje soubory volitelné složky *fonts* do výstupu aplikace; sekce [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) ji používá.

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

*Program.cs* přidá jeden textový rámeček pro každé jméno písma na snímek a přiřadí písmo prostřednictvím vlastnosti [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/). Jména písem pocházejí z příkazové řádky; bez argumentů aplikace kontroluje Calibri, Arial a Times New Roman. Vytiskne složky, ve kterých Aspose.Slides hledá písma ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), vykreslí snímek do *output/fonts.pdf* a vypíše náhrady hlášené metodou [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/). Dva volitelné kroky na začátku, načtení složky *fonts* a přečtení proměnné `DEFAULT_FONT`, jsou vysvětleny dále v tomto článku.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Písma ke kontrole: argumenty příkazové řádky nebo tři běžná Office písma.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Načíst soubory písem ze složky fonts vedle aplikace, pokud existuje.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Použít písmo pojmenované v proměnné prostředí DEFAULT_FONT, pokud je nastavená, pro text, jehož písmo chybí.
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

*.dockerignore* udržuje lokální výsledky sestavení mimo kontext sestavení:

```text
bin/
obj/
output/
```

*Dockerfile* sestavuje aplikaci s obrazem .NET SDK a spouští ji na obrazu .NET runtime. Ve fázi runtime se instalují `libfontconfig1`, které Aspose.Slides.NET6.CrossPlatform vyžaduje, a písma DejaVu. [Run Aspose.Slides for .NET in Docker](/slides/cs/net/how-to-run-aspose-slides-in-docker/) vysvětluje každou instrukci.

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

Sestavte obraz a spusťte kontrolu:

```bash
docker build -t font-check .
docker run --rm font-check
```

Obraz má jen písma DejaVu, takže všechna tři písma jsou nahrazena DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Chcete‑li zkontrolovat písma ve vlastních prezentacích, předávejte jejich názvy jako argumenty, například `docker run --rm font-check "Segoe UI" Consolas`. Pro zkopírování *output/fonts.pdf* z kontejneru použijte příkazy v [Copy the Output to Your Machine](/slides/cs/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Instalace písem na Debianu a Ubuntu**

### **Microsoft Core Fonts**

Balíček `ttf-mscorefonts-installer` stahuje a instaluje základní písma Microsoftu pro web, mezi nimi Arial, Times New Roman, Courier New, Verdana, Georgia a Trebuchet MS. Písma jsou licencována podle koncového uživatelského licenčního souhlasu Microsoftu (EULA) a balíček je nainstaluje až po akceptaci EULA. Docker build nemůže na výzvu odpovědět, takže instalátor odmítne EULA a neinstaluje žádná písma, přičemž `apt-get install` stále hlásí úspěch. Přijměte EULA pomocí `debconf-set-selections` **před** instalací balíčku.

V *Dockerfile* nahraďte instrukci `RUN`, která v runtime fázi instaluje balíčky, následujícím:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Sestavte obraz a znovu spusťte kontrolu stejnými dvěma příkazy. Arial a Times New Roman jsou nyní nainstalovány:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, výchozí písmo prezentace, kterou Aspose.Slides vytváří, není jedním ze základních písem, takže je stále nahrazováno. Viz [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Na Debianu je balíček v komponentě repozitáře `contrib`, kterou Debian obrazy nepovolují; výchozí obrazy .NET 8 a .NET 9 jsou založeny na Debianu 12. Povolení `contrib` proveďte ve stejné instrukci:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Ubuntu‑based .NET 10 obrazy již povolují `multiverse`, komponentu Ubuntu, která balíček obsahuje.

### **Další balíčky písem**

Debian a Ubuntu také balíčkovají volně licencovaná písma, například:

| Balíček | Písma |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif a Mono, se stejnými metrikami jako Arial, Times New Roman a Courier New |
| `fonts-crosextra-carlito` | Carlito, se stejnými metrikami jako Calibri |
| `fonts-crosextra-caladea` | Caladea, se stejnými metrikami jako Cambria |

Instalujte je pomocí `apt-get install` ve stejné `RUN` instrukci. Aspose.Slides.NET6.CrossPlatform neaplikuje aliasy písem z linuxové konfigurace písem: i po instalaci `fonts-liberation` se text v Ariali stále vykresluje obecnou náhradou, nikoli Liberation Sans. Pro použití metricky kompatibilního písma místo chybějícího nastavte jej jako [výchozí písmo](#set-a-default-font-for-missing-fonts) nebo přidejte [pravidlo náhrady písma](/slides/cs/net/font-substitution/).

## **Přidání vlastních souborů písem**

Písma, která distribuce nebalíkují, například písma vaší organizace nebo další písma, na která máte licenci pro použití na serveru, lze přidat jako soubory písem. Vložte soubory písem, např. *.ttf* soubory, do složky pojmenované *fonts* uvnitř složky *FontCheck*. Níže uvedené příklady používají soubory Carlito, písmo se stejnými metrikami jako Calibri, které můžete stáhnout z [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Instalace písem do systémové složky písem**

Aspose.Slides čte písma ve složkách vytištěných na řádku `Font folders`. Pro instalaci písem pro každou aplikaci v obrazu je zkopírujte do */usr/local/share/fonts*, složky pro lokálně instalovaná písma. Přidejte tuto instrukci do runtime fáze *Dockerfile*, za instrukci `RUN`, která instalují balíčky:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Načtení písem ze složky aplikace**

Místo instalace písem v obrazu je můžete dodávat s aplikací a načíst pomocí [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/). Písma jsou pak k dispozici jen Aspose.Slides a nasazena jsou spolu s aplikací. *FontCheck* to dělá: *FontCheck.csproj* kopíruje složku *fonts* do výstupu aplikace a *Program.cs* před vytvořením prezentace předá tuto složku metodě `LoadExternalFonts`. [Custom Font](/slides/cs/net/custom-font/) popisuje další způsoby dodání písem, například načtení z paměti.

Znovu sestavte obraz a poté zkontrolujte Calibri a Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Složka aplikace se nyní objeví mezi složkami písem a Carlito již není nahrazováno:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Nastavení výchozího písma pro chybějící písma**

Když chybí písmo, Aspose.Slides použije náhradu, kterou si zvolí sám. Chcete‑li si náhradu zvolit vy, nastavte vlastnost [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) třídy [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) a předávejte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). *FontCheck* načte název písma z proměnné prostředí `DEFAULT_FONT`. S načteným Carlitem jej použijte pro chybějící písma:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri se nyní vykresluje pomocí Carlita, jehož znaky mají stejné šířky jako u Calibri, takže text si zachovává své zalomení řádků:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Výchozí písmo nahrazuje každé chybějící písmo. Pro mapování jednotlivých písem, např. Arial na Liberation Sans a Calibri na Carlito, použijte [pravidla náhrady písem](/slides/cs/net/font-substitution/). Pravidla mění vykreslený výstup, ale `GetSubstitutions` je neodráží, takže písma v souboru výstupu kontrolujte přímo. Pro asijský text nastavte také [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/); viz [Default Font](/slides/cs/net/default-font/).

## **Instalace písem na Alpine Linux**

Na Alpine Linux použijte balíček Aspose.Slides.NET; [Run on Alpine Linux](/slides/cs/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) uvádí změny projektu. Proveďte stejné úpravy v *FontCheck*: nahraďte odkaz na balíček, přidejte výraz `SetSwitch` do *Program.cs* a použijte tuto runtime fázi, která také instalovat Microsoft Core Fonts:

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

`update-ms-fonts` stahuje a instaluje stejná Microsoft Core Fonts jako balíček pro Debian a Ubuntu a jejich EULA se použije stejným způsobem. `fc-cache` aktualizuje mezipaměť písem.

S Aspose.Slides.NET na Linuxu knihovna pro konfiguraci písem (fontconfig) vybírá náhradu pro chybějící písmo a `GetSubstitutions` ji nehlásí, takže *FontCheck* vypíše `No font substitutions.` Chcete‑li zjistit, které písmo je použito pro konkrétní název, zeptejte se fontconfigu v kontejneru:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Po instalaci Microsoft Core Fonts se pro Arial používá Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Bez nich, když `RUN` instrukce instaluje jen `icu-libs libgdiplus font-dejavu`, stejný příkaz vypíše:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **Často kladené otázky**

**Proč vypadá prezentace po konverzi na serveru jinak?**

Server nemá písma, která prezentace používá, takže Aspose.Slides vykresluje text náhradním písmem, jehož písmena mají jiné šířky. Spusťte *FontCheck* s názvy písem prezentace, abyste zjistili, která písma jsou nahrazena, a poté tato písma nainstalujte nebo načtěte ze složky aplikace.

**Instalace balíčku ttf‑mscorefonts‑installer proběhla, ale Arial je stále nahrazováno. Proč?**

EULA nebyla přijata před instalací balíčku, takže instalátor písma přeskočil. Přidejte příkaz `debconf-set-selections` před `apt-get install`, jak je ukázáno v [Microsoft Core Fonts](#microsoft-core-fonts), a obrazu sestavte znovu.

**Potřebuje počítač, který otevírá PDF, písma?**

Ne. V těchto příkladech PDF obsahuje písma, která byla použita k vykreslení textu, takže vypadá stejně na jakémkoli počítači. Písma jsou potřeba jen tam, kde Aspose.Slides renderuje prezentaci.