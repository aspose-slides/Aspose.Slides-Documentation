---
title: Prezentáció szövegének formázása JavaScriptben
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/nodejs-java/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sortávolság
- autofit tulajdonság
- szövegkeret rögzítés
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js Java-n keresztül. Testreszabhatja a betűket, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázható a szöveg PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js Java-n keresztül használva. Tárgyalja a háttérszíneket, átlátszóságot, karakterközöket, betűtulajdonságokat, forgatást, bekezdésközöket, automatikus illesztés viselkedését, szöveg rögzítését, tabulátorállásokat és nyelvi beállításokat.

Kivéve, ha másként van feltüntetve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdésében az alább látható szöveg található. Mind a dia, mind az alakzat indexei nullától indulnak. A félkövér részeket kiválasztó példák hatékony formázást alkalmaznak, beleértve az örökölt félkövér formázást:

![Sample text](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezések kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/nodejs-java/search-and-replace-text/).

## **Szöveg háttérszínének beállítása**

Használja a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelési szín beállításához, vagy a [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) metódust egyedi szövegrésszekhez.

A következő példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyedi részeken megadott kiemelési színek felülbírálják ezt az alapértelmezést:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a kiemelés színét az egész bekezdésre.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The gray paragraph](gray_paragraph.png)

Az alábbi kódpélda bemutatja, hogyan állítható be a háttérszín **félkövér betűkkel rendelkező szövegrések** számára:

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
            // Állítsa be a szövegréssze kiemelési színét.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The gray text portions](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) metódust a bekezdés igazításának beállításához egy szövegkeretben. Az érték lehet középre, balra, jobbra, sorkizárt stb.

A következő kódpélda megmutatja, hogyan igazítható a bekezdés **középre**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a bekezdés igazítását középre.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The aligned paragraph](aligned_paragraph.png)

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) szín alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódpélda megmutatja, hogyan alkalmazható átlátszóság az **egész bekezdésre**:

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

    // Állítsa be a szöveg kitöltőszínét átlátszó színre.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent paragraph](transparent_paragraph.png)

A következő kódpélda megmutatja, hogyan alkalmazható átlátszóság **félkövér betűkkel rendelkező szövegrések** esetén:

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

            // Állítsa be a szövegréssze átlátszóságát.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent text portions](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használja a [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy szűkítésére egy szövegdobozban. A példák 3 pont közközt adnak hozzá; negatív értékek szűkítik a szöveget.

A következő JavaScript kód megmutatja, hogyan növelhető a karakterköz az **egész bekezdésben**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használatával a karakterköz összenyomható.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Bővítse a karakterközöt.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Az alábbi kódpélda megmutatja, hogyan növelhető a karakterköz **félkövér betűkkel rendelkező szövegrések** esetén:

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
            // Megjegyzés: Negatív értékek használatával a karakterköz összenyomható.
            portion.getPortionFormat().setSpacing(3); // Bővítse a karakterközöt.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPoint-ban megjelenő szöveg. Ez akkor fordulhat elő, ha a PowerPoint figyelmen kívül hagyja a kerning adatokat egyes betűtípusoknál, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a kerning be van kapcsolva a PowerPoint beállításaiban.

A PowerPoint-hoz hasonlóbb megjelenés elérése érdekében letilthatja a kerninget azoknál a szövegréseknél, amelyek az érintett betűtípust használják. Állítsa a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) értékét nagyobbra, mint a tényleges betűméret. Ez a példa a "presentation.pptx" fájlt igényli, amelyen az első dián az első alakzat egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be azoknál a részeknél, amelyek a Roboto betűtípust használják. Ez letiltja a kerninget a 100 pont alatti betűmérettel rendelkező egyező részeknél:

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

A küszöb alatti egyező szövegnél ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelését a PowerPoint vizuális kimenetéhez igazítani az érintett betűtípusok esetében.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/) segítségével.

A következő példa beállítja az első bekezdés alapértelmezett betűjét 12 pontos Times New Roman-ra, félkövér, dőlt és pontozott aláhúzással. Az egyedi részeken megadott explicit formázás felülírja ezeket az alapértelmezéseket:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Állítsa be a bekezdés betűtulajdonságait.
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

Az eredmény:

![The font properties for the paragraph](font_properties_for_paragraph.png)

A következő példa 13 pontos Times New Roman, dőlt formázást és pontozott aláhúzást alkalmaz azon részekre, amelyek hatékony formázása félkövér:

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

            // Állítsa be a szövegréssz betűtulajdonságait.
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

Az eredmény:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használja a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust egy előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódpélda a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textverticaltype/) értékre állítja, ami a szöveget **90 fokkal óramutató járásával ellentétesen** forgatja:

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

Az eredmény:

![The text rotation](text_rotation.png)

## **Egyedi forgatás beállítása szövegkeretekhez**

Használja a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) metódust egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) számára.

Az alábbi kódpélda a szövegkeretet 3 fokkal forgatja az óramutató járásával megegyező irányban az alakzaton belül:

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

Az eredmény:

![The custom text rotation](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) metódusokkal szabályozza a bekezdésközöket. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív érték esetén a sortávolság a sor magasságának százalékában adható meg.
* Negatív érték esetén a sortávolság pontokban adható meg.

A következő példa a első bekezdésen belüli távolságot a sor magasságának 200%-ára (dupla sorköz) állítja:

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

Az eredmény:

![The line spacing within the paragraph](line_spacing.png)

## **Sorátlás szabályozása**

