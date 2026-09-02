---
title: Präsentationstext formatieren in .NET
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
- Schriftarteigenschaften
- Schriftfamilie
- Textdrehung
- Drehwinkel
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeld-Anker
- Texttabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET. Passen Sie Schriftarten, Farben, Ausrichtung und mehr an."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET formatiert. Er behandelt Hintergrundfarben, Transparenz, Zeichenabstand, Schriftarteigenschaften, Drehung, Absatzabstand, Autofit‑Verhalten, Textausrichtung, Tabstopps und Spracheinstellungen.

In den nachfolgenden Beispielen verwenden wir die Datei „sample.pptx“, die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

Um wörtlichen Text oder reguläre Ausdrücke zu finden und zu markieren, siehe [Text suchen und ersetzen](/slides/de/net/search-and-replace-text/).

## **Texthintergrundfarbe festlegen**

Verwenden Sie [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/defaultportionformat/), um die Standard‑Hervorhebungsfarbe für einen Absatz festzulegen, oder [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/highlightcolor/) für einzelne Textabschnitte.

Der folgende Code demonstriert, wie die Hintergrundfarbe für den **gesamten Absatz** gesetzt wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Legen Sie die Hervorhebungsfarbe für den gesamten Absatz fest.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Der nachstehende Code zeigt, wie die Hintergrundfarbe für **Textabschnitte mit fetter Schrift** festgelegt wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Textabsätze ausrichten**

Verwenden Sie [IParagraphFormat.Alignment](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/alignment/), um die Absatzausrichtung innerhalb eines Textfeldes festzulegen. Der Wert kann z. B. zentriert, linksbündig, rechtsbündig, Blocksatz usw. sein.

Der folgende Code richtet den Absatz **zentriert** aus:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setzen Sie die Ausrichtung des Absatzes auf zentriert.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Transparenz für Text festlegen**

Die Texttransparenz wird über die Alpha‑Komponente der Farbe gesteuert, die [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/fillformat/) zugewiesen wird. In den nachfolgenden Beispielen ist `alpha = 50` ein ARGB‑Alpha‑Wert im Bereich 0–255, nicht ein Transparenz‑Prozentsatz.

Der folgende Code wendet Transparenz auf den **gesamten Absatz** an:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setzen Sie die Füllfarbe des Textes auf eine transparente Farbe.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Der folgende Code wendet Transparenz auf **Textabschnitte mit fetter Schrift** an:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Setzen Sie die Transparenz des Textabschnitts.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die transparenten Textabschnitte](transparent_text_portions.png)

## **Zeichenabstand für Text festlegen**

Verwenden Sie [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/spacing/), um den Abstand zwischen Zeichen in einem Textfeld zu vergrößern oder zu verkleinern.

Der folgende C#‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** vergrößert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Zeichenabstand vergrößern.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Der nachstehende Code demonstriert, wie der Zeichenabstand in **Textabschnitten mit fetter Schrift** vergrößert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
            portion.PortionFormat.Spacing = 3;  // Zeichenabstand vergrößern.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

### **Kerning für bestimmte Schriften deaktivieren**

In manchen Fällen kann Text, der von Aspose.Slides gerendert wird, etwas enger wirken als derselbe Text in PowerPoint. Das kann auftreten, weil PowerPoint Kerning‑Daten für bestimmte Schriften ignoriert, selbst wenn die Schrift gültige Kerning‑Informationen enthält und Kerning in den PowerPoint‑Einstellungen aktiviert ist.

Um das Rendering in solchen Fällen PowerPoint‑ähnlicher zu machen, können Sie Kerning für Textabschnitte deaktivieren, die die betroffene Schrift verwenden. Setzen Sie [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/kerningminimalsize/) auf einen Wert, der deutlich größer ist als die eigentliche Schriftgröße:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Diese Einstellung verhindert, dass Kerning auf die entsprechenden Textabschnitte angewendet wird, und kann helfen, das Rendering von Aspose.Slides an die visuelle Ausgabe von PowerPoint für betroffene Schriften anzupassen.

## **Schriftarteigenschaften von Text verwalten**

Schriftarteigenschaften können auf Absatzebene über [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/defaultportionformat/) oder auf einzelne Abschnitte über [IPortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iportionformat/) festgelegt werden.

Der folgende Code legt die Schrift und den Textstil für den gesamten Absatz fest: Er wendet Schriftgröße, Fett, Kursiv, gepunktete Unterstreichung und die Schriftart Times New Roman auf alle Abschnitte im Absatz an:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setzen Sie die Schriftarteigenschaften für den Absatz.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Schriftarteigenschaften für den Absatz](font_properties_for_paragraph.png)

