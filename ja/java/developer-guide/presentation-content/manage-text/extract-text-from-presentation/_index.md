---
title: Java におけるプレゼンテーションの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/java/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPoint からテキスト抽出
- OpenDocument からテキスト抽出
- PPT からテキスト抽出
- PPTX からテキスト抽出
- ODP からテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPoint からテキスト取得
- OpenDocument からテキスト取得
- PPT からテキスト取得
- PPTX からテキスト取得
- ODP からテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルでステップバイステップのガイドに従って、時間を節約しましょう。"
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。本記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。

{{% /alert %}} 
## **スライドからテキストを抽出する**
Aspose.Slides for Java は [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil) クラスを提供します。このクラスは、プレゼンテーションまたはスライド全体のテキストを抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、[SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil) クラスが提供するオーバーロードされた静的メソッド [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) を使用します。このメソッドは Slide オブジェクトをパラメーターとして受け取ります。
実行すると、Slide メソッドはパラメーターとして渡されたスライドからテキスト全体をスキャンし、[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) オブジェクトの配列を返します。これにより、テキストに関連付けられた書式情報も取得できます。以下のコードは、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します:
```java
//PPTX ファイルを表す Presentation クラスをインスタンス化する
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得する
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //TextFrames の配列をループ処理する
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //現在の ITextFrame の段落をループ処理する
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //現在の IParagraph のポーションをループ処理する
                for (IPortion port : para.getPortions()) {
                    //現在のポーションのテキストを表示する
                    System.out.println(port.getText());

                    //テキストのフォント高さを表示する
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //テキストのフォント名を表示する
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


## **プレゼンテーション全体からテキストを抽出する**
プレゼンテーション全体のテキストをスキャンするには、SlideUtil クラスが提供する静的メソッド [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) を使用します。このメソッドは 2 つのパラメーターを受け取ります:

1. テキストを抽出する対象のプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) オブジェクト。
2. プレゼンテーションからテキストをスキャンする際に、マスタースライドを含めるかどうかを決定するブール値。

このメソッドは、テキスト書式情報を含む [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) オブジェクトの配列を返します。以下のコードは、プレゼンテーションおよびマスタースライドからテキストと書式情報をスキャンします:
```java
//PPTX ファイルを表す Presentation クラスをインスタンス化する
Presentation pres = new Presentation("demo.pptx");
try {
    //PPTX の全スライドから ITextFrame オブジェクトの配列を取得する
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //TextFrames 配列をループ処理する
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //現在の ITextFrame の段落をループ処理する
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //現在の IParagraph のポーションをループ処理する
            for (IPortion port : para.getPortions())
            {
                //現在のポーションのテキストを表示する
                System.out.println(port.getText());

                //テキストのフォント高さを表示する
                System.out.println(port.getPortionFormat().getFontHeight());

                //テキストのフォント名を表示する
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

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**Aspose.Slides はテキスト抽出時に大規模なプレゼンテーションをどのくらい高速に処理できますか？**

Aspose.Slides は高性能に最適化されており、[大規模なプレゼンテーション](/slides/ja/java/open-presentation/) でも効率的に処理できるため、リアルタイムや大量処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートなどからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスは必要ですか？**

無料トライアル版でもテキストの抽出は可能ですが、スライド数に制限などの制約があります。制限なく使用し、より大きなプレゼンテーションを扱うにはフルライセンスの購入が推奨されます。