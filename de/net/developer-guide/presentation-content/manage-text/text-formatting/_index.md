---
title: Präsentationstext formatieren in .NET
linktitle: Textformatierung
type: docs
weight: 50
url: /de/net/text-formatting/
keywords:
  - Absatz ausrichten
  - Textstil
  - Text-Hintergrund
  - Text-Transparenz
  - Zeichenabstand
  - Schrifteigenschaften
  - Schriftfamilie
  - Textdrehung
  - Drehwinkel
  - Textfeld
  - Zeilenabstand
  - Autofit-Eigenschaft
  - Textfeldverankerung
  - Texttabulierung
  - Standardsprache
  - PowerPoint
  - OpenDocument
  - Präsentation
  - .NET
  - C#
  - Aspose.Slides
description: "Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET formatieren und gestalten. Schriftarten, Farben, Ausrichtung und mehr anpassen."
---
## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET formatiert wird. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schrifteigenschaften, Drehung, Absatzabstände, Autofit‑Verhalten, Textverankerung, Tabstopps und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien- als auch Formindizes beginnen bei Null. Beispiele, die fette Textabschnitte auswählen, verwenden effektive Formatierung, einschließlich vererbter Fettschrift:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder reguläre Ausdruck-Übereinstimmungen zu finden und zu markieren, siehe [Suchen und Ersetzen von Text](/slides/de/net/search-and-replace-text/).

## **Text-Hintergrundfarbe festlegen**

Verwenden Sie [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/defaultportionformat/) , um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder verwenden Sie [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/highlightcolor/) , um einzelne Textabschnitte zu formatieren.

Das folgende Beispiel legt ein hellgraues Hervorhebungsfarb als Standard für den ersten Absatz fest. Explizite Hervorhebungsfarben für einzelne Abschnitte haben Vorrang vor diesem Standard:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Setzt die Hervorhebungsfarbe für den gesamten Absatz.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachstehende Codebeispiel zeigt, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** festgelegt wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Setzt die Hervorhebungsfarbe für den Textabschnitt.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [IParagraphFormat.Alignment](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/alignment/) , um die Absatzausrichtung innerhalb eines Textfelds festzulegen. Der Wert kann zentriert, linksbündig, rechtsbündig, blockseitig usw. sein.

Das folgende Codebeispiel zeigt, wie der Absatz **zentriert** ausgerichtet wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Setzt die Ausrichtung des Absatzes auf zentriert.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/fillformat/) zugewiesen wird. In den nachstehenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Kanalwert im Bereich 0–255 und keine Transparenz‑Prozentsatz.

Das nachstehende Codebeispiel zeigt, wie Transparenz auf den **gesamten Absatz** angewendet wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Setzt eine halbtransparente schwarze Füllung für den Text.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Codebeispiel zeigt, wie Transparenz auf **Textabschnitte mit fetter Schrift** angewendet wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Setzt die Transparenz des Textabschnitts.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die transparenten Textabschnitte](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/spacing/) , um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu reduzieren. Die Beispiele fügen 3 Punkte Abstand hinzu; negative Werte verdichten den Text.

Der folgende C#‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Erweitert den Zeichenabstand.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das nachstehende Codebeispiel zeigt, wie der Zeichenabstand in **Textabschnitten mit fetter Schrift** erweitert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
        portion.PortionFormat.Spacing = 3;  // Erweitert den Zeichenabstand.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In einigen Fällen kann von Aspose.Slides gerenderter Text leicht enger aussehen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignorieren kann, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um die gerenderte Ausgabe in solchen Fällen PowerPoint anzunähern, können Sie das Kerning für Textabschnitte deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/kerningminimalsize/) , auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel erfordert „presentation.pptx“ mit einem Textfeld als erster Form auf der ersten Folie. Es prüft die effektiven Schriftnamen, einschließlich geerbter Schriften, und legt eine Schwelle von 100 Punkten für Abschnitte fest, die Roboto verwenden. Dadurch wird das Kerning für passende Abschnitte mit einer Schriftgröße unter 100 Punkten deaktiviert:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Für passenden Text unterhalb der Schwelle verhindert diese Einstellung Kerning und kann helfen, die Darstellung von Aspose.Slides an die visuelle Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften anzupassen.

## **Schrifteigenschaften von Text verwalten**

