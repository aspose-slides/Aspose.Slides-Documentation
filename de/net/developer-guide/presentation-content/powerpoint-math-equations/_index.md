---
title: Math-Gleichungen zu PowerPoint-Präsentationen in .NET hinzufügen
linktitle: PowerPoint-Math-Gleichungen
type: docs
weight: 80
url: /de/net/powerpoint-math-equations/
keywords:
- Mathegleichung
- Mathezeichen
- Matheformel
- Mathetext
- Mathegleichung hinzufügen
- Mathezeichen hinzufügen
- Matheformel hinzufügen
- Mathetext hinzufügen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Math-Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für .NET einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare C#‑Beispielcode."
---
## **Übersicht**

PowerPoint speichert Gleichungen als Office Math Markup Language (OMML). Mit Aspose.Slides für .NET können Sie dieselbe Art von mathematischem Inhalt programmgesteuert erstellen: Brüche, Radikale, Funktionen, Grenzwerte, n‑stellige Operatoren, Matrizen, Arrays und formatierte mathematische Blöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** ein:

![PowerPoint-Registerkarte Einfügen mit dem Befehl Gleichung ausgewählt](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint‑Folie, die eine editierbare mathematische Gleichung enthält](powerpoint-math-equations_2.png)

Aspose.Slides erstellt diesen mathematischen Text über drei Hauptobjekte:

- Eine mathematische Form, erstellt mit [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), ist die Form, die die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) speichert mathematischen Inhalt im Text‑Frame der Form.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)-Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) und die Fluent‑Methoden von [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/), um den Code kurz und lesbar zu halten.

Für MathML‑Export‑Szenarien siehe [Mathematische Gleichungen aus Präsentationen in .NET exportieren](/slides/de/net/exporting-math-equations/).

## **Gleichung erstellen**

Dieses Beispiel verwendet [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), um eine mathematische Form zu erstellen und fügt den Satz des Pythagoras hinzu:

![Die Gleichung c² = a² + b²](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) erstellt eine Form, die bereits einen mathematischen Paragraphen enthält. Greifen Sie auf den ersten [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) zu, holen Sie dessen [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), und fügen Sie Matheblöcke oder mathematische Elemente hinzu.
{{% /alert %}}

### **Matheblöcke kombinieren**

Wenn Teile einer Gleichung unabhängig als [IMathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/)‑Objekte gebaut werden, benutzen Sie [JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/), um sie zu kombinieren. Das Beispiel baut `c² =` im linken Block und `a² + b²` im rechten Block. [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/) erzeugt editierbare mathematische Hochstellungen für alle drei Potenzen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddMathShape(20, 20, 600, 100);
var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var leftBlock = new MathBlock();
leftBlock.Add(new MathematicalText("c").SetSuperscript("2"));
leftBlock.Add(new MathematicalText("="));

var rightBlock = new MathBlock();
rightBlock.Add(new MathematicalText("a").SetSuperscript("2"));
rightBlock.Add(new MathematicalText("+"));
rightBlock.Add(new MathematicalText("b").SetSuperscript("2"));

var combinedBlock = leftBlock.JoinBlock(rightBlock);
mathParagraph.Add(combinedBlock);

