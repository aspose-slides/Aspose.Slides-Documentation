---
title: Поиск и замена текста в презентациях PowerPoint на C++
linktitle: Поиск и замена текста
type: docs
weight: 55
url: /ru/cpp/search-and-replace-text/
keywords:
- поиск текста
- выделение текста
- замена текста
- регулярное выражение
- обратный вызов результата
- текстовый кадр
- отчет аудита
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Поиск, выделение и замена текста в презентациях PowerPoint с одновременным сбором всех совпадений с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ может выполнять поиск, выделение и замену текста в отдельном текстовом кадре или по всей презентации. Каждая операция также может уведомлять приложение о каждом совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно формировать журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый кадр и номер слайда.

Эти возможности полезны для рецензирования, редактирования, проверки терминологии, очистки шаблонов и автоматизированных рабочих процессов отчетности.

В первых примерах ниже мы используем файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выбор области поиска**

Используйте методы интерфейса [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) для ограничения операции одним текстовым кадром. Используйте методы интерфейса [IPresentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/) для обработки всего применимого текста в презентации.

| Операция | Один текстовый кадр | Вся презентация |
|---|---|---|
| Выделить буквальный текст | [ITextFrame::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/highlighttext/) |
| Выделить совпадения регулярных выражений | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/highlightregex/) |
| Заменить буквальный текст | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/replacetext/) |
| Заменить совпадения регулярных выражений | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Настройка соответствия текста**

Для операций с буквальным текстом используйте [ITextSearchOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/) для управления поиском:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) ограничивает совпадения полными словами.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) определяет, должна ли совпадать регистр символов.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_includenotes/) включает заметки слайдов в поиск, замену и операции выделения на уровне презентации.

Операции с регулярными выражениями используют `System::Text::RegularExpressions::Regex`, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, определяются выражением и его параметрами.

## **Определение владельца текстового кадра**

Общие потоки обработки текста часто получают объект [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) при поиске, замене, проверке или экспорте текста. Используйте [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentshape/) и [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentcell/) для определения, какому объекту презентации принадлежит текстовый кадр.

Ожидаемые значения зависят от владельца:

| Владелец текстового кадра | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| AutoShape или другая форма, содержащая текст | Владелец [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) | `nullptr` |
| Ячейка таблицы | `nullptr` | Владелец [ICell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icell/) |

Оба метода предоставляют навигацию только для чтения. Вызов их не перемещает текстовый кадр и не меняет его владельца. Универсальный код должен проверять оба значения на `nullptr` и учитывать возможность, что ни один владелец недоступен.

В следующем примере используется [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/getalltextframes/) для перебора текстовых кадров в презентации. Для фигур он выводит имя фигуры, тип C++ во время выполнения и содержащий слайд. Для ячеек таблицы он выводит координаты столбца и строки, начиная с нуля, и содержащий слайд.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

Для содержимого SmartArt перебирайте фигуры в [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) и получайте каждую [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). Текстовый кадр можно проследить к связанной фигуре через [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentshape/), тогда как [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/get_parentcell/) возвращает `nullptr`. Поэтому ветка фигур в примере также обрабатывает текст из узлов SmartArt.

## **Сбор информации о совпадениях с помощью обратного вызова**

Реализуйте [IFindResultCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifindresultcallback/) для получения уведомления о каждом совпадении. Его метод [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifindresultcallback/foundresult/) предоставляет связанный текстовый кадр, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Реализация ниже получает его из [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecomponent/get_slide/) и также обрабатывает текст, найденный в заметках слайдов, через [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inotesslide/get_parentslide/). Наличие nullable номера слайда позволяет использовать одну модель результата для представления текста, связанного с другими типами слайдов.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

Для операций замены `FoundText` содержит оригинальный найденный текст, поэтому обратный вызов может точно зафиксировать, какие термины были заменены.

## **Выделение текста**

Используйте метод [ITextFrame::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlighttext/) для выделения совпадений буквального текста в текстовом кадре. Передайте [ITextSearchOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/) для управления поиском и обратный вызов для сбора деталей совпадений.

Пример кода ниже выделяет все вхождения символов **"try"** и затем выделяет только полное слово **"to"**. Оба поиска сообщают свои совпадения в один и тот же обратный вызов.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Получить первую форму с первого слайда.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделение текста с использованием регулярных выражений**

Метод [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlightregex/) выделяет совпадения текста, найденные регулярным выражением, в текстовом кадре.

Следующий код выделяет все слова, содержащие семь или более символов, и собирает каждое совпадение:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Выделение текста по всей презентации**

Используйте [IPresentation::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/highlighttext/) и [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/highlightregex/) для поиска во всех применимых текстовых кадрах презентации. Приведенный пример выделяет буквальный термин и все адреса электронной почты, при этом сохраняет отдельные наборы результатов для двух поисков.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexceptions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Замена текста в текстовом кадре**

Используйте [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replacetext/) для буквального текста и [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replaceregex/) для замены на основе шаблона. Эти методы обновляют найденный текст внутри существующего текстового кадра, сохраняя форматирование окружающих частей вместо воссоздания кадра из обычной строки.

В следующем примере стандартизируется вариант написания, а затем заменяются метки версий. Тот же обратный вызов фиксирует оригинальные термины, найденные обеими операциями.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Если одно совпадение охватывает участки с разным форматированием, проверьте результат, чтобы убедиться, какое форматирование должно применяться к заменяемому тексту.

## **Замена текста по всей презентации**

Используйте [IPresentation::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/replacetext/) и [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/replaceregex/) для применения тех же операций по всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Группировка совпадений для отчётов**

Поскольку каждый результат хранит номер слайда и текстовый кадр, приложения могут группировать совпадения для аудита, отчётности или процессов проверки. Ниже пример группирует собранные результаты сначала по слайду, а затем по текстовому кадру:

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **Вопросы и ответы**

**Как я могу искать только в одном текстовом поле, а не во всей презентации?**

Получите текстовый кадр формы и вызовите [ITextFrame::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replacetext/) или [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replaceregex/) для этого текстового кадра. Методы уровня презентации обрабатывают все применимые текстовые кадры.

**Как я могу находить полные слова с правильным регистром?**

Вызовите [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) и [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) с параметром `true` и передайте параметры в метод выделения или замены буквального текста. Для регулярных выражений определяйте границы слов и чувствительность к регистру непосредственно в `System::Text::RegularExpressions::Regex`.

**Может ли поиск и замена включать текст в заметках к слайдам?**

Да. Вызовите [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_includenotes/) с параметром `true` при использовании операций буквального текста на уровне презентации. Реализация обратного вызова, показанная выше, сопоставляет совпадение в заметках слайда с номером родительского слайда.

**Как создать отчёт без повторного сканирования презентации?**

Передайте реализацию [IFindResultCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifindresultcallback/) в операцию выделения или замены. Обратный вызов получает каждое совпадение во время выполнения операции, поэтому приложение может сохранять исходный текст, найденный текст, позицию, текстовый кадр и полученный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replacetext/) и [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replaceregex/) изменяют найденный текст внутри существующего текстового кадра и сохраняют форматирование окружающих частей. Если совпадение охватывает участки с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.