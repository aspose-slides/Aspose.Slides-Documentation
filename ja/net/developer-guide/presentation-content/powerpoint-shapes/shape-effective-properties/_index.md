---
title: ".NET のプレゼンテーションからシェイプの有効プロパティを取得する"
linktitle: "有効プロパティ"
type: docs
weight: 50
url: /ja/net/shape-effective-properties/
keywords:
- "シェイプ プロパティ"
- "カメラ プロパティ"
- "ライト リグ"
- "ベベル シェイプ"
- "テキスト フレーム"
- "テキスト スタイル"
- "フォント 高さ"
- "塗りつぶし フォーマット"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "PowerPoint プレゼンテーションにおけるローカル、継承、そして有効なシェイプ書式設定を区別する方法を、.NET 用 Aspose.Slides を使って学びます。"
---
## **ローカル、継承、および有効なプロパティを理解する**

PowerPoint の書式設定は複数の場所から取得されます。オブジェクトに直接保存されている値は **ローカル値** です。その値が設定されていない場合、PowerPoint は段落のデフォルト、テキスト スタイル、レイアウトまたはマスタースライド、テーマ、またはプレゼンテーション レベルのデフォルトなど、親の書式設定ソースを参照します。これらの値は **継承値** と呼ばれます。階層全体が解決された後に残る値が **有効値** であり、オブジェクトの描画に使用される値です。

例えば、テキストの一部がフォントの高さを定義していない場合があります。そのローカル [FontHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/fontheight/) は `float.NaN` となり、これは「ここでは設定されていない」ことを意味します。その部分は段落やプレゼンテーションのデフォルト テキスト スタイル、または他の適用可能なソースから高さを継承できます。[GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/geteffective/) を部分フォーマットに対して呼び出すと、最終的に解決された高さが返されます。

目的に応じて、2 種類の書式設定データを使用します:
- 値が定義されている場所を制御する必要がある場合は、[IPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/) のようなローカル フォーマット オブジェクトを読み取るか変更します。
- 最終的な描画結果が必要な場合は、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformateffectivedata/) のような有効データ オブジェクトを読み取ります。 有効データは読み取り専用です。

## **ローカル、継承、および有効な値の比較**

以下の完全な例は、シェイプを作成し、プレゼンテーション、段落、および部分レベルでフォントの高さを設定します。各ステップでそれらのレベルで定義された値と、同じテキスト部分に対する結果としての有効値を出力します。また、書式設定の変更後に有効データを再度読み取る必要がある理由も示します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// 2 つの異なるレベルで継承値を定義します。
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// 部分のローカル値が両方の継承値を上書きします。
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// 継承値を変更しても、既存のローカル値は上書きされません。
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// ローカル値をクリアします。部分は再び段落から継承されます。
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// 段落の値をクリアします。プレゼンテーションのデフォルトが結果を提供します。
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // 前の変更の後に有効データを読み取ります。
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

この例での優先順位は、まず部分のローカル書式設定、次に段落の書式設定、そしてプレゼンテーションのデフォルトです。他のオブジェクトは異なる継承チェーンを持つ場合がありますが、原則は同じです。より具体的な明示的な値が優先され、[GetEffective](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/geteffective/) が最終結果を返します。

## **有効なテキスト プロパティを取得する**

テキストの書式設定は複数のオブジェクトに分割されています:
- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/geteffective/) は、余白、アンカー、オートフィット、垂直テキスト方向などのテキストフレーム プロパティを解決します。
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/ja/net/aspose.slides/itextstyle/geteffective/) は、各テキスト スタイル レベルの段落書式設定を解決します。
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/geteffective/) は、配置、インデント、箇条書きなどの段落プロパティを解決します。
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/geteffective/) は、フォントの高さ、フォント ファミリ、色、太字、斜体などの文字プロパティを解決します。

