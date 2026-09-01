---
title: 在 C++ 中自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/cpp/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 抑制拼写检查
- 校对语言
- 语言标识符
- 多语言文本
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中为 PowerPoint 和 OpenDocument 演示文稿文本设置校对语言，包括默认语言和多语言段落。"
---
## **概述**

Aspose.Slides for C++ 允许您为单独的文本片段配置校对元数据。使用 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_languageid/) 来标识校对语言，使用 [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseportionformat/set_spellcheck/) 来允许或抑制拼写检查，使用 [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseportionformat/set_proofdisabled/) 来控制更广泛的“未校对”状态。由于这些设置在片段级别应用，一个段落可以包含多种语言和不同的校对规则。

本文说明了如何为特定文本分配语言，使用 [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) 为新文本设置默认语言，构建多语言段落，在 `SpellCheck` 与 `ProofDisabled` 之间进行选择，以及在使用 [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/joinportionswithsameformatting/) 时保持预期的设置。这些属性存储演示文稿应用程序的元数据；它们不翻译文本、执行基于词典的拼写检查或返回拼写错误的单词。

## **为文本设置校对语言**

创建或加载一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/)，通过 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/get_portionformat/) 访问所需的文本片段，并为其分配语言标识符。以下示例创建一个形状，将英国英语设为校对语言，并使用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 保存结果：

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

## **为新文本设置默认语言**

使用 [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) 指定 Aspose.Slides 为新创建的文本分配的校对语言。当演示文稿中大多数或全部新文本使用相同语言时，此设置非常有用。它不会更改已具有显式语言的文本的语言元数据。

以下示例创建一个演示文稿，其新文本使用德语校对规则：

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

## **在同一段落中使用多种语言**

[IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 包含一系列文本片段。为每种语言创建单独的 [Portion](https://reference.aspose.com/slides/zh/cpp/aspose.slides/portion/)，并独立设置其 `LanguageId`。

此示例创建一个段落，其中包含英文和法文片段：

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
englishPortion->get_PportionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **为单个片段启用或抑制拼写检查**

[IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/) 继承自 [IBasePortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/) 定义的通用文本属性。通过 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/get_portionformat/) 访问片段的格式，并调用 [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseportionformat/set_spellcheck/) 来控制演示文稿应用程序是否检查该片段的拼写。默认值为 `false`：`true` 允许拼写检查，`false` 则抑制。

此设置适用于单个文本片段。因此，同一段落中的不同片段可以使用不同的值。[BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseportionformat/set_languageid/) 与 `SpellCheck` 互补：`LanguageId` 标识校对语言，而 `SpellCheck` 决定是否允许对该片段进行拼写检查。

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseportionformat/set_proofdisabled/) 也控制校对，但它以 [NullableBool](https://reference.aspose.com/slides/zh/cpp/aspose.slides/nullablebool/) 表示更宽泛的“不要校对”状态。当您只需要针对拼写检查的布尔开关时使用 `SpellCheck`；当您需要保留或显式控制演示文稿的“未校对”元数据（包括 `NullableBool::NotDefined` 状态）时使用 `ProofDisabled`。如果同时设置两个属性，请保持其值一致；不要将 `SpellCheck = true` 与 `ProofDisabled = NullableBool::True` 混用。

这些属性配置 PowerPoint 等演示文稿应用程序使用的校对元数据。Aspose.Slides 不会使用它们进行词典式拼写检查或返回拼写错误单词列表。

以下完整示例创建输入演示文稿，加载后为同一段落中的两个片段分配不同的拼写检查设置和校对语言，保存结果，重新打开并验证存储的值：

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

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/joinportionswithsameformatting/) 会合并具有相同格式的相邻片段。仅 `SpellCheck` 的差异不足以保持片段分离；合并后，结果片段保留第一个片段的 `SpellCheck` 值。如果片段需要不同的拼写检查设置，请在分配这些设置之前调用 `JoinPortionsWithSameFormatting`，或在合并后检查结果片段的边界并重新应用设置。具有不同 `LanguageId` 值的片段会保持分离，因为它们的校对语言格式不同。

## **常见问题**

**语言 ID 会翻译文本吗？**

不会。[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_languageid/) 仅存储拼写和语法校对的元数据；它不改变文本内容。请单独翻译文本，然后为每个已翻译的片段设置相应的语言标识符。

**校对语言会控制字体、连字或换行吗？**

不会。语言标识符仅用于校对。文本的渲染和布局主要取决于可用的 [fonts](/slides/zh/cpp/powerpoint-fonts/)、书写系统以及文本框设置。为获得可靠的渲染，请提供所需字体，配置 [font substitution](/slides/zh/cpp/font-substitution/)，或在演示文稿中 [embed fonts](/slides/zh/cpp/embedded-font/)。

**一个段落可以使用多种校对语言吗？**

可以。正如多语言段落示例所示，为每种语言创建单独的片段并分配相应的语言即可。

**我应该使用 `DefaultTextLanguage` 还是 `LanguageId`？**

当您希望为新创建的文本提供默认语言时，请使用 [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/)。当特定片段需要显式的校对语言，或段落中包含多种语言时，请使用 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_languageid/)。