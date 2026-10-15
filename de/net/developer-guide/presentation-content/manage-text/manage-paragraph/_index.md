---
title: PowerPoint-Textabsätze in .NET verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatzeinzug
- hängender Einzug
- Absatzaufzählungszeichen
- nummerierte Liste
- Aufzählungsliste
- Absatzeigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für .NET Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML‑Inhalte und Absatz‑Bilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für .NET stellt Text als Hierarchie von Textfeldern, Absätzen und Portionen dar:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) stellt den Textbehälter in einer Form dar und bietet Zugriff auf die Absatzsammlung.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) stellt einen Absatz in einem Textfeld dar und bietet Zugriff auf seine Portionen und die Absatzformatierung.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jede Portion kann ihren eigenen Text und Zeichenformatierung besitzen.

Ein Absatz kann daher Text mit unterschiedlichen Schriften, Farben, Größen und sonstiger Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Erstellen und Formatieren von Absätzen**

Erstellen Sie Absätze im Textfeld einer Form und verwenden Sie Portionen, um einzelne Textläufe zu formatieren. Dieser Abschnitt zeigt, wie ...

### **Absätze mit mehreren Portionen erstellen**

Das folgende C#‑Beispiel erstellt drei Absätze, die jeweils drei Textläufe in ihrer [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/)‑Sammlung enthalten. Es verwendet den Standardabsatz und seine leere Portion wieder, fügt dann die übrigen Absätze und Portionen hinzu. Die Formatierung wird über [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) angewendet: Die erste Portion in jedem Absatz ist rot, fett und 15 Punkt; die zweite ist blau, kursiv und 18 Punkt. Die dritte Portion behält die Standardformatierung bei:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Aufzählungs‑ und nummerierte Listen erstellen**

Organisieren Sie Absatztext in Listen mit Symbolen, Zahlen oder benutzerdefinierten Bildern. Die Beispiele in diesem Abschnitt behandeln Aufzählungsformatierung, mehrstufige Listen und benutzerdefinierte Startzahlen.

### **Eine Aufzählungs‑ oder nummerierte Liste erstellen**

Aufzählungen und Nummerierungen erleichtern das Scannen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) definiert.

Dieses C#‑Beispiel fügt einem Textfeld ein Symbol‑Aufzählungszeichen und ein nummeriertes Element hinzu. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) wählt den Aufzählungszeichentyp aus, während [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) das Symbol bereitstellt und [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) den Nummerierungsstil auswählt. Beide Elemente verwenden schwarze Aufzählungszeichen mit einer Höhe von 100 Prozent und einem Absatz‑Einzug von 25 Punkt:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Bild‑Aufzählungszeichen verwenden**

Bild‑Aufzählungszeichen ermöglichen es, ein benutzerdefiniertes Bild anstelle eines Symbols oder einer Zahl zu verwenden.

Dieses C#‑Beispiel fügt der Bildersammlung der Präsentation ein Bild als [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) hinzu und verwendet es als Absatz‑Aufzählungszeichen. Es setzt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) auf ein Bild‑Aufzählungszeichen und weist das Bild über [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) zu. [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) wird auf 100 Prozent gesetzt, um das Aufzählungszeichen relativ zum Absatztext zu skalieren:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Mehrstufige Liste erstellen**

Setzen Sie [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) , um Absätze auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat eine Tiefe von `0`.

Dieses C#‑Beispiel weist den vier Absätzen Werte für [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) von 0 bis 3 zu und erstellt so eine Hierarchie innerhalb eines Textfelds. Jeder Absatz verwendet ein Symbol‑Aufzählungszeichen, wobei [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) zwischen einem runden Aufzählungszeichen und einem Bindestrich wechselt, um benachbarte Ebenen zu unterscheiden:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Nummerierte Listenelemente bei benutzerdefinierten Werten starten**

Verwenden Sie [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) , um die für einen nummerierten Absatz angezeigte Anfangszahl festzulegen.

Dieses C#‑Beispiel setzt [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) auf Nummerierung für drei Absätze und weist [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/)‑Werte von 2, 3 und 7 zu. Der Startwert wird für jeden Absatz separat konfiguriert, sodass die angezeigten Zahlen Werte überspringen können:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Absatzlayout und End‑Eigenschaften steuern**

Passen Sie Absatzränder und Einzüge an, um die Position der ersten Zeile und der umgebrochenen Zeilen zu steuern. Sie können auch das Absatz‑Endzeichen separat von den sichtbaren Textportionen formatieren.

### **Ersten Zeileneinzug festlegen**

Verwenden Sie die Eigenschaft [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) , um den Erstzeileneinzug eines Absatzes zu steuern. Diese Eigenschaft verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) , wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) , wenn Sie nur die erste Zeile verschieben müssen.

