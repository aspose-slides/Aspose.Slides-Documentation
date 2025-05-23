---
title: Python で PowerPoint プレゼンテーションから高度なテキスト抽出を行う
linktitle: テキストを抽出
type: docs
weight: 90
url: /ja/python-net/extract-text-from-presentation/
keywords:
- テキストを抽出
- スライドからテキストを抽出
- プレゼンテーションからテキストを抽出
- PowerPoint からテキストを抽出
- PPT からテキストを抽出
- PPTX からテキストを抽出
- ODP からテキストを抽出
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションからテキストを迅速かつ簡単に抽出する方法を学びましょう。シンプルなステップバイステップ ガイドに従って時間を節約し、アプリケーションでスライドの内容に効率的にアクセスできるようにします。"
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があるのは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドにあるすべての図形からテキストを抽出する必要があります。この記事では、Aspose.Slidesを使用してMicrosoft PowerPoint PPTXプレゼンテーションからテキストを抽出する方法を説明します。テキストは以下の方法で抽出できます：

- [1つのスライドからテキストを抽出する](/slides/ja/python-net/extracting-text-from-the-presentation/)
- [GetAllTextBoxesメソッドを使用してテキストを抽出する](/slides/ja/python-net/extracting-text-from-the-presentation/)
- [分類された迅速なテキスト抽出](/slides/ja/python-net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **スライドからテキストを抽出する**
Aspose.Slides for Python via .NETは、SlideUtilクラスを含むAspose.Slides.Util名前空間を提供しています。このクラスは、プレゼンテーションまたはスライドからテキスト全体を抽出するためのオーバーロードされた静的メソッドをいくつか公開しています。PPTXプレゼンテーションのスライドからテキストを抽出するには、 
SlideUtilクラスによって公開されている[GetAllTextBoxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)オーバーロードされた静的メソッドを使用します。このメソッドは、Slideオブジェクトをパラメーターとして受け取ります。
実行時に、Slideメソッドは、パラメーターとして渡されたスライドから全テキストをスキャンし、TextFrameオブジェクトの配列を返します。これは、テキストに関連付けられたテキストフォーマットも利用可能であることを意味します。以下のコードは、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します：

```py
import aspose.slides as slides

#PPTXファイルを表すPresentationクラスをインスタンス化
with slides.Presentation("pres.pptx") as pptxPresentation:
    # PPTX内のすべてのスライドからITextFrameオブジェクトの配列を取得
    textFramesPPTX = slides.util.SlideUtil.get_all_text_boxes(pptxPresentation.slides[0])
    
    # TextFramesの配列をループする
    for i in range(len(textFramesPPTX)):
	    # 現在のITextFrame内の段落をループする
        for para in textFramesPPTX[i].paragraphs:
            # 現在のIParagraph内の部分をループする
            for port in para.portions:
			    # 現在の部分内のテキストを表示する
                print(port.text)

    			# テキストのフォント高さを表示する
                print(port.portion_format.font_height)

			    # テキストのフォント名を表示する
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **プレゼンテーションからテキストを抽出する**
プレゼンテーション全体からテキストをスキャンするには、 
SlideUtilクラスによって公開されている[GetAllTextFrames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)静的メソッドを使用します。このメソッドは、2つのパラメーターを受け取ります：

1. 最初に、テキストを抽出するPPTXプレゼンテーションを表すPresentationオブジェクト。
2. 次に、プレゼンテーションからテキストをスキャンする際にマスタースライドを含めるかどうかを決定するBoolean値。
   このメソッドは、テキストフォーマット情報を含むTextFrameオブジェクトの配列を返します。以下のコードは、マスタースライドを含むプレゼンテーションからテキストとフォーマット情報をスキャンします。

```py
import aspose.slides as slides

#PPTXファイルを表すPresentationクラスをインスタンス化
with slides.Presentation("pres.pptx") as pptxPresentation:
    # PPTX内のすべてのスライドからITextFrameオブジェクトの配列を取得
    textFramesPPTX = slides.util.SlideUtil.get_all_text_frames(pptxPresentation, True)
    
    # TextFramesの配列をループする
    for i in range(len(textFramesPPTX)):
	    # 現在のITextFrame内の段落をループする
        for para in textFramesPPTX[i].paragraphs:
            # 現在のIParagraph内の部分をループする
            for port in para.portions:
			    # 現在の部分内のテキストを表示する
                print(port.text)

    			# テキストのフォント高さを表示する
                print(port.portion_format.font_height)

			    # テキストのフォント名を表示する
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **分類された迅速なテキスト抽出**
新しい静的メソッドGetPresentationTextがPresentationクラスに追加されました。このメソッドには2つのオーバーロードがあります：

```py
slides.Presentation.get_presentation_text(stream)
slides.Presentation.get_presentation_text(stream, mode)      
```

ExtractionMode列挙型引数は、テキスト結果の出力を整理するモードを示し、次の値に設定できます：
Unarranged - スライド上の位置に関係なく生テキスト
Arranged - テキストはスライド上での順序と同じように配置されます

Unarrangedモードは、速度が重要な場合に使用でき、Arrangedモードよりも速くなります。

PresentationTextは、プレゼンテーションから抽出された生テキストを表します。それは、Aspose.Slides.Util名前空間のslides_textプロパティを含み、このプロパティはSlideTextオブジェクトの配列を返します。各オブジェクトは、対応するスライドのテキストを表します。SlideTextオブジェクトには次のプロパティがあります：

SlideText.text - スライドの図形内のテキスト
SlideText.master_text - このスライドのマスターページ内の図形のテキスト
SlideText.layout_text - このスライドのレイアウトページ内の図形のテキスト
SlideText.notes_text - このスライドのノートページ内の図形のテキスト


新しいAPIは次のように使用できます：

```py
import aspose.slides as slides

text1 = slides.PresentationFactory().get_presentation_text("pres.pptx", slides.TextExtractionArrangingMode.UNARRANGED)
print(text1.slides_text[0].text)
print(text1.slides_text[0].layout_text)
print(text1.slides_text[0].master_text)
print(text1.slides_text[0].notes_text)
```