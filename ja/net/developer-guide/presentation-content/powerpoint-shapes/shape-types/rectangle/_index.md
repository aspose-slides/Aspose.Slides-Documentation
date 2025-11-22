---
title: 矩形
type: docs
weight: 80
url: /ja/net/rectangle/
keywords: "矩形の作成, PowerPoint 図形, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションに矩形を作成します"
---

## **シンプルな矩形の作成**
前回のトピックと同様に、今回も図形の追加について説明しますが、今回扱う図形は矩形です。このトピックでは、開発者が Aspose.Slides for .NET を使用してスライドにシンプルまたは書式設定された矩形を追加できる方法を説明しました。プレゼンテーションの選択したスライドにシンプルな矩形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、矩形タイプの IAutoShape を追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドにシンプルな矩形を追加しています。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // 矩形タイプのオートシェイプを追加
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Write PPTX ファイルをディスクに保存
}
```


## **書式設定された矩形の作成**
スライドに書式設定された矩形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、矩形タイプの IAutoShape を追加します。
1. 矩形の塗りつぶしタイプを Solid に設定します。
1. IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、矩形の色を設定します。
1. 矩形の線の色を設定します。
1. 矩形の線の幅を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。
上記の手順は、以下の例で実装されています。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // 矩形タイプのオートシェイプを追加
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 矩形シェイプに書式設定を適用
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 矩形の線に書式設定を適用
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //PPTX ファイルをディスクに保存
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**角丸矩形を追加するにはどうすればよいですか？**  
角丸の [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) を使用し、図形のプロパティでコーナー半径を調整します。ジオメトリの調整により、コーナーごとに丸めを適用することも可能です。

**矩形に画像（テクスチャ）を貼り付けるにはどうすればよいですか？**  
画像 [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) を設定します。

**矩形に影やグローを付けることはできますか？**  
はい。調整可能なパラメータで [Outer/inner shadow, glow, and soft edges](/slides/ja/net/shape-effect/) を使用できます。

**矩形をハイパーリンク付きのボタンに変えることはできますか？**  
はい。形状のクリックに対して [Assign a hyperlink](/slides/ja/net/manage-hyperlinks/) を設定すると、スライド、ファイル、ウェブアドレス、またはメールにジャンプできます。

**矩形が移動や変更されないように保護するにはどうすればよいですか？**  
[Use shape locks](/slides/ja/net/applying-protection-to-presentation/): 移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**矩形をラスタ画像や SVG に変換できますか？**  
はい。指定したサイズ/スケールで画像に [render the shape](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) したり、ベクタとして使用できるように [export it as SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) したりできます。

**テーマや継承を考慮した矩形の実際（実効）プロパティをすばやく取得するにはどうすればよいですか？**  
[Use the shape’s effective properties](/slides/ja/net/shape-effective-properties/): API はテーマスタイル、レイアウト、ローカル設定を考慮した計算済みの値を返すため、書式設定の分析が簡素化されます。