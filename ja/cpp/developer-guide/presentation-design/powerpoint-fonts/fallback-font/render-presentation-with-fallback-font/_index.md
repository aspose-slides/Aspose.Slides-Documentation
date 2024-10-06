---
title: フォールバックフォントを使用したプレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/cpp/render-presentation-with-fallback-font/
keywords: 
- フォールバックフォント
- パワーポイントのレンダリング
- パワーポイント
- プレゼンテーション
- C++
- Aspose.Slides for C++
description: "C++でフォールバックフォントを使用してパワーポイントをレンダリング"
---

以下の例は、これらの手順を含みます：

1. [フォールバックフォントルールコレクションを作成する](/slides/ja/cpp/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#aaf12e563d822f6e05e27732a837bcf33) を使用してフォールバックフォントルールを削除し、別のルールに [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#a030268631ae616b775bdb6df8accf42c) を追加します。
1. ルールコレクションを [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) プロパティに設定します。
1. [Presentation::Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) メソッドを使用して、プレゼンテーションを同じフォーマットで保存するか、別のフォーマットで保存できます。フォールバックフォントルールコレクションがFontsManagerに設定された後、これらのルールはプレゼンテーションの保存、レンダリング、変換などの操作中に適用されます。

``` cpp
// ルールコレクションの新しいインスタンスを作成
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// いくつかのルールを作成
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// 読み込まれたルールからフォールバックフォント「Tahoma」を削除しようとしています
	fallBackRule->Remove(u"Tahoma");

	// 指定された範囲のルールを更新します
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// リストから既存のルールを削除することも可能です
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// 使用するために準備したルールリストを割り当て
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// 初期化されたルールコレクションを使用してサムネイルをレンダリングし、PNGに保存
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
[プレゼンテーションの保存と変換についてもっと読む](/slides/ja/cpp/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}