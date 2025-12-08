---
title: Добавить математические уравнения в презентации PowerPoint на Python
linktitle: Математические уравнения
type: docs
weight: 80
url: /ru/python-net/powerpoint-math-equations/
keywords:
- математическое уравнение
- математическое уравнение PowerPoint
- математический символ
- математический символ PowerPoint
- математическая формула
- математическая формула PowerPoint
- математический текст
- математический текст PowerPoint
- добавить математическое уравнение в PowerPoint
- добавить математический символ в PowerPoint
- добавить математическую формулу в PowerPoint
- добавить математический текст в PowerPoint
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Изучите, как работать с математическими уравнениями в PowerPoint, используя Aspose.Slides для Python через .NET. Получите подробные инструкции, примеры кода и советы по автоматизации создания и редактирования презентаций."
---

## **Обзор**

В PowerPoint вы можете написать математическое уравнение или формулу и отобразить её в своей презентации. Доступны различные математические символы, которые можно добавлять в текст или уравнения. Конструктор математических уравнений используется для создания сложных формул, таких как:

- Математическая дробь
- Математический радикал
- Математическая функция
- Пределы и логарифмические функции
- N-арные операции
- Матрица
- Большие операторы
- Функции sin, cos

Для добавления математического уравнения в PowerPoint используется меню *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в XML, который может быть отображён в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает широкий набор математических символов для создания уравнений. Однако генерация сложных математических уравнений в PowerPoint часто не дает отполированного, профессионального результата. Поэтому пользователи, часто создающие математические презентации, часто обращаются к сторонним решениям для получения более красивых формул.

Используя [**Aspose.Slides API**](https://products.aspose.com/slides/python-net/), вы можете работать с математическими уравнениями в презентациях PowerPoint программно на Python. Создавайте новые математические выражения или редактируйте уже созданные. Частичная поддержка доступна для экспорта математических структур в виде изображений.

## **Как создать математическое уравнение**

Математические элементы используются для построения любой математической конструкции, независимо от уровня вложенности. Линейная последовательность этих элементов образует математический блок, представляемый классом [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Класс [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) представляет самостоятельное математическое выражение, формулу или уравнение. Класс [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) используется для хранения математического текста (отличного от обычного класса [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)), а [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) позволяет манипулировать набором объектов [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Эти классы необходимы для работы с математическими уравнениями PowerPoint через Aspose.Slides API.

Посмотрим, как можно создать следующее математическое уравнение с помощью Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте форму, которая будет содержать математический текст:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


После создания формы в ней уже по умолчанию есть один абзац с математической долей. Класс [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) представляет долю, содержащую математический текст. Чтобы получить доступ к содержимому математической доли, обратитесь к переменной [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/):
```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


Класс [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) позволяет читать, добавлять, редактировать и удалять математические блоки ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), которые состоят из комбинации математических элементов. Например, создать дробь и поместить её в презентацию:
```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
``` 

```py
math_block = (
    math.MathematicalText("c").set_superscript("2").
        join("=").
        join(math.MathematicalText("a").set_superscript("2")).
        join("+").
        join(math.MathematicalText("b").set_superscript("2")))
```


Операции интерфейса [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) реализованы в каждом типе элемента, включая класс [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Ниже полное примерное исходное приложение:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    math_paragraph.add(math.MathBlock(fraction))

    math_block = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    math_paragraph.add(math_block)

    presentation.save("math.pptx", slides.export.SaveFormat.PPTX)
```


## **Типы математических элементов**

Математические выражения состоят из последовательностей математических элементов. Математический блок представляет такую последовательность, а аргументы этих элементов формируют вложенную, древовидную структуру.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть агрегирован внутри другого, образуя древовидную структуру. Самый простой тип элемента — тот, который не содержит других математических текстовых элементов.

Каждый тип математического элемента реализует интерфейс [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), позволяя использовать единый набор математических операций для разных типов элементов.

### **Класс MathematicalText**

Класс [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) представляет математический текст — базовый элемент всех математических построений. Математический текст может представлять операнды и операторы, переменные или любой иной линейный текст.

Пример: 𝑎=𝑏+𝑐

### **Класс MathFraction**

Класс [MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) задаёт объект дроби, состоящий из числителя и знаменателя, разделённых чертой дроби. Черта может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления функции «стек», при которой один элемент размещается над другим без черты дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Класс MathRadical**

Класс [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) задаёт радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Класс MathFunction**

Класс [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) задаёт функцию аргумента. Он содержит свойства, такие как [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/), представляющее имя функции, и [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/), представляющее аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Класс MathNaryOperator**

Класс [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) задаёт N‑арный математический объект, такой как суммирование или интеграл. Он состоит из оператора, основания (или операнда) и необязательных верхних и нижних пределов. Примеры N‑арных операторов: Summation, Union, Intersection и Integral.

Этот класс не включает простые операторы, такие как сложение, вычитание и т.п. Они представлены единственным текстовым элементом [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Класс MathLimit**

Класс [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) создаёт верхний или нижний предел. Он задаёт объект предела, состоящий из текста на базовой линии и уменьшенного текста непосредственно над или под ней. Этот элемент не включает слово «lim», но позволяет разместить текст вверху или внизу выражения. Таким образом, выражение  

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией элементов [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) и [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/):
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Эти классы задают нижний или верхний индекс. Вы можете одновременно установить нижний и верхний индексы слева или справа от аргумента, но одиночный нижний или верхний индекс поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) также может использоваться для задания математической степени числа.

Пример:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Класс MathMatrix**

Класс [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) задаёт объект матрицы, состоящий из дочерних элементов, размещённых в одной или нескольких строках и столбцах. Важно отметить, что у матриц нет встроенных ограничителей. Чтобы заключить матрицу в скобки, используйте объект ограничителя [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/). Для создания пробелов в матрицах можно использовать нулевые аргументы.

Пример:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Класс MathArray**

Класс [MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) задаёт вертикальный массив уравнений или любых математических объектов.

Пример:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Форматирование математических элементов**

- Класс [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) — рисует прямоугольную или альтернативную рамку вокруг [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Пример:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) — задаёт логическое обрамление (упаковку) математического элемента. Объект в рамке может выступать как эмулятор оператора — с точкой выравнивания или без неё — выступать в роли разрыва строки или группироваться, чтобы предотвратить разрывы внутри. Например, оператор «==» следует поместить в рамку, чтобы избежать разрывов.

- Класс [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) — задаёт объект ограничителя, который состоит из открывающих и закрывающих символов (например, скобок, фигурных скобок, квадратных скобок или вертикальных черт) и одного или более математических элементов внутри, разделённых указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].

Пример:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) — задаёт функцию акцента, состоящую из основания и комбинирующего диакритического знака.

Пример: 𝑎́.

- Класс [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) — задаёт функцию черты, состоящую из базового аргумента и надчерты или подчерты.

Пример:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) — задаёт группирующий символ, размещаемый над или под выражением, обычно для подчёркивания взаимосвязей между элементами.

