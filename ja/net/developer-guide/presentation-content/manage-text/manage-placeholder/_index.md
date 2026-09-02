---
title: ".NET でプレゼンテーションのプレースホルダーを管理する"
linktitle: "プレースホルダーの管理"
type: docs
weight: 10
url: /ja/net/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- グラフプレースホルダー
- コンテンツプレースホルダー
- プロンプトテキスト
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、テキスト、画像、グラフ、コンテンツのプレースホルダーを検査および編集し、プレースホルダーの継承について理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保する形状です。一般的な例として、タイトル、本文、画像、グラフ、汎用コンテンツのプレースホルダーがあります。通常の形状とは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides はプレースホルダー情報を [IShape.Placeholder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/placeholder/) プロパティで提供します。このプロパティは [IPlaceholder](https://reference.aspose.com/slides/ja/net/aspose.slides/iplaceholder/) オブジェクトを返し、通常の形状の場合は `null` です。プレースホルダーが何を含むことを意図しているかは [IPlaceholder.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/iplaceholder/type/) で確認します。

プレースホルダーの種類が分かったら、形状インターフェイスは依然として重要です。

- 空のテキスト、画像、グラフ、またはコンテンツプレースホルダーは通常、[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) で表されます。
- 内容が入った画像プレースホルダーは [IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/) で表されます。
- 内容が入ったグラフプレースホルダーは [IChart](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/) で表されます。
- コンテンツプレースホルダーはさまざまな種類のコンテンツを保持できます。すべてのプレースホルダーが [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると仮定せず、[IPlaceholder.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/iplaceholder/type/) と実行時の形状インターフェイスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/iplaceholder/type/) はプレースホルダーの役割を示しますが、形状の実行時タイプを保証するものではありません。テキスト、画像、グラフ、テーブル、メディア固有のメンバーにアクセスする前に、必ずタイプチェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承の理解**

プレースホルダーは階層構造を持ちます。

1. マスタースライドは再利用可能なスタイルと、場合によってはマスターレベルのプレースホルダーを定義します。
2. レイアウトスライドは 1 つ以上の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/getbaseplaceholder/) を呼び出すと、この階層で 1 つ上のレベルに移動できます。スライドのプレースホルダーは通常、レイアウトプレースホルダーを返し、レイアウトプレースホルダーはマスタープレースホルダーを返す可能性があります。形状に基礎プレースホルダーがない場合、このメソッドは `null` を返します。

以下の例は、最初のスライドのプレースホルダーを列挙し、基礎プレースホルダーを報告します。

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

通常スライドでプレースホルダーを編集すると、そのスライド用のローカルオーバーライドが作成または変更されます。関連するレイアウトまたはマスターを編集すると、まだその設定を継承しているすべてのスライドに影響を与える可能性があります。ローカルの通常形状には基礎プレースホルダーがなく、同じ座標に配置されているだけで継承が開始されるわけではありません。

## **プレースホルダー内のテキスト変更**

タイトル、センタードタイトル、サブタイトル、本文、テキストプレースホルダーは通常、テキストをサポートします。使用する前に [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) かどうか確認し、[TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/textframe/) プロパティを使用してください。

この例は最初のスライドの最初のタイトルプレースホルダーを更新し、結果を保存します。

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

このパターンは画像、グラフ、テーブル、メディアのプレースホルダーを [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) にキャストすることを回避します。また、脆弱な形状インデックスに依存せず、目的でプレースホルダーを識別します。

## **レイアウト上でプロンプトテキストを設定**

プロンプトテキストは、空のプレースホルダーに表示されるデザイン時の指示で、例として *Click to add title* があります。通常スライドの形状コレクションを介して取得しようとせず、レイアウトプレースホルダーにカスタムプロンプトテキストを設定してください。[ISlide.LayoutSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/layoutslide/) でレイアウトにアクセスし、[ILayoutSlide.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/shapes/) を反復処理します。

次の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します。

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

