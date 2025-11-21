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
- レイアウト スライドのクローン作成
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してレイアウト スライドを管理します：PPT、PPTX、ODP 用のプレゼンテーションでプレースホルダーやテーマの作成、適用、クローン作成、名前変更、カスタマイズを行います。"
---

この記事では、Aspose.Slides for .NET で **Layout Slides** を操作する方法を示します。レイアウト スライドは、通常のスライドが継承するデザインと書式設定を定義します。レイアウト スライドの追加、アクセス、クローン作成、削除、未使用のレイアウト スライドのクリーンアップが可能で、プレゼンテーションのサイズを削減できます。

## レイアウト スライドの追加

再利用可能な書式設定を定義するためにカスタム レイアウト スライドを作成できます。たとえば、このレイアウトを使用するすべてのスライドに表示されるテキスト ボックスを追加することができます。

```csharp
static void Add_Layout_Slide()
{
    using var pres = new Presentation();
    
    // 空白レイアウトタイプとカスタム名でレイアウト スライドを作成
    var layoutSlide = pres.LayoutSlides.Add(pres.Masters[0], SlideLayoutType.Blank, "Main layout");

    // レイアウト スライドにテキスト ボックスを追加
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // このレイアウトを使用して 2 枚のスライドを追加; 両方ともレイアウトからテキストを継承
    pres.Slides.AddEmptySlide(layoutSlide);
    pres.Slides.AddEmptySlide(layoutSlide);
}
````

> 💡 **ヒント 1:** レイアウト スライドは個々のスライドのテンプレートとして機能します。共通要素を一度定義すれば、多くのスライドで再利用できます。

> 💡 **ヒント 2:** レイアウト スライドにシェイプやテキストを追加すると、そのレイアウトに基づくすべてのスライドが自動的に共有コンテンツを表示します。  
> 以下のスクリーンショットは、同じレイアウト スライドからテキスト ボックスを継承した 2 枚のスライドを示しています。

![レイアウト コンテンツを継承するスライド](layout-slide-result.png)

## レイアウト スライドへのアクセス

レイアウト スライドはインデックスまたはレイアウト タイプ（例: `Blank`、`Title`、`SectionHeader` など）でアクセスできます。

```csharp
static void Access_Layout_Slide()
{
    using var pres = new Presentation();
    
    // インデックスでアクセス
    var firstLayoutSlide = pres.LayoutSlides[0];
    
    // レイアウト タイプでアクセス
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## レイアウト スライドの削除

不要になった特定のレイアウト スライドを削除できます。

```csharp
static void Remove_Layout_Slide()
{
    using var pres = new Presentation();
    
    // タイプでレイアウト スライドを取得し削除
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    pres.LayoutSlides.Remove(blankLayoutSlide);
}
```

## 未使用レイアウト スライドの削除

プレゼンテーションのサイズを縮小するために、通常のスライドで使用されていないレイアウト スライドを削除したい場合があります。

```csharp
static void RemoveUnused_Layout_Slides()
{
    using var pres = new Presentation();
    
    // 参照されていないすべてのレイアウト スライドを自動的に削除
    pres.LayoutSlides.RemoveUnused();
}
```

## レイアウト スライドのクローン作成

`AddClone` メソッドを使用してレイアウト スライドを複製できます。

```csharp
static void Clone_Layout_Slides()
{
    using var pres = new Presentation();
    
    // タイプで既存のレイアウト スライドを取得
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // レイアウト スライドコレクションの末尾にクローンを追加
    var clonedLayoutSlide = pres.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **概要:** レイアウト スライドは、スライド全体で一貫した書式設定を管理する強力なツールです。Aspose.Slides は、レイアウト スライドの作成、管理、最適化に完全なコントロールを提供します。