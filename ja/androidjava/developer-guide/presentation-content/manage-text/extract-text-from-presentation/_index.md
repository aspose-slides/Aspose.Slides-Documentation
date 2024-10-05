---
title: プレゼンテーションからテキストを抽出する
type: docs
weight: 90
url: /androidjava/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドにあるすべての図形からテキストを抽出する必要があります。この記事では、Aspose.Slidesを使用してMicrosoft PowerPoint PPTXプレゼンテーションからテキストを抽出する方法を説明します。

{{% /alert %}} 
## **スライドからテキストを抽出する**
Aspose.Slides for Android via Javaは、[SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil)クラスを提供します。このクラスは、プレゼンテーションまたはスライドから全テキストを抽出するためのいくつかのオーバーロードされた静的メソッドを公開しています。PPTXプレゼンテーションのスライドからテキストを抽出するには、[SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil)クラスによって公開されたオーバーロードされた静的メソッド[getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-)を使用します。このメソッドは、スライドオブジェクトをパラメーターとして受け取ります。実行時に、Slideメソッドは、パラメーターとして渡されたスライドから全テキストをスキャンし、[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)オブジェクトの配列を返します。これは、テキストに関連したすべてのテキストフォーマットが利用可能であることを意味します。以下のコードは、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します：

```java
//PPTXファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //PPTX内のすべてのスライドからITextFrameオブジェクトの配列を取得
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //TextFramesの配列をループ
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //現在のITextFrame内の段落をループ
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //現在のIParagraph内の部分をループ
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
全体のプレゼンテーションからテキストをスキャンするには、SlideUtilクラスによって公開された静的メソッド[getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-)を使用します。これは2つのパラメーターを受け取ります：

1. 最初に、テキストが抽出されるプレゼンテーションを表す[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged)オブジェクト。
1. 次に、プレゼンテーションからテキストをスキャンする際にマスター スライドを含めるかどうかを決定するブール値。
   このメソッドは、テキストフォーマット情報を含む[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)オブジェクトの配列を返します。以下のコードは、マスター スライドを含むプレゼンテーションからのテキストとフォーマット情報をスキャンします。

```java
//PPTXファイルを表すプレゼンテーションクラスをインスタンス化
Presentation pres = new Presentation("demo.pptx");
try {
    //PPTX内のすべてのスライドからITextFrameオブジェクトの配列を取得
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //TextFramesの配列をループ
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //現在のITextFrame内の段落をループ
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //現在のIParagraph内の部分をループ
            for (IPortion port : para.getPortions())
            {
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
} finally {
    pres.dispose();
}
```

## **カテゴリ別で高速なテキスト抽出**
Presentationクラスに新しい静的メソッドgetPresentationTextが追加されました。このメソッドには3つのオーバーロードがあります：

```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

[TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode)列挙型の引数は、テキスト結果の出力を整理するモードを示し、次の値に設定できます：
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - スライド上の位置を考慮しない生のテキスト
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - スライド上と同じ順序で配置されたテキスト

**Unarranged**モードは、速度が重要な場合に使用できます。これはArrangedモードよりも速くなります。

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText)は、プレゼンテーションから抽出された生のテキストを表します。これは、[getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--)メソッドを含み、このメソッドは[ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText)オブジェクトの配列を返します。各オブジェクトは、対応するスライド上のテキストを表します。[ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText)オブジェクトには、次のメソッドがあります：

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - スライドの図形上のテキスト
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - このスライドのマスターページの図形上のテキスト
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - このスライドのレイアウトページの図形上のテキスト
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - このスライドのノートページの図形上のテキスト

[SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText)クラスもあり、これは[ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText)インターフェースを実装しています。

新しいAPIは次のように使用できます：

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```