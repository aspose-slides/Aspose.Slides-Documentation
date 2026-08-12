---
title: Text in Präsentationen in PHP formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/php-java/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Drehwinkel
- Textrahmen
- Zeilenabstand
- Autofit-Eigenschaft
- Textrahmen-Anker
- Texttabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP über Java. Passen Sie Schriftarten, Farben, Ausrichtung und mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP über Java formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textausrichtung, Tabulatoren und Spracheinstellungen.

In den nachfolgenden Beispielen verwenden wir eine Datei mit dem Namen "sample.pptx", die auf der ersten Folie eine einzelne Textbox mit folgendem Text enthält:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder reguläre Ausdruck‑Übereinstimmungen zu finden und zu markieren, siehe [Suchen und Ersetzen von Text](/slides/de/php-java/search-and-replace-text/).

## **Text-Hintergrundfarbe festlegen**

Verwenden Sie [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder verwenden Sie [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#getHighlightColor) für einzelne Textabschnitte.

Das folgende Codebeispiel zeigt, wie die Hintergrundfarbe für den **gesamten Absatz** festgelegt wird:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Setze die Hervorhebungsfarbe für den gesamten Absatz.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das folgende Codebeispiel demonstriert, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** festgelegt wird:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Setze die Hervorhebungsfarbe für den Textabschnitt.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#setAlignment), um die Absatzausrichtung innerhalb eines Textfelds festzulegen. Der Wert kann zentriert, linksbündig, rechtsbündig, blockiert usw. sein.

Das folgende Codebeispiel zeigt, wie der Absatz **zentriert** ausgerichtet wird:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Setze die Ausrichtung des Absatzes auf zentriert.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#getFillFormat) zugewiesen wird. In den folgenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Kanalwert im Bereich 0–255 und keine Transparenz‑Prozentsatz.

Das folgende Codebeispiel zeigt, wie Transparenz auf den **gesamten Absatz** angewendet wird:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Setze die Füllfarbe des Textes auf eine transparente Farbe.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Codebeispiel zeigt, wie Transparenz auf **Textabschnitte mit fetter Schrift** angewendet wird:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Setze die Transparenz des Textabschnitts.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die transparenten Textabschnitte](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setSpacing), um den Abstand zwischen Zeichen in einer Textbox zu vergrößern oder zu verkleinern.

Der folgende PHP‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu verringern.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Zeichenabstand vergrößern.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das folgende Codebeispiel zeigt, wie der Zeichenabstand in **Textabschnitten mit fetter Schrift** erweitert wird:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu verringern.
            $portion->getPortionFormat()->setSpacing(3); // Zeichenabstand vergrößern.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In einigen Fällen kann von Aspose.Slides gerenderter Text etwas enger wirken als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die gerenderte Ausgabe in solchen Fällen PowerPoint anzugleichen, können Sie das Kerning für Textabschnitte, die die betroffene Schrift verwenden, deaktivieren. Setzen Sie [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) auf einen Wert, der deutlich größer ist als die tatsächliche Schriftgröße:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Diese Einstellung verhindert, dass Kerning auf passende Textabschnitte angewendet wird, und kann dazu beitragen, das Rendering von Aspose.Slides an die visuelle Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften anzupassen.

## **Textschrift‑Eigenschaften verwalten**

Schrifteigenschaften können auf Absatzebene über [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) oder auf einzelnen Abschnitten über [PortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/portionformat/) festgelegt werden.

Der folgende Code legt die Schrift und den Textstil für den gesamten Absatz fest: Er wendet Schriftgröße, Fett, Kursiv, gepunktete Unterstreichung und die Schrift Times New Roman auf alle Abschnitte im Absatz an.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Setze die Schrifteigenschaften für den Absatz.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Schrifteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Codebeispiel wendet ähnliche Eigenschaften auf **Textabschnitte mit fetter Schrift** an:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Setze die Schrifteigenschaften für den Textabschnitt.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Schrifteigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Textrotation festlegen**

Verwenden Sie [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setTextVerticalType), um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Das folgende Codebeispiel setzt die Textausrichtung in der Form auf `Vertical270`, wodurch der Text **90 ° gegen den Uhrzeigersinn** gedreht wird:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Textrotation](text_rotation.png)

## **Benutzerdefinierte Drehung für Textrahmen festlegen**

Verwenden Sie [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setRotationAngle), um einen benutzerdefinierten Drehwinkel für einen [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) festzulegen.

Das folgende Codebeispiel dreht den Textrahmen innerhalb der Form um 3 ° im Uhrzeigersinn:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die benutzerdefinierte Textrotation](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#setSpaceBefore) und [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#setSpaceWithin) zur Steuerung des Absatzabstands. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Codebeispiel zeigt, wie der Zeilenabstand innerhalb des Absatzes festgelegt wird:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der Zeilenabstand im Absatz](line_spacing.png)

## **Autofit‑Typ für Textrahmen festlegen**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setAutofitType) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob der Text verkleinert, überläuft oder die Form automatisch anpasst.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verankerung von Textrahmen festlegen**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setAnchoringType) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Texttabulation festlegen**

Verwenden Sie [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) und [ParagraphFormat::getTabs](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#getTabs), um Tabulatoren in einem Absatz zu konfigurieren.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Absatz‑Tabulatoren](paragraph_tabs.png)

## **Rechtschreib‑Sprache festlegen**

Aspose.Slides stellt [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setLanguageId) bereit, mit dem Sie die Rechtschreibsprache für einen Textabschnitt festlegen können. Die Rechtschreibsprache bestimmt die Sprache, die für Rechtschreib‑ und Grammatikprüfungen in PowerPoint verwendet wird.

Das folgende Codebeispiel zeigt, wie die Rechtschreibsprache für einen Textabschnitt festgelegt wird:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Setze die Id einer Rechtschreibsprache.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Füge eine neue Rechteckform mit Text hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Überprüfe die Sprache des ersten Textabschnitts.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Standard‑Textstil festlegen**

Um die Standard‑Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Das folgende Codebeispiel zeigt, wie eine standardmäßige fette Schrift mit einer Größe von 14 pt für allen Text über alle Folien hinweg in einer neuen Präsentation festgelegt wird.

```php
$presentation = new Presentation();
try {
    // Hole das Absatzformat der obersten Ebene.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Text mit dem ALL‑CAPS‑Effekt extrahieren**

In PowerPoint sorgt das Anwenden des **All Caps**‑Schrifteffekts dafür, dass Text auf der Folie in Großbuchstaben erscheint, selbst wenn er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides abrufen, gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/de/php-java/aspose.slides/textcaptype/) und wandeln Sie die zurückgegebene Zeichenkette in Großbuchstaben um, wenn der Wert `All` ist.

Angenommen, wir haben die folgende Textbox auf der ersten Folie der Datei sample2.pptx.

![Der All Caps‑Effekt](all_caps_effect.png)

Das folgende Codebeispiel zeigt, wie der Text mit angewendetem **All Caps**‑Effekt extrahiert wird:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Ausgabe:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [Cell::getTextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/cell/#getTextFrame) sowie die Absatzformatierung über [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Wie kann man einem Text in einer PowerPoint‑Folien einen Farbverlauf hinzufügen?**

Um einem Text einen Farbverlauf zuzuweisen, verwenden Sie [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#getFillFormat). Setzen Sie [FillFormat::setFillType](https://reference.aspose.com/slides/de/php-java/aspose.slides/fillformat/#setFillType) auf [FillType::Gradient](https://reference.aspose.com/slides/de/php-java/aspose.slides/filltype/) und konfigurieren Sie die Farbverlaufsstopps, die Richtung und die Transparenz.