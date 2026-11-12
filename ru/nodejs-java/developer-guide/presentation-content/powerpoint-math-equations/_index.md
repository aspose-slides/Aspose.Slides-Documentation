---
title: Добавить математические уравнения в презентации PowerPoint на JavaScript
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/nodejs-java/powerpoint-math-equations/
keywords:
- математическое уравнение
- математический символ
- математическая формула
- математический текст
- добавить математическое уравнение
- добавить математический символ
- добавить математическую формулу
- добавить математический текст
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides for Node.js via Java, поддерживая OMML, элементы управления форматированием и понятные примеры кода на JavaScript."
---
## **Обзор**

PowerPoint хранит уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides for Node.js via Java вы можете программно создавать такой же тип математического содержимого: дроби, радикалы, функции, пределы, n‑арные операторы, матрицы, массивы и форматированные математические блоки.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выделенной командой Equation](powerpoint-math-equations_1.png)

В результате на слайде появляется редактируемый математический текст:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides формирует этот математический текст с помощью трех основных объектов:

- Математическая фигура, созданная с помощью [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) сохраняет математическое содержимое внутри текстового фрейма фигуры.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) и «потоковые» методы из [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) для сокращения и упрощения кода.

Для сценариев экспорта MathML смотрите [Export Math Equations from Presentations in Node.js via Java](/slides/ru/nodejs-java/exporting-math-equations/).

## **Создать уравнение**

Этот пример использует [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) для создания математической фигуры и добавляет теорему Пифагора:

![Уравнение c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) создаёт фигуру, уже содержащую математический абзац. Получите первый [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) и добавьте в него математические блоки или элементы.
{{% /alert %}}

## **Добавить дроби**

