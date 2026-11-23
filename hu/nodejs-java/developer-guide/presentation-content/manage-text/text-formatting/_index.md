---
title: Prezentáció szövegének formázása JavaScriptben
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/nodejs-java/text-formatting/
keywords:
- bekezdés igazítása
- szöveg stílusa
- szöveg háttér
- szöveg átlátszóság
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus illeszkedés tulajdonság
- szövegdoboz rögzítése
- szöveg tabulálása
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js Java segítségével. Testreszabhatja a betűket, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js Java használatával. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdéses távolságra, automatikus illeszkedés viselkedésére, szöveg‑rögzítésre, tabulátorokra és nyelvi beállításokra.

Hacsak nincs másként feltüntetve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakzata egy szövegdoboz, és az első bekezdése a lenti szöveget tartalmazza. A diák és az alakzat indexei nullától indulnak. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

További információk a szöveg és reguláris kifejezések megtalálásáról és kiemeléséről: [Szöveg keresése és cseréje](/slides/hu/nodejs-java/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használd a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) függvényt a bekezdés alapértelmezett kiemelés színének beállításához, vagy a [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) függvényt az egyes szövedrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott explicit kiemelés színe felülírja ezt az alapértelmezést:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a kiemelés színét az egész bekezdéshez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

A következő kódrészlet bemutatja, hogyan állítsuk be a háttérszínt a **félkövér betűvel rendelkező szövedrészek** esetén:

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

![A szürke szövedrészek](gray_text_portions.png)

## **Szövegbekezdések igazítása**

Használd a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) függvényt a bekezdés igazításának beállításához egy szövegdobozban. Az érték lehet középre igazított, balra igazított, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet megmutatja, hogyan igazítsuk a bekezdést **középre**:

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

## **Betűk igazítása soron belül**

Használd a [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) függvényt a szövegrészek függőleges igazításához különböző betűméretek esetén egy soron belül. Ez a beállítás az egész bekezdésre vonatkozik, és szabályozza az egyes sorokban történő igazítást.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontos mérettel, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus illeszkedést és a sortörést, és úgy tartja a szövegdobozokat, hogy egy sor elférjen benne.

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

![Összehasonlítás az alapvonal, felső, középső és alsó betűigazításról kevert betűméretekkel](font_alignment.png)

Az betűigazítás a betűmetrikákat használja, ezért az egyes betűk látható szélei nem feltétlenül kerülnek pontosan egymás alá. A példa egy nagybetűt és egy alsó tartó karaktert tartalmaz, hogy bemutassa a különbséget az alapvonal és az alsó igazítás között. A betűk elérhetősége és helyettesítése, a használt karakterek, valamint a betűméretek közti különbség befolyásolja az eredményt. A keret méretei, margók, sortávolság, sortörés és automatikus illeszkedés szintén hat a megjelenésre; használj ugyanazt a betűkészletet és elrendezési beállításokat a módok összehasonlításakor.  

Ez a beállítás különbözik a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) beállítástól, amely a vízszintes bekezdésigazítást szabályozza, valamint a [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) beállítástól, amely a szöveges blokk függőleges pozícióját állítja be az alakzatban. A felső- és alsó index formázás a [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) segítségével az egyes részeket a alapvonalhoz viszonyítva tolja el, nem pedig a bekezdés soraira vonatkozó betűigazítást állít be.

## **Szöveg átlátszóság beállítása**

A szöveg átlátszósága a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) szín alpha komponensével szabályozható. Az alábbi példákban a `alpha = 50` egy ARGB alfa-csatorna érték 0–255 skálán, nem átlátszósági százalék.

A következő kódrészlet bemutatja, hogyan alkalmazzunk átlátszóságot az **egész bekezdésre**:

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

A következő kódrészlet bemutatja, hogyan alkalmazzunk átlátszóságot a **félkövér betűvel rendelkező szövedrészekre**:

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

![Az átlátszó szövedrészek](transparent_text_portions.png)

## **Karaktertávolság beállítása szövegnél**

A [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) segítségével növelheted vagy szűkítheted a karakterek közötti távolságot egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek a szöveget sűkítik.

Az alábbi JavaScript kód megmutatja, hogyan növeljünk karaktertávolságot az **egész bekezdésben**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Használjon negatív értékeket a karaktertávolság szorításához.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Növelje a karaktertávolságot.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

