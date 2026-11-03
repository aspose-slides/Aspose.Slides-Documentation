---
title: .NET でプレゼンテーション プレースホルダーを管理する
linktitle: プレースホルダーの管理
type: docs
weight: 10
url: /ja/net/manage-placeholder/
keywords:
- プレースホルダー
- テキスト プレースホルダー
- 画像 プレースホルダー
- チャート プレースホルダー
- コンテンツ プレースホルダー
- プロンプト テキスト
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、テキスト、画像、チャート、コンテンツ プレースホルダーを検査・編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides はプレースホルダー情報を [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) プロパティで公開します。このプロパティは通常のシェイプの場合は `null`、それ以外は [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) オブジェクトを返します。[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) を使用して、プレースホルダーが何を保持することを意図しているかを判断します。

プレースホルダーの種類が分かっても、シェイプ インターフェイスは依然として重要です：

- 空のテキスト、画像、チャート、またはコンテンツ プレースホルダーは通常、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) で表されます。
- 内容が設定された画像プレースホルダーは、[IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) で表されます。
- 内容が設定されたチャートプレースホルダーは、[IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) で表されます。
- コンテンツ プレースホルダーは複数の種類のコンテンツを含むことができます。すべてのプレースホルダーが [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) であると仮定せず、[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) と実行時のシェイプ インターフェイスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) はプレースホルダーの役割を示しますが、シェイプの実行時タイプを保証するものではありません。テキスト、画像、チャート、テーブル、またはメディア固有のメンバーにアクセスする前に、必ずタイプチェックを行ってください。
{{% /alert %}}

## **プレースホルダーの継承を理解する**

プレースホルダーは階層を形成します：

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスター レベルのプレースホルダーも定義します。
2. レイアウトスライドは、1 つ以上の通常スライドで使用される配置を定義し、マスターから継承することができます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) を呼び出すと、この階層で 1 つ上のレベルに移動します。スライド プレースホルダーは通常、レイアウト プレースホルダーを返し、レイアウト プレースホルダーはマスタープレースホルダーを返すことがあります。シェイプにベース プレースホルダーがない場合、メソッドは `null` を返します。

次の例は、最初のスライド上のプレースホルダーを一覧表示し、それらのベース プレースホルダーを報告します：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

通常スライド上のプレースホルダーを編集すると、そのスライド用のローカル オーバーライドが作成または変更されます。関連するレイアウトやマスターを編集すると、設定を継承しているすべてのスライドに影響を与える可能性があります。ローカルの普通のシェイプはベース プレースホルダーを持たず、単に同じ座標にあるだけでは継承を開始しません。

## **プレースホルダーのステータスを削除する**

テンプレートを調整する際は、[IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) を使用して既存のオブジェクトを普通のシェイプとして保持します。その [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) プロパティは `null` になりますが、シェイプはスライドのコレクションに残ります。対照的に、[IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) はそのコレクションからシェイプを削除します。

次の例は、少なくとも 1 枚のスライドと最初のスライドに空でないテキスト プレースホルダーがある `template.pptx` を前提としています。レイアウトまたはマスターから書式設定を継承したプレースホルダーを使用して、関係を削除したときの影響を確認します。この例は同じシェイプが残っていることを確認し、普通のシェイプになった後に再度メソッドを呼び出し、結果を保存します：

{{% alert color="warning" title="Warning" %}}
プレースホルダーのステータスを削除しても、継承された外観設定が自動的に保持されるわけではありません。以下の例では、これらの設定を意図的に変更せずに残しているため、出力が異なる場合があります。位置とサイズが完全に継承されているシェイプは、呼び出し後に座標とサイズが 0 になり、コレクションに残っていても見えなくなることがあります。
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // 普通のシェイプに対してメソッドを呼び出しても効果はありません。
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

一致するプレースホルダーについては、3 つのチェックすべてが `True` を出力します。テキストは残りますが、プレースホルダーの関係が削除されると、継承された位置、サイズ、回転、フォント、段落配置、テキスト フレームの余白、垂直アンカー、塗りつぶし、線の設定が変わることがあります。たとえば、継承されたタイトル書式は普通のテキスト書式に戻ることがあります。レイアウトの詳細については、[Slide Layout](/slides/ja/net/slide-layout/) を参照してください。

意図した外観を保持するには、呼び出し前に解決された位置、サイズ、回転を取得し、必要な有効書式設定値を別々の変数にコピーします。これらの値は [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/)、[IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/)、[ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/)、[IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/)、[ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) を使用して取得します。有効書式オブジェクトだけに依存しないでください。関係が削除された後にテキスト書式設定値が変わる可能性があります。取得した値を普通のシェイプに明示的に適用し、フォント ファミリ、サイズ、スタイル、色、段落設定、テキスト フレーム設定、塗りつぶし、線などテンプレートで使用されている設定を含めます。

