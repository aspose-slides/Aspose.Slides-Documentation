---
title: Formatierung von Präsentationstext in .NET
linktitle: Textformatierung
type: docs
weight: 50
url: /de/net/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
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
- Textfeld-Anker
- Text-Tabulation
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Formatieren und gestalten Sie Text in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET. Passen Sie Schriftarten, Farben, Ausrichtung und mehr an."
---

## **Übersicht**

Dieser Artikel führt ein, wie man Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET verwaltet und formatiert. Sie lernen, wie Sie Textformatierungsfunktionen wie Schriftartauswahl, Größe, Farbe, Hervorhebung, Hintergrundfarbe, Abstand und Ausrichtung anwenden. Darüber hinaus wird die Arbeit mit Textfeldern, Absätzen, Formatierung und erweiterten Layout‑Optionen wie benutzerdefinierter Drehung und Autofit‑Verhalten behandelt.

Egal, ob Sie Präsentationen programmgesteuert erzeugen oder bestehende Inhalte anpassen – diese Beispiele helfen Ihnen, klare, professionell aussehende Textlayouts zu erstellen, die Ihre Folien aufwerten und die Lesbarkeit verbessern.

In den nachfolgenden Beispielen verwenden wir eine Datei namens **"sample.pptx"**, die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Text hervorheben**

Die [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/)‑Methode ermöglicht es, einen Textabschnitt mit einer Hintergrundfarbe basierend auf einem passenden Textbeispiel hervorzuheben.

