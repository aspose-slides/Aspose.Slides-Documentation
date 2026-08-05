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
description: "Aspose.Slides for C++ でフォールバックフォントを使用してプレゼンテーションをレンダリングし、PPT、PPTX、ODP 間でテキストの一貫性を保つためのステップバイステップ C++ コードサンプルをご紹介します。"
---
## **概要**

Aspose.Slides はフォールバックフォントルールを使用してプレゼンテーションをレンダリングできます。この記事では、フォールバックフォントルールコレクションの作成、フォールバックフォントの削除または追加によるルールの変更、そして `FontsManager::set_FontFallBackRulesCollection` メソッドを使用したコレクションの割り当て方法を示します。

フォールバックフォントルールコレクションがプレゼンテーションの `FontsManager` に割り当てられると、保存、レンダリング、変換などの操作中にルールが適用されます。例では、スライドのサムネイルをレンダリングし、PNG 画像として保存する際に設定されたルールを使用する方法を示しています。

## **フォールバックフォントルールを使用してスライドをレンダリングする**

以下の例では次の手順を行います。

1. 我々は[フォールバックフォントルールコレクションを作成](/slides/ja/cpp/create-fallback-fonts-collection/)します。
1. [Remove()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/remove/) でフォールバックフォントルールを削除し、[AddFallBackFonts()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) で別のルールに追加します。
1. ルールコレクションを[FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) メソッドに渡します。
1. [Presentation::Save()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) メソッドを使用して、プレゼンテーションを同じ形式で保存するか、別の形式で保存できます。フォールバックフォントルールコレクションが FontsManager に設定されると、保存、レンダリング、変換などプレゼンテーションに対するすべての操作でこれらのルールが適用されます。

``` cpp
// ルールコレクションの新しいインスタンスを作成する
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 複数のルールを作成する
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// ロードされたルールからフォールバックフォント "Tahoma" を削除しようとしています
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
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
C++でPowerPointスライドをPNGに変換する方法の詳細は[こちら](/slides/ja/cpp/convert-powerpoint-to-png/)です。 
{{% /alert %}}