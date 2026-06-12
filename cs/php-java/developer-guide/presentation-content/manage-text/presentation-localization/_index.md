---
title: Automatizace lokalizace prezentací v PHP
linktitle: Lokalizace prezentací
type: docs
weight: 100
url: /cs/php-java/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- jazykový identifikátor
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Automatizujte lokalizaci snímků PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP prostřednictvím Javy, s praktickými ukázkami kódu a tipy pro rychlejší globální nasazení."
---
## **Přehled**

Tento článek vysvětluje, jak nastavit `LanguageId` pro text v prezentaci pomocí Aspose.Slides. Ukazuje, jak otevřít prezentaci, přidat tvar s textem, přiřadit jazykový identifikátor k části textu a uložit výsledek jako soubor PPTX.

## **Změna jazyka pro text prezentace a tvaru**
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) typu [Rectangle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ShapeType#Rectangle) na snímek.
- Přidejte nějaký text do TextFrame.
- [Nastavte Language Id](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId) na text.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je níže ukázána v příkladu.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Spouští Language ID automatický překlad textu?**

Ne. [Language ID](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId) v Aspose.Slides ukládá jazyk pro kontrolu pravopisu a gramatiky, ale nepřekládá ani nemění obsah textu. Jedná se o metadata, která PowerPoint rozumí pro korekturu.

**Ovlivňuje Language ID dělení slov a zalamování řádků během vykreslování?**

V Aspose.Slides je [language ID](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId) určeno pro korekturu. Kvalita dělení slov a zalamování řádků primárně závisí na dostupnosti [proper fonts](/slides/cs/php-java/powerpoint-fonts/) a nastaveních rozvržení/zalamování řádků pro daný písemný systém. Pro zajištění správného vykreslení zajistěte dostupnost požadovaných písem, nakonfigurujte [font substitution rules](/slides/cs/php-java/font-substitution/), a/nebo [embed fonts](/slides/cs/php-java/embedded-font/) do prezentace.

**Mohu nastavit různé jazyky v jednom odstavci?**

Ano. [Language ID](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId) se aplikuje na úroveň částí textu, takže jeden odstavec může kombinovat několik jazyků s odlišnými nastaveními korektury.