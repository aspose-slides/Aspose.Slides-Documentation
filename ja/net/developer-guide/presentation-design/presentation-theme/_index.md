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
- "テーマの設定"
- "テーマの変更"
- "テーマの管理"
- "テーマカラー"
- "追加パレット"
- "テーマフォント"
- "テーマスタイル"
- "テーマ効果"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でプレゼンテーションのテーマをマスターし、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果といった調和の取れた一連の設定を定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation.MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/mastertheme/) プロパティで取得できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスターは [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/masterthememanager/overridetheme/) によってプレゼンテーションテーマを上書きでき、レイアウトは [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) によって継承されたテーマを上書きでき、個々のスライドでも同様に行えます。実際には、スライドの有効テーマは次の継承チェーンで決定されます。プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/) オブジェクトはテーマの [ColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/fontscheme/)、および [FormatScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/formatscheme/) を公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイルエントリの数や内容はファイルごとに異なる可能性があります。

次の例は、メインテーマのプロパティを読み取り、背景、塗りつぶし、線、効果スタイルがテーマに何個格納されているかを報告します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

ファイルに複数のマスターが含まれる場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、この記事後半で示す有効テーマフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) の該当エントリを変更すると、そのテーマ色を参照しているすべてのオブジェクトが新しい値で解決されます。直接 RGB 色を使用しているオブジェクトはテーマ色の更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用した図形を作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

矩形は `Accent4` にリンクされたままであるため、テーマが変更されると表示色が赤になります。図形上で直接色を設定してスキームカラーを置き換えた場合、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマ色に対して色変換を適用し、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/net/aspose.slides/colortransformoperation/) で公開しています。

![メインテーマカラーと追加パレットから生成された明るい・暗いカラー](additional-palette-colors.png)

**1** – メインテーマカラー。  
**2** – メインテーマカラーから生成された明るい・暗いバリエーション。

次の例は `Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

これらのバリエーションはテーマカラーに基づいたままです。後で `Accent4` が変更されると、変換後の色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` の値を `IColorScheme` のスロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントの変更**

テーマのフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.Major](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/fontscheme/major/) と [FontScheme.Minor](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/fontscheme/minor/) プロパティでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン文字 (Minor Latin Font)  
* `+mj-lt` – 見出しフォント ラテン文字 (Major Latin Font)  
* `+mn-ea` – 本文フォント 東アジア文字 (Minor East Asian Font)  
* `+mj-ea` – 見出しフォント 東アジア文字 (Major East Asian Font)

次の例は、メジャーラテンテーマフォントを使用した見出しと、マイナーラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

見出しはメジャーフォントに従い、本文テキストはマイナーフォントに従います。テーマ識別子ではなく明示的にフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/net/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマのコピーまたは適用**

一般的なワークフローは 2 種類あり、解決すべき課題が異なります。

### **スライドを移動する際に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/addclone/) でソースマスターをターゲットにクローンし、続いて [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) でスライドとクローンしたマスターをクローンします。これによりマスター、レイアウト、テーマが一緒にコピーされます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

このフローは、ソーススライドが宛先でも同一の外観である必要がある場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色・フォント・背景・効果が変わってしまう可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターとレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initfontschemefrom/)、[OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initformatschemefrom/) メソッドで 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

この操作により他のスライドが継承しているテーマは変更せず、対象スライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/clear/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されます（ただし個別スライドに独自オーバーライドがある場合は除く）。同じ初期化メソッドはレイアウトの [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/layoutslidethememanager/) を通じて使用できます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけ異なるスタイリングが必要な場合はレイアウトオーバーライドを、真の例外だけに適用したい場合はスライドオーバーライドを使用してください。スライドレベルのオーバーライドを過度に使用すると、後からのグローバルテーマ変更の予測が困難になります。

## **テーマの背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) に格納されています。PowerPoint の UI では、テーマ塗りつぶしにテーマカラーやその他のスタイル参照を組み合わせて、実際にコレクションに保持されている数より多くの背景オプションを提示することがあります。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.StyleIndex](https://reference.aspose.com/slides/ja/net/aspose.slides/background/styleindex/) を確認してください。`StyleIndex` は `0` がテーマ塗りつぶしなし、正の値がテーマ背景スタイル参照を表します。これは .NET コレクションのインデックスとは異なり、`[0]` が最初の格納項目を意味します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らない点に注意してください。

次の例は利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

表示結果はマスターが参照しているテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドには影響しません。継承適用後の最終背景が必要なときは、[Background.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/background/geteffective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`StyleIndex` をゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号をハードコーディングして別ファイルでも同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定や背景継承については、[Presentation Background](/slides/ja/net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマットスキームは、個別の [FillStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/linestyles/)、[EffectStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/effectstyles/) コレクションを含みます。一般的な Office テーマは、微妙、標準、強調という視覚的に異なる 3 つの主要スタイルエントリを持つことが多いですが、コード側では固定数を前提にせず各コレクションを検査してください。

![同一図形に適用された微妙・標準・強調のテーマ効果](presentation-design_10.png)

C# でこれらのコレクションにアクセスする場合、インデックスはゼロベースです。`[0]` が最初のスタイル、`[2]` が 3 番目のスタイルを指します。図形のスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapestyle/) を通じて取得します。テーマスタイルを変更すると、そのスタイルを参照している図形に影響し、直接書式設定された図形は変わらないことがあります。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外部シャドウ（距離 10pt）を有効化して結果を保存します。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

これらのスロットを参照している図形では、1 番目のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑（実線）に、3 番目の効果スタイルに外部シャドウが追加されます。最終的なビジュアルは、各図形がどのスタイルスロットを参照しているか、直接書式設定がテーマを上書きしているかに依存します。

![線、塗りつぶし、シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効テーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は、継承とローカルオーバーライドが解決された後、スライドや図形が実際に使用している値を示します。スライドの場合は [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) を呼び出します。背景は [Background.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/background/geteffective/)、塗りつぶしは [FillFormat.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/fillformat/geteffective/) を使用します。

次の例は、スライドから有効テーマ、背景、最初の図形の塗りつぶしを取得します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

有効データはレンダリング診断、検証、比較に使用してください。[Presentation.MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/mastertheme/) だけを検査すると、マスター、レイアウト、スライド、図形のいずれかで行われたオーバーライドによる最終外観の変化を見落とす可能性があります。

## **FAQ**

**テーマをマスターを変更せずに単一スライドに適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドにのみ適用され、他のスライドは既存のテーマを継承し続けます。

**テーマをあるプレゼンテーションから別のプレゼンテーションへ安全に持ち運ぶ最良の方法は？**

スライドを移動して元の外観を保持する場合は、[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/addclone/) でソースマスターをターゲットにクローンし、続いて [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) で同じマスターを使用してスライドをクローンしてください。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値はどうやって確認できますか？**

スライドまたはレイアウトテーマについては [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) を使用し、[Background.GetEffective]、[FillFormat.GetEffective] などのフォーマットオブジェクト用有効データ取得メソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。