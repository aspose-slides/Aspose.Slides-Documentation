---
title: Добавить математические уравнения в презентации PowerPoint на С++
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/cpp/powerpoint-math-equations/
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
- С++
- Aspose.Slides
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides для С++, поддерживая OMML, элементы управления форматированием и понятные примеры кода на С++."
---

## **Обзор**
В PowerPoint возможно написать математическое уравнение или формулу и отобразить её в презентации. Для этого в PowerPoint представлены различные математические символы, которые можно добавить в текст или уравнение. Для создания сложных формул используется конструктор математических уравнений в PowerPoint, который помогает создавать такие конструкции, как:

- Математическая дробь
- Математический радикал
- Математическая функция
- Пределы и логарифмические функции
- N‑арные операции
- Матрица
- Большие операторы
- Функции sin, cos

Для добавления математического уравнения в PowerPoint используется меню *Insert -> Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаст математический текст в XML, который может быть отображён в PowerPoint следующим образом:  

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания уравнений. Однако создание сложных уравнений в PowerPoint часто не даёт хорошего и профессионального результата. Пользователи, которым часто нужно создавать математические презентации, прибегают к сторонним решениям для получения красивых формул.

Используя [**Aspose.Slides API**](https://products.aspose.com/slides/cpp/), вы можете работать с математическими уравнениями в презентациях PowerPoint программно на C++. Создавать новые математические выражения или редактировать уже созданные. Экспорт математических структур в изображения также частично поддерживается.

## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций любой степени вложенности. Линейная коллекция математических элементов образует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block). Класс [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block) фактически представляет отдельное математическое выражение, формулу или уравнение. Класс [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) — это математическая часть, используемая для хранения математического текста (не путать с классом [**Portion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion)). Класс [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) позволяет управлять набором математических блоков. Указанные выше классы являются ключом к работе с математическими уравнениями PowerPoint через API Aspose.Slides.

Рассмотрим, как создать следующее математическое уравнение с помощью API Aspose.Slides:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте форму, которая будет содержать математический текст:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 

После создания форма уже содержит один абзац с математической частью по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) представляет часть, содержащую математический текст. Чтобы получить доступ к математическому содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph):

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 

Класс [**MathParagraph**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)), состоящие из комбинации математических элементов. Например, создадим дробь и поместим её в презентацию:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 

Каждый математический элемент представлен классом, реализующим интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). Этот интерфейс предоставляет множество методов для простого создания математических выражений. Вы можете создать довольно сложное выражение одной строкой кода. Например, теорема Пифагора будет выглядеть так:

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
Математические выражения формируются из последовательностей математических элементов. Последовательность элементов представлена математическим блоком, а аргументы элементов образуют древовидную вложенность.

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый из этих элементов может быть включён (агрегирован) в другой элемент. То есть элементы действительно являются контейнерами для других, образуя древовидную структуру. Наиболее простой тип элемента не содержит других элементов текста.

Каждый тип элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element), позволяя использовать общий набор математических операций для разных типов элементов.

### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text) представляет математический текст — базовый элемент всех математических конструкций. Такой текст может выступать в роли операндов, операторов, переменных и любого другого линейного текста.

Пример: 𝑎=𝑏+𝑐

### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction) описывает объект дроби, состоящий из числителя и знаменателя, разделённых линией дроби. Линия может быть горизонтальной или диагональной в зависимости от свойств дроби. Этот объект также используется для представления функции стека, где один элемент размещён над другим без линии дроби.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical) описывает радикальную функцию (корень), состоящую из оснований и, при необходимости, степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) описывает функцию от аргумента. Содержит методы: [get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3) — имя функции и [get_Base()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) — аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator) описывает N‑арный математический объект, такой как сумма или интеграл. Он состоит из оператора, базы (или операнда) и опциональных верхних и нижних пределов. Примерами N‑арных операторов являются Summation, Union, Intersection, Integral.

Этот класс не включает простые операторы вроде сложения или вычитания; они представлены отдельным элементом — [MathematicalText](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) создаёт верхний или нижний предел. Он состоит из текста на базовой линии и уменьшенного текста непосредственно выше или ниже неё. Этот элемент не включает слово “lim”, но позволяет разместить текст сверху или снизу выражения. Таким образом, выражение

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией [**MathFunction**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) и [**MathLimit**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) следующим образом:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 

### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

Эти классы задают нижний (subscript) или верхний (superscript) индекс. Можно одновременно установить subscript и superscript слева или справа от аргумента, но одиночный subscript или superscript поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element) также может использоваться для задания степени числа.

Пример:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix) описывает объект матрицы, состоящий из дочерних элементов, размещённых в строках и столбцах. Важно отметить, что матрицы не имеют встроенных ограничителей. Чтобы окружить матрицу скобками, необходимо использовать объект‑ограничитель — [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter). При необходимости можно передать null‑аргументы для создания пробелов в матрице.

