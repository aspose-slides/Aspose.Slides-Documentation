---
title: Добавление математических уравнений в презентации PowerPoint на JavaScript
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
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides для Node.js через Java, поддерживая OMML, элементы управления форматированием и понятные примеры кода JavaScript."
---
## **Обзор**

PowerPoint сохраняет уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides для Node.js через Java вы можете программно создавать такой же математический контент: дроби, корни, функции, пределы, n-арные операторы, матрицы, массивы и отформатированные блоки математики.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![PowerPoint Insert tab with the Equation command selected](powerpoint-math-equations_1.png)

Результат — редактируемый математический текст на слайде:

![A PowerPoint slide containing an editable math equation](powerpoint-math-equations_2.png)

Aspose.Slides создает этот математический текст с помощью трех основных объектов:

- Математическая фигура, создаваемая с помощью [addMathShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addMathShape), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathportion/) хранит математическое содержимое внутри текстового кадра фигуры.
- [MathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathematicaltext/) и плавные методы из [MathElementBase](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), чтобы код был коротким и читабельным.

Для сценариев экспорта MathML см. [Export Math Equations from Presentations in Node.js via Java](/slides/ru/nodejs-java/exporting-math-equations/).

## **Создать уравнение**

В этом примере создается математическая фигура и добавляется теорема Пифагора:

![The equation c squared equals a squared plus b squared](powerpoint-math-equations_3.png)

```javascript
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

{{% alert color="primary" %}}
`addMathShape` создает фигуру, которая уже содержит математический абзац. Получите первый `MathPortion`, извлеките его `MathParagraph` и добавьте к нему математические блоки или элементы.
{{% /alert %}}

## **Добавить дроби**

Используйте [`divide`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathfractiontypes/).

![A skewed math fraction showing one divided by x](powerpoint-math-equations_4.png)

```javascript
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

Для сложенной дроби используйте `MathFractionTypes.Bar`:

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **Добавить радикалы**

Используйте [`radical`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для создания квадратного корня, кубического корня или любого другого корня. Текущий элемент становится основанием, а аргумент — показателем степени.

![An n-th root radical expression with x under the radical sign](powerpoint-math-equations_5.png)

```javascript
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

Используйте [`asArgumentOfFunction`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) или [`function`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для функций, таких как `sin(x)`, `log(x)`, или пользовательских имен функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathlimit/) или используйте [`setLowerLimit`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/).

![The limit of x as x approaches infinity](powerpoint-math-equations_8.png)

```javascript
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

Для пользовательского имени функции сделайте имя функции текущим элементом:

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **Добавить N-арные операторы и интегралы**

Используйте [`nary`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для сумм, объединений, пересечений и других больших операторов. Используйте [`integral`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для интегралов. Оба метода позволяют задать нижнюю и верхнюю границы.

![A summation with lower and upper limits](powerpoint-math-equations_7.png)

```javascript
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

N-арные операторы предназначены для больших операторов с опциональными границами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как `MathematicalText` и соединяются в выражение.

Для интеграла используйте `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Добавить матрицы**

Используйте [MathMatrix](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому обрамляйте их, когда нужны круглые скобки, квадратные скобки или фигурные скобки.

![A two-row math matrix with one empty cell](powerpoint-math-equations_10.png)

```javascript
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

Используйте [`toMathArray`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) когда нужны выровненные уравнения или вертикальная стопка выражений.

![A vertical math array with x above y](powerpoint-math-equations_11.png)

```javascript
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

## **Добавить тригонометрические функции**

Используйте [`asArgumentOfFunction`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) когда аргумент является текущим элементом и имя функции известно.

![The trigonometric function cos applied to 2x](powerpoint-math-equations_6.png)

```javascript
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

Используйте вспомогательные функции для нижних и верхних индексов для индексирования и степеней. Когда индексы должны располагаться слева от основания, используйте [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/).

![A capital Y with left-side subscript 1 and superscript n](powerpoint-math-equations_9.png)

```javascript
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

Используйте [`enclose`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) чтобы поместить выражение внутри разделителей. Вы также можете задать символ‑разделитель для выражений с несколькими элементами.

![A delimiter expression containing x, y, and z separated by vertical bars](powerpoint-math-equations_13.png)

```javascript
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

## **Добавить рамку (border box)**

Используйте [`toBorderBox`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) когда уравнение само должно быть обрамлено.

![A boxed equation showing a squared equals b squared plus c squared](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Группировать термы**

Используйте [`group`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) чтобы разместить символ группировки над или под выражением. Добавьте границу, чтобы пометить сгруппированные термы.

![The expression x plus y grouped with the label any text below it](powerpoint-math-equations_15.png)

```javascript
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

Используйте вспомогательные функции форматирования только там, где они уточняют формулу. Например, [`overbar`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) помещает черту над математическим элементом.

![A math expression ABC with an overbar](powerpoint-math-equations_14.png)

```javascript
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

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создать математический текст | [MathematicalText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathematicaltext/) |
| Объединить элементы | [join](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Создать дроби | [divide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить верхний или нижний индекс | [setSuperscript](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить функции | [function](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить радикалы | [radical](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить пределы | [setLowerLimit](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить скрипты слева | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить суммы и интегралы | [nary](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить матрицы | [MathMatrix](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathmatrix/) |
| Добавить массивы уравнений | [toMathArray](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить разделители | [enclose](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавить линии и рамки | [overbar](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Группировать термы | [group](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Могу ли я редактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемый Office‑math контент.

**Могу ли я экспортировать уравнения в LaTeX?**

Aspose.Slides экспортирует математические уравнения в MathML. Если нужен LaTeX, сначала экспортируйте в MathML, а затем преобразуйте MathML с помощью инструмента, поддерживающего нужный диалект LaTeX.