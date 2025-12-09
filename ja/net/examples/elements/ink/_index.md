---
title: インク
type: docs
weight: 180
url: /ja/net/examples/elements/ink/
keywords:
- インク例
- インクへのアクセス
- インクの削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してスライド上のデジタルインクを操作します。ペンストロークの追加、パスの編集、色と幅の設定、そして PowerPoint と OpenDocument 用に結果をエクスポートできます。"
---

**Aspose.Slides for .NET** を使用して、既存のインクシェイプにアクセスし、それらを削除する例を提供します。

> ❗ **注:** インクシェイプは、特殊なデバイスからのユーザー入力を表します。Aspose.Slides はプログラムで新しいインクストロークを作成できませんが、既存のインクを読み取り、変更することは可能です。

## インクにアクセス

スライド上の最初のインクシェイプからタグを読み取ります。
```csharp
static void Access_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // 必要に応じて tagName を使用します
        }
    }
}
```


## インクの削除

存在する場合、スライドからインクシェイプを削除します。
```csharp
static void Remove_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```
