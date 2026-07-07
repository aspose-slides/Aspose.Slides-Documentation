---
title: Rendszerkövetelmények
type: docs
weight: 60
url: /hu/net/system-requirements/
keywords:
- rendszerkövetelmények
- operációs rendszer
- telepítés
- függőségek
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET rendszerkövetelményeit. Biztosítsa a zökkenőmentes PowerPoint és OpenDocument támogatást Windows, Linux és macOS rendszereken."
---
## **Bevezetés**

Az Aspose.Slides for .NET nem igényli a Microsoft PowerPoint telepítését, mivel az Aspose.Slides egy független Microsoft PowerPoint dokumentumkészítő, konvertáló, oldalelrendező és megjelenítő motor.

## **Támogatott operációs rendszerek**

Az Aspose.Slides for .NET minden 32‑ vagy 64‑bit operációs rendszert támogat, amelyen telepítve van a .NET vagy a Mono keretrendszer, többek között (de nem kizárólag):

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine és egyéb)

### **Mac**

- Mac OS X

## **Támogatott keretrendszerek**

Az Aspose.Slides for .NET a .NET és a Mono keretrendszereket támogatja:

### **.NET keretrendszerek**

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
- COM Interop támogatás (COM, C++, VBScript)

### **Mono keretrendszer**

- MONO támogatás MAC és Linux platformokon

## **Fejlesztői környezetek**

Az Aspose.Slides for .NET bármely .NET célplatformra fejlesztett alkalmazásban használható, de a következő környezetek kifejezetten támogatottak:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides fő buildjei**

Jelenleg két fő build létezik az Aspose.Slides‑ből – az Aspose.Slides.NET és az Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Ez a termék fő verziója. A standard .NET grafikus motor használatával működik.
- Nem Windows platformokon a `libgdiplus` könyvtár és függőségeinek telepítése lehet szükséges.
- Az Aspose.Slides 25.3 előtti verziók esetén, nem Windows platformokon a .NET Standard 2.0 DLL‑t a Aspose.Slides ZIP‑csomagból kellett használni.
- A 25.3‑as verziótól a NuGet‑csomag közvetlenül használható nem Windows rendszereken is.
- Nem Windows rendszereken az alkalmazásnak a következő sort kell tartalmaznia indításkor:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **A 25.3‑as verziótól kezdve a csomag használható olyan platformokon, amelyek támogatják a .NET‑et, például Linux aarch64 (ARM64).**

#### **További csomagok Linux Alpine‑hoz**

Amikor az Aspose.Slides for .NET‑et Alpine Linux konténerben futtatja, a `libgdiplus` önmagában nem biztos, hogy elegendő. Az Alpine konténerek általában nem tartalmaznak betűtípusokat alapértelmezésként. Ha nincs elérhető betűtípus, a megjelenítés vagy a konvertálás hibával leállhat, hasonlóan az alábbihoz:

```text
System.ArgumentException: Font '?' cannot be found
```
Az Aspose.Slides Alpine‑on való használatához telepítse a `libgdiplus`‑t legalább egy betűtípus‑csomaggal együtt.

**1. lehetőség: DejaVu betűtípusok**

Az ajánlott megoldás a `ttf-dejavu` csomag telepítése:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

A `ttf-dejavu` csomag automatikusan telepíti a szükséges, betűtípus‑függő csomagokat, mint a `fontconfig`, `encodings`, `mkfontscale` és `mkfontdir`. A legtöbb esetben nincs szükség további betűtípus‑csomagra.

**2. lehetőség: Microsoft Core Fonts**

Ha a prezentációk Microsoft‑specifikus betűtípusokat (pl. Arial, Times New Roman, Courier New vagy Verdana) használnak, telepítse a Microsoft Core Fonts csomagot:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Ezt a lehetőséget csak akkor válassza, ha a feldolgozott prezentációk Microsoft‑betűtípusokat igényelnek. A legtöbb szituációban a `ttf-dejavu` egyszerűbb és megbízhatóbb.

**További követelmények a globalizációhoz**

Az Alpine‑on a megfelelő globalizációs támogatáshoz telepítse az `icu-libs` csomagot, és tiltsa le az invariáns módot:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Ez az Aspose.Slides változat egy egyedi, a Aspose.Slides csapata által kifejlesztett keresztplatformos grafikus motorra épül. Nem Windows platformokon a `fontconfig` könyvtár szükséges lehet.

**Támogatott platformok**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nem támogatott platformok**
- *Windows 11 ARM* (ARM64) — *Jelenleg nem kerül megfontolásra*

{{%  alert  title="Megjegyzések"  color="primary"  %}}  
Linux x64 esetén GLIBC 2.23+ szükséges; Linux ARM64 esetén GLIBC 2.39+ szükséges. Olyan rendszerek, mint a CentOS 7 (GLIBC 2.14), nem támogatottak. Ha CentOS 7‑en vagy más inkompatibilis rendszeren (például Alpine) kell futtatni az Aspose.Slides‑t, használja a standard csomagot: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **GYIK**

**Szükségem van a Microsoft PowerPoint telepítésére a konvertáláshoz és a megjelenítéshez?**

Nem, a PowerPoint nem kötelező; az Aspose.Slides egy önálló motor a [létrehozáshoz](/slides/hu/net/create-presentation/), módosításhoz, [konvertáláshoz](/slides/hu/net/convert-presentation/) és [megjelenítéshez](/slides/hu/net/convert-powerpoint-to-png/) prezentációkhoz.

**Milyen betűtípusokra van szükség a helyes megjelenítéshez?**

A prezentációban használt betűtípusoknak, vagy megfelelő helyettesítőiknek elérhetőnek kell lenniük az operációs rendszerben. Linuxon és macOS‑on telepítsen általános betűtípus‑csomagokat a konzisztens megjelenítés biztosításához.

Alpine Linux konténerek esetén telepítsen legalább egy betűtípus‑csomagot a `libgdiplus` mellett. Az ajánlott minimális beállítás a `libgdiplus` a `ttf-dejavu`‑val. Ha olyan Microsoft‑betűtípusokra (Arial, Times New Roman, Courier New vagy Verdana) van szükség, használja a `msttcorefonts-installer`‑t a `fontconfig`‑tal együtt.

**Miért jelenik meg egy egyéni betűtípus helyettesítőként vagy hiányzó szövegként Linuxon?**

Ha a betűtúrafájl névtábla-bejegyzései inkonzisztensek vagy sérültek, a Linux betűtípus‑illesztő (FreeType/fontconfig) érvénytelen rekordot választhat, ami a betűtípus feloldásának hibájához vezet. A probléma megoldható egy javított névtáblával rendelkező betűtípus‑verzió használatával vagy egy következetes helyettesítő telepítésével.