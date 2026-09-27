---
title: Instalacja
type: docs
weight: 70
url: /pl/nodejs-net/installation/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- instalacja Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Zainstaluj Aspose.Slides for Node.js via .NET z npm w systemie Windows lub Linux: wymagania wstępne, nadpisanie edge-js, jednorazowe przywrócenie NuGet oraz pierwszy program tworzący prezentację."
---
## **Przegląd**

Aspose.Slides for Node.js via .NET to pakiet npm `aspose.slides.via.net`. Uruchamia bibliotekę Aspose.Slides .NET wewnątrz Node.js za pośrednictwem mostka [edge-js](https://github.com/agracio/edge-js), więc działająca instalacja wymaga zarówno Node.js, jak i .NET.

Ten artykuł prowadzi Cię od czystej maszyny do pierwszego programu, który tworzy prezentację. Są cztery kroki: utworzenie projektu z nadpisaniem edge-js, instalacja pakietu z npm, jednorazowe przywrócenie zależności .NET pakietu i uruchomienie skryptu z folderu projektu.

## **Wymagania wstępne**

- **Node.js 22 lub 24 LTS**, kompilacja x64, z [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 lub nowszy**, z [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Sam runtime .NET nie wystarczy: krok przywracania niżej wymaga SDK, tak samo mostek podczas uruchamiania skryptu. Uruchom `dotnet --list-sdks`, aby sprawdzić, które SDK są zainstalowane.
- **Tylko na Linuksie**:
  - narzędzia budowania `python3`, `make` i `g++`, ponieważ npm kompiluje edge-js podczas instalacji na Linuksie;
  - biblioteka fontconfig, którą ładuje natywna biblioteka rysująca Aspose.Slides.

  Na Debianie są to pakiety `python3`, `make`, `g++` oraz `libfontconfig1`.

Kroki w tym artykule zostały przetestowane na następujących platformach:

| Platforma | Wynik |
|---|---|
| Windows x64 z Node.js 22 lub 24 | Działa. Testowano z zainstalowanym Microsoft Visual C++ Redistributable. |
| Linux x64 z Node.js 22 lub 24, gdzie systemowy OpenSSL pochodzi z tej samej linii wersji co OpenSSL wbudowany w Node.js, np. Debian 13 | Działa. |
| Linux, gdzie dwie wersje OpenSSL różnią się, np. Debian 12 | Node.js wywołuje błąd segmentacji przy tworzeniu prezentacji. |
| macOS | Nie zweryfikowano. |

Na Linuksie porównaj dwie wersje przed rozpoczęciem. Pierwsze polecenie wypisuje wersję OpenSSL wbudowaną w Node.js; drugie wypisuje wersję systemową. Użyj systemu, w którym obie wersje zaczynają się od tych samych numerów głównych i pobocznych, np. `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Jeśli polecenie `openssl` nie zostanie znalezione, najpierw zainstaluj pakiet `openssl`.

## **Utworzenie projektu**

Utwórz folder dla swojego projektu, zainicjuj go i dodaj nadpisanie, które mówi npm, którą wersję edge-js zainstalować:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Pakiet wymaga starszej wersji edge-js, której prekompilowane binaria Windows kończą się na Node.js 20, więc bez nadpisania pierwszy skrypt na Windowsie zatrzymuje się komunikatem „The edge module has not been pre-compiled for node.js version”. Polecenie zapisuje nadpisanie w sekcji `overrides` pliku `package.json`; dodaj je przed instalacją pakietu.

## **Instalacja pakietu**

Zainstaluj Aspose.Slides for Node.js via .NET z npm:

```sh
npm install aspose.slides.via.net
```

Podczas instalacji pakiet kopiuje swoje natywne biblioteki rysujące (pliki, których nazwy zawierają `aspose.slides.drawing.capi`) do folderu projektu, obok `package.json`.

Pakiet jest również udostępniany jako archiwum ZIP na [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/). Ten artykuł opisuje instalację wyłącznie z npm.

## **Przywrócenie zależności .NET**

Pakiet zawiera zestawy .NET Aspose.Slides, ale nie 20 pakietów NuGet, od których te zestawy zależą. W czasie wykonywania .NET szuka ich w pamięci podręcznej pakietów NuGet: `%USERPROFILE%\.nuget\packages` w Windows, `~/.nuget/packages` w Linuksie lub w folderze określonym zmienną środowiskową `NUGET_PACKAGES`. Jeśli ich brak, pierwszy skrypt zatrzymuje się komunikatem „assembly specified in the dependencies manifest was not found”.

Aby wypełnić pamięć podręczną, utwórz folder o nazwie `deps` w folderze projektu i zapisz w nim następujący plik jako `deps.csproj`. Każdy element `PackageDownload` pobiera jeden pakiet w dokładnie podanej wersji; nic nie jest kompilowane.

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

Następnie przywróć go z folderu projektu:

```sh
dotnet restore deps/deps.csproj
```

Ten krok wykonujesz raz na maszynie, nie na każdy projekt: pakiety pozostają w pamięci podręcznej NuGet, a kolejne projekty na tej samej maszynie je wykorzystują. Po przywróceniu możesz usunąć folder `deps`.

## **Uruchomienie pierwszego programu**

Utwórz plik o nazwie `hello.js` w folderze projektu z następującym kodem. Tworzy on prezentację, dodaje prostokąt z tekstem „Hello, World!” do pierwszego slajdu i zapisuje wynik jako `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Nowa prezentacja zawiera jeden pusty slajd.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozycja i rozmiar podane są w punktach (1/72 cala): x, y, szerokość, wysokość.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Zwolnij obiekt .NET odpowiadający prezentacji.
    presentation.dispose();
}
```

Uruchom go z folderu projektu:

```sh
node hello.js
```

Skrypt wypisuje `Saved hello.pptx`. Otwórz `hello.pptx`, aby zobaczyć jeden slajd z wypełnionym prostokątem zawierającym tekst. Bez licencji Aspose.Slides dodaje również znak wodny oceny; zobacz [Evaluate Aspose.Slides](/slides/pl/nodejs-net/evaluate-aspose-slides/) i [Licensing](/slides/pl/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Uruchamiaj swoje skrypty z folderu projektu, tego który zawiera `package.json`. Ścieżki względne, takie jak `hello.pptx`, są rozwiązywane względem bieżącego folderu, a na niektórych maszynach skrypt uruchomiony z innego folderu nie może utworzyć prezentacji.
{{% /alert %}}

JavaScript API odzwierciedla Aspose.Slides for .NET: klasy zachowują swoje nazwy .NET, właściwości i metody używają camelCase (`Slides` staje się `slides`, `AddAutoShape` staje się `addAutoShape`), a elementy kolekcji odczytuje się za pomocą `get(index)`. Nie istnieje osobna dokumentacja API dla tego pakietu, więc używaj [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) do szczegółów klas i członków, np. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **FAQ**

**Co oznacza „The edge module has not been pre-compiled for node.js version”?**

npm zainstalował starszą wersję edge-js, o którą prosi pakiet. Dodaj nadpisanie z sekcji [Utworzenie projektu](#utworzenie-projektu) i ponownie uruchom `npm install`.

**Co oznacza „assembly specified in the dependencies manifest was not found”?**

Zależności .NET nie znajdują się w pamięci podręcznej NuGet. Ten sam błąd zgłasza również „edge.initializeClrFunc is not a function”. Postępuj zgodnie z [Przywróceniem zależności .NET](#przywrócenie-zależności-.net) raz, a następnie uruchom skrypt ponownie.

**Co oznacza „The edge native module is not available” na Linuksie?**

edge-js nie został skompilowany podczas `npm install`, np. ponieważ brakowało `python3`, `make` lub `g++`. npm nie zgłasza tego jako błąd. Zainstaluj narzędzia budowania, a potem uruchom `npm rebuild edge-js` w folderze projektu.

**Dlaczego tworzenie prezentacji kończy się pustym „Error”?**

Na Linuksie sprawdź, czy zainstalowana jest biblioteka fontconfig (`libfontconfig1` w Debianie); bez niej natywna biblioteka rysująca nie może się załadować. Na każdym systemie upewnij się także, że uruchamiasz skrypt z folderu projektu.

**Dlaczego Node.js ulega awarii z błędem segmentacji na Linuksie?**

Systemowy OpenSSL i OpenSSL wbudowany w Node.js pochodzą z różnych linii wersji. Porównaj je, jak pokazano w [Wymagania wstępne](#wymagania-wstępne) i użyj dystrybucji lub kompilacji Node.js, w której wersje się zgadzają.

**Czy muszę powtarzać przywracanie NuGet dla każdego projektu?**

Nie. Przywrócenie wypełnia pamięć podręczną NuGet dla Twojego konta użytkownika i każdy projekt na tej maszynie korzysta z tej samej pamięci podręcznej.