A következő kódrészlet bemutatja, hogyan növeljünk karaktertávolságot a **félkövér betűvel rendelkező szövedrészekben**:

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
            // Megjegyzés: Használjon negatív értékeket a karaktertávolság szorításához.
            portion.getPortionFormat().setSpacing(3); // Növelje a karaktertávolságot.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a szövedrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Néhány esetben az Aspose.Slides által renderelt szöveg kissé szorosabbnak tűnhet, mint a PowerPoint-ban megjelenített ugyanaz a szöveg. Ez azért fordulhat elő, mert a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyhatja a kerning adatokat, még akkor is, ha a betűtípus tartalmazza a megfelelő kerning információkat, és a PowerPoint beállításaiban a kerning engedélyezve van.

Az ilyen esetekben, hogy a renderelt kimenet közelebb legyen a PowerPoint-hoz, letilthatod a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsd a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét egy a tényleges betűméretnél nagyobb értékre. Ez a példa a "presentation.pptx" fájlt igényli, ahol az első alakzat az első dia szövegdoboz. A hatékony betűneveket ellenőrzi, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto-t használó részekhez. Ez letiltja a kerninget azoknál a részeknél, amelyek betűmérete 100 pont alatt van:

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

A küszöbnél kisebb szövegnél ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális megjelenítésével egyezővé tételében azoknál a betűtípusoknál, amelyekre ez a PowerPoint-specifikus viselkedés vonatkozik.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) segítségével.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott explicit formázás felülírja ezeket az alapértelmezéseket:

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

Az alábbi példa 13 pontos Times New Roman-t, dőlt formázást és pontozott aláhúzást alkalmaz a részekre, amelyek hatékony formázása félkövér:

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

## **Szövegmagasság normalizálásának vezérlése**

Használd a [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) függvényt sablon tipográfia reprodukálásakor vagy a karaktermagasságok közti eltérések vizsgálatakor. PowerPointban a normalizálás függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egységes látható magasságot érjen el a szövedrészben. Ez nem garantálja, hogy a különböző betűk magassága egyenlő legyen.

