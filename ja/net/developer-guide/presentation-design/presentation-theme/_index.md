---
title: ".NET でのプレゼンテーションテーマの管理"
linktitle: "プレゼンテーションテーマ"
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
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、および効果の調和したセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多くのオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/mastertheme/) プロパティで取得できます。プレゼンテーションは下位レベルでテーマのオーバーライドを保持することもできます。マスターは [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/masterthememanager/overridetheme/) を介してプレゼンテーションテーマをオーバーライドでき、レイアウトは [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) で継承されたテーマをオーバーライドでき、個々のスライドも同様にオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作ワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [ColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/fontscheme/)、および [FormatScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/mastertheme/formatscheme/) を公開します。これらのコレクションを変更前に検査することは、外部ソースからのプレゼンテーションの場合に特に有用です。スタイルエントリの数と内容は変わり得るからです。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマワークフローを使用してください。

## **テーマカラーの変更**

テーマ対応の塗りつぶし、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体の論理カラーを参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) の該当エントリを変更すると、まだそのテーマカラーを参照しているすべてのオブジェクトが新しい値で解決されます。直接 RGB カラーを使用しているオブジェクトは、テーマカラーの更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` カラーを赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶしカラーを出力します。

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

矩形は `Accent4` にリンクされたままなので、テーマが変更されると表示色が赤になります。シェイプ上でスキームカラーを直接カラーに置き換えると、以後の `Accent4` 変更はその塗りつぶしに影響しなくなります。

### **追加パレットからカラーを使用する**

PowerPoint はテーマカラーに対して色変換を適用し、明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/net/aspose.slides/colortransformoperation/) を通じて公開しています。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - メインテーマカラー。  
**2** - メインテーマカラーから生成された明るいバリエーションと暗いバリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用して結果を保存します。

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

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換されたカラーは新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/net/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。対応は固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同一スロットの別名であり、動的に相互変換される値ではありません。

## **テーマフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。`[FontScheme.Major]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/fontscheme/major/) と `[FontScheme.Minor]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/fontscheme/minor/) プロパティがそれらのセットを公開します。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン文字 (Minor Latin Font)  
* `+mj-lt` - 見出しフォント ラテン文字 (Major Latin Font)  
* `+mn-ea` - 本文フォント 東アジア文字 (Minor East Asian Font)  
* `+mj-ea` - 見出しフォント 東アジア文字 (Major East Asian Font)

次の例は、メジャー ラテンテーマフォントを使用した見出しと、マイナー ラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーとマイナーのフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個々の文字体系向けのフォントマッピングも含めることができます。これらのマッピングを検査、追加、置換、削除する方法は、[スクリプト固有のテーマフォント](/slides/ja/net/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細情報は、[PowerPoint フォント](/slides/ja/net/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用する**

`.thmx` 形式の PowerPoint テーマファイルがあり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) を使用します。対象のマスターは [Presentation.Masters](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/masters/) コレクション (実装は [IMasterSlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/)) から選択し、テーマファイルのパスをメソッドに渡します。

メソッドは以下の操作を実行します。

1. 選択したマスターを基に新しいマスタースライドを作成します。  
1. 外部テーマを新しいマスターに適用します。  
1. 以前に選択マスターに依存していたすべてのスライドに新しいマスターを割り当てます。  
1. 新しく作成された [IMasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/) を返します。

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

無効・破損・非対応のテーマは [PptxException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxexception/) またはその派生例外をスローする可能性があります。ユーザーが指定したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマが正常に適用された後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに紐付くスライドは既存のマスターとテーマを保持します。テーマ対応の色・フォント・塗りつぶし・線・背景・効果は外部テーマに対して解決されますが、直接割り当てられた色・フォント・塗りつぶしなどの明示的書式は変更されないことがあります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先される場合があります。

テーマが実行環境に存在しないフォントを参照していることがあります。レンダリングやエクスポートの一貫性を保つには、必要なフォントをインストールするか、[カスタムフォント ソース](/slides/ja/net/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/net/font-substitution/) を構成してください。

この操作はマスターレベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルまたはレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタープレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[ISlide.LayoutSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/layoutslide/) と [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/masterslide/) を介して代表スライドから取得します。テーマを適用する前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスターを作成します。

次の例は、2 つのセクションのスライドからそれぞれのマスターを取得し、各グループに異なる外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドのみ、2 回目の呼び出しは `secondGroupMaster` に依存するスライドのみを対象とします。他のマスターに属するスライドはスタイルが変更されません。

### **スライドを移動する際に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/addclone/) でソースマスターをターゲットにクローンし、続いて [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) でスライドとクローンしたマスターをクローンします。これによりマスター、レイアウト、および関連テーマが一緒にコピーされます。

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

この方法は、ソーススライドが宛先でも同一の外観を保つ必要がある場合に推奨されます。コンテンツだけを無関係な宛先マスターにクローンすると、テーマ駆動の色・フォント・背景・効果が変わってしまいます。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターやレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。`[OverrideTheme.InitColorSchemeFrom]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、`[OverrideTheme.InitFontSchemeFrom]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initfontschemefrom/)、`[OverrideTheme.InitFormatSchemeFrom]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/initformatschemefrom/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマは変更せずに、そのスライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、`[OverrideTheme.Clear]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/overridetheme/clear/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用しているスライド全体に適用されます（ただし、個別スライドが独自のオーバーライドを持っている場合は例外）。同じ初期化メソッドはレイアウトの `[LayoutSlideThemeManager]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/layoutslidethememanager/) から使用できます。

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

