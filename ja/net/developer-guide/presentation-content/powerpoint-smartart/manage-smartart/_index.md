---
title: PowerPoint プレゼンテーションで SmartArt を .NET で管理する
linktitle: SmartArt を管理する
type: docs
weight: 10
url: /ja/net/manage-smartart/
keywords:
- スマートアート
- スマートアート テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像 組織図
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用し、スライドのデザインと自動化を高速化する明確な C# コードサンプルで、PowerPoint の SmartArt の作成と編集を学びましょう。"
---
## **概要**

SmartArt はノード、ノード シェイプ、およびレイアウトで構成される PowerPoint の図です。Aspose.Slides for .NET を使用すると、SmartArt の作成、ノードからのテキスト読み取り、レイアウトの変更、非表示ノードの検査、組織図レイアウトの構成、画像組織図の作成ができます。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt のノードは 1 つ以上のシェイプを含むことができます。ノード シェイプからテキストを読み取るには、[ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/) を反復処理し、次に [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/) が返す [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) を読み取ります。

この例では、少なくとも 1 枚のスライドと、そのスライドの最初のシェイプとして SmartArt オブジェクトが含まれるプレゼンテーションが必要です。利用可能な各テキスト フレームをコンソールに出力します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **SmartArt オブジェクトのレイアウト タイプを変更する**

SmartArt のレイアウトはノードの配置と接続方法を制御します。以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。[IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) に渡す位置とサイズはポイント単位で測定されます。レイアウトを変更するには、[ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) を設定します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **SmartArt ノードが非表示かどうかを確認する**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) は、ノードが SmartArt データ モデルで非表示かどうかを示します。選択されたレイアウトがノードを可視的な図形要素として表示しなくても、非表示ノードは構造内に存在する可能性があります。

以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、追加されたノードの非表示状態を確認します。ノードが非表示の場合はメッセージを出力し、図を保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt 図の場合、[ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) は親ノードの下で子ノードがどのように配置されるかを定義します。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側にぶら下げるように設定できます。

以下の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) の `LeftHanging` 値に設定します。0 ベースのインデックス `0` が最上位の最初のノードを選択し、その子ノードは選択された配置を使用します。変更されたプレゼンテーションは保存されます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図向けに設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際は、[SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。この例では画像プレースホルダーを含む図を保存しますが、プレースホルダーに画像は設定しません。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **レガシー図をシェイプのグループに変換する**

既存のプレゼンテーションを最新化する際、PowerPoint 97–2003 で作成された組織図を更新する必要がある場合があります。Aspose.Slides はこれらのレガシー図を [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) オブジェクトとして表します。[LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) を使用して図をシェイプのグループに変換すれば、個々のビジュアル要素を編集できます。詳細は [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) を参照してください。

変換は元の図を削除せずにシェイプ コレクションに新しいグループを追加します。変換が成功したら、[IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) を使用して元の図を削除し、重複コンテンツを防ぎます。シェイプの追加・削除がイテレーションを乱さないよう、変換前にレガシー図を配列に収集してください。

以下の例では、プレゼンテーションを開き、すべてのスライドを検索し、図をシェイプのグループに変換し、更新されたプレゼンテーションを PPTX として保存します。

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

保存されたプレゼンテーションには、変換されたレガシー図の代わりに編集可能なシェイプのグループが含まれ、元の図は残っていません。PowerPoint で PPTX を開き、各グループ内のテキスト、塗りつぶし、位置など個々の要素を編集できます。

## **よくある質問**

**SmartArt は RTL 言語向けにミラーリングまたは反転をサポートしていますか？**

はい。選択された SmartArt レイアウトが反転をサポートしている場合、[IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) プロパティは図の方向を左から右へから右から左へ、またはその逆に切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**

[SmartArt シェイプをクローン](/slides/ja/net/shape-manipulations/) するには [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) を使用するか、SmartArt を含むスライド全体を [クローン](/slides/ja/net/clone-slides/) できます。どちらの方法もサイズ、位置、書式を保持します。

**SmartArt をプレビューまたは Web エクスポート用のラスタ画像にレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/net/convert-powerpoint-to-png/) またはプレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**スライドに複数の SmartArt オブジェクトがある場合、特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) または [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) の値を設定し、[Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) でその値を検索し、対応するシェイプが [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/) であることを確認します。