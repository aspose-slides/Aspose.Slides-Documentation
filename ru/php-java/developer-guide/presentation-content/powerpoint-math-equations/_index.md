---
title: Математические Уравнения PowerPoint
type: docs
weight: 80
url: /php-java/powerpoint-math-equations/
keywords: "Математические Уравнения PowerPoint, Символы Математики PowerPoint, Формула PowerPoint, Математический Текст PowerPoint"
description: "Математические Уравнения PowerPoint, Символы Математики PowerPoint, Формула PowerPoint, Математический Текст PowerPoint"
---

## **Обзор**
В PowerPoint возможно написать математическое уравнение или формулу и отобразить их в презентации. Для этого различными математическими символами, представленными в PowerPoint, можно дополнить текст или уравнение. Для этого используется конструктор математических уравнений в PowerPoint, который помогает создавать сложные формулы, такие как:

- Математическая дробь
- Математический радикал
- Математическая функция
- Пределы и логарифмические функции
- N-ичные операции
- Матрица
- Упрощенные операторы
- Функции синуса и косинуса

Чтобы добавить математическое уравнение в PowerPoint, используется меню *Вставка -> Уравнение*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в формате XML, который может быть отображен в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания математических уравнений. Тем не менее, создание сложных математических уравнений в PowerPoint часто не дает хорошего и профессионального результата. Пользователи, которым часто нужно создавать математические презентации, прибегают к использованию сторонних решений для создания хорошо оформленных математических формул.

Используя [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/), вы можете программно работать с математическими уравнениями в PowerPoint-презентациях на C#. Создавайте новые математические выражения или редактируйте ранее созданные. Экспорт математических структур в изображения также частично поддерживается.


## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций с любым уровнем вложенности. Линейная коллекция математических элементов формирует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). Класс [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) фактически является отдельным математическим выражением, формулой или уравнением. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) — это математическая порция, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) позволяет манипулировать набором математических блоков. Упомянутые классы являются ключом к работе с математическими уравнениями PowerPoint через Aspose.Slides API.

Давайте посмотрим, как мы можем создать следующее математическое уравнение с помощью Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте форму, которая будет содержать математический текст:

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

После создания форма уже будет содержать один абзац с математической порцией по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) — это порция, которая содержит математический текст внутри. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion), обращайтесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

Класс [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), которые состоят из комбинации математических элементов. Например, создайте дробь и поместите её в презентацию:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

Каждый математический элемент представлен каким-то классом, который реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Этот интерфейс предоставляет множество методов для легкого создания математических выражений. Вы можете создать довольно сложное математическое выражение всего одной строкой кода. Например, теорема Пифагора будет выглядеть так:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

Операции интерфейса [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) реализованы в любом типе элемента, включая [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

Полный образец исходного кода:

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $fraction = new MathematicalText("x")->divide("y");
    $mathParagraph->add(new MathBlock($fraction));
    $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
    $mathParagraph->add($mathBlock);
    $pres->save("math.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Типы математических элементов**
Математические выражения формируются из последовательностей математических элементов. Последовательность математических элементов представляется математическим блоком, а аргументы математических элементов формируют древовидную вложенность.

Существует множество типов математических элементов, которые могут быть использованы для построения математического блока. Каждый из этих элементов может быть включён (агрегирован) в другой элемент. То есть элементы фактически являются контейнерами для других, формируя древовидную структуру. Самый простой тип элемента не содержит других элементов математического текста.

Каждый тип математического элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement), позволяя использовать общий набор математических операций на различных типах математических элементов.
### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) представляет математический текст - основной элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐
### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) задает фракционный объект, состоящий из числителя и знаменателя, разделенных дробной чертой. Дробная черта может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления функции стека, которая помещает один элемент над другим без дробной черты.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) задает радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) задает функцию аргумента. Содержит свойства: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) - имя функции и [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) - аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) задает N-ичные математические объекты, такие как сумма и интеграл. Он состоит из оператора, базы (или операнда) и необязательных верхних и нижних пределов. Примеры N-ичных операторов включают сумму, объединение, пересечение, интеграл.

Этот класс не включает простые операторы, такие как сложение, вычитание и т. д. Они представлены одним текстовым элементом - [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) создает верхний или нижний предел. Он задает объект предела, состоящий из текста на базовой линии и уменьшенного текста сразу выше или ниже него. Этот элемент не включает слово “lim", но позволяет разместить текст вверху или внизу выражения. Таким образом, выражение

![todo:image_alt_text](powerpoint-math-equations_8.png)

создается с помощью сочетания элементов [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) и [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) следующим образом:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));

