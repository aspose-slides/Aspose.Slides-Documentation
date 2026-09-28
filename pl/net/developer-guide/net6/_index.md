---
title: Pakiet wieloplatformowy dla .NET 6 i nowszych
linktitle: Pakiet wieloplatformowy
type: docs
weight: 235
url: /pl/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- wieloplatformowy
- obsługa .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, kiedy używać pakietu Aspose.Slides.NET6.CrossPlatform: dlaczego istnieje, na jakich platformach działa i czego potrzebuje w systemie Linux zamiast libgdiplus."
---
## **Wprowadzenie**

Aspose.Slides for .NET jest publikowane jako dwa pakiety NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) rysuje slajdy przy użyciu biblioteki Microsoft System.Drawing.Common. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) rysuje je natomiast własnym silnikiem graficznym. Ten artykuł wyjaśnia, dlaczego istnieje drugi pakiet, gdzie może być używany, czego potrzebuje w systemie Linux oraz jak współistnieje z System.Drawing.Common w jednym projekcie.

## **Dlaczego oddzielny pakiet**

Od .NET 6 firma Microsoft obsługuje System.Drawing.Common [tylko w systemie Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). W rezultacie w systemie Linux Aspose.Slides.NET wymaga przełącznika `System.Drawing.EnableUnixSupport` oprócz biblioteki `libgdiplus`, i tam kończy się niepowodzeniem, jeśli projekt odwołuje się do System.Drawing.Common w wersji 7 lub wyższej. [Wymagania systemowe](/slides/pl/net/system-requirements/) opisują te warunki.

Aspose.Slides.NET6.CrossPlatform nie używa System.Drawing.Common ani `libgdiplus`. Jego silnik graficzny to natywna biblioteka zawarta w pakiecie w jednej wersji dla każdej obsługiwanej platformy. Oba pakiety udostępniają te same przestrzenie nazw i klasy Aspose.Slides, więc przejście z jednego na drugi zmienia tylko odwołanie do pakietu, a nie kod.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafika | System.Drawing.Common | Natywny silnik graficzny zawarty w pakiecie |
| Docelowe frameworki | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Wymagania Linux | `libgdiplus` i przełącznik `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Obsługiwane | Nieobsługiwane |

## **Obsługiwane platformy**

Aspose.Slides.NET6.CrossPlatform działa z .NET 6 i nowszymi wersjami na następujących platformach:

- **Windows**: x86 i x64. Biblioteka natywna używa środowiska uruchomieniowego Microsoft Visual C++; zobacz [Wymagania systemowe](/slides/pl/net/system-requirements/).
- **Linux**: x64 z glibc 2.23 lub nowszym oraz ARM64 z glibc 2.39 lub nowszym.
- **macOS**: x64 (Intel) i ARM64 (Apple silicon).

Nie działa na Windows ARM64, na Alpine Linux ani innych dystrybucjach opartych na musl zamiast glibc, ani na dystrybucjach z starszą glibc, takich jak CentOS 7. W takich systemach użyj Aspose.Slides.NET.

## **Instalacja w systemie Linux**

W systemie Linux pakiet wymaga biblioteki `fontconfig`, ale nie `libgdiplus`. Na Debianie i Ubuntu zainstaluj `fontconfig`, a następnie dodaj pakiet do swojego projektu:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Na Debianie i Ubuntu pakiet `libfontconfig1` instaluję także czcionki DejaVu, więc tekst jest renderowany bez dodatkowych pakietów czcionek. Bez `fontconfig` tworzenie [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) kończy się `TypeInitializationException`, którego wewnętrzny `DllNotFoundException` informuje, że nie można otworzyć `libfontconfig.so.1`. [Wymagania systemowe](/slides/pl/net/system-requirements/) zawierają krótki program sprawdzający konfigurację.

## **Hosty w chmurze i kontenery**

Ponieważ nie potrzebuje `libgdiplus`, Aspose.Slides.NET6.CrossPlatform jest pakietem do użycia na hostach Linux, gdzie nie można zainstalować `libgdiplus`. Nadal wymaga jednak `fontconfig` i czcionek, które mogą nie być obecne w minimalnych obrazach bazowych. Przykładowo obraz bazowy AWS Lambda dla .NET 8 nie zawiera żadnego z nich. W obrazie kontenera zbudowanym na tym obrazie uruchom `dnf install -y fontconfig`, co także zainstaluje czcionki Noto Sans.

Poradniki dotyczące konkretnych platform chmurowych znajdziesz w [Aspose.Slides on Cloud Platforms](/slides/pl/net/slides-on-cloud-platforms/).

## **Używanie System.Drawing.Common w tym samym projekcie (CS0433)**

Projekt, który używa Aspose.Slides.NET6.CrossPlatform, może również odwoływać się do System.Drawing.Common, bezpośrednio lub przez inny pakiet. Aktualna wersja Aspose.Slides nie udostępnia publicznych typów w przestrzeniach nazw `System`, więc dwie biblioteki nie kolidują i możesz importować przestrzenie nazw `Aspose.Slides` i `System.Drawing` w tym samym pliku.

Jeśli kompilator zgłasza błąd CS0433, ponieważ typ taki jak `Image` lub `Graphics` istnieje zarówno w Aspose.Slides, jak i w System.Drawing.Common, Twój projekt używa starszej wersji Aspose.Slides. Zaktualizuj pakiet do najnowszej wersji. Aspose.Slides zwraca renderowane obrazy jako obiekty [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), opisane w [Modern API](/slides/pl/net/modern-api/).

## **FAQ**

**Czy muszę zmieniać kod przy przełączaniu z Aspose.Slides.NET na Aspose.Slides.NET6.CrossPlatform?**

Nie. Oba pakiety udostępniają te same przestrzenie nazw i klasy Aspose.Slides, więc wystarczy zamienić odwołanie do pakietu. Aspose.Slides.NET6.CrossPlatform nie wymaga przełącznika `System.Drawing.EnableUnixSupport`. Dodaj tylko jeden z dwóch pakietów do projektu.

**Czy mogę używać Aspose.Slides.NET6.CrossPlatform w projekcie .NET Framework?**

Nie. Pakiet docelowy jest tylko .NET 6 i nowsze. Dla .NET Framework 4.6.2 i późniejszych użyj Aspose.Slides.NET.