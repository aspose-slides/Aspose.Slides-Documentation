---
title: "Formátování textu prezentace v JavaScriptu"
linktitle: "Formátování textu"
type: docs
weight: 50
url: /cs/nodejs-java/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezery mezi znaky
- vlastnosti písma
- rodina písma
- otočení textu
- úhel otočení
- textový rámeček
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámečku
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Java. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Java. Popisuje barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otáčení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor s názvem **sample.pptx**, který obsahuje jedinou textovou oblast na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárního výrazu viz [Hledat a nahradit text](/slides/cs/nodejs-java/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) k nastavení výchozí barvy zvýraznění pro odstavec, nebo [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) pro jednotlivé části textu.

Následující ukázkový kód ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

Níže uvedený kód ukazuje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavte barvu zvýraznění pro část textu.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedé části textu](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) k nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku atd.

Následující kód ukazuje, jak zarovnat odstavec do **středu**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

Průhlednost textu se řídí alfa komponentou barvy přiřazené pomocí [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). V příkladech níže je `alpha = 50` hodnota kanálu ARGB v rozsahu 0‑255, nikoli procento průhlednosti.

Ukázkový kód níže ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

Následující kód ukazuje, jak aplikovat průhlednost na **části textu s tučným písmem**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Nastavte průhlednost části textu.
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

![Průhledné části textu](transparent_text_portions.png)

## **Nastavení mezery mezi znaky textu**

Použijte [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) k rozšíření nebo zmenšení mezery mezi znaky v textovém rámečku.

Níže uvedený JavaScriptový kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Poznámka: Použijte záporné hodnoty pro zmenšení mezery mezi znaky.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Rozšíří mezery mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Kód níže ukazuje, jak rozšířit mezeru mezi znaky v **částech textu s tučným písmem**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Poznámka: Použijte záporné hodnoty pro zmenšení mezery mezi znaky.
            portion.getPortionFormat().setSpacing(3); // Rozšíří mezery mezi znaky.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v částech textu](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, pokud PowerPoint ignoruje data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl v takových případech blíže vzhledu v PowerPointu, můžete zakázat kerning pro části textu, které používají dotčené písmo. Nastavte [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) na hodnotu podstatně větší než skutečná velikost písma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

Toto nastavení zabraňuje aplikaci kerningu na odpovídající části textu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma ovlivněná tímto specifickým chováním PowerPointu.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) nebo na jednotlivých částech pomocí [PortionFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portionformat/).

Následující kód nastavuje písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučné, kurzívou, tečkované podtržení a písmo Times New Roman na všechny části odstavce.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

Kód níže aplikuje podobné vlastnosti na **části textu s tučným písmem**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Nastavte vlastnosti písma pro část textu.
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

![Vlastnosti písma pro části textu](font_properties_for_text_portions.png)

## **Nastavení otočení textu**

Použijte [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující kód nastavuje orientaci textu v tvaru na `Vertical270`, což otočí text **o 90 stupňů proti směru hodinových ručiček**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Otočení textu](text_rotation.png)

## **Nastavení vlastního otočení pro textové rámečky**

Použijte [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) k nastavení vlastního úhlu otočení pro [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/).

Níže uvedený kód otočí textový rámeček o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Vlastní otočení textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) a [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) k řízení vzdálenosti odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro specifikaci řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro specifikaci řádkování v bodech.

Následující kód ukazuje, jak zadat řádkování uvnitř odstavce:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Řádkování uvnitř odstavce](line_spacing.png)

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přeteče nebo automaticky změní velikost tvaru.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro spočítání řádků po automatickém zalomení a zjištění, jak se mění šířka textu nebo tvaru, viz [Počítat vykreslené řádky](/slides/cs/nodejs-java/manage-paragraph/). Pouze počet řádků neindikuj

e, zda text přeteče svůj kontejner.

## **Nastavení ukotvení textových rámečků**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení tabulace textu**

Použijte [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraphformat/#getTabs--) k konfiguraci tabulátorů v odstavci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

## **Nastavení jazyka korekce pravopisu**

Aspose.Slides poskytuje [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), který umožňuje nastavit jazyk korekce pravopisu pro část textu. Jazyk korekce určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující kód ukazuje, jak nastavit jazyk korekce pravopisu pro část textu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Nastavte Id korekčního jazyka.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) k definování výchozího jazyka pro text vytvářený při načítání nebo vytváření prezentace.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Přidejte nový obdélníkový tvar s textem.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Zkontrolujte jazyk první části.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího stylu textu**

Pro použití výchozího formátování textu na úrovni prezentace použijte [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Následující kód ukazuje, jak nastavit výchozí tučné písmo s velikostí 14 pt pro veškerý text napříč snímky v nové prezentaci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

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

## **Extrahování textu s efektem VŠECH PRÁVKŮ VELKÝMI PÍSMENY**

V PowerPointu aplikace **All Caps** (všechna velká písmena) způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně zadán malými. Při získávání takové části textu pomocí Aspose.Slides knihovna vrátí text přesně tak, jak byl zadán. Pro odpovídající zobrazení textu zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textcaptype/) a převeďte vrácený řetězec na velká písmena, pokud je hodnota `All`.

Předpokládejme, že máme následující textovou oblast na první snímek souboru sample2.pptx.

![Efekt All Caps](all_caps_effect.png)

Níže uvedený kód ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
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

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). Nastavte [FillFormat.setFillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) na [FillType.Gradient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.