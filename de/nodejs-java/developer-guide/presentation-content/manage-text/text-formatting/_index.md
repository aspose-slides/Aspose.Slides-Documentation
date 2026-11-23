---
title: Präsentationstext in JavaScript formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/nodejs-java/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textdrehung
- Drehwinkel
- Textrahmen
- Zeilenabstand
- Autofit-Eigenschaft
- Textrahmen-Anker
- Texttabulatoren
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js über Java. Passen Sie Schriftarten, Farben, Ausrichtungen und mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Node.js via Java formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schrifteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabulatoren und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Das erste Shape auf der ersten Folie ist ein Textfeld, und sein erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Shape‑Indizes beginnen bei 0. Beispiele, die fette Teile auswählen, nutzen effektive Formatierung, einschließlich geerbter Fettschrift:

![Beispieltext](sample_text.png)

Zum Finden und Hervorheben von literalem Text oder regulären Ausdrucks‑Übereinstimmungen siehe [Suchen und Ersetzen von Text](/slides/de/nodejs-java/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), um die Standard‑Highlight‑Farbe für einen Absatz festzulegen, oder [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) für einzelne Textportionen.

Das folgende Beispiel setzt ein hellgraues Highlight als Standard für den ersten Absatz. Explizite Highlight‑Farben für einzelne Portionen haben Vorrang vor diesem Standard:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setzen Sie die Hervorhebungsfarbe für den gesamten Absatz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachstehende Code‑Beispiel demonstriert, wie man die Hintergrundfarbe für **Textportionen mit fetter Schrift** festlegt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setzen Sie die Hervorhebungsfarbe für die Textportion.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die grauen Textportionen](gray_text_portions.png)

## **Absätze ausrichten**

Verwenden Sie [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), um die Absatz‑Ausrichtung innerhalb eines Textfeldes festzulegen. Der Wert kann z. B. zentriert, linksbündig, rechtsbündig, block­gerecht usw. sein.

Das folgende Code‑Beispiel zeigt, wie man den Absatz **zentriert** ausrichtet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setzen Sie die Ausrichtung des Absatzes auf Mitte.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriftarten innerhalb einer Zeile ausrichten**

Verwenden Sie [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment), um Textportionen unterschiedlicher Schriftgrößen innerhalb einer Zeile vertikal auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung innerhalb jeder Zeile.

Das folgende eigenständige Beispiel erzeugt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 Pt, jeweils mit unterschiedlicher Schrift‑Ausrichtung. Es verwendet Arial, deaktiviert Autofit und Zeilenumbruch und hält die Textfelder groß genug für eine einzelne Zeile.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Vergleich von Grundlinie, Oberseite, Mitte und Unterseite bei gemischten Schriftgrößen](font_alignment.png)

Die Schrift‑Ausrichtung nutzt Schrift‑Metriken, sodass die sichtbaren Kanten einzelner Zeichen nicht unbedingt exakt übereinstimmen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen Abstieg, um den Unterschied zwischen Grundlinie und Unterkante zu verdeutlichen. Schrift‑Verfügbarkeit und -Substitution, die verwendeten Zeichen und die unterschiedlichen Schriftgrößen beeinflussen das Ergebnis. Rahmen‑Abmessungen, Ränder, Zeilenabstand, Zeilenumbruch und Autofit wirken sich ebenfalls auf das Layout aus; verwenden Sie dieselben Schriften und Layout‑Einstellungen beim Vergleich der Modi.

Diese Einstellung unterscheidet sich von [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), die die horizontale Absatz‑Ausrichtung steuert, sowie von [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), die den Textblock vertikal innerhalb seines Shapes positioniert. Hoch‑ und Tiefstellung über [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) verschiebt einzelne Portionen relativ zur Grundlinie, anstatt die Schrift‑Ausrichtung für die Zeilen des Absatzes zu setzen.

## **Transparenz für Text festlegen**

Die Text‑Transparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) zugewiesen wird. In den nachstehenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0–255 und kein Transparenz‑Prozentsatz.

