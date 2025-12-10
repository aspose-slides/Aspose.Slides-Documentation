---
title: Java を使用したプレゼンテーションでのフォント代替の構成
linktitle: フォント代替
type: docs
weight: 70
url: /ja/java/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント代替
- フォント置換
- フォント置換
- 代替規則
- 置換規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションを他のファイル形式に変換する際に、Aspose.Slides for Java で最適なフォント代替を有効にします。"
---

## **フォント置換規則の設定**

Aspose.Slides では、フォントに関する規則を設定し、特定の条件（例: フォントにアクセスできない場合）で何を行うかを決定できます。

1. 対象のプレゼンテーションを読み込む。
2. 置き換えるフォントを読み込む。
3. 新しいフォントを読み込む。
4. 置き換え規則を追加する。
5. プレゼンテーションのフォント置換規則コレクションに規則を追加する。
6. スライド画像を生成して効果を確認する。

この Java コードはフォント置換プロセスを示しています:
```java
// プレゼンテーションを読み込む
Presentation pres = new Presentation("Fonts.pptx");
try {
    // 置き換える元フォントを読み込む
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // 新しいフォントを読み込む
    IFontData destFont = new FontData("Arial");
    
    // フォント置換用のルールを追加する
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // ルールをフォント置換ルールコレクションに追加する
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // ルールリストにフォントルールコレクションを追加する
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // 後者がアクセス不能な場合、Arial フォントが SomeRareFont の代わりに使用されます
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // 画像を JPEG 形式でディスクに保存する
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

[**フォント置換**](/slides/ja/java/font-replacement/) をご覧ください。 

{{% /alert %}}

## **FAQ**

**フォント置換とフォント代替の違いは何ですか？**

[置換](/slides/ja/java/font-replacement/) は、プレゼンテーション全体であるフォントを別のフォントに強制的に上書きします。代替は特定の条件（例: 元のフォントが利用できない場合）で発動し、指定したフォールバックフォントが使用される規則です。

**代替規則は正確にはいつ適用されますか？**

規則は標準の[フォント選択](/slides/ja/java/font-selection-sequence/) シーケンスに組み込まれ、読み込み、レンダリング、変換時に評価されます。選択されたフォントが利用できない場合、置換または代替が適用されます。

**置換も代替も設定されておらず、システムにフォントが存在しない場合の既定動作は何ですか？**

ライブラリは PowerPoint と同様に、最も近い利用可能なシステムフォントを自動的に選択しようとします。

**実行時にカスタム外部フォントを添付して代替を回避できますか？**

はい。実行時に[外部フォントを追加](/slides/ja/java/custom-font/) すれば、ライブラリは選択とレンダリングの際にそれらを考慮します。以降の変換でも同様です。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布しません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS で代替の挙動に違いはありますか？**

あります。フォントの検出は OS のフォントディレクトリから開始され、デフォルトで利用可能なフォントや検索パスはプラットフォームごとに異なるため、利用可能性と代替の必要性が変わります。

**バッチ変換時に予期しない代替を最小限に抑えるための環境準備はどうすれば良いですか？**

マシンやコンテナ間でフォントセットを統一し、出力ドキュメントに必要な[外部フォントを追加](/slides/ja/java/custom-font/)し、可能であればプレゼンテーションに[フォントを埋め込む](/slides/ja/java/embedded-font/)ことで、レンダリング時に選択されたフォントが利用できるようにします。