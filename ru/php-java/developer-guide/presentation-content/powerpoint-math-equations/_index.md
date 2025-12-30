---
title: Добавление математических уравнений в презентации PowerPoint на PHP
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides для PHP через Java, поддерживая OMML, элементы форматирования и понятные примеры кода."
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

Для добавления математического уравнения в PowerPoint используется меню *Insert->Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в XML, который может быть отображён в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания уравнений. Однако создание сложных математических уравнений в PowerPoint часто не даёт хорошего и профессионального результата. Пользователи, которым часто требуется создавать математические презентации, прибегают к использованию сторонних решений для создания красивых математических формул.

С помощью [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/) вы можете программно работать с математическими уравнениями в презентациях PowerPoint на C#. Создавать новые математические выражения или редактировать уже созданные. Экспорт математических структур в изображения также поддерживается частично.


## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций с произвольным уровнем вложенности. Линейная коллекция математических элементов образует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock). Класс [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) по сути представляет отдельное математическое выражение, формулу или уравнение. Класс [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) — это математическая часть, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). Класс [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) позволяет манипулировать набором математических блоков. Перечисленные выше классы являются ключевыми для работы с математическими уравнениями PowerPoint через API Aspose.Slides.

Посмотрим, как можно создать следующее математическое уравнение с помощью Aspose.Slides API:

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


После создания форма автоматически содержит один абзац с математической частью по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) представляет часть, содержащую математический текст. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

