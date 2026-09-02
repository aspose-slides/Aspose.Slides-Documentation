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
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides for Node.js via Java, поддерживая OMML, параметры форматирования и понятные примеры кода на JavaScript."
---
## **Обзор**

PowerPoint хранит уравнения в формате Office Math Markup Language (OMML). С помощью Aspose.Slides for Node.js via Java вы можете программно создавать такие же математические элементы: дроби, радикалы, функции, пределы, n‑арные операторы, матрицы, массивы и форматированные блоки формул.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результат – редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides строит этот математический текст с помощью трёх основных объектов:

- Математическая фигура, создаваемая с помощью [addMathShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addMathShape), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathportion/) хранит математическое содержимое внутри текстового кадра фигуры.
- [MathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathematicaltext/) и методы из [MathElementBase](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для упрощения и читаемости кода.

Для сценариев экспорта в MathML смотрите [Export Math Equations from Presentations in Node.js via Java](/slides/ru/nodejs-java/exporting-math-equations/).

## **Создание уравнения**

Этот пример создаёт математическую фигуру и добавляет теорему Пифагора:

![Уравнение c² = a² + b²](powerpoint-math-equations_3.png)

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
`addMathShape` создает фигуру, которая уже содержит математический параграф. Получите первый `MathPortion`, извлеките его `MathParagraph` и добавьте в него блоки или элементы математики.
{{% /alert %}}

## **Добавление дробей**

Используйте [`divide`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathfractiontypes/).

![Наклонная математическая дробь, показывающая 1 делённое на x](powerpoint-math-equations_4.png)

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

## **Добавление радикалов**

Используйте [`radical`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент – степенью.

![Выражение n‑го корня с x под радикалом](powerpoint-math-equations_5.png)

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

## **Добавление функций и пределов**

Используйте [`asArgumentOfFunction`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) или [`function`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для функций, таких как `sin(x)`, `log(x)` или пользовательских имён функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathlimit/) или используйте [`setLowerLimit`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/).

![Предел x при стремлении x к бесконечности](powerpoint-math-equations_8.png)

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

## **Добавление n‑арных операторов и интегралов**

Используйте [`nary`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для сумм, объединений, пересечений и других больших операторов. Используйте [`integral`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) для интегралов. Оба метода позволяют задавать нижний и верхний пределы.

![Суммирование с нижним и верхним пределами](powerpoint-math-equations_7.png)

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

n‑арные операторы предназначены для больших операторов с опциональными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как `MathematicalText` и объединяются в выражение.

Для интеграла используйте `integral`:

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **Добавление матриц**

Используйте [MathMatrix](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому оборачивайте матрицу, когда нужны круглые, квадратные или фигурные скобки.

![Матрица с двумя строками и одной пустой ячейкой](powerpoint-math-equations_10.png)

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

## **Добавление массивов уравнений**

Используйте [`toMathArray`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) когда нужны выровненные уравнения или вертикальная стопка выражений.

![Вертикальный массив с x над y](powerpoint-math-equations_11.png)

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

## **Добавление тригонометрических функций**

Используйте [`asArgumentOfFunction`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) когда аргумент является текущим элементом, а имя функции известно.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

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

## **Добавление индексов и степеней**

Используйте вспомогательные функции для подстрочных и надстрочных индексов. Когда индексы должны располагаться слева от основания, используйте [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/).

![Буква Y с левосторонним подстрочным индексом 1 и надстрочным n](powerpoint-math-equations_9.png)

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

## **Добавление разделителей**

Используйте [`enclose`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) чтобы поместить выражение в разделители. Вы также можете задать символ‑разделитель для выражений с несколькими элементами.

![Выражение с разделителями, содержащие x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

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

## **Добавление рамки**

Используйте [`toBorderBox`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) когда уравнение должно быть обрамлено.

![Уравнение в рамке, показывающее a² = b² + c²](powerpoint-math-equations_12.png)

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

## **Группировка членов**

Используйте [`group`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) чтобы разместить группирующий символ над или под выражением. Добавьте предел, чтобы пометить сгруппированные члены.

![Выражение x + y, сгруппированное с подписью любой текст под ним](powerpoint-math-equations_15.png)

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

## **Форматирование элементов формул**

Используйте вспомогательные функции форматирования только там, где они уточняют формулу. Например, [`overbar`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) размещает черту над математическим элементом.

![Математическое выражение ABC с надчеркой](powerpoint-math-equations_14.png)

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
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathematicaltext/) |
| Объединение элементов | [join](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Создание дробей | [divide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление надстрочных или подстрочных индексов | [setSuperscript](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление функций | [function](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление радикалов | [radical](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление пределов | [setLowerLimit](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление скриптов слева | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление суммирований и интегралов | [nary](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathmatrix/) |
| Добавление массивов уравнений | [toMathArray](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление разделителей | [enclose](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Добавление линий и границ | [overbar](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |
| Группировка членов | [group](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Можно ли редактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите математические блоки в этом параграфе.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемое содержимое Office Math.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [MathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/) уравнения из его [MathPortion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathportion/) и вызовите [MathParagraph.toLatex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/#toLatex--) для непосредственного экспорта. Полный пример см. в статье [Export Math Equations from Presentations in Node.js via Java](/slides/ru/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).