---
title: .NET でのプレゼンテーションテーマの管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/net/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でプレゼンテーションテーマを管理し、一貫したブランディングで PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
## **概要**

プレゼンテーションテーマはデザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選ぶことになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/net/powerpoint-fonts/)、[背景スタイル](/slides/ja/net/presentation-background/) およびエフェクトで構成されます。

![テーマの構成要素](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定のカラーセットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更します。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体の値を提供しています。

この C# コードはテーマのアクセントカラーを変更する方法を示しています:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

この方法で結果のカラーの実効値を取得できます:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (カラー [A=255, R=128, G=100, B=162])
}
```

カラー変更操作をさらに示すために、別の要素を作成し、最初の操作で取得したアクセントカラーを割り当てます。その後、テーマ内のカラーを変更します:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

新しいカラーは両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー (1) に輝度変換を適用すると、追加パレット (2) の色が生成されます。その後、これらのテーマカラーを設定および取得できます。

![追加パレットの色](additional-palette-colors.png)

**1** - メインテーマカラー

**2** - 追加パレットの色

この C# コードは、メインテーマカラーから取得した追加パレットの色をシェイプで使用する操作を示しています:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **`SchemeColor` を `IColorScheme` のカラーにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) を使用すると、次のテーマカラー値が含まれていることに気付くかもしれません：

`Background1`、`Background2`、`Text1`、`Text2`。

しかし、`Presentation.MasterTheme.ColorScheme` は [IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) を返し、対応するカラーを次のように公開します：

`Dark1`、`Dark2`、`Light1`、`Light2`。

この違いは名前だけです。これらの値は同じテーマカラーのスロットを指しており、マッピングは固定されています：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` と `Dark`/`Light` の間に動的な変換はありません。同じテーマカラーの別名です。

この名前の違いは Microsoft Office の用語に由来します。古い Office バージョンでは `Dark 1`、`Light 1`、`Dark 2`、`Light 2` が使用され、新しい UI バージョンでは同じスロットが `Text 1`、`Background 1`、`Text 2`、`Background 2` と表示されます。

## **テーマフォントの変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は PowerPoint で使用されるのと同様の特別な識別子を使用します：

* **+mn-lt** - 本文フォント ラテン語 (Minor Latin Font)
* **+mj-lt** - 見出しフォント ラテン語 (Major Latin Font)
* **+mn-ea** - 本文フォント 東アジア語 (Minor East Asian Font)
* **+mj-ea** - 見出しフォント 東アジア語 (Major East Asian Font)

この C# コードはラテンフォントをテーマ要素に割り当てる方法を示しています:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

この C# コードはプレゼンテーションのテーマフォントを変更する方法を示しています:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

すべてのテキストボックスのフォントが更新されます。

{{% alert color="info" title="TIP" %}} 
[PowerPoint フォント](/slides/ja/net/powerpoint-fonts/) をご覧になると良いでしょう。 
{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 の事前定義された背景を提供しますが、典型的なプレゼンテーションに保存されるのはそのうちの 3 つだけです。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の C# コードを実行してプレゼンテーションに含まれる事前定義背景の数を取得できます:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) プロパティを [FormatScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/) クラスから使用すると、PowerPoint テーマの背景スタイルを追加またはアクセスできます。 
{{% /alert %}}

この C# コードはプレゼンテーションの背景を設定する方法を示しています:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**インデックスガイド**: 0 は塗りなしを表します。インデックスは 1 から始まります。

{{% alert color="info" title="TIP" %}} 
[PowerPoint 背景](/slides/ja/net/presentation-background/) をご覧になると良いでしょう。 
{{% /alert %}}

## **テーマエフェクトの変更**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を持ちます。これらの配列は 3 つのエフェクト（subtle、moderate、intense）に結合されます。たとえば、特定のシェイプにエフェクトを適用した結果は次のとおりです:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme) クラスの 3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/linestyles)、[EffectStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/effectstyles)）を使用すると、PowerPoint のオプション以上に柔軟にテーマ内の要素を変更できます。

この C# コードは、要素の一部を変更してテーマエフェクトを変更する方法を示しています:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

塗りの色、塗りタイプ、影エフェクトなどの結果としての変更:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### マスターを変更せずに、単一のスライドにテーマを適用できますか？

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしており、[SlideThemeManager](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/slidethememanager/) を使用してマスターテーマをそのままにしながら、対象スライドにローカルテーマを適用できます。

### テーマをあるプレゼンテーションから別のプレゼンテーションへ安全に持ち込む最適な方法は何ですか？

[スライドのクローン](/slides/ja/net/clone-slides/) をマスタと共に対象プレゼンテーションにコピーします。これにより元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫します。

### 継承やオーバーライド後の「実効」値を確認するにはどうすればよいですか？

テーマ/カラー/フォント/エフェクトの ["effective" ビュー](/slides/ja/net/shape-effective-properties/) を使用します。これらはマスターとローカルオーバーライドを適用した後の最終的に解決されたプロパティを返します。