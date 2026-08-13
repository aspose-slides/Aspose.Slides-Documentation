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

Aspose.Slides for .NET nem igényli a Microsoft PowerPoint telepítését, mert az Aspose.Slides egy független Microsoft PowerPoint dokumentumkészítő, konvertáló, oldalelrendező és renderelő motor.

## **Támogatott operációs rendszerek**

Az Aspose.Slides for .NET minden 32 vagy 64 bites operációs rendszert támogat, ahol .NET vagy Mono keretrendszer van telepítve, többek között:

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine és egyebek)

### **Mac**

- Mac OS X

## **Támogatott keretrendszerek**

Az Aspose.Slides for .NET a .NET és Mono keretrendszereket támogatja:

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

Az Aspose.Slides for .NET bármely .NET platformra célzó fejlesztői környezetben használható, de a következő környezetek expliciten támogatottak:

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

Jelenleg két fő build létezik: Aspose.Slides.NET és Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Ez a termék fő változata. A standard .NET grafikai motorral működik.
- Nem Windows platformon előfordulhat, hogy a `libgdiplus` könyvtárat és függőségeit telepíteni kell.
- Az Aspose.Slides 25.3 előtti verziók esetén nem Windows platformon a .NET Standard 2.0 DLL-t kellett használni az Aspose.Slides ZIP csomagból.
- A 25.3-as verziótól a NuGet csomag közvetlenül használható nem Windows rendszereken is.
- Nem Windows rendszeren történő futtatáskor az alkalmazásnak a következő sort kell tartalmaznia az indításkor:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **A 25.3-as verziótól kezdve ezt a csomagot használhatja olyan platformokon, amelyek támogatják a .NET-et, például Linux aarch64 (ARM64).**

#### **További csomagok Linux Alpine-hoz**

Alpine Linux konténerben az Aspose.Slides for .NET futtatásakor a `libgdiplus` önmagában nem biztos, hogy elegendő. Az Alpine konténerek általában alapértelmezés szerint nem tartalmaznak betűkészleteket. Ha nincs elérhető betűkészlet, a renderelés vagy konvertálás hibával állhat elő, például:

```text
System.ArgumentException: Font '?' cannot be found
```
Az Aspose.Slides használatához Alpine-on telepítse a `libgdiplus`-t legalább egy betűkészlet csomaggal együtt.

**1. lehetőség: DejaVu betűkészletek**

Ajánlott a ttf-dejavu csomag telepítése:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

A `ttf-dejavu` csomag automatikusan telepíti a szükséges betűkészlet‑függőségeket, mint a `fontconfig`, `encodings`, `mkfontscale` és `mkfontdir`. A legtöbb esetben nincs szükség további betűkészlet csomagra.

**2. lehetőség: Microsoft Core Fonts**

Ha a prezentációk Microsoft‑specifikus betűkészleteket (Arial, Times New Roman, Courier New vagy Verdana) használnak, telepítse a Microsoft Core Fonts csomagot:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Ezt a lehetőséget csak akkor válassza, ha a feldolgozott prezentációk Microsoft‑betűket igényelnek. A legtöbb forgatókönyvben a `ttf-dejavu` telepítése egyszerűbb és megbízhatóbb.

**További követelmények a globalizációhoz**

Az Alpine-on a megfelelő globalizáció támogatásához telepítse az `icu-libs` csomagot, és tiltsa le az invariáns módot:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Az Aspose.Slides saját, keresztplatformos grafikai motorral ellátott változata, amelyet az Aspose.Slides csapat fejlesztett.  
Nem Windows platformon a `fontconfig` könyvtár szükséges lehet.

**Támogatott platformok**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nem támogatott platformok**
- *Windows 11 ARM* (ARM64) — *Jelenleg nincs tervben*

{{%  alert  title="Notes"  color="info"  %}}  
Linux x64 esetén GLIBC 2.23+, Linux ARM64 esetén GLIBC 2.39+ szükséges. A CentOS 7 (GLIBC 2.14) nem támogatott. Ha az Aspose.Slides-et CentOS 7-en vagy más inkompatibilis rendszeren (pl. Alpine) kell futtatni, használja a standard csomagot: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **GYIK**

### Telepíteni kell a Microsoft PowerPointot a konvertáláshoz és rendereléshez?

Nem, a PowerPoint nem szükséges; az Aspose.Slides egy önálló motor a [létrehozáshoz](/slides/hu/net/create-presentation/), módosításhoz, [konvertáláshoz](/slides/hu/net/convert-presentation/) és [rendereléshez](/slides/hu/net/convert-powerpoint-to-png/) prezentációkhoz.

### Milyen betűkészletekre van szükség a helyes rendereléshez?

A prezentációban használt betűkészleteknek, vagy megfelelő helyettesítőknek elérhetőnek kell lenniük az operációs rendszerben. Linuxon és macOS-en telepítsen általános betűkészlet csomagokat a konzisztens renderelés biztosításához.

Alpine Linux konténerek esetén telepítsen legalább egy betűkészlet csomagot a `libgdiplus` mellé. Az ajánlott minimális beállítás a `libgdiplus` és a `ttf-dejavu`. Ha Microsoft betűk (Arial, Times New Roman, Courier New vagy Verdana) szükségesek, használja a `msttcorefonts-installer`-t a `fontconfig`-tal együtt.

### Miért jelenik meg egy egyedi betűkészlet helyettesítőként vagy hiányzó szövegként Linuxon?

Ha a betűkészlet fájl nevetáblája inkonzisztens vagy sérült, a Linux betűkészlet‑illesztő (FreeType/fontconfig) érvénytelen rekordot választhat, ami a betűkészlet feloldásának kudarcához vezet. A probléma megoldásához használjon helyes nevetáblájú betűkészlet‑verziót, vagy telepítsen egy konzisztens helyettesítőt.