So verwenden Sie die Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse mit einer Eingabedatei (PPT, PPTX, ODP usw.).
2. Greifen Sie über die [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑Sammlung auf die gewünschte Folie zu.
3. Greifen Sie über die [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)‑Sammlung auf das Ziel‑Shape zu und casten Sie es zu einer [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. Hervorheben Sie den gewünschten Text mit der [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/)‑Methode, indem Sie den Beispieltext und die Farbe angeben.
5. Speichern Sie die Präsentation im gewünschten Ausgabeformat (z. B. PPT, PPTX, ODP).

Der folgende Code hebt alle Vorkommen der Zeichen **"try"** und des vollständigen Wortes **"to"** hervor.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Holen Sie das erste Shape von der ersten Folie.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Hervorheben des Wortes "try" im Shape.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Hervorheben des Wortes "to" im Shape.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der hervorgehobene Text](highlighted_text.png)

{{% alert color="primary" %}} 
Aspose bietet einen einfachen, [KOSTENLOSEN Online-PowerPoint-Editor](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Text mit regulären Ausdrücken hervorheben**

Aspose.Slides für .NET ermöglicht das Suchen und Hervorheben bestimmter Textteile in PowerPoint‑Folien mithilfe regulärer Ausdrücke. Diese Funktion ist besonders nützlich, wenn Sie Schlüsselwörter, Muster oder datenabhängige Inhalte dynamisch betonen möchten. Die [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/)‑Methode ermöglicht es, Textteile mit einer Hintergrundfarbe anhand eines regulären Ausdrucks zu markieren.

Der nachfolgende Code hebt alle Wörter hervor, die **sieben oder mehr Zeichen** enthalten:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Alle Wörter mit sieben oder mehr Zeichen hervorheben.
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der hervorgehobene Text mit regulärem Ausdruck](highlighted_text_using_regex.png)

## **Hintergrundfarbe für Text festlegen**

Aspose.Slides für .NET ermöglicht das Anwenden von Hintergrundfarben auf ganze Absätze oder einzelne Textabschnitte in PowerPoint‑Folien. Diese Funktion ist praktisch, wenn Sie bestimmte Wörter oder Phrasen hervorheben, Schlüsselbotschaften betonen oder die visuelle Attraktivität Ihrer Präsentationen steigern möchten.

Das folgende Beispiel zeigt, wie Sie die Hintergrundfarbe für den **gesamten Absatz** festlegen: 
```cs
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

Der folgende Code demonstriert das Festlegen der Hintergrundfarbe für **Textabschnitte mit fetter Schrift**:
```cs
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

Die Ausrichtung von Text ist ein zentraler Aspekt der Folienformatierung, der sowohl die Lesbarkeit als auch die optische Wirkung beeinflusst. In Aspose.Slides für .NET können Sie die Absatz­ausrichtung in Textfeldern präzise steuern, sodass Ihr Inhalt konsistent dargestellt wird – zentriert, linksbündig, rechtsbündig oder Blocksatz. Dieser Abschnitt erklärt, wie Sie die Textausrichtung in Ihren PowerPoint‑Präsentationen anwenden und anpassen.

Das folgende Beispiel zeigt, wie Sie den Absatz **zentrieren**:
```cs
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

Das Anpassen der Texttransparenz ermöglicht subtile visuelle Effekte und verbessert die Ästhetik von Folien. Aspose.Slides für .NET bietet die Möglichkeit, den Transparenzgrad von Absätzen und Textabschnitten festzulegen, sodass Sie Text mühelos mit Hintergründen verschmelzen oder bestimmte Elemente betonen können. Dieser Abschnitt zeigt, wie Sie Transparenzeinstellungen für Text in Ihren Präsentationen anwenden.

Der folgende Code zeigt, wie Sie **den gesamten Absatz** transparent machen:
```cs
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

Das folgende Beispiel zeigt, wie Sie **Textabschnitte mit fetter Schrift** transparent machen:
```cs
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

Aspose.Slides ermöglicht das Festlegen des Abstands zwischen Buchstaben in einem Textfeld. So können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen vergrößern oder verkleinern.

Der folgende C#‑Code zeigt, wie Sie den Zeichenabstand im **gesamten Absatz** erweitern:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu komprimieren.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Zeichenabstand erweitern.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Der nachfolgende Code demonstriert die Erweiterung des Zeichenabstands in **Textabschnitten mit fetter Schrift**:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```


Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

## **Schrifteigenschaften von Text verwalten**

Aspose.Slides für .NET ermöglicht das feine Abstimmen von Schriftspezifikationen sowohl auf Absatz‑ als auch auf Textabschnittsebene, wodurch visuelle Konsistenz gewährleistet und Ihre Designanforderungen erfüllt werden. Sie können Schriftstile, -größen und weitere Formatierungsoptionen für gesamte Absätze definieren, was Ihnen mehr Kontrolle über das Erscheinungsbild des Textes gibt. Dieser Abschnitt demonstriert, wie Sie die Schrifteigenschaften für Textabsätze in einer Folie verwalten.

Der folgende Code setzt Schrift und Textstil für den gesamten Absatz: Er wendet Schriftgröße, Fett, Kursiv, gepunktete Unterstreichung und die Schriftart Times New Roman auf alle Textabschnitte im Absatz an.
```cs
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

![Die Schrifteigenschaften für den Absatz](font_properties_for_paragraph.png)

Der nachfolgende Code wendet ähnliche Eigenschaften auf **Textabschnitte mit fetter Schrift** an:
```cs
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

![Die Schrifteigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Textrotation festlegen**

Das Rotieren von Text kann das Layout Ihrer Folien verbessern und bestimmte Inhalte hervorheben. Mit Aspose.Slides für .NET können Sie Text in Shapes problemlos rotieren und den Winkel an Ihr Design anpassen. Dieser Abschnitt zeigt, wie Sie die Textrotation einstellen und steuern, um den gewünschten visuellen Effekt zu erzielen.

Der folgende Code setzt die Textausrichtung im Shape auf `Vertical270`, wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die Textrotation](text_rotation.png)

## **Benutzerdefinierte Rotation für TextFrames festlegen**

Das Festlegen eines benutzerdefinierten Rotationswinkels für ein `TextFrame` ermöglicht es, Text in präzisen Winkeln zu positionieren und somit kreativere und flexiblere Foliendesigns zu realisieren. Aspose.Slides für .NET bietet volle Kontrolle über die Rotation von TextFrames, sodass Sie Text leicht an anderen Elemente der Folie ausrichten können. Dieser Abschnitt führt Sie durch die Anwendung eines spezifischen Rotationswinkels auf ein `TextFrame`.

Der folgende Code dreht das TextFrame um 3 Grad im Uhrzeigersinn innerhalb des Shapes: 
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die benutzerdefinierte Textrotation](custom_text_rotation.png)

## **Zeilenabstand für Absätze festlegen**

