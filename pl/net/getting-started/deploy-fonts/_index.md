---
title: "Wdrażanie czcionek dla Aspose.Slides na Linuxie i w Dockerze"
linktitle: "Wdrażanie czcionek"
type: docs
weight: 145
url: /pl/net/deploy-fonts/
keywords:
- wdrażanie czcionek
- instalowanie czcionek
- czcionki w Dockerze
- czcionki na Linuxie
- brakujące czcionki
- zastępowanie czcionek
- Podstawowe czcionki Microsoft
- ttf-mscorefonts-installer
- własne czcionki
- czcionka domyślna
- serwer
- kontener
- konwersja PDF
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Wdrażaj czcionki dla Aspose.Slides dla .NET na serwerach Linux oraz w kontenerach Docker: sprawdź, które czcionki są zastępowane, zainstaluj pakiety czcionek na Debianie, Ubuntu i Alpine, dodaj własne pliki czcionek oraz ustaw czcionkę domyślną."
---
## **Przegląd**

Aspose.Slides rysuje tekst czcionkami, które są dostępne w momencie renderowania prezentacji, na przykład przy konwersji slajdów do PDF lub obrazów. Na komputerze z systemem Windows zazwyczaj znajdują się czcionki używane w prezentacjach. Serwery i kontenery Linux zazwyczaj mają bardzo mało czcionek lub wcale ich nie mają, dlatego Aspose.Slides rysuje tekst przy użyciu czcionki zastępczej. Zastępca ma inne kształty i szerokości liter, więc wiersze mogą się zawijać inaczej, tekst może wyjść poza swój kształt, a znaki, których brak w czcionce zastępczej, nie są rysowane poprawnie. Jeśli w ogóle nie zostanie zainstalowana żadna czcionka, konwersja zatrzyma się z błędem.

Ten artykuł pokazuje, jak sprawdzić, które czcionki Aspose.Slides zastępuje, jak zainstalować czcionki w systemach Debian, Ubuntu i Alpine Linux, jak dodać własne pliki czcionek oraz jak ustawić czcionkę, która ma być używana, gdy czcionka jest nieobecna. Przykłady uruchamiane są w Dockerze na oficjalnych obrazach .NET, tak jak w [Run Aspose.Slides for .NET in Docker](/slides/pl/net/how-to-run-aspose-slides-in-docker/). Polecenia pakietów to instrukcje Dockerfile; na serwerze Linux uruchom te same polecenia jako root.

Informacje na temat samego API czcionek, takich jak osadzanie czcionek w prezentacji oraz reguły zastępowania i awaryjnego użycia, znajdziesz w [PowerPoint Fonts](/slides/pl/net/powerpoint-fonts/).

## **Sprawdź, które czcionki są zastępowane**

Poniższa aplikacja konsolowa raportuje czcionki, które Aspose.Slides zastępuje w bieżącym środowisku. Utwórz folder o nazwie *FontCheck* i dodaj do niego poniższe pliki.

*FontCheck.csproj* odwołuje się do [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), pakietu dla Debiana i Ubuntu. Kopiuje także pliki opcjonalnego folderu *fonts* do wyjścia aplikacji; sekcja [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) korzysta z tego folderu.

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

*Program.cs* dodaje jedną ramkę tekstową na nazwę czcionki do slajdu i przypisuje czcionkę za pomocą właściwości [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/). Nazwy czcionek pochodzą z linii poleceń; bez argumentów aplikacja sprawdza czcionki Calibri, Arial i Times New Roman. Wypisuje foldery, w których Aspose.Slides szuka czcionek ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), renderuje slajd do *output/fonts.pdf* i wypisuje zastąpienia zgłoszone przez [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/). Dwa opcjonalne kroki na początku, ładowanie folderu *fonts* oraz odczyt zmiennej `DEFAULT_FONT`, są wyjaśnione później w tym artykule.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Czcionki do sprawdzenia: argumenty wiersza poleceń lub trzy popularne czcionki Office.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Wczytaj pliki czcionek z folderu fonts znajdującego się obok aplikacji, jeśli taki istnieje.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Użyj czcionki określonej w zmiennej środowiskowej DEFAULT_FONT, jeśli jest ustawiona, dla tekstu, którego czcionka jest brakująca.
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

*.dockerignore* trzyma wyniki lokalnego budowania poza kontekstem budowania:

```text
bin/
obj/
output/
```