Пример:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Математические операции**

Каждый математический элемент и каждое математическое выражение (через [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) реализуют интерфейс [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Это позволяет выполнять операции над существующей структурой и формировать более сложные математические выражения. Все операции имеют два набора параметров: либо [IMathElement], либо строковые аргументы. Экземпляры класса [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) неявно создаются из указанных строк, когда используются строковые аргументы. Ниже перечислены доступные в Aspose.Slides математические операции.

### **Метод Join**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

Эти методы соединяют математический элемент и образуют математический блок. Например:
```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **Метод Divide**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String,MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement,MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

Эти методы создают дробь указанного типа с заданным числителем и знаменателем. Например:
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Метод Enclose**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char,Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

Эти методы заключают элемент в указанные символы, например скобки или другие ограничительные символы. Например:
```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Метод Function**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

Эти методы принимают функцию от аргумента, используя текущий объект как имя функции. Например:
```py
function = math.MathematicalText("sin").function("x")
```


### **Метод AsArgumentOfFunction**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Эти методы берут указанную функцию, используя текущий экземпляр как аргумент. Вы можете:

- задать строку как имя функции, например "cos";
- выбрать одно из предопределённых значений перечислений [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) или [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/), например `MathFunctionsOfOneArgument.ARC_SIN`;
- передать экземпляр [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Например:
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```


### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**

- [set_subscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#str)
- [set_subscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#imathelement)
- [set_superscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#str)
- [set_superscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#imathelement)
- [set_sub_superscript_on_the_right(String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

Эти методы задают нижний и верхний индексы. Вы можете установить оба индекса одновременно слева или справа от аргумента; однако одиночный нижний или верхний индекс поддерживается только справа. **Superscript** также может использоваться для задания степени числа.

Пример:
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Метод Radical**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

Эти методы задают математический корень указанной степени на основе переданного аргумента.

Пример:
```py
radical = math.MathematicalText("x").radical("3")
```


### **Методы SetUpperLimit и SetLowerLimit**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

Эти методы задают верхний или нижний предел, где «верхний» и «нижний» указывают положение аргумента относительно основания.

Рассмотрим выражение:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения можно создать комбинацией классов [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) и [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/), а также операций интерфейса [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), как показано ниже:
```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **Методы Nary и Integral**

- [nary(MathNaryOperatorTypes,IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes,String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes,IMathElement,IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes,String,String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes,IMathElement,IMathElement,MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes,String,String,MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

Оба метода — `nary` и `integral` — создают и возвращают N‑арный оператор типа [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/). В методе `nary` перечисление [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) указывает тип оператора — например, суммирование или объединение — без интегралов. В методе `integral` предоставлена специализированная операция для интегралов, использующая перечисление [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/).

Пример:
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **Метод ToMathArray**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) помещает элементы в вертикальный массив. Если эта операция вызывается у экземпляра [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/), все его дочерние элементы будут размещены в возвращённом массиве.

Пример:
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- Метод [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) — добавляет надстрочный акцент (символ над элементом).
- Методы [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) и [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) — добавляют черту сверху или снизу.
- Метод [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) — размещает элемент в группе, используя группирующий символ, например нижнюю фигурную скобку.
- Метод [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) — размещает элемент в рамке‑коробке.
- Метод [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) — размещает элемент в невизуальной коробке (логическая группировка).

Примеры:
```py
accent = math.MathematicalText("x").accent(chr(0x0303))
bar = math.MathematicalText("x").overbar()
group_chr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
        math.MathTopBotPositions.BOTTOM, 
        math.MathTopBotPositions.TOP)
border_box = math.MathematicalText("x+y+z").to_border_box()
boxed_operator = math.MathematicalText(":=").to_box()
```


## **FAQ**

**Как добавить математическое уравнение на слайд PowerPoint?**

Чтобы добавить математическое уравнение, нужно создать объект [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) — математическую форму, которая автоматически содержит математическую долю. Затем получите [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) из [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) и добавьте в него объекты [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

**Можно ли создавать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные математические выражения посредством вложения [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Каждый математический элемент позволяет применять операции (Join, Divide, Enclose и т.д.) для комбинирования элементов в более сложные структуры.

**Как обновить или изменить уже существующее математическое уравнение?**

Чтобы обновить уравнение, необходимо получить доступ к существующему [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) через [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Затем, используя такие методы, как Join, Divide, Enclose и другие, можно изменить отдельные элементы уравнения. После редактирования сохраните презентацию, чтобы применить изменения.