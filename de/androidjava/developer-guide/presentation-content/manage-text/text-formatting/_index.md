---
title: Präsentationstext auf Android formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/androidjava/text-formatting/
keywords:
- Absatz ausrichten
- Textstil
- Text-Hintergrund
- Texttransparenz
- Zeichenabstand
- Schrifteigenschaften
- Schriftfamilie
- Textrotation
- Rotationswinkel
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeldverankerung
- Texttabulation
- Standard-Sprache
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mithilfe von Aspose.Slides für Android via Java. Passen Sie Schriftarten, Farben, Ausrichtung und vieles mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint- und OpenDocument-Präsentationen mithilfe von Aspose.Slides für Android via Java formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textverankerung, Tabstopps und Spracheinstellungen.

In den Beispielen unten verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder reguläre Ausdrücke zu finden und zu markieren, siehe [Suche und ersetze Text](/slides/de/androidjava/search-and-replace-text/).

## **Hintergrundfarbe für Text festlegen**

Verwenden Sie [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) um die Standard‑Highlight‑Farbe für einen Absatz festzulegen, oder nutzen Sie [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) für einzelne Textabschnitte.

Das folgende Code‑Beispiel zeigt, wie man die Hintergrundfarbe für den **gesamten Absatz** festlegt:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setze die Highlight-Farbe für den gesamten Absatz.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das Code‑Beispiel unten demonstriert, wie man die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** festlegt:

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
            // Setze die Highlight-Farbe für den Textabschnitt.
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

Verwenden Sie [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) um die Absatz‑Ausrichtung innerhalb eines Textrahmens festzulegen. Der Wert kann zentriert, linksbündig, rechtsbündig, im Blocksatz usw. sein.

Das folgende Code‑Beispiel zeigt, wie man den Absatz zur **Mitte** ausrichtet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setze die Ausrichtung des Absatzes auf zentriert.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Transparenz für Text festlegen**

Die Text‑Transparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) zugewiesen wird. In den nachfolgenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0–255, nicht ein Transparenz‑Prozentsatz.

Das folgende Code‑Beispiel zeigt, wie man Transparenz auf den **gesamten Absatz** anwendet:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setze die Füllfarbe des Textes auf transparente Farbe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Code‑Beispiel zeigt, wie man Transparenz auf **Textabschnitte mit fetter Schrift** anwendet:

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
            // Setze die Transparenz des Textabschnitts.
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

Verwenden Sie [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern.

Der folgende Java‑Code zeigt, wie man den Zeichenabstand im **gesamten Absatz** vergrößert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zeichenabstand erweitern.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das Code‑Beispiel unten zeigt, wie man den Zeichenabstand in **Textabschnitten mit fetter Schrift** vergrößert:

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
            portion.getPortionFormat().setSpacing(3); // Zeichenabstand erweitern.
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

In einigen Fällen kann Text, der von Aspose.Slides gerendert wird, etwas enger erscheinen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um das gerenderte Ergebnis in solchen Fällen PowerPoint‑näher zu bringen, können Sie Kerning für Textabschnitte deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) auf einen Wert, der deutlich größer ist als die tatsächliche Schriftgröße:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diese Einstellung verhindert, dass Kerning auf passende Textabschnitte angewendet wird, und kann helfen, das Rendering von Aspose.Slides an die visuelle Ausgabe von PowerPoint für betroffene Schriften anzupassen.

## **Schrifteigenschaften für Text verwalten**

Schrifteigenschaften können auf Absatz‑Ebene über [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) oder für einzelne Abschnitte über [IPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportionformat/) gesetzt werden.

Der folgende Code legt die Schrift und den Textstil für den gesamten Absatz fest: Er wendet Schriftgröße, Fett, Kursiv, gepunktete Unterstreichung und die Schriftart Times New Roman auf alle Abschnitte im Absatz an.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Setze die Schrifteigenschaften für den Absatz.
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

Das Code‑Beispiel unten wendet ähnliche Eigenschaften auf **Textabschnitte mit fetter Schrift** an:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Setze die Schrifteigenschaften für den Textabschnitt.
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

## **Textrotation festlegen**

Verwenden Sie [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Der folgende Code setzt die Textorientierung in der Form auf [TextVerticalType.Vertical270](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:

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

## **Benutzerdefinierte Rotation für Textfelder festlegen**

Verwenden Sie [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) um einen benutzerdefinierten Rotationswinkel für ein [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) festzulegen.

Der folgende Code rotiert das Textfeld um 3 Grad im Uhrzeigersinn innerhalb der Form:

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

Aspose.Slides stellt [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) und [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) bereit, um den Absatzabstand zu steuern. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Der folgende Code zeigt, wie man den Zeilenabstand innerhalb des Absatzes festlegt:

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

## **Autofit‑Typ für Textfelder festlegen**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob der Text verkleinert, überläuft oder die Form automatisch anpasst.

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

Um Zeilen nach automatischem Umbruch zu zählen und zu sehen, wie sich Text‑ oder Formbreite auf das Ergebnis auswirken, siehe [Count Rendered Lines](/slides/de/androidjava/manage-paragraph/). Die reine Zeilenzahl sagt nicht aus, ob Text seinen Container überläuft.

## **Verankerung von Textfeldern festlegen**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definiert, wie Text vertikal innerhalb einer Form positioniert wird, beispielsweise oben, in der Mitte oder unten.

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

Verwenden Sie [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) und [IParagraphFormat.getTabs](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) um Tabstopps in einem Absatz zu konfigurieren.

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

![Die Absatz‑Tabulatoren](paragraph_tabs.png)

## **Rechtschreibsprache festlegen**

Aspose.Slides bietet [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), mit dem Sie die Rechtschreib‑ und Grammatik‑Sprache für einen Textabschnitt festlegen können. Die Rechtschreibsprache bestimmt, welche Sprache für Rechtschreib‑ und Grammatikprüfung in PowerPoint verwendet wird.

Der folgende Code zeigt, wie man die Rechtschreibsprache für einen Textabschnitt festlegt:

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

    // Setze die Id einer Rechtschreibsprache.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), um die Standardsprache für Text zu definieren, der beim Laden oder Erstellen einer Präsentation erzeugt wird.

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

    // Überprüfe die Sprache des ersten Abschnitts.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standard‑Textstil festlegen**

Um die Standard‑Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Der folgende Code legt eine Standardschriftart fett mit 14 pt Größe für gesamten Text in allen Folien einer neuen Präsentation fest.

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

## **Text mit dem Großschreibungseffekt extrahieren**

In PowerPoint bewirkt der **All Caps**‑Schrifteffekt, dass Text auf der Folie in Großbuchstaben angezeigt wird, selbst wenn er ursprünglich klein geschrieben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides abrufen, gibt die Bibliothek den Text genau so zurück, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, konvertieren Sie die zurückgegebene Zeichenkette in Großbuchstaben, wenn der Wert [TextCapType.All](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textcaptype/) ist.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei sample2.pptx.

![Der Großschreibungseffekt](all_caps_effect.png)

Der folgende Code zeigt, wie man den Text mit angewendetem **All Caps**‑Effekt extrahiert:

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

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [ITable](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itable/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [ICell.getTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icell/#getTextFrame--) und die Absatzformatierung über [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Wie kann man einen Farbverlauf auf Text in einer PowerPoint‑Folie anwenden?**

Um einen Farbverlauf auf Text anzuwenden, verwenden Sie [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Setzen Sie [IFillFormat.setFillType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) auf [FillType.Gradient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/filltype/) und konfigurieren Sie die Verlaufsstopps, Richtung und Transparenz.