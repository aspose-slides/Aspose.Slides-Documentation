---
title: 在 C++ 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/cpp/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 抑制拼寫檢查
- 校對語言
- 語言識別碼
- 多語言文字
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中設定 PowerPoint 與 OpenDocument 簡報文字的校對語言，包含預設值與多語言段落。"
---
## **概述**

Aspose.Slides for C++ 允許您為單獨的文字部份配置校對中繼資料。使用 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_languageid/) 來識別校對語言，使用 [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_spellcheck/) 來允許或抑制拼寫檢查，並使用 [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_proofdisabled/) 來控制更廣泛的「不校對」狀態。由於這些設定套用於部份層級，一個段落可以包含多種語言和不同的校對規則。

本文說明如何將語言指定給特定文字、使用 [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) 為新文字設定預設語言、建立多語言段落、在 `SpellCheck` 與 `ProofDisabled` 之間選擇，以及在使用 [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/joinportionswithsameformatting/) 時保留預期的設定。這些屬性僅儲存簡報應用程式的中繼資料；它們不會翻譯文字、執行基於字典的拼寫檢查，或回傳錯字。

## **設定文字的校對語言**

建立或載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)，透過 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/get_portionformat/) 取得所需的文字部份，並指派其語言識別碼。以下範例會建立一個圖形、將校對語言設定為英式英語，並使用 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 儲存結果：

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

## **設定新文字的預設語言**

使用 [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) 來指定 Aspose.Slides 為新建立的文字分配的校對語言。當簡報中大部分或全部新文字使用相同語言時，此設定非常有用。它不會變更已具有明確語言的文字的語言中繼資料。

以下範例建立一個簡報，其新文字使用德語校對規則：

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

## **在同一段落中使用多種語言**

[IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 包含一組文字部份。為每種語言建立獨立的 [Portion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portion/)，並分別設定其 `LanguageId`。

此範例建立一個段落，包含英文和法文部份：

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

## **為單一部份啟用或抑制拼寫檢查**

[IPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/) 繼承自 [IBasePortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/) 定義的通用文字屬性。透過 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/get_portionformat/) 取得部份的格式，並呼叫 [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_spellcheck/) 來控制簡報應用程式是否可以對該部份進行拼寫檢查。預設值為 `false`：`true` 允許拼寫檢查，`false` 抑制拼寫檢查。

此設定僅適用於個別文字部份。因此，同一段落中的不同部份可以使用不同的值。[BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_languageid/) 與 `SpellCheck` 互為補充：`LanguageId` 用於識別校對語言，而 `SpellCheck` 決定該部份是否允許拼寫檢查。

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_proofdisabled/) 亦可控制校對，但它以 [NullableBool](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/nullablebool/) 表示更廣泛的「不校對」狀態。當您需要僅針對拼寫檢查的直接布林開關時，使用 `SpellCheck`；當您需要保留或明確控制簡報的「不校對」中繼資料（包含其 `NullableBool::NotDefined` 狀態）時，使用 `ProofDisabled`。如果同時設定兩者，請確保其值保持一致；不要將 `SpellCheck = true` 與 `ProofDisabled = NullableBool::True` 同時使用。

這些屬性設定的是 PowerPoint 與其他簡報應用程式使用的校對中繼資料。Aspose.Slides 不會利用它們執行字典式拼寫檢查或返回錯字清單。

以下完整範例建立輸入簡報、載入它、為同一段落中的兩個部份指派不同的拼寫檢查設定與校對語言、儲存結果、重新開啟，並驗證儲存的值：

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

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/joinportionswithsameformatting/) 會合併具有相同格式的相鄰部份。僅因 `SpellCheck` 不同而不會讓部份保持分離；合併後的部份會保留第一個部份的 `SpellCheck` 值。若部份需要不同的拼寫檢查設定，請在指派這些設定之前呼叫 `JoinPortionsWithSameFormatting`，或在合併後檢查部份邊界並重新套用設定。具有不同 `LanguageId` 值的部份會保持分離，因為其校對語言格式不同。

## **FAQ**

**語言 ID 會翻譯文字嗎？**

不會。[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_languageid/) 只儲存拼寫與文法的校對中繼資料；它不會改變文字內容。請先分別翻譯文字，然後為每個已翻譯的部份設定適當的語言識別碼。

**校對語言會控制字型、斷字或換行嗎？**

不會。語言識別碼僅用於校對。文字的呈現與版面主要取決於可用的[字型](/slides/zh-hant/cpp/powerpoint-fonts/)、書寫系統，以及文字框設定。為確保可靠的呈現，請提供必要的字型、設定[字型替代](/slides/zh-hant/cpp/font-substitution/)，或在簡報中[嵌入字型](/slides/zh-hant/cpp/embedded-font/)。

**一個段落可以使用多種校對語言嗎？**

可以。如多語言段落範例所示，將每種語言指派給獨立的部份即可。

**應該使用 `DefaultTextLanguage` 還是 `LanguageId`？**

當您想為新建立的文字設定預設語言時，使用 [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/)。當特定部份需要明確的校對語言，或段落中包含多種語言時，使用 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_languageid/)。