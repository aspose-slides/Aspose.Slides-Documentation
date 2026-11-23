---
title: Präsentationstext in .NET formatieren
linktitle: Textformatierung
type: docs
weight: 50
url: /de/net/text-formatting/
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
- Textfeld
- Zeilenabstand
- Autofit‑Eigenschaft
- Textfeld-Anker
- Tabulator
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET formatieren und gestalten. Schriftarten, Farben, Ausrichtungen und mehr anpassen."
---
## **Übersicht**

Dieser Artikel zeigt, wie Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET formatiert wird. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textausrichtung, Tabulatoren und Spracheinstellungen.

Sofern nicht anders angegeben, verwenden die Beispiele [sample.pptx](sample.pptx). Die erste Form auf der ersten Folie ist ein Textfeld, und ihr erster Absatz enthält den unten gezeigten Text. Sowohl Folien‑ als auch Form‑Indizes beginnen bei 0. Beispiele, die fette Textteile auswählen, nutzen effektive Formatierung, einschließlich geerbter Fettdarstellung:

![Beispieltext](sample_text.png)

Um wörtlichen Text bzw. Übereinstimmungen mit regulären Ausdrücken zu finden und hervorzuheben, siehe [Search and Replace Text](/slides/de/net/search-and-replace-text/).

## **Text‑Hintergrundfarbe festlegen**

Verwenden Sie [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/), um die standardmäßige Hervorhebungsfarbe für einen Absatz festzulegen, oder [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) für einzelne Textabschnitte.

Das folgende Beispiel legt ein hellgraues Hervorheben als Standard für den ersten Absatz fest. Explizite Hervorhebungsfarben in einzelnen Abschnitten haben Vorrang vor diesem Standard:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Legen Sie die Hervorhebungsfarbe für den gesamten Absatz fest.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Das nachstehende Code‑Beispiel zeigt, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** gesetzt wird:

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
        // Legen Sie die Hervorhebungsfarbe für den Textabschnitt fest.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), um die Absatzausrichtung innerhalb eines Textfelds festzulegen. Der Wert kann zentriert, linksbündig, rechtsbündig, Blocksatz usw. sein.

Das folgende Code‑Beispiel zeigt, wie der Absatz **mittig** ausgerichtet wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Setze die Ausrichtung des Absatzes auf zentriert.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Schriftarten innerhalb einer Zeile ausrichten**

Verwenden Sie [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/), um Textabschnitte mit unterschiedlichen Schriftgrößen innerhalb einer Zeile vertikal auszurichten. Diese Einstellung gilt für den gesamten Absatz und steuert die Ausrichtung innerhalb jeder seiner Zeilen.

Das folgende eigenständige Beispiel erstellt vier beschriftete Textfelder auf einer Folie. Jeder Absatz enthält denselben Text in 18, 36 und 54 Punkt, jeweils mit unterschiedlicher Schrift­ausrichtung. Es verwendet Arial, deaktiviert Autofit und Zeilenumbruch und hält die Textfelder groß genug für eine einzelne Zeile.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Vergleich von Baseline, Top, Center und Bottom Schrift­ausrichtung bei gemischten Schriftgrößen](font_alignment.png)

Die Schrift­ausrichtung verwendet Schrift­metriken, sodass die sichtbaren Kanten einzelner Buchstaben nicht unbedingt exakt übereinstimmen. Das Beispiel enthält sowohl einen Großbuchstaben als auch einen tiefer hängenden Buchstaben, um den Unterschied zwischen Grundlinie und Unterkante zu verdeutlichen. Verfügbarkeit und Ersatz von Schriften, die verwendeten Zeichen und die unterschiedlichen Schriftgrößen beeinflussen das Ergebnis. Rahmen‑Abmessungen, Ränder, Zeilenabstand, Zeilenumbruch und Autofit wirken sich ebenfalls auf das Layout aus; beim Vergleich der Modi sollten dieselben Schriften und Layout‑Einstellungen verwendet werden.

Diese Einstellung unterscheidet sich von [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), die die horizontale Absatzausrichtung steuert, und von [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), die den Textblock vertikal innerhalb seiner Form positioniert. Hoch‑ und Tiefstellung über [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) verschieben einzelne Abschnitte relativ zur Grundlinie, anstatt die Schrift­ausrichtung für die Zeilen des Absatzes zu setzen.

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe geregelt, die [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) zugewiesen wird. In den nachfolgenden Beispielen ist `alpha = 50` ein ARGB‑Alphakanalwert im Bereich 0‑255, keine Transparenz‑Prozentangabe.

