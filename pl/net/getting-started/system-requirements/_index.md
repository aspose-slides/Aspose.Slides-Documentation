---
title: Wymagania systemowe
type: docs
weight: 60
url: /pl/net/system-requirements/
keywords:
- wymagania systemowe
- obsługiwane platformy
- docelowe frameworki
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Sprawdź, czego potrzebuje Aspose.Slides dla .NET przed jego instalacją: frameworki, które docelowo obsługuje każdy pakiet NuGet, obsługiwane systemy operacyjne i procesory oraz biblioteki i czcionki wymagane przez Linux."
---
## **Wprowadzenie**

Aspose.Slides dla .NET jest biblioteką samodzielną: nie wymaga Microsoft PowerPoint ani Microsoft Office. Jest publikowana jako dwa pakiety NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) i [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Oba dostarczają te same przestrzenie nazw i klasy Aspose.Slides; różnią się docelowymi frameworkami oraz sposobem rysowania slajdów, co decyduje o tym, gdzie działają i czego potrzebują.

Ten artykuł wymienia wersje .NET i platformy obsługiwane przez każdy pakiet oraz biblioteki systemowe i czcionki wymagane przez Linux, a kończy się krótkim programem sprawdzającym konfigurację. Aby dodać pakiet do projektu, zobacz [Installation](/slides/pl/net/installation/).

## **Obsługiwane wersje .NET**

Każdy pakiet zawiera jedną kompilację Aspose.Slides dla każdego docelowego frameworka, a NuGet wybiera kompilację pasującą do docelowego frameworka Twojego projektu.

| Pakiet | Frameworki docelowe w pakiecie | Twój projekt może celować w |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 lub nowszy; .NET 6 lub nowszy, w tym .NET 8, .NET 9 i .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 lub nowszy, w tym .NET 8, .NET 9 i .NET 10 |

Komponent `netstandard2.0` pozwala bibliotece klas .NET Standard 2.0 odwoływać się do Aspose.Slides.NET. Aplikacja korzystająca z takiej biblioteki uruchamia kompilację pasującą do własnego docelowego frameworka: aplikacja .NET 8, na przykład, uruchamia kompilację `net6.0`.

## **Obsługiwane systemy operacyjne i procesory**

**Aspose.Slides.NET** zawiera wyłącznie kod zarządzany niezależny od procesora (AnyCPU), więc działa na architekturze procesora środowiska .NET, które go ładuje. Rysuje slajdy przy użyciu biblioteki System.Drawing.Common firmy Microsoft, którą Microsoft obsługuje [tylko w systemie Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). W systemie Linux Aspose.Slides.NET wymaga więc biblioteki `libgdiplus` oraz przełącznika startowego, opisanego w sekcji [Linux](#linux). Działa na dystrybucjach Linuxa, które dostarczają `libgdiplus`, takich jak Debian, Ubuntu i Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** rysuje slajdy własnym silnikiem graficznym. Silnik jest natywną biblioteką, którą pakiet zawiera w jednej kompilacji na każdą platformę, więc pakiet działa wyłącznie na następujących platformach:

| System operacyjny | Procesory | Uwagi |
|---|---|---|
| Windows | x86, x64 | Windows na ARM64 nie jest obsługiwany. |
| Linux | x64, ARM64 | Wymaga glibc 2.23 lub nowszego na x64 oraz glibc 2.39 lub nowszego na ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform nie działa na Alpine Linux ani na innych dystrybucjach opartych na musl zamiast glibc, ani na dystrybucjach z starszą wersją glibc, takiej jak CentOS 7. W takich systemach użyj Aspose.Slides.NET.

Natywna biblioteka Aspose.Slides.NET6.CrossPlatform używa środowiska uruchomieniowego Microsoft Visual C++ (*MSVCP140.dll* i *VCRUNTIME140.dll*, plus *VCRUNTIME140_1.dll* na x64). Jeśli te pliki są nieobecne na docelowym komputerze, zainstaluj [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Oba pakiety wymagają dodatkowych bibliotek systemowych w systemie Linux. Bez nich pierwszy przykład w sekcji [Create Presentations](/slides/pl/net/create-presentation/) kończy się wyjątkiem zamiast zapisać plik. Poniższe polecenia dotyczą Debiana i Ubuntu; w tych dystrybucjach każda biblioteka dodatkowo instaluje czcionki DejaVu (`fonts-dejavu-core`), więc tekst jest renderowany bez dodatkowych pakietów czcionek.

### **Aspose.Slides.NET6.CrossPlatform**

Biblioteka Linux tego pakietu wymaga biblioteki `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Bez niej tworzenie [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) kończy się `TypeInitializationException`, którego wewnętrzny `DllNotFoundException` informuje, że nie można otworzyć `libfontconfig.so.1`.

Minimalne obrazy bazowe mogą również nie zawierać `fontconfig`. Na przykład obraz bazowy AWS Lambda dla .NET 8 nie zawiera ani `fontconfig`, ani żadnych czcionek. W obrazie kontenera zbudowanym na tym obrazie uruchom `dnf install -y fontconfig`, co dodatkowo zainstaluje czcionki Noto Sans.

### **Aspose.Slides.NET**

Pakiet wymaga dwóch rzeczy w systemie Linux:

1. Biblioteki `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. Przełącznika `System.Drawing.EnableUnixSupport`, włączanego na początku aplikacji przed jakimkolwiek wywołaniem Aspose.Slides. W pliku *Program.cs* z instrukcjami poziomu top-level, umieść go po dyrektywach `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Bez `libgdiplus` zapisywanie prezentacji kończy się `TypeInitializationException`, którego wewnętrzny `DllNotFoundException` informuje, że nie można załadować `libgdiplus`. Bez przełącznika wewnętrzny wyjątek to `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
Przełącznik działa tylko z System.Drawing.Common 6, wersją, od której zależy Aspose.Slides.NET. Microsoft usunął go w System.Drawing.Common 7. Jeśli Twój projekt odwołuje się do System.Drawing.Common 7 lub nowszej, bezpośrednio lub poprzez inny pakiet, Aspose.Slides.NET nie działa w systemie Linux i zgłasza `PlatformNotSupportedException` nawet przy zainstalowanym `libgdiplus` i włączonym przełączniku. W takim przypadku użyj Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Na Alpine Linux użyj Aspose.Slides.NET z opisanym wyżej przełącznikiem. Obrazy Alpine zazwyczaj nie zawierają czcionek, a sam `libgdiplus` nie instaluje żadnych, więc zainstaluj `libgdiplus` wraz z co najmniej jednym pakietem czcionek. Bez czcionek zapisywanie prezentacji kończy się tym błędem:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Opcja 1: czcionki DejaVu**

Zalecaną opcją jest pakiet `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Na bieżących wydaniach Alpine, `ttf-dejavu` instaluje pakiet `font-dejavu`, który również instaluje `fontconfig` oraz narzędzia czcionkowe, od których zależy.

**Opcja 2: czcionki podstawowe Microsoft**

Jeśli Twoje prezentacje używają czcionek Microsoft takich jak Arial, Times New Roman, Courier New lub Verdana, zainstaluj zamiast tego czcionki podstawowe Microsoft. Krok `update-ms-fonts` pobiera czcionki podczas budowania obrazu, więc budowanie wymaga dostępu do internetu:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Wsparcie internacjonalizacji**

Oba pakiety potrzebują wsparcia internacjonalizacji .NET, które .NET na Linuxie zapewnia poprzez biblioteki ICU. W [globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) tworzenie [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) kończy się `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Niektóre obrazy kontenerowe włączają ten tryb. Obrazy środowiska uruchomieniowego .NET dla Alpine Linux (`runtime-deps`, `runtime` i `aspnet`) na przykład ustawiają `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` i nie zawierają ICU. W obrazie zbudowanym na nich zainstaluj ICU i wyłącz tryb:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Upewnij się również, że plik projektu nie ustawia właściwości `InvariantGlobalization` na `true`.

## **Sprawdź swoją konfigurację**

Aby sprawdzić, czy pakiet i jego wymagania są spełnione, uruchom program, który zapisuje prezentację i renderuje slajd jako obraz. Zapis i renderowanie używają biblioteki graficznej oraz czcionek, które zapewniają powyższe wymagania Linuxa.

Utwórz aplikację konsolową i dodaj pakiet zgodnie z opisem w sekcji [Installation](/slides/pl/net/installation/), zamień zawartość *Program.cs* na kod poniżej i uruchom `dotnet run`. Jeśli używasz Aspose.Slides.NET w systemie Linux, dodaj instrukcję przełącznika `System.Drawing.EnableUnixSupport` pokazanej w sekcji [Linux](#linux) po dyrektywach `using`. Program używa instrukcji top-level oraz deklaracji `using`, które wymagają C# 9 lub nowszego. Projekty targetujące .NET 6 lub nowszy używają domyślnie nowszej wersji C#, w projekcie targetującym .NET Framework dodaj `<LangVersion>latest</LangVersion>` do `PropertyGroup` w pliku projektu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Program dodaje prostokąt z tekstem do pierwszego slajdu i zapisuje prezentację jako *hello.pptx* przy użyciu metody [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Następnie renderuje slajd za pomocą [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) i zapisuje wynik jako *hello.png* przy użyciu [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) w formacie [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/). Skalowanie równe 1 renderuje jeden piksel na punkt, więc domyślny slajd 720 × 540 punktów staje się obrazem 720 × 540 pikseli, z tekstem widocznym we wnętrzu prostokąta. Bez licencji oba pliki zawierają znak wodny oceny; zobacz [Licensing](/slides/pl/net/licensing/). Jeśli brakuje któregoś wymogu, program zatrzyma się jednym z wyjątków opisanych w sekcji [Linux](#linux).

## **Narzędzia programistyczne**

Możesz budować aplikacje korzystające z Aspose.Slides przy użyciu dowolnego narzędzia obsługującego docelowy framework Twojego projektu: .NET SDK i jego interfejs wiersza poleceń `dotnet` na Windows, Linux i macOS, lub Visual Studio na Windows. [Installation](/slides/pl/net/installation/) opisuje oba rozwiązania.

## **FAQ**

**Czy potrzebuję zainstalowanego Microsoft PowerPoint do konwersji i renderowania?**

Nie, PowerPoint nie jest wymagany. Aspose.Slides jest samodzielnym silnikiem do [tworzenia](/slides/pl/net/create-presentation/), modyfikacji, [konwersji](/slides/pl/net/convert-presentation/) oraz [renderowania](/slides/pl/net/convert-powerpoint-to-png/) prezentacji.

**Który pakiet powinienem używać?**

Używaj Aspose.Slides.NET na Windows oraz Aspose.Slides.NET6.CrossPlatform na Linuxie i macOS. Na Alpine Linux, na systemach Linux z starszym glibc niż wymienione powyżej wersje oraz w projektach targetujących .NET Framework, użyj Aspose.Slides.NET. Do projektu dodaj tylko jeden z tych dwóch pakietów.

**Jakie czcionki są potrzebne do prawidłowego renderowania?**

Czcionki użyte w prezentacji, lub odpowiednie zamienniki, muszą być dostępne w systemie operacyjnym. Na Linuxie i macOS zainstaluj pakiety czcionek potrzebne Twoim prezentacjom, aby uzyskać spójne renderowanie. Na Alpine Linux zainstaluj co najmniej jeden pakiet czcionek oprócz `libgdiplus`, jak opisano w sekcji [Alpine Linux](#alpine-linux).

**Dlaczego własna czcionka jest renderowana jako zastępcza lub brakujący tekst w Linuxie?**

Jeśli plik czcionki ma niespójne lub uszkodzone wpisy w tabeli nazw, stos dopasowywania czcionek w Linuxie (FreeType/fontconfig) może wybrać nieprawidłowy rekord, co powoduje, że czcionka jest nierozpoznana. Użycie wersji czcionki z poprawionymi rekordami w tabeli nazw lub zainstalowanie spójnego zamiennika rozwiązuje problem.