---
title: Добавление математических уравнений в презентации PowerPoint на PHP
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides для PHP через Java, поддержка OMML, элементов форматирования и понятных примеров кода на PHP."
---
## **Обзор**

PowerPoint хранит уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides for PHP via Java вы можете создавать такой же математический контент программно: дроби, радикалы, функции, пределы, N-арные операторы, матрицы, массивы и отформатированные блоки математики.

In PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результатом является редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создает этот математический текст с помощью трех основных объектов:

- Математическая фигура, создаваемая с помощью [addMathShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/#addMathShape), является фигурой, содержащей уравнение.
- [MathPortion] хранит математическое содержимое внутри текстового кадра фигуры.
- [MathParagraph] содержит один или несколько объектов [MathBlock].

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathematicaltext/), а также последовательные методы из [MathElementBase](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/), чтобы код был коротким и читабельным.

Для сценариев экспорта MathML см. [Экспорт математических уравнений из презентаций в PHP через Java](/slides/ru/php-java/exporting-math-equations/).

## **Создать уравнение**

Этот пример создает математическую фигуру и добавляет теорему Пифагора:

![Уравнение c² = a² + b²](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}
`addMathShape` создает фигуру, которая уже содержит математический абзац. Получите первый `MathPortion`, получите его `MathParagraph` и добавьте в него блоки математики или математические элементы.
{{% /alert %}}

## **Добавить дроби**

Используйте [`divide`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathfractiontypes/).

![Искривленная математическая дробь, показывающая 1, делённое на x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Для сложенной дроби используйте `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Добавить радикалы**

Используйте [`radical`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент — показателем.

![Выражение n-го корня с x под радикальным знаком](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Добавить функции и пределы**

Используйте [`asArgumentOfFunction`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) или [`function`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) для функций, таких как `sin(x)`, `log(x)` или пользовательских имён функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathlimit/) или используйте [`setLowerLimit`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/).

![Предел x при x стремящемся к бесконечности](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Для пользовательского имени функции сделайте имя функции текущим элементом:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Добавить N-арные операторы и интегралы**

Используйте [`nary`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) для сумм, объединений, пересечений и других больших операторов. Используйте [`integral`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) для интегралов. Оба метода позволяют задавать нижние и верхние пределы.

![Сумма с нижним и верхним пределами](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

N-арные операторы предназначены для больших операторов с необязательными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как `MathematicalText` и соединяются в выражении.

Для интеграла используйте `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Добавить матрицы**

Используйте [MathMatrix](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому обрамляйте матрицу, если нужны круглые скобки, квадратные скобки или фигурные скобки.

![Матрица с двумя строками и одной пустой ячейкой](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Добавить массивы уравнений**

Используйте [`toMathArray`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) , когда нужны выровненные уравнения или вертикальная стековая последовательность выражений.

![Вертикальный массив математики, где x над y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Добавить тригонометрические функции**

Используйте [`asArgumentOfFunction`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) , когда аргумент является текущим элементом и имя функции известно.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Добавить нижние и верхние индексы**

Используйте вспомогательные функции нижних и верхних индексов для индексов и степеней. Когда индексы должны располагаться слева от основания, используйте [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/).

![Заглавная Y с левым нижним индексом 1 и верхним индексом n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Добавить разделители**

Используйте [`enclose`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) , чтобы поместить выражение внутрь разделителей. Вы также можете задать символ-разделитель для выражений с несколькими элементами.

![Выражение с разделителями, содержащие x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Добавить рамку**

Используйте [`toBorderBox`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) , когда само уравнение должно быть обрамлено.

![Уравнение в рамке, показывающее a² = b² + c²](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Группировать члены**

Используйте [`group`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) , чтобы разместить символ группировки над или под выражением. Добавьте предел, чтобы пронумеровать сгруппированные члены.

![Выражение x + y, сгруппированное с подписью любой текст под ним](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Форматировать математические элементы**

Используйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, [`overbar`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) размещает черту над математическим элементом.

![Математическое выражение ABC с надчеркой](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Быстрая справка**

| Task | Main API |
| --- | --- |
| Создать математический текст | [MathematicalText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathematicaltext/) |
| Объединить элементы | [join](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Создать дроби | [divide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить верхний или нижний индекс | [setSuperscript](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить функции | [function](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить радикалы | [radical](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить пределы | [setLowerLimit](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить индексы слева | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить суммирования и интегралы | [nary](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить матрицы | [MathMatrix](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathmatrix/) |
| Добавить массивы уравнений | [toMathArray](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить разделители | [enclose](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Добавить черты и рамки | [overbar](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |
| Группировать члены | [group](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathelementbase/) |

## **Часто задаваемые вопросы**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите блоки математики в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемый контент Office Math.

**Можно ли экспортировать уравнения в LaTeX?**

Aspose.Slides экспортирует математические уравнения в MathML. Если нужен LaTeX, сначала экспортируйте в MathML, а затем преобразуйте MathML с помощью инструмента, поддерживающего нужный диалект LaTeX.