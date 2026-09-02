---
title: Suchen und Ersetzen von Text in PowerPoint-Präsentationen in PHP
linktitle: Suchen und Ersetzen von Text
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
description: "Suchen, Hervorheben und Ersetzen von Text in PowerPoint-Präsentationen, wobei jede Übereinstimmung mit Aspose.Slides für PHP via Java gesammelt wird."
---
## **Übersicht**

Aspose.Slides für PHP via Java kann Text in einem einzelnen TextFrame oder über die gesamte Präsentation hinweg suchen, hervorheben und ersetzen. Jeder Vorgang kann auch eine Anwendung über jede Übereinstimmung mittels eines Ergebnis‑Callbacks benachrichtigen. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, TextFrame und Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfungen, Schwärzungen, Terminologie‑Prüfungen, Vorlagenbereinigungen und automatisierte Bericht‑Workflows.

In den ersten Beispielen unten verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden auf [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) um einen Vorgang auf ein TextFrame zu beschränken. Verwenden Sie Methoden auf [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) um allen anwendbaren Text in der Präsentation zu verarbeiten.

| Operation | Ein TextFrame | Ganze Präsentation |
|---|---|---|
| Literalen Text hervorheben | [TextFrame::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#highlightText) |
| Übereinstimmungen regulärer Ausdrücke hervorheben | [TextFrame::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#highlightRegex) |
| Literalen Text ersetzen | [TextFrame::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceText) |
| Übereinstimmungen regulärer Ausdrücke ersetzen | [TextFrame::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceRegex) |

## **Textabgleich konfigurieren**

Für literal‑Text‑Vorgänge verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/) , um den Abgleich zu steuern:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) begrenzt Übereinstimmungen auf komplette Wörter.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) steuert, ob die Groß‑ und Kleinschreibung übereinstimmen muss.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) schließt Foliennotizen in Such‑, Ersetz‑ und Hervorhebungs‑Vorgängen auf Präsentationsebene ein.

Bei Vorgängen mit regulären Ausdrücken wird ein Java `Pattern` verwendet, sodass Abgleichregeln wie Groß‑ und Kleinschreibung sowie Wortgrenzen durch den Ausdruck und seine Flags festgelegt werden.

## **Den Eigentümer eines TextFrames ermitteln**

Allgemeine Textverarbeitungs‑Workflows erhalten häufig ein [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) beim Suchen, Ersetzen, Validieren oder Exportieren von Text. Verwenden Sie [TextFrame::getParentShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentShape) und [TextFrame::getParentCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentCell), um zu bestimmen, welches Präsentationsobjekt das TextFrame besitzt.

Die erwarteten Werte hängen vom Eigentümer ab:

