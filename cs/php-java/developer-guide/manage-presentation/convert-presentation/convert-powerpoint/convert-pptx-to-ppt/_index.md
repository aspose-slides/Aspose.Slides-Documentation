---
title: Převod PPTX na PPT v PHP
linktitle: PPTX na PPT
type: docs
weight: 21
url: /cs/php-java/convert-pptx-to-ppt/
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
- PHP
- Aspose.Slides
description: "Jednoduše převádějte PPTX na PPT pomocí Aspose.Slides - zajistěte bezproblémovou kompatibilitu s formáty PowerPoint při zachování rozvržení a kvality vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí PHP převést prezentaci PowerPoint ve formátu PPTX do formátu PPT. Níže je pokryto následující téma.

- Převést PPTX na PPT

## **Převod PPTX na PPT v PHP**

Pro ukázkový kód v Javě pro převod PPTX na PPT se podívejte na sekci níže, tj. [Convert PPTX to PPT](#convert-pptx-to-ppt). Kód pouze načte soubor PPTX a uloží jej ve formátu PPT. Zadáním různých formátů uložení můžete také uložit soubor PPTX do řady dalších formátů, jako je PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích.

- [Převést PPTX na PDF v PHP](/slides/cs/php-java/convert-powerpoint-to-pdf/)
- [Převést PPTX na XPS v PHP](/slides/cs/php-java/convert-powerpoint-to-xps/)
- [Převést PPTX na HTML v PHP](/slides/cs/php-java/convert-powerpoint-to-html/)
- [Převést PPTX na ODP v PHP](/slides/cs/php-java/save-presentation/)
- [Převést PPTX na PNG v PHP](/slides/cs/php-java/convert-powerpoint-to-png/)

## **Převést PPTX na PPT**
Chcete‑li převést PPTX na PPT, stačí předat název souboru a formát uložení metodě **Save** třídy [**Presentation**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation). Níže uvedený ukázkový kód v PHP převádí prezentaci z PPTX na PPT s výchozími nastaveními.

```php
  # vytvořte objekt Presentation, který představuje soubor PPTX
  $presentation = new Presentation("template.pptx");
  # uložte prezentaci jako PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **Často kladené otázky**

**Přežijí všechny efekty a funkce PPTX při ukládání do staršího formátu PPT (97–2003)?**

Ne vždy. Formát PPT postrádá některé novější možnosti (např. určité efekty, objekty a chování), takže funkce mohou být při konverzi zjednodušeny nebo rasterizovány.

**Mohu převést pouze vybrané snímky na PPT místo celé prezentace?**

Přímé uložení cílí na celou prezentaci. Pro převod konkrétních snímků vytvořte novou prezentaci pouze s těmito snímky a uložte ji jako PPT; alternativně použijte službu/API, která podporuje parametry konverze po snímcích.

**Jsou podporovány prezentace chráněné heslem?**

Ano. Můžete zjistit, zda je soubor chráněn, otevřít jej s heslem a také [nastavit ochranu/šifrovací nastavení](/slides/cs/php-java/password-protected-presentation/) pro uložený PPT.