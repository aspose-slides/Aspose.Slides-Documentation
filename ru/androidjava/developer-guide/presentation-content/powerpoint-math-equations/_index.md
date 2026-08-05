---
title: Добавление математических уравнений в презентации PowerPoint на Android
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides для Android, поддерживая OMML, средства форматирования и понятные образцы кода на Java."
---
## **Обзор**

PowerPoint хранит уравнения в формате Office Math Markup Language (OMML). С помощью Aspose.Slides for Android via Java вы можете программно создавать такие же математические конструкции: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и отформатированные блоки математических формул.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результат — редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создает этот математический текст с помощью трех основных объектов:

- Математическая фигура, созданная с помощью [addMathShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/), — это фигура, содержащая уравнение.
- [MathPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathportion/) хранит математическое содержимое внутри текстового кадра фигуры.
- [MathParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathematicaltext/) и методы из [IMathElement](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) для короткого и читабельного кода.

Для сценариев экспорта MathML см. [Export Math Equations from Presentations on Android](/slides/ru/androidjava/exporting-math-equations/).

## **Создание уравнения**

Этот пример создает математическую фигуру и добавляет теорему Пифагора:

![Уравнение c² = a² + b²](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` создает фигуру, уже содержащую математический абзац. Получите первый `MathPortion`, возьмите его `MathParagraph` и добавьте в него математические блоки или элементы.
{{% /alert %}}

## **Добавление дробей**

Для создания дроби используйте `divide`. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathfractiontypes/).

![Наклоненная математическая дробь, показывающая 1 делённое на x](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для вертикальной (stacked) дроби используйте `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Добавление радикалов**

Для создания квадратного корня, кубического корня или другого корня используйте `radical`. Текущий элемент становится основанием, а аргумент — степенью.

![Выражение n‑го корня с x под радикалом](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление функций и пределов**

Для функций, таких как `sin(x)`, `log(x)`, или пользовательских имен функций, используйте `asArgumentOfFunction` или `function`. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathlimit/) или используйте `setLowerLimit`.

![Предел x при x стремящемся к бесконечности](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для пользовательского имени функции сделайте имя функции текущим элементом:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Добавление N‑арных операторов и интегралов**

Для сумм, объединений, пересечений и других крупных операторов используйте `nary`. Для интегралов используйте `integral`. Оба метода позволяют задавать нижние и верхние пределы.

![Сумма с нижними и верхними пределами](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N‑арные операторы предназначены для крупных операторов с опциональными пределами. Простые операторы такие как `+`, `-` и `=` обычно добавляются как `MathematicalText` и объединяются в выражение.

Для интеграла используйте `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Добавление матриц**

Для строк и столбцов используйте [MathMatrix](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathmatrix/). По умолчанию матрицы не включают скобки, поэтому заключайте матрицу в скобки, квадратные скобки или фигурные скобки при необходимости.

![Математическая матрица с двумя строками и одной пустой ячейкой](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление массивов уравнений**

Используйте `toMathArray`, когда нужны выровненные уравнения или вертикальная стопка выражений.

![Вертикальный массив уравнений с x над y](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление тригонометрических функций**

Используйте `asArgumentOfFunction`, когда аргумент является текущим элементом, а имя функции известно.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление индексов и степеней**

Используйте вспомогательные функции для нижних и верхних индексов. Когда индексы должны располагаться слева от основания, используйте `setSubSuperscriptOnTheLeft`.

![Заглавная Y с левым индексом 1 и верхним индексом n](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление ограничителей**

Используйте `enclose`, чтобы поместить выражение в ограничители. Также можно задать разделительный символ для выражений с несколькими элементами.

![Выражение с ограничителями, содержащие x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление рамки‑коробки**

Используйте `toBorderBox`, когда уравнение должно быть заключено в рамку.

![Уравнение в рамке, показывающее a² = b² + c²](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Группировка терминов**

Используйте `group`, чтобы разместить группирующий символ над или под выражением. Добавьте предел, чтобы пометить сгруппированные термины.

![Выражение x + y, сгруппированное с подписью любой текст под ним](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Форматирование математических элементов**

Используйте вспомогательные функции форматирования только там, где они делают формулу более понятной. Например, `overbar` помещает черту над элементом.

![Математическое выражение ABC с надчеркиванием](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Быстрый справочник**

| Задача | Основной API |
| --- | --- |
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathematicaltext/) |
| Объединение элементов | [IMathElement.join](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Создание дробей | [IMathElement.divide](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление верхнего или нижнего индекса | [setSuperscript](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление функций | [function](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление радикалов | [IMathElement.radical](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление пределов | [setLowerLimit](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление индексов слева | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление сумм и интегралов | [nary](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathmatrix/) |
| Добавление массивов уравнений | [toMathArray](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление ограничителей | [enclose](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Добавление черт и рамок | [overbar](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |
| Группировка терминов | [group](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathelement/) |

## **Часто задаваемые вопросы**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математическая часть PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемое содержимое Office Math.

**Могу ли я экспортировать уравнения в LaTeX?**

Да. Получите [IMathParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathparagraph/) уравнения из его [IMathPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathportion/), вызовите [IMathParagraph.toLatex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathparagraph/#toLatex--) для прямого экспорта. Полный пример смотрите в [Export Math Equations from Presentations in Android via Java](/slides/ru/androidjava/exporting-math-equations/#export-math-equations-to-latex).