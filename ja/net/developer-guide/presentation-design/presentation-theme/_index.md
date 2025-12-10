---
title: ".NET でプレゼンテーションテーマを管理する"
linktitle: "プレゼンテーションテーマ"
type: docs
weight: 10
url: /ja/net/presentation-theme/
keywords:
- "PowerPoint テーマ"
- "プレゼンテーションテーマ"
- "スライドテーマ"
- "テーマ設定"
- "テーマ変更"
- "テーマ管理"
- "テーマカラー"
- "追加パレット"
- "テーマフォント"
- "テーマスタイル"
- "テーマエフェクト"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でプレゼンテーションテーマをマスターし、ブランド一貫性のある PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---

プレゼンテーションテーマはデザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選ぶことになります。

PowerPoint では、テーマはカラー、[フォント](/slides/ja/net/powerpoint-fonts/)、[背景スタイル](/slides/ja/net/presentation-background/)、およびエフェクトで構成されます。

![theme-constituents](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定のカラーセットを使用します。カラーが好みでない場合は、テーマに新しいカラーを適用して変更します。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 列挙体の値を提供します。

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```


この方法で結果のカラーの実効値を求めることができます。

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (カラー [A=255, R=128, G=100, B=162])
```


カラー変更操作をさらに示すために、別の要素を作成し、アクセントカラー（最初の操作から取得）を割り当てます。その後、テーマ内のカラーを変更します。

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


新しいカラーは両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー（1）に輝度変換を適用すると、追加パレット（2）からカラーが生成されます。その後、これらのテーマカラーを取得および設定できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - メインテーマカラー  
**2** - 追加パレットのカラー。

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

    // アクセント 4、暗さ 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント 4、暗さ 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```


## **テーマフォントの変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides はこれらの特別な識別子（PowerPoint で使用されるものと同様）を使用します。

* **+mn-lt** - 本文フォント ラテン文字 (Minor Latin Font)
* **+mj-lt** - 見出しフォント ラテン文字 (Major Latin Font)
* **+mn-ea** - 本文フォント 東アジア (Minor East Asian Font)
* **+mj-ea** - 本文フォント 東アジア (Minor East Asian Font)

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


この C# コードはプレゼンテーションのテーマフォントを変更する方法を示します。

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


すべてのテキスト ボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}} 
以下をご覧になると便利です: [PowerPoint フォント](/slides/ja/net/powerpoint-fonts/). 
{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 の事前定義された背景を提供しますが、典型的なプレゼンテーションに保存されるのはそのうち 3 つだけです。 

![todo:image_alt_text](presentation-design_8.png)

例えば、PowerPoint アプリでプレゼンテーションを保存した後、以下の C# コードを実行してプレゼンテーション内の事前定義背景の数を確認できます：

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) を使用して、PowerPoint テーマの背景スタイルを追加または取得できます。 
{{% /alert %}}

```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**インデックスガイド**: 0 は塗りなしを表します。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}} 
以下をご覧になると便利です: [PowerPoint 背景](/slides/ja/net/presentation-background/). 
{{% /alert %}}

## **テーマエフェクトの変更**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は、微妙、適度、強烈という 3 つのエフェクトに結合されます。例えば、特定の形状にエフェクトを適用した結果は次のとおりです：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme] クラスの 3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles)、[EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)）を使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

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


結果として、塗りの色、塗りタイプ、影エフェクトなどが変更されます：

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、マスターテーマをそのままにして、対象スライドだけにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) を使用）。

**テーマをあるプレゼンテーションから別のプレゼンテーションに安全に移行する最適な方法は何ですか？**

[Clone slides](/slides/ja/net/clone-slides/) とそのマスターをターゲットプレゼンテーションにコピーします。これにより、元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫します。

**すべての継承とオーバーライド後の“実効”値はどのように確認できますか？**

API の ["effective" views](/slides/ja/net/shape-effective-properties/)（テーマ/カラー/フォント/エフェクト）を使用してください。これらは、マスターとローカルオーバーライドを適用した後の解決済みの最終プロパティを返します。