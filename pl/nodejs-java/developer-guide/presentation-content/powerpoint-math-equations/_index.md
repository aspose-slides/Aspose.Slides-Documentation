---
title: Dodaj równania matematyczne do prezentacji PowerPoint w JavaScript
linktitle: Równania matematyczne PowerPoint
type: docs
weight: 80
url: /pl/nodejs-java/powerpoint-math-equations/
keywords:
- równanie matematyczne
- symbol matematyczny
- formuła matematyczna
- tekst matematyczny
- dodaj równanie matematyczne
- dodaj symbol matematyczny
- dodaj formułę matematyczną
- dodaj tekst matematyczny
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Wstaw i edytuj równania matematyczne w plikach PowerPoint PPT i PPTX za pomocą Aspose.Slides for Node.js via Java, obsługując OMML, kontrolę formatowania i klarowne przykłady kodu JavaScript."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Dzięki Aspose.Slides for Node.js via Java możesz programowo tworzyć tego samego rodzaju treści matematyczne: ułamki, pierwiastki, funkcje, granice, operatory n‑ary, macierze, tablice oraz sformatowane bloki matematyczne.

W programie PowerPoint użytkownicy zazwyczaj dodają równania z **Wstaw > Równanie**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Wynikiem jest edytowalny tekst matematyczny na slajdzie:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides buduje ten tekst matematyczny za pomocą trzech głównych obiektów:

- Kształt matematyczny, tworzony metodą [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), jest kształtem zawierającym równanie.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) przechowuje treść matematyczną wewnątrz ramki tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

Większość poniższych przykładów używa [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) oraz metod fluent z [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), aby kod był krótki i czytelny.

W scenariuszach eksportu MathML zobacz [Export Math Equations from Presentations in Node.js via Java](/slides/pl/nodejs-java/exporting-math-equations/).

## **Utwórz równanie**

Ten przykład używa [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) do utworzenia kształtu matematycznego i dodaje twierdzenie Pitagorasa:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Uwaga" %}}

[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj dostęp do pierwszego [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), wywołaj [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) i dodaj do niego bloki lub elementy matematyczne.

{{% /alert %}}

### **Łączenie bloków matematycznych**

Gdy części równania są budowane niezależnie jako obiekty [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/), użyj [joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock), aby je połączyć. Przykład buduje `c² =` w lewym bloku i `a² + b²` w prawym bloku. [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSuperscript) tworzy edytowalne superskrypty dla wszystkich trzech potęg.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const mathParagraph = mathPortion.getMathParagraph();

    const leftBlock = new slides.MathBlock();
    leftBlock.add(new slides.MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new slides.MathematicalText("="));

    const rightBlock = new slides.MathBlock();
    rightBlock.add(new slides.MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new slides.MathematicalText("+"));
    rightBlock.add(new slides.MathematicalText("b").setSuperscript("2"));

    const combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) zwraca sam `leftBlock`, teraz zawierający obie części w kolejności, a `rightBlock` pozostaje pusty. Dodaj połączony blok do [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) tylko raz. Po ponownym otwarciu `equation.pptx` akapit zawiera jeden blok reprezentujący `c² = a² + b²`, przy zachowaniu wszystkich trzech potęg jako superskryptów matematycznych.

