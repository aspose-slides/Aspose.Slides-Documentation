---
title: プレゼンテーションからテキストを抽出する
type: docs
weight: 90
url: /net/extract-text-from-presentation/
keywords: "スライドからテキストを抽出, PowerPointからテキストを抽出, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでスライドまたはPowerPointプレゼンテーションからテキストを抽出する"
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーションのすべてのスライドにあるすべてのシェイプからテキストを抽出する必要があります。この記事では、Aspose.Slidesを使用してMicrosoft PowerPoint PPTXプレゼンテーションからテキストを抽出する方法を説明します。テキストは以下の方法で抽出できます。

- [1つのスライドからテキストを抽出する](/slides/net/extracting-text-from-the-presentation/)
- [GetAllTextBoxesメソッドを使用してテキストを抽出する](/slides/net/extracting-text-from-the-presentation/)
- [分類された高速なテキスト抽出](/slides/net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **スライドからテキストを抽出する**
Aspose.Slides for .NETは、SlideUtilクラスを含むAspose.Slides.Util名前空間を提供します。このクラスは、プレゼンテーションまたはスライドからすべてのテキストを抽出するためのオーバーロードされた静的メソッドをいくつか公開しています。 PPTXプレゼンテーションのスライドからテキストを抽出するには、  
SlideUtilクラスによって公開された[GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextboxes)オーバーロード済み静的メソッドを使用します。このメソッドは、Slideオブジェクトをパラメータとして受け取ります。
実行すると、Slideメソッドはパラメータとして渡されたスライドからすべてのテキストをスキャンし、TextFrameオブジェクトの配列を返します。これは、テキストに関連付けられたフォーマット情報が利用可能であることを意味します。以下のコードは、プレゼンテーションの最初のスライドのすべてのテキストを抽出します。

```c#
//PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pptxPresentation = new Presentation("demo.pptx");

//PPTXのすべてのスライドからITextFrameオブジェクトの配列を取得
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//TextFramesの配列をループ
for (int i = 0; i < textFramesPPTX.Length; i++)
{
	//現在のITextFrameの段落をループ
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
	{
		//現在のIParagraphの部分をループ
		foreach (IPortion port in para.Portions)
		{
			//現在の部分のテキストを表示
			Console.WriteLine(port.Text);

			//テキストのフォント高さを表示
			Console.WriteLine(port.PortionFormat.FontHeight);

			//テキストのフォント名を表示
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
	}
}
```




## **プレゼンテーションからテキストを抽出する**
プレゼンテーション全体からテキストをスキャンするには、  
SlideUtilクラスによって公開された[GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes)静的メソッドを使用します。このメソッドは2つのパラメータを取ります：

1. 最初に、テキストが抽出されるPPTXプレゼンテーションを表すPresentationオブジェクト。
1. 2番目に、プレゼンテーションからテキストをスキャンする際にマスタースライドを含めるかどうかを決定するBoolean値。
   このメソッドは、テキストフォーマット情報を含むTextFrameオブジェクトの配列を返します。以下のコードは、マスタースライドを含むプレゼンテーションからテキストとフォーマット情報をスキャンします。

```c#
//PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pptxPresentation = new Presentation("demo.pptx");

//PPTXのすべてのスライドからITextFrameオブジェクトの配列を取得
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//TextFramesの配列をループ
for (int i = 0; i < textFramesPPTX.Length; i++)

	//現在のITextFrameの段落をループ
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

		//現在のIParagraphの部分をループ
		foreach (IPortion port in para.Portions)
		{
			//現在の部分のテキストを表示
			Console.WriteLine(port.Text);

			//テキストのフォント高さを表示
			Console.WriteLine(port.PortionFormat.FontHeight);

			//テキストのフォント名を表示
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
```




## **分類された高速テキスト抽出**
Presentationクラスに新しい静的メソッドGetPresentationTextが追加されました。このメソッドには2つのオーバーロードがあります：

``` csharp
PresentationText GetPresentationText(Stream stream)
PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

ExtractionMode列挙型の引数は、テキスト結果の出力を整理するモードを示し、以下の値に設定できます：
Unarranged - スライド上の位置を無視した生のテキスト
Arranged - スライド上の順序と同じ順序で配置されたテキスト

速度が重要な場合、Unarrangedモードが利用できます。これは、Arrangedモードよりも高速です。

PresentationTextは、プレゼンテーションから抽出された生のテキストを表します。これは、ISlideTextオブジェクトの配列を返すAspose.Slides.Util名前空間のSlidesTextプロパティを含みます。各オブジェクトは、対応するスライド上のテキストを表します。ISlideTextオブジェクトには以下のプロパティがあります：

ISlideText.Text - スライドのシェイプ上のテキスト
ISlideText.MasterText - このスライドのマスターページのシェイプ上のテキスト
ISlideText.LayoutText - このスライドのレイアウトページのシェイプ上のテキスト
ISlideText.NotesText - このスライドのノートページのシェイプ上のテキスト

SlideTextクラスもISlideTextインターフェースを実装しています。

新しいAPIは次のように使用できます：

```c#
IPresentationText text1 = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);
```