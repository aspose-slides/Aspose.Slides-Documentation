---
title: スライド
type: docs
weight: 10
url: /ja/net/examples/elements/slide/
keywords:
- スライド例
- スライド追加
- スライドアクセス
- スライドインデックス
- スライドクローン
- スライド並び替え
- スライド削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してスライドを管理します: 作成、クローン、並び替え、非表示、背景とサイズの設定、トランジションの適用、PowerPoint および OpenDocument へのエクスポート。"
---

この記事では、**Aspose.Slides for .NET** を使用してスライドを操作する方法を示す一連の例を提供します。`Presentation` クラスを使用して、スライドの追加、アクセス、クローン、並び替え、削除の方法を学びます。

以下の各例は、簡単な説明と C# のコードスニペットで構成されています。

## スライドの追加

新しいスライドを追加するには、まずレイアウトを選択する必要があります。この例では、`Blank` レイアウトを使用し、プレゼンテーションに空のスライドを追加します。
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // 各スライドはレイアウトに基づき、そのレイアウトはマスタースライドに基づいています。
    // 新しいスライドを作成するには Blank レイアウトを使用します。
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // 選択したレイアウトを使用して新しい空のスライドを追加します
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## Access Slides by Index

You can access slides using their index, or find a slide’s index based on a reference. This is useful for iterating through or modifying specific slides.

```csharp
static void Access_Slide()
{
    // デフォルトでは、プレゼンテーションは空のスライドが1枚作成されます
    using var pres = new Presentation();

    // もう1枚空のスライドを追加します
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // インデックスでスライドにアクセスします
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // 参照からスライドのインデックスを取得し、インデックスでアクセスします
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```

## Clone a Slide

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```csharp
static void Clone_Slide()
{
    // デフォルトでは、プレゼンテーションには空のスライドが1枚含まれます
    using var pres = new Presentation();

    // 最初のスライドをクローンします。クローンされたスライドはプレゼンテーションの末尾に追加されます
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // クローンされたスライドのインデックスは 1 です（プレゼンテーションの2枚目のスライド）
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```

## Reorder Slides

You can change the order of slides by moving one to a new index. In this case, we move a cloned slide to the first position.

```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // 最初のスライドのクローンを追加します（デフォルトで作成されたもの）
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // クローンされたスライドを最初の位置に移動します（他のスライドは下にシフトします）
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```

## Remove a Slide

To remove a slide, simply reference it and call `Remove`. This example adds a second slide and then removes the original, leaving only the new one.

```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // デフォルトの最初のスライドに加えて、新しい空のスライドを追加します
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // 最初のスライドを削除します。新しく追加されたスライドだけが残ります
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