``` 


### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Следующие классы задают нижний индекс или верхний индекс. Вы можете установить подстрочный и надстрочный текст одновременно слева или справа от аргумента, однако поддерживается только одиночный подстрочный или надстрочный текст справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) также может использоваться для задания математической степени числа.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) задает объект Матрицы, состоящий из дочерних элементов, расположенных в одном или нескольких рядах и столбцах. Важно отметить, что матрицы не имеют встроенных разделителей. Чтобы поместить матрицу в скобки, необходимо использовать объект разделителя - [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter). Нулевые аргументы могут быть использованы для создания пробелов в матрицах.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) задает вертикальный массив уравнений или любых математических объектов.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): рисует прямоугольную или другую рамку вокруг [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): задает логическую упаковку (упаковку) математического элемента. Например, объект в боксе может служить эмулятором оператора с или без точки выравнивания, служить точкой разрыва линии или быть сгруппированным так, чтобы не допускать разрывов линий внутри. Например, оператор "==" должен быть помещен в бокс, чтобы предотвратить разрывы линии.
- Класс [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): задает объект разделителя, состоящий из открывающих и закрывающих символов (таких как скобки, фигурные скобки, квадратные скобки и вертикальные линии) и одного или нескольких математических элементов внутри, разделенных указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): задает акцентирующую функцию, состоящую из основания и диакритического знака.

  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): задает барную функцию, состоящую из базового аргумента и надчеркивающего или подчеркивающего знака.
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): задает символ группировки над или под выражением, обычно для выделения взаимосвязей между элементами.
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Это позволяет использовать операции на существующей структуре и формировать более сложные математические выражения. Все операции имеют два набора параметров: либо [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement), либо строку в качестве аргумента. Экземпляры класса [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) создаются неявно из указанных строк, когда используются строковые аргументы. Математические операции, доступные в Aspose.Slides, перечислены ниже.
### **Метод Join**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Соединяет математический элемент и формирует математический блок. Например:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);

``` 

### **Метод Divide**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Создает дробь указанного типа с этим числителем и заданным знаменателем. Например:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);

``` 

### **Метод Enclose**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

Заключает элемент в указанные символы, такие как круглые скобки или другой символ для оформления.

```php

``` 


Например:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();

``` 

### **Метод Function**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Принимает функцию аргумента, используя текущий объект в качестве имени функции.

```php

``` 


Например:

```php
  $func = new MathematicalText("sin")->function("x");

``` 

### **Метод AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Принимает заданную функцию, используя текущий экземпляр в качестве аргумента. Вы можете:

- указать строку в качестве имени функции, например “cos”.
- выбрать одно из предопределенных значений перечисления [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments), например [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- выбрать экземпляр [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

Например:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");

``` 

### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Устанавливает подстрочный и надстрочный текст. Вы можете установить подстрочный и надстрочный текст одновременно слева или справа от аргумента, однако поддерживается только одиночный подстрочный или надстрочный текст справа. **Надстрочный текст** также может использоваться для задания математической степени числа.

Пример:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");

``` 

### **Метод Radical**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Задает математический корень указанной степени от заданного аргумента.

Пример:

```php
  $radical = new MathematicalText("x")->radical("3");

``` 

### **Методы SetUpperLimit и SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Принимает верхний или нижний предел. Здесь верхний и нижний обычно указывают местоположение аргумента относительно базы.

Рассмотрим выражение: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения могут быть созданы через сочетание классов [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) и [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit), а также операций [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) следующим образом:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");

``` 

### **Методы Nary и Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Методы **nary** и **integral** создают и возвращают N-ичный оператор, представленный типом [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator). В методе nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) задает тип оператора: сумма, объединение и т. д., не включая интегралы. В методе Integral осуществляется специализированная операция интеграла с перечислением типов интеграла [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes). 

Пример:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");

``` 

### **Метод ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) помещает элементы в вертикальный массив. Если эта операция вызывается для экземпляра [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock), все дочерние элементы будут помещены в возвращаемый массив.

Пример:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();

``` 

### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) устанавливает акцентирующий знак (символ над верхней частью элемента).
- Методы [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) и [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) устанавливают бар сверху или снизу.
- Метод [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) размещает в группе с использованием символа группировки, такого как нижняя фигурная скобка или другой.
- Метод [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) помещает в границу.
- Метод [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) помещает в невидимый бокс (логическая группировка).

Примеры:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();

``` 