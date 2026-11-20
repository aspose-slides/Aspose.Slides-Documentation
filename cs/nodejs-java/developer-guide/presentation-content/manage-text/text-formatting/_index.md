---
title: Formátování textu prezentace v JavaScriptu
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/nodejs-java/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- rozestup znaků
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
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Javy. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Javy. Pokrývá barvy pozadí, průhlednost, rozestupy znaků, vlastnosti písma, rotaci, rozestupy odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). Prvním tvarem na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné části, používají účinné formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Vyhledat a nahradit text](/slides/cs/nodejs-java/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) k nastavení výchozí barvy zvýraznění pro odstavec, nebo [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) pro jednotlivé části textu.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Explicitní barvy zvýraznění na jednotlivých částech mají přednost před tímto výchozím nastavením:

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

Níže uvedený ukázkový kód demonstruje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

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

## **Zarovnat odstavce textu**

Použijte [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, zarovnaná do bloku atd.

Následující ukázkový kód ukazuje, jak zarovnat odstavec **do středu**:

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

## **Zarovnat písma v řádku**

Použijte [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) k vertikálnímu zarovnání částí textu s různými velikostmi písma v řádku. Toto nastavení se vztahuje na celý odstavec a řídí zarovnání v každém řádku.

Následující samostatný příklad vytváří čtyři popsaná textová pole na jednom snímku. Každý odstavec obsahuje stejný text ve velikostech 18, 36 a 54 bodů s různým zarovnáním písma. Používá Arial, vypíná automatické přizpůsobení a zalamování a ponechává textové rámy dostatečně velké pro jeden řádek.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Porovnání zarovnání Baseline, Top, Center a Bottom při smíšených velikostech písma](font_alignment.png)

Zarovnání písma používá metriky písma, takže viditelné hrany jednotlivých znaků nemusí být přesně zarovnané. Příklad zahrnuje jak velké písmeno, tak znak s dolním výčnem, aby ukázal rozdíl mezi zarovnáním k základní linii a dolní. Dostupnost písma a jeho náhrada, použité znaky a rozdíl ve velikostech písma ovlivňují výsledek. Rozměry rámců, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; při porovnávání režimů používejte stejná písma a nastavení rozvržení.

Toto nastavení se liší od [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), které řídí vodorovné zarovnání odstavce, a od [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), které pozicuje textový blok vertikálně uvnitř tvaru. Formátování horního a dolního indexu pomocí [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) posouvá jednotlivé části relativně k základní linii místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavit průhlednost textu**

Průhlednost textu je řízena alfa komponentou barvy přiřazené k [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). V níže uvedených příkladech je `alpha = 50` hodnota kanálu ARGB na stupnici 0–255, nikoli procento průhlednosti.

Ukázkový kód níže ukazuje, jak použít průhlednost na **celý odstavec**:

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

Následující ukázkový kód ukazuje, jak použít průhlednost na **části textu s tučným písmem**:

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

## **Nastavit rozestup znaků v textu**

Použijte [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) k rozšíření nebo zmenšení rozestupu mezi znaky v textovém poli. Příklady přidávají 3 body rozestupu; záporné hodnoty zmenšují text.

Následující JavaScriptový kód ukazuje, jak rozšířit rozestup znaků v **celém odstavci**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Poznámka: Použijte záporné hodnoty ke zmenšení rozestupu znaků.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Rozšířit rozestup znaků.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Rozestup znaků v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit rozestup znaků v **částech textu s tučným písmem**:

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
            // Poznámka: Použijte záporné hodnoty ke zmenšení rozestupu znaků.
            portion.getPortionFormat().setSpacing(3); // Rozšířit rozestup znaků.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Rozestup znaků v částech textu](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může vypadat text vykreslený Aspose.Slides mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby byl výstup v takových případech blíže PowerPointu, můžete zakázat kerning pro části textu, které používají dotčené písmo. Nastavte [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) na hodnotu větší než skutečná velikost písma. Tento příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na první snímku. Kontroluje účinná jména písem, včetně zděděných, a nastavuje práh 100 bodů pro části, které používají Roboto. Tím se zakáže kerning pro odpovídající části s velikostí písma pod 100 bodů:

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
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma ovlivněná tímto specifickým chováním PowerPointu.

## **Spravovat vlastnosti písma v textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) nebo na jednotlivých částech pomocí [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

Následující příklad nastaví výchozí písmo prvního odstavce na 12‑bodové Times New Roman s tučným, kurzívovým a tečkovaným podtržením. Explicitní formátování na jednotlivých částech má přednost před těmito výchozími hodnotami.

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

Následující příklad aplikuje 13‑bodové Times New Roman, kurzívu a tečkované podtržení na části, jejichž účinné formátování je tučné:

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

## **Ovládání normalizace výšky textu**

Použijte [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) při reprodukci typografie šablon nebo zkoumání rozdílů ve výšce znaků. V PowerPointu zapnutí normalizace protahuje nebo stlačuje jednotlivé znaky vertikálně, aby měly jednotnou viditelnou výšku v rámci textové části. Nezaručuje stejnou výšku textu napříč různými písmy.

