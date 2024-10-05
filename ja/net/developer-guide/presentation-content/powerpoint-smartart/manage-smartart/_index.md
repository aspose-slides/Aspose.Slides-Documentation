---
title: スマートアートを管理する
type: docs
weight: 10
url: /net/manage-smartart/
keywords: "SmartArt, SmartArtからのテキスト, 組織図, 画像組織図, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointプレゼンテーションのスマートアートと組織図"
---

## **SmartArtからテキストを取得する**
現在、ISmartArtShapeインターフェイスおよびSmartArtShapeクラスにTextFrameプロパティが追加されました。このプロパティを使用すると、ノードのテキストだけでなく、SmartArtからすべてのテキストを取得できます。以下のサンプルコードは、SmartArtノードからテキストを取得するのに役立ちます。

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



## **SmartArtのレイアウトタイプを変更する**
SmartArtのレイアウトタイプを変更するには、以下の手順に従ってください。

- `Presentation`クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- SmartArt BasicBlockListを追加します。
- LayoutTypeをBasicProcessに変更します。
- プレゼンテーションをPPTXファイルとして保存します。
  以下の例では、2つのシェイプの間にコネクタを追加しました。

```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcessを追加
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutTypeをBasicProcessに変更
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // プレゼンテーションの保存
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```



## **SmartArtの隠しプロパティを確認する**
メソッドcom.aspose.slides.ISmartArtNode.isHidden()は、このノードがデータモデル内の隠しノードである場合にtrueを返すことに注意してください。SmartArtの任意のノードの隠しプロパティを確認するには、以下の手順に従ってください。

- `Presentation`クラスのインスタンスを作成します。
- SmartArt RadialCycleを追加します。
- SmartArtにノードを追加します。
- isHiddenプロパティを確認します。
- プレゼンテーションをPPTXファイルとして保存します。

以下の例では、2つのシェイプの間にコネクタを追加しました。

```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcessを追加
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // SmartArtにノードを追加
    ISmartArtNode node = smart.AllNodes.AddNode();

    // isHiddenプロパティを確認
    bool hidden = node.IsHidden; // trueを返します

    if (hidden)
    {
        // いくつかのアクションまたは通知を実行
    }
    // プレゼンテーションの保存
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **組織図タイプを取得または設定する**
メソッドcom.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)は、現在のノードに関連付けられた組織図タイプを取得または設定します。組織図タイプを取得または設定するには、以下の手順に従ってください。

- `Presentation`クラスのインスタンスを作成します。
- スライドにSmartArtを追加します。
- 組織図タイプを取得または設定します。
- プレゼンテーションをPPTXファイルとして保存します。
  以下の例では、2つのシェイプの間にコネクタを追加しました。

```c#
using (Presentation presentation = new Presentation())
{
    // SmartArt BasicProcessを追加
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 組織図タイプを取得または設定
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // プレゼンテーションの保存
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **画像組織図を作成する**
Aspose.Slides for .NETは、簡単に画像組織図を作成するためのシンプルなAPIを提供します。スライドで図を作成するには：

1. `Presentation`クラスのインスタンスを作成します。
1. インデックスによってスライドの参照を取得します。
1. デフォルトデータとともに所望のタイプ（ChartType.PictureOrganizationChart）で図を追加します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下のコードは、図を作成するために使用されます。

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