---
title: Добавление математических уравнений в презентации PowerPoint на Java
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides для Java, поддерживая OMML, элементы управления форматированием и понятные примеры кода на Java."
---
## **Обзор**

PowerPoint сохраняет уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides for Java вы можете программно создавать такой же тип математического контента: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и форматированные блоки формул.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

В результате появляется редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides строит этот математический текст с помощью трёх основных объектов:

- Математическая фигура, создаваемая с помощью [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) хранит математический контент внутри текстового фрейма фигуры.
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) и методы из [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) для компактного и читаемого кода.

Для сценариев экспорта в MathML см. [Export Math Equations from Presentations in Java](/slides/ru/java/exporting-math-equations/).

## **Создание уравнения**

В этом примере используется [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) для создания математической фигуры и добавляется теорема Пифагора:

![Уравнение c² = a² + b²](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) создаёт фигуру, уже содержащую математический абзац. Получите первый [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), и добавляйте математические блоки или элементы.
{{% /alert %}}

## **Добавление дробей**

Используйте [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/).

![Наклонённая математическая дробь, показывающая один делённый на x](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

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

Для обычной (строчной) дроби используйте [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Добавление радикалов**

Используйте [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) для создания квадратного, кубического или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![Выражение n‑го корня с x под радикалом](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

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

Для функций, таких как `sin(x)`, `log(x)` или пользовательских имён, используйте [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) или [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-). Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) или используйте [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![Предел x при x стремящемся к бесконечности](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для пользовательского имени функции сделайте его текущим элементом и вызовите [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) с аргументом:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Добавление N‑арных операторов и интегралов**

Для сумм, объединений, пересечений и других крупных операторов используйте [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-). Для интегралов — [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-). Оба метода позволяют задавать нижний и верхний пределы.

![Сумма с нижним и верхним пределами](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

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

N‑арные операторы предназначены для крупных операторов с необязательными пределами. Простые операторы вроде `+`, `-` и `=` обычно добавляются как [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) и объединяются в выражении.

Для интеграла используйте [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Добавление матриц**

Используйте [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) для работы со строками и столбцами. По умолчанию у матриц нет скобок, поэтому при необходимости окружайте их круглыми, квадратными или фигурными скобками.

![Матрица с двумя строками и одной пустой ячейкой](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

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

Когда нужны выровненные уравнения или вертикальная стопка выражений, используйте [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--).

![Вертикальный массив с x над y](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

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

### **Выравнивание массива относительно соседних элементов**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) управляет вертикальным выравниванием массива относительно соседних математических элементов. Пример ниже сравнивает выравнивание по первой строке, центру массива и последней строке.

В следующем примере создаются три одинаковых массива по три строки каждый, рядом с элементами `A=` и `=B`. Весь математический текст использует Cambria Math 24 pt. Меняется только выравнивание массива.

```java
import com.aspose.slides.*;
import java.awt.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);
    
    int[] alignments = { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };
    String[] alignmentNames = { "Top", "Center", "Bottom" };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(alignmentNames[i]);
        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        IAutoShape mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        IMathParagraph mathParagraph = ((IMathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение сохраняет презентацию в PowerPoint. Обратите внимание на позицию `A=` и `=B` рядом с каждым массивом.

![Массивы уравнений в PowerPoint с выравниванием сверху, по центру и снизу и одинаковыми соседними элементами](equation-array-alignment.png)

### **Настройка межстрочного интервала в массиве**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) выбирает правило интервала между строками массива. [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) задаёт числовое значение для явного правила и игнорируется предустановленными правилами.

Для точного интервала значение измеряется в пунктовых единицах. Для пропорционального — в половинах строк: значение `3` в примере означает 1,5 строки. При указании явного значения задавайте оба свойства; изменение только числового не меняет правило интервала.

Ниже пример сохраняет пять презентаций с одинаковыми уравнениями, выравниванием и шрифтами. Первые три используют предустановки, последние два — явные значения.

```java
import com.aspose.slides.*;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
int[] rules = { MathRowSpacingRule.SingleLineGap, MathRowSpacingRule.OneAndAHalfLineGap, MathRowSpacingRule.TwoLineGap, MathRowSpacingRule.Exactly, MathRowSpacingRule.Multiple };
int[] spacingValues = { 0, 0, 0, 20, 3 };
String[] ruleNames = { "SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple" };

for (int i = 0; i < rules.length; i++) {
    String fileName = "equation-array-" + ruleNames[i] + ".pptx";
    Presentation presentation = new Presentation();
    try {
        IAutoShape mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        IMathParagraph mathParagraph = ((IMathPortion) paragraph.getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(spacingValues[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

Интервал строк массива отделён от интервала абзаца. [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) и [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) добавляют отступы вокруг содержащего абзаца, а не между строками массива. Аналогично, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) позиционирует весь математический абзац по горизонтали; он не заменяет вертикальное выравнивание массива.

## **Добавление тригонометрических функций**

Когда аргумент является текущим элементом, а имя функции известно, используйте [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-).

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

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

## **Добавление нижних и верхних индексов**

Для индексов и степеней используйте вспомогательные методы нижних и верхних индексов. Когда индексы должны располагаться слева от основания, используйте [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![Буква Y с левым нижним индексом 1 и верхним индексом n](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

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

## **Добавление разделителей**

Используйте [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) для помещения выражения в разделители. Также можно задать символ‑разделитель для выражений, содержащих несколько элементов.

![Выражение с разделителями, содержащими x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

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

### **Размер и выравнивание разделителей**

Передайте `true` в [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-), чтобы скобки увеличивались вокруг высокого операнда, или `false`, чтобы оставить их обычного размера. Используйте [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) с одним из значений [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/). `Centered` центрирует скобки по математической оси, проходящей через середину знака равенства. `Match` выравнивает их по содержимому. Оба параметра влияют только на скобки; выражение внутри остаётся без изменений.

В примере дробь помещена в показатель степени `x`, поэтому выражение выступает выше базовой линии сильнее, чем ниже. Все четыре уравнения используют одинаковые скобки и настройки шрифта.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (int row = 0; row < 2; row++) {
        for (int column = 0; column < 2; column++) {
            IMathFraction fraction = new MathematicalText("a + b").divide("c + d");
            IMathSuperscriptElement power = new MathematicalText("x").setSuperscript(fraction);
            IMathDelimiter delimiter = power.enclose('(', ')');
            delimiter.setGrowToMatchOperandHeight(row == 0);
            delimiter.setDelimiterShape(column == 0 ? MathDelimiterShape.Centered : MathDelimiterShape.Match);

            IAutoShape mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            MathPortion portion = (MathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            IMathBlock equation = new MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В PowerPoint сравните строки, чтобы увидеть эффект роста. В верхней строке скобки увеличиваются, охватывая показатель степени, и выглядят одинаково для обеих форм. В нижней строке рост отключён. Маленькие скобки слева (`Centered`) выравниваются с знаком равенства, а справа (`Match`) расположены выше вокруг выражения.

![Четыре уравнения в PowerPoint с включённым и отключённым ростом скобок, `Centered` слева и `Match` справа](delimiter-sizing.png)

## **Добавление рамки‑коробки**

Вызовите [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) у дроби, чтобы обрамить всё выражение. Возвращаемый [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) по умолчанию отображает все четыре стороны. Используйте [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) для скрытия отдельных сторон.

В примере шесть копий одной и той же дроби размещены на одном слайде. Чтобы показать зачёркивание, скройте все четыре стороны и передайте `true` в [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) для диагонали ↗ или в [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) для диагонали ↘. Также можно использовать [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) или [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) в комбинации с видимыми сторонами.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    class FractionBuilder {
        IMathBorderBox addFraction(float x, float y, boolean hideBorder) {
            IMathFraction fraction = new MathematicalText("x+1").divide("y+2");
            IMathBorderBox box = fraction.toBorderBox();
            box.setHideTop(hideBorder);
            box.setHideBottom(hideBorder);
            box.setHideLeft(hideBorder);
            box.setHideRight(hideBorder);

            IAutoShape shape = slide.getShapes().addMathShape(x, y, 160, 90);
            MathPortion portion = (MathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(28);
            portion.getMathParagraph().add(new MathBlock(box));
            return box;
        }
    }

    FractionBuilder builder = new FractionBuilder();
    builder.addFraction(10, 10, false);

    IMathBorderBox partial = builder.addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    builder.addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    builder.addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    builder.addFraction(190, 120, true).setStrikethroughHorizontal(true);
    builder.addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Шесть редактируемых дробей в PowerPoint. Верхняя строка: полная рамка, нижняя и левая стороны, диагональ ↗. Нижняя строка: диагональ ↘, горизонтальное зачёркивание, вертикальное зачёркивание с полной рамкой.](border-box-fractions.png)

На этой дроби горизонтальное зачёркивание перекрывает черту дроби. Вертикальное зачёркивание пересекает и числитель, и знаменатель, оставляя рамку видимой. Такие линии украшают всё выражение. Обычное зачёркивание текста применяется к символам в текстовом фрагменте. После повторного открытия презентации в PowerPoint вы всё ещё можете независимо редактировать числитель и знаменатель.

## **Группировка членов**

Используйте [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) для размещения символа группировки над или под выражением. Добавьте предел, чтобы подписать сгруппированные члены.

![Выражение x + y, сгруппированное с подписью «любой текст» снизу](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

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

Применяйте вспомогательные функции форматирования только там, где они делают формулу более понятной. Например, [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) ставит черту над элементом.

![Математическое выражение ABC с надчеркой](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

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

### **Форматирование текста в существующем уравнении**

Для форматирования текста по всему уравнению пройдите дерево элементов каждого математического блока. [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) возвращает только непосредственных детей, поэтому вызывайте его рекурсивно, чтобы добраться до текста внутри дробей, скриптов, радикалов и других вложенных структур. Проверяйте текущий элемент и его детей, включая стартовый элемент, если он является [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/).

В примере считается, что `input.pptx` содержит уравнение вида `z = xᵢ / ∛y`, где дробь имеет нижний индекс в числителе и радикал в знаменателе. Обработка только верхних элементов блока пропустила бы текст внутри дроби. Пример ищет математические части в текстовых фреймах слайдов, получает их блоки через [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), и использует [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) для установки размера шрифта 28 pt через метод [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) каждого текстового элемента.

```java
import com.aspose.slides.*;

class MathTextFormatter {
    void formatMathText(IMathElement element) {
        if (element instanceof MathematicalText) {
            MathematicalText text = (MathematicalText) element;
            text.getFormat().setFontHeight(28);
        }

        for (IMathElement child : element.getChildren()) {
            formatMathText(child);
        }
    }
}

MathTextFormatter formatter = new MathTextFormatter();
Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (portion instanceof IMathPortion) {
                        IMathPortion mathPortion = (IMathPortion) portion;
                        for (IMathBlock block : mathPortion.getMathParagraph()) {
                            formatter.formatMathText(block);
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сохранённая презентация содержит обновлённое форматирование текста на каждом уровне каждого обработанного уравнения, при этом сохраняются его содержимое и математическая структура.

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| Комбинирование элементов | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Создание дробей | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Добавление над- и нижестепенных индексов | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Добавление функций | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Добавление радикалов | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Добавление пределов | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Добавление скриптов слева | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Добавление сумм и интегралов | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| Добавление массивов уравнений | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| Добавление разделителей | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Добавление надчерки и рамок | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Группировка членов | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **FAQ**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемый контент Office Math.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) уравнения из его [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/), и вызовите [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) для прямого экспорта. Полный пример см. в [Export Math Equations from Presentations in Java](/slides/ru/java/exporting-math-equations/#export-math-equations-to-latex).