Пример:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array) описывает вертикальный массив уравнений или любых других математических объектов.

Пример:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box): рисует прямоугольную или другую рамку вокруг [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).  

  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box): задаёт логическую упаковку (boxing) математического элемента. Например, упакованный объект может выступать в роли эмулятора оператора с точкой согласования или без неё, может служить разрывом строки или быть сгруппированным, чтобы запрещать разрывы внутри. Например, оператор “==” следует упаковать, чтобы предотвратить разрыв строки.

- Класс [**MathDelimiter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter): задаёт ограничитель, состоящий из открывающего и закрывающего символов (скобки, фигурные скобки, квадратные скобки, вертикальные линии) и одного или нескольких математических элементов внутри, разделённых указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].  

  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent): задаёт акцент над символом, состоящий из основы и объединяющего диакритического знака.  

  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar): задаёт полосу над или под элементом.  

  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character): задаёт группирующий символ над или под выражением, обычно для подчёркивания взаимосвязей между элементами.  

  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element). Он позволяет выполнять операции над существующей структурой и формировать более сложные выражения. Все операции имеют два набора параметров: либо [**IMathElement**], либо строку. При использовании строковых аргументов экземпляры класса [**MathematicalText**] создаются неявно. Ниже перечислены доступные в Aspose.Slides операции.

### **Метод Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

Объединяет математический элемент, формируя математический блок. Пример:

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

Создаёт дробь указанного типа с текущим числителем и заданным знаменателем. Пример:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 

### **Метод Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

Оборачивает элемент в указанные символы, например скобки.

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 

Пример:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::ExplicitCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Метод Function**
- [Function(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

Создаёт функцию от аргумента, используя текущий объект как имя функции.

``` cpp
/// <summary>
/// Takes a function of an argument using this instance as the function name
/// </summary>
/// <param name="functionArgument">An argument of the function</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;
virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 

Пример:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 

### **Метод AsArgumentOfFunction**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

Позволяет задать функцию, используя текущий объект как аргумент. Можно:
- указать строку‑имя функции, например “cos”;
- выбрать предопределённое значение из перечислений [**MathFunctionsOfOneArgument**] или [**MathFunctionsOfTwoArguments**], например **MathFunctionsOfOneArgument.ArcSin**;
- передать экземпляр [**IMathElement**].

Пример:

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

Устанавливают нижний и верхний индексы. Можно задать subscript и superscript одновременно слева или справа, но одиночный subscript или superscript поддерживается только справа. **Superscript** также может использоваться для задания степени числа.

Пример:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 

### **Метод Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

Задаёт корень заданной степени из указанного аргумента.

Пример:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 

### **Методы SetUpperLimit и SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

Задают верхний или нижний предел. Здесь «верхний» и «нижний» просто указывают положение аргумента относительно базового элемента.

Рассмотрим выражение:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такое выражение создаётся комбинацией классов [MathFunction](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function) и [MathLimit](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit) и операциями [IMathElement](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element):

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

Методы **Nary** и **Integral** создают и возвращают N‑арный оператор, представляемый типом [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator). В методе **Nary** перечисление [**MathNaryOperatorTypes**] задаёт тип оператора (сумма, объединение и т.п.), без интегралов. В методе **Integral** используется специализированный тип интеграла из перечисления [**MathIntegralTypes**].

Пример:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 

### **Метод ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) размещает элементы в вертикальном массиве. Если вызвать эту операцию у экземпляра **MathBlock**, все дочерние элементы будут помещены в возвращаемый массив.

Пример:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 

### **Форматирующие операции: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **Accent** — добавляет надстрочный акцент.
- **Overbar** и **Underbar** — добавляют полосу над или под элементом.
- **Group** — объединяет элементы с помощью символа группировки (например, нижняя фигурная скобка).
- **ToBorderBox** — размещает элемент в рамке.
- **ToBox** — помещает элемент в логический (не визуальный) блок.

Примеры:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();
auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();
auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 

## **FAQ**

**Как добавить математическое уравнение на слайд PowerPoint?**

Для добавления уравнения необходимо создать объект математической формы, который автоматически содержит математическую часть. Затем получить [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) из [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) и добавить в него объекты [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/).

**Можно ли создавать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные выражения, вложивая MathBlock‑и. Каждый математический элемент реализует интерфейс [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), что даёт возможность применять операции (Join, Divide, Enclose и др.) для комбинации элементов в более сложные структуры.

**Как обновить или изменить существующее математическое уравнение?**

Чтобы обновить уравнение, нужно получить доступ к существующим MathBlock‑ам через [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). Затем, используя методы Join, Divide, Enclose и другие, изменить отдельные элементы уравнения. После редактирования сохраните презентацию, чтобы изменения были применены.