Aspose.Slides stellt die Eigenschaften `SpaceAfter`, `SpaceBefore` und `SpaceWithin` in der Klasse [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) bereit, mit denen Sie den Zeilenabstand für einen Absatz verwalten können. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Der nachfolgende Code zeigt, wie Sie den Zeilenabstand innerhalb des Absatzes festlegen:
```cs
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

## **Autofit‑Typ für TextFrames festlegen**

Die Eigenschaft `AutofitType` bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Aspose.Slides für .NET ermöglicht es Ihnen, zu steuern, ob der Text verkleinert, überläuft oder die Form automatisch resized. Dieser Abschnitt demonstriert, wie Sie den `AutofitType` für ein `TextFrame` festlegen, um das Textlayout in Shapes effektiv zu verwalten.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **Anker für TextFrames festlegen**

Der Anker definiert, wie Text vertikal innerhalb einer Form positioniert wird. Mit Aspose.Slides für .NET können Sie den Ankertyp eines `TextFrame` setzen, um Text am oberen, mittleren oder unteren Rand der Form auszurichten. Dieser Abschnitt zeigt, wie Sie die Ankereinstellungen anpassen, um die gewünschte vertikale Ausrichtung des Textinhalts zu erreichen.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **Tabulatoren für Text festlegen**

Tabulatoren helfen, Text in gut strukturierten Layouts zu organisieren, indem sie konsistente Abstände zwischen Inhaltselementen hinzufügen. Aspose.Slides für .NET unterstützt das Festlegen benutzerdefinierter Tabstopps innerhalb von Textabsätzen, was eine präzise Kontrolle über die Textpositionierung ermöglicht. Dieser Abschnitt demonstriert, wie Sie Tabulatoren für Text konfigurieren, um die Ausrichtung und Formatierung zu verbessern.
```cs
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

![Die Absatz‑Tabulatoren](paragraph_tabs.png)

## **Rechtschreifsprache festlegen**

Aspose.Slides bietet die Eigenschaft `LanguageId` der Klasse [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/), mit der Sie die Rechtschreifsprache für ein PowerPoint‑Dokument festlegen können. Die Rechtschreifsprache bestimmt, welche Sprache für Rechtschreib‑ und Grammatikprüfungen in PowerPoint verwendet wird.

Der folgende Code zeigt, wie Sie die Rechtschreifsprache für einen Textabschnitt festlegen:
```cs
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

    // Setzen Sie die Id einer Korrektursprache.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```


## **Standard‑Sprache festlegen**

Die Angabe der Standardsprache für Text stellt sicher, dass Rechtschreibprüfung, Silbentrennung und Text‑zu‑Sprache‑Verhalten in PowerPoint korrekt funktionieren. Aspose.Slides für .NET ermöglicht das Festlegen der Sprache auf Text‑Abschnitts‑ oder Absatzebene. Dieser Abschnitt zeigt, wie Sie die Standardsprache für Ihren Präsentationstext definieren.
```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Fügen Sie ein neues Rechteck-Shape mit Text hinzu.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Überprüfen Sie die Sprache des ersten Textabschnitts.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```


## **Standard‑Textstil festlegen**

Wenn Sie dieselbe Standard‑Textformatierung auf alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die Eigenschaft `DefaultTextStyle` des Interfaces [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) nutzen und Ihr bevorzugtes Format definieren.

Der folgende Code zeigt, wie Sie für alle Texte in einer neuen Präsentation eine Standardschriftart **fett** mit Größe **14 pt** festlegen.
```cs
using (var presentation = new Presentation())
{
    // Abrufen des Absatzformats der obersten Ebene.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```


## **Text mit All‑Caps‑Effekt extrahieren**

In PowerPoint bewirkt der **All Caps**‑Schrifteffekt, dass Text in Großbuchstaben angezeigt wird, obwohl er ursprünglich in Kleinbuchstaben eingegeben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides auslesen, gibt die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um dies zu handhaben, prüfen Sie [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) – wenn er `All` anzeigt, konvertieren Sie die zurückgegebene Zeichenkette einfach in Großbuchstaben, sodass Ihre Ausgabe dem auf der Folie sichtbaren Text entspricht.

Nehmen wir an, wir haben das folgende Textfeld auf der ersten Folie der Datei **sample2.pptx**.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der folgende Code zeigt, wie Sie den Text mit dem **All Caps**‑Effekt extrahieren:
```cs
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

**Wie kann ich Text in einer Tabelle auf einer Folie bearbeiten?**

Um Text in einer Tabelle auf einer Folie zu bearbeiten, verwenden Sie das [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)-Objekt. Sie können durch alle Zellen der Tabelle iterieren und den Text in jeder Zelle ändern, indem Sie auf deren `TextFrame`‑ und `ParagraphFormat`‑Eigenschaften zugreifen.

**Wie kann ich Farbverläufe auf Text in einer PowerPoint‑Folien anwenden?**

Um Farbverläufe auf Text anzuwenden, benutzen Sie die `FillFormat`‑Eigenschaft im [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). Setzen Sie das `FilFormat` auf `Gradient` und definieren Sie die Start‑ und Endfarben des Gradienten sowie weitere Eigenschaften wie Richtung und Transparenz, um den Verlaufseffekt auf den Text zu erzeugen.