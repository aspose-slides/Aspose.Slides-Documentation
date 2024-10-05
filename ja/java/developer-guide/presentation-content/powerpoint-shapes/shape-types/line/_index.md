---
title: 線
type: docs
weight: 50
url: /java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides for Javaは、スライドにさまざまな種類の図形を追加することをサポートしています。このトピックでは、スライドに線を追加することで図形の操作を開始します。Aspose.Slides for Javaを使用すると、開発者は単純な線を作成するだけでなく、スライド上にいくつかの華やかな線を描画することもできます。

{{% /alert %}} 

## **単純な線の作成**

プレゼンテーションの選択したスライドに単純な平面の線を追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)オブジェクトが公開する[addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、線のタイプのAutoShapeを追加します。
- 修正したプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドに線を追加しました。

```java
// PPTXファイルを表すPresentationExクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 線のタイプのAutoShapeを追加
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTXをディスクに書き込む
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **矢印型の線の作成**

Aspose.Slides for Javaは、開発者が線の見た目をより魅力的にするためにいくつかのプロパティを設定することを許可します。線を矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)オブジェクトが公開する[addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)メソッドを使用して、線のタイプのAutoShapeを追加します。
- [線のスタイル](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle)をAspose.Slides for Javaが提供するスタイルの1つに設定します。
- 線の幅を設定します。
- 線の[ダッシュスタイル](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle)をAspose.Slides for Javaが提供するスタイルの1つに設定します。
- 線の始点の[矢印ヘッドスタイル](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle)と[長さ](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength)を設定します。
- 線の終点の[矢印ヘッドスタイル](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle)と[長さ](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength)を設定します。
- 修正したプレゼンテーションをPPTXファイルとして書き込みます。

```java
// PPTXファイルを表すPresentationExクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 線のタイプのAutoShapeを追加
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