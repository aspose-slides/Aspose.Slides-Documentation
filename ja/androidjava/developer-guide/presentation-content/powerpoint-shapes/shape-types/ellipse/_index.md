---
title: 楕円
type: docs
weight: 30
url: /androidjava/ellipse/
---


{{% alert color="primary" %}} 

このトピックでは、Java経由でAspose.Slides for Androidを使用して、スライドに楕円形を追加する開発者について紹介します。Aspose.Slides for Androidを使用すると、数行のコードだけでさまざまな種類の形状を描画するための簡単なAPIセットが提供されます。

{{% /alert %}} 

## **楕円を作成する**
プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが公開する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して楕円タイプのAutoShapeを追加します。
- 修正したプレゼンテーションをPPTXファイルとして書き込みます。

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

## **フォーマットされた楕円を作成する**
スライドにより良いフォーマットの楕円を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが公開する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して楕円タイプのAutoShapeを追加します。
- 楕円の塗りつぶしタイプをソリッドに設定します。
- [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) オブジェクトに関連付けられた [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) オブジェクトが公開するSolidFillColor.Colorプロパティを使用して楕円の色を設定します。
- 楕円の線の色を設定します。
- 楕円の線の幅を設定します。
- 修正したプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにフォーマットされた楕円を追加しました。

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

    // 楕円の線にいくつかのフォーマットを適用
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTXファイルをディスクに書き込む
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```