Schrifteigenschaften können auf Absatzebene über [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/defaultportionformat/) oder für einzelne Abschnitte über [IPortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformat/) festgelegt werden.

Das folgende Beispiel setzt die Standardschrift des ersten Absatzes auf 12 Punkt Times New Roman mit fetter, kursiver und gepunkteter Unterstreichung. Explizite Formatierung einzelner Abschnitte hat Vorrang vor diesen Vorgaben:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Setzt die Schrifteigenschaften für den Absatz.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Schrifteigenschaften für den Absatz](font_properties_for_paragraph.png)

Das folgende Beispiel wendet 13 Punkt Times New Roman, kursive Formatierung und eine gepunktete Unterstreichung auf Abschnitte an, deren effektive Formatierung fett ist:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Setzt die Schrifteigenschaften für den Textabschnitt.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Schrifteigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Textdrehung festlegen**

Verwenden Sie [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/textverticaltype/) , um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Das folgende Codebeispiel setzt die Textausrichtung in der Form auf [TextVerticalType.Vertical270](https://reference.aspose.com/slides/de/net/aspose.slides/textverticaltype/) , was den Text **um 90 Grad gegen den Uhrzeigersinn** dreht:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Textdrehung](text_rotation.png)

## **Benutzerdefinierte Drehung für Textfelder festlegen**

Verwenden Sie [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/rotationangle/) , um einen benutzerdefinierten Drehwinkel für ein [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) festzulegen.

Das nachstehende Codebeispiel dreht das Textfeld innerhalb der Form um 3 Grad im Uhrzeigersinn:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die benutzerdefinierte Textdrehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides stellt [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/spaceafter/) , [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/spacebefore/) und [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/spacewithin/) bereit, um den Absatzabstand zu steuern. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Das folgende Beispiel setzt den Abstand innerhalb des ersten Absatzes auf 200 % der Zeilenhöhe (doppelter Abstand):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der Zeilenabstand innerhalb des Absatzes](line_spacing.png)

## **Zeilenumbruch steuern**

Absatz‑Zeilenumbruchregeln sind nützlich in schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen. Die folgenden Eigenschaften gehören zu [IParagraphFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/) , sodass sie für einen gesamten Absatz gelten:

- [LatinLineBreak](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/latinlinebreak/) steuert die Zeilenumbruchregeln für lateinischen Text. Bei gemischtem Text kann eine Änderung auch beeinflussen, wo angrenzender ostasiatischer Text und Satzzeichen umbrochen werden.
- [EastAsianLineBreak](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/eastasianlinebreak/) steuert die Zeilenumbruchregeln für ostasiatischen Text, einschließlich Beschränkungen für Zeichen am Anfang und Ende einer Zeile.

Diese Regeln ersetzen nicht [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/wraptext/) , das automatisches Umbrechen innerhalb eines Textfelds ermöglicht. Sie beeinflussen das Layout, wenn ein Umbrechen erfolgt; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzwingt eine neue Zeile im Absatz, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erstellt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Eigenschaften explizit und speichert „line_breaking.pptx“. Um mit einer der Regeln zu experimentieren, ändern Sie den Wert dieser Eigenschaft, während die andere Einstellung unverändert bleibt. Das Beispiel verwendet 24‑Punkt Arial und SimSun bei einer Rahmenbreite von 160 Punkten und horizontalen Textfeld‑Rändern von 0. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/autofittype/) ist auf [TextAutofitType.None](https://reference.aspose.com/slides/de/net/aspose.slides/textautofittype/) gesetzt, sodass Textgröße und Rahmenmaße fix bleiben.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Hängende Interpunktion steuern**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/hangingpunctuation/) ermöglicht es zulässiger Interpunktion, über den rechten Rand der Textzeile hinauszuragen, anstatt die nächste Zeile zu belegen. Es gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100‑Punkt breiten Textfeld und speichert „hanging_punctuation.pptx“. Mit 24‑Punkt Arial und horizontalen Textfeld‑Rändern von 0 bleibt der abschließende Punkt nach „sentence“ und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.False](https://reference.aspose.com/slides/de/net/aspose.slides/nullablebool/) , um zu vergleichen: Bei diesen Einstellungen belegt der Punkt eine eigene Zeile. Umbrechen ist aktiviert und Autofit deaktiviert, um die verfügbare Breite festzuhalten.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Nicht jedes Satzzeichen kann hängen. Die [oben beschriebenen Schrift‑ und Layoutbedingungen](#conditions-and-limitations) gelten ebenfalls für diesen Vergleich: Eine Änderung der Schrift, der verfügbaren Breite, der Ränder oder der Autofit‑Einstellungen kann den sichtbaren Unterschied entfernen.

## **Autofit‑Typ für Textfelder festlegen**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/autofittype/) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Verwenden Sie es, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst, und speichert das Ergebnis in „autofit_type.pptx“.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Um nach automatischem Umbrechen Zeilen zu zählen und zu sehen, wie Text‑ oder Formbreite das Ergebnis ändern, siehe [Anzahl gerenderter Zeilen](/slides/de/net/manage-paragraph/). Die Zeilenzahl allein gibt keinen Aufschluss darüber, ob Text seinen Container überläuft.

## **Verankerung von Textfeldern festlegen**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/anchoringtype/) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis in „text_anchor.pptx“.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Texttabulation festlegen**

Verwenden Sie [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/defaulttabsize/) und [IParagraphFormat.Tabs](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/tabs/) , um Tabstopps in einem Absatz zu konfigurieren. Das folgende Beispiel setzt das Standard‑Tab‑Intervall auf 100 Punkte und fügt einen linksbündigen Tab‑Stopp bei 30 Punkten hinzu. Diese Einstellungen wirken sich auf Text mit Tab‑Zeichen aus.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Absatz‑Tabstopps](paragraph_tabs.png)

