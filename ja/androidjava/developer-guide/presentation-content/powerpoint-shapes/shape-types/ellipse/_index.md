---
title: Android のプレゼンテーションに楕円を追加する
linktitle: 楕円
type: docs
weight: 30
url: /ja/androidjava/ellipse/
keywords:
- 楕円
- 図形
- 楕円を追加
- 楕円を作成
- 楕円を描画
- 書式設定された楕円
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android で PPT および PPTX プレゼンテーションにおける楕円形の作成、書式設定、操作方法を学びます—Java のコード例を含みます。"
---

{{% alert color="primary" %}} 

このトピックでは、Aspose.Slides for Android via Java を使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for Android via Java は、数行のコードだけでさまざまな形状を描画できる簡単な API を提供します。

{{% /alert %}} 

## **楕円の作成**
プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- IShapeCollection オブジェクトが提供する addAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。

以下の例では、最初のスライドに楕円を追加しています
```java
// PPTX を表す Presentation クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 楕円タイプの AutoShape を追加
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTX ファイルをディスクに書き込む
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **書式設定された楕円の作成**
スライドに書式設定された楕円を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- IShapeCollection オブジェクトが提供する addAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加します。
- 楕円の塗りつぶしタイプを Solid に設定します。
- IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、楕円の色を設定します。
- 楕円の線の色を設定します。
- 楕円の線の幅を設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに書式設定された楕円を追加しています。
```java
// PPTX を表す Presentation クラスのインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 楕円タイプの AutoShape を追加
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 楕円形にいくつかの書式設定を適用
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // 楕円の線にいくつかの書式設定を適用
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX ファイルをディスクに書き込む
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常、ポイント単位で指定されます。予測可能な結果を得るために、スライドのサイズを基準に計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**楕円を他のオブジェクトの上または下に配置（スタック順を制御）するにはどうすればよいですか？**

オブジェクトの描画順序を前面に持ってくるか背面に送ることで調整します。これにより、楕円が他のオブジェクトと重なったり、背後のオブジェクトを表示したりできます。

**楕円の表示や強調のアニメーションを付けるにはどうすればよいですか？**

形状に対して[Apply](/slides/ja/androidjava/shape-animation/) の入場、強調、または退出効果を適用し、トリガーとタイミングを設定してアニメーションの再生タイミングと方法を制御します。