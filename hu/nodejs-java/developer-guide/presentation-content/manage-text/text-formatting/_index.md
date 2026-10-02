---
title: Prezentáció szövegének formázása JavaScript-ben
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/nodejs-java/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus illesztés tulajdonság
- szövegdoboz rögzítés
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js Java-n keresztül. Testreszabhatja a betűtípusokat, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Node.js Java-on keresztül használva. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdéstávolságra, automatikus illesztés viselkedésére, szöveg rögzítésére, tabulátor beállításokra és nyelvi beállításokra.

Amennyiben nincs másként feltüntetve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdése tartalmazza az alább látható szöveget. Mind a diák, mind az alakzat indexei nullától indulnak. A félkövér részletet kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés találatok megtalálásához és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/nodejs-java/search-and-replace-text/) oldalt.

## **A szöveg háttérszínének beállítása**

Használd a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) metódust egy bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) metódust egyedi szövegrészekhez.

A következő példa világosszürke kiemelést állít be az első bekezdés alapértelmezettként. Az egyedi részeken megadott kiemelési színek felülírják ezt az alapértelmezést:

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

Az alábbi kódrészlet bemutatja, hogyan állítsd be a háttérszínt **félkövér betűkkel** rendelkező **szövegrészek** számára:

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

Használd a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) metódust a bekezdés igazításához egy szövegdobozon belül. Az érték lehet középre igazított, balra igazított, jobbra igazított, sorkizárt stb.

A következő kódrészlet megmutatja, hogyan igazítsd a bekezdést a **középre**:

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

## **Betűtípusok igazítása egy soron belül**

Használd a [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment-int-) metódust a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás az egész bekezdésre vonatkozik, és minden sorban szabályozza az igazítást.

Az alábbi önálló példa négy felcímzett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pont méretben, eltérő betűigazítással. Arial betűtípust használ, letiltja az automatikus illesztést és a sortörést, és a szövegdobozok elég nagyok ahhoz, hogy egy sorba férjenek.

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

Az eredmény:

![Összehasonlítás a Baseline, Top, Center és Bottom betűigazításokról vegyes betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákon alapul, ezért az egyes betűk látható szélei nem feltétlenül esnek pontosan egy vonalba. A példa egy nagybetűt és egy alsóleges betűt is tartalmaz, hogy bemutassa a baseline és a bottom igazítás közti különbséget. A betűtípus elérhetősége, helyettesítése, a karakterek és a betűméretek közti különbségek mind befolyásolják az eredményt. A keret mérete, margók, sortávolság, sortörés és az automatikus illesztés szintén hat a megjelenésre; a módok összehasonlításához használj azonos betűtípusokat és elrendezési beállításokat.

Ez a beállítás különbözik a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) metódustól, amely a vízszintes bekezdésigazítást szabályozza, valamint a [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) metódustól, amely a szövegdoboz függőleges pozícióját határozza meg az alakzatban. A [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement-float-) metódussal elérhető felső- és alsó indexelés az egyes részeket a baseline-hoz képest mozgatja, a bekezdés sorainak betűigazítása helyett.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) színének alfa komponensével szabályozható. Az alábbi példákban az `alpha = 50` egy 0–255 skálán értendő ARGB alfa-csatorna érték, nem átlátszósági százalék.

Az alábbi kódrészlet megmutatja, hogyan alkalmazz átlátszóságot a **teljes bekezdésre**:

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

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet megmutatja, hogyan alkalmazz átlátszóságot **félkövér betűkkel** rendelkező **szövegrészek** számára:

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

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karaktertávolság beállítása a szövegben**

