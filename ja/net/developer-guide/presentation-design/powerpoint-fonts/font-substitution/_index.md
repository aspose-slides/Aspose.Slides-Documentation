---
title: フォント置換 - PowerPoint C# API
linktitle: フォント置換
type: docs
weight: 70
url: /ja/net/font-substitution/
keywords:
- フォント
- 代替フォント
- PowerPoint
- プレゼンテーション
- C#
- C#
- Aspose.Slides for .NET
description: C# PowerPoint API を使用すると、プレゼンテーション内のフォントを置換できます
---

## **フォント置換の取得**

プレゼンテーションのレンダリングプロセス中に置換されるフォントを確認できるように、Aspose.Slides は [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) インターフェイスの [GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) メソッドを提供します。

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

Aspose.Slides では、フォントに対して特定の条件下での処理を決定するルールを次のように設定できます（例: フォントにアクセスできない場合）:

1. 対象のプレゼンテーションをロードします。
2. 置換対象のフォントをロードします。
3. 新しいフォントをロードします。
4. 置換のルールを追加します。
5. プレゼンテーションのフォント置換ルールコレクションにルールを追加します。
6. スライド画像を生成して効果を確認します。

この C# のコードはフォント置換プロセスを示しています。
```c#
 // プレゼンテーションを読み込む
 Presentation presentation = new Presentation("Fonts.pptx");
 
 // 置き換える元フォントを読み込む
 IFontData sourceFont = new FontData("SomeRareFont");
 
 // 新しいフォントを読み込む
 IFontData destFont = new FontData("Arial");
 
 // フォント置換のためのルールを追加する
 IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
 
 // フォント置換ルールコレクションにルールを追加する
 IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
 fontSubstRuleCollection.Add(fontSubstRule);
 
 // フォントルールコレクションをルールリストに設定する
 presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;
 
 using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
 {
     // 画像を JPEG 形式でディスクに保存する
     image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
 }
```


{{%  alert title="NOTE"  color="warning"   %}} 
以下をご覧になることをおすすめします [**フォント置換**](/slides/ja/net/font-replacement/)。 
{{% /alert %}}

## **FAQ**

**フォント置換とフォント代替の違いは何ですか？**

[置換](/slides/ja/net/font-replacement/) はプレゼンテーション全体であるフォントを別のフォントに強制的に上書きすることです。代替は、特定の条件（例: 元のフォントが利用できない場合）でトリガーされ、指定されたフォントに置き換えるルールです。

**代替ルールは正確にいつ適用されますか？**

これらのルールは、ロード、レンダリング、変換の各段階で評価される標準的な [フォント選択](/slides/ja/net/font-selection-sequence/) シーケンスに参加します。選択されたフォントが利用できない場合、置換または代替が適用されます。

**置換も代替も設定されておらず、システムにフォントが存在しない場合のデフォルト動作は何ですか？**

ライブラリは、PowerPoint と同様に、利用可能な最も近いシステムフォントを選択しようとします。

**実行時にカスタム外部フォントを追加して代替を回避できますか？**

はい。実行時に [外部フォントを追加](/slides/ja/net/custom-font/) でき、ライブラリはそれらを選択とレンダリング（後続の変換も含む）に使用します。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。Aspose は有償・無償を問わずフォントを配布しません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS での代替動作に違いはありますか？**

はい。フォントの検出は OS のフォントディレクトリから開始されます。デフォルトで利用可能なフォントセットや検索パスはプラットフォームごとに異なり、利用可能性や代替の必要性に影響します。

**バッチ変換時の予期しない代替を最小限に抑えるために環境をどのように準備すべきですか？**

マシンやコンテナ間でフォントセットを同期し、出力ドキュメントに必要な [外部フォントを追加](/slides/ja/net/custom-font/)、可能であればプレゼンテーションに [フォントを埋め込み](/slides/ja/net/embedded-font/) して、レンダリング時に選択されたフォントが利用できるようにします。