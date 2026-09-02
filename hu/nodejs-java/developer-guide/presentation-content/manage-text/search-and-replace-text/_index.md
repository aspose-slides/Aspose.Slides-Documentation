---
title: Szöveg keresése és cseréje PowerPoint prezentációkban JavaScript-ben
linktitle: Keresés és csere szöveg
type: docs
weight: 55
url: /hu/nodejs-java/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg cseréje
- reguláris kifejezés
- eredmény visszahívás
- szövegdoboz
- audit jelentés
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Keresés, kiemelés és szövegcserék PowerPoint prezentációkban, miközben minden egyezést az Aspose.Slides for Node.js via Java segítségével gyűjtünk."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java képes keresni, kiemelni és cserélni a szöveget egy adott szövegdobozban vagy egy egész bemutatóban. Minden művelet result callback‑en keresztül értesítheti az alkalmazást minden egyezésről. Ez lehetővé teszi a bemutató frissítését, miközben audit‑nyomot épít, amely tartalmazza a megtalált szöveget, a környezetét, a pozíciót, a szövegdobozt és a dia számát.

Ezek a lehetőségek hasznosak felülvizsgálat, szenzitív információk eltávolítása, terminológiai ellenőrzés, sablon‑tisztítás és automatizált jelentéskészítés során.

Az alábbi első példákban egy „sample.pptx” nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **A keresés hatókörének kiválasztása**

Használja a [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) metódusait egy művelet korlátozásához egy szövegdobozra. Használja a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) metódusait a bemutató összes alkalmazható szövegének feldolgozásához.

| Művelet | Egy szövegdoboz | Teljes bemutató |
|---|---|---|
| Literális szöveg kiemelése | [TextFrame.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris‑kifejezés egyezések kiemelése | [TextFrame.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Literális szöveg cseréje | [TextFrame.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris‑kifejezés egyezések cseréje | [TextFrame.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **A szöveg egyezésének beállítása**

Literális‑szöveg műveleteknél használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/)‑t a keresés szabályozásához:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) csak teljes szavakra korlátozza a találatot.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) meghatározza, hogy a kis‑ és nagybetű egyezés kötelező‑e.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) a diáknaplókat is beleveszi a bemutató‑szintű keresés, csere és kiemelés műveletekbe.

Reguláris‑kifejezés műveleteknél a Java `Pattern` határozza meg az egyezési szabályokat, például a kis‑/nagybetű érzékenységet és a szóhatárokat a kifejezés és zászlói szerint.

## **Egyezés információinak gyűjtése visszahívással**

Hozzon létre egy Java proxy‑t a result callback‑hez, hogy minden egyezésről értesítést kapjon. A proxy függvény megkapja a kapcsolódó szövegdobozt, a forrás‑szöveget, a megtalált szöveget és a pozíciót.

A callback nem kap közvetlenül diaszámot. Az alábbi megvalósítás a diaszámot a [TextFrame.getSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#getSlide--) , a [Slide.getSlideNumber](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getSlideNumber--) és a [NotesSlide.getParentSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslide/#getParentSlide--) segítségével határozza meg. A diánaplókban található szöveget is kezeli.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

Csere műveleteknél a `foundText` az eredeti megtalált szöveget tartalmazza, így a callback pontosan rögzítheti, mely kifejezéseket cserélték.

## **Szöveg kiemelése**

Használja a [TextFrame.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust a literális‑szöveg egyezések kiemelésére egy szövegdobozban. Adja át a keresés szabályozásához a [TextSearchOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/)‑t.

Az alábbi kódrészlet először minden **„try”** karakterláncot, majd csak a teljes **„to”** szót emeli ki.

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

    // Emelje ki a "try" minden előfordulását a szövegdobozban.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Emelje ki csak a teljes "to" szót.
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

A [TextFrame.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) metódus kiemeli a reguláris kifejezés által megtalált szöveg‑egyezéseket egy szövegdobozban.

Az alábbi kód minden hét vagy több karakterből álló szót kiemel:

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

## **Szöveg kiemelése a teljes bemutatóban**

Használja a [Presentation.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [Presentation.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) metódusokat a bemutató összes alkalmazható szövegdobozának kereséséhez. Az alábbi példa egy literális kifejezést és minden e‑mail címet emel ki:

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

## **Szöveg cseréje egy szövegdobozban**

Használja a [TextFrame.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)‑t literális szöveghez és a [TextFrame.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)‑t mintára alapozott cseréhez. Ezek a metódusok a megtalált szöveget a meglévő szövegdobozon belül módosítják, megtartva a környező szegmens formázását, ahelyett, hogy egy egyszerű karakterláncból újra felépítenék a dobozt.

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

Ha egy egyezés olyan részeket fed le, amelyek formázása eltérő, ellenőrizze a kimenetet, hogy mely formázás legyen alkalmazva a helyettesítő szövegre.

## **Szöveg cseréje a teljes bemutatóban**

Használja a [Presentation.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [Presentation.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokat a műveletek teljes bemutatóra való alkalmazásához. Ez hasznos sablon‑tisztításhoz, terminológiai frissítésekhez és szenzitív információk eltávolításához.

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

## **Egyezések csoportosítása jelentéshez**

Mivel minden gyűjtött eredmény tárolja a dia számát és a szövegdobozt, az alkalmazások csoportosíthatják az egyezéseket audit, jelentés vagy felülvizsgálat céljából. Az alábbi példa először diánként, majd szövegdobozonként csoportosítja az eredményeket:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

**Hogyan kereshetek csak egy szövegdobozt a teljes bemutató helyett?**

Szerezze meg az alakzat szövegdobozát, és hívja meg a [TextFrame.highlightText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), vagy [TextFrame.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokon azon a szövegdobozon. A bemutató‑szintű módszerek az összes alkalmazható szövegdobozt feldolgozzák.

**Hogyan egyeztessek teljes szavakat a helyes nagybetűhasználattal?**

Állítsa be a [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) és a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) értékét `true`‑ra, és adja át a beállításokat a literális‑szöveg kiemeléshez vagy cseréhez. Reguláris kifejezéseknél határozza meg a szóhatárokat és a kis‑/nagybetű érzékenységet magában a Java `Pattern`‑ben.

**A keresés és a csere magában foglalhatja a diáknaplók szövegét is?**

Igen. Állítsa a [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) értékét `true`‑ra, amikor bemutató‑szintű literális‑szöveg műveletet használ. A fent bemutatott callback megvalósítás a notes‑dián belüli egyezést visszakapcsolja a szülődia számához.

**Hogyan készítsek jelentést anélkül, hogy a bemutatót másodszor átnézném?**

Adjunk át egy Java result‑callback proxyt a kiemelés vagy csere műveletnek. A callback minden egyezést megkap a művelet futása közben, így az alkalmazás elmentheti a forrás‑szöveget, a megtalált szöveget, a pozíciót, a szövegdobozt és a származtatott diaszámot későbbi csoportosításhoz vagy exporthoz.

**A szöveg cseréje megőrzi-e a formázását?**

A [TextFrame.replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [TextFrame.replaceRegex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) a megtalált szöveget a meglévő szövegdobozon belül módosítja, és megtartja a környező formázást. Ha egy egyezés különböző formázású részeket fed le, ellenőrizze az eredményt, hogy a csere a kívánt stílust alkalmazza.