## **Rechtschreibprüfungssprache festlegen**

Aspose.Slides bietet [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/languageid/) , mit dem Sie die Rechtschreibprüfungssprache für einen Textabschnitt festlegen können. Die Rechtschreibprüfungssprache bestimmt die für Rechtschreib‑ und Grammatikprüfung in PowerPoint verwendete Sprache.

Das folgende Beispiel erfordert „presentation.pptx“ mit einem Textfeld als erster Form auf der ersten Folie und mindestens einem Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schrift und weist die vereinfachte chinesische Rechtschreibprüfungssprache (`zh-CN`) zu. Es speichert das Ergebnis in „proofing_language.pptx“:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Setzt die Korrektursprache auf vereinfachtes Chinesisch.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/defaulttextlanguage/) , um die Standardsprache für beim Laden oder Erstellen einer Präsentation erzeugten Text festzulegen. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standard‑Textsprache, fügt ein Textfeld hinzu und gibt `en-US` für dessen ersten Textabschnitt aus.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Fügt eine neue Rechteckform mit Text hinzu.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Prüft die Sprache des ersten Textabschnitts.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Standard‑Textstil festlegen**

Um standardmäßige Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/defaulttextstyle/) .

Das folgende Beispiel legt eine 14‑Punkt fette Schrift als Standard für Absatz‑Erste‑Ebene in einer neuen Präsentation fest und speichert sie in „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern nicht spezifischere Formatierungen sie überschreiben.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Holt das Absatzformat der obersten Ebene.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint lässt die Anwendung des **All‑Caps**‑Schrifteffekts Text in Großbuchstaben auf der Folie erscheinen, auch wenn er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides abfragen, gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/de/net/aspose.slides/textcaptype/) und konvertieren die zurückgegebene Zeichenkette in Großbuchstaben, wenn der Wert `All` ist.

Dieses Beispiel erfordert „sample2.pptx“ mit einem Textfeld als erster Form auf der ersten Folie. Der erste Abschnitt des ersten Absatzes enthält „Hello, Aspose!“ mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das nachstehende Codebeispiel zeigt, wie der Text mit angewendetem **All‑Caps**‑Effekt extrahiert wird:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Ausgabe:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Wie ändere ich Text in einer Tabelle auf einer Folie?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [ICell.TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/icell/textframe/) sowie die Absatzformatierung über [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/paragraphformat/) .

**Wie wende ich einen Farbverlauf auf Text in einer PowerPoint‑Folien an?**

Um einen Farbverlauf auf Text anzuwenden, verwenden Sie [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/fillformat/). Setzen Sie [IFillFormat.FillType](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformat/filltype/) auf [FillType.Gradient](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) und konfigurieren Sie die Farbverlaufs‑Stops, die Richtung und die Transparenz.