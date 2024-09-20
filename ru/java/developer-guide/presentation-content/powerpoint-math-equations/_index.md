---
title: Уравнения математики PowerPoint
type: docs
weight: 80
url: /java/powerpoint-math-equations/
keywords: " Уравнения математики PowerPoint, Символы математики PowerPoint, Формула PowerPoint, Текст математики PowerPoint"
description: "Уравнения математики PowerPoint, Символы математики PowerPoint, Формула PowerPoint, Текст математики PowerPoint"
---

## **Обзор**
В PowerPoint возможно написать математическое уравнение или формулу и отобразить её на слайде. Для этого в PowerPoint представлены различные математические символы, которые можно добавить в текст или уравнение. Для этого в PowerPoint используется конструктор математических уравнений, который помогает создавать сложные формулы, такие как:

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

Это создаст математический текст в формате XML, который может быть отображен в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания математических уравнений. Однако создание сложных математических уравнений в PowerPoint часто не дает хороших и профессионально выглядящих результатов. Пользователи, которым часто необходимо создавать математические презентации, прибегают к использованию сторонних решений для создания презентаций с хорошо оформленными математическими формулами.

С помощью [**Aspose.Slide API**](https://products.aspose.com/slides/java/) вы можете программно работать с математическими уравнениями в презентациях PowerPoint на C#. Создавайте новые математические выражения или редактируйте ранее созданные. Экспорт математических структур в изображения также частично поддерживается.

## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций с любым уровнем вложенности. Линейная коллекция математических элементов образует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock). Класс [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) по сути является отдельным математическим выражением, формулой или уравнением. [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) – это математическая часть, предназначенная для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) позволяет манипулировать множеством математических блоков. Упомянутые классы являются ключом к работе с математическими уравнениями PowerPoint через Aspose.Slides API.

Давайте посмотрим, как мы можем создать следующее математическое уравнение с помощью Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте фигуру, которая будет содержать математический текст:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

После создания фигура уже будет содержать один абзац с математической частью по умолчанию. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Класс [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)), состоящие из комбинации математических элементов. Например, создадим дробь и разместим её в презентации:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Каждый математический элемент представлен некоторым классом, который реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Этот интерфейс предоставляет множество методов для легкого создания математических выражений. Вы можете создать довольно сложное математическое выражение всего за одну строку кода. Например, теорема Пифагора будет выглядеть так:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Операции интерфейса [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) реализуются в любом типе элемента, включая [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

Пример полного исходного кода:

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
Математические выражения формируются из последовательностей математических элементов. Последовательность математических элементов представляется математическим блоком, а аргументы математических элементов образуют древовидную вложенность.

Существует множество типов математических элементов, которые могут быть использованы для построения математического блока. Каждый из этих элементов может быть включен (агрегирован) в другой элемент. То есть, элементы фактически являются контейнерами для других, формируя древовидную структуру. Самый простой тип элемента - это элемент, который не содержит других элементов математического текста.

Каждый тип математического элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement), позволяя использовать общий набор математических операций на различных типах математических элементов.
### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) представляет собой математический текст — основной элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐
### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) задает объект дроби, состоящий из числителя и знаменателя, разделенных чертой дроби. Черта дроби может быть горизонтальной или диагональной в зависимости от свойств дроби. Объект дроби также используется для представления функции стека, которая помещает один элемент над другим без черты дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) задает радикальную функцию (математический корень), состоящую из основания и опциональной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) задает функцию аргумента. Содержит свойства: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) - имя функции и [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) - аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) задает N-арный математический объект, такой как сумма и интеграл. Он состоит из оператора, основания (или операнда) и опциональных верхних и нижних пределов. Примеры N-арных операторов: сумма, объединение, пересечение, интеграл.

Этот класс не включает простые операторы, такие как сложение, вычитание и тому подобное. Они представлены единичным текстовым элементом - [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) создает верхний или нижний предел. Он задает объект предела, состоящий из текста на базовой линии и текста уменьшенного размера сразу над или под ним. Этот элемент не включает слово "lim", но позволяет разместить текст вверху или внизу выражения. Таким образом, выражение 

![todo:image_alt_text](powerpoint-math-equations_8.png)

создается с использованием комбинации элементов [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) и [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) следующим образом:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