プロンプトテキストは通常スライドのコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに対して表示される指示です。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用しているスライド上の既存テキストは置き換わりません。

## **画像プレースホルダーの更新**

処理すべきケースは 2 つあります。

- 画像プレースホルダーがすでに入力済みで、[IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/) で表されている場合は、[IPictureFillFormat.Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/ipicturefillformat/picture/) と [ISlidesPicture.Image](https://reference.aspose.com/slides/ja/net/aspose.slides/islidespicture/image/) を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合は、[IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addpictureframe/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースをサポートし、プレゼンテーションを保存します。

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

空のプレースホルダー用に作成された置換はローカル画像フレームであり、新しいプレースホルダーではありません。これは [IShape.Placeholder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/placeholder/) が読み取り専用であるためです。予約された位置は保持されますが、プレースホルダー固有の挙動は継承されなくなります。プレースホルダーとの関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを作成・入力し、次に Aspose.Slides で生成された [IPictureFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/ipictureframe/) を更新してください。

画像の透過、クロッピング、その他の画像固有効果については、[Manage Picture Frames](/slides/ja/net/picture-frame/) を参照してください。これらの操作は画像フレームまたは画像塗りつぶしに対して行われ、プレースホルダーのメタデータには関係しません。

## **グラフおよびコンテンツプレースホルダーの操作**

入力済みのグラフプレースホルダーは [IChart](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/) で表されます。この例はプレースホルダータイプと実行時インターフェイスの両方で該当グラフを検索し、タイトルを変更してファイルを保存します。

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

一般的なコンテンツプレースホルダーは通常 [PlaceholderType.Object](https://reference.aspose.com/slides/ja/net/aspose.slides/placeholdertype/) を持ちます。PowerPoint では、グラフ、テーブル、図表、画像、メディアなど複数のコンテンツタイプのランチャーとして機能します。入力後は、実際の形状インターフェイスを調べて何が含まれているかを判別してください。特化したレイアウトは [PlaceholderType.Chart](https://reference.aspose.com/slides/ja/net/aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/ja/net/aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/ja/net/aspose.slides/placeholdertype/)、[PlaceholderType.Diagram](https://reference.aspose.com/slides/ja/net/aspose.slides/placeholdertype/) を公開することもあります。

Aspose.Slides は、空の [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) プレースホルダーを [IChart](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichart/) に単に [IPlaceholder.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/iplaceholder/type/) を変更しただけでは変換しません。タイプは読み取り専用です。空のグラフまたはコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。以下の例はグラフについてそれを実行します。

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

追加されたグラフは普通のローカルチャートです。プレースホルダーの領域を占有しますが、レイアウトプレースホルダーから継承はしません。カテゴリ、系列、ブックデータの置換が必要な場合は、専用の [chart management articles](/slides/ja/net/powerpoint-charts/) を参照してください。

## **完全例：テキストまたは画像コンテンツの更新**

次のエンドツーエンド例はテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーと形状のタイプを確認して適切なコンテンツを更新し、出力を保存します。この例は形状インデックスに依存したり、すべてのプレースホルダーを同一インターフェイスにキャストしたりすることを意図的に回避しています。

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

**基礎プレースホルダーとは何ですか？**

基礎プレースホルダーは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応する形状です。[IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/getbaseplaceholder/) を使用して取得します。ローカルの通常形状はプレースホルダー階層の一部ではないため `null` を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを通じて継承された書式やプロンプトテキストは変更できますが、実際のタイトルコンテンツは通常スライドに保存されています。プレゼンテーション全体のタイトルテキストを置き換えるには、スライドを列挙し、各タイトルプレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッタープレースホルダーはどう管理しますか？**

適切なスライド、レイアウト、マスター、ノート、配布資料のスコープでヘッダーおよびフッターマネージャーを使用します。完全な例については [Manage Presentation Header and Footer](/slides/ja/net/presentation-header-and-footer/) を参照してください。