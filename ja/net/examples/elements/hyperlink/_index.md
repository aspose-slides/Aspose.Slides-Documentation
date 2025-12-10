---
title: ハイパーリンク
type: docs
weight: 130
url: /ja/net/examples/elements/hyperlink/
keywords:
- ハイパーリンク例
- ハイパーリンクの追加
- ハイパーリンクへのアクセス
- ハイパーリンクの削除
- ハイパーリンクの更新
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してハイパーリンクを追加、編集、削除します。テキスト、シェイプ、スライド、URL、メールアドレスにリンクし、PPT、PPTX、ODP の対象とアクションを設定できます。"
---

**Aspose.Slides for .NET** を使用して、シェイプ上のハイパーリンクの追加、アクセス、削除、更新を示します。

## **ハイパーリンクの追加**
外部ウェブサイトを指すハイパーリンクを持つ四角形シェイプを作成します。
```csharp
static void Add_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```


## **ハイパーリンクへのアクセス**
シェイプのテキスト部分からハイパーリンク情報を読み取ります。
```csharp
static void Access_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```


## **ハイパーリンクの削除**
シェイプのテキストからハイパーリンクをクリアします。
```csharp
static void Remove_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = null;
}
```


## **ハイパーリンクの更新**
既存のハイパーリンクのターゲットを変更します。`HyperlinkManager` を使用して、既にハイパーリンクが含まれているテキストを変更し、PowerPoint がハイパーリンクを安全に更新する方法を模倣します。
```csharp
static void Update_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // 既存のテキスト内のハイパーリンクを変更する場合は、
    // HyperlinkManager を使用し、プロパティを直接設定しないでください。
    // これは、PowerPoint がハイパーリンクを安全に更新する方法を模倣しています。
    portion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```