Nastavte vlastnost na [NullableBool.True nebo False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) pro explicitní zapnutí nebo vypnutí normalizace. `NullableBool.NotDefined` nechává místní nastavení nevyplněné, takže část zdědí hodnotu, například z [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) odstavce. To neznamená `False`. Použijte [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) a přečtěte [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) pro získání vyřešené boolovské hodnoty.

Následující samostatný příklad vyžaduje nainstalované **Arial**. Vytváří dva textové bloky obsahující stejné velké písmeno, malá písmena, dolní výčny a diakritiku při 54 bodech. Oba odstavce mají ve výchozím nastavení zapnutou normalizaci. Horní část ji explicitně vypíná; dolní část ji zdědí. Rozměry rámců, okraje a řádkování jsou identické, zalamování a automatické přizpůsobení jsou vypnuté, aby byl srovnání konzistentní. Příklad vypíše `False: false` a `NotDefined: true`, poté uloží „text_height_normalization.pptx“.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Porovnání níže bylo exportováno ze uložené prezentace. Horní řada má normalizaci vypnutou (`False`); spodní řada ji zdědí (`NotDefined` → `True`). Pro reprodukci vzhledu mějte nainstalované Arial.

![Text Arial 54 bodů s vypnutou normalizací nahoře a zděděnou normalizací dole](text_height_normalization.png)

Normalizace mění výšku znaků, aniž by měnila přiřazenou hodnotu [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight), která určuje velikost písma v bodech. Odstavec [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) řídí řádkování, zatímco text‑frame [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) určuje, jak se text nebo jeho kontejner přizpůsobí. Tato nastavení slouží k odlišným účelům a mohou nezávisle ovlivnit celkové rozvržení. Další informace o formátování odstavců a dědičnosti najdete v kapitole [Spravovat odstavec](/slides/cs/nodejs-java/manage-paragraph/).

## **Použít a odstranit přeškrtnutí**

Použijte [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) na část textu k zobrazení oprav, zrušených výrazů nebo předchozích cen bez mazání původního textu. Nastavte na [TextStrikethroughType.Single nebo Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) pro jednu nebo dvě čáry přes text.

Pro odstranění přeškrtnutí použijte [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). Toto explicitně zakáže efekt, i když okolní formátování specifikuje přeškrtnutí. Naopak [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) nechává místní nastavení nedefinované, což umožňuje části zdědit formátování, například z odstavce. To nezaručuje, že přeškrtnutí bude odstraněno. Použijte [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) k načtení výsledného formátování, včetně zděděných hodnot.

Následující samostatný příklad vytváří tři cenové srovnání. Každý odstavec má samostatné části pro popisek, původní cenu a aktuální cenu, takže je ovlivněna jen původní cena. V první řadě se přeškrtnutí použije a následně odstraní; ostatní řady si ponechají jednoduché a dvojité přeškrtnutí. Změna tohoto nastavení zachovává text i jeho další formátování, včetně tučné původní ceny.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Použijte přeškrtnutí a poté jej explicitně odstraňte od první předchozí ceny.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek, shora dolů: žádné přeškrtnutí, jednoduché přeškrtnutí a dvojité přeškrtnutí.

![Původní ceny bez přeškrtnutí, s jednoduchým a s dvojitým přeškrtnutím](strikethrough.png)

## **Nastavit rotaci textu**

Použijte [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastaví orientaci textu v tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

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

![Rotace textu](text_rotation.png)

## **Nastavit vlastní rotaci textových rámců**

Použijte [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) k nastavení vlastní úhlu rotace pro [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

Níže uvedený kód otáčí textový rám o 3 stupně ve směru hodinových ručiček uvnitř tvaru:

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

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) a [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) pro řízení rozestupů odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující příklad nastaví rozestup uvnitř prvního odstavce na 200 % výšky řádku (dvojnásobné řádkování):

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

## **Ovládání zalamování řádků**

Pravidla zalamování řádků odstavce jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinský a východoasijský text. Následující metody patří do [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), takže se vztahují na celý odstavec:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) řídí pravidla zalamování latinského textu. V smíšeném textu může změna také ovlivnit, kde se zalamuje sousední východoasijský text a interpunkce.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) řídí pravidla zalamování východoasijského textu, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), které umožňuje automatické zalamování v textovém rámci. Ovlivňují rozvržení, když k zalamování dochází; nevkládají znaky pro zalomení řádku. Explicitní zalomení řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytváří úzký textový blok obsahující čínštinu a latinku. Explicitně nastaví obě možnosti zalamování a uloží „line_breaking.pptx“. Pro experimentování s libovolným pravidlem změňte odpovídající hodnotu a ostatní nastavení nechte beze změny. Příklad používá 24‑bodové Arial a SimSun s šířkou rámce 160 bodů a nulovými horizontálními okraji textového rámce. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) je voláno s [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/), aby velikost textu a rozměry rámce zůstaly pevné.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ovládání visící interpunkce**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) umožňuje oprávněné interpunkci vyčnívat za pravý okraj řádku místo aby zabírala další řádek. Používá se na celý odstavec a liší se od visícího odrážky.

