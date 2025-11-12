---
title: Pythonでプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクを管理する
type: docs
weight: 20
url: /ja/python-net/manage-hyperlinks/
keywords:
- URLを追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクをフォーマット
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- シェイプハイパーリンク
- 画像ハイパーリンク
- ビデオハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを簡単に管理し、数分でインタラクティブ性とワークフローを向上させます。"
---

## **概要**

ハイパーリンクは外部リソース、オブジェクトやデータ項目、またはファイル内の特定の場所への参照です。PowerPoint プレゼンテーションで一般的なハイパーリンクのタイプは次のとおりです。

* テキスト、シェイプ、またはメディアに埋め込まれたウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for Python via .NET は、プレゼンテーション内でさまざまなハイパーリンク操作を実行できるようにします。

## **URLハイパーリンクを追加**

このセクションでは、Aspose.Slides を使用してスライド要素に URL ハイパーリンクを追加する方法を説明します。テキスト、シェイプ、画像にリンク アドレスを割り当て、プレゼンテーション中のスムーズなナビゲーションを実現します。

### **テキストへのURLハイパーリンク追加**

以下のコード例は、テキストにウェブサイトのハイパーリンクを追加する方法を示しています。

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

### **シェイプまたはフレームへのURLハイパーリンク追加**

以下のコード例は、シェイプにウェブサイトのハイパーリンクを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **メディアへのURLハイパーリンク追加**

Aspose.Slides を使用すると、画像、音声、ビデオ ファイルにハイパーリンクを追加できます。

以下のコード例は、**画像** にハイパーリンクを追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # プレゼンテーションに画像を追加します。
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # 先ほど追加した画像を使用してスライド 1 に画像フレームを作成します。
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

以下のコード例は、**ビデオ** にハイパーリンクを追加する方法を示しています。

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
[PythonでプレゼンテーションのOLEを管理する](/slides/ja/python-net/manage-ole/)
{{% /alert %}}

## **ハイパーリンクを使用して目次を作成**

ハイパーリンクはオブジェクトや場所への参照を提供するため、目次の作成に利用できます。

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

## **ハイパーリンクのフォーマット**

このセクションでは、Aspose.Slides におけるハイパーリンクの外観をフォーマットする方法を示します。テキスト、シェイプ、画像に対してカラーやスタイルオプションを制御し、一貫したフォーマットを実現します。

### **ハイパーリンクの色**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) クラスの [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) プロパティを使用すると、ハイパーリンクの色を設定し、色情報を取得できます。この機能は PowerPoint 2019 で導入されたため、以前のバージョンには適用されません。

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

## **プレゼンテーションからハイパーリンクを削除**

このセクションでは、Aspose.Slides を使用してプレゼンテーションからハイパーリンクを削除する方法を説明します。テキスト、シェイプ、画像からリンク先をクリアし、元のコンテンツと書式は保持されます。

### **テキストからハイパーリンクを削除**

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

### **シェイプまたはフレームからハイパーリンクを削除**

以下のサンプルコードは、スライド上のシェイプからハイパーリンクを削除する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **可変ハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) クラスは可変です。このクラスを使用すると、次のプロパティの値を変更できます。

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

以下のコードスニペットは、スライドにハイパーリンクを追加し、ツールチップを編集する方法を示しています。

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

[HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) クラスは次のメソッドをサポートしています。

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Aspose のシンプルで無料のオンライン [PowerPoint editor](https://products.aspose.app/slides/editor) をご覧ください。
{{% /alert %}}

## **よくある質問**

**スライドだけでなく、セクションやセクションの最初のスライドへ内部ナビゲーションを作成するにはどうすればよいですか？**

PowerPoint のセクションはスライドのグループ化です。ナビゲーションは技術的に特定のスライドを対象にするため、セクションへ「移動」するには通常、その最初のスライドへのリンクを設定します。

**マスタースライド要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスタースライドおよびレイアウト要素はハイパーリンクをサポートしています。これらのリンクは子スライドに反映され、スライドショー中にクリック可能です。

**PDF、HTML、画像、ビデオへのエクスポート時にハイパーリンクは保持されますか？**

[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/python-net/convert-powerpoint-to-html/) では、リンクは通常保持されます。[画像](/slides/ja/python-net/convert-powerpoint-to-png/) と [ビデオ](/slides/ja/python-net/convert-powerpoint-to-video/) へのエクスポートでは、ラスターフレームやビデオはハイパーリンクをサポートしないため、クリック可能性は失われます。