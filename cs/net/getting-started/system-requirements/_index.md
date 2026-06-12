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
description: "Objevte systémové požadavky Aspose.Slides pro .NET. Zajistěte bezproblémovou podporu PowerPoint a OpenDocument na Windows, Linuxu a macOS."
---
## **Úvod**

Aspose.Slides pro .NET nevyžaduje instalaci Microsoft PowerPoint, protože Aspose.Slides je nezávislý engine pro tvorbu, konverzi, rozvržení stránky a renderování dokumentů Microsoft PowerPoint.

## **Podporované operační systémy**

Aspose.Slides pro .NET podporuje jakýkoli 32‑bitový nebo 64‑bitový operační systém, na kterém je nainstalován .NET nebo Mono framework, včetně (ale nikoli výhradně):

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

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine a další)

### **Mac**

- Mac OS X

## **Podporované frameworky**

Aspose.Slides pro .NET podporuje .NET a Mono frameworky:

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

- MONO Support in MAC and Linux platforms

## **Vývojová prostředí**

Aspose.Slides pro .NET lze použít k vývoji aplikací v libovolném vývojovém prostředí cílícím platformu .NET, ale tato prostředí jsou výslovně podporována:

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

V současnosti existují dvě hlavní sestavení Aspose.Slides — Aspose.Slides.NET a Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Jedná se o hlavní verzi produktu. Používá standardní grafický engine .NET.
- Na ne‑Windows platformách může být nutné nainstalovat knihovnu `libgdiplus` a její závislosti.
- Před verzí Aspose.Slides 25.3 bylo pro ne‑Windows platformy nutné použít .NET Standard 2.0 DLL z balíčku Aspose.Slides ZIP.
- Od verze Aspose.Slides 25.3 lze NuGet balíček používat přímo i na ne‑Windows systémech.
- Při běhu na ne‑Windows systémech musí vaše aplikace při spuštění obsahovat následující řádek:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Od verze 25.3 můžete tento balíček použít na platformách podporujících .NET, např. Linux aarch64 (ARM64).**

#### **Další balíčky pro Linux Alpine**

Při běhu Aspose.Slides pro .NET v kontejneru Alpine Linux může samotná instalace `libgdiplus` být nedostatečná. Alpine kontejnery obvykle neobsahují žádná písma. Pokud nejsou k dispozici žádná písma, operace renderování nebo konverze mohou selhat s chybou podobnou následující:

```text
System.ArgumentException: Font '?' cannot be found
```
Pro použití Aspose.Slides na Alpine nainstalujte `libgdiplus` spolu s alespoň jedním balíčkem písem.

**Možnost 1: Písma DejaVu**

Doporučenou možností je instalace balíčku ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Balíček `ttf-dejavu` automaticky nainstaluje potřebné závislosti související s písmy, jako jsou `fontconfig`, `encodings`, `mkfontscale` a `mkfontdir`. Ve většině případů nejsou vyžadovány žádné další balíčky písem.

**Možnost 2: Microsoft Core Fonts**

Pokud vaše prezentace používají specifická Microsoftová písma, jako Arial, Times New Roman, Courier New nebo Verdana, nainstalujte místo toho Microsoft Core Fonts:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Tuto možnost používejte jen tehdy, když zpracovávané prezentace vyžadují Microsoftová písma. Ve většině scénářů je instalace `ttf-dejavu` jednodušší a spolehlivější.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Jedná se o verzi Aspose.Slides používající vlastní multiplatformní grafický engine vyvinutý týmem Aspose.Slides.  
Na ne‑Windows platformách může být vyžadována knihovna `fontconfig`.

**Podporované platformy**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Nepodporované platformy**
- *Windows 11 ARM* (ARM64) — *V současnosti není zvažováno*

{{%  alert  title="Notes"  color="primary"  %}}  
Pro Linux x64 je vyžadováno GLIBC 2.23+; pro Linux ARM64 GLIBC 2.39+. Systémy jako CentOS 7 (GLIBC 2.14) nejsou podporovány. Pokud potřebujete spustit Aspose.Slides na CentOS 7 nebo jiných nekompatibilních systémech (např. Alpine), použijte standardní balíček: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint pro konverze a renderování?**

Ne, PowerPoint není vyžadován; Aspose.Slides je samostatný engine pro [vytváření](/slides/cs/net/create-presentation/), úpravy, [konverzi](/slides/cs/net/convert-presentation/) a [renderování](/slides/cs/net/convert-powerpoint-to-png/) prezentací.

**Jaká písma jsou potřeba pro správné renderování?**

Písma použitá v prezentaci, nebo vhodné náhrady, musí být dostupná v operačním systému. Na Linuxu a macOS nainstalujte běžné balíčky písem pro zajištění konzistentního renderování.

Pro kontejnery Alpine Linux nainstalujte alespoň jeden balíček písem vedle `libgdiplus`. Doporučené minimální nastavení je `libgdiplus` s `ttf-dejavu`. Pokud jsou vyžadována Microsoftová písma jako Arial, Times New Roman, Courier New nebo Verdana, použijte `msttcorefonts-installer` spolu s `fontconfig`.

**Proč se vlastní písmo na Linuxu zobrazuje jako náhradní nebo chybějící text?**

Pokud soubor písma obsahuje nekonzistentní nebo poškozené položky v tabulce name, Linuxový stack pro párování písem (FreeType/fontconfig) může vybrat neplatný záznam, což vede k nevyřešenému písmu. Použití verze písma s opravenými záznamy v tabulce name nebo instalace konzistentní náhrady problém vyřeší.