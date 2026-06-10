---
title: Prezentáció szövegének formázása JavaScript-ben
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/nodejs-java/text-formatting/
keywords:
- szöveg kiemelése
- reguláris kifejezés
- bekezdés igazítása
- szöveg stílusa
- szöveg háttere
- szöveg átlátszósága
- karakterköz
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus illesztés tulajdonság
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js Java-n keresztül. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatja a szöveget PowerPoint és OpenDocument előadásban az Aspose.Slides for Node.js Java-n keresztül használva. Kitér a kiemelésre, háttérszínekre, átlátszóságra, karakterközökre, betűtípus‑tulajdonságokra, forgatásra, bekezdésközökre, automatikus illesztés viselkedésére, szöveg rögzítésére, tabulátorállomásokra és nyelvi beállításokra.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Szöveg kiemelése**

Használja a [TextFrame.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) metódust, amikor ki kíván emelni egy szövegkeretben egy adott mintának megfelelő szöveget. A metódus kiemelési színt alkalmaz a megtalált szövegrészekre, és használható a [TextSearchOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/) segítségével a keresés módjának vezérlésére, például csak teljes szavak egyezésére.

Az alábbi kódrészlet kiemeli a **"try"** karakterek minden előfordulását, majd csak a **"to"** teljes szót emeli ki.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Kiemeli a "try" szót az alakzaton.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Kiemeli a "to" szót az alakzaton.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

A [TextFrame.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) metódus kiemeli a reguláris kifejezéssel megtalált szöveg egyezéseket. Node.js Java-n keresztül ez az API a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) osztályon érhető el.

Az alábbi kódrészlet kiemeli az összes olyan szót, amely **hétszer vagy annál több karaktert** tartalmaz:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Kiemeli az összes olyan szót, amely hét vagy annál több karaktert tartalmaz.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A kiemelt szöveg reguláris kifejezés használatával](highlighted_text_using_regex.png)

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) metódust az egyedi szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **teljes bekezdés** számára:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Az alábbi kódrészlet azt mutatja be, hogyan állítható be a háttérszín **vastag betűtípusú szövegrészek** esetén:

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
            // Állítsa be a kiemelés színét a szövegrészhez.
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

Használja a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) metódust a bekezdés igazításának beállításához egy szövegkeretben. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés **középre**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Szöveg átlátszóság beállítása**

A szöveg átlátszóságát a [PortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/#getFillFormat--) által kapott szín alfa komponense vezérli. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték a 0‑255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet azt mutatja, hogyan alkalmazható átlátszóság a **teljes bekezdés** számára:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![Az átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet azt mutatja, hogyan alkalmazható átlátszóság **vastag betűtípusú szövegrészek** esetén:

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

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használja a [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) metódust a karakterek közötti távolság növelésére vagy szűkítésére egy szövegdobozban.

Az alábbi JavaScript kód bemutatja, hogyan növelhető a karakterköz a **teljes bekezdés** esetén:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használatával csökkenthető a karakterköz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Növeli a karakterközt.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karakterköz **vastag betűtípusú szövegrészek** esetén:

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
            // Megjegyzés: Negatív értékek használatával csökkenthető a karakterköz.
            portion.getPortionFormat().setSpacing(3); // Növeli a karakterközt.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg valamivel szorosabbnak tűnhet, mint a PowerPoint-ban megjelenített szöveg. Ez akkor fordul elő, amikor a PowerPoint egyes betűtípusok esetén figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt, és a kerning be van kapcsolva a PowerPoint beállításaiban.

Az ilyen esetekben, hogy a renderelt kimenet közelebb legyen a PowerPoint-hoz, letilthatja a kerninget az érintett betűtípust használó szövegrészeknél. Állítsa a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél lényegesen nagyobbra:

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

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrészeken, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális megjelenésével való összehangolásában a PowerPoint‑specifikus viselkedés miatt érintett betűtípusoknál.

## **Szöveg betűtípus tulajdonságok kezelése**

A betűtípus‑tulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) vagy egyedi szövegrészeknél a [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/) segítségével.

