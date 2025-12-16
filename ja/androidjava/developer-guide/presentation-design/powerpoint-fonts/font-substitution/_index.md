---
title: Android のプレゼンテーションでフォント置換を設定
linktitle: フォント置換
type: docs
weight: 70
url: /ja/androidjava/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォント置換
- フォント置換
- 置換ルール
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションを他のファイル形式に変換する際に、Java を使用して Android 用 Aspose.Slides で最適なフォント置換を有効にします。"
---

## **フォント置換ルールの設定**

Aspose.Slides では、フォントが特定の条件（例: フォントにアクセスできない場合）で何をすべきかを決定するルールを設定できます。その方法は次のとおりです:

1. 対象のプレゼンテーションをロードします。
2. 置換されるフォントをロードします。
3. 新しいフォントをロードします。
4. 置換用のルールを追加します。
5. そのルールをプレゼンテーションのフォント置換ルールコレクションに追加します。
6. スライド画像を生成して効果を確認します。

この Java コードはフォント置換プロセスを示しています:
```java
// プレゼンテーションをロードします
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 置換される元フォントをロードします
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 新しいフォントをロードします
    IFontData destFont = new FontData("Arial");
    
    // フォント置換のためのルールを追加します
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // ルールをフォント置換ルールコレクションに追加します
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // ルールリストにフォントルールコレクションを追加します
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // 後者がアクセスできない場合、Arial フォントが SomeRareFont の代わりに使用されます
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // 画像を JPEG 形式でディスクに保存します
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
フォント置換の詳細は[**Font Replacement**](/slides/ja/androidjava/font-replacement/)をご覧ください。
{{% /alert %}}

## **FAQ**

**フォント置換とフォント代替の違いは何ですか？**

[Replacement](/slides/ja/androidjava/font-replacement/) は、プレゼンテーション全体であるフォントを別のフォントに強制的に上書きすることです。代替は、元のフォントが利用できない場合など、特定の条件が満たされたときにトリガーされ、指定したフォントにフォールバックするルールです。

**代替ルールは正確にはいつ適用されますか？**

これらのルールは、ロード、レンダリング、変換時に評価される標準の[font selection](/slides/ja/androidjava/font-selection-sequence/)シーケンスに組み込まれます。選択されたフォントが利用できない場合に、置換または代替が適用されます。

**置換も代替も設定されておらず、システムにフォントが存在しない場合の既定の動作は？**

ライブラリは PowerPoint と同様に、利用可能な最も近いシステムフォントを自動的に選択しようとします。

**実行時にカスタム外部フォントを添付して代替を回避できますか？**

はい。実行時に[add external fonts](/slides/ja/androidjava/custom-font/) を追加すれば、ライブラリはそれらを選択およびレンダリング時に考慮します。以降の変換でも使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布していません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS で代替動作に違いはありますか？**

あります。フォントの検出は OS のフォントディレクトリから始まります。デフォルトで利用可能なフォントと検索パスはプラットフォームごとに異なり、利用可能性と代替の必要性に影響します。

**バッチ変換時に予期しない代替を最小限に抑えるための環境設定は？**

マシンやコンテナ間でフォントセットを統一し、出力ドキュメントに必要な[add the external fonts](/slides/ja/androidjava/custom-font/) を追加し、可能であればプレゼンテーションに[embed fonts](/slides/ja/androidjava/embedded-font/) を埋め込んで、レンダリング時にフォントが利用できるようにしてください。