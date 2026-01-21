---
title: C++ でフォールバックフォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/cpp/render-presentation-with-fallback-font/
keywords:
- フォールバックフォント
- PowerPoint のレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でフォールバックフォントを使用してプレゼンテーションをレンダリングし、PPT、PPTX、ODP 間でテキストを一貫させるためのステップバイステップ C++ コードサンプル。"
---

以下の例では、これらの手順が含まれています。

1. フォールバックフォント規則コレクションを[create fallback font rules collection](/slides/ja/cpp/create-fallback-fonts-collection/)します。
1. フォールバックフォント規則を[Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/remove/)し、別の規則に[AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/)を追加します。
1. ルールコレクションを[FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)メソッドに渡します。
1. [Presentation::Save()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)メソッドを使用して、プレゼンテーションを同じ形式で保存するか、別の形式で保存できます。FontsManager にフォールバックフォント規則コレクションが設定されると、保存、レンダリング、変換など、プレゼンテーションに対するあらゆる操作時にこれらの規則が適用されます。
``` cpp
// ルールコレクションの新しいインスタンスを作成
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 複数のルールを作成
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
 //rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// 読み込まれたルールからフォールバックフォント "Tahoma" を削除しようとしています
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
// 使用するために準備したルールリストを割り当てています
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// 初期化されたルールコレクションを使用してサムネイルをレンダリングし、PNGとして保存します
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```



{{% alert color="primary" %}} 
C++ で PowerPoint スライドを PNG に変換する方法の詳細は、[Convert PowerPoint Slides to PNG in C++](/slides/ja/cpp/convert-powerpoint-to-png/)をご覧ください。
{{% /alert %}}