Használd a [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy szűkítésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek szűkítik a szöveget.

Az alábbi JavaScript kód megmutatja, hogyan növeld a karaktertávolságot a **teljes bekezdésben**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használata tömöríti a karaktertávolságot.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Bővítse a karaktertávolságot.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növeld a karaktertávolságot **félkövér betűkkel** rendelkező **szövegrészek** számára:

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
            // Megjegyzés: Negatív értékek használata tömöríti a karaktertávolságot.
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

### **Kerning letiltása meghatározott betűtípusokhoz**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kicsit szorosabb lehet, mint a PowerPointban megjelenített változat. Ez akkor fordulhat elő, ha a PowerPoint figyelmen kívül hagyja a kerning adatokat bizonyos betűtípusoknál, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban a kerning engedélyezve van.

Az ilyen esetekben a renderelt kimenetet a PowerPointnak megfelelően a kerning letiltásával az érintett betűtípusú szövegrészeknél érheted el. Állítsd a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél nagyobbra. Ez a példa egy „presentation.pptx” fájlt igényel, amelynek első alakzata egy szövegdoboz az első dián. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be azokhoz a részekhez, amelyek a Roboto-t használják. Ez letiltja a kerninget az olyan részeknél, amelyek betűmérete 100 pont alatt van:

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

A küszöbérték alatti egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális megjelenéséhez való igazításában a professzionális, PowerPoint‑specifikus viselkedés által érintett betűtípusoknál.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) vagy egyedi részekre a [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) segítségével.

A következő példa beállítja az első bekezdés alapértelmezett betűtípusát 12 pont Times New Roman-ra, félkövérrel, dőltstílussal és pontozott aláhúzással. Az egyedi részeken megadott formázás felülírja ezeket az alapértelmezéseket:

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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

A következő példa 13 pont Times New Roman, dőlt és pontozott aláhúzással alkalmaz a **félkövér** hatékony formázással rendelkező részekre:

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

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használd a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust egy előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) értékre állítja, amely a szöveget **90 fokkal óramutatóval ellentétesen** forgatja:

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

Használd a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) metódust egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) esetén.

Az alábbi kódrészlet 3 fokos órán járó forgatást alkalmaz a szövegdobozra az alakzaton belül:

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

![Az egyéni szövegforgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) metódusokkal szabályozza a bekezdés távolságát. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív értékkel a sortávolság a sormagasság százalékában adható meg.
* Negatív értékkel a sortávolság pontban adható meg.

A következő példa a bekezdés belső távolságát a sormagasság 200%-ára (dupla sorköz) állítja:

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

## **Sortörés szabályainak vezérlése**

A bekezdés sortörés szabályai szűk szövegdobozokban és olyan prezentációkban hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. Az alábbi módszerek a [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) osztályhoz tartoznak, így egy teljes bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) szabályozza a latin sortörési szabályokat. Vegyes szöveg esetén ennek módosítása befolyásolhatja a kelet-ázsiai szöveg és írásjelek tördelését is.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) szabályozza a kelet-ázsiai sortörési szabályokat, beleértve a sor elején és végén lévő karakterek korlátozását.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) metódust, amely automatikus sortörést engedélyez a szövegdobozban. A szabályok a layoutot befolyásolják, amikor a sortörés megtörténik; nem illesztenek sortörés karaktereket. Egy kifejezett sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegdobozt hoz létre kínai és latin szöveggel. Mindkét sortörési beállítást kifejezetten megadja, majd a „line_breaking.pptx” fájlt menti. A szabályok kipróbálásához változtasd meg a megfelelő értéket, miközben a másik beállítást állandóan hagyod. A példa 24 pont Arial és SimSun betűket használ, 160 pont széles kerettel és nulla vízszintes szövegdoboz margóval. A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) metódust a [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) értékkel hívja meg, hogy a szöveg mérete és a keret mérete rögzítve maradjon:

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

## **Függőleges központozás (hanging punctuation) vezérlése**

