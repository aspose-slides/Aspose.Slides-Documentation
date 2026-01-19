---
title: .NET でフォールバック フォントを使用したプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/net/render-presentation-with-fallback-font/
keywords:
- フォールバック フォント
- PowerPoint のレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でフォールバック フォントを使用してプレゼンテーションをレンダリングします – PPT、PPTX、ODP 間でテキストを一貫させるためのステップバイステップ C# コードサンプルをご提供します。"
---

以下の例には次の手順が含まれています:

1. [フォールバック フォント ルール コレクションを作成](/slides/ja/net/create-fallback-fonts-collection/)。
1. フォールバック フォント ルールを [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) し、別のルールに [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) を追加します。
1. ルール コレクションを [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) プロパティに設定します。
1. [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) メソッドを使用して、プレゼンテーションを同じ形式で保存したり、別の形式で保存したりできます。フォールバック フォント ルール コレクションが FontsManager に設定された後、これらのルールはプレゼンテーションに対するすべての操作（保存、レンダリング、変換など）で適用されます。
```c#
// ルールコレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// いくつかのルールを作成
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// 読み込まれたルールからフォールバックフォント「Tahoma」を削除しようとしています
	fallBackRule.Remove("Tahoma");

	// 指定された範囲のルールを更新します
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// また、リストから既存のルールを削除できます
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // 使用するために準備したルールリストを割り当てています
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 初期化されたルールコレクションを使用してサムネイルをレンダリングし、PNGで保存します
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


{{% alert color="primary" %}} 
[プレゼンテーションの保存と変換](/slides/ja/net/convert-powerpoint-to-png/) の詳細をご覧ください。
{{% /alert %}}