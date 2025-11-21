---
title: .NET でプレゼンテーションに矩形を追加
linktitle: 矩形
type: docs
weight: 80
url: /ja/net/rectangle/
keywords:
- 矩形を追加
- 矩形を作成
- 矩形シェイプ
- シンプルな矩形
- 書式設定された矩形
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して矩形を追加し、PowerPoint プレゼンテーションを強化しましょう。プログラムから形状を簡単に設計・変更できます。"
---

## **シンプルな矩形を作成**
前のトピックと同様に、本トピックも図形の追加について解説しますが、今回は矩形について説明します。本トピックでは、開発者が Aspose.Slides for .NET を使用してスライドにシンプルまたは書式設定された矩形を追加する方法を紹介しました。プレゼンテーションの選択したスライドにシンプルな矩形を追加するには、以下の手順に従ってください。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加します。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな矩形を追加しています。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // 矩形タイプのオートシェイプを追加
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //PPTX ファイルをディスクに保存
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **書式設定された矩形を作成**
スライドに書式設定された矩形を追加するには、以下の手順に従ってください。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加します。
1. 矩形の塗りつぶしタイプを Solid に設定します。
1. IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、矩形の色を設定します。
1. 矩形の線の色を設定します。
1. 矩形の線の幅を設定します。
1. 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。
上記の手順は、以下の例で実装されています。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // 矩形タイプのオートシェイプを追加
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 矩形シェイプにいくつかの書式設定を適用
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 矩形の線にいくつかの書式設定を適用
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //PPTX ファイルをディスクに書き込む
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**角が丸い矩形はどうやって追加しますか？**  
角丸の [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) を使用し、形状のプロパティでコーナー半径を調整します。ジオメトリ調整により各コーナーごとに丸めることも可能です。

**画像（テクスチャ）で矩形を塗りつぶすにはどうすればよいですか？**  
ピクチャの [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) を設定します。

**矩形に影や光彩を付けることはできますか？**  
はい。[Outer/inner shadow, glow, and soft edges](/slides/ja/net/shape-effect/) が利用でき、パラメータを調整できます。

**矩形をハイパーリンク付きのボタンにできますか？**  
はい。形状のクリックに対して [Assign a hyperlink](/slides/ja/net/manage-hyperlinks/) を設定すれば、スライド、ファイル、Web アドレス、またはメールにジャンプできます。

**矩形が移動や変更されないように保護するにはどうすればよいですか？**  
[Use shape locks](/slides/ja/net/applying-protection-to-presentation/): 移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**矩形をラスタ画像または SVG に変換できますか？**  
はい。指定したサイズ/スケールで画像に [render the shape](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) したり、ベクター用途のために [export it as SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) したりできます。

**テーマや継承を考慮した矩形の実際（有効）プロパティを簡単に取得するにはどうすればよいですか？**  
[Use the shape’s effective properties](/slides/ja/net/shape-effective-properties/): API はテーマスタイル、レイアウト、ローカル設定を考慮した計算済みの値を返し、書式分析を簡素化します。