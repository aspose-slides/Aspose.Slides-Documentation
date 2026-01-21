---
title: プレゼンテーションからテキストを抽出する
type: docs
weight: 60
url: /ja/cpp/extracting-text-from-the-presentation/
keywords:
- テキスト抽出
- テキスト取得
- スライド
- テキストボックス
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライドやプレゼンテーション全体からテキストを抽出し、PPT、PPTX、ODP のコンテンツをプログラムで処理する方法を学びます。"
---

{{% alert color="primary" %}} 

Presentationからテキストを抽出する必要がある開発者は珍しくありません。そのためには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。本記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。テキストは以下の方法で抽出できます:

[1枚のスライドからテキストを抽出](/slides/ja/cpp/extracting-text-from-the-presentation/)
[GetAllTextBoxes メソッドを使用してテキストを抽出](/slides/ja/cpp/extracting-text-from-the-presentation/)
[分類された高速テキスト抽出](/slides/ja/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extracting Text from a Slide**
Aspose.Slides for C++ は Aspose.Slides.Util 名前空間を提供し、その中に PresentationScanner クラスがあります。このクラスはプレゼンテーションまたはスライド全体のテキストを抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、PresentationScanner クラスが提供する [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextboxes/) オーバーロード 静的メソッドを使用します。このメソッドは Slide オブジェクトをパラメーターとして受け取ります。実行時に、Slide メソッドはパラメーターとして渡されたスライドの全テキストをスキャンし、TextFrame オブジェクトの配列を返します。これにより、テキストに関連付けられた書式情報も取得できます。以下のコードはプレゼンテーションの最初のスライドのすべてのテキストを抽出します:

**C#**
``` cpp

 //PPTX ファイルを表す PresentationEx クラスをインスタンス化する
Presentation pptxPresentation = new Presentation(path + "demo.pptx");

 //最初のスライドから TextFrameEx オブジェクトの配列を取得する
ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

 //TextFrame の配列をループ処理する
for (int i = 0; i < textFramesSlideOne.Length; i++)
    //現在の TextFrame の段落をループ処理する
    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)
        //現在の段落のポーションをループ処理する
        foreach (Portion port in para.Portions)
        {
            //現在のポーションのテキストを表示する
            Console.WriteLine(port.Text);
            //テキストのフォント高さを表示する
            Console.WriteLine(port.PortionFormat.FontHeight);
            //テキストのフォント名を表示する
            Console.WriteLine(port.PortionFormat.LatinFont.FontName);
        }



```



## **Extracting Text from the Whole Presentation**
プレゼンテーション全体のテキストをスキャンするには、PresentationScanner クラスが提供する [GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/) 静的メソッドを使用します。このメソッドは2つのパラメーターを取ります:

1. 最初に、テキストを抽出する対象の PPTX プレゼンテーションを表す Presentation オブジェクト。
2. 次に、テキストをスキャンする際にマスタースライドを含めるかどうかを決定する Boolean 値。   このメソッドは TextFrame オブジェクトの配列を返し、テキスト書式情報も含まれます。以下のコードはプレゼンテーション（マスタースライドを含む）のテキストと書式情報をスキャンします。

**C#**
``` cpp

 //PPTX ファイルを表す Presentation クラスをインスタンス化

Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//TextFrame の配列をループ処理

for (int i = 0; i < textFramesPPTX.Length; i++)

    //現在の ITextFrame の段落をループ処理

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //現在の IParagraph のポーションをループ処理

        foreach (IPortion port in para.Portions)

        {

            //現在のポーションのテキストを表示

            Console.WriteLine(port.Text);

            //テキストのフォント高さを表示

            Console.WriteLine(port.PortionFormat.FontHeight);

            //テキストのフォント名を表示

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }

```



## **Categorized and fast extraction of text**
Presentation クラスに新しい静的メソッド GetPresentationText が追加されました。このメソッドには2つのオーバーロードがあります:
``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```


ExtractionMode 列挙体の引数はテキスト結果の出力方法を指定し、以下の値に設定できます:
Unarranged - スライド上の位置を考慮しない生テキスト
Arranged - スライド上の順序と同じ順序でテキストが配置される

速度が重要な場合は Unarranged モードを使用できます。Arranged モードよりも高速です。

PresentationText はプレゼンテーションから抽出された生テキストを表します。Aspose.Slides.Util 名前空間の SlidesText プロパティを持ち、ISlideText オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。ISlideText オブジェクトには以下のプロパティがあります:

ISlideText.Text - スライドのシェイプ上のテキスト
ISlideText.MasterText - このスライドのマスターページ上のシェイプのテキスト
ISlideText.LayoutText - このスライドのレイアウトページ上のシェイプのテキスト
ISlideText.NotesText - このスライドのノートページ上のシェイプのテキスト

また、ISlideText インターフェイスを実装する SlideText クラスもあります。

新しい API は次のように使用できます:
``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```
