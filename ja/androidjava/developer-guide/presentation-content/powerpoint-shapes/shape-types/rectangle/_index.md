---
title: Androidでプレゼンテーションに矩形を追加
linktitle: 矩形
type: docs
weight: 80
url: /ja/androidjava/rectangle/
keywords:
- 矩形を追加
- 矩形を作成
- 矩形シェイプ
- シンプルな矩形
- 書式設定された矩形
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して矩形を追加し、PowerPoint プレゼンテーションを強化します。プログラムで図形を簡単に設計・変更できます。"
---

{{% alert color="primary" %}} 
前回のトピックと同様に、今回も図形の追加について説明します。今回取り上げる図形は**矩形**です。このトピックでは、開発者が Aspose.Slides for Android via Java を使用してスライドにシンプルまたは書式設定された矩形を追加する方法を説明しました。
{{% /alert %}} 

## **スライドに矩形を追加する**
スライドにシンプルな矩形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、矩形タイプの [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
- 変更したプレゼンテーションを PPTX ファイルとして保存します。

下の例では、プレゼンテーションの最初のスライドにシンプルな矩形を追加しています。
```java
// PPTX を表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円タイプの AutoShape を追加する
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX ファイルをディスクに書き込む
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **スライドに書式設定された矩形を追加する**
書式設定された矩形をスライドに追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、矩形タイプの [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
- 矩形の [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) を Solid に設定します。
- 矩形の色を、[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) オブジェクトに関連付けられた [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) が提供する [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) メソッドで設定します。
- 矩形の線の色を設定します。
- 矩形の線の幅を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記の手順は、下の例で実装されています。
```java
// PPTX を表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円タイプの AutoShape を追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 楕円形にいくつかの書式設定を適用
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 楕円の線にいくつかの書式設定を適用
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX ファイルを書き出す
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**矩形に角丸を付けるにはどうすればよいですか？**

角丸の [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) を使用し、図形のプロパティでコーナー半径を調整します。ジオメトリの調整により、各コーナーごとに個別に丸めることも可能です。

**矩形を画像（テクスチャ）で塗りつぶすにはどうすればよいですか？**

画像 [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) を設定します。

**矩形に影やグローを付けることはできますか？**

はい。調整可能なパラメータで、[Outer/inner shadow, glow, and soft edges](/slides/ja/androidjava/shape-effect/) を使用できます。

**矩形をハイパーリンク付きのボタンにすることはできますか？**

はい。図形のクリックに対して [Assign a hyperlink](/slides/ja/androidjava/manage-hyperlinks/) を設定すれば、スライド、ファイル、Web アドレス、またはメールへのジャンプが可能です。

**矩形が移動や変更されないように保護するには？**

図形ロックを使用します。移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**矩形をラスタ画像または SVG に変換できますか？**

はい。指定したサイズやスケールで [render the shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) を画像として出力するか、ベクトル用途のために [export it as SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) できます。

**テーマや継承を考慮した矩形の実際（有効）プロパティをすぐに取得するには？**

[Use the shape’s effective properties](/slides/ja/androidjava/shape-effective-properties/) を使用します。API はテーマ設定、レイアウト、ローカル設定を考慮した計算済みの値を返すため、書式分析が簡素化されます。