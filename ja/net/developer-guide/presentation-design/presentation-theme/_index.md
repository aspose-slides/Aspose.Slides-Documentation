---
title: .NET でプレゼンテーションテーマを管理する
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
- テーマ効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でプレゼンテーションテーマをマスターし、一貫したブランドを保ちながら PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
プレゼンテーションテーマはデザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選ぶことになります。

PowerPoint では、テーマは色、[fonts](/slides/ja/net/powerpoint-fonts/)、[background styles](/slides/ja/net/presentation-background/)、および効果で構成されます。

![テーマ構成要素](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して色を変更します。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体の値を提供しています。

この C# コードは、テーマのアクセントカラーを変更する方法を示しています。

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

この方法で、結果として得られる色の実効値を確認できます。

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (カラー [A=255, R=128, G=100, B=162])
```

色変更操作をさらに示すために、別の要素を作成し、アクセントカラー（最初の操作から取得）を割り当てます。その後、テーマ内の色を変更します。

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定**

メインテーマカラー(1)に輝度変換を適用すると、追加パレット(2)から色が生成されます。その後、これらのテーマカラーを設定および取得できます。

![追加パレットカラー](additional-palette-colors.png)

**1** - メインテーマカラー  
**2** - 追加パレットからのカラー

この C# コードは、メインテーマカラーから取得した追加パレットの色をシェイプで使用する操作を示しています。

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

### **`SchemeColor` を `IColorScheme` のカラーにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) を使用すると、次のテーマカラー値が含まれていることに気付くかもしれません。 `Background1`、`Background2`、`Text1`、`Text2`。

しかし、`Presentation.MasterTheme.ColorScheme` は [IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) を返し、対応するカラーは次のように公開されます。 `Dark1`、`Dark2`、`Light1`、`Light2`。

この違いは名前だけです。これらの値は同じテーマカラーのスロットを指し、マッピングは固定されています。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` と `Dark`/`Light` の間に動的な変換はありません。これらは同じテーマカラーの別名に過ぎません。

この命名の違いは Microsoft Office の用語から来ています。古い Office バージョンでは `Dark 1`、`Light 1`、`Dark 2`、`Light 2` が使用されていましたが、新しい UI バージョンでは同じスロットが `Text 1`、`Background 1`、`Text 2`、`Background 2` と表示されます。

## **テーマフォントの変更**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides はこれらの特殊識別子（PowerPoint で使用されるものに類似）を使用します。

* **+mn-lt** - 本文フォント ラテン（マイナー ラテン フォント）
* **+mj-lt** - 見出しフォント ラテン（メジャー ラテン フォント）
* **+mn-ea** - 本文フォント 東アジア（マイナー 東アジア フォント）
* **+mj-ea** - 本文フォント 東アジア（マイナー 東アジア フォント）

この C# コードは、テーマ要素にラテンフォントを割り当てる方法を示しています。

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

この C# コードは、プレゼンテーションのテーマフォントを変更する方法を示しています。

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

すべてのテキスト ボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint fonts](/slides/ja/net/powerpoint-fonts/) をご覧になるとよいでしょう。 
{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 個の事前定義された背景を提供しますが、そのうち 3 個だけが通常のプレゼンテーションに保存されます。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の C# コードを実行して、プレゼンテーションに含まれる事前定義された背景の数を確認できます。

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
[BackgroundFillStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) プロパティを、[FormatScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/) クラスから使用すると、PowerPoint テーマの背景スタイルを追加または取得できます。 
{{% /alert %}}

この C# コードは、プレゼンテーションの背景を設定する方法を示しています。

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**インデックス ガイド**: 0 は塗りなしに使用されます。インデックスは 1 から始まります。

{{% alert color="primary" title="TIP" %}} 
[PowerPoint Background](/slides/ja/net/presentation-background/) をご覧になるとよいでしょう。 
{{% /alert %}}

## **テーマ効果の変更**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は 3 つの効果（subtle、moderate、intense）に結合されます。たとえば、特定のシェイプに効果を適用した結果は次のとおりです。

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme]クラスの 3 つのプロパティ（[FillStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/fillstyles)、[LineStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/linestyles)、[EffectStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/effectstyles)）を使用すると、PowerPoint のオプションよりも柔軟にテーマ内の要素を変更できます。

この C# コードは、要素の一部を変更してテーマの効果を変更する方法を示しています。

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

結果として、塗りの色、塗りタイプ、影効果などが変化します。

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**マスターを変更せずに単一のスライドにテーマを適用できますか？**

はい。Aspose.Slides はスライドレベルのテーマオーバーライドをサポートしているため、[SlideThemeManager](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/slidethememanager/) を使用して、マスターテーマをそのままに個々のスライドにローカルテーマを適用できます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最適な方法は何ですか？**

[Clone slides](/slides/ja/net/clone-slides/) をマスターとともに対象のプレゼンテーションにコピーすると、元のマスター、レイアウト、および関連するテーマが保持され、外観が一貫します。

**すべての継承とオーバーライドの後の「実効」値を確認するにはどうすればよいですか？**

API の ["effective" view](/slides/ja/net/shape-effective-properties/)（テーマ/カラー/フォント/効果）を使用してください。これらは、マスターとローカルオーバーライドを適用した後の解決された最終プロパティを返します。