---
title: Добавить математические уравнения в презентации PowerPoint на PHP
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
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides for PHP via Java, поддерживая OMML, управление форматированием и понятные примеры кода PHP."
---
## **Обзор**

PowerPoint хранит уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides for PHP via Java вы можете программно создавать такой же тип математического контента: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и форматированные блоки математики.

В PowerPoint пользователи обычно добавляют уравнения через **Вставка > Уравнение**:

![Вкладка Вставка PowerPoint с выбранной командой Уравнение](powerpoint-math-equations_1.png)

В результате на слайде появляется редактируемый математический текст:

![Слайд PowerPoint с редактируемым математическим уравнением](powerpoint-math-equations_2.png)

Aspose.Slides формирует этот математический текст через три основных объекта:

- Математическую форму, создаваемую с помощью [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), — это форма, содержащая уравнение.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) хранит математическое содержимое внутри текстового кадра формы.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) и плавные методы из [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) для упрощения и читаемости кода.

Для сценариев экспорта MathML см. [Export Math Equations from Presentations in PHP via Java](/slides/ru/php-java/exporting-math-equations/).

## **Создание уравнения**

В этом примере используется [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) для создания математической формы и добавляется теорема Пифагора:

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

{{% alert color="info" title="Note" %}}

[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) создаёт форму, уже содержащую математический абзац. Получите первый [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) и добавьте в него математические блоки или элементы.

{{% /alert %}}

## **Добавление дробей**

