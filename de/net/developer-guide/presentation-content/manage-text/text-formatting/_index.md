---
title: Textformatierung
linktitle: Textformatierung
type: docs
weight: 50
url: /de/net/text-formatting/
keywords:
- Text hervorheben
- regulärer Ausdruck
- Textabsätze ausrichten
- Texttransparenz
- Schriftart-Eigenschaften des Absatzes
- Schriftfamilie
- Textrotation
- benutzerdefinierte Winkelrotation
- Textfeld
- Zeilenabstand
- Autofit-Eigenschaft
- Textfeldanker
- Texttabulierung
- Standardtextstil
- C#
- Aspose.Slides für .NET
description: "Verwalten und Manipulieren von Text- und Textfeldeigenschaften in C#"
---

## Übersicht

Dieser Artikel beschreibt, wie man **mit der Textformatierung von PowerPoint-Präsentationen in C# arbeitet**, z.B. Text hervorheben, einen regulären Ausdruck anwenden, Textabsätze ausrichten, die Texttransparenz festlegen, die Schriftart-Eigenschaften von Absätzen ändern, Schriftfamilien verwenden, eine Textrichtung einstellen, eine Winkelrotation anpassen, ein Textfeld verwalten, den Zeilenabstand einstellen, die Autofit-Eigenschaft verwenden, einen Textfeldanker festlegen und die Texttabulierung ändern. Der Artikel behandelt diese Themen.

## **Text hervorheben**
Die neue HighlightText-Methode wurde zur ITextFrame-Schnittstelle und zur TextFrame-Klasse hinzugefügt.

Sie ermöglicht es, einen Textteil mit Hintergrundfarbe zu kennzeichnen, ähnlich wie das Werkzeug Textmarkerfarbe in PowerPoint 2019.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse mit der Eingabedatei.
   - Die Eingabedatei kann PPT, PPTX, ODP usw. sein.
