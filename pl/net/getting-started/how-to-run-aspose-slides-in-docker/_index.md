---  
title: Uruchom Aspose.Slides for .NET w Dockerze  
linktitle: Docker  
type: docs  
weight: 140  
url: /pl/net/how-to-run-aspose-slides-in-docker/  
keywords:  
- Docker  
- Dockerfile  
- Kontener Docker  
- budowa wieloetapowa  
- obraz kontenera  
- Linux  
- Ubuntu  
- Alpine  
- libfontconfig  
- libgdiplus  
- czcionki  
- konwersja PDF  
- PowerPoint  
- prezentacja  
- .NET  
- C#  
- Aspose.Slides  
description: "Zbuduj i uruchom konsolową aplikację Aspose.Slides for .NET w Dockerze: wieloetapowy Dockerfile na oficjalnych obrazach .NET, potrzebne biblioteki i czcionki Linux oraz sposób kopiowania wygenerowanych plików na twój komputer."  
---
## **Przegląd**

Ten artykuł pokazuje, jak uruchomić Aspose.Slides for .NET w kontenerze Docker. Tworzysz małą aplikację konsolową, która tworzy prezentację z polem tekstowym i konwertuje ją na PDF, pakuje ją przy użyciu wieloetapowego Dockerfile‑a na oficjalnych obrazach .NET firmy Microsoft, uruchamia ją i kopiuje wygenerowane pliki na swój komputer. Artykuł zawiera także listę bibliotek systemowych Linux i czcionek, których potrzebuje Aspose.Slides w kontenerze, oraz wariant dla Alpine Linux.

