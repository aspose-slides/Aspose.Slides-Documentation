---
title: ハイパーリンク
type: docs
weight: 130
url: /ja/net/examples/elements/hyperlink/
keywords:
- ハイパーリンク
- ハイパーリンクを追加
- ハイパーリンクにアクセス
- ハイパーリンクを削除
- ハイパーリンクを更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でハイパーリンクを追加および管理します。テキスト、シェイプ、画像にリンクし、PPT、PPTX、ODP 用にターゲットとアクションを設定し、C# の例を示します。"
---
この記事では、**Aspose.Slides for .NET** を使用して、シェイプ上のハイパーリンクの追加、取得、削除、および更新を示します。

## **ハイパーリンクの追加**

外部ウェブサイトへリンクするハイパーリンクを持つ四角形シェイプを作成します。

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **ハイパーリンクへのアクセス**

シェイプのテキスト部分からハイパーリンク情報を読み取ります。

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **ハイパーリンクの削除**

シェイプのテキストからハイパーリンクをクリアします。

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **ハイパーリンクの更新**

既存のハイパーリンクの対象を書き換えます。`HyperlinkManager` を使用して、すでにハイパーリンクが含まれているテキストを変更し、PowerPoint がハイパーリンクを安全に更新する方法を模倣します。

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // 既存のテキスト内のハイパーリンクを変更する場合は、
    // プロパティを直接設定するのではなく、HyperlinkManager を使用すべきです。
    // これは、PowerPoint がハイパーリンクを安全に更新する方法を模倣しています。
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```