Následující samostatný příklad zapíná visící interpunkci v 100‑bodovém širokém textovém rámci a ukládá „hanging_punctuation.pptx“. S 24‑bodovým Arial a nulovými horizontálními okraji textového rámce poslední tečka zůstane za slovem „sentence“ a vyčnívá za pravý okraj textu. Nastavte vlastnost na [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) pro porovnání: s těmito nastaveními tečka zabírá samostatný řádek. Zalamování je zapnuto a automatické přizpůsobení je vypnuto, aby byla šířka pevná.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ne každá interpunkční značka může viset. Výše popsané [podmínky písma a rozvržení](#control-line-breaking) také platí pro toto srovnání: změna písma, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může viditelný rozdíl odstranit.

## **Nastavit typ automatického přizpůsobení pro textové rámy**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, překročí nebo automaticky změní velikost tvaru. Následující příklad konfiguruje tvar tak, aby se přizpůsobil svému textu, a ukládá výsledek do „autofit_type.pptx“.

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

Pro spočítání řádků po automatickém zalomení a zjištění, jak změna šířky textu nebo tvaru ovlivní výsledek, viz [Count Rendered Lines](/slides/cs/nodejs-java/manage-paragraph/). Počet řádků sám o sobě neukazuje, zda text přesahuje svůj kontejner.

## **Nastavit ukotvení textových rámců**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) určuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole. Následující příklad ukotví text ke spodnímu okraji prvního tvaru a uloží výsledek do „text_anchor.pptx“.

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

## **Nastavit tabulaci textu**

Použijte [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) k nastavení tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levým zarovnaný tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující znak tabulátoru.

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

![Tabulátory v odstavci](paragraph_tabs.png)

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), který umožňuje nastavit jazyk kontroly pravopisu pro část textu. Jazyk kontroly pravopisu určuje jazyk použitý pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje „presentation.pptx“ s textovým polem jako prvním tvarem na první snímku a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce textem „1。“, nastaví SimSun jako jeho písmo a přiřadí jazyk kontroly pravopisu pro zjednodušenou čínštinu (`zh-CN`). Výsledek uloží do „proofing_language.pptx“:

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

    // Nastavte Id jazyka pro kontrolu pravopisu.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kopírovat jazyková metadata**

Při kopírování vícejazyčného textu ze šablony zachovejte jak [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId), tak [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Následující samostatný příklad vytvoří zdrojovou část s US English jako jejím jazykem a francouzštinou jako alternativním jazykem a zkopíruje text i identifikátory do části v nové prezentaci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Pokud zdroj nemá alternativní jazyk, null vymaže hodnotu v cíli.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro vyzkoušení zdroje bez alternativního jazyka vynechte přiřazení `"fr-FR"`. Alternativní identifikátor bude pak `null` a stejný příkaz pro kopírování zachová jeho nepřítomnost, aniž by zavedl výchozí hodnotu, i když cíl dříve měl přiřazen alternativní jazyk.

Tyto identifikátory uchovávají jazyková metadata. Jejich zachování neovlivňuje, který slovník PowerPoint vybere pro kontrolu pravopisu nebo gramatiky.

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) k definování výchozího jazyka pro text vytvářený při načítání nebo vytváření prezentace. Následující příklad vytvoří prezentaci s US English jako výchozím jazykem textu, přidá textové pole a vytiskne `en-US` pro první část textu.

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

## **Nastavit výchozí styl textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

Následující příklad nastaví 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží jej do „default_text_style.pptx“. Text může tato výchozí nastavení zdědit, pokud není přepsáno konkrétnějším formátováním.

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

## **Extrahovat text s efektem VŠECH NAHRANÝCH PÍSMEN**

V PowerPointu aplikace efektu **All Caps** (všechny velké) způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně zadán malými. Když tento textový úsek získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu s vykresleným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) a pokud je hodnota `All`, převeďte vrácený řetězec na velká písmena.

Tento příklad vyžaduje „sample2.pptx“ s textovým polem jako prvním tvarem na první snímku. První odstavec jeho první část obsahuje „Hello, Aspose!“ s aplikovaným efektem All Caps, jak je znázorněno níže.

![Efekt All Caps](all_caps_effect.png)

Níže uvedený ukázkový kód ukazuje, jak extrahovat text s aplikovaným **All Caps** efektem:

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

**Jak mohu upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) a formátování odstavců pomocí [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Jak mohu aplikovat přechodový barevný efekt na text na snímku PowerPoint?**

Pro aplikaci přechodové barvy na text použijte [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Nastavte [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) na [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) a nakonfigurujte přechodové zastávky, směr a průhlednost.