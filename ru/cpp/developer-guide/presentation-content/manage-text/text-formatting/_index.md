---
title: Форматирование текста презентации в C++
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/cpp/text-formatting/
keywords:
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- поворот текста
- угол поворота
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
description: "Форматировать и оформлять текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Рассматриваются фоновые цвета, прозрачность, межсимвольный интервал, свойства шрифта, поворот, интервалы абзацев, поведение автоподгонки, привязка текста, табуляция и параметры языка.

Если не указано иначе, в примерах используется [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, а его первый абзац содержит показанный ниже текст. Индексы слайдов и фигур начинаются с нуля. Примеры, где выделены жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и подсветить буквальный текст или совпадения по регулярному выражению, см. [Search and Replace Text](/slides/ru/cpp/search-and-replace-text/).

## **Установка фонового цвета текста**

Используйте [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) для установки цвета подсветки по умолчанию для абзаца или используйте [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) для отдельных частей текста.

В следующем примере задаётся светло‑серая подсветка как значение по умолчанию для первого абзаца. Явные цвета подсветки для отдельных частей имеют приоритет над этим значением по умолчанию:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// Установить цвет подсветки для всего абзаца.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже приведён пример кода, демонстрирующий, как установить фоновый цвет для **частей текста с жирным шрифтом**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Установить цвет подсветки для части текста.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Серые части текста](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_alignment/) для установки выравнивания абзаца внутри текстовой рамки. Значение может быть «center», «left», «right», «justify» и т.д.

В следующем примере кода показано выравнивание абзаца по **центру**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Установить выравнивание абзаца по центру.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Выравненный абзац](aligned_paragraph.png)

## **Установка прозрачности текста**

Прозрачность текста управляется альфа‑компонентой цвета, задаваемой через [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/get_fillformat/). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже пример кода, показывающий, как применить прозрачность к **всему абзацу**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Установить цвет заливки текста в прозрачный цвет.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **частям текста с жирным шрифтом**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Установить прозрачность части текста.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Прозрачные части текста](transparent_text_portions.png)

## **Установка межсимвольного интервала текста**

Используйте [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_spacing/) для увеличения или уменьшения расстояния между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сужают текст.

Ниже приведён C++‑код, показывающий, как увеличить межсимвольный интервал в **полном абзаце**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Увеличить межсимвольный интервал.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже демонстрирует увеличение межсимвольного интервала в **частях текста с жирным шрифтом**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
        portionFormat->set_Spacing(3.0f); // Увеличить межсимвольный интервал.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Межсимвольный интервал в частях текста](character_spacing_in_text_portions.png)

### **Отключение кернинга для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит немного плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint игнорирует данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и параметр кернинга включён в настройках PowerPoint.

Чтобы привести вывод к виду PowerPoint, можно отключить кернинг для частей текста, использующих затронутый шрифт. Используйте [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) и задайте значение, превышающее реальный размер шрифта. В этом примере требуется файл «presentation.pptx» с текстовым полем в качестве первой фигуры на первом слайде. Пример проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кернинг для соответствующих частей текста, размер шрифта которых меньше 100 пунктов:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto textFormat = portionFormat->GetEffective();
        auto latinFont = textFormat->get_LatinFont();
        auto eastAsianFont = textFormat->get_EastAsianFont();
        auto complexScriptFont = textFormat->get_ComplexScriptFont();

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

Для текста ниже порога это настройка предотвращает кернинг и может помочь согласовать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, на которые влияет данное поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) или для отдельных частей через [IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/).

В следующем примере задаётся шрифт по умолчанию для первого абзаца: Times New Roman 12 пунктов, жирный, курсив и пунктирное подчёркивание. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Установить свойства шрифта для абзаца.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Свойства шрифта абзаца](font_properties_for_paragraph.png)

Следующий пример применяет Times New Roman 13 пунктов, курсив и пунктирное подчёркивание к частям текста, эффективное форматирование которых жирное:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Установить свойства шрифта для части текста.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Свойства шрифта частей текста](font_properties_for_text_portions.png)

## **Установка поворота текста**

Используйте [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_textverticaltype/) для задания предопределённой ориентации текста внутри фигуры.

В следующем примере кода задаётся ориентация текста в фигуре [TextVerticalType::Vertical270](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textverticaltype/), которая вращает текст **на 90 градусов против часовой стрелки**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Поворот текста](text_rotation.png)

## **Установка пользовательского поворота для текстовых рамок**

Используйте [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_rotationangle/) для задания произвольного угла поворота для [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/).

Ниже пример кода, вращающего текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Пользовательский поворот текста](custom_text_rotation.png)

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_spacebefore/) и [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_spacewithin/) для управления интервалами абзацев. Методы используются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

В следующем примере задаётся интервал внутри первого абзаца в 200 % от высоты строки (двойной интервал):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Управление разрывом строк**

Правила разрыва строк абзаца полезны в узких блоках текста и в презентациях, где смешаны латинский и восточно‑азиатский текст. Ниже перечислены методы, принадлежащие [IParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/), поэтому они применяются ко всему абзацу:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) управляет правилами разрыва строк для латинского текста. В смешанном тексте изменение этого параметра может также изменить места переноса соседнего восточно‑азиатского текста и знаков препинания.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) управляет правилами разрыва строк для восточно‑азиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_wraptext/), который включает автоматический перенос внутри текстовой рамки. Они влияют на раскладку при переносе, но не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку в абзаце, независимо от доступной ширины.

