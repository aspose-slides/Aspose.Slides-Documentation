---
title: Добавить математические уравнения в презентации PowerPoint на Android
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides для Android, поддерживая OMML, элементы управления форматированием и понятные примеры кода на Java."
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

Для добавления математического уравнения в PowerPoint используется меню *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в XML, который может быть отображён в PowerPoint следующим образом:  

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания уравнений. Однако создание сложных уравнений в PowerPoint часто не даёт хорошего и профессионального результата. Пользователи, которым часто нужно создавать математические презентации, прибегают к сторонним решениям для получения красиво оформленных формул.

Используя [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/), вы можете программно работать с математическими уравнениями в презентациях PowerPoint на C#. Создавать новые математические выражения или редактировать уже существующие. Экспорт математических структур в изображения также поддерживается частично.


## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций любой глубины вложения. Последовательность математических элементов образует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock). Класс [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) по сути представляет отдельное математическое выражение, формулу или уравнение. Класс [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) — это математическая часть, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). Класс [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) позволяет управлять набором математических блоков. Перечисленные классы являются ключом к работе с математическими уравнениями PowerPoint через Aspose.Slides API.

Посмотрим, как можно создать следующее математическое уравнение через Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте форму, которая будет содержать математический текст:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

После создания форма уже будет содержать один абзац с математической частью по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) представляет часть, содержащую математический текст. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Класс [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)), состоящие из комбинации математических элементов. Например, создать дробь и разместить её в презентации:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Каждый математический элемент представлен классом, реализующим интерфейс [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Этот интерфейс предоставляет множество методов для простого создания математических выражений. Можно создать достаточно сложное выражение одной строкой кода. Например, теорема Пифагора будет выглядеть так:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Операции интерфейса [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) реализованы во всех типах элементов, включая [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

Полный пример кода:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);

    IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
    
    IMathFraction fraction = new MathematicalText("x").divide("y");

    mathParagraph.add(new MathBlock(fraction));

    IMathBlock mathBlock = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);

    pres.save("math.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
``` 

## **Типы математических элементов**
Математические выражения формируются из последовательностей математических элементов. Последовательность элементов представлена математическим блоком, а аргументы элементов образуют древовидную вложенность.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть включён (агрегирован) в другой элемент. Таким образом, элементы фактически являются контейнерами для других, образуя древовидную структуру. Простейший тип элемента не содержит других элементов математического текста.

Каждый тип элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement), позволяя использовать общий набор математических операций для разных типов элементов.

### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) представляет математический текст — базовый элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой линейный текст.

Пример: 𝑎=𝑏+𝑐

### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) задаёт объект дроби, состоящий из числителя и знаменателя, разделённых чертой. Черта может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления функции “stack”, которая размещает один элемент над другим без черты.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) задаёт радикальную функцию (математический корень), состоящую из основания и, опционально, степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) задаёт функцию от аргумента. Содержит свойства: [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) — имя функции и [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) — аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) задаёт N‑арный математический объект, такой как сумма или интеграл. Он состоит из оператора, основания (или операнда) и опциональных верхних и нижних пределов. Примеры N‑арных операторов: Summation, Union, Intersection, Integral.

Этот класс не включает простые операторы вроде сложения или вычитания; они представляются отдельным элементом — [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) создаёт верхний или нижний предел. Он представляет объект предела, состоящий из текста на базовой линии и уменьшенного текста сразу над или под ней. Этот элемент не включает слово “lim”, но позволяет разместить текст сверху или снизу выражения. Таким образом, выражение  

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией элементов [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) и [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) следующим образом:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

Эти классы задают нижний или верхний индекс. Можно одновременно установить подстрочный и надстрочный индексы слева или справа от аргумента, но одиночный подстрочный или надстрочный индекс поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) также может использоваться для задания степени числа.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) задаёт объект матрицы, состоящий из дочерних элементов, размещённых в одну или несколько строк и столбцов. Важно помнить, что у матриц нет встроенных ограничителей. Чтобы поместить матрицу в скобки, используйте объект‑ограничитель — [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). Для создания пустых ячеек можно передать `null` в качестве аргументов.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) задаёт вертикальный массив уравнений или любых математических объектов.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox): рисует прямоугольную или другую рамку вокруг [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox): задаёт логическую упаковку (boxing) математического элемента. Например, такой объект может выступать в роли эмулятора оператора с или без точки выравнивания, служить разрывом строки или группироваться, чтобы запрещать разрывы внутри. Например, оператор “==” следует упаковать, чтобы предотвратить разрывы строки.

- Класс [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter): задаёт объект‑ограничитель, состоящий из открывающих и закрывающих символов (скобки, фигурные скобки, квадратные скобки, вертикальные черты) и одного или нескольких математических элементов внутри, разделённых указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent): задаёт функцию акцента, состоящую из основания и комбинируемого диакритического знака.  
  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar): задаёт функцию черты, состоящую из базового аргумента и надчерты или подчёркивания.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter): задаёт группирующий символ над или под выражением, обычно для подчёркивания взаимосвязей элементов.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Математические операции**
Каждый математический элемент и выражение (через [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Он позволяет применять операции к существующей структуре и формировать более сложные выражения. Все операции имеют два набора параметров: либо [**IMathElement**], либо строку. Экземпляры класса [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) неявно создаются из указанных строк при использовании строковых аргументов. Ниже перечислены доступные операции.

### **Метод Join**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Объединяет математический элемент и формирует блок. Пример:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Метод Divide**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Создаёт дробь указанного типа с текущим числителем и заданным знаменателем. Пример:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Метод Enclose**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

Оборачивает элемент в указанные символы, например в скобки.

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

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Метод Function**
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

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

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **Метод AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Принимает указанный метод как функцию, используя текущий экземпляр как аргумент. Можно:
- указать строку в качестве имени функции, например “cos”;
- выбрать одно из предопределённых значений перечислений — [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments), например [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin);
- передать экземпляр [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

Пример:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Устанавливает подстрочный и надстрочный индексы. Можно задать их одновременно слева или справа от аргумента, но одиночный индекс поддерживается только справа. **Superscript** также может использоваться для задания степени числа.

Пример:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Метод Radical**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Задаёт математический корень указанной степени от аргумента.

Пример:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Методы SetUpperLimit и SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Устанавливает верхний или нижний предел. Здесь верхний и нижний просто указывают расположение аргумента относительно основания.

Рассмотрим выражение:  

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такое выражение можно создать комбинацией классов [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) и [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit), используя операции [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement):

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Методы Nary и Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Оба метода **nary** и **integral** создают и возвращают N‑арный оператор типа [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator). В методе **nary** перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) задаёт тип оператора: суммирование, объединение и т.д., без интегралов. В методе **integral** используется специализированный тип интеграла с перечислением [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes).

Пример:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Метод ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) помещает элементы в вертикальный массив. Если вызвать эту операцию у экземпляра [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock), все дочерние элементы будут размещены в возвращаемом массиве.

Пример:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) задаёт надстрочный акцент (символ над элементом).
- Методы [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) и [**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) задают черту сверху или снизу.
- Метод [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) помещает элемент в группу, используя символ группировки, например нижнюю фигурную скобку.
- Метод [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) помещает элемент в рамку.
- Метод [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) помещает элемент в невизуальный контейнер (логическую группу).

Примеры:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **FAQ**

**Как добавить математическое уравнение на слайд PowerPoint?**

Чтобы добавить уравнение, нужно создать объект math shape, который автоматически содержит математическую часть. Затем получаем [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) из [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) и добавляем в него объекты [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/).

**Можно ли создавать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные выражения, вложивая MathBlocks. Каждый элемент реализует интерфейс [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), что даёт возможность применять операции (Join, Divide, Enclose и др.) для комбинации элементов в более сложные структуры.

**Как обновить или изменить существующее математическое уравнение?**

Для обновления уравнения необходимо получить доступ к существующим MathBlocks через [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). Затем с помощью методов Join, Divide, Enclose и других можно изменять отдельные элементы уравнения. После редактирования сохраните презентацию, чтобы применить изменения.