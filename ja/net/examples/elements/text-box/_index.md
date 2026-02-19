---
title: テキスト ボックス
type: docs
weight: 40
url: /ja/net/examples/elements/text-box/
keywords:
- テキスト ボックス
- テキスト ボックスの追加
- テキスト ボックスへのアクセス
- テキスト ボックスの削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でテキスト ボックスを操作します：C# を使用して PPT、PPTX、ODP プレゼンテーションのテキストを追加、書式設定、配置、折り返し、自動調整、スタイル設定します。"
---
Aspose.Slides では、**テキスト ボックス**は `AutoShape` で表されます。ほぼすべてのシェイプがテキストを含めることができますが、典型的なテキスト ボックスは塗りつぶしや枠線がなく、テキストのみが表示されます。

このガイドでは、テキスト ボックスをプログラムで追加、アクセス、削除する方法について説明します。

## **テキスト ボックスの追加**

テキスト ボックスは、塗りつぶしや枠線がなく、書式設定されたテキストが含まれる `AutoShape` にすぎません。作成方法は次のとおりです：

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 矩形シェイプを作成します（デフォルトでは塗りつぶしと枠線があり、テキストはありません）。
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // 塗りつぶしと枠線を削除して、典型的なテキスト ボックスのように見せます。
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // テキストの書式設定を行います。
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // 実際のテキスト コンテンツを割り当てます。
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **注:** 非空の `TextFrame` を含む任意の `AutoShape` はテキスト ボックスとして機能します。

## **コンテンツでテキスト ボックスにアクセス**

特定のキーワード（例: "Slide"）を含むすべてのテキスト ボックスを見つけるには、シェイプを反復処理し、テキストをチェックします：

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // 編集可能なテキストを含めることができるのは AutoShape のみです。
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // 一致するテキスト ボックスで何らかの処理を行います。
            }
        }
    }
}
```

## **コンテンツでテキスト ボックスを削除**

この例では、特定のキーワードを含む最初のスライド上のすべてのテキスト ボックスを検索し、削除します：

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **ヒント:** 反復処理中に変更を行う際のコレクション変更エラーを防ぐため、シェイプ コレクションのコピーを作成してから変更してください。