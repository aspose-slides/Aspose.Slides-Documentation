---
title: ズームの管理
type: docs
weight: 60
url: /python-net/manage-zoom/
keywords: "ズーム, ズームフレーム, ズームの追加, ズームフレームのフォーマット, サマリーズーム, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにズームまたはズームフレームを追加する"
---

## **概要**
PowerPointのズームは、特定のスライド、セクション、プレゼンテーションの部分にジャンプすることを可能にします。プレゼンテーション中に、コンテンツを迅速にナビゲートできるこの能力は非常に役立つかもしれません。

![overview](overview.png)

* プレゼンテーション全体を1つのスライドで要約するには、[サマリーズーム](#Summary-Zoom)を使用します。
* 選択されたスライドのみを表示するには、[スライドズーム](#Slide-Zoom)を使用します。
* 単一のセクションのみを表示するには、[セクションズーム](#Section-Zoom)を使用します。

## **スライドズーム**

スライドズームはプレゼンテーションをより動的にし、自由にスライド間をナビゲートすることを可能にします。スライドの流れを中断することなく、選択した任意の順序で移動できます。スライドズームは、セクションが少ない短いプレゼンテーションに最適ですが、さまざまなプレゼンテーションシナリオでも使用できます。

スライドズームは、あたかも1つのキャンバス上にいるかのように、複数の情報を掘り下げるのに役立ちます。

![slidezoomsel](slidezoomsel.png)

スライドズームオブジェクトについて、Aspose.Slidesは[ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/)列挙体、[IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/)インターフェース、および[IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)インターフェースのいくつかのメソッドを提供します。

### **ズームフレームの作成**
次の方法でスライドにズームフレームを追加できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. リンクするスライドを新しく作成します。
3. 作成したスライドに識別テキストと背景を追加します。
4. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このサンプルコードは、スライドにズームフレームを作成する方法を示しています：
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #秒のスライドに背景を作成
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #第二スライドのためのテキストボックスを作成
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第2スライド"

    #第三スライドのための背景を作成
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #第三スライドのためのテキストボックスを作成
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第三スライド"

    #ズームフレームオブジェクトを追加
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #プレゼンテーションを保存
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **カスタム画像を使用したズームフレームの作成**
Aspose.Slides for Python via .NETを使用すると、スライドプレビュー画像とは異なる画像を持つズームフレームをこのように作成できます： 
1. `Presentation`クラスのインスタンスを作成します。
2. リンクする新しいスライドを作成します。 
3. 作成したスライドに識別テキストと背景を追加します。
4. [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)オブジェクトを作成し、プレゼンテーションオブジェクトに関連付けられた画像コレクションに画像を追加して、フレームを満たすために使用します。
5. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、異なる画像を持つズームフレームを作成する方法を示しています：

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #第二スライドのための背景を作成
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #第三スライドのためのテキストボックスを作成
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第2スライド"

    #ズームオブジェクトのために新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #ズームフレームオブジェクトを追加
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    #プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **ズームフレームのフォーマット**
前のセクション（上記）では、シンプルなズームフレームを作成する方法を示しました。より複雑なズームフレームを作成するには、フレームのフォーマットを変更する必要があります。ズームフレームに適用できるいくつかのフォーマット設定があります。

スライド上のズームフレームのフォーマットを次のように制御できます：

1. `Presentation`クラスのインスタンスを作成します。
2. リンクする新しいスライドを作成します。
3. 作成したスライドに識別テキストと背景を追加します。
4. 最初のスライドにズームフレーム（作成したスライドへの参照を含む）を追加します。
5. 画像を追加して、フレームを満たすIPPImageオブジェクトを作成します。
6. 最初のズームフレームオブジェクトのカスタム画像を設定します。
7. 二つ目のズームフレームオブジェクト用にラインフォーマットを変更します。
8. 二つ目のズームフレームオブジェクトの画像の背景を削除します。
5. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonサンプルコードは、ズームフレームのフォーマットを変更する方法を示しています：

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #プレゼンテーションに新しいスライドを追加
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #秒のスライドに背景を作成
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #第二スライドのためのテキストボックスを作成
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第2スライド"

    #第三スライドのための背景を作成
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #第三スライドのためのテキストボックスを作成
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "第三スライド"

    #ズームフレームオブジェクトを追加
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #ズームオブジェクトのために新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    #zoomFrame1オブジェクトのカスタム画像を設定
    zoomFrame1.image = image

    #zoomFrame2オブジェクト用のズームフレーム形式を設定
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    #zoomFrame2オブジェクトの背景を表示しない
    zoomFrame2.show_background = False

    #プレゼンテーションを保存
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **セクションズーム**

セクションズームは、プレゼンテーションのセクションへのリンクです。セクションズームを使用して、本当に強調したいセクションに戻ることができます。また、プレゼンテーションの特定の部分がどのように接続しているかを強調するためにも使用できます。

![seczoomsel](seczoomsel.png)

セクションズームオブジェクトについて、Aspose.Slidesは[ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/)インターフェースおよび[IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)インターフェースの下にいくつかのメソッドを提供します。

### **セクションズームフレームの作成**

次の方法でスライドにセクションズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。 
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクするための新しいセクションを作成します。 
5. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、スライドにズームフレームを作成する方法を示しています：

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
    pres.sections.add_section("セクション 1", slide)

    # セクションズームフレームオブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **カスタム画像を使用したセクションズームフレームの作成**

Aspose.Slides for Pythonを使用すると、異なるスライドプレビュー画像を持つセクションズームフレームをこのように作成できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクするための新しいセクションを作成します。 
5. [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)オブジェクトを作成し、プレゼンテーションオブジェクトに関連付けられた画像コレクションに画像を追加して、フレームを満たすために使用します。
6. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
7. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、異なる画像を持つズームフレームを作成する方法を示しています：

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
    pres.sections.add_section("セクション 1", slide)

    # ズームオブジェクトのために新しい画像を作成
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # セクションズームフレームオブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **セクションズームフレームのフォーマット**

より複雑なセクションズームフレームを作成するには、シンプルなフレームのフォーマットを変更する必要があります。セクションズームフレームに適用できるいくつかのフォーマットオプションがあります。

スライド上のセクションズームフレームのフォーマットを次のように制御できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 新しいスライドを作成します。
3. 作成したスライドに識別背景を追加します。
4. ズームフレームをリンクするための新しいセクションを作成します。 
5. 最初のスライドにセクションズームフレーム（作成したセクションへの参照を含む）を追加します。
6. 作成されたセクションズームオブジェクトのサイズと位置を変更します。
7. [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)オブジェクトを作成し、プレゼンテーションオブジェクトに関連付けられた画像コレクションに画像を追加して、フレームを満たすために使用します。
8. 作成されたセクションズームフレームオブジェクトのカスタム画像を設定します。
9. リンクされたセクションから元のスライドに戻る能力を設定します。 
10. セクションズームフレームオブジェクトの画像の背景を削除します。
11. 二つ目のズームフレームオブジェクト用にラインフォーマットを変更します。
12. トランジションの長さを変更します。
13. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、セクションズームフレームのフォーマットを変更する方法を示しています：

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
    pres.sections.add_section("セクション 1", slide)

    # セクションズームフレームオブジェクトを追加
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # セクションズームフレーム用のフォーマット
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

## **サマリーズーム**

サマリーズームは、プレゼンテーションのすべての要素を一度に表示するようなランディングページのようなものです。プレゼンテーション中は、ズームを使用してプレゼンテーション内の他の場所に移動できます。順不同で進めたり、前に進んだり、スライドショーのいくつかを再訪したりすることができ、プレゼンテーションの流れを中断することなく行えます。

![overview_image](summaryzoom.png)

サマリーズームオブジェクトについて、Aspose.Slidesは[ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/)、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/)、および[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/)インターフェース、さらに[IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)インターフェースの下にいくつかのメソッドを提供します。

### **サマリーズームの作成**

次の方法でスライドにサマリーズームフレームを追加できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 識別背景を持つ新しいスライドと、新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、スライドにサマリーズームフレームを作成する方法を示しています：

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # スライドの配列を作成
    for slideNumber in range(5):
        #プレゼンテーションに新しいスライドを追加
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # スライドの背景を作成
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # スライド用のテキストボックスを作成
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "スライド - {num}".format(num = (slideNumber + 2))

    # 最初のスライドでのすべてのスライドのズームオブジェクトを作成
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # ReturnToParentプロパティを設定して最初のスライドに戻る
        zoomFrame.return_to_parent = True

    # プレゼンテーションを保存
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **サマリーズームセクションの追加と削除**

サマリーズームフレーム内のすべてのセクションは、[ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/)オブジェクトで表され、[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/)オブジェクトに格納されています。[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/)インターフェースを通じてサマリーズームセクションオブジェクトを追加または削除できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 識別背景を持つ新しいスライドと、新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. 新しいスライドとセクションをプレゼンテーションに追加します。
5. 作成したセクションをサマリーズームフレームに追加します。
6. サマリーズームフレームから最初のセクションを削除します。
7. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、サマリーズームフレーム内のセクションを追加および削除する方法を示しています：

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
    pres.sections.add_section("セクション 1", slide)

    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("セクション 2", slide)

    # サマリーズームフレームオブジェクトを追加
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # プレゼンテーションに新しいセクションを追加
    section3 = pres.sections.add_section("セクション 3", slide)

    # サマリーズームにセクションを追加
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # サマリーズームからセクションを削除
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # プレゼンテーションを保存
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **サマリーズームセクションのフォーマット**

より複雑なサマリーズームセクションオブジェクトを作成するには、シンプルなフレームのフォーマットを変更する必要があります。サマリーズームセクションオブジェクトに適用できるいくつかのフォーマットオプションがあります。

サマリーズームフレーム内のサマリーズームセクションオブジェクトのフォーマットを次のように制御できます：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 識別背景を持つ新しいスライドと、新しいセクションを作成します。
3. 最初のスライドにサマリーズームフレームを追加します。
4. `ISummaryZoomSectionCollection`から最初のオブジェクトのサマリーズームセクションオブジェクトを取得します。
5. [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)オブジェクトを作成し、プレゼンテーションオブジェクトに関連付けられた画像コレクションに画像を追加して、フレームを満たすために使用します。
6. 作成されたセクションズームフレームオブジェクトのカスタム画像を設定します。
7. リンクされたセクションから元のスライドに戻る能力を設定します。 
8. 二つ目のズームフレームオブジェクト用にラインフォーマットを変更します。
9. トランジションの長さを変更します。
10. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このPythonコードは、サマリーズームセクションオブジェクトのフォーマットを変更する方法を示しています：

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
    pres.sections.add_section("セクション 1", slide)

    #プレゼンテーションに新しいスライドを追加
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # プレゼンテーションに新しいセクションを追加
    pres.sections.add_section("セクション 2", slide)

    # サマリーズームフレームオブジェクトを追加
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # 最初のサマリーズームセクションオブジェクトを取得
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # サマリーズームセクションオブジェクトのフォーマット
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