Das folgende Code‑Beispiel zeigt, wie Transparenz auf den **gesamten Absatz** angewendet wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Setze eine halbtransparente schwarze Füllung für den Text.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Das folgende Code‑Beispiel zeigt, wie Transparenz auf **Textabschnitte mit fetter Schrift** angewendet wird:

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
        // Setze die Transparenz des Textabschnitts.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die transparenten Textabschnitte](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern. Die Beispiele fügen 3 Punkt Abstand hinzu; negative Werte verdichten den Text.

Der folgende C#‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Zeichenabstand erweitern.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Das nachstehende Code‑Beispiel zeigt, wie der Zeichenabstand in **Textabschnitten mit fetter Schrift** erweitert wird:

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
        portion.PortionFormat.Spacing = 3;  // Zeichenabstand erweitern.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In manchen Fällen kann der von Aspose.Slides gerenderte Text leicht enger erscheinen als derselbe Text in PowerPoint. Das kann passieren, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in PowerPoint aktiviert ist.

Um die gerenderte Ausgabe in solchen Fällen PowerPoint‑ähnlicher zu machen, können Sie Kerning für Textabschnitte deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) auf einen Wert, der größer ist als die tatsächliche Schriftgröße. Dieses Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erster Form auf der ersten Folie. Es prüft effektive Schriftsnamen, einschließlich geerbter Schriften, und legt einen Schwellenwert von 100 Punkt für Abschnitte fest, die Roboto verwenden. Damit wird Kerning für passende Abschnitte mit einer Schriftgröße unter 100 Punkt deaktiviert:

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

Für Text, der unter dem Schwellenwert liegt, verhindert diese Einstellung Kerning und kann dabei helfen, das Rendering von Aspose.Slides an die visuelle Ausgabe von PowerPoint für von diesem PowerPoint‑spezifischen Verhalten betroffene Schriften anzupassen.

## **Schriftarteigenschaften von Text verwalten**

Schriftarteigenschaften können auf Absatzebene über [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) oder auf einzelnen Abschnitten über [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) festgelegt werden.

Das folgende Beispiel legt die Standardschrift des ersten Absatzes auf 12 Punkt Times New Roman mit fetter, kursiver und punktierter Unterstreichung fest. Explizite Formatierung einzelner Abschnitte hat Vorrang vor diesen Vorgaben:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Setzen Sie die Schriftarteigenschaften für den Absatz.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Schriftarteigenschaften des Absatzes](font_properties_for_paragraph.png)

Das folgende Beispiel wendet 13 Punkt Times New Roman, kursive Formatierung und eine punktierte Unterstreichung auf Abschnitte an, deren effektive Formatierung fett ist:

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
        // Setzen Sie die Schriftarteigenschaften für den Textabschnitt.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![Die Schriftarteigenschaften der Textabschnitte](font_properties_for_text_portions.png)

## **Steuerung der Normalisierung der Text‑Höhe**

Verwenden Sie [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/), wenn Sie Vorlagen‑Typografie reproduzieren oder Unterschiede in der Zeichenhöhe untersuchen. In PowerPoint bewirkt das Aktivieren der Normalisierung, dass einzelne Zeichen vertikal gestreckt oder komprimiert werden, um innerhalb des Textabschnitts eine einheitliche sichtbare Höhe zu erhalten. Es garantiert keine gleiche Text‑Höhe zwischen verschiedenen Schriften.

Setzen Sie die Eigenschaft auf [NullableBool.True oder False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), um die Normalisierung explizit zu aktivieren bzw. zu deaktivieren. `NullableBool.NotDefined` lässt die lokale Einstellung unbestimmt, sodass der Abschnitt den Wert, beispielsweise von der Absatz‑[DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/), erbt. Das bedeutet nicht `False`. Verwenden Sie [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) und lesen Sie [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/), um den aufgelösten booleschen Wert zu erhalten.

Das folgende eigenständige Beispiel erfordert die Installation von **Arial**. Es erzeugt zwei Textblöcke mit denselben Groß‑ und Kleinbuchstaben, Tiefhängern und Sonderzeichen in 54 Punkt. Beide Absätze aktivieren die Normalisierung standardmäßig. Der obere Abschnitt deaktiviert sie explizit; der untere erbt sie. Rahmen‑Größen, Ränder und Absatz‑Abstand sind identisch, Zeilenumbruch und Autofit sind deaktiviert, um den Vergleich konsistent zu halten. Das Beispiel gibt `False: False` und `NotDefined: True` aus und speichert „text_height_normalization.pptx“.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

