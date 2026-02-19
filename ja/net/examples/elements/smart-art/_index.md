---
title: SmartArt
type: docs
weight: 140
url: /ja/net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt の追加
- SmartArt へのアクセス
- SmartArt の削除
- SmartArt レイアウト
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で SmartArt を操作します。PowerPoint および OpenDocument プレゼンテーション用に C# でダイアグラムの作成、編集、変換、スタイル設定を行います。"
---
この記事では、**Aspose.Slides for .NET** を使用して SmartArt グラフィックの追加、アクセス、削除、レイアウトの変更方法を示します。

## **SmartArt の追加**

組み込みレイアウトのいずれかを使用して SmartArt グラフィックを挿入します。

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **SmartArt へのアクセス**

スライド上の最初の SmartArt オブジェクトを取得します。

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **SmartArt の削除**

スライドから SmartArt シェイプを削除します。

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **SmartArt レイアウトの変更**

既存の SmartArt グラフィックのレイアウトタイプを更新します。

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```