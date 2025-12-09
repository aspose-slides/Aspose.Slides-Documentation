---
title: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/nodejs-java/powerpoint-math-equations/
keywords: " PowerPoint Math Equations, PowerPoint Math Symbols, PowerPoint Formula, PowerPoint Math Text"
description: "PowerPoint Math Equations, PowerPoint Math Symbols, PowerPoint Formula, PowerPoint Math Text"
---

## **Обзор**
В PowerPoint можно писать математическое уравнение или формулу и отображать их в презентации. Для этого в PowerPoint представлены различные математические символы, которые можно добавить в текст или уравнение. Для создания сложных формул используется конструктор математических уравнений в PowerPoint, который помогает создавать такие конструкции, как:

- Математическая дробь
- Математический радикал
- Математическая функция
- Пределы и логарифмические функции
- N-арные операции
- Матрица
- Большие операторы
- Функции sin, cos

Для добавления математического уравнения в PowerPoint используется меню *Insert → Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в XML, который PowerPoint отобразит следующим образом:  

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания уравнений. Однако создание сложных уравнений в PowerPoint часто не даёт хорошего, профессионального результата. Пользователи, которым часто требуется создавать математические презентации, прибегают к сторонним решениям для получения красиво выглядящих формул.

С помощью [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/), вы можете программно работать с математическими уравнениями в презентациях PowerPoint на C#. Создавать новые математические выражения или редактировать уже созданные. Экспорт математических структур в изображения также поддерживается частично.


## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций любой глубины вложения. Линейная коллекция математических элементов образует математический блок, представляемый классом [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock). Класс [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) по сути является отдельным математическим выражением, формулой или уравнением. [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) — это математическая часть, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) позволяет работать с набором блоков MathBlock. Указанные выше классы являются ключом к работе с математическими уравнениями PowerPoint через Aspose.Slides API.

Посмотрим, как можно создать следующее математическое уравнение через Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте форму, которая будет содержать математический текст:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

После создания форма уже содержит один абзац с математической частью по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) — это часть, содержащая математический текст внутри. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion), обратитесь к переменной [**MathParagraph** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph):

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

Класс [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) позволяет читать, добавлять, изменять и удалять блоки MathBlock ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)), которые состоят из комбинации математических элементов. Например, создадим дробь и разместим её в презентации:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

Каждый математический элемент представлен классом, реализующим [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement). Этот класс предоставляет множество методов для простого создания математических выражений. Можно создать достаточно сложное выражение одной строкой кода. Например, теорема Пифагора будет выглядеть так:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

Операции класса [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) реализованы во всех типах элементов, включая [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

Полный пример кода:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
    var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    var fraction = new aspose.slides.MathematicalText("x").divide("y");
    mathParagraph.add(new aspose.slides.MathBlock(fraction));
    var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);
    pres.save("math.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

## **Типы математических элементов**
Математические выражения образуют последовательности математических элементов. Последовательность элементов представлена математическим блоком, а аргументы элементов образуют древовидную структуру вложения.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть включён (агрегирован) в другой элемент. То есть элементы фактически являются контейнерами для других, образуя древовидную структуру. Самый простой тип элемента не содержит других элементов математического текста.

Каждый тип математического элемента реализует класс [**MathElement** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement), позволяющий использовать общий набор математических операций над различными типами элементов.
### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) представляет математический текст — базовый элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐
### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) описывает объект дроби, состоящий из числителя и знаменателя, разделённых чертой дроби. Черта может быть горизонтальной или диагональной в зависимости от свойств дроби. Объект дроби также используется для представления функции стека, которая размещает один элемент над другим без черты дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) описывает радикальную функцию (математический корень), состоящую из основания и, при необходимости, степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) описывает функцию аргумента. Содержит свойства: [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) — имя функции и [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) — аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) описывает N-арный математический объект, такой как суммирование или интеграл. Он состоит из оператора, основания (или операнда) и, при необходимости, верхних и нижних пределов. Примеры N-арных операторов: Summation, Union, Intersection, Integral.

Этот класс не включает простые операторы, такие как сложение, вычитание и т.д.; они представлены отдельным элементом [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) создаёт верхний или нижний предел. Он описывает объект предела, состоящий из текста на базовой линии и уменьшенного текста непосредственно над или под ним. Этот элемент не включает слово “lim”, но позволяет разместить текст сверху или снизу выражения. Таким образом, выражение  

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) и [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) следующим образом:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 
### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

Эти классы задают нижний или верхний индекс. Можно одновременно установить подстрочный и надстрочный индексы слева или справа от аргумента, но одиночный подстрочный или надстрочный индекс поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) может также использоваться для задания степени числа.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) описывает объект Matrix, состоящий из дочерних элементов, расположенных в одну или несколько строк и столбцов. Важно отметить, что у матриц нет встроенных ограничителей. Чтобы разместить матрицу в скобках, используйте объект‑ограничитель [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). Для создания пустот в матрицах можно передавать null‑аргументы.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) описывает вертикальный массив уравнений или любых математических объектов.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox): рисует прямоугольную или другую рамку вокруг [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox): задаёт логическое обёртывание (упаковку) математического элемента. Например, объект в коробке может служить эмулятором оператора с или без точки выравнивания, служить разрывом строки или группироваться так, чтобы не допускать переноса внутри. Например, оператор “==” следует поместить в коробку, чтобы предотвратить перенос строки.

