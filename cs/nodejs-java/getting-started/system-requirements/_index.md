---
title: Systémové požadavky
type: docs
weight: 60
url: /cs/nodejs-java/system-requirements/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte systémové požadavky Aspose.Slides pro Node.js via Java. Zajistěte bezproblémovou podporu PowerPointu a OpenDocument na Windows, Linuxu a macOS."
---
## **Úvod**

Aspose.Slides for Node.js via Java nevyžaduje žádný třetí produkt, jako je Microsoft PowerPoint, aby byl nainstalován. Aspose.Slides samotný je engine pro vytváření, úpravu, konverzi a renderování dokumentů v různých formátech, včetně formátů prezentací Microsoft PowerPoint.

## **Podporované operační systémy**

Aspose.Slides for Node.js via Java podporuje jakýkoli 32bitový nebo 64bitový operační systém, který spouští Java runtime, včetně, ale nejen:

### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)

### **Linux**
- Linux (Ubuntu, CentOS a další)

### **Mac**
- Mac OS X

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint pro konverze a renderování?**

Ne, PowerPoint není vyžadován; Aspose.Slides je samostatný engine pro [vytváření](/slides/cs/nodejs-java/create-presentation/), úpravy, [konverzi](/slides/cs/nodejs-java/convert-presentation/), a [renderování](/slides/cs/nodejs-java/convert-powerpoint-to-png/) prezentací.

**Jaká písma jsou potřebná pro správné renderování?**

V praxi musí být k dispozici písma použitá v prezentaci nebo vhodné [náhrady](/slides/cs/nodejs-java/font-substitution/). Pro zajištění jednotného renderování na Linuxu/macOS se doporučuje nainstalovat běžné balíčky písem.

**Proč se vlastní písmo na Linuxu renderuje jako záložní nebo chybějící text?**

Pokud má soubor písma nekonzistentní nebo poškozené záznamy v tabulce názvů, může Linuxový stack pro párování písem (FreeType/fontconfig) vybrat neplatný záznam, což způsobí, že písmo nebude rozpoznáno. Použití verze písma s opravenými záznamy v tabulce názvů nebo instalace konzistentní náhrady problém vyřeší.