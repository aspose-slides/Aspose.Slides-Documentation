---
title: エリプス
type: docs
weight: 30
url: /net/ellipse/
keywords: "エリプス, PowerPoint シェイプ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET を使用して PowerPoint プレゼンテーションにエリプスを作成する"
---


## **エリプスの作成**
このトピックでは、Aspose.Slides for .NET を使用してスライドにエリプスシェイプを追加する方法について開発者に紹介します。Aspose.Slides for .NET は、わずかな行数のコードでさまざまな種類のシェイプを描画するための簡単な API セットを提供します。プレゼンテーションの選択されたスライドに単純なエリプスを追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します
1. インデックスを使用してスライドの参照を取得します
1. IShapes オブジェクトによって公開されている AddAutoShape メソッドを使用してエリプスタイプの AutoShape を追加します
1. 修正されたプレゼンテーションを PPTX ファイルとして保存します

以下の例では、最初のスライドにエリプスを追加しました。

```c#
// PPTX を表す Prseetation クラスをインスタンス化します
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // エリプスタイプのオートシェイプを追加します
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // PPTX ファイルをディスクに書き込みます
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **フォーマットされたエリプスの作成**
スライドにより良いフォーマットのエリプスを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトによって公開されている AddAutoShape メソッドを使用してエリプスタイプの AutoShape を追加します。
1. エリプスの塗りつぶしタイプをソリッドに設定します。
1. IShape オブジェクトに関連付けられた FillFormat オブジェクトによって公開されている SolidFillColor.Color プロパティを使用してエリプスの色を設定します。
1. エリプスの線の色を設定します。
1. エリプスの線の幅を設定します。
1. 修正されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにフォーマットされたエリプスを追加しました。

```c#
// PPTX を表す Prseetation クラスをインスタンス化します
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // エリプスタイプのオートシェイプを追加します
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // エリプスシェイプにいくつかのフォーマットを適用します
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // エリプスの線にいくつかのフォーマットを適用します
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // PPTX ファイルをディスクに書き込みます
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```