presentation.Save("equation.pptx", SaveFormat.Pptx);
```

[JoinBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathblock/joinblock/) gibt `leftBlock` selbst zurück, das nun beide Teile in Reihenfolge enthält, und lässt `rightBlock` leer. Fügen Sie den kombinierten Block nur einmal zu [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) hinzu. Nach erneutem Öffnen von `equation.pptx` enthält der Paragraph einen Block, der `c² = a² + b²` darstellt, wobei alle drei Potenzen als mathematische Hochstellungen erhalten bleiben.

Der Aufruf von [Add](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelementcollection/add/) als `leftBlock.Add(rightBlock)` versucht stattdessen, einen Block direkt in einen anderen zu verschachteln, und wirft `InvalidOperationException`.

## **Brüche hinzufügen**

Verwenden Sie [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/), um einen Bruch zu erzeugen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) auswählen.

![Ein schräger mathematischer Bruch, der eins geteilt durch x zeigt](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Für einen gestapelten Bruch verwenden Sie [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Radikale hinzufügen**

Verwenden Sie [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erzeugen. Das aktuelle Element wird zur Basis, und das Argument wird zum Grad.

![Ein n‑ter Wurzel‑Radikalausdruck mit x unter dem Radikalsymbol](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

### **Grad einer Quadratwurzel anzeigen oder verbergen**

Eine Quadratwurzel kann eine explizite 2 anzeigen oder die konventionelle √x‑Notation verwenden. Die [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/)-Eigenschaft von [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) steuert, welche Form erscheint. Beide Formen behalten den Grad 2 und den Radikanden x in der editierbaren Gleichung bei.

![Die gleiche Quadratwurzel mit HideDegree auf false links und true rechts](square-root-degree.png)

Das Beispiel speichert dieselbe Quadratwurzel zweimal. In `visible-degree.pptx` ist die 2 sichtbar. In `hidden-degree.pptx` ist sie verborgen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **Funktionen und Grenzen hinzufügen**

Verwenden Sie [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) oder [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) für Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen. Für Grenzen setzen Sie `lim` in ein [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) oder benutzen Sie [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Der Grenzwert von x, wenn x gegen unendlich geht](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Für einen benutzerdefinierten Funktionsnamen machen Sie den Funktionsnamen zum aktuellen Element und rufen [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) mit seinem Argument auf:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **N‑stellige Operatoren und Integrale hinzufügen**

Verwenden Sie [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) für Summationen, Vereinigungen, Schnittmengen und andere große Operatoren. Verwenden Sie [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) für Integrale. Beide Methoden erlauben das Festlegen von unteren und oberen Grenzen.

![Eine Summation mit unteren und oberen Grenzen](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

N‑stellige Operatoren dienen großen Operatoren mit optionalen Grenzen. Einfache Operatoren wie `+`, `-` und `=` werden in der Regel als [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) hinzugefügt und in den Ausdruck eingebunden.

Für ein Integral verwenden Sie [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) für Zeilen und Spalten. Matrizen enthalten standardmäßig keine Klammern, daher umschließen Sie die Matrix, wenn Sie Klammern, eckige Klammern oder geschweifte Klammern benötigen.

![Eine mathematische Matrix mit zwei Reihen und einer leeren Zelle](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

### **Eine vorhandene Matrix bearbeiten**

Angenommen, eine lineare‑Algebra‑Stunde beginnt mit der Koeffizientenmatrix in `matrix.pptx`, gespeichert vom vorherigen Beispiel. Für die nächste Übung behalten Sie die erste Gleichung, ersetzen die zweite durch zwei neue Gleichungen und überarbeiten die Variablenmenge. Öffnen Sie die vorhandene Matrix über [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/), um die noch gültigen Koeffizienten zu erhalten.

![Original‑Matrix mit zwei Reihen, Einträge 1, x und einer leeren Zelle in der ersten Reihe sowie x, 2 und y in der zweiten Reihe](matrix-before-edit.png)

Zeilen‑ und Spaltenindizes beginnen bei 0 und beziehen sich auf die aktuelle Matrix bei jedem Aufruf. Das Einfügen einer Zeile vor Index 1 verschiebt die ursprüngliche zweite Zeile zu Index 2. Das Einfügen nach Index 2 fügt dann eine Zeile an. Das Löschen von Zeile 2 entfernt die ursprüngliche zweite Gleichung und verschiebt die angefügte Zeile um eine Position nach oben. Spalten verschieben sich analog.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// Neue Zellen sind zunächst null. Setzen Sie zuerst die von null verschiedenen Koeffizienten.
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) richtet die erste Spalte linksbündig aus. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) richtet drei aufeinander folgende Spalten rechtsbündig aus, beginnend bei Index 1. In `updated-matrix.pptx` hat die Matrix drei Gleichungen und vier Variablen. Die ursprünglichen Koeffizienten der ersten Zeile `1` und `x` erscheinen nun in der ersten bzw. dritten Spalte.

![Aktualisierte Matrix mit drei Reihen, die die Reihen 1, 0, x, 0; 12, 1, 0, 0; und 0, 0, 10, 1 zeigt](matrix-after-edit.png)

## **Gleichungsarrays hinzufügen**

Verwenden Sie [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/), wenn Sie ausgerichtete Gleichungen oder einen vertikalen Stapel von Ausdrücken benötigen.

![Ein vertikales mathematisches Array mit x über y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

### **Ein Array mit umgebenden Elementen ausrichten**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) steuert die vertikale Ausrichtung eines Arrays relativ zu den benachbarten mathematischen Elementen. Das folgende Beispiel vergleicht die Ausrichtung mit der ersten Zeile, dem Mittelpunkt des Arrays und der letzten Zeile.

Das folgende Beispiel erzeugt drei identische Arrays, je mit drei Zeilen und den Nachbarelementen `A=` und `=B`. Der gesamte mathematische Text verwendet Cambria Math in 24 pt. Nur die Array‑Ausrichtung ändert sich.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Der folgende Vergleich zeigt die gespeicherte Präsentation in PowerPoint. Beachten Sie die Position von `A=` und `=B` neben jedem Array.

![Gleichungsarrays in PowerPoint mit oberer, mittiger und unterer Ausrichtung und identischen umgebenden Elementen](equation-array-alignment.png)

### **Zeilenabstand konfigurieren**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) wählt die Abstand‑Regel für Zeilen innerhalb des Arrays. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) liefert einen numerischen Wert für eine explizite Abstand‑Regel und wird von den Voreinstellungen ignoriert.

Für exakten Abstand wird der Wert in Punkten gemessen. Für proportionalen Abstand wird in halben Zeilen gemessen: Der Wert `3` im Beispiel entspricht 1,5 Zeilen. Setzen Sie beide Eigenschaften, wenn Sie einen expliziten Wert angeben; das alleinige Ändern des numerischen Werts wählt keine Abstand‑Regel aus.

Das Beispiel unten speichert fünf Präsentationen mit denselben Gleichungen, derselben Ausrichtung und denselben Schrift‑Einstellungen. Die ersten drei verwenden Voreinstellungen; die letzten beiden zeigen explizite Werte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Der Zeilenabstand im Array ist unabhängig vom Absatzabstand. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) und [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) fügen Abstand um den enthaltenden Absatz hinzu, nicht zwischen Array‑Zeilen. Ebenso positioniert [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) den gesamten mathematischen Absatz horizontal; es ersetzt nicht die vertikale Ausrichtung des Arrays.

## **Trigonometrische Funktionen hinzufügen**

Verwenden Sie [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/), wenn das Argument das aktuelle Element ist und der Funktionsname bekannt ist.

![Die trigonometrische Funktion cos angewendet auf 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Tief- und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsfunktionen für Tief‑ und Hochstellungen für Indizes und Potenzen. Wenn die Indizes auf der linken Seite der Basis erscheinen sollen, benutzen Sie [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Ein Großbuchstabe Y mit linksseitigem Tiefstellung 1 und Hochstellung n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

### **Rechte Tief- und Hochstellungen ausrichten**

Wenn beide Skripte derselben Basis zugeordnet sind, benutzen Sie [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement/). Seine [AlignScripts](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathrightsubsuperscriptelement/alignscripts/)‑Eigenschaft steuert ihre horizontale Position: `false` (Standard) lässt sie der Kontur der Basis folgen, während `true` die Skripte horizontal ausrichtet.

Dieses Beispiel platziert zwei Kopien des gleichen editierbaren Ausdrucks nebeneinander. Beide verwenden das mathematische Kursiv‑f (U+1D453), eine tiefgestellte 1, eine hochgestellte 2 und Cambria Math in 72 pt. Die schräge Basis macht den Unterschied in PowerPoint sichtbar. Installieren Sie Cambria Math, bevor Sie das Beispiel ausführen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(900, 250, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var format = new PortionFormat
{
    FontHeight = 72,
    LatinFont = new FontData("Cambria Math")
};

for (var i = 0; i < 2; i++)
{
    var left = 40 + i * 440;
    var shape = slide.Shapes.AddMathShape(left, 75, 380, 150);

    var baseText = new MathematicalText("\U0001D453", format);
    var subscript = new MathematicalText("1", format);
    var superscript = new MathematicalText("2", format);
    var scripts = new MathRightSubSuperscriptElement(baseText, subscript, superscript);
    scripts.AlignScripts = i == 1;

    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = format.FontHeight;
    portion.PortionFormat.LatinFont = format.LatinFont;
    portion.MathParagraph.Add(new MathBlock(scripts));
}

presentation.Save("aligned-scripts.pptx", SaveFormat.Pptx);
```

