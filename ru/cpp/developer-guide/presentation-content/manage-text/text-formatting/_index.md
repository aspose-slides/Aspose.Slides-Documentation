---
title: Форматировать текст презентации на C++
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/cpp/text-formatting/
keywords:
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- интервал между символами
- свойства шрифта
- семейство шрифта
- вращение текста
- угол вращения
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для C++. Настраивать шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для C++. Она охватывает цвета фона, прозрачность, интервал между символами, свойства шрифта, вращение, интервалы абзацев, поведение автоподгонки, привязку текста, табуляцию и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, и его первый абзац содержит текст, показанный ниже. Как индексы слайдов, так и индексы фигур начинаются с нуля. Примеры, выделяющие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/cpp/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) для установки цвета подсветки по умолчанию для абзаца или [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) для отдельных текстовых частей.

Следующий пример устанавливает светло-серую подсветку по умолчанию для первого абзаца. Явные цвета подсветки у отдельных частей переопределяют это значение по умолчанию:

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

Ниже показан пример кода, демонстрирующий, как установить цвет фона для **текстовых частей с жирным шрифтом**:

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
        // Установить цвет подсветки для текстовой части.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Серые текстовые части](gray_text_portions.png)

## **Выравнивать абзацы текста**

Используйте [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) для установки выравнивания абзаца внутри текстового кадра. Значение может быть «центрировано», «по левому краю», «по правому краю», «по ширине» и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

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

![Выровненный абзац](aligned_paragraph.png)

## **Выравнивать шрифты внутри строки**

Используйте [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) для вертикального выравнивания текстовых частей разного размера шрифта внутри строки. Эта настройка применяется к всему абзацу и управляет выравниванием в каждой его строке.

Следующий самостоятельный пример создает четыре помеченных текстовых поля на одном слайде. Каждый абзац содержит один и тот же текст размером 18, 36 и 54 пункта с разным выравниванием шрифта. Он использует Arial, отключает автоподгонку и перенос, и оставляет текстовые кадры достаточно большими для одной строки.

