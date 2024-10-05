---
title: プレゼンテーションからのテキストの抽出
type: docs
weight: 60
url: /cpp/extracting-text-from-the-presentation/
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があるのは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。本記事では、Aspose.Slidesを使用してMicrosoft PowerPoint PPTXプレゼンテーションからテキストを抽出する方法を説明します。テキストは以下の方法で抽出できます：

[1つのスライドからのテキストの抽出](/slides/cpp/extracting-text-from-the-presentation/)
[GetAllTextBoxesメソッドを使用してテキストを抽出](/slides/cpp/extracting-text-from-the-presentation/)
[分類された迅速なテキスト抽出](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **スライドからのテキストの抽出**
Aspose.Slides for C++は、PresentationScannerクラスを含むAspose.Slides.Util名前空間を提供します。このクラスは、プレゼンテーションまたはスライドから全体のテキストを抽出するためのオーバーロードされた静的メソッドを多数公開しています。PPTXプレゼンテーションのスライドからテキストを抽出するには、PresentationScannerクラスによって公開されている[GetAllTextBoxes](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members)オーバーロードされた静的メソッドを使用します。このメソッドは、Slideオブジェクトをパラメーターとして受け取ります。
実行時に、Slideメソッドはパラメーターとして渡されたスライドから全体のテキストをスキャンし、TextFrameオブジェクトの配列を返します。これは、テキストに関連付けられた任意のテキスト形式が利用可能であることを意味します。以下のコードスニペットは、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します：

**C#**

``` cpp

 //PPTXファイルを表すPresentationExクラスをインスタンス化

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//最初のスライドからTextFrameExオブジェクトの配列を取得

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//TextFramesの配列をループ

for (int i = 0; i < textFramesSlideOne.Length; i++)

//現在のTextFrame内の段落をループ

foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

//現在の段落内のポーションをループ

foreach (Portion port in para.Portions)

{

    //現在のポーションのテキストを表示

    Console.WriteLine(port.Text);

    //テキストのフォントサイズを表示

    Console.WriteLine(port.PortionFormat.FontHeight);

    //テキストのフォント名を表示

    Console.WriteLine(port.PortionFormat.LatinFont.FontName);

}

```

## **全体のプレゼンテーションからのテキストの抽出**
全体のプレゼンテーションからテキストをスキャンするには、PresentationScannerクラスによって公開されている[GetAllTextFrames](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members)静的メソッドを使用します。これには2つのパラメータが必要です：

1. 最初に、テキストを抽出するPPTXプレゼンテーションを表すPresentationオブジェクト。
1. 次に、プレゼンテーションからテキストをスキャンするときにマスタースライドを含めるかどうかを決定するBoolean値。
   このメソッドは、テキスト形式情報を完全に含むTextFrameオブジェクトの配列を返します。以下のコードは、マスタースライドを含むプレゼンテーションからテキストと形式情報をスキャンします。

**C#**

``` cpp

 //PPTXファイルを表すPresentationクラスをインスタンス化

Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//PPTX内のすべてのスライドからITextFrameオブジェクトの配列を取得

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//TextFramesの配列をループ

for (int i = 0; i < textFramesPPTX.Length; i++)

//現在のITextFrame内の段落をループ

foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

//現在のIParagraph内のポーションをループ

foreach (IPortion port in para.Portions)

{

    //現在のポーションのテキストを表示

    Console.WriteLine(port.Text);

    //テキストのフォントサイズを表示

    Console.WriteLine(port.PortionFormat.FontHeight);

    //テキストのフォント名を表示

    if (port.PortionFormat.LatinFont != null)

        Console.WriteLine(port.PortionFormat.LatinFont.FontName);

}

```

## **分類された迅速なテキスト抽出**
Presentationクラスに新しい静的メソッドGetPresentationTextが追加されました。このメソッドには2つのオーバーロードがあります：

``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

```

ExtractionMode列挙型引数は、テキスト結果の出力形式を整理するモードを示し、次の値に設定できます：
Unarranged - スライド上の位置を無視した生のテキスト
Arranged - スライド上と同じ順序に配置されたテキスト

Unarrangedモードは、速度が重要な場合に使用できます。これは、Arrangedモードよりも高速です。

PresentationTextは、プレゼンテーションから抽出された生のテキストを表します。これは、ISlideTextオブジェクトの配列を返すAspose.Slides.Util名前空間のSlidesTextプロパティを含みます。各オブジェクトは、対応するスライド上のテキストを表します。ISlideTextオブジェクトには次のプロパティがあります：

ISlideText.Text - スライドのシェイプ上のテキスト
ISlideText.MasterText - このスライドのマスターページのシェイプ上のテキスト
ISlideText.LayoutText - このスライドのレイアウトページのシェイプ上のテキスト
ISlideText.NotesText - このスライドのノートページのシェイプ上のテキスト

ISlideTextインターフェースを実装するSlideTextクラスもあります。

新しいAPIは次のように使用できます：

``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);

```