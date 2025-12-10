---
title: ".NET でプレゼンテーションに線形図形を追加"
linktitle: "線"
type: docs
weight: 50
url: /ja/net/Line/
keywords:
  - "線"
  - "線の作成"
  - "線の追加"
  - "単純な線"
  - "線の設定"
  - "線のカスタマイズ"
  - "破線スタイル"
  - "矢印ヘッド"
  - "PowerPoint"
  - "プレゼンテーション"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションの線書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルをご紹介します。"
---

Aspose.Slides for .NET はスライドにさまざまな種類の図形を追加することをサポートします。このトピックでは、図形の操作を開始し、スライドに線を追加します。Aspose.Slides for .NET を使用すると、開発者は単純な線を作成できるだけでなく、いくつかの装飾的な線もスライド上に描画できます。

## **単純な線の作成**
スライドの選択したスライドに単純な線を追加するには、以下の手順に従ってください。

- [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが公開する [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```c#
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 線タイプのオートシェイプを追加します
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // PPTX をディスクに保存します
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **矢印形状の線の作成**
Aspose.Slides for .NET は、線の外観を向上させるためにいくつかのプロパティを設定することも可能です。線を矢印のように見せるために、以下の手順でプロパティを設定してください。

- Presentation クラスのインスタンスを作成します[Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/)。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが公開する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for .NET が提供するスタイルのいずれかにラインスタイルを設定します。
- 線の幅を設定します。
- Aspose.Slides for .NET が提供するスタイルのいずれかに線の [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) を設定します。
- 線の開始点の [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) と長さを設定します。
- 線の終了点の矢尻スタイルと長さを設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。
```c#
 // PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
 using (Presentation pres = new Presentation())
 {
 
     // 最初のスライドを取得
     ISlide sld = pres.Slides[0];
 
     // 線タイプのオートシェイプを追加
     IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
 
     // 線にいくつかの書式設定を適用
     shp.LineFormat.Style = LineStyle.ThickBetweenThin;
     shp.LineFormat.Width = 10;
 
     shp.LineFormat.DashStyle = LineDashStyle.DashDot;
 
     shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
     shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;
 
     shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
     shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
 
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;
 
     // PPTX をディスクに保存
     pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
 }
```


## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。形状にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) タイプと接続用の [corresponding APIs](/slides/ja/net/connector/) を使用してください。

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/ja/net/shape-effective-properties/) を [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) インターフェイスを通じて確認してください—これらはすでに継承とテーマスタイルを考慮しています。

**Can I lock a line against editing (moving, resizing)?**

はい。Shapes は [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) を提供しており、[disallow editing operations](/slides/ja/net/applying-protection-to-presentation/) を行うことができます。