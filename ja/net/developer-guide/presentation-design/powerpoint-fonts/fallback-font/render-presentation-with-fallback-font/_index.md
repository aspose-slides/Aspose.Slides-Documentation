---
title: フォールバックフォントを使用したプレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/net/render-presentation-with-fallback-font/
keywords: 
- フォールバックフォント
- PowerPointのレンダリング
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでフォールバックフォントを使用してPowerPointをレンダリングします"
---

次の例は、以下の手順を含みます：

1. [フォールバックフォントルールコレクションを作成します](/slides/ja/net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/remove)でフォールバックフォントルールを削除し、[AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts)を別のルールに追加します。
1. ルールコレクションを[FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)プロパティに設定します。
1. [Presentation.Save()](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/4)メソッドを使用して、同じ形式でプレゼンテーションを保存するか、別の形式で保存することができます。フォールバックフォントルールコレクションがFontsManagerに設定されると、これらのルールはプレゼンテーションに対する任意の操作（保存、レンダリング、変換など）中に適用されます。

```c#
// ルールコレクションの新しいインスタンスを作成
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// いくつかのルールを作成
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// ロードされたルールからフォールバックフォント「Tahoma」を削除しようとしています
	fallBackRule.Remove("Tahoma");

	// 指定された範囲のルールを更新するために
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// リストから既存のルールを削除することもできます
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // 使用するために準備されたルールリストを割り当て
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 初期化されたルールコレクションを使用してサムネイルをレンダリングし、PNGとして保存
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
[プレゼンテーションの保存と変換についてさらに読む](/slides/ja/net/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}