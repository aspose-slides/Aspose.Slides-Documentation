---
title: Добавить математические уравнения в презентации PowerPoint на Python
linktitle: Математические уравнения
type: docs
weight: 80
url: /ru/python-net/powerpoint-math-equations/
keywords:
- уравнение
- уравнение PowerPoint
- символ
- символ PowerPoint
- формула
- формула PowerPoint
- текст
- текст PowerPoint
- добавить уравнение в PowerPoint
- добавить символ в PowerPoint
- добавить формулу в PowerPoint
- добавить текст в PowerPoint
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как работать с математическими уравнениями в PowerPoint, используя Aspose.Slides для Python через .NET. Получите подробные инструкции, примеры кода и рекомендации по автоматизации создания и редактирования презентаций."
---

## **Обзор**

В PowerPoint вы можете написать математическое уравнение или формулу и отобразить её в презентации. Доступно множество математических символов, которые можно добавить к тексту или уравнениям. Конструктор математических уравнений используется для создания сложных формул, таких как:

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

Это создаст математический текст в XML, который будет отображён в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает широкий набор математических символов для создания уравнений. Однако генерация сложных уравнений часто не даёт отшлифованный, профессиональный результат. Поэтому пользователи, часто создающие математические презентации, обращаются к сторонним решениям для получения более эстетичных формул.