A bekezdés sorátlás szabályai szűk szövegdobozokban és olyan prezentációkban hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. Az alábbi módszerek a [ParagraphFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/) részei, így egy teljes bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) a latin sorátlás szabályait irányítja. Vegyes szöveg esetén ennek módosítása befolyásolhatja a szomszédos kelet-ázsiai szöveg és írásjelek tördelését is.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) a kelet-ázsiai sorátlás szabályait irányítja, beleértve a sor elején és végén megengedett karaktereket.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) beállítást, amely automatikus tördelést engedélyez egy szövegkereten belül. Ők a tördelés során a elrendezést befolyásolják; nem helyeznek be sortörés karaktert. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

A következő önálló példa szűk szövegdobozt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sorátlási beállítást explicit módon megadja, majd elmenti a „line_breaking.pptx” fájlt. A szabályok teszteléséhez változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűket használ 160 pontos keretszélességgel és nulla vízszintes szövegkeret-margóval. A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) metódus a [TextAutofitType.None](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textautofittype/) értékre van állítva, így a szövegméret és a keretméretek rögzítve maradnak.

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

## **Hanging punctuation szabályozása**

A [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) lehetővé teszi, hogy az elegendő interpunkció a sor jobb szélén túlnyúljon, ahelyett, hogy a következő sorra kerülne. Ez a teljes bekezdésre vonatkozik, és különbözik a hanging indent-től.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a hanging punctuation-t, és elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial és nulla vízszintes szövegkeret-margó esetén az utolsó pont a „sentence” szó után marad, és a jobb szél fölé nyúlik. A tulajdonságot állítsa [NullableBool.False](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben az esetben a pont külön sorba kerül. A tördelés engedélyezett, az autofit le van tiltva, így a rendelkezésre álló szélesség rögzített.

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

Nem minden írásjel függeszthető. A látható eredmény a betűtípus elérhetőségétől és az elrendezéstől függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az autofit beállítások módosítása eltüntetheti a látható különbséget.

## **Autofit típus beállítása szövegkeretekhez**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a konténer határait. Használja ezt annak szabályozására, hogy a szöveg zsugorodjon, túlcsorduljon vagy automatikusan átméretezze a formát.

A következő példa úgy konfigurálja a formát, hogy a szöveghez igazodva méretezze át, majd elmenti az eredményt a „autofit_type.pptx” fájlba.

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

A sorok számlálásához automatikus tördelés után, illetve a szöveg vagy forma szélességének változásához lásd a [Count Rendered Lines](/slides/hu/nodejs-java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túlcsordul-e a konténerből.

## **Szövegkeret rögzítésének beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) meghatározza, hogy a szöveg függőlegesen hogyan helyezkedjen el egy alakzatban, például a tetején, közepén vagy alján. A következő példa a szöveget az első alakzat aljára rögzíti, majd elmenti a „text_anchor.pptx” fájlt.

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

## **Tabulátorok beállítása szöveghez**

Használja a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getTabs--) metódusokat a bekezdés tabulátorállásainak konfigurálásához. A következő példa az alapértelmezett tabulátor-intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontra. Ezek a beállítások a tab karaktert tartalmazó szövegre hatnak.

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

Az eredmény:

![The paragraph tabs](paragraph_tabs.png)

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) metódussal lehetővé teszi a szövegrésszek helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg, mely nyelvet használja a PowerPoint a helyesírás- és nyelvtani ellenőrzéshez.

A következő példa a „presentation.pptx” fájlt igényli, amelyen az első dián az első alakzat egy szövegdoboz, és legalább egy bekezdést tartalmaz. Lecseréli az első bekezdés tartalmát „1。”‑re, a betűtípust SimSunra állítja, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

    // Állítsa be a helyesírási nyelv azonosítóját.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a prezentáció betöltése vagy létrehozása közben keletkező szöveg alapértelmezett nyelvének meghatározásához. A következő példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyeleusa az US English, hozzáad egy szövegdobozt, és az első szövegrésszel `en-US` értéket ír ki.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Új téglalap alakzat hozzáadása szöveggel.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Ellenőrizze az első szövegréssze nyelvét.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentációs szinten való alkalmazásához használja a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) metódust.

A következő példa 14 pontos félkövér betűt állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, majd elmenti a „default_text_style.pptx” fájlt. A szöveg örökölheti ezeket az alapértékeket, hacsak nincs specifikusabb formázás, amely felülírja őket.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg a felső szintű bekezdésformátumot.
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

## **Szöveg kinyerése All‑Caps hatással**

PowerPointban az **All Caps** betűhatás alkalmazása azt eredményezi, hogy a szöveg nagybetűvel jelenik meg a dián, még akkor is, ha eredetileg kisbetűvel lett beírt. Amikor ilyen szövegrésszeket kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett gépelve. A megjelenített szöveghez való illeszkedéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textcaptype/) értékét, és a visszakapott karakterláncot nagybetűvé alakítsa, ha az érték `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelyen az első dián az első alakzat egy szövegdoboz. Az első bekezdés első réssze tartalmazza a „Hello, Aspose!” szöveget All Caps hatással, ahogyan az alább látható:

![The All Caps effect](all_caps_effect.png)

A következő kódpélda megmutatja, hogyan nyerhető ki a szöveg **All Caps** hatással:

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

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosíthatom egy dián lévő táblázat szövegét?**

Egy dián lévő táblázat szövegének módosításához használja a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/) osztályt. Iteráljon a cellákon, és frissítse az egyes cellákat a [Cell.getTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/#getTextFrame--) segítségével, valamint a bekezdésformázást a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) metódussal.

**Hogyan alkalmazhatok színátmenetes színt a PowerPoint dián lévő szövegre?**

A színátmenetes szín alkalmazásához használja a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) metódust. Állítsa a [FillFormat.setFillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) típusra, és konfigurálja a gradient stop-okat, irányt és átlátszóságot.