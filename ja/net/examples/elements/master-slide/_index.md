---
title: マスタースライド
type: docs
weight: 30
url: /ja/net/examples/elements/master-slide/
keywords:
- マスタースライド
- マスタースライドの追加
- マスタースライドへのアクセス
- マスタースライドの削除
- 未使用マスタースライド
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のマスタースライド例を探求し、PPT、PPTX、ODP でマスター、プレースホルダー、テーマを作成、編集、スタイル設定する方法を明確な C# コードで示します。"
---
マスタースライドは、PowerPoint のスライド継承階層の最上位を構成します。**マスタースライド** は、背景、ロゴ、テキスト書式設定などの共通デザイン要素を定義します。**レイアウトスライド** はマスタースライドから継承し、**標準スライド** はレイアウトスライドから継承します。

この記事では、Aspose.Slides for .NET を使用してマスタースライドを作成、変更、および管理する方法を示します。

## **マスタースライドの追加**

この例では、デフォルトのマスタースライドをクローンして新しいマスタースライドを作成する方法を示します。その後、レイアウト継承を通じて全スライドに会社名バナーを追加します。

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // デフォルトのマスタースライドをクローンします。
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // マスタースライドの上部に会社名バナーを追加します。
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // 新しいマスタースライドをレイアウトスライドに割り当てます。
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // レイアウトスライドをプレゼンテーションの最初のスライドに割り当てます。
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **注 1:** マスタースライドは、すべてのスライドに一貫したブランディングや共有デザイン要素を適用する手段を提供します。マスターに加えた変更は、依存するレイアウトスライドおよび標準スライドに自動的に反映されます。

> 💡 **注 2:** マスタースライドに追加された図形や書式設定は、レイアウトスライドに継承され、さらにそのレイアウトを使用するすべての標準スライドにも継承されます。  
> 下の画像は、マスタースライドに追加されたテキストボックスが最終スライドに自動的に描画される様子を示しています。

![マスタ継承例](master-slide-banner.png)

## **マスタースライドへのアクセス**

`Presentation.Masters` コレクションを使用してマスタースライドにアクセスできます。以下は、それらを取得して操作する方法です。

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // 最初のマスタースライドにアクセスします。
    var firstMasterSlide = presentation.Masters[0];

    // 背景のタイプを変更します。
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **マスタースライドの削除**

マスタースライドは、インデックスまたは参照で削除できます。

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // インデックスでマスタースライドを削除します。
    presentation.Masters.RemoveAt(0);

    // 参照でマスタースライドを削除します。
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **未使用マスタースライドの削除**

一部のプレゼンテーションには使用されていないマスタースライドが含まれています。これらのスライドを削除すると、ファイルサイズの削減に役立ちます。

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // 未使用のマスタースライドをすべて削除します (Preserve とマークされたものも含む)。
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```