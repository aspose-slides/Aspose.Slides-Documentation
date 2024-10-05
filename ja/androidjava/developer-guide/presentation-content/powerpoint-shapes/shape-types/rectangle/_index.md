---
title: 長方形
type: docs
weight: 80
url: /androidjava/rectangle/
---

{{% alert color="primary" %}} 

前のトピックと同様に、今回も図形を追加することについてです。今回は議論する図形は**長方形**です。このトピックでは、開発者がAspose.Slides for Androidを使用してJavaでスライドにシンプルまたはフォーマット済みの長方形を追加する方法について説明します。

{{% /alert %}} 

## **スライドに長方形を追加する**
プレゼンテーションの選択したスライドにシンプルな長方形を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)オブジェクトが公開する[addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、長方形型の[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)を追加します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにシンプルな長方形を追加しました。

```java
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円型のAutoShapeを追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTXファイルをディスクに書き込む
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドにフォーマット済みの長方形を追加する**
スライドにフォーマット済みの長方形を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)オブジェクトが公開する[addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、長方形型の[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)を追加します。
- 長方形の[Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType)をソリッドに設定します。
- [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape)オブジェクトに関連付けられた[IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat)オブジェクトが公開する[SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-)メソッドを使用して、長方形の色を設定します。
- 長方形の線の色を設定します。
- 長方形の線の幅を設定します。
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記の手順は、以下の例に実装されています。

```java
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円型のAutoShapeを追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 楕円の形状にいくつかのフォーマットを適用
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 楕円の線にいくつかのフォーマットを適用
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTXファイルをディスクに書き込む
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```