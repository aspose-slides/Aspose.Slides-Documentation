---
title: Präsentationstext auf Android formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/androidjava/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Texthintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textrahmen
- Zeilenabstand
- Autofit-Eigenschaft
- Textrahmen-Anker
- Texttabulator
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android über Java. Passen Sie Schriftarten, Farben, Ausrichtungen und mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint‑ und OpenDocument‑Präsentationen mithilfe von Aspose.Slides für Android über Java formatiert wird. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schrifteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabstopps und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Form‑Indizes beginnen bei Null. Beispiele, die fette Textabschnitte auswählen, verwenden effektive Formatierung, einschließlich geerbter Fettschrift:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder reguläre Ausdrücke zu finden und hervorzuheben, siehe [Suchen und Ersetzen von Text](/slides/de/androidjava/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) , um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder verwenden Sie [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) für einzelne Textabschnitte.

Das folgende Beispiel legt eine hellgraue Hervorhebung als Standard für den ersten Absatz fest. Explizite Hervorhebungsfarben in einzelnen Abschnitten haben Vorrang vor diesem Standard:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setzen Sie die Hervorhebungsfarbe für den gesamten Absatz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das folgende Codebeispiel zeigt, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** festgelegt wird:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setzen Sie die Hervorhebungsfarbe für den Textabschnitt.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) , um die Absatzausrichtung innerhalb eines Textrahmens festzulegen. Der Wert kann zentriert, linksbündig, rechtsbündig, Blocksatz usw. sein.

Das folgende Codebeispiel zeigt, wie der Absatz **mittig** ausgerichtet wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setzen Sie die Ausrichtung des Absatzes auf Mitte.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriftarten innerhalb einer Zeile ausrichten**

Verwenden Sie [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) , um Textabschnitte mit unterschiedlichen Schriftgrößen innerhalb einer Zeile vertikal auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung in jeder seiner Zeilen.

Das folgende eigenständige Beispiel erstellt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 pt mit unterschiedlicher Schriftalignierung. Es verwendet Arial, deaktiviert Autofit und Zeilenumbruch und hält die Textrahmen groß genug für eine einzelne Zeile.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Vergleich von Grundlinie, Oberkante, Mitte und Unterkante der Schrift mit gemischten Schriftgrößen](font_alignment.png)

Schrift‑Alignierung verwendet Schriftmetriken, sodass die sichtbaren Kanten einzelner Buchstaben nicht unbedingt exakt übereinstimmen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen Tiefsteller, um den Unterschied zwischen Grundlinie und Unterkante zu verdeutlichen. Verfügbarkeit und Substitution der Schrift, die verwendeten Zeichen und die unterschiedlichen Schriftgrößen beeinflussen das Ergebnis. Rahmenabmessungen, Ränder, Zeilenabstand, Zeilenumbruch und Autofit wirken sich ebenfalls auf das Layout aus; verwenden Sie bei Vergleichen dieselben Schriften und Layout‑Einstellungen.

Diese Einstellung unterscheidet sich von [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) , das die horizontale Absatzausrichtung steuert, und von [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) , das den Textblock vertikal innerhalb seiner Form positioniert. Hoch‑ und Tiefstellung über [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) verschiebt einzelne Abschnitte relativ zur Grundlinie, anstatt die Schrift‑Alignierung für die Zeilen des Absatzes festzulegen.

## **Transparenz für Text festlegen**

Die Transparenz von Text wird über die Alpha‑Komponente der Farbe gesteuert, die [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) zugewiesen wird. In den nachfolgenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0–255, kein Transparenz‑Prozentsatz.

Das folgende Codebeispiel zeigt, wie Transparenz auf den **gesamten Absatz** angewendet wird:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setzen Sie die Füllfarbe des Textes auf eine transparente Farbe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Codebeispiel zeigt, wie Transparenz auf **Textabschnitte mit fetter Schrift** angewendet wird:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setzen Sie die Transparenz des Textabschnitts.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die transparenten Textabschnitte](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) , um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern. Die Beispiele fügen einen Abstand von 3 pt hinzu; negative Werte verdichten den Text.

Das folgende Java‑Beispiel zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zeichenabstand vergrößern.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das folgende Codebeispiel zeigt, wie der Zeichenabstand in **Textabschnitten mit fetter Schrift** erweitert wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
            portion.getPortionFormat().setSpacing(3); // Zeichenabstand vergrößern.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In einigen Fällen kann Text, der von Aspose.Slides gerendert wird, etwas enger aussehen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die Ausgabe in solchen Fällen PowerPoint‑näher zu machen, können Sie Kerning für Textabschnitte deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erste Form auf der ersten Folie. Es prüft wirksame Schriftnamen, einschließlich geerbter Schriften, und setzt eine Schwelle von 100 pt für Abschnitte, die Roboto verwenden. Damit wird Kerning für passende Abschnitte mit einer Schriftgröße unter 100 pt deaktiviert:

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

