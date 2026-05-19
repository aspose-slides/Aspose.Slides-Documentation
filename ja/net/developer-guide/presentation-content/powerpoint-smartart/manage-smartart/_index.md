---
title: .NETでPowerPointプレゼンテーションのSmartArtを管理する
linktitle: SmartArtの管理
type: docs
weight: 10
url: /ja/net/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像 組織図
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を使用し、スライドのデザインと自動化を高速化する明快な C# コードサンプルで、PowerPoint の SmartArt の作成と編集を学びます。"
---
## **概要**

SmartArtは、ノード、ノードシェイプ、およびレイアウトで構成されたPowerPointの図です。Aspose.Slides for .NETを使用すると、SmartArtの作成、ノードからテキストの読み取り、レイアウトの変更、非表示ノードの検査、組織図レイアウトの構成、画像組織図の作成が可能です。

## **SmartArtオブジェクトからテキストを取得する**

SmartArtノードは1つ以上のシェイプを含めることができます。表示テキストを取得するには、[ISmartArt.AllNodes](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartart/allnodes/)を反復処理し、続いて[ISmartArtShape.TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartartshape/textframe/)が返す[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/)を読み取ります。

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **SmartArtオブジェクトのレイアウトタイプを変更する**

SmartArtのレイアウトはノードの配置と接続方法を制御します。以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/smartartlayouttype/) の `BasicBlockList` 値でSmartArtオブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **SmartArtノードが非表示かどうかを確認する**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartartnode/ishidden/) は、SmartArtデータモデル内でノードが非表示かどうかを示します。選択されたレイアウトがノードを可視的な図要素として表示しなくても、非表示ノードは構造内に存在することがあります。

以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/smartartlayouttype/) の `RadialCycle` 値を使用するSmartArtオブジェクトにノードを追加し、ノードの非表示状態を確認します。

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用するSmartArt図の場合、[ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) は親ノードの下に子ノードが配置される方法を定義します。たとえば、選択された[OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側から吊り下げるように設定できます。

以下の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/organizationchartlayouttype/) の `LeftHanging` 値に設定します。

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図用に設計されたSmartArtレイアウトです。スライドにSmartArtオブジェクトを追加する際は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**SmartArtはRTL言語のミラーリングや反転をサポートしていますか？**

はい。選択されたSmartArtレイアウトが反転をサポートしている場合、[IsReversed](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/smartart/isreversed/) プロパティは図の方向を左から右へから右から左へ、またはその逆に切り替えます。

**SmartArtを同じスライドや別のプレゼンテーションにコピーし、書式設定を保持するにはどうすればよいですか？**

[SmartArtシェイプ](/slides/ja/net/shape-manipulations/) を [ShapeCollection.AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/shapecollection/addclone/) でクローンするか、SmartArtを含むスライド全体を [スライド全体をクローン](/slides/ja/net/clone-slides/) でクローンできます。どちらの方法もサイズ、位置、書式設定を保持します。

**SmartArtをプレビューやウェブエクスポート用にラスタ画像にレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/net/convert-powerpoint-to-png/) またはプレゼンテーション全体を PNG または JPEG に変換します。SmartArtはスライドの一部としてレンダリングされます。

**スライドに複数のSmartArtオブジェクトがある場合、特定のSmartArtオブジェクトを見つけるにはどうすればよいですか？**

SmartArtシェイプに固有の [AlternativeText](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/alternativetext/) または [Name](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/name/) 値を設定し、[Slide.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides/baseslide/shapes/) でその値を検索し、対象のシェイプが [ISmartArt](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartart/) であることを確認します。