---
title: 線
type: docs
weight: 50
url: /ja/androidjava/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides for Android via Java は、スライドにさまざまな種類の図形を追加することをサポートしています。このトピックでは、スライドに線を追加することから図形の作成を始めます。Aspose.Slides for Android via Java を使用することで、開発者は単純な線だけでなく、スライド上に装飾的な線も描画できます。

{{% /alert %}} 

## **単純な線の作成**

プレゼンテーションの選択したスライドに単純な線を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドのリファレンスを取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトによって公開されている [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、線型の自動図形を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しました。

```java
// PPTXファイルを表すPresentationExクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 線型のAutoShapeを追加
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTXをディスクに書き込む
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **矢印型の線の作成**

Aspose.Slides for Android via Java は、開発者が線のプロパティを設定して、見た目をより魅力的にすることもできます。線を矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドのリファレンスを取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトによって公開されている [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、線型の自動図形を追加します。
- [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) を、Aspose.Slides for Android via Java によって提供されるスタイルのいずれかに設定します。
- 線の幅を設定します。
- 線の [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) を、Aspose.Slides for Android via Java によって提供されるスタイルのいずれかに設定します。
- 線の始点の [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) を設定します。
- 線の終点の [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして保存します。

```java
// PPTXファイルを表すPresentationExクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 線型のAutoShapeを追加
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 線にいくつかのフォーマットを適用
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTXをディスクに書き込む
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```