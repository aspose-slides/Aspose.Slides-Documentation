---
title: Pythonでプレゼンテーションのズームを管理
linktitle: ズーム
type: docs
weight: 60
url: /ja/python-net/manage-zoom/
keywords:
- ズーム
- ズームフレーム
- スライドズーム
- セクションズーム
- サマリーズーム
- ズームを追加
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してズームを作成およびカスタマイズし、セクション間をジャンプし、PPT、PPTX、ODP プレゼンテーション全体にサムネイルやトランジションを追加します。"
---

## **Overview**
PowerPoint のズーム機能を使用すると、プレゼンテーション内の特定のスライド、セクション、またはページの一部へ簡単にジャンプしたり、そこから戻ったりできます。プレゼンテーション中にコンテンツ間を素早く移動できるこの機能は、非常に便利です。

![概要](overview.png)

* プレゼンテーション全体を 1 枚のスライドで要約するには、[Summary Zoom](#Summary-Zoom) を使用します。
* 特定のスライドのみを表示するには、[Slide Zoom](#Slide-Zoom) を使用します。
* 特定のセクションのみを表示するには、[Section Zoom](#Section-Zoom) を使用します。

## **Slide Zoom**

スライドズームを使用すると、プレゼンテーションをよりダイナミックにし、任意の順序でスライド間を中断せずに自由に移動できます。スライドズームは、セクションが少ない短めのプレゼンテーションに最適ですが、さまざまなシナリオでも活用できます。

スライドズームは、単一のキャンバス上にいるかのように、複数の情報にドリルダウンできるようにします。

![slidezoomsel](slidezoomsel.png)

スライドズームオブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) 列挙型、[IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) インターフェイス、および [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) インターフェイス内のいくつかのメソッドを提供します。

### **Creating Zoom Frames**
スライドにズームフレームを追加する手順は次のとおりです。

1.	`Presentation` クラスのインスタンスを作成します。
2.	リンク先となる新しいスライドを作成します。 
3.	作成したスライドに識別用テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	変更したプレゼンテーションを PPTX ファイルとして保存します。

このサンプルコードは、スライドにズームフレームを作成する方法を示しています。
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #2番目のスライドの背景を作成
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #2番目のスライドのテキストボックスを作成
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #3番目のスライドの背景を作成
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #3番目のスライドのテキストボックスを作成
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrameオブジェクトを追加
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #プレゼンテーションを保存
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **Creating Zoom Frames with Custom Images**
Aspose.Slides for Python via .NET を使用すると、スライドプレビュー画像以外の画像でズームフレームを作成できます。手順は次のとおりです。 
1.	`Presentation` クラスのインスタンスを作成します。
2.	リンク先となる新しいスライドを作成します。 
3.	作成したスライドに識別用テキストと背景を追加します。
4.	`Presentation` オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) オブジェクトを作成してフレームを埋めます。
5.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
6.	変更したプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、別の画像でズームフレームを作成する方法を示しています。
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #2番目のスライドの背景を作成
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #3番目のスライドのテキストボックスを作成
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #ズームオブジェクト用の新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #ZoomFrameオブジェクトを追加
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    #プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatting Zoom Frames**
前述の項目では、シンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、フレームの書式設定を変更する必要があります。ズームフレームに適用できる書式設定は複数あります。

スライド上のズームフレームの書式設定は次の手順で行います。

1.	`Presentation` クラスのインスタンスを作成します。
2.	リンク先となる新しいスライドを作成します。
3.	作成したスライドに識別用テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	`Presentation` オブジェクトに関連付けられた Images コレクションに画像を追加し、[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) オブジェクトを作成します。
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。
8.	2 番目のズームフレームオブジェクトの画像から背景を削除します。
5.	変更したプレゼンテーションを PPTX ファイルとして保存します。

この Python サンプルコードは、ズームフレームの書式設定を変更する方法を示しています。 
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #2番目のスライドの背景を作成
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #2番目のスライドのテキストボックスを作成
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #3番目のスライドの背景を作成
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #3番目のスライドのテキストボックスを作成
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrameオブジェクトを追加
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #ズームオブジェクト用の新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    #zoomFrame1オブジェクトにカスタム画像を設定
    zoomFrame1.image = image

    #zoomFrame2オブジェクトのズームフレーム書式を設定
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    #zoomFrame2オブジェクトの背景を表示しない
    zoomFrame2.show_background = False

    #プレゼンテーションを保存
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **Section Zoom**

セクションズームは、プレゼンテーション内の特定のセクションへのリンクです。強調したいセクションに戻ったり、プレゼンテーションの各部分がどのように結びつくかを示したりするのに使用できます。

![seczoomsel](seczoomsel.png)

セクションズームオブジェクトについては、Aspose.Slides が [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) インターフェイス内のいくつかのメソッドを提供します。

### **Creating Section Zoom Frames**

スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。 
3.	作成したスライドに識別用背景を追加します。
4.	リンク先となる新しいセクションを作成します。 
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	変更したプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、スライド上にズームフレームを作成する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # 新しいセクションをプレゼンテーションに追加
    pres.sections.add_section("Section 1", slide)

    # SectionZoomFrameオブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Creating Section Zoom Frames with Custom Images**

Aspose.Slides for Python を使用すると、別のスライドプレビュー画像でセクションズームフレームを作成できます。手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	リンク先となる新しいセクションを作成します。 
5.	`Presentation` オブジェクトに関連付けられた Images コレクションに画像を追加し、`IPPImage` オブジェクトを作成してフレームを埋めます。
6.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
7.	変更したプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、別の画像でセクションズームフレームを作成する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    #プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("Section 1", slide)

    #ズームオブジェクト用の新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #SectionZoomFrameオブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    #プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatting Section Zoom Frames**

より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。セクションズームフレームに適用できる書式設定はいくつかあります。

スライド上でセクションズームフレームの書式設定を行う手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	リンク先となる新しいセクションを作成します。 
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。
7.	`Presentation` オブジェクトに関連付けられた Images コレクションに画像を追加し、`IPPImage` オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	「リンクされたセクションから元のスライドに戻る」機能を有効にします。 
10.	セクションズームフレームオブジェクトの画像から背景を削除します。
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	トランジションの継続時間を変更します。
13.	変更したプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、セクションズームフレームの書式設定を変更する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # 新しいセクションをプレゼンテーションに追加
    pres.sections.add_section("Section 1", slide)

    # SectionZoomFrame オブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # SectionZoomFrame の書式設定
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Summary Zoom**

サマリーズームは、プレゼンテーションの全体像を一度に表示するランディングページのようなものです。プレゼンテーション中に、任意の順序で任意の場所へジャンプしたり、スキップしたり、再訪したりできます。

![overview_image](summaryzoom.png)

サマリーズームオブジェクトについては、Aspose.Slides が [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/)、および [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) インターフェイスと、[IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) インターフェイス内のいくつかのメソッドを提供します。

### **Creating Summary Zoom**

スライドにサマリーズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを設定します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	変更したプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、スライド上にサマリーズームフレームを作成する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # スライド配列を作成
    for slideNumber in range(5):
        # プレゼンテーションに新しいスライドを追加
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # スライドの背景を作成
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # スライドのテキストボックスを作成
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # 最初のスライドに対してすべてのスライドのズームオブジェクトを作成
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # ReturnToParent プロパティを設定して最初のスライドに戻る
        zoomFrame.return_to_parent = True

    # プレゼンテーションを保存
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **Adding and Removing Summary Zoom Section**

サマリーズームフレーム内のすべてのセクションは [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) オブジェクトとして表現され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) オブジェクトに格納されます。セクションの追加や削除は、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) インターフェイスを介して次の手順で行えます。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを設定します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	プレゼンテーションに新しいスライドとセクションを追加します。
5.	作成したセクションをサマリーズームフレームに追加します。
6.	サマリーズームフレームから最初のセクションを削除します。
7.	変更したプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、サマリーズームフレーム内のセクションの追加と削除を行う方法を示しています。
``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("Section 1", slide)

    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("Section 2", slide)

    # SummaryZoomFrame オブジェクトを追加
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # プレゼンテーションに新しいセクションを追加
    section3 = pres.sections.add_section("Section 3", slide)

    # Summary Zoom にセクションを追加
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Summary Zoom からセクションを削除
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Formatting Summary Zoom Sections**

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームの書式設定を変更する必要があります。サマリーズームセクションオブジェクトに適用できる書式設定はいくつかあります。

