---
title: PowerPoint-Text formatieren in C#
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
- Schriftart-Eigenschaften
- Schriftfamilie
- Textrotation
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
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text in PowerPoint- und OpenDocument-Präsentationen mithilfe von Aspose.Slides für .NET formatieren und gestalten. Passen Sie Schriftarten, Farben, Ausrichtungen und vieles mehr mit leistungsstarken C#-Codebeispielen an."
---

## **Übersicht**

Dieser Artikel führt ein, wie man Text in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für .NET verwaltet und formatiert. Sie lernen, wie Sie Textformatierungsfunktionen wie Schriftartauswahl, Größe, Farbe, Hervorhebung, Hintergrundfarbe, Abstand und Ausrichtung anwenden. Zusätzlich wird die Arbeit mit Textfeldern, Absätzen, Formatierung und erweiterten Layout‑Optionen wie benutzerdefinierter Drehung und Autofit‑Verhalten behandelt.

Egal, ob Sie Präsentationen programmgesteuert erzeugen oder vorhandene Inhalte anpassen, diese Beispiele helfen Ihnen, klare, professionell aussehende Textlayouts zu erstellen, die Ihre Folien verbessern und die Lesbarkeit erhöhen.

In den folgenden Beispielen verwenden wir die Datei **sample.pptx**, die auf der ersten Folie ein einzelnes Textfeld mit folgendem Inhalt enthält:

![Beispieltext](sample_text.png)

## **Text hervorheben**

Die [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/)‑Methode ermöglicht es, einen Textabschnitt mit einer Hintergrundfarbe basierend auf einem passenden Textmuster zu markieren.

So gehen Sie vor:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse mit einer Eingabedatei (PPT, PPTX, ODP usw.).
2. Greifen Sie über die [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑Sammlung auf die gewünschte Folie zu.
3. Greifen Sie über die [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)‑Sammlung auf das Ziel‑Shape zu und casten Sie es zu einem [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
4. Markieren Sie den gewünschten Text mittels der [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/)‑Methode, indem Sie den Beispieltext und die Farbe angeben.
5. Speichern Sie die Präsentation im gewünschten Ausgabeformat (z. B. PPT, PPTX, ODP).

Der untenstehende Code markiert alle Vorkommen der Zeichen **"try"** und des vollständigen Wortes **"to"**.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Erhalte die erste Form von der ersten Folie.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Markiere das Wort "try" in der Form.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Markiere das Wort "to" in der Form.
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

Aspose.Slides für .NET ermöglicht das Suchen und Hervorheben bestimmter Textteile in PowerPoint‑Folien mithilfe regulärer Ausdrücke. Diese Funktion ist besonders nützlich, wenn Sie Schlüsselwörter, Muster oder datenbasierte Inhalte dynamisch betonen möchten. Die [ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/)‑Methode erlaubt das Hervorheben von Textteilen mit einer Hintergrundfarbe anhand eines regulären Ausdrucks.

Der untenstehende Code markiert alle Wörter, die **sieben oder mehr Zeichen** enthalten:
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

Aspose.Slides für .NET ermöglicht es, Hintergrundfarben für ganze Absätze oder einzelne Textteile in PowerPoint‑Folien anzuwenden. Diese Funktion ist praktisch, wenn Sie bestimmte Wörter oder Phrasen hervorheben, Schlüsselbotschaften betonen oder die visuelle Attraktivität Ihrer Präsentationen steigern möchten.

Der folgende Code zeigt, wie die Hintergrundfarbe für den **gesamten Absatz** festgelegt wird: 
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setze die Hervorhebungsfarbe für den gesamten Absatz.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der graue Absatz](gray_paragraph.png)

Der untenstehende Code demonstriert, wie die Hintergrundfarbe für **Textabschnitte mit Fettschrift** festgelegt wird:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Setze die Hervorhebungsfarbe für den Textabschnitt.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Die grauen Textabschnitte](gray_text_portions.png)

## **Textabsätze ausrichten**

Die Textausrichtung ist ein entscheidender Aspekt der Folienformatierung, der sowohl die Lesbarkeit als auch die visuelle Anziehungskraft beeinflusst. In Aspose.Slides für .NET können Sie die Absatz‑Ausrichtung innerhalb von Textfeldern präzise steuern, sodass Ihr Inhalt konsistent präsentiert wird – zentriert, linksbündig, rechtsbündig oder im Blocksatz. Dieser Abschnitt erklärt, wie Sie die Textausrichtung in Ihren PowerPoint‑Präsentationen anwenden und anpassen.

Der folgende Code zeigt, wie der Absatz **mittig** ausgerichtet wird:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setze die Ausrichtung des Absatzes auf zentriert.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der ausgerichtete Absatz](aligned_paragraph.png)

## **Transparenz für Text festlegen**

