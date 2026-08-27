---
title: Vyhledávání a nahrazování textu v prezentacích PowerPoint v PHP
linktitle: Vyhledávání a nahrazování textu
type: docs
weight: 55
url: /cs/php-java/search-and-replace-text/
keywords:
- vyhledávání textu
- zvýraznit text
- nahradit text
- regulární výraz
- zpětné volání výsledku
- textový rámeček
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint a současně shromažďujte všechny shody pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP via Java může vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámečku nebo v celé prezentaci. Každá operace může také pomocí zpětného volání výsledku informovat aplikaci o každém nalezeném výskytu. To umožňuje aktualizovat prezentaci a zároveň vytvářet auditní stopu obsahující nalezený text, jeho kontext, pozici, textový rámeček a číslo snímku.

Tyto možnosti jsou užitečné při revizi, redakci, kontrolách terminologie, úklidu šablon a automatizovaných pracovních postupech pro vykazování.

V prvních příkladech níže používáme soubor nazvaný "sample.pptx", který obsahuje jedinou textovou schránku na první stránce s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah vyhledávání**

Použijte metody na [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) k omezení operace na jeden textový rámeček. Použijte metody na [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) k provedení operace na veškerý vhodný text v prezentaci.

| Operace | Jeden textový rámeček | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [TextFrame::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#highlightText) |
| Zvýraznit shody regulárního výrazu | [TextFrame::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#highlightRegex) |
| Nahradit doslovný text | [TextFrame::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#replaceText) |
| Nahradit shody regulárního výrazu | [TextFrame::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#replaceRegex) |

## **Nastavit porovnávání textu**

Pro operace s doslovným textem použijte [TextSearchOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/) k řízení porovnávání:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) omezuje shody na celá slova.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) určuje, zda se musí shodovat velikost písmen.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) zahrnuje poznámky ke snímkům do vyhledávání, nahrazování a zvýrazňování na úrovni celé prezentace.

Operace s regulárními výrazy používají v Javě třídu `Pattern`, takže pravidla porovnávání, jako je citlivost na velikost písmen a hranice slov, jsou definována výrazem a jeho příznaky.

## **Identifikovat vlastníka textového rámečku**

Obecné pracovní postupy pro zpracování textu často získají [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) při vyhledávání, nahrazování, validaci nebo exportu textu. Použijte [TextFrame::getParentShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentShape) a [TextFrame::getParentCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentCell) k určení, který objekt prezentace vlastní textový rámeček.

| Vlastník textového rámečku | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape nebo jiný tvar obsahující text | The owning [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) | `null` |
| Buňka tabulky | `null` | The owning [Cell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cell/) |

Obě metody poskytují pouze pro čtení navigaci. Volání jich nepřesune textový rámeček ani nezmění jeho vlastníka. Obecný kód by měl kontrolovat obě hodnoty pomocí `java_is_null` a ošetřit možnost, že žádný vlastník není dostupný.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Pro obsah SmartArt iterujte přes tvary pomocí [SmartArtNode::getShapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnode/#getShapes) a přistupujte ke každému [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartshape/#getTextFrame). Textový rámeček lze sledovat k jeho přidruženému tvaru pomocí [TextFrame::getParentShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentShape), zatímco [TextFrame::getParentCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParentCell) vrací `null`. Proto větev tvarů v příkladu také zpracovává text ze SmartArt uzlů.

## **Shromažďovat informace o shodách pomocí zpětného volání**

Předávejte Java proxy zpětné volání metodě pro zvýraznění nebo nahrazení, aby bylo možné získat oznámení o každé shodě. Metoda zpětného volání přijímá související textový rámeček, zdrojový text, nalezený text a pozici shody.

Zpětné volání nedostává číslo snímku přímo. Implementace níže jej odvozuje z nadřazeného snímku a také zpracovává text nalezený v poznámkách ke snímkům. Výsledné pole používá `null`, pokud je text spojen s jiným typem snímku.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

Vytvořte proxy pro tento PHP objekt před předáním do operace:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

U operací nahrazování obsahuje `foundText` původní nalezený text, takže zpětné volání může přesně zaznamenat, které výrazy byly nahrazeny.

## **Zvýraznit text**

Použijte metodu [TextFrame::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightText) k zvýraznění doslovných shod v textovém rámečku. Předávejte [TextSearchOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/) k řízení vyhledávání.

Kódový příklad níže zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní jen celé slovo **"to"**.

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

    // Zvýraznit každý výskyt "try" v textovém rámečku.
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

Metoda [TextFrame::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightRegex) zvýrazní textové shody nalezené regulárním výrazem v textovém rámečku.

Následující kód zvýrazní všechna slova obsahující sedm a více znaků:

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

Použijte [Presentation::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#highlightText) a [Presentation::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#highlightRegex) k prohledání všech vhodných textových rámečků v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy:

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

## **Nahradit text v textovém rámečku**

Použijte [TextFrame::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceText) pro doslovný text a [TextFrame::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceRegex) pro nahrazování na základě vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámečku, přičemž zachovávají formátování okolních částí místo přestavování rámečku z prostého řetězce.

Následující příklad standardizuje variantu pravopisu a poté nahradí označení verzí:

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

Pokud jedna shoda zasahuje do částí s odlišným formátováním, zkontrolujte výstup, abyste potvrdili, které formátování má být použito pro nahrazený text.

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

## **Seskupit shody pro reportování**

Protože každý výsledek ukládá číslo snímku a textový rámeček, mohou aplikace seskupovat shody pro audit, reportování nebo revizní pracovní postupy. Následující příklad seskupuje získané výsledky nejprve podle snímku a poté podle textového rámečku:

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

## **FAQ**

**Jak mohu vyhledávat pouze v jednom textovém rámečku místo celé prezentace?**

Získáte textový rámec tvaru a zavoláte [TextFrame::highlightText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceText) nebo [TextFrame::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceRegex) na tomto rámci. Metody na úrovni prezentace zpracovávají všechny vhodné textové rámečky.

**Jak mohu najít celá slova se správnou velikostí písmen?**

Nastavte [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) a [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) na `true` a předávejte možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. U regulárních výrazů definujte hranice slov a citlivost na velikost písmen přímo v Java `Pattern`.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) na `true` při použití operace doslovného textu na úrovni prezentace.

**Jak mohu vytvořit report bez druhého procházení prezentace?**

Předávejte Java proxy zpětné volání operaci zvýraznění nebo nahrazování. Získává každou shodu během běhu operace, takže aplikace může uložit zdrojový text, nalezený text, pozici, textový rámec a odvozené číslo snímku pro pozdější seskupení nebo export.

**Zachovává nahrazování textu jeho formátování?**

[TextFrame::replaceText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceText) a [TextFrame::replaceRegex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#replaceRegex) upravují nalezený text v existujícím textovém rámečku a zachovávají formátování okolních částí. Pokud shoda zasahuje do částí s odlišným formátováním, zkontrolujte výsledek, aby nahrazení použilo požadovaný styl.