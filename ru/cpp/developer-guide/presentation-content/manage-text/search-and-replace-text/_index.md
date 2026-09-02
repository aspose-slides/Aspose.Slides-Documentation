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
- текстовый фрейм
- отчет аудита
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Поиск, выделение и замена текста в презентациях PowerPoint с одновременным сбором всех совпадений с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ может выполнять поиск, выделение и замену текста в отдельном текстовом фрейме или во всей презентации. Каждая операция также может уведомлять приложение о каждом совпадении через обратный вызов результата. Это позволяет обновлять презентацию и одновременно создавать журнал аудита, содержащий найденный текст, его контекст, позицию, текстовый фрейм и номер слайда.

Эти возможности полезны для рецензирования, редактирования, проверки терминологии, очистки шаблонов и автоматизированных рабочих процессов отчётности.

В первых примерах ниже мы используем файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выбор области поиска**

Используйте методы на [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) для ограничения операции одним текстовым фреймом. Используйте методы на [IPresentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/) для обработки всего применимого текста в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Выделить буквальный текст | [ITextFrame::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/highlighttext/) |
| Выделить совпадения регулярных выражений | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/highlightregex/) |
| Заменить буквальный текст | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/replacetext/) |
| Заменить совпадения регулярных выражений | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [ITextSearchOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/) для управления сопоставлением:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) ограничивает совпадения полными словами.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) управляет тем, должно ли регистр символов совпадать.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_includenotes/) включает заметки слайдов в операции поиска, замены и выделения уровня презентации.

Операции с регулярными выражениями используют `System::Text::RegularExpressions::Regex`, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, задаются самим выражением и его параметрами.

## **Сбор информации о совпадениях с помощью обратного вызова**

Реализуйте [IFindResultCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifindresultcallback/) для получения уведомления о каждом совпадении. Его метод [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifindresultcallback/foundresult/) предоставляет связанный текстовый фрейм, исходный текст, найденный текст и позицию совпадения.

Обратный вызов не получает номер слайда напрямую. Ниже показанная реализация получает его из [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidecomponent/get_slide/) и также обрабатывает текст, найденный в заметках слайда, через [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inotesslide/get_parentslide/). nullable‑номер слайда позволяет одной модели результата представлять текст, связанный с другими типами слайдов.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
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
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
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

Используйте метод [ITextFrame::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlighttext/) для выделения буквальных совпадений в текстовом фрейме. Передайте [ITextSearchOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/) для управления поиском и обратный вызов для сбора деталей совпадений.

Пример кода ниже выделяет все вхождения символов **"try"**, а затем выделяет только полное слово **"to"**. Оба поиска передают свои совпадения одному и тому же обратному вызову.

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

// Get the first shape from the first slide.
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

Метод [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlightregex/) выделяет совпадения текста, найденные регулярным выражением, в текстовом фрейме.

Следующий код выделяет все слова, содержащие семь и более символов, и собирает каждое совпадение:

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

Используйте [IPresentation::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/highlighttext/) и [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/highlightregex/) для поиска во всех применимых текстовых фреймах презентации. Ниже приведён пример, который выделяет буквальный термин и все электронные адреса, при этом поддерживая отдельные коллекции результатов для двух поисков.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

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

## **Замена текста в текстовом фрейме**

Используйте [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replacetext/) для буквального текста и [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replaceregex/) для замены по шаблону. Эти методы обновляют найденный текст внутри существующего текстового фрейма, сохраняя форматирование окружающих частей вместо полной реконструкции фрейма из простой строки.

Следующий пример стандартизирует вариант написания и затем заменяет метки версий. Один и тот же обратный вызов сохраняет оригинальные термины, найденные обеими операциями.

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

Используйте [IPresentation::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/replacetext/) и [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipresentation/replaceregex/) для применения тех же операций ко всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

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

## **Группировка совпадений для отчётности**

Поскольку каждый результат хранит номер слайда и текстовый фрейм, приложения могут группировать совпадения для аудита, отчётности или рабочих процессов рецензирования. Ниже пример группировки собранных результатов сначала по слайду, затем по текстовому фрейму:

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

## **FAQ**

**Как выполнить поиск только в одном текстовом поле вместо всей презентации?**

Получите текстовый фрейм фигуры и вызовите [ITextFrame::HighlightText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replacetext/) или [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replaceregex/) для этого фрейма. Методы уровня презентации обрабатывают все применимые текстовые фреймы.

**Как сопоставить полные слова с правильным регистром?**

Вызовите [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) и [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) со значением `true` и передайте параметры в метод выделения или замены буквального текста. Для регулярных выражений определите границы слов и чувствительность к регистру непосредственно в `System::Text::RegularExpressions::Regex`.

**Можно ли включить в поиск и замену текст из заметок слайдов?**

Да. Вызовите [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextsearchoptions/set_includenotes/) со значением `true` при использовании буквальной операции уровня презентации. Реализация обратного вызова, показанная выше, сопоставляет совпадения в заметках с номером родительского слайда.

**Как создать отчёт без повторного сканирования презентации?**

Передайте реализацию [IFindResultCallback](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ifindresultcallback/) в операцию выделения или замены. Обратный вызов получает каждое совпадение во время выполнения операции, поэтому приложение может сохранять исходный текст, найденный текст, позицию, текстовый фрейм и вычисленный номер слайда для последующей группировки или экспорта.

**Сохраняет ли замена текста его форматирование?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replacetext/) и [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/replaceregex/) изменяют найденный текст внутри существующего текстового фрейма и сохраняют форматирование окружающих частей. Если совпадение охватывает участки с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.