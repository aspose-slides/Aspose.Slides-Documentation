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
- 外部テーマ
- THMX
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
description: "Aspose.Slides for .NET でプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
## **概要**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果といった要素を統一的に定義したセットです。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として保持するのではなく、これらの共有定義を参照します。そのため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/mastertheme/) プロパティで取得できます。プレゼンテーションには、下位レベルでテーマのオーバーライドを設定することも可能です。マスターは [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/masterthememanager/overridetheme/) によってプレゼンテーションテーマを上書きでき、レイアウトは [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) で継承されたテーマを上書きでき、個々のスライドも同様に上書きできます。実際には、スライドの有効テーマは次の継承チェーンをたどって解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作のワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [ColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/fontscheme/) および [FormatScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/formatscheme/) を公開します。変更前にこれらのコレクションを検査しておくと、外部ソースから取得したプレゼンテーションでスタイルエントリの数や内容が変わる可能性があるため特に有用です。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数をレポートします。

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

ファイルに複数のマスターが含まれる場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の「有効テーマ」ワークフローを使用してください。

## **テーマの色を変更する**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) の該当エントリを変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマカラーの更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

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

矩形が `Accent4` にリンクされたままであるため、テーマが変更されると表示色が赤になります。シェイプ上でスキーム色を直接の色に置き換えた場合、以降の `Accent4` 変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマカラーに対してカラー変換を適用し、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/net/aspose.slides/colortransformoperation/) で公開しています。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – メインテーマカラー  
**2** – メインテーマカラーから生成された明るい・暗いバリエーション

次の例は、`Accent4` を基にした 6 つの矩形を作成し、うち 5 枚に輝度変換を適用して結果を保存します。

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

### **`SchemeColor` の値を `IColorScheme` のスロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) は同じスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同一スロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントを変更する**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。`FontScheme.Major` と `FontScheme.Minor` プロパティでそれぞれのセットにアクセスできます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント Latin (Minor Latin Font)  
* `+mj-lt` – 見出しフォント Latin (Major Latin Font)  
* `+mn-ea` – 本文フォント East Asian (Minor East Asian Font)  
* `+mj-ea` – 見出しフォント East Asian (Major East Asian Font)

次の例は、メジャー Latin テーマフォントを使用した見出しと、マイナー Latin テーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォント、本文はマイナーフォントに従います。テーマ識別子ではなく明示的にフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャー・マイナーのフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個別の書字体系向けマッピングを含めることも可能です。これらのマッピングを検査・追加・置換・削除する方法は、[Script-Specific Theme Fonts](/slides/ja/net/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/net/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマを特定マスターの依存スライドに適用する**

PowerPoint のテーマファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドのデザインを変更したい場合は、[IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) を使用します。まず [Presentation.Masters] コレクションから対象マスターを取得し（このコレクションは [IMasterSlideCollection] を実装しています）、テーマファイルのパスをメソッドに渡します。

メソッドが実行する操作は次のとおりです。

1. 選択したマスターを基に新しいマスタースライドを作成する。  
2. 外部テーマを新しいマスターに適用する。  
3. 以前は選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てる。  
4. 作成された [IMasterSlide] を返す。

次の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存して結果を再度開きます。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

無効・破損・非対応のテーマを使用すると、[PptxException] やそのフォーマット関連サブクラスがスローされる可能性があります。ユーザーから受け取ったパスは検証し、ファイルシステムアクセスの失敗をハンドリングし、テーマの適用が成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに属するスライドは既存のマスターとテーマを保持したままです。テーマ対応の色、フォント、塗りつぶし、線、背景、効果は外部テーマに対して解決されますが、直接割り当てられた色やフォントなどの明示的書式は変更されないことがあります。レイアウトレベルやスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマがランタイム環境に存在しないフォントを参照している場合があります。安定した描画とエクスポートのために、必要なフォントをインストールするか、[カスタムフォント ソース](/slides/ja/net/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/net/font-substitution/) を構成してください。

これはマスターレベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスのみを受け取り、スライドレベルやレイアウトレベルでテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタープレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[ISlide.LayoutSlide] と [ILayoutSlide.MasterSlide] から代表的なスライドのマスターを取得します。テーマ適用前に元のマスター参照を保存しておくことが重要です。各呼び出しはプレゼンテーションに新しいマスターを追加します。

次の例は、2 つのセクションのスライドからそれぞれのマスターを取得し、グループごとに別々の外部テーマを適用します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

最初の呼び出しは `firstGroupMaster` に依存するスライドのみに影響し、2 回目の呼び出しは `secondGroupMaster` に依存するスライドのみに影響します。その他のマスターに属するスライドは再スタイル化されません。

### **スライド移動時に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.AddClone] でソースマスターをターゲットにクローンし、続いて [ISlideCollection.AddClone] でスライドとクローンされたマスターをコピーします。これにより、マスター・レイアウト・テーマが一緒に持ち運ばれます。

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

この方法は、ソーススライドの外観を宛先でも同一に保ちたいときの推奨ワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色・フォント・背景・効果が変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターやレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。`OverrideTheme.InitColorSchemeFrom`、`OverrideTheme.InitFontSchemeFrom`、`OverrideTheme.InitFormatSchemeFrom` メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマは変更せずに、対象スライドだけのテーマが変更されます。ローカルオーバーライドを解除して継承値に戻すには、`OverrideTheme.Clear` を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するすべてのスライドに適用されます（ただし個別スライドに独自のオーバーライドがある場合は除く）。同じ初期化メソッドはレイアウトの [LayoutSlideThemeManager] を通して使用できます。

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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリーだけが別のスタイリングを必要とする場合はレイアウトオーバーライドを、真に例外的なケースだけはスライドオーバーライドを使用してください。過度なスライドレベルのオーバーライドは、後からのグローバルテーマ変更を予測しにくくします。

## **テーマの背景スタイルを更新する**

テーマの背景塗りつぶしは [FormatScheme.BackgroundFillStyles] に格納されています。PowerPoint の UI では、このコレクションに実際に格納されている数を超えて多くの背景選択肢を提示できることがあります。これは UI がテーマ塗りつぶしとテーマカラー、その他のスタイル参照を組み合わせて表示できるためです。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.StyleIndex] を確認してください。`StyleIndex` が `0` の場合はテーマ塗りつぶしなしを意味し、正の値はテーマ背景スタイルへの参照です。これは .NET コレクションのインデックス（`[0]` が最初の項目）とは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限りません。

