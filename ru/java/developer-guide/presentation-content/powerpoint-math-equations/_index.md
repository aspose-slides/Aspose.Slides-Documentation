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
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides для Java, поддержка OMML, средств форматирования и понятные примеры кода на Java."
---

## **Обзор**
В PowerPoint можно написать математическое уравнение или формулу и отобразить её в презентации. Для этого в PowerPoint представлены различные математические символы, которые можно добавить в текст или уравнение. Для создания сложных формул используется конструктор математических уравнений в PowerPoint, который помогает создавать такие выражения, как:

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

PowerPoint поддерживает множество математических символов для создания уравнений. Однако создание сложных уравнений в PowerPoint часто не даёт хорошего и профессионального результата. Пользователи, которым часто нужно создавать математические презентации, прибегают к сторонним решениям для получения красивых формул.

Используя [**Aspose.Slide API**](https://products.aspose.com/slides/java/), вы можете программно работать с математическими уравнениями в презентациях PowerPoint на C#. Создавать новые математические выражения или редактировать уже созданные. Экспорт математических структур в изображения также частично поддерживается.

## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций любой глубины вложения. Последовательная коллекция математических элементов образует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock). Класс [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) по сути представляет отдельное математическое выражение, формулу или уравнение. Класс [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) — математическая часть, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). Класс [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) позволяет манипулировать набором математических блоков. Перечисленные выше классы являются ключевыми для работы с математическими уравнениями PowerPoint через Aspose.Slides API.

Посмотрим, как можно создать следующее математическое уравнение с помощью Aspose.Slides API:

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

После создания форма уже будет содержать один абзац с математической частью по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) — часть, содержащая внутри себя математический текст. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion), обратитесь к переменной [**MathParagraph** ](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) :

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Класс [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)), состоящие из комбинаций математических элементов. Например, создадим дробь и разместим её в презентации:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Каждый математический элемент представлен некоторым классом, реализующим интерфейс [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Этот интерфейс предоставляет множество методов для простого создания математических выражений. С помощью одной строки кода можно создать довольно сложное выражение. Например, теорема Пифагора будет выглядеть так:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Операции интерфейса [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) реализованы в любом типе элемента, включая [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

Полный пример исходного кода:

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
Математические выражения формируются из последовательностей математических элементов. Последовательность элементов представляется математическим блоком, а аргументы элементов образуют древовидную вложенность.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть включён (агрегирован) в другой элемент. То есть элементы фактически являются контейнерами для остальных, образуя древовидную структуру. Самый простой тип — элемент, который не содержит других элементов математического текста.

Каждый тип математического элемента реализует интерфейс [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement), позволяющий использовать общий набор математических операций для разных типов элементов.

### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) представляет математический текст — базовый элемент всех математических построений. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐

### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) задаёт объект дроби, состоящий из числителя и знаменателя, разделённых чертой дроби. Черта может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления функции «stack», которая размещает один элемент над другим без линии дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) задаёт радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) задаёт функцию от аргумента. Содержит свойства: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) — имя функции и [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) — аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) задаёт N‑арный математический объект, такой как Summation или Integral. Он состоит из оператора, основания (или операнда) и необязательных верхних и нижних пределов. Примеры N‑арных операторов: Summation, Union, Intersection, Integral.

Этот класс не включает простые операторы вроде сложения или вычитания; они представлены одиночным текстовым элементом — [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) создаёт верхний или нижний предел. Он задаёт объект предела, состоящий из текста на базовой линии и уменьшенного текста сразу над или под ним. Этот элемент не включает слово «lim», а позволяет разместить текст сверху или снизу выражения. Таким образом, выражение  

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией элементов [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) и [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) следующим образом:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

Эти классы задают нижний или верхний индекс. Можно одновременно задать нижний и верхний индекс слева или справа от аргумента, но одиночный нижний или верхний индекс поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) также можно использовать для задания степени числа.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) задаёт объект матрицы, состоящий из дочерних элементов, расположенных в одной или нескольких строках и столбцах. Важно отметить, что у матриц нет встроенных разделителей. Чтобы поместить матрицу в скобки, следует использовать объект‑разделитель — [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). Для создания пустых ячеек в матрице можно передать null‑аргументы.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) задаёт вертикальный массив уравнений или любых математических объектов.

