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
description: "Zoek, markeer en vervang tekst in PowerPoint‑presentaties terwijl je elke overeenkomst verzamelt met Aspose.Slides for PHP via Java."
---
## **Overzicht**

Aspose.Slides for PHP via Java kan zoeken, markeren en tekst vervangen in een individueel tekstkader of door de gehele presentatie heen. Elke bewerking kan ook een applicatie informeren over elke overeenkomst via een result‑callback. Hierdoor kan een presentatie worden bijgewerkt en tegelijkertijd een audit‑trail worden opgebouwd met de gevonden tekst, de context, positie, het tekstkader en het slide‑nummer.

Deze mogelijkheden zijn nuttig voor revisie, redactie, terminologiecontroles, het opschonen van sjablonen en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand genaamd "sample.pptx", dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies de zoekscope**

Gebruik methoden op [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) om een bewerking te beperken tot één tekstkader. Gebruik methoden op [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerking | Eén tekstkader | Volledige presentatie |
|---|---|---|
| Markeer letterlijke tekst | [TextFrame::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#highlightText) |
| Markeer reguliere‑expressie‑overeenkomsten | [TextFrame::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#highlightRegex) |
| Vervang letterlijke tekst | [TextFrame::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceText) |
| Vervang reguliere‑expressie‑overeenkomsten | [TextFrame::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configureer tekstmatching**

Voor bewerkingen met letterlijke tekst kun je [TextSearchOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/) gebruiken om het zoeken te regelen:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) bepaalt of hoofdletters en kleine letters moeten overeenkomen.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) neemt notities van dia's op in zoek‑, vervang‑ en markeerbewerkingen op presentatieniveau.

Reguliere‑expressie‑bewerkingen gebruiken een Java `Pattern`, zodat zoekregels zoals hoofdlettergevoeligheid en woordgrenzen worden gedefinieerd door de expressie en de bijbehorende vlaggen.

## **Identificeer de eigenaar van een tekstkader**

Generieke tekstverwerkings‑workflows ontvangen vaak een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) tijdens het zoeken, vervangen, valideren of exporteren van tekst. Gebruik [TextFrame::getParentShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentShape) en [TextFrame::getParentCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentCell) om te bepalen welk presentatie‑object het tekstkader bezit.

De verwachte waarden hangen af van de eigenaar:

| Eigenaar van tekstkader | `getParentShape` | `getParentCell` |
|---|---|---|
| Een AutoShape of een andere tekst‑behorende vorm | De eigenaar‑[Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) | `null` |
| Een tabelcel | `null` | De eigenaar‑[Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/) |

Beide methoden bieden alleen‑lezen‑navigatie. Het aanroepen ervan verplaatst het tekstkader niet en verandert de eigenaar niet. Generieke code moet beide waarden controleren met `java_is_null` en de mogelijkheid afhandelen dat geen van beide beschikbaar is.

Het onderstaande voorbeeld gebruikt [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/#getAllTextFrames) om door alle tekstkaders in een presentatie te itereren. Voor vormen rapporteert het de vormnaam, Java‑runtime‑type en de bijbehorende dia. Voor tabelcellen rapporteert het de nul‑gebaseerde kolom‑ en rij‑coördinaten en de bijbehorende dia.

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

Voor SmartArt‑inhoud itereren we door de vormen in [SmartArtNode::getShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartnode/#getShapes) en benaderen we elk [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartartshape/#getTextFrame). Het tekstkader kan via [TextFrame::getParentShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentShape) worden getraceerd naar de bijbehorende vorm, terwijl [TextFrame::getParentCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getParentCell) `null` retourneert. Daarom behandelt de vorm‑tak in het voorbeeld ook tekst uit SmartArt‑nodes.

## **Verzamel overeenkomst‑informatie met een callback**

Geef een Java‑proxy‑callback door aan een markeer‑ of vervangmethode om een melding te ontvangen voor elke overeenkomst. De callback‑methode ontvangt het gerelateerde tekstkader, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt niet direct een slidenaam. De implementatie hieronder haalt deze af van de bovenliggende dia en verwerkt ook tekst die in notities staat. Het result‑array gebruikt `null` wanneer tekst gekoppeld is aan een ander slide‑type.

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

Maak een proxy voor dit PHP‑object aan voordat je het aan een bewerking doorgeeft:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Voor vervang‑bewerkingen bevat `foundText` de originele gevonden tekst, zodat de callback exact kan registreren welke termen zijn vervangen.

## **Markeer tekst**

Gebruik de [TextFrame::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightText)‑methode om letterlijke tekstovereenkomsten in een tekstkader te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/) door om de zoekopdracht te regelen.

De onderstaande code markeert alle voorkomens van de tekens **"try"** en markeert vervolgens alleen het volledige woord **"to"**.

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

    // Markeer elke instantie van "try" in het tekstkader.
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

De [TextFrame::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightRegex)‑methode markeert tekstovereenkomsten gevonden door een reguliere expressie in een tekstkader.

De onderstaande code markeert alle woorden die zeven of meer tekens bevatten:

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

## **Markeer tekst door een presentatie heen**

Gebruik [Presentation::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#highlightText) en [Presentation::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#highlightRegex) om alle toepasselijke tekstkaders in een presentatie te doorzoeken. Het onderstaande voorbeeld markeert een letterlijke term en alle e‑mailadressen:

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

Gebruik [TextFrame::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceText) voor letterlijke tekst en [TextFrame::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceRegex) voor patroon‑gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstkader, waardoor de opmaak van de omringende delen behouden blijft in plaats van het tekstkader opnieuw samen te stellen uit een platte string.

Het onderstaande voorbeeld uniformiseert een spellingvariant en vervangt vervolgens versie‑labels:

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

Als één overeenkomst delen met verschillende opmaak omvat, controleer dan de uitvoer om te bevestigen welke opmaak moet worden toegepast op de vervangende tekst.

## **Vervang tekst door een presentatie heen**

Gebruik [Presentation::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceText) en [Presentation::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#replaceRegex) om dezelfde bewerkingen over de gehele presentatie toe te passen. Dit is nuttig voor het opschonen van sjablonen, terminologie‑updates en redactie.

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

Omdat elk resultaat zijn slidenaam en tekstkader opslaat, kunnen applicaties overeenkomsten groeperen voor audit‑, rapportage‑ of review‑processen. Het onderstaande voorbeeld groepeert de verzamelde resultaten eerst per dia en vervolgens per tekstkader:

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

**Hoe kan ik slechts één tekstvak doorzoeken in plaats van de gehele presentatie?**

Haal het tekstkader van de vorm op en roep [TextFrame::highlightText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceText) of [TextFrame::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceRegex) aan op dat tekstkader. Methoden op presentatieniveau verwerken alle toepasselijke tekstkaders.

**Hoe kan ik volledige woorden met de juiste hoofdletters vinden?**

Stel [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) en [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) in op `true` en geef de opties door aan een letterlijke‑tekst‑markeer‑ of vervangmethode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid direct in de Java `Pattern`.

**Kunnen zoeken en vervangen ook tekst in notities van dia's omvatten?**

Ja. Stel [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) in op `true` bij het gebruik van een letterlijke‑tekst‑bewerking op presentatieniveau.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een Java‑proxy‑callback door aan de markeer‑ of vervangbewerking. Deze ontvangt elke overeenkomst terwijl de bewerking loopt, zodat de applicatie de brontekst, gevonden tekst, positie, tekstkader en afgeleide slidenaam kan opslaan voor later groeperen of exporteren.

**Behoudt het vervangen van tekst de opmaak?**

[TextFrame::replaceText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceText) en [TextFrame::replaceRegex](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#replaceRegex) wijzigen de gevonden tekst binnen het bestaande tekstkader en behouden de opmaak van de omringende delen. Als een overeenkomst delen met verschillende opmaak omvat, inspecteer dan het resultaat om te verzekeren dat de vervanging de gewenste stijl gebruikt.