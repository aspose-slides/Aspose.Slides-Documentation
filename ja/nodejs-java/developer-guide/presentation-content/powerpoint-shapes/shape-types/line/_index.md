---
title: 線
type: docs
weight: 50
url: /ja/nodejs-java/Line/
---

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java はスライドにさまざまな形状を追加することをサポートしています。このトピックでは、線をスライドに追加して形状の操作を開始します。Aspose.Slides for Node.js via Java を使用すると、開発者は単純な線だけでなく、装飾的な線もスライドに描くことができます。

{{% /alert %}} 

## **プレーン線の作成**

プレゼンテーションの選択されたスライドにシンプルなプレーン線を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```javascript
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します
    var sld = pres.getSlides().get_Item(0);
    // タイプが line の AutoShape を追加します
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // PPTX をディスクに保存します
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **矢印形状の線の作成**

Aspose.Slides for Node.js via Java では、線のプロパティを設定して見た目を向上させることができます。線を矢印のように見せるために、いくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for Node.js via Java が提供するスタイルのうちの1つに [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) を設定します。
- 線の幅を設定します。
- Aspose.Slides for Node.js via Java が提供するスタイルのうちの1つに線の [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) を設定します。
- 線の開始点の [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) を設定します。
- 線の終了点の [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) を設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。
```javascript
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得します
    var sld = pres.getSlides().get_Item(0);
    // タイプが line の AutoShape を追加します
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // 線にいくつかの書式設定を適用します
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // PPTX をディスクに保存します
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**通常の線をコネクタに変換して、形状に「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。形状にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/nodejs-java/connector/) を使用してください。

**線のプロパティがテーマから継承されていて、最終的な値を判別しにくい場合はどうすればよいですか？**

`ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` クラスを通じて [effective properties](/slides/ja/nodejs-java/shape-effective-properties/) を読み取ります。これらは継承およびテーマスタイルを考慮しています。

**線を編集（移動、サイズ変更）できないようにロックできますか？**

はい。シェイプは [lock objects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/) を提供しており、[編集操作の禁止](/slides/ja/nodejs-java/applying-protection-to-presentation/) が可能です。