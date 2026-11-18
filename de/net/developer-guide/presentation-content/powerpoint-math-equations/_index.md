---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in .NET hinzufügen
linktitle: PowerPoint mathematische Gleichungen
type: docs
weight: 80
url: /de/net/powerpoint-math-equations/
keywords:
- mathematische Gleichung
- mathematisches Symbol
- mathematische Formel
- mathematischer Text
- mathematische Gleichung hinzufügen
- mathematisches Symbol hinzufügen
- mathematische Formel hinzufügen
- mathematischen Text hinzufügen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für .NET einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare C#-Codebeispiele."
---
## **Übersicht**

PowerPoint speichert Gleichungen im Office Math Markup Language (OMML). Mit Aspose.Slides für .NET können Sie denselben mathematischen Inhalt programmgesteuert erstellen: Brüche, Radikale, Funktionen, Grenzen, N‑stellige Operatoren, Matrizen, Arrays und formatierte mathematische Blöcke.

In PowerPoint fügen Benutzer Gleichungen normalerweise über **Einfügen > Gleichung** hinzu:

![PowerPoint Insert-Registerkarte mit dem Befehl Gleichung ausgewählt](powerpoint-math-equations_1.png)

Das Ergebnis ist editierbarer mathematischer Text auf der Folie:

![Eine PowerPoint-Folie mit einer editierbaren mathematischen Gleichung](powerpoint-math-equations_2.png)

Aspose.Slides erzeugt diesen mathematischen Text über drei Hauptobjekte:

- Eine mathematische Form, erstellt mit [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), ist die Form, die die Gleichung enthält.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) speichert mathematischen Inhalt im Textfeld der Form.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) enthält ein oder mehrere [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) Objekte.

Die meisten Beispiele unten verwenden [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) und die Fluent-Methoden von [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/), um den Code kurz und lesbar zu halten.

Für MathML-Export‑Szenarien siehe [Exportieren von mathematischen Gleichungen aus Präsentationen in .NET](/slides/de/net/exporting-math-equations/).

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) erstellt eine Form, die bereits einen mathematischen Absatz enthält. Greifen Sie auf das erste [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), erhalten Sie dessen [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), und fügen Sie mathematische Blöcke oder Elemente hinzu.
{{% /alert %}}

## **Brüche hinzufügen**

Verwenden Sie [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/), um einen Bruch zu erstellen. Sie können einen Bruchstil mit [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) wählen.

![Ein schräger mathematischer Bruch, der eins durch x darstellt](powerpoint-math-equations_4.png)

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

Verwenden Sie [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/), um eine Quadratwurzel, Kubikwurzel oder andere Wurzel zu erstellen. Das aktuelle Element wird zur Basis, und das Argument wird zum Grad.

![Ein n‑ter Wurzelausdruck mit x unter dem Wurzelzeichen](powerpoint-math-equations_5.png)

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

### **Grad einer Quadratwurzel anzeigen oder ausblenden**

Eine Quadratwurzel kann eine explizite 2 anzeigen oder die konventionelle √x‑Notation verwenden. Die Eigenschaft [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) von [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) steuert, welche Form erscheint. Beide Formen behalten den Grad 2 und den Radikanden x in der editierbaren Gleichung bei.

![Die gleiche Quadratwurzel, bei der HideDegree links auf false und rechts auf true gesetzt ist](square-root-degree.png)

Das Beispiel speichert dieselbe Quadratwurzel zweimal. In `visible-degree.pptx` ist die 2 sichtbar. In `hidden-degree.pptx` ist sie ausgeblendet.

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

