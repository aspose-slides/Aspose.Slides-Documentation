---
title: Математические уравнения PowerPoint
type: docs
weight: 80
url: /python-net/powerpoint-math-equations/
keywords: "Математические уравнения PowerPoint, Математические символы PowerPoint, Формула PowerPoint, Математический текст PowerPoint, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Математические уравнения PowerPoint, математические символы, формулы и математический текст на Python"
---

## **Обзор**
В PowerPoint возможно написать математическое уравнение или формулу и отобразить их в презентации. Для этого в PowerPoint представлены различные математические символы, которые могут быть добавлены в текст или уравнение. Для этого используется конструктор математических уравнений в PowerPoint, который помогает создавать сложные формулы, такие как:

- Математическая дробь
- Математический радикал
- Математическая функция
- Пределы и логарифмические функции
- N-арные операции
- Матрица
- Большие операторы
- Функции синуса и косинуса

Чтобы добавить математическое уравнение в PowerPoint, используется меню *Вставка -> Уравнение*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в XML, который может быть отображён в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания математических уравнений. Однако создание сложных математических уравнений в PowerPoint часто не приводит к хорошему и профессиональному результату. Пользователи, которым часто нужно создавать математические презентации, обращаются к использованию сторонних решений для создания привлекательных математических формул.

Используя [**Aspose.Slide API**](https://products.aspose.com/slides/python-net/), вы можете программно работать с математическими уравнениями в презентациях PowerPoint на Python. Создавать новые математические выражения или редактировать ранее созданные. Экспорт математических структур в изображения также частично поддерживается.

## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций с любым уровнем вложенности. Линейная коллекция математических элементов образует математический блок, представляемый классом [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Класс [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) по сути является отдельным математическим выражением, формулой или уравнением. [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) - это математическая порция, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)). [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) позволяет манипулировать набором математических блоков. Указанные выше классы являются ключевыми для работы с математическими уравнениями PowerPoint с помощью Aspose.Slides API.

Давайте посмотрим, как мы можем создать следующее математическое уравнение через Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте фигуру, которая будет содержать математический текст:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```

После создания фигура будет уже содержать один параграф с математической порцией по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) - это порция, которая содержит математический текст внутри. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/):

```py
    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph
```

Класс [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), состоящие из комбинации математических элементов. Например, создайте дробь и разместите её в презентации:

```py
    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))
```

Каждый математический элемент представлен некоторым классом, который реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Этот интерфейс предоставляет множество методов для лёгкого создания математических выражений. Вы можете создать довольно сложное математическое выражение одной строкой кода. Например, теорема Пифагора будет выглядеть так:

```py
    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))
```

Операции интерфейса [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) реализуются для любого типа элемента, включая [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Полный пример исходного кода:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))

    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    mathParagraph.add(mathBlock)

    pres.save("math.pptx", slides.export.SaveFormat.PPTX)
```

## **Типы математических элементов**
Математические выражения формируются из последовательностей математических элементов. Последовательность математических элементов представляется математическим блоком, а аргументы математических элементов формируют древовидную структуру вложенности.

Существует множество типов математических элементов, которые могут быть использованы для конструирования математического блока. Каждый из этих элементов может быть включён (агрегирован) в другой элемент. То есть, элементы фактически являются контейнерами для других, формируя древовидную структуру. Самый простой тип элемента не содержит других элементов математического текста.

Каждый тип математического элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), позволяя использовать общий набор математических операций на различных типах математических элементов.
### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) представляет математический текст - основной элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐
### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) определяет объект дроби, состоящий из числителя и знаменателя, разделённых дробной чертой. Дробная черта может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления функции стека, которая помещает один элемент над другим, без дробной черты.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) определяет радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) определяет функцию аргумента. Содержит свойства: [Name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - имя функции и [Base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) определяет N-арный математический объект, такой как сумма и интеграл. Он состоит из оператора, базового (или операнда) и необязательных верхних и нижних пределов. Примеры N-арных операторов: сумма, объединение, пересечение, интеграл.

Этот класс не включает простые операторы, такие как сложение, вычитание и т.д. Они представлены одним текстовым элементом - [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) создает верхний или нижний предел. Он определяет объект предела, состоящий из текста на базовой линии и уменьшенного текста сразу над ним или под ним. Этот элемент не включает слово “lim", но позволяет разместить текст в верхней или нижней части выражения. Так, выражение

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся с использованием комбинации [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) и [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) элементов следующим образом:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
    mathFunc = math.MathFunction(funcName, math.MathematicalText("𝑥"))
