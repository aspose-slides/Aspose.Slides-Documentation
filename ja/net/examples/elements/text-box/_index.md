---
title: テキストボックス
type: docs
weight: 40
url: /ja/net/examples/elements/text-box/
keywords:
- テキストボックス例
- テキストボックスの追加
- テキストボックスへのアクセス
- テキストボックスの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides でテキストボックスを作成および書式設定します。フォント、配置、折り返し、オートフィット、リンクを設定し、PowerPoint と OpenDocument 用のスライドを磨きます。"
---

Aspose.Slides では、**テキストボックス**は `AutoShape` で表されます。ほぼすべての形状がテキストを含めることができますが、典型的なテキストボックスは塗りつぶしや枠線がなく、テキストだけが表示されます。

このガイドでは、テキストボックスをプログラムで追加、アクセス、削除する方法を説明します。

## テキストボックスの追加

テキストボックスは、塗りつぶしや枠線がなく、書式設定されたテキストを含む `AutoShape` にすぎません。作成方法は次のとおりです:

```csharp
public static void Add_TextBox()
{
    using var pres = new Presentation();

    // Create a rectangle shape (defaults to filled with border and no text)
    var textBox = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **注意:** 空でない `TextFrame` を含む `AutoShape` は、テキストボックスとして機能します。

## 内容でテキストボックスにアクセスする

特定のキーワード（例: "Slide"）を含むすべてのテキストボックスを見つけるには、シェイプを反復処理し、テキストを確認します:

```csharp
public static void Access_TextBox()
{
    using var pres = new Presentation();

    foreach (var shape in pres.Slides[0].Shapes)
    {
        // Only AutoShapes can contain editable text
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box
            }
        }
    }
}
```

## 内容でテキストボックスを削除する

この例では、特定のキーワードを含む最初のスライド上のすべてのテキストボックスを検索して削除します:

```csharp
public static void Remove_TextBox()
{
    using var pres = new Presentation();

    var shapesToRemove = pres.Slides[0].Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => pres.Slides[0].Shapes.Remove(shape));
}
```

> 💡 **ヒント:** 反復処理中に変更エラーを防ぐため、形状コレクションを変更する前に必ずコピーを作成してください。