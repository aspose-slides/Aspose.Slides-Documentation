---
title: Androidでプレゼンテーションに矩形を追加する
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
description: "Aspose.Slides for Android via Java を使用して矩形を追加し、PowerPoint プレゼンテーションを強化します。プログラムで形状を簡単に設計・修正できます。"
---

{{% alert color="primary" %}} 

前のトピックと同様に、この記事も図形の追加についてで、今回は**矩形**について説明します。このトピックでは、開発者が Aspose.Slides for Android via Java を使用してスライドにシンプルまたは書式設定された矩形を追加できる方法を説明しました。

{{% /alert %}} 

## **スライドに矩形を追加する**
プレゼンテーションの選択したスライドにシンプルな矩形を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Rectangle 型の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな矩形を追加しています。
```java
// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円型の AutoShape を追加します
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX ファイルを書き出します
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **スライドに書式設定された矩形を追加する**
スライドに書式設定された矩形を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Rectangle 型の [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) を追加します。
- 矩形の [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) を Solid に設定します。
- 矩形の色を、[IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) オブジェクトに関連付けられた [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) メソッドで設定します。
- 矩形の線の色を設定します。
- 矩形の線の幅を設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。

上記の手順は、以下の例で実装されています。
```java
// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円型の AutoShape を追加します
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 楕円シェイプにいくつかの書式設定を適用します
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 楕円の線にいくつかの書式設定を適用します
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX ファイルを書き出します
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**矩形に丸みのある角を追加するには？**  
丸みのある角の [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) を使用し、シェイプのプロパティでコーナー半径を調整します。ジオメトリの調整により、角ごとに丸みを適用することもできます。

**矩形を画像（テクスチャ）で塗りつぶすには？**  
画像 [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) を選択し、画像ソースを指定し、[stretching/tiling modes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) を構成します。

**矩形に影やグローを付けることはできますか？**  
はい。外側/内側の影、グロー、ソフトエッジ [/slides/androidjava/shape-effect/] は調整可能なパラメータで利用できます。

**矩形をハイパーリンク付きのボタンに変えることはできますか？**  
はい。シェイプのクリックに対して [Assign a hyperlink](/slides/ja/androidjava/manage-hyperlinks/) を設定すれば、スライド、ファイル、Web アドレス、またはメールにジャンプできます。

**矩形が移動や変更から保護するには？**  
[Use shape locks](/slides/ja/androidjava/applying-protection-to-presentation/) を使用すると、移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**矩形をラスタ画像または SVG に変換できますか？**  
はい。指定したサイズ/スケールで画像に [render the shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) したり、ベクタ用に [export it as SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) したりできます。

**テーマと継承を考慮した矩形の実際（有効）プロパティをすぐに取得するには？**  
[Use the shape’s effective properties](/slides/ja/androidjava/shape-effective-properties/) を使用すると、API がテーマスタイル、レイアウト、ローカル設定を考慮した計算値を返すため、書式解析が簡素化されます。