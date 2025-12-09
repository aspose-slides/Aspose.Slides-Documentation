---
title: ".NET で PowerPoint プレゼンテーションの SmartArt を管理"
linktitle: "SmartArt の管理"
type: docs
weight: 10
url: /ja/net/manage-smartart/
keywords:
- "SmartArt"
- "SmartArt テキスト"
- "レイアウト タイプ"
- "非表示 プロパティ"
- "組織図"
- "画像組織図"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用し、PowerPoint の SmartArt を作成・編集するための明確な C# コードサンプルで、スライドのデザインと自動化を迅速に実装できます。"
---

## **SmartArt からテキストを取得**
現在、ISmartArtShape インターフェイスと SmartArtShape クラスに TextFrame プロパティが追加されました。このプロパティを使用すると、ノードのテキストだけでなく SmartArt 全体のテキストを取得できます。以下のサンプルコードは SmartArt ノードからテキストを取得する方法を示します。
```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
	ISlide slide = pres.Slides[0];
	ISmartArt smartArt = (ISmartArt)slide.Shapes[0];

	ISmartArtNodeCollection smartArtNodes = smartArt.AllNodes;
	foreach (ISmartArtNode smartArtNode in smartArtNodes)
	{
		foreach (ISmartArtShape nodeShape in smartArtNode.Shapes)
		{
			if (nodeShape.TextFrame != null)
				Console.WriteLine(nodeShape.TextFrame.Text);
		}
	}
}
```


## **SmartArt のレイアウトタイプを変更**
SmartArt のレイアウトタイプを変更するには、以下の手順に従ってください：

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- SmartArt BasicBlockList を追加します。
- LayoutType を BasicProcess に変更します。
- プレゼンテーションを書き出して PPTX ファイルに保存します。
以下の例では、2 つの図形の間にコネクタを追加しています。
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess を追加
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutType を BasicProcess に変更
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // プレゼンテーションを保存
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```


## **SmartArt の非表示プロパティを確認**
メソッド com.aspose.slides.ISmartArtNode.isHidden() は、データモデルでノードが非表示の場合に true を返すことに注意してください。SmartArt の任意のノードの非表示プロパティを確認するには、以下の手順に従ってください：

- `Presentation` クラスのインスタンスを作成します。
- SmartArt RadialCycle を追加します。
- SmartArt にノードを追加します。
- isHidden プロパティを確認します。
- プレゼンテーションを書き出して PPTX ファイルに保存します。
以下の例では、2 つの図形の間にコネクタを追加しています。
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess を追加
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // SmartArt にノードを追加
    ISmartArtNode node = smart.AllNodes.AddNode();

    // isHidden プロパティを確認
    bool hidden = node.IsHidden; // true を返します

    if (hidden)
    {
        // 何らかのアクションまたは通知を実行
    }
    // プレゼンテーションを保存
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **組織図タイプの取得または設定**
メソッド com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() と setOrganizationChartLayout(int) を使用すると、現在のノードに関連付けられた組織図タイプを取得または設定できます。組織図タイプを取得または設定するには、以下の手順に従ってください：

- `Presentation` クラスのインスタンスを作成します。
- スライドに SmartArt を追加します。
- 組織図タイプを取得または設定します。
- プレゼンテーションを書き出して PPTX ファイルに保存します。
以下の例では、2 つの図形の間にコネクタを追加しています。
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess を追加 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 組織図タイプを取得または設定 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // プレゼンテーションを保存
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **画像組織図の作成**
Aspose.Slides for .NET は、PictureOrganization 図表を簡単に作成できるシンプルな API を提供します。スライド上に図表を作成する手順は次のとおりです：

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ (ChartType.PictureOrganizationChart) のチャートを追加します。
4. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードはチャートを作成するためのものです。
```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save("OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```


## **FAQ**

**SmartArt は RTL 言語のミラーリング/反転をサポートしていますか？**

はい。選択した SmartArt タイプが反転をサポートしている場合、[IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) プロパティで図の方向 (LTR/RTL) を切り替えることができます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーし、書式を保持するにはどうすればよいですか？**

シェイプコレクションを使用して [SmartArt シェイプをクローン](/slides/ja/net/shape-manipulations/) するか ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/))、このシェイプが含まれるスライド全体を [クローン](/slides/ja/net/clone-slides/) することができます。どちらの方法でもサイズ、位置、スタイルが保持されます。

**プレビューや Web エクスポートのために SmartArt をラスタ画像としてレンダリングするにはどうすればよいですか？**

スライド（またはプレゼンテーション全体）を PNG/JPEG に変換する API を使用して、[スライドをレンダリング](/slides/ja/net/convert-powerpoint-to-png/) します。SmartArt はスライドの一部として描画されます。

**スライドに複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[代替テキスト](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)（Alt Text）または [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) を使用し、[Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 内でその属性でシェイプを検索し、タイプが [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/) であることを確認することです。ドキュメントには、シェイプの検索と操作に関する典型的な手法が記載されています。