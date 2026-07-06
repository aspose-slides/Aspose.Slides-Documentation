---
title: .NET でプレゼンテーションからテキスト部分の境界を取得する
linktitle: 部分の境界
type: docs
weight: 47
url: /ja/net/portion-bounds/
keywords:
- テキスト部分の境界
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーション内のテキスト部分の境界を取得する方法を学びます。"
---
## **概要**

テキスト部分は段落内の特定のテキストフラグメントを表し、周囲のコンテンツとは独立してそのフラグメントを操作できます。Aspose.Slides では、テキストフラグメントの境界を取得したり、段落の一部だけに書式設定を適用したり、より詳細なレベルでテキストの動作を制御したりする必要がある場合に、部分を使用します。

この記事では、[IPortion.GetRect](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/getrect/) を使用して部分のバウンディング矩形を取得する方法を示します。また、[IPortion.GetCoordinates](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/getcoordinates/) を使用して部分の開始座標を取得する方法も示します。さらに、単一テキストフラグメントへのハイパーリンク適用、部分・段落・テキストフレーム・テーマの継承による書式解決、指定されたフォントが利用できない場合の対処など、一般的な部分関連シナリオをハイライトします。

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```
## **テキスト部分の境界取得**

[IPortion.GetRect](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/getrect/) を使用してテキスト部分のバウンディング矩形を取得します。

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```
## **テキスト部分の座標取得**

[IPortion.GetCoordinates](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/getcoordinates/) を使用してテキスト部分の開始座標を取得します。

## **よくある質問**

**単一段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、[assign a hyperlink](/slides/ja/net/manage-hyperlinks/) を個々の部分に割り当てることができます。そのフラグメントだけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか：部分は何を上書きし、段落やテキストフレームから何が引き継がれますか？**

部分レベルのプロパティが最も高い優先順位を持ちます。プロパティが[IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/)で設定されていない場合、Aspose.Slides は[IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/)から取得します。そこでも設定されていない場合は、[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) または[theme](https://reference.aspose.com/slides/ja/net/aspose.slides.theme/theme/) のスタイルが使用されます。

**部分に指定されたフォントが対象のマシンまたはサーバーに存在しない場合はどうなりますか？**

[Font substitution rules](/slides/ja/net/font-selection-sequence/) が適用されます。テキストの再フローが発生する可能性があり、メトリクス、ハイフネーション、幅が変わるため、正確な配置に影響します。

**段落全体とは別に、部分固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/) レベルでのテキストカラー、塗りつぶし、透明度は隣接するフラグメントとは異なる設定が可能です。