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
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でプレゼンテーションテーマをマスターし、一貫したブランドで PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗り、線、エフェクトの調整されたセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として格納するのではなく、これらの共有定義を参照するため、テーマを変更すると多くのオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) プロパティで利用できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスターは [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/) によってプレゼンテーションテーマをオーバーライドでき、レイアウトは [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) によって継承されたテーマをオーバーライドでき、個々のスライドも同様にオーバーライドできます。実際には、スライドの実効テーマは次の継承チェーンを通じて解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマのワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景とエフェクトスタイルの更新、継承とオーバーライドが解決された後の実効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/)、[FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/)、[FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) を公開します。変更前にこれらのコレクションを検査することは、プレゼンテーションが外部ソースから取得された場合に特に有用です。スタイルエントリの数や内容は変わる可能性があります。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗り、線、エフェクトスタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ実効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の実効テーマワークフローを使用してください。

## **テーマカラーの変更**

テーマ対応の塗り、線、テキストは [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 列挙体の論理カラーを参照できます。テーマの [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) の該当エントリを変更すると、まだそのテーマカラーを参照しているすべてのオブジェクトが新しい値に解決されます。直接 RGB カラーを使用しているオブジェクトはテーマカラーの更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` カラーを赤に変更し、プレゼンテーションを保存して再度開き、実効塗りカラーを出力します。

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

矩形は `Accent4` にリンクされたままなので、テーマが変更されると表示色は赤になります。シェイプ上でスキームカラーを直接のカラーに置き換えると、以降の `Accent4` の変更はその塗りに影響しなくなります。

### **追加パレットからのカラー使用**

PowerPoint はテーマカラーに対して色変換を適用し、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/) を通じて提供します。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - メインテーマカラー。

**2** - メインテーマカラーから生成された明るいバリエーションと暗いバリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、うち 5 つに輝度変換を適用し、結果を保存します。

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

### **`SchemeColor` 値を `IColorScheme` スロットにマッピング**

[SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) と [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) プロパティでそれらのセットにアクセスできます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン文字 (Minor Latin Font)
* `+mj-lt` - 見出しフォント ラテン文字 (Major Latin Font)
* `+mn-ea` - 本文フォント 東アジア文字 (Minor East Asian Font)
* `+mj-ea` - 見出しフォント 東アジア文字 (Major East Asian Font)
* `+mn-cs` - 本文フォント 複合文字 (Minor Complex Script Font)
* `+mj-cs` - 見出しフォント 複合文字 (Major Complex Script Font)

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が設定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーとマイナーのフォントコレクションには、キリル文字、アラビア文字、和文、グルジア文字、タナ文字など、個々の書字システム用のフォントマッピングを含めることもできます。これらのマッピングを検査、追加、置換、削除するには、[Script-Specific Theme Fonts](/slides/ja/net/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/net/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

### **テーマフォント参照の解決**

テキストを検査する際、[IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) はフォントファミリ名の代わりに `+mn-lt` などのテーマ参照を含むことがあります。適切な [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) を使用して [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) を呼び出し、その参照を解決します。`+mj` と `+mn` プレフィックスはメジャーとマイナーのフォントセットを選択し、`-lt`、`-ea`、`-cs` サフィックスはそれぞれラテン、東アジア、複合文字フォントを選択します。

テーマが適用されるオブジェクトに対して [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) を呼び出して実効テーマを取得します。スライド上の通常テキストの場合は `slide.CreateThemeEffective()` を使用すると、コンテキストにそのスライドの継承テーマとローカルオーバーライドが含まれます。レイアウトやマスター自体を検査する場合はそれぞれの実効テーマを使用します。最初のマスターのテーマがすべてのスライドに適用されると仮定しないでください。

次の例は、マイナーラテンフォントを明示的に参照するテキスト部分を作成します。 [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) を使用してスライドのフォントスキームを初期化し、メジャーとマイナーのラテンファミリをそれぞれ `Arial` と `Calibri` に設定し、入力ファイルなしでも結果が再現できるようにしています。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

出力は `+mn-lt -> Calibri` その後に `Verdana -> Verdana` となります。保存された参照は変更されず、明示的なファミリ名はそのまま返されます。もし `+mj-lt` が使用されていれば、このテーマでは `Arial` に解決されます。

テーマ参照の解決は、テーマによって指定されたフォントファミリを特定します。フォントの利用可能性のチェックや、レンダリング時の代替フォントや字形フォールバックによって最終的に使用されるフォントファイルの決定は行いません。これらの別ステップについては、[Font Selection Sequence](/slides/ja/net/font-selection-sequence/) と [Font Substitution](/slides/ja/net/font-substitution/) を参照してください。

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の問題を解決します。

### **外部テーマをマスター依存スライドに適用**

[IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) は、PowerPoint テーマファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合に使用します。対象のマスターは [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) コレクション（[IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/) を実装）から選択し、テーマファイルのパスをメソッドに渡します。

このメソッドは次の操作を行います。

1. 選択したマスターを元に新しいマスタースライドを作成します。
1. 外部テーマを新しいマスターに適用します。
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。
1. 新しく作成された [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/) を返します。

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

無効、破損、またはサポートされていないテーマは [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) またはそのフォーマット関連サブクラスをスローする可能性があります。ユーザーが提供するパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマが正常に適用された後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗り、線、背景、エフェクトは外部テーマに対して解決されます。直接割り当てられた色、フォント、塗り、その他の明示的書式設定は変更されないままです。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマは実行環境に存在しないフォントを参照することがあります。レンダリングとエクスポートの一貫性を保つため、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/net/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/net/font-substitution/) を構成してください。

これは直接的なマスターレベルのワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタープレゼンテーションで異なる外部テーマを適用**

対象のマスターが事前に分からない場合、[ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) と [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/) を使用して代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに別のマスターを作成します。

次の例は、2 つのセクションのスライドからそれぞれのマスターを特定し、各グループに異なる外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドのみ、2 番目の呼び出しは `secondGroupMaster` に依存するスライドのみを対象とします。その他のマスターに属するスライドは再スタイル化されません。

### **スライドを移動する際に元のテーマを保持**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) でスライドとクローンしたマスターをクローンします。これにより、マスター、そのレイアウト、関連するテーマが一緒にコピーされます。

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

これは、ソーススライドが宛先でも同一に見えることが求められる場合の推奨ワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わってしまうことがあります。

### **既存スライドにテーマ値を適用**

対象スライドが現在のマスターとレイアウトを維持したままテーマを適用したい場合、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/)、[OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

これにより、他のスライドが継承しているテーマは変更せずに、そのスライドだけのテーマが変わります。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドに適用されますが、特定のスライドが独自のオーバーライドを持っている場合は例外です。同じ初期化メソッドはレイアウトの [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) を通じて使用できます。

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

多数のレイアウトやスライドが同じ基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけ別のスタイルが必要な場合はレイアウトオーバーライドを、真の例外の場合のみスライドオーバーライドを使用してください。過剰なスライドレベルのオーバーライドは、後のグローバルテーマ変更を予測しにくくします。

## **テーマ背景スタイルの更新**

テーマの背景塗りは [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) に格納されています。PowerPoint の UI では、テーマ塗りとテーマカラーやその他のスタイル参照を組み合わせて、実際にコレクションに物理的に格納されている塗り定義よりも多くの背景選択肢を提示できます。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、保存されているコレクションと現在の [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) を検査してください。`StyleIndex` はテーマ塗りがない場合は `0`、正の値はテーマ背景スタイル参照を示します。これは .NET コレクションのインデックスとは異なり、`[0]` は最初の格納項目を意味します。すべてのプレゼンテーションが同じ数の背景塗りスタイルを持つとは限らないことに注意してください。

次の例は、利用可能な背景塗り数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わらないことがあります。継承が適用された後の最終背景を知りたい場合は [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`StyleIndex` をゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号をハードコードし、別のファイルでも同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマエフェクトの更新**

テーマフォーマットスキームは、個別の [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/)、[LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/)、[EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/) コレクションを含みます。典型的な Office テーマは、微妙、標準、強調という視覚的に区別できる 3 つの主要スタイルエントリを持つことが多いですが、コード側では固定数を前提にせず、各コレクションを検査すべきです。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

C# でこれらのコレクションにアクセスすると、インデックスはゼロベースです：`[0]` が最初の格納スタイル、`[2]` が 3 番目です。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/) に公開されています。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されないことがあります。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りスタイルを変更し、3 番目のエフェクトスタイルに外側の影を有効にして結果を保存します。

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

これらのスロットを参照するシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りスタイルが濃い森林緑に、3 番目のエフェクトスタイルに距離 10 ポイントの外側の影が追加されます。最終的な視覚結果は、各シェイプがどのスロットを参照しているか、直接書式設定がテーマを上書きしているかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **シェイプのテーマ塗りと線スタイルの選択**

シェイプは [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) と [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/) を使って、塗りと輪郭を個別に選択できます。どちらのプロパティでも、インデックス `1` は対応するテーマコレクションの最初のエントリ（`FillStyles[0]` または `LineStyles[0]`）を選択し、インデックス `2` は 2 番目のエントリを選択します。

次の例は、新規プレゼンテーションのデフォルトテーマで、2 つの塗りスタイル（金色と空色）と 2 つの線スタイル（6 pt の濃い青と 12 pt の濃い赤）を設定し、3 段階でスライドを保存して PowerPoint で結果を比較できるようにします。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| 初期スタイル | 右側の輪郭を変更 | 最初のテーマ塗りを編集 |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

別の線スタイルを選択すると、右側の矩形の輪郭だけが変わります。最初のテーマ塗りを編集すると、それを使用しているすべてのシェイプが更新されます。この例では左側の矩形だけが緑に変わります。

既存のシェイプでは、ローカルの塗り色、線色、線幅がテーマスタイルのその部分を上書きできます。スタイルインデックスを変更しても視覚効果がない場合は、シェイプの [direct formatting](/slides/ja/net/shape-formatting/) を確認してください。

## **実効的な単色塗りがテーマカラーを使用しているかの判定**

塗りはオブジェクトに直接格納されるか、段落、レイアウト、マスター、テーマスタイル、または別の書式レベルから継承されます。[IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) を呼び出して、その階層を不変の [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) に変換します。まず [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/) を確認してください。`FillType.Solid` の場合にのみ、単色塗りのプロパティを読み取ります。

単色塗りの場合、[IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) は継承、テーマ参照、色変換が適用された後の最終的な RGB 値を返します。[IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) は対応する論理 [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) スロット（例: `Text1` や `Accent6`）を返します。`SchemeColor.NotDefined` は、実効単色塗りがスキームカラーに基づいていないことを意味します。このワークフローで塗りがテーマカラーまたは直接 RGB カラーのいずれかである場合、この値は直接 RGB 塗りを識別します。

ローカルの [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) の値だけで塗りを分類しないでください。たとえば、テキスト部分にローカルで定義されたスキームカラーがなく `NotDefined` でも、実効塗りはテーマカラーを継承して `Text1` や `Accent6` に解決されることがあります。逆に、`SolidFillSchemeColor` は実効カラーを生成した論理テーマスロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別レベルから来たかは示しません。

次の例は、プレゼンテーションをロードし、シェイプ塗りとテキスト部分塗りの両方を監査し、最終的な RGB 値と関連するスキームカラーを出力し、テーマカラーの変更に追従しない単色塗りにフラグを付けます。

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

`NotDefined` ブランチは、テーマカラー スロットの変更に反応しない単色塗りの監査リストを提供します。新しいブランドパレットに合わせてプレゼンテーションを調整する際にこれらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに結びついているかどうかを説明します。

実効フォーマットオブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後は、再度 `GetEffective` を呼び出し、新しい `IFillFormatEffectiveData` オブジェクトを取得してから色を比較または報告してください。

## **実効テーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。実効値は継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) を呼び出します。背景の場合は [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) を、塗りの場合は [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/) を使用します。

次の例は、スライドから実効テーマ、背景、最初のシェイプ塗りを取得します。

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

レンダリング診断、検証、比較には実効データを使用してください。[Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終外観が変わっているケースを見落とす可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション全体のスライドに影響しますか？**

いいえ。[IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) は選択したマスターに依存するスライドだけを再割り当てします。別のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一のスライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドだけにローカルで適用され、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む最良の方法は何ですめ？**

スライドを移動し元のデザインを保持する際は、[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) と [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) を使用して、ソースマスターを宛先にクローンし、そのマスターを使用してスライドをクローンしてください。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の実効値はどうやって確認できますか？**

[BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) をスライドまたはレイアウトテーマに使用し、[Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) や [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/) などの対応する実効データメソッドを利用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。