- Класс [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter): задаёт объект‑ограничитель, состоящий из открывающих и закрывающих символов (скобки, фигурные скобки, квадратные скобки, вертикальные черты) и одного или нескольких математических элементов внутри, разделённых заданным символом. Примеры: (𝑥²); [𝑥²|𝑦²].  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent): задаёт акцентную функцию, состоящую из основания и комбинируемого диакритического знака.  
  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar): задаёт функцию черты, состоящую из базового аргумента и над- или подчеркивающей линии.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter): задаёт группирующий символ над или под выражением, обычно для выделения взаимосвязей между элементами.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) реализует класс [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement). Он позволяет выполнять операции над существующей структурой и формировать более сложные выражения. Все операции принимают два набора параметров: либо [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement), либо строку. При использовании строковых аргументов из указанных строк неявно создаются объекты [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText). Ниже перечислены доступные в Aspose.Slides математические операции.
### **Метод Join**
- [join(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-aspose.slides.IMathElement-)

Объединяет математический элемент и формирует математический блок. Пример:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 
### **Метод Divide**
- [divide(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-int-)

Создаёт дробь указанного типа с данным числителем и знаменателем. Пример:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 
### **Метод Enclose**
- [enclose()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose-char-char-)

Оборачивает элемент в указанные символы, такие как скобки или другие символы‑рамки.

```java
/**
 * <p>
 * Enclose a math element in parenthesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Encloses this element in specified characters such as parenthesis or another characters as framing
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 


Пример:

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 
### **Метод Function**
- [function(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-aspose.slides.IMathElement-)

Создаёт функцию от аргумента, используя текущий объект как имя функции.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 


Пример:

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 
### **Метод AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-java.lang.String-)

Принимает указанную функцию, используя текущий объект как аргумент. Можно:

- указать строку как имя функции, например “cos”;
- выбрать одно из предопределённых значений перечислений [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments), например [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin);
- передать экземпляр [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).

Пример:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 
### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-aspose.slides.IMathElement-aspose.slides.IMathElement-)

Устанавливает нижний и верхний индексы. Можно задавать подстрочный и надстрочный индексы одновременно слева или справа от аргумента, но одиночный подстрочный или надстрочный индекс поддерживается только справа. **Superscript** также может использоваться для задания степени числа.

Пример:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 
### **Метод Radical**
- [radical(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-aspose.slides.IMathElement-)

Задаёт математический корень указанной степени от заданного аргумента.

Пример:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 
### **Методы SetUpperLimit и SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-aspose.slides.IMathElement-)

Задаёт верхний или нижний предел. Здесь верхний и нижний просто указывают позицию аргумента относительно основания.

Рассмотрим выражение:  

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения можно создать комбинацией классов [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) и [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) и операциями [MathElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) следующим образом:

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 
### **Методы Nary и Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-int-)

Методы **nary** и **integral** создают и возвращают N‑арный оператор, представленный типом [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator). В методе nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) указывает тип оператора: суммирование, объединение и т.д., без интегралов. В методе integral используется специализированная операция Integral с перечислением типов интегралов [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes).

Пример:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 
### **Метод ToMathArray**
Метод [**toMathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toMathArray--) размещает элементы в вертикальном массиве. Если вызвать эту операцию у экземпляра [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock), все дочерние элементы будут помещены в возвращаемый массив.

Пример:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 
### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**accent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#accent-char-) устанавливает акцентный знак (символ над элементом).
- Методы [**overbar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#overbar--) и [**underbar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#underbar--) устанавливают линию над или под элементом.
- Метод [**group**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#group--) размещает элемент в группу, используя символ группировки, например нижнюю фигурную скобку или иной.
- Метод [**toBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toBorderBox--) размещает элемент в рамочную коробку.
- Метод [**toBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toBox--) размещает элемент в нелинейную (логическую) коробку.

Примеры:

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **FAQ**

**Как добавить математическое уравнение в слайд PowerPoint?**

Чтобы добавить уравнение, необходимо создать объект `MathShape`, который автоматически содержит математическую часть. Затем получить `MathParagraph` из `MathPortion` и добавить в него объекты `MathBlock`.

**Можно ли создавать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные выражения, вложивая MathBlock‑ы. Каждый математический элемент реализует класс `IMathElement`, который позволяет применять операции (Join, Divide, Enclose и др.) для комбинирования элементов в более сложные структуры.

**Как обновить или изменить существующее математическое уравнение?**

Чтобы изменить уравнение, нужно получить существующие MathBlock‑ы через `MathParagraph`. Затем с помощью методов Join, Divide, Enclose и других изменить отдельные элементы уравнения. После редактирования сохраните презентацию, чтобы изменения вступили в силу.