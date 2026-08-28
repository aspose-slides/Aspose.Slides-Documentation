---
title: Verwalten von PowerPoint-Textabsätzen in .NET
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
  - Absatz-Einzug
  - hängender Einzug
  - Absatz-Aufzählungszeichen
  - nummerierte Liste
  - Aufzählungsliste
  - Absatz-Eigenschaften
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
description: "Erfahren Sie, wie Sie mit Aspose.Slides für .NET Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML-Inhalte und Absatzbilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für .NET stellt Text als Hierarchie von Textrahmen, Absätzen und Portionen dar:

* [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) stellt den Textbehälter in einer Form dar und bietet Zugriff auf die Absatzsammlung.
* [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/) stellt einen Absatz in einem Textrahmen dar und bietet Zugriff auf seine Portionen und die Absatzformatierung.
* [IPortion](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/) stellt einen Textlauf innerhalb eines Absatzes dar. Jede Portion kann eigenen Text und Zeichenformatierung besitzen.

Ein Absatz kann daher Text mit unterschiedlichen Schriftarten, Farben, Größen und weiterer Formatierung enthalten, indem mehrere Portionen verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Portionen erstellen**

Die folgenden Schritte erstellen einen Textrahmen mit drei Absätzen, die jeweils drei Portionen enthalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) der Form zu.
5. Verwenden Sie den Standardabsatz und fügen Sie dem Textrahmen zwei weitere [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/)‑Objekte hinzu.
6. Fügen Sie genügend [IPortion](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/)‑Objekte hinzu, damit jeder Absatz drei Portionen enthält. Der Standardabsatz enthält bereits eine leere Portion.
7. Setzen Sie den Text jeder Portion.
8. Wenden Sie Zeichenformatierung über [IPortion.PortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/portionformat/) an.
9. Speichern Sie die modifizierte Präsentation.

Dieses C#‑Beispiel implementiert die Schritte:

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

## **Aufzählungs‑ und Nummerierungslisten erstellen**

### **Eine Aufzählungs‑ oder Nummerierungsliste erstellen**

Aufzählungszeichen und Nummerierungen erleichtern das Scannen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [IBulletFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/) definiert.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) zur ausgewählten Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) der Form zu.
5. Entfernen Sie den Standardabsatz aus dem Textrahmen.
6. Erstellen Sie ein [Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [IBulletFormat.Type](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/type/) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/net/aspose.slides/bullettype/) und geben Sie das Aufzählungszeichen‑Zeichen an.
8. Legen Sie den Absatztext, Einzug, Aufzählungsfarbe und Aufzählungsgröße fest.
9. Fügen Sie den Absatz dem Textrahmen hinzu.
10. Erstellen Sie einen zweiten Absatz und setzen Sie [IBulletFormat.Type](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/type/) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/net/aspose.slides/bullettype/).
11. Konfigurieren Sie den nummerierten Aufzählungsstil und fügen Sie den Absatz dem Textrahmen hinzu.
12. Speichern Sie die Präsentation.

Dieses C#‑Beispiel erstellt ein Symbol‑Aufzählungszeichen und ein nummeriertes Aufzählungszeichen:

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

