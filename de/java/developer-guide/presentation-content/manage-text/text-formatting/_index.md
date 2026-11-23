---
title: Text in Präsentationen mit Java formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/java/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schriftarteigenschaften
- Schriftfamilie
- Textrotation
- Drehwinkel
- Textrahmen
- Zeilenabstand
- Autofit‑Eigenschaft
- Textrahmenverankerung
- Texttabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java. Passen Sie Schriftarten, Farben, Ausrichtung und mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Java formatiert wird. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabstopps und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Form‑Indizes beginnen bei null. Beispiele, die fette Textteile auswählen, verwenden effektive Formatierung, einschließlich vererbter Fettschrift:

![Beispieltext](sample_text.png)

Um literal Text oder reguläre Ausdruck‑Übereinstimmungen zu finden und hervorzuheben, siehe [Suchen und Ersetzen von Text](/slides/de/java/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) , um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) für einzelne Textanteile.

Das folgende Beispiel legt ein hellgraues Hervorhebungsfeld als Standard für den ersten Absatz fest. Explizite Hervorhebungsfarben bei einzelnen Anteilen haben Vorrang vor diesem Standard:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setze die Hervorhebungsfarbe für den gesamten Absatz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachfolgende Code‑Beispiel demonstriert, wie die Hintergrundfarbe für **Textanteile mit fetter Schrift** festgelegt wird:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setze die Hervorhebungsfarbe für den Textanteil.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die grauen Textanteile](gray_text_portions.png)

## **Absätze ausrichten**

Verwenden Sie [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) , um die Absatz‑Ausrichtung innerhalb eines Textrahmens festzulegen. Der Wert kann zentriert, linksbündig, rechtsbündig, block‑justiert usw. sein.

Das folgende Code‑Beispiel zeigt, wie der Absatz **mittig** ausgerichtet wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setze die Ausrichtung des Absatzes auf Mitte.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriftarten innerhalb einer Zeile ausrichten**

Verwenden Sie [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) , um Textanteile unterschiedlicher Schriftgrößen innerhalb einer Zeile vertikal auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung innerhalb jeder Zeile.

Das folgende, eigenständige Beispiel erstellt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 Punkten mit unterschiedlicher Schrift‑Ausrichtung. Es verwendet Arial, deaktiviert Autofit und Zeilenumbruch und hält die Textrahmen groß genug für eine einzelne Zeile.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Vergleich von Grundlinie, Oberkante, Mitte und Unterkante bei gemischten Schriftgrößen](font_alignment.png)

Die Schrift‑Ausrichtung verwendet Schriftmetriken, sodass die sichtbaren Kanten einzelner Buchstaben nicht exakt übereinstimmen müssen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen Abstieg, um den Unterschied zwischen Grundlinie und Unterkante zu verdeutlichen. Schriftverfügbarkeit und -ersatz, die verwendeten Zeichen und die Unterschiedlichkeit der Schriftgrößen beeinflussen das Ergebnis. Rahmen‑Abmessungen, Ränder, Zeilenabstand, Zeilenumbruch und Autofit wirken sich ebenfalls auf das Layout aus; verwenden Sie dieselben Schriften und Layout‑Einstellungen beim Vergleich der Modi.

Diese Einstellung unterscheidet sich von [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), das die horizontale Absatz‑Ausrichtung steuert, und von [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), das den Textblock vertikal innerhalb seiner Form positioniert. Hoch‑ und Tiefstellung über [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) verschieben einzelne Anteile relativ zur Grundlinie, anstatt die Schrift‑Ausrichtung für die Zeilen des Absatzes zu setzen.

## **Transparenz für Text festlegen**

Die Text‑Transparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) zugewiesen wird. In den nachfolgenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0‑255 und kein Transparenz‑Prozentsatz.

Das folgende Code‑Beispiel zeigt, wie Transparenz für den **gesamten Absatz** angewendet wird:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setze die Füllfarbe des Textes auf eine transparente Farbe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Code‑Beispiel zeigt, wie Transparenz für **Textanteile mit fetter Schrift** angewendet wird:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setze die Transparenz des Textanteils.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die transparenten Textanteile](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) , um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern. Die Beispiele fügen 3 Punkte Abstand hinzu; negative Werte verkleinern den Text.

