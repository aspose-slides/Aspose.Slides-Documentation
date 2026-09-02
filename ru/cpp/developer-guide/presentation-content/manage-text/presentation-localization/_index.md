---
title: Автоматизация локализации презентаций в C++
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/cpp/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- подавление проверки орфографии
- язык проверки
- идентификатор языка
- многоязычный текст
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Задайте языки проверки для текста презентаций PowerPoint и OpenDocument в C++ с помощью Aspose.Slides, включая значения по умолчанию и многоязычные абзацы."
---
## **Обзор**

Aspose.Slides for C++ позволяет настраивать метаданные проверки правописания для отдельных текстовых фрагментов. Используйте [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_languageid/) для указания языка проверки, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseportionformat/set_spellcheck/) — для разрешения или подавления проверки орфографии, и [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseportionformat/set_proofdisabled/) — для управления более широким состоянием «не проверять». Поскольку эти настройки применяются на уровне фрагмента, один абзац может содержать несколько языков и разных правил проверки.

В этой статье объясняется, как назначить язык определённому тексту, установить язык по умолчанию для нового текста с помощью [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), создавать многоязычные абзацы, выбирать между `SpellCheck` и `ProofDisabled`, а также сохранять заданные параметры при использовании [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Эти свойства хранят метаданные для приложений презентаций; они не переводят текст, не выполняют проверку орфографии на основе словаря и не возвращают список ошибочно написанных слов.

## **Установить язык проверки правописания для текста**

Создайте или загрузите [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/), получите нужный текстовый фрагмент через [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/get_portionformat/), и задайте его идентификатор языка. В следующем примере создаётся фигура, задаётся британский английский как язык проверки, и результат сохраняется с помощью [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Установить язык по умолчанию для нового текста**

Используйте [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) , чтобы указать язык проверки, который Aspose.Slides назначает новому создаваемому тексту. Эта настройка полезна, когда большинство или весь новый текст в презентации использует один и тот же язык. Она не изменяет метаданные языка текста, у которого уже указан явный язык.

В следующем примере создаётся презентация, в которой новый текст использует правила проверки немецкого языка:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Использовать несколько языков в одном абзаце**

Объект [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/) содержит коллекцию текстовых фрагментов. Создайте отдельный [Portion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/portion/) для каждого языка и задайте его `LanguageId` независимо.

В этом примере создаётся один абзац с английскими и французскими фрагментами:

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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Включить или подавить проверку орфографии для отдельных фрагментов**

[IPortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportionformat/) наследует общие свойства текста, определённые в [IBasePortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/). Получите формат фрагмента через [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/get_portionformat/) и вызовите [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseportionformat/set_spellcheck/), чтобы управлять тем, может ли приложение презентаций проверять орфографию для данного фрагмента. Значение по умолчанию — `false`: `true` разрешает проверку орфографии, а `false` подавляет её.

Эта настройка применяется к отдельным текстовым фрагментам. Поэтому различные фрагменты в одном абзаце могут иметь разные значения. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseportionformat/set_languageid/) и `SpellCheck` выполняют дополняющие задачи: `LanguageId` указывает язык проверки, а `SpellCheck` определяет, разрешена ли проверка орфографии для фрагмента.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseportionformat/set_proofdisabled/) также управляет проверкой, но представляет более общее состояние «не проверять» в виде [NullableBool](https://reference.aspose.com/slides/ru/cpp/aspose.slides/nullablebool/). Используйте `SpellCheck`, когда нужен прямой логический переключатель именно для проверки орфографии. Используйте `ProofDisabled`, когда необходимо сохранять или явно управлять метаданными «не проверять» презентации, включая её состояние `NullableBool::NotDefined`. Если вы задаёте оба свойства, поддерживайте их значения согласованными; не комбинируйте `SpellCheck = true` с `ProofDisabled = NullableBool::True`.

Эти свойства настраивают метаданные проверки, используемые PowerPoint и другими приложениями презентаций. Aspose.Slides не использует их для выполнения словарной проверки орфографии или возврата списка ошибочных слов.

В следующем полном примере создаётся входная презентация, загружается, назначаются разные настройки проверки орфографии и языки проверки для двух фрагментов в одном абзаце, сохраняется результат, открывается заново и проверяются сохранённые значения:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/joinportionswithsameformatting/) объединяет соседние фрагменты, имеющие одинаковое форматирование. Различие только в `SpellCheck` не сохраняет фрагменты раздельно; после объединения результирующий фрагмент сохраняет значение `SpellCheck` первого фрагмента. Если фрагменты требуют разных настроек проверки орфографии, вызовите `JoinPortionsWithSameFormatting` до назначения этих настроек, либо проанализируйте границы полученного фрагмента и повторно примените настройки после объединения. Фрагменты с разными значениями `LanguageId` остаются раздельными, поскольку их форматирование языка проверки отличается.

## **FAQ**

**Переводит ли идентификатор языка текст?**

Нет. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_languageid/) сохраняет метаданные проверки правописания и грамматики; он не изменяет содержание текста. Переводите текст отдельно, а затем задавайте соответствующий идентификатор языка для каждого переведённого фрагмента.

**Контролирует ли язык проверки шрифты, переносы или перенос строк?**

Нет. Идентификатор языка предназначен только для проверки. Отображение текста и макет в основном зависят от доступных [fonts](/slides/ru/cpp/powerpoint-fonts/), системы письма и настроек текстового фрейма. Для надёжного отображения предоставьте необходимые шрифты, настройте [font substitution](/slides/ru/cpp/font-substitution/), или [embed fonts](/slides/ru/cpp/embedded-font/) в презентации.

**Можно ли использовать несколько языков проверки в одном абзаце?**

Да. Присвойте каждому языку отдельный фрагмент, как показано в примере многоязычного абзаца.

**Следует ли использовать `DefaultTextLanguage` или `LanguageId`?**

Используйте [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), когда нужен язык по умолчанию для ново‑создаваемого текста. Используйте [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseportionformat/set_languageid/), когда конкретному фрагменту требуется явный язык проверки или когда абзац содержит несколько языков.