---
title: Androidのプレゼンテーションから高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/androidjava/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPointからテキスト抽出
- OpenDocumentからテキスト抽出
- PPTからテキスト抽出
- PPTXからテキスト抽出
- ODPからテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPointからテキスト取得
- OpenDocumentからテキスト取得
- PPTからテキスト取得
- PPTXからテキスト取得
- ODPからテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint と OpenDocument のプレゼンテーションからテキストをすばやく抽出します。シンプルな手順に従って、時間を節約してください。"
---

{{% alert color="primary" %}}
プレゼンテーションからテキストを抽出する必要がある開発者は珍しくありません。そのためには、プレゼンテーション内のすべてのスライドにあるすべてのシェイプからテキストを抽出する必要があります。この記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。
{{% /alert %}}
## **スライドからテキストを抽出**
Aspose.Slides for Android via Java は [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) クラスを提供します。このクラスは、プレゼンテーションまたはスライド全体のテキストを抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、[SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) クラスが提供する [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) のオーバーロードされた静的メソッドを使用します。このメソッドは Slide オブジェクトをパラメーターとして受け取ります。
実行すると、Slide メソッドはパラメーターとして渡されたスライド全体のテキストをスキャンし、[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) オブジェクトの配列を返します。これにより、テキストに関連付けられたすべての書式情報が利用可能になります。以下のコードは、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します。
```java
//PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得します
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //TextFrame の配列をループします
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //現在の ITextFrame の段落をループします
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //現在の IParagraph の部分をループします
                for (IPortion port : para.getPortions()) {
                    //現在の部分のテキストを表示します
                    System.out.println(port.getText());

                    //テキストのフォント高さを表示します
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //テキストのフォント名を表示します
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
プレゼンテーション全体のテキストをスキャンするには、SlideUtil クラスが提供する [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) 静的メソッドを使用します。このメソッドは 2 つのパラメーターを受け取ります。

1. 最初に、テキストを抽出する対象となるプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) オブジェクト。
1. 次に、プレゼンテーションからテキストをスキャンする際にマスタースライドを含めるかどうかを決定するブール値。

このメソッドは、テキスト書式情報を含む [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) オブジェクトの配列を返します。以下のコードは、マスタースライドを含めてプレゼンテーションのテキストと書式情報をスキャンします。
```java
//PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("demo.pptx");
try {
    //PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得します
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //TextFrame 配列をループします
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //現在の ITextFrame の段落をループします
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //現在の IParagraph の部分をループします
            for (IPortion port : para.getPortions())
            {
                //現在の部分のテキストを表示します
                System.out.println(port.getText());

                //テキストのフォント高さを表示します
                System.out.println(port.getPortionFormat().getFontHeight());

                //テキストのフォント名を表示します
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
Presentation クラスに新しい静的メソッド getPresentationText が追加されました。このメソッドには 3 つのオーバーロードがあります。
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

There is also a [SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText) class which implements the [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) interface.

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**Aspose.Slides はテキスト抽出時に大規模なプレゼンテーションをどの程度高速に処理できますか？**

Aspose.Slides は高性能に最適化されており、[大規模プレゼンテーション](/slides/ja/androidjava/open-presentation/) でも効率的に処理できるため、リアルタイムやバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスし分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

無料体験版の Aspose.Slides でもテキスト抽出は可能ですが、スライド数に制限があるなどの制約があります。制限なく使用し、より大きなプレゼンテーションを処理するには、正規ライセンスの購入が推奨されます。