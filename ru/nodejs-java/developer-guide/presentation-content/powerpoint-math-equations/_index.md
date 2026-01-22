---
title: Добавление математических уравнений в презентации PowerPoint на JavaScript
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides для Node.js, поддержка OMML, элементов управления форматированием и понятных примеров кода."
---

## **Обзор**
В PowerPoint можно написать математическое уравнение или формулу и отобразить её в презентации. Для этого в PowerPoint представлены различные математические символы, которые можно добавить в текст или уравнение. Для этого используется конструктор математических уравнений в PowerPoint, который помогает создавать сложные формулы, такие как:

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

Это создаст математический текст в XML, который может быть отображён в PowerPoint следующим образом: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания уравнений. Однако создание сложных математических уравнений в PowerPoint часто не даёт хорошего и профессионального результата. Пользователи, которым часто нужно создавать математические презентации, прибегают к использованию сторонних решений для создания красивых математических формул.

С помощью [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/), вы можете работать с математическими уравнениями в презентациях PowerPoint программно на C#. Создавайте новые математические выражения или редактируйте уже созданные. Экспорт математических структур в изображения также поддерживается частично.

## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций любого уровня вложения. Последовательность математических элементов образует математический блок, представляемый классом [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock). Класс [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) по сути представляет отдельное математическое выражение, формулу или уравнение. [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) – это математическая часть, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) позволяет управлять набором математических блоков. Вышеупомянутые классы являются ключевыми для работы с математическими уравнениями PowerPoint через API Aspose.Slides.

Посмотрим, как можно создать следующее математическое уравнение через API Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте фигуру, которая будет содержать математический текст:

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

После создания фигура уже будет содержать один абзац с математической частью по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) представляет часть, содержащую внутри себя математический текст. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph):

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

Класс [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)), состоящие из комбинации математических элементов. Например, создадим дробь и разместим её в презентации:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

Каждый математический элемент представлен классом, реализующим класс **MathElement**. Этот класс предоставляет множество методов для упрощённого создания математических выражений. Вы можете создать довольно сложное выражение одной строкой кода. Например, теорема Пифагора будет выглядеть так:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

Операции класса **MathElement** реализованы во всех типах элементов, включая [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

Полный пример исходного кода:

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
Математические выражения формируются из последовательностей математических элементов. Последовательность элементов представлена математическим блоком, а аргументы элементов образуют древовидную вложенность.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть включён (агрегирован) в другой элемент. То есть элементы являются контейнерами для других, образуя древовидную структуру. Самый простой тип элемента не содержит других элементов математического текста.

Каждый тип математического элемента реализует класс **MathElement**, позволяя использовать общий набор математических операций для разных типов элементов.

### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) представляет математический текст — базовый элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐

### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) задаёт объект дроби, состоящий из числителя и знаменателя, разделённых чертой дроби. Черта может быть горизонтальной или диагональной в зависимости от свойств дроби. Объект дроби также используется для представления функции stack, которая размещает один элемент над другим без черты дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) задаёт радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) задаёт функцию от аргумента. Содержит свойства: [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) — имя функции и [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) — аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) задаёт N-арный математический объект, такой как суммирование и интеграл. Он состоит из оператора, основания (или операнда) и опциональных верхних и нижних пределов. Примеры N-арных операторов: Summation, Union, Intersection, Integral.

Этот класс не включает простые операторы, такие как сложение, вычитание и т.п. Они представлены одиночным текстовым элементом — [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) создаёт верхний или нижний предел. Он задаёт объект предела, состоящий из текста на базовой линии и уменьшенного текста непосредственно выше или ниже её. Этот элемент не включает слово “lim”, но позволяет разместить текст вверху или внизу выражения. Таким образом, выражение  

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией элементов [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) и [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) следующим образом:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

Эти классы задают нижний индекс или верхний индекс. Вы можете одновременно задать подстрочный и надстрочный индексы слева или справа от аргумента, но одиночный подстрочный или надстрочный индекс поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) также может использоваться для задания степени числа.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) задаёт объект матрицы, состоящий из дочерних элементов, размещённых в одной или нескольких строках и столбцах. Важно отметить, что у матриц нет встроенных ограничителей. Чтобы разместить матрицу в скобках, следует использовать объект ограничителя — [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). Нулевые аргументы могут использоваться для создания пустых ячеек в матрице.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) задаёт вертикальный массив уравнений или любых математических объектов.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox): рисует прямоугольную или другую границу вокруг **MathElement**.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox): задаёт логическое обрамление (упаковку) математического элемента. Например, обрамлённый объект может служить эмулатором оператора с точкой выравнивания или без неё, может быть точкой разрыва строки или может быть сгруппирован так, чтобы не допускать разрывов внутри. Например, оператор “==” следует поместить в коробку, чтобы предотвратить разрыв строки.

