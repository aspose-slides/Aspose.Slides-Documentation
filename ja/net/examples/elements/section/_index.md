---
title: セクション
type: docs
weight: 90
url: /ja/net/examples/elements/section/
keywords:
- セクション
- スライド セクション
- セクションの追加
- セクションへのアクセス
- セクションの削除
- セクションの名前変更
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でスライド セクションを管理します。C# の例を使用して、PPT、PPTX、ODP 用にスライドを作成、名前変更、並べ替え、グループ化します。"
---
**Aspose.Slides for .NET** を使用して、プレゼンテーション セクションをプログラムで管理する例—追加、アクセス、削除、名前の変更。

## **セクションの追加**

特定のスライドから開始するセクションを作成します。

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // セクションの開始を示すスライドを指定します。
    presentation.Sections.AddSection("New Section", slide);
}
```

## **セクションへのアクセス**

プレゼンテーションからセクション情報を読み取ります。

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // インデックスでセクションにアクセスします。
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **セクションの削除**

以前に追加したセクションを削除します。

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // 最初のセクションを削除します。
    presentation.Sections.RemoveSection(section);
}
```

## **セクションの名前変更**

既存のセクションの名前を変更します。

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```