---
title: 長方形
type: docs
weight: 80
url: /ja/java/rectangle/
---

{{% alert color="primary" %}} 

前のトピックと同様に、今回も形状を追加することについてです。今回議論する形状は **長方形** です。このトピックでは、開発者が Aspose.Slides for Java を使用してスライドにシンプルまたはフォーマットされた長方形を追加する方法を説明しました。

{{% /alert %}} 

## **スライドに長方形を追加する**
選択したプレゼンテーションのスライドにシンプルな長方形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、長方形タイプの [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を追加します。
- 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにシンプルな長方形を追加しました。

```java
// PPTX を表す Prseetation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプの AutoShape を追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX ファイルをディスクに書き込む
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **スライドにフォーマットされた長方形を追加する**
スライドにフォーマットされた長方形を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、長方形タイプの [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) を追加します。
- 長方形の [Fill Type](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) をソリッドに設定します。
- [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) オブジェクトに関連付けられた [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) オブジェクトが提供する [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) メソッドを使用して、長方形の色を設定します。
- 長方形の線の色を設定します。
- 長方形の線の幅を設定します。
- 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

上記の手順は、以下の例で実装されています。

```java
// PPTX を表す Prseetation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプの AutoShape を追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 長方形の形状にいくつかのフォーマットを適用
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 長方形の線にいくつかのフォーマットを適用
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX ファイルをディスクに書き込む
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```