- Класс [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter): задаёт объект ограничителя, состоящий из открывающего и закрывающего символов (скобок, фигурных скобок, квадратных скобок, вертикальных черт) и одного или более математических элементов внутри, разделённых указанным символом. Примеры: (𝑥²); [𝑥²|𝑦²].  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent): задаёт акцентную функцию, состоящую из основания и комбинируемого диакритического знака.  
  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar): задаёт функцию черты, состоящую из базового аргумента и надчерты или подчёрты.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter): задаёт символ группировки над или под выражением, обычно для подчёркивания взаимосвязей между элементами.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) реализует класс **MathElement**. Он позволяет применять операции к существующей структуре и формировать более сложные математические выражения. Все операции принимают два набора параметров: либо **MathElement**, либо строку. Экземпляры класса [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) неявно создаются из указанных строк, когда используются строковые аргументы. Ниже перечислены доступные в Aspose.Slides математические операции.

### **Метод Join**
- `join(String)`
- `join(MathElement)`

Объединяет математический элемент и образует математический блок. Пример:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Метод Divide**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

Создаёт дробь указанного типа с данным числителем и заданным знаменателем. Пример:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Метод Enclose**
- `enclose()`
- `enclose(Char, Char)`

Обрамляет элемент указанными символами, например скобками или другими символами.

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
- `function(String)`
- `function(MathElement)`

Создаёт функцию от аргумента, используя текущий объект как имя функции.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(MathElement functionArgument);

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
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

Использует текущий экземпляр в качестве аргумента указанной функции. Вы можете:

- задать строку как имя функции, например “cos”;
- выбрать одно из предопределённых значений перечислений [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments), например [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument).**ArcSin**;
- передать экземпляр **MathElement**.

Пример:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

Устанавливают подстрочный и надстрочный индексы. Вы можете одновременно задать оба индекса слева или справа от аргумента, но одиночный подстрочный или надстрочный индекс поддерживается только справа. **Superscript** также может использоваться для задания степени числа.

Пример:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Метод Radical**
- `radical(String)`
- `radical(MathElement)`

Задает математический корень заданной степени от указанного аргумента.

Пример:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **Методы SetUpperLimit и SetLowerLimit**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

Устанавливает верхний или нижний предел. Здесь верхний и нижний просто указывают расположение аргумента относительно основания.

Рассмотрим выражение:  

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения можно создать, комбинируя классы [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) и [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit), а также операции `MathElement` следующим образом:

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Методы Nary и Integral**
- `nary(MathNaryOperatorTypes, MathElement, MathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

Оба метода **nary** и **integral** создают и возвращают N-арный оператор типа [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator). В методе nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) задаёт тип оператора: суммирование, объединение и т.п., без интегралов. В методе Integral реализована специальная операция интеграл с перечислением типов интегралов [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes).

Пример:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **Метод ToMathArray**
**toMathArray** помещает элементы в вертикальный массив. Если эта операция вызывается для экземпляра [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock), все дочерние элементы будут размещены в возвращаемом массиве.

Пример:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод **accent** ставит ударный знак (символ над элементом).
- Методы **overbar** и **underbar** ставят черту сверху или снизу.
- Метод **group** помещает в группу, используя символ группировки, например нижнюю фигурную скобку или другую.
- Метод **toBorderBox** помещает в границу‑коробку.
- Метод **toBox** помещает в невизуальную коробку (логическое объединение).

Примеры:

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **FAQ**

**Как добавить математическое уравнение на слайд PowerPoint?**

Для добавления уравнения необходимо создать объект `MathShape`, который автоматически содержит математическую часть. Затем получите `MathParagraph` из `MathPortion` и добавьте в него объекты `MathBlock`.

**Возможно ли создавать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные математические выражения, вложая MathBlocks. Каждый математический элемент наследует класс `MathElement`, что даёт возможность применять операции (Join, Divide, Enclose и др.) для комбинирования элементов в более сложные структуры.

**Как обновить или изменить существующее математическое уравнение?**

Для обновления уравнения необходимо получить доступ к существующим MathBlocks через `MathParagraph`. Затем, используя такие методы, как Join, Divide, Enclose и другие, можно изменять отдельные элементы уравнения. После редактирования сохраните презентацию, чтобы применить изменения.