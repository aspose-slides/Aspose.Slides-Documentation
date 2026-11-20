---
title: Präsentationstext in PHP formatieren
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
- Schriftarteigenschaften
- Schriftfamilie
- Textdrehung
- Drehwinkel
- Textrahmen
- Zeilenabstand
- Autofit‑Eigenschaft
- Textrahmen-Anker
- Texttabulator
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java formatieren und gestalten. Schriftarten, Farben, Ausrichtungen und mehr anpassen."
---
## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint‑ und OpenDocument‑Präsentationen mithilfe von Aspose.Slides für PHP via Java formatiert wird. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textanker, Tabulatoren und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Form‑Indizes beginnen bei Null. Beispiele, die fette Textteile auswählen, verwenden effektive Formatierung, einschließlich vererbter fetter Formatierung:

![Beispieltext](sample_text.png)

Um wörtlichen Text bzw. Übereinstimmungen von regulären Ausdrücken zu finden und zu markieren, siehe [Search and Replace Text](/slides/de/php-java/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder verwenden Sie [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) für einzelne Textabschnitte.

Das folgende Beispiel setzt eine hellgraue Hervorhebung als Standard für den ersten Absatz. Explizite Hervorhebungsfarben für einzelne Abschnitte haben Vorrang vor diesem Standard:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Setzt die Hervorhebungsfarbe für den gesamten Absatz.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachstehende Code‑Beispiel demonstriert, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** festgelegt wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Setzt die Hervorhebungsfarbe für den Textabschnitt.
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

## **Absätze ausrichten**

Verwenden Sie [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), um die Absatz­ausrichtung innerhalb eines Textrahmens festzulegen. Der Wert kann z. B. zentriert, linksbündig, rechtsbündig, Block‑Justified usw. sein.

Das folgende Code‑Beispiel zeigt, wie der Absatz **zentriert** ausgerichtet wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Setzt die Ausrichtung des Absatzes auf zentriert.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriftarten innerhalb einer Zeile ausrichten**

Verwenden Sie [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment), um Textabschnitte unterschiedlicher Schriftgrößen vertikal innerhalb einer Zeile auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung innerhalb jeder seiner Zeilen.

Das folgende, eigenständige Beispiel erzeugt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 Punkt, jeweils mit einer anderen Schrift‑Ausrichtung. Es verwendet Arial, deaktiviert Autofit und Zeilenumbruch und hält die Textrahmen groß genug für eine einzelne Zeile.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Vergleich von Baseline, Top, Center und Bottom Schrift‑Ausrichtung bei gemischten Schriftgrößen](font_alignment.png)

Die Schrift‑Ausrichtung verwendet Schrift‑Metriken, sodass die sichtbaren Kanten einzelner Buchstaben nicht zwangsläufig exakt übereinstimmen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen tief hängenden Buchstaben, um den Unterschied zwischen Basis‑ und Unter‑Ausrichtung zu verdeutlichen. Schriftverfügbarkeit und -ersatz, die verwendeten Zeichen und die Unterschiedlichkeit der Schriftgrößen beeinflussen das Ergebnis. Rahmen‑Abmessungen, Ränder, Zeilenabstand, Zeilenumbruch und Autofit wirken sich ebenfalls auf das Layout aus; verwenden Sie dieselben Schriften und Layout‑Einstellungen beim Vergleich der Modi.

Diese Einstellung unterscheidet sich von [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), das die horizontale Absatz‑Ausrichtung steuert, und von [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), das den Textblock vertikal innerhalb seiner Form positioniert. Hoch‑ bzw. Tiefstellung über [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) verschiebt einzelne Abschnitte relativ zur Grundlinie, anstatt die Schrift‑Ausrichtung für die Zeilen des Absatzes festzulegen.

## **Transparenz für Text festlegen**

Die Text‑Transparenz wird durch die Alpha‑Komponente der Farbe gesteuert, die [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) zugewiesen wird. In den nachfolgenden Beispielen bedeutet `alpha = 50` einen ARGB‑Alpha‑Wert im Bereich 0–255 und keine Prozent‑Angabe für die Transparenz.

Das folgende Code‑Beispiel zeigt, wie die Transparenz auf den **gesamten Absatz** angewendet wird:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Setzt die Füllfarbe des Textes auf eine transparente Farbe.
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

Das folgende Code‑Beispiel zeigt, wie die Transparenz auf **Textabschnitte mit fetter Schrift** angewendet wird:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Setzt die Transparenz des Textabschnitts.
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

