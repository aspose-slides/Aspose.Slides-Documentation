---
title: Automatizace lokalizace prezentací v Javě
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/java/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- identifikátor jazyka
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Automatizujte lokalizaci snímků PowerPoint a OpenDocument v Javě pomocí Aspose.Slides, s praktickými ukázkami kódu a tipy pro rychlejší globální nasazení."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides nastavit `LanguageId` pro text v prezentaci. Ukazuje, jak otevřít prezentaci, přidat tvar s textem, přiřadit identifikátor jazyka k části textu a uložit výsledek jako soubor PPTX.

## **Změna jazyka pro prezentaci a text tvaru**
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
- Získejte referenci snímku pomocí jeho Indexu.
- Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) typu [Rectangle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapeType#Rectangle).
- Přidejte nějaký text do TextFrame.
- [Nastavení Language Id](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) pro text.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je ukázána níže v příkladu.

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

**Spouští Language ID automatické překládání textu?**

Ne. [Language ID](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) v Aspose.Slides ukládá jazyk pro kontrolu pravopisu a gramatiky, ale nepřekladá ani nemění obsah textu. Jedná se o metadata, která PowerPoint rozumí pro korekturu.

**Ovlivňuje Language ID dělení slov a zalomení řádků při vykreslování?**

V Aspose.Slides je [language ID](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) určeno pro korekturu. Kvalita dělení slov a zalamování řádků závisí především na dostupnosti [správných fontů](/slides/cs/java/powerpoint-fonts/) a nastavení rozvržení/zalamování řádků pro daný psací systém. Pro zajištění správného vykreslování zajistěte dostupnost požadovaných fontů, nakonfigurujte [pravidla substituce fontů](/slides/cs/java/font-substitution/) a/nebo [vložte fonty](/slides/cs/java/embedded-font/) do prezentace.

**Mohu nastavit různé jazyky v jednom odstavci?**

Ano. [Language ID](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) se aplikuje na úrovni části textu, takže jeden odstavec může obsahovat více jazyků s odlišnými nastaveními korektury.