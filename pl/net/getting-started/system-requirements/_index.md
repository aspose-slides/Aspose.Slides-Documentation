---
title: Wymagania systemowe
type: docs
weight: 60
url: /pl/net/system-requirements/
keywords:
- wymagania systemowe
- system operacyjny
- instalacja
- zależności
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Poznaj wymagania systemowe Aspose.Slides dla .NET. Zapewnij płynne wsparcie dla PowerPoint i OpenDocument w systemach Windows, Linux i macOS."
---
## **Wprowadzenie**

Aspose.Slides for .NET nie wymaga zainstalowanego Microsoft PowerPoint, ponieważ Aspose.Slides jest niezależnym silnikiem tworzenia, konwersji, układu stron i renderowania dokumentów Microsoft PowerPoint.

## **Obsługiwane systemy operacyjne**

Aspose.Slides for .NET wspiera każdy 32‑bitowy lub 64‑bitowy system operacyjny, na którym zainstalowano .NET lub Mono, w tym (ale nie wyłącznie):

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine i inne)

### **Mac**

- Mac OS X

## **Obsługiwane frameworki**

Aspose.Slides for .NET wspiera frameworki .NET i Mono:

### **.NET Frameworks**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- Obsługa COM Interop (COM, C++, VBScript)

### **Mono Framework**

- MONO Support in MAC and Linux platforms

## **Środowiska programistyczne**

Aspose.Slides for .NET może być używany do tworzenia aplikacji w dowolnym środowisku programistycznym, które celuje w platformę .NET, ale następujące środowiska są explicite wspierane:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Główne kompilacje Aspose.Slides**

Obecnie istnieją dwie główne kompilacje Aspose.Slides — Aspose.Slides.NET i Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

To główna wersja produktu. Korzysta ze standardowego silnika graficznego .NET.
- Na platformach nie‑Windows może być konieczne zainstalowanie biblioteki `libgdiplus` oraz jej zależności.
- Przed wersją Aspose.Slides 25.3, na platformach nie‑Windows konieczne było użycie DLL .NET Standard 2.0 z pakietu ZIP Aspose.Slides.
- Od wersji Aspose.Slides 25.3 pakiet NuGet może być używany bezpośrednio także na systemach nie‑Windows.
- Działając na systemach nie‑Windows, Twoja aplikacja musi zawierać następującą linię przy uruchamianiu:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Od wersji 25.3 możesz używać tego pakietu na platformach obsługujących .NET, takich jak Linux aarch64 (ARM64).**

#### **Dodatkowe pakiety dla Linux Alpine**

Uruchamiając Aspose.Slides for .NET w kontenerze Alpine Linux, samo zainstalowanie `libgdiplus` może nie wystarczyć. Kontenery Alpine zazwyczaj nie zawierają czcionek domyślnie. Brak czcionek może spowodować niepowodzenie renderowania lub konwersji z błędem podobnym do:

```text
System.ArgumentException: Font '?' cannot be found
```
Aby używać Aspose.Slides na Alpine, zainstaluj `libgdiplus` razem z co najmniej jednym pakietem czcionek.

**Opcja 1: Czcionki DejaVu**

Zalecaną opcją jest instalacja pakietu ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Pakiet `ttf-dejavu` automatycznie instaluje wymagane zależności związane z czcionkami, takie jak `fontconfig`, `encodings`, `mkfontscale` i `mkfontdir`. Dla większości zastosowań nie są potrzebne dodatkowe pakiety czcionek.

**Opcja 2: Czcionki podstawowe Microsoft**

Jeśli Twoje prezentacje używają czcionek specyficznych dla Microsoftu, takich jak Arial, Times New Roman, Courier New czy Verdana, zainstaluj Microsoft Core Fonts:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Używaj tej opcji tylko wtedy, gdy przetwarzane prezentacje wymagają czcionek Microsoft. W większości scenariuszy prostszym i bardziej niezawodnym rozwiązaniem jest instalacja `ttf-dejavu`.

**Dodatkowe wymagania dotyczące globalizacji**

Aby włączyć poprawne wsparcie globalizacji na Alpine, zainstaluj pakiet `icu-libs` i wyłącz tryb invariantny:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

To wersja Aspose.Slides wykorzystująca własny, wieloplatformowy silnik graficzny opracowany przez zespół Aspose.Slides.  
Na platformach nie‑Windows może być wymagana biblioteka `fontconfig`.

**Obsługiwane platformy**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Niewspierane platformy**
- *Windows 11 ARM* (ARM64) — *Obecnie nie rozważane*

{{%  alert  title="Uwagi"  color="primary"  %}}  
Dla Linux x64 wymagany jest GLIBC 2.23+, dla Linux ARM64 — GLIBC 2.39+. Systemy takie jak CentOS 7 (GLIBC 2.14) nie są wspierane. Jeśli musisz uruchomić Aspose.Slides na CentOS 7 lub innych niekompatybilnych systemach (np. Alpine), użyj standardowego pakietu: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Czy potrzebuję zainstalowanego Microsoft PowerPoint do konwersji i renderowania?**

Nie, PowerPoint nie jest wymagany; Aspose.Slides to samodzielny silnik do [tworzenia](/slides/pl/net/create-presentation/), modyfikacji, [konwersji](/slides/pl/net/convert-presentation/) i [renderowania](/slides/pl/net/convert-powerpoint-to-png/) prezentacji.

**Jakie czcionki są potrzebne do prawidłowego renderowania?**

Czcionki użyte w prezentacji, lub ich odpowiednie zamienniki, muszą być dostępne w systemie operacyjnym. Na Linux i macOS zainstaluj popularne pakiety czcionek, aby zapewnić spójne renderowanie.

Dla kontenerów Alpine Linux zainstaluj co najmniej jeden pakiet czcionek oprócz `libgdiplus`. Minimalna zalecana konfiguracja to `libgdiplus` z `ttf-dejavu`. Jeśli wymagane są czcionki Microsoftu, takie jak Arial, Times New Roman, Courier New lub Verdana, użyj `msttcorefonts-installer` razem z `fontconfig`.

**Dlaczego niestandardowa czcionka jest renderowana jako zamiennik lub brakujący tekst w Linux?**

Jeśli plik czcionki ma niespójne lub uszkodzone wpisy w tabeli nazw, stos dopasowywania czcionek w Linux (FreeType/fontconfig) może wybrać nieprawidłowy rekord, co skutkuje brakiem rozpoznania czcionki. Użycie wersji czcionki z poprawioną tabelą nazw lub zainstalowanie spójnego zamiennika rozwiązuje problem.