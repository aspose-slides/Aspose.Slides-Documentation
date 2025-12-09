---
title: .NET でプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/net/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーション テーマ
- スライド テーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマ効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でマスタープレゼンテーションテーマを使用し、一貫したブランディングで PowerPoint ファイルの作成、カスタマイズ、変換を行う。"
---

プレゼンテーション テーマは、デザイン要素のプロパティを定義します。プレゼンテーション テーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選んでいることになります。

PowerPoint では、テーマは色、[fonts](/slides/ja/net/powerpoint-fonts/)、[background styles](/slides/ja/net/presentation-background/)、および効果で構成されます。

![theme-constituents](theme-constituents.png)

## **テーマの色を変更**

PowerPoint のテーマは、スライド上のさまざまな要素に対して特定のカラーセットを使用します。色が気に入らない場合は、テーマに新しいカラーを適用して色を変更します。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 列挙体の値を提供します。

この C# コードは、テーマのアクセントカラーを変更する方法を示しています:
```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```


この方法で、結果として得られるカラーの実際の値を確認できます:
```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (カラー [A=255, R=128, G=100, B=162])
```


色変更操作をさらに示すために、別の要素を作成し、最初の操作で取得したアクセントカラーを割り当てます。その後、テーマ内のカラーを変更します:
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


新しいカラーは、両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー(1)に輝度変換を適用すると、追加パレット(2)からカラーが生成されます。その後、これらのテーマカラーの取得と設定が可能です。

![additional-palette-colors](additional-palette-colors.png)

**1** - メインテーマカラー

**2** - 追加パレットからのカラー。

この C# コードは、メインテーマカラーから追加パレットのカラーを取得し、それらをシェイプで使用する操作を示しています:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // アクセント 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // アクセント 4、明るさ 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // アクセント 4、明るさ 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // アクセント 4、明るさ 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // アクセント 4、暗く 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント 4、暗く 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```


## **テーマフォントを変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は以下の特別な識別子（PowerPoint で使用されるものと同様）を使用します:

* **+mn-lt** - 本文フォント Latin（マイナー Latin フォント）
* **+mj-lt** - 見出しフォント Latin（メジャー Latin フォント）
* **+mn-ea** - 本文フォント 東アジア（マイナー 東アジア フォント）
* **+mj-ea** - 本文フォント 東アジア（マイナー 東アジア フォント）

この C# コードは、Latin フォントをテーマ要素に割り当てる方法を示しています:
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


この C# コードは、プレゼンテーションのテーマフォントを変更する方法を示しています:
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


すべてのテキスト ボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint fonts](/slides/ja/net/powerpoint-fonts/) をご覧になると便利です。 
{{% /alert %}}

## **テーマの背景スタイルを変更**

デフォルトでは、PowerPoint アプリは 12 個の事前定義された背景を提供しますが、典型的なプレゼンテーションではそのうち 3 個のみが保存されます。

![todo:image_alt_text](presentation-design_8.png)

例として、PowerPoint アプリでプレゼンテーションを保存した後、以下の C# コードを実行すると、プレゼンテーションに含まれる事前定義背景の数を確認できます:
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) プロパティを [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) クラスから使用することで、PowerPoint テーマの背景スタイルを追加または取得できます。 
{{% /alert %}}

この C# コードは、プレゼンテーションの背景を設定する方法を示しています:
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**インデックスガイド**: 0 は塗りなしを表します。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint Background](/slides/ja/net/presentation-background/) をご覧になると便利です。 
{{% /alert %}}

## **テーマ効果を変更**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を持ちます。これらの配列は 3 つの効果（サブトル、モデレート、インテンス）に結合されます。たとえば、特定のシェイプに効果を適用した結果は次のとおりです:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) クラスの 3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles)、[EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)）を使用すると、PowerPoint のオプションよりも柔軟にテーマの要素を変更できます。

この C# コードは、要素の一部を変更してテーマ効果を変更する方法を示しています:
```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```


結果として、塗りカラー、塗りタイプ、影効果などが変更されます:

![todo:image_alt_text](presentation-design_11.png)

## **よくある質問**

**マスタを変更せずに、単一のスライドにテーマを適用できますか？**

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、マスタテーマをそのままにして、特定のスライドにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) を使用）。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に移行する最良の方法は何ですか？**

[Clone slides](/slides/ja/net/clone-slides/) とマスタをターゲットのプレゼンテーションにコピーすることで、元のマスタ、レイアウト、および関連するテーマを保持し、外観の一貫性を保ちます。

**すべての継承とオーバーライド後の「実効」値を確認するにはどうすればよいですか？**

API の ["effective" views](/slides/ja/net/shape-effective-properties/)（テーマ/カラー/フォント/エフェクト）を使用します。これらは、マスタとローカルオーバーライドを適用した後の解決済み最終プロパティを返します。