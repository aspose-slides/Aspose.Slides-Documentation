---
title: .NET でフォールバック フォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/net/render-presentation-with-fallback-font/
keywords:
- フォールバック フォント
- PowerPoint をレンダリング
- プレゼンテーションをレンダリング
- スライドをレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でフォールバック フォントを使用してプレゼンテーションをレンダリングし、PPT、PPTX、ODP 間でテキストの一貫性を保つステップバイステップの C# コードサンプル。"
---
## **概要**

Aspose.Slides はフォールバック フォント ルールを使用してプレゼンテーションをレンダリングできます。本記事では、フォールバック フォント ルール コレクションの作成方法、フォールバック フォントを削除または追加してルールを変更する方法、そしてそのコレクションを `FontsManager.FontFallBackRulesCollection` プロパティに割り当てる方法を示します。

フォールバック フォント ルール コレクションがプレゼンテーションの `FontsManager` に割り当てられると、保存、レンダリング、変換などの操作時にルールが適用されます。この例では、スライドのサムネイルをレンダリングし、PNG 画像として保存する際に設定されたルールを使用する方法を示しています。

## **フォールバック フォント ルールを使用したスライドのレンダリング**

次の例では、以下の手順が含まれます。

1. フォールバック フォント ルール コレクションを[作成](/slides/ja/net/create-fallback-fonts-collection/)します。
2. [Remove()](https://reference.aspose.com/slides/ja/net/aspose.slides/fontfallbackrule/methods/remove) を使用してフォールバック フォント ルールを削除し、[AddFallBackFonts()](https://reference.aspose.com/slides/ja/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) を別のルールに追加します。
3. [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) プロパティにルール コレクションを設定します。
4. [Presentation.Save()](https://reference.aspose.com/slides/ja/net/aspose.slides.presentation/save/methods/4) メソッドを使用して、プレゼンテーションを同じ形式で保存したり、別の形式で保存したりできます。フォールバック フォント ルール コレクションが FontsManager に設定されると、保存、レンダリング、変換など、プレゼンテーションに対するすべての操作でこれらのルールが適用されます。

```c#
using Aspose.Slides;

// ルール コレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// ロードされたルールからフォールバック フォント "Tahoma" を削除しようとしています
	fallBackRule.Remove("Tahoma");

	// 指定された範囲のルールを更新します
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// リストから既存のルールをすべて削除できますが、少なくとも1つのルールは保持してレンダリングします
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // 用意したルール リストを割り当てます
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 初期化されたルール コレクションを使用してサムネイルをレンダリングし、PNG に保存します
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
プレゼンテーションの[保存と変換](/slides/ja/net/convert-powerpoint-to-png/)の詳細をご覧ください。
{{% /alert %}}