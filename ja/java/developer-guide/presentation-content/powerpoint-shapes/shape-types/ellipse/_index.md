---
title: Javaでプレゼンテーションに楕円を追加する
linktitle: 楕円
type: docs
weight: 30
url: /ja/java/ellipse/
keywords:
- 楕円
- 形状
- 楕円を追加
- 楕円を作成
- 楕円を描画
- 書式設定された楕円
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PPT および PPTX プレゼンテーションで楕円形を作成、書式設定、操作する方法を学びます。Java コード例を含む。"
---

{{% alert color="primary" %}} 

このトピックでは、Aspose.Slides for Java を使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for Java は、数行のコードだけでさまざまな形状を描画できる使いやすい API を提供します。

{{% /alert %}} 

## **楕円の作成**
プレゼンテーションの選択されたスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)
- インデックスを使用してスライドの参照を取得します。
- IShapeCollection オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Ellipse タイプの AutoShape を追加します。[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、最初のスライドに楕円を追加しています。
```java
// PPTX を表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 楕円タイプの AutoShape を追加する
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTX ファイルをディスクに書き込む
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **フォーマットされた楕円の作成**
スライドにより適切にフォーマットされた楕円を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)
- インデックスを使用してスライドの参照を取得します。
- IShapeCollection オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) メソッドを使用して、Ellipse タイプの AutoShape を追加します。[IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)
- 楕円の塗りつぶしタイプを Solid に設定します。
- [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) オブジェクトに関連付けられた [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) オブジェクトが提供する SolidFillColor.Color プロパティを使用して、楕円の色を設定します。
- 楕円の線の色を設定します。
- 楕円の線の幅を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドにフォーマットされた楕円を追加しています。
```java
// PPTX を表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円タイプの AutoShape を追加する
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 楕円シェイプにいくつかの書式設定を適用する
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // 楕円の輪郭線にいくつかの書式設定を適用する
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX ファイルをディスクに書き込む
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常 **ポイント**で指定されます。予測可能な結果を得るために、スライドのサイズに基づいて計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**他のオブジェクトの上または下に楕円を配置するにはどうすればよいですか（スタック順序の制御）？**

オブジェクトの描画順序を前面に持ってくるか背面に送ることで調整します。これにより、楕円が他のオブジェクトと重なったり、背後にあるオブジェクトを表示したりできます。

**楕円の表示や強調にアニメーションを付けるにはどうすればよいですか？**

[Apply](/slides/ja/java/shape-animation/) を使用して、シェイプに入場、強調、または終了エフェクトを適用し、トリガーとタイミングを設定してアニメーションの再生タイミングと方法を制御します。