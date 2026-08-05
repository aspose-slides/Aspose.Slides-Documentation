---
title: Android でプレゼンテーションにライン シェイプを追加する
linktitle: ライン
type: docs
weight: 50
url: /ja/androidjava/line/
keywords:
- ライン
- ラインの作成
- ラインの追加
- プレーン ライン
- ラインの構成
- ラインのカスタマイズ
- 破線スタイル
- 矢じり
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint プレゼンテーションのライン書式設定を操作する方法を学びます。プロパティ、メソッド、Java のサンプルをご紹介します。"
---
## **概要**

Aspose.Slides を使用すると、プログラムで PowerPoint スライドにライン シェイプを追加できます。この記事では、シンプルなラインの作成方法と、ラインを矢印として表示する方法を示します。

スライドにライン シェイプを追加し、外観を調整し、更新されたプレゼンテーションを保存する方法を学びます。例では、スタイル、幅、破線パターン、矢じりオプション、塗りつぶし色など、実用的なライン書式設定に焦点を当てています。

## **プレーン ラインの作成**

プレゼンテーションの選択したスライドにシンプルなプレーン ラインを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、ライン タイプの AutoShape を追加します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しています。

```java
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);
    
    // タイプが line の AutoShape を追加する
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX をディスクに書き込む
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **矢印形状のラインの作成**

Aspose.Slides for Android via Java でも、開発者はラインのプロパティを設定して、より魅力的に見せることができます。ラインのいくつかのプロパティを設定して矢印のように見せてみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、ライン タイプの AutoShape を追加します。
- [Line Style](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/LineStyle) を Aspose.Slides for Android via Java が提供するスタイルのいずれかに設定します。
- ラインの幅を設定します。
- ラインの [Dash Style](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/LineDashStyle) を Aspose.Slides for Android via Java が提供するスタイルのいずれかに設定します。
- ラインの開始点の [Arrow Head Style](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/LineArrowheadLength) を設定します。
- ラインの終了点の [Arrow Head Style](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/LineArrowheadLength) を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

```java
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // タイプが line の AutoShape を追加する
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ラインにいくつかの書式設定を適用する
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

いいえ。通常のライン（タイプが [Line](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapetype/) の [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/)）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/androidjava/connector/) を使用してください。

**ラインのプロパティがテーマから継承されていて最終的な値が判断しづらい場合はどうすればよいですか？**

継承およびテーマ スタイルを考慮した、実際のプロパティは [ILineFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilineformateffectivedata/) / [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinefillformateffectivedata/) インターフェイスを使用して [実効プロパティを読む](/slides/ja/androidjava/shape-effective-properties/) ことで取得できます。

**ラインの編集（移動、サイズ変更）をロックできますか？**

はい。Shapes は編集操作を禁止できる [lock objects](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) を提供しています。