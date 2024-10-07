```markdown
---
title: Textformatierung
linktitle: Textformatierung
type: docs
weight: 50
url: /net/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Textabsätze ausrichten
- Texttransparenz
- Absatzschrifteigenschaften
- Schriftfamilie
- Textrotation
- benutzerdefinierte Winkelrotation
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeldanker
- Texttabulator
- standardmäßiger Textstil
- C#
- Aspose.Slides für .NET
description: "Verwalten und Manipulieren von Text- und Textfeldeigenschaften in C#"
---

## Übersicht

Dieser Artikel beschreibt, wie man **mit der Textformatierung von PowerPoint-Präsentationen in C# arbeitet** z.B. Text hervorheben, einen regulären Ausdruck anwenden, Textabsätze ausrichten, die Texttransparenz einstellen, die Schrifteigenschaften von Absätzen ändern, Schriftfamilien verwenden, eine Textrotation festlegen, einen Winkel anpassen, ein Textfeld verwalten, den Zeilenabstand einstellen, die Autofit-Eigenschaft verwenden, einen Textfeldanker setzen, die Texttabulierung ändern. Der Artikel behandelt diese Themen.

## **Text Hervorheben**
Die neue HighlightText-Methode wurde zum ITextFrame-Interface und zur TextFrame-Klasse hinzugefügt.

Es ermöglicht, einen Teil des Textes mit einer Hintergrundfarbe hervorzuheben, ähnlich dem Text-Hervorheben-Werkzeug in PowerPoint 2019.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse mit einer Eingabedatei.
   - Die Eingabedatei kann PPT, PPTX, ODP usw. sein.
3. Greifen Sie auf den entsprechenden Folien zu, indem Sie die [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) Sammlung verwenden.
4. Greifen Sie auf die Form zu, indem Sie die [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) Sammlung als [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) verwenden.
5. Heben Sie den Text mit der [TextFrame.Highlight()](https://reference.aspose.com/slides/net/aspose.slides/textframe/highlighttext/#highlighttext) Methode hervor.
6. Speichern Sie die Präsentation im gewünschten Ausgabeformat, d.h. PPT, PPTX oder ODP usw.

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // hebt alle Wörter 'wichtig' hervor
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // hebt alle separaten Vorkommen von 'the' hervor
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Aspose bietet einen einfachen, [kostenlosen Online PowerPoint-Bearbeitungsdienst](https://products.aspose.app/slides/editor)

{{% /alert %}} 


## **Text Hervorheben mit Regulärem Ausdruck**
Die neue HighlightRegex-Methode wurde zum ITextFrame-Interface und zur TextFrame-Klasse hinzugefügt.

Es ermöglicht, einen Teil des Textes mit einer Hintergrundfarbe zu markieren, indem ein regulärer Ausdruck verwendet wird, ähnlich dem Text-Hervorheben-Werkzeug in PowerPoint 2019.

Der folgende Codeausschnitt zeigt, wie Sie diese Funktion verwenden:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // hebt alle Wörter mit 10 oder mehr Zeichen hervor
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```

## **Text-Hintergrundfarbe Festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Farbe für den Hintergrund eines Textes anzugeben.

Dieser C#-Code zeigt Ihnen, wie Sie die Hintergrundfarbe für einen gesamten Text festlegen:

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Schwarz");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Rot ");
    
    var portion3 = new Portion("Schwarz");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    foreach (IPortion portion in autoShape.TextFrame.Paragraphs[0].Portions)
    {
        portion.PortionFormat.HighlightColor.Color = Color.Blue;
    }

    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

Dieser C#-Code zeigt Ihnen, wie Sie die Hintergrundfarbe nur für einen Teil eines Textes festlegen:

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Schwarz");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Rot ");
    
    var portion3 = new Portion("Schwarz");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    IPortion redPortion = autoShape.TextFrame.Paragraphs[0].Portions
        .First(p => p.Text.Contains("Rot"));

    redPortion.PortionFormat.HighlightColor.Color = Color.Red;
    
    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