Bild‑Aufzählungszeichen ermöglichen die Verwendung eines benutzerdefinierten Bildes anstelle eines Symbols oder einer Zahl.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu und greifen Sie auf sein [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) zu.
4. Entfernen Sie den Standardabsatz aus dem Textrahmen.
5. Laden Sie das Aufzählungszeichen‑Bild und fügen Sie es der Bildsammlung der Präsentation als [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) hinzu.
6. Erstellen Sie ein [Paragraph](https://reference.aspose.com/slides/de/net/aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [IBulletFormat.Type](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/type/) auf [BulletType.Picture](https://reference.aspose.com/slides/de/net/aspose.slides/bullettype/).
8. Weisen Sie das Bild über [IBulletFormat.Picture](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/picture/) zu und setzen Sie die Aufzählungsgröße.
9. Fügen Sie den Absatz dem Textrahmen hinzu.
10. Speichern Sie die modifizierte Präsentation.

Dieses C#‑Beispiel erstellt ein Bild‑Aufzählungszeichen:

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

Setzen Sie [IParagraphFormat.Depth](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/depth/) um Absätze auf verschiedenen Ebenen einer Liste zu platzieren. Die oberste Ebene hat die Tiefe `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu und löschen Sie den Standardabsatz aus dessen Textrahmen.
3. Erstellen Sie vier Absätze und konfigurieren Sie deren Aufzählungssymbole.
4. Setzen Sie ihre [IParagraphFormat.Depth](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/depth/)‑Werte auf `0`, `1`, `2` und `3`.
5. Fügen Sie die Absätze dem Textrahmen hinzu und speichern Sie die Präsentation.

Dieses C#‑Beispiel erstellt eine vierstufige Aufzählungsliste:

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

### **Nummerierte Listeneinträge bei benutzerdefinierten Werten beginnen lassen**

Verwenden Sie [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/de/net/aspose.slides/ibulletformat/numberedbulletstartwith/) um die anfängliche Nummer für einen nummerierten Absatz festzulegen.

1. Erstellen Sie eine [Presentation] und fügen Sie einer Folie ein [IAutoShape] hinzu.
2. Entfernen Sie den Standardabsatz aus dem Textrahmen der Form.
3. Erstellen Sie drei nummerierte Absätze.
4. Setzen Sie [IBulletFormat.NumberedBulletStartWith] für die jeweiligen Absätze auf `2`, `3` bzw. `7`.
5. Fügen Sie die Absätze dem Textrahmen hinzu und speichern Sie die Präsentation.

Dieses C#‑Beispiel weist jedem Absatz eine benutzerdefinierte Startnummer zu:

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

## **Absatzlayout und Endeigenschaften steuern**

### **Erste‑Zeilen‑Einzug festlegen**

Verwenden Sie die Eigenschaft [IParagraphFormat.Indent], um den ersten Zeileneinzug eines Absatzes zu steuern. Diese Eigenschaft verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [IParagraphFormat.MarginLeft], wenn Sie den gesamten Absatz verschieben möchten. Verwenden Sie [IParagraphFormat.Indent], wenn Sie nur die erste Zeile verschieben wollen.

Das nachstehende Beispiel erstellt mehrere Absätze und wendet verschiedene [IParagraphFormat.Indent]-Werte an, um zu zeigen, wie der erste Zeileneinzug das Absatzlayout beeinflusst.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) .
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie unterschiedliche [Indent](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/indent/)‑Werte für sie.
6. Fügen Sie die Absätze dem Textrahmen hinzu.
7. Speichern Sie die modifizierte Präsentation.

Dieser Code zeigt, wie man einen Absatz‑Einzug festlegt:

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

Ein hängender Einzug ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Eigenschaft [IParagraphFormat.Indent]. Setzen Sie `Indent` auf einen negativen Wert, um die erste Zeile relativ zum Absatzkörper nach links zu verschieben.

In der Praxis definiert [IParagraphFormat.MarginLeft] die linke Position des Absatzkörpers und [IParagraphFormat.Indent] die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Diese Formatierung ist nützlich für Bibliographien, Referenzen, Glossareinträge und andere Absätze, bei denen umbrochene Zeilen unter dem Absatzkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) .
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie ein rechteckiges [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) zur Folie hinzu.
4. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und setzen Sie für jeden Absatz einen positiven [MarginLeft](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/marginleft/)‑Wert.
6. Setzen Sie einen negativen [Indent](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/indent/)‑Wert, um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Absätze dem Textrahmen hinzu.
8. Speichern Sie die modifizierte Präsentation.

Dieser Code zeigt, wie man für einen Absatz einen hängenden Einzug festlegt:

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

Die Eigenschaft [IParagraph.EndParagraphPortionFormat] steuert die Formatierung des Absatzendzeichens. Das folgende Beispiel weist dem Endzeichen des zweiten Absatzes eine Schriftgröße und eine lateinische Schriftart zu:

1. Laden Sie eine [Presentation] und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [IAutoShape] hinzu und entfernen Sie dessen Standardabsatz.
3. Erstellen Sie zwei Absätze und fügen Sie ihnen Textportionen hinzu.
4. Erstellen Sie ein [PortionFormat] für das Endzeichen des zweiten Absatzes.
5. Setzen Sie [IBasePortionFormat.FontHeight] und [IBasePortionFormat.LatinFont].
6. Weisen Sie das Format [IParagraph.EndParagraphPortionFormat] zu und speichern Sie die Präsentation.

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

## **Absatzinhalt importieren und exportieren**

### **HTML‑Text in Absätze importieren**

Verwenden Sie [ParagraphCollection.AddFromHtml], um HTML‑Markup in Absätze und Portionen eines Textrahmens zu konvertieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) .
2. Greifen Sie auf eine Folie zu und fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) hinzu.
3. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) der Form zu und entfernen Sie den Standardabsatz.
4. Lesen Sie die Quell‑HTML‑Datei.
5. Übergeben Sie die HTML‑Zeichenkette an [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/de/net/aspose.slides/paragraphcollection/addfromhtml/) .
6. Speichern Sie die modifizierte Präsentation.

Dieses C#‑Beispiel importiert HTML in einen Textrahmen:

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

### **Absatz‑Text nach HTML exportieren**

Verwenden Sie [ParagraphCollection.ExportToHtml], um einen ausgewählten Bereich von Absätzen als HTML zu exportieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) und laden Sie die gewünschte Präsentation.
2. Greifen Sie auf die Folie zu und finden Sie das [IAutoShape], das den Text enthält.
3. Greifen Sie auf das [ITextFrame] der Form zu.
4. Rufen Sie [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/de/net/aspose.slides/paragraphcollection/exporttohtml/) mit dem Start‑Absatz‑Index und der Anzahl der zu exportierenden Absätze auf.
5. Schreiben Sie die zurückgegebene HTML‑Zeichenkette in eine Datei.

Dieses C#‑Beispiel exportiert alle Absätze aus dem ersten Text‑Shape:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Einen Absatz als Bild rendern**

[IParagraph.GetImage] rendert einen einzelnen Absatz direkt und gibt ein [IImage] zurück. Speichern Sie das Ergebnis mit [IImage.Save] in eine Datei oder einen Stream. Sie müssen die enthaltende Form nicht rendern oder ein Bitmap manuell zuschneiden.

[IParagraph.GetImage] kann `null` zurückgeben, wenn der Absatz in seiner übergeordneten Sammlung nicht gefunden wird, keine gültigen Render‑Grenzen hat oder nicht gerendert werden kann. Prüfen Sie das Ergebnis vor dem Speichern und geben Sie das zurückgegebene Bild nach der Verwendung frei.

#### **Einen Absatz mit Standardskala rendern**

Nehmen wir an, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, auf der die erste Form ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

Das folgende Beispiel rendert den zweiten Absatz in einer normalen Textform bei der Standardskala und speichert das zurückgegebene Bild im PNG‑Format. Die `using`‑Deklaration sorgt dafür, dass das Bild korrekt freigegeben wird.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Einen Absatz in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [IParagraph.GetImage], die die Parameter `float scaleX` und `float scaleY` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende Beispiel erstellt eine Tabelle, rendert den Absatz in ihrer ersten Zelle mit dem Doppelten der Standardbreite und -höhe und speichert das Ergebnis als PNG‑Bild.

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

Ein Skalierungsfaktor von `1` hält diese Achse auf ihrer Standard‑Pixelgröße. Zum Beispiel erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa doppelt so groß wie die Standardmaße sind, was zu viermal so vielen Pixeln führt. Größere Faktoren erzeugen im Allgemeinen schärferen Text für Zoom oder hochauflösende Ausgaben, erhöhen jedoch auch den Speicherverbrauch und die Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Absatzes beizubehalten; unterschiedliche horizontale und vertikale Faktoren strecken die Ausgabe jeweils separat.

Das Rendern einer gesamten Form mit [IShape.GetImage] bleibt nützlich, wenn die Ausgabe die Füllung, den Rand oder andere visuelle Kontexte der Form enthalten muss. Für ein Bild, das nur den Absatz enthält, verwenden Sie [IParagraph.GetImage].

## **FAQ**

**Kann ich das Zeilenumbruch‑Verhalten in einem Textrahmen vollständig deaktivieren?**

Ja. Setzen Sie [ITextFrameFormat.WrapText], um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des Textrahmens umgebrochen werden.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes erhalten?**

Verwenden Sie [IParagraph.GetRect], um das begrenzende Rechteck des Absatzes abzurufen. [IPortion.GetRect] liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatzausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[IParagraphFormat.Alignment] ist eine Einstellung auf Absatzebene und gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich die Rechtschreibsprache für einen Teil eines Absatzes festlegen?**

Ja. Setzen Sie [IBasePortionFormat.LanguageId] für einzelne Portionen, sodass ein Absatz Text in mehreren Sprachen enthalten kann.