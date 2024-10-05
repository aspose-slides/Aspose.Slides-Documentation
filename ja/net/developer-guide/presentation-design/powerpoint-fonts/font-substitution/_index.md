---
title: フォントの置き換え - PowerPoint C# API
linktitle: フォントの置き換え
type: docs
weight: 70
url: /net/font-substitution/
keywords: 
- フォント
- 置き換えフォント
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: C# PowerPoint APIを使用すると、プレゼンテーション内のフォントを置き換えることができます
---

## **フォントの置き換えを取得する**

プレゼンテーションのレンダリングプロセス中に置き換えられるプレゼンテーションのフォントを確認するために、Aspose.Slidesは[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/)インターフェースから[GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/)メソッドを提供します。

以下のC#コードは、プレゼンテーションがレンダリングされる際に実行されるすべてのフォントの置き換えを取得する方法を示しています：
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```


## **フォントの置き換えルールの設定**

Aspose.Slidesでは、特定の条件（例えば、フォントにアクセスできない場合など）で何をすべきかを決定するフォントのルールを設定できます。この手順で行います：

1. 関連するプレゼンテーションを読み込む。
2. 置き換えられるフォントを読み込む。
3. 新しいフォントを読み込む。
4. 置き換えのためのルールを追加する。
5. ルールをプレゼンテーションのフォント置き換えルールのコレクションに追加する。
6. スライド画像を生成して効果を観察する。

このC#コードは、フォントの置き換えプロセスを示しています：

```c#
// プレゼンテーションを読み込む
Presentation presentation = new Presentation("Fonts.pptx");

// 置き換えられるソースフォントを読み込む
IFontData sourceFont = new FontData("SomeRareFont");

// 新しいフォントを読み込む
IFontData destFont = new FontData("Arial");

// フォント置き換えのためのルールを追加する
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// ルールをフォント置き換えルールコレクションに追加する
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// フォントルールコレクションをルールリストに追加する
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // 画像をJPEG形式でディスクに保存する
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="注意"  color="warning"   %}} 

[**フォントの置き換え**](/slides/net/font-replacement/)を参照することをお勧めします。 

{{% /alert %}}