Der untenstehende Vergleich wurde aus der gespeicherten Präsentation exportiert. Die obere Zeile hat die Normalisierung deaktiviert (`False`); die untere Zeile erbt die aktivierte Einstellung (`NotDefined` → `True`). Arial muss installiert sein, um das Aussehen reproduzieren zu können.

![Arial‑Text mit 54 Punkt, Normalisierung deaktiviert oben und geerbte Normalisierung aktiviert unten](text_height_normalization.png)

Die Normalisierung ändert die Zeichenhöhe, ohne den zugewiesenen [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/)-Wert zu verändern, der die Schriftgröße in Punkten angibt. Der Absatz‑[SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/)-Wert steuert den Zeilenabstand, während die Text‑Frame‑[AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) festlegt, wie Text oder sein Container sich anpassen. Diese Einstellungen dienen unterschiedlichen Zwecken und können das Gesamtlayout unabhängig voneinander beeinflussen. Weitere Informationen zur Absatzformatierung und Vererbung finden Sie unter [Manage Paragraph](/slides/de/net/manage-paragraph/).

## **Durchstreichen anwenden und entfernen**

Verwenden Sie [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) auf einem Textabschnitt, um Korrekturen, durchgestrichene Begriffe oder frühere Preise anzuzeigen, ohne den Originaltext zu löschen. Setzen Sie ihn auf [TextStrikethroughType.Single oder Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/), um eine bzw. zwei Durchstreich‑Linien zu erzeugen.

Um das Durchstreichen zu entfernen, weisen Sie `TextStrikethroughType.None` zu. Damit wird der Effekt explizit deaktiviert, selbst wenn das umgebende Format Durchstreichen angibt. Im Gegensatz dazu lässt `TextStrikethroughType.NotDefined` die lokale Einstellung undefiniert, sodass der Abschnitt Formatierungen erben kann, etwa vom Absatz. Das garantiert nicht, dass das Durchstreichen entfernt wird. Verwenden Sie [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), um die resultierende Formatierung, einschließlich geerbter Werte, zu lesen.

Das folgende eigenständige Beispiel erstellt drei Preisvergleiche. Jeder Absatz enthält separate Abschnitte für Bezeichnung, früheren Preis und aktuellen Preis, sodass nur der frühere Preis betroffen ist. Die erste Zeile wendet Durchstreichen an und entfernt es anschließend; die anderen Zeilen behalten einfaches bzw. doppeltes Durchstreichen bei. Durch Ändern dieser Eigenschaft bleibt der Text erhalten und andere Formatierungen, einschließlich des fetten früheren Preises, bleiben unverändert.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Durchstreichen anwenden, dann explizit vom ersten vorherigen Preis entfernen.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Das Ergebnis von oben nach unten: kein Durchstreichen, einfaches Durchstreichen und doppeltes Durchstreichen.

![Frühere Preise ohne Durchstreichen, mit einfachem Durchstreichen und mit doppeltem Durchstreichen](strikethrough.png)

## **Textrotation festlegen**

Verwenden Sie [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/), um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Das folgende Code‑Beispiel setzt die Textausrichtung in der Form auf [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), wodurch der Text **90 Grad gegen den Uhrzeigersinn** rotiert wird:

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

![Die Textrotation](text_rotation.png)

## **Ziffern nebeneinander in vertikalem Text anzeigen**

Um eine zweistellige Zahl in einer vertikalen japanischen Beschriftung zusammenzuhalten, platzieren Sie beide Ziffern in einem Textabschnitt und setzen Sie [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) für diesen Abschnitt. Das Beispiel verwendet [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) und 40 Punkt MS Gothic für beide Beschriftungen. Nur der Wert von [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) im numerischen Abschnitt unterscheidet sich.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

In PowerPoint zeigt die linke Beschriftung (`True`) die Ziffern aufrecht und nebeneinander zwischen 和 und 年. In der rechten Beschriftung (`False`) wird das Paar um 90 Grad im Uhrzeigersinn gedreht. Die umgebenden japanischen Zeichen bleiben in beiden Beschriftungen aufrecht.

