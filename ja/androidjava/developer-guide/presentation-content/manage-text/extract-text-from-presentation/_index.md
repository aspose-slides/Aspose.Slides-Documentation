---
title: Android のプレゼンテーションから高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルで段階的なガイドに従って、時間を節約しましょう。"
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。この記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。 

{{% /alert %}} 
## **スライドからテキストを抽出する**
Aspose.Slides for Android via Java は [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) クラスを提供します。このクラスは、プレゼンテーションまたはスライドから全文テキストを抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、[SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) クラスが提供するオーバーロードされた静的メソッド [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) を使用します。このメソッドは Slide オブジェクトをパラメーターとして受け取ります。
実行時に、Slide メソッドはパラメーターとして渡されたスライドの全文テキストをスキャンし、[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) オブジェクトの配列を返します。これにより、テキストに関連付けられたすべてのテキスト書式設定が利用可能になります。以下のコードはプレゼンテーションの最初のスライドのすべてのテキストを抽出します:
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
                //現在の IParagraph の部分（ポーション）をループ処理
                for (IPortion port : para.getPortions()) {
                    //現在の部分のテキストを表示
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


## **プレゼンテーションからテキストを抽出する**
プレゼンテーション全体のテキストをスキャンするには、SlideUtil クラスが提供する静的メソッド [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) を使用します。このメソッドは 2 つのパラメーターを受け取ります:

1. まず、テキストを抽出する対象のプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) オブジェクトです。
2. 次に、プレゼンテーションからテキストをスキャンする際にマスタースライドを含めるかどうかを決定するブール値です。
このメソッドは、テキスト書式設定情報を含む [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) オブジェクトの配列を返します。以下のコードは、マスタースライドを含むプレゼンテーションからテキストと書式情報をスキャンします。
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


## **カテゴリ化された高速テキスト抽出**
Presentation クラスに新しい静的メソッド getPresentationText が追加されました。このメソッドには 3 つのオーバーロードがあります:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **よくある質問**

**テキスト抽出時に Aspose.Slides は大規模なプレゼンテーションをどれくらい高速に処理しますか？**

Aspose.Slides は高性能に最適化されており、[大規模なプレゼンテーション](/slides/ja/androidjava/open-presentation/) さえも効率的に処理できるため、リアルタイムやバルク処理のシナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスし分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

Aspose.Slides の無料トライアル版でもテキストを抽出できますが、処理できるスライド数に制限があるなどの制約があります。制限なく使用し、より大規模なプレゼンテーションを処理するには、正規のライセンスを購入することを推奨します。