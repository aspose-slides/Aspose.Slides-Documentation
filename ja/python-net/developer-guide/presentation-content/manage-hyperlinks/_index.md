---
title: Pythonでプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/python-net/manage-hyperlinks/
keywords:
- URLを追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクの削除
- ハイパーリンクの更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーション内のハイパーリンクを手軽に管理し、インタラクティブ性とワークフローを数分で向上させます。"
---

## **概要**

ハイパーリンクは、外部リソースやオブジェクト、データ項目、またはファイル内の特定の場所への参照です。PowerPoint プレゼンテーションで一般的なハイパーリンクの種類は次のとおりです。

* テキスト、図形、またはメディアに埋め込まれた Web サイトへのリンク
* スライドへのリンク

Aspose.Slides for Python via .NET は、プレゼンテーションでハイパーリンクに関連する幅広い操作を可能にします。

## **URLハイパーリンクの追加**

このセクションでは、Aspose.Slides を使用してスライド要素に URL ハイパーリンクを追加する方法を説明します。テキスト、図形、画像にリンク先アドレスを割り当て、プレゼンテーション中のスムーズなナビゲーションを実現します。

### **テキストへのURLハイパーリンクの追加**

以下のコード例は、テキストに Web サイトのハイパーリンクを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **図形またはフレームへのURLハイパーリンクの追加**

以下のコード例は、図形に Web サイトのハイパーリンクを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **メディアへのURLハイパーリンクの追加**

Aspose.Slides では、画像、音声、動画ファイルにもハイパーリンクを追加できます。

以下のコード例は、**画像** にハイパーリンクを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Create a picture frame on slide 1 using the image added earlier.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

以下のコード例は、**音声ファイル** にハイパーリンクを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

以下のコード例は、**動画** にハイパーリンクを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}

[Manage OLE in Presentations Using Python](/slides/ja/python-net/manage-ole/) もご覧ください。

{{% /alert %}}

## **ハイパーリンクを使用した目次の作成**

ハイパーリンクはオブジェクトや場所への参照を可能にするため、目次の作成に利用できます。

以下のサンプルコードは、ハイパーリンク付きの目次を作成する方法を示しています。

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
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンクの書式設定**

このセクションでは、Aspose.Slides におけるハイパーリンクの外観を設定する方法を示します。テキスト、図形、画像のハイパーリンクの色やスタイルを一貫させる方法を学びます。

### **ハイパーリンクの色**

[Hyperlink] クラスの [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) プロパティを使用すると、ハイパーリンクの色を設定したり色情報を取得したりできます。この機能は PowerPoint 2019 で導入されたため、以前のバージョンには適用されません。

以下のサンプルは、同一スライドに異なる色のハイパーリンクを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **プレゼンテーションからハイパーリンクを削除する**

このセクションでは、Aspose.Slides を使用してプレゼンテーションからハイパーリンクを削除する方法を説明します。テキスト、図形、画像からリンク対象をクリアし、元のコンテンツと書式を保持したまま削除できます。

### **テキストからハイパーリンクを削除する**

以下のサンプルコードは、スライド上のテキストからハイパーリンクを削除する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **図形またはフレームからハイパーリンクを削除する**

以下のサンプルコードは、スライド上の図形からハイパーリンクを削除する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **可変ハイパーリンク**

[Hyperlink] クラスは可変です。このクラスを使用すると、以下のプロパティの値を変更できます。

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

以下のコードスニペットは、スライドにハイパーリンクを追加し、そのツールチップを編集する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **IHyperlinkQueriesでサポートされているプロパティ**

ハイパーリンクを含むプレゼンテーション、スライド、テキストから [HyperlinkQueries] を取得できます。

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

[HyperlinkQueries] クラスは以下のメソッドをサポートします。

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}

Aspose のシンプルで無料のオンライン [PowerPoint エディター](https://products.aspose.app/slides/editor) もぜひお試しください。

{{% /alert %}}

## **よくある質問**

**スライドだけでなく「セクション」やセクションの最初のスライドへ内部ナビゲーションを作成する方法はありますか？**

PowerPoint のセクションはスライドのグループです。ナビゲーションは技術的には特定のスライドを対象とするため、セクションへ「移動」する場合は通常、その最初のスライドへのリンクを設定します。

**マスタースライド要素にハイパーリンクを付ければ、すべてのスライドで機能しますか？**

はい。マスター スライドおよびレイアウト要素はハイパーリンクをサポートします。これらのリンクは子スライドに反映され、スライドショー中にクリックできます。

**PDF、HTML、画像、またはビデオにエクスポートした際にハイパーリンクは保持されますか？**

[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) および [HTML](/slides/ja/python-net/convert-powerpoint-to-html/) ではハイパーリンクは通常保持されます。画像 [PNG](/slides/ja/python-net/convert-powerpoint-to-png/) やビデオ [MP4](/slides/ja/python-net/convert-powerpoint-to-video/) にエクスポートした場合、ハイパーリンクは保持されません。画像やビデオはラスターフレーム/動画であり、ハイパーリンクをサポートしないためです。