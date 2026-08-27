---
title: PowerPoint előadások szövegének keresése és cseréje JavaScriptben
linktitle: Szöveg keresése és cseréje
type: docs
weight: 55
url: /hu/nodejs-java/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg cseréje
- reguláris kifejezés
- eredmény visszahívás
- szövegkeret
- audit jelentés
- PowerPoint
- OpenDocument
- előadás
- Node.js
- JavaScript
- Aspose.Slides
description: "Szöveg keresése, kiemelése és cseréje PowerPoint előadásokban, miközben minden egyezést összegyűjt az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes keresni, kiemelni és helyettesíteni a szöveget egy egyedi szövegkeretben vagy egy teljes bemutatóban. Minden művelet értesítheti az alkalmazást minden egyezésről egy eredmény‑visszahíváson keresztül. Ez lehetővé teszi a bemutató frissítését, miközben egy auditnaplót épít, amely tartalmazza a megtalált szöveget, annak környezetét, pozícióját, a szövegkeretet és a diavetítés számát.

Ezek a képességek hasznosak felülvizsgálathoz, sötétítéshez, terminológiai ellenőrzésekhez, sablon tisztításhoz és automatizált jelentéskészítési munkafolyamatokhoz.

Az alábbi első példákban egy "sample.pptx" nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Válassza ki a keresés hatókörét**

Használja a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) metódusait egy művelet egy szövegkeretre korlátozásához. Használja a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) metódusait a bemutatóban található összes alkalmazható szöveg feldolgozásához.

| Művelet | Egy szövegkeret | Teljes bemutató |
|---|---|---|
| Highlight literal text | [TextFrame.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [TextFrame.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [TextFrame.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [TextFrame.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Szövegillesztés beállítása**

A szó szerinti szöveg műveletekhez használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/) elemet a keresés szabályozásához:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) korlátozza a találatokat teljes szavakra.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) irányítja, hogy a karakterek nagybetű‑érzékenysége kötelező‑e.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) belefoglalja a diák jegyzeteit a bemutató szintű keresés, helyettesítés és kiemelés műveletekbe.

A reguláris kifejezés műveletek egy Java `Pattern`‑t használnak, így a keresési szabályok, mint a case sensitivity és a szóhatárok, a kifejezés és annak jelzői által vannak meghatározva.

## **A szövegkeret tulajdonosának azonosítása**

Az általános szövegfeldolgozó munkafolyamatok gyakran egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumot kapnak a keresés, helyettesítés, érvényesítés vagy exportálás során. Használja a [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentShape--) és a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentCell--) metódusokat annak meghatározásához, hogy melyik bemutatóobjektum birtokolja a szövegkeretet.

A várt értékek a tulajdonostól függenek:

| Szövegkeret tulajdonosa | `getParentShape` | `getParentCell` |
|---|---|---|
| Egy AutoShape vagy egy másik szövegtartalmú alakzat | A tulajdonos [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) | `null` |
| Egy táblázat cellája | `null` | A tulajdonos [Cell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cell/) |

Mindkét metódus csak olvasási navigációt biztosít. Meghívásuk nem mozdítja el a szövegkeretet, és nem változtatja meg a tulajdonost. Az általános kódnak ellenőriznie kell mindkét értéket `null`‑ra, és kezelnie kell azt a lehetőséget, hogy egyik tulajdonos sem érhető el.

Az alábbi példa a [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) metódust használja a bemutató szövegkereteinek bejárásához. Alakzatok esetén jelenti az alakzat nevét, a Java futási típust és a befoglaló diát. Táblázat cellák esetén jelenti a nulláról induló oszlop‑ és sorkoordinátákat, valamint a befoglaló diát.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

