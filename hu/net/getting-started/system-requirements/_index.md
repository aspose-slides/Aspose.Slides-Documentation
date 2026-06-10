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
description: "Fedezze fel az Aspose.Slides for .NET rendszerkövetelményeit. Biztosítsa a zökkenőmentes PowerPoint és OpenDocument támogatást Windowson, Linuxon és macOS-en."
---
## **Bevezetés**

Az Aspose.Slides for .NET nem igényli a Microsoft PowerPoint telepítését, mivel az Aspose.Slides egy önálló Microsoft PowerPoint dokumentumkészítő, konvertáló, oldalelrendező és renderelő motor.

## **Támogatott operációs rendszerek**

Az Aspose.Slides for .NET bármely 32 bites vagy 64 bites operációs rendszert támogat, amelyen a .NET vagy a Mono keretrendszer telepítve van, többek között (de nem kizárólag):

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, and others)

### **Mac**

- Mac OS X

## **Támogatott keretrendszerek**

Az Aspose.Slides for .NET támogatja a .NET és a Mono keretrendszereket:

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
- COM Interop support (COM, C++, VBScript)

### **Mono keretrendszer**

- MONO támogatás MAC és Linux platformokon

## **Fejlesztői környezetek**

Az Aspose.Slides for .NET bármilyen fejlesztői környezetben használható, amely a .NET platformra céloz, de a következő környezeteket explicit módon támogatja:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Az Aspose.Slides fő buildjei**

Jelenleg két fő build létezik az Aspose.Slides‑ből – Aspose.Slides.NET és Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Ez a termék fő verziója. A szabványos .NET grafikai motort használja.
- Nem‑Windows platformokon előfordulhat, hogy a `libgdiplus` könyvtárat és annak függőségeit telepíteni kell.
- Az Aspose.Slides 25.3 előtti verziói esetén nem‑Windows platformokon a .NET Standard 2.0 DLL‑t kellett használni az Aspose.Slides ZIP csomagból.
- A 25.3‑as verziótól a NuGet csomag közvetlenül használható nem‑Windows rendszereken is.
- Nem‑Windows rendszeren való futtatáskor az alkalmazásnak a következő sort kell tartalmaznia az indításkor:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **A 25.3‑as verziótól kezdve ezt a csomagot olyan platformokon is használhatja, amelyek támogatják a .NET‑et, például Linux aarch64 (ARM64).**

#### **További csomagok Linux Alpine-hoz**

Amikor az Aspose.Slides for .NET‑et Alpine Linux konténerben futtatja, a `libgdiplus` önmagában gyakran nem elegendő. Az Alpine konténerek alapértelmezés szerint nem tartalmaznak betűkészleteket. Ha nincs elérhető betűkészlet, a renderelés vagy konvertálás hibával végződhet, például:

```text
System.ArgumentException: Font '?' cannot be found
```
Az Aspose.Slides használatához Alpine‑on telepítse a `libgdiplus`‑t legalább egy betűkészlet‑csomaggal együtt.

**Opció 1: DejaVu betűkészletek**

Az ajánlott megoldás a `ttf-dejavu` csomag telepítése:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

A `ttf-dejavu` csomag automatikusan telepíti a szükséges, betűkészletekkel kapcsolatos függőségeket, például a `fontconfig`, `encodings`, `mkfontscale` és `mkfontdir` csomagokat. A legtöbb felhasználási esethez nem szükséges további betűkészlet‑csomag.

**Opció 2: Microsoft Core betűkészletek**

Ha a prezentációk Microsoft‑specifikus betűkészleteket használnak (pl. Arial, Times New Roman, Courier New vagy Verdana), telepítse a Microsoft Core betűkészleteket:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Ezt az opciót csak akkor válassza, ha a feldolgozott prezentációk Microsoft betűkészleteket igényelnek. A legtöbb helyzetben a `ttf-dejavu` telepítése egyszerűbb és megbízhatóbb.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Ez az Aspose.Slides verzió, amelyet az Aspose.Slides csapata által fejlesztett egyedi, többplatformos grafikai motor használ.  
Nem‑Windows platformokon a `fontconfig` könyvtár szükséges lehet.

**Támogatott platformok**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nem támogatott platformok**
- *Windows 11 ARM* (ARM64) — *Jelenleg nincs tervezésben*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64 esetén GLIBC 2.23+ szükséges; Linux ARM64 esetén GLIBC 2.39+ szükséges. A CentOS 7 (GLIBC 2.14) és hasonló rendszerek nem támogatottak. Ha az Aspose.Slides‑et CentOS 7‑en vagy más inkompatibilis rendszeren (például Alpine) kell futtatni, használja a szabványos csomagot: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **GYIK**

**Szükséges-e a Microsoft PowerPoint telepítése a konverziókhoz és rendereléshez?**

Nem, a PowerPoint nem szükséges; az Aspose.Slides egy önálló motor a [létrehozáshoz](/slides/hu/net/create-presentation/), a módosításhoz, a [konvertáláshoz](/slides/hu/net/convert-presentation/) és a [rendereléshez](/slides/hu/net/convert-powerpoint-to-png/) prezentációkhoz.

**Milyen betűkészletekre van szükség a helyes rendereléshez?**

A prezentációban használt betűkészleteknek, vagy megfelelő helyettesítőiknek elérhetőnek kell lenniük az operációs rendszerben. Linuxon és macOS‑on telepítsen általános betűkészlet‑csomagokat a konzisztens renderelés érdekében.

Alpine Linux konténerek esetén legalább egy betűkészlet‑csomagot telepíteni kell a `libgdiplus` mellett. Az ajánlott minimális beállítás a `libgdiplus` és a `ttf-dejavu`. Ha Microsoft betűkészletekre (Arial, Times New Roman, Courier New vagy Verdana) van szükség, használja a `msttcorefonts-installer`‑t a `fontconfig`‑tel együtt.

**Miért jelenik meg egy egyéni betűkészlet helyettesítőként vagy hiányzó szövegként Linuxon?**

Ha a betűkészlet‑fájl neve‑táblázat‑bejegyzései ellentmondóak vagy sérültek, a Linux betűkészlet‑illesztő (FreeType/fontconfig) érvénytelen rekordot választhat, ami a betűkészlet feloldásának hiányához vezet. A probléma megoldásához használjon javított névtábla‑rekordokkal rendelkező betűkészlet‑verziót, vagy telepítsen konzisztens helyettesítőt.