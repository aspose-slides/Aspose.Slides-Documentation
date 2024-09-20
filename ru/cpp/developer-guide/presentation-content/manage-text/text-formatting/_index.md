---
title: Форматирование текста
type: docs
weight: 50
url: /cpp/text-formatting/
keywords:
- выделить текст
- регулярное выражение
- выравнивание текстовых абзацев
- прозрачность текста
- свойства шрифта абзаца
- семейство шрифтов
- вращение текста
- пользовательский угол вращения
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- якорь текстовой рамки
- табуляция текста
- стиль текста по умолчанию
- C++
- Aspose.Slides для .C++
description: "Управление и изменение свойств текста и текстовых рамок в C++"
---

## **Выделение текста**
В классах ITextFrame и TextFrame был добавлен новый метод HighlightText. Он позволяет выделять часть текста на фоне, используя образец текста, аналогично инструменту цвета выделения текста в PowerPoint 2019.

Ниже приведен фрагмент кода, демонстрирующий, как использовать эту функцию:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose предоставляет простой, [бесплатный онлайн-сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Выделение текста с использованием регулярного выражения**
В классах ITextFrame и TextFrame был добавлен новый метод HighlightRegex. Он позволяет выделять часть текста на фоне с использованием регулярных выражений, аналогично инструменту цвета выделения текста в PowerPoint 2019.

Ниже приведен фрагмент кода, демонстрирующий, как использовать эту функцию:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Установка фона текста**
Aspose.Slides позволяет вам указать предпочитаемый цвет фона для текста.

Этот код на C++ показывает, как установить цвет фона для всего текста:

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Черный");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Красный ");

    auto portion3 = System::MakeObject<Portion>(u"Черный");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));
    auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    for (auto&& portion : portions)
    {
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Blue());
    }
    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```

Этот код на C++ показывает, как установить цвет фона только для части текста:

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Черный");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Красный ");

    auto portion3 = System::MakeObject<Portion>(u"Черный");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));

	auto predicate = [](System::SharedPtr<IPortion> portion) -> bool {
        return portion->get_Text().Contains(u"Красный");
	};

	auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    System::SharedPtr<IPortion> redPortion;
	for (auto&& portion : portions)
        if (predicate(portion))
            redPortion = portion;

    redPortion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Red());

    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```

## **Выравнивание текстового абзаца**
Форматирование текста является одним из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides для C++ поддерживает добавление текста на слайды, но в этой теме мы увидим, как можно контролировать выравнивание текстовых абзацев на слайде. Пожалуйста, выполните следующие шаги, чтобы выровнять текстовые абзацы с использованием Aspose.Slides для C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к фигурам-заместителям на слайде и приведите их к типу AutoShape.
4. Получите абзац (который нужно выровнять) из TextFrame, доступного через AutoShape.
5. Выровняйте абзац. Абзац можно выровнять по правому краю, левому, центру и по ширине.
6. Запишите измененную презентацию как файл PPTX.

Имплементация вышеперечисленных шагов представлена ниже.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Установка прозрачности для текста**
Эта статья демонстрирует, как установить свойство прозрачности для любой текстовой фигуры с использованием Aspose.Slides. Чтобы установить прозрачность текста, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Запишите презентацию как файл PPTX.

Имплементация вышеперечисленных шагов представлена ниже.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Установка межбуквенного интервала для текста**
Aspose.Slides позволяет вам устанавливать расстояние между буквами в текстовом блоке. Таким образом, вы можете регулировать визуальную плотность строки или блока текста, расширяя или сжимая промежутки между символами.

Этот код на C++ показывает, как расширить промежуток для одной строки текста и сжать промежуток для другой строки:

```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // расширить
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // сжать

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Управление свойствами шрифта абзаца**
Презентации обычно содержат как текст, так и изображения. Текст можно форматировать различными способами, либо чтобы выделить конкретные разделы и слова, либо чтобы соответствовать корпоративным стилям. Форматирование текста помогает пользователям разнообразить внешний вид содержимого презентации. Эта статья показывает, как использовать Aspose.Slides для C++, чтобы настроить свойства шрифта абзацев текста на слайдах. Для управления свойствами шрифта абзаца с помощью Aspose.Slides для C++:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к фигурным заместителям на слайде и приведите их к типу AutoShape.
1. Получите абзац из TextFrame, доступного через AutoShape.
1. Выровняйте абзац по ширине.
1. Получите доступ к текстовой порции абзаца.
1. Определите шрифт с помощью FontData и установите шрифт текстовой порции соответственно.
   1. Установите шрифт как полужирный.
   1. Установите шрифт как курсивный.
1. Установите цвет шрифта с помощью FillFormat, доступного через объект Portion.
1. Запишите измененную презентацию в файл PPTX.

Имплементация вышеперечисленных шагов представлена ниже. Она берет неоформленную презентацию и форматирует шрифты на одном из слайдов.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **Управление семейством шрифтов текста**
Порция используется для хранения текста с аналогичным стилем форматирования в абзаце. Эта статья показывает, как использовать Aspose.Slides для C++, чтобы создать текстовое поле с некоторым текстом, а затем определить конкретный шрифт и различные другие свойства из категории семейства шрифтов. Чтобы создать текстовое поле и установить свойства шрифта текста в нём:

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Rectangle на слайд.
4. Удалите стиль заливки, связанный с AutoShape.
5. Получите доступ к TextFrame AutoShape.
6. Добавьте текст в TextFrame.
7. Получите доступ к объекту Portion, связанному с TextFrame.
8. Определите шрифт, который будет использоваться для порции.
9. Установите другие свойства шрифта, такие как полужирный, курсивный, подчеркнутый, цвет и высота, используя соответствующие свойства, предоставленные объектом Portion.
10. Запишите измененную презентацию как файл PPTX.

Имплементация вышеперечисленных шагов представлена ниже.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **Установка размера шрифта для текста**
Aspose.Slides позволяет вам выбрать предпочитаемй размер шрифта для существующего текста в абзаце и других текстов, которые могут быть добавлены в абзац позже.

Этот код на C++ показывает, как установить размер шрифта для текстов, содержащихся в абзаце:

```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Получает первую фигуру, например.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // Получает первый абзац, например.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // Устанавливает размер шрифта по умолчанию на 20 пт для всех текстовых порций в абзаце.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // Устанавливает размер шрифта на 20 пт для текущих текстовых порций в абзаце.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Установка вращения текста**
Aspose.Slides для C++ позволяет разработчикам вращать текст. Текст можно настроить таким образом, чтобы он отображался горизонтально, вертикально, вертикально270, WordArtVertical, EastAsianVertical, MongolianVertical или WordArtVerticalRightToLeft. Чтобы повернуть текст в любой TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к TextFrame.
5. Поверните текст.
6. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **Вкладки и EffectiveTabs в презентации**
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.
- Коллекция EffectiveTabs включает все вкладки (из коллекции Tabs и стандартные вкладки).
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между стандартными вкладками (3 и 4 в нашем примере).
- EffectiveTabs.GetTabByIndex(index) с index = 0 вернет первую явную вкладку (Положение = 731), index = 1 - вторую вкладку (Положение = 1241). Если вы попытаетесь получить следующую вкладку с index = 2, она вернет первую стандартную вкладку (Положение = 1470) и т.д.
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, у вас есть текст: "Helloworld!". Чтобы отобразить этот текст, вы должны знать, с какого места начинать рисовать "world!". Сначала вам нужно рассчитать длину "Hello" в пикселях и вызвать GetTabAfterPosition с этим значением. Вы получите следующую позицию табуляции для отрисовки "world!".

## **Межстрочный интервал абзаца**
Aspose.Slides предоставляет свойства в рамках `ParagraphFormat` — `SpaceAfter`, `SpaceBefore` и `SpaceWithin` — которые позволяют вам управлять межстрочным интервалом для абзаца. Три свойства используются следующим образом:

* Чтобы указать межстрочный интервал для абзаца в процентах, используйте положительное значение.
* Чтобы указать межстрочный интервал для абзаца в пунктах, используйте отрицательное значение.

Например, вы можете применить межстрочный интервал в 16 пунктов для абзаца, установив свойство `SpaceBefore` в -16.

Вот как вы можете указать межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с текстом в нём.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к TextFrame.
4. Получите доступ к абзацу.
5. Установите свойства абзаца.
6. Сохраните презентацию.

Этот код на C++ показывает, как указать межстрочный интервал для абзаца:

```cpp
// Путь к каталогу документов.
System::String dataDir = GetDataPath();

// Создать экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Получите ссылку на слайд по его индексу
auto sld = presentation->get_Slides()->idx_get(0);

// Получите доступ к TextFrame
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Получите доступ к абзацу
auto para = tf1->get_Paragraphs()->idx_get(0);

// Установите свойства абзаца
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Сохраните презентацию
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```

## **Установка свойства AutofitType текстовой рамки**
В этой теме мы рассмотрим различные свойства форматирования текстовой рамки. Эта статья охватывает, как установить свойство AutofitType текстовой рамки, якорь текста и вращение текста в презентации. Aspose.Slides для C++ позволяет разработчикам устанавливать свойство AutofitType для любой текстовой рамки. AutofitType может быть установлен на Normal или Shape. Если установлен на Normal, то форма останется прежней, в то время как текст будет отрегулирован без изменения самой формы, в то время как если свойство AutofitType установлено на Shape, то форма будет изменена таким образом, чтобы в ней содержался только требуемый текст. Чтобы установить свойство AutofitType текстовой рамки, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к TextFrame.
5. Установите AutofitType для TextFrame.
6. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **Установка якоря текстовой рамки**
Aspose.Slides для C++ позволяет разработчикам устанавливать якорь для любой текстовой рамки. TextAnchorType указывает, где размещен этот текст в форме. TextAnchorType может быть установлен на Top, Center, Bottom, Justified или Distributed. Чтобы установить якорь для любой текстовой рамки, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Получите доступ к TextFrame.
5. Установите TextAnchorType для TextFrame.
6. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **Установка пользовательского угла вращения для текстовой рамки**
Aspose.Slides для C++ теперь поддерживает установку пользовательского угла вращения для текстовой рамки. В этой теме мы увидим пример, как установить свойство RotationAngle в Aspose.Slides. Новое свойство RotationAngle было добавлено в интерфейсы IChartTextBlockFormat и ITextFrameFormat, позволяющее установить пользовательский угол вращения для текстовой рамки. Чтобы установить свойство RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
2. Добавьте диаграмму на слайд.
3. Установите свойство RotationAngle.
4. Запишите презентацию как файл PPTX.

В приведённом ниже примере мы устанавливаем свойство RotationAngle.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **Установка языка проверки**
Aspose.Slides предоставляет свойство [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (предоставленное классом [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)), которое позволяет вам установить язык проверки для документа PowerPoint. Язык проверки — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот код на C++ показывает, как установить язык проверки для PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN"); // установите идентификатор языка проверки

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Установка языка по умолчанию**
Этот код на C++ показывает, как установить язык по умолчанию для всей презентации PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Добавляет новую фигуру прямоугольной формы с текстом
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"Новый текст");

// Проверка языка первой порции
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Установка стиля текста по умолчанию**
Если вам нужно применить одно и то же форматирование текста по умолчанию ко всем текстовым элементам презентации сразу, вы можете использовать метод `get_DefaultTextStyle` из интерфейса [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) и установить предпочитаемое форматирование. Пример кода ниже показывает, как установить шрифт по умолчанию (14 пт) для текста на всех слайдах новой презентации.

```c++
auto presentation = MakeObject<Presentation>();

// Получите формат абзаца верхнего уровня.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```