Das folgende Code‑Beispiel zeigt, wie man Transparenz auf den **gesamten Absatz** anwendet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Setzen Sie die Füllfarbe des Textes auf eine transparente Farbe.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Der folgende Code demonstriert, wie man Transparenz auf **Textportionen mit fetter Schrift** anwendet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Setzen Sie die Transparenz der Textportion.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die transparenten Textportionen](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern. Die Beispiele fügen 3 Pt Abstand hinzu; negative Werte verkleinern den Text.

Der folgende JavaScript‑Code zeigt, wie man den Zeichenabstand im **gesamten Absatz** erweitert:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zeichenabstand vergrößern.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das folgende Beispiel zeigt, wie man den Zeichenabstand in **Textportionen mit fetter Schrift** erweitert:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
            portion.getPortionFormat().setSpacing(3); // Zeichenabstand vergrößern.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand in den Textportionen](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In manchen Fällen kann Text, der von Aspose.Slides gerendert wird, leicht enger erscheinen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um das gerenderte Ergebnis in solchen Fällen PowerPoint‑näher zu bringen, können Sie Kerning für Textportionen deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erstem Shape auf der ersten Folie. Es prüft effektive Schrift­namen, einschließlich geerbter Schriften, und legt eine Schwelle von 100 Pt für Portionen fest, die Roboto verwenden. Damit wird Kerning für passende Portionen mit einer Schriftgröße unter 100 Pt deaktiviert:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für übereinstimmenden Text unterhalb der Schwelle verhindert diese Einstellung Kerning und kann helfen, das Rendering von Aspose.Slides an die visuelle Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften anzupassen.

## **Schrifteigenschaften von Text verwalten**

Schrifteigenschaften können über [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) auf Absatz‑Ebene oder über [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) für einzelne Portionen festgelegt werden.

Das folgende Beispiel setzt die Standardschrift des ersten Absatzes auf Times New Roman 12 Pt mit fett, kursiv und gepunkteter Unterstreichung. Explizite Formatierung einzelner Portionen hat Vorrang vor diesen Vorgaben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Setzen Sie die Schrifteigenschaften für den Absatz.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Schrifteigenschaften des Absatzes](font_properties_for_paragraph.png)

Das nachstehende Beispiel wendet Times New Roman 13 Pt, kursive Formatierung und gepunktete Unterstreichung auf Portionen an, deren effektive Formatierung fett ist:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Setzen Sie die Schrifteigenschaften für die Textportion.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Schrifteigenschaften der Textportionen](font_properties_for_text_portions.png)

## **Text‑Höhen‑Normalisierung steuern**

Verwenden Sie [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight), wenn Sie Vorlagen‑Typografie reproduzieren oder Unterschiede in der Zeichenhöhe untersuchen. In PowerPoint dehnt das Aktivieren der Normalisierung einzelne Zeichen vertikal, um ihnen innerhalb der Textportion eine einheitliche sichtbare Höhe zu geben. Es garantiert keine gleichen Text‑Höhen über verschiedene Schriften hinweg.

Setzen Sie die Eigenschaft auf [NullableBool.True oder False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/), um Normalisierung explizit zu aktivieren bzw. zu deaktivieren. `NullableBool.NotDefined` lässt die lokale Einstellung ungesetzt, sodass die Portion den Wert z. B. vom Absatz‑[getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) erbt. Das bedeutet nicht `False`. Verwenden Sie [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) und lesen Sie [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) aus, um den aufgelösten booleschen Wert zu erhalten.