次の例は、利用可能な背景塗りつぶし数をレポートし、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスターが参照しているテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドは変わりません。継承後の最終背景が必要なときは [Background.GetEffective] を使用してください。

{{% alert color="warning" title="Warning" %}}
`StyleIndex` をゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号をハードコーディングして別のファイルで同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定や背景の継承については、[Presentation Background](/slides/ja/net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマの効果を更新する**

テーマのフォーマットスキームは、[FillStyles]、[LineStyles]、[EffectStyles] の 3 つのコレクションを持ちます。一般的な Office テーマでは、微妙、標準、強調の 3 つの主要スタイルエントリが視覚的に対応しますが、コード側では固定数を想定せず、各コレクションを検査してください。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C# でこれらのコレクションにアクセスする場合、インデックスはゼロベースです：`[0]` が最初のスタイル、`[2]` が3番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle] を通して取得できます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変わらないことがあります。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側シャドウ（距離 10pt）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、1 番目のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑に、3 番目の効果スタイルに外側シャドウが追加されます。最終的なビジュアルは、シェイプがどのスロットを参照しているか、直接書式がテーマを上書きしているかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **有効テーマ値を取得する**

生のテーマオブジェクトは、特定レベルで定義されている内容を示します。継承とローカルオーバーライドが解決された後に実際に使用されている値が「有効」値です。スライドの場合は [BaseOverrideThemeManager.CreateThemeEffective] を呼び出し、背景は [Background.GetEffective]、塗りつぶしは [FillFormat.GetEffective] を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプの塗りつぶしを取得します。

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

有効データはレンダリング診断、検証、比較に利用してください。単に [Presentation.MasterTheme] を検査するだけでは、マスター、レイアウト、スライド、シェイプのオーバーライドによって最終外観が変わっているケースを見落とすことがあります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション全体のスライドが変更されますか？**

いいえ。`IMasterSlide.ApplyExternalThemeToDependingSlides` は選択したマスターに依存しているスライドのみを再割り当てします。その他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

できます。スライドの `SlideThemeManager` を使用してオーバーライドテーマを初期化してください。変更はそのスライドだけにローカルに適用され、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む最適な方法は？**

スライドを移動して元の外観を保持したい場合は、ソースマスターを宛先にクローンし、`IMasterSlideCollection.AddClone` と `ISlideCollection.AddClone` を使ってスライドもクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライド後の有効値を確認するには？**

スライドやレイアウトのテーマについては `BaseOverrideThemeManager.CreateThemeEffective` を使用し、`Background.GetEffective`、`FillFormat.GetEffective` などの有効データ取得メソッドを利用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。