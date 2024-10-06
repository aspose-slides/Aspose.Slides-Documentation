---
title: 楕円
type: docs
weight: 30
url: /ja/java/ellipse/
---


{{% alert color="primary" %}} 

このトピックでは、Aspose.Slides for Javaを使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for Javaは、数行のコードでさまざまな形状を描画するための簡単なAPIセットを提供します。

{{% /alert %}} 

## **楕円を作成する**
プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)オブジェクトによって公開された[addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して楕円タイプのAutoShapeを追加します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、最初のスライドに楕円を追加しました。

```java
// PPTXを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 楕円タイプのAutoShapeを追加
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTXファイルをディスクに書き込む
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **フォーマット済み楕円を作成する**
スライドにより良いフォーマットの楕円を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)オブジェクトによって公開された[addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して楕円タイプのAutoShapeを追加します。
- 楕円の塗りつぶしタイプをソリッドに設定します。
- [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)オブジェクトに関連付けられた[FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat)オブジェクトによって公開されたSolidFillColor.Colorプロパティを使用して楕円の色を設定します。
- 楕円の線の色を設定します。
- 楕円の線の幅を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにフォーマット済みの楕円を追加しました。

```java
// PPTXを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円タイプのAutoShapeを追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 楕円形にいくつかのフォーマットを適用
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // 楕円の線のフォーマットを適用
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTXファイルをディスクに書き込む
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```