---
title: インク
type: docs
weight: 180
url: /ja/net/examples/elements/ink/
keywords:
- インク
- インクへのアクセス
- インクの削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でインクを操作します。ストロークの描画、インポート、編集、色と幅の調整を行い、C# のサンプルを使用して PPT、PPTX、ODP にエクスポートします。"
---
この記事では、既存のインク シェイプにアクセスし、それらを **Aspose.Slides for .NET** を使用して削除する例を示します。

> ❗ **注:** インク シェイプは、専用デバイスからのユーザー入力を表します。Aspose.Slides ではプログラムから新しいインクストロークを作成できませんが、既存のインクを読み取って変更することは可能です。

## **インクへのアクセス**

スライド上の最初のインク シェイプからタグを読み取ります。

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // 必要に応じて tagName を使用します。
        }
    }
}
```

## **インクの削除**

インク シェイプが存在する場合、スライドから削除します。

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```