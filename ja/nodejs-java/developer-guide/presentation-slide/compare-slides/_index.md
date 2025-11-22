---
title: スライド比較
type: docs
weight: 50
url: /ja/nodejs-java/compare-slides/
---

## **スライド2枚の比較**
Equals メソッドが [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) クラスに追加されました。構造と静的コンテンツが同一であるスライド/レイアウトおよびマスタースライドに対して true を返します。

すべてのシェイプ、スタイル、テキスト、アニメーション、その他の設定等が同じであれば、2つのスライドは等しいとみなされます。比較では、SlideId のような一意識別子や、日付プレースホルダーの現在の日付値などの動的コンテンツは考慮されません。
```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **よくある質問**

**スライドが非表示であることは、スライド自体の比較に影響しますか？**

[Hidden status](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/gethidden/) はプレゼンテーション/再生レベルのプロパティであり、視覚的コンテンツではありません。2つの特定スライドの等価性はその構造と静的コンテンツによって決まります。スライドが非表示であるという事実だけでは、スライドは異なるものとはみなされません。

**ハイパーリンクとそのパラメータは考慮されますか？**

はい。リンクはスライドの静的コンテンツの一部です。URL やハイパーリンクのアクションが異なる場合、通常は静的コンテンツの違いとして扱われます。

**チャートが外部の Excel ファイルを参照している場合、そのファイルの内容は考慮されますか？**

いいえ。比較はスライド自体に基づいて行われます。外部データソースは比較時に読み込まれることは通常なく、スライドの構造と静的状態に存在するものだけが考慮されます。