継承されたシェイプのジオメトリも、[IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/) を使用して明示的に割り当てる必要がある場合があります。矩形テキスト プレースホルダーの場合、[ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) を割り当てることを意味します。塗りつぶしと線だけを復元しても、目に見える矩形が復元されないことがあります。追加のエフェクトやより複雑な書式設定を持つテンプレートでは、これらの設定も処理する必要があります。

## **プレースホルダーのテキストを変更する**

タイトル、センタリングされたタイトル、サブタイトル、本文、テキスト プレースホルダーは通常テキストをサポートします。[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) プロパティを使用する前に、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) であることを確認してください。

この例は、最初のスライドの最初のタイトル プレースホルダーを更新し、結果を保存します：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

このパターンは、画像、チャート、テーブル、またはメディア プレースホルダーを [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) にキャストすることを回避します。また、脆弱なシェイプ インデックスに依存せず、目的でプレースホルダーを識別します。

## **レイアウト上のプロンプトテキストを設定する**

プロンプト テキストは、*タイトルを追加するにはクリック* のように空のプレースホルダーに表示されるデザイン時の指示です。通常のスライドのシェイプ コレクションを介さずに、レイアウト プレースホルダーにカスタム プロンプト テキストを設定してください。[ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) でレイアウトにアクセスし、[ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/) を列挙します。

次の例は、最初のスライドで使用されるレイアウトのタイトルとサブタイトルのプロンプトを変更します：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

プロンプト テキストは通常のスライド コンテンツではありません。PowerPoint のような編集アプリケーションで空のプレースホルダー向けに意図されています。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用しているスライド上の既存のテキストは置き換わりません。

## **画像プレースホルダーを更新する**

処理すべき 2 つのケースがあります：

- 画像プレースホルダーがすでに内容を持ち、[IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) で表されている場合は、[IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) と [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合は、[IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースをサポートし、プレゼンテーションを保存します：

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

空のプレースホルダー用に作成された置き換えはローカルの画像フレームであり、新しいプレースホルダーではありません。これは [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) が読み取り専用であるためです。予約された位置は保持されますが、プレースホルダー固有の動作は継承されなくなります。プレースホルダーの関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを用意し内容を設定してから、Aspose.Slides で生成された [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) を更新してください。

画像の透過、トリミング、その他画像固有の効果については、[Manage Picture Frames](/slides/ja/net/picture-frame/) を参照してください。これらの操作はプレースホルダーのメタデータではなく、画像フレームまたは画像塗りつぶしに属します。

## **チャートおよびコンテンツプレースホルダーの操作**

内容が設定されたチャート プレースホルダーは [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) で表されます。この例では、プレースホルダーの種類と実行時インターフェイスの両方でチャートを検索し、タイトルを変更してファイルを保存します：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

一般的なコンテンツ プレースホルダーは通常、[PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) を持ちます。PowerPoint では、チャート、テーブル、図、画像、メディアなど複数のコンテンツ タイプの起動役として機能します。内容が設定された後は、実際のシェイプ インターフェイスを調べて何が含まれているかを確認してください。特化したレイアウトでは、[PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/)、または [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) を公開することもあります。

Aspose.Slides は、空の [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) プレースホルダーを [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) を変更するだけで [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) に変換しません。タイプは読み取り専用です。空のチャートまたはコンテンツ領域にプログラムで内容を設定するには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はチャートに対してそれを行います：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

追加されたチャートは普通のローカル チャートです。プレースホルダーの領域を占有しますが、レイアウト プレースホルダーからは継承しません。カテゴリ、シリーズ、ブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/net/powerpoint-charts/) を利用してください。

## **完全な例: テキストまたは画像コンテンツの更新**

次のエンドツーエンドの例は、テンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプのタイプを確認して、適切なコンテンツを更新し、出力を保存します。この例は、シェイプ インデックスを仮定したり、すべてのプレースホルダーを同じインターフェイスにキャストしたりすることを意図的に回避しています。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**ベース プレースホルダーとは何ですか？**

ベース プレースホルダーとは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応するシェイプのことです。[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) を使用して取得します。普通のローカル シェイプはプレースホルダー階層の一部ではないため、`null` を返します。

**レイアウト プレースホルダーを編集してすべてのスライドのタイトルを変更できますか？**

レイアウトを通じて継承された書式設定やプロンプト テキストを変更することは可能ですが、既存のタイトル コンテンツは通常のスライドに保存されています。プレゼンテーション全体のタイトル テキストを置き換えるには、スライドを反復処理し、各タイトル プレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどのように管理しますか？**

適切なスライド、レイアウト、マスター、ノート、またはハンドアウトのスコープでヘッダーおよびフッター マネージャーを使用します。完全な例については、[Manage Presentation Header and Footer](/slides/ja/net/presentation-header-and-footer/) を参照してください。