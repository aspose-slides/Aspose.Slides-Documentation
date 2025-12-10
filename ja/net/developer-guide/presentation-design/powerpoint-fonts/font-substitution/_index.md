---
title: .NET のプレゼンテーションでフォント置換を設定する
linktitle: フォント置換
type: docs
weight: 70
url: /ja/net/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォントの置換
- フォント置換
- 置換ルール
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションを他のファイル形式に変換する際、Aspose.Slides for .NET で最適なフォント置換を有効にします。"
---

## **フォント置換の取得**

プレゼンテーションのレンダリングプロセス中に置換されるフォントを確認できるように、Aspose.Slidesは[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/)インターフェイスの[GetSubstitution](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/)メソッドを提供します。

C#コードは、プレゼンテーションがレンダリングされる際に実行されるすべてのフォント置換を取得する方法を示しています。
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

Aspose.Slidesでは、フォントに対して条件に応じて行うべき処理（例: フォントにアクセスできない場合）を決定するルールを次のように設定できます。

1. 対象のプレゼンテーションをロードします。
2. 置換対象のフォントをロードします。
3. 新しいフォントをロードします。
4. 置換のルールを追加します。
5. プレゼンテーションのフォント置換ルールコレクションにルールを追加します。
6. スライド画像を生成し、効果を確認します。

このC#コードはフォント置換プロセスを実演します。
```c#
 // プレゼンテーションをロードします
 Presentation presentation = new Presentation("Fonts.pptx");

 // 置換される元フォントをロードします
 IFontData sourceFont = new FontData("SomeRareFont");

 // 新しいフォントをロードします
 IFontData destFont = new FontData("Arial");

 // フォント置換用のルールを追加します
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
[**フォント置換**](/slides/ja/net/font-replacement/)をご覧になるとよいでしょう。 
{{% /alert %}}

## **FAQ**

**フォント置換とフォント代替の違いは何ですか？**

[Replacement](/slides/ja/net/font-replacement/) は、プレゼンテーション全体であるフォントを別のフォントに強制的に置き換えることです。代替は、特定の条件（例: 元のフォントが利用できない場合）でトリガーされ、指定された代替フォントが使用されるルールです。

**代替ルールは正確にはいつ適用されますか？**

これらのルールは、ロード、レンダリング、変換の際に評価される標準の[font selection](/slides/ja/net/font-selection-sequence/)シーケンスに参加します。選択されたフォントが利用できない場合、置換または代替が適用されます。

**置換も代替も設定されておらず、システムにフォントが存在しない場合のデフォルト動作は何ですか？**

ライブラリは、PowerPoint と同様に、利用可能なシステムフォントの中で最も近いものを選択しようとします。

**代替を回避するために、実行時にカスタム外部フォントを追加できますか？**

はい。実行時に[add external fonts](/slides/ja/net/custom-font/) を追加でき、ライブラリはそれらを選択およびレンダリング時に考慮し、以降の変換にも使用します。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布していません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS での代替動作に違いはありますか？**

あります。フォントの検出は OS のフォントディレクトリから始まります。デフォルトで利用可能なフォントと検索パスはプラットフォームごとに異なり、利用可能性や代替の必要性に影響します。

**バッチ変換時の予期せぬ代替を最小限に抑えるために、環境はどのように準備すべきですか？**

マシンやコンテナ間でフォントセットを同期し、出力ドキュメントに必要な[add the external fonts](/slides/ja/net/custom-font/) を追加し、可能な限りプレゼンテーションに[embed fonts](/slides/ja/net/embedded-font/) を埋め込んで、レンダリング時に選択したフォントが利用できるようにします。