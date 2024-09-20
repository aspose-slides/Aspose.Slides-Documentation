---
title: Математические уравнения PowerPoint
type: docs
weight: 80
url: /cpp/powerpoint-math-equations/
keywords: " Математические уравнения PowerPoint, Математические символы PowerPoint, Формула PowerPoint, Математический текст PowerPoint"
description: "Математические уравнения PowerPoint, Математические символы PowerPoint, Формула PowerPoint, Математический текст PowerPoint"
---

## **Обзор**
В PowerPoint возможно написать математическое уравнение или формулу и отобразить их в презентации. Для этого в PowerPoint представлены различные математические символы, которые можно добавить в текст или уравнение. Для этого используется конструктор математических уравнений в PowerPoint, который помогает создавать сложные формулы, такие как:

- Математическая дробь
- Математический корень
- Математическая функция
- Пределы и логарифмические функции
- N-ерные операции
- Матрица
- Большие операторы
- Функции синуса и косинуса

Для добавления математического уравнения в PowerPoint используется меню *Вставка -> Уравнение*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в XML, который может отображаться в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания математических уравнений. Тем не менее, создание сложных математических уравнений в PowerPoint часто не дает хорошего и профессионального результата. Пользователи, которым часто необходимо создавать математические презентации, прибегают к использованию сторонних решений для создания красивых математических формул.

Используя [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/), вы можете программно работать с математическими уравнениями в PowerPoint-презентациях на C++. Создавайте новые математические выражения или редактируйте ранее созданные. Экспорт математических структур в изображения также поддерживается частично.

## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций с любым уровнем вложенности. Линейная коллекция математических элементов образует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block). Класс [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) по сути является отдельным математическим выражением, формулой или уравнением. [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) – это математическая часть, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)). Класс [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) позволяет управлять набором математических блоков. Упомянутые классы являются ключом к работе с математическими уравнениями PowerPoint через Aspose.Slides API.

Давайте посмотрим, как мы можем создать следующее математическое уравнение с помощью Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте фигуру, которая будет содержать математический текст:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
```

После создания фигура уже будет содержать один абзац с математической частью по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) является частью, содержащей математический текст внутри. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph):

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
```

Класс [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)), состоящие из комбинации математических элементов. Например, создайте дробь и поместите ее в презентацию:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
```

Каждый математический элемент представлен некоторым классом, который реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). Этот интерфейс предоставляет множество методов для легкого создания математических выражений. Вы можете создать довольно сложное математическое выражение с помощью одной строки кода. Например, теорема Пифагора будет выглядеть так:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
```

Операции интерфейса [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) реализованы в любом типе элемента, включая [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block).

Полный пример кода:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
mathParagraph->Add(mathBlock);

pres->Save(u"math.pptx", SaveFormat::Pptx);
```

## **Типы математических элементов**
Математические выражения формируются из последовательностей математических элементов. Последовательность математических элементов представляется математическим блоком, а аргументы математических элементов образуют древовидную вложенность.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть включен (агрегирован) в другой элемент. То есть элементы на самом деле являются контейнерами для других, образуя древовидную структуру. Самый простой тип элемента, который не содержит других элементов математического текста.

Каждый тип математического элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element), позволяя использовать общий набор математических операций на различных типах математических элементов.
### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) представляет собой математический текст - основной элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой другой линейный текст.

Пример: 𝑎=𝑏+𝑐
### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction) определяет объект дроби, состоящий из числителя и знаменателя, разделенных линией дроби. Линия дроби может быть горизонтальной или диагональной, в зависимости от свойств дроби. Объект дроби также используется для представления стековой функции, которая помещает один элемент над другим без линии дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical) определяет радикальную функцию (математический корень), состоящую из основания и необязательной степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) определяет функцию от аргумента. Содержит методы: [get_Name() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) - имя функции и [get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) - аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator) определяет N-ерный математический объект, такой как сумма и интеграл. Он состоит из оператора, основы (или операнда) и необязательных верхних и нижних пределов. Примеры N-ерных операторов: Сумма, Объединение, Пересечение, Интеграл.

Этот класс не включает простые операторы, такие как сложение, вычитание и т.д. Они представлены одним текстовым элементом - [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) создает верхний или нижний предел. Он определяет объект предела, состоящий из текста на базовой линии и уменьшенного текста сразу выше или ниже него. Этот элемент не включает слово "lim", но позволяет размещать текст вверху или внизу выражения. Таким образом, выражение

![todo:image_alt_text](powerpoint-math-equations_8.png)

создается с помощью комбинации элементов [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) и [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) следующим образом:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
```

### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

Следующие классы определяют нижний индекс или верхний индекс. Вы можете установить подстрочный и надстрочный текст одновременно с левой или правой стороны аргумента, но единичный подстрочный или надстрочный текст поддерживается только с правой стороны. Элемент [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element) также можно использовать для установки математической степени числа.