Wywołanie [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#add) jako `leftBlock.add(rightBlock)` próbuje zagnieździć jeden blok bezpośrednio w drugim i zgłasza `InvalidOperationException`.

## **Dodaj ułamki**

Użyj [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide), aby utworzyć ułamek. Możesz wybrać styl ułamka za pomocą [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla ułamka stosowanego pionowo użyj [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Dodaj pierwiastki**

Użyj [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical), aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Obecny element staje się podstawą, a argument określa stopień.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pokaż lub ukryj stopień pierwiastka kwadratowego**

Pierwiastek kwadratowy może wyświetlać wyraźne 2 lub używać konwencjonalnej notacji √x. Metoda [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) klasy [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) steruje, która forma jest wyświetlana. Obie formy zachowują stopień 2 i radicand x w edytowalnym równaniu.

![The same square root with the degree visible on the left and hidden on the right](square-root-degree.png)

Przykład zapisuje ten sam pierwiastek kwadratowy dwukrotnie. W `visible-degree.pptx` 2 jest widoczne. W `hidden-degree.pptx` jest ukryte.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj funkcje i granice**

Użyj [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) lub [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) dla funkcji takich jak `sin(x)`, `log(x)` lub nazw własnych funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) lub użyj [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla własnej nazwy funkcji ustaw nazwę funkcji jako bieżący element i wywołaj [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) z jej argumentem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Dodaj operatory n‑ary i całki**

Użyj [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) dla sum, sum, przecięć i innych dużych operatorów. Użyj [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) dla całek. Obie metody pozwalają ustawić granice dolne i górne.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Operatory n‑ary służą do dużych operatorów z opcjonalnymi granicami. Proste operatory takie jak `+`, `-` i `=` zwykle dodaje się jako [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) i łączy w wyrażeniu.

Dla całki użyj [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Dodaj macierze**

Użyj [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) dla wierszy i kolumn. Domyślnie macierze nie zawierają nawiasów, więc otaczaj macierz, gdy potrzebujesz okrągłych nawiasów, kwadratowych lub klamrowych.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Edytuj istniejącą macierz**

Załóżmy, że lekcja algebry liniowej zaczyna się od macierzy współczynników w `matrix.pptx`, zapisanej w poprzednim przykładzie. Dla kolejnego zadania zachowaj pierwsze równanie, zamień drugie na dwa nowe i zaktualizuj zestaw zmiennych. Otwórz istniejącą macierz przez [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/), aby zachować współczynniki, które nadal obowiązują.

![Original two-row coefficient matrix with entries 1, x, and an empty cell in the first row and x, 2, and y in the second](matrix-before-edit.png)

Indeksy wierszy i kolumn zaczynają się od zera i odnoszą się do macierzy w stanie przy każdym wywołaniu. Wstawienie wiersza przed indeksem 1 przesuwa oryginalny drugi wiersz na indeks 2. Wstawienie po indeksie 2 dodaje kolejny wiersz. Usunięcie wiersza 2 usuwa oryginalne drugie równanie i przesuwa do góry wiersz dodany wcześniej. Kolumny przesuwają się w ten sam sposób.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // Nowe komórki są początkowo null. Najpierw ustaw niezerowe współczynniki.
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) wyrównuje pierwszą kolumnę do lewej. [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) wyrównuje trzy kolejne kolumny do prawej, zaczynając od indeksu 1. W `updated-matrix.pptx` macierz ma trzy równania i cztery zmienne. Oryginalne współczynniki pierwszego wiersza `1` i `x` pojawiają się teraz w pierwszej i trzeciej kolumnie.

![Updated three-row matrix showing the rows 1, 0, x, 0; 12, 1, 0, 0; and 0, 0, 10, 1](matrix-after-edit.png)

## **Dodaj tablice równań**

Użyj [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray), gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Wyrównaj tablicę z otaczającymi elementami**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) steruje pionowym wyrównaniem tablicy względem elementów matematycznych obok niej. Poniższy przykład porównuje wyrównanie z pierwszym wierszem, środkiem tablicy i ostatnim wierszem.

Poniższy przykład tworzy trzy identyczne tablice, każda z trzema wierszami i sąsiadującymi elementami `A=` oraz `=B`. Cały tekst matematyczny używa czcionki Cambria Math o rozmiarze 24 punkty. Zmienia się tylko wyrównanie tablicy.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższe porównanie pokazuje zapisane prezentacje w PowerPoint. Zwróć uwagę na położenie `A=` i `=B` obok każdej tablicy.

![Equation arrays in PowerPoint with Top, Center, and Bottom alignment and identical neighboring elements](equation-array-alignment.png)

### **Skonfiguruj odstęp między wierszami**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) wybiera regułę odstępu dla wierszy w tablicy. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) podaje wartość numeryczną dla wyraźnej reguły odstępu i jest ignorowane przy użyciu reguł wstępnych.

Dla dokładnego odstępu wartość jest podawana w punktach. Dla odstępu proporcjonalnego jest podawana w półliniach: wartość `3` w przykładzie określa 1,5 linii. Ustaw obie właściwości, gdy podajesz wyraźną wartość; zmiana samej wartości numerycznej nie wybiera reguły odstępu.

Poniższy przykład zapisuje pięć prezentacji z tymi samymi równaniami, wyrównaniem i ustawieniami czcionki. Pierwsze trzy używają wstępnych ustawień; dwa ostatnie pokazują wyraźne wartości.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Odstęp wierszy tablicy jest osobny od odstępu akapitu. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) i [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) dodają odstęp wokół zawierającego akapitu, nie pomiędzy wierszami tablicy. Podobnie [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) pozycjonuje cały akapit matematyczny poziomo; nie zastępuje ustawienia pionowego wyrównania tablicy.

## **Dodaj funkcje trygonometryczne**

Użyj [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction), gdy argument jest bieżącym elementem i nazwa funkcji jest znana.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj indeksy dolne i górne**

Używaj pomocników indeksu dolnego i górnego dla indeksów i potęg. Gdy indeksy muszą znajdować się po lewej stronie podstawy, użyj [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj delimitery**

Użyj [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose), aby umieścić wyrażenie wewnątrz delimiterów. Możesz także ustawić znak separatora dla wyrażeń delimiterowych zawierających kilka elementów.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Rozmiar i wyrównanie delimiterów**

Przekaż `true` do [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), aby nawiasy rosły wokół wysokiego operandu, lub `false`, aby pozostały w normalnym rozmiarze. Użyj [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) z jedną z dwóch wartości [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). `Centered` centruje nawiasy na osi matematycznej, która przechodzi przez środek znaku równości. `Match` wyrównuje je z zawartością. Oba ustawienia wpływają tylko na delimitery. Wyrażenie wewnątrz pozostaje niezmienione.

Przykład umieszcza ułamek w wykładniku `x`, więc wyrażenie rozciąga się wyżej nad linią bazową niż poniżej. Wszystkie cztery równania używają tych samych nawiasów i ustawień czcionki.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W PowerPoint porównaj wiersze, aby zobaczyć efekt wzrostu. W górnym wierszu nawiasy rosną, aby objąć wykładnik i wyglądają tak samo dla obu kształtów. W dolnym wierszu wzrost jest wyłączony. Mniejsze nawiasy po lewej (`Centered`) są wyrównane z znakiem równości, a po prawej (`Match`) znajdują się wyżej wokół wyrażenia.

![Four equations in PowerPoint with delimiter growth enabled above and disabled below, and Centered on the left and Match on the right](delimiter-sizing.png)

## **Dodaj ramkę obramowania**

Wywołaj [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) na ułamku, aby obramować całe wyrażenie. Zwrócony [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) domyślnie pokazuje wszystkie cztery boki. Użyj [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) i [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight), aby usunąć poszczególne boki.

Przykład umieszcza sześć kopii tego samego ułamka na jednym slajdzie. Aby pokazać anulowanie, ukryj wszystkie cztery boki i przekaż `true` do [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) dla rosnącej przekątnej (↗) lub [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) dla opadającej przekątnej (↘). Możesz także użyć [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) lub [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) w dowolnej kombinacji widocznych boków.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Six editable fractions in PowerPoint. Top row: full border, bottom and left sides, rising diagonal. Bottom row: falling diagonal, horizontal strike, vertical strike with a full border.](border-box-fractions.png)

Na tym ułamku poziomy przekreślenie nakłada się na kreskę ułamkową. Pionowy przekreślenie przecina zarówno licznik, jak i mianownik, podczas gdy otaczające obramowanie pozostaje widoczne. Te linie ozdabiają całe wyrażenie. Zwykłe przekreślenie tekstu dotyczy znaków w ciągu tekstowym. Po ponownym otwarciu prezentacji w PowerPoint nadal możesz edytować licznik i mianownik niezależnie.

## **Kontroluj widoczność i układ za pomocą elementów fantomowych**

Objąć wyrażenie w [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/), aby kontrolować jego widoczność oraz przestrzeń, jaką przyczynia się do równania, niezależnie. Metody [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) sterują następującymi właściwościami:

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | Przekaż `false`, aby ukryć wyrażenie. Jego wymiary nadal wpływają na układ, chyba że odpowiadające metody poniżej otrzymają `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | Traktuj poziomą szerokość wyrażenia jako zero, co pozwala sąsiednim elementom zbliżyć się do siebie. |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | Traktuj wzniesienie (wysokość ponad linią bazową) jako zero. Może to zmniejszyć przestrzeń nad sąsiednimi elementami. |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | Traktuj zstąpienie (głębokość pod linią bazową) jako zero. Może to przybliżyć kreskę ułamkową lub inną treść poniżej wyrażenia do sąsiadów. |

Linia bazowa jest linią odniesienia, na której stoją zwykłe znaki matematyczne. Ukrywanie treści nie usuwa jej wymiarów, a traktowanie wymiaru jako zero nie usuwa wyrażenia. Podstawowe wyrażenie pozostaje dostępne przez [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase). Przekaż `true` do [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow), aby ponownie je wyświetlić; ustawienia wymiarów pozostają niezmienione.

Poniższy przykład tworzy pięć wariantów obok siebie: widoczny ułamek, ukryty ułamek, który zachowuje miejsce, oraz trzy ukryte ułamki, w których jeden wymiar traktowany jest jako zero. Każdy wariant używa tego samego otaczającego wyrażenia i czcionki Cambria Math 24‑punkty. Wszystkie kształty równań mają tę samą pozycję górną, oznaczoną szarym prowadnikiem. Umieszczenie fantomu w liczniku zewnętrznego ułamka ułatwia obserwację zmian układu pionowego.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Five equations in PowerPoint comparing a visible fraction, a hidden fraction that reserves space, and hidden fractions with ZeroWidth, ZeroAsc, or ZeroDesc enabled](math-phantom.png)

## **Grupuj wyrażenia**

Użyj [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group), aby umieścić znak grupujący nad lub pod wyrażeniem. Dodaj granicę, aby oznaczyć pogrupowane wyrażenia.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formatuj elementy matematyczne**

Używaj pomocy formatowania wyłącznie tam, gdzie wyjaśniają formułę. Na przykład [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) umieszcza pasek nad elementem matematycznym.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Formatuj tekst w istniejącym równaniu**

Aby sformatować tekst w całym istniejącym równaniu, przejdź przez drzewo elementów każdego bloku matematycznego. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) zwraca tylko bezpośrednie dzieci, więc wywołaj ją rekurencyjnie, aby dotrzeć do tekstu wewnątrz ułamków, skryptów, pierwiastków i innych zagnieżdżonych struktur. Sprawdź bieżący element oraz jego dzieci, aby uwzględnić element początkowy, gdy jest to [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

Ten przykład zakłada, że `input.pptx` zawiera równanie takie jak `z = xᵢ / ∛y`, z ułamkiem zawierającym indeks dolny w liczniku i pierwiastek w mianowniku. Przetwarzanie wyłącznie elementów najwyższego poziomu bloku pominęłoby tekst wewnątrz ułamka. Przykład znajduje części matematyczne w ramkach tekstowych slajdów, uzyskuje dostęp do ich bloków przez [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) i używa [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight), aby ustawić rozmiar czcionki na 28 punktów w każdym elemencie tekstowym za pomocą metody [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisana prezentacja zawiera zaktualizowane formatowanie tekstu na każdym poziomie przetworzonego równania, zachowując jednocześnie treść i strukturę matematyczną.

## **Szybkie odniesienie**

| Task | Main API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Combine elements | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Create fractions | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add superscript or subscript | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add functions | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add radicals | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add limits | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add left-side scripts | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add summations and integrals | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Add equation arrays | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add delimiters | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Add bars and borders | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Group terms | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Czy mogę edytować istniejące równanie PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), wywołaj [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Po zapisaniu do PPTX Aspose.Slides zapisuje równanie jako edytowalną treść Office Math.

**Czy mogę wyeksportować równania do LaTeX?**

Tak. Pobierz [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) z jego [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), a następnie wywołaj [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex), aby wyeksportować je bezpośrednio. Pełny przykład znajdziesz w [Export Math Equations from Presentations in Node.js via Java](/slides/pl/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).