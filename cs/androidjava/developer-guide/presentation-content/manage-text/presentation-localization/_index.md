---
title: Automatizujte lokalizaci prezentací na Androidu
linktitle: Lokalizace prezentací
type: docs
weight: 100
url: /cs/androidjava/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- ID jazyka
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Automatizujte lokalizaci snímků PowerPoint a OpenDocument v Javě s Aspose.Slides pro Android, pomocí praktických ukázek kódu a tipů pro rychlejší globální nasazení."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides nastavit `LanguageId` pro text v prezentaci. Ukazuje, jak otevřít prezentaci, přidat tvar s textem, přiřadit identifikátor jazyka k části textu a výsledek uložit jako soubor PPTX.

## **Změna jazyka pro prezentaci a text tvaru**
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape) typu [Rectangle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ShapeType#Rectangle).
- Přidejte nějaký text do TextFrame.
- [Nastavení jazykového ID](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) k textu.
- Uložte prezentaci jako soubor PPTX.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Spouští ID jazyka automatický překlad textu?**

Ne. [Language ID](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) v Aspose.Slides ukládá jazyk pro kontrolu pravopisu a gramatiky, ale nepřekládá ani nemění obsah textu. Jedná se o metadata, která PowerPoint rozumí pro korekturu.

**Ovlivňuje ID jazyka dělení slov a zalomení řádků během vykreslování?**

V Aspose.Slides je [language ID](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) určeno pro korekturu. Kvalita dělení slov a zalamování řádků primárně závisí na dostupnosti [správných písem](/slides/cs/androidjava/powerpoint-fonts/) a nastavení rozvržení/zalamování řádků pro daný psací systém. Pro zajištění správného vykreslování zajistěte dostupnost potřebných písem, nakonfigurujte [pravidla náhrady písem](/slides/cs/androidjava/font-substitution/) a/nebo [vložená písma](/slides/cs/androidjava/embedded-font/) v prezentaci.

**Mohu nastavit různé jazyky v rámci jednoho odstavce?**

Ano. [Language ID](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) se aplikuje na úroveň části textu, takže jeden odstavec může obsahovat více jazyků s odlišnými nastaveními korektury.