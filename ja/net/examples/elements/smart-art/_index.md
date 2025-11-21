---
title: SmartArt
type: docs
weight: 140
url: /ja/net/examples/elements/smartart/
keywords:
- SmartArt の例
- SmartArt の追加
- SmartArt へのアクセス
- SmartArt の削除
- SmartArt のレイアウト
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用して SmartArt を作成および編集します：ノードの追加、レイアウトとスタイルの変更、正確にシェイプへ変換、そして PPT、PPTX、ODP 用にエクスポートします。"
---

**Aspose.Slides for .NET** を使用して、SmartArt グラフィックの追加、アクセス、削除、レイアウト変更方法を示します。

## SmartArt の追加

組み込みレイアウトのいずれかを使用して SmartArt グラフィックを挿入します。
```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```


## SmartArt へのアクセス

スライド上の最初の SmartArt オブジェクトを取得します。
```csharp
static void Access_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```


## SmartArt の削除

スライドから SmartArt シェイプを削除します。
```csharp
static void Remove_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smart);
}
```


## SmartArt レイアウトの変更

既存の SmartArt グラフィックのレイアウト タイプを更新します。
```csharp
static void Change_SmartArt_Layout()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smart.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