Verwenden Sie [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verringern. Die Beispiele fügen 3 Punkt Abstand hinzu; negative Werte verdichten den Text.

Der folgende PHP‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Zeichenabstand erweitern.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das nachstehende Code‑Beispiel zeigt, wie der Zeichenabstand in **Textabschnitten mit fetter Schrift** erweitert wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
            $portion->getPortionFormat()->setSpacing(3); // Zeichenabstand erweitern.
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

In manchen Fällen kann der von Aspose.Slides gerenderte Text leicht enger wirken als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint für bestimmte Schriften Kerning‑Daten ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die gerenderte Ausgabe in solchen Fällen PowerPoint‑ähnlicher zu machen, können Sie Kerning für Textabschnitte deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erste Form auf der ersten Folie. Es prüft effektive Schrift­namen, einschließlich vererbter Schriften, und legt eine Schwelle von 100 Punkt für Abschnitte fest, die Roboto verwenden. Damit wird Kerning für passende Abschnitte mit einer Schriftgröße unter 100 Punkt deaktiviert:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Für passende Texte unterhalb der Schwelle verhindert diese Einstellung Kerning und kann dabei helfen, die Darstellung von Aspose.Slides an die visuelle Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften anzupassen.

## **Schriftarteigenschaften verwalten**

Schriftarteigenschaften können auf Absatz‑Ebene über [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) oder für einzelne Abschnitte über [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) festgelegt werden.

Das folgende Beispiel setzt die Standardschrift des ersten Absatzes auf Times New Roman 12 Punkt mit fett, kursiv und gepunkteter Unterstreichung. Explizite Formatierung einzelner Abschnitte hat Vorrang vor diesen Vorgaben.

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Setzen Sie die Schriftarteigenschaften für den Absatz.
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

![Die Schriftarteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet Times New Roman 13 Punkt, kursive Formatierung und eine gepunktete Unterstreichung auf Abschnitte an, deren effektive Formatierung fett ist:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Setzen Sie die Schriftarteigenschaften für den Textabschnitt.
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

![Die Schriftarteigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Text‑Höhen‑Normalisierung steuern**

Verwenden Sie [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight), wenn Sie typografische Vorlagen reproduzieren oder Unterschiede in der Zeichenhöhe untersuchen. In PowerPoint bewirkt das Aktivieren der Normalisierung, dass einzelne Zeichen vertikal gedehnt bzw. komprimiert werden, um innerhalb des Textabschnitts eine einheitliche sichtbare Höhe zu erhalten. Es garantiert keine gleiche Text‑Höhe zwischen unterschiedlichen Schriften.

Setzen Sie die Eigenschaft auf [NullableBool::True or False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), um Normalisierung explizit zu aktivieren bzw. zu deaktivieren. `NullableBool::NotDefined` lässt die lokale Einstellung undefiniert, sodass der Abschnitt den Wert z. B. von [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) des Absatzes erbt. Das bedeutet nicht `False`. Verwenden Sie [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) und lesen Sie `getNormaliseHeight` aus den zurückgegebenen effektiven Formatierungsdaten, um den aufgelösten booleschen Wert zu erhalten.

Das folgende eigenständige Beispiel benötigt **Arial**. Es erzeugt zwei Textblöcke mit denselben Groß‑ und Kleinbuchstaben, tief hängenden Buchstaben und Zeichen mit Akzenten bei 54 Punkt. Beide Absätze aktivieren Normalisierung standardmäßig. Der obere Abschnitt deaktiviert sie explizit; der untere erbt die Aktivierung. Rahmen‑Größen, Ränder und Absatz‑Abstand sind identisch, Zeilenumbruch und Autofit sind deaktiviert, um den Vergleich konsistent zu halten. Das Beispiel gibt `False: false` und `NotDefined: true` aus und speichert „text_height_normalization.pptx“.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der unten abgebildete Vergleich stammt aus der gespeicherten Präsentation. Die obere Zeile hat Normalisierung deaktiviert (`False`); die untere Zeile erbt die aktivierte Einstellung (`NotDefined` → `True`). Stellen Sie sicher, dass Arial installiert ist, um das Aussehen zu reproduzieren.

![Arial‑Text mit 54 Punkt, oben ohne Normalisierung und unten mit geerbter Normalisierung](text_height_normalization.png)

Normalisierung verändert die Zeichenhöhe, ohne den zugewiesenen Wert von [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) zu ändern, der die Schriftgröße in Punkt angibt. Der Absatz‑[setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) steuert den Zeilenabstand, während das Text‑Frame‑[setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) festlegt, wie Text oder sein Behälter sich anpassen. Diese Einstellungen dienen unterschiedlichen Zwecken und können das Gesamtlayout unabhängig voneinander beeinflussen. Weitere Informationen zu Absatz‑Formatierung und Vererbung finden Sie unter [Manage Paragraph](/slides/de/php-java/manage-paragraph/).

## **Durchgestrichenen Text anwenden und entfernen**

Verwenden Sie [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) auf einem Textabschnitt, um Korrekturen, stornierte Begriffe oder frühere Preise anzuzeigen, ohne den Originaltext zu löschen. Setzen Sie ihn auf [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) für ein‑ bzw. zweifaches Durchstreichen.

Um das Durchstreichen zu entfernen, übergeben Sie [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). Dies deaktiviert den Effekt ausdrücklich, selbst wenn die umgebende Formatierung Durchstreichen angibt. Im Gegensatz dazu lässt [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) die lokale Einstellung undefiniert, sodass der Abschnitt Formatierung beispielsweise vom Absatz erben kann. Das garantiert nicht, dass Durchstreichen entfernt wird. Verwenden Sie [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective), um die resultierende Formatierung, einschließlich vererbter Werte, auszulesen.

Das folgende eigenständige Beispiel erzeugt drei Preisvergleiche. Jeder Absatz enthält separate Abschnitte für Bezeichnung, früheren Preis und aktuellen Preis, sodass nur der frühere Preis betroffen ist. In der ersten Zeile wird Durchstreichen angewendet und anschließend entfernt; die anderen Zeilen behalten einfaches bzw. doppeltes Durchstreichen bei. Durch Ändern dieser Einstellung bleibt der Text und seine übrige Formatierung, einschließlich des fetten früheren Preises, erhalten.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Durchstreichen anwenden und dann explizit vom ersten vorherigen Preis entfernen.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis von oben nach unten: kein Durchstreichen, einfaches Durchstreichen und doppeltes Durchstreichen.

![Frühere Preise ohne Durchstreichen, mit einfachem Durchstreichen und mit doppeltem Durchstreichen](strikethrough.png)

## **Text‑Drehung festlegen**

Verwenden Sie [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType), um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Das folgende Code‑Beispiel setzt die Textausrichtung in der Form auf [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

![Die Text‑Drehung](text_rotation.png)

## **Benutzerdefinierte Drehung für Text‑Frames festlegen**

Verwenden Sie [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle), um einen benutzerdefinierten Drehwinkel für einen [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) festzulegen.

Das nachstehende Code‑Beispiel dreht den Text‑Frame um 3 Grad im Uhrzeigersinn innerhalb der Form:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![Die benutzerdefinierte Text‑Drehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) und [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) zur Steuerung des Absatzabstands. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkt anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelter Zeilenabstand):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

![Der Zeilenabstand innerhalb des Absatzes](line_spacing.png)

## **Zeilenumbruch steuern**

Regeln für den Absatz‑Zeilenumbruch sind bei schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen, nützlich. Die folgenden Methoden gehören zu [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) und gelten daher für einen gesamten Absatz:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) steuert die Zeilenumbruch‑Regeln für Lateinisch. Im gemischten Text kann eine Änderung auch beeinflussen, wo benachbarter ostasiatischer Text und Interpunktion umbrochen werden.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) steuert die Zeilenumbruch‑Regeln für Ostasiatisch, einschließlich Beschränkungen für Zeichen am Zeilenanfang bzw. -ende.

Diese Regeln ersetzen nicht [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), das automatischen Zeilenumbruch innerhalb eines Text‑Frames aktiviert. Sie beeinflussen das Layout, wenn ein Umbruch erfolgt; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzwingt eine neue Zeile innerhalb des Absatzes, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erzeugt einen schmalen Textblock, der chinesischen und lateinischen Text enthält. Es setzt beide Zeilenumbruch‑Optionen explizit und speichert „line_breaking.pptx“. Um eine der Regeln zu testen, ändern Sie den entsprechenden Wert, während die andere Einstellung unverändert bleibt. Das Beispiel verwendet 24‑Punkt Arial und SimSun bei einer Rahmenbreite von 160 Punkt und keinen horizontalen Text‑Frame‑Rändern. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) wird mit [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) aufgerufen, sodass Textgröße und Rahmenabmessungen fix bleiben.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hängende Interpunktion steuern**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) ermöglicht es zulässiger Interpunktion, über den rechten Rand der Textzeile hinauszuragen, anstatt die nächste Zeile zu belegen. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem Text‑Frame von 100 Punkt Breite und speichert „hanging_punctuation.pptx“. Mit 24‑Punkt Arial und keinen horizontalen Text‑Frame‑Rändern bleibt der abschließende Punkt nach „sentence“ und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), um zu vergleichen: Bei diesen Einstellungen belegt der Punkt eine separate Zeile. Zeilenumbruch ist aktiviert und Autofit deaktiviert, um die verfügbare Breite festzuhalten.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nicht jede Interpunktionsmarke kann hängen. Die im Abschnitt [Control Line Breaking](#control-line-breaking) beschriebenen Schrift‑ und Layout‑Bedingungen gelten ebenfalls für diesen Vergleich: Änderungen an Schriftart, verfügbarer Breite, Rändern oder Autofit‑Einstellungen können den sichtbaren Unterschied entfernen.

## **Autofit‑Typ für Text‑Frames festlegen**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Behälters überschreitet. Verwenden Sie ihn, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch resized. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst, und speichert das Ergebnis in „autofit_type.pptx“.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

Um nach automatischem Zeilenumbruch die Zeilen zu zählen und zu sehen, wie sich Text‑ bzw. Form‑Breite auf das Ergebnis auswirken, siehe [Count Rendered Lines](/slides/de/php-java/manage-paragraph/). Die reine Zeilenzahl sagt nicht aus, ob Text über den Container hinausläuft.

## **Anker von Text‑Frames festlegen**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis in „text_anchor.pptx“.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

## **Tabulatoren für Text festlegen**

Verwenden Sie [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) und [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs), um Tabstopps in einem Absatz zu konfigurieren. Das folgende Beispiel setzt den Standard‑Tab‑Intervall auf 100 Punkt und fügt einen linksbündigen Tab‑Stopp bei 30 Punkt hinzu. Diese Einstellungen wirken sich auf Text aus, der Tab‑Zeichen enthält.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

## **Korrektursprache festlegen**

Aspose.Slides bietet [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId), mit dem Sie die Korrektursprache für einen Textabschnitt festlegen können. Die Korrektursprache bestimmt die Sprache, die für Rechtschreib‑ und Grammatikprüfungen in PowerPoint verwendet wird.

Das folgende Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erste Form auf der ersten Folie und mindestens einen Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schrift und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird in „proofing_language.pptx“ gespeichert:

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

    // Setzt die ID einer Korrektursprache.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Sprach‑Metadaten kopieren**

Beim Kopieren mehrsprachigen Textes aus einer Vorlage sollten sowohl [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) als auch [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) erhalten bleiben. Das folgende eigenständige Beispiel erzeugt einen Quell‑Abschnitt mit US‑Englisch als Sprache und Französisch als alternativer Sprache und kopiert Text sowie Kennungen in einen Abschnitt einer neuen Präsentation.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Falls die Quelle keine alternative Sprache hat, setzt null den Zielwert zurück.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Um eine Quelle ohne alternative Sprache zu testen, lassen Sie die Zuweisung von `"fr-FR"` weg. Der alternative Kennzeichner ist dann `null`, und dieselbe Kopieranweisung bewahrt dessen Fehlen, ohne einen Standardwert einzufügen, selbst wenn das Ziel zuvor eine alternative Sprache zugewiesen hatte.

Diese Kennungen speichern Sprach‑Metadaten. Das Beibehalten beeinflusst nicht, welches Wörterbuch PowerPoint für Rechtschreib‑ oder Grammatikprüfungen auswählt.

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standard‑Textsprache, fügt ein Textfeld hinzu und gibt `en-US` für den ersten Textabschnitt aus.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Füge eine neue Rechteckform mit Text hinzu.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Überprüfe die Sprache des ersten Abschnitts.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Standard‑Textstil festlegen**

Um Standard‑Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Das folgende Beispiel setzt eine 14‑Punkt‑fette Schrift als Standard für Absatz‑Ebene‑1 in einer neuen Präsentation und speichert sie unter „default_text_style.pptx“. Text kann diese Vorgaben erben, solange keine spezifischere Formatierung sie überschreibt.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Holen Sie das Absatzformat der obersten Ebene.
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

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt der Font‑Effekt **All Caps**, dass Text im Folien‑Layout großgeschrieben erscheint, selbst wenn er ursprünglich in Kleinbuchstaben eingegeben wurde. Bei der Abfrage eines solchen Textabschnitts mit Aspose.Slides liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) und wandeln Sie die zurückgegebene Zeichenkette in Großbuchstaben um, wenn der Wert `All` lautet.

Dieses Beispiel benötigt „sample2.pptx“ mit einem Textfeld als erste Form auf der ersten Folie. Sein erster Absatz‑erste Abschnitt enthält „Hello, Aspose!“ mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der nachstehende Code‑Beispiel zeigt, wie der Text mit angewendetem **All Caps**‑Effekt extrahiert wird:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

**Wie kann ich Text in einer Tabelle auf einer Folie bearbeiten?**

Um Text in einer Tabelle auf einer Folie zu bearbeiten, verwenden Sie [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) sowie die Absatz‑Formatierung über [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Wie wende ich einen Farbverlauf auf Text in einer PowerPoint‑Folie an?**

Um einen Farbverlauf auf Text anzuwenden, nutzen Sie [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Setzen Sie [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) auf [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) und konfigurieren Sie die Gradienten‑Stops, Richtung und Transparenz.