![Zwei editierbare Ausdrücke in PowerPoint mit AlignScripts auf false links und true rechts](aligned-scripts.png)

Links beginnt die tiefgestellte Zahl weiter links als die hochgestellte, da sie der Kontur der Basis folgt. Rechts sind die beiden Skripte horizontal zueinander ausgerichtet.

## **Begrenzungszeichen hinzufügen**

Verwenden Sie [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/), um einen Ausdruck in Begrenzungszeichen zu setzen. Sie können außerdem ein Trennzeichen‑Zeichen für Begrenzungs‑Ausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Begrenzungszeichenausdruck, der x, y und z enthält, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

### **Größe und Ausrichtung von Begrenzungszeichen**

Setzen Sie [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) auf `true`, damit die Klammern um einen hohen Operanden wachsen, oder auf `false`, um sie in ihrer normalen Größe zu belassen. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) nimmt einen von zwei [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/)‑Werten an. `Centered` zentriert die Klammern auf der mathematischen Achse, die durch die Mitte des Gleichheitszeichens verläuft. `Match` richtet sie an dem eingeschlossenen Inhalt aus. Beide Einstellungen betreffen nur die Begrenzungszeichen. Der innere Ausdruck bleibt unverändert.

Das Beispiel setzt einen Bruch in den Exponenten von `x`, sodass der Ausdruck weiter über die Grundlinie hinaus reicht als darunter. Alle vier Gleichungen verwenden dieselben Klammern und Schrift‑Einstellungen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

