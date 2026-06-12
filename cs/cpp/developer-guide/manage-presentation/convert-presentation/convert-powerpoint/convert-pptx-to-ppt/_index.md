---
title: Převést PPTX na PPT v C++
linktitle: PPTX na PPT
type: docs
weight: 21
url: /cs/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Jednoduše převést PPTX na PPT pomocí Aspose.Slides pro C++ — zajistěte bezproblémovou kompatibilitu s formáty PowerPoint a zachovejte rozvržení a kvalitu vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentaci PowerPoint ve formátu PPTX do formátu PPT pomocí C++. Následující téma je pokryto.

- Převést PPTX na PPT v C++

## **Převést PPTX na PPT v C++**

Pro ukázkový kód v C++ pro převod PPTX na PPT se podívejte na sekci níže, tj. [Převést PPTX na PPT](#convert-pptx-to-ppt). Stačí načíst soubor PPTX a uložit jej ve formátu PPT. Zadáním různých formátů uložení můžete také uložit soubor PPTX do mnoha dalších formátů, jako je PDF, XPS, ODP, HTML atd., jak je diskutováno v těchto článcích. 

- [Převést PPTX na PDF v C++](/slides/cs/cpp/convert-powerpoint-to-pdf/)
- [Převést PPTX na XPS v C++](/slides/cs/cpp/convert-powerpoint-to-xps/)
- [Převést PPTX na HTML v C++](/slides/cs/cpp/convert-powerpoint-to-html/)
- [Převést PPTX na ODP v C++](/slides/cs/cpp/save-presentation/)
- [Převést PPTX na PNG v C++](/slides/cs/cpp/convert-powerpoint-to-png/)

## **Převést PPTX na PPT**
Chcete‑li převést PPTX na PPT, jednoduše předávejte název souboru a formát uložení metodě **Save** třídy [**Presentation**](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/). Níže uvedený příklad kódu v C++ převádí prezentaci z PPTX do PPT s výchozími možnostmi.

```cpp
// Načíst PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Uložit ve formátu PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **Často kladené otázky**

**Přežijí všechny efekty a funkce PPTX při ukládání do staršího formátu PPT (97–2003)?**

Ne vždy. Formát PPT postrádá některé novější funkce (např. určité efekty, objekty a chování), takže některé vlastnosti mohou být při konverzi zjednodušeny nebo rasterizovány.

**Mohu převést pouze vybrané snímky do PPT místo celé prezentace?**

Přímé uložení cílí na celou prezentaci. Pro převod konkrétních snímků vytvořte novou prezentaci pouze s těmito snímky a uložte ji jako PPT; alternativně použijte službu/API, která podporuje parametry konverze po jednotlivých snímcích.

**Jsou podporovány prezentace chráněné heslem?**

Ano. Můžete zjistit, zda je soubor chráněn, otevřít jej s heslem a také [nastavit ochranu/šifrování](/slides/cs/cpp/password-protected-presentation/) pro uložený PPT.