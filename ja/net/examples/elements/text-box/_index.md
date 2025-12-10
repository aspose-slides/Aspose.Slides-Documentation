---
title: テキスト ボックス
type: docs
weight: 40
url: /ja/net/examples/elements/text-box/
keywords:
- テキストボックスの例
- テキストボックスの追加
- テキストボックスへのアクセス
- テキストボックスの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してテキストボックスを作成および書式設定します。フォント、配置、折り返し、自動調整、リンクを設定し、PowerPoint および OpenDocument 用のスライドを洗練させます。"
---

Aspose.Slides では、**テキスト ボックス**は `AutoShape` で表されます。ほぼすべての図形にテキストを含めることができますが、典型的なテキスト ボックスは塗りつぶしや枠線がなく、テキストのみが表示されます。

このガイドでは、テキスト ボックスをプログラムで追加、取得、削除する方法を説明します。

## **テキスト ボックスを追加**

テキスト ボックスは、塗りつぶしや枠線がなく、書式設定されたテキストを持つ単なる `AutoShape` です。作成方法は以下の通りです：

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
````

> 💡 **注:** 空でない `TextFrame` を含む `AutoShape` はすべて、テキスト ボックスとして機能できます。

## **コンテンツでテキスト ボックスにアクセス**

特定のキーワード（例: "Slide"）を含むすべてのテキスト ボックスを見つけるには、図形を反復処理し、そのテキストを確認します：

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

## **コンテンツでテキスト ボックスを削除**

この例では、特定のキーワードを含む最初のスライド上のすべてのテキスト ボックスを検索して削除します：

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

> 💡 **ヒント:** 反復処理中に変更を加える際は、コレクションの変更エラーを防ぐために、常に図形コレクションのコピーを作成してください。