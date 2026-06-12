---
title: Převod PPTX na PPT v Pythonu
linktitle: PPTX na PPT
type: docs
weight: 21
url: /cs/python-net/convert-pptx-to-ppt/
keywords:
- PPTX na PPT
- převést PPTX na PPT
- převést PowerPoint
- převést prezentaci
- Python
- Aspose.Slides
description: "Jednoduše převádějte PPTX na PPT pomocí Aspose.Slides pro Python přes .NET—zajistěte bezproblémovou kompatibilitu s formáty PowerPointu při zachování rozvržení a kvality vaší prezentace."
---
## **Přehled**

Aspose.Slides for Python vám umožňuje převádět moderní prezentace PPTX do staršího formátu PPT výhradně v kódu. Otevřete soubor PPTX a exportujte jej jako PPT při zachování obsahu a rozvržení prezentace, což výsledný soubor učiní kompatibilním se staršími verzemi PowerPointu. Stejný postup může vytvářet i jiné výstupy — například PDF, XPS, ODP, HTML nebo obrázky — takže se snadno začlení do skriptů, CI pipeline a dávkového zpracování.

## **Převod PPTX na PPT**

Pro převod PPTX na PPT stačí předat název souboru a formát uložení metodě [save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Níže uvedený příklad v Pythonu převádí prezentaci z PPTX do PPT pomocí výchozích možností.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
presentation = slides.Presentation("presentation.pptx")

# Uložte prezentaci jako soubor PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Často kladené otázky**

**Přežijí při ukládání do staršího formátu PPT (97–2003) všechny efekty a funkce PPTX?**

Ne vždy. Formát PPT postrádá některé novější schopnosti (např. určité efekty, objekty a chování), takže některé funkce mohou být během konverze zjednodušeny nebo rasterizovány.

**Mohu převést pouze vybrané snímky na PPT místo celé prezentace?**

Přímé uložení cílí na celou prezentaci. Pro převod konkrétních snímků vytvořte novou prezentaci jen s těmito snímky a uložte ji jako PPT; alternativně použijte službu/API, která podporuje parametry konverze po snímku.

**Jsou podporovány prezentace chráněné heslem?**

Ano. Můžete zjistit, zda je soubor chráněn, otevřít jej pomocí hesla a také [nastavit ochranu/šifrování](/slides/cs/python-net/password-protected-presentation/) pro uložený PPT.

**Viz také:**
- [Převod PPT a PPTX do PDF v Pythonu | Pokročilé možnosti](/slides/cs/python-net/convert-powerpoint-to-pdf/)
- [Převod prezentací PowerPoint do XPS v Pythonu](/slides/cs/python-net/convert-powerpoint-to-xps/)
- [Převod prezentací PowerPoint do HTML v Pythonu](/slides/cs/python-net/convert-powerpoint-to-html/)
- [Převod snímků PowerPoint do PNG v Pythonu](/slides/cs/python-net/convert-powerpoint-to-png/)