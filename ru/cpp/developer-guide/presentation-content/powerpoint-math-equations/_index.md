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
В PowerPoint можно написать математическое уравнение или формулу и отобразить её в презентации. Для этого в PowerPoint представлены различные математические символы, которые можно добавить в текст или уравнение. Для создания сложных формул, таких как:

- Дробь
- Радикал
- Функция
- Пределы и логарифмические функции
- N-арные операции
- Матрица
- Большие операторы
- Функции sin, cos

используется конструктор математических уравнений в PowerPoint.

Для добавления математического уравнения в PowerPoint используется меню *Insert → Equation*:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Это создаёт математический текст в XML, который может быть отображён в PowerPoint следующим образом:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint поддерживает множество математических символов для создания уравнений. Однако создание сложных уравнений в PowerPoint часто не даёт хорошего и профессионального результата. Пользователи, которым часто требуется создавать математические презентации, прибегают к сторонним решениям для получения красиво оформленных формул.

Используя [**Aspose.Slide API**](https://products.aspose.com/slides/cpp/), вы можете программно работать с математическими уравнениями в презентациях PowerPoint на C++. Создавать новые математические выражения или редактировать уже созданные. Экспорт математических структур в изображения также поддерживается частично.


## **Как создать математическое уравнение**
Математические элементы используются для построения любых математических конструкций любой степени вложенности. Последовательность математических элементов образует математический блок, представленный классом [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/). Класс [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/) по сути представляет отдельное математическое выражение, формулу или уравнение. Класс [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) — это математическая часть, используемая для хранения математического текста (не путать с [**Portion**](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)). Класс [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) позволяет управлять набором математических блоков. Указанные классы являются ключом к работе с математическими уравнениями PowerPoint через Aspose.Slides API.

Рассмотрим, как создать следующее математическое уравнение с помощью Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Чтобы добавить математическое выражение на слайд, сначала добавьте фигуру, в которой будет содержаться математический текст:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
```


После создания фигура уже содержит один абзац с математической частью по умолчанию. Класс [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) — это часть, содержащая математический текст. Чтобы получить доступ к содержимому внутри [**MathPortion**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/), обратитесь к переменной [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/):

``` cpp
 auto mathParagraph = (System::AsCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
```


Класс [**MathParagraph**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) позволяет читать, добавлять, редактировать и удалять математические блоки ([**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)), состоящие из комбинации математических элементов. Например, создать дробь и разместить её в презентации:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
```


Каждый математический элемент представлен классом, реализующим интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/). Этот интерфейс предоставляет множество методов для простого создания математических выражений. Можно создать достаточно сложное выражение одной строкой кода. Например, теорема Пифагора будет выглядеть так:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
```


Операции интерфейса [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/) реализованы во всех типах элементов, включая [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/).

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

Существует множество типов математических элементов, которые можно использовать для построения математического блока. Каждый такой элемент может быть включён (агрегирован) в другой элемент. Таким образом, элементы выступают контейнерами для других, образуя древовидную структуру. Самый простой тип элемента не содержит других элементов математического текста.

Каждый тип элемента реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), позволяя использовать общий набор математических операций для разных типов элементов.
### **Класс MathematicalText**
Класс [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/) представляет математический текст — базовый элемент всех математических конструкций. Математический текст может представлять операнды и операторы, переменные и любой линейный текст.

Пример: 𝑎=𝑏+𝑐
### **Класс MathFraction**
Класс [**MathFraction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfraction/) определяет объект дроби, состоящий из числителя и знаменателя, разделённых чертой. Черта может быть горизонтальной или диагональной в зависимости от свойств дроби. Объект дроби также используется для представления функции стека, размещающей один элемент над другим без черты.

Пример:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **Класс MathRadical**
Класс [**MathRadical**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathradical/) определяет радикальную функцию (корень), состоящую из основания и, при желании, степени.

Пример:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **Класс MathFunction**
Класс [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) определяет функцию от аргумента. Содержит методы: [get_Name()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_name/) — имя функции и [get_Base()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/get_base/) — аргумент функции.

Пример:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **Класс MathNaryOperator**
Класс [**MathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperator/) определяет N‑арный математический объект, такой как сумма или интеграл. Он состоит из оператора, основания (или операнда) и опциональных верхних и нижних пределов. Примеры N‑арных операторов: сумма, объединение, пересечение, интеграл.

Этот класс не включает простые операторы вроде сложения или вычитания; они представлены одним текстовым элементом [MathematicalText](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/).

Пример:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **Класс MathLimit**
Класс [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/) создаёт верхний или нижний предел. Он состоит из текста на базовой линии и уменьшенного текста непосредственно над или под ним. Этот элемент не включает слово “lim”, но позволяет разместить текст сверху или снизу выражения. Таким образом, выражение

![todo:image_alt_text](powerpoint-math-equations_8.png)

создаётся комбинацией элементов [**MathFunction**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) и [**MathLimit**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/):

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
```


### **Классы MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Перечисленные классы задают нижний или верхний индекс. Можно одновременно задавать и подпись, и надпись слева или справа от аргумента, но одиночный нижний или верхний индекс поддерживается только справа. Класс [MathSubscriptElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathsubscriptelement/) может также использоваться для задания степени числа.

Пример:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **Класс MathMatrix**
Класс [**MathMatrix**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathmatrix/) определяет объект матрицы, состоящий из дочерних элементов, расположенных в одной или нескольких строках и столбцах. Важно отметить, что у матриц нет встроенных разделителей. Чтобы поместить матрицу в скобки, следует использовать объект‑разделитель [**IMathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathdelimiter/). Null‑аргументы можно использовать для создания пробелов в матрице.

Пример:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **Класс MathArray**
Класс [**MathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/matharray/) определяет вертикальный массив уравнений или любых математических объектов.

Пример:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Форматирование математических элементов**
- Класс [**MathBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathborderbox/) рисует прямоугольную или иную рамку вокруг [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/).  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Класс [**MathBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbox/) определяет логическое обрамление (упаковку) математического элемента. Например, объект‑коробка может выступать в роли эмулятора оператора с или без точки выравнивания, служить разрывом строки или группировать элементы, чтобы запретить разрывы внутри. Например, оператор “==” следует упаковать, чтобы предотвратить разрыв строки.
- Класс [**MathDelimiter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathdelimiter/) определяет объект‑разделитель, состоящий из открывающего и закрывающего символов (скобки, фигурные скобки, квадратные скобки, вертикальные черты) и одного или нескольких математических элементов внутри, разделённых указанным символом. Примеры: (𝑥2); [𝑥2|𝑦2].  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Класс [**MathAccent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathaccent/) определяет функцию акцента, состоящую из основания и комбинируемого диакритического знака.  
  Пример: 𝑎́.

- Класс [**MathBar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathbar/) определяет функцию черты, состоящую из базового аргумента и надчерты или подчёркивания.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Класс [**MathGroupingCharacter**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathgroupingcharacter/) определяет группирующий символ над или под выражением, обычно для подчёркивания взаимосвязей между элементами.  
  Пример: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Математические операции**
Каждый математический элемент и математическое выражение (через [**MathBlock**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) реализует интерфейс [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/). Он позволяет применять операции к существующей структуре и формировать более сложные математические выражения. Все операции имеют два набора параметров: либо [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), либо строку. При использовании строковые аргументы автоматически преобразуются в экземпляры [**MathematicalText**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathematicaltext/). Ниже перечислены доступные в Aspose.Slides математические операции.
### **Метод Join**
- [Join(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemstring-method)
- [Join(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/join/#imathelementjoinsystemsharedptrimathelement-method)

Объединяет математический элемент и формирует математический блок. Пример:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
```


### **Метод Divide**
- [Divide(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-method)
- [Divide(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-method)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemstring-mathfractiontypes-method)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/divide/#imathelementdividesystemsharedptrimathelement-mathfractiontypes-method)

Создаёт дробь указанного типа с текущим числителем и заданным знаменателем. Пример:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 
### **Метод Enclose**
- [Enclose()](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclose-method)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/enclose/#imathelementenclosechar16_t-char16_t-method)

Оборачивает элемент в указанные символы, такие как скобки или другие символы.

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
- [Function(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemstring-method)
- [Function(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/function/#imathelementfunctionsystemsharedptrimathelement-method)

Создаёт функцию от аргумента, используя текущий объект в качестве имени функции.

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
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemstring-method)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionsystemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsofoneargument-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemsharedptrimathelement-method)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/#imathelementasargumentoffunctionmathfunctionsoftwoarguments-systemstring-method)

Принимает указанный метод функции, используя текущий объект в качестве аргумента. Можно:

- указать строку как имя функции, например “cos”;
- выбрать одно из предопределённых значений перечислений [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunctionsofoneargument/) или [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunctionsoftwoarguments/), например **MathFunctionsOfOneArgument.ArcSin**;
- передать экземпляр [**IMathElement**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/).

Пример:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");
``` 
### **Методы SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [SetSubscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemstring-method)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubscript/#imathelementsetsubscriptsystemsharedptrimathelement-method)
- [SetSuperscript(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemstring-method)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsuperscript/#imathelementsetsuperscriptsystemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheright/#imathelementsetsubsuperscriptontherightsystemsharedptrimathelement-systemsharedptrimathelement-method)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemstring-systemstring-method)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/#imathelementsetsubsuperscriptontheleftsystemsharedptrimathelement-systemsharedptrimathelement-method)

Устанавливает нижний и верхний индексы. Можно задать их одновременно слева или справа от аргумента, но одиночный нижний или верхний индекс поддерживается только справа. **Superscript** также может использоваться для задания степени числа.

Пример:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 
### **Метод Radical**
- [Radical(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemstring-method)
- [Radical(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/radical/#imathelementradicalsystemsharedptrimathelement-method)

Задаёт радикал (корень) указанной степени от аргумента.

Пример:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 
### **Методы SetUpperLimit и SetLowerLimit**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemstring-method)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setupperlimit/#imathelementsetupperlimitsystemsharedptrimathelement-method)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemstring-method)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/#imathelementsetlowerlimitsystemsharedptrimathelement-method)

Задаёт верхний или нижний предел. Здесь верхний и нижний просто указывают расположение аргумента относительно основания.

Рассмотрим выражение:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Такое выражение можно создать комбинацией классов [MathFunction](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathfunction/) и [MathLimit](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathlimit/), а также операций интерфейса [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/):

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 
### **Методы Nary и Integral**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/nary/#imathelementnarymathnaryoperatortypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-method)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-method)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemsharedptrimathelement-systemsharedptrimathelement-mathlimitlocations-method)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/integral/#imathelementintegralmathintegraltypes-systemstring-systemstring-mathlimitlocations-method)

Оба метода **Nary** и **Integral** создают и возвращают N‑арный оператор типа [**IMathNaryOperator**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathnaryoperator/). В методе Nary перечисление [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathnaryoperatortypes/) определяет тип оператора: сумма, объединение и т.д., но не включает интегралы. В методе Integral используется специализированный оператор интеграла с перечислением [**MathIntegralTypes**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathintegraltypes/).

Пример:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 
### **Метод ToMathArray**
[**ToMathArray**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tomatharray/) размещает элементы в вертикальном массиве. Если вызвать эту операцию у экземпляра **MathBlock**, все дочерние элементы будут помещены в возвращаемый массив.

Пример:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 
### **Операции форматирования: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Метод [**Accent**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/accent/) добавляет надстрочный диакритический знак (акцент).
- Методы [**Overbar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/overbar/) и [**Underbar**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/underbar/) добавляют черту сверху или снизу.
- Метод [**Group**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/group/) размещает элементы в группе, используя группирующий символ, например нижнюю фигурную скобку.
- Метод [**ToBorderBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/toborderbox/) помещает элемент в рамку.
- Метод [**ToBox**](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/tobox/) помещает элемент в логическую (не визуальную) коробку.

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

Чтобы добавить уравнение, необходимо создать объект математической фигуры, который автоматически содержит математическую часть. Затем получить объект [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) из [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) и добавить в него объекты [MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/).

**Можно ли создавать сложные вложенные математические выражения?**

Да, Aspose.Slides позволяет создавать сложные выражения, вкладывая MathBlocks. Каждый математический элемент реализует интерфейс [IMathElement](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/imathelement/), что позволяет применять операции (Join, Divide, Enclose и др.) для комбинирования элементов в более сложные структуры.

**Как обновить или изменить существующее математическое уравнение?**

Чтобы обновить уравнение, нужно получить доступ к существующим MathBlocks через [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). Затем с помощью методов Join, Divide, Enclose и других изменить отдельные элементы уравнения. После редактирования сохранить презентацию, чтобы изменения вступили в силу.