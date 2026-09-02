---
title: Vyhledávání a nahrazování textu v prezentacích PowerPoint v JavaScriptu
linktitle: Vyhledávání a nahrazování textu
type: docs
weight: 55
url: /cs/nodejs-java/search-and-replace-text/
keywords:
- vyhledat text
- zvýraznit text
- nahradit text
- regulární výraz
- zpětné volání výsledku
- textový rámec
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint a současně shromažďujte všechny shody pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Aspose.Slides for Node.js via Java dokáže vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámci nebo v celé prezentaci. Každá operace může také prostřednictvím zpětného volání výsledků informovat aplikaci o každé shodě. To umožňuje aktualizovat prezentaci a zároveň vytvářet auditní stopu obsahující nalezený text, jeho kontext, pozici, textový rámec a číslo snímku.

Tyto možnosti jsou užitečné při revizích, redakci, kontrolách terminologie, úklidu šablon a automatizovaných pracovních tocích pro reportování.

V následujících ukázkách používáme soubor **„sample.pptx“**, který na prvním snímku obsahuje jediný textový rámeček s tímto textem:

![Ukázkový text](sample_text.png)

## **Zvolte oblast hledání**

Použijte metody třídy [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) k omezení operace na jeden textový rámec. Použijte metody třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) k prohledání veškerého relevantního textu v celé prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [TextFrame.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zvýraznit shody regulárního výrazu | [TextFrame.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Nahradit doslovný text | [TextFrame.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Nahradit shody regulárního výrazu | [TextFrame.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Nastavení shody textu**

Pro operace s doslovným textem použijte třídu [TextSearchOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/) k ovlivnění způsobu shody:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) omezuje shody na celá slova.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) určuje, zda se rozlišuje velikost písmen.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) zahrnuje poznámky ke snímkům do operací vyhledávání, nahrazování a zvýrazňování na úrovni celé prezentace.

Operace s regulárním výrazem používají v Javě třídu `Pattern`, takže pravidla jako rozlišení velkých a malých písmen či hranice slov jsou definována samotným výrazem a jeho přepínači.

## **Shromažďování informací o shodách pomocí zpětného volání**

Vytvořte Java proxy pro zpětné volání výsledků, aby bylo možné dostávat oznámení o každé shodě. Proxy funkce přijímá související textový rámec, zdrojový text, nalezený text a pozici shody.

Zpětné volání nedostává přímo číslo snímku. Implementace níže jej získává pomocí [TextFrame.getSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getSlideNumber--), a [NotesSlide.getParentSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslide/#getParentSlide--). Také zpracovává text nalezený v poznámkách ke snímkům.

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

U operací nahrazování proměnná `foundText` obsahuje původní nalezený text, takže zpětné volání může zaznamenat přesně, které výrazy byly nahrazeny.

## **Zvýraznění textu**

Použijte metodu [TextFrame.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) k zvýraznění doslovných shod v textovém rámci. Předejte [TextSearchOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/) pro řízení vyhledávání.

Níže uvedený příklad zvýrazní všechny výskyty řetězce **„try“** a poté zvýrazní pouze celé slovo **„to“**.

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

    // Zvýraznit každý výskyt "try" v textovém rámci.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Zvýraznit jen celé slovo "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznění textu pomocí regulárních výrazů**

Metoda [TextFrame.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) zvýrazní shody nalezené regulárním výrazem v textovém rámci.

Následující kód zvýrazní všechna slova obsahující alespoň sedm znaků:

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

## **Zvýraznění textu v celé prezentaci**

Použijte [Presentation.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [Presentation.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) k prohledání všech relevantních textových rámců v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy:

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

## **Nahrazení textu v textovém rámci**

Použijte [TextFrame.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pro doslovný text a [TextFrame.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pro nahrazování na základě vzoru. Tyto metody aktualizují nalezený text uvnitř existujícího textového rámce, což zachovává formátování okolních částí místo přepsání celého rámce prostým řetězcem.

Níže uvedený příklad sjednotí variantu pravopisu a poté nahradí verze štítků:

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

Pokud jedna shoda zasahuje do částí s různým formátováním, zkontrolujte výstup a potvrďte, jaké formátování by mělo být použito pro nahrazený text.

## **Nahrazení textu v celé prezentaci**

Použijte [Presentation.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [Presentation.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) k provedení stejných operací napříč celou prezentací. To je užitečné při úklidu šablon, aktualizaci terminologie a redakci.

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

Protože každý shromážděný výsledek obsahuje číslo snímku a textový rámec, aplikace mohou shody seskupovat pro audit, reportování nebo revizní toky. Následující příklad seskupí výsledky nejprve podle snímku a poté podle textového rámce:

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

## **Často kladené otázky**

**Jak mohu vyhledávat pouze v jednom textovém poli místo v celé prezentaci?**

Získejte textový rámec objektu tvaru a zavolejte [TextFrame.highlightText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), nebo [TextFrame.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tomto textovém rámci. Metody na úrovni prezentace zpracovávají všechny relevantní textové rámce.

**Jak mohu shodovat celá slova s přesnou velikostí písmen?**

Nastavte [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true` a předejte možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. Pro regulární výrazy definujte hranice slov a rozlišení velikosti písmen přímo v Java `Pattern`.

**Mohou vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true` při použití operace na úrovni celé prezentace s doslovným textem. Implementace zpětného volání uvedená výše mapuje shodu v poznámce snímku zpět na číslo jejího nadřazeného snímku.

**Jak mohu vytvořit zprávu bez druhého skenování prezentace?**

Předávejte proxy Java zpětného volání výsledků do operace zvýraznění nebo nahrazení. Zpětné volání dostává každou shodu během běhu operace, takže aplikace může uložit zdrojový text, nalezený text, pozici, textový rámec a odvozené číslo snímku pro pozdější seskupování nebo export.

**Zachovává nahrazení textu jeho formátování?**

[TextFrame.replaceText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [TextFrame.replaceRegex](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) upravují nalezený text uvnitř existujícího textového rámce a zachovávají formátování okolních částí. Pokud shoda zasahuje do oblastí s různým formátováním, prověřte výsledek, aby nahrazený text používal požadovaný styl.