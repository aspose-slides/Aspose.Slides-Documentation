---
title: ".NET でプレゼンテーションのフォント置換を構成"
linktitle: "フォント置換"
type: docs
weight: 70
url: /ja/net/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォント置換
- フォント置換
- 置換規則
- 置換規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションを他のファイル形式に変換する際、.NET 用 Aspose.Slidesで最適なフォント置換を有効にします。"
---

## **フォント置換の取得**

プレゼンテーションのレンダリング中に置換されるフォントを確認できるように、Aspose.Slides は [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) インターフェイスの [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) メソッドを提供します。

C# のコードは、プレゼンテーションがレンダリングされる際に実行されるすべてのフォント置換を取得する方法を示しています。
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```



## **フォント置換ルールの設定**

Aspose.Slides では、フォントが特定の条件（例: フォントにアクセスできない場合）で何をすべきかを決定するルールを次のように設定できます。

1. 対象のプレゼンテーションを読み込む。
2. 置換対象となるフォントを読み込む。
3. 新しいフォントを読み込む。
4. 置換のルールを追加する。
5. そのルールをプレゼンテーションのフォント置換ルールコレクションに追加する。
6. スライド画像を生成して効果を確認する。

以下の C# コードは、フォント置換プロセスを示しています。
```c#
// プレゼンテーションをロードします
Presentation presentation = new Presentation("Fonts.pptx");

// 置換される元フォントをロードします
IFontData sourceFont = new FontData("SomeRareFont");

// 新しいフォントをロードします
IFontData destFont = new FontData("Arial");

// フォント置換のためのルールを追加します
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// ルールをフォント置換ルールコレクションに追加します
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// フォントルールコレクションをルールリストに設定します
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // 画像を JPEG 形式でディスクに保存します
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
[**フォント置換**](/slides/ja/net/font-replacement/)をご覧になりたい場合は、上記をご参照ください。 
{{% /alert %}}

## **FAQ**

**フォント置換とフォント代替の違いは何ですか？**

[Replacement](/slides/ja/net/font-replacement/) は、プレゼンテーション全体であるフォントを別のフォントに強制的に置き換えるものです。代替は、特定の条件（例: 元のフォントが利用できない場合）で発動するルールで、その場合に指定されたフォールバックフォントが使用されます。

**置換ルールは正確にはいつ適用されますか？**

これらのルールは、読み込み、レンダリング、変換の際に評価される標準的な [font selection](/slides/ja/net/font-selection-sequence/) シーケンスに組み込まれます。選択されたフォントが利用できない場合、置換または代替が適用されます。

**置換も代替も設定されておらず、システムにフォントが存在しない場合のデフォルト動作は何ですか？**

ライブラリは、PowerPoint と同様に、利用可能なシステムフォントの中から最も近いものを自動的に選択しようとします。

**実行時にカスタム外部フォントを追加して代替を回避できますか？**

はい。実行時に [add external fonts](/slides/ja/net/custom-font/) を追加すれば、ライブラリはそれらをフォント選択やレンダリング、さらに後続の変換でも考慮します。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布していません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS での代替動作に違いがありますか？**

あります。フォントの検出は OS のフォントディレクトリから開始されます。各プラットフォームでデフォルトで利用できるフォントの種類や検索パスが異なるため、利用可能性や代替の必要性に影響します。

**バッチ変換時の予期せぬ代替を最小限に抑えるために環境をどのように整備すべきですか？**

マシンやコンテナ間でフォントセットを統一し、出力ドキュメントに必要な [add the external fonts](/slides/ja/net/custom-font/) を追加し、可能な限りプレゼンテーションに [embed fonts](/slides/ja/net/embedded-font/) を埋め込んで、レンダリング時に選択したフォントが利用できるようにしてください。