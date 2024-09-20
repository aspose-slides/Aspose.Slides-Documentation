---
title: Уравнения математики в PowerPoint
type: docs
weight: 80
url: /net/powerpoint-math-equations/
keywords: " Уравнения математики в PowerPoint, Символы математики в PowerPoint, Формулы в PowerPoint, Математический текст в PowerPoint, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Уравнения математики в PowerPoint, символы, формулы и математический текст на C# или .NET"
---

## **Обзор**
В PowerPoint возможно написать математическое уравнение или формулу и отобразить его в презентации. Для этого в PowerPoint представлены различные математические символы, которые можно добавить в текст или уравнение. Для этого используется конструктор математических уравнений, который помогает создавать сложные формулы, такие как:

- Математическая дробь
- Математический радикал
- Математическая функция
- Пределы и логарифмические функции
- N-арные операции
- Матрица
- Крупные операторы
- Функции синуса и косинуса

Чтобы добавить математическое уравнение в PowerPoint, используется меню *Вставка -> Уравнение*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в формате XML, который может быть отображен в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания математических уравнений. Однако создание сложных математических уравнений в PowerPoint часто не дает хорошего и профессионального результата. Пользователи, которым часто необходимо создавать математические презентации, прибегают к использованию сторонних решений для создания привлекательных математических формул.

С помощью [**Aspose.Slide API**](https://products.aspose.com/slides/net/) вы можете программно работать с математическими уравнениями в презентациях PowerPoint на C#. Создавайте новые математические выражения или редактируйте ранее созданные. Экспорт математических структур в изображения также частично поддерживается.

## **Как создать математическое уравнение**
Математические элементы используются для создания любых математических конструкций с любым уровнем вложенности. Линейная коллекция математических элементов формирует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). Класс [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) по сути является отдельным математическим выражением, формулой или уравнением. [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) — это математическая часть, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/net/aspose.slides/portion)). [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) позволяет манипулировать набором математических блоков. Указанные классы являются ключевыми для работы с математическими уравнениями PowerPoint через Aspose.Slides API.

Давайте посмотрим, как мы можем создать следующее математическое уравнение через Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте фигуру, которая будет содержать математический текст:

``` csharp

 using (Presentation pres = new Presentation())

{

    var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

}

```

После создания фигура уже будет содержать один абзац с математической частью по умолчанию. Для доступа к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):

``` csharp

 var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

```

Класс [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), которые состоят из комбинации математических элементов. Например, создадим дробь и поместим ее в презентацию:

``` csharp

 var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));

```

Каждый математический элемент представлен некоторым классом, который реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). Этот интерфейс предоставляет много методов для легкого создания математических выражений. Вы можете создать довольно сложное математическое выражение с помощью одной строки кода. Например, теорема Пифагора будет выглядеть так:

``` csharp

 var mathBlock = new MathematicalText("c")

    .SetSuperscript("2")

    .Join("=")

    .Join(new MathematicalText("a").SetSuperscript("2"))

    .Join("+")

    .Join(new MathematicalText("b").SetSuperscript("2"));

```

Операции интерфейса [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) реализованы в любом типе элемента, включая [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

Полный пример исходного кода:

``` csharp

 using (Presentation pres = new Presentation())

{

    IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

   var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;



   var fraction = new MathematicalText("x").Divide("y");

    mathParagraph.Add(new MathBlock(fraction));



   var mathBlock = new MathematicalText("c")

        .SetSuperscript("2")

        .Join("=")

        .Join(new MathematicalText("a").SetSuperscript("2"))

        .Join("+")

        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);

    pres.Save("math.pptx", SaveFormat.Pptx);

}

```

## **Типы математических элементов**
Математические выражения формируются из последовательностей математических элементов. Последовательность математических элементов представлена математическим блоком, а аргументы математических элементов формируют древовидную структуру.

Существует множество типов математических элементов, которые могут использоваться для построения математического блока. Каждый из этих элементов может быть включен (агрегирован) в другой элемент. То есть элементы по сути являются контейнерами для других, формируя древовидную структуру. Самый простой тип элемента не содержит других элементов математического текста.

Каждый тип математического элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement), позволяя использовать общий набор математических операций на различных типах математических элементов.

### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) представляет математический текст — основной элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐
### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) определяет объект дроби, состоящий из числителя и знаменателя, разделенных дробной чертой. Дробная черта может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления функции стека, которая помещает один элемент над другим без дробной черты.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) определяет радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) определяет функцию аргумента. Содержит свойства: [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) - имя функции и [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) - аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) определяет N-арный математический объект, такой как сумма и интеграл. Он состоит из оператора, основания (или операнда) и необязательных верхних и нижних пределов. Примеры N-арных операторов: сумма, объединение, пересечение, интеграл.

Этот класс не включает простые операторы, такие как сложение, вычитание и так далее. Они представлены одним текстовым элементом - [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) создает верхний или нижний предел. Он определяет объект предела, состоящий из текста на основной линии и текста уменьшенного размера, расположенного непосредственно над или под ним. Этот элемент не включает слово "lim", но позволяет разместить текст в верхней или нижней части выражения. Таким образом, выражение

![todo:image_alt_text](powerpoint-math-equations_8.png)

создается с помощью комбинации элементов [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) и [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) следующим образом:

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));