| Eigentümer des TextFrames | `getParentShape` | `getParentCell` |
|---|---|---|
| Ein AutoShape oder eine andere texthaltende Form | Das zugehörige [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) | `null` |
| Eine Tabellenzelle | `null` | Das zugehörige [Cell](https://reference.aspose.com/slides/de/php-java/aspose.slides/cell/) |

Beide Methoden bieten eine schreibgeschützte Navigation. Ein Aufruf ändert nicht die Position des TextFrames und auch nicht dessen Eigentümer. Generischer Code sollte beide Werte mit `java_is_null` prüfen und den Fall berücksichtigen, dass kein Eigentümer vorhanden ist.

Das folgende Beispiel verwendet [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/de/php-java/aspose.slides/slideutil/#getAllTextFrames), um durch die TextFrames einer Präsentation zu iterieren. Für Formen gibt es den Namen der Form, den Java‑Laufzeit‑Typ und die zugehörige Folie aus. Für Tabellenzellen werden die nullbasierten Spalten‑ und Zeilenkoordinaten sowie die zugehörige Folie ausgegeben.

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

Für SmartArt‑Inhalte iterieren Sie über die Formen in [SmartArtNode::getShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartnode/#getShapes) und greifen auf jedes [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/smartartshape/#getTextFrame) zu. Das TextFrame kann über [TextFrame::getParentShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentShape) zu seiner zugehörigen Form zurückverfolgt werden, während [TextFrame::getParentCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentCell) `null` zurückgibt. Deshalb behandelt der Form‑Zweig im Beispiel auch Text aus SmartArt‑Knoten.

## **Match‑Informationen mithilfe eines Callbacks sammeln**

Übergeben Sie einen Java‑Proxy‑Callback an eine Hervorhebungs‑ oder Ersetzungsmethode, um für jede Übereinstimmung eine Benachrichtigung zu erhalten. Die Callback‑Methode erhält das zugehörige TextFrame, den Ausgangstext, den gefundenen Text und die Position der Übereinstimmung.

Der Callback erhält die Foliennummer nicht direkt. Die nachstehende Implementierung leitet sie aus der übergeordneten Folie ab und verarbeitet zudem Text, der in Foliennotizen gefunden wird. Das Ergebnis‑Array verwendet `null`, wenn der Text einer anderen Folientyp zugeordnet ist.

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

Erzeugen Sie einen Proxy für dieses PHP‑Objekt, bevor Sie es an einen Vorgang übergeben:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Bei Ersetzungsvorgängen enthält `foundText` den ursprünglichen gefundenen Text, sodass der Callback genau festhalten kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [TextFrame::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightText), um Literal‑Text‑Übereinstimmungen in einem TextFrame hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/), um die Suche zu steuern.

Das nachstehende Code‑Beispiel hebt alle Vorkommen der Zeichen **"try"** hervor und hebt anschließend nur das komplette Wort **"to"** hervor.

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

    // Hebe jedes Vorkommen von "try" im Textfeld hervor.
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

    // Hebe nur das komplette Wort "to" hervor.
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

Die Methode [TextFrame::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightRegex) hebt Textübereinstimmungen hervor, die durch einen regulären Ausdruck in einem TextFrame gefunden wurden.

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

![Der hervorgehobene Text unter Verwendung des regulären Ausdrucks](highlighted_text_using_regex.png)

## **Text in einer Präsentation hervorheben**

Verwenden Sie [Presentation::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#highlightText) und [Presentation::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#highlightRegex), um alle anwendbaren TextFrames in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen literal‑Begriff und alle E‑Mail‑Adressen hervor:

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

## **Text in einem TextFrame ersetzen**

Verwenden Sie [TextFrame::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceText) für literal‑Text und [TextFrame::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceRegex) für ersatzbasierte Muster. Diese Methoden aktualisieren den gefundenen Text innerhalb des bestehenden TextFrames, wobei die umgebende Formatierung beibehalten wird, anstatt das TextFrame aus einem einfachen String neu zu erstellen.

Das nachstehende Beispiel standardisiert eine Rechtschreibvariante und ersetzt anschließend Versionsbezeichnungen:

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

Falls eine Übereinstimmung Teile mit unterschiedlicher Formatierung umfasst, prüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den ersetzten Text angewendet werden soll.

## **Text in einer Präsentation ersetzen**

Verwenden Sie [Presentation::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceText) und [Presentation::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#replaceRegex), um dieselben Vorgänge über die gesamte Präsentation anzuwenden. Dies ist nützlich für die Bereinigung von Vorlagen, Terminologie‑Aktualisierungen und Schwärzungen.

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

## **Übereinstimmungen für Berichte gruppieren**

Da jedes Ergebnis die Foliennummer und das TextFrame speichert, können Anwendungen Übereinstimmungen für Prüfungen, Berichte oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zunächst nach Folie und anschließend nach TextFrame:

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

Rufen Sie das TextFrame der Form ab und rufen Sie [TextFrame::highlightText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceText) bzw. [TextFrame::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceRegex) für dieses TextFrame auf. Methoden auf Präsentationsebene verarbeiten stattdessen alle anwendbaren TextFrames.

**Wie kann ich komplette Wörter mit korrekter Groß‑ und Kleinschreibung abgleichen?**

Setzen Sie [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) und [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) auf `true` und übergeben Sie die Optionen an eine literal‑Text‑Hervorhebungs‑ oder Ersetzungsmethode. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im Java‑`Pattern` selbst.

**Können Suche und Ersetzung Text in Foliennotizen einschließen?**

Ja. Setzen Sie [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/de/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) auf `true`, wenn Sie eine literal‑Text‑Operation auf Präsentationsebene verwenden.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu durchlaufen?**

Übergeben Sie einen Java‑Proxy‑Callback an die Hervorhebungs‑ oder Ersetzungs‑Operation. Er erhält jede Übereinstimmung während des Vorgangs, sodass die Anwendung den Ausgangstext, den gefundenen Text, die Position, das TextFrame und die abgeleitete Foliennummer für spätere Gruppierung oder den Export speichern kann.

**Behält das Ersetzen von Text dessen Formatierung bei?**

[TextFrame::replaceText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceText) und [TextFrame::replaceRegex](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#replaceRegex) ändern den gefundenen Text innerhalb des bestehenden TextFrames und behalten die umgebende Formatierung bei. Wenn eine Übereinstimmung Teile mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung den gewünschten Stil verwendet.