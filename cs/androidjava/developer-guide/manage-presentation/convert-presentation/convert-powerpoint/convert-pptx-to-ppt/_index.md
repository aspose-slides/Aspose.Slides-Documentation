---
title: Převést PPTX do PPT na Androidu
linktitle: PPTX do PPT
type: docs
weight: 21
url: /cs/androidjava/convert-pptx-to-ppt/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPTX
- PPTX do PPT
- uložit PPTX jako PPT
- exportovat PPTX do PPT
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Jednoduše převést PPTX do PPT pomocí Aspose.Slides pro Android v Javě - zajistěte bezproblémovou kompatibilitu s formáty PowerPoint při zachování rozvržení a kvality vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPTX do formátu PPT pomocí Javy. Následující téma je pokryto.

- Převést PPTX do PPT v Javě

## **Převést PPTX do PPT na Androidu**

Pro ukázkový kód v Javě pro převod PPTX do PPT se podívejte na sekci níže, tj. [Převést PPTX do PPT](#convert-pptx-to-ppt). Jednoduše načte soubor PPTX a uloží jej do formátu PPT. Specifikací různých formátů ukládání můžete také soubor PPTX uložit do mnoha dalších formátů, jako je PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích. 

- [Převést PPTX do PDF na Androidu](/slides/cs/androidjava/convert-powerpoint-to-pdf/)
- [Převést PPTX do XPS na Androidu](/slides/cs/androidjava/convert-powerpoint-to-xps/)
- [Převést PPTX do HTML na Androidu](/slides/cs/androidjava/convert-powerpoint-to-html/)
- [Převést PPTX do ODP na Androidu](/slides/cs/androidjava/save-presentation/)
- [Převést PPTX do PNG na Androidu](/slides/cs/androidjava/convert-powerpoint-to-png/)

## **Převést PPTX do PPT**
Pro převod PPTX do PPT stačí předat název souboru a formát uložení metodě **Save** třídy [**Presentation**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation). Ukázkový kód v Javě níže převádí prezentaci z PPTX do PPT s výchozími možnostmi.

```java
// vytvořte objekt Presentation, který reprezentuje soubor PPTX
Presentation presentation = new Presentation("template.pptx");

// uložte prezentaci jako PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **Často kladené otázky**

**Přetrvávají všechny efekty a funkce PPTX při ukládání do starého formátu PPT (97–2003)?**

Ne vždy. Formát PPT postrádá některé novější možnosti (např. určité efekty, objekty a chování), takže funkce mohou být během převodu zjednodušeny nebo rasterizovány.

**Mohu převést pouze vybrané snímky do PPT místo celé prezentace?**

Přímé uložení cílí na celou prezentaci. Pro převod konkrétních snímků vytvořte novou prezentaci obsahující jen tyto snímky a uložte ji jako PPT; alternativně použijte službu/API, která podporuje parametry převodu po snímcích.

**Jsou podporovány prezentace chráněné heslem?**

Ano. Můžete zjistit, zda je soubor chráněn, otevřít jej s heslem a také [konfigurovat nastavení ochrany/šifrování](/slides/cs/androidjava/password-protected-presentation/) pro uložený PPT.