```cpp
#include <DOM/FontAlignment.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

FontAlignment alignments[] = { FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom };
String labels[] = { u"Baseline", u"Top", u"Center", u"Bottom" };
float fontSizes[] = { 18.0f, 36.0f, 54.0f };
auto font = MakeObject<FontData>(u"Arial");

for (auto i = 0; i < 4; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20 + i * 130, 660, 120);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);

    auto label = textFrame->get_Paragraph(0);
    label->set_Text(labels[i]);
    label->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto labelFormat = label->get_ParagraphFormat()->get_DefaultPortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->set_LatinFont(font);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_FontAlignment(alignments[i]);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto portionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    portionFormat->set_LatinFont(font);
    portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
    portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    for (auto fontSize : fontSizes)
    {
        auto portion = MakeObject<Portion>(u"Ag ");
        portion->get_PortionFormat()->set_FontHeight(fontSize);
        paragraph->get_Portions()->Add(portion);
    }

    textFrame->get_Paragraphs()->Add(paragraph);
}

presentation->Save(u"font_alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Сравнение выравнивания Baseline, Top, Center и Bottom при смешанных размерах шрифтов](font_alignment.png)

Выравнивание шрифта использует метрики шрифта, поэтому видимые границы отдельных букв не обязательно будут точно совпадать. В примере присутствуют заглавная буква и нижний вынос, чтобы продемонстрировать разницу между базовой линией и нижним выравниванием. Доступность шрифтов и их замена, используемые символы и различие в размерах шрифтов влияют на результат. Размеры кадра, отступы, межстрочный интервал, перенос и автоподгонка также влияют на разметку; при сравнении режимов используйте те же шрифты и настройки разметки.

Эта настройка отличается от [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/), который управляет горизонтальным выравниванием абзаца, и [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/), который позиционирует текстовый блок вертикально внутри фигуры. Форматирование надстрочного и подстрочного текста через [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) смещает отдельные части относительно базовой линии вместо установки выравнивания шрифта для строк абзаца.

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, задаваемого через [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/). В приведённых ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Следующий пример кода показывает, как применить прозрачность к **всему абзацу**:

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

Следующий пример кода показывает, как применить прозрачность к **текстовым частям с жирным шрифтом**:

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
        // Установить прозрачность текстовой части.
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

![Прозрачные текстовые части](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) для расширения или сжатия интервала между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Следующий C++‑код показывает, как расширить интервал между символами в **всём абзаце**:

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

// Примечание: используйте отрицательные значения для сжатия интервала между символами.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Расширить интервал между символами.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Ниже приведён пример кода, показывающий, как расширить интервал между символами в **текстовых частях с жирным шрифтом**:

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
        // Примечание: используйте отрицательные значения для сжатия интервала между символами.
        portionFormat->set_Spacing(3.0f); // Расширить интервал между символами.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Интервал между символами в текстовых частях](character_spacing_in_text_portions.png)

### **Отключить кёрнинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть чуть плотнее, чем тот же текст в PowerPoint. Это может происходить из‑за того, что PowerPoint игнорирует данные кёрнинга для определённых шрифтов, даже если шрифт содержит корректную информацию о кёрнинге и кёрнинг включён в настройках PowerPoint.

Чтобы визуально приблизить результат к PowerPoint, можно отключить кёрнинг для текстовых частей, использующих затронутый шрифт. Используйте [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) для установки значения, превышающего реальный размер шрифта. В этом примере требуется файл «presentation.pptx» с текстовым полем в качестве первой фигуры на первом слайде. Он проверяет эффективные имена шрифтов, включая унаследованные, и устанавливает порог 100 пунктов для частей, использующих Roboto. Это отключает кёрнинг для соответствующих частей, имеющих размер шрифта ниже 100 пунктов:

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

Для текста, соответствующего порогу, эта настройка предотвращает кёрнинг и может помочь согласовать отрисовку Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управлять свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) или для отдельных частей через [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/).

Следующий пример устанавливает для первого абзаца шрифт Times New Roman 12 пунктов с жирным, курсивным и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию.

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

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Следующий пример применяет к частям, у которых эффективное форматирование — жирное, шрифт Times New Roman 13 пунктов, курсив и пунктирное подчёркивание:

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
        // Установить свойства шрифта для текстовой части.
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

![Свойства шрифта для текстовых частей](font_properties_for_text_portions.png)

## **Управлять нормализацией высоты текста**

Используйте [IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) при воспроизведении типографики шаблона или исследовании различий в высоте символов. В PowerPoint включение нормализации растягивает или сжимает отдельные символы по вертикали, чтобы обеспечить им одинаковую видимую высоту внутри текстовой части. Это не гарантирует одинаковую высоту текста между разными шрифтами.

Установите свойство в [NullableBool::True or False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) для явного включения или отключения нормализации. `NullableBool::NotDefined` оставляет локальную настройку неустановленной, так что часть наследует значение, например, из [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/). Это не то же самое, что `False`. Используйте [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) и читайте [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) для получения разрешённого логического значения.

Следующий самостоятельный пример требует установленный **Arial**. Он создаёт два текстовых блока, содержащих одинаковые заглавные буквы, строчные буквы, нижние выносы и символы с диакритическими знаками размером 54 пункта. Оба абзаца включают нормализацию по умолчанию. Верхняя часть явно отключает её; нижняя часть наследует её. Размеры кадров, отступы и интервалы абзацев одинаковы, перенос и автоподгонка отключены, чтобы сравнение было консистентным. Пример выводит `False: False` и `NotDefined: True`, затем сохраняет «text_height_normalization.pptx».

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

NullableBool settings[] = { NullableBool::False, NullableBool::NotDefined };

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 60 + i * 200, 660, 150);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(u"Hxgjpq ÅÉ 0123");
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_MarginTop(0);
    textFrame->get_TextFrameFormat()->set_MarginLeft(0);

    auto paragraph = textFrame->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    paragraph->get_ParagraphFormat()->set_SpaceWithin(100);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_NormaliseHeight(NullableBool::True);

    auto portion = paragraph->get_Portion(0);
    auto font = MakeObject<FontData>(u"Arial");
    portion->get_PortionFormat()->set_LatinFont(font);
    portion->get_PortionFormat()->set_FontHeight(54);
    portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    portion->get_PortionFormat()->set_NormaliseHeight(settings[i]);

    Console::WriteLine(u"{0}: {1}", settings[i], portion->get_PortionFormat()->GetEffective()->get_NormaliseHeight());
}

presentation->Save(u"text_height_normalization.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Сравнение ниже экспортировано из сохранённой презентации. Верхняя строка имеет отключённую нормализацию (`False`); нижняя строка наследует включённую настройку (`NotDefined` → `True`). Оставьте установленный Arial, чтобы воспроизвести внешний вид.

![Текст Arial 54 пункта с отключённой нормализацией сверху и унаследованной нормализацией снизу](text_height_normalization.png)

Нормализация изменяет высоту символов без изменения значения [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/), которое задаёт размер шрифта в пунктах. Межстрочный интервал абзаца регулируется [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/), а тип автоподгонки текстового кадра — [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/). Эти настройки служат разным целям и могут независимо влиять на общую разметку. Подробнее о форматировании абзацев и наследовании см. [Управление абзацами](/slides/ru/cpp/manage-paragraph/).

## **Применять и удалять зачёркивание**

Используйте [IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) для текстовой части, чтобы показывать исправления, отменённые термины или прежние цены без удаления исходного текста. Установите значение [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) для одной или двух линий через текст.

Чтобы удалить зачёркивание, назначьте `TextStrikethroughType::None`. Это явно отключает эффект, даже если окружающее форматирование указывает на зачёркивание. В отличие от этого, `TextStrikethroughType::NotDefined` оставляет локальную настройку неопределённой, позволяя части наследовать форматирование, например, из абзаца. Это не гарантирует, что зачёркивание будет удалено. Используйте [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) для чтения получившегося форматирования, включая унаследованные значения.

Следующий самостоятельный пример создаёт три сравнения цен. Каждый абзац имеет отдельные части для метки, прежней цены и текущей цены, поэтому зачёркиванию подлежит только прежняя цена. В первой строке применяется и затем удаляется зачёркивание; остальные строки сохраняют одно и двойное зачёркивание. Изменение этого свойства сохраняет текст и его другое форматирование, включая жирную прежнюю цену.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextStrikethroughType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

String labels[] = { u"None: ", u"Single: ", u"Double: " };

for (auto label : labels)
{
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(20);

    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    format->set_FontHeight(28);
    auto font = MakeObject<FontData>(u"Arial");
    format->set_LatinFont(font);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto labelPortion = MakeObject<Portion>(label);
    paragraph->get_Portions()->Add(labelPortion);

    auto previousPrice = MakeObject<Portion>(u"$100");
    previousPrice->get_PortionFormat()->set_FontBold(NullableBool::True);
    paragraph->get_Portions()->Add(previousPrice);
    auto currentPrice = MakeObject<Portion>(u" → $80");
    paragraph->get_Portions()->Add(currentPrice);

    textFrame->get_Paragraphs()->Add(paragraph);
}

// Применить перечёркивание, затем явно удалить его у первой прежней цены.
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат сверху вниз: без зачёркивания, с одинарным зачёркиванием и с двойным зачёркиванием.

![Прежние цены без зачёркивания, с одинарным и двойным зачёркиванием](strikethrough.png)


## **Установить вращение текста**

Используйте [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) для установки предопределённой ориентации текста внутри фигуры.

Следующий пример кода устанавливает ориентацию текста в фигуре в значение [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/), которое вращает текст **на 90 градусов против часовой стрелки**:

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

![Вращение текста](text_rotation.png)

## **Установить пользовательское вращение для текстовых кадров**

Используйте [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) для задания пользовательского угла вращения [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).

Пример кода ниже вращает текстовый кадр на 3 градуса по часовой стрелке внутри фигуры:

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

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/) и [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) для управления интервалами абзацев. Эти методы используются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

Следующий пример устанавливает интервал внутри первого абзаца в 200 % от высоты строки (двойной интервал):

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

## **Управлять разрывом строк**

Правила разрыва строк абзаца полезны в узких текстовых блоках и презентациях, которые смешивают латинский и восточно‑азиатский текст. Ниже перечисленные методы принадлежат [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/), поэтому они применяются ко всему абзацу:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) управляет правилами разрыва строк для латинского текста. В смешанном тексте изменение этого параметра может также изменить место переноса соседнего восточно‑азиатского текста и пунктуации.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) управляет правилами разрыва строк для восточно‑азиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/), который включает автоматический перенос внутри текстового кадра. Они влияют на разметку, когда происходит перенос; они не вставляют символы разрыва строки. Явный разрыв строки заставляет создать новую строку в абзаце независимо от доступной ширины.

Следующий самостоятельный пример создаёт узкий текстовый блок, содержащий китайский и латинский текст. Он явно задаёт оба правила разрыва строк и сохраняет файл «line_breaking.pptx». Чтобы поэкспериментировать с любым из правил, измените значение, передаваемое в соответствующий сеттер, оставив остальные настройки неизменными. Пример использует Arial 24 пункта и SimSun, ширина кадра 160 пунктов и нулевые горизонтальные отступы текстового кадра. [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) вызывается с [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/), чтобы размер текста и размеры кадра оставались фиксированными.

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

## **Управлять «висящей» пунктуацией**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) позволяет допускаемым знакам пунктуации выходить за правый край строки текста вместо переноса на следующую строку. Это применяется ко всему абзацу и отличается от «висящего» отступа.

Следующий самостоятельный пример включает «висящую» пунктуацию в текстовом кадре шириной 100 пунктов и сохраняет файл «hanging_punctuation.pptx». При Arial 24 пункта и нулевых горизонтальных отступах текстового кадра конечная точка остаётся после слова «sentence» и выходит за правый край текста. Передайте в сеттер [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/), чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы ширина оставалась фиксированной.

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

Не каждый знак пунктуации может «висеть». Описанные выше [условия шрифта и разметки](#control-line-breaking) также применимы к этому сравнению: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может устранить видимую разницу.

## **Установить тип автоподгонки для текстовых кадров**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) определяет, как текст ведёт себя, когда он превышает границы своего контейнера. Используйте его, чтобы контролировать, уменьшает ли текст размер, выходит ли за пределы или автоматически изменяет размер фигуры. Следующий пример настраивает фигуру так, чтобы она изменяла размер под свой текст, и сохраняет результат в «autofit_type.pptx».

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняются ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/cpp/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых кадров**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) определяет, как текст позиционируется вертикально внутри фигуры, например, сверху, посередине или снизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в «text_anchor.pptx».

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

## **Установить табуляцию текста**

Используйте [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) и [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) для настройки табуляций в абзаце. Следующий пример устанавливает интервал табуляции по умолчанию в 100 пунктов и добавляет левый табулятор на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

![Табуляции абзаца](paragraph_tabs.png)

## **Установить язык проверки правописания**

Aspose.Slides предоставляет [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/), который позволяет задать язык проверки правописания для текстовой части. Язык проверки определяет язык, используемый для проверок орфографии и грамматики в PowerPoint.

Следующий пример требует файл «presentation.pptx» с текстовым полем в качестве первой фигуры на первом слайде и хотя бы один абзац. Он заменяет содержимое первого абзаца на «1。», задаёт SimSun как шрифт и присваивает упрощённый китайский язык проверки (`zh-CN`). Затем сохраняет результат в «proofing_language.pptx»:

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

// Установить язык проверки правописания на упрощенный китайский.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Копировать метаданные языка**

При копировании многоязычного текста из шаблона сохраняйте оба идентификатора языка, используя [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) и [IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/). Следующий самостоятельный пример создаёт исходную часть с английским (US) как основным языком и французским как альтернативным, а затем копирует текст и идентификаторы в часть новой презентации.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto source = System::MakeObject<Portion>(u"Hello! Bonjour!");
source->get_PortionFormat()->set_LanguageId(u"en-US");
source->get_PortionFormat()->set_AlternativeLanguageId(u"fr-FR");

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto destination = System::MakeObject<Portion>();
destination->set_Text(source->get_Text());
destination->get_PortionFormat()->set_LanguageId(source->get_PortionFormat()->get_LanguageId());
// Если у источника нет альтернативного языка, нулевая строка очищает значение назначения.
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Чтобы попробовать источник без альтернативного языка, опустите присвоение `u"fr-FR"`. В этом случае альтернативный идентификатор будет пустой строкой, и то же выражение копирования сохранит её отсутствие без ввода значения по умолчанию, даже если у назначения ранее был установлен альтернативный язык.

Эти идентификаторы хранят метаданные языка. Их сохранение не определяет, какой словарь PowerPoint выберет для проверки орфографии или грамматики.

## **Установить язык по умолчанию**

Используйте [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с английским (US) в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для его первой текстовой части.

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

// Проверить язык первой части.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

Следующий пример задаёт шрифт 14 пунктов, жирный, как значение по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в «default_text_style.pptx». Текст может наследовать эти значения, если более специфичное форматирование их не переопределит.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat> 
#include <DOM/ITextStyle> 
#include <DOM/NullableBool> 
#include <DOM/Presentation> 
#include <Export/SaveFormat> 

using namespace Aspose :: Slides; 
using namespace Aspose :: Slides :: Export; 

auto  \  \  \  \  \  \  presentation = System :: MakeObject <Presentation>(); 

//  Об  об  об  об  об  об  об  об  об  об   а  ти. 
auto  \  \  \  \  \  \​   paragraph  \  \  = presentation -> get_DefaultText  传统  \  \\ … 
```


## **Извлекать текст с эффектом «Все заглавные»**

В PowerPoint применение эффекта шрифта **All Caps** делает текст на слайде заглавным, даже если он изначально был введён строчными. При получении такой текстовой части с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/).

Этот пример требует файл «sample2.pptx» с текстовым полем в качестве первой фигуры на первом слайде. Первая часть первого абзаца содержит «Hello, Aspose!» с применённым эффектом All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

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

Чтобы изменить текст в таблице на слайде, используйте [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Пройдите по ячейкам и обновите каждую ячейку через [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) и форматирование абзацев через [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Установите [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) в значение [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.

Связанная функция: [Format text within slides](/slides/ru/features/text-formatting/).