---
title: .NET のプレゼンテーションから段落の境界を取得する
linktitle: 段落の境界
type: docs
weight: 43
url: /ja/net/paragraph-bounds/
keywords:
- 段落の境界
- 段落座標
- 段落サイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で段落の境界を取得し、PowerPoint プレゼンテーションのテキスト配置を最適化する方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides における段落の境界、サイズ、および座標の取得方法を説明します。[IParagraph.GetRect](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getrect/) を使用して [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) から段落の矩形を取得する方法、テーブルセルのテキストフレーム内の段落座標の取得方法、および測定単位、テキスト折り返しが境界に与える影響、ピクセル変換、実効段落書式設定値などの重要な詳細を示します。

## **段落の矩形座標を取得する**

[IParagraph.GetRect](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getrect/) を使用して段落のバウンディング矩形を取得します。

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **テーブルセルの TextFrame 内の段落のサイズを取得する**

テーブルセルのテキストフレーム内の [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) のサイズと座標を取得するには、[IParagraph.GetRect](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getrect/) を使用します。返される矩形はテーブルセルのテキストフレームに対して相対的であるため、スライドレベルの座標が必要な場合はテーブル位置とセルオフセットを加算します。

以下の例は、テーブルセル内の段落の境界を取得し、スライド上に矩形を描画してその境界を視覚化します。

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **よくある質問**

**段落の座標はどの単位で測定されますか？**

ポイントで測定されます。1インチは 72 ポイントです。これはスライド上のすべての座標と寸法に適用されます。

**ワードラッピングは段落の境界に影響しますか？**

はい。[TextFrameFormat.WrapText](https://reference.aspose.com/slides/ja/net/aspose.slides/textframeformat/wraptext/) が有効な場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポートされた画像のピクセルに確実にマッピングできますか？**

はい。ポイントをピクセルに変換するには次の式を使用します：pixels = points × (DPI / 72)。結果はレンダリングまたはエクスポート時に選択した DPI に依存します。

**スタイルの継承を考慮した「実効」段落書式設定パラメータを取得するにはどうすればよいですか？**

[実効段落書式設定データ構造](/slides/ja/net/shape-effective-properties/) を使用します。インデント、間隔、折り返し、RTL などの最終的な統合値が返されます。