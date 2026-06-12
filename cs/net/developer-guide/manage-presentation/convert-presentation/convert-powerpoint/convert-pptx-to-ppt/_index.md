---
title: Převod PPTX na PPT v .NET
linktitle: PPTX na PPT
type: docs
weight: 21
url: /cs/net/convert-pptx-to-ppt/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPTX
- PPTX na PPT
- uložit PPTX jako PPT
- exportovat PPTX do PPT
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Jednoduše převést PPTX na PPT pomocí Aspose.Slides pro .NET—zajistěte bezproblémovou kompatibilitu s formáty PowerPoint při zachování rozvržení a kvality vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPTX do formátu PPT pomocí C#. Pokrývá následující téma.

- Převod PPTX na PPT v C#

## **Převod PPTX na PPT v .NET**

Pro ukázkový kód C# pro převod PPTX na PPT viz sekce níže, tj. [Convert PPTX to PPT](#convert-pptx-to-ppt). Kód pouze načte soubor PPTX a uloží jej ve formátu PPT. Zadáním různých formátů uložení můžete také uložit soubor PPTX do mnoha dalších formátů, jako je PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Convert PPTX to PDF in .NET](/slides/cs/net/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in .NET](/slides/cs/net/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in .NET](/slides/cs/net/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in .NET](/slides/cs/net/save-presentation/)
- [Convert PPTX to PNG in .NET](/slides/cs/net/convert-powerpoint-to-png/)

## **Převod PPTX na PPT**
Pro převod PPTX na PPT jednoduše předáte název souboru a formát uložení metodě [**Save**](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) třídy [**Presentation**](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Níže uvedený ukázkový kód C# převádí prezentaci z PPTX do PPT s výchozími možnostmi.

```c#
// Vytvořte objekt Presentation, který představuje soubor PPTX
Presentation pres = new Presentation("presentation.pptx");

// Ukládání prezentace PPTX do formátu PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **Často kladené otázky**

**Přežijí všechny efekty a funkce PPTX při uložení do staršího formátu PPT (97–2003)?**

Ne vždy. Formát PPT postrádá některé novější schopnosti (například určité efekty, objekty a chování), takže funkce mohou být během konverze zjednodušené nebo rasterizované.

**Mohu převést pouze vybrané snímky do PPT místo celé prezentace?**

Přímé uložení cílí na celou prezentaci. Pro převod konkrétních snímků vytvořte novou prezentaci pouze s těmito snímky a uložte ji jako PPT; alternativně můžete použít službu/API, která podporuje parametry konverze po snímku.

**Jsou podporovány prezentace chráněné heslem?**

Ano. Můžete zjistit, zda je soubor chráněn, otevřít jej s heslem a také [configure protection/encryption settings](/slides/cs/net/password-protected-presentation/) pro uložený PPT.