Das folgende eigenständige Beispiel erfordert die Installation von **Arial**. Es erzeugt zwei Textblöcke mit denselben Groß‑, Klein‑ und Abstieg‑Zeichen sowie akzentuierten Zeichen in 54 Pt. Beide Absätze aktivieren die Normalisierung standardmäßig. Der obere Teil deaktiviert sie explizit; der untere erbt den aktivierten Zustand. Rahmen‑Größe, Ränder und Absatz‑Abstand sind identisch, Zeilenumbruch und Autofit sind deaktiviert, um den Vergleich konsistent zu halten. Das Beispiel gibt `False: false` und `NotDefined: true` aus und speichert „text_height_normalization.pptx“.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der nachstehende Vergleich stammt aus der gespeicherten Präsentation. Die obere Zeile hat Normalisierung deaktiviert (`False`); die untere Zeile erbt die aktivierte Einstellung (`NotDefined` → `True`). Arial muss installiert sein, um das Aussehen zu reproduzieren.

![Arial‑Text 54 Pt mit deaktivierter Normalisierung oben und geerbter Normalisierung unten](text_height_normalization.png)

Normalisierung ändert die Zeichenhöhe, ohne den zugewiesenen [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight)-Wert zu ändern, der die Schriftgröße in Punkten angibt. Absatz‑[setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) steuert den Zeilenabstand, während Text‑Frame‑[setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) regelt, wie Text oder dessen Container angepasst werden. Diese Einstellungen dienen unterschiedlichen Zwecken und können das Gesamtlayout unabhängig beeinflussen. Weitere Informationen zu Absatz‑Formatierung und Vererbung finden Sie unter [Absatz verwalten](/slides/de/nodejs-java/manage-paragraph/).

## **Durchgestrichenen Text anwenden und entfernen**

Verwenden Sie [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) auf einer Textportion, um Korrekturen, gestrichene Begriffe oder frühere Preise anzuzeigen, ohne den Originaltext zu löschen. Setzen Sie es auf [TextStrikethroughType.Single oder Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) für eine bzw. zwei Linien durch den Text.

Um Durchstreichen zu entfernen, übergeben Sie [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). Damit wird der Effekt explizit deaktiviert, selbst wenn das umgebende Format Durchstreichen angibt. Im Gegensatz dazu lässt [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) die lokale Einstellung undefiniert, sodass die Portion das Format erben kann, z. B. vom Absatz. Das garantiert nicht, dass Durchstreichen entfernt wird. Verwenden Sie [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), um die resultierende Formatierung einschließlich geerbter Werte zu lesen.

Das folgende eigenständige Beispiel erstellt drei Preisvergleiche. Jeder Absatz hat separate Portionen für Bezeichnung, alten Preis und aktuellen Preis, sodass nur der alte Preis betroffen ist. Die erste Zeile wendet Durchstreichen an und entfernt es dann wieder; die anderen Zeilen behalten einfaches bzw. doppeltes Durchstreichen bei. Das Ändern dieser Einstellung bewahrt den Text und seine übrige Formatierung, einschließlich des fetten alten Preises.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Durchstreichen anwenden, dann explizit vom ersten vorherigen Preis entfernen.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis von oben nach unten: kein Durchstreichen, einfaches Durchstreichen und doppeltes Durchstreichen.

![Frühere Preise ohne Durchstreichen, mit einfachem Durchstreichen und mit doppeltem Durchstreichen](strikethrough.png)

## **Text‑Drehung festlegen**

Verwenden Sie [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType), um eine vordefinierte Text‑Ausrichtung innerhalb eines Shapes festzulegen.

Das folgende Code‑Beispiel setzt die Text‑Ausrichtung im Shape auf [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** rotiert wird:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Text‑Drehung](text_rotation.png)

## **Ziffern nebeneinander in vertikalem Text anzeigen**

Um eine zweistellige Zahl in einem vertikalen japanischen Etikett zusammenzuhalten, legen Sie beide Ziffern in einer Textportion ab und rufen Sie [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) für die Formatierung dieser Portion auf. Das Beispiel verwendet [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) und 40‑Pt MS Gothic für beide Etiketten. Nur der an den numerischen Portion übergebene [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/)-Wert unterscheidet sich.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In PowerPoint zeigt das linke Etikett (`True`) die Ziffern aufrecht und nebeneinander zwischen 和 und 年. Das rechte Etikett (`False`) rotiert das Paar um 90 Grad im Uhrzeigersinn. Die umgebenden japanischen Zeichen bleiben in beiden Etiketten aufrecht.