![PowerPoint‑Vergleich vertikaler Datums‑Beschriftungen mit aufrechten Ziffern links und gedrehten Ziffern rechts.](vertical_date.png)

## **Benutzerdefinierte Rotation für Text‑Frames festlegen**

Verwenden Sie [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/), um einen benutzerdefinierten Rotationswinkel für ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) festzulegen.

Das nachstehende Code‑Beispiel rotiert den Text‑Frame um 3 Grad im Uhrzeigersinn innerhalb der Form:

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

![Die benutzerdefinierte Textrotation](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides bietet [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) und [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) zur Steuerung des Absatzabstands. Diese Eigenschaften werden wie folgt verwendet:

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

Regeln für den Zeilenumbruch in Absätzen sind nützlich in schmalen Textblöcken und Präsentationen, die lateinischen und ostasiatischen Text mischen. Die folgenden Eigenschaften gehören zu [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), sodass sie für einen gesamten Absatz gelten:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) steuert die Zeilenumbruch‑Regeln für Lateinisch. Bei gemischtem Text kann eine Änderung auch das Zeilen‑Umbruch‑Verhalten von benachbartem ostasiatischem Text und Satzzeichen beeinflussen.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) steuert die Zeilenumbruch‑Regeln für Ostasiatisch, einschließlich Beschränkungen für Zeichen am Anfang bzw. Ende einer Zeile.

Diese Regeln ersetzen nicht [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), das automatischen Zeilenumbruch innerhalb eines Textfelds aktiviert. Sie beeinflussen das Layout, wenn Zeilenumbruch auftritt; sie fügen keine Zeilenumbruch‑Zeichen ein. Ein expliziter Zeilenumbruch erzwingt eine neue Zeile im Absatz, unabhängig von der verfügbaren Breite.

Das folgende eigenständige Beispiel erstellt einen schmalen Textblock mit chinesischem und lateinischem Text. Es setzt beide Zeilenumbruch‑Eigenschaften explizit und speichert „line_breaking.pptx“. Um eine der Regeln zu testen, ändern Sie deren Wert, während die andere Einstellung unverändert bleibt. Das Beispiel verwendet 24 Punkt Arial und SimSun, einen Rahmen von 160 Punkt Breite und horizontale Text‑Frame‑Ränder von 0. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ist auf [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) gesetzt, sodass Textgröße und Rahmen‑Abmessungen fixiert bleiben.

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) ermöglicht es, dass zulässige Interpunktionszeichen über den rechten Rand der Textzeile hinausragen, anstatt in die nächste Zeile zu wechseln. Sie gilt für den gesamten Absatz und unterscheidet sich von einem hängenden Einzug.

Das folgende eigenständige Beispiel aktiviert hängende Interpunktion in einem 100 Punkt breiten Text‑Frame und speichert „hanging_punctuation.pptx“. Mit 24 Punkt Arial und horizontalen Text‑Frame‑Rändern von 0 bleibt der abschließende Punkt nach „sentence“ stehen und ragt über den rechten Textrand hinaus. Setzen Sie die Eigenschaft auf [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), um zu vergleichen: Mit dieser Einstellung nimmt der Punkt eine separate Zeile ein. Zeilenumbruch ist aktiviert und Autofit deaktiviert, um die verfügbare Breite festzuhalten.

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

