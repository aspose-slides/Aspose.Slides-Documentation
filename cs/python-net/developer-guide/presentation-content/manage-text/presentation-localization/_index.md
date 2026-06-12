---
title: Automatizujte lokalizaci prezentací pomocí Pythonu
linktitle: Lokalizace prezentací
type: docs
weight: 100
url: /cs/python-net/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- ID jazyka
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Automatizujte lokalizaci snímků PowerPoint a OpenDocument v Pythonu s Aspose.Slides pomocí praktických ukázek kódu a tipů pro rychlejší celosvětové nasazení."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides nastavit `language_id` pro text v prezentaci. Ukazuje, jak otevřít prezentaci, přidat tvar s textem, přiřadit identifikátor jazyka k textové části a uložit výsledek jako soubor PPTX.

## **Změna jazyka pro prezentaci a text tvaru**
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte na snímek AutoShape typu Obdélník.
- Přidejte nějaký text do TextFrame.
- Nastavte Language Id pro text.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je ilustrována níže v příkladu.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Vyvolává language ID automatický překlad textu?**

Ne. [language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/language_id/) v Aspose.Slides ukládá jazyk pro kontrolu pravopisu a gramatiku, ale nepřekládá ani nemění obsah textu. Jedná se o metadata, která PowerPoint rozumí pro účely korektury.

**Ovlivňuje language ID dělení slov a zalomení řádků při vykreslování?**

V Aspose.Slides slouží [language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/language_id/) k kontrole pravopisu. Kvalita dělení slov a zalamování řádků závisí hlavně na dostupnosti [správné fonty](/slides/cs/python-net/powerpoint-fonts/) a nastaveních rozvržení/zalomení řádků pro daný psací systém. Pro zajištění správného vykreslování zajistěte dostupnost požadovaných fontů, nakonfigurujte [pravidla náhrady fontů](/slides/cs/python-net/font-substitution/) a/nebo [vložte fonty](/slides/cs/python-net/embedded-font/) do prezentace.

**Mohu nastavit různé jazyky v jednom odstavci?**

Ano. [language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/language_id/) se aplikuje na úroveň textové části, takže jeden odstavec může obsahovat více jazyků s odlišnými nastaveními korektury.