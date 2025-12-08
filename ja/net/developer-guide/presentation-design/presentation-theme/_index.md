---
title: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/net/presentation-theme/
keywords: "テーマ, PowerPoint テーマ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET での PowerPoint プレゼンテーション テーマ"
---

プレゼンテーションのテーマはデザイン要素のプロパティを定義します。プレゼンテーションのテーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選ぶことになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/net/powerpoint-fonts/)、[背景スタイル](/slides/ja/net/presentation-background/)、および効果で構成されます。

![theme-constituents](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更します。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 列挙体の値を提供します。

この C# コードはテーマのアクセントカラーを変更する方法を示しています：
```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```


この方法で結果の色の有効な値を決定できます：
```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (カラー [A=255, R=128, G=100, B=162])
```


色変更操作をさらに示すために、別の要素を作成し、（最初の操作から取得した）アクセントカラーを割り当てます。その後、テーマ内の色を変更します：
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー(1)に輝度変換を適用すると、追加パレット(2)から色が生成されます。その後、これらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1** - メインテーマカラー

**2** - 追加パレットからのカラー

この C# コードは、メインテーマカラーから追加パレットの色を取得し、それらをシェイプで使用する操作を示しています：
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

テーマやその他の目的でフォントを選択できるように、Aspose.Slides はこれらの特殊識別子（PowerPoint で使用されるものと類似）を使用します：

* **+mn-lt** - 本文フォント ラテン文字 (マイナー ラテンフォント)
* **+mj-lt** - 見出しフォント ラテン文字 (メジャー ラテンフォント)
* **+mn-ea** - 本文フォント 東アジア (マイナー 東アジアフォント)
* **+mj-ea** - 見出しフォント 東アジア (メジャー 東アジアフォント)

この C# コードはラテンフォントをテーマ要素に割り当てる方法を示しています：
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


この C# コードはプレゼンテーションテーマのフォントを変更する方法を示しています：
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}} 
PowerPoint フォントを確認したい場合があります。[PowerPoint フォント](/slides/ja/net/powerpoint-fonts/)。
{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 の定義済み背景を提供しますが、典型的なプレゼンテーションではそのうち 3 つだけが保存されます。

![todo:image_alt_text](presentation-design_8.png)

例えば、PowerPoint アプリでプレゼンテーションを保存した後、次の C# コードを実行してプレゼンテーション内の定義済み背景の数を調べることができます：
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) プロパティを [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) クラスから使用すると、PowerPoint テーマの背景スタイルを追加または取得できます。
{{% /alert %}}

この C# コードはプレゼンテーションの背景を設定する方法を示しています：
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**インデックスガイド**: 0 は塗りなしに使用されます。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}} 
PowerPoint 背景を確認したい場合があります。[PowerPoint Background](/slides/ja/net/presentation-background/)。
{{% /alert %}}

## **テーマ効果の変更**

PowerPoint のテーマは通常、各スタイル配列に 3 つの値を含みます。その配列は 3 つの効果、すなわち subtle、moderate、intense に結合されます。例えば、特定のシェイプに効果を適用した結果は以下の通りです：

![todo:image_alt_text](presentation-design_10.png)

[FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles) を 【FormatScheme】クラスの 3 つのプロパティとして使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この C# コードはテーマ要素の一部を変更してテーマ効果を変更する方法を示しています：
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


結果として、塗りの色、塗りタイプ、影効果などが変化します：

![todo:image_alt_text](presentation-design_11.png)

## **よくある質問**

**マスタを変更せずに単一のスライドにテーマを適用できますか？**

はい。Aspose.Slides はスライドレベルのテーマ上書きをサポートしているため、マスタテーマをそのままにして特定のスライドにローカルテーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) を使用）。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最善の方法は何ですか？**

スライドを [Clone slides](/slides/ja/net/clone-slides/) と共にマスタもターゲットプレゼンテーションにコピーします。これにより元のマスタ、レイアウト、関連するテーマが保持され、外観が一貫します。

**すべての継承と上書きの後に「有効」な値を確認するにはどうすればよいですか？**

API の ["effective" views](/slides/ja/net/shape-effective-properties/) を使用してテーマ/カラー/フォント/効果の最終的に解決されたプロパティを取得できます。