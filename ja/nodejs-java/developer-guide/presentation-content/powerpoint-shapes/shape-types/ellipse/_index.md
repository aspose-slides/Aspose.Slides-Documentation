---
title: 楕円
type: docs
weight: 30
url: /ja/nodejs-java/ellipse/
---

{{% alert color="primary" %}} 

このトピックでは、Aspose.Slides for Node.js via Java を使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for Node.js via Java は、わずかなコード行でさまざまな形状を描画できる簡単な API を提供します。

{{% /alert %}} 

## **楕円の作成**
プレゼンテーションの選択されたスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Ellipse タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、最初のスライドに楕円を追加しています。
```javascript
// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 楕円タイプの AutoShape を追加
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // PPTX ファイルを書き込む
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **書式設定された楕円の作成**
スライドに書式設定された楕円を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Ellipse タイプの AutoShape を追加します。
- 楕円の塗りつぶしタイプを Solid に設定します。
- [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) オブジェクトに関連付けられた [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) オブジェクトが提供する SolidFillColor.Color プロパティを使用して、楕円の色を設定します。
- 楕円の線の色を設定します。
- 楕円の線の幅を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに書式設定された楕円を追加しています。
```javascript
// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 楕円タイプの AutoShape を追加
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // 楕円シェイプにいくつかの書式設定を適用
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // 楕円の線にいくつかの書式設定を適用
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX ファイルを書き込む
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

 
## **よくある質問**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常 **ポイント** 単位で指定します。予測可能な結果を得るには、スライドのサイズを基準に計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**他のオブジェクトの上または下に楕円を配置するにはどうすればよいですか（スタック順の制御）？**

オブジェクトの描画順序を前面に持ってくるか背面に送ることで調整します。これにより、楕円が他のオブジェクトと重なったり、背後のオブジェクトを表示したりできます。

**楕円の表示または強調をアニメーション化するにはどうすればよいですか？**

[Apply](/slides/ja/nodejs-java/shape-animation/) を使用して、形状に入場、強調、または退出エフェクトを適用し、トリガーとタイミングを設定して、アニメーションの再生タイミングと方法を制御します。