Der nachstehende Code wendet ähnliche Eigenschaften auf **Textabschnitte mit fetter Schrift** an:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Das Ergebnis:

![Die Schriftarteigenschaften für die Textabschnitte](font_properties_for_text_portions.png)

## **Textdrehung festlegen**

Verwenden Sie [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/textverticaltype/), um eine vordefinierte Textausrichtung innerhalb einer Form festzulegen.

Der folgende Code setzt die Textrichtung in der Form auf `Vertical270`, wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Textdrehung](text_rotation.png)

## **Benutzerdefinierte Drehung für Textfelder festlegen**

Verwenden Sie [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/rotationangle/), um einen benutzerdefinierten Drehwinkel für ein [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) festzulegen.

Der nachstehende Code dreht das Textfeld innerhalb der Form um 3 Grad im Uhrzeigersinn:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die benutzerdefinierte Textdrehung](custom_text_rotation.png)

## **Zeilenabstand von Absätzen festlegen**

Aspose.Slides stellt [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/spacebefore/) und [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/spacewithin/) bereit, um den Absatzabstand zu steuern. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Der folgende Code legt den Zeilenabstand innerhalb des Absatzes fest:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Der Zeilenabstand im Absatz](line_spacing.png)

## **Autofit‑Typ für Textfelder festlegen**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/autofittype/) bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Nutzen Sie es, um zu steuern, ob der Text schrumpft, überläuft oder die Form automatisch resized.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Anker von Textfeldern festlegen**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/anchoringtype/) definiert, wie Text vertikal innerhalb einer Form positioniert wird, z. B. oben, mittig oder unten.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Texttabulation festlegen**

Verwenden Sie [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/defaulttabsize/) und [IParagraphFormat.Tabs](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/tabs/), um Tabstopps in einem Absatz zu konfigurieren.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Das Ergebnis:

![Die Absatz‑Tabstopps](paragraph_tabs.png)

## **Rechtschreibsprache festlegen**

Aspose.Slides stellt [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/languageid/) bereit, mit dem Sie die Rechtschreibsprache für einen Textabschnitt festlegen können. Die Rechtschreibsprache bestimmt, welche Sprache für Rechtschreib‑ und Grammatikprüfungen in PowerPoint verwendet wird.

Der folgende Code zeigt, wie die Rechtschreibsprache für einen Textabschnitt festgelegt wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Setzen Sie die Id einer Rechtschreibsprache.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Standard‑Sprache festlegen**

Verwenden Sie [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/defaulttextlanguage/), um die Standardsprache für beim Laden oder Erstellen einer Präsentation erzeugten Text festzulegen.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Fügen Sie ein neues Rechteck-Shape mit Text hinzu.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Prüfen Sie die Sprache des ersten Abschnitts.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Standard‑Textstil festlegen**

Um die Standard‑Textformatierung auf Präsentationsebene anzuwenden, verwenden Sie [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/defaulttextstyle/).

Der folgende Code legt für alle Texte in einer neuen Präsentation eine Standardschriftart fett mit einer Größe von 14 pt fest.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // Erhalte das Absatzformat der obersten Ebene.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Text mit dem Großschrifts‑Effekt extrahieren**

In PowerPoint sorgt der Schriftarteffekt **All Caps** dafür, dass Text auf der Folie in Großbuchstaben angezeigt wird, obwohl er ursprünglich klein geschrieben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides auslesen, liefert die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um den angezeigten Text zu erhalten, prüfen Sie [TextCapType](https://reference.aspose.com/slides/de/net/aspose.slides/textcaptype/) und konvertieren Sie die zurückgegebene Zeichenkette in Großbuchstaben, wenn der Wert `All` ist.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei sample2.pptx.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der nachstehende Code extrahiert den Text mit angewendetem **All Caps**‑Effekt:

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Ausgabe:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/). Durchlaufen Sie die Zellen und aktualisieren Sie jede Zelle über [ICell.TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/icell/textframe/) sowie die Absatzformatierung über [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/paragraphformat/).

**Wie kann man einem Text in einer PowerPoint‑Folie eine Farbverlauf‑Füllung zuweisen?**

Um einem Text einen Farbverlauf zuzuweisen, verwenden Sie [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/fillformat/). Setzen Sie [IFillFormat.FillType](https://reference.aspose.com/slides/de/net/aspose.slides/ifillformat/filltype/) auf [FillType.Gradient](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) und konfigurieren Sie die Farbverlaufsstopps, Richtung und Transparenz.