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
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- シェイプハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーション内のハイパーリンクを手軽に管理し、数分でインタラクティブ性とワークフローを向上させましょう。"
---

## **概要**

ハイパーリンクは外部リソース、オブジェクトまたはデータ項目、またはファイル内の特定の位置への参照です。PowerPoint のプレゼンテーションで一般的なハイパーリンクの種類は次のとおりです：

* テキスト、シェイプ、またはメディアに埋め込まれたウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for Python via .NET はプレゼンテーション内で幅広いハイパーリンク関連操作を可能にします。

## **URL ハイパーリンクの追加**

このセクションでは、Aspose.Slides を使用してスライド要素に URL ハイパーリンクを追加する方法を説明します。テキスト、シェイプ、画像にリンク先アドレスを割り当て、プレゼンテーション中のスムーズなナビゲーションを実現します。

### **テキストへの URL ハイパーリンクの追加**

以下のコード例は、テキストにウェブサイトハイパーリンクを追加する方法を示しています：

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

### **シェイプまたはフレームへの URL ハイパーリンクの追加**

以下のコード例は、シェイプにウェブサイトハイパーリンクを追加する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **メディアへの URL ハイパーリンクの追加**

Aspose.Slides では、画像、音声、動画ファイルにハイパーリンクを追加できます。

以下のコード例は、**画像**にハイパーリンクを追加する方法を示しています：

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

以下のコード例は、**音声ファイル**にハイパーリンクを追加する方法を示しています：

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

以下のコード例は、**動画**にハイパーリンクを追加する方法を示しています：

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

{{% alert title="ヒント" color="primary" %}}
以下をご覧になりたいかもしれません: [Python を使用したプレゼンテーションの OLE 管理](/slides/ja/python-net/manage-ole/)。
{{% /alert %}}

## **ハイパーリンクを使用した目次の作成**

ハイパーリンクはオブジェクトや位置への参照を可能にするため、目次を構築する際に活用できます。

以下のサンプルコードは、ハイパーリンクを使用した目次の作成方法を示しています：

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

このセクションでは、Aspose.Slides におけるハイパーリンクの外観の書式設定方法を示します。テキスト、シェイプ、画像間でハイパーリンクの書式設定を一貫させるために、色やその他のスタイルオプションを制御する方法を学びます。

### **ハイパーリンクの色**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) クラスの [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) プロパティを使用すると、ハイパーリンクの色を設定したり、色情報を取得したりできます。この機能は PowerPoint 2019 で導入されたため、従来のバージョンには適用されません。

以下のサンプルは、同じスライドに異なる色のハイパーリンクを追加する方法を示しています：

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

このセクションでは、Aspose.Slides を使用してプレゼンテーションからハイパーリンクを削除する方法を説明します。テキスト、シェイプ、画像のリンク先をクリアし、元のコンテンツと書式設定を保持します。

### **テキストからハイパーリンクを削除する**

以下のサンプルコードは、プレゼンテーションのスライド上のテキストからハイパーリンクを削除する方法を示しています：

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

### **シェイプまたはフレームからハイパーリンクを削除する**

以下のサンプルコードは、プレゼンテーションのスライド上のシェイプからハイパーリンクを削除する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **可変ハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) クラスは可変です。このクラスを使用すると、以下のプロパティの値を変更できます：

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

以下のコードスニペットは、スライドにハイパーリンクを追加し、そのツールチップを編集する方法を示しています：

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

## **IHyperlinkQueries のサポートされているプロパティ**

プレゼンテーション、スライド、またはハイパーリンクを含むテキストから [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) にアクセスできます。

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

[HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) クラスは次のメソッドをサポートしています：

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Aspose のシンプルで無料のオンライン [PowerPoint エディター] をぜひご利用ください。
{{% /alert %}}

## **FAQ**

**スライドだけでなく「セクション」やセクションの最初のスライドへ内部ナビゲーションを作成するにはどうすればよいですか？**

PowerPoint のセクションはスライドのグループ化です。ナビゲーションは実際には特定のスライドを対象とするため、セクションへ「移動」したい場合は通常、その最初のスライドへリンクします。

**マスタースライドの要素にハイパーリンクを添付すれば、すべてのスライドで機能しますか？**

はい。マスタースライドおよびレイアウト要素はハイパーリンクをサポートしており、子スライド上でもクリック可能になります。

**ハイパーリンクは PDF、HTML、画像、動画へのエクスポート時に保持されますか？**

[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/python-net/convert-powerpoint-to-html/) では、通常リンクが保持されます。画像や動画へのエクスポート（[画像](/slides/ja/python-net/convert-powerpoint-to-png/) や [動画](/slides/ja/python-net/convert-powerpoint-to-video/)）では、ラスターフレームや動画がハイパーリンクをサポートしないため、クリック可能性は維持されません。