![PowerPoint‑Vergleich vertikaler Datums‑Etiketten mit aufrechten Ziffern links und rotierten Ziffern rechts.](vertical_date.png)

## **Benutzerdefinierte Drehung für Text‑Frames festlegen**

Verwenden Sie [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle), um einen benutzerdefinierten Drehwinkel für ein [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) festzulegen.

Das nachstehende Code‑Beispiel rotiert den Text‑Frame um 3 Grad im Uhrzeigersinn innerhalb des Shapes:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die benutzerdefinierte Text‑Drehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) und [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) zur Steuerung des Absatzabstands. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelter Abstand):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeilenabstand innerhalb des Absatzes](line_spacing.png)

## **Zeilenumbruch steuern**

Absatz‑Zeilenumbruch‑Regeln sind nützlich in schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen. Die folgenden Methoden gehören zu [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), sodass sie für einen gesamten Absatz gelten:

* [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) steuert lateinische Zeilenumbruch‑Regeln. In gemischtem Text kann eine Änderung auch das Umbrechen benachbarter ostasiatischer Texte und Satzzeichen beeinflussen.
* [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) steuert ostasiatische Zeilenumbruch‑Regeln, einschließlich Beschränkungen für Zeichen am Anfang bzw. Ende einer Zeile.

Diese Regeln ersetzen nicht [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), das automatisches Umbrechen innerhalb eines Text‑Frames aktiviert. Sie beeinflussen das Layout, wenn Umbrechen erfolgt; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch zwingt eine neue Zeile im Absatz, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erzeugt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Optionen explizit und speichert „line_breaking.pptx“. Zum Experimentieren mit einer der beiden Regeln ändern Sie den entsprechenden Wert, während die andere Einstellung unverändert bleibt. Das Beispiel verwendet Arial 24 Pt und SimSun bei einer Rahmenbreite von 160 Pt und horizontalen Text‑Frame‑Rändern von 0. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) wird mit [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) aufgerufen, sodass Textgröße und Rahmen‑Abmessungen fix bleiben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hängende Interpunktion steuern**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) erlaubt es zulässigen Satzzeichen, über den rechten Rand der Textzeile hinaus zu reichen, anstatt die nächste Zeile zu belegen. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100‑Pt‑breiten Text‑Frame und speichert „hanging_punctuation.pptx“. Mit Arial 24 Pt und horizontalen Text‑Frame‑Rändern von 0 bleibt der abschließende Punkt nach „Satz“ und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/), um zu vergleichen: Mit diesen Einstellungen belegt der Punkt eine eigene Zeile. Zeilenumbruch ist aktiviert und Autofit deaktiviert, um die verfügbare Breite fix zu halten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nicht jedes Satzzeichen kann hängen. Die oben beschriebenen [Schrift‑ und Layout‑Bedingungen](#control-line-breaking) gelten ebenfalls für diesen Vergleich: Eine Änderung der Schrift, der verfügbaren Breite, der Ränder oder der Autofit‑Einstellungen kann den sichtbaren Unterschied entfernen.

## **Autofit‑Typ für Text‑Frames festlegen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob Text schrumpft, überläuft oder das Shape automatisch anpasst. Das folgende Beispiel konfiguriert das Shape so, dass es sich der Textgröße anpasst, und speichert das Ergebnis unter „autofit_type.pptx“.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um Zeilen nach automatischem Umbrechen zu zählen und zu sehen, wie Text‑ oder Shape‑Breite das Ergebnis verändert, siehe [Count Rendered Lines](/slides/de/nodejs-java/manage-paragraph/). Die Zeilenzahl allein sagt nicht aus, ob Text seinen Container überläuft.

## **Verankerung von Text‑Frames festlegen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) definiert, wie Text vertikal innerhalb eines Shapes positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand des ersten Shapes und speichert das Ergebnis unter „text_anchor.pptx“.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabulatoren für Text festlegen**

Verwenden Sie [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) und [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs), um Tabulatoren in einem Absatz zu konfigurieren. Das folgende Beispiel setzt das Standard‑Tab‑Intervall auf 100 Pt und fügt einen linksbündigen Tab‑Stopp bei 30 Pt hinzu. Diese Einstellungen beeinflussen Text, der Tab‑Zeichen enthält.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Absatz‑Tabulatoren](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides bietet [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), mit dem Sie die Korrektursprache für eine Textportion festlegen können. Die Korrektursprache bestimmt die für Rechtschreib‑ und Grammatikprüfungen in PowerPoint zu nutzende Sprache.

Das folgende Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erstem Shape auf der ersten Folie und mindestens einem Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schrift und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird unter „proofing_language.pptx“ gespeichert:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Setzen Sie die Id einer Korrektursprache.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sprach‑Metadaten kopieren**

Beim Kopieren mehrsprachigen Textes aus einer Vorlage sollten sowohl [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) als auch [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) erhalten bleiben. Das folgende eigenständige Beispiel erstellt eine Quell‑Portion mit US‑Englisch als Sprache und Französisch als alternativer Sprache und kopiert Text und Kennungen in eine Portion einer neuen Präsentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Wenn die Quelle keine alternative Sprache hat, setzt null den Zielwert zurück.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um eine Quelle ohne alternative Sprache zu testen, lassen Sie die Zuweisung von `"fr-FR"` weg. Der alternative Kennzeichner ist dann `null`, und dieselbe Kopier‑Anweisung bewahrt dessen Fehlen, ohne einen Standardwert einzufügen, selbst wenn das Ziel zuvor eine alternative Sprache zugewiesen hatte.

Diese Kennzeichen speichern Sprach‑Metadaten. Das Bewahren bewirkt nicht, welches Wörterbuch PowerPoint für Rechtschreibung oder Grammatik verwendet.

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage), um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standard‑Textsprache, fügt ein Textfeld hinzu und gibt `en-US` für seine erste Textportion aus.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Fügen Sie ein neues Rechteck-Shape mit Text hinzu.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Überprüfen Sie die Sprache der ersten Portion.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standard‑Textstil festlegen**

