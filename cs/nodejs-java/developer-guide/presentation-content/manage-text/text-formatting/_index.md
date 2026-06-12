---
title: Formátování textu prezentace v JavaScriptu
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/nodejs-java/text-formatting/
keywords:
- zvýraznění textu
- regulární výraz
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezery mezi znaky
- vlastnosti písma
- rodina písma
- rotace textu
- úhel rotace
- textový rámec
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámce
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Javu. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Javy. Popisuje zvýrazňování, barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, rotaci, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V následujících příkladech použijeme soubor s názvem "sample.pptx", který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvýraznění textu**

Použijte metodu [TextFrame.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) když potřebujete zvýraznit text, který odpovídá konkrétnímu vzorku v textovém rámci. Metoda aplikuje barvu zvýraznění na odpovídající úryvky textu a lze ji použít s [TextSearchOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/) k řízení způsobu vyhledávání, například pro shodu pouze celých slov.

Ukázkový kód níže zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Zvýrazněte slovo "try" v tvaru.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Zvýrazněte slovo "to" v tvaru.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznění textu pomocí regulárních výrazů**

Metoda [TextFrame.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) zvýrazňuje shody textu nalezené regulárním výrazem. V Node.js přes Javu je toto API exponováno na [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/).

Ukázkový kód níže zvýrazní všechna slova, která obsahují **sedm nebo více znaků**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Zvýrazněte všechna slova s délkou alespoň sedmi znaků.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Nastavení barvy pozadí textu**

Použijte [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) k nastavení výchozí barvy zvýraznění pro odstavec, nebo použijte [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) pro jednotlivé textové úseky.

Následující ukázkový kód ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavte barvu zvýraznění pro celý odstavec.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Ukázkový kód níže demonstruje, jak nastavit barvu pozadí pro **textové úseky s tučným písmem**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavte barvu zvýraznění pro textový úsek.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedé textové úseky](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná doleva, doprava, do bloku apod.

Následující ukázkový kód ukazuje, jak zarovnat odstavec do **středu**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavte zarovnání odstavce na střed.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavení průhlednosti textu**

Průhlednost textu je řízena alfa komponentou barvy přiřazené k [PortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/#getFillFormat--). V příkladech níže je `alpha = 50` hodnota alfa kanálu ARGB na stupnici 0‑255, nikoli procento průhlednosti.

Ukázkový kód níže ukazuje, jak použít průhlednost na **celý odstavec**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Nastavte barvu výplně textu na průhlednou barvu.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázkový kód ukazuje, jak použít průhlednost na **textové úseky s tučným písmem**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Nastavte průhlednost textového úseku.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledné textové úseky](transparent_text_portions.png)

## **Nastavení mezery mezi znaky textu**

Použijte [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) k rozšíření nebo zúžení mezery mezi znaky v textovém rámečku.

Následující JavaScriptový kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit mezeru mezi znaky v **textových úsecích s tučným písmem**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
            portion.getPortionFormat().setSpacing(3); // Rozšířit mezeru mezi znaky.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v textových úsecích](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby byl výstup vykreslení blíže PowerPointu, můžete v takových případech zakázat kerning pro textové úseky používající dotčené písmo. Nastavte [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) na hodnotu podstatně větší než skutečná velikost písma:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Toto nastavení zabraňuje aplikaci kerningu na odpovídající textové úseky a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma ovlivněná tímto specifickým chováním PowerPointu.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) nebo na jednotlivých úsecích pomocí [PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/).

Následující kód nastavuje písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučné, kurzívu, tečkované podtržení a písmo Times New Roman na všechny úseky v odstavci.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Nastavte vlastnosti písma pro odstavec.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Ukázkový kód níže aplikuje podobné vlastnosti na **textové úseky s tučným písmem**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Nastavte vlastnosti písma pro textový úsek.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Vlastnosti písma pro textové úseky](font_properties_for_text_portions.png)

## **Nastavení rotace textu**

Použijte [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastavuje orientaci textu ve tvaru na `Vertical270`, což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Rotace textu](text_rotation.png)

## **Nastavení vlastní rotace pro textové rámečky**

Použijte [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) k nastavení vlastního úhlu rotace pro [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/).

Ukázkový kód níže otáčí textový rámec o 3 stupně ve směru hodinových ručiček uvnitř tvaru:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) a [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) k řízení mezery odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.  
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující ukázkový kód ukazuje, jak specifikovat řádkování v odstavci:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přeteče, nebo automaticky změní velikost tvaru.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení ukotvení textových rámců**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) určuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení tabulátorů textu**

Použijte [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#getTabs--) k nastavení tabulátorů v odstavci.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavení jazyka ověřování pravopisu**

Aspose.Slides poskytuje [PortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), který umožňuje nastavit jazyk ověřování pravopisu pro textový úsek. Jazyk ověřování určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující ukázkový kód ukazuje, jak nastavit jazyk ověřování pravopisu pro textový úsek:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Nastavte Id jazykové kontroly pravopisu.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) k definování výchozího jazyka pro text vytvářený při načítání nebo vytváření prezentace.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Přidejte nový obdélníkový tvar s textem.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Zkontrolujte jazyk první úseky.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího stylu textu**

Pro použití výchozího formátování textu na úrovni prezentace použijte [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Následující ukázkový kód ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro celý text napříč snímky v nové prezentaci.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // Získejte formát odstavce nejvyšší úrovně.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrahování textu s efektem Všechna velká písmena**

V PowerPointu aplikace efektu **All Caps** (všechna velká písmena) způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými písmeny. Když takový textový úsek načtete pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro sladění se zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textcaptype/) a převod vráceného řetězce na velká písmena, pokud je hodnota `All`.

Předpokládejme, že na první snímek souboru sample2.pptx máme následující textový rámeček.

![Efekt Všechna velká písmena](all_caps_effect.png)

Ukázkový kód níže ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell.getTextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/#getTextFrame--) a formátování odstavců pomocí [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Jak použít gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [PortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Nastavte [FillFormat.setFillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) na [FillType.Gradient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) a nakonfigurujte gradientové zastavení, směr a průhlednost.