## **Textabsätze Ausrichten**

Textformatierung ist eines der entscheidenden Elemente bei der Erstellung jeglicher Art von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für .NET das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema werden wir sehen, wie wir die Ausrichtung von Textabsätzen in einer Folie steuern können. Bitte folgen Sie den folgenden Schritten, um Textabsätze mit Aspose.Slides für .NET auszurichten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und typisieren Sie diese als AutoShape.
4. Holen Sie sich den Absatz (der ausgerichtet werden muss) aus dem von AutoShape bereitgestellten TextFrame.
5. Richten Sie den Absatz aus. Ein Absatz kann nach rechts, links, zentriert und gerecht ausgerichtet werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird unten dargestellt.

```c#
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // Zugriff auf die erste Folie
    ISlide slide = pres.Slides[0];

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Ändern Sie den Text in beiden Platzhaltern
    tf1.Text = "Zentrieren mit Aspose";
    tf2.Text = "Zentrieren mit Aspose";

    // Erhalten des ersten Absatzes der Platzhalter
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Ausrichten des Textabsatzes zur Mitte
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    // Schreiben Sie die Präsentation als PPTX-Datei
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```

## **Texttransparenz Festlegen**
Dieser Artikel zeigt, wie die Transparenzeigenschaft für irgendeine Textform mit Aspose.Slides für .NET festgelegt werden kann. Um die Transparenz für Text festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie.
3. Setzen Sie die Schattenfarbe.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte ist unten angegeben.