Für passende Texte unterhalb der Schwelle verhindert diese Einstellung Kerning und kann dazu beitragen, dass das Rendering von Aspose.Slides dem visuellen Ergebnis von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften näher kommt.

## **Text‑Schrifteigenschaften verwalten**

Schrifteigenschaften können über [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) auf Absatzebene oder über [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) für einzelne Abschnitte festgelegt werden.

Das folgende Beispiel setzt die Standardschrift des ersten Absatzes auf 12‑pt Times New Roman mit fetter, kursiver und punktierter Unterstreichung. Explizite Formatierung einzelner Abschnitte hat Vorrang vor diesen Vorgaben:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Schrift‑Eigenschaften für den Absatz festlegen.
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

![Die Schrifteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet 13‑pt Times New Roman, kursive Formatierung und punktierte Unterstreichung auf Abschnitte an, deren wirksame Formatierung fett ist:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setzen Sie die Schrift‑Eigenschaften für den Textabschnitt.
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

![Die Schrifteigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Text‑Höhen‑Normalisierung steuern**

Verwenden Sie [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) , wenn Sie Vorlagen‑Typografie reproduzieren oder Unterschiede in der Zeichenhöhe untersuchen. In PowerPoint streckt das Aktivieren der Normalisierung einzelne Zeichen vertikal, um ihnen innerhalb des Textabschnitts eine einheitliche sichtbare Höhe zu geben. Es garantiert nicht gleiche Texthöhen über verschiedene Schriften hinweg.

Setzen Sie die Eigenschaft auf [NullableBool.True or False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) , um die Normalisierung explizit zu aktivieren bzw. zu deaktivieren. `NullableBool.NotDefined` lässt die lokale Einstellung ungesetzt, sodass der Abschnitt den Wert beispielsweise von [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) des Absatzes erbt. Das bedeutet nicht `False`. Verwenden Sie [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) und lesen Sie [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) , um den aufgelösten booleschen Wert zu erhalten.

Das folgende eigenständige Beispiel erfordert **Arial**. Es erstellt zwei Textblöcke mit denselben Groß‑ und Kleinbuchstaben, Tiefstellern und Zeichen mit Akzenten in 54 pt. Beide Absätze aktivieren die Normalisierung standardmäßig. Der obere Abschnitt deaktiviert sie ausdrücklich; der untere erbt sie. Rahmen­größen, Ränder und Absatzabstand sind identisch, Zeilenumbruch und Autofit sind deaktiviert, um den Vergleich konsistent zu halten. Das Beispiel gibt `False: false` und `NotDefined: true` aus und speichert „text_height_normalization.pptx“.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Der unten dargestellte Vergleich stammt aus der gespeicherten Präsentation. Die obere Zeile hat Normalisierung deaktiviert (`False`); die untere Zeile erbt die aktivierte Einstellung (`NotDefined` → `True`). Arial muss installiert sein, um das Aussehen zu reproduzieren.

![Arial‑Text 54 pt mit deaktivierter Normalisierung oben und geerbter Normalisierung unten](text_height_normalization.png)

Normalisierung ändert die Zeichenhöhe, ohne den zugewiesenen [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) Wert zu verändern, der die Schriftgröße in Punkten angibt. [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) steuert den Zeilenabstand, während [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bestimmt, wie Text oder dessen Behälter angepasst werden. Diese Einstellungen dienen unterschiedlichen Zwecken und können das Gesamtlayout unabhängig beeinflussen. Mehr zu Absatzformatierung und Vererbung finden Sie unter [Absatz verwalten](/slides/de/androidjava/manage-paragraph/).

## **Durchgestrichenen Text anwenden und entfernen**

Verwenden Sie [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) auf einem Textabschnitt, um Korrekturen, stornierte Begriffe oder frühere Preise anzuzeigen, ohne den Originaltext zu löschen. Setzen Sie ihn auf [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) für eine bzw. zwei Durchstreichungen.

Um Durchstreichungen zu entfernen, verwenden Sie [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None). Damit wird der Effekt ausdrücklich deaktiviert, selbst wenn das umgebende Format Durchstreichungen angibt. Im Gegensatz dazu lässt [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) die lokale Einstellung undefiniert, sodass der Abschnitt Formatierungen erben kann, beispielsweise vom Absatz. Das garantiert nicht, dass Durchstreichungen entfernt werden. Verwenden Sie [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) , um die resultierende Formatierung einschließlich geerbter Werte zu lesen.

Das folgende eigenständige Beispiel erstellt drei Preisvergleiche. Jeder Absatz hat separate Abschnitte für Beschriftung, alten Preis und aktuellen Preis, sodass nur der alte Preis betroffen ist. Die erste Zeile wendet Durchstreichung an und entfernt sie dann wieder; die anderen Zeilen behalten einfache bzw. doppelte Durchstreichung bei. Durch das Ändern dieser Einstellung bleibt der Text und seine übrige Formatierung, einschließlich der fetten alten Preise, erhalten.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    // Durchstreichung anwenden, dann explizit aus dem ersten vorherigen Preis entfernen.
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

![Alte Preise ohne Durchstreichung, mit einfacher Durchstreichung und mit doppelter Durchstreichung](strikethrough.png)

## **Textrotation festlegen**

Verwenden Sie [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) , um eine vordefinierte Textorientierung innerhalb einer Form festzulegen.

Das folgende Codebeispiel setzt die Textorientierung in der Form auf [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** rotiert wird:

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

![Die Textrotation](text_rotation.png)

## **Ziffern in vertikalem Text nebeneinander anzeigen**

Um eine zweistellige Zahl in einem vertikalen japanischen Etikett zusammenzuhalten, setzen Sie beide Ziffern in einen Textabschnitt und rufen Sie [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) für diesen Abschnitt auf. Das Beispiel verwendet [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/#EastAsianVertical) und 40‑pt MS Gothic für beide Etiketten. Nur der an den numerischen Abschnitt übergebene [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) Wert unterscheidet sich.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

In PowerPoint zeigt das linke Etikett (`True`) die Ziffern aufrecht und nebeneinander zwischen 和 und 年. Das rechte Etikett (`False`) dreht das Paar um 90 Grad im Uhrzeigersinn. Die umgebenden japanischen Zeichen bleiben in beiden Etiketten aufrecht.

![PowerPoint‑Vergleich von vertikalen Datums‑Etiketten mit aufrechten Ziffern links und gedrehten Ziffern rechts.](vertical_date.png)

## **Benutzerdefinierte Rotation für Textrahmen festlegen**

Verwenden Sie [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) , um einen benutzerdefinierten Drehwinkel für ein [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) festzulegen.

Das folgende Codebeispiel dreht den Textrahmen um 3 Grad im Uhrzeigersinn innerhalb der Form:

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

![Die benutzerdefinierte Textrotation](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) und [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) an, um den Absatzabstand zu steuern. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.  
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelter Zeilenabstand):

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

![Der Zeilenabstand im Absatz](line_spacing.png)

## **Zeilenumbruch steuern**

Regeln für den Zeilenumbruch eines Absatzes sind in schmalen Textblöcken und Präsentationen nützlich, die lateinischen und ostasiatischen Text mischen. Die folgenden Methoden gehören zu [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) und gelten daher für einen gesamten Absatz:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) steuert die Zeilenumbruch‑Regeln für lateinischen Text. In gemischtem Text kann eine Änderung auch beeinflussen, wo angrenzender ostasiatischer Text und Interpunktion umbrechen.  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) steuert die Zeilenumbruch‑Regeln für ostasiatischen Text, einschließlich Beschränkungen für Zeichen am Anfang und Ende einer Zeile.

Diese Regeln ersetzen nicht [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), das automatisches Umbrechen innerhalb eines Textrahmens aktiviert. Sie beeinflussen das Layout, wenn Umbrechen erfolgt; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzwingt eine neue Zeile im Absatz, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erstellt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Optionen explizit und speichert „line_breaking.pptx“. Um eine der Regeln zu testen, ändern Sie den entsprechenden Wert, während Sie die anderen Einstellungen unverändert lassen. Das Beispiel verwendet 24‑pt Arial und SimSun bei einer Rahmenbreite von 160 pt und keinen horizontalen Textrahmen‑Rändern. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) wird mit [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) aufgerufen, sodass Textgröße und Rahmenabmessungen fix bleiben.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) erlaubt zulässiger Interpunktion, über den rechten Rand der Textzeile hinaus zu reichen, anstatt in die nächste Zeile zu geraten. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100‑pt breiten Textrahmen und speichert „hanging_punctuation.pptx“. Mit 24‑pt Arial und keinen horizontalen Textrahmen‑Rändern bleibt der abschließende Punkt nach „sentence“ und reicht über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/), um zu vergleichen: Mit dieser Einstellung nimmt der Punkt eine eigene Zeile ein. Zeilenumbruch ist aktiviert und Autofit deaktiviert, um die verfügbare Breite festzuhalten.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Nicht jedes Satzzeichen kann hängen. Die [oben beschriebenen Bedingungen für Schrift und Layout](#control-line-breaking) gelten ebenfalls für diesen Vergleich: Änderungen an Schrift, Breite, Rändern oder Autofit‑Einstellungen können den sichtbaren Unterschied entfernen.

## **Autofit‑Typ für Textrahmen festlegen**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Behälters überschreitet. Verwenden Sie ihn, um zu steuern, ob Text verkleinert, überläuft oder die Form automatisch anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst, und speichert das Ergebnis unter „autofit_type.pptx“.

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

Um nach automatischem Umbrechen die Zeilen zu zählen und zu sehen, wie sich Text‑ oder Formbreite auf das Ergebnis auswirkt, siehe [Anzahl gerenderter Zeilen](/slides/de/androidjava/manage-paragraph/). Die Zeilenzahl allein sagt nicht aus, ob Text seinen Behälter überläuft.

## **Verankerung von Textrahmen festlegen**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis unter „text_anchor.pptx“.

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

## **Texttabulatoren festlegen**

Verwenden Sie [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) und [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) , um Tabstopps in einem Absatz zu konfigurieren. Das folgende Beispiel setzt den Standard‑Tab‑Abstand auf 100 pt und fügt einen linksbündigen Tab‑Stopp bei 30 pt hinzu. Diese Einstellungen wirken sich auf Text mit Tab‑Zeichen aus.

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

![Die Absatz‑Tabs](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides bietet [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) , mit dem Sie die Korrektursprache für einen Textabschnitt festlegen können. Die Korrektursprache bestimmt die Sprache, die PowerPoint für Rechtschreib‑ und Grammatikprüfung verwendet.

Das folgende Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erste Form auf der ersten Folie und mindestens einen Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schrift und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird unter „proofing_language.pptx“ gespeichert:

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

    // Setzen Sie die Id einer Korrektursprache.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sprach‑Metadaten kopieren**

Beim Kopieren mehrsprachiger Texte aus einer Vorlage sollten sowohl [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) als auch [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) erhalten bleiben. Das folgende eigenständige Beispiel erstellt einen Quellabschnitt mit US‑Englisch als Sprache und Französisch als alternativer Sprache und kopiert den Text sowie die Bezeichner in einen Abschnitt einer neuen Präsentation.

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
    // Wenn die Quelle keine alternative Sprache hat, löscht null den Wert im Ziel.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um eine Quelle ohne alternative Sprache zu testen, lassen Sie die Zuweisung von `"fr-FR"` weg. Der alternative Bezeichner ist dann `null`, und dieselbe Kopieranweisung erhält dessen Fehlen, ohne einen Standardwert einzufügen, selbst wenn das Ziel zuvor eine alternative Sprache zugewiesen hatte.

Diese Bezeichner speichern Sprach‑Metadaten. Das Beibehalten beeinflusst nicht, welches Wörterbuch PowerPoint für Rechtschreib‑ oder Grammatikprüfung auswählt.

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) , um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standardsprache, fügt ein Textfeld hinzu und gibt `en-US` für den ersten Textabschnitt aus.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Fügen Sie eine neue Rechteckform mit Text hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Überprüfen Sie die Sprache des ersten Abschnitts.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standard‑Textstil festlegen**

Um ein Standard‑Textformat auf Präsentationsebene anzuwenden, verwenden Sie [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Das folgende Beispiel setzt eine 14‑pt fette Schrift als Standard für Absatz‑Ebene‑1 in einer neuen Präsentation und speichert sie unter „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern nicht spezifischere Formatierungen sie überschreiben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Das Absatzformat der obersten Ebene abrufen.
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

In PowerPoint bewirkt die Anwendung des **All Caps**‑Schrifteffekts, dass Text auf der Folie groß geschrieben angezeigt wird, obwohl er ursprünglich klein geschrieben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides abrufen, liefert die Bibliothek den Text exakt so, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) und wandeln Sie die zurückgegebene Zeichenfolge bei `All` in Großbuchstaben um.

Dieses Beispiel benötigt „sample2.pptx“ mit einem Textfeld als erste Form auf der ersten Folie. Der erste Absatz‑erste Abschnitt enthält „Hello, Aspose!“ mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das folgende Codebeispiel zeigt, wie der Text mit dem **All Caps**‑Effekt extrahiert wird:

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

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) und die Absatzformatierung über [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Wie kann ich einem Text auf einer PowerPoint‑Folie eine Farbverlauf‑Füllung zuweisen?**

Um einer Textfüllung einen Farbverlauf zuzuweisen, verwenden Sie [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Setzen Sie [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) auf [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) und konfigurieren Sie die Verlaufspunkte, Richtung und Transparenz.