```

### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Следующие классы определяют нижний индекс или верхний индекс. Вы можете установить нижний индекс и верхний индекс одновременно слева или справа от аргумента, но одиночный нижний индекс или верхний индекс поддерживается только с правой стороны. Класс [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) также можно использовать для установки математической степени числа.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) определяет объект матрицы, состоящий из дочерних элементов, размещенных в одном или нескольких рядах и столбцах. Важно отметить, что матрицы не имеют встроенных разделителей. Чтобы поместить матрицу в скобки, следует использовать объект-разделитель - [**IMathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Нулевые аргументы могут быть использованы для создания пробелов в матрицах.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) определяет вертикальный массив уравнений или любых математических объектов.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox): рисует прямоугольную или другую рамку вокруг [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox): определяет логическую рамку (упаковку) математического элемента. Например, рамочный объект может служить эмулятором оператора с или без точки выравнивания, служить разрывом строки или быть сгруппированным таким образом, чтобы не допускать разрывов строк внутри. Например, оператор "==" должен быть обрамлен, чтобы предотвратить разрывы строк.
- Класс [**MathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter): определяет объект-разделитель, состоящий из открывающих и закрывающих символов (таких как скобки, фигурные скобки, квадратные скобки и вертикальные черты), и одного или более математических элементов внутри, разделенных указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].

  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent): определяет акцентирующую функцию, состоящую из основания и объединяющего диакритического знака. 

  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar): определяет функцию полосы, состоящую из базового аргумента и надстрочных или подстрочных черт.

  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter): определяет символ группировки над или под выражением, обычно для выделения взаимосвязей между элементами.

  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). Он позволяет выполнять операции над существующей структурой и формировать более сложные математические выражения. Все операции имеют два набора параметров: либо [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement), либо строку в качестве аргументов. Экземпляры класса [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) неявно создаются из указанных строк, когда используются строковые аргументы. Доступные математические операции в Aspose.Slides перечислены ниже.

### **Метод Join**
- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Соединяет математический элемент и формирует математический блок. Например:

``` csharp

 IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);

```
### **Метод Divide**
- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Создает дробь указанного типа с этим числителем и указанным знаменателем. Например:

``` csharp

 IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);

```
### **Метод Enclose**
- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Заключает элемент в указанные символы, такие как скобки или другой символ как окантовка.

``` csharp

 /// <summary>

/// Заключает математический элемент в скобки

/// </summary>

IMathDelimiter Enclose();

/// <summary>

/// Заключает этот элемент в указанные символы, такие как скобки или другие символы как окантовка

/// </summary>

IMathDelimiter Enclose(char beginningCharacter, char endingCharacter);

```

Например:

``` csharp

 IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();

```
### **Метод Function**
- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Принимает функцию аргумента, используя текущий объект в качестве имени функции.

``` csharp

 /// <summary>

/// Принимает функцию аргумента, используя этот экземпляр в качестве имени функции

/// </summary>

/// <param name="functionArgument">Аргумент функции</param>

IMathFunction Function(IMathElement functionArgument);

IMathFunction Function(string functionArgument);

```

Например:

``` csharp

 IMathFunction func = new MathematicalText("sin").Function("x");

```
### **Метод AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

Принимает указанную функцию, используя текущий экземпляр в качестве аргумента. Вы можете:

- указать строку в качестве имени функции, например "cos".
- выбрать одно из предопределенных значений перечислений [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments), например **MathFunctionsOfOneArgument.ArcSin.**
- выбрать экземпляр [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

Например:

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);

var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");

var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")

```
### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

Устанавливает нижний индекс и верхний индекс. Вы можете установить нижний индекс и верхний индекс одновременно слева или справа от аргумента, но одиночный нижний индекс или верхний индекс поддерживается только с правой стороны. **Верхний индекс** также может использоваться для установки математической степени числа.

Пример:

``` csharp

 var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");

```
### **Метод Radical**
- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Определяет математический корень заданной степени от указанного аргумента.

Пример:

``` csharp

 var radical = new MathematicalText("x").Radical("3");

```
### **Методы SetUpperLimit и SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Принимает верхний или нижний предел. Здесь верхний и нижний просто указывают на расположение аргумента относительно основания.

Рассмотрим выражение: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения могут быть созданы через комбинацию классов [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) и [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit), и операции [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) следующим образом:

``` csharp

 var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");

```
### **Методы Nary и Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

Методы **Nary** и **Integral** создают и возвращают N-арный оператор, представленный типом [**INaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). В методе Nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) указывает тип оператора: сумма, объединение и т. д., не включая интегралы. В методе Integral есть специализированная операция интеграл с перечислением типов интегралов [**MathIntegralTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes). 

Пример:

``` csharp

 IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());

IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");

```
### **Метод ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) помещает элементы в вертикальный массив. Если эта операция вызывается для экземпляра **MathBlock**, все дочерние элементы будут помещены в возвращаемый массив.

Пример:

``` csharp

 var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();

```
### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**Accent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) устанавливает акцентный знак (символ на вершине элемента).
- Методы [**Overbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) и [**Underbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) устанавливают полосу сверху или снизу.
- Метод [**Group**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) группирует с помощью символа группировки, такого как нижняя фигурная скобка или другой.
- Метод [**ToBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) помещает в рамку.
- Метод [**ToBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) помещает в невизуальную рамку (логическая группа).

Примеры:

``` csharp

 var accent = new MathematicalText("x").Accent('\u0303');

var bar = new MathematicalText("x").Overbar();

var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

var borderBox = new MathematicalText("x+y+z").ToBorderBox();

var boxedOperator = new MathematicalText(":=").ToBox();

```