```c#
using (Presentation pres = new Presentation("transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - Transparenz ist: {((float)shadowColor.A / byte.MaxValue) * 100}");

    // Setzen Sie die Transparenz auf null Prozent
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **Zeichenabstand für Text Festlegen**

Aspose.Slides erlaubt es Ihnen, den Abstand zwischen Buchstaben in einem Textfeld festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen erweitern oder verengen.

Dieser C#-Code zeigt Ihnen, wie Sie den Abstand für eine Textzeile erhöhen und den Abstand für eine andere Zeile verringern:

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape) presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape) presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // erweitern
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // verringern

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Schrifteigenschaften des Absatzes Verwalten**

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, entweder um bestimmte Abschnitte und Wörter hervorzuheben oder um den Unternehmensrichtlinien zu entsprechen. Die Textformatierung hilft den Benutzern, das Aussehen und das Gefühl des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie man Aspose.Slides für .NET verwendet, um die Schrifteigenschaften von Textabsätzen auf Folien zu konfigurieren. Um die Schrifteigenschaften eines Absatzes mit Aspose.Slides für .NET zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und typisieren Sie diese zu AutoShape.
4. Holen Sie sich den Absatz aus dem von AutoShape bereitgestellten TextFrame.
5. Rechtfertigen Sie den Absatz.
6. Greifen Sie auf die Textportion eines Absatzes zu.
7. Definieren Sie die Schriftart mit FontData und setzen Sie entsprechend die Schrift des Textanteils.
   1. Setzen Sie die Schriftart auf fett.
   2. Setzen Sie die Schriftart auf kursiv.
8. Setzen Sie die Schriftfarbe mithilfe des FillFormat, das vom Portion-Objekt bereitgestellt wird.
9. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Die Implementierung der obigen Schritte wird unten dargestellt. Es nimmt eine schlichte Präsentation und formatiert die Schriftarten auf einer der Folien.

```c#
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // Zugang zu einer Folie durch ihre Folienposition
    ISlide slide = pres.Slides[0];

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typumwandlung zu AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Zugriff auf den ersten Absatz
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Zugriff auf die erste Portion
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // Definieren neuer Schriftarten
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Neue Schriftarten dem Anteil zuweisen
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // Schrift auf fett setzen
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // Schrift auf kursiv setzen
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // Schriftfarbe setzen
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    // Schreiben Sie die PPTX auf die Festplatte
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```


## **Familie der Schriftarten von Text Verwalten**
Eine Portion wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie man Aspose.Slides für .NET verwendet, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene andere Eigenschaften der Schriftfamilie zu definieren. Um ein Textfeld zu erstellen und die Schrifteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
4. Entfernen Sie den mit der AutoShape verbundenen Füllstil.
5. Greifen Sie auf das TextFrame der AutoShape zu.
6. Fügen Sie dem TextFrame etwas Text hinzu.
7. Greifen Sie auf das Portion-Objekt zu, das mit dem TextFrame assoziiert ist.
8. Definieren Sie die zu verwendende Schriftart für die Portion.
9. Setzen Sie andere Schrifteigenschaften wie fett, kursiv, unterstrichen, Farbe und Höhe mithilfe der relevanten Eigenschaften, die vom Portion-Objekt bereitgestellt werden.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird unten dargestellt.

```c#
// Instanziieren Sie die Präsentation
using (Presentation presentation = new Presentation())
{
   
    // Erhalten Sie die erste Folie
    ISlide sld = presentation.Slides[0];

    // Fügen Sie eine AutoShape vom Rechtecktyp hinzu
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Entfernen Sie jeden mit der AutoShape verbundenen Füllstil
    ashp.FillFormat.FillType = FillType.NoFill;

    // Greifen Sie auf das TextFrame der AutoShape zu
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "Aspose TextBox";

    // Greifen Sie auf die Portion zu, die mit dem TextFrame verbunden ist
    IPortion port = tf.Paragraphs[0].Portions[0];

    // Setzen Sie die Schriftart für die Portion
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // Setzen Sie den Fettstil der Schriftart
    port.PortionFormat.FontBold = NullableBool.True;

    // Setzen Sie den Kursivstil der Schriftart
    port.PortionFormat.FontItalic = NullableBool.True;

    // Setzen Sie den Unterstrichstil der Schriftart
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // Setzen Sie die Höhe der Schrift
    port.PortionFormat.FontHeight = 25;

    // Setzen Sie die Farbe der Schrift
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Schreiben Sie die PPTX auf die Festplatte 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```

## **Schriftgröße für Text Festlegen**

Aspose.Slides ermöglicht es Ihnen, die von Ihnen bevorzugte Schriftgröße für vorhandenen Text in einem Absatz und andere Texte, die möglicherweise später zum Absatz hinzugefügt werden, auszuwählen.

Dieser C#-Code zeigt Ihnen, wie Sie die Schriftgröße für Texte in einem Absatz festlegen:

```c#
var presentation = new Presentation("example.pptx");

// Erhält die erste Form, zum Beispiel.
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape autoShape)
{
    // Erhält den ersten Absatz, zum Beispiel.
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setzt die Standard-Schriftgröße auf 20 pt für alle Textanteile im Absatz. 
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

    // Setzt die Schriftgröße auf 20 pt für die aktuellen Textanteile im Absatz. 
    foreach (var portion in paragraph.Portions)
    {
        portion.PortionFormat.FontHeight = 20;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Textrotation Festlegen**

Aspose.Slides für .NET ermöglicht Entwicklern, den Text zu rotieren. Text kann so eingestellt werden, dass er horizontal, vertikal, vertikal270, WordArtVertical, EastAsianVertical, MongolianVertical oder WordArtVerticalRightToLeft angezeigt wird. Um den Text eines TextFrames zu rotieren, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Rotieren Sie den Text.
6. Speichern Sie die Datei auf der Festplatte.

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Erhalten Sie die erste Folie 
ISlide slide = presentation.Slides[0];

// Fügen Sie eine AutoShape vom Rechtecktyp hinzu
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Fügen Sie dem Rechteck ein TextFrame hinzu
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Zugriff auf das Textfeld
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

// Erstellen Sie das Absatzobjekt für das Textfeld
IParagraph para = txtFrame.Paragraphs[0];

// Erstellen Sie das Portion-Objekt für den Absatz
IPortion portion = para.Portions[0];
portion.Text = "Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Speichern Sie die Präsentation
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```


## **Benutzerdefinierter Rotationswinkel für TextFrame Festlegen**
Aspose.Slides für .NET unterstützt jetzt das Setzen eines benutzerdefinierten Rotationswinkels für Textframes. In diesem Thema werden wir sehen, wie wir die RotationAngle-Eigenschaft in Aspose.Slides festlegen können. Die neue Eigenschaft RotationAngle wurde zu den IChartTextBlockFormat und ITextFrameFormat-Interfaces hinzugefügt und ermöglicht es, den benutzerdefinierten Rotationswinkel für das Textfeld festzulegen. Um die RotationAngle-Eigenschaft festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Fügen Sie auf der Folie ein Diagramm hinzu.
3. Setzen Sie die RotationAngle-Eigenschaft.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Im unten stehenden Beispiel setzen wir die RotationAngle-Eigenschaft.

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Benutzerdefinierter Titel").TextFrameFormat.RotationAngle = -30;

// Speichern Sie die Präsentation
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```


## **Zeilenabstand des Absatzes**
Aspose.Slides bietet Eigenschaften ([SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spaceafter), [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacebefore), und [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacewithin)) unter der [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) Klasse, die es Ihnen ermöglichen, den Zeilenabstand für einen Absatz zu verwalten. Die drei Eigenschaften werden folgendermaßen verwendet:

* Um den Zeilenabstand für einen Absatz in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Absatz in Punkten anzugeben, verwenden Sie einen negativen Wert.

Zum Beispiel können Sie einen Zeilenabstand von 16pt für einen Absatz anwenden, indem Sie die `SpaceBefore`-Eigenschaft auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die eine AutoShape mit etwas Text enthält.
2. Erhalten Sie eine Folienreferenz über ihren Index.
3. Greifen Sie auf das Textfeld zu.
4. Greifen Sie auf den Absatz zu.
5. Setzen Sie die Eigenschaften des Absatzes.
6. Speichern Sie die Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie den Zeilenabstand für einen Absatz festlegen:

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation("Fonts.pptx");

// Erhalten Sie eine Folienreferenz durch ihren Index
ISlide sld = presentation.Slides[0];

// Greifen Sie auf das Textfeld zu
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// Greifen Sie auf den Absatz zu
IParagraph para1 = tf1.Paragraphs[0];

// Setzen Sie die Eigenschaften des Absatzes
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// Speichern Sie die Präsentation
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```


## **Die AutofitType-Eigenschaft für TextFrame Festlegen**
In diesem Thema werden wir die verschiedenen Formatierungseigenschaften von Textfeldern erkunden. Dieser Artikel behandelt, wie Sie die AutofitType-Eigenschaft des Textfeldes, den Anker des Textes und die Rotation des Textes in der Präsentation festlegen. Aspose.Slides für .NET ermöglicht es Entwicklern, die AutofitType-Eigenschaft eines Textfelds festzulegen. Die AutofitType kann auf Normal oder Shape gesetzt werden. Wenn es auf Normal eingestellt ist, bleibt die Form gleich, während der Text angepasst wird, ohne dass die Form selbst verändert wird. Wenn die AutofitType hingegen auf Shape gesetzt ist, wird die Form so modifiziert, dass nur der erforderliche Text darin enthalten ist. Um die AutofitType-Eigenschaft eines Textfeldes festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Setzen Sie den AutofitType des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Greifen Sie auf die erste Folie zu 
ISlide slide = presentation.Slides[0];

// Fügen Sie eine AutoShape vom Rechtecktyp hinzu
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Fügen Sie dem Rechteck ein TextFrame hinzu
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Zugriff auf das Textfeld
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Erstellen Sie das Absatzobjekt für das Textfeld
IParagraph para = txtFrame.Paragraphs[0];

// Erstellen Sie das Portion-Objekt für den Absatz
IPortion portion = para.Portions[0];
portion.Text = "Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Speichern Sie die Präsentation
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```


## **Anker des TextFrame Festlegen**
Aspose.Slides für .NET ermöglicht es Entwicklern, den Anker eines beliebigen TextFrames festzulegen. TextAnchorType gibt an, wo dieser Text in der Form platziert ist. TextAnchorType kann auf Top, Center, Bottom, Justified oder Distributed eingestellt werden. Um den Anker eines TextFrames festzulegen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Form hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Setzen Sie den TextAnchorType des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Erhalten Sie die erste Folie 
ISlide slide = presentation.Slides[0];

// Fügen Sie eine AutoShape vom Rechtecktyp hinzu
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Fügen Sie dem Rechteck ein TextFrame hinzu
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Zugriff auf das Textfeld
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// Erstellen Sie das Absatzobjekt für das Textfeld
IParagraph para = txtFrame.Paragraphs[0];

// Erstellen Sie das Portion-Objekt für den Absatz
IPortion portion = para.Portions[0];
portion.Text = "Ein schneller brauner Fuchs springt über den faulen Hund. Ein schneller brauner Fuchs springt über den faulen Hund.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Speichern Sie die Präsentation
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **Texttabulation Festlegen**
- Die EffectiveTabs.ExplicitTabCount (in unserem Fall 2) Eigenschaft entspricht der Tabs.Count.
- Die EffectiveTabs-Sammlung umfasst alle Tabs (von der Tabs-Sammlung und den Standard-Tabs).
- Die EffectiveTabs.ExplicitTabCount (in unserem Fall 2) Eigenschaft entspricht der Tabs.Count.
- Die EffectiveTabs.DefaultTabSize (294) Eigenschaft zeigt den Abstand zwischen den Standard-Tabs (3 und 4 in unserem Beispiel).
- EffectiveTabs.GetTabByIndex(index) mit index = 0 gibt das erste explizite Tab (Position = 731) zurück, index = 1 - das zweite Tab (Position = 1241). Wenn Sie versuchen, das nächste Tab mit index = 2 zu erhalten, wird das erste Standard-Tab (Position = 1470) zurückgegeben usw.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um die nächste Tabulation nach einem Text zu holen. Zum Beispiel haben Sie den Text: "Helloworld!". Um diesen Text darzustellen, sollten Sie wissen, wo Sie "world!" zu ziehen beginnen. Zunächst sollten Sie die Länge von "Hello" in Pixeln berechnen und GetTabAfterPosition mit diesem Wert aufrufen. Sie erhalten die nächste Tab-Position, um "world!" zu zeichnen.

## **Nachweis-Sprache Festlegen**

Aspose.Slides bietet die [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) Eigenschaft (bereitsgestellt von der [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) Klasse), um Ihnen zu ermöglichen, die Nachweis-Sprache für ein PowerPoint-Dokument festzulegen. Die Nachweis-Sprache ist die Sprache, für die Rechtschreibfehler und Grammatik in PowerPoint überprüft werden.

Dieser C#-Code zeigt Ihnen, wie Sie die Nachweis-Sprache für eine PowerPoint festlegen:

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // setzen Sie die ID einer Nachweis-Sprache
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Standard-Sprache Festlegen**

Dieser C#-Code zeigt Ihnen, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen: 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Fügt eine neue Rechteckform mit Text hinzu
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Neuer Text";
    
    // Überprüft die Sprache des ersten Anteils
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```

## **Standard-Textstil Festlegen**

Wenn Sie dasselbe standardmäßige Textformat für alle Textelemente einer Präsentation gleichzeitig anwenden müssen, können Sie die `DefaultTextStyle`-Eigenschaft aus dem [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) Interface verwenden und die bevorzugte Formatierung festlegen. Der folgende Code zeigt, wie Sie die standardmäßige fette Schriftart (14 pt) für den Text auf allen Folien in einer neuen Präsentation festlegen.

```c#
using (Presentation presentation = new Presentation())
{
    // Holen Sie sich das oberste Absatzformat.
    IParagraphFormat paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("DefaultTextStyle.pptx", SaveFormat.Pptx);
}
```