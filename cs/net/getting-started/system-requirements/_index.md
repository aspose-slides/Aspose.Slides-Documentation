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
description: "Objevte systémové požadavky Aspose.Slides pro .NET. Zajistěte plynulou podporu PowerPoint a OpenDocument na Windows, Linuxu a macOS."
---
## **Úvod**

Aspose.Slides for .NET nevyžaduje instalaci Microsoft PowerPoint, protože Aspose.Slides je nezávislý engine pro vytváření, konverzi, rozvržení stránek a vykreslování dokumentů Microsoft PowerPoint.

## **Podporované operační systémy**

Aspose.Slides for .NET podporuje libovolný 32‑bitový nebo 64‑bitový operační systém, na kterém je nainstalován .NET nebo Mono framework, včetně (ale nikoli výhradně):

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

Aspose.Slides for .NET podporuje .NET a Mono frameworky:

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

- Podpora MONO na platformách macOS a Linux

## **Vývojová prostředí**

Aspose.Slides for .NET může být použit k vývoji aplikací v libovolném vývojovém prostředí cílícím .NET platformu, ale tato prostředí jsou explicitně podporována:

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

V současnosti existují dva hlavní buildy Aspose.Slides — Aspose.Slides.NET a Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Toto je hlavní verze produktu. Používá standardní .NET grafický engine.  
- Na ne‑Windows platformách může být nutné nainstalovat knihovnu `libgdiplus` a její závislosti.  
- Před verzí Aspose.Slides 25.3 bylo na ne‑Windows platformách nutné použít .NET Standard 2.0 DLL ze ZIP balíčku Aspose.Slides.  
- Od verze Aspose.Slides 25.3 může být NuGet balíček použit přímo i na ne‑Windows systémech.  
- Při běhu na ne‑Windows systémech musí aplikace při startu zahrnout následující řádek:  
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```  
- **Od verze 25.3 můžete tento balíček použít na platformách podporujících .NET, jako je Linux aarch64 (ARM64).**

#### **Další balíčky pro Linux Alpine**

Při spuštění Aspose.Slides for .NET v Alpine Linux kontejneru nemusí instalace `libgdiplus` stačit. Alpine kontejnery obvykle neobsahují fonty ve výchozím stavu. Pokud nejsou k dispozici žádné fonty, operace vykreslování nebo konverze mohou selhat s chybou podobnou této:

```text
System.ArgumentException: Font '?' cannot be found
```  
Pro použití Aspose.Slides na Alpine nainstalujte `libgdiplus` společně s alespoň jedním fontovým balíčkem.

**Možnost 1: DejaVu fonty**

Doporučená možnost je instalovat balíček ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```  

Balíček `ttf-dejavu` automaticky nainstaluje potřebné fontové závislosti, jako jsou `fontconfig`, `encodings`, `mkfontscale` a `mkfontdir`. Pro většinu případů nejsou vyžadovány žádné další fontové balíčky.

**Možnost 2: Microsoft Core Fonts**

Pokud vaše prezentace používají specifické Microsoft fonty, jako jsou Arial, Times New Roman, Courier New nebo Verdana, nainstalujte místo toho Microsoft Core Fonts:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```  

Použijte tuto možnost jen tehdy, když zpracovávané prezentace vyžadují Microsoft fonty. Pro většinu scénářů je instalace `ttf-dejavu` jednodušší a spolehlivější.

**Další požadavky pro globalizaci**

Pro zajištění správné podpory globalizace na Alpine nainstalujte balíček `icu-libs` a vypněte invariantní režim:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Toto je verze Aspose.Slides používající vlastní cross‑platform grafický engine vyvinutý týmem Aspose.Slides.  
Na ne‑Windows platformách může být vyžadována knihovna `fontconfig`.

**Podporované platformy**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**Nepodporované platformy**
- *Windows 11 ARM* (ARM64) — *V současné době není zvažováno*

{{%  alert  title="Notes"  color="info"  %}}  
Pro Linux x64 je vyžadován GLIBC 2.23+, pro Linux ARM64 GLIBC 2.39+. Systémy jako CentOS 7 (GLIBC 2.14) nejsou podporovány. Pokud potřebujete spustit Aspose.Slides na CentOS 7 nebo jiných nekompatibilních systémech (např. Alpine), použijte standardní balíček: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Často kladené otázky**

### Potřebuji mít Microsoft PowerPoint nainstalovaný pro konverze a vykreslování?

Ne, PowerPoint není vyžadován; Aspose.Slides je samostatný engine pro [vytváření](/slides/cs/net/create-presentation/), úpravu, [konvertování](/slides/cs/net/convert-presentation/) a [renderování](/slides/cs/net/convert-powerpoint-to-png/) prezentací.

### Jaké fonty jsou potřeba pro správné vykreslování?

Fonty použité v prezentaci, nebo vhodné náhradní fonty, musí být dostupné v operačním systému. Na Linuxu a macOS nainstalujte běžné fontové balíčky, aby bylo zajištěno konzistentní vykreslování.

Pro Alpine Linux kontejnery nainstalujte alespoň jeden fontový balíček kromě `libgdiplus`. Doporučené minimální nastavení je `libgdiplus` s `ttf-dejavu`. Pokud jsou vyžadovány Microsoft fonty jako Arial, Times New Roman, Courier New nebo Verdana, použijte `msttcorefonts-installer` společně s `fontconfig`.

### Proč se vlastní font na Linuxu zobrazuje jako náhradní nebo chybějící text?

Pokud má soubor fontu nekonzistentní nebo poškozené záznamy v tabulce názvů, Linuxová font‑matching vrstva (FreeType/fontconfig) může vybrat neplatný záznam, což vede k nevyřešenému fontu. Použití verze fontu s opravenými záznamy v tabulce názvů nebo instalace konzistentní náhrady problém vyřeší.