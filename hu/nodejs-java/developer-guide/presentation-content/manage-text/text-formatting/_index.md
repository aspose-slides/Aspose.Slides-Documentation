---
title: Prezentáció szövegformázása JavaScriptben
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
- betűtípus‑tulajdonságok
- betűtípus család
- szöveg forgatás
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus méretezés tulajdonság
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js via Java használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js via Java használatával. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtípus‑tulajdonságokra, forgatásra, bekezdés távolságokra, automatikus méretezésre, szöveg rögzítésére, tabulátorokra és nyelvi beállításokra.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezéseinek kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/nodejs-java/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) metódust egy bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) metódust egyedi szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **teljes bekezdés** számára:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a teljes bekezdés kiemelési színét.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűvel rendelkező szövegrészek** számára:

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
                // Állítsa be a szövegrész kiemelési színét.
                portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) metódust a bekezdés igazításához egy szövegdobozon belül. Az érték lehet középen, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés **középre**:

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

![Az igazított bekezdés](aligned_paragraph.png)

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) színek alfa komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték a 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **teljes bekezdés** esetén:

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

![Az áttetsző bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság **félkövér betűvel rendelkező szövegrészek** esetén:

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

            // Állítsa be a szövegrész átlátszóságát.
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

![Az áttetsző szövegrészek](transparent_text_portions.png)

## **Karaktertávolság beállítása a szöveghez**

Használja a [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi JavaScript kód bemutatja, hogyan növelhető a karaktertávolság a **teljes bekezdés** esetén:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Használjon negatív értékeket a karaktertávolság csökkentéséhez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Bővítse a karaktertávolságot.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karaktertávolság **félkövér betűvel rendelkező szövegrészek** esetén:

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
            // Megjegyzés: Negatív értékek használata a karaktertávolság csökkentéséhez.
            portion.getPortionFormat().setSpacing(3); // Bővítse a karaktertávolságot.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenített szöveg. Ez akkor fordulhat elő, ha a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban engedélyezve van a kerning.

Ha ilyen helyzetben szeretné, hogy a renderelt kimenet közelebb legyen a PowerPointhoz, letilthatja a kerninget a megtámadott betűtípusú szövegrészeknél. Állítsa be a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél lényegesen nagyobbra:

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

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában azon betűtípusoknál, amelyeket ez a PowerPoint‑specifikus viselkedés érint.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók a bekezdés szintjén a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/) segítségével.

Az alábbi kód a betűtípust és a szövegstílust a teljes bekezdésre állítja: betűméret, félkövér, dőlt, pontozott aláhúzás és a Times New Roman betűtípus alkalmazása minden részre a bekezdésben.

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

![A bekezdés betűtípus‑tulajdonságai](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűvel rendelkező szövegrészek** esetén:

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

            // Állítsa be a szövegrész betűtulajdonságait.
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

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használja a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust egy előre definiált szövegtájolás beállításához egy alakzaton belül.

Az alábbi kódrészlet a szöveg tájolását `Vertical270`‑re állítja, ami a szöveget **90 fokkal óramutató járásával ellentétesen** forgatja:

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

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használja a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) metódust egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegdobozt 3 fokkal órakor irányban forgatja az alakzatban:

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

![Az egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) metódusokkal szabályozza a bekezdés távolságait. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi kódrészlet bemutatja, hogyan adható meg a sortávolság a bekezdésen belül:

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

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Automatikus méretezés típusának beállítása szövegdobozokhoz**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tárolója határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, túlcsorduljon vagy a forma automatikusan átméreteződjön.

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

A sorok számolásához automatikus sortörés után, és a szöveg vagy forma szélességének változásához lásd a [Count Rendered Lines](/slides/hu/nodejs-java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túlcsordul-e a tárolójából.

## **Szövegdobozok rögzítésének beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) meghatározza, hogyan helyezkedik el függőlegesen a szöveg egy alakzatban, például a tetején, közepén vagy alján.

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

## **Tabuláció beállítása a szöveghez**

Használja a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getTabs--) metódusokat a tabulátorok konfigurálásához egy bekezdésben.

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

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) metódussal lehetővé teszi a helyesírási nyelv beállítását egy szövegrészhez. A helyesírási nyelv határozza meg, hogy a PowerPoint milyen nyelven végez helyesírás‑ és nyelvtani ellenőrzést.

Az alábbi kódrészlet bemutatja, hogyan állítható be a helyesírási nyelv egy szövegrészhez:

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

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a betöltés vagy prezentáció létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Adj hozzá egy új téglalap alakzatot szöveggel.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Ellenőrizze az első szövegrész nyelvét.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén alkalmazandó alapértelmezett szövegformázáshoz használja a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) metódust.

Az alábbi kódrészlet bemutatja, hogyan állítható be egy alapértelmezett félkövér betű 14 pt mérettel minden diához egy új prezentációban.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Lekérjük a legfelső szintű bekezdésformátumot.
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

A PowerPointben az **All Caps** betűhatás alkalmazása nagybetűvel jeleníti meg a szöveget a dián még akkor is, ha azt eredetileg kisbetűkkel írták. Amikor az Aspose.Slides visszaad egy ilyen szövegrészt, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez való igazításhoz ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textcaptype/) értékét, és ha az `All`, akkor a visszakapott karakterláncot alakítsa nagybetűssé.

Tegyük fel, hogy van egy szövegdoboz a sample2.pptx első diáján.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg az **All Caps** hatás alkalmazásával:

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

**Hogyan módosítható a szöveg egy táblázatban egy dián?**

A táblázat szövegének módosításához egy dián használja a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/) osztályt. Iteráljon a cellákon, és frissítse minden cellát a [Cell.getTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/#getTextFrame--) metódussal, valamint a bekezdés formázást a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) metódussal.

**Hogyan alkalmazhatunk színátmenetet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához használja a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) metódust. Állítsa a [FillFormat.setFillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) típusra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.