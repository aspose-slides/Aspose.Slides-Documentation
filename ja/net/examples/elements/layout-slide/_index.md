---
title: レイアウトスライド
type: docs
weight: 20
url: /ja/net/examples/elements/layout-slide/
keywords:
- レイアウトスライド
- レイアウトスライドの追加
- レイアウトスライドへのアクセス
- レイアウトスライドの削除
- 未使用レイアウトスライド
- レイアウトスライドのクローン作成
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のマスターレイアウトスライド: スライドレイアウト、プレースホルダー、マスターを選択、適用、カスタマイズし、PPT、PPTX、ODP プレゼンテーションの C# サンプルを提供します。"
---
この記事では、Aspose.Slides for .NET の **Layout Slides** の使用方法を示します。レイアウトスライドは、通常のスライドが継承するデザインと書式を定義します。レイアウトスライドを追加、アクセス、クローン、削除でき、未使用のスライドをクリーンアップしてプレゼンテーションのサイズを削減できます。

## **レイアウトスライドの追加**

カスタムレイアウトスライドを作成して、再利用可能な書式を定義できます。たとえば、このレイアウトを使用するすべてのスライドに表示されるテキスト ボックスを追加することができます。

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // 空白のレイアウトタイプとカスタム名でレイアウトスライドを作成します。
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // レイアウトスライドにテキストボックスを追加します。
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // このレイアウトを使用して2枚のスライドを追加します。両方ともレイアウトからテキストを継承します。
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** レイアウトスライドは個々のスライドのテンプレートとして機能します。共通要素を一度定義すれば、複数のスライドで再利用できます。

> 💡 **Note 2:** レイアウトスライドにシェイプやテキストを追加すると、そのレイアウトに基づくすべてのスライドが自動的にこの共有コンテンツを表示します。
> スクリーンショットは、同じレイアウトスライドからテキストボックスを継承した2つのスライドを示しています。

![レイアウトコンテンツを継承するスライド](layout-slide-result.png)

## **レイアウトスライドへのアクセス**

レイアウトスライドはインデックスまたはレイアウトタイプ（例: `Blank`、`Title`、`SectionHeader` など）でアクセスできます。

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // インデックスでレイアウトスライドにアクセスします。
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // タイプでレイアウトスライドにアクセスします。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **レイアウトスライドの削除**

不要になった特定のレイアウトスライドを削除できます。

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // タイプでレイアウトスライドを取得し、削除します。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **未使用レイアウトスライドの削除**

プレゼンテーションのサイズを削減するために、通常のスライドで使用されていないレイアウトスライドを削除したい場合があります。

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // 参照されていないすべてのレイアウトスライドを自動的に削除します。
    presentation.LayoutSlides.RemoveUnused();
}
```

## **レイアウトスライドのクローン作成**

`AddClone` メソッドを使用してレイアウトスライドを複製できます。

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // タイプで既存のレイアウトスライドを取得します。
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // レイアウトスライドをコレクションの末尾にクローンします。
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Summary:** レイアウトスライドは、スライド全体で一貫した書式を管理するための強力なツールです。Aspose.Slides は、レイアウトスライドの作成、管理、最適化を完全にコントロールできるようにします。