Vergleichen Sie in PowerPoint die Zeilen, um den Effekt des Wachstums zu sehen. In der oberen Zeile wachsen die Klammern, um den Exponenten zu umschließen, und sehen bei beiden Formen gleich aus. In der unteren Zeile ist das Wachstum deaktiviert. Die kleineren Klammern links (`Centered`) richten sich an dem Gleichheitszeichen aus, während die rechts (`Match`) höher um den Ausdruck liegen.

![Vier Gleichungen in PowerPoint mit aktiviertem Begrenzungszeichenwachstum oben und deaktiviert unten, sowie Centered links und Match rechts](delimiter-sizing.png)

## **Ein Rahmenfeld hinzufügen**

Rufen Sie [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) für einen Bruch auf, um den gesamten Ausdruck zu umrahmen. Das zurückgegebene [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) zeigt standardmäßig alle vier Seiten. Verwenden Sie [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) und [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/), um einzelne Seiten zu entfernen.

Das Beispiel platziert sechs Kopien desselben Bruchs auf einer Folie. Um eine Streichung darzustellen, verstecken Sie alle vier Seiten und setzen [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) für eine aufsteigende Diagonale (↗) oder [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) für eine absteigende Diagonale (↘). Sie können auch [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) oder [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) mit beliebiger Kombination sichtbarer Seiten verwenden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![Sechs editierbare Brüche in PowerPoint. Obere Zeile: voller Rahmen, untere und linke Seiten, aufsteigende Diagonale. Untere Zeile: absteigende Diagonale, horizontaler Strich, vertikaler Strich mit vollem Rahmen](border-box-fractions.png)

Bei diesem Bruch überlappt der horizontale Strich den Bruchstrich. Der vertikale Strich schneidet sowohl Zähler als auch Nenner, während der umgebende Rahmen sichtbar bleibt. Diese Linien dekorieren den gesamten Ausdruck. Der normale Text‑Durchstreich‑Effekt gilt für Zeichen in einem Textlauf. Nach erneutem Öffnen der Präsentation in PowerPoint können Sie Zähler und Nenner weiterhin getrennt bearbeiten.

## **Sichtbarkeit und Layout mit Phantom‑Elementen steuern**

