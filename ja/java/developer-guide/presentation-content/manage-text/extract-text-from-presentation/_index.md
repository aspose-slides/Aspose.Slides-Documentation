---
title: Javaでのプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/java/extract-text-from-presentation/
keywords:
- テキストを抽出
- スライドからテキストを抽出
- プレゼンテーションからテキストを抽出
- PowerPointからテキストを抽出
- OpenDocumentからテキストを抽出
- PPTからテキストを抽出
- PPTXからテキストを抽出
- ODPからテキストを抽出
- テキストを取得
- スライドからテキストを取得
- プレゼンテーションからテキストを取得
- PowerPointからテキストを取得
- OpenDocumentからテキストを取得
- PPTからテキストを取得
- PPTXからテキストを取得
- ODPからテキストを取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルなステップバイステップガイドに従って、時間を節約しましょう。"
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライド上のすべての図形からテキストを抽出する必要があります。この記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。

{{% /alert %}} 
## **スライドからテキストを抽出**
Aspose.Slides for Java は [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil) クラスを提供します。このクラスは、プレゼンテーションまたはスライド全体のテキストを抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、[SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil) クラスが提供する [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) オーバーロード静的メソッドを使用します。このメソッドは Slide オブジェクトをパラメータとして受け取ります。実行時に、Slide メソッドはパラメータとして渡されたスライド全体のテキストをスキャンし、[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) オブジェクトの配列を返します。これは、テキストに関連付けられた書式情報も取得できることを意味します。以下のコードは、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します:
```java
//PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //TextFrame の配列をループ処理
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //現在の ITextFrame の段落をループ処理
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //現在の IParagraph のポーションをループ処理
                for (IPortion port : para.getPortions()) {
                    //現在のポーションのテキストを表示
                    System.out.println(port.getText());

                    //テキストのフォント高さを表示
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //テキストのフォント名を表示
                    if (port.getPortionFormat().getLatinFont() != null)
                        System.out.println(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **プレゼンテーションからテキストを抽出**
プレゼンテーション全体のテキストをスキャンするには、SlideUtil クラスが提供する [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) 静的メソッドを使用します。このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象となるプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) オブジェクト。
1. 次に、プレゼンテーションからテキストをスキャンする際にマスタースライドを含めるかどうかを決定するブール値。

このメソッドは、テキスト書式情報を含む [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) オブジェクトの配列を返します。以下のコードは、マスタースライドを含めてプレゼンテーションからテキストと書式情報をスキャンします。
```java
//PPTX ファイルを表す Presentation クラスをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    //PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //TextFrame の配列をループ処理
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //現在の ITextFrame の段落をループ処理
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //現在の IParagraph のポーションをループ処理
            for (IPortion port : para.getPortions())
            {
                //現在のポーションのテキストを表示
                System.out.println(port.getText());

                //テキストのフォント高さを表示
                System.out.println(port.getPortionFormat().getFontHeight());

                //テキストのフォント名を表示
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **カテゴリ別かつ高速なテキスト抽出**
Presentation クラスに新しい静的メソッド getPresentationText が追加されました。このメソッドには 3 つのオーバーロードがあります:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **よくある質問**

**Aspose.Slides はテキスト抽出中に大規模なプレゼンテーションをどれくらい高速に処理しますか？**

Aspose.Slides は高性能に最適化されており、[大規模なプレゼンテーション](/slides/ja/java/open-presentation/) さえも効率的に処理できるため、リアルタイムまたはバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

無料トライアル版の Aspose.Slides を使用してテキストを抽出できますが、スライド数に制限があるなどの制約があります。制限なく利用し、より大きなプレゼンテーションを処理するには、フルライセンスの購入が推奨されます。