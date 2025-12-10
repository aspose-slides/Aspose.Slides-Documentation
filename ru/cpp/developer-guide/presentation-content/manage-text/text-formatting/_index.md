---
title: Форматирование текста PowerPoint на C++
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/cpp/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовый фрейм
- межстрочный интервал
- свойство автоподгонки
- привязка текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Настройка шрифтов, цветов, выравнивания и прочего."
---

## **Выделение текста**
Новый метод HighlightText добавлен в классы ITextFrame и TextFrame. Он позволяет выделять часть текста фоном, используя образец текста, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже показан фрагмент кода, демонстрирующий использование этой функции:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose предоставляет простой, [бесплатный онлайн‑сервис редактирования PowerPoint](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Выделение текста с помощью регулярных выражений**
Новый метод HighlightRegex добавлен в классы ITextFrame и TextFrame. Он позволяет выделять часть текста фоном, используя регулярное выражение, аналогично инструменту Text Highlight Color в PowerPoint 2019.

Ниже показан фрагмент кода, демонстрирующий использование этой функции:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **Установка цвета фона текста**

Aspose.Slides позволяет указать предпочитаемый цвет фона текста.

Этот C++ код показывает, как установить цвет фона для всего текста:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
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


Этот C++ код показывает, как установить цвет фона только для части текста:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
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
        return portion->get_Text().Contains(u"Red");
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


## **Выравнивание абзацев текста**
Форматирование текста является одним из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides for C++ поддерживает добавление текста на слайды, но в этой теме мы посмотрим, как контролировать выравнивание абзацев текста на слайде. Пожалуйста, выполните следующие шаги для выравнивания абзацев текста с помощью Aspose.Slides for C++ :

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Получите ссылку на слайд, используя его индекс.
3. Доступ к Placeholder‑формам, присутствующим на слайде, и приведение их к типу AutoShape.
4. Получите Paragraph (который нужно выровнять) из TextFrame, предоставляемого AutoShape.
5. Выровняйте Paragraph. Абзац может быть выровнен по правому, левому, центральному и выровненному по ширине (Justify) краю.
6. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Установка прозрачности для текста**
В этой статье показано, как задать свойство прозрачности для любой текстовой фигуры с помощью Aspose.Slides. Чтобы установить прозрачность текста, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Сохраните презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Установка межсимвольного интервала для текста**

Aspose.Slides позволяет задать расстояние между символами в текстовом поле. Таким образом, вы можете регулировать визуальную плотность строки или блока текста, увеличивая или уменьшая интервал между символами.

Этот C++ код показывает, как расширить интервал для одной строки текста и уменьшить интервал для другой строки:
```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // расширить
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // сжать

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```


## **Управление свойствами шрифта текста**

Презентации обычно содержат и текст, и изображения. Текст может быть отформатирован различными способами — для выделения определённых разделов и слов или в соответствии с корпоративными стилями. Форматирование текста помогает пользователям изменить внешний вид содержимого презентации. В этой статье показано, как с помощью Aspose.Slides for C++ настроить свойства шрифта абзацев текста на слайдах. Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides for C++ :

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к Placeholder‑формам на слайде и приведение их к AutoShape.
1. Получите Paragraph из TextFrame, предоставляемого AutoShape.
1. Выравнивайте абзац.
1. Доступ к Portion текста абзаца.
1. Определите шрифт с помощью FontData и соответственно задайте Font для Portion.
   1. Установите шрифт полужирным.
   1. Установите шрифт курсивом.
1. Установите цвет шрифта с помощью FillFormat, предоставляемого объектом Portion.
1. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже. Она берёт пустую презентацию и форматирует шрифты на одном из слайдов.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **Управление семейством шрифтов текста**
Portion используется для хранения текста с единым стилем форматирования в абзаце. В этой статье показано, как с помощью Aspose.Slides for C++ создать текстовое поле с некоторым текстом, а затем задать конкретный шрифт и различные свойства семейства шрифтов. Чтобы создать текстовое поле и задать свойства шрифта текста в нём:

1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Rectangle на слайд.
4. Удалите стиль заливки, связанный с AutoShape.
5. Доступ к TextFrame AutoShape.
6. Добавьте некоторый текст в TextFrame.
7. Доступ к объекту Portion, связанному с TextFrame.
8. Определите шрифт, который будет использоваться для Portion.
9. Установите другие свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства объекта Portion.
10. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **Установка размера шрифта для текста**

Aspose.Slides позволяет выбрать предпочитаемый размер шрифта для существующего текста в абзаце и для других текстов, которые могут быть добавлены в абзац позже.

Этот C++ код показывает, как задать размер шрифта для текста, содержащегося в абзаце:
```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Получает первую форму, например.
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // Получает первый абзац, например.
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // Устанавливает размер шрифта по умолчанию 20 pt для всех текстовых фрагментов в абзаце.
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // Устанавливает размер шрифта 20 pt для текущих текстовых фрагментов в абзаце.
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Установка вращения текста**

Aspose.Slides for C++ позволяет разработчикам вращать текст. Текст может быть установлен как Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical или WordArtVerticalRightToLeft. Чтобы вращать текст любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
2. Доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Доступ к TextFrame.
5. Поверните текст.
6. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **Вкладки и эффективные вкладки в презентации**
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.
- Коллекция EffectiveTabs включает все вкладки (из коллекции Tabs и вкладки по умолчанию).
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно Tabs.Count.
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между вкладками по умолчанию (3 и 4 в нашем примере).
- EffectiveTabs.GetTabByIndex(index) с index = 0 вернёт первую явную вкладку (Position = 731), index = 1 — вторую (Position = 1241). При запросе index = 2 будет возвращена первая вкладка по умолчанию (Position = 1470) и т.д.
- EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, у вас есть текст: "Helloworld!". Чтобы отрисовать такой текст, нужно знать, где начать рисовать "world!". Сначала вычислите длину "Hello" в пикселях и вызовите GetTabAfterPosition с этим значением. Вы получите позицию следующей табуляции для рисования "world!".

## **Межстрочный интервал абзаца**

Aspose.Slides предоставляет свойства в `ParagraphFormat` — `SpaceAfter`, `SpaceBefore` и `SpaceWithin` — которые позволяют управлять межстрочным интервалом абзаца. Эти три свойства используются так:

* Чтобы задать межстрочный интервал в процентах, укажите положительное значение. 
* Чтобы задать межстрочный интервал в пунктах, укажите отрицательное значение.

Например, чтобы применить интервал 16 pt к абзацу, установите свойство `SpaceBefore` в -16.

Так задаётся межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с некоторым текстом.
2. Получите ссылку на слайд через его индекс.
3. Доступ к TextFrame.
4. Доступ к Paragraph.
5. Установите свойства Paragraph.
6. Сохраните презентацию.

Этот C++ код показывает, как задать межстрочный интервал для абзаца:
``` cpp
// Путь к каталогу документов.
System::String dataDir = GetDataPath();

// Создать экземпляр класса Presentation
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Получить ссылку на слайд по его индексу
auto sld = presentation->get_Slides()->idx_get(0);

// Получить доступ к TextFrame
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Получить доступ к Paragraph
auto para = tf1->get_Paragraphs()->idx_get(0);

// Установить свойства Paragraph
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Сохранить презентацию
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **Установка свойства AutofitType для текстового фрейма**
В этой теме мы рассмотрим различные свойства форматирования текстового фрейма. Статья описывает, как установить свойство AutofitType, привязку текста и вращение текста в презентации. Aspose.Slides for C++ позволяет разработчикам задавать свойство AutofitType для любого текстового фрейма. AutofitType может быть установлен в Normal или Shape. При значении Normal форма остаётся прежней, а текст подстраивается без изменения формы, тогда как при значении Shape форма изменяется так, чтобы в неё помещался только необходимый текст. Чтобы установить свойство AutofitType, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
2. Доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Доступ к TextFrame.
5. Установите AutofitType TextFrame.
6. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **Установка привязки (Anchor) текстового фрейма**
Aspose.Slides for C++ позволяет разработчикам задавать привязку любого TextFrame. TextAnchorType указывает, где располагается текст внутри формы. TextAnchorType может быть установлен в Top, Center, Bottom, Justified или Distributed. Чтобы задать привязку любого TextFrame, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation` .
2. Доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Доступ к TextFrame.
5. Установите TextAnchorType TextFrame.
6. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **Установка пользовательского угла вращения для текстового фрейма**
Aspose.Slides for C++ теперь поддерживает установку пользовательского угла вращения для текстового фрейма. В этой теме мы покажем пример того, как задать свойство RotationAngle в Aspose.Slides. Новое свойство RotationAngle добавлено в интерфейсы IChartTextBlockFormat и ITextFrameFormat и позволяет задавать пользовательский угол вращения для текстового фрейма. Чтобы задать свойство RotationAngle, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
2. Добавьте диаграмму на слайд.
3. Установите свойство RotationAngle.
4. Запишите презентацию в файл PPTX.

В приведённом ниже примере задаётся свойство RotationAngle.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **Установка языка проверки правописания**

Aspose.Slides предоставляет свойство [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (предоставляемое классом [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)), позволяющее задать язык проверки правописания для документа PowerPoint. Язык проверки правописания — это язык, для которого проверяются орфография и грамматика в PowerPoint.

Этот C++ код показывает, как задать язык проверки правописания для PowerPoint:
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

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **Установка языка по умолчанию**

Этот C++ код показывает, как задать язык по умолчанию для всей презентации PowerPoint:
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Добавляет новую прямоугольную форму с текстом
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Проверяет язык первой части
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **Установка стиля текста по умолчанию**

Если вам нужно применить одинаковое форматирование текста ко всем элементам текста презентации сразу, вы можете использовать метод `get_DefaultTextStyle` интерфейса [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) и задать предпочтительное форматирование. Пример кода ниже показывает, как задать полужирный шрифт (14 pt) по умолчанию для текста на всех слайдах новой презентации.
```c++
auto presentation = MakeObject<Presentation>();

// Получить формат абзаца верхнего уровня.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Извлечение текста с эффектом All Caps**

В PowerPoint применение эффекта **All Caps** делает текст заглавными буквами на слайде, даже если он был введён строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы обработать это, проверьте [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) — если он указывает `All`, просто преобразуйте возвращённую строку в верхний регистр, чтобы ваш вывод совпадал с тем, что видят пользователи на слайде.

Предположим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:
```cpp
auto presentation = MakeObject<Presentation>(u"sample2.pptx");
auto autoShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```


Вывод:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, необходимо использовать объект [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Можно перебрать все ячейки таблицы и изменить текст в каждой ячейке, получив её текстовый фрейм и свойства формата абзаца внутри каждой ячейки.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте метод `get_FillFormat` в [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/). Установите тип заполнения в `Gradient`, где можно задать начальный и конечный цвета градиента, а также другие свойства, такие как направление и прозрачность, чтобы создать градиентный эффект для текста.