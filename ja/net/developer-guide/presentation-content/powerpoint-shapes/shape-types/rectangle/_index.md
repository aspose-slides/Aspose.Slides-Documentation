---
title: .NET でプレゼンテーションに長方形を追加
linktitle: 長方形
type: docs
weight: 80
url: /ja/net/rectangle/
keywords:
- 長方形を追加
- 長方形を作成
- 長方形シェイプ
- シンプルな長方形
- 書式設定された長方形
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して長方形を追加し、PowerPoint プレゼンテーションを強化します。シェイプを簡単にプログラムで設計・変更できます。"
---

## **単純な長方形の作成**
前回と同様に、今回も図形の追加について説明します。今回は Rectangle（長方形）です。このトピックでは、開発者が Aspose.Slides for .NET を使用してスライドに単純な長方形または書式設定された長方形を追加する方法を説明します。プレゼンテーションの選択したスライドに単純な長方形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。

以下の例では、プレゼンテーションの最初のスライドに単純な長方形を追加しています。
```c#
// PPTX を表す Presentation クラスをインスタンス化します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 長方形タイプのオートシェイプを追加します
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX ファイルをディスクに保存します
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **書式設定された長方形の作成**
スライドに書式設定された長方形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapes オブジェクトが提供する AddAutoShape メソッドを使用して、Rectangle タイプの IAutoShape を追加します。
1. 長方形の塗りつぶしタイプを Solid に設定します。
1. IShape オブジェクトに関連付けられた FillFormat オブジェクトが提供する SolidFillColor.Color プロパティを使用して、長方形の色を設定します。
1. 長方形の線の色を設定します。
1. 長方形の線の幅を設定します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。
上記の手順は以下の例で実装されています。
```c#
// PPTX を表す Prseetation クラスをインスタンス化します
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 長方形タイプのオートシェイプを追加します
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 長方形シェイプに書式設定を適用します
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 長方形の線に書式設定を適用します
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //PPTX ファイルをディスクに保存します
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**角が丸い長方形を追加するには？**

丸角の [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) を使用し、シェイプのプロパティでコーナー半径を調整します。ジオメトリの調整により、コーナーごとに丸みを設定することも可能です。

**画像（テクスチャ）で長方形を塗りつぶすには？**

画像の [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/) を選択し、画像ソースを指定し、[stretching/tiling modes](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) を構成します。

**長方形に影やグローを付けられますか？**

はい。[Outer/inner shadow, glow, and soft edges](/slides/ja/net/shape-effect/) が利用でき、パラメータを調整可能です。

**長方形をハイパーリンク付きボタンにできますか？**

はい。シェイプのクリックに対して [Assign a hyperlink](/slides/ja/net/manage-hyperlinks/) を設定すれば、スライド、ファイル、Web アドレス、またはメールへのジャンプが可能です。

**長方形の移動や変更から保護するには？**

[Use shape locks](/slides/ja/net/applying-protection-to-presentation/) を使用します。移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**長方形をラスタ画像または SVG に変換できますか？**

はい。指定したサイズ/スケールで [render the shape](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) を画像に変換したり、ベクタ用途のために [export it as SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) したりできます。

**テーマや継承を考慮した長方形の実際の（有効な）プロパティをすぐに取得するには？**

[Use the shape’s effective properties](/slides/ja/net/shape-effective-properties/) を使用します。API はテーマスタイル、レイアウト、ローカル設定を考慮した計算済みの値を返し、書式解析を簡素化します。