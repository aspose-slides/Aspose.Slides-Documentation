---
title: ".NET でプレゼンテーションに楕円を追加する"
linktitle: "楕円"
type: docs
weight: 30
url: /ja/net/ellipse/
keywords:
- "楕円"
- "形状"
- "楕円を追加"
- "楕円を作成"
- "楕円を描画"
- "書式設定された楕円"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET で PPT および PPTX プレゼンテーションの楕円形を作成、書式設定、操作する方法を学びます（C# のコード例付き）。"
---

## **楕円の作成**
このトピックでは、Aspose.Slides for .NET を使用してスライドに楕円形を追加する方法を開発者に紹介します。Aspose.Slides for .NET は、数行のコードでさまざまな形状を描画できる使いやすい API を提供します。プレゼンテーションの選択スライドに単純な楕円を追加するには、以下の手順に従ってください。

1. [プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成する
1. インデックスを使用してスライドの参照を取得する
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加する
1. 変更したプレゼンテーションを PPTX ファイルとして保存する

以下の例では、最初のスライドに楕円を追加しています。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成する
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得する
    ISlide sld = pres.Slides[0];

    // 楕円タイプの AutoShape を追加する
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //PPTX ファイルをディスクに保存する
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```




## **書式設定された楕円の作成**
スライドに書式設定された楕円を追加するには、以下の手順に従ってください。

1. [プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成する
1. インデックスを使用してスライドの参照を取得する
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加する
1. 楕円の塗りつぶしタイプを Solid に設定する
1. FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、楕円の塗りつぶし色を設定する
1. 楕円の線の色を設定する
1. 楕円の線の幅を設定する
1. 変更したプレゼンテーションを PPTX ファイルとして保存する

以下の例では、プレゼンテーションの最初のスライドに書式設定された楕円を追加しています。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成する
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得する
    ISlide sld = pres.Slides[0];

    // 楕円タイプのオートシェイプを追加する
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 楕円シェイプにいくつかの書式設定を適用する
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 楕円の線にいくつかの書式設定を適用する
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //PPTX ファイルをディスクに保存する
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常 **ポイント** 単位で指定します。予測可能な結果を得るには、スライドサイズを基準に計算し、必要なミリメートルやインチをポイントに換算してから値を設定してください。

**楕円を他のオブジェクトの上または下に配置する（スタック順を制御する）にはどうすればよいですか？**

オブジェクトの描画順序を調整し、前面に持ってくるか背面に送ることで、楕円が他のオブジェクトと重なったり、背後のオブジェクトが透けて見えるようにできます。

**楕円の表示や強調のアニメーションを付けるにはどうすればよいですか？**

[Apply](/slides/ja/net/shape-animation/) エフェクトで入口、強調、または終了アニメーションを形状に適用し、トリガーやタイミングを設定して、アニメーションの開始タイミングと方法を制御します。