Nicht jedes Interpunktionszeichen kann hängen. Die [oben beschriebenen Schrift‑ und Layout‑Bedingungen](#control-line-breaking) gelten ebenfalls für diesen Vergleich: Änderungen von Schrift, verfügbarer Breite, Rändern oder Autofit‑Einstellungen können den sichtbaren Unterschied entfernen.

## **Autofit‑Typ für Text‑Frames festlegen**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Behälters überschreitet. Nutzen Sie sie, um zu steuern, ob Text schrumpft, überläuft oder die Form automatisch anpasst. Das folgende Beispiel konfiguriert die Form so, dass sie sich an den Text anpasst, und speichert das Ergebnis als „autofit_type.pptx“.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Um nach automatischem Zeilenumbruch die Zeilen zu zählen und zu sehen, wie sich Text‑ oder Formbreite auf das Ergebnis auswirken, siehe [Count Rendered Lines](/slides/de/net/manage-paragraph/). Die Zeilenzahl allein sagt nicht aus, ob Text seinen Behälter überläuft.

## **Anker von Text‑Frames festlegen**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten. Das folgende Beispiel verankert den Text am unteren Rand der ersten Form und speichert das Ergebnis als „text_anchor.pptx“.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Tabulatoren für Text festlegen**

Verwenden Sie [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) und [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/), um Tabulatoren in einem Absatz zu konfigurieren. Das folgende Beispiel setzt das Standard‑Tab‑Intervall auf 100 Punkt und fügt einen linksbündigen Tab‑Stopp bei 30 Punkt hinzu. Diese Einstellungen beeinflussen Text, der Tabulator‑Zeichen enthält.

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

![Die Absatz‑Tabulatoren](paragraph_tabs.png)

## **Korrektursprache festlegen**

Aspose.Slides bietet [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), mit dem Sie die Korrektursprache für einen Textabschnitt festlegen können. Die Korrektursprache bestimmt die für Rechtschreib‑ und Grammatikprüfung in PowerPoint zu verwendende Sprache.

Das folgende Beispiel benötigt „presentation.pptx“ mit einem Textfeld als erster Form auf der ersten Folie und mindestens einen Absatz. Es ersetzt den Inhalt des ersten Absatzes durch „1。“, setzt SimSun als Schrift und weist die vereinfachte chinesische Korrektursprache (`zh-CN`) zu. Das Ergebnis wird als „proofing_language.pptx“ gespeichert:

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

// Setzen Sie die Korrektursprache auf vereinfachtes Chinesisch.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Sprach‑Metadaten kopieren**

Beim Kopieren mehrsprachiger Texte aus einer Vorlage sollten sowohl [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) als auch [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) erhalten bleiben. Das folgende eigenständige Beispiel erstellt einen Quell‑Abschnitt mit US‑Englisch als Sprache und Französisch als alternativer Sprache und kopiert Text und Kennungen in einen Abschnitt einer neuen Präsentation.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// Wenn die Quelle keine alternative Sprache hat, löscht null den Wert im Ziel.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Um eine Quelle ohne alternative Sprache zu testen, lassen Sie die Zuweisung von `"fr-FR"` weg. Der alternative Kennzeichner ist dann `null`, und dieselbe Kopieranweisung bewahrt dessen Fehlen, ohne einen Standardwert einzufügen, selbst wenn das Ziel zuvor eine alternative Sprache hatte.

Diese Kennungen speichern Sprach‑Metadaten. Das Beibehalten ändert nicht, welches Wörterbuch PowerPoint für Rechtschreib‑ oder Grammatikprüfungen auswählt.

## **Standardsprache festlegen**

Verwenden Sie [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/), um die Standardsprache für Text festzulegen, der beim Laden oder Erstellen einer Präsentation erzeugt wird. Das folgende Beispiel erstellt eine Präsentation mit US‑Englisch als Standard‑Textsprache, fügt ein Textfeld hinzu und gibt `en-US` für den ersten Textabschnitt aus.

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

Um standardmäßige Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Das folgende Beispiel setzt eine 14‑Punkt fette Schrift als Standard für Absatz‑Oberebenen in einer neuen Präsentation und speichert sie als „default_text_style.pptx“. Text kann diese Vorgaben erben, sofern keine spezifischere Formatierung sie überschreibt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Hole das Absatzformat der obersten Ebene.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt die Anwendung des **All Caps**‑Schrifteffekts, dass Text auf der Folie in Großbuchstaben angezeigt wird, obwohl er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides abrufen, liefert die Bibliothek den exakt eingegebenen Text zurück. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) und wandeln Sie die zurückgegebene Zeichenkette in Großbuchstaben um, wenn der Wert `All` ist.

Dieses Beispiel benötigt „sample2.pptx“ mit einem Textfeld als erster Form auf der ersten Folie. Der erste Absatz‑erste Abschnitt enthält „Hello, Aspose!“ mit angewendetem All‑Caps‑Effekt, wie unten gezeigt.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Das nachstehende Code‑Beispiel zeigt, wie der Text mit angewendetem **All Caps**‑Effekt extrahiert wird:

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

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) und die Absatzformatierung über [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Wie wende ich einer Textfläche in PowerPoint eine Farbverlauf‑Farbe an?**

Um einer Textfläche eine Farbverlauf‑Farbe zu geben, nutzen Sie [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Setzen Sie [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) auf [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) und konfigurieren Sie die Farbverlauf‑Stopps, Richtung und Transparenz.

Verwandte Funktion: [Format text within slides](/slides/de/features/text-formatting/).