SmartArt tartalom esetén járja be az alakzatokat a [SmartArtNode.getShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartnode/#getShapes--) metóduson, és érje el minden [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) elemet. A szövegkeret a hozzá tartozó alakzatra nyomon követhető a [TextFrame.getParentShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentShape--) segítségével, míg a [TextFrame.getParentCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getParentCell--) `null`‑t ad vissza. Ezért a példában lévő alakzat ága a SmartArt csomópontok szövegét is kezeli.

## **Egyezésinformációk gyűjtése visszahívással**

Hozzon létre egy Java proxyt az eredmény‑visszahíváshoz, hogy értesítést kapjon minden egyezésről. A proxy függvény megkapja a kapcsolódó szövegkeretet, a forrásszöveget, a megtalált szöveget és a találat pozícióját.

A visszahívás nem kap közvetlenül diaszámot. Az alábbi megvalósítás a szövegkeret tulajdonos alakzatából vagy táblázat cellájából származtatja azt, a [TextFrame.getSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getSlide--) tartalékaként. Kezeli a diák jegyzeteiben talált szöveget is.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Helyettesítési műveleteknél a `foundText` az eredeti megtalált szöveget tartalmazza, így a visszahívás pontosan rögzítheti, mely kifejezéseket cserélték.

## **Szöveg kiemelése**

Használja a [TextFrame.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust a szó szerinti szöveg találatainak kiemeléséhez egy szövegkeretben. Adja át a [TextSearchOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/) objektumot a keresés szabályozásához.

Az alábbi kódpélda a **"try"** karakterek minden előfordulását, majd csak a teljes **"to"** szót emeli ki.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Kiemeli a "try" minden előfordulását a szövegkeretben.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Kiemeli csak a "to" teljes szót.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

A [TextFrame.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) metódus kiemeli a reguláris kifejezéssel megtalált szövegeket egy szövegkeretben.

Az alábbi kód kiemeli az összes olyan szót, amely legalább hét karaktert tartalmaz:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg kiemelése egy bemutatóban**

Használja a [Presentation.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [Presentation.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) metódusokat a bemutató összes alkalmazható szövegkeretének kereséséhez. Az alábbi példa egy szó szerinti kifejezést és az összes e‑mail címet emeli ki:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szöveg cseréje egy szövegkeretben**

Használja a [TextFrame.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust szó szerinti szöveghez és a [TextFrame.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódust mintára alapozott helyettesítéshez. Ezek a metódusok a megtalált szöveget frissítik a meglévő szövegkereten belül, megtartva a környező rész formázását anélkül, hogy egy egyszerű karakterláncból építenék újra a szövegkeretet.

Az alábbi példa egységesíti egy helyesírási változatot, majd lecseréli a verziócímkéket:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha egy találat különböző formázású részeket ölel fel, ellenőrizze a kimenetet, hogy megerősítse, melyik formázás legyen alkalmazva a helyettesítő szövegre.

## **Szöveg cseréje egy bemutatóban**

Használja a [Presentation.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [Presentation.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokat ugyanazon műveletek alkalmazásához a teljes bemutatóban. Ez hasznos sablon tisztításhoz, terminológiai frissítésekhez és sötétítéshez.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Találatok csoportosítása jelentéshez**

Mivel minden összegyűjtött eredmény tárolja a diaszámát és a szövegkeretet, az alkalmazások csoportosíthatják a találatokat audit, jelentés vagy felülvizsgálati munkafolyamatok céljából. Az alábbi példa először diára, majd szövegkeretre csoportosítja az eredményeket:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Hogyan kereshetek csak egy szövegdobozban a teljes bemutató helyett?**

Szerezze meg az alakzat szövegkeretét, és hívja meg a [TextFrame.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), vagy a [TextFrame.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódust azon a szövegkereten. A bemutató‑szintű metódusok ezzel szemben az összes alkalmazható szövegkeretet dolgozzák fel.

**Hogyan illeszthetek teljes szavakat a megfelelő nagybetűkkel?**

Állítsa a [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) és a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) értékét `true`‑ra, és adja át ezeket a lehetőségeket egy szó szerinti kiemelés vagy helyettesítés metódusának. Reguláris kifejezések esetén határozza meg a szóhatárokat és a case sensitivity‑t magában a Java `Pattern`‑ben.

**Tartalmazhat a keresés és a helyettesítés a diáknaplók szövegét is?**

Igen. Állítsa a [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) értékét `true`‑ra, ha bemutató‑szintű szó szerinti műveletet használ. A fent bemutatott visszahívás‑implementáció egy jegyzet dia találatát visszafejti a szülő dia számára.

**Hogyan készítsek jelentést a bemutató újbóli beolvasása nélkül?**

Adjon át egy Java eredmény‑visszahívó proxyt a kiemelés vagy helyettesítés műveletnek. A visszahívás minden találatot megkap a művelet futása közben, így az alkalmazás tárolhatja a forrásszöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott diaszámot későbbi csoportosítás vagy export céljából.

**Megőrzi a szöveg helyettesítése a formázását?**

A [TextFrame.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [TextFrame.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) módosítja a megtalált szöveget a meglévő szövegkereten belül, és megtartja a környező rész formázását. Ha egy találat különböző formázású részeket ölel fel, vizsgálja meg az eredményt, hogy biztosan a kívánt stílus legyen alkalmazva a helyettesítésnél.