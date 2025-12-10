---
title: レイアウト スライド
type: docs
weight: 20
url: /ja/net/examples/elements/layout-slide/
keywords:
- レイアウト スライドの例
- レイアウト スライドの追加
- レイアウト スライドへのアクセス
- レイアウト スライドの削除
- 未使用のレイアウト スライド
- レイアウト スライドのクローン
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# を使用して Aspose.Slides でレイアウト スライドを管理します：プレゼンテーション（PPT、PPTX、ODP）の作成、適用、クローン、名前の変更、プレースホルダーやテーマのカスタマイズを行います。"
---

この記事では、Aspose.Slides for .NET で **Layout Slides** を操作する方法を示します。レイアウト スライドは、通常のスライドが継承するデザインと書式設定を定義します。レイアウト スライドの追加、取得、クローン、削除、未使用スライドのクリーンアップが可能で、プレゼンテーションのサイズを削減できます。

## **Add a Layout Slide**
レイアウト スライドをカスタム作成して、再利用可能な書式設定を定義できます。たとえば、このレイアウトを使用するすべてのスライドに表示されるテキスト ボックスを追加することが考えられます。

```csharp
static void Add_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Create a layout slide with a blank layout type and a custom name
    var layoutSlide = pres.LayoutSlides.Add(pres.Masters[0], SlideLayoutType.Blank, "Main layout");

    // Add a text box to the layout slide
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Add two slides using this layout; both will inherit the text from the layout
    pres.Slides.AddEmptySlide(layoutSlide);
    pres.Slides.AddEmptySlide(layoutSlide);
}
````

> 💡 **Tip 1:** レイアウト スライドは個別スライドのテンプレートとして機能します。共通要素を一度定義すれば、複数のスライドで再利用できます。

> 💡 **Tip 2:** レイアウト スライドにシェイプやテキストを追加すると、そのレイアウトを基にしたすべてのスライドで自動的に共有コンテンツが表示されます。  
> 以下のスクリーンショットは、同じレイアウト スライドからテキスト ボックスを継承した 2 つのスライドを示しています。

![Slides Inheriting Layout Content](layout-slide-result.png)


## **Access a Layout Slide**
レイアウト スライドはインデックスまたはレイアウト タイプ（例: `Blank`、`Title`、`SectionHeader` など）で取得できます。

```csharp
static void Access_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Access by index
    var firstLayoutSlide = pres.LayoutSlides[0];
    
    // Access by layout type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Remove a Layout Slide**
不要になった特定のレイアウト スライドを削除できます。

```csharp
static void Remove_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Get a layout slide by type and remove it
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    pres.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Remove Unused Layout Slides**
プレゼンテーションのサイズを縮小するために、通常のスライドで使用されていないレイアウト スライドを削除したい場合があります。

```csharp
static void RemoveUnused_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Automatically removes all layout slides not referenced by any slide
    pres.LayoutSlides.RemoveUnused();
}
```

## **Clone a Layout Slide**
`AddClone` メソッドを使用してレイアウト スライドを複製できます。

```csharp
static void Clone_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Get an existing layout slide by type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clone the layout slide to the end of the layout slide collection
    var clonedLayoutSlide = pres.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Summary:** レイアウト スライドは、スライド全体で一貫した書式設定を管理するための強力なツールです。Aspose.Slides は、レイアウト スライドの作成、管理、最適化をフルコントロールできる機能を提供します。