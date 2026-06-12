---
title: Systémové požadavky
type: docs
weight: 80
url: /cs/cpp/system-requirements/
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
- C++
- Aspose.Slides
description: "Objevte systémové požadavky Aspose.Slides pro C++. Zajistěte bezproblémovou podporu PowerPoint a OpenDocument na Windows, Linuxu a macOS."
---
## **Úvod**

Aspose.Slides nevyžaduje instalaci Microsoft PowerPoint, protože Aspose.Slides je nezávislý engine pro tvorbu, konverzi, rozvržení stránek a vykreslování dokumentů Microsoft PowerPoint.

## **Podporované operační systémy**
Aspose.Slides pro C++ je nativní knihovna C++. Aspose.Slides pro C++ podporuje následující 64‑bitové a 32‑bitové operační systémy a platformy:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 nebo novější.
- CentOS 8 nebo novější.
- Fedora 24 nebo novější.
- A další Linux x86_64 s glibc 2.23 nebo novějším.

### **macOS**
- macOS Monterey 12.1 nebo novější.

## **Vývojová prostředí**
Aspose.Slides pro C++ můžete použít při vývoji aplikací pro Windows, Linux nebo macOS.

### **Windows**
- Microsoft Visual Studio 2017 nebo novější.
- CMake 3.18 nebo novější.

### **Linux**
- Clang 3.9 nebo novější.
- GCC 6.1 nebo novější.
- CMake 3.18 nebo novější.

### **macOS**
- Xcode 13.4 nebo novější.

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint pro konverze a renderování?**

Ne, PowerPoint není vyžadován; Aspose.Slides je samostatný engine pro [vytváření](/slides/cs/cpp/create-presentation/), úpravu, [konverzi](/slides/cs/cpp/convert-presentation/) a [renderování](/slides/cs/cpp/convert-powerpoint-to-png/) prezentací.

**Která písma jsou potřebná pro správné renderování?**

V praxi musí být k dispozici písma použité v prezentaci nebo vhodné [náhrady](/slides/cs/cpp/font-substitution/). Aby bylo zajištěno konzistentní renderování na Linuxu/macOS, doporučuje se nainstalovat běžné balíčky písem.

**Proč se vlastní písmo na Linuxu vykresluje jako náhradní nebo chybějící text?**

Pokud má soubor písma nejednotné nebo poškozené záznamy v tabulce názvů, může stack pro přiřazování písem na Linuxu (FreeType/fontconfig) vybrat neplatný záznam, což vede k nevyřešenému písmu. Použití verze písma s opravenými záznamy v tabulce názvů nebo instalace konzistentní náhrady problém vyřeší.