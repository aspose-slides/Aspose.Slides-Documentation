---
title: Android でプレゼンテーションにライン形状を追加する
linktitle: ライン
type: docs
weight: 50
url: /ja/androidjava/Line/
keywords:
- ライン
- ライン作成
- ライン追加
- 普通のライン
- ライン設定
- ラインカスタマイズ
- ダッシュスタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint プレゼンテーションのライン書式設定を操作する方法を学びます。プロパティ、メソッド、Java のサンプルをご紹介します。"
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java はスライドにさまざまな形状を追加することをサポートします。このトピックでは、形状の操作を開始し、スライドにラインを追加します。Aspose.Slides for Android via Java を使用すると、開発者は単純なラインを作成できるだけでなく、派手なラインもスライドに描画できます。

{{% /alert %}} 

## **単純なラインの作成**

プレゼンテーションの選択したスライドに単純なラインを追加するには、以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- IShapeCollection オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しています。
```java
// PPTX ファイルを表す PresentationEx クラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // ラインタイプの AutoShape を追加
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX をディスクに書き込む
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **矢印形状のラインの作成**

Aspose.Slides for Android via Java は、ラインをより魅力的に見せるためにいくつかのプロパティを設定できるようにします。矢印のように見せるためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- IShapeCollection オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- [Line Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) を Aspose.Slides for Android via Java が提供するスタイルのいずれかに設定します。
- ラインの幅を設定します。
- [Dash Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) を提供されているスタイルのいずれかに設定します。
- ラインの開始点の [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) を設定します。
- ラインの終了点の [Arrow Head Style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) を設定します。
- 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。
```java
// PPTX ファイルを表す PresentationEx クラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // ラインタイプの AutoShape を追加
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ラインにいくつかの書式設定を適用
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

**通常のラインをコネクタに変換して、図形に「スナップ」させることはできますか？**

できません。通常のライン（[AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/) のタイプが [Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) のもの）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/) タイプと接続用の [corresponding APIs](/slides/ja/androidjava/connector/) を使用してください。

**ラインのプロパティがテーマから継承され、最終的な値を判断しにくい場合はどうすればよいですか？**

[Read the effective properties](/slides/ja/androidjava/shape-effective-properties/) を ILineFormatEffectiveData (https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) / ILineFillFormatEffectiveData (https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinefillformateffectivedata/) インターフェイスを通じて確認してください。これらは継承およびテーマ スタイルを考慮した上での有効なプロパティを提供します。

**ラインを編集（移動、サイズ変更）できないようにロックできますか？**

はい。Shapes は [lock objects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) を提供しており、これにより [disallow editing operations](/slides/ja/androidjava/applying-protection-to-presentation/) を行うことができます。