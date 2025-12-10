---
title: .NET でプレゼンテーションに楕円を追加
linktitle: 楕円
type: docs
weight: 30
url: /ja/net/ellipse/
keywords:
- 楕円
- 図形
- 楕円を追加
- 楕円を作成
- 楕円を描画
- 書式設定された楕円
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PPT および PPTX プレゼンテーション内の楕円形を作成、書式設定、および操作する方法を学びます—C# のコード例が含まれています。"
---

## **楕円の作成**
このトピックでは、Aspose.Slides for .NET を使用してスライドに楕円形を追加する方法をご紹介します。Aspose.Slides for .NET は、数行のコードだけでさまざまな形状を描画できる簡単な API を提供します。プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従ってください。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します
1. インデックスを使用してスライドの参照を取得します
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加します
1. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します

以下の例では、最初のスライドに楕円を追加しています。
```c#
 // PPTX を表す Presentation クラスのインスタンスを作成します
 using (Presentation pres = new Presentation())
 {
 
     // 最初のスライドを取得します
     ISlide sld = pres.Slides[0];
 
     // 楕円タイプの AutoShape を追加します
     sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     //PPTX ファイルをディスクに書き込みます
     pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
 }
```




## **書式設定された楕円の作成**
スライドにより書式設定された楕円を追加するには、以下の手順に従ってください。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Ellipse タイプの AutoShape を追加します。
1. 楕円の塗りつぶしタイプを Solid に設定します。
1. IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、楕円の色を設定します。
1. 楕円の線の色を設定します。
1. 楕円の線の幅を設定します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

以下の例では、プレゼンテーションの最初のスライドに書式設定された楕円を追加しています。
```c#
 // PPTX を表す Presentation クラスのインスタンスを作成します
 using (Presentation pres = new Presentation())
 {
 
     // 最初のスライドを取得します
     ISlide sld = pres.Slides[0];
 
     // 楕円タイプの AutoShape を追加します
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     // 楕円シェイプにいくつかの書式設定を適用します
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // 楕円の線にいくつかの書式設定を適用します
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     // PPTX ファイルをディスクに書き込みます
     pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
 }
```


## **FAQ**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常 **ポイント** 単位で指定します。予測可能な結果を得るために、スライドサイズを基準に計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**楕円を他のオブジェクトの上または下に配置するにはどうすればよいですか（スタック順序の制御）？**

オブジェクトの描画順序を前面に持ってくるか背面に送ることで調整します。これにより、楕円が他のオブジェクトと重なったり、下にあるオブジェクトを表示したりできます。

**楕円の出現や強調をアニメーションさせるにはどうすればよいですか？**

[適用](/slides/ja/net/shape-animation/) 入場、強調、または退出効果を形状に適用し、トリガーとタイミングを設定してアニメーションの再生時期と方法を制御します。