---
title: Převést PPTX na PPT v Javě
linktitle: PPTX na PPT
type: docs
weight: 21
url: /cs/java/convert-pptx-to-ppt/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPTX
- PPTX na PPT
- uložit PPTX jako PPT
- exportovat PPTX do PPT
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše převést PPTX na PPT pomocí Aspose.Slides pro Javu -- zajistěte bezproblémovou kompatibilitu s formáty PowerPoint a zachovejte rozvržení a kvalitu vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Javy převést prezentaci PowerPoint ve formátu PPTX do formátu PPT. Následující téma je pokryto.

- Převést PPTX na PPT v Javě

## **Převést PPTX na PPT v Javě**

Pro ukázkový kód v Javě pro převod PPTX na PPT se podívejte na sekci níže, tj. [Convert PPTX to PPT](#convert-pptx-to-ppt). Stačí načíst soubor PPTX a uložit jej ve formátu PPT. Specifikací různých formátů uložení můžete soubor PPTX uložit i do mnoha dalších formátů, jako je PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Převést PPTX na PDF v Javě](/slides/cs/java/convert-powerpoint-to-pdf/)
- [Převést PPTX na XPS v Javě](/slides/cs/java/convert-powerpoint-to-xps/)
- [Převést PPTX na HTML v Javě](/slides/cs/java/convert-powerpoint-to-html/)
- [Převést PPTX na ODP v Javě](/slides/cs/java/save-presentation/)
- [Převést PPTX na PNG v Javě](/slides/cs/java/convert-powerpoint-to-png/)

## **Převést PPTX na PPT**

Pro převod PPTX na PPT stačí předat název souboru a formát uložení metodě **Save** třídy [**Presentation**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation). Níže uvedený ukázkový kód v Javě převádí prezentaci z PPTX na PPT pomocí výchozích možností.

```java
// instancujte objekt Presentation, který představuje soubor PPTX
Presentation presentation = new Presentation("template.pptx");

// uložte prezentaci jako PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **Často kladené otázky**

**Přežijí všechny efekty a funkce PPTX při ukládání do staršího formátu PPT (97–2003)?**

Ne vždy. Formát PPT postrádá některé novější funkce (např. určité efekty, objekty a chování), takže během konverze mohou být funkce zjednodušeny nebo rasterizovány.

**Mohu převést jen vybrané snímky na PPT místo celé prezentace?**

Přímé uložení cílí na celou prezentaci. Pro převod konkrétních snímků vytvořte novou prezentaci obsahující jen tyto snímky a uložte ji jako PPT; alternativně použijte službu/API, která podporuje parametry konverze po snímcích.

**Jsou podporovány prezentace chráněné heslem?**

Ano. Můžete zjistit, zda je soubor chráněn, otevřít jej pomocí hesla a také [nastavit ochranu/šifrování](/slides/cs/java/password-protected-presentation/) pro uložený PPT.