```

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement классы**
- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Следующие классы определяют нижний индекс или верхний индекс. Вы можете установить подстрочный и надстрочный индексы одновременно слева или справа от аргумента, но одиночный подстрочный или надстрочный индекс поддерживается только с правой стороны. Класс [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) также может использоваться для установки математической степени числа.

Пример:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) определяет объект матрицы, состоящий из дочерних элементов, расположенных в одном или нескольких рядах и столбцах. Важно отметить, что матрицы не имеют встроенных разделителей. Чтобы разместить матрицу в скобках, необходимо использовать объект-разделитель - [**IMathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/). Пустые аргументы могут быть использованы для создания пробелов в матрицах.

Пример:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) определяет вертикальный массив уравнений или любых математических объектов.

Пример:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/): рисует прямоугольную или другую границу вокруг [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) определяет логическую упаковку (упаковку) математического элемента. Например, упакованный объект может служить эмулятором оператора с или без точки выравнивания, служить точкой разрыва строки или быть сгруппирован таким образом, чтобы не допускать разрывов строк внутри. Например, оператор "==" должен быть упакован, чтобы предотвратить разрывы строк.
- Класс [**MathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) определяет объект-разделитель, состоящий из открывающих и закрывающих символов (таких как скобки, фигурные скобки, квадратные скобки и вертикальные черты) и одного или нескольких математических элементов внутри, разделённых заданным символом. Примеры: (𝑥2); [𝑥2|𝑦2].

  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) определяет акцентирующую функцию, состоящую из базы и комбинирующего диакритического знака. 

  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) определяет бар-функцию, состоящую из базового аргумента и надстрочной или подстрочной черты.
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) определяет символ группировки над или под выражением, обычно для выделения взаимосвязей между элементами.
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Это позволяет использовать операции на существующей структуре и формировать более сложные математические выражения. Все операции имеют два набора параметров: либо [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), либо строку в качестве аргументов. Экземпляры класса [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) создаются неявно из указанных строк, когда используются строковые аргументы. Математические операции, доступные в Aspose.Slides, перечислены ниже.
### **Метод Join**
- [Join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Соединяет математический элемент и формирует математический блок. Например:

```py
    element1 = math.MathematicalText("x")
    element2 = math.MathematicalText("y")
    block = element1.join(element2)
```
### **Метод Divide**
- [Divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Создает дробь указанного типа с этим числителем и заданным знаменателем. Например:

```py
    numerator = math.MathematicalText("x")
    fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```
### **Метод Enclose**
- [Enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Включает элемент в указанные символы, такие как скобки или другой символ как обрамление.

```py
# Включает математический элемент в скобки
MathDelimiter enclose()

# Включает этот элемент в указанные символы, такие как скобки или другие символы как обрамление
MathDelimiter enclose(char beginningCharacter, char endingCharacter)
```

Например:

```py
    delimiter = math.MathematicalText("x").enclose('[', ']')
    delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```
### **Метод Function**
- [Function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Берёт функцию аргумента, используя текущий объект в качестве имени функции.

Например:

```py
func = math.MathematicalText("sin").function("x")
```
### **Метод AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Берёт заданную функцию, используя текущий экземпляр в качестве аргумента. Вы можете:

- указать строку в качестве имени функции, например “cos”.
- выбрать одно из предопределенных значений перечислений [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/), например **MathFunctionsOfOneArgument.ArcSin.**
- выбрать экземпляр [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Например:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
    func1 = math.MathematicalText("2x").as_argument_of_function(funcName)
    func2 = math.MathematicalText("x").as_argument_of_function("sin")
    func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
    func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```
### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Устанавливает подстрочный и надстрочный индекс. Вы можете установить подстрочный и надстрочный индекс одновременно слева или справа от аргумента, но одиночный подстрочный или надстрочный индекс поддерживается только с правой стороны. Указатель **Superscript** также может использоваться для установки математической степени числа.

Пример:

```py
    script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```
### **Метод Radical**
- [Radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Определяет математический корень заданной степени из указанного аргумента.

Пример:

```py
    radical = math.MathematicalText("x").radical("3")
```
### **Методы SetUpperLimit и SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Устанавливает верхний или нижний предел. Здесь верхний и нижний пределы просто указывают на расположение аргумента относительно основания.

Рассмотрим выражение:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения могут быть созданы с помощью комбинации классов [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) и [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/), а также операций [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) следующим образом:

```py
mathExpression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```
### **Методы Nary и Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Оба метода **Nary** и **Integral** создают и возвращают N-арный оператор, представленный типом [**INaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathnaryoperator/). В методе Nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) указывает тип оператора: сумма, объединение и т.д., не включая интегралы. В методе Integral есть специализированная операция Integral с перечислением типов интегралов [**MathIntegralTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/).

Пример:

```py
    baseArg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
    integral = baseArg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **Метод ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) помещает элементы в вертикальный массив. Если эта операция вызывается для экземпляра **MathBlock**, все дочерние элементы будут помещены в возвращаемый массив.

Пример:

```py
    arrayFunction = math.MathematicalText("x").join("y").to_math_array()
```
### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**Accent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) устанавливает акцентный знак (символ на верхней части элемента).
- Методы [**Overbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) и [**Underbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) устанавливают полосу сверху или снизу.
- Метод [**Group**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) помещает в группу с использованием символа группировки, такого как нижняя фигурная скобка или другой.
- Метод [**ToBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) помещает в рамку.
- Метод [**ToBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) помещает в невизуальную коробку (логическую группировку).

Примеры:

```py
    accent = math.MathematicalText("x").accent(chr(0x0303))
    bar = math.MathematicalText("x").overbar()
    groupChr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
            math.MathTopBotPositions.BOTTOM, 
            math.MathTopBotPositions.TOP)
    borderBox = math.MathematicalText("x+y+z").to_border_box()
    boxedOperator = math.MathematicalText(":=").to_box()
```