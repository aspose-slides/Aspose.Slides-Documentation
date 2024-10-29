---
title: 自動調整設定の管理
type: docs
weight: 30
url: /ja/python-net/manage-autofit-settings/
keywords: "テキストボックス, 自動調整, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointのテキストボックスの自動調整設定を行います"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPointはテキストボックスに対して**テキストに合わせて図形をサイズ変更**設定を使用します。これにより、テキストボックスは常にその中にテキストが収まるように自動的にサイズが変更されます。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックスのテキストが長くなったり大きくなったりすると、PowerPointは自動的にテキストボックスを拡大し、高さを増やしてより多くのテキストを収めることができます。
* テキストボックスのテキストが短くなったり小さくなったりすると、PowerPointは自動的にテキストボックスを縮小し、高さを減少させて冗長なスペースを排除します。

PowerPointでは、テキストボックスの自動調整動作を制御する4つの重要なパラメータまたはオプションがあります：

* **自動調整しない**
* **オーバーフロー時にテキストを縮小**
* **テキストに合わせて図形をサイズ変更**
* **図形内のテキストを折り返す。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NETでは、プレゼンテーションのテキストボックスの自動調整動作を制御できる、[text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)クラスのいくつかのプロパティに似たオプションを提供しています。

## **テキストに合わせて図形をサイズ変更**

テキストが変更された後に、ボックス内に常に収まるようにしたい場合は、**テキストに合わせて図形をサイズ変更**オプションを使用する必要があります。この設定を指定するには、[autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)プロパティ（[text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)クラスから）を`SHAPE`に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

このPythonコードは、PowerPointプレゼンテーション内でテキストが常にボックスに収まるように指定する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.SHAPE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

テキストが長くなったり大きくなると、テキストボックスは自動的にリサイズされ（高さが増加）、すべてのテキストが収まるようになります。テキストが短くなると、逆の動作が行われます。

## **自動調整しない**

テキストボックスまたは図形がその内容にかかわらず寸法を保持するようにしたい場合は、**自動調整しない**オプションを使用する必要があります。この設定を指定するには、[autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)プロパティ（[text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)クラスから）を`NONE`に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

このPythonコードは、PowerPointプレゼンテーション内でテキストボックスが常にその寸法を保持するように指定する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

テキストがボックスに対して長すぎると、テキストがこぼれ出ます。

## **オーバーフロー時にテキストを縮小**

テキストがボックスに対して長すぎる場合、**オーバーフロー時にテキストを縮小**オプションを使用することで、テキストのサイズと間隔を減少させてボックス内に収めることができます。この設定を指定するには、[autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)プロパティ（[text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)クラスから）を`NORMAL`に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

このPythonコードは、PowerPointプレゼンテーション内でオーバーフロー時にテキストを縮小する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NORMAL

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="情報" color="info" %}}

**オーバーフロー時にテキストを縮小**オプションが使用されると、その設定はテキストがボックスに対して長すぎる場合にのみ適用されます。

{{% /alert %}}

## **テキストを折り返す**

テキストが図形の境界を超えるときに、その図形内でテキストを折り返したい場合は、**図形内のテキストを折り返す**パラメータを使用する必要があります。この設定を指定するには、[wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)クラスから）を`1`に設定します。

このPythonコードは、PowerPointプレゼンテーション内でテキストを折り返す設定を使用する方法を示しています：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE
    textFrameFormat.wrap_text = 1

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

図形に対して`wrap_text`プロパティを`0`に設定すると、図形内のテキストがその幅よりも長くなると、テキストは単一行として図形の境界を超えて延長されます。

{{% /alert %}}