Пример:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix) определяет объект Матрицы, состоящий из дочерних элементов, расположенных в одном или нескольких рядах и столбцах. Важно отметить, что матрицы не имеют встроенных разделителей. Чтобы поместить матрицу в скобки, вам следует использовать объект-разделитель - [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter). Нулевые аргументы могут использоваться для создания промежутков в матрицах.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array) определяет вертикальный массив уравнений или любых математических объектов.

Пример: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box): рисует прямоугольную или другую рамку вокруг [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box): определяет логическую упаковку (упаковку) математического элемента. Например, запакованный объект может служить эмулятором оператора с или без точки выравнивания, служить для разрыва строки или быть сгруппированным так, чтобы не допустить разрывов строки внутри. Например, оператор "==" должен быть упакован, чтобы предотвратить разрывы строки.
- Класс [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter): определяет объект-разделитель, состоящий из открывающих и закрывающих символов (таких как круглые скобки, фигурные скобки, квадратные скобки и вертикальные линии) и одного или нескольких математических элементов внутри, разделенных указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent): определяет акцентную функцию, состоящую из основания и комбинирующего диакритического знака. 

  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar): определяет барную функцию, состоящую из базового аргумента и надстрочного или подстрочного элемента.
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character): определяет символ группировки над или под выражением, обычно для выделения отношений между элементами.
  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) реализуют интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). Он позволяет использовать операции над существующей структурой и формировать более сложные математические выражения. Все операции имеют два набора параметров: либо [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element), либо строку в качестве аргументов. Экземпляры класса [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) создаются неявно из указанных строк, когда используются строковые аргументы. Доступные математические операции в Aspose.Slides перечислены ниже.
### **Метод Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

Объединяет математический элемент и формирует математический блок. Например:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 

### **Метод Divide**
- [Divide(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

Создает дробь указанного типа с данным числителем и заданным знаменателем. Например:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Метод Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

Заключает элемент в указанные символы, такие как скобки или другой символ для обрамления.

``` cpp
/// <summary>
/// Заключает математический элемент в скобки
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Заключает этот элемент в указанные символы, такие как скобки или другие символы для обрамления
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

Например:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Метод Function**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

Принимает функцию от аргумента, используя текущий объект в качестве имени функции.

``` cpp
/// <summary>
/// Принимает функцию от аргумента, используя этот экземпляр в качестве имени функции
/// </summary>
/// <param name="functionArgument">Аргумент функции</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

Например:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **Методы AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

Принимает указанную функцию, используя текущий экземпляр в качестве аргумента. Вы можете:

- указать строку в качестве имени функции, например “cos”.
- выбрать одно из предопределенных значений перечислений [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b), например **MathFunctionsOfOneArgument.ArcSin.**
- выбрать экземпляр [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).

Например:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 

### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

Устанавливает подстрочный и надстрочный текст. Вы можете установить подстрочный и надстрочный текст одновременно с левой или правой стороны аргумента, но единичный подстрочный или надстрочный текст поддерживается только с правой стороны. **Nadstrнyjj** также можно использовать для установки математической степени числа.

Пример:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Метод Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

Определяет математический корень заданной степени из указанного аргумента.

Пример:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **Методы SetUpperLimit и SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

Принимает верхний или нижний предел. Здесь верхний и нижний просто указывают на местоположение аргумента относительно основания.

Рассмотрим выражение: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такие выражения можно создать с помощью комбинации классов [MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) и [MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit), а также операций [IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element) следующим образом:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 

### **Методы Nary и Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

Оба метода **Nary** и **Integral** создают и возвращают N-ерный оператор, представленный типом [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator). В методе Nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167) указывает тип оператора: сумма, объединение и т.д., исключая интегралы. В методе Integral существует специализированная операция Integral с перечислением типов интегралов [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607).

Пример:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **Метод ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) помещает элементы в вертикальный массив. Если эта операция вызвана для экземпляра **MathBlock**, все дочерние элементы будут помещены в возвращаемый массив.

Пример:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **Форматирующие операции: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**Accent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acd0f38691b52fb83294c0da9f3690483) устанавливает акцент (символ сверху элемента).
- Методы [**Overbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5d4780f9be6d0709465f50f5d830d4e3) и [**Underbar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a97d93a1fc79a31f4ffd20d233e06c5a5) устанавливают линию сверху или снизу.
- Метод [**Group**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4662589060e34723455b8164ce556546) помещает в группу, используя символ группировки, такой как нижняя фигурная скобка или другой.
- Метод [**ToBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aa32771655d8931aa8e0b5d3c1c7e160b) помещает в рамку.
- Метод [**ToBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac18b6b70362303cb307862a9aaa7dce2) помещает в невизуальную коробку (логическая группировка).

Примеры:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
```
