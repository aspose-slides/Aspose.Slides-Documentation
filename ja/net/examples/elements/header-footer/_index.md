---
title: ヘッダーとフッター
type: docs
weight: 220
url: /ja/net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- ヘッダーとフッター
- ヘッダーとフッターを追加
- ヘッダーとフッターを更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してスライドのヘッダーとフッターを制御します。C# の例で、PPT、PPTX、ODP に日付、スライド番号、カスタムテキストを追加できます。"
---
この記事では、**Aspose.Slides for .NET** を使用してフッターを追加し、日付と時刻のプレースホルダーを更新する方法を示します。

## **フッターの追加**

スライドのフッター領域にテキストを追加し、表示させます。

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **日付と時刻の更新**

スライド上の日付と時刻のプレースホルダーを変更します。

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```