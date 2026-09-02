---
title: Автоматизация локализации презентаций в .NET
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/net/presentation-localization/
keywords:
- изменить язык
- проверка орфографии
- подавление проверки орфографии
- язык проверки
- идентификатор языка
- многоязычный текст
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Установите языки проверки для текста презентаций PowerPoint и OpenDocument в .NET с помощью Aspose.Slides, включая значения по умолчанию и многоязычные абзацы."
---
## **Обзор**

Aspose.Slides for .NET позволяет настраивать метаданные проверки орфографии для отдельных текстовых частей. Используйте [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/languageid/) чтобы указать язык проверки, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/spellcheck/) чтобы разрешить или подавить проверку орфографии, и [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/proofdisabled/) чтобы управлять более широким состоянием «не проверять». Поскольку эти настройки применяются на уровне части, один абзац может содержать несколько языков и разные правила проверки.

В этой статье объясняется, как назначить язык конкретному тексту, задать язык по умолчанию для нового текста с помощью [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaulttextlanguage/), создать многоязычные абзацы, выбрать между `SpellCheck` и `ProofDisabled`, а также сохранить нужные настройки при использовании [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/joinportionswithsameformatting/). Эти свойства хранят метаданные для приложений презентаций; они не переводят текст, не выполняют проверку орфографии на основе словарей и не возвращают неверно написанные слова.

## **Установить язык проверки для текста**

Создайте или загрузите [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/), получите нужную часть текста через [IPortion.PortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/portionformat/), и задайте её идентификатор языка. Ниже приведён пример, который создаёт форму, задаёт британский английский как язык проверки и сохраняет результат с помощью [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Установить язык по умолчанию для нового текста**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaulttextlanguage/) для указания языка проверки, который Aspose.Slides назначит только что созданному тексту. Эта настройка полезна, когда большинство или весь новый текст в презентации использует один и тот же язык. Она не изменяет метаданные языка уже существующего текста с явно заданным языком.

Ниже пример, который создаёт презентацию, где новый текст использует правила немецкой проверки:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Использовать несколько языков в одном абзаце**

[IParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides/iparagraph/) содержит коллекцию текстовых частей. Создайте отдельный [Portion](https://reference.aspose.com/slides/ru/net/aspose.slides/portion/) для каждого языка и задайте его `LanguageId` независимо.

Пример создаёт один абзац с английскими и французскими частями:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Включить или подавить проверку орфографии для отдельных частей**

[IPortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportionformat/) наследует общие текстовые свойства, определённые в [IBasePortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/). Получите формат части через [IPortion.PortionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/iportion/portionformat/) и задайте [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/spellcheck/) для управления тем, будет ли приложение презентаций проверять орфографию этой части. Значение по умолчанию — `false`: `true` разрешает проверку, а `false` подавляет её.

Эта настройка применяется к отдельным текстовым частям. Поэтому разные части в одном абзаце могут использовать разные значения. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/languageid/) и `SpellCheck` выполняют дополняющие функции: `LanguageId` указывает язык проверки, а `SpellCheck` определяет, разрешена ли проверка орфографии для части.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/proofdisabled/) также управляет проверкой, но представляет более широкое состояние «не проверять» как [NullableBool](https://reference.aspose.com/slides/ru/net/aspose.slides/nullablebool/). Используйте `SpellCheck`, когда нужен простой логический переключатель именно для проверки орфографии. Используйте `ProofDisabled`, когда необходимо сохранить или явно контролировать метаданные презентации, указывающие отсутствие проверки, включая состояние `NotDefined`. Если задаёте оба свойства, поддерживайте их согласованность; не комбинируйте `SpellCheck = true` с `ProofDisabled = NullableBool.True`.

Эти свойства задают метаданные проверки, используемые PowerPoint и другими приложениями презентаций. Aspose.Slides не использует их для выполнения словарной проверки орфографии или возврата списка ошибок.

Ниже полный пример, который создаёт исходную презентацию, загружает её, назначает разные настройки проверки орфографии и языки проверки двум частям в одном абзаце, сохраняет результат, открывает его снова и проверяет сохранённые значения:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/joinportionswithsameformatting/) объединяет соседние части с одинаковым форматированием. Различие только в `SpellCheck` не удерживает такие части раздельными; после объединения результирующая часть сохраняет значение `SpellCheck` первой части. Если части требуют разных настроек проверки, вызовите `JoinPortionsWithSameFormatting` до назначения этих настроек или проанализируйте границы получившихся частей и повторно примените настройки. Части с разными значениями `LanguageId` остаются раздельными, поскольку их форматирование языка проверки отличается.

## **Часто задаваемые вопросы**

**Переводит ли идентификатор языка текст?**

Нет. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/languageid/) хранит метаданные проверки орфографии и грамматики; он не изменяет содержание текста. Переведите текст отдельно, а затем задайте соответствующий идентификатор языка для каждой переведённой части.

**Контролирует ли язык проверки шрифты, переносы или перенос строк?**

Нет. Идентификатор языка предназначен только для проверки. Отрисовка текста и разметка в основном зависят от доступных [шрифтов](/slides/ru/net/powerpoint-fonts/), системы письма и настроек текстового кадра. Для надёжного отображения предоставьте требуемые шрифты, настройте [замену шрифтов](/slides/ru/net/font-substitution/) или [встраивание шрифтов](/slides/ru/net/embedded-font/) в презентацию.

**Можно ли в одном абзаце использовать несколько языков проверки?**

Да. Назначьте каждый язык отдельной части, как показано в примере многоязычного абзаца.

**Что использовать: `DefaultTextLanguage` или `LanguageId`?**

Используйте [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/defaulttextlanguage/), когда нужен язык по умолчанию для вновь создаваемого текста. Используйте [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseportionformat/languageid/), когда конкретной части нужен явный язык проверки или когда абзац содержит несколько языков.