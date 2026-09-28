---
title: Präsentationstext in Java formatieren
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
- Schrifteigenschaften
- Schriftfamilie
- Textdrehung
- Drehwinkel
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeld-Anker
- Tabulatoren
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java. Passen Sie Schriftarten, Farben, Ausrichtungen und mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schrifteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabstopps und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Das erste Shape auf der ersten Folie ist ein Textfeld, und sein erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Shape‑Indizes sind nullbasiert. Beispiele, die fette Textteile auswählen, verwenden effektives Formatieren, einschließlich geerbter Fettschrift:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder Übereinstimmungen mit regulären Ausdrücken zu finden und hervorzuheben, siehe [Search and Replace Text](/slides/de/java/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) zum Festlegen der Standard‑Highlight‑Farbe für einen Absatz oder [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) für einzelne Textteile.

Im folgenden Beispiel wird ein hellgraues Highlight als Standard für den ersten Absatz festgelegt. Explizite Highlight‑Farben für einzelne Teile haben Vorrang vor diesem Standard:

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

Das nachstehende Code‑Beispiel zeigt, wie man die Hintergrundfarbe für **Textteile mit fetter Schrift** festlegt:

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
            // Setze die Hervorhebungsfarbe für den Textabschnitt.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Die grauen Textteile](gray_text_portions.png)

## **Absätze ausrichten**

Verwenden Sie [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) zum Festlegen der Absatz‑Ausrichtung innerhalb eines Textfeldes. Der Wert kann zentriert, linksbündig, rechtsbündig, block­justiert usw. sein.

Das folgende Code‑Beispiel zeigt, wie man den Absatz **zentriert** ausrichtet:

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

## **Transparenz für Text festlegen**

Die Text‑Transparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) zugewiesen wird. In den nachstehenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0–255, nicht ein Transparenz‑Prozentsatz.

Das folgende Code‑Beispiel zeigt, wie man Transparenz auf den **gesamten Absatz** anwendet:

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

Das folgende Code‑Beispiel zeigt, wie man Transparenz auf **Textteile mit fetter Schrift** anwendet:

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
            // Setze die Transparenz des Textabschnitts.
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

![Die transparenten Textteile](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) zum Vergrößern oder Verkleinern des Zeichenabstands in einem Textfeld. Die Beispiele fügen 3 Punkt Abstand hinzu; negative Werte verkleinern den Abstand.

Das folgende Java‑Code‑Beispiel zeigt, wie man den Zeichenabstand im **gesamten Absatz** vergrößert:

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

Das nachstehende Code‑Beispiel zeigt, wie man den Zeichenabstand in **Textteilen mit fetter Schrift** vergrößert:

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