サマリーズームフレーム内のサマリーズームセクションオブジェクトの書式設定は次の手順で行います。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを設定します。
3.	最初のスライドにサマリーズームフレームを追加します。
4.	`ISummaryZoomSectionCollection` から最初のセクションオブジェクトを取得します。
5.	`Presentation` オブジェクトに関連付けられた Images コレクションに画像を追加し、`IPPImage` オブジェクトを作成します。
6.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
7.	「リンクされたセクションから元のスライドに戻る」機能を有効にします。 
8.	2 番目のズームフレームオブジェクトの線の書式を変更します。
9.	トランジションの継続時間を変更します。
10.	変更したプレゼンテーションを PPTX ファイルとして保存します。

この Python コードは、サマリーズームセクションオブジェクトの書式設定を変更する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("Section 1", slide)

    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("Section 2", slide)

    # SummaryZoomFrame オブジェクトを追加
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # 最初の SummaryZoomSection オブジェクトを取得
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # SummaryZoomSection オブジェクトの書式設定
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

はい。[Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) には `return_to_parent` 動作があり、有効にすると対象コンテンツを表示した後に元のスライドに戻ります。

**Can I adjust the 'speed' or duration of the Zoom transition?**

はい。Zoom では `transition_duration` を設定でき、ジャンプ アニメーションの長さを制御できます。

**Are there limits on how many Zoom objects a presentation can contain?**

明確な API 制限は文書化されていません。実際の制限はプレゼンテーション全体の複雑さや閲覧環境のパフォーマンスに依存します。多数のズームフレームを追加可能ですが、ファイルサイズやレンダリング時間には留意してください。