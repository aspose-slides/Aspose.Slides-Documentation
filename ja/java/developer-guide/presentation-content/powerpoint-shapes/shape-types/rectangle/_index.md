---
title: Javaでプレゼンテーションに矩形を追加する
linktitle: 矩形
type: docs
weight: 80
url: /ja/java/rectangle/
keywords:
- 矩形を追加
- 矩形を作成
- 矩形シェイプ
- シンプルな矩形
- 書式設定された矩形
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して矩形を追加し、PowerPoint プレゼンテーションを強化しましょう—プログラムで形状を簡単に設計・変更できます。"
---

{{% alert color="primary" %}} 

前回のトピックと同様に、今回もシェイプの追加について扱いますが、今回取り上げるシェイプは **Rectangle** です。このトピックでは、開発者が Aspose.Slides for Java を使用してスライドにシンプルまたは書式設定された矩形を追加する方法を説明しました。

{{% /alert %}} 

## **スライドに矩形を追加する**
プレゼンテーションの選択したスライドにシンプルな矩形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Rectangle タイプの [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を、[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して追加します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな矩形を追加しています。
```java
// PPTX を表す Presentation クラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円タイプの AutoShape を追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX ファイルを書き込みディスクに保存
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **スライドに書式設定された矩形を追加する**
スライドに書式設定された矩形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Rectangle タイプの [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を、[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して追加します。
- 矩形の [Fill Type](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) を Solid に設定します。
- [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) オブジェクトに関連付けられた [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) オブジェクトが提供する [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) メソッドを使用して矩形の色を設定します。
- 矩形の線の色を設定します。
- 矩形の線の幅を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

上記の手順は以下の例で実装されています。
```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円タイプの AutoShape を追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 楕円形にいくつか書式設定を適用
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 楕円の線にいくつか書式設定を適用
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX ファイルを書き込みディスクに保存
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**角丸の矩形を追加するには？**

角丸の [shape type](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/) を使用し、シェイプのプロパティでコーナー半径を調整します。ジオメトリ調整により、各コーナーごとに丸めを適用することもできます。

**画像（テクスチャ）で矩形を塗りつぶすには？**

画像 [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) を設定します。

**矩形に影や光彩を付けられますか？**

はい。[外部/内部影、光彩、ソフトエッジ](/slides/ja/java/shape-effect/) は調整可能なパラメータで利用できます。

**矩形をハイパーリンク付きのボタンに変換できますか？**

はい。形状のクリックに対して [ハイパーリンクを割り当てる](/slides/ja/java/manage-hyperlinks/) と、スライド、ファイル、Web アドレス、またはメールへのジャンプが可能です。

**矩形を移動や変更から保護するには？**

[シェイプロックを使用する](/slides/ja/java/applying-protection-to-presentation/) と、移動、サイズ変更、選択、テキスト編集を禁止でき、レイアウトを保護できます。

**矩形をラスタ画像または SVG に変換できますか？**

はい。指定したサイズ/スケールで画像に [シェイプをレンダリング](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) したり、ベクトル用途のために [SVG としてエクスポート](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) したりできます。

**テーマと継承を考慮した矩形の実際（有効）プロパティをすぐに取得するには？**

[シェイプの有効プロパティを使用する](/slides/ja/java/shape-effective-properties/) と、API はテーマスタイル、レイアウト、ローカル設定を考慮した計算値を返すため、書式設定の分析が簡素化されます。