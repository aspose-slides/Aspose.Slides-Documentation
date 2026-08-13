---
title: C++ でフォールバック フォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/cpp/render-presentation-with-fallback-font/
keywords:
- フォールバック フォント
- PowerPoint のレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でフォールバック フォントを使用してプレゼンテーションをレンダリングします – PPT、PPTX、ODP 間でテキストの一貫性を保つためのステップバイステップ C++ コードサンプルをご提供します。"
---
## **概要**

Aspose.Slides は、フォールバック フォント ルールを使用してプレゼンテーションをレンダリングできます。この記事では、フォールバック フォント ルール コレクションの作成方法、フォントを削除または追加してルールを変更する方法、および `FontsManager::set_FontFallBackRulesCollection` メソッドを使用してコレクションを割り当てる方法を示します。

フォールバック フォント ルール コレクションがプレゼンテーションの `FontsManager` に割り当てられると、保存、レンダリング、変換などの操作中にルールが適用されます。この例では、スライドのサムネイルをレンダリングし、PNG 画像として保存する際に設定されたルールを使用する方法を示しています。

## **フォールバック フォント ルールを使用したスライドのレンダリング**

以下の例では、次の手順が含まれます：

1. フォールバック フォント ルール コレクションを[作成](/slides/ja/cpp/create-fallback-fonts-collection/)します。
2. フォールバック フォント ルールを[Remove()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/remove/)し、別のルールに[AddFallBackFonts()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/)を追加します。
3. ルール コレクションを[FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)メソッドに渡します。
4. [Presentation::Save()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/)メソッドを使用すると、プレゼンテーションを同じ形式で保存したり、別の形式で保存したりできます。フォールバック フォント ルール コレクションが FontsManager に設定されると、保存、レンダリング、変換など、プレゼンテーションに対するすべての操作でこれらのルールが適用されます。

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// ルール コレクションの新しいインスタンスを作成します
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 複数のルールを作成します
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// ロードされたルールからフォールバック フォント "Tahoma" を削除しようとしています
	fallBackRule->Remove(u"Tahoma");

	// 指定された範囲のルールを更新します
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) &&
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// リストから既存のルールをすべて削除することもできます
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// 使用するために準備したルール リストを割り当てます
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// 初期化されたルール コレクションを使用してサムネイルをレンダリングし、PNG で保存します
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
C++ で PowerPoint スライドを PNG に変換する方法の詳細は、[C++ で PowerPoint スライドを PNG に変換](/slides/ja/cpp/convert-powerpoint-to-png/)をご覧ください。
{{% /alert %}}