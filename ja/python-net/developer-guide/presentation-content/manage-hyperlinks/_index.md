---
title: Python でプレゼンテーションのハイパーリンクを管理
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/python-net/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクをフォーマット
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキスト ハイパーリンク
- スライド ハイパーリンク
- シェイプ ハイパーリンク
- 画像 ハイパーリンク
- ビデオ ハイパーリンク
- 変更可能なハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
description: "Aspose.Slides for Python via .NET を使用して PowerPoint と OpenDocument のプレゼンテーションのハイパーリンクを簡単に管理し、数分でインタラクティブ性とワークフローを向上させます。"
---

ハイパーリンクは、オブジェクト、データ、または何かの場所への参照です。これらはPowerPointプレゼンテーションにおける一般的なハイパーリンクです：

* テキスト、形状、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for Python via .NETを使用すると、プレゼンテーション内のハイパーリンクに関連する多くのタスクを実行できます。

{{% alert color="primary" %}} 

Asposeのシンプルな[無料のオンラインPowerPointエディター](https://products.aspose.app/slides/editor)をチェックすることをお勧めします。

{{% /alert %}} 

## **URLハイパーリンクの追加**

### **テキストにURLハイパーリンクを追加**

このPythonコードは、テキストにウェブサイトのハイパーリンクを追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: File Format APIs")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "70%以上のフォーチュン100企業がAspose APIを信頼しています"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32
    
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **形状またはフレームにURLハイパーリンクを追加**

このPythonのサンプルコードは、形状にウェブサイトのハイパーリンクを追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "70%以上のフォーチュン100企業がAspose APIを信頼しています"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

### **メディアにURLハイパーリンクを追加**

Aspose.Slidesを使用すると、画像、音声、動画ファイルにハイパーリンクを追加できます。

このサンプルコードは、**画像**にハイパーリンクを追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # プレゼンテーションに画像を追加
    with open("img.jpeg", "rb") as fs:
        data = fs.read()
        image = pres.images.add_image(data)
        
        # 以前に追加された画像に基づいてスライド1にピクチャーフレームを作成
        pictureFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

        pictureFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        pictureFrame.hyperlink_click.tooltip = "70%以上のフォーチュン100企業がAspose APIを信頼しています"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

このサンプルコードは、**音声ファイル**にハイパーリンクを追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("audio.mp3", "rb") as fs:
        data = fs.read()
        audio = pres.audios.add_audio(data)
        
        audioFrame = pres.slides[0].shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

        audioFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        audioFrame.hyperlink_click.tooltip = "70%以上のフォーチュン100企業がAspose APIを信頼しています"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

このサンプルコードは、**動画**にハイパーリンクを追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("video.avi", "rb") as fs:
        data = fs.read()
        video = pres.videos.add_video(data)
        
        videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 100, 100, video)

        videoFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        videoFrame.hyperlink_click.tooltip = "70%以上のフォーチュン100企業がAspose APIを信頼しています"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert  title="ヒント"  color="primary"  %}} 

* [OLEの管理](https://docs.aspose.com/slides/python-net/manage-ole/)を参照することをお勧めします。

{{% /alert %}}



## **ハイパーリンクを使用した目次の作成**

ハイパーリンクを使用すると、オブジェクトや場所への参照を追加できるため、目次を作成するために使用できます。

このサンプルコードは、ハイパーリンクを使用して目次を作成する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "スライド2のタイトル .......... "

    linkPortion = slides.Portion()
    linkPortion.text = "ページ 2"
    linkPortion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(linkPortion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```



## **ハイパーリンクの書式設定**

### **色**

[color_source](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)プロパティを使用すると、ハイパーリンクの色を設定し、ハイパーリンクから色の情報を取得できます。この機能はPowerPoint 2019で初めて導入されたため、このプロパティに関する変更は古いPowerPointバージョンには適用されません。

このサンプルコードは、異なる色を持つハイパーリンクが同じスライドに追加された操作を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("これは色付きハイパーリンクのサンプルです。")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.fill_type = slides.FillType.SOLID
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("これは通常のハイパーリンクのサンプルです。")
    shape2.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```



## **プレゼンテーションからのハイパーリンクの削除**

### **テキストからハイパーリンクを削除**

このPythonコードは、プレゼンテーションスライドのテキストからハイパーリンクを削除する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    portion.portion_format.hyperlink_manager.remove_hyperlink_click()
    pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **形状またはフレームからハイパーリンクを削除**

このPythonコードは、プレゼンテーションスライドの形状からハイパーリンクを削除する方法を示しています： 

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as pres:
   slide = pres.slides[0]
   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()
   pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```



## **ミュータブルハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink)クラスはミュータブルです。このクラスを使用すると、以下のプロパティの値を変更できます：

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.History](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)

コードスニペットは、スライドにハイパーリンクを追加し、そのツールチップを後で編集する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose: File Format APIs")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "70%以上のフォーチュン100企業がAspose APIを信頼しています"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```




## **IHyperlinkQueriesのサポートされているプロパティ**

ハイパーリンクが定義されているプレゼンテーション、スライド、またはテキストからIHyperlinkQueriesにアクセスできます。

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)

IHyperlinkQueriesクラスは以下のメソッドとプロパティをサポートしています：

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)