Ниже приводится самостоятельный пример, создающий узкий блок текста, содержащий китайский и латинский текст. В примере явно задаются оба правила разрыва строк и сохраняется файл «line_breaking.pptx». Чтобы поэкспериментировать с тем или иным правилом, измените значение, передаваемое в соответствующий сеттер, оставив другие настройки неизменными. Пример использует шрифты Arial 24 пт и SimSun, ширину рамки 160 пт и нулевые горизонтальные отступы текстовой рамки. [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_autofittype/) вызывается с [TextAutofitType::None](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textautofittype/), чтобы размеры текста и рамки оставались фиксированными.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 160.0f, 300.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"中文排版测试，PowerPoint 中文演示。");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
auto eastAsianFont = System::MakeObject<FontData>(u"SimSun");
portionFormat->set_EastAsianFont(eastAsianFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_LatinLineBreak(NullableBool::False);
format->set_EastAsianLineBreak(NullableBool::True);

presentation->Save(u"line_breaking.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Управление висячей пунктуацией**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) позволяет допускаемой пунктуации выходить за правый край строки вместо перехода на следующую строку. Применяется к целому абзацу и отличается от висячего отступа.

В следующем самостоятельном примере включается висячая пунктуация в текстовой рамке шириной 100 пт и сохраняется файл «hanging_punctuation.pptx». При шрифте Arial 24 пт и нулевых горизонтальных отступах конечная точка остаётся после слова «sentence» и выходит за правый край текста. Чтобы сравнить, передайте в сеттер [NullableBool::False](https://reference.aspose.com/slides/ru/cpp/aspose.slides/nullablebool/): при этих настройках точка будет находиться на отдельной строке. Перенос включён, а автоподгонка отключена, чтобы ширина оставалась фиксированной.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 200.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"Simple text, next sentence.");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_HangingPunctuation(NullableBool::True);

presentation->Save(u"hanging_punctuation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Не каждая пунктуация может «висеть». Видимый результат зависит от шрифта и раскладки: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать визуальную разницу.

## **Установка типа автоподгонки для текстовых рамок**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_autofittype/) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за пределы или автоматически менять размер фигуры. В следующем примере конфигурируется фигура так, чтобы она изменялась в размере под текст, и результат сохраняется в файл «autofit_type.pptx».

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняется ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/cpp/manage-paragraph/). Само по себе количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установка привязки текстовых рамок**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframeformat/set_anchoringtype/) определяет вертикальное положение текста внутри фигуры, например вверху, по центру или внизу. В следующем примере привязывается текст к нижней части первой фигуры и результат сохраняется в файл «text_anchor.pptx».

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установка табуляции текста**

Используйте [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) и [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/get_tabs/) для настройки табуляций в абзаце. В следующем примере задаётся стандартный интервал табуляции 100 пунктов и добавляется левая табуляция на позиции 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Табуляции в абзаце](paragraph_tabs.png)

## **Установка языка проверки правописания**

Aspose.Slides предоставляет [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_languageid/), позволяющий задать язык проверки правописания для части текста. Язык проверки определяет, какие правила орфографии и грамматики будут применяться в PowerPoint.

В следующем примере требуется файл «presentation.pptx» с текстовым полем в качестве первой фигуры на первом слайде и как минимум один абзац. Пример заменяет содержимое первого абзаца на «1。», задаёт шрифт SimSun и назначает язык проверки «Упрощённый китайский» (`zh-CN`). Результат сохраняется в файл «proofing_language.pptx»:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// Установить язык проверки в упрощенный китайский.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установка языка по умолчанию**

Используйте [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) для задания языка текста по умолчанию при загрузке или создании презентации. В следующем примере создаётся презентация с американским английским в качестве языка текста по умолчанию, добавляется текстовое поле и выводится `en-US` для первой части текста.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Добавить новую прямоугольную форму с текстом.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Проверить язык первой части текста.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Установка стиля текста по умолчанию**

Чтобы задать форматирование текста по умолчанию на уровне презентации, используйте [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

В следующем примере задаётся шрифт 14 пунктов, жирный, в качестве стиля по умолчанию для абзацев верхнего уровня новой презентации, после чего она сохраняется в файл «default_text_style.pptx». Текст может наследовать эти значения, если более специфическое форматирование их не переопределит.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// Получить формат абзаца верхнего уровня.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Извлечение текста с эффектом «Все заглавные»**

В PowerPoint применение эффекта шрифта **All Caps** делает текст заглавным на слайде, даже если он изначально был введён строчными буквами. При получении такой части текста через Aspose.Slides библиотека возвращает текст именно в том виде, в каком он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textcaptype/) и при значении [TextCapType::All](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textcaptype/) преобразуйте возвращённую строку в верхний регистр.

В примере требуется файл «sample2.pptx» с текстовым полем в качестве первой фигуры на первом слайде. Первая часть первого абзаца содержит «Hello, Aspose!» с применённым эффектом All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Ниже пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
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

Чтобы изменить текст в таблице на слайде, используйте [ITable](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itable/). Переберите ячейки и обновляйте каждую ячейку через [ICell::get_TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/get_textframe/) и форматирование абзацев через [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Установите [IFillFormat::set_FillType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifillformat/set_filltype/) в значение [FillType::Gradient](https://reference.aspose.com/slides/ru/cpp/aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.