Das Anpassen der Texttransparenz ermöglicht subtile visuelle Effekte und verbessert die Ästhetik von Folien. Aspose.Slides für .NET bietet die Möglichkeit, den Transparenzgrad von Absätzen und Textteilen festzulegen, sodass Text leicht mit Hintergründen verschmilzt oder bestimmte Elemente betont werden können. Dieser Abschnitt zeigt, wie Transparenzeinstellungen auf Text in Ihren Präsentationen angewendet werden.

Der untenstehende Code zeigt, wie die Transparenz für den **gesamten Absatz** angewendet wird:
```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setze die Füllfarbe des Textes auf eine transparente Farbe.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der transparente Absatz](transparent_paragraph.png)

Der folgende Code zeigt, wie die Transparenz für **Textabschnitte mit Fettschrift** angewendet wird:
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
            // Setze die Transparenz des Textabschnitts.
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

Aspose.Slides ermöglicht das Einstellen des Abstands zwischen Buchstaben in einem Textfeld. Damit können Sie die visuelle Dichte einer Zeile oder eines Textblocks durch Vergrößern oder Verkleinern des Zeichenabstands anpassen.

Der folgende C#‑Code zeigt, wie der Zeichenabstand im **gesamten Absatz** erweitert wird:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu verkleinern.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Zeichenabstand erweitern.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der Zeichenabstand im Absatz](character_spacing_in_paragraph.png)

Der untenstehende Code zeigt, wie der Zeichenabstand in **Textabschnitten mit Fettschrift** erweitert wird:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Hinweis: Verwenden Sie negative Werte, um den Zeichenabstand zu verkleinern.
            portion.PortionFormat.Spacing = 3;  // Zeichenabstand erweitern.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


Das Ergebnis:

![Der Zeichenabstand in den Textabschnitten](character_spacing_in_text_portions.png)

## **Textschriftart-Eigenschaften verwalten**

Aspose.Slides für .NET ermöglicht das feine Abstimmen von Schriftarteinstellungen sowohl auf Absatz‑ als auch auf Textebene, um visuelle Konsistenz zu gewährleisten und Design‑Anforderungen Ihrer Präsentation zu erfüllen. Sie können Schriftstil, Größe und weitere Formatierungsoptionen für ganze Absätze definieren, was Ihnen mehr Kontrolle über das Erscheinungsbild des Textes gibt. Dieser Abschnitt demonstriert, wie Schriftarteigenschaften für Textabsätze in einer Folie verwaltet werden.

Der folgende Code legt Schriftart und Textstil für den gesamten Absatz fest: Er wendet Schriftgröße, Fettdruck, Kursiv, punktierte Unterstreichung und die Schriftart Times New Roman auf alle Textabschnitte im Absatz an.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setze die Schriftarteigenschaften für den Absatz.
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

Der untenstehende Code wendet ähnliche Eigenschaften auf **Textabschnitte mit Fettschrift** an:
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Setze die Schriftarteigenschaften für den Textabschnitt.
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

![Die Schriftarteigenschaften für Textabschnitte](font_properties_for_text_portions.png)

## **Textdrehung festlegen**

Das Drehen von Text kann das Layout Ihrer Folien verbessern und bestimmte Inhalte hervorheben. Mit Aspose.Slides für .NET können Sie Text in Formen einfach rotieren und den Winkel an Ihr Design anpassen. Dieser Abschnitt zeigt, wie Sie die Textdrehung festlegen und steuern, um den gewünschten visuellen Effekt zu erzielen.

Der folgende Code setzt die Textausrichtung in der Form auf `Vertical270`, wodurch der Text **90 Grad gegen den Uhrzeigersinn** gedreht wird:
```cs
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

Das Festlegen eines benutzerdefinierten Drehwinkels für ein `TextFrame` ermöglicht es, Text in präzisen Winkeln zu positionieren und so kreativere und flexiblere Folien‑Designs zu realisieren. Aspose.Slides für .NET bietet vollständige Kontrolle über die Drehung von Textfeldern, sodass Text leicht mit anderen Folienelementen ausgerichtet werden kann. Dieser Abschnitt zeigt, wie ein spezifischer Drehwinkel auf ein `TextFrame` angewendet wird.

