---
title: Převést PPTX na PPT v JavaScriptu
linktitle: PPTX na PPT
type: docs
weight: 21
url: /cs/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše převádějte PPTX na PPT pomocí Aspose.Slides — zajistěte bezproblémovou kompatibilitu s formáty PowerPointu při zachování rozvržení a kvality vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPTX do formátu PPT pomocí JavaScriptu. Pokrývá následující téma.

- Převést PPTX na PPT v JavaScriptu

## **JavaScript převod PPTX na PPT**

Pro ukázkový kód JavaScriptu pro převod PPTX na PPT se podívejte na níže uvedenou sekci, tj. [Convert PPTX to PPT](#convert-pptx-to-ppt). Kód pouze načte soubor PPTX a uloží jej ve formátu PPT. Pokud zadáte různé formáty uložení, můžete soubor PPTX také uložit do mnoha dalších formátů, jako je PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích. 

- [Převést PPTX na PDF v JavaScriptu](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/)
- [Převést PPTX na XPS v JavaScriptu](/slides/cs/nodejs-java/convert-powerpoint-to-xps/)
- [Převést PPTX na HTML v JavaScriptu](/slides/cs/nodejs-java/convert-powerpoint-to-html/)
- [Převést PPTX na ODP v JavaScriptu](/slides/cs/nodejs-java/save-presentation/)
- [Převést PPTX na PNG v JavaScriptu](/slides/cs/nodejs-java/convert-powerpoint-to-png/)

## **Převést PPTX na PPT**

Pro převod PPTX na PPT jednoduše předáte název souboru a formát uložení metodě **Save** třídy [**Presentation**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation). Níže uvedený ukázkový kód JavaScriptu převádí prezentaci z PPTX na PPT s výchozími možnostmi.

```javascript
// vytvořte objekt Presentation, který představuje soubor PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// uložte prezentaci jako PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **Často kladené dotazy**

**Přetrvají všechny efekty a funkce PPTX při uložení do staršího formátu PPT (97–2003)?**

Ne vždy. Formát PPT postrádá některé novější možnosti (např. určité efekty, objekty a chování), takže funkce mohou být během převodu zjednodušeny nebo rasterizovány.

**Mohu převést pouze vybrané snímky na PPT místo celé prezentace?**

Přímé uložení cílí na celou prezentaci. Chcete-li převést konkrétní snímky, vytvořte novou prezentaci pouze s těmito snímky a uložte ji jako PPT; alternativně použijte službu/API, která podporuje parametry převodu po jednotlivých snímcích.

**Jsou podporovány prezentace chráněné heslem?**

Ano. Můžete zjistit, zda je soubor chráněn, otevřít jej pomocí hesla a také [nastavit ochranu/šifrování](/slides/cs/nodejs-java/password-protected-presentation/) pro uložený PPT.