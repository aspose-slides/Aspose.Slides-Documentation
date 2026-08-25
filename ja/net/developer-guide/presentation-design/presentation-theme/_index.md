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
description: "Aspose.Slides for .NET でプレゼンテーションのテーマをマスターし、一貫したブランドイメージで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果の調和したセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保持する代わりに、これらの共有定義を参照するため、テーマを変更すると多くのオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/mastertheme/) プロパティで取得できます。プレゼンテーションは、下位レベルでテーマの上書きも保持できます。マスターは [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/masterthememanager/overridetheme/) によってプレゼンテーションテーマを上書きでき、レイアウトは [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) によって継承されたテーマを上書きでき、個々のスライドも同様に上書きできます。実際には、スライドの有効テーマは次の継承チェーンを通して解決されます。プレゼンテーションテーマ → マスター上書き → レイアウト上書き → スライド上書き。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマのワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承と上書きが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [ColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/fontscheme/) および [FormatScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/formatscheme/) を公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合、スタイルエントリの数と内容が変わる可能性があるため特に有用です。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つと仮定しないでください。スライドに関連付けられたマスターを検査し、レイアウトやスライドの上書きが存在する可能性がある場合は、この記事の後半で示す有効テーマワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) で対応するエントリを変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に基づいて解決されます。直接 RGB 色を使用しているオブジェクトは、テーマカラーの更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

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

長方形は `Accent4` にリンクされたままであるため、テーマが変更されると表示色は赤になります。シェイプ上で直接色に置き換えた場合、以降の `Accent4` の変更はその塗りつぶしに影響しません。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーに対してカラー変換を適用し、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/net/aspose.slides/colortransformoperation/) を通して提供します。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – メインテーマカラー。  
**2** – メインテーマカラーから生成された明るいバリエーションと暗いバリエーション。

次の例は、`Accent4` に基づく 6 つの長方形を作成し、うち 5 つに輝度変換を適用し、結果を保存します。

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

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、ある形式から別の形式へ動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.Major](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/fontscheme/major/) と [FontScheme.Minor](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/fontscheme/minor/) プロパティでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント Latin (Minor Latin Font)  
* `+mj-lt` – 見出しフォント Latin (Major Latin Font)  
* `+mn-ea` – 本文フォント East Asian (Minor East Asian Font)  
* `+mj-ea` – 見出しフォント East Asian (Major East Asian Font)

次の例は、メジャー Latin テーマフォントを使用する見出しと、マイナー Latin テーマフォントを使用する本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が設定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーとマイナーのフォントコレクションには、キリル文字、アラビア文字、日本語、グルジア文字、ターナ文字など、個々の記述システム向けのフォントマッピングも含めることができます。これらのマッピングを検査、追加、置換、削除する方法は、[Script-Specific Theme Fonts](/slides/ja/net/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/net/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

一般的なワークフローは 2 つあり、解決すべき問題が異なります。

### **スライド移動時に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/addclone/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) とクローンしたマスターでスライドをクローンします。これにより、マスター、そのレイアウト、および関連するテーマが一緒にコピーされます。

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

ソーススライドが宛先でも同じ外観である必要がある場合に推奨されるワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わってしまう可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドが現在のマスターとレイアウトにとどまる必要がある場合は、ソーステーマからスライドレベルの上書きを初期化します。`[OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)`、`[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initfontschemefrom/)`、`[OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initformatschemefrom/)` メソッドが 3 つの主要テーマコンポーネントを上書きにコピーします。

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

これにより、他のスライドが継承しているテーマは変更せずに、対象スライドだけのテーマが変更されます。ローカル上書きを削除して継承値に戻すには、`[OverrideTheme.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/clear/)` を呼び出します。

### **レイアウトにテーマ上書きを適用する**

レイアウトレベルの上書きは、そのレイアウトを使用するスライドすべてに適用されます（ただし個別スライドに独自の上書きがある場合は例外）。同じ初期化メソッドは、レイアウトの [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/layoutslidethememanager/) を通じて使用できます。

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

多くのレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけが異なるスタイリングを必要とする場合はレイアウト上書きを使用し、真の例外に対してのみスライド上書きを使用してください。スライドレベルの上書きが過剰になると、後からの全体テーマ変更の予測が難しくなります。

## **テーマの背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) に格納されています。PowerPoint の UI では、テーマ塗りつぶしとテーマカラーや他のスタイル参照を組み合わせて、実際にコレクションに保存されている塗りつぶし定義数以上の背景選択肢を提示できます。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、格納されているコレクションと現在の [Background.StyleIndex](https://reference.aspose.com/slides/ja/net/aspose.slides/background/styleindex/) を確認してください。`StyleIndex` が `0` の場合はテーマ塗りつぶしなしを意味し、正の値はテーマ背景スタイル参照を表します。これは .NET コレクションのインデックスと異なり、`[0]` が最初の格納項目を指します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

次の例は、利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスターが参照するテーマエントリと、レイアウトやスライドレベルでの背景上書きの有無に依存します。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドは変わりません。継承後の最終背景を知りたいときは、[Background.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/background/geteffective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`StyleIndex` をゼロベースのコレクションインデックスとみなさないでください。また、あるファイルから取得したスタイル番号をハードコーディングして別のファイルでも同じ外観になると期待しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマットスキームは、個別の [FillStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/linestyles/)、[EffectStyles](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/effectstyles/) コレクションを含みます。一般的な Office テーマは、微妙、適度、強烈という視覚的な 3 つの主要スタイルエントリを持つことが多いですが、コード側では固定数を想定せず、各コレクションを検査してください。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C# でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです。`[0]` が最初の格納スタイル、`[2]` が 3 番目のスタイルを指します。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapestyle/) で公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側シャドウ（距離 10pt）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルがソリッドの濃い緑に、3 番目の効果スタイルに外側シャドウが追加されます。最終的な視覚結果は、各シェイプがどのスタイルスロットを参照しているか、また直接書式設定がテーマを上書きしているかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **有効テーマ値の取得**

生のテーマオブジェクトは特定のレベルで定義されている内容を示します。有効値は、継承とローカル上書きが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) を呼び出します。背景の場合は [Background.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/background/geteffective/) を、塗りつぶしの場合は [FillFormat.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/fillformat/geteffective/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプ塗りつぶしを読み取ります。

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

有効データはレンダリング診断、検証、比較に利用してください。単に [Presentation.MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/mastertheme/) を検査すると、最終的な外観を変えるマスター、レイアウト、スライド、シェイプの上書きを見逃す可能性があります。

## **FAQ**

**スライド単体にテーマを適用し、マスターを変更せずに済む方法はありますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/slidethememanager/) を使用し、その上書きテーマを初期化します。変更はそのスライドに限定され、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち運ぶ最良の方法は何ですか？**

スライドを移動し元の外観を保持したい場合は、[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/addclone/) でソースマスターを宛先にクローンし、続いて [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) でそのマスターを使用してスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承と上書きの後の有効値はどのように確認できますか？**

スライドまたはレイアウトテーマには [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) を、背景や塗りつぶしなどのフォーマットオブジェクトにはそれぞれ [Background.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/background/geteffective/) や [FillFormat.GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/fillformat/geteffective/) を使用してください。これらの API は継承と上書きが適用された後の解決済み値を返します。