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
- resultatåteruppringning
- textruta
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som du samlar varje träff med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides for PHP via Java kan söka, markera och ersätta text i en enskild textruta eller i hela presentationen. Varje operation kan också meddela en applikation om varje träff via en resultat‑återuppringning. Detta möjliggör att uppdatera en presentation och samtidigt bygga ett granskningsspår som innehåller den matchade texten, dess kontext, position, textruta och bildnummer.

Dessa funktioner är användbara för granskning, redigering, terminologikontroller, mallrengöring och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi filen ”sample.pptx”, som innehåller en enda textruta på den första bilden med följande text:

![Sample text](sample_text.png)

## **Välj sökomfång**

Använd metoder på [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) för att begränsa en operation till en textruta. Använd metoder på [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | En textruta | Hela presentationen |
|---|---|---|
| Markera exakt text | [TextFrame::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#highlightText) |
| Markera reguljära uttryck | [TextFrame::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#highlightRegex) |
| Ersätt exakt text | [TextFrame::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceText) |
| Ersätt reguljära uttryck | [TextFrame::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceRegex) |

## **Konfigurera textmatchning**

För exakt‑textoperationer, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) begränsar träffar till hela ord.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) styr om teckenkänslighet krävs.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) inkluderar bildanteckningar i sök‑, ersättnings‑ och markeringsoperationer på presentationsnivå.

Reguljära‑uttrycksoperationer använder ett Java‑`Pattern`, så regler som teckenkänslighet och ordgränser definieras av uttrycket och dess flaggor.

## **Samla matchningsinformation med en återuppringning**

Skicka en Java‑proxy‑återuppringning till en markerings‑ eller ersättningsmetod för att få en avisering för varje träff. Återuppringningsmetoden får den relaterade textrutan, källtexten, den matchade texten och matchningspositionen.

Återuppringningen får inte bildnumret direkt. Implementeringen nedan härleder det från den överordnade bilden och hanterar också text som finns i bildanteckningar. Resultat‑arrayen använder `null` när text är kopplad till en annan bildtyp.

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

Skapa en proxy för detta PHP‑objekt innan du skickar det till en operation:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

För ersättningsoperationer innehåller `foundText` den ursprungliga matchade texten, så återuppringningen kan registrera exakt vilka termer som ersattes.

## **Markera text**

Använd metoden [TextFrame::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightText) för att markera exakt‑textträffar i en textruta. Skicka [TextSearchOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/) för att styra sökningen.

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

    // Markera varje förekomst av "try" i textrutan.
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

![The highlighted text](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [TextFrame::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightRegex) markerar textträffar som hittas med ett reguljärt uttryck i en textruta.

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Markera text i hela presentationen**

Använd [Presentation::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#highlightText) och [Presentation::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#highlightRegex) för att söka i alla tillämpliga textrutor i en presentation. Följande exempel markerar ett exakt uttryck och alla e‑postadresser:

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

## **Ersätt text i en textruta**

Använd [TextFrame::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceText) för exakt text och [TextFrame::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceRegex) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten i den befintliga textrutan, vilket bevarar den omgivande formateringen istället för att bygga om textrutan från en ren sträng.

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

Om en träff sträcker sig över delar med olika formatering, granska utdata för att bekräfta vilken formatering som ska gälla för den ersatta texten.

## **Ersätt text i hela presentationen**

Använd [Presentation::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceText) och [Presentation::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#replaceRegex) för att tillämpa samma operationer i hela presentationen. Detta är användbart för mallrengöring, terminologiska uppdateringar och redigering.

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

Eftersom varje resultat sparar sitt bildnummer och sin textruta kan applikationer gruppera matchningar för revision, rapportering eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textruta:

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

**Hur kan jag söka i endast en textruta istället för hela presentationen?**

Hämta formens textruta och anropa [TextFrame::highlightText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceText) eller [TextFrame::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceRegex) på den textrutan. Metoder på presentationsnivå bearbetar alla tillämpliga textrutor istället.

**Hur kan jag matcha hela ord med korrekt versalisering?**

Sätt [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) och [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) till `true` och skicka alternativen till en exakt‑textmarkerings‑ eller ersättningsmetod. För reguljära uttryck definierar du ordgränser och teckenkänslighet i själva Java‑`Pattern`.

**Kan sök och ersättning inkludera text i bildanteckningar?**

Ja. Sätt [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) till `true` när du använder en exakt‑textoperation på presentationsnivå.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en Java‑proxy‑återuppringning till markerings‑ eller ersättningsoperationen. Den får varje träff medan operationen körs, så applikationen kan lagra källtext, matchad text, position, textruta och härlett bildnummer för senare gruppering eller export.

**Bevarar ersättning av text dess formatering?**

[TextFrame::replaceText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceText) och [TextFrame::replaceRegex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/#replaceRegex) ändrar den matchade texten i den befintliga textrutan och behåller formateringen i de omgivande delarna. Om en träff sträcker sig över delar med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder önskad stil.