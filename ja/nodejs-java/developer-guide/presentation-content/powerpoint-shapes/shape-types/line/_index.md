---
title: JavaScript でプレゼンテーションにライン形状を追加する
linktitle: ライン
type: docs
weight: 50
url: /ja/nodejs-java/line/
keywords:
- ライン
- ライン作成
- ライン追加
- プレーンライン
- ライン構成
- ラインカスタマイズ
- ダッシュスタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使用して PowerPoint プレゼンテーションのライン書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルを紹介します。"
---

{{% alert color="primary" %}} 
Aspose.Slides for Node.js via Java はスライドにさまざまな形状を追加することをサポートしています。このトピックでは、スライドに線を追加することで形状の操作を開始します。Aspose.Slides for Node.js via Java を使用すると、開発者は単純な線を作成できるだけでなく、装飾的な線もスライド上に描くことができます。
{{% /alert %}} 

## **プレーン線の作成**

簡単なプレーン線をプレゼンテーションの選択されたスライドに追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- ShapeCollection オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```javascript
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // タイプが line の AutoShape を追加
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // PPTX をディスクに保存
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **矢印形状の線の作成**

Aspose.Slides for Node.js via Java は、線の外観を調整するためのプロパティ設定もサポートしています。線を矢印のように見せるために、いくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- ShapeCollection オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- [Line Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) を Aspose.Slides for Node.js via Java が提供するスタイルのいずれかに設定します。
- 線の幅を設定します。
- 線の [Dash Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) を Aspose.Slides for Node.js via Java が提供するスタイルのいずれかに設定します。
- 線の開始点の [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) を設定します。
- 線の終了点の [Arrow Head Style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。
```javascript
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // タイプが line の AutoShape を追加
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // ラインにいくつかの書式設定を適用
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // PPTX をディスクに保存
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**通常の線をコネクタに変換して形状に「スナップ」させることはできますか？**

いいえ。通常の線（タイプが [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)）は自動的にコネクタにはなりません。形状にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) タイプと接続用の [corresponding APIs](/slides/ja/nodejs-java/connector/) を使用してください。

**線のプロパティがテーマから継承されていて、最終的な値を把握しにくい場合はどうすればよいですか？**

[有効なプロパティを読む](/slides/ja/nodejs-java/shape-effective-properties/) を `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` クラスを通じて行います—これらは継承とテーマスタイルをすでに考慮しています。

**線を編集（移動やサイズ変更）からロックできますか？**

はい。Shapes は編集操作を禁止できる [lock objects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/) を提供します。