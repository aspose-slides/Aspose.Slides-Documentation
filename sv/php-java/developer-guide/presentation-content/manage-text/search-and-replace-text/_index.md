---
title: Sök och ersätt text i PowerPoint-presentationer i PHP
linktitle: Sök och ersätt text
type: docs
weight: 55
url: /sv/php-java/search-and-replace-text/
keywords:
- sök text
- markera text
- ersätt text
- reguljärt uttryck
- resultat-callback
- textram
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som du samlar varje matchning med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides for PHP via Java kan söka, markera och ersätta text i en enskild textram eller i hela presentationen. Varje operation kan också meddela en applikation om varje matchning via en resultat‑callback. Detta gör det möjligt att uppdatera en presentation och samtidigt bygga ett granskningsspår som innehåller den matchade texten, dess sammanhang, position, textram och bildnummer.

Dessa funktioner är användbara för granskning, redigering, terminologikontroller, mallrengöring och automatiserade rapportarbetsflöden.

I de första exemplen nedan använder vi en fil som heter "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj sökområde**

Använd metoder på [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) för att begränsa en operation till en textram. Använd metoder på [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att bearbeta all tillämpbar text i presentationen.

| Operation | En textram | Hela presentationen |
|---|---|---|
| Markera bokstavlig text | [TextFrame::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#highlightText) |
| Markera reguljära uttryckmatchningar | [TextFrame::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#highlightRegex) |
| Ersätt bokstavlig text | [TextFrame::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceText) |
| Ersätt reguljära uttryckmatchningar | [TextFrame::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceRegex) |

## **Konfigurera textmatchning**

För bokstavliga textoperationer, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) begränsar matchningar till hela ord.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) styr om teckenens skiftläge måste matcha.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) inkluderar bildanteckningar i sök-, ersättnings- och markeringsoperationer på presentationsnivå.

Reguljära uttrycks‑operationer använder ett Java `Pattern`, så matchningsregler som skiftlägeskänslighet och ordgränser definieras av uttrycket och dess flaggor.

## **Identifiera ägaren till en textram**

Generiska textbearbetnings‑arbetsflöden får ofta en [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) när de söker, ersätter, validerar eller exporterar text. Använd [TextFrame::getParentShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentShape) och [TextFrame::getParentCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentCell) för att bestämma vilket presentationsobjekt som äger textramen.

| Ägare av textram | `getParentShape` | `getParentCell` |
|---|---|---|
| En AutoShape eller en annan textinnehållande form | Den ägande [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) | `null` |
| En tabellcell | `null` | Den ägande [Cell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cell/) |

Båda metoderna erbjuder skrivskyddad navigation. Att anropa dem flyttar inte textramen eller ändrar dess ägare. Generisk kod bör kontrollera båda värdena med `java_is_null` och hantera möjligheten att ingen ägare är tillgänglig.

Följande exempel använder [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/#getAllTextFrames) för att iterera genom textramarna i en presentation. För former rapporterar den formens namn, Java‑körtidstyp och innehållande bild. För tabellceller rapporterar den noll‑baserade kolumn‑ och radkoordinater samt den innehållande bilden.

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

För SmartArt‑innehåll, iterera genom formerna i [SmartArtNode::getShapes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartnode/#getShapes) och nå varje [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/smartartshape/#getTextFrame). Textramen kan spåras till sin associerade form via [TextFrame::getParentShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentShape), medan [TextFrame::getParentCell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#getParentCell) returnerar `null`. Därför hanterar formgrenen i exemplet även text från SmartArt‑noder.

## **Samla matchningsinformation med en callback**

Skicka en Java‑proxy‑callback till en markerings‑ eller ersättningsmetod för att få en notifikation för varje matchning. Callback‑metoden får den relaterade textramen, källtexten, den matchade texten och matchningspositionen.

Callback‑en får inte bildnumret direkt. Implementeringen nedan härleder det från föräldrabilden och hanterar även text som finns i bildanteckningar. Resultat‑arrayen använder `null` när text är associerad med en annan bildtyp.

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

Skapa en proxy för detta PHP‑objekt innan det skickas till en operation:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

För ersättningsoperationer innehåller `foundText` den ursprungliga matchade texten, så callback‑en kan exakt registrera vilka termer som ersattes.

## **Markera text**

Använd metoden [TextFrame::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightText) för att markera bokstavliga textmatchningar i en textram. Skicka [TextSearchOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/) för att styra sökningen.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**.

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

    // Markera varje förekomst av "try" i textramen.
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

    // Markera endast hela ordet "to".
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

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [TextFrame::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightRegex) markerar textmatchningar som hittas med ett reguljärt uttryck i en textram.

Följande kod markerar alla ord som innehåller sju eller fler tecken:

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

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Markera text i hela presentationen**

Använd [Presentation::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#highlightText) och [Presentation::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#highlightRegex) för att söka i alla tillämpbara textramar i en presentation. Följande exempel markerar ett bokstavligt uttryck och alla e‑postadresser:

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

## **Ersätt text i en textram**

Använd [TextFrame::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceText) för bokstavlig text och [TextFrame::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceRegex) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten inom den befintliga textramen, vilket behåller formatering av de omgivande delarna i stället för att bygga om textramen från en enkel sträng.

Följande exempel standardiserar en stavningsvariant och ersätter sedan versionsetiketter:

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

Om en matchning sträcker sig över delar med olika formatering, granska resultatet för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätt text i hela presentationen**

Använd [Presentation::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceText) och [Presentation::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceRegex) för att tillämpa samma operationer i hela presentationen. Detta är användbart för mallrengöring, terminologiuppdateringar och radering.

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

## **Gruppera matchningar för rapportering**

Eftersom varje resultat lagrar bildnummer och textram kan applikationer gruppera matchningar för granskning, rapportering eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textram:

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

**Hur kan jag söka endast i en textruta istället för i hela presentationen?**

Hämta figurens textram och anropa [TextFrame::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceText) eller [TextFrame::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceRegex) på den textramen. Metoder på presentationsnivå bearbetar alla tillämpbara textramar istället.

**Hur kan jag matcha hela ord med korrekt versalisering?**

Ställ in [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) och [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) till `true` och skicka alternativen till en bokstavlig textmarkerings‑ eller ersättningsmetod. För reguljära uttryck definierar du ordgränser och skiftlägeskänslighet i Java‑`Pattern` själv.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Ställ in [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) till `true` när du använder en bokstavlig textoperation på presentationsnivå.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en Java‑proxy‑callback till markerings‑ eller ersättningsoperationen. Den får varje matchning medan operationen körs, så applikationen kan lagra källtexten, den matchade texten, positionen, textramen och det härledda bildnumret för senare gruppering eller export.

**Behåller ersättning av text dess formatering?**

[TextFrame::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceText) och [TextFrame::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceRegex) ändrar den matchade texten inom den befintliga textramen och behåller formateringen för de omgivande delarna. Om en matchning sträcker sig över delar med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder önskad stil.