Verwenden Sie [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) oder [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), um Funktionen wie `sin(x)`, `log(x)` oder benutzerdefinierte Funktionsnamen zu erstellen. Für Grenzen setzen Sie `lim` in einen [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) oder verwenden Sie [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

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

Verwenden Sie [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), um Summen, Vereinigungen, Schnittmengen und andere große Operatoren zu erzeugen. Verwenden Sie [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/), um Integrale zu erzeugen. Beide Methoden ermöglichen das Festlegen von unteren und oberen Grenzen.

![Eine Summe mit unteren und oberen Grenzen](powerpoint-math-equations_7.png)

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

N‑stellige Operatoren sind für große Operatoren mit optionalen Grenzen vorgesehen. Einfache Operatoren wie `+`, `-` und `=` werden normalerweise als [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) hinzugefügt und in den Ausdruck eingefügt.

Für ein Integral verwenden Sie [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Matrizen hinzufügen**

Verwenden Sie [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/), um Zeilen und Spalten zu erzeugen. Matrizen enthalten standardmäßig keine Klammern, daher sollten Sie die Matrix einschließen, wenn Sie Klammern, eckige Klammern oder geschweifte Klammern benötigen.

![Eine zweizeilige mathematische Matrix mit einer leeren Zelle](powerpoint-math-equations_10.png)

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

### **Vorhandene Matrix bearbeiten**

Nehmen wir an, eine Lineare‑Algebra‑Stunde beginnt mit der Koeffizientenmatrix in `matrix.pptx`, die durch das vorherige Beispiel gespeichert wurde. Für die nächste Übung behalten Sie die erste Gleichung bei, ersetzen die zweite durch zwei neue Gleichungen und überarbeiten den Variablen­satz. Öffnen Sie die vorhandene Matrix über [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/), um die noch gültigen Koeffizienten zu erhalten.

![Ursprüngliche zweizeilige Koeffizientenmatrix mit den Einträgen 1, x und einer leeren Zelle in der ersten Zeile sowie x, 2 und y in der zweiten Zeile](matrix-before-edit.png)

Zeilen‑ und Spaltenindizes beginnen bei Null und beziehen sich auf die Matrix, wie sie bei jedem Aufruf steht. Das Einfügen einer Zeile vor Index 1 verschiebt die ursprüngliche zweite Zeile zu Index 2. Das Einfügen nach Index 2 fügt dann eine Zeile an. Das Löschen von Zeile 2 entfernt die ursprüngliche zweite Gleichung und verschiebt die angefügte Zeile eine Position nach oben. Spalten verschieben sich auf dieselbe Weise.

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

// Neue Zellen sind zunächst null. Setzen Sie zuerst die von Null verschiedenen Koeffizienten.
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

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) richtet die erste Spalte linksbündig aus. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) richtet drei aufeinanderfolgende Spalten rechtsbündig aus, beginnend bei Index 1. In `updated-matrix.pptx` hat die Matrix drei Gleichungen und vier Variablen. Die ursprünglichen Koeffizienten der ersten Zeile `1` und `x` erscheinen nun in der ersten und dritten Spalte.

![Aktualisierte dreizeilige Matrix, die die Zeilen 1, 0, x, 0; 12, 1, 0, 0; und 0, 0, 10, 1 zeigt](matrix-after-edit.png)

## **Gleichungs‑Arrays hinzufügen**

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

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) steuert die vertikale Ausrichtung eines Arrays relativ zu den mathematischen Elementen daneben. Das nachfolgende Beispiel vergleicht die Ausrichtung mit der ersten Zeile, der Mitte des Arrays und der letzten Zeile.

Das folgende Beispiel erstellt drei identische Arrays, jeweils mit drei Zeilen und den benachbarten Elementen `A=` und `=B`. Der gesamte mathematische Text verwendet Cambria Math in 24 Punkten. Nur die Array‑Ausrichtung ändert sich.

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

![Gleichungs‑Arrays in PowerPoint mit oberer, mittlerer und unterer Ausrichtung und identischen benachbarten Elementen](equation-array-alignment.png)

### **Zeilenabstand konfigurieren**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) wählt die Abstandregel für Zeilen im Array aus. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) liefert einen numerischen Wert für eine explizite Abstandregel und wird von den Voreinstellungen ignoriert.

Für genauen Abstand wird der Wert in Punkten gemessen. Für proportionalen Abstand wird er in halben Zeilen gemessen: Der Wert `3` im Beispiel entspricht 1,5 Zeilen. Setzen Sie beide Eigenschaften, wenn Sie einen expliziten Wert angeben; das alleinige Ändern des numerischen Wertes wählt keine Abstandregel aus.

Das untenstehende Beispiel speichert fünf Präsentationen mit denselben Gleichungen, Ausrichtungen und Font‑Einstellungen. Die ersten drei verwenden Voreinstellungen; die letzten beiden zeigen explizite Werte.

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

Der Zeilenabstand des Arrays ist getrennt vom Absatzabstand. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) und [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) fügen Abstand um den umgebenden Absatz hinzu, nicht zwischen Array‑Zeilen. Ebenso positioniert [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) den gesamten mathematischen Absatz horizontal; es ersetzt nicht die vertikale Ausrichtungs­einstellung des Arrays.

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

## **Indizes und Hochstellungen hinzufügen**