次の例では、`text-formatting.pptx` に少なくとも 1 枚のスライドと、空でないテキスト フレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) が含まれている必要があります。AutoShape はシェイプ コレクション内の任意の位置に配置でき、コードは適切なオブジェクトを検索し、使用前に検証します。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **有効な 3D プロパティを取得する**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/geteffective/) は、すべての解決された 3D 設定をまとめた [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) オブジェクトを返します。その [Camera](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/camera/)、[LightRig](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/lightrig/)、[BevelTop](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/beveltop/)、[BevelBottom](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) プロパティは、対応する有効データを公開します。これらの関連設定をまとめて読み取ることで、シェイプの最終的な 3D 表示を理解しやすくなります。

この例では、`shape-3d.pptx` の最初のスライドに少なくとも 1 つのシェイプが含まれている必要があります。デフォルト以外の値を出力に含めたい場合は、そのシェイプに 3D カメラ、照明、またはベベル設定を適用してください。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **有効なテーブル書式設定を取得する**

テーブルの書式設定は、テーブル スタイルとテーブル全体、列、行、個々のセルに適用された書式設定の両方から取得されます。明示的に定義された塗りつぶしが競合する場合の優先順位は、セル、行、列、そしてテーブル全体です。セルの有効書式は、そのセルを描画する際に使用される最終書式です。

この例では、`table-formatting.pptx` の最初のスライドに少なくとも 1 つのテーブルが含まれている必要があります。テーブルは最低でも 1 行と 1 列を持つ必要があります。コードは `Shapes[0]` がテーブルであると仮定せず、[ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) を検索します。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

塗りつぶしのタイプだけでなく色が必要な場合は、まず有効な [FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformateffectivedata/filltype/) を確認し、そのタイプに適用されるプロパティを読み取ります。例えば、実体塗りつぶしの場合は [SolidFillColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) を使用します。

## **変更後に有効データを再読み取りする**

有効データは、解決時点での書式設定階層を示します。その階層に関与できるものを変更した後は、`GetEffective` を再度呼び出します。対象には次が含まれます:
- オブジェクトのローカル書式設定;
- 段落またはテキストフレームのデフォルト;
- テーブル スタイル、テーブル、列、行、またはセルの書式設定;
- レイアウトまたはマスタースライドの書式設定;
- テーマ データまたはプレゼンテーション レベルのデフォルト;
- スライドに割り当てられたレイアウトまたはマスター。

有効データ オブジェクトを永続的なスナップショットとして保持しないでください。Aspose.Slides は内部で一部の有効データをキャッシュする可能性があり、後で `GetEffective` を呼び出すとデータが更新されます。変更前後の値を比較する必要がある場合は、変更を行う前にフォントの高さ、色、配置、ベベル幅など必要なスカラー値を自分の変数にコピーしてください。

値を変更するには、適切なローカル フォーマット オブジェクトを更新し、その後 `GetEffective` を呼び出して結果を確認します。有効データ オブジェクト自体は読み取り専用です。

## **FAQ**

**どのレベルが有効な値を提供したかを判断するには？**

有効データは最終値を含み、そのソースは含みません。最も具体的なレベルから外側へ向かって該当するローカルオブジェクトを確認してください。テキストの場合、部分、段落、テキストフレーム、レイアウト、マスター、テーマ、プレゼンテーションのデフォルトが含まれます。`float.NaN` や `null` のような未定義の値は、検索が別のレベルに続くことを示します。

**プロパティがどのレベルでも定義されていない場合はどうなりますか？**

Aspose.Slides は適切な PowerPoint またはライブラリのデフォルトを解決します。その解決された値は、ローカルオブジェクトが明示的に定義していなくても有効データに表示されます。

**なぜ有効値がローカル値と同じになることがあるのですか？**

ローカル値が継承計算で優先されたためです。オブジェクトにプロパティが明示的に設定され、より具体的なルールが上書きしない場合にこうなります。

**ローカルデータを使うべき時期はいつで、いつ有効データを使うべきですか？**

特定の書式設定レベルを検査または編集する場合はローカルデータを使用します。継承、テーマ ルール、適用されるスタイルが解決された後の最終的な外観が必要な場合は有効データを使用します。[完全な比較例](#compare-local-inherited-and-effective-values) は同じワークフローで両方を示しています。