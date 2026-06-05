---
title: Форматирование текста презентации в C++
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
- семейство шрифта
- вращение текста
- угол вращения
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- привязка текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Рассматриваются выделение, цвета фона, прозрачность, межсимвольный интервал, свойства шрифта, вращение, интервал между абзацами, поведение автоподгонки, привязка текста, табуляция и настройки языка.

В нижеприведенных примерах мы будем использовать файл с именем "sample.pptx", содержащий один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выделение текста**

Используйте метод [ITextFrame.HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlighttext/) когда необходимо выделить текст, соответствующий определённому образцу внутри текстовой рамки. Метод применяет цвет выделения к совпадающим фрагментам текста и может использоваться вместе с [ITextSearchOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/) для управления способом поиска, например, для совпадения только целых слов.

В приведённом ниже примере кода выделяются все вхождения символов **"try"**, а затем выделяется только полное слово **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Получить первую фигуру с первого слайда.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Выделить слово "try" в фигуре.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Выделить слово "to" в фигуре.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделение текста с использованием регулярных выражений**

Метод [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlightregex/) выделяет совпадения текста, найденные регулярным выражением. В C++ этот API доступен через [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/).

В приведённом ниже примере кода выделяются все слова, содержащие **семь и более символов**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Выделить все слова, содержащие семь и более символов.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Установка цвета фона текста**

Используйте [IParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` для установки цвета выделения по умолчанию для абзаца, либо используйте [IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/)`.HighlightColor` для отдельных текстовых фрагментов.

Следующий пример кода показывает, как установить цвет фона для **всего абзаца**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже приведён пример кода, демонстрирующий установку цвета фона для **текстовых фрагментов с полужирным шрифтом**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Установить цвет выделения для текстового фрагмента.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Серые текстовые фрагменты](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/)`.Alignment` для установки выравнивания абзаца внутри текстовой рамки. Значение может быть центрировано, выровнено по левому, правому краю, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац по **центру**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Установить выравнивание абзаца по центру.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Выравненный абзац](aligned_paragraph.png)

## **Установка прозрачности для текста**

Прозрачность текста контролируется альфа‑компонентой цвета, назначенного [IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/)`.FillFormat`. В примерах ниже `alpha = 50` — значение альфа‑канала ARGB в диапазоне 0‑255, а не процент прозрачности.

Следующий пример кода показывает, как применить прозрачность к **всему абзацу**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Set the fill color of the text to transparent color.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **текстовым фрагментам с полужирным шрифтом**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Установить прозрачность текстового фрагмента.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установка межсимвольного интервала для текста**

Используйте [IBasePortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/)`.Spacing` для увеличения или уменьшения интервала между символами в текстовом блоке.

Следующий код C++ показывает, как увеличить межсимвольный интервал в **всём абзаце**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как увеличить межсимвольный интервал в **текстовых фрагментах с полужирным шрифтом**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Межсимвольный интервал в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключение кернинга для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит немного плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint игнорирует данные кернинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать результат ближе к PowerPoint в таких случаях, можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` в значение, значительно превышающее фактический размер шрифта:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Эта настройка предотвращает применение кернинга к соответствующим текстовым фрагментам и помогает согласовать визуальный вывод Aspose.Slides с отображением PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` или на отдельных фрагментах через [IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/)`.

Следующий код задаёт шрифт и стиль текста для **всего абзаца**: применяется размер шрифта, полужирный, курсив, пунктирное подчёркивание и шрифт Times New Roman ко всем фрагментам абзаца.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Установить свойства шрифта для абзаца.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Ниже пример кода, применяющий аналогичные свойства к **текстовым фрагментам с полужирным шрифтом**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Установить свойства шрифта для текстового фрагмента.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Свойства шрифта для текстовых фрагментов](font_properties_for_text_portions.png)

## **Установка вращения текста**

Используйте [ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` для установки предопределённой ориентации текста внутри фигуры.

Следующий пример кода устанавливает ориентацию текста в фигуре в значение `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Вращение текста](text_rotation.png)

## **Установка пользовательского вращения для текстовых рамок**

Используйте [ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/)`.RotationAngle` для установки пользовательского угла вращения для [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/).

Пример кода ниже вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [IParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore` и `IParagraphFormat.SpaceWithin` для управления интервалами абзацев. Эти свойства используются следующим образом:

* Положительное значение — процент от высоты строки.
* Отрицательное значение — интервал в пунктах.

Следующий пример кода показывает, как задать межстрочный интервал внутри абзаца:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Межстрочный интервал в абзаце](line_spacing.png)

## **Установка типа автоподгонки для текстовых рамок**

[ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/)`.AutofitType` определяет, как текст будет вести себя, когда превышает границы своего контейнера. Используйте его для контроля того, будет ли текст уменьшаться, вырываться за пределы или автоматически изменять размер фигуры.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установка привязки текстовых рамок**

[ITextFrameFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/)`.AnchoringType` определяет, как текст позиционируется вертикально внутри фигуры, например в верхней, средней или нижней части.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установка табуляции текста**

Используйте [IParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` и `IParagraphFormat.Tabs` для настройки табуляций в абзаце.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Табуляция абзаца](paragraph_tabs.png)

## **Установка языка проверки орфографии**

Aspose.Slides предоставляет [IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/)`.LanguageId`, который позволяет задать язык проверки орфографии для текстового фрагмента. Язык проверки определяет, какой язык будет использоваться для проверки правописания и грамматики в PowerPoint.

Следующий пример кода показывает, как задать язык проверки орфографии для текстового фрагмента:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Set the Id of a proofing language.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установка языка по умолчанию**

Используйте [ILoadOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Добавить новую прямоугольную фигуру с текстом.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Проверить язык первого фрагмента.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Установка стиля текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

Следующий пример кода показывает, как задать полужирный шрифт размером 14 pt для всего текста на всех слайдах новой презентации.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Получить формат абзаца верхнего уровня.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Извлечение текста с эффектом All-Caps**

В PowerPoint применение эффекта **All Caps** заставляет текст отображаться заглавными буквами на слайде, даже если он был введён строчными. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы получить отображаемый вариант, проверьте [TextCapType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Предположим, что на первом слайде файла sample2.pptx находится следующий текстовый блок.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
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

Для изменения текста в таблице на слайде используйте [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/). Пройдите по ячейкам и обновите каждую ячейку через [ICell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/)`.TextFrame` и форматирование абзацев через [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте [IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/)`.FillFormat`. Установите [IFillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformat/)`.FillType` в значение [FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/)`.Gradient` и настройте градиентные остановки, направление и прозрачность.