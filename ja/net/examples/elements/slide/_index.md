---
title: スライド
type: docs
weight: 10
url: /ja/net/examples/elements/slide/
keywords:
- スライド
- スライドを追加
- スライドにアクセス
- スライドインデックス
- スライドをクローン
- スライドを並び替え
- スライドを削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でスライドを制御します：作成、クローン、並び替え、サイズ変更、背景設定、そして PPT、PPTX、ODP プレゼンテーション向けに C# でトランジションを適用します。"
---
この記事では、**Aspose.Slides for .NET** を使用してスライドを操作する一連の例を紹介します。`Presentation` クラスを使用して、スライドの追加、アクセス、クローン、並び替え、削除の方法を学びます。

以下の各例には簡単な説明と C# のコードスニペットが含まれます。

## **スライドの追加**

新しいスライドを追加するには、まずレイアウトを選択する必要があります。この例では `Blank` レイアウトを使用し、プレゼンテーションに空のスライドを追加します。

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // 各スライドはレイアウトに基づき、そのレイアウトはマスタースライドに基づきます。
    // Blank レイアウトを使用して新しいスライドを作成します。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // 選択したレイアウトを使用して新しい空のスライドを追加します。
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Note:** 各スライドレイアウトはマスタースライドから派生しており、全体のデザインとプレースホルダー構造を定義します。下の画像は、PowerPoint でマスタースライドとそれに関連付けられたレイアウトがどのように構成されているかを示しています。

![マスターとレイアウトの関係](master-layout-slide.png)

## **インデックスによるスライドへのアクセス**

インデックスを使用してスライドにアクセスしたり、参照からスライドのインデックスを取得したりできます。これは、スライドを反復処理したり特定のスライドを変更したりする際に便利です。

```csharp
static void AccessSlide()
{
    // デフォルトでは、プレゼンテーションは空のスライドが1枚作成されます。
    using var presentation = new Presentation();

    // 別の空のスライドを追加します。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // インデックスでスライドにアクセスします。
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // 参照からスライドインデックスを取得し、インデックスでアクセスします。
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **スライドのクローン**

この例では、既存のスライドをクローンする方法を示します。クローンされたスライドは自動的にスライドコレクションの末尾に追加されます。

```csharp
static void CloneSlide()
{
    // デフォルトでは、プレゼンテーションには空のスライドが1枚含まれます。
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // 最初のスライドをクローンします。クローンされたスライドはプレゼンテーションの末尾に追加されます。
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // クローンされたスライドのインデックスは1です（プレゼンテーションの2枚目のスライド）。
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **スライドの並び替え**

スライドの順序は、スライドを新しいインデックスに移動することで変更できます。この例では、クローンしたスライドを最初の位置に移動します。

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // 最初のスライドのクローンを追加します（デフォルトで作成されます）。
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // クローンされたスライドを最初の位置に移動します（他のスライドは下にシフトします）。
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **スライドの削除**

スライドを削除するには、対象のスライドを参照して `Remove` を呼び出すだけです。この例では、2 番目のスライドを追加し、元のスライドを削除して新しいスライドだけが残ります。

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // デフォルトの最初のスライドに加えて、新しい空のスライドを追加します。
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // 最初のスライドを削除します。新しく追加されたスライドだけが残ります。
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```