---
title: マスタースライド
type: docs
weight: 30
url: /ja/net/examples/elements/master-slide/
keywords:
- マスタースライドの例
- マスタースライドの追加
- マスタースライドへのアクセス
- マスタースライドの削除
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides を使用してマスタースライドを管理します。テーマ、背景、プレースホルダーを作成、編集、クローン、フォーマットし、PowerPoint と OpenDocument のスライドを統合します。"
---

マスタースライドは PowerPoint のスライド継承階層の最上位を構成します。**マスタースライド**は背景、ロゴ、テキスト書式設定などの共通デザイン要素を定義します。**レイアウトスライド**はマスタースライドから継承し、**ノーマルスライド**はレイアウトスライドから継承します。

この記事では、Aspose.Slides for .NET を使用してマスタースライドを作成、変更、管理する方法を示します。

## マスタースライドの追加

この例では、既定のマスタースライドをクローンして新しいマスタースライドを作成する方法を示します。その後、レイアウトの継承を通じて全スライドに会社名バナーを追加します。

```csharp
static void Add_Master_Slide()
{
    using var pres = new Presentation();

    // Clone the default master slide
    var defaultMasterSlide = pres.Masters[0];
    var newMaster = pres.Masters.AddClone(defaultMasterSlide);

    // Add a banner with company name to the top of the master slide
    var textBox = newMaster.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assign the new master slide to a layout slide
    var layoutSlide = pres.LayoutSlides[0];
    layoutSlide.MasterSlide = newMaster;

    // Assign the layout slide to the first slide in the presentation
    pres.Slides[0].LayoutSlide = layoutSlide;
}
````

> 💡 **Tip 1:** マスタースライドは、すべてのスライドに一貫したブランディングや共有デザイン要素を適用する手段を提供します。マスターに加えた変更は、依存するレイアウトスライドやノーマルスライドに自動的に反映されます。

> 💡 **Tip 2:** マスタースライドに追加された形状や書式設定はレイアウトスライドに継承され、さらにそれらのレイアウトを使用するすべてのノーマルスライドにも継承されます。  
> 以下の画像は、マスタースライドに追加されたテキストボックスが最終スライドに自動的に表示される様子を示しています。

![マスター継承例](master-slide-banner.png)

## マスタースライドへのアクセス

`Presentation.Masters` コレクションを使用してマスタースライドにアクセスできます。以下に取得および操作方法を示します：

```csharp
static void Access_Master_Slide()
{
    using var pres = new Presentation();

    // Access the first master slide
    var firstMasterSlide = pres.Masters[0];

    // Change the background type
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## マスタースライドの削除

マスタースライドはインデックスまたは参照で削除できます。

```csharp
static void Remove_Master_Slide()
{
    using var pres = new Presentation();

    // Remove by index
    pres.Masters.RemoveAt(0);

    // Or remove by reference
    var firstMasterSlide = pres.Masters[0];
    pres.Masters.Remove(firstMasterSlide);
}
```

## 未使用マスタースライドの削除

一部のプレゼンテーションには使用されていないマスタースライドが含まれています。これらのスライドを削除すると、ファイルサイズの削減に役立ちます。

```csharp
static void RemoveUnused_Master_Slide()
{
    using var pres = new Presentation();

    // Remove all unused master slides (even those marked as Preserve)
    pres.Masters.RemoveUnused(ignorePreserveField: true);
}
```

> ⚙️ **Tip:** `RemoveUnused(true)` を使用して未使用のマスタースライドをクリーンアップし、プレゼンテーションのサイズを最小化します。