Verwenden Sie die Hilfsmethoden für Index und Hochstellung für Indizes und Potenzen. Wenn die Indizes links von der Basis erscheinen müssen, verwenden Sie [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Ein Groß‑Y mit linksseitigem Subscript 1 und Superscript n](powerpoint-math-equations_9.png)

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

## **Begrenzer hinzufügen**

Verwenden Sie [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/), um einen Ausdruck in Begrenzern zu setzen. Sie können auch ein Trennzeichen für Begrenzerausdrücke festlegen, die mehrere Elemente enthalten.

![Ein Begrenzerausdruck, der x, y und z enthält, getrennt durch senkrechte Striche](powerpoint-math-equations_13.png)

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

### **Größe und Ausrichtung von Begrenzern**

Setzen Sie [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) auf `true`, damit die Klammern um einen hohen Operanden wachsen, oder auf `false`, um sie in ihrer normalen Größe zu belassen. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) nimmt einen von zwei [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) Werten an. `Centered` zentriert die Klammern auf der mathematischen Achse, die durch die Mitte des Gleichheitszeichens verläuft. `Match` richtet sie an dem eingeschlossenen Inhalt aus. Beide Einstellungen betreffen nur die Begrenzern. Der Ausdruck im Inneren bleibt unverändert.

Das Beispiel platziert einen Bruch im Exponenten von `x`, sodass der Ausdruck weiter über die Grundlinie hinausreicht als darunter. Alle vier Gleichungen verwenden dieselben Klammern und Font‑Einstellungen.

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

In PowerPoint vergleichen Sie die Zeilen, um den Wachstumseffekt zu sehen. In der oberen Zeile wachsen die Klammern, um den Exponenten zu umschließen, und sehen bei beiden Formen gleich aus. In der unteren Zeile ist das Wachstum deaktiviert. Die kleineren Klammern links (`Centered`) sind an das Gleichheitszeichen ausgerichtet, während die rechts (`Match`) höher um den Ausdruck liegen.

![Vier Gleichungen in PowerPoint mit aktivem Begrenzungswachstum oben und deaktiviert unten, sowie `Centered` links und `Match` rechts](delimiter-sizing.png)

## **Rahmenbox hinzufügen**

Rufen Sie [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) für einen Bruch auf, um den gesamten Ausdruck zu umrahmen. Das zurückgegebene [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) zeigt standardmäßig alle vier Seiten. Verwenden Sie [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/), und [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/), um einzelne Seiten zu entfernen.

Das Beispiel platziert sechs Kopien desselben Bruchs auf einer Folie. Um eine Streichung zu zeigen, verbergen Sie alle vier Seiten und setzen Sie [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) für eine steigende Diagonale (↗) oder [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) für eine fallende Diagonale (↘). Sie können auch [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) oder [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) mit beliebiger Kombination sichtbarer Seiten verwenden.

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

![Sechs editierbare Brüche in PowerPoint. Obere Zeile: voller Rand, untere und linke Seite, steigende Diagonale. Untere Zeile: fallende Diagonale, horizontale Durchstreichung, vertikale Durchstreichung mit vollem Rand.](border-box-fractions.png)

Bei diesem Bruch überlappt die horizontale Durchstreichung den Bruchstrich. Die vertikale Durchstreichung kreuzt sowohl Zähler als auch Nenner, während der umgebende Rand sichtbar bleibt. Diese Linien schmücken den gesamten Ausdruck. Die gewöhnliche Text‑Durchstreichung gilt für Zeichen in einem Textlauf. Nach dem erneuten Öffnen der Präsentation in PowerPoint können Sie Zähler und Nenner weiterhin unabhängig bearbeiten.

## **Sichtbarkeit und Layout mit Phantom‑Elementen steuern**

