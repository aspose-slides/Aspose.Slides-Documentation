---
title: Suche und Ersetze Text in PowerPoint-Präsentationen in PHP
linktitle: Suche und Ersetze Text
type: docs
weight: 55
url: /de/php-java/search-and-replace-text/
keywords:
- Text suchen
- Text hervorheben
- Text ersetzen
- regulärer Ausdruck
- Ergebnis-Callback
- Textfeld
- Prüfbericht
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Text in PowerPoint-Präsentationen suchen, hervorheben und ersetzen, wobei jeder Treffer mit Aspose.Slides für PHP via Java gesammelt wird."
---
## **Übersicht**

Aspose.Slides für PHP via Java kann Text in einem einzelnen Textfeld oder in einer gesamten Präsentation suchen, hervorheben und ersetzen. Jede Operation kann außerdem einer Anwendung über jeden Treffer mittels eines Ergebnis‑Callbacks benachrichtigen. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textfeld und Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfungen, Schwärzungen, Terminologie‑Prüfungen, Vorlagenbereinigung und automatisierte Bericht‑Workflows.

In den ersten nachstehenden Beispielen verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden auf [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) um eine Operation auf ein Textfeld zu beschränken. Verwenden Sie Methoden auf [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) um allen anwendbaren Text in der Präsentation zu verarbeiten.

| Operation | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Literaltext hervorheben | [TextFrame::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#highlightText) |
| Übereinstimmungen regulärer Ausdrücke hervorheben | [TextFrame::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#highlightRegex) |
| Literaltext ersetzen | [TextFrame::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceText) |
| Übereinstimmungen regulärer Ausdrücke ersetzen | [TextFrame::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceRegex) |

## **Textabgleich konfigurieren**

Für Literal‑Text‑Operationen verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/), um die Übereinstimmung zu steuern:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) begrenzt Treffer auf vollständige Wörter.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) steuert, ob die Groß‑ und Kleinschreibung der Zeichen übereinstimmen muss.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) schließt Folien‑Notizen in Such‑, Ersetz‑ und Hervorhebungs‑Operationen auf Präsentationsebene ein.

Operationen mit regulären Ausdrücken verwenden ein Java‑`Pattern`, sodass Regeln für die Übereinstimmung wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck und dessen Flags definiert werden.

## **Trefferinformationen mit einem Callback sammeln**

Übergeben Sie einem Hervorhebungs‑ oder Ersetzungs‑Methoden einen Java‑Proxy‑Callback, um für jeden Treffer eine Benachrichtigung zu erhalten. Die Callback‑Methode erhält das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Treffer‑Position.

Der Callback erhält die Foliennummer nicht direkt. Die untenstehende Implementierung leitet sie aus der übergeordneten Folie ab und verarbeitet außerdem Text, der in Folien‑Notizen gefunden wird. Das Ergebnis‑Array verwendet `null`, wenn der Text einer anderen Folientyp‑Kategorie zugeordnet ist.

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

Erstellen Sie einen Proxy für dieses PHP‑Objekt, bevor Sie es an eine Operation übergeben:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Bei Ersetzungs‑Operationen enthält `foundText` den ursprünglich gefundenen Text, sodass der Callback exakt festhalten kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [TextFrame::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightText), um Literal‑Text‑Treffer in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/), um die Suche zu steuern.

Das nachstehende Code‑Beispiel hebt alle Vorkommen der Zeichen **"try"** hervor und anschließend nur das vollständige Wort **"to"**.

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

    // Hervorheben jedes Vorkommens von "try" im Textfeld.
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

    // Nur das vollständige Wort "to" hervorheben.
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

Das Ergebnis:

![Der hervorgehobene Text](highlighted_text.png)

## **Text mit regulären Ausdrücken hervorheben**

Die Methode [TextFrame::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightRegex), hebt Text‑Treffer hervor, die durch einen regulären Ausdruck in einem Textfeld gefunden wurden.

Der folgende Code hebt alle Wörter hervor, die sieben oder mehr Zeichen enthalten:

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

Das Ergebnis:

![Der hervorgehobene Text mittels regulärem Ausdruck](highlighted_text_using_regex.png)

## **Text in einer gesamten Präsentation hervorheben**

Verwenden Sie [Presentation::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#highlightText) und [Presentation::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#highlightRegex), um alle anwendbaren Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen Literalbegriff und alle E‑Mail‑Adressen hervor:

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

## **Text in einem Textfeld ersetzen**

Verwenden Sie [TextFrame::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceText), um Literaltext zu ersetzen, und [TextFrame::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceRegex), um ersatzbasiert mittels Muster zu ersetzen. Diese Methoden aktualisieren den gefundenen Text innerhalb des bestehenden Textfeldes, wobei die Formatierung des umgebenden Bereichs erhalten bleibt, anstatt das Textfeld aus einem einfachen String neu aufzubauen.

Das folgende Beispiel standardisiert eine Schreibvariante und ersetzt anschließend Versionsbezeichnungen:

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

Falls ein Treffer Bereiche mit unterschiedlicher Formatierung umfasst, überprüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den ersetzten Text angewendet werden soll.

## **Text in einer gesamten Präsentation ersetzen**

Verwenden Sie [Presentation::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceText) und [Presentation::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceRegex), um dieselben Operationen in der gesamten Präsentation anzuwenden. Dies ist nützlich für Vorlagenbereinigung, Terminologie‑Aktualisierungen und Schwärzungen.

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

## **Treffer für Berichte gruppieren**

Da jedes Ergebnis seine Foliennummer und das Textfeld speichert, können Anwendungen Treffer für Prüf‑, Bericht‑ oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zuerst nach Folie und anschließend nach Textfeld:

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

**Wie kann ich nur ein Textfeld statt der gesamten Präsentation durchsuchen?**

Rufen Sie das Textfeld der Form auf und verwenden Sie [TextFrame::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceText) oder [TextFrame::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceRegex) für dieses Textfeld. Methoden auf Präsentationsebene verarbeiten stattdessen alle anwendbaren Textfelder.

**Wie kann ich vollständige Wörter mit korrekter Groß‑ und Kleinschreibung finden?**

Setzen Sie [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) und [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) auf `true` und übergeben Sie die Optionen an eine Literal‑Text‑Hervorhebungs‑ oder Ersetzungs‑Methode. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im Java‑`Pattern` selbst.

**Können Suche und Ersetzung Text in Folien‑Notizen einschließen?**

Ja. Setzen Sie [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) auf `true`, wenn Sie eine Literal‑Text‑Operation auf Präsentationsebene verwenden.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu durchsuchen?**

Übergeben Sie einen Java‑Proxy‑Callback an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält jeden Treffer, während die Operation läuft, sodass die Anwendung den Quelltext, den gefundenen Text, die Position, das Textfeld und die abgeleitete Foliennummer für spätere Gruppierung oder den Export speichern kann.

**Behält das Ersetzen von Text dessen Formatierung bei?**

[TextFrame::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceText) und [TextFrame::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceRegex) ändern den gefundenen Text innerhalb des bestehenden Textfeldes und behalten die Formatierung des umgebenden Bereichs bei. Falls ein Treffer Bereiche mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung die gewünschte Formatierung verwendet.