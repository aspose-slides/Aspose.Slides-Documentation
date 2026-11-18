---
title: Добавить математические уравнения в презентации PowerPoint в PHP
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
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides for PHP via Java, поддержка OMML, управление форматированием и понятные примеры кода PHP."
---
## **Обзор**

PowerPoint сохраняет уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides for PHP via Java можно программно создавать тот же тип математического контента: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и отформатированные блоки математики.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Получается редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создает такой математический текст через три основных объекта:

- Математическую форму, создаваемую с помощью [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), – это форма, содержащая уравнение.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) хранит математическое содержимое внутри текстового кадра формы.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) и fluent‑методы из [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) для краткости и читаемости кода.

Для сценариев экспорта в MathML см. [Export Math Equations from Presentations in PHP via Java](/slides/ru/php-java/exporting-math-equations/).

## **Создание уравнения**

В этом примере используется [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) для создания математической формы и добавления теоремы Пифагора:

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

[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) создает форму, уже содержащую математический абзац. Получите первый [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) и добавьте в него математические блоки или элементы.

{{% /alert %}}

## **Добавление дробей**

Используйте [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) для создания дроби. Можно выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![Скосованная дробь, показывающая один деленное на x](powerpoint-math-equations_4.png)

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

Для «накладывающейся» дроби используйте [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Добавление радикалов**

Используйте [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) для создания квадратного, кубического или другого корня. Текущий элемент становится основанием, а аргумент – степенью.

![Выражение радикала n‑й степени с x под радикальной чертой](powerpoint-math-equations_5.png)

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

### **Показ или скрытие степени квадратного корня**

Квадратный корень может явно отображать 2 или использовать обычную запись √x. Метод [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) класса [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) управляет тем, какая форма отображается. Оба варианта сохраняют степень 2 и радиканд x в редактируемом уравнении.

![Тот же квадратный корень: слева степень видна, справа скрыта](square-root-degree.png)

Пример сохраняет один и тот же квадратный корень дважды. В `visible-degree.pptx` 2 видна. В `hidden-degree.pptx` 2 скрыта.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $radical = (new MathematicalText("x"))->radical("2");

    $shape = $slide->getShapes()->addMathShape(20, 20, 200, 100);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getMathParagraph()->add(new MathBlock($radical));

    $radical->setHideDegree(false);
    $presentation->save("visible-degree.pptx", SaveFormat::Pptx);

    $radical->setHideDegree(true);
    $presentation->save("hidden-degree.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Добавление функций и пределов**

Для функций, таких как `sin(x)`, `log(x)` или пользовательские имена, используйте [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) или [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function). Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) или используйте [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![Предел x при x → ∞](powerpoint-math-equations_8.png)

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

Для пользовательского имени функции сделайте имя функции текущим элементом и вызовите [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) с его аргументом:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Добавление N‑арных операторов и интегралов**

Используйте [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) для сумм, объединений, пересечений и других больших операторов. Для интегралов — [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral). Оба метода позволяют задавать нижние и верхние пределы.

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

N‑арные операторы предназначены для больших операторов с необязательными пределами. Простые операторы вроде `+`, `-` и `=` обычно добавляются как [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) и объединяются в выражение.

Для интеграла используйте [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Добавление матриц**

Используйте [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) для строк и столбцов. По умолчанию у матриц нет скобок, поэтому при необходимости оборачивайте их в круглые, квадратные или фигурные скобки.

![Матрица из двух строк с одной пустой ячейкой](powerpoint-math-equations_10.png)

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

### **Редактирование существующей матрицы**

Предположим, урок линейной алгебры начинается с матрицы коэффициентов в `matrix.pptx`, сохранённой предыдущим примером. Для следующего упражнения оставьте первое уравнение, замените второе двумя новыми и скорректируйте набор переменных. Откройте существующую матрицу через [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/), чтобы сохранить коэффициенты, которые ещё актуальны.

![Исходная матрица коэффициентов из двух строк: 1, x, (пусто) в первой строке и x, 2, y во второй](matrix-before-edit.png)

Индексы строк и столбцов начинаются с 0 и относятся к текущему состоянию матрицы при каждом вызове. Вставка строки перед индексом 1 смещает оригинальную вторую строку к индексу 2. Вставка после индекса 2 добавляет строку в конец. Удаление строки 2 убирает оригинальное второе уравнение и сдвигает добавленную строку вверх. Столбцы смещаются аналогично.

```php
use aspose\slides\MathematicalText;
use aspose\slides\MathHorizontalAlignment;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("matrix.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $block = $portion->getMathParagraph()->get_Item(0);
    $matrix = $block->get_Item(0);

    $matrix->insertRowBefore(1);
    $matrix->insertRowAfter(2);
    $matrix->deleteRow(2);

    $matrix->insertColumnBefore(1);
    $matrix->insertColumnAfter(3);
    $matrix->deleteColumn(3);

    // Новые ячейки изначально null. Сначала задайте ненулевые коэффициенты.
    $matrix->set_Item(1, 0, new MathematicalText("12"));
    $matrix->set_Item(1, 1, new MathematicalText("1"));
    $matrix->set_Item(2, 2, new MathematicalText("10"));
    $matrix->set_Item(2, 3, new MathematicalText("1"));
    $rowCount = java_values($matrix->getRowCount());
    $columnCount = java_values($matrix->getColumnCount());
    for ($row = 0; $row < $rowCount; $row++) {
        for ($column = 0; $column < $columnCount; $column++) {
            $coefficient = $matrix->get_Item($row, $column);
            if (java_is_null($coefficient)) {
                $matrix->set_Item($row, $column, new MathematicalText("0"));
            }
        }
    }

    $matrix->setColumnAlignment(0, MathHorizontalAlignment::Left);
    $matrix->setColumnsAlignment(1, 3, MathHorizontalAlignment::Right);

    $presentation->save("updated-matrix.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) выравнивает первый столбец по левому краю. [setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) выравнивает три последовательных столбца по правому краю, начиная с индекса 1. В `updated-matrix.pptx` матрица содержит три уравнения и четыре переменные. Коэффициенты первой строки `1` и `x` теперь находятся в первом и третьем столбцах.

![Обновлённая матрица из трёх строк: 1, 0, x, 0; 12, 1, 0, 0; 0, 0, 10, 1](matrix-after-edit.png)

## **Добавление массивов уравнений**

Используйте [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray), когда нужны выровненные уравнения или вертикальная стопка выражений.

![Вертикальный массив с x над y](powerpoint-math-equations_11.png)

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

### **Выровнять массив относительно соседних элементов**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) управляет вертикальным выравниванием массива относительно соседних математических элементов. В примере ниже сравнивается выравнивание первой строки, центра массива и последней строки.

Следующий пример создаёт три одинаковых массива, каждый из трёх строк, с соседними элементами `A=` и `=B`. Весь математический текст использует шрифт Cambria Math 24 pt. Меняется только выравнивание массива.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сравнительный снимок показывает сохранённую презентацию в PowerPoint. Обратите внимание на позицию `A=` и `=B` рядом с каждым массивом.

![Массивы уравнений в PowerPoint с верхним, центральным и нижним выравниванием и одинаковыми соседними элементами](equation-array-alignment.png)

### **Настройка расстояния между строками**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) выбирает правило расстояния между строками в массиве. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) задаёт числовое значение для явного правила и игнорируется предустановленными правилами.

Для точного расстояния значение измеряется в пунктах. Для пропорционального – в полулиниях: значение `3` в примере означает 1,5 строки. При указании явного значения задайте оба свойства; изменение только числового значения не выбирает правило.

Ниже пример сохраняет пять презентаций с одинаковыми уравнениями, выравниванием и настройками шрифта. Первые три используют предустановки, последние два – явные значения.

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

Расстояние между строками массива отличается от интервала между абзацами. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) и [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) добавляют отступы вокруг содержащего абзаца, а не между строками массива. Аналогично, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) позиционирует весь математический абзац горизонтально; он не заменяет вертикальное выравнивание массива.

## **Добавление тригонометрических функций**

Используйте [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction), когда аргумент – текущий элемент, а имя функции известно.

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

## **Добавление индексов и показателей**

Используйте вспомогательные функции для индексов и степеней. Когда индексы должны располагаться слева от основания, примените [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Буква Y с левосторонним индексом 1 и показателем n](powerpoint-math-equations_9.png)

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

## **Добавление ограничителей**

Используйте [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) для помещения выражения в ограничители. Можно также задать разделительный символ для выражений, содержащих несколько элементов.

![Выражение с ограничителями, содержащие x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

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

### **Размер и выравнивание ограничителей**

Передайте `true` в [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), чтобы скобки расширялись вокруг высокого операнда, или `false`, чтобы оставить их обычного размера. С помощью [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) выберите один из вариантов [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/). `Centered` центрирует скобки относительно математической оси, проходящей через середину знака «=». `Match` выравнивает их по содержимому. Оба параметра влияют лишь на ограничители; содержимое выражения остаётся прежним.

В примере дробь помещена в показатель степени `x`, поэтому выражение выступает выше базовой линии сильнее, чем ниже. Все четыре уравнения используют одинаковые скобки и настройки шрифта.

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

В PowerPoint сравните строки, чтобы увидеть эффект роста. В верхней строке скобки растут, охватывая показатель, и выглядят одинаково для обеих форм. В нижней строке рост отключён. Маленькие скобки слева (`Centered`) выравниваются с знаком «=», а правые (`Match`) находятся выше, охватывая выражение.

![Четыре уравнения в PowerPoint с включённым и отключённым ростом ограничителей, слева Centered, справа Match](delimiter-sizing.png)

## **Добавление рамки‑границы**

Вызовите [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) у дроби, чтобы обрамить всё выражение. Возвращаемый объект [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) по умолчанию отображает все четыре стороны. С помощью [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) и [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) можно скрыть отдельные стороны.

В примере шесть копий одной и той же дроби размещены на одном слайде. Чтобы показать отмену, скрывают все четыре стороны и передают `true` в [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) для диагонали ↗ или в [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) для диагонали ↘. Также можно применять [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) или [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) с любой комбинацией видимых сторон.

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

![Шесть редактируемых дробей в PowerPoint. Верхняя строка: полная граница, нижняя и левая стороны, диагональ ↗. Нижняя строка: диагональ ↘, горизонтальная черта, вертикальная черта при полной границе.](border-box-fractions.png)

На этой дроби горизонтальная черта пересекает черту дроби. Вертикальная черта проходит через числитель и знаменатель, в то время как окружающая граница остаётся видимой. Такие линии украшают всё выражение. Обычное зачеркивание текста применяется к символам в текстовом фрагменте. После повторного открытия презентации в PowerPoint числитель и знаменатель по‑прежнему можно редактировать независимо.

## **Управление видимостью и раскладкой с помощью Phantom‑элементов**

Обёрните выражение в [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/), чтобы управлять его видимостью и занимаемым пространством независимо. Методы [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) регулируют следующее:

| Метод | Эффект |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | Передайте `false`, чтобы скрыть выражение. Его размеры всё равно учитываются в раскладке, пока соответствующие методы ниже не получат `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | Рассматривать горизонтальную ширину выражения как 0, позволяя соседним элементам сблизиться. |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | Рассматривать его подъем (высоту над базовой линией) как 0. Это может уменьшить пространство над соседними элементами. |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | Рассматривать его спуск (глубину ниже базовой линии) как 0. Это может перенести линию дроби или другое содержимое ближе к соседям. |

Базовая линия — это ориентир, на котором размещаются обычные математические символы. Скрытие контента не удаляет его размеры, а трактование размера как 0 не удаляет выражение. Исходное выражение остаётся доступным через [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase). Передайте `true` в [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow), чтобы отобразить его снова; настройки размеров сохраняются.

В примере ниже создаются пять вариантов рядом: видимая дробь, скрытая дробь, сохраняющая пространство, и три скрытых дроби с нулевой шириной, нулевым подъемом или нулевым спуском. Все варианты используют одно и то же окружающее выражение и шрифт Cambria Math 24 pt. Все формы уравнений имеют одинаковую верхнюю позицию, отмеченную серой направляющей. Размещение phantom‑элемента в числителе внешней дроби облегчает восприятие вертикальных изменений раскладки.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathBlock;
use aspose\slides\MathFraction;
use aspose\slides\MathPhantom;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(1000, 180, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"];

    $guide = $slide->getShapes()->addAutoShape(ShapeType::Line, 10, 60, 980, 0);
    $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    foreach ($labels as $i => $labelText) {
        $left = 10 + $i * 200;

        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $left, 10, 190, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($labelText);

        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(14);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $fractionNumerator = $createText("a+b");
        $fractionDenominator = $createText("c+d");
        $fraction = new MathFraction($fractionNumerator, $fractionDenominator);
        $phantom = new MathPhantom($fraction);
        $phantom->setShow($i === 0);
        $phantom->setZeroWidth($i === 2);
        $phantom->setZeroAsc($i === 3);
        $phantom->setZeroDesc($i === 4);

        $leftText = $createText("x+");
        $rightText = $createText("+y");
        $numerator = (new MathBlock($leftText))->join($phantom)->join($rightText);
        $denominator = $createText("z");
        $equation = new MathFraction($numerator, $denominator);

        $shape = $slide->getShapes()->addMathShape($left, 60, 190, 100);
        $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);

        $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $mathParagraph = $mathPortion->getMathParagraph();
        $mathBlock = new MathBlock($equation);
        $mathParagraph->add($mathBlock);
    }

    $presentation->save("math-phantom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Пять уравнений в PowerPoint, сравнивающих видимую дробь, скрытую дробь с сохранением места и скрытые дроби с включёнными ZeroWidth, ZeroAsc или ZeroDesc](math-phantom.png)

## **Группировка членов**

Используйте [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) для размещения группирующего символа над или под выражением. Добавьте предел, чтобы подписать сгруппированные члены.

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

## **Форматирование математических элементов**

Применяйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) размещает черту над элементом.

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

Чтобы отформатировать текст по всему существующему уравнению, пройдите дерево элементов каждого математического блока. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) возвращает только непосредственных потомков, поэтому вызывайте его рекурсивно, чтобы добраться до текста внутри дробей, индексов, радикалов и других вложенных структур. Проверяйте текущий элемент и его детей, чтобы включить начальный элемент, если он является [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

В этом примере предполагается, что `input.pptx` содержит уравнение вроде `z = xᵢ / ∛y`, где дробь имеет индекс в числителе, а радикал – в знаменателе. Обработка только верхнеуровневых элементов блока пропустит текст внутри дроби. Пример ищет математические части в текстовых кадрах слайдов, получает их блоки через [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) и использует [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight), чтобы задать размер шрифта 28 pt каждому текстовому элементу через его метод [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat).

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

Сохранённая презентация содержит обновлённое форматирование текста на каждом уровне каждой обработанной формулы, сохраняя её текстовое содержание и математическую структуру.

## **Краткое справочное руководство**

| Задача | Основной API |
| --- | --- |
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Объединение элементов | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Создание дробей | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление надстрочного или нижстрочного индекса | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление функций | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление радикалов | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление пределов | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление индексов слева | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление сумм и интегралов | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Добавление массивов уравнений | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление ограничителей | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Добавление черт и рамок | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Группировка членов | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Можно ли редактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите форму, содержащую [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в формате PPTX Aspose.Slides записывает уравнение как редактируемый Office‑math контент.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) уравнения из его [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), затем вызовите [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) для прямого экспорта. Полный пример см. в разделе [Export Math Equations from Presentations in PHP via Java](/slides/ru/php-java/exporting-math-equations/#export-math-equations-to-latex).