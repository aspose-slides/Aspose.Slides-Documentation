---
title: プレゼンテーションテーマ
type: docs
weight: 10
url: /net/presentation-theme/
keywords: "テーマ, PowerPointテーマ, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointプレゼンテーションテーマ"
---

プレゼンテーションテーマは、デザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、特定の視覚要素とそのプロパティのセットを選んでいることになります。

PowerPointでは、テーマは色、[フォント](/slides/net/powerpoint-fonts/)、[背景スタイル](/slides/net/presentation-background/)、およびエフェクトで構成されます。

![theme-constituents](theme-constituents.png)

## **テーマカラーを変更する**

PowerPointテーマは、スライドの異なる要素に対して特定の色のセットを使用します。色が気に入らない場合は、テーマの新しい色を適用することで変更できます。新しいテーマカラーを選択できるようにするために、Aspose.Slidesは[SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/)列挙体の値を提供します。

このC#コードは、テーマのアクセントカラーを変更する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

このようにして、結果の色の効果的な値を決定できます。

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

色の変更操作をさらに示すために、別の要素を作成し、その要素に初期操作からアクセントカラーを割り当てます。次に、テーマで色を変更します。

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

主テーマカラー(1)に対して輝度変換を適用すると、追加パレット(2)から色が生成されます。これらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主テーマカラー

**2** - 追加パレットの色。

このC#コードは、追加パレットの色が主テーマカラーから取得され、その後シェイプで使用される操作を示しています。

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // アクセント4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // アクセント4, 明るさ80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // アクセント4, 明るさ60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // アクセント4, 明るさ40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // アクセント4, 暗さ25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // アクセント4, 暗さ50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

## **テーマフォントを変更する**

テーマおよびその他の目的のためにフォントを選択できるようにするために、Aspose.Slidesは特別な識別子を使用しています（PowerPointで使用されるものに似ています）：

* **+mn-lt** - 本体フォントラテン（マイナラテンフォント）
* **+mj-lt** - 見出しフォントラテン（メジャーラテンフォント）
* **+mn-ea** - 本体フォント東アジア（マイナー東アジアフォント）
* **+mj-ea** - 本体フォント東アジア（マイナー東アジアフォント）

このC#コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています。

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("テーマテキストフォーマット");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

このC#コードは、プレゼンテーションテーマフォントを変更する方法を示しています。

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="ヒント" %}} 

[PowerPointフォント](/slides/net/powerpoint-fonts/)を参照したい場合があります。

{{% /alert %}}

## **テーマ背景スタイルを変更する**

デフォルトでは、PowerPointアプリは12の事前定義された背景を提供しますが、これら12の背景のうち、通常のプレゼンテーションでは3つしか保存されません。 

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPointアプリでプレゼンテーションを保存した後、このC#コードを実行してプレゼンテーション内の事前定義された背景の数を確認できます。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"テーマの背景フィルスタイルの数は {numberOfBackgroundFills} です");
}
```

{{% alert color="warning" %}} 

[FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/)クラスの[BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/)プロパティを使用して、PowerPointテーマの背景スタイルを追加またはアクセスできます。 

{{% /alert %}}

このC#コードは、プレゼンテーションの背景を設定する方法を示しています。

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**インデックスガイド**: 0は塗りつぶしなしに使用されます。インデックスは1から始まります。

{{% alert color="primary" title="ヒント" %}} 

[PowerPoint背景](/slides/net/presentation-background/)を参照したい場合があります。

{{% /alert %}}

## **テーマエフェクトを変更する**

PowerPointテーマには、通常、各スタイル配列に対して3つの値が含まれます。これらの配列は、微妙、中程度、強烈の3つのエフェクトに結合されます。たとえば、これは特定のシェイプにエフェクトを適用した場合の結果です：

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme)クラスの3つのプロパティ（[FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles)、[EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)）を使用して、テーマ内の要素を変更できます（PowerPointのオプションよりも柔軟に）。

このC#コードは、要素の部分を変更してテーマエフェクトを変更する方法を示しています。

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

塗りつぶしの色、塗りつぶしの種類、影のエフェクトなどの結果の変更：

![todo:image_alt_text](presentation-design_11.png)