---
title: JavaScriptでプレゼンテーションに長方形を追加する
linktitle: 長方形
type: docs
weight: 80
url: /ja/nodejs-java/rectangle/
keywords:
- 長方形を追加
- 長方形を作成
- 長方形シェイプ
- シンプルな長方形
- 書式設定された長方形
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript と Aspose.Slides for Node.js を使って長方形を追加し、PowerPoint プレゼンテーションを強化しましょう。形状をプログラムで簡単にデザイン・変更できます。"
---

{{% alert color="primary" %}} 

前回のトピックと同様に、今回も図形の追加について取り上げますが、今回取り上げる図形は **長方形** です。このトピックでは、開発者が Aspose.Slides for Node.js via Java を使用してスライドにシンプルまたは書式設定された長方形を追加できる方法について説明しました。

{{% /alert %}} 

## **スライドに長方形を追加**
プレゼンテーションの選択したスライドにシンプルな長方形を追加するには、以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Rectangle タイプの [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) を、[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが公開する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して追加します。
- 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな長方形を追加しています。
```javascript
// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 楕円型の AutoShape を追加
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // PPTX ファイルをディスクに保存
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **スライドに書式設定された長方形を追加**
スライドに書式設定された長方形を追加するには、以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Rectangle タイプの [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) を、[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが公開する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して追加します。
- 長方形の [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) を Solid に設定します。
- [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) オブジェクトに関連付けられた [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) オブジェクトが公開する [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) メソッドを使用して、長方形の色を設定します。
- 長方形の線の色を設定します。
- 長方形の線の幅を設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

上記の手順は以下の例に実装されています。
```javascript
// PPTX を表す Presentation クラスのインスタンスを生成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 楕円型の AutoShape を追加
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // 楕円シェイプに塗りつぶし書式を適用
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // 楕円の線に書式を適用
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX ファイルをディスクに保存
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**角丸の長方形はどうやって追加しますか？**

角丸の [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) を使用し、形状のプロパティでコーナー半径を調整します。ジオメトリの調整により、コーナーごとに丸めを適用することも可能です。

**画像（テクスチャ）で長方形を塗りつぶすにはどうすればよいですか？**

画像の [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を picture に設定し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) を構成します。

**長方形に影や光彩を付けることはできますか？**

はい。[Outer/inner shadow, glow, and soft edges](/slides/ja/nodejs-java/shape-effect/) が利用可能で、パラメータを調整できます。

**長方形をハイパーリンク付きのボタンにできますか？**

はい。形状のクリックに対して [Assign a hyperlink](/slides/ja/nodejs-java/manage-hyperlinks/) を設定すれば、スライド、ファイル、Web アドレス、またはメールへのジャンプが可能です。

**長方形が移動や変更されないように保護するにはどうすればよいですか？**

shape ロックを使用します。移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**長方形をラスタ画像や SVG に変換できますか？**

はい。指定したサイズ/スケールで画像に [render the shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) するか、ベクタ利用のために [export it as SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) できます。

**テーマや継承を考慮した長方形の実際（有効）プロパティをすぐに取得するには？**

[Use the shape’s effective properties](/slides/ja/nodejs-java/shape-effective-properties/) を使用します。API はテーマスタイル、レイアウト、ローカル設定を考慮した計算済み値を返し、書式分析を簡素化します。