Einen Ausdruck in [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) einbetten, um seine Sichtbarkeit und den Platz, den er einer Gleichung beisteuert, unabhängig zu steuern. Die Eigenschaften von [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) steuern Folgendes:

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Auf `false` setzen, um den Ausdruck auszublenden. Seine Abmessungen tragen weiterhin zum Layout bei, es sei denn, die entsprechenden Eigenschaften unten sind `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Die horizontale Breite des Ausdrucks als Null behandeln, sodass benachbarte Elemente näher zusammenrücken können. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Den Aufstieg, also die Höhe über der Grundlinie, als Null behandeln. Dies kann den über den benachbarten Elementen reservierten Abstand verringern. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Den Abstieg, also die Tiefe unterhalb der Grundlinie, als Null behandeln. Dadurch kann ein Bruchstrich oder anderer Inhalt unter dem Ausdruck näher an die Nachbarn rücken. |

Die Grundlinie ist die Referenzlinie, auf der gewöhnliche mathematische Zeichen sitzen. Das Ausblenden von Inhalten entfernt nicht deren Abmessungen, und das Behandeln einer Dimension als Null löscht den Ausdruck nicht. Der zugrunde liegende Ausdruck bleibt über [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) verfügbar. Setzen Sie [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) wieder auf `true`, um ihn erneut anzuzeigen; die Dimensionseinstellungen bleiben unverändert.

Das folgende Beispiel erstellt fünf nebeneinander stehende Varianten: einen sichtbaren Bruch, einen ausgeblendeten Bruch, der Platz reserviert, und drei ausgeblendete Brüche, bei denen jeweils eine Dimension als Null behandelt wird. Jede Variante verwendet denselben umgebenden Ausdruck und Cambria Math in 24 Punkten. Alle Gleichungsformen haben dieselbe obere Position, gekennzeichnet durch die graue Führungslinie. Das Platzieren des Phantoms im Zähler eines äußeren Bruchs erleichtert das Erkennen der vertikalen Layout‑Änderungen.

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

![Fünf Gleichungen in PowerPoint, die einen sichtbaren Bruch, einen ausgeblendeten Bruch, der Platz reserviert, und ausgeblendete Brüche mit aktiviertem ZeroWidth, ZeroAsc oder ZeroDesc vergleichen](math-phantom.png)

## **Terme gruppieren**

Verwenden Sie [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/), um ein Gruppierungszeichen über oder unter einem Ausdruck zu platzieren. Fügen Sie eine Grenze hinzu, um die gruppierten Terme zu beschriften.

![Der Ausdruck x + y gruppiert mit der Beschriftung beliebiger Text darunter](powerpoint-math-equations_15.png)

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

Verwenden Sie Formatierungs‑Hilfsmethoden nur dort, wo sie die Formel verdeutlichen. Zum Beispiel platziert [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) einen Balken über einem mathematischen Element.

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

Um Text in einer gesamten vorhandenen Gleichung zu formatieren, traversieren Sie den Elementbaum jedes mathematischen Blocks. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) liefert nur die unmittelbaren Kinder, daher rufen Sie es rekursiv auf, um Text in Brüchen, Skripten, Radikalen und anderen verschachtelten Strukturen zu erreichen. Prüfen Sie das aktuelle Element sowie dessen Kinder, um das Ausgangselement einzubeziehen, wenn es [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) ist.

Dieses Beispiel geht davon aus, dass eine Präsentation eine Gleichung wie `z = xᵢ / ∛y` enthält, wobei ein Bruch ein Subscript im Zähler und ein Radikal im Nenner hat. Das Beispiel findet mathematische Abschnitte in Folientextfeldern, greift über [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) auf deren Blöcke zu und setzt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) auf 28 Punkte über die [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/)‑Eigenschaft jedes Textelements.

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

## **Kurzreferenz**

| Aufgabe | Haupt‑API |
| --- | --- |
| Mathematischen Text erstellen | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Elemente kombinieren | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Brüche erstellen | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Hoch- oder Tiefstellung hinzufügen | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Funktionen hinzufügen | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Radikale hinzufügen | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Grenzen hinzufügen | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Linke Skripte hinzufügen | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Summen und Integrale hinzufügen | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Matrizen hinzufügen | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Gleichungs‑Arrays hinzufügen | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Begrenzer hinzufügen | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Balken und Rahmen hinzufügen | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Terme gruppieren | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Kann ich eine vorhandene PowerPoint‑Gleichung bearbeiten?**

Ja. Öffnen Sie die Präsentation, finden Sie die Form, die ein [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) enthält, erhalten Sie deren [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), und aktualisieren Sie die mathematischen Blöcke in diesem Absatz.

**Werden Gleichungen als editierbare PowerPoint‑Mathematik gespeichert?**

Ja. Beim Speichern als PPTX schreibt Aspose.Slides die Gleichung als editierbaren Office‑Math‑Inhalt.

**Kann ich Gleichungen nach LaTeX exportieren?**

Ja. Holen Sie das [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) der Gleichung aus ihrem [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), und rufen Sie [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) auf, um sie direkt zu exportieren. Ein vollständiges Beispiel finden Sie unter [Export Math Equations from Presentations in .NET](/slides/de/net/exporting-math-equations/#export-math-equations-to-latex).