*Dockerfile* buduje aplikację przy użyciu obrazu .NET SDK i uruchamia ją na obrazie .NET Runtime. Etap runtime instaluje `libfontconfig1`, którego wymaga Aspose.Slides.NET6.CrossPlatform, oraz czcionki DejaVu. [Run Aspose.Slides for .NET in Docker](/slides/pl/net/how-to-run-aspose-slides-in-docker/) wyjaśnia każdą instrukcję.

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

Zbuduj obraz i uruchom sprawdzenie:

```bash
docker build -t font-check .
docker run --rm font-check
```

Obraz zawiera tylko czcionki DejaVu, więc wszystkie trzy czcionki są zamieniane na DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Aby sprawdzić czcionki własnych prezentacji, przekaż ich nazwy jako argumenty, np. `docker run --rm font-check "Segoe UI" Consolas`. Aby skopiować *output/fonts.pdf* z kontenera, użyj poleceń opisanych w [Copy the Output to Your Machine](/slides/pl/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Zainstaluj czcionki w Debianie i Ubuntu**

### **Microsoft Core Fonts**

Pakiet `ttf-mscorefonts-installer` pobiera i instaluje podstawowe czcionki Microsoftu dla sieci, wśród których są Arial, Times New Roman, Courier New, Verdana, Georgia i Trebuchet MS. Czcionki są licencjonowane na podstawie umowy EULA Microsoftu, a pakiet instaluję je dopiero po akceptacji EULA. Budowanie obrazu Docker nie może odpowiedzieć na monit, więc instalator odrzuca EULA i nie instaluje czcionek, podczas gdy `apt-get install` wciąż zgłasza sukces. Zaakceptuj EULA przy pomocy `debconf-set-selections` **przed** instalacją pakietu.

W *Dockerfile* zamień instrukcję `RUN` instalującą pakiety w etapie runtime na:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Zbuduj obraz i ponownie uruchom sprawdzenie tymi samymi dwoma poleceniami. Arial i Times New Roman są teraz zainstalowane:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, domyślna czcionka prezentacji tworzonej przez Aspose.Slides, nie jest jedną z czcionek podstawowych, więc nadal jest zamieniana. Zobacz [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

W Debianie pakiet znajduje się w komponencie repozytorium `contrib`, który obrazy Debian nie włączają domyślnie; obrazy .NET 8 i .NET 9 opierają się na Debianie 12. Włącz `contrib` w tej samej instrukcji:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Obrazy .NET 10 oparte na Ubuntu już domyślnie włączają `multiverse`, komponent Ubuntu zawierający ten pakiet.

### **Inne pakiety czcionek**

Debian i Ubuntu udostępniają także wolne czcionki, na przykład:

| Pakiet | Czcionki |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif i Mono, o tych samych metrykach co Arial, Times New Roman i Courier New |
| `fonts-crosextra-carlito` | Carlito, o tych samych metrykach co Calibri |
| `fonts-crosextra-caladea` | Caladea, o tych samych metrykach co Cambria |

Instaluj je przy pomocy `apt-get install` w tej samej instrukcji `RUN`. Aspose.Slides.NET6.CrossPlatform nie stosuje aliasów czcionek z konfiguracji Linuxa: po zainstalowaniu `fonts-liberation` tekst w Arial nadal jest rysowany ogólną czcionką zastępczą, a nie Liberation Sans. Aby użyć czcionki kompatybilnej metrycznie zamiast brakującej, ustaw ją jako [czcionkę domyślną](#set-a-default-font-for-missing-fonts) lub dodaj [regułę zastępowania czcionek](/slides/pl/net/font-substitution/).

## **Dodaj własne pliki czcionek**

Czcionki, które dystrybucje nie pakują, takie jak czcionki Twojej organizacji lub inne czcionki, na które masz licencję używania na serwerze, można dodać jako pliki czcionek. Umieść pliki czcionek, np. pliki *.ttf*, w folderze o nazwie *fonts* wewnątrz folderu *FontCheck*. Przykłady poniżej używają plików Carlito, czcionki o tych samych metrykach co Calibri, które możesz pobrać z [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Zainstaluj czcionki w systemowym folderze czcionek**

Aspose.Slides odczytuje czcionki z folderów wypisanych w linii `Font folders`. Aby zainstalować czcionki dla każdej aplikacji w obrazie, skopiuj je do */usr/local/share/fonts*, folderu przeznaczonego na lokalnie zainstalowane czcionki. Dodaj tę instrukcję do etapu runtime w *Dockerfile*, po instrukcji `RUN` instalującej pakiety:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Wczytaj czcionki z folderu aplikacji**

Zamiast instalować czcionki w obrazie, możesz dołączyć je do aplikacji i wczytać przy pomocy [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/). Czcionki będą wtedy dostępne wyłącznie dla Aspose.Slides i będą dystrybuowane razem z aplikacją. *FontCheck* robi to w następujący sposób: *FontCheck.csproj* kopiuje folder *fonts* do wyjścia aplikacji, a *Program.cs* przekazuje ten folder do `LoadExternalFonts` przed utworzeniem prezentacji. [Custom Font](/slides/pl/net/custom-font/) opisuje inne sposoby dostarczania czcionek, np. wczytywanie ich z pamięci.

Przebuduj obraz, a następnie sprawdź Calibri i Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Folder aplikacji pojawia się teraz wśród folderów czcionek, a Carlito nie jest już zastępowany:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Ustaw czcionkę domyślną dla brakujących czcionek**

Gdy czcionka jest nieobecna, Aspose.Slides używa własnej czcionki zastępczej. Aby wybrać ją samodzielnie, ustaw właściwość [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) klasy [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) i przekaż opcje do konstruktora [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). *FontCheck* odczytuje nazwę czcionki ze zmiennej środowiskowej `DEFAULT_FONT`. Z wczytanym Carlito użyj go dla brakujących czcionek:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri jest teraz rysowany przy użyciu Carlito, którego znaki mają takie same szerokości jak w Calibri, więc tekst zachowuje podziały wierszy:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Czcionka domyślna zastępuje każdą brakującą czcionkę. Aby mapować poszczególne czcionki, np. Arial na Liberation Sans i Calibri na Carlito, użyj [reguł zastępowania czcionek](/slides/pl/net/font-substitution/). Reguły zmieniają renderowany wynik, ale `GetSubstitutions` ich nie odzwierciedla, więc sprawdzaj czcionki w pliku wyjściowym. Dla tekstu azjatyckiego ustaw także [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/); zobacz [Default Font](/slides/pl/net/default-font/).

## **Zainstaluj czcionki w Alpine Linux**

W Alpine Linux użyj pakietu Aspose.Slides.NET; [Run on Alpine Linux](/slides/pl/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) opisuje zmiany w projekcie. Wprowadź te same zmiany w *FontCheck*: zamień referencję pakietu, dodaj instrukcję `SetSwitch` do *Program.cs* i użyj tego etapu runtime, który również instaluje czcionki Microsoft Core Fonts:

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

`update-ms-fonts` pobiera i instaluje te same czcionki Microsoft Core Fonts, co pakiet dla Debiana i Ubuntu, a ich EULA ma taką samą zasadę akceptacji. `fc-cache` aktualizuje pamięć podręczną czcionek.

W Linuxie z Aspose.Slides.NET biblioteka konfiguracyjna czcionek (fontconfig) wybiera zastępcę dla brakującej czcionki, a `GetSubstitutions` go nie zgłasza, więc *FontCheck* wypisuje `No font substitutions.` Aby zobaczyć, której czcionki użyto dla danej nazwy, zapytaj fontconfig w kontenerze:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Po zainstalowaniu czcionek Microsoft Core Fonts, dla Arial używany jest Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Bez nich, gdy instrukcja `RUN` instaluje tylko `icu-libs libgdiplus font-dejavu`, to samo polecenie wypisuje:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Dlaczego prezentacja wygląda inaczej po konwersji na serwerze?**

Serwer nie posiada czcionek używanych w prezentacji, więc Aspose.Slides rysuje tekst czcionką zastępczą, której litery mają inne szerokości. Uruchom *FontCheck* z nazwami czcionek z prezentacji, aby zobaczyć, które czcionki są zastępowane, a następnie zainstaluj te czcionki lub wczytaj je z folderu aplikacji.

**Budowa zainstalowała ttf-mscorefonts-installer, ale Arial jest nadal zastępowany. Dlaczego?**

EULA nie została zaakceptowana przed instalacją pakietu, więc instalator pominął czcionki. Dodaj polecenie `debconf-set-selections` przed `apt-get install`, jak pokazano w sekcji [Microsoft Core Fonts](#microsoft-core-fonts), i przebuduj obraz.

**Czy komputer otwierający plik PDF potrzebuje tych czcionek?**

Nie. W tych przykładach PDF zawiera czcionki użyte do renderowania tekstu, więc wygląda tak samo na każdym komputerze. Czcionki są potrzebne wyłącznie tam, gdzie Aspose.Slides renderuje prezentację.