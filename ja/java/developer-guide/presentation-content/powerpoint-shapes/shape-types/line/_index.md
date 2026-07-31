---
title: Javaでプレゼンテーションに線形シェイプを追加
linktitle: 線形
type: docs
weight: 50
url: /ja/java/line/
keywords:
- 線
- 線形の作成
- 線形の追加
- 単純な線形
- 線形の構成
- 線形のカスタマイズ
- 破線スタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint プレゼンテーションでの線形書式設定を Aspose.Slides for Java を使用して操作する方法を学びます。プロパティ、メソッド、サンプルを紹介します。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint スライドにプログラムで線形シェイプを追加できます。この記事では、単純な線を作成する方法と、線を矢印として表示する方法を示します。

線形シェイプをスライドに追加し、外観を調整し、更新されたプレゼンテーションを保存する方法を学びます。例では、スタイル、幅、破線パターン、矢印ヘッドオプション、塗りつぶし色など、実用的な線の書式設定に焦点を当てています。

## **単純な線の作成**

プレゼンテーションの選択されたスライドにシンプルな平線を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。

```java
// PPTX ファイルを表す PresentationEx クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // line タイプの AutoShape を追加
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX をディスクに保存
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **矢印形状の線の作成**

Aspose.Slides for Java でも、線のプロパティを設定して見た目を向上させることができます。線を矢印のように見せるために、いくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for Java が提供するスタイルのいずれかに、[Line Style](https://reference.aspose.com/slides/ja/java/com.aspose.slides/LineStyle) を設定します。
- 線の幅を設定します。
- Aspose.Slides for Java が提供するスタイルのいずれかに、[Dash Style](https://reference.aspose.com/slides/ja/java/com.aspose.slides/LineDashStyle) を設定します。
- 線の開始点の [Arrow Head Style](https://reference.aspose.com/slides/ja/java/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/ja/java/com.aspose.slides/LineArrowheadLength) を設定します。
- 線の終了点の [Arrow Head Style](https://reference.aspose.com/slides/ja/java/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/ja/java/com.aspose.slides/LineArrowheadLength) を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

```java
// PPTX ファイルを表す PresentationEx クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // line タイプの AutoShape を追加
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 線に対していくつかの書式設定を適用
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTX をディスクに保存
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**通常の線をコネクタに変換して図形に「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/ja/java/com.aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/java/connector/) を使用してください。

**線のプロパティがテーマから継承されていて最終値が分かりにくい場合はどうすればよいですか？**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinefillformateffectivedata/) インターフェイスを使用して [effective properties](/slides/ja/java/shape-effective-properties/) を取得します。これらは継承およびテーマスタイルが考慮された状態です。

**線の編集（移動、サイズ変更）をロックできますか？**

はい。シェイプは [lock objects](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/#getAutoShapeLock--) を提供しており、[editing operations を禁止する](/slides/ja/java/applying-protection-to-presentation/) ことができます。