Um Standard‑Textformatierung auf Präsentations‑Ebene anzuwenden, verwenden Sie [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

Das folgende Beispiel setzt eine 14‑Pt‑fette Schrift als Standard für Absatz‑Ebene 1 in einer neuen Präsentation und speichert sie unter „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern nicht spezifischere Formatierungen sie überschreiben.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Holen Sie das Absatzformat der obersten Ebene.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint lässt das Anwenden des **All Caps**‑Schrifteffekts Text in Großbuchstaben auf der Folie erscheinen, obwohl er ursprünglich in Kleinbuchstaben eingegeben wurde. Beim Abrufen einer solchen Textportion mit Aspose.Slides liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) und wandeln Sie die zurückgegebene Zeichenkette in Großbuchstaben um, wenn der Wert `All` ist.

Dieses Beispiel benötigt „sample2.pptx“ mit einem Textfeld als erstem Shape auf der ersten Folie. Der erste Absatz‑erste Portion enthält „Hello, Aspose!“ mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das nachstehende Code‑Beispiel zeigt, wie man den Text mit angewendetem **All Caps**‑Effekt extrahiert:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Ausgabe:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Wie kann ich Text in einer Tabelle auf einer Folie ändern?**

Verwenden Sie dazu [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Durchlaufen Sie die Zellen und aktualisieren Sie jede über [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) sowie die Absatz‑Formatierung über [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Wie wende ich einen Farbverlauf auf Text in einer PowerPoint‑Folie an?**

Verwenden Sie [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Setzen Sie [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) auf [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) und konfigurieren Sie die Verlauf‑Stopps, Richtung und Transparenz.