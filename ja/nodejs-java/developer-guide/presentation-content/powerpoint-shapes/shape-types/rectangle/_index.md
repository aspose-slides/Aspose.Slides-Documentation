---
title: 長方形
type: docs
weight: 80
url: /ja/nodejs-java/rectangle/
---

{{% alert color="primary" %}} 

前回のトピックと同様に、今回もシェイプの追加について扱いますが、今回は **Rectangle**（長方形）について説明します。このトピックでは、開発者が Aspose.Slides for Node.js via Java を使用して、スライドにシンプルな長方形や書式設定された長方形を追加する方法を説明しました。

{{% /alert %}} 

## **スライドに長方形を追加**
プレゼンテーションの選択したスライドにシンプルな長方形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Rectangle タイプの [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな長方形を追加しています。
```javascript
// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 楕円タイプの AutoShape を追加
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // PPTX ファイルをディスクに保存
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **書式設定された長方形をスライドに追加**
スライドに書式設定された長方形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Rectangle タイプの [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) を追加します。
- 長方形の [Fill Type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillType) を Solid に設定します。
- [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) オブジェクトに関連付けられた [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FillFormat) オブジェクトが提供する [SolidFillColor.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) メソッドを使用して、長方形の色を設定します。
- 長方形の線の色を設定します。
- 長方形の線の幅を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして保存します。

上記の手順は、以下の例で実装されています。
```javascript
// PPTX を表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 楕円タイプの AutoShape を追加
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // 楕円シェイプにいくつかの書式設定を適用
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // 楕円の線にいくつかの書式設定を適用
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


## **よくある質問**

**角が丸い長方形を追加するには？**

角丸の [shape type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/) を使用し、シェイプのプロパティで角の半径を調整します。ジオメトリ調整により、各コーナーごとに丸めることも可能です。

**画像（テクスチャ）で長方形を塗りつぶすには？**

画像の [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) を構成します。

**長方形に影やグローを付けることはできますか？**

はい。[Outer/inner shadow, glow, and soft edges](/slides/ja/nodejs-java/shape-effect/) が利用可能で、パラメータを調整できます。

**長方形をハイパーリンク付きのボタンに変換できますか？**

はい。シェイプのクリックに対して [Assign a hyperlink](/slides/ja/nodejs-java/manage-hyperlinks/) を設定すれば、スライド、ファイル、ウェブアドレス、またはメールへのジャンプが可能です。

**長方形が移動や変更から保護するにはどうすればよいですか？**

[Use shape locks](/slides/ja/nodejs-java/applying-protection-to-presentation/) を使用します。移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**長方形をラスタ画像または SVG に変換できますか？**

はい。指定したサイズ/スケールで画像に [render the shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) したり、ベクタ用途のために [export it as SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) へエクスポートしたりできます。

**テーマや継承を考慮した長方形の実際（有効）プロパティをすぐに取得するには？**

[Use the shape’s effective properties](/slides/ja/nodejs-java/shape-effective-properties/) を使用します。API はテーマスタイル、レイアウト、ローカル設定を考慮した計算値を返し、書式設定の分析を簡素化します。