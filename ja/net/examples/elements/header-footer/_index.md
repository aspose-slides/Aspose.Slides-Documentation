---
title: ヘッダーとフッター
type: docs
weight: 220
url: /ja/net/examples/elements/elements/header-footer/
keywords:
- ヘッダーとフッターの例
- ヘッダーとフッターの追加
- ヘッダーとフッターの更新
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してヘッダーとフッターを制御します: 日付/時刻、スライド番号、フッターテキストを追加または編集し、PPT、PPTX、ODP でプレースホルダーの表示/非表示を切り替えます。"
---

Aspose.Slides for .NET を使用してフッターを追加し、日付と時刻のプレースホルダーを更新する方法を示します。

## **フッターを追加**

スライドのフッター領域にテキストを追加し、表示できるようにします。
```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```


## **日付と時刻の更新**

スライド上の日付と時刻のプレースホルダーを変更します。
```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
