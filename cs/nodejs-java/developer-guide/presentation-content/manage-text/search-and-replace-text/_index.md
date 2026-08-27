---
title: Vyhledávání a nahrazování textu v prezentacích PowerPoint v JavaScriptu
linktitle: Vyhledávání a nahrazování textu
type: docs
weight: 55
url: /cs/nodejs-java/search-and-replace-text/
keywords:
- hledat text
- zvýraznit text
- nahradit text
- regulární výraz
- callback výsledku
- textový rámec
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint a zároveň shromažďujte všechny shody pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides for Node.js via Java může vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámci nebo v celé prezentaci. Každá operace může také prostřednictvím zpětného volání výsledku upozornit aplikaci na každou shodu. To umožňuje aktualizovat prezentaci a současně vytvořit auditní stopu obsahující nalezený text, jeho kontext, pozici, textový rámec a číslo snímku.

Tyto možnosti jsou užitečné pro revizi, redakci, kontrolu pojmů, úklid šablon a automatizované workflow reportování.

V prvních příkladech níže používáme soubor s názvem "sample.pptx", který obsahuje jedinou textovou rámeček na prvním snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah vyhledávání**

Použijte metody na [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) k omezení operace na jeden textový rámec. Použijte metody na [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) ke zpracování veškerého relevantního textu v prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [TextFrame.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zvýraznit shody regulárního výrazu | [TextFrame.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Nahradit doslovný text | [TextFrame.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Nahradit shody regulárního výrazu | [TextFrame.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurace shody textu**

Pro operace s doslovným textem použijte [TextSearchOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/) ke kontrole shody:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) omezuje shody na celá slova.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) určuje, zda musí být velikost písmen shodná.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) zahrnuje poznámky ke snímkům do vyhledávání, nahrazování a zvýrazňování na úrovni celé prezentace.

Operace s regulárním výrazem používají Java `Pattern`, takže pravidla shody, jako je citlivost na velikost písmen a hranice slov, jsou definována výrazem a jeho příznaky.

## **Identifikace vlastníka textového rámce**

Obecné workflow pro zpracování textu často získává [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) při vyhledávání, nahrazování, validaci nebo exportu textu. Použijte [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentShape--) a [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentCell--) k určení, který objekt prezentace vlastní daný textový rámec.

Očekávané hodnoty závisí na vlastníkovi:

| Vlastník textového rámce | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape nebo jiný tvar obsahující text | Vlastnící [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) | `null` |
| Buňka tabulky | `null` | Vlastnící [Cell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cell/) |

Obě metody poskytují jen‑read navigaci. Volání metod nepřesouvá textový rámec ani nemění jeho vlastníka. Obecný kód by měl kontrolovat obě hodnoty na `null` a ošetřit možnost, že žádný vlastník není k dispozici.

Následující příklad používá [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) k iteraci přes textové rámečky v prezentaci. Pro tvary vypisuje název tvaru, runtime typ v Javě a snímek, ve kterém se nachází. Pro buňky tabulky vypisuje nulově‑základní souřadnice sloupce a řádku a snímek, ve kterém jsou.

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

Pro obsah SmartArt iterujte přes tvary v [SmartArtNode.getShapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartnode/#getShapes--) a přistupujte k jednotlivým [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Textový rámec lze dohledat až k příslušnému tvaru pomocí [TextFrame.getParentShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentShape--), zatímco [TextFrame.getParentCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getParentCell--) vrací `null`. Proto větev tvaru v příkladu také zpracovává text ze SmartArt uzlů.

## **Sbírání informací o shodách pomocí zpětného volání**

Vytvořte Java proxy pro zpětné volání výsledku, aby bylo možné obdržet upozornění pro každou shodu. Proxy funkce přijímá související textový rámec, zdrojový text, nalezený text a pozici shody.

Zpětné volání nedostává číslo snímku přímo. Implementace níže jej odvozuje z tvaru nebo buňky, které vlastní textový rámec, s [TextFrame.getSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getSlide--) jako záložní možnost. Také zpracovává text nalezený v poznámkách ke snímkům.

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

Pro operace nahrazování `foundText` obsahuje původní nalezený text, takže zpětné volání může zaznamenat přesně, které výrazy byly nahrazeny.

## **Zvýraznit text**

Použijte metodu [TextFrame.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) k zvýraznění doslovných shod v textovém rámci. Předávejte [TextSearchOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/) k řízení vyhledávání.

Níže uvedený kód zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**.

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

    // Zvýraznit každé výskyty "try" v textovém rámci.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Zvýraznit pouze celé slovo "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznit text pomocí regulárních výrazů**

Metoda [TextFrame.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) zvýrazní shody textu nalezené regulárním výrazem v textovém rámci.

Následující kód zvýrazní všechna slova obsahující sedm nebo více znaků:

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

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Zvýraznit text v celé prezentaci**

Použijte [Presentation.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [Presentation.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) k vyhledání ve všech relevantních textových rámečcích v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy:

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

## **Nahradit text v textovém rámci**

Použijte [TextFrame.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pro doslovný text a [TextFrame.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pro nahrazení založené na vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámci, přičemž zachovávají formátování okolních částí místo restartování rámce z prostého řetězce.

Následující příklad standardizuje variantu pravopisu a pak nahradí označení verzí:

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

Pokud jedna shoda zasahuje oblasti s různým formátováním, zkontrolujte výstup a ověřte, které formátování by mělo být použito u nahrazeného textu.

## **Nahradit text v celé prezentaci**

Použijte [Presentation.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [Presentation.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) k aplikaci stejných operací napříč prezentací. To je užitečné pro úklid šablon, aktualizaci terminologie a redakci.

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

## **Seskupování shod pro reportování**

Protože každý shromážděný výsledek ukládá číslo snímku a textový rámec, mohou aplikace shody seskupovat pro audit, reportování nebo revizní workflow. Následující příklad seskupí výsledky nejprve podle snímku a poté podle textového rámce:

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

## **Často kladené otázky**

**Jak mohu vyhledávat jen v jednom textovém rámečku místo celé prezentace?**

Získejte textový rámec tvaru a zavolejte [TextFrame.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), nebo [TextFrame.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tomto textovém rámci. Metody na úrovni prezentace zpracovávají všechny relevantní textové rámečky.

**Jak mohu shodovat celá slova s přesnou kapitalizací?**

Nastavte [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true` a předávejte možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. Pro regulární výrazy definujte hranice slov a citlivost na velikost písmen přímo ve výrazu Java `Pattern`.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true` při použití operace na úrovni prezentace s doslovným textem. Implementace zpětného volání uvedená výše mapuje shodu v poznámce snímku zpět na číslo nadřazeného snímku.

**Jak mohu vytvořit zprávu bez druhého procházení prezentace?**

Předávejte proxy Java result‑callback do operace zvýraznění nebo nahrazení. Zpětné volání přijímá každou shodu během běhu operace, takže aplikace může uložit zdrojový text, nalezený text, pozici, textový rámec a odvozené číslo snímku pro pozdější seskupení nebo export.

**Zachovává nahrazení textu jeho formátování?**

[TextFrame.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [TextFrame.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) upravují nalezený text v existujícím textovém rámci a zachovávají formátování okolních částí. Pokud shoda zasahuje oblasti s různým formátováním, zkontrolujte výsledek, aby bylo zajištěno, že náhrada používá požadovaný styl.