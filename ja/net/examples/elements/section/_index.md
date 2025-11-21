---
title: セクション
type: docs
weight: 90
url: /ja/net/examples/elements/section/
keywords:
- セクションの例
- スライドのセクション
- セクションを追加
- セクションにアクセス
- セクションを削除
- セクションの名前変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用した C# でスライド セクションを管理します：セクションの作成、名前の変更、簡単な並び替え、セクション間のスライド移動、PPT、PPTX、ODP の表示制御が可能です。"
---

**Aspose.Slides for .NET** を使用して、プレゼンテーション セクションをプログラムで管理する例—追加、アクセス、削除、名前変更。

## セクションの追加

特定のスライドから始まるセクションを作成します。
```csharp
static void Add_Section()
{
    using var pres = new Presentation();

    // セクションの開始地点となるスライドを指定します
    pres.Sections.AddSection("New Section", pres.Slides[0]);
}
```


## セクションにアクセスする

プレゼンテーションからセクション情報を読み取ります。
```csharp
static void Access_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("My Section", pres.Slides[0]);

    // インデックスでセクションにアクセス
    var section = pres.Sections[0];
    var sectionName = section.Name;
}
```


## セクションの削除

以前に追加したセクションを削除します。
```csharp
static void Remove_Section()
{
    using var pres = new Presentation();
    var section = pres.Sections.AddSection("Temporary Section", pres.Slides[0]);

    // 最初のセクションを削除
    pres.Sections.RemoveSection(section);
}
```


## セクションの名前変更

既存のセクションの名前を変更します。
```csharp
static void Rename_Section()
{
    using var pres = new Presentation();
    pres.Sections.AddSection("Old Name", pres.Slides[0]);

    var section = pres.Sections[0];
    section.Name = "New Name";
}
```
