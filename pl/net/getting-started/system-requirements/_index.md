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
description: "Poznaj wymagania systemowe Aspose.Slides dla .NET. Zapewnij bezproblemowe wsparcie dla PowerPoint i OpenDocument w systemach Windows, Linux i macOS."
---
## **Wprowadzenie**

Aspose.Slides dla .NET nie wymaga zainstalowanego programu Microsoft PowerPoint, ponieważ Aspose.Slides jest niezależnym silnikiem do tworzenia, konwersji, układu i renderowania dokumentów Microsoft PowerPoint.

## **Obsługiwane systemy operacyjne**

Aspose.Slides dla .NET obsługuje każdy system operacyjny 32‑bitowy lub 64‑bitowy, na którym zainstalowano platformę .NET lub Mono, w tym (ale nie wyłącznie):

### **Windows**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, i inne)

### **Mac**

- Mac OS X

## **Obsługiwane platformy .NET**

Aspose.Slides dla .NET obsługuje platformy .NET i Mono:

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
- COM Interop support (COM, C++, VBScript)

### **Platforma Mono**

- Obsługa MONO na platformach MAC i Linux

## **Środowiska programistyczne**

Aspose.Slides dla .NET może być używany do tworzenia aplikacji w dowolnym środowisku programistycznym skierowanym na platformę .NET, ale następujące środowiska są explicite wspierane:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Główne wersje Aspose.Slides**

Obecnie istnieją dwie główne wersje Aspose.Slides — Aspose.Slides.NET i Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Jest to główna wersja produktu. Używa standardowego silnika graficznego .NET.  
Na platformach nie‑Windows może być konieczne zainstalowanie biblioteki `libgdiplus` oraz jej zależności.  
Przed wersją Aspose.Slides 25.3, na platformach nie‑Windows konieczne było użycie pliku DLL .NET Standard 2.0 z pakietu ZIP Aspose.Slides.  
Od wersji Aspose.Slides 25.3 pakiet NuGet można używać bezpośrednio także na systemach nie‑Windows.  
Podczas uruchamiania na systemach nie‑Windows aplikacja musi zawierać następującą linię przy starcie:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
**Od wersji 25.3 możesz używać tego pakietu na platformach obsługujących .NET, takich jak Linux aarch64 (ARM64).**

#### **Dodatkowe pakiety dla Linux Alpine**

Podczas uruchamiania Aspose.Slides dla .NET w kontenerze Alpine Linux, samo zainstalowanie `libgdiplus` może nie wystarczyć. Kontenery Alpine zazwyczaj nie zawierają czcionek domyślnie. Jeśli brak czcionek, operacje renderowania lub konwersji mogą zakończyć się błędem podobnym do:

```text
System.ArgumentException: Font '?' cannot be found
```

Aby używać Aspose.Slides na Alpine, zainstaluj `libgdiplus` wraz z co najmniej jednym pakietem czcionek.

**Opcja 1: Czcionki DejaVu**

Zalecaną opcją jest zainstalowanie pakietu ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Pakiet `ttf-dejavu` automatycznie instaluje wymagane zależności związane z czcionkami, takie jak `fontconfig`, `encodings`, `mkfontscale` i `mkfontdir`. Dla większości przypadków nie są potrzebne dodatkowe pakiety czcionek.

**Opcja 2: Microsoft Core Fonts**

Jeśli Twoje prezentacje używają czcionek specyficznych dla Microsoft, takich jak Arial, Times New Roman, Courier New lub Verdana, zainstaluj Microsoft Core Fonts zamiast tego:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Używaj tej opcji tylko wtedy, gdy przetwarzane prezentacje wymagają czcionek Microsoft. Dla większości scenariuszy prostszym i bardziej niezawodnym rozwiązaniem jest instalacja `ttf-dejavu`.

**Dodatkowe wymagania dotyczące globalizacji**

Aby włączyć właściwe wsparcie globalizacji na Alpine, zainstaluj pakiet `icu-libs` i wyłącz tryb invariantny:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Jest to wersja Aspose.Slides używająca własnego, wieloplatformowego silnika graficznego opracowanego przez zespół Aspose.Slides.  
Na platformach nie‑Windows może być wymagana biblioteka `fontconfig`.

**Obsługiwane platformy**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**Niewspierane platformy**
- *Windows 11 ARM* (ARM64) — *Obecnie nie rozważane*

{{%  alert  title="Notes"  color="info"  %}}  
Dla Linux x64 wymagana jest GLIBC 2.23+, a dla Linux ARM64 GLIBC 2.39+. Systemy takie jak CentOS 7 (GLIBC 2.14) nie są wspierane. Jeśli musisz uruchomić Aspose.Slides na CentOS 7 lub innych niekompatybilnych systemach (np. Alpine), użyj standardowego pakietu: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

### Czy potrzebuję zainstalowanego Microsoft PowerPoint do konwersji i renderowania?

Nie, PowerPoint nie jest wymagany; Aspose.Slides jest samodzielnym silnikiem do [tworzenia](/slides/pl/net/create-presentation/), modyfikowania, [konwertowania](/slides/pl/net/convert-presentation/) oraz [renderowania](/slides/pl/net/convert-powerpoint-to-png/) prezentacji.

### Jakie czcionki są potrzebne do poprawnego renderowania?

Czcionki użyte w prezentacji lub odpowiednie ich zamienniki muszą być dostępne w systemie operacyjnym. Na Linux i macOS zainstaluj popularne pakiety czcionek, aby zapewnić spójne renderowanie.

W kontenerach Alpine Linux zainstaluj co najmniej jeden pakiet czcionek oprócz `libgdiplus`. Rekomendowane minimalne ustawienie to `libgdiplus` wraz z `ttf-dejavu`. Jeśli potrzebne są czcionki Microsoft, takie jak Arial, Times New Roman, Courier New lub Verdana, użyj `msttcorefonts-installer` razem z `fontconfig`.

### Dlaczego niestandardowa czcionka renderuje się jako zamiennik lub brakujący tekst w systemie Linux?

Jeśli plik czcionki ma niezgodne lub uszkodzone wpisy w tabeli nazw, stos dopasowywania czcionek w Linux (FreeType/fontconfig) może wybrać nieprawidłowy rekord, co powoduje, że czcionka nie zostaje rozpoznana. Użycie wersji czcionki z poprawionymi rekordami nazwy lub zainstalowanie spójnego zamiennika rozwiązuje problem.