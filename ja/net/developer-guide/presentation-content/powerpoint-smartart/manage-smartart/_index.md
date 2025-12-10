---
title: .NET で PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt を管理する
type: docs
weight: 10
url: /ja/net/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を使用し、スライド デザインと自動化を高速化する明快な C# コードサンプルで、PowerPoint の SmartArt を作成および編集する方法を学びます。"
---

## **SmartArt オブジェクトからテキストを取得**
現在、ISmartArtShape インターフェイスと SmartArtShape クラスにそれぞれ TextFrame プロパティが追加されました。このプロパティを使用すると、ノードのテキストだけでなく SmartArt 全体のテキストを取得できます。以下のサンプルコードは、SmartArt ノードからテキストを取得する方法を示しています。
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


## **SmartArt オブジェクトのレイアウト タイプを変更**
SmartArt のレイアウト タイプを変更するには、以下の手順に従ってください。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- SmartArt BasicBlockList を追加します。
- LayoutType を BasicProcess に変更します。
- プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、2 つの図形間にコネクタを追加しています。
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


## **SmartArt オブジェクトの Hidden プロパティを確認**
メソッド com.aspose.slides.ISmartArtNode.isHidden() は、このノードがデータモデルで非表示ノードである場合に true を返すことに注意してください。SmartArt の任意のノードの hidden プロパティを確認するには、以下の手順に従ってください。

- `Presentation` クラスのインスタンスを作成します。
- SmartArt RadialCycle を追加します。
- SmartArt にノードを追加します。
- isHidden プロパティを確認します。
- プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、2 つの図形間にコネクタを追加しています。
```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcess を追加 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // SmartArt にノードを追加 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // isHidden プロパティをチェック
    bool hidden = node.IsHidden; // true を返します

    if (hidden)
    {
        // 何らかのアクションまたは通知を実行
    }
    // プレゼンテーションを保存
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **組織図のタイプを取得または設定**
メソッド com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() と setOrganizationChartLayout(int) は、現在のノードに関連付けられた組織図のタイプを取得または設定できます。組織図のタイプを取得または設定するには、以下の手順に従ってください。

- `Presentation` クラスのインスタンスを作成します。
- スライドに SmartArt を追加します。
- 組織図のタイプを取得または設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、2 つの図形間にコネクタを追加しています。
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
Aspose.Slides for .NET は、PictureOrganization チャートを簡単に作成するためのシンプルな API を提供します。スライド上にチャートを作成する手順は以下の通りです：

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. デフォルトデータと希望のタイプ (ChartType.PictureOrganizationChart) を指定してチャートを追加します。
4. 変更したプレゼンテーションを PPTX ファイルに書き出します。

以下のコードはチャート作成に使用されます。
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
はい。選択した SmartArt タイプが反転をサポートしている場合、[IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) プロパティは図の方向 (LTR/RTL) を切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**  
形状コレクションを介して[SmartArt シェイプをクローン](/slides/ja/net/shape-manipulations/)するか、（[ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)）このシェイプを含むスライド全体を[スライド全体をクローン](/slides/ja/net/clone-slides/)することができます。どちらの方法でもサイズ、位置、スタイルが保持されます。

**SmartArt をプレビューやウェブエクスポート用にラスタ画像としてレンダリングするにはどうすればよいですか？**  
スライドを PNG/JPEG に変換する API を使用して[スライドをレンダリング](/slides/ja/net/convert-powerpoint-to-png/)（またはプレゼンテーション全体）することで、SmartArt はスライドの一部として描画されます。

**スライド上に複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**  
一般的な方法は、[代替テキスト](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) または[名前](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) を使用し、その属性で[Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 内のシェイプを検索し、タイプを確認して[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/) であることを確認する、という手法が一般的です。ドキュメントではシェイプの検索と操作に関する典型的な手法が説明されています。