Wymagany jest tylko Docker. SDK .NET jest częścią obrazu budowania, więc nie musisz go instalować. Aby zainstalować Docker, zobacz [Pobierz Docker](https://docs.docker.com/get-started/get-docker/).

## **Wybierz pakiet i obraz bazowy**

Domyślne obrazy kontenerów .NET 10 opierają się na Ubuntu 24.04. Na tych obrazach użyj pakietu [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Wymaga on biblioteki `fontconfig`, a obraz środowiska uruchomieniowego .NET nie zawiera ani tej biblioteki, ani żadnych czcionek, więc Dockerfile w tym artykule instaluje oba elementy.

Aspose.Slides.NET6.CrossPlatform nie działa na Alpine Linux. Dla obrazów opartych na Alpine użyj pakietu [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) wraz z `libgdiplus`, jak opisano w sekcji [Uruchom na Alpine Linux](#run-on-alpine-linux). [Instalacja](/slides/pl/net/installation/) porównuje oba pakiety.

## **Utwórz projekt**

Utwórz folder o nazwie *HelloSlidesDocker* i dodaj do niego następujące trzy pliki.

*HelloSlidesDocker.csproj* opisuje aplikację konsolową dla .NET 10, wersję obrazów kontenerów używaną poniżej oraz odwołanie do Aspose.Slides.NET6.CrossPlatform. Ustaw wersję pakietu na najnowszą dostępną na [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

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

*Program.cs* tworzy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), dodaje prostokąt z tekstem do pierwszego slajdu i zapisuje prezentację dwa razy przy użyciu metody [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/): jako PPTX i jako PDF. Oba pliki trafiają do folderu *output* w katalogu roboczym. Aplikacja wypisuje następnie czcionki, które zostały zastąpione podczas renderowania PDF, korzystając z [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/), abyś mógł zobaczyć, czy kontener posiada czcionki używane w prezentacji.

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

*.dockerignore* wyklucza foldery *bin* i *obj* z lokalnego builda oraz wyniki wcześniejszych uruchomień z kontekstu budowania Docker, tak aby obraz był tworzony wyłącznie z plików źródłowych.

```text
bin/
obj/
output/
```

## **Napisz plik Dockerfile**

Dodaj plik o nazwie *Dockerfile* do tego samego folderu:

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

Plik ma dwa etapy:

- **Etap budowania** rozpoczyna się od obrazu .NET SDK. Kopiuje najpierw plik projektu i przywraca pakiety NuGet, dzięki czemu Docker ponownie używa tej warstwy, dopóki plik projektu się nie zmieni. Następnie kopiuje kod źródłowy i publikuje aplikację do */app*.
- **Etap uruchomieniowy** rozpoczyna się od mniejszego obrazu .NET runtime, który nie zawiera SDK, i kopiuje tylko opublikowaną aplikację. Instaluje dwa pakiety:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform ładuje tę bibliotekę przy starcie. Bez niej aplikacja kończy działanie z `DllNotFoundException` wskazującym na `libfontconfig.so.1`.
  - `fonts-dejavu-core`: obraz runtime nie zawiera żadnych czcionek, a Aspose.Slides wymaga przynajmniej jednej zainstalowanej czcionki do rysowania tekstu; bez czcionek konwersja kończy się `InvalidOperationException: Cannot find any fonts installed on the system.` Tekst w niezainstalowanych czcionkach jest rysowany zamiennikiem. Czcionki DejaVu to mały zestaw, który umożliwia renderowanie tekstu; aby renderować prezentacje z czcionkami, w których zostały zaprojektowane, zobacz [Wdrażanie czcionek](/slides/pl/net/deploy-fonts/).

  `--no-install-recommends` oraz usunięcie list pakietów utrzymują obraz małym. Ostatnie linie tworzą folder *output*, nadają go nie‑rootowemu użytkownikowi `app` definiowanemu w oficjalnych obrazach .NET (jego identyfikator znajduje się w zmiennej `APP_UID`) i uruchamiają aplikację jako ten użytkownik.

W przypadku aplikacji ASP.NET Core rozpocznij etap uruchomieniowy od `mcr.microsoft.com/dotnet/aspnet:10.0`. Opiera się on na tym samym obrazie Ubuntu, więc potrzebne są te same pakiety.

## **Zbuduj i uruchom kontener**

Otwórz terminal w folderze *HelloSlidesDocker*. Zbuduj obraz, a następnie uruchom z niego kontener:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Pierwsze budowanie pobiera obrazy bazowe i pakiety NuGet, więc trwa dłużej niż kolejne buildy. Kontener uruchamia aplikację i kończy działanie. Wypisuje:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Pierwsza linia pokazuje, że tekst używa czcionki Calibri, domyślnej czcionki nowej prezentacji, i że Calibri nie jest zainstalowana w obrazie, więc Aspose.Slides narysował tekst czcionką DejaVu Sans. Tekst w PDF jest prawdziwym, zaznaczalnym tekstem w tej czcionce. Bez licencji Aspose.Slides dodaje również znak wodny oceny do każdego zapisanego slajdu; zobacz [Licencjonowanie](/slides/pl/net/licensing/).

## **Skopiuj wyniki na swój komputer**

Pliki znajdują się w folderze */app/output* zatrzymanego kontenera. Skopiuj je do folderu *output* na swoim komputerze, a następnie usuń kontener:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Oba polecenia działają tak samo w Bash, PowerShell i w wierszu poleceń systemu Windows.

W systemie Linux możesz zamiast tego zamontować folder swojego komputera w kontenerze, aby aplikacja zapisywała pliki bezpośrednio tam:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Opcja `--user` uruchamia aplikację z Twoim identyfikatorem użytkownika i grupy, dzięki czemu może zapisywać do utworzonego folderu i pliki należą do Ciebie. `--rm` usuwa kontener po jego zakończeniu.

## **Uruchom na Alpine Linux**

Aby uruchomić aplikację w obrazie opartym na Alpine, przełącz się na pakiet Aspose.Slides.NET i zmień etap uruchomieniowy. Etap budowania pozostaje bez zmian.

1. W *HelloSlidesDocker.csproj* zamień odwołanie do pakietu:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. W *Program.cs* dodaj poniższą instrukcję po dyrektywach `using`, przed pierwszym wywołaniem Aspose.Slides. Włącza ona obsługę System.Drawing dla Linuksa, z której korzysta Aspose.Slides.NET:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. W *Dockerfile* zamień etap uruchomieniowy (wszystko od drugiej linii `FROM`) na:

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

Etap Alpine instaluje trzy pakiety i zmienia jedną opcję:

- `libgdiplus` to biblioteka graficzna, której Aspose.Slides.NET używa w Linuksie.
- `font-dejavu` dostarcza czcionki. Bez żadnej czcionki konwersja kończy się `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` oraz `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` zapewniają dane kulturowe. Obrazy .NET na Alpine działają domyślnie w trybie globalizacji‑invariant, a w tym trybie Aspose.Slides przerywa działanie z `CultureNotFoundException` dla `en-US`.

Zbuduj, uruchom i skopiuj wyniki takimi samymi poleceniami jak powyżej. Na tym obrazie aplikacja wypisuje tylko linię `Saved`: z Aspose.Slides.NET w Linuksie fontconfig wybiera zamiennik dla brakującej czcionki, a [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) go nie wyświetla. [Wdrażanie czcionek](/slides/pl/net/deploy-fonts/) pokazuje, jak sprawdzić, której czcionki użyto.

## **FAQ**

**Aplikacja kończy działanie z komunikatem "Unable to load shared library 'libaspose.slides.drawing.capi…'". Co jest brakujące?**

Na obrazach Ubuntu i Debian brakuje pakietu `libfontconfig1`; komunikat wymienia `libfontconfig.so.1` jako nieodnaleziony plik. Na Alpine Linux komunikat oznacza, że używany jest Aspose.Slides.NET6.CrossPlatform; przełącz się na Aspose.Slides.NET, jak opisano w sekcji [Uruchom na Alpine Linux](#run-on-alpine-linux).

**Dlaczego tekst w PDF ma inną czcionkę niż w PowerPoint?**

Czcionki użyte w prezentacji nie są zainstalowane w obrazie, więc Aspose.Slides rysuje tekst zamiennikiem. Wyjście aplikacji podaje każdą zastąpioną czcionkę. [Wdrażanie czcionek](/slides/pl/net/deploy-fonts/) wyjaśnia, jak zainstalować czcionki w obrazie lub załadować je z katalogu aplikacji.

**Czy potrzebuję .NET SDK na moim komputerze?**

Nie. Etap budowania kompiluje aplikację wewnątrz obrazu SDK. SDK jest potrzebne tylko wtedy, gdy chcesz budować i uruchamiać aplikację poza Dockerem; zobacz [Instalacja](/slides/pl/net/installation/).