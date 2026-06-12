---
title: Automatizace lokalizace prezentace v C++
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/cpp/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- identifikátor jazyka
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Automatizujte lokalizaci snímků PowerPoint a OpenDocument v C++ pomocí Aspose.Slides, s praktickými ukázkami kódu a tipy pro rychlejší celosvětové nasazení."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides nastavit `LanguageId` pro text v prezentaci. Ukazuje, jak otevřít prezentaci, přidat tvar s textem, přiřadit identifikátor jazyka k části textu a výsledek uložit jako soubor PPTX.

## **Změna jazyka pro prezentaci a text tvaru**
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte do snímku AutoShape typu Obdélník.
- Přidejte nějaký text do TextFrame.
- Nastavte Language Id pro text.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je ukázána níže v příkladu.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **Často kladené otázky**

**Vyvolá Language ID automatický překlad textu?**

Ne. [Language ID](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_languageid/) v Aspose.Slides ukládá jazyk pro kontrolu pravopisu a gramatiky, ale nepřekládá ani nemění obsah textu. Jedná se o metadata, která PowerPoint rozumí při korektuře.

**Ovlivňuje Language ID dělení slov a zalamování řádků při vykreslování?**

V Aspose.Slides slouží [Language ID](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_languageid/) k korektuře. Kvalita dělení slov a zalamování řádků závisí především na dostupnosti [správných písem](/slides/cs/cpp/powerpoint-fonts/) a nastaveních rozvržení/zalamování řádků pro daný psací systém. Pro zajištění správného vykreslení zajistěte potřebná písma, nakonfigurujte [pravidla substituce písem](/slides/cs/cpp/font-substitution/) a/nebo [vložte písma](/slides/cs/cpp/embedded-font/) do prezentace.

**Mohu nastavit různé jazyky v jednom odstavci?**

Ano. [Language ID](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_languageid/) se uplatňuje na úrovni části textu, takže v jednom odstavci lze kombinovat více jazyků s odlišnými nastaveními korektury.