Пример:  

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox): рисует прямоугольную или иную границу вокруг [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox): задаёт логическое обёртывание (упаковку) математического элемента. Например, объект в коробке может служить эмулятором оператора с точкой выравнивания или без неё, служить разрывом строки или группировать так, чтобы внутри не было переносов. Например, оператор «==» следует упаковать, чтобы избежать разрывов строки.

- Класс [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter): задаёт объект‑разделитель, состоящий из открывающего и закрывающего символов (скобки, фигурные скобки, квадратные скобки, вертикальные черты) и одного или более математических элементов внутри, разделённых указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent): задаёт акцентную функцию, состоящую из основания и объединяющего диакритического знака.  
  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar): задаёт функцию бар, состоящую из базового аргумента и надчеркивания или подчеркивания.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter): задаёт группирующий символ над или под выражением, обычно для выделения отношений между элементами.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Это позволяет использовать операции над существующей структурой и формировать более сложные выражения. Все операции принимают два набора параметров: либо [**IMathElement**], либо строку. При передаче строки автоматически создаётся объект [**MathematicalText**].

### **Метод Join**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Объединяет математический элемент и формирует блок. Например:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Метод Divide**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Создаёт дробь указанного типа с данным числителем и знаменателем. Например:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Метод Enclose**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

Оборачивает элемент в указанные символы, например скобки.

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
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

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
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Принимает указанную функцию, используя текущий объект как аргумент. Можно:

- указать строку как имя функции, например «cos»;
- выбрать один из предопределённых значений перечислений [**MathFunctionsOfOneArgument**] или [**MathFunctionsOfTwoArguments**], например [**MathFunctionsOfOneArgument**].ArcSin;
- передать экземпляр [**IMathElement**].

Пример:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Устанавливает нижний и верхний индексы. Можно задать оба одновременно слева или справа, но одиночный нижний или верхний индекс поддерживается только справа. **Superscript** также может использоваться для указания степени числа.

Пример:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Метод Radical**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Задаёт корень из аргумента заданной степени.

Пример:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Методы SetUpperLimit и SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Задаёт верхний или нижний предел. Здесь верхний и нижний просто указывают расположение аргумента относительно основания.

Рассмотрим выражение:  

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения можно создать комбинацией классов [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) и [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) и операциями [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement):

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Методы Nary и Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Оба метода **nary** и **integral** создают и возвращают N‑арный оператор типа [**IMathNaryOperator**]. В методе nary перечисление [**MathNaryOperatorTypes**] указывает тип оператора: суммирование, объединение и т.д., без интегралов. В методе integral используется специализированный тип интеграл с перечислением [**MathIntegralTypes**].

Пример:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Метод ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) помещает элементы в вертикальный массив. Если вызвать эту операцию у экземпляра [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock), все дочерние элементы будут помещены в возвращённый массив.

Пример:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод **accent** — устанавливает надстрочный акцент (символ над элементом).  
- Методы **overbar** и **underbar** — добавляют линию сверху или снизу.  
- Метод **group** — размещает элементы в группе, используя символ группировки, например нижнюю фигурную скобку.  
- Метод **toBorderBox** — размещает элемент в рамке‑коробке.  
- Метод **toBox** — размещает элемент в логической коробке (без визуального отображения).

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

Чтобы добавить уравнение, необходимо создать объект математической формы, который автоматически содержит математическую часть. Затем получить объект [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) из [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) и добавить в него объекты [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/).

**Можно ли создавать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные выражения, вложивая MathBlocks. Каждый математический элемент реализует интерфейс [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/), что даёт возможность применять операции (Join, Divide, Enclose и др.) для комбинирования элементов в более сложные структуры.

**Как обновить или изменить уже существующее математическое уравнение?**

Для обновления уравнения необходимо получить доступ к существующим MathBlocks через [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). Затем, используя методы Join, Divide, Enclose и другие, можно изменить отдельные части уравнения. После редактирования сохраните презентацию, чтобы изменения вступили в силу.