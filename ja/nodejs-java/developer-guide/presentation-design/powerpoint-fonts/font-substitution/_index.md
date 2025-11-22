---
title: フォント置換 - PowerPoint JavaScript API
linktitle: フォント置換
type: docs
weight: 70
url: /ja/nodejs-java/font-substitution/
keywords: "フォント, 置換フォント, PowerPoint プレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "PowerPoint のフォントを JavaScript で置換する"
---

## **フォント置換規則の設定**

Aspose.Slides では、フォントに対して特定の条件下（例: フォントにアクセスできない場合）に取るべき処理を決定する規則を次のように設定できます。

1. 対象のプレゼンテーションを読み込みます。
2. 置換対象のフォントを読み込みます。
3. 新しいフォントを読み込みます。
4. 置換の規則を追加します。
5. 規則をプレゼンテーションのフォント置換規則コレクションに追加します。
6. スライド画像を生成し、効果を確認します。

この JavaScript コードはフォント置換プロセスを示しています:
```javascript
// プレゼンテーションを読み込む
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // 置換対象となる元のフォントを読み込む
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // 新しいフォントを読み込む
    var destFont = new aspose.slides.FontData("Arial");
    // フォント置換のための規則を追加する
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // 規則をフォント置換規則コレクションに追加する
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // 規則リストにフォント規則コレクションを追加する
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // 後者がアクセス不可の場合、Arial フォントが SomeRareFont の代わりに使用されます
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // 画像を JPEG 形式でディスクに保存する
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

次のページをご覧になると良いでしょう [**フォント置換**](/slides/ja/nodejs-java/font-replacement/)。

{{% /alert %}}

## **FAQ**

**フォント置換とフォント代替の違いは何ですか？**

[置換](/slides/ja/nodejs-java/font-replacement/) はプレゼンテーション全体であるフォントを別のフォントに強制的に上書きするものです。代替は、特定の条件下（例: 元のフォントが利用できない場合）にトリガーされ、指定した代替フォントが使用される規則です。

**代替規則は正確にはいつ適用されますか？**

規則は標準の[フォント選択](/slides/ja/nodejs-java/font-selection-sequence/)シーケンスに参加し、ロード、レンダリング、変換の際に評価されます。選択されたフォントが利用できない場合、置換または代替が適用されます。

**置換も代替も設定されておらず、システムにフォントが存在しない場合のデフォルト動作は何ですか？**

ライブラリは利用可能な最も近いシステムフォントを選択しようとします。これは PowerPoint の動作と同様です。

**実行時にカスタム外部フォントを添付して代替を回避できますか？**

はい。実行時に[外部フォントを追加](/slides/ja/nodejs-java/custom-font/)することで、ライブラリは選択とレンダリング時にそれらを考慮します。以降の変換にも適用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布していません。フォントはご自身の判断と責任で追加・使用してください。

**Windows、Linux、macOS で代替動作に違いはありますか？**

はい。フォントの検出は OS のフォントディレクトリから開始されます。デフォルトで利用可能なフォントと検索パスはプラットフォームごとに異なり、利用可否や代替の必要性に影響します。

**バッチ変換時に予期しない代替を最小限に抑えるための環境準備はどうすべきですか？**

マシンやコンテナ間でフォントセットを統一し、出力ドキュメントに必要な[外部フォントを追加](/slides/ja/nodejs-java/custom-font/)し、可能であればプレゼンテーションに[フォントを埋め込む](/slides/ja/nodejs-java/embedded-font/)ことで、レンダリング時にフォントが利用できるようにします。