3. Greifen Sie über die [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) Sammlung auf die Folie zu.
4. Greifen Sie über die [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) Sammlung auf die Form zu als [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).
5. Heben Sie den Text mit der [TextFrame.Highlight()](https://reference.aspose.com/slides/net/aspose.slides/textframe/highlighttext/#highlighttext) Methode hervor.
6. Speichern Sie die Präsentation im gewünschten Ausgabeformat, d.h. PPT, PPTX oder ODP usw.

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // hebt alle Wörter 'wichtig' hervor
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // hebt alle separaten 'die' Vorkommen hervor
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Aspose bietet einen einfachen, [kostenlosen Online PowerPoint-Bearbeitungsdienst](https://products.aspose.app/slides/editor)

{{% /alert %}} 


## **Text hervorheben mit regulärem Ausdruck**
Die neue HighlightRegex-Methode wurde zur ITextFrame-Schnittstelle und zur TextFrame-Klasse hinzugefügt.

Sie ermöglicht es, einen Textteil mit Hintergrundfarbe mithilfe von Regex hervorzuheben, ähnlich wie das Werkzeug Textmarkerfarbe in PowerPoint 2019.


Der folgende Codeausschnitt zeigt, wie man diese Funktion verwendet:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // hebt alle Wörter mit 10 Symbolen oder mehr hervor
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```

## **Text-Hintergrundfarbe festlegen**

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

## **Textabsätze ausrichten**

Die Textformatierung ist eines der Schlüsselelemente beim Erstellen jeglicher Art von Dokumenten oder Präsentationen. Wir wissen, dass Aspose.Slides für .NET das Hinzufügen von Text zu Folien unterstützt, aber in diesem Thema werden wir sehen, wie wir die Ausrichtung der Textabsätze in einer Folie steuern können. Bitte folgen Sie den folgenden Schritten, um Textabsätze mit Aspose.Slides für .NET auszurichten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und typisieren Sie sie als AutoShape.
4. Holen Sie sich den Absatz (der ausgerichtet werden muss) aus dem TextFrame, das von AutoShape bereitgestellt wird.
5. Richten Sie den Absatz aus. Ein Absatz kann rechts, links, zentriert und im Blocksatz ausgerichtet werden.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```c#
// Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // Zugriff auf die erste Folie
    ISlide slide = pres.Slides[0];

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typcasting als AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Ändern Sie den Text in beiden Platzhaltern
    tf1.Text = "Zentriert ausrichten von Aspose";
    tf2.Text = "Zentriert ausrichten von Aspose";

    // Holen Sie sich den ersten Absatz der Platzhalter
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Richten Sie den Textabsatz zentriert aus
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    // Schreiben Sie die Präsentation als PPTX-Datei
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```


## **Transparenz für Text festlegen**
Dieser Artikel demonstriert, wie Sie die Transparenzeigenschaft für eine beliebige Textform mit Aspose.Slides für .NET festlegen können. Um die Transparenz für Text festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie.
3. Legen Sie die Schattenfarbe fest.
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

    // Legen Sie die Transparenz auf null Prozent fest
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **Zeichenabstand für Text festlegen**

Aspose.Slides ermöglicht es Ihnen, den Abstand zwischen Buchstaben in einem Textfeld festzulegen. Auf diese Weise können Sie die visuelle Dichte einer Zeile oder eines Textblocks anpassen, indem Sie den Abstand zwischen den Zeichen erweitern oder verringern.

Dieser C#-Code zeigt Ihnen, wie Sie den Abstand für eine Zeile Text erweitern und den Abstand für eine andere Zeile verringern:

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape) presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape) presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // erweitern
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // verringern

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Schriftart-Eigenschaften des Absatzes verwalten**

Präsentationen enthalten normalerweise sowohl Text als auch Bilder. Der Text kann auf verschiedene Weise formatiert werden, entweder um bestimmte Abschnitte und Wörter hervorzuheben oder um sich an Unternehmensstile anzupassen. Die Textformatierung hilft Benutzern, das Aussehen und das Gefühl des Präsentationsinhalts zu variieren. Dieser Artikel zeigt, wie Sie Aspose.Slides für .NET verwenden können, um die Schriftarteigenschaften von Textabsätzen auf Folien zu konfigurieren. Um die Schriftarteigenschaften eines Absatzes mit Aspose.Slides für .NET zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich eine Referenz der Folie, indem Sie ihren Index verwenden.
3. Greifen Sie auf die Platzhalterformen in der Folie zu und typisieren Sie sie zu AutoShape.
4. Holen Sie sich den Absatz aus dem TextFrame, das von AutoShape bereitgestellt wird.
5. Rechtfertigen Sie den Absatz.
6. Greifen Sie auf den Textanteil eines Absatzes zu.
7. Definieren Sie die Schriftart mit FontData und setzen Sie die Schriftart des Textanteils entsprechend.
   1. Setzen Sie die Schriftart auf fett.
   2. Setzen Sie die Schriftart auf kursiv.
8. Legen Sie die Schriftfarbe mithilfe des FillFormat fest, das vom Portion-Objekt bereitgestellt wird.
9. Schreiben Sie die modifizierte Präsentation in eine [PPTX](https://docs.fileformat.com/presentation/pptx/) Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben. Sie nimmt eine ungeschmückte Präsentation und formatiert die Schriften auf einer der Folien.

```c#
// Instanziieren Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // Zugriff auf eine Folie mithilfe ihrer Folienposition
    ISlide slide = pres.Slides[0];

    // Zugriff auf den ersten und zweiten Platzhalter in der Folie und Typcasting als AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Zugriff auf den ersten Absatz
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Zugriff auf den ersten Anteil
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // Definieren neuer Schriften
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Zuweisen neuer Schriften zum Anteil
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // Setzen der Schriftart auf Fett
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // Setzen der Schriftart auf Kursiv
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // Setzen der Schriftfarbe
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    // Schreiben Sie die PPTX auf die Festplatte
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```


## **Schriftfamilie des Textes verwalten**
Ein Anteil wird verwendet, um Text mit ähnlichem Formatierungsstil in einem Absatz zu halten. Dieser Artikel zeigt, wie Sie Aspose.Slides für .NET verwenden können, um ein Textfeld mit etwas Text zu erstellen und dann eine bestimmte Schriftart sowie verschiedene andere Eigenschaften der Schriftfamilie festzulegen. Um ein Textfeld zu erstellen und die Schrifteigenschaften des darin enthaltenen Textes festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
3. Fügen Sie ein AutoShape von der Art Rechteck zur Folie hinzu.
4. Entfernen Sie den Füllstil, der mit dem AutoShape verbunden ist.
5. Greifen Sie auf das TextFrame des AutoShape zu.
6. Fügen Sie etwas Text zum TextFrame hinzu.
7. Greifen Sie auf das Portion-Objekt zu, das mit dem TextFrame verbunden ist.
8. Definieren Sie die Schriftart, die für den Anteil verwendet werden soll.
9. Stellen Sie andere Schrifteigenschaften wie Fett, Kursiv, Unterstrichen, Farbe und Höhe mithilfe der relevanten Eigenschaften, die vom Portion-Objekt bereitgestellt wurden, ein.
10. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die Implementierung der oben genannten Schritte ist unten angegeben.

```c#
// Instanziieren Sie die Präsentation
using (Presentation presentation = new Presentation())
{
   
    // Holen Sie sich die erste Folie
    ISlide sld = presentation.Slides[0];

    // Fügen Sie ein AutoShape vom Typ Rechteck hinzu
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Entfernen Sie jeglichen Füllstil, der mit dem AutoShape verbunden ist
    ashp.FillFormat.FillType = FillType.NoFill;

    // Greifen Sie auf das TextFrame zu, das mit dem AutoShape verbunden ist
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "Aspose TextBox";

    // Greifen Sie auf den Anteil zu, der mit dem TextFrame verbunden ist
    IPortion port = tf.Paragraphs[0].Portions[0];

    // Setzen Sie die Schriftart für den Anteil
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // Setzen Sie die Fettschrift-Eigenschaft für die Schriftart
    port.PortionFormat.FontBold = NullableBool.True;

    // Setzen Sie die Kursivschrift-Eigenschaft für die Schriftart
    port.PortionFormat.FontItalic = NullableBool.True;

    // Setzen Sie die Unterstrich-Eigenschaft für die Schriftart
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // Setzen Sie die Höhe der Schriftart
    port.PortionFormat.FontHeight = 25;

    // Setzen Sie die Farbe der Schriftart
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Schreiben Sie die PPTX auf die Festplatte 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```

## **Schriftgröße für Text festlegen**

Aspose.Slides ermöglicht es Ihnen, Ihre bevorzugte Schriftgröße für bestehenden Text in einem Absatz und andere Texte, die später zu dem Absatz hinzugefügt werden, auszuwählen.

Dieser C# zeigt Ihnen, wie Sie die Schriftgröße für Texte, die in einem Absatz enthalten sind, festlegen:

```c#
var presentation = new Presentation("example.pptx");

// Holen Sie sich die erste Form, zum Beispiel.
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape autoShape)
{
    // Holen Sie sich den ersten Absatz, zum Beispiel.
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Setzen Sie die Standard-Schriftgröße auf 20 pt für alle Textanteile im Absatz.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

    // Setzen Sie die Schriftgröße auf 20 pt für die aktuellen Textanteile im Absatz.
    foreach (var portion in paragraph.Portions)
    {
        portion.PortionFormat.FontHeight = 20;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Textrrotation festlegen**

Aspose.Slides für .NET ermöglicht es Entwicklern, den Text zu drehen. Der Text kann so eingestellt werden, dass er horizontal, vertikal, vertikal 270, WordArt vertikal, ostasiatisch vertikal, mongolisch vertikal oder WordArt vertikal von rechts nach links erscheint. Um den Text eines beliebigen TextFrame zu drehen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Drehen Sie den Text.
6. Speichern Sie die Datei auf der Festplatte.

```c#
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation presentation = new Presentation();

// Holen Sie sich die erste Folie 
ISlide slide = presentation.Slides[0];

// Fügen Sie ein AutoShape vom Typ Rechteck hinzu
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
portion.Text = "Ein schneller, brauner Fuchs springt über den faulen Hund. Ein schneller, brauner Fuchs springt über den faulen Hund.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Speichern der Präsentation
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```


## **Benutzerdefinierte Rotationswinkel für TextFrame festlegen**
Aspose.Slides für .NET unterstützt jetzt das Festlegen des benutzerdefinierten Rotationswinkels für Textframe. In diesem Thema werden wir an einem Beispiel sehen, wie die RotationAngle-Eigenschaft in Aspose.Slides festgelegt wird. Die neue Eigenschaft RotationAngle wurde zur IChartTextBlockFormat und ITextFrameFormat Schnittstelle hinzugefügt und ermöglicht das Festlegen des benutzerdefinierten Rotationswinkels für das Textfeld. Um die RotationAngle-Eigenschaft festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Fügen Sie ein Diagramm auf der Folie hinzu.
3. Setzen Sie die RotationAngle-Eigenschaft.
4. Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel setzen wir die RotationAngle-Eigenschaft.

```c#
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Benutzerdefinierter Titel").TextFrameFormat.RotationAngle = -30;

// Speichern der Präsentation
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```


## **Zeilenabstand des Absatzes**
Aspose.Slides bietet die Eigenschaften ([SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spaceafter), [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacebefore) und [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacewithin)) unter der Klasse [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/), die es Ihnen ermöglichen, den Zeilenabstand für einen Absatz zu verwalten. Die drei Eigenschaften werden so verwendet:

* Um den Zeilenabstand für einen Absatz in Prozent anzugeben, verwenden Sie einen positiven Wert. 
* Um den Zeilenabstand für einen Absatz in Punkten anzugeben, verwenden Sie einen negativen Wert.

Zum Beispiel können Sie einen Zeilenabstand von 16pt für einen Absatz festlegen, indem Sie die `SpaceBefore`-Eigenschaft auf -16 setzen.

So geben Sie den Zeilenabstand für einen bestimmten Absatz an:

1. Laden Sie eine Präsentation, die ein AutoShape mit etwas Text enthält.
2. Erhalten Sie die Referenz einer Folie über ihren Index.
3. Greifen Sie auf das TextFrame zu.
4. Greifen Sie auf den Absatz zu.
5. Stellen Sie die Eigenschaften des Absatzes ein.
6. Speichern Sie die Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie den Zeilenabstand für einen Absatz angeben:

```c#
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation presentation = new Presentation("Fonts.pptx");

// Holen Sie sich die Referenz einer Folie über ihren Index
ISlide sld = presentation.Slides[0];

// Greifen Sie auf das Textframe zu
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// Greifen Sie auf den Absatz zu
IParagraph para1 = tf1.Paragraphs[0];

// Stellen Sie die Eigenschaften des Absatzes ein
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// Speichern der Präsentation
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```


## **AutofitType-Eigenschaft für TextFrame festlegen**
In diesem Thema werden wir die verschiedenen Formatierungseigenschaften des Textfeldes erkunden. Dieser Artikel behandelt, wie man die AutofitType-Eigenschaft des Textfeldes, den Anker des Textes und die Rotierung des Textes in der Präsentation festlegt. Aspose.Slides für .NET ermöglicht es Entwicklern, die AutofitType-Eigenschaft eines beliebigen Textfeldes festzulegen. AutofitType kann auf Normal oder Shape gesetzt werden. Wenn auf Normal gesetzt, bleibt die Form gleich, während der Text angepasst wird, ohne dass sich die Form selbst ändert. Wenn die AutofitType auf Shape gesetzt wird, wird die Form so modifiziert, dass nur der erforderliche Text darin enthalten ist. Um die AutofitType-Eigenschaft eines Textfeldes festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Setzen Sie den AutofitType des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```c#
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation presentation = new Presentation();

// Greifen Sie auf die erste Folie zu 
ISlide slide = presentation.Slides[0];

// Fügen Sie ein AutoShape vom Typ Rechteck hinzu
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Fügen Sie dem Rechteck einen TextFrame hinzu
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Zugriff auf das Textfeld
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Erstellen Sie das Absatzobjekt für das Textfeld
IParagraph para = txtFrame.Paragraphs[0];

// Erstellen Sie das Portion-Objekt für den Absatz
IPortion portion = para.Portions[0];
portion.Text = "Ein schneller, brauner Fuchs springt über den faulen Hund. Ein schneller, brauner Fuchs springt über den faulen Hund.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Speichern der Präsentation
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```


## **Anker des TextFrame festlegen**
Aspose.Slides für .NET ermöglicht Entwicklern, den Anker für jedes TextFrame festzulegen. TextAnchorType gibt an, wo der Text in der Form platziert ist. TextAnchorType kann auf Oben, Zentriert, Unten, Blocksatz oder Verteilte eingestellt werden. Um den Anker eines beliebigen TextFrames festzulegen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine beliebige Form zur Folie hinzu.
4. Greifen Sie auf das TextFrame zu.
5. Setzen Sie den TextAnchorType des TextFrames.
6. Speichern Sie die Datei auf der Festplatte.

```c#
// Erstellen Sie eine Instanz der Präsentationsklasse
Presentation presentation = new Presentation();

// Holen Sie sich die erste Folie 
ISlide slide = presentation.Slides[0];

// Fügen Sie ein AutoShape vom Typ Rechteck hinzu
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Fügen Sie dem Rechteck einen TextFrame hinzu
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Zugriff auf das Textfeld
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// Erstellen Sie das Absatzobjekt für das Textfeld
IParagraph para = txtFrame.Paragraphs[0];

// Erstellen Sie das Portion-Objekt für den Absatz
IPortion portion = para.Portions[0];
portion.Text = "Ein schneller, brauner Fuchs springt über den faulen Hund. Ein schneller, brauner Fuchs springt über den faulen Hund.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Speichern der Präsentation
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **Texttabulierung festlegen**
- Die Eigenschaft EffectiveTabs.ExplicitTabCount (2 in unserem Fall) entspricht der Anzahl der Tabs.
- Die EffectiveTabs-Sammlung umfasst alle Tabs (aus der Tabs-Sammlung und den Standard-Tabs).
- Die Eigenschaft EffectiveTabs.DefaultTabSize (294) zeigt den Abstand zwischen den Standard-Tabs (3 und 4 in unserem Beispiel).
- EffectiveTabs.GetTabByIndex(index) mit index = 0 gibt den ersten expliziten Tab (Position = 731) zurück, index = 1 - den zweiten Tab (Position = 1241). Wenn Sie versuchen, den nächsten Tab mit index = 2 abzurufen, wird der erste Standard-Tab (Position = 1470) zurückgegeben usw.
- EffectiveTabs.GetTabAfterPosition(pos) wird verwendet, um die nächste Tabulierung nach einem bestimmten Text zu erhalten. Wenn Sie beispielsweise den Text "Helloworld!" haben. Um diesen Text darzustellen, sollten Sie wissen, wo Sie mit dem Zeichnen von "world!" beginnen können. Zuerst sollten Sie die Länge von "Hello" in Pixeln berechnen und GetTabAfterPosition mit diesem Wert aufrufen. Sie erhalten die nächste Tab-Position, um "world!" zu zeichnen.

## **Überprüfungssprache festlegen**

Aspose.Slides bietet die [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) Eigenschaft (bereitgestellt von der [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) Klasse), um Ihnen zu ermöglichen, die Überprüfungssprache für ein PowerPoint-Dokument festzulegen. Die Überprüfungssprache ist die Sprache, für die die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

Dieser C#-Code zeigt Ihnen, wie Sie die Überprüfungssprache für einen PowerPoint festlegen:

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

    portionFormat.LanguageId = "zh-CN"; // Setzen Sie die Id einer Überprüfungssprache
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Standardsprache festlegen**

Dieser C#-Code zeigt Ihnen, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen:

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Fügen Sie eine neue Rechteckform mit Text hinzu
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Neuer Text";
    
    // Überprüfen Sie die Sprache des ersten Anteils
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```

## **Standardtextstil festlegen**

Wenn Sie denselben Standardtextstil auf alle Textelemente einer Präsentation gleichzeitig anwenden möchten, können Sie die `DefaultTextStyle`-Eigenschaft der [IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) Schnittstelle verwenden und die bevorzugte Formatierung festlegen. Das folgende Codebeispiel zeigt, wie Sie die Standardfett-Formatierung (14 pt) für den Text auf allen Folien in einer neuen Präsentation festlegen:

```c#
using (Presentation presentation = new Presentation())
{
    // Holen Sie sich die oberste Absatzformatierung.
    IParagraphFormat paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("DefaultTextStyle.pptx", SaveFormat.Pptx);
}
```