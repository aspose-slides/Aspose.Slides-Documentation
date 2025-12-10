---
title: Javaでプレゼンテーションにラインシェイプを追加
linktitle: ライン
type: docs
weight: 50
url: /ja/java/Line/
keywords:
- 線
- 線の作成
- 線の追加
- 単純な線
- 線の設定
- 線のカスタマイズ
- 破線スタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションの線の書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルをご紹介します。"
---

{{% alert color="primary" %}} 
Aspose.Slides for Java はスライドにさまざまな形状を追加することをサポートしています。このトピックでは、形状の操作を開始し、スライドに線を追加します。Aspose.Slides for Java を使用すると、開発者は単純な線だけでなく、装飾的な線もスライドに描くことができます。
{{% /alert %}} 

## **プレーンラインの作成**

プレゼンテーションの選択されたスライドにシンプルなプレーンラインを追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- Index を使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを書き込み、PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```java
// PPTX ファイルを表す PresentationEx クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // line タイプの AutoShape を追加
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX をディスクに書き込む
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **矢印付きラインの作成**

Aspose.Slides for Java は、開発者がラインのプロパティを設定して、見栄えを良くすることも可能です。ラインを矢印のように見せるために、いくつかのプロパティを設定してみましょう。以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- Index を使用してスライドの参照を取得します。
- [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Line タイプの AutoShape を追加します。
- [Line Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) を Aspose.Slides for Java が提供するスタイルのいずれかに設定します。
- ラインの幅を設定します。
- [Dash Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) を Aspose.Slides for Java が提供するスタイルのいずれかに設定します。
- ラインの開始点の [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) を設定します。
- ラインの終了点の [Arrow Head Style](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) と [Length](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) を設定します。
- 変更されたプレゼンテーションを書き込み、PPTX ファイルとして保存します。
```java
// PPTX ファイルを表す PresentationEx クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // line タイプの AutoShape を追加
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 線にいくつかの書式設定を適用
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


## **よくある質問**

**通常の線をコネクタに変換して、形状に「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。形状にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/java/com.aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/java/connector/) を使用してください。

**ラインのプロパティがテーマから継承されていて、最終的な値を判断しにくい場合はどうすればよいですか？**

[効果的なプロパティを読む](/slides/ja/java/shape-effective-properties/) には、[ILineFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ilinefillformateffectivedata/) インターフェイスを使用します—これらは継承とテーマスタイルをすでに考慮しています。

**ラインを編集（移動、サイズ変更）からロックできますか？**

はい。Shapes は [lock objects](https://reference.aspose.com/slides/java/com.aspose.slides/autoshape/#getAutoShapeLock--) を提供しており、[disallow editing operations](/slides/ja/java/applying-protection-to-presentation/) が可能です。