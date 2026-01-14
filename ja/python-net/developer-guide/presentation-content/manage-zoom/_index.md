---
title: Pythonでプレゼンテーションのズームを管理する
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
- ズームの追加
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用してズームを作成およびカスタマイズします — セクション間をジャンプし、PPT、PPTX、ODP プレゼンテーション全体にサムネイルやトランジションを追加します。"
---

## **概要**
PowerPoint のズーム機能を使用すると、プレゼンテーション内の特定のスライド、セクション、および部分にジャンプしたり、そこから戻ったりできます。プレゼンテーション中に、コンテンツを素早くナビゲートできるこの機能は非常に便利です。

![概要](overview.png)

* プレゼンテーション全体を 1 枚のスライドに要約するには、[Summary Zoom](#Summary-Zoom) を使用します。
* 選択したスライドのみを表示するには、[Slide Zoom](#Slide-Zoom) を使用します。
* 単一のセクションのみを表示するには、[Section Zoom](#Section-Zoom) を使用します。

## **スライドズーム**

スライドズームを使用すると、プレゼンテーションの流れを中断せずに任意の順序でスライド間を自由に移動でき、プレゼンテーションがよりダイナミックになります。スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなシナリオでも利用できます。

スライドズームは、単一のキャンバス上にいるような感覚で複数の情報にドリルダウンできるようにします。

![slidezoomsel](slidezoomsel.png)

スライドズームオブジェクトについては、Aspose.Slides が [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) 列挙型、[ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) クラス、および [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) クラスのいくつかのメソッドを提供します。

### **ズームフレームの作成**
スライドにズームフレームを追加する手順は次のとおりです。

1.	`Presentation` クラスのインスタンスを作成します。
2.	リンク先となる新しいスライドを作成します。 
3.	作成したスライドに識別テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

このサンプルコードは、スライドにズームフレームを作成する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 2番目のスライドの背景を作成
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 2番目のスライド用テキストボックスを作成
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # 3番目のスライドの背景を作成
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # 3番目のスライド用テキストボックスを作成
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrameオブジェクトを追加
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # プレゼンテーションを保存
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **カスタム画像付きズームフレームの作成**
Aspose.Slides for Python via .NET を使用すると、スライドプレビュー画像以外の画像でズームフレームを作成できます。手順は次のとおりです。

1.	`Presentation` クラスのインスタンスを作成します。
2.	リンク先となる新しいスライドを作成します。 
3.	作成したスライドに識別テキストと背景を追加します。
4.	`Presentation` オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを作成します。
5.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
6.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

この Python コードは、画像を変更したズームフレームを作成する方法を示しています。
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 2番目のスライドの背景を作成
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 3番目のスライド用テキストボックスを作成
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # ズームオブジェクト用の新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #ZoomFrameオブジェクトを追加
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **ズームフレームの書式設定**
前述のセクションでは、シンプルなズームフレームの作成方法を示しました。より複雑なズームフレームを作成するには、フレームの書式設定を変更する必要があります。ズームフレームに適用できる書式設定は複数あります。

スライド上のズームフレームの書式設定を行う手順は次のとおりです。

1.	`Presentation` クラスのインスタンスを作成します。
2.	リンク先となる新しいスライドを作成します。
3.	作成したスライドに識別テキストと背景を追加します。
4.	最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5.	`Presentation` オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを作成します。
6.	最初のズームフレームオブジェクトにカスタム画像を設定します。
7.	2 番目のズームフレームオブジェクトの線の書式を変更します。
8.	2 番目のズームフレームオブジェクトの画像から背景を除去します。
5.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

この Python サンプルコードは、ズームフレームの書式設定を変更する方法を示しています。
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # 2番目のスライドの背景を作成
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # 2番目のスライド用テキストボックスを作成
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # 3番目のスライドの背景を作成
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # 3番目のスライド用テキストボックスを作成
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrameオブジェクトを追加
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # ズームオブジェクト用の新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # zoomFrame1オブジェクトにカスタム画像を設定
    zoomFrame1.image = image

    # zoomFrame2オブジェクトのズームフレーム書式を設定
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # zoomFrame2オブジェクトの背景を表示しない
    zoomFrame2.show_background = False

    # プレゼンテーションを保存
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **セクションズーム**

セクションズームは、プレゼンテーション内のセクションへのリンクです。セクションズームを使用して、強調したいセクションに戻ったり、プレゼンテーションの特定の部分同士のつながりをハイライトしたりできます。

![seczoomsel](seczoomsel.png)

セクションズームオブジェクトについては、Aspose.Slides が [SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) クラスと [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) クラスのいくつかのメソッドを提供します。

### **セクションズームフレームの作成**

スライドにセクションズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。 
3.	作成したスライドに識別用背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。 
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

この Python コードは、スライドにズームフレームを作成する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("Section 1", slide)

    # SectionZoomFrameオブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **カスタム画像付きセクションズームフレームの作成**

Aspose.Slides for Python を使用すると、異なるスライドプレビュー画像でセクションズームフレームを作成できます。手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。 
5.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを作成します。
6.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
7.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

この Python コードは、画像を変更したズームフレームを作成する方法を示しています。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("Section 1", slide)

    # ズームオブジェクト用の新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # SectionZoomFrameオブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **セクションズームフレームの書式設定**

より複雑なセクションズームフレームを作成するには、シンプルなフレームの書式設定を変更する必要があります。セクションズームフレームに適用できる書式設定は複数あります。

スライド上のセクションズームフレームの書式設定を行う手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	新しいスライドを作成します。
3.	作成したスライドに識別用背景を追加します。
4.	ズームフレームをリンクする新しいセクションを作成します。 
5.	最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6.	作成したセクションズームオブジェクトのサイズと位置を変更します。
7.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトに関連付けられた Images コレクションに画像を追加して、フレームの塗りつぶしに使用する [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを作成します。
8.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
9.	*リンクされたセクションから元のスライドに戻る* 動作を設定します。 
10.	セクションズームフレームオブジェクトの画像から背景を除去します。
11.	2 番目のズームフレームオブジェクトの線の書式を変更します。
12.	遷移時間を変更します。
13.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

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

    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("Section 1", slide)

    # SectionZoomFrameオブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # SectionZoomFrameの書式設定
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


## **要約ズーム**

要約ズームは、プレゼンテーションの全体像を 1 ページにまとめたランディングページのようなものです。プレゼンテーション中に、要約ズームを使って任意の順序でスライド間を移動したり、スキップしたり、再訪したりできます。プレゼンテーションの流れを中断せずに創造的に操作できます。

![summaryzoom.png](summaryzoom.png)

要約ズームオブジェクトについては、Aspose.Slides が [SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/)、[SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/)、および [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) クラスと、[ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) クラスのいくつかのメソッドを提供します。

### **要約ズームの作成**

スライドに要約ズームフレームを追加する手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを設定して新規スライドを作成します。
3.	最初のスライドに要約ズームフレームを追加します。
4.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

この Python コードは、スライドに要約ズームフレームを作成する方法を示しています。
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

        # スライド用テキストボックスを作成
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # 最初のスライドのすべてのスライドに対してズームオブジェクトを作成
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # ReturnToParent プロパティを設定して最初のスライドに戻るようにする
        zoomFrame.return_to_parent = True

    # プレゼンテーションを保存
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **要約ズームセクションの追加と削除**

要約ズームフレーム内のすべてのセクションは [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/) オブジェクトで表され、[SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) オブジェクトに格納されます。要約ズームセクションオブジェクトは、[SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) クラスを使用して追加または削除できます。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを設定して新規スライドを作成します。
3.	最初のスライドに要約ズームフレームを追加します。
4.	プレゼンテーションに新しいスライドとセクションを追加します。
5.	作成したセクションを要約ズームフレームに追加します。
6.	要約ズームフレームから最初のセクションを削除します。
7.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

この Python コードは、要約ズームフレームでセクションを追加および削除する方法を示しています。
```python
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

    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adds a new section to the presentation
    pres.sections.add_section("Section 2", slide)

    # Adds SummaryZoomFrame object
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adds a new section to the presentation
    section3 = pres.sections.add_section("Section 3", slide)

    # Adds a section to the Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Removes section from the Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Saves the presentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **要約ズームセクションの書式設定**

より複雑な要約ズームセクションオブジェクトを作成するには、シンプルなフレームの書式設定を変更する必要があります。要約ズームセクションオブジェクトに適用できる書式設定は複数あります。

要約ズームフレーム内の要約ズームセクションオブジェクトの書式設定を行う手順は次のとおりです。

1.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2.	作成したスライドに識別用背景と新しいセクションを設定して新規スライドを作成します。
3.	最初のスライドに要約ズームフレームを追加します。
4.	`SummaryZoomSectionCollection` から最初のオブジェクトの要約ズームセクションを取得します。
5.	[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトに関連付けられた images コレクションに画像を追加して、フレームの塗りつぶしに使用する `PPImage` オブジェクトを作成します。
6.	作成したセクションズームフレームオブジェクトにカスタム画像を設定します。
7.	*リンクされたセクションから元のスライドに戻る* 動作を設定します。 
8.	2 番目のズームフレームオブジェクトの線の書式を変更します。
9.	遷移時間を変更します。
10.	修正したプレゼンテーションを書き出して PPTX ファイルに保存します。

この Python コードは、要約ズームセクションオブジェクトの書式設定を変更する方法を示しています。
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

    # SummaryZoomFrameオブジェクトを追加
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

**対象を表示した後に「親」スライドに戻る操作を制御できますか？**

はい。[Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) または [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) には `return_to_parent` 動作があり、有効にすると対象コンテンツを閲覧した後に元のスライドに戻ります。

**ズームの遷移「速度」や期間を調整できますか？**

はい。Zoom では `transition_duration` を設定でき、ジャンプアニメーションの長さを制御できます。

**プレゼンテーションに含められる Zoom オブジェクトの数に制限はありますか？**

ドキュメント上の厳密な API 制限はありません。実際の制限はプレゼンテーション全体の複雑さやビューアーのパフォーマンスに依存します。多数のズームフレームを追加できますが、ファイルサイズや描画時間を考慮してください。