A [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) lehetővé teszi, hogy az jogos központozási jelek a sor jobb szélén túlnyúljanak, ahelyett, hogy a következő sorba kerülnének. Ez az egész bekezdésre érvényes, és különbözik a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegdobozban engedélyezi a függőleges központozást, majd a „hanging_punctuation.pptx” fájlt menti. 24 pont Arial betűkkel és nulla vízszintes szövegdoboz margóval a végpont a „mondat” után marad, és a jobb szövegszegmens túlcsordul. Állítsd a tulajdonságot a [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben a beállításban a pont külön sorba kerül. A sortörés engedélyezett, az automatikus illesztés pedig letiltott, hogy a rendelkezésre álló szélesség rögzítve maradjon.

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

Nem minden írásjel függőlegesen helyezhető el. A fentebb leírt [betű- és layoutfeltételek](#control-line-breaking) szintén érvényesek erre a példára: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegdobozokhoz**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) határozza meg, hogyan viselkedjen a szöveg, ha túllépi a tároló határait. Ezzel szabályozhatod, hogy a szöveg zsugorodjon, kifolyjon vagy a forma automatikusan átméreteződjön. A következő példa úgy konfigurálja a formát, hogy mérete a szöveghez igazodjon, majd a „autofit_type.pptx” fájlt menti.

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

Az automatikus sortörés utáni sorok számolásához és a szöveg vagy a forma szélességének változásához lásd a [Renderelt sorok számolása](/slides/hu/nodejs-java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg kifolyik-e a tárolóból.

## **Szövegdobozok rögzítési pontjának beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) meghatározza, hogyan helyezkedjen el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljához rögzíti, majd a „text_anchor.pptx” fájlt menti.

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

## **Szöveg tabulációjának beállítása**

Használd a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs--) metódusokat a tabulátorok konfigurálásához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátor méretét 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontra. Ezek a beállítások a tabulátor karaktert tartalmazó szövegre hatnak.

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

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) metódussal lehetővé teszi a helyesírási nyelv beállítását egy szövegrészhez. A helyesírási nyelv határozza meg, hogy melyik nyelvet használja a PowerPoint a helyesírás- és nyelvtani ellenőrzéshez.

A következő példa a „presentation.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián, és legalább egy bekezdést tartalmaz. Az első bekezdés tartalmát „1。” szövegre cseréli, a betűtípust SimSunra állítja, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. A „proofing_language.pptx” fájlt menti:

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

Használd a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a betöltés vagy a prezentáció létrehozása közben létrejövő szöveg alapértelmezett nyelvének meghatározásához. A következő példa egy olyan prezentációt hoz létre, amelynek alapértelmezett szövegnyelvének az amerikai angolt állítja be, egy szövegdobozt ad hozzá, majd az első szövegrész nyelvét `en-US`-ként írja ki.

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

    // Ellenőrizze az első szövegrész nyelvét.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használd a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) metódust.

A következő példa 14 pont félkövér betűt állít be az új prezentáció felső szintű bekezdéseihez alapértelmezettként, majd a „default_text_style.pptx” fájlt menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nincs specifikusabb formázás, amely felülírja őket.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Lekéri a felső szintű bekezdésformátumot.
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

PowerPointban az **All Caps** betűhatás alkalmazása nagybetűssé teszi a szöveget a dián, még ha eredetileg kisbetűkkel lett beírva is. Amikor az Aspose.Slides segítségével ilyen szövegrészt kérsz le, a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett gépelve. A megjelenített szöveghez való egyezés érdekében ellenőrizd a [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) értékét, és ha `All`, akkor alakítsd a visszakapott karakterláncot nagybetűssé.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, amelyre All Caps hatás van alkalmazva, az alábbiak szerint.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerj ki szöveget **All Caps** hatással:

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

A táblázat szövegének módosításához egy dián használd a [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) osztályt. Iteráld a cellákat, és frissítsd az egyes cellákat a [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) segítségével, a bekezdés formázását pedig a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) metódussal.

**Hogyan alkalmazható színátmenet a szövegre egy PowerPoint dián?**

A színátmenetes szöveghez használd a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) metódust. Állítsd a [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) típusra, és konfiguráld a gradient állomásokat, irányt és átlátszóságot.