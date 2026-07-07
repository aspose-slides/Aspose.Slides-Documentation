---
title: Systémové požadavky
type: docs
weight: 60
url: /cs/net/system-requirements/
keywords:
- systémové požadavky
- operační systém
- instalace
- závislosti
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte systémové požadavky Aspose.Slides pro .NET. Zajistěte bezproblémovou podporu PowerPointu a OpenDocument na Windows, Linuxu a macOS."
---
## **Úvod**

Aspose.Slides pro .NET nevyžaduje instalaci Microsoft PowerPoint, protože Aspose.Slides je samostatný engine pro tvorbu, konverzi, rozvržení stránek a vykreslování dokumentů Microsoft PowerPoint.

## **Podporované operační systémy**

Aspose.Slides pro .NET podporuje jakýkoli 32‑bitový nebo 64‑bitový operační systém, na kterém je nainstalován .NET nebo Mono framework, včetně (ale nikoli výhradně):

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine a další)

### **Mac**

- Mac OS X

## **Podporované frameworky**

Aspose.Slides pro .NET podporuje frameworky .NET a Mono:

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

### **Mono Framework**

- Podpora MONO na platformách MAC a Linux

## **Vývojová prostředí**

Aspose.Slides pro .NET lze použít k vývoji aplikací v libovolném vývojovém prostředí zaměřeném na platformu .NET, ale tato prostředí jsou výslovně podporována:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Hlavní sestavení Aspose.Slides**

V současné době existují dvě hlavní sestavení Aspose.Slides — Aspose.Slides.NET a Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Jedná se o hlavní verzi produktu. Používá standardní grafický engine .NET.
- Na ne‑Windows platformách může být nutné nainstalovat knihovnu `libgdiplus` a její závislosti.
- Před verzí Aspose.Slides 25.3 bylo na ne‑Windows platformách nutné použít .NET Standard 2.0 DLL ze ZIP balíčku Aspose.Slides.
- Od verze Aspose.Slides 25.3 lze balíček NuGet použít přímo i na ne‑Windows systémech.
- Při spuštění na ne‑Windows systémech musí aplikace na začátku zahrnout následující řádek:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Od verze 25.3 můžete tento balíček použít na platformách, které podporují .NET, například Linux aarch64 (ARM64).**

#### **Další balíčky pro Linux Alpine**

Při spuštění Aspose.Slides pro .NET v Alpine Linux kontejneru nemusí samotná instalace `libgdiplus` stačit. Alpine kontejnery obvykle neobsahují fonty ve výchozím nastavení. Pokud nejsou k dispozici žádné fonty, operace vykreslování nebo konverze mohou selhat s chybou podobnou následující:
```text
System.ArgumentException: Font '?' cannot be found
```
Pro použití Aspose.Slides na Alpine nainstalujte `libgdiplus` spolu s alespoň jedním fontovým balíčkem.

**Možnost 1: DejaVu fonty**

Doporučená možnost je nainstalovat balíček ttf-dejavu:
```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` balíček automaticky nainstaluje potřebné fontové závislosti, jako jsou `fontconfig`, `encodings`, `mkfontscale` a `mkfontdir`. Pro většinu případů není potřeba žádný další fontový balíček.

**Možnost 2: Microsoft Core Fonts**

Pokud vaše prezentace používají specifické Microsoft fonty, například Arial, Times New Roman, Courier New nebo Verdana, nainstalujte místo toho Microsoft Core Fonts:
```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Tuto možnost použijte pouze v případě, že zpracovávané prezentace vyžadují Microsoft fonty. Ve většině scénářů je instalace `ttf-dejavu` jednodušší a spolehlivější.

**Další požadavky pro globalizaci**

Aby byla na Alpine zajištěna správná podpora globalizace, nainstalujte balíček `icu-libs` a vypněte invariantní režim:
```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Jedná se o verzi Aspose.Slides používající vlastní multiplatformní grafický engine vyvinutý týmem Aspose.Slides.  
Na ne‑Windows platformách může být vyžadována knihovna `fontconfig`.

**Podporované platformy**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nepodporované platformy**
- *Windows 11 ARM* (ARM64) — *Momentálně není zvažováno*

{{%  alert  title="Notes"  color="primary"  %}}  
Pro Linux x64 je vyžadováno GLIBC 2.23+, pro Linux ARM64 GLIBC 2.39+. Systémy jako CentOS 7 (GLIBC 2.14) nejsou podporovány. Pokud potřebujete spustit Aspose.Slides na CentOS 7 nebo jiných nekompatibilních systémech (např. Alpine), použijte standardní balíček: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint pro konverze a vykreslování?**

Ne, PowerPoint není vyžadován; Aspose.Slides je samostatný engine pro [vytváření](/slides/cs/net/create-presentation/), úpravy, [konverzi](/slides/cs/net/convert-presentation/) a [vykreslování](/slides/cs/net/convert-powerpoint-to-png/) prezentací.

**Které fonty jsou potřeba pro správné vykreslení?**

Fonty použité v prezentaci nebo vhodné náhrady musí být dostupné v operačním systému. Na Linuxu a macOS nainstalujte běžné fontové balíčky, aby bylo zajištěno konzistentní vykreslování.

Pro kontejnery Alpine Linux nainstalujte alespoň jeden fontový balíček kromě `libgdiplus`. Doporučené minimální nastavení je `libgdiplus` spolu s `ttf-dejavu`. Pokud jsou vyžadovány Microsoft fonty jako Arial, Times New Roman, Courier New nebo Verdana, použijte `msttcorefonts-installer` spolu s `fontconfig`.

**Proč se vlastní font na Linuxu vykresluje jako náhradní nebo chybějící text?**

Pokud má soubor fontu nekonzistentní nebo poškozené položky v tabulce názvů, může Linuxová vrstva pro výběr fontů (FreeType/fontconfig) vybrat neplatný záznam, což způsobí, že font nebude rozpoznán. Použití verze fontu s opravenými záznamy v name‑table nebo instalace konzistentní náhrady problém vyřeší.