```


## **Типы математических элементов**
Математические выражения формируются из последовательностей математических элементов. Последовательность элементов представлена математическим блоком, а аргументы элементов образуют древовидную вложенность.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть включён (агрегирован) в другой элемент. То есть элементы являются контейнерами для других, образуя древовидную структуру. Самый простой тип элемента не содержит других элементов математического текста.

Каждый тип математического элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement), позволяя использовать общий набор математических операций для разных типов элементов.
### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) представляет математический текст — базовый элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐
### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) определяет объект дроби, состоящий из числителя и знаменателя, разделённых чертой дроби. Черта может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления функции стека, которая размещает один элемент над другим без черты дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) определяет радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) определяет функцию аргумента. Содержит свойства: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) — имя функции и [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) — аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) определяет N‑арный математический объект, такой как суммирование или интеграл. Он состоит из оператора, основания (или операнда) и опциональных верхних и нижних пределов. Примерами N‑арных операторов являются суммирование, объединение, пересечение, интеграл.

Этот класс не включает простые операторы, такие как сложение, вычитание и т.п. Они представлены одним текстовым элементом — [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) создаёт верхний или нижний предел. Он определяет объект предела, состоящий из текста на основной линии и уменьшенного текста непосредственно выше или ниже неё. Этот элемент не включает слово «lim», но позволяет разместить текст сверху или снизу выражения. Таким образом, выражение  

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией элементов [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) и [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) следующим способом:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Эти классы задают нижний или верхний индекс. Можно одновременно задать субскрипт и суперкрипт слева или справа от аргумента, но одиночный субскрипт или суперкрипт поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) также может использоваться для задания степени числа.

Пример:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) определяет объект матрицы, состоящий из дочерних элементов, размещённых в одной или нескольких строках и колонках. Важно отметить, что у матриц нет встроенных делимитеров. Чтобы разместить матрицу в скобках, следует использовать объект делимитера — [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter). Null‑аргументы можно использовать для создания пробелов в матрицах.

Пример:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) определяет вертикальный массив уравнений или любых математических объектов.

Пример:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): рисует прямоугольную или другую границу вокруг [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).

  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): задаёт логическую упаковку (боксинг) математического элемента. Например, объект в боксе может выступать в роли эмулятора оператора с выравнивающей точкой или без неё, служить разрывом строки или группироваться так, чтобы внутри не было разрывов. Например, оператор «==» следует поместить в бокс, чтобы избежать разрывов строки.

- Класс [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): задаёт объект делимитера, состоящий из открывающего и закрывающего символов (скобки, фигурные скобки, квадратные скобки, вертикальные черты) и одного или нескольких математических элементов внутри, разделённых заданным символом. Примеры: (𝑥2); [𝑥2|𝑦2].

  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): задаёт акцент, состоящий из основания и комбинирующего диакритического знака.

  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): задаёт бар‑функцию, состоящую из базового аргумента и надчеркивания или подчеркнутого символа.

  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): задаёт группирующий символ над или под выражением, обычно для подчёркивания взаимосвязей между элементами.

  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Он позволяет применять операции к существующей структуре и формировать более сложные выражения. Все операции имеют два набора параметров: либо [**IMathElement**], либо строку. Экземпляры класса [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) неявно создаются из переданных строк при использовании строковых аргументов. Ниже перечислены операции, доступные в Aspose.Slides.
### **Метод Join**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Объединяет математический элемент и формирует математический блок. Например:

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

Создаёт дробь указанного типа с данным числителем и заданным знаменателем. Например:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Метод Enclose**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

Оборачивает элемент указанными символами, например скобками или другим символом‑рамкой.

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

Создаёт функцию от аргумента, используя текущий объект как имя функции.

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

Принимает указанный функции текущий объект как аргумент. Вы можете:

- задать строку как имя функции, например “cos”;
- выбрать одно из предопределённых значений перечислений [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments), например [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**];
- передать экземпляр [**IMathElement**].

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
- [setSubSuperscriptOnTheRight(IMMathElement, IMMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMMathElement, IMMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Устанавливает субскрипт и суперкрипт. Можно задать одновременно субскрипт и суперкрипт слева или справа от аргумента, но одиночный субскрипт или суперкрипт поддерживается только справа. **Superscript** также может использоваться для задания степени числа.

Пример:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Метод Radical**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Задает математический корень заданной степени от указанного аргумента.

Пример:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **Методы SetUpperLimit и SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Задает верхний или нижний предел. Здесь верхний и нижний просто указывают расположение аргумента относительно основания.

Рассмотрим выражение:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения можно создать комбинацией классов [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) и [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) и операциями [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) следующим образом:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Методы Nary и Integral**
- [nary(MathNaryOperatorTypes, IMMathElement, IMMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMMathElement, IMMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMMathElement, IMMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMMathElement-com.aspose.slides.IMMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Оба метода **nary** и **integral** создают и возвращают N‑арный оператор типа [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator). В методе nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) задаёт тип оператора: суммирование, объединение и т.п., не включая интегралы. В методе Integral используется специализированная операция Integral с перечислением типов интегралов [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes).

Пример:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **Метод ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) помещает элементы в вертикальный массив. Если вызвать эту операцию у экземпляра [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock), все дочерние элементы будут размещены в возвращаемом массиве.

Пример:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) задаёт акцент (символ над элементом).
- Методы [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) и [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) ставят черту сверху или снизу.
- Метод [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) группирует с помощью символа группировки, например нижней фигурной скобки или иной.
- Метод [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) помещает в границу‑бокс.
- Метод [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) помещает в невизуальную коробку (логическая группировка).

Примеры:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **FAQ**

**Как добавить математическое уравнение на слайд PowerPoint?**

Чтобы добавить уравнение, необходимо создать объект математической формы, который автоматически содержит математическую часть. Затем получить [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) из [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) и добавить в него объекты [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/).

**Можно ли создать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные выражения, вложивая MathBlocks. Каждый математический элемент позволяет применять операции (Join, Divide, Enclose и т.д.) для комбинирования элементов в более сложные структуры.

**Как обновить или изменить существующее математическое уравнение?**

Чтобы обновить уравнение, необходимо обратиться к существующим MathBlocks через [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Затем, используя такие методы, как Join, Divide, Enclose и другие, можно изменить отдельные элементы уравнения. После редактирования сохраните презентацию, чтобы применить изменения.