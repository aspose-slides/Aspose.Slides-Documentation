---
title: .NET のフォールバックフォントでプレゼンテーションをレンダリング
linktitle: プレゼンテーションをレンダリング
type: docs
weight: 30
url: /ja/net/render-presentation-with-fallback-font/
keywords:
- フォールバックフォント
- PowerPoint をレンダリング
- プレゼンテーションをレンダリング
- スライドをレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でフォールバックフォントを使用してプレゼンテーションをレンダリングします – PPT、PPTX、ODP でテキストの一貫性を保つためのステップバイステップ C# コードサンプルをご提供します。"
---

次の例には以下の手順が含まれます:

1. We [create fallback font rules collection](/slides/ja/net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove) a fallback font rule and [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) to another rule。
1. Set rules collection to [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) property。
1. With [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4) method we can save presentation in the same format, or save it in another one. After fallback font rules collection is set to FontsManager, these rules are applied during any operations over the presentation: save, render, convert, etc.```c#
// ルールコレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// ロードされたルールからフォールバックフォント「Tahoma」を削除しようとしています
	fallBackRule.Remove("Tahoma");

	// 指定された範囲のルールを更新します
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// リストから既存のルールをすべて削除することもできます
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
プレゼンテーションの保存と変換の詳細はこちら[Save and Convertion in Presentation](/slides/ja/net/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}