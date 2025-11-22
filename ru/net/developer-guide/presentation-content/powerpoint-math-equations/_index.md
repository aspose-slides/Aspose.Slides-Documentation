---
title: Добавление математических уравнений в презентации PowerPoint на C#
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как работать с математическими уравнениями в PowerPoint, используя Aspose.Slides для .NET. Получите подробные инструкции, примеры кода и советы по автоматизации создания и редактирования презентаций."
---

## **Обзор**

В PowerPoint вы можете написать математическое уравнение или формулу и отобразить её в своей презентации. Доступно множество математических символов, которые можно добавлять в текст или уравнения. Конструктор математических уравнений используется для создания сложных формул, таких как:

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

PowerPoint поддерживает широкий набор математических символов для создания уравнений. Однако генерация сложных математических уравнений в PowerPoint часто не даёт отшлифованный, профессиональный результат. Поэтому пользователи, часто создающие математические презентации, часто обращаются к сторонним решениям для более эстетичных математических формул.

Используя [**Aspose.Slides API**](https://products.aspose.com/slides/net/), вы можете программно работать с математическими уравнениями в презентациях PowerPoint на C#. Создавать новые математические выражения или редактировать ранее созданные. Частичная поддержка доступна для экспорта математических структур в виде изображений.

## **Как создать математическое уравнение**

Математические элементы используются для построения любой математической конструкции, независимо от уровня вложенности. Линейная коллекция этих элементов образует математический блок, представленный классом [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). Класс [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) представляет отдельное математическое выражение, формулу или уравнение. Класс [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) используется для хранения математического текста (отличающегося от обычного класса [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion)), тогда как [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) позволяет манипулировать набором объектов [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). Эти классы необходимы для работы с математическими уравнениями PowerPoint через Aspose.Slides API.

Давайте посмотрим, как можно создать следующее математическое уравнение, используя Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте форму, которая будет содержать математический текст:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


После создания формы она по умолчанию уже содержит один абзац с математической частью. Класс [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) представляет часть, содержащую математический текст. Чтобы получить доступ к математическому содержимому внутри [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion), обратитесь к переменной [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


Класс [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), которые состоят из комбинации математических элементов. Например, создать дробь и разместить её в презентации:
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


Каждый математический элемент представлен классом, реализующим интерфейс [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement). Этот интерфейс предоставляет множество методов для простого создания математических выражений, позволяя построить довольно сложные уравнения всего одной строкой кода. Например, теорема Пифагора будет выглядеть так:
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


Операции интерфейса [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) реализованы в каждом типе элемента, включая класс [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

Ниже приведён полный пример исходного кода:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
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

    presentation.Save("math.pptx", SaveFormat.Pptx);
}
```


## **Типы математических элементов**

Математические выражения состоят из последовательностей математических элементов. Математический блок представляет такую последовательность, а аргументы этих элементов образуют вложенную древовидную структуру.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть агрегирован внутри другого, образуя древовидную структуру. Самый простой тип элемента — тот, который не содержит других элементов математического текста.

Каждый тип математического элемента реализует интерфейс [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement), что позволяет использовать общий набор математических операций для разных типов элементов.

### **Класс MathematicalText**

Класс [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) представляет математический текст — базовый элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные или любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐

### **Класс MathFraction**

Класс [MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) определяет объект дроби, состоящий из числителя и знаменателя, разделённых чертой дроби. Черта дроби может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления функции stack, которая размещает один элемент над другим без черты дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Класс MathRadical**

Класс [MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) определяет радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Класс MathFunction**

Класс [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) определяет функцию аргумента. Он содержит свойства, такие как [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name), представляющее имя функции, и [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base), представляющее аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Класс MathNaryOperator**

Класс [MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) определяет N-арный математический объект, такой как суммирование или интеграл. Он состоит из оператора, основания (или операнда) и необязательных верхних и нижних пределов. Примерами N-арных операторов являются Summation, Union, Intersection и Integral. for a couple of seconds

Класс MathNaryOperator определяет N-арный математический объект, такой как Summation и Integral. Он состоит из оператора, основания (или операнда) и необязательных верхних и нижних пределов. Примерами N-арных операторов являются Summation, Union, Intersection и Integral.

Этот класс не включает простые операторы, такие как сложение, вычитание и т.д. Они представлены одиночным текстом [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Класс MathLimit**

Класс [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) создаёт верхний или нижний предел. Он определяет объект предела, состоящий из текста на базовой линии и уменьшенного текста сразу выше или ниже её. Этот элемент не включает слово “lim”, но позволяет разместить текст в верхней или нижней части выражения. Таким образом, выражение 

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией элементов [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) и [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) следующим образом:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Эти классы определяют нижний индекс или верхний индекс. Вы можете одновременно задавать субскрипт и суперкрипт слева или справа от аргумента, но одиночный субскрипт или суперкрипт поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) также можно использовать для задания степени числа.

Пример:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Класс MathMatrix**

Класс [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) определяет объект матрицы, состоящий из дочерних элементов, расположенных в одной или нескольких строках и столбцах. Важно отметить, что у матриц нет встроенных разделителей. Чтобы заключить матрицу в скобки, используйте объект‑разделитель [IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Нулевые аргументы могут использоваться для создания пробелов в матрицах.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Класс MathArray**

Класс [MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) определяет вертикальный массив уравнений или любых математических объектов.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Форматирование математических элементов**

- Класс [MathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox): рисует прямоугольную или альтернативную границу вокруг [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

Пример: 

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [MathBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox): определяет логическое обрамление (упаковку) математического элемента. Объект в коробке может выступать как эмулятор оператора — с точкой выравнивания или без неё — функционировать как разрыв строки или быть сгруппированным, чтобы предотвратить разрывы внутри. Например, оператор “==” следует разместить в коробке, чтобы избежать разрывов строки.

- Класс [MathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter): определяет объект‑разделитель, состоящий из открывающих и закрывающих символов (например, скобок, фигурных скобок, квадратных скобок или вертикальных черт) и одного или более математических элементов внутри, разделённых указанным символом. Примеры: (𝑥²); [𝑥²|𝑦²].

Пример: 

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [MathAccent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent): определяет акцентную функцию, состоящую из основания и комбинирующего диакритического знака.

Пример: 𝑎́.

- Класс [MathBar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar): определяет функцию черты, состоящую из базового аргумента и надчеркивающей или подчёркивающей линии.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [MathGroupingCharacter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter): определяет символ группировки, размещаемый над или под выражением, обычно для подчёркивания взаимосвязей между элементами.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Математические операции**

Каждый математический элемент и каждое математическое выражение (через [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) реализует интерфейс [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). Это позволяет выполнять операции над существующей структурой и формировать более сложные математические выражения. Все операции имеют два набора параметров: либо [IMathElement], либо строковые аргументы. При использовании строковых аргументов экземпляры класса [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) создаются неявно из указанных строк. Ниже перечислены доступные в Aspose.Slides математические операции.

### **Метод Join**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Эти методы объединяют математический элемент и формируют математический блок. Например:
```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **Метод Divide**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Эти методы создают дробь указанного типа с числителем и указанным знаменателем. Например:
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **Метод Enclose**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Эти методы заключают элемент в указанные символы, такие как скобки или другие ограничительные знаки. Например:
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **Метод Function**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Эти методы принимают функцию аргумента, используя текущий объект в качестве имени функции. Например:
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **Метод AsArgumentOfFunction**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

Эти методы принимают указанную функцию, используя текущий объект в качестве аргумента. Вы можете:

- задать строку как имя функции, например “cos”;
- выбрать одно из предопределённых значений перечислений [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) или [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments), например `MathFunctionsOfOneArgument.ArcSin`;
- указать экземпляр [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

Например:
```cs
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

Эти методы задают субскрипт и суперкрипт. Вы можете одновременно задавать оба на левую или правую сторону аргумента; однако одиночный субскрипт или суперкрипт поддерживается только справа. **Superscript** также может использоваться для задания степени числа.

Пример:
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **Метод Radical**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Эти методы задают математический корень указанной степени на основе заданного аргумента.

Пример:
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **Методы SetUpperLimit и SetLowerLimit**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Эти методы задают верхний или нижний предел, где “upper” и “lower” указывают позицию аргумента относительно основания.

Рассмотрим выражение: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Подобные выражения могут быть созданы комбинацией классов [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) и [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit), а также операциями интерфейса [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement), следующим образом:
```cs
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

Оба метода **Nary** и **Integral** создают и возвращают N-арный оператор, представляемый типом [INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator). В методе Nary перечисление [MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) задаёт тип оператора — например, суммирование или объединение, исключая интегралы. В методе Integral используется специализированная операция для интегралов, определяемая перечислением [MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes).

Пример:
```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **Метод ToMathArray**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) помещает элементы в вертикальный массив. Если вызвать эту операцию у экземпляра [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock), все его дочерние элементы будут размещены в возвращённом массиве.

Пример:
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- Метод [Accent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) задаёт акцентный знак (символ над элементом).
- Методы [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) и [Underbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) задают черту сверху или снизу.
- Метод [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) группирует с помощью символа группировки, например, нижней фигурной скобки.
- Метод [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) помещает элемент в рамочную коробку.
- Метод [ToBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) помещает элемент в нелимитирующую (логическую) коробку.

Примеры:
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **FAQ**

**Как добавить математическое уравнение на слайд PowerPoint?**

Чтобы добавить уравнение, необходимо создать объект `MathShape`, который автоматически содержит математическую часть. Затем получить `MathParagraph` из `MathPortion` и добавить в него объекты `MathBlock`.

**Можно ли создать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные математические выражения, вкладывая MathBlocks. Каждый математический элемент реализует интерфейс `IMathElement`, что позволяет применять операции (Join, Divide, Enclose и др.) для комбинирования элементов в более сложные структуры.

**Как обновить или изменить существующее математическое уравнение?**

Чтобы обновить уравнение, нужно получить доступ к существующим MathBlocks через `MathParagraph`. Затем с помощью методов Join, Divide, Enclose и других можно изменить отдельные элементы уравнения. После редактирования сохраните презентацию, чтобы применить изменения.