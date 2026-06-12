---
title: Automatizovat lokalizaci prezentace v JavaScriptu
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/nodejs-java/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- ID jazyka
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizujte lokalizaci snímků PowerPoint a OpenDocument v JavaScriptu s Aspose.Slides, pomocí praktických ukázek kódu a tipů pro rychlejší globální nasazení."
---
## **Přehled**

Tento článek vysvětluje, jak nastavit `LanguageId` pro text v prezentaci pomocí Aspose.Slides. Ukazuje, jak otevřít prezentaci, přidat tvar s textem, přiřadit identifikátor jazyka k části textu a výsledek uložit jako soubor PPTX.

## **Změna jazyka pro prezentaci a text tvaru**

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) typu [Rectangle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeType#Rectangle).
- Přidejte nějaký text do TextFrame.
- Nastavte Language Id ([Setting Language Id](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-)) pro text.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je demonstrována níže v příkladu.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Spouští Language ID automatický překlad textu?**

Ne. [setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) v Aspose.Slides ukládá jazyk pro kontrolu pravopisu a gramatiku, ale nepřekládá ani ne mění obsah textu. Jedná se o metadata, která PowerPoint rozumí pro korekturu.

**Ovlivňuje Language ID dělení slov a zalamování řádků při vykreslování?**

V Aspose.Slides slouží [setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) k opravě. Kvalita dělení slov a zalamování řádků závisí hlavně na dostupnosti [proper fonts](/slides/cs/nodejs-java/powerpoint-fonts/) a nastaveních rozvržení/zalamování řádků pro daný psací systém. Pro zajištění správného vykreslení zpřístupněte požadované fonty, nakonfigurujte [font substitution rules](/slides/cs/nodejs-java/font-substitution/) a/nebo [embed fonts](/slides/cs/nodejs-java/embedded-font/) v prezentaci.

**Mohu nastavit různé jazyky v jediném odstavci?**

Ano. [setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) se aplikuje na úrovni části textu, takže jeden odstavec může obsahovat více jazyků s odlišnými nastaveními korektury.