Следующие классы задают нижний или верхний индекс. Вы можете установить нижний и верхний индекс одновременно слева или справа от аргумента, но единичный нижний или верхний индекс поддерживается только с правой стороны. [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) также может быть использован для задания математической степени числа.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) задает объект матрицы, состоящий из дочерних элементов, расположенных в одном или нескольких рядах и столбцах. Важно отметить, что матрицы не имеют встроенных разделителей. Для помещения матрицы в скобки следует использовать объект-разделитель - [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). Пустые аргументы могут быть использованы для создания пробелов в матрицах.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) задает вертикальный массив уравнений или любых математических объектов.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox): рисует прямоугольную или какую-либо другую границу вокруг [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox): задает логическую упаковку математического элемента. Например, запакованный объект может служить эмулятором оператора с точкой выравнивания или без неё, служить точкой разрыва строки или быть сгруппирован так, чтобы не допускать переносов строк внутри. Например, оператор "==" должен быть запакован, чтобы предотвратить перенос строки.
- Класс [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter): задает объект-разделитель, состоящий из открывающих и закрывающих символов (таких как скобки, фигурные скобки, квадратные скобки и вертикальные палочки), и одного или нескольких математических элементов внутри, разделенных указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent): задает функцию акцента, состоящую из основания и объединившего диакритического знака. 

  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar): задает функцию черты, состоящую из базового аргумента и верхней или нижней черты.
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter): задает символ группировки над или под выражением, обычно для подчеркивания взаимосвязей между элементами.
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) реализуют интерфейс [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Это позволяет вам использовать операции на существующей структуре и формировать более сложные математические выражения. Все операции имеют два набора параметров: или [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement), или строку в качестве аргументов. Экземпляры класса [**MathematicalText** ](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) неявно создаются из указанных строк, когда используются строковые аргументы. Математические операции, доступные в Aspose.Slides, перечислены ниже.
### **Метод Join**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Соединяет математический элемент и формирует математический блок. Например:

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

Создает дробь указанного типа с этим числителем и указанным знаменателем. Например:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Метод Enclose**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

Заключает элемент в указанные символы, такие как скобки или другой символ как рамка.

```java
/**
 * <p>
 * Заключает математический элемент в скобки
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Заключает этот элемент в указанные символы, такие как скобки или другие символы как рамка
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

Например:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Метод Function**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Берет функцию аргумента, используя текущий объект как имя функции.

```java
/**
 * <p>
 * Берет функцию аргумента, используя этот экземпляр как имя функции
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Берет функцию аргумента, используя этот экземпляр как имя функции
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

Например:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **Метод AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Принимает указанную функцию, используя текущий экземпляр в качестве аргумента. Вы можете:

- указать строку в качестве имени функции, например "cos".
- выбрать одно из предопределенных значений перечислений [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments), например [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- выбрать экземпляр [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

Например:

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

Устанавливает нижний и верхний индекс. Вы можете установить нижний и верхний индекс одновременно слева или справа от аргумента, но единичный нижний или верхний индекс поддерживается только с правой стороны. **Верхний индекс** также может использоваться для задания математической степени числа.

Пример:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Метод Radical**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Задает математический корень заданной степени от указанного аргумента.

Пример:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Методы SetUpperLimit и SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Принимает верхний или нижний предел. Здесь верхний и нижний просто указывают на расположение аргумента относительно базы.

Рассмотрим выражение: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такое выражение может быть создано с помощью комбинации классов [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) и [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit), а также операций [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) следующим образом:

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

Как метод **nary**, так и метод **integral** создают и возвращают N-арный оператор, представленный типом [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator). В методе nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) определяет тип оператора: сумма, объединение и т.д., не включая интегралы. В методе Integral имеется специализированная операция интеграл с перечислением типов интеграла [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes). 

Пример:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Метод ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) помещает элементы в вертикальный массив. Если эта операция вызывается для экземпляра [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock), все дочерние элементы будут помещены в возвращаемый массив.

Пример:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) устанавливает акцентный знак (символ на верхней части элемента).
- Методы [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) и [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) устанавливают черту сверху или снизу.
- Метод [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) помещает в группу, используя символ группировки, такой как нижняя фигурная скобка или другой.
- Метод [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) помещает в границу.
- Метод [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) помещает в невизуальную коробку (логическая группировка).

Примеры:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 