Der folgende Java‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu verkleinern.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zeichenabstand vergrößern.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das nachfolgende Code‑Beispiel zeigt, wie der Zeichenabstand in **Textanteilen mit fetter Schrift** erweitert wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu verkleinern.
            portion.getPortionFormat().setSpacing(3); // Zeichenabstand vergrößern.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand in den Textanteilen](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In einigen Fällen kann der von Aspose.Slides gerenderte Text etwas enger wirken als derselbe Text in PowerPoint. Das kann vorkommen, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die Ausgabe in solchen Fällen PowerPoint‑näher zu machen, können Sie das Kerning für Textanteile deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erster Form auf der ersten Folie. Es prüft effektive Schriftnamen, einschließlich vererbter Schriften, und legt einen Schwellenwert von 100 Punkten für Anteile fest, die Roboto verwenden. Damit wird Kerning für passende Anteile mit einer Schriftgröße unter 100 Punkten deaktiviert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für passende Texte unterhalb des Schwellenwerts verhindert diese Einstellung Kerning und kann helfen, das Rendering von Aspose.Slides an die visuelle Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften anzupassen.

## **Schriftarteigenschaften verwalten**

Schriftarteigenschaften können auf Absatz‑Ebene über [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) oder für einzelne Anteile über [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) festgelegt werden.

Das folgende Beispiel setzt die Standardschrift des ersten Absatzes auf 12‑Punkt Times New Roman mit fett, kursiv und gepunkteter Unterstreichung. Explizite Formatierung einzelner Anteile hat Vorrang vor diesen Vorgaben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setze die Schriftarteigenschaften für den Absatz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Schriftarteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet 13‑Punkt Times New Roman, kursive Formatierung und gepunktete Unterstreichung auf Anteile an, deren effektive Formatierung fett ist:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setze die Schriftarteigenschaften für den Textanteil.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Schriftarteigenschaften für Textanteile](font_properties_for_text_portions.png)

## **Text‑Höhen‑Normalisierung steuern**

Verwenden Sie [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-), wenn Sie Vorlagen‑Typografie reproduzieren oder Unterschiede in der Zeichenhöhe untersuchen. In PowerPoint streckt das Aktivieren der Normalisierung einzelne Zeichen vertikal, um ihnen innerhalb des Textanteils eine einheitliche sichtbare Höhe zu geben. Es garantiert keine gleichen Text‑Höhen über verschiedene Schriften hinweg.

Setzen Sie die Eigenschaft auf [NullableBool.True oder False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/), um die Normalisierung explizit zu aktivieren bzw. zu deaktivieren. `NullableBool.NotDefined` lässt die lokale Einstellung ungesetzt, sodass der Anteil den Wert etwa vom Absatz‑[getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) erbt. Das bedeutet nicht `False`. Verwenden Sie [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) und lesen Sie [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) , um den aufgelösten Booleschen Wert zu erhalten.

Das nachfolgende, eigenständige Beispiel erfordert **Arial**. Es erstellt zwei Textblöcke mit denselben Groß‑, Klein‑, Abstieg‑ und Sonderzeichen bei 54 Punkten. Beide Absätze aktivieren die Normalisierung standardmäßig. Der obere Anteil deaktiviert sie explizit; der untere erbt die Einstellung. Rahmen‑Größen, Ränder und Absatz‑Abstand sind identisch, Zeilenumbruch und Autofit sind deaktiviert, um den Vergleich konsistent zu halten. Das Beispiel gibt `False: false` und `NotDefined: true` aus und speichert „text_height_normalization.pptx“.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der unten dargestellte Vergleich stammt aus der gespeicherten Präsentation. Die obere Zeile hat Normalisierung deaktiviert (`False`); die untere Zeile erbt die aktivierte Einstellung (`NotDefined` → `True`). Für die Reproduktion muss Arial installiert sein.

![Arial‑Text mit 54 Punkt, oben ohne Normalisierung und unten mit geerbter Normalisierung](text_height_normalization.png)

Normalisierung ändert die Zeichenhöhe, ohne den zugewiesenen [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--)‑Wert zu verändern, der die Schriftgröße in Punkten angibt. Absatz‑[setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) steuert den Zeilenabstand, während Text‑Frame‑[setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) festlegt, wie Text oder sein Container an die Größe angepasst werden. Diese Einstellungen dienen unterschiedlichen Zwecken und können das Gesamtlayout unabhängig beeinflussen. Weitere Informationen zu Absatz‑Formatierung und Vererbung finden Sie unter [Absatz verwalten](/slides/de/java/manage-paragraph/).

## **Durchgestrichenen Text anwenden und entfernen**

Verwenden Sie [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) auf einen Textanteil, um Korrekturen, stornierte Begriffe oder frühere Preise anzuzeigen, ohne den Ursprungstext zu löschen. Setzen Sie ihn auf [TextStrikethroughType.Single oder Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) für eine bzw. zwei Durchstreich‑Linien.

Um Durchstreichung zu entfernen, übergeben Sie [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None). Dies deaktiviert den Effekt explizit, selbst wenn das umgebende Format Durchstreichung angibt. Im Gegensatz dazu lässt [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) die lokale Einstellung undefiniert, sodass der Anteil Formatierungen wie vom Absatz erben kann. Es garantiert jedoch nicht, dass Durchstreichung entfernt wird. Verwenden Sie [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) , um das resultierende Format, einschließlich vererbter Werte, zu lesen.

