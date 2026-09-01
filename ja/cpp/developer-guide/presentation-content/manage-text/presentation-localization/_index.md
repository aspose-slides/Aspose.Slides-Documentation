---
title: C++でプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーションローカリゼーション
type: docs
weight: 100
url: /ja/cpp/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- スペルチェックの抑制
- 校正言語
- 言語 ID
- 多言語テキスト
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ と Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションテキストの校正言語を設定します。既定設定や多言語段落も含みます。"
---
## **概要**

Aspose.Slides for C++ を使用すると、個々のテキスト部分の校正メタデータを構成できます。校正言語を識別するには[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_languageid/)を、スペルチェックを有効または抑制するには[BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_spellcheck/)を、より広範な校正無効状態を制御するには[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_proofdisabled/)を使用します。これらの設定は部分レベルで適用されるため、1つの段落に複数の言語や異なる校正ルールを含めることができます。

本記事では、特定のテキストに言語を割り当てる方法、[ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) を使用して新規テキストの既定言語を設定する方法、多言語段落を作成する方法、`SpellCheck` と `ProofDisabled` を選択する方法、そして [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/joinportionswithsameformatting/) を使用する際に意図した設定を保持する方法について説明します。これらのプロパティはプレゼンテーションアプリケーション向けのメタデータを格納しますが、テキストを翻訳したり、辞書ベースのスペルチェックを実行したり、誤字リストを返したりはしません。

## **テキストの校正言語を設定する**

[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) を作成またはロードし、[IPortion::get_PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/get_portionformat/) で対象のテキスト部分にアクセスして言語識別子を割り当てます。以下の例はシェイプを作成し、校正言語としてイギリス英語を設定し、[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) で結果を保存します。

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

## **新規テキストの既定言語を設定する**

[ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) を使用して、Aspose.Slides が新規に作成するテキストに割り当てる校正言語を指定します。この設定は、プレゼンテーション内のほとんどまたはすべての新規テキストが同じ言語を使用する場合に便利です。既に明示的な言語が設定されているテキストの言語メタデータは変更されません。

以下の例は、新規テキストがドイツ語の校正規則を使用するプレゼンテーションを作成します。

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

## **1つの段落で複数言語を使用する**

[IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) はテキスト部分のコレクションを保持します。言語ごとに別々の[Portion](https://reference.aspose.com/slides/ja/cpp/aspose.slides/portion/) を作成し、`LanguageId` を個別に設定してください。

この例は、英語とフランス語の部分を持つ段落を作成します。

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

## **個別の部分に対してスペルチェックを有効または抑制する**

[IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/) は[IBasePortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/) で定義された共通テキストプロパティを継承します。[IPortion::get_PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/get_portionformat/) で部分の書式にアクセスし、[BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_spellcheck/) を呼び出してその部分のスペルチェックの可否を制御します。既定値は `false` で、`true` にするとスペルチェックが許可され、`false` にすると抑制されます。

この設定は個々のテキスト部分に適用されます。同じ段落内の異なる部分は異なる値を持つことができ、[BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_languageid/) と `SpellCheck` は補完的な役割を果たします。`LanguageId` は校正言語を識別し、`SpellCheck` はその部分でスペルチェックを許可するかどうかを決定します。

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_proofdisabled/) も校正を制御しますが、これは[NullableBool](https://reference.aspose.com/slides/ja/cpp/aspose.slides/nullablebool/) として「校正しない」状態全体を表します。スペルチェック専用のブールスイッチが必要な場合は `SpellCheck` を使用し、プレゼンテーションの「校正しない」メタデータ（`NullableBool::NotDefined` 状態を含む）を保持または明示的に制御したい場合は `ProofDisabled` を使用してください。両方のプロパティを設定する場合は、値を一貫させてください。`SpellCheck = true` と `ProofDisabled = NullableBool::True` を組み合わせないでください。

これらのプロパティは PowerPoint やその他のプレゼンテーションアプリケーションで使用される校正メタデータを構成します。Aspose.Slides はこれらを使用して辞書ベースのスペルチェックを実行したり、誤字リストを返したりはしません。

以下の完全な例は、入力プレゼンテーションを作成し、ロードし、同じ段落内の 2 つの部分に異なるスペルチェック設定と校正言語を割り当て、結果を保存し、再度開いて格納された値を検証します。

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

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/joinportionswithsameformatting/) は、同じ書式を持つ隣接する部分を結合します。`SpellCheck` のみが異なる場合でも部分は別々に保たれません。結合後の部分は最初の部分の `SpellCheck` 値を保持します。部分ごとに異なるスペルチェック設定が必要な場合は、設定を割り当てる前に `JoinPortionsWithSameFormatting` を呼び出すか、結合後の部分境界を検査して設定を再適用してください。`LanguageId` の値が異なる部分は、校正言語の書式が異なるため別々のまま残ります。

## **FAQ**

**言語 ID はテキストを翻訳しますか？**

いいえ。[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_languageid/) はスペルチェックや文法チェック用の校正メタデータを格納するだけで、テキスト内容は変更しません。テキストは別途翻訳し、翻訳後の各部分に適切な言語識別子を設定してください。

**校正言語はフォント、ハイフネーション、改行を制御しますか？**

いいえ。言語識別子は校正用です。テキストの描画とレイアウトは主に利用可能な[フォント](/slides/ja/cpp/powerpoint-fonts/)、書記体系、テキストフレーム設定に依存します。確実な表示のために必要なフォントを提供し、[フォント置換](/slides/ja/cpp/font-substitution/) や[フォント埋め込み](/slides/ja/cpp/embedded-font/) を設定してください。

**1つの段落で複数の校正言語を使用できますか？**

はい。多言語段落の例に示すように、言語ごとに別々の部分を割り当てれば可能です。

**`DefaultTextLanguage` と `LanguageId` のどちらを使用すべきですか？**

新規に作成したテキストの既定言語を設定したい場合は [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) を使用してください。特定の部分に明示的な校正言語を設定したい、または段落内に複数言語が混在する場合は [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_languageid/) を使用してください。