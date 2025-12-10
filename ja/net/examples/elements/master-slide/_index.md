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
description: "C# と Aspose.Slides を使用してマスタースライドを管理します：作成、編集、クローン、テーマ、背景、プレースホルダーの書式設定により、PowerPoint と OpenDocument のスライドを統一します。"
---

マスタースライドは PowerPoint のスライド継承階層の最上位に位置します。**マスタースライド** は背景、ロゴ、テキストの書式設定などの共通デザイン要素を定義します。**レイアウトスライド** はマスタースライドから継承し、**通常スライド** はレイアウトスライドから継承します。

この記事では、Aspose.Slides for .NET を使用してマスタースライドを作成、変更、管理する方法を示します。

## **マスタースライドを追加する**

この例では、デフォルトのマスタースライドをクローンして新しいマスタースライドを作成します。その後、レイアウト継承を通じてすべてのスライドに会社名バナーを追加します。

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

> 💡 **ヒント 1:** マスタースライドは、すべてのスライドに一貫したブランディングや共有デザイン要素を適用する方法を提供します。マスタースライドに加えた変更は、依存するレイアウトスライドや通常スライドに自動的に反映されます。

> 💡 **ヒント 2:** マスタースライドに追加した図形や書式設定は、レイアウトスライドを通じてそれらのレイアウトを使用するすべての通常スライドに継承されます。  
> 下の画像は、マスタースライドに追加したテキストボックスが最終スライドに自動的に描画される様子を示しています。

![Master Inheritance Example](master-slide-banner.png)

## **マスタースライドにアクセスする**

`Presentation.Masters` コレクションを使用してマスタースライドにアクセスできます。以下はマスタースライドを取得して操作する方法です。

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

## **マスタースライドを削除する**

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

## **未使用のマスタースライドを削除する**

プレゼンテーションによっては使用されていないマスタースライドが含まれることがあります。これらのスライドを削除するとファイルサイズの削減に役立ちます。

```csharp
static void RemoveUnused_Master_Slide()
{
    using var pres = new Presentation();

    // Remove all unused master slides (even those marked as Preserve)
    pres.Masters.RemoveUnused(ignorePreserveField: true);
}
```

> ⚙️ **ヒント:** `RemoveUnused(true)` を使用して未使用のマスタースライドをクリーンアップし、プレゼンテーションのサイズを最小化します。