Используйте [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![Наклонная математическая дробь, показывающая один делённый на x](powerpoint-math-equations_4.png)

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

Для сложенной дроби используйте [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Добавление радикалов**

Используйте [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![Выражение n‑го корня с x под радикальным знаком](powerpoint-math-equations_5.png)

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

## **Добавление функций и пределов**

Используйте [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) или [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) для функций, таких как `sin(x)`, `log(x)` или пользовательских имён функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) или используйте [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![Предел x при x, стремящемся к бесконечности](powerpoint-math-equations_8.png)

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

Для пользовательского имени функции сделайте имя функции текущим элементом и вызовите [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) с её аргументом:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Добавление N‑арных операторов и интегралов**

Используйте [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) для сумм, объединений, пересечений и других крупных операторов. Используйте [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) для интегралов. Оба метода позволяют задавать нижние и верхние пределы.

![Суммирование с нижним и верхним пределами](powerpoint-math-equations_7.png)

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

N‑арные операторы предназначены для крупных операторов с необязательными пределами. Простые операторы вроде `+`, `-` и `=` обычно добавляются как [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) и соединяются в выражении.

Для интеграла используйте [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Добавление матриц**

Используйте [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому при необходимости обрамляйте их в круглые, квадратные или фигурные скобки.

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

## **Добавление массивов уравнений**

Используйте [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray), когда нужны выровненные уравнения или вертикальная стопка выражений.

![Вертикальный массив математики с x над y](powerpoint-math-equations_11.png)

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

## **Добавление тригонометрических функций**

Используйте [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction), когда аргумент является текущим элементом, а имя функции известно.

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

## **Добавление индексов и степеней**

Используйте вспомогательные функции для нижних и верхних индексов. Когда индексы должны располагаться слева от основания, используйте [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Буква Y с левым нижним индексом 1 и верхним индексом n](powerpoint-math-equations_9.png)

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

## **Добавление разделителей**

Используйте [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) для помещения выражения в разделители. Также можно задать символ‑разделитель для выражений, содержащих несколько элементов.

![Выражение с разделителями, содержащими x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

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

### **Размер и выравнивание разделителей**

Передайте `true` в [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), чтобы скобки увеличивались вокруг высокого операнда, или `false`, чтобы оставить их обычного размера. Используйте [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) с одной из двух величин [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` центрирует скобки по математической оси, проходящей через середину знака «=». `Match` выравнивает их по содержимому. Оба параметра влияют только на разделители; выражение внутри остаётся прежним.

В примере дробь помещена в степень `x`, поэтому выражение поднимается выше базовой линии, чем опускается. Все четыре уравнения используют одинаковые скобки и настройки шрифта.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

В PowerPoint сравните строки, чтобы увидеть эффект роста. В верхней строке скобки растут, охватывая степень, и выглядят одинаково для обеих фигур. В нижней строке рост отключён. Меньшие скобки слева (`Centered`) выравниваются с знаком «=», а справа (`Match`) находятся выше вокруг выражения.

![Четыре уравнения в PowerPoint с включённым ростом разделителей сверху и отключённым снизу; слева — Centered, справа — Match](delimiter-sizing.png)

## **Добавление рамки‑коробки**

Вызовите [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) у дроби, чтобы обрамить всё выражение. Возвращаемый [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) по умолчанию отображает все четыре стороны. Используйте [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) и [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight), чтобы убрать отдельные стороны.

В примере шесть копий одной и той же дроби размещены на одном слайде. Чтобы показать зачёркивание, скрывайте все четыре стороны и передайте `true` в [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) для восходящей диагонали (↗) или в [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) для нисходящей диагонали (↘). Также можно использовать [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) или [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) с любой комбинацией видимых сторон.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Шесть редактируемых дробей в PowerPoint. Верхняя строка: полная рамка, нижняя и левая стороны, восходящая диагональ. Нижняя строка: нисходящая диагональ, горизонтальное зачёркивание, вертикальное зачёркивание с полной рамкой.](border-box-fractions.png)

На этой дроби горизонтальное зачёркивание перекрывает черту дроби. Вертикальное зачёркивание проходит через числитель и знаменатель, при этом окружающая рамка остаётся видимой. Эти линии декорируют всё выражение. Обычное зачёркивание текста применяется к символам в текстовом фрагменте. После повторного открытия презентации в PowerPoint вы всё равно сможете отдельно редактировать числитель и знаменатель.

## **Группировка терминов**

Используйте [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group), чтобы разместить группирующий символ над или под выражением. Добавьте предел, чтобы пометить сгруппированные термы.

![Выражение x + y, сгруппированное с подписью любой текст ниже него](powerpoint-math-equations_15.png)

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

## **Форматирование математических элементов**

Применяйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) помещает черту над математическим элементом.

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

### **Форматирование текста в существующем уравнении**

Чтобы отформатировать текст во всём уравнении, пройдите по дереву элементов каждого математического блока. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) возвращает только непосредственных потомков, поэтому вызывайте его рекурсивно, чтобы добраться до текста внутри дробей, скриптов, радикалов и других вложенных структур. Проверяйте текущий элемент и его детей, включая стартовый элемент, если он является [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

Этот пример предполагает, что `input.pptx` содержит уравнение вроде `z = xᵢ / ∛y`, где в дроби числитель имеет нижний индекс, а знаменатель — радикал. Обработка только верхнеуровневых элементов блока пропустит текст внутри дроби. Пример ищет математические части в текстовых кадрах слайдов, получает их блоки через [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) и использует [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight), чтобы задать размер шрифта 28 pt через метод [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) каждого текстового элемента.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сохранённая презентация содержит обновлённое форматирование текста на каждом уровне каждого обработанного уравнения, при этом сохраняется его текстовое содержание и математическая структура.

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Объединение элементов | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Создание дробей | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление верхнего или нижнего индекса | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление функций | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление радикалов | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление пределов | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление скриптов слева | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление сумм и интегралов | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Добавление массивов уравнений | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление разделителей | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление черт и рамок | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Группировка терминов | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите форму, содержащую [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемый контент Office Math.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) из его [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), затем вызовите [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) для прямого экспорта. Полный пример см. в [Export Math Equations from Presentations in PHP via Java](/slides/ru/php-java/exporting-math-equations/#export-math-equations-to-latex).