![Der Zeichenabstand in den Textteilen](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In einigen Fällen kann Text, der von Aspose.Slides gerendert wird, etwas enger aussehen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die gerenderte Ausgabe in solchen Fällen PowerPoint‑ähnlicher zu machen, können Sie Kerning für Textteile deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel erfordert „presentation.pptx“ mit einem Textfeld als erstem Shape auf der ersten Folie. Es prüft effektive Schriftarten, einschließlich geerbter Schriften, und legt eine Schwelle von 100 Punkt für Textteile fest, die Roboto verwenden. Damit wird Kerning für passende Textteile mit einer Schriftgröße unter 100 Punkt deaktiviert:

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

Für Textteile, die unterhalb der Schwelle liegen, verhindert diese Einstellung Kerning und kann helfen, das Rendering von Aspose.Slides an die visuelle Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften anzupassen.

## **Schrifteigenschaften verwalten**

Schrifteigenschaften können auf Absatzebene über [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) oder für einzelne Textteile über [IPortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportionformat/) festgelegt werden.

Das folgende Beispiel setzt die Standardschrift des ersten Absatzes auf Times New Roman 12 Pt mit fetter, kursiver und punktierter Unterstreichung. Explizite Formatierung einzelner Textteile hat Vorrang vor diesen Vorgaben:

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

![Die Schrifteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das nachstehende Beispiel wendet Times New Roman 13 Pt, kursive Formatierung und eine punktierte Unterstreichung auf Textteile an, deren effektive Formatierung fett ist:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setze die Schriftarteigenschaften für den Textabschnitt.
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

![Die Schrifteigenschaften für die Textteile](font_properties_for_text_portions.png)

## **Text drehen**

Verwenden Sie [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) zum Festlegen einer vordefinierten Textausrichtung innerhalb eines Shapes.

Das folgende Code‑Beispiel setzt die Textausrichtung im Shape auf [TextVerticalType.Vertical270](https://reference.aspose.com/slides/de/java/com.aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:

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

![Die Textdrehung](text_rotation.png)

## **Benutzerdefinierte Drehung für Textfelder festlegen**

Verwenden Sie [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) zum Festlegen eines benutzerdefinierten Drehwinkels für ein [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/).

Das nachstehende Code‑Beispiel dreht das Textfeld um 3 Grad im Uhrzeigersinn innerhalb des Shapes:

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

![Die benutzerdefinierte Textdrehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides stellt [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) und [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) zur Steuerung des Absatzabstands bereit. Diese Eigenschaften werden folgendermaßen verwendet:

* Ein positiver Wert gibt den Zeilenabstand als Prozentsatz der Zeilenhöhe an.
* Ein negativer Wert gibt den Zeilenabstand in Punkten an.

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

Regeln für den Zeilenumbruch von Absätzen sind in schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen, nützlich. Die folgenden Methoden gehören zu [IParagraphFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/), daher gelten sie für den gesamten Absatz:

- [setLatinLineBreak](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) steuert die Zeilenumbruch‑Regeln für lateinischen Text. In gemischtem Text kann eine Änderung auch das Umbrechen von angrenzendem ostasiatischem Text und Interpunktion beeinflussen.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) steuert die Zeilenumbruch‑Regeln für ostasiatischen Text, einschließlich Einschränkungen für Zeichen am Anfang und Ende einer Zeile.

Diese Regeln ersetzen nicht [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), das automatisches Umbrechen innerhalb eines Textfeldes aktiviert. Sie beeinflussen das Layout, wenn ein Umbrechen stattfindet; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzwingt eine neue Zeile im Absatz, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erzeugt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Optionen explizit und speichert „line_breaking.pptx“. Um eine der Regeln zu testen, ändern Sie den entsprechenden Wert, während die andere Einstellung unverändert bleibt. Das Beispiel verwendet Arial 24 Pt und SimSun mit einer Frame‑Breite von 160 Pt und keinen horizontalen Text‑Frame‑Rändern. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) wird mit [TextAutofitType.None](https://reference.aspose.com/slides/de/java/com.aspose.slides/textautofittype/) aufgerufen, sodass Textgröße und Frame‑Abmessungen fest bleiben:

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

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) ermöglicht es geeigneter Interpunktion, über den rechten Rand der Textzeile hinauszuragen, anstatt in die nächste Zeile zu wandern. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100‑Pt‑breiten Textfeld und speichert „hanging_punctuation.pptx“. Mit Arial 24 Pt und keinen horizontalen Text‑Frame‑Rändern bleibt der abschließende Punkt nach „Satz“ und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.False](https://reference.aspose.com/slides/de/java/com.aspose.slides/nullablebool/), um zu vergleichen: In diesem Fall occupy the period a separate line. Das Umbrechen ist aktiviert und Autofit deaktiviert, damit die verfügbare Breite fest bleibt.

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

Nicht jedes Satzzeichen kann hängen. Das sichtbare Ergebnis hängt von der Verfügbarkeit der Schriftart und dem Layout ab: Änderungen an Schriftart, verfügbarer Breite, Rändern oder Autofit‑Einstellungen können den sichtbaren Unterschied entfernen.

## **Autofit‑Typ für Textfelder festlegen**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie sie, um zu steuern, ob der Text schrumpft, überläuft oder das Shape automatisch anpasst. Das folgende Beispiel konfiguriert das Shape so, dass es sich an den Text anpasst, und speichert das Ergebnis als „autofit_type.pptx“.

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

Um nach automatischem Umbrechen die Zeilen zu zählen und zu sehen, wie sich Text‑ oder Shape‑Breite auf das Ergebnis auswirken, siehe [Count Rendered Lines](/slides/de/java/manage-paragraph/). Die reine Zeilenzahl sagt nicht aus, ob Text den Container überläuft.

## **Anker von Textfeldern festlegen**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definiert, wie Text vertikal innerhalb eines Shapes positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand des ersten Shapes und speichert das Ergebnis als „text_anchor.pptx“.

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

Verwenden Sie [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) und [IParagraphFormat.getTabs](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraphformat/#getTabs--) zur Konfiguration von Tabstopps in einem Absatz. Das folgende Beispiel setzt das Standard‑Tab‑Intervall auf 100 Punkt und fügt bei 30 Punkt einen linksbündigen Tab‑Stopp hinzu. Diese Einstellungen wirken sich auf Text aus, der Tabulator‑Zeichen enthält.

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

## **Rechtschreibsprache festlegen**

Aspose.Slides bietet [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), mit dem Sie die Korrektursprache für einen Textteil festlegen können. Die Korrektursprache bestimmt die Sprache, die für Rechtschreib‑ und Grammatikprüfung in PowerPoint verwendet wird.

Das folgende Beispiel erfordert „presentation.pptx“ mit einem Textfeld als erstem Shape auf der ersten Folie und mindestens einem Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schriftart und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird als „proofing_language.pptx“ gespeichert:

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

## **Standardsprache festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), um die Standardsprache für Text zu definieren, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standardsprache für Text, fügt ein Textfeld hinzu und gibt `en-US` für den ersten Textteil aus.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Füge ein neues Rechteck-Shape mit Text hinzu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Prüfe die Sprache des ersten Textabschnitts.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standard‑Textstil festlegen**

Um eine standardmäßige Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Das folgende Beispiel legt eine 14‑Pt‑fette Schrift als Standard für Oberabsätze in einer neuen Präsentation fest und speichert sie als „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern keine spezifischere Formatierung sie überschreibt.

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

In PowerPoint bewirkt die Schriftart‑Eigenschaft **All Caps**, dass Text auf der Folie großgeschrieben angezeigt wird, obwohl er ursprünglich klein geschrieben wurde. Wenn Sie einen solchen Textteil mit Aspose.Slides abrufen, liefert die Bibliothek den original eingegebenen Text. Um den angezeigten Text abzugleichen, prüfen Sie [TextCapType](https://reference.aspose.com/slides/de/java/com.aspose.slides/textcaptype/) und konvertieren Sie die zurückgegebene Zeichenkette bei `All` in Großbuchstaben.

Dieses Beispiel erfordert „sample2.pptx“ mit einem Textfeld als erstem Shape auf der ersten Folie. Der erste Absatz‑erste Teil enthält „Hello, Aspose!“ mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der nachstehende Code zeigt, wie man den Text mit angewendetem **All Caps**‑Effekt extrahiert:

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

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [ITable](https://reference.aspose.com/slides/de/java/com.aspose.slides/itable/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [ICell.getTextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/icell/#getTextFrame--) sowie die Absatzformatierung über [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Wie kann ich einem Text auf einer PowerPoint‑Folien einen Farbverlauf zuweisen?**

Um einem Text einen Farbverlauf zuzuweisen, verwenden Sie [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Setzen Sie [IFillFormat.setFillType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifillformat/#setFillType-byte-) auf [FillType.Gradient](https://reference.aspose.com/slides/de/java/com.aspose.slides/filltype/) und konfigurieren Sie die Gradient‑Stops, Richtung und Transparenz.