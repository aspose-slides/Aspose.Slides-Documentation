---
title: スマートアートの管理
type: docs
weight: 10
url: /ja/net/manage-smartart/
keywords: "SmartArt, SmartArt からのテキスト, 組織タイプチャート, ピクチャー組織チャート, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET での PowerPoint プレゼンテーションにおける SmartArt と組織タイプチャート"
---

## **SmartArt からテキストを取得**
ISmartArtShape インターフェイスと SmartArtShape クラスにそれぞれ TextFrame プロパティが追加されました。このプロパティを使用すると、ノードのテキストだけでなく SmartArt のすべてのテキストを取得できます。以下のサンプルコードは SmartArt ノードからテキストを取得するのに役立ちます。
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


## **SmartArt のレイアウト タイプを変更**
SmartArt のレイアウト タイプを変更するには、以下の手順に従ってください：

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- SmartArt BasicBlockList を追加します。
- LayoutType を BasicProcess に変更します。
- プレゼンテーションを書き込み、PPTX ファイルとして保存します。

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


## **SmartArt の Hidden プロパティを確認**
メソッド com.aspose.slides.ISmartArtNode.isHidden() は、このノードがデータモデルで非表示ノードの場合に true を返すことに注意してください。SmartArt の任意のノードの hidden プロパティを確認するには、以下の手順に従ってください：

- `Presentation` クラスのインスタンスを作成します。
- SmartArt RadialCycle を追加します。
- SmartArt にノードを追加します。
- isHidden プロパティを確認します。
- プレゼンテーションを書き込み、PPTX ファイルとして保存します。

以下の例では、2 つの図形の間にコネクタを追加しています。
```c#
using (Presentation presentation = new Presentation())
{
    // スマートアート BasicProcess を追加 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // スマートアートにノードを追加 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // isHidden プロパティを確認
    bool hidden = node.IsHidden; // true を返す

    if (hidden)
    {
        // 何らかの処理または通知を行う
    }
    // プレゼンテーションを保存
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **組織図のタイプを取得または設定**
メソッド com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() と setOrganizationChartLayout(int) は、現在のノードに関連付けられた組織図のタイプを取得または設定できます。組織図のタイプを取得または設定するには、以下の手順に従ってください：

- `Presentation` クラスのインスタンスを作成します。
- スライドに SmartArt を追加します。
- 組織図のタイプを取得または設定します。
- プレゼンテーションを書き込み、PPTX ファイルとして保存します。

以下の例では、2 つの図形の間にコネクタを追加しています。
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess を追加 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 組織図のタイプを取得または設定 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // プレゼンテーションを保存
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **ピクチャー組織図の作成**
Aspose.Slides for .NET は、PictureOrganization チャートを簡単に作成するためのシンプルな API を提供します。スライド上にチャートを作成するには、次の手順を実行します。

1. `Presentation` クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルト データと目的のタイプ (ChartType.PictureOrganizationChart) を指定してチャートを追加します。
1. 修正したプレゼンテーションを書き込み、PPTX ファイルとして保存します。

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


## **よくある質問**

**SmartArt は RTL 言語のミラーリング/反転をサポートしていますか？**

はい。選択された SmartArt タイプが反転をサポートしている場合、[IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) プロパティはダイアグラムの方向（LTR/RTL）を切り替えます。

**フォーマットを保持したまま SmartArt を同じスライドまたは別のプレゼンテーションにコピーするにはどうすればよいですか？**

Shapes コレクションを使って[SmartArt シェイプをクローン](/slides/ja/net/shape-manipulations/)するか（[ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)）、このシェイプが含まれるスライド全体を[クローン](/slides/ja/net/clone-slides/)できます。どちらの方法もサイズ、位置、スタイルを保持します。

**プレビューやウェブエクスポート用に SmartArt をラスタ画像にレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/net/convert-powerpoint-to-png/)（またはプレゼンテーション全体）して、PNG/JPEG に変換する API を使用します。SmartArt はスライドの一部として描画されます。

**スライドに複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[代替テキスト](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)（Alt Text）または[Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) を使用し、[Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 内でその属性でシェイプを検索し、タイプを確認してそれが[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)であることを確認します。ドキュメントにはシェイプの検索と操作に関する典型的な手法が記載されています。