Állítsd a tulajdonságot [NullableBool.True vagy False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) értékre a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NotDefined` helyi beállítást üresen hagyja, így a rész örökölheti az értéket, például a bekezdés [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat). Ez nem azt jelenti, hogy `False`. Használd a [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) és olvasd a [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) értéket a feloldott logikai értékhez.

Az alábbi önálló példa **Arial** betöltését igényli. Két szövegrészletet hoz létre, amelyek ugyanazokat a nagybetűket, kisbetűket, alsó tartókat és ékezetes karaktereket tartalmazzák 54 ponton. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső rész kifejezetten letiltja; az alsó örökli. A keret méretei, margói és bekezdéses távolság azonosak, a sortörés és automatikus illeszkedés le van tiltva a összehasonlítás konzisztenciája érdekében. A példa kiírja a `False: false` és `NotDefined: true` értékeket, majd menti a "text_height_normalization.pptx" fájlt.

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

Az alábbi összehasonlítás a mentett prezentációból lett exportálva. A felső sor a normalizálás letiltott állapotát (`False`) mutatja; az alsó sor örökli az engedélyezett beállítást (`NotDefined` → `True`). Az Arial telepítése szükséges a megjelenés reprodukálásához.

![Arial 54 pontos szöveg a normalizálás letiltásával felül és az örökölt normalizálás engedélyezésével alul](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja meg anélkül, hogy a hozzárendelt [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight) érték, azaz betűméret pontban változna. A bekezdés [setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) szabályozza a sortávolságot, míg a szövegdoboz [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) szabályozza, hogyan igazodik a szöveg vagy a tároló a méretekhez. Ezek a beállítások különböző célokat szolgálnak és önállóan befolyásolhatják a teljes elrendezést. További információk a bekezdés formázásáról és öröklődéséről: [Manage Paragraph](/slides/hu/nodejs-java/manage-paragraph/).

## **Áthúzás alkalmazása és eltávolítása**

Használd a [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) függvényt egy szövegrész áthúzásához, például hibák, törölt kifejezések vagy korábbi árak megjelenítéséhez a szöveg törlése nélkül. Állítsd a [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) értékre egy vagy két vonalhoz a szöveg felett.

Az áthúzás eltávolításához add meg a [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None) értéket. Ez kifejezetten letiltja a hatást, még ha a környező formázás áthúzást ír elő is. Ezzel szemben a [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) helyi beállítást undefined állapotban hagyja, így a rész örökölheti a formázást, például a bekezdéstől. Ez nem garantálja, hogy az áthúzás eltávolításra kerül. Használd a [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) a kapott formázás, beleértve az örökölt értékek, lekérdezéséhez.

Az alábbi önálló példa három ár összehasonlítást hoz létre. Minden bekezdésben külön részek találhatók a címke, a korábbi ár és az aktuális ár számára, így csak a korábbi ár érintett. Az első sor alkalmazza, majd eltávolítja az áthúzást; a többi sor egyes és kétszeres áthúzást tartalmaz. Ennek a beállításnak a módosítása megőrzi a szöveget és egyéb formázásait, beleértve a félkövér korábbi árat.

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

    // Alkalmazza a áthúzást, majd kifejezetten eltávolítja azt az első korábbi árból.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény felülről lefelé: áthúzás nélkül, egyes áthúzással és kétszeres áthúzással.

![Korábbi árak áthúzás nélkül, egyes és kétszeres áthúzással](strikethrough.png)

## **Szöveg forgatásának beállítása**

Használd a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) függvényt egy előre definiált szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet a szöveg orientációját a alakzatban a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal az óramutató járásával ellentétesen** forgatja a szöveget:

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

## **Számok egymás mellett megjelenítése függőleges szövegben**

Ahhoz, hogy egy kétszámjegyű számot egy függőleges japán címkében együtt tartsunk, helyezd a két számjegyet egy szövegrészbe, és hívd meg a [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) függvényt a rész formázásán. A példa a [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) és 40 pontos MS Gothic betűtípust használ mindkét címkéhez. Csak a [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) értéke különbözik a numerikus részben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPointban a bal címke (`True`) a számjegyeket egyenesen és egymás mellett jeleníti meg a 和 és 年 karakterek között. A jobb címke (`False`) a párost 90 fokkal az óramutató járásával megegyezően forgatja. A környező japán karakterek mindkét címkén egyenesen maradnak.

![PowerPoint összehasonlítás függőleges dátumcímkékről, a bal oldalon egyenesen álló számjegyekkel, a jobb oldalon elfordított számjegyekkel](vertical_date.png)

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használd a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) függvényt egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) számára.

A következő kódrészlet a szövegdobozt 3 fokkal az óramutató járásával megegyezően forgatja az alakzatban:

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

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokat biztosítja a bekezdés távolságainak szabályozásához. Ezek a tulajdonságok a következőképpen használhatók:

* Használj pozitív értéket a sortávolság sormagasság százalékaként történő megadásához.
* Használj negatív értéket a sortávolság pontokban történő megadásához.

Az alábbi példa a első bekezdésen belüli távolságot a sormagasság 200%-ára (dupla sortávolság) állítja:

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

## **Sortörés szabályozása**

A bekezdés sortörés szabályai szűk szövegblokkokban és olyan prezentációkban hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. A következő metódusok a [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) részei, így egy teljes bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) szabályozza a latin sortörés szabályait. Kevert szövegben módosítása megváltoztathatja, hol törik a szomszédos kelet-ázsiai szöveg és írásjel.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) szabályozza a kelet-ázsiai sortörés szabályait, beleértve a sor elején és végén lévő karakterek korlátozásait.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText) funkciót, amely automatikus sortörést engedélyez egy szövegdobozon belül. A layoutot befolyásolják, amikor sortörés történik; nem helyeznek be sortörés karaktert. Egy explicit sortörés új sort kényszerít a bekezdésen belül a rendelkezésre álló szélességtől függetlenül.

Az alábbi önálló példa egy szűk szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési beállítást explicit módon állítja be, és a "line_breaking.pptx" fájlt menti. A szabályok kipróbálásához változtasd meg a megfelelő értéket, miközben a többi beállítást változatlanul hagyod. A példa 24 pontos Arial és SimSun betűket használ 160 pontos keretszélességgel és nulla vízszintes szövegdoboz margóval. A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) értékkel van meghívva, hogy a szövegméret és a keret mérete állandó maradjon.

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

## **Lengő írásjelek szabályozása**

A [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) lehetővé teszi, hogy a megfelelő írásjelek a sor jobb széle mögé nyúljanak, ahelyett, hogy a következő sorba kerülnének. Ez az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa engedélyezi a lengő írásjeleket egy 100 pont széles szövegdobozban, és a "hanging_punctuation.pptx" fájlt menti. 24 pontos Arial és nulla vízszintes margó használatával az utolsó pont a "sentence" után marad, és túlnyúlik a jobb szövegélén. Állítsd a tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) értékre a hasonlításhoz: ebben a beállításban a pont külön sorba kerül. A sortörés engedélyezett, az automatikus illeszkedés le van tiltva a rendelkezésre álló szélesség rögzítése érdekében.

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

Nem minden írásjel tud lengeni. A [fenti betű- és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illeszkedés módosítása eltüntetheti a látható különbséget.

## **Automatikus illeszkedés típusának beállítása szövegdobozokhoz**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) meghatározza, hogyan viselkedjen a szöveg, ha meghaladja a tároló határait. Ezzel szabályozhatod, hogy a szöveg zsugorodjon, túlcsorduljon vagy az alakzat automatikusan átméreteződjön. A következő példa úgy konfigurálja az alakzatot, hogy a szöveghez igazodva átméretezze magát, és a "autofit_type.pptx" fájlba menti az eredményt.

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

A sorok számolásához automatikus sortörés után és a szöveg vagy alakzat szélességének hatásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/nodejs-java/manage-paragraph/) oldalt. A sorok száma önmagában nem jelzi, hogy a szöveg túllépi-e a tárolót.

## **Szövegdobozok rögzítésének beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például a tetején, közepén vagy alján. A következő példa a szöveget az első alakzat aljára rögzíti, és a "text_anchor.pptx" fájlba menti az eredményt.

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

## **Szöveg tabulálásának beállítása**

Használd a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) függvényeket a tabulátorok beállításához egy bekezdésben. A következő példa az alapértelmezett tabulátorintervalt 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor karaktert tartalmazó szövegre hatnak.

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

Az Aspose.Slides a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) függvényt kínálja, amely lehetővé teszi a szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg, hogy a PowerPoint milyen nyelven végez helyesírás- és nyelvtani ellenőrzést.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián, és legalább egy bekezdést tartalmaz. A példa az első bekezdés tartalmát "1。"‑ra cseréli, a betűtípust SimSun‑ra állítja, és a Simplified Chinese helyesírási nyelvet (`zh-CN`) rendeli hozzá. A "proofing_language.pptx" fájlba menti az eredményt:

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

### **Nyelvi metaadat másolása**

Többnyelvű szöveg sablonból történő másolásakor meg kell őrizni mind a [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) , mind a [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) értékeket. Az alábbi önálló példa egy forrásrészt hoz létre, amelynek nyelvi beállítása US English, alternatív nyelve French, és a szöveget és az azonosítókat egy új prezentáció egy részébe másolja.

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
    // Ha a forrásnak nincs alternatív nyelve, a null érték törli a cél értékét.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha olyan forrást szeretnél kipróbálni alternatív nyelv nélkül, hagyd ki a "fr-FR" hozzárendelését. Az alternatív azonosító ekkor `null`, és a másolási utasítás megőrzi annak hiányát alapértelmezett érték bevezetése nélkül, még akkor is, ha a célodban korábban volt alternatív nyelv beállítva.

Ezek az azonosítók nyelvi metaadatként vannak tárolva. Megőrzésük nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás- vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használd a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) függvényt a szöveg alapértelmezett nyelvének meghatározásához a prezentáció betöltése vagy létrehozása során. Az alábbi példa egy prezentációt hoz létre US English alapértelmezett szövegnyelvvel, egy szövegdobozt ad hozzá, és az első szövegrészhez kiírja az `en-US` értéket.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

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

Alapértelmezett szövegformázás alkalmazásához prezentációszinten használd a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi példa 14 pontos félkövér betűt állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, és a "default_text_style.pptx" fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy specifikusabb formázás nem írja felül őket.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg a legfelső szintű bekezdésformátumot.
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

## **Szöveg kinyerése nagybetűs effektussal**

PowerPointban az **All Caps** (csupa nagybetű) betűhatás alkalmazása a szöveget a dián nagybetűsen jeleníti meg, még akkor is, ha eredetileg kisbetűvel írták. Amikor az Aspose.Slides visszaad egy ilyen szövegrészt, a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett gépölve. A megjelenített szöveghez való illesztéshez ellenőrizd a [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) értékét, és ha az `All`, konvertáld a visszakapott karakterláncot nagybetűssé.

Ez a példa a "sample2.pptx" fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián. Az első bekezdés első része a "Hello, Aspose!" szöveget tartalmazza, amelyre az All Caps effektus alkalmazva van, ahogy alább látható.

![A All Caps effektus](all_caps_effect.png)

A következő kódrészlet bemutatja, hogyan nyerjük ki a szöveget, amikor az **All Caps** effektus alkalmazva van:

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosíthatom a szöveget egy dián lévő táblázatban?**

A dián lévő táblázat szövegének módosításához használd a [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) osztályt. Iterálj a cellákon, és frissítsd minden cellát a [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) segítségével, illetve a bekezdés formázását a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat) használatával.

**Hogyan alkalmazhatok fokozatos színátmenetet a szövegre egy PowerPoint dián?**

A szövegre való fokozatos színátmenet alkalmazásához használd a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) metódust. Állítsd a [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) értékét a [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) típusra, és konfiguráld a gradient stop-okat, irányt és átlátszóságot.