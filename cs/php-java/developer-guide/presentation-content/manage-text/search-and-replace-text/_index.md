---
title: Vyhledávat a nahrazovat text v PowerPoint prezentacích v PHP
linktitle: Vyhledávat a nahrazovat text
type: docs
weight: 55
url: /cs/php-java/search-and-replace-text/
keywords:
- vyhledávání textu
- zvýraznění textu
- nahrazení textu
- regulární výraz
- callback výsledku
- textový rámec
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v PowerPoint prezentacích a při tom sbírejte každou shodu pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP via Java dokáže vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámci nebo v celé prezentaci. Každá operace může také upozornit aplikaci na každý výskyt prostřednictvím zpětného volání výsledku. To umožňuje aktualizovat prezentaci a současně vytvořit auditní stopu obsahující nalezený text, jeho kontext, pozici, textový rámec a číslo snímku.

Tyto možnosti jsou užitečné pro revizi, redakci, kontrolu terminologie, úklid šablon a automatizované workflow pro vytváření zpráv.

V prvních příkladech níže používáme soubor nazvaný "sample.pptx", který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah vyhledávání**

Použijte metody na [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) k omezení operace na jeden textový rámec. Použijte metody na [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) ke zpracování veškerého relevantního textu v prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [TextFrame::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#highlightText) |
| Zvýraznit shody regulárního výrazu | [TextFrame::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#highlightRegex) |
| Nahradit doslovný text | [TextFrame::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#replaceText) |
| Nahradit shody regulárního výrazu | [TextFrame::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#replaceRegex) |

## **Konfigurace shody textu**

Pro operace s doslovným textem použijte [TextSearchOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/) k řízení shody:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) omezuje shody na celá slova.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) určuje, zda se musí shodovat velikost písmen.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) zahrnuje poznámky ke snímkům do vyhledávání, nahrazování a zvýrazňování na úrovni prezentace.

Operace s regulárními výrazy používají Java `Pattern`, takže pravidla shody jako velikost písmen a hranice slov jsou definována výrazem a jeho příznaky.

## **Sbírat informace o shodách pomocí zpětného volání**

Předáte Java proxy zpětné volání metodě pro zvýraznění nebo nahrazení, aby dostala oznámení o každé shodě. Metoda zpětného volání získá související textový rámec, původní text, nalezený text a pozici shody.

Zpětné volání nedostává číslo snímku přímo. Implementace níže ho odvozuje z nadřazeného snímku a také zpracovává text nalezený v poznámkách ke snímkům. Výsledek pole používá `null`, když je text spojen s jiným typem snímku.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Vytvořte proxy pro tento PHP objekt před jeho předáním operaci:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

U operací nahrazování `foundText` obsahuje původní nalezený text, takže zpětné volání může přesně zaznamenat, které výrazy byly nahrazeny.

## **Zvýraznit text**

Použijte metodu [TextFrame::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightText) k zvýraznění doslovných shod v textovém rámci. Předávejte [TextSearchOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/) pro řízení vyhledávání.

Následující ukázkový kód zvýrazní všechny výskyty znaků **"try"** a následně zvýrazní pouze celé slovo **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Zvýraznit každý výskyt "try" v textovém rámci.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Zvýraznit pouze celé slovo "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznit text pomocí regulárních výrazů**

Metoda [TextFrame::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightRegex) zvýrazní shody textu nalezené regulárním výrazem v textovém rámci.

Následující kód zvýrazní všechna slova obsahující sedm nebo více znaků:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Zvýraznit text v celé prezentaci**

Použijte [Presentation::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#highlightText) a [Presentation::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#highlightRegex) k prohledání všech relevantních textových rámců v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Nahradit text v textovém rámci**

Použijte [TextFrame::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceText) pro doslovný text a [TextFrame::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceRegex) pro nahrazení založené na vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámci, přičemž zachovávají formátování okolních částí místo přestavby celého rámce z prostého řetězce.

Následující příklad standardizuje variantu pravopisu a následně nahradí štítky verzí:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Pokud jedna shoda zahrnuje části s odlišným formátováním, prohlédněte výstup a potvrďte, které formátování by se mělo použít na nahrazený text.

## **Nahradit text v celé prezentaci**

Použijte [Presentation::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#replaceText) a [Presentation::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#replaceRegex) k provedení stejných operací v celé prezentaci. To je užitečné pro úklid šablon, aktualizaci terminologie a redakci.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Seskupování shod pro reportování**

Protože každý výsledek ukládá číslo snímku a textový rámec, aplikace mohou shody seskupovat pro audit, reportování nebo revizní workflow. Následující příklad seskupí nasbírané výsledky nejprve podle snímku a poté podle textového rámce:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **Často kladené dotazy**

**Jak mohu vyhledávat pouze v jednom textovém rámečku místo celé prezentace?**

Získejte textový rámec tvaru a zavolejte na něm [TextFrame::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceText) nebo [TextFrame::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceRegex). Metody na úrovni prezentace zpracují všechny relevantní textové rámečky.

**Jak mohu najít celá slova se správnou kapitalizací?**

Nastavte [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) a [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) na `true` a předávejte tyto možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. Pro regulární výrazy definujte hranice slov a citlivost na velikost písmen přímo v Java `Pattern`.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) na `true` při použití operace doslovného textu na úrovni prezentace.

**Jak mohu vytvořit report bez druhého průchodu prezentací?**

Předáte Java proxy zpětné volání operaci zvýraznění nebo nahrazování. Toto zpětné volání dostává každou shodu během provádění operace, takže aplikace může uložit původní text, nalezený text, pozici, textový rámec a odvozené číslo snímku pro pozdější seskupování nebo export.

**Zachovává nahrazení textu jeho formátování?**

[TextFrame::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceText) a [TextFrame::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceRegex) upravují nalezený text v existujícím textovém rámci a zachovávají formátování okolních částí. Pokud shoda zahrnuje části s odlišným formátováním, prohlédněte výsledek a ujistěte se, že nahrazení používá požadovaný styl.