Используйте [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![Скосленная математическая дробь, показывающая 1 делённое на x](powerpoint-math-equations_4.png)

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

Для «stacked» дроби используйте [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Добавить радикалы**

Используйте [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) для создания квадратного, кубического или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![n‑й корень с x под радикальным знаком](powerpoint-math-equations_5.png)

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

## **Добавить функции и пределы**

Используйте [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) или [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) для функций, таких как `sin(x)`, `log(x)` или пользовательских названий. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) или используйте [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![Предел x, когда x стремится к бесконечности](powerpoint-math-equations_8.png)

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

Для пользовательского имени функции сделайте его текущим элементом и вызовите [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) с аргументом:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Добавить n‑арные операторы и интегралы**

Используйте [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) для сумм, объединений, пересечений и других больших операторов. Для интегралов используйте [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral). Оба метода позволяют задавать нижние и верхние пределы.

![Сумма с нижним и верхним пределами](powerpoint-math-equations_7.png)

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

n‑арные операторы предназначены для больших операторов с возможными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) и объединяются в выражение.

Для интеграла используйте [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Добавить матрицы**

Используйте [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому окружайте матрицу, когда нужны круглые, квадратные или фигурные скобки.

![Матрица из двух строк с одной пустой ячейкой](powerpoint-math-equations_10.png)

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

## **Добавить массивы уравнений**

Используйте [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray), когда нужны выровненные уравнения или вертикальная стековая компоновка выражений.

![Вертикальный массив с x над y](powerpoint-math-equations_11.png)

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

### **Выровнять массив с окружающими элементами**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) управляет вертикальным выравниванием массива относительно соседних математических элементов. Ниже приводится сравнение выравнивания первой строки, центра массива и последней строки.

В следующем примере создаются три одинаковых массива, каждый из трёх строк, и соседние элементы `A=` и `=B`. Весь математический текст использует Cambria Math 24 pt. Меняется только выравнивание массива.

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

Сравнение показано в сохранённой презентации PowerPoint. Обратите внимание на положение `A=` и `=B` рядом с каждым массивом.

![Массивы уравнений в PowerPoint с верхним, центральным и нижним выравниванием и одинаковыми соседними элементами](equation-array-alignment.png)

### **Настроить интервал строк**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) выбирает правило интервала для строк внутри массива. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) задаёт числовое значение для явного правила и игнорируется предустановленными правилами.

Для точного интервала значение измеряется в пунктах. Для пропорционального интервала измеряется в полуполосах: значение `3` в примере задаёт 1,5 линии. Устанавливайте оба свойства, задавая явное значение; изменение только числового значения не выбирает правило интервала.

В примере ниже сохраняются пять презентаций с одинаковыми уравнениями, выравниванием и настройками шрифта. Первые три используют предустановки; последние два показывают явные значения.

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

Интервал строк массива отдельный от интервала абзаца. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) и [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) добавляют пространство вокруг содержащего абзаца, а не между строками массива. Аналогично, [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) позиционирует весь математический абзац горизонтально; он не заменяет настройку вертикального выравнивания массива.

## **Добавить тригонометрические функции**

Используйте [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction), когда аргумент — текущий элемент, а имя функции известно.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

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

## **Добавить нижние и верхние индексы**

Используйте вспомогательные функции нижнего и верхнего индекса для индексов и степеней. Когда индексы должны располагаться слева от основания, используйте [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Буква Y с левым нижним индексом 1 и верхним индексом n](powerpoint-math-equations_9.png)

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

## **Добавить разделители**

Используйте [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose), чтобы поместить выражение внутрь разделителей. Вы также можете задать символ-разделитель для выражений, содержащих несколько элементов.

![Выражение с разделителями, содержащими x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

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

### **Размер и выравнивание разделителей**

Передайте `true` в [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), чтобы скобки увеличивались вокруг высокого операнда, или `false`, чтобы оставить их обычного размера. Используйте [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) с одним из двух значений [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/). `Centered` центрирует скобки по оси математики, проходящей через середину знака равенства. `Match` выравнивает их по содержимому. Оба параметра влияют только на разделители; внутреннее выражение остаётся прежним.

В примере дробь помещена в показатель степени `x`, поэтому выражение поднимается выше базовой линии, чем опускается ниже. Все четыре уравнения используют одинаковые скобки и настройки шрифта.

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

В PowerPoint сравните строки, чтобы увидеть эффект роста. В верхней строке скобки увеличиваются, охватывая показатель, и выглядят одинаково для обеих форм. В нижней строке рост отключён. Маленькие скобки слева (`Centered`) выравниваются по знаку равенства, а права (`Match`) размещаются выше вокруг выражения.

![Четыре уравнения в PowerPoint с включённым и отключённым ростом разделителей, слева — Centered, справа — Match](delimiter-sizing.png)

## **Добавить рамку**

Вызовите [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) у дроби, чтобы обрамить всё выражение. Возвращаемый [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) отображает все четыре стороны по умолчанию. Используйте [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) и [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight), чтобы скрыть отдельные стороны.

В примере размещено шесть копий одной и той же дроби на одном слайде. Чтобы показать отмену, скройте все четыре стороны и передайте `true` в [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) для восходящей диагонали (↗) или в [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) для нисходящей диагонали (↘). Вы также можете использовать [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) или [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) в комбинации с любыми видимыми сторонами.

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

![Шесть редактируемых дробей в PowerPoint. Верхняя строка: полная рамка, нижняя и левая стороны, восходящая диагональ. Нижняя строка: нисходящая диагональ, горизонтальный штрих, вертикальный штрих с полной рамкой.](border-box-fractions.png)

На этой дроби горизонтальный штрих перекрывает черту дроби. Вертикальный штрих проходит через числитель и знаменатель, в то время как окружающая рамка остаётся видимой. Эти линии украшают всё выражение. Обычное зачёркивание текста применяется к символам в текстовом блоке. После повторного открытия презентации в PowerPoint вы всё ещё можете независимо редактировать числитель и знаменатель.

## **Группировать термы**

Используйте [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group), чтобы разместить символ группировки над или под выражением. Добавьте предел, чтобы пометить сгруппированные термы.

![Выражение x + y, сгруппированное с подписью любой текст снизу](powerpoint-math-equations_15.png)

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

## **Форматировать математические элементы**

Используйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) помещает черту над математическим элементом.

![Математическое выражение ABC с надчеркиванием](powerpoint-math-equations_14.png)

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

### **Форматировать текст в существующем уравнении**

Чтобы отформатировать текст во всём существующем уравнении, пройдитесь по дереву элементов каждого математического блока. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) возвращает только непосредственных детей, поэтому вызывайте его рекурсивно, чтобы достичь текста внутри дробей, скриптов, радикалов и других вложенных структур. Проверяйте текущий элемент и его детей, чтобы включить начальный элемент, если это [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

В этом примере предполагается, что `input.pptx` содержит уравнение вида `z = xᵢ / ∛y`, где в числителе дроби есть нижний индекс, а в знаменателе — радикал. Обработка только верхнего уровня элементов блока пропустила бы текст внутри дроби. Пример ищет математические части в текстовых фреймах слайдов, получает их блоки через [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) и использует [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight), чтобы установить размер шрифта 28 pt через метод [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) каждого текстового элемента.

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

Сохранённая презентация содержит обновлённое форматирование текста на всех уровнях каждого обработанного уравнения, сохраняя его текстовое содержимое и математическую структуру.

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создать математический текст | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| Объединить элементы | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Создать дроби | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить верхний или нижний индекс | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить функции | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить радикалы | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить пределы | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить скрипты слева | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить суммы и интегралы | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить матрицы | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| Добавить массивы уравнений | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить разделители | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить штрихи и рамки | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| Группировать термы | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **Часто задаваемые вопросы**

**Могу ли я отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемое содержимое Office Math.

**Могу ли я экспортировать уравнения в LaTeX?**

Да. Получите [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) уравнения из его [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), затем вызовите [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) для прямого экспорта. Полный пример см. в [Export Math Equations from Presentations in Node.js via Java](/slides/ru/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).