多数のレイアウトやスライドが同一のベースデザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定レイアウトファミリーだけ異なるスタイリングが必要な場合はレイアウトオーバーライドを、真の例外だけにスライドオーバーライドを使用してください。過剰なスライドレベルのオーバーライドは、後続のグローバルテーマ変更を予測しにくくします。

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは `[FormatScheme.BackgroundFillStyles]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) に格納されています。PowerPoint の UI は、このコレクションに実際に格納されている塗りつぶし定義の数以上の背景選択肢を提示できるのは、テーマ塗りつぶしとテーマカラー、他のスタイル参照を組み合わせられるためです。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、格納されているコレクションと現在の `[Background.StyleIndex]`(https://reference.aspose.com/slides/ja/net/aspose.slides/background/styleindex/) を確認してください。`StyleIndex` が `0` の場合はテーマ塗りつぶしなし、正の値はテーマ背景スタイルへの参照を示します。これは .NET コレクションのインデックスとは異なり、`[0]` は最初の格納項目を意味します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

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

表示結果はマスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わりません。継承後の最終背景を取得したい場合は `[Background.GetEffective]`(https://reference.aspose.com/slides/ja/net/aspose.slides/background/geteffective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`StyleIndex` をゼロベースのコレクションインデックスとみなさないでください。また、あるファイルでのスタイル番号をハードコードして他のファイルでも同じ見た目になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定や背景継承については、[Presentation Background](/slides/ja/net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマットスキームは、別々の `[FillStyles]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/fillstyles/)、`[LineStyles]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/linestyles/)、`[EffectStyles]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/formatscheme/effectstyles/) コレクションを含みます。一般的な Office テーマは微妙、標準、強調の 3 つの主要スタイルエントリを持つことが多いですが、コード側では固定数を前提にせず各コレクションを検査してください。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C# でこれらのコレクションにアクセスする場合、インデックスはゼロベースです：`[0]` が最初のスタイル、`[2]` が3番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、`[IShapeStyle]`(https://reference.aspose.com/slides/ja/net/aspose.slides/ishapestyle/) で公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変わりません。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイル、3 番目の効果スタイルの外側シャドウを変更して結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑に、3 番目の効果スタイルに距離 10 ポイントの外側シャドウが付与されます。最終的な視覚結果は、各シェイプがどのスロットを参照しているか、また直接書式がテーマを上書きしているかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **実効的な単色塗りつぶしがテーマカラーを使用しているか判定する**