Используя [**Aspose.Slides API**](https://products.aspose.com/slides/python-net/), вы можете работать с математическими уравнениями в презентациях PowerPoint программно на Python. Создавать новые математические выражения или редактировать уже созданные. Частичная поддержка экспорта математических структур в виде изображений.

## **Как создать математическое уравнение**

Математические элементы используются для построения любой математической конструкции, независимо от уровня вложенности. Линейная коллекция этих элементов образует математический блок, представленный классом [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Класс [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) представляет отдельное математическое выражение, формулу или уравнение. Класс [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) используется для хранения математического текста (отличного от обычного класса [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)), а класс [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) позволяет работать с набором объектов [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Эти классы необходимы для работы с математическими уравнениями PowerPoint через Aspose.Slides API.

Посмотрим, как создать следующее математическое уравнение с помощью Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте фигуру, в которой будет размещён математический текст:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


После создания фигуры она уже содержит один абзац с математической частью по умолчанию. Класс [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) представляет часть, содержащую математический текст. Чтобы получить доступ к математическому содержимому внутри [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), обратитесь к переменной [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/):
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


Операции класса [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) реализованы во всех типах элементов, включая класс [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Ниже приведён полный пример исходного кода:
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

Математические выражения состоят из последовательностей математических элементов. Математический блок представляет такую последовательность, а аргументы этих элементов образуют вложенную древовидную структуру.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть вложен в другой, образуя древовидную структуру. Самый простой тип элемента – тот, который не содержит других математических текстовых элементов.

Каждый тип математического элемента реализует класс [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), позволяя использовать общий набор математических операций для разных типов элементов.

### **Класс MathematicalText**

Класс [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) представляет математический текст — базовый элемент всех математических конструкций. Математический текст может представлять операнды и операции, переменные или любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐

### **Класс MathFraction**

Класс [MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) задаёт объект дроби, состоящий из числителя и знаменателя, разделённых чертой дроби. Черта может быть горизонтальной или диагональной в зависимости от свойств дроби. Объект дроби также используется для представления функции стека, где один элемент помещается над другим без черты дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Класс MathRadical**

Класс [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) задаёт радикал (математический корень), состоящий из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Класс MathFunction**

Класс [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) задаёт функцию от аргумента. Он содержит свойства, такие как [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/), представляющее имя функции, и [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/), представляющее аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Класс MathNaryOperator**

Класс [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) задаёт N‑арный математический объект, например суммирование или интеграл. Он состоит из оператора, основания (или операнда) и необязательных верхних и нижних пределов. Примерами N‑арных операторов являются суммирование, объединение, пересечение и интеграл.

Этот класс не включает простые операторы, такие как сложение или вычитание; они представляются отдельным текстовым элементом [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Класс MathLimit**

Класс [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) создаёт верхний или нижний предел. Он задаёт объект предела, состоящий из текста на базовой линии и уменьшенного текста, размещённого непосредственно выше или ниже её. Элемент не включает слово «lim», но позволяет разместить текст сверху или снизу выражения. Таким образом выражение

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

Эти классы задают нижний или верхний индекс. Можно одновременно задавать и нижний, и верхний индекс слева или справа от аргумента, однако одиночный индекс поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) также может использоваться для указания степени числа.

Пример:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Класс MathMatrix**

Класс [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) задаёт объект матрицы, состоящий из дочерних элементов, расположенных в одной или нескольких строках и столбцах. Важно отметить, что у матриц нет встроенных разделителей. Чтобы заключить матрицу в скобки, используйте объект разделителя [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/). Для создания пробелов в матрице можно передавать пустые аргументы.

Пример:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Класс MathArray**

Класс [MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) задаёт вертикальный массив уравнений или любых математических объектов.

Пример:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Форматирование математических элементов**

- Класс [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) — рисует прямоугольную (или альтернативную) рамку вокруг [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Пример:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) — задаёт логическую упаковку (boxing) математического элемента. Упакованный объект может выступать в роли имитатора оператора — с точкой выравнивания или без неё, функционировать как разрыв строки или быть сгруппированным, чтобы предотвратить переносы внутри. Например, оператор «==» следует упаковать, чтобы избежать разрывов строки.

- Класс [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) — задаёт объект-разделитель, состоящий из открывающего и закрывающего символов (скобки, фигурные скобки, квадратные скобки, вертикальная черта) и одного или нескольких математических элементов внутри, разделённых указанным символом. Примеры: (𝑥₂); [𝑥₂|𝑦₂].

Пример:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) — задаёт акцент, состоящий из основания и комбинирующего диакритического знака.

Пример: 𝑎́.

- Класс [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) — задаёт черту над или под элементом.

Пример:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) — задаёт символ группировки, размещаемый над или под выражением, обычно для выделения взаимосвязей элементов.

Пример:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Математические операции**

Каждый математический элемент и каждое математическое выражение (через [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) реализует класс [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Это позволяет выполнять операции над существующей структурой и формировать более сложные математические выражения. Все операции имеют два набора параметров: либо [IMathElement], либо строковые аргументы. При использовании строковых аргументов экземпляры класса [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) создаются неявно из указанных строк. Ниже перечислены доступные в Aspose.Slides математические операции.

### **Метод Join**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

Эти методы соединяют математический элемент и формируют математический блок. Пример:
```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **Метод Divide**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

Эти методы создают дробь указанного типа с числителем и заданным знаменателем. Пример:
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Метод Enclose**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

Эти методы помещают элемент в заданные символы, например скобки или другие ограничительные символы. Пример:
```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Метод Function**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

Эти методы принимают функцию от аргумента, используя текущий объект как имя функции. Пример:
```py
function = math.MathematicalText("sin").function("x")
```


### **Метод AsArgumentOfFunction**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Эти методы берут указанную функцию, используя текущий экземпляр как аргумент. Вы можете:

- задать строку как имя функции, например «cos»;
- выбрать одно из предопределённых значений перечислений [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) или [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/), например `MathFunctionsOfOneArgument.ARC_SIN`;
- передать экземпляр [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Пример:
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
- [set_sub_superscript_on_the_right(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

Эти методы задают нижний и верхний индексы. Можно задавать оба одновременно слева или справа от аргумента; однако одиночный индекс поддерживается только справа. **Superscript** также может использоваться для указания степени числа.

Пример:
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Метод Radical**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

Эти методы задают математический корень заданной степени на основе указанного аргумента.

Пример:
```py
radical = math.MathematicalText("x").radical("3")
```


### **Методы SetUpperLimit и SetLowerLimit**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

Эти методы задают верхний или нижний предел, где «upper» и «lower» указывают расположение аргумента относительно основания.

Рассмотрим выражение:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Подобные выражения можно создать комбинацией классов [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) и [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/), используя операции класса [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/):
```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **Методы Nary и Integral**

- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

Оба метода, `nary` и `integral`, создают и возвращают N‑арный оператор типа [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/). В методе `nary` перечисление [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) задаёт тип оператора — например, суммирование или объединение, без интегралов. В методе `integral` предоставляется специализированная операция для интегралов, использующая перечисление [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/).

Пример:
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **Метод ToMathArray**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) помещает элементы в вертикальный массив. Если вызвать эту операцию у экземпляра [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/), все его дочерние элементы будут размещены в возвращаемом массиве.

Пример:
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- Метод [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) — ставит акцент (символ над элементом).
- Методы [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) и [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) — ставят линию сверху или снизу.
- Метод [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) — помещает в группу, используя символ группировки, например нижнюю фигурную скобку или иной.
- Метод [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) — помещает в рамочный блок.
- Метод [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) — помещает в невизуальный блок (логическая группировка).

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

Для добавления уравнения необходимо [создать объект математической фигуры](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), который автоматически содержит математическую часть. Затем получите [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) из [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) и добавьте в него объекты [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

**Можно ли создавать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные математические выражения, вкладывая [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) друг в друга. Каждый математический элемент поддерживает операции (Join, Divide, Enclose и др.) для комбинирования в более сложные структуры.

**Как обновить или изменить существующее математическое уравнение?**

Чтобы обновить уравнение, необходимо получить доступ к существующему [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) через [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Затем, используя методы Join, Divide, Enclose и другие, можно изменить отдельные элементы уравнения. После редактирования сохраните презентацию, чтобы применить изменения.