Das folgende Beispiel gibt drei Absätzen das gleiche [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) von 20 Punkt und [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/)‑Werte von 0, 20 und 40 Punkt. Die ersten Zeilen beginnen mit zunehmend größeren Versätzen, während umgebrochene Zeilen denselben linken Rand behalten:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Hängenden Einzug festlegen**

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den restlichen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Eigenschaft [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Setzen Sie `Indent` auf einen negativen Wert, um die erste Zeile relativ zum Absatzkörper nach links zu verschieben.

In der Praxis definiert [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) die linke Position des Absatzkörpers und [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Diese Formatierung ist nützlich für Bibliografien, Referenzen, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

Das folgende C#‑Beispiel kombiniert [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/)‑Werte von 40 und 60 Punkt mit [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/)‑Werten von -20 und -30 Punkt. In jedem Absatz beginnt die erste Zeile links von den umgebrochenen Zeilen; der zweite Absatz hat einen tieferen hängenden Einzug:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Das Ergebnis:

![The hanging indent of the paragraphs](hanging_indent.png)

### **End‑Absatz‑Lauf‑Eigenschaften festlegen**

Die Eigenschaft [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) steuert die Formatierung des Absatz‑Endzeichens. Das folgende Beispiel erstellt ein [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) mit [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) auf 48 Punkt und [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) auf Times New Roman. Es weist dieses Format dem Endzeichen des zweiten Absatzes zu, während die sichtbaren Textportionen unverändert bleiben:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Gerenderte Zeilen zählen**

Für Absatzregeln, die automatisches Umbrechen und Interpunktion am Zeilenende beeinflussen, siehe [Zeilenumbruch steuern](/slides/de/net/text-formatting/#control-line-breaking) und [hängende Interpunktion steuern](/slides/de/net/text-formatting/#control-hanging-punctuation).

Verwenden Sie [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) , um die Zeilen zu zählen, die ein Absatz nach der Textlayout‑Phase belegt, einschließlich automatischem Umbrechen. Das ist nützlich beim Prüfen von Textlänge und Layout in Präsentationsvorlagen.

Ein Absatz ist ein Element in [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) und kann mehrere gerenderte Zeilen belegen. ein expliziter Zeilenumbruch innerhalb eines Absatzes erzwingt eine neue Zeile, ohne einen weiteren Absatz zu erzeugen. automatisches Umbrechen erzeugt Zeilen basierend auf der verfügbaren Breite, ohne explizite Zeilenumbrüche in den Text einzufügen. Das Zählen von Absätzen oder Zeilenumbruch‑Zeichen liefert daher nicht die gerenderte Zeilenzahl.

Das folgende Beispiel erstellt eine Textform, zählt ihre Zeilen, verkleinert die Form und ersetzt dann den Text durch eine kürzere Zeichenfolge. Das Beispiel aktiviert [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) und deaktiviert [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) , sodass die Formbreite das Umbrechen steuert, ohne den Text automatisch zu verkleinern oder die Form zu skalieren. Jede Messung verwendet [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Formabmessungen werden in Punkten angegeben. Abschließend fügt das Beispiel einen weiteren Absatz hinzu und summiert die Zeilenzahlen über das Textfeld.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Mit diesem Text und diesen Abmessungen erhöht das Verengen der Form die Zeilenzahl, während das Ersetzen des Textes durch die kurze Zeichenfolge sie verringert. Exakte Zahlen können je nach Schriftverfügbarkeit und -ersatz, Schriftgröße, Rändern, Einzügen, Umbrechen und Autofit‑Einstellungen variieren. Verwenden Sie die für die Zielumgebung vorgesehenen Schriften und Layout‑Einstellungen, wenn Sie eine Vorlage überprüfen.

Die Zeilenzahl allein bestimmt nicht, ob der Text seinen Container überläuft. Die verfügbare Höhe, Zeilenhöhen, Absatz‑ und Zeilenabstände sowie das Autofit‑Verhalten spielen ebenfalls eine Rolle; selbst eine einzelne Zeile kann die verfügbare Breite überschreiten, wenn das Umbrechen deaktiviert ist.

## **Absatzinhalt importieren und exportieren**

Verwenden Sie HTML, um Text in eine Präsentation zu übernehmen oder bestehende Absätze für die Nutzung außerhalb zu exportieren. Dieser Abschnitt zeigt außerdem, wie einzelne Absätze als Bilder gerendert werden können, einschließlich Absätzen in Tabellenzellen.

### **HTML‑Text in Absätze importieren**

Verwenden Sie [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) , um HTML‑Markup in Absätze und Portionen in einem Textfeld zu konvertieren.

Dieses C#‑Beispiel liest HTML aus einer Datei und übergibt das Markup an [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Es löscht den Standardabsatz des Textfelds, sodass das Feld nur den importierten Inhalt enthält. Die rechteckige Form lässt an jeder Seite der Folie einen Rand von 10 Punkt:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Absatztext nach HTML exportieren**

Verwenden Sie [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) , um einen ausgewählten Absatzbereich als HTML zu exportieren. Beim Wiederverwenden von Präsentationstext auf einer Website möchten Sie möglicherweise lokale Hervorhebungen beibehalten, ohne die Schriftart, Größe oder Textfeld‑Stile der Präsentation zu übernehmen. Setzen Sie [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) , um zu steuern, wie weit der Exporter der Formatierungs‑Vererbung folgt.

Laden Sie [die Beispielpräsentation](text-inheritance.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält ein Textfeld mit dem Text „Inherited text; explicit red 18pt“. Die Eingabe verwendet bewusst mehrere Formatierungsebenen:

- Der Standard‑Textstil der Präsentation verwendet Calibri und eine Größe von 28 pt.
- Der Textstil der ersten Ebene des Textfelds liefert blauen Text und Kursivschrift.
- Der Absatz setzt ausdrücklich fetten Text.
- Die zweite Portion, „explicit red 18pt“, setzt ausdrücklich roten Text und eine Größe von 18 pt.

Das folgende vollständige Beispiel exportiert dieselben Absätze dreimal. Es übergibt [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) an die Export‑Methode und schreibt jedes Ergebnis als separate UTF‑8‑HTML‑Datei:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

Das erzeugte HTML enthält das folgende CSS für die erste Portion, "Inherited text; ". Die Tabelle listet die relevanten Deklarationen auf; andere erzeugte Eigenschaften wurden aus Übersichtlichkeit weggelassen.

| Ausgabe | Relevantes CSS für die erste Portion | Erscheinungsbild |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blauer, fetter, kursiver Text mit 28 pt in Calibri, falls diese Schrift verfügbar ist. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blauer, fetter, kursiver Text; die umgebende Seite oder der Browser liefert die Schriftfamilie und Größe. |
| `ParagraphOnly.html` | `font-weight:bold` | Fetter Text; die umgebende Seite oder der Browser liefert Schriftfamilie, Größe, Farbe und Kursivstil. |

Die zweite Portion behält `color:#ff0000`, `font-size:18pt` und `font-weight:bold` in allen drei Ausgaben bei. Sie behält außerdem Kursivschrift bei `All` und `TextBox` bei, jedoch nicht bei `ParagraphOnly`. Das Einschränken der Vererbung entfernt daher nicht die ausdrücklich einem Absatz oder einer Portion zugewiesene Formatierung.

Öffnen Sie die Dateien im selben Browser, um sie zu vergleichen. In den beiden eingeschränkten Modi werden weggelassene CSS‑Eigenschaften durch die Stile der Zielseite oder die Browser‑Standardwerte aufgelöst, sodass das Ergebnis davon abhängt, wo das HTML verwendet wird.

### **Einen Absatz als Bild rendern**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) rendert einen einzelnen Absatz direkt und gibt ein [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) in einer Datei oder einem Stream. Sie müssen nicht die enthaltende Form rendern oder ein Bitmap manuell zuschneiden.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) kann `null` zurückgeben, wenn der Absatz nicht in seiner übergeordneten Sammlung gefunden wird, keine gültigen Render‑Grenzen hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis, bevor Sie es speichern, und geben Sie das zurückgegebene Bild nach der Verwendung frei.

#### **Einen Absatz im Standardmaßstab rendern**

Das Beispiel verwendet eine Präsentation mit einer Folie, deren erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

Das folgende Beispiel wählt den zweiten Absatz mit Index 1 aus und ruft [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) ohne Skalierungsparameter auf. Es prüft, dass die Form den erforderlichen Absatz enthält und dass das Rendern ein Bild zurückgibt, bevor [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) zum Speichern im PNG‑Format aufgerufen wird. Die `using`‑Deklaration gibt das Bild nach dem Gebrauch frei.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Das Ergebnis:

![Das Absatzbild](paragraph_to_image_output.png)

#### **Einen Absatz in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/), die die Parameter `float scaleX` und `float scaleY` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in ihrer ersten Zelle mit dem doppelten Standardbreite und -höhe und speichert das Ergebnis als PNG‑Bild.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Ein Skalierungsfaktor von `1` hält diese Achse bei ihrer Standard‑Pixelgröße. Zum Beispiel erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa das Doppelte der Standardabmessungen betragen, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen im Allgemeinen schärferen Text für Zoom‑ oder hochauflösende Ausgaben, erhöhen jedoch auch Speicherverbrauch und Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes beizubehalten; unterschiedliche horizontale und vertikale Faktoren dehnen die Ausgabe unabhängig voneinander.

Das Rendern einer gesamten Form mit [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) bleibt nützlich, wenn die Ausgabe die Füllung, den Rand oder andere visuelle Kontextinformationen der Form enthalten muss. Für ein Bild, das nur den Absatz zeigt, verwenden Sie [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Kann ich das Zeilenumbruch komplett in einem Textfeld deaktivieren?**

Ja. Setzen Sie [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) , um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des Textfelds umbrochen werden.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes erhalten?**

Verwenden Sie [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) , um das Begrenzungsrechteck des Absatzes abzurufen. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ist eine Einstellung auf Absatz‑Ebene und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.  
Um Schriftgrößen innerhalb einer Zeile vertikal auszurichten, siehe [Schriftgrößen innerhalb einer Zeile vertikal ausrichten](/slides/de/net/text-formatting/#align-fonts-within-a-line).

**Kann ich die Rechtschreibprüfungssprache für einen Teil eines Absatzes festlegen?**

Ja. Setzen Sie [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.