塗りつぶしはオブジェクトに直接設定されるか、段落、レイアウト、マスター、テーマスタイル、または他の書式階層から継承されます。`[IFillFormat.GetEffective]`(https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformat/geteffective/) を呼び出すと、この階層が不変の `[IFillFormatEffectiveData]` に解決されます。まず `[IFillFormatEffectiveData.FillType]`(https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformateffectivedata/filltype/) を確認し、`FillType.Solid` の場合にのみ単色塗りつぶしプロパティを読み取ります。

単色塗りつぶしの場合、`[IFillFormatEffectiveData.SolidFillColor]`(https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) は継承、テーマ参照、色変換が適用された最終的な RGB 値を返します。`[IFillFormatEffectiveData.SolidFillSchemeColor]`(https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) は対応する論理 `[SchemeColor]` スロット（例：`Text1`、`Accent6`）を返します。`SchemeColor.NotDefined` は実効的単色塗りつぶしがスキームカラーに基づいていないことを意味し、直接 RGB 塗りつぶしであることを示します。

ローカルの `[IColorFormat.SchemeColor]`(https://reference.aspose.com/slides/ja/net/aspose.slides/icolorformat/schemecolor/) のみで塗りつぶしを分類しないでください。たとえば、テキストの一部はローカルでスキームカラーが未定義 (`NotDefined`) でも、実効的塗りつぶしがテーマカラーを継承して `Text1` や `Accent6` になることがあります。逆に、`SolidFillSchemeColor` は実効的カラーを生成した論理スロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別の階層から来たかは示しません。

次の例はプレゼンテーションを読み込み、シェイプの塗りつぶしとテキスト部分の塗りつぶしを監査し、最終的な RGB 値と対応スキームカラーを出力し、テーマカラーの変更に追従しない単色塗りつぶしをフラグします。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

`NotDefined` ブランチは、テーマカラー スロットの変更に応答しない単色塗りつぶしの監査リストを提供します。ブランド パレットが変更されたときにこれらのオブジェクトを確認してください。報告される RGB 値は現在の外観を示し、スキーム値はその外観がテーマに接続されているかどうかを説明します。

実効書式オブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または継承書式を変更した後は、再度 `GetEffective` を呼び出して新しい `IFillFormatEffectiveData` を取得し、色を比較または報告してください。

## **有効なテーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は `[BaseOverrideThemeManager.CreateThemeEffective]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) を呼び出します。背景は `[Background.GetEffective]`(https://reference.aspose.com/slides/ja/net/aspose.slides/background/geteffective/) を、塗りつぶしは `[FillFormat.GetEffective]`(https://reference.aspose.com/slides/ja/net/aspose.slides/fillformat/geteffective/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプ塗りつぶしを取得します。

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

有効データはレンダリング診断、検証、比較に使用します。`[Presentation.MasterTheme]` だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終的な外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。`[IMasterSlide.ApplyExternalThemeToDependingSlides]`(https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) は選択したマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの `[SlideThemeManager]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドにローカルに留まり、他のスライドは既存テーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち運ぶ方法は？**

スライドを移動して元の外観を保持する場合は、[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslidecollection/addclone/) でソースマスターを宛先にクローンし、続いて [ISlideCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/addclone/) でそのマスターを使ってスライドをクローンします。これによりマスター、レイアウト、テーマが一体で保持されます。

**継承とオーバーライドの後の有効値はどうやって確認できますか？**

スライドやレイアウトのテーマについては `[BaseOverrideThemeManager.CreateThemeEffective]`(https://reference.aspose.com/slides/ja/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) を、`[Background.GetEffective]` や `[FillFormat.GetEffective]` などのフォーマットオブジェクト用の有効データ取得メソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。