Der folgende Code dreht das Textfeld innerhalb der Form um **3 Grad im Uhrzeigersinn**:
```cs
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

Aspose.Slides stellt die Eigenschaften `SpaceAfter`, `SpaceBefore` und `SpaceWithin` der Klasse [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) bereit, mit denen der Zeilenabstand eines Absatzes verwaltet werden kann. Diese Eigenschaften werden wie folgt verwendet:

* Verwenden Sie einen positiven Wert, um den Zeilenabstand als Prozentsatz der Zeilenhöhe anzugeben.
* Verwenden Sie einen negativen Wert, um den Zeilenabstand in Punkten anzugeben.

Der folgende Code zeigt, wie der Zeilenabstand innerhalb des Absatzes festgelegt wird:
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

## **Autofit‑Typ für Textfelder festlegen**

Die `AutofitType`‑Eigenschaft bestimmt, wie sich Text verhält, wenn er die Grenzen seines Containers überschreitet. Aspose.Slides für .NET ermöglicht es, zu steuern, ob der Text schrumpfen, überlaufen oder die Form automatisch anpassen soll. Dieser Abschnitt demonstriert, wie der `AutofitType` für ein `TextFrame` festgelegt wird, um das Textlayout in Formen effektiv zu verwalten.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **Anker von Textfeldern festlegen**

Der Anker definiert, wie Text innerhalb einer Form vertikal positioniert wird. Mit Aspose.Slides für .NET können Sie den Anker‑Typ eines `TextFrame` festlegen, um Text am oberen, mittleren oder unteren Rand der Form auszurichten. Dieser Abschnitt zeigt, wie Sie die Anker‑Einstellungen anpassen, um die gewünschte vertikale Ausrichtung des Textinhalts zu erreichen.
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **Texttabulation festlegen**

Tabulation hilft, Text in gut strukturierten Layouts zu organisieren, indem konsistente Abstände zwischen Inhaltselementen hinzugefügt werden. Aspose.Slides für .NET unterstützt das Festlegen benutzerdefinierter Tabstopps innerhalb von Textabsätzen, was eine präzise Steuerung der Textpositionierung ermöglicht. Dieser Abschnitt demonstriert, wie Texttabulation für eine verbesserte Ausrichtung und Formatierung konfiguriert wird.
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

![Die Absatz-Tabulatoren](paragraph_tabs.png)

## **Rechtschreibsprache festlegen**

Aspose.Slides stellt die Eigenschaft `LanguageId` der Klasse [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) bereit, mit der die Korrektursprache für ein PowerPoint‑Dokument festgelegt werden kann. Die Korrektursprache bestimmt, welche Sprache für Rechtschreib‑ und Grammatikprüfungen in PowerPoint verwendet wird.

Der folgende Code zeigt, wie die Korrektursprache für einen Textabschnitt festgelegt wird:
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


## **Standardsprache festlegen**

Das Festlegen einer Standardsprache für Text stellt sicher, dass Rechtschreibprüfung, Silbentrennung und Text‑zu‑Sprache‑Funktionen in PowerPoint korrekt funktionieren. Aspose.Slides für .NET ermöglicht das Setzen der Sprache auf Text‑Absatz‑ oder Portionsebene. Dieser Abschnitt zeigt, wie die Standardsprache für den Text Ihrer Präsentation definiert wird.
```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Fügen Sie ein neues Rechteck-Shape mit Text hinzu.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Prüfen Sie die Sprache des ersten Textabschnitts.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```


## **Standard-Textstil festlegen**

Wenn Sie dieselbe Standard‑Textformatierung auf alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die Eigenschaft `DefaultTextStyle` des Interfaces [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) nutzen und Ihr bevorzugtes Format festlegen.

Der folgende Code setzt eine Standardschriftart mit Fettdruck und einer Größe von 14 pt für allen Text in allen Folien einer neuen Präsentation.
```cs
using (var presentation = new Presentation())
{
    // Hole das Absatzformat der obersten Ebene.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```


## **Text mit dem All‑Caps‑Effekt extrahieren**

In PowerPoint lässt der **All Caps**‑Schrifteffekt Text in Großbuchstaben auf der Folie erscheinen, selbst wenn er ursprünglich klein geschrieben wurde. Wenn Sie einen solchen Textabschnitt mit Aspose.Slides auslesen, liefert die Bibliothek den Text exakt so zurück, wie er eingegeben wurde. Um dies zu handhaben, prüfen Sie [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) — wenn er `All` anzeigt, konvertieren Sie den zurückgegebenen String einfach in Großbuchstaben, sodass Ihre Ausgabe dem entspricht, was Benutzer auf der Folie sehen.

Angenommen, wir haben das folgende Textfeld auf der ersten Folie der Datei **sample2.pptx**.

![Der All‑Caps‑Effekt](all_caps_effect.png)

Der folgende Code zeigt, wie der Text mit dem **All Caps**‑Effekt extrahiert wird:
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

**Wie kann man Text in einer Tabelle auf einer Folie ändern?**

Um Text in einer Tabelle auf einer Folie zu ändern, verwenden Sie das [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)-Objekt. Durchlaufen Sie alle Zellen der Tabelle und ändern Sie den Text jeder Zelle, indem Sie deren `TextFrame`‑ und `ParagraphFormat`‑Eigenschaften innerhalb jeder Zelle zugreifen.

**Wie kann man Farbverlauf auf Text in einer PowerPoint‑Folie anwenden?**

Um Farbverlauf auf Text anzuwenden, nutzen Sie die `FillFormat`‑Eigenschaft in [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/). Setzen Sie `FilFormat` auf `Gradient` und definieren Sie die Start‑ und Endfarben des Gradienten sowie weitere Eigenschaften wie Richtung und Transparenz, um den Farbeffekt auf den Text zu erzeugen.