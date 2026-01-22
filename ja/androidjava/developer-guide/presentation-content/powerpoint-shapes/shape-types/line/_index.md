---
title: Android 上のプレゼンテーションに線形状を追加
linktitle: 線
type: docs
weight: 50
url: /ja/androidjava/Line/
keywords:
- 線
- 線の作成
- 線の追加
- プレーンライン
- 線の構成
- 線のカスタマイズ
- 破線スタイル
- 矢じり
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint プレゼンテーションの線の書式設定を操作する方法を学びます。プロパティ、メソッド、および Java の例を紹介します。"
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java は、スライドにさまざまな種類の図形を追加することをサポートしています。このトピックでは、図形の操作を開始するためにスライドに線を追加します。Aspose.Slides for Android via Java を使用すると、開発者は単純な線だけでなく、装飾的な線もスライドに描くことができます。

{{% /alert %}} 

## **プレーンラインの作成**

プレゼンテーションの選択されたスライドにシンプルなプレーンラインを追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```java
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // type が line の AutoShape を追加
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX をディスクに書き込む
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **矢印形状のラインの作成**

Aspose.Slides for Android via Java は、ラインの外観を向上させるためにいくつかのプロパティを設定することも可能です。ラインを矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) を Aspose.Slides for Android via Java が提供するスタイルのいずれかに設定します。
- ラインの幅を設定します。
- [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) を Aspose.Slides for Android via Java が提供するスタイルのいずれかに設定します。
- ラインの開始点の [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) を設定します。
- ラインの終了点の [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。
```java
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // line タイプの AutoShape を追加
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 線に書式設定を適用
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTX をディスクに書き込む
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**通常の線をコネクタに変換して図形に「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) のタイプが [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) のもの）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) タイプと接続用の [corresponding APIs](/slides/ja/androidjava/connector/) を使用してください。

**テーマから継承された線のプロパティが原因で最終的な値が分かりにくい場合はどうすればよいですか？**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) / [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/) インターフェイスを通じて [効果的なプロパティ](/slides/ja/androidjava/shape-effective-properties/) を取得してください。これらは継承やテーマスタイルを考慮した上で値を提供します。

**線を編集（移動、サイズ変更）できないようにロックできますか？**

はい。図形は [ロック オブジェクト](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) を提供しており、編集操作を禁止することができます。