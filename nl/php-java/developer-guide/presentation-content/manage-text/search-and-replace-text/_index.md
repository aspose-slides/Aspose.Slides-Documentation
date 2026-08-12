---
title: Zoeken en Vervangen van Tekst in PowerPoint-presentaties in PHP
linktitle: Zoeken en Vervangen van Tekst
type: docs
weight: 55
url: /nl/php-java/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- resultaat callback
- tekstkader
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint-presentaties terwijl u elke overeenkomst verzamelt met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides voor PHP via Java kan tekst zoeken, markeren en vervangen in een enkel tekstkader of in een volledige presentatie. Elke bewerking kan ook een applicatie op de hoogte stellen van elke overeenkomst via een result‑callback. Hiermee kan men een presentatie bijwerken en tegelijk een audit‑trail opbouwen met de gevonden tekst, de context, positie, het tekstkader en het dia‑nummer.

Deze functionaliteiten zijn nuttig voor beoordeling, redactie, terminologiecontrole, het opruimen van sjablonen en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand met de naam "sample.pptx", dat een enkel tekstvak bevat op de eerste dia met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies het zoekbereik**

Gebruik methoden op [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) om een bewerking te beperken tot één tekstkader. Gebruik methoden op [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerking | Eén tekstkader | Volledige presentatie |
|---|---|---|
| Markeer letterlijke tekst | [TextFrame::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#highlightText) |
| Markeer reguliere‑expressie‑overeenkomsten | [TextFrame::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#highlightRegex) |
| Vervang letterlijke tekst | [TextFrame::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceText) |
| Vervang reguliere‑expressie‑overeenkomsten | [TextFrame::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configureer tekstmatching**

Voor letterlijke‑tekstbewerkingen gebruikt u [TextSearchOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/) om het zoeken te regelen:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) beperkt de overeenkomsten tot volledige woorden.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) bepaalt of hoofdletters moeten overeenkomen.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) neemt aantekeningen van dia's op in zoek-, vervang‑ en markeerbewerkingen op presentatieniveau.

Reguliere‑expressiebewerkingen gebruiken een Java `Pattern`, waardoor regels voor zoeken zoals hoofdlettergevoeligheid en woordgrenzen worden gedefinieerd door de expressie en diens vlaggen.

## **Verzamel match‑informatie met een callback**

Geef een Java‑proxy‑callback door aan een markeer‑ of vervangingsmethode om een melding te ontvangen voor elke overeenkomst. De callback‑methode ontvangt het bijbehorende tekstkader, de brontekst, de gevonden tekst en de positie van de match.

De callback krijgt niet direct een dia‑nummer. De onderstaande implementatie haalt dit af van de bovenliggende dia en verwerkt tevens tekst die zich in aantekeningen van dia's bevindt. De resultaat‑array gebruikt `null` wanneer tekst gekoppeld is aan een ander dia‑type.

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

Maak een proxy voor dit PHP‑object aan voordat u het doorgeeft aan een bewerking:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Voor vervangingsbewerkingen bevat `foundText` de oorspronkelijk gevonden tekst, zodat de callback precies kan registreren welke termen zijn vervangen.

## **Markeer tekst**

Gebruik de methode [TextFrame::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightText) om letterlijke‑tekstovereenkomsten in een tekstkader te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/) door om het zoeken te regelen.

Het code‑voorbeeld hieronder markeert alle voorkomen van de tekens **"try"** en markeert vervolgens alleen het volledige woord **"to"**.

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

    // Markeer elke voorkoming van "try" in het tekstkader.
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

    // Markeer alleen het volledige woord "to".
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

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Markeer tekst met reguliere expressies**

De methode [TextFrame::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightRegex) markeert tekstovereenkomsten die gevonden zijn met een reguliere expressie in een tekstkader.

De volgende code markeert alle woorden die zeven of meer tekens bevatten:

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

Het resultaat:

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Markeer tekst in een presentatie**

Gebruik [Presentation::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#highlightText) en [Presentation::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#highlightRegex) om alle toepasselijke tekstkaders in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen:

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

## **Vervang tekst in een tekstkader**

Gebruik [TextFrame::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceText) voor letterlijke tekst en [TextFrame::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceRegex) voor op patroon gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstkader, waardoor de opmaak van de omringende delen behouden blijft in plaats van het tekstkader opnieuw op te bouwen vanuit een platte tekenreeks.

Het volgende voorbeeld standaardiseert een spellingvariant en vervangt vervolgens versie‑labels:

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

Als één overeenkomst delen met verschillende opmaak omvat, controleer dan de output om te bevestigen welke opmaak moet gelden voor de vervangende tekst.

## **Vervang tekst in een presentatie**

Gebruik [Presentation::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceText) en [Presentation::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceRegex) om dezelfde bewerkingen toe te passen over de hele presentatie. Dit is nuttig voor het opruimen van sjablonen, terminologie‑updates en redaction.

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

## **Groeperen van overeenkomsten voor rapportage**

Aangezien elk resultaat het dia‑nummer en het tekstkader opslaat, kunnen applicaties overeenkomsten groeperen voor audit, rapportage of review‑workflows. Het volgende voorbeeld groepeert de verzamelde resultaten eerst per dia en vervolgens per tekstkader:

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

**Hoe kan ik slechts één tekstvak doorzoeken in plaats van de hele presentatie?**

Haal het tekstkader van de vorm op en roep [TextFrame::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceText) of [TextFrame::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceRegex) aan op dat tekstkader. Methoden op presentatieniveau verwerken alle toepasselijke tekstkaders.

**Hoe kan ik volledige woorden matchen met de juiste hoofdlettergebruik?**

Stel [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) en [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) in op `true` en geef de opties door aan een letterlijke‑tekst markeer‑ of vervangingsmethode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de Java `Pattern` zelf.

**Kan zoeken en vervangen tekst in dia‑notities omvatten?**

Ja. Stel [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) in op `true` wanneer u een operation op presentatieniveau met letterlijke tekst gebruikt.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een Java‑proxy‑callback door aan de markeer‑ of vervangingsbewerking. Deze ontvangt elke overeenkomst tijdens de uitvoering, zodat de applicatie de brontekst, gevonden tekst, positie, tekstkader en afgeleide dia‑nummer kan opslaan voor latere groepering of export.

**Behoudt het vervangen van tekst de opmaak?**

[TextFrame::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceText) en [TextFrame::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceRegex) wijzigen de gevonden tekst binnen het bestaande tekstkader en behouden de opmaak van de omringende delen. Als een overeenkomst delen met verschillende opmaak omvat, inspecteer dan het resultaat om te verzekeren dat de vervanging de gewenste stijl gebruikt.