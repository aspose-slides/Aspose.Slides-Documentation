---
title: Добавить математические уравнения в презентации PowerPoint на C++
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
- C++
- Aspose.Slides
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides для C++, поддерживая OMML, средства форматирования и понятные примеры кода на C++."
---
## **Обзор**

PowerPoint сохраняет уравнения в формате Office Math Markup Language (OMML). С помощью Aspose.Slides для C++ вы можете программно создавать такой же тип математического контента: дроби, радикалы, функции, пределы, N‑ary‑операторы, матрицы, массивы и отформатированные математические блоки.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результат — редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создает этот математический текст с помощью трех основных объектов:

- Геометрический объект Math, создаваемый с помощью [AddMathShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapecollection/), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathportion/) хранит математическое содержимое внутри текстового фрейма фигуры.
- [MathParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathematicaltext/) и «чистые» методы из [IMathElement](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/) для сокращения и упрощения кода.

Для сценариев экспорта MathML смотрите [Export Math Equations from Presentations in C++](/slides/ru/cpp/exporting-math-equations/).

## **Создание уравнения**

В этом примере создаётся математическая фигура и добавляется теорема Пифагора:

![Уравнение c² = a² + b²](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` создает фигуру, уже содержащую математический абзац. Получите первый `MathPortion`, возьмите его `MathParagraph` и добавьте в него математические блоки или элементы.
{{% /alert %}}

## **Добавление дробей**

Используйте `Divide` для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathfractiontypes/).

![Наклоненная математическая дробь, показывающая 1, делённое на x](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Для сложенной (stacked) дроби используйте `MathFractionTypes::Bar`:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Добавление радикалов**

Используйте `Radical` для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![Выражение n‑го корня с x под радикалом](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Добавление функций и пределов**

Используйте `AsArgumentOfFunction` или `Function` для функций вроде `sin(x)`, `log(x)` или пользовательских имен функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathlimit/) или используйте `SetLowerLimit`.

![Предел x, когда x стремится к бесконечности](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Для пользовательского имени функции сделайте имя функции текущим элементом:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **Добавление N‑ary операторов и интегралов**

Используйте `Nary` для сумм, объединений, пересечений и других крупных операторов. Используйте `Integral` для интегралов. Оба метода позволяют задавать нижние и верхние пределы.

![Суммирование с нижними и верхними пределами](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

N‑ary‑операторы предназначены для крупных операторов с необязательными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как `MathematicalText` и объединяются в выражении.

Для интеграла используйте `Integral`:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Добавление матриц**

Используйте [MathMatrix](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому заключайте матрицу в круглые, квадратные или фигурные скобки при необходимости.

![Матрица из двух строк с одной пустой ячейкой](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Добавление массивов уравнений**

Используйте `ToMathArray`, когда нужны выровненные уравнения или вертикальная стекация выражений.

![Вертикальный массив уравнений с x над y](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Добавление тригонометрических функций**

Используйте `AsArgumentOfFunction`, когда аргумент является текущим элементом и имя функции известно.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Добавление индексов и степеней**

Используйте вспомогательные функции для нижних и верхних индексов. Когда индексы должны располагаться слева от основания, используйте `SetSubSuperscriptOnTheLeft`.

![Заглавная Y с индексом 1 слева и степенью n справа](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Добавление разделителей**

Используйте `Enclose`, чтобы поместить выражение в разделители. Также можно задать символ‑разделитель для выражений, содержащих несколько элементов.

![Выражение с разделителями, содержащие x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Добавление рамки**

Используйте `ToBorderBox`, когда уравнение должно быть заключено в рамку.

![Уравнение в рамке, показывающее a² = b² + c²](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Группировка терминов**

Используйте `Group`, чтобы разместить символ группировки над или под выражением. Добавьте предел, чтобы пометить сгруппированные термины.

![Выражение x + y, сгруппированное с подписью любой текст снизу](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Форматирование математических элементов**

Используйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, `Overbar` ставит черту над элементом.

![Математическое выражение ABC с надчеркиванием](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Объединение элементов | [IMathElement.Join](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/join/) |
| Создание дробей | [IMathElement.Divide](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Добавление надстрочного или нижнего индекса | [SetSuperscript](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Добавление функций | [Function](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Добавление радикалов | [IMathElement.Radical](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Добавление пределов | [SetLowerLimit](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Добавление скриптов слева | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Добавление сумм и интегралов | [Nary](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathmatrix/) |
| Добавление массивов уравнений | [ToMathArray](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Добавление разделителей | [Enclose](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Добавление черт и рамок | [Overbar](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Группировка терминов | [Group](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математическая информация PowerPoint?**

Да. При сохранении в формате PPTX Aspose.Slides записывает уравнение как редактируемый объект Office Math.

**Могу ли я экспортировать уравнения в LaTeX?**

Aspose.Slides экспортирует математические уравнения в MathML. Если вам нужен LaTeX, сначала экспортируйте в MathML, а затем преобразуйте MathML с помощью инструмента, поддерживающего нужный диалект LaTeX.