Az alábbi kód beállítja a betűtípust és a szövegstílust a **teljes bekezdés** számára: alkalmazza a betűméretet, a félkövér, dőlt, pontozott aláhúzást, valamint a Times New Roman betűtípust az összes szövegrészre a bekezdésben.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Állítsa be a betűtulajdonságokat a bekezdéshez.
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

![A betűtípus tulajdonságai a bekezdésben](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **vastag betűtípusú szövegrészek** esetén:

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

            // Állítsa be a betűtulajdonságokat a szövegrészhez.
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

![A betűtípus tulajdonságai a szövegrészekben](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használja a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust előre definiált szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet a szövegorientációt `Vertical270`‑re állítja a formában, ami **90 fokkal az óramutató járásával ellentétesen** forgatja a szöveget:

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

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használja a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) metódust egyedi forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegdobozt **3 fokkal** forgatja az óramutató járásával megegyező irányban az alakzatban:

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

Az eredmény:

![Az egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sortávolság beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) metódusokkal biztosítja a bekezdésköz szabályozását. Ezeket a tulajdonságokat a következőképpen használják:

* Pozitív értékkel a sortávolság a sormagasság százalékában adható meg.  
* Negatív értékkel a sortávolság pontban adható meg.

Az alábbi kódrészlet bemutatja, hogyan adható meg a sortávolság a bekezdésen belül:

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

Az eredmény:

![A sortávolság a bekezdésben](line_spacing.png)

## **Automatikus illesztés típus beállítása szövegdobozokhoz**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tárolója határait. Használja a szöveg zsugorodásának, túlcsordulásának vagy az alakzat automatikus átméretezésének vezérlésére.

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

## **Szövegdobozok rögzítésének beállítása**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) meghatározza, hogyan helyezkedik el függőlegesen a szöveg egy alakzatban, például a tetején, közepén vagy alján.

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

## **Szöveg tabuláció beállítása**

Használja a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getTabs--) metódusokat a tabulátorok bekezdésben történő konfigurálásához.

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

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Helyesírás-ellenőrző nyelv beállítása**

Az Aspose.Slides a [PortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) metódussal teszi lehetővé a helyesírás-ellenőrző nyelv beállítását egy szövegrészhez. A helyesírás-ellenőrző nyelv határozza meg, mely nyelvet használja a PowerPoint a helyesírás‑ és nyelvtan‑ellenőrzéshez.

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

    // Állítsa be a helyesírási nyelv azonosítóját.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust az alapértelmezett nyelv meghatározásához a betöltés vagy a prezentáció létrehozása során létrehozott szöveghez.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Adjunk hozzá egy új téglalap alakzatot szöveggel.
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

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használja a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) metódust.

Az alábbi kódrészlet bemutatja, hogyan állítható be alapértelmezés szerint félkövér betűtípus 14 pt mérettel az összes dián lévő szöveghez egy új prezentációban.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // Szerezze be a legfelső szintű bekezdésformátumot.
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

## **Szöveg kinyerése nagybetűs hatással**

A PowerPoint‑ban a **All Caps** betűhatás alkalmazása a szöveget nagybetűkkel jeleníti meg a dián, még akkor is, ha az eredetileg kisbetűkkel lett beírva. Amikor az Aspose.Slides‑szel ilyen szövegrészt kérdezi le, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textcaptype/) értékét, és konvertálja a visszakapott karakterláncot nagybetűsre, ha az érték `All`.

Tegyük fel, hogy a **sample2.pptx** fájl első diáján a következő szövegdoboz található.

![A nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg a **All Caps** hatással:

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

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hogyan módosítható a szöveg egy táblázatban a dián?**

A táblázaton belüli szöveg módosításához használja a [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/) osztályt. Iteráljon a cellákon, és frissítse minden cellát a [Cell.getTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/#getTextFrame--) segítségével, valamint a bekezdésformázást a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) segítségével.

**Hogyan alkalmazható színátmenet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához használja a [PortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/#getFillFormat--) metódust. Állítsa a [FillFormat.setFillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) típusra, és konfigurálja a színátmenet állomásait, irányát és átlátszóságát.