Umwickeln Sie einen Ausdruck mit [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/), um seine Sichtbarkeit und den Platz, den er einer Gleichung beiträgt, unabhängig zu steuern. Die Eigenschaften von [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) steuern das Folgende:

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Auf `false` setzen, um den Ausdruck zu verbergen. Seine Abmessungen tragen weiterhin zum Layout bei, es sei denn, die nachfolgenden Eigenschaften sind `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Die horizontale Breite des Ausdrucks als Null behandeln, sodass benachbarte Elemente näher zusammenrücken. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Die Aufwärts­höhe (Höhe über der Grundlinie) als Null behandeln. Das kann den über benachbarten Elementen reservierten Raum reduzieren. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Die Abwärts­höhe (Tiefe unter der Grundlinie) als Null behandeln. Das kann einen Bruchstrich oder anderen Inhalt unter dem Ausdruck näher an die Nachbarn bringen. |

Die Grundlinie ist die Referenzlinie, auf der gewöhnliche mathematische Buchstaben sitzen. Das Verbergen von Inhalt entfernt nicht seine Abmessungen, und das Behandeln einer Dimension als Null löscht den Ausdruck nicht. Der zugrunde liegende Ausdruck bleibt über [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) verfügbar. Setzen Sie [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) wieder auf `true`, um ihn erneut anzuzeigen; die Dimensionseinstellungen bleiben unverändert.

Das Beispiel unten erstellt fünf nebeneinander stehende Varianten: einen sichtbaren Bruch, einen verborgenen Bruch, der Platz reserviert, und drei verborgene Brüche, bei denen jeweils eine Dimension als Null behandelt wird. Jede Variante verwendet denselben umgebenden Ausdruck und Cambria Math in 24 pt. Alle Gleichungsformen haben dieselbe obere Position, markiert durch die graue Hilfslinie. Das Platzieren des Phantoms im Zähler eines äußeren Bruchs macht die vertikalen Layout‑Änderungen leichter erkennbar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![Fünf Gleichungen in PowerPoint, die einen sichtbaren Bruch, einen verborgenen Bruch, der Platz reserviert, und verborgene Brüche mit ZeroWidth, ZeroAsc bzw. ZeroDesc zeigen](math-phantom.png)

## **Terme gruppieren**

Verwenden Sie [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y gruppiert mit der Beschriftung irgendein Text darunter](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Mathematische Elemente formatieren**

Verwenden Sie Formatierungshilfen nur dort, wo sie die Formel verdeutlichen. Zum Beispiel setzt [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) einen Strich über ein mathematisches Element.

![Ein mathematischer Ausdruck ABC mit einem Überstrich](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **Text in einer vorhandenen Gleichung formatieren**

Um Text in einer bestehenden Gleichung zu formatieren, durchlaufen Sie den Elementbaum jedes Mathe‑Blocks. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) gibt nur die unmittelbaren Kinder zurück, rufen Sie sie also rekursiv auf, um Text in Brüchen, Skripten, Radikalen und anderen verschachtelten Strukturen zu erreichen. Prüfen Sie sowohl das aktuelle Element als auch dessen Kinder, um das Ausgangselement einzubeziehen, wenn es sich um [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) handelt.

Dieses Beispiel geht davon aus, dass eine Präsentation eine Gleichung wie `z = xᵢ / ∛y` enthält, wobei ein Bruch eine tiefgestellte Zahl im Zähler und ein Radikal im Nenner hat. Das Verarbeiten nur der obersten Elemente des Blocks würde den Text im Bruch übersehen. Das Beispiel findet mathematische Portionen in Folientext‑Frames, greift über [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) auf deren Blöcke zu und setzt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) über jedes Textelement‑[Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) auf 28 pt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

Die gespeicherte Präsentation enthält die aktualisierte Textformatierung auf jeder Ebene jeder verarbeiteten Gleichung, während ihr Textinhalt und ihre mathematische Struktur erhalten bleiben.

## **Kurzer Überblick**

| Aufgabe | Main API |
| --- | --- |
| Mathetext erstellen | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Elemente kombinieren | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Brüche erstellen | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Hoch‑ oder Tiefstellung hinzufügen | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Funktionen hinzufügen | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Radikale hinzufügen | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Grenzen hinzufügen | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Linksseitige Skripte hinzufügen | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Summen und Integrale hinzufügen | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Gleichungsarrays hinzufügen | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Begrenzungszeichen hinzufügen | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Balken und Rahmen hinzufügen | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Terme gruppieren | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kann ich eine vorhandene PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie die Form, die ein [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) enthält, holen Sie deren [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), und aktualisieren Sie die Matheblöcke in diesem Paragraphen.

**Werden Gleichungen als editierbare PowerPoint‑Mathe gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Mathe‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie das [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) der Gleichung aus ihrem [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), und rufen Sie [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) auf, um sie direkt zu exportieren. Für ein vollständiges Beispiel siehe [Mathematische Gleichungen aus Präsentationen in .NET exportieren](/slides/de/net/exporting-math-equations/#export-math-equations-to-latex).