Das folgende eigenständige Beispiel erstellt drei Preisvergleiche. Jeder Absatz hat separate Anteile für Bezeichnung, vorherigen Preis und aktuellen Preis, sodass nur der vorherige Preis betroffen ist. Die erste Zeile wendet Durchstreichung an und entfernt sie dann wieder; die anderen Zeilen behalten einzelne bzw. doppelte Durchstreichung bei. Durch Ändern dieser Einstellung bleibt der Text erhalten und behält seine übrigen Formatierungen, einschließlich des fetten vorherigen Preises.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Durchstreichen anwenden und anschließend explizit das erste vorherige Preis-Element entfernen.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis von oben nach unten: keine Durchstreichung, einfache Durchstreichung und doppelte Durchstreichung.

![Vorherige Preise ohne Durchstreichung, mit einfacher Durchstreichung und mit doppelter Durchstreichung](strikethrough.png)

## **Text‑Drehung festlegen**

Verwenden Sie [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) , um eine vordefinierte Text‑Ausrichtung innerhalb einer Form festzulegen.

Das folgende Code‑Beispiel setzt die Text‑Ausrichtung der Form auf [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Text‑Drehung](text_rotation.png)

## **Ziffern nebeneinander in vertikalem Text anzeigen**

Um eine zweistellige Zahl in einem vertikalen japanischen Beschriftungsfeld zusammenzuhalten, setzen Sie beide Ziffern in einen Textanteil und rufen Sie [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) für diesen Anteil auf. Das Beispiel verwendet [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) und 40‑Punkt MS Gothic für beide Beschriftungen. Nur der an den numerischen Anteil übergebene [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/)‑Wert unterscheidet sich.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In PowerPoint zeigt die linke Beschriftung (`True`) die Ziffern aufrecht und nebeneinander zwischen 和 und 年. In der rechten Beschriftung (`False`) ist das Paar um 90 Grad im Uhrzeigersinn gedreht. Die umgebenden japanischen Zeichen bleiben in beiden Beschriftungen aufrecht.

![PowerPoint‑Vergleich vertikaler Datums‑Beschriftungen mit aufrechten Ziffern links und gedrehten Ziffern rechts.](vertical_date.png)

## **Benutzerdefinierte Drehung für Textrahmen festlegen**

Verwenden Sie [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) , um einen benutzerdefinierten Drehwinkel für ein [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) festzulegen.

Das folgende Code‑Beispiel dreht den Textrahmen um 3 Grad im Uhrzeigersinn innerhalb der Form:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die benutzerdefinierte Text‑Drehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) und [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) zur Steuerung des Absatz‑Abstands. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelter Abstand):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeilenabstand innerhalb des Absatzes](line_spacing.png)

## **Zeilenumbruch steuern**

Absatz‑Zeilenumbruch‑Regeln sind bei schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen, nützlich. Die folgenden Methoden gehören zu [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/), sodass sie auf einen gesamten Absatz angewendet werden:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) steuert lateinische Zeilenumbruch‑Regeln. In gemischtem Text kann eine Änderung auch das Umbrechen benachbarter ostasiatischer Zeichen und Satzzeichen beeinflussen.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) steuert ostasiatische Zeilenumbruch‑Regeln, einschließlich Beschränkungen für Zeichen am Anfang bzw. Ende einer Zeile.

Diese Regeln ersetzen nicht [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), das automatisches Umbrechen innerhalb eines Textrahmens aktiviert. Sie beeinflussen das Layout, wenn ein Umbrechen erfolgt; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch zwingt innerhalb des Absatzes zu einer neuen Zeile, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erstellt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Optionen explizit und speichert „line_breaking.pptx“. Um eine Regel zu testen, ändern Sie den entsprechenden Wert, während Sie die andere Einstellung unverändert lassen. Das Beispiel verwendet 24‑Punkt Arial und SimSun bei 160 Punkt Rahmenbreite und null horizontalen Text‑Rahmen‑Rändern. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) wird mit [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) aufgerufen, sodass Textgröße und Rahmenabmessungen fest bleiben.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hängende Interpunktion steuern**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) ermöglicht es zulässigen Interpunktionszeichen, über den rechten Rand der Textzeile hinauszuragen, anstatt die nächste Zeile zu besetzen. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100‑Punkt‑breiten Textrahmen und speichert „hanging_punctuation.pptx“. Mit 24‑Punkt Arial und null horizontalen Text‑Rahmen‑Rändern bleibt der abschließende Punkt nach „Satz“ und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/), um zu vergleichen: Mit diesen Einstellungen belegt der Punkt eine eigene Zeile. Zeilenumbruch ist aktiviert und Autofit deaktiviert, um die verfügbare Breite festzuhalten.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nicht jedes Satzzeichen kann hängen. Die oben beschriebenen [Schrift‑ und Layout‑Bedingungen](#control-line-breaking) gelten ebenfalls für diesen Vergleich: Ändern von Schrift, verfügbarer Breite, Rändern oder Autofit‑Einstellungen können den sichtbaren Unterschied entfernen.

## **Autofit‑Typ für Textrahmen festlegen**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie ihn, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst, und speichert das Ergebnis unter „autofit_type.pptx“.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um Zeilen nach automatischem Umbrechen zu zählen und zu sehen, wie sich Text‑ oder Form‑Breite auf das Ergebnis auswirkt, siehe [Anzahl gerenderter Zeilen](/slides/de/java/manage-paragraph/). Die Zeilenzahl allein sagt nicht aus, ob Text über den Container hinausläuft.

## **Verankerung von Textrahmen festlegen**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, Mitte oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis unter „text_anchor.pptx“.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabulatoren für Text festlegen**

Verwenden Sie [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) und [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) , um Tabstopps in einem Absatz zu konfigurieren. Das folgende Beispiel setzt das Standard‑Tab‑Intervall auf 100 Punkte und fügt bei 30 Punkten einen linksbündigen Tabstopps hinzu. Diese Einstellungen wirken sich auf Text mit Tab‑Zeichen aus.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die Absatz‑Tabstopps](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides bietet [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), mit dem Sie die Korrektursprache für einen Textanteil festlegen können. Die Korrektursprache bestimmt die Sprache, die in PowerPoint für Rechtschreib‑ und Grammatik‑Prüfungen verwendet wird.

Das folgende Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erster Form auf der ersten Folie und mindestens einem Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schrift und weist die vereinfachte Chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird unter „proofing_language.pptx“ gespeichert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Setze die Id einer Korrektursprache.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sprach‑Metadaten kopieren**

Beim Kopieren mehrsprachigen Textes aus einer Vorlage sollten sowohl [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) als auch [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) erhalten bleiben. Das folgende eigenständige Beispiel erstellt einen Quell‑Anteils mit US‑Englisch als Sprache und Französisch als alternativer Sprache und kopiert Text und Kennungen zu einem Anteil in einer neuen Präsentation.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Wenn die Quelle keine alternative Sprache hat, löscht null den Zielwert.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um eine Quelle ohne alternative Sprache zu testen, lassen Sie die Zuweisung von `"fr-FR"` weg. Der alternative Kennzeichner ist dann `null`, und dieselbe Kopier‑Anweisung erhält dessen Fehlen, ohne einen Standardwert einzufügen, selbst wenn das Ziel zuvor eine alternative Sprache zugewiesen hatte.

Diese Kennungen speichern Sprach‑Metadaten. Das Beibehalten verändert nicht, welches Wörterbuch PowerPoint für Rechtschreibung oder Grammatik verwendet.

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) , um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation generiert wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standard‑Textsprache, fügt ein Textfeld hinzu und gibt `en-US` für dessen ersten Textanteil aus.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Füge eine neue Rechteckform mit Text hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Überprüfe die Sprache des ersten Textanteils.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standard‑Textstil festlegen**

Um standardmäßige Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Das folgende Beispiel setzt eine 14‑Punkt‑fette Schrift als Standard für Absätze der obersten Ebene in einer neuen Präsentation und speichert sie unter „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern keine spezifischere Formatierung sie überschreibt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Hole das Absatzformat der obersten Ebene.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt das Anwenden des **All Caps**‑Schrifteffekts, dass Text in Großbuchstaben auf der Folie erscheint, obwohl er ursprünglich in Kleinbuchstaben eingegeben wurde. Beim Abrufen eines solchen Textanteils mit Aspose.Slides gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) und konvertieren Sie die zurückgegebene Zeichenkette in Großbuchstaben, wenn der Wert `All` ist.

Dieses Beispiel benötigt „sample2.pptx“ mit einem Textfeld als erster Form auf der ersten Folie. Der erste Absatz‑erste Teil enthält „Hello, Aspose!“ mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das nachfolgende Code‑Beispiel zeigt, wie der Text mit angewendetem **All Caps**‑Effekt extrahiert wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) und die Absatz‑Formatierung über [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Wie kann ich einem Text auf einer PowerPoint‑Folien‑Folien‑Folie einen Farbverlauf zuweisen?**

Um einem Text einen Farbverlauf zuzuweisen, verwenden Sie [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Setzen Sie [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) auf [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) und konfigurieren Sie die Verlaufs‑Stopps, die Richtung und die Transparenz.

Verwandte Funktion: [Text in Folien formatieren](/slides/de/features/text-formatting/).