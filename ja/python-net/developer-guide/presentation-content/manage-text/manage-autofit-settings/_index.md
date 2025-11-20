---
title: Python で AutoFit を使用してプレゼンテーションを強化する
linktitle: AutoFit 設定
type: docs
weight: 30
url: /ja/python-net/manage-autofit-settings/
keywords:
- テキストボックス
- オートフィット
- オートフィットしない
- テキストに合わせる
- テキストを縮小
- テキストの折り返し
- シェイプのリサイズ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET で AutoFit 設定を管理し、PowerPoint および OpenDocument プレゼンテーションのテキスト表示を最適化して、コンテンツの可読性を向上させる方法を学びます。"
---

デフォルトでは、テキストボックスを追加すると Microsoft PowerPoint はテキストボックスに対して **Resize shape to fix text** 設定を使用します。テキストが常に収まるように、テキストボックスのサイズが自動的に調整されます。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長く大きくなると、PowerPoint はテキストボックスの高さを増やして自動的に拡大し、より多くのテキストを保持できるようにします。  
* テキストボックス内のテキストが短く小さくなると、PowerPoint はテキストボックスの高さを減らして自動的に縮小し、余分なスペースを除去します。

PowerPoint では、テキストボックスの自動調整動作を制御する重要なパラメータまたはオプションが 4 つあります。

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET は、[TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) クラスのいくつかのプロパティとして、プレゼンテーション内のテキストボックスの自動調整動作を制御する同様のオプションを提供します。

## **Resize Shapes to Fit Text**

テキストが変更された後も常に箱に収まるようにしたい場合は、**Resize shape to fix text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) クラスの `autofit_type` プロパティを `SHAPE` に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

この Python コードは、PowerPoint プレゼンテーションでテキストが常に箱に収まるように指定する方法を示しています:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


テキストが長く大きくなると、テキストボックスは自動的に高さが増えてサイズが変更され、すべてのテキストが収まります。テキストが短くなると、逆の処理が行われます。

## **Do Not Autofit**

テキストの変更に関係なくテキストボックスまたはシェイプのサイズを保持したい場合は、**Do not Autofit** オプションを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) クラスの `autofit_type` プロパティを `NONE` に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

この Python コードは、PowerPoint プレゼンテーションでテキストボックスが常にサイズを保持するように指定する方法を示しています:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


テキストが箱に対して長すぎる場合、テキストははみ出します。

## **Shrink Text on Overflow**

テキストが箱に対して長すぎる場合、**Shrink text on overflow** オプションを使用して、テキストのサイズと間隔を縮小し、箱に収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) クラスの `autofit_type` プロパティを `NORMAL` に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

この Python コードは、PowerPoint プレゼンテーションでテキストがオーバーフローしたときに縮小されるように指定する方法を示しています:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
**Shrink text on overflow** オプションが使用された場合、テキストが箱に対して長くなったときだけ設定が適用されます。
{{% /alert %}}

## **Wrap Text**

テキストがシェイプの幅を超えたときに、シェイプ内でテキストが折り返されるようにしたい場合は、**Wrap text in shape** パラメータを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) クラスの `wrap_text` プロパティを `NullableBool.TRUE` に設定します。

この Python コードは、PowerPoint プレゼンテーションで Wrap Text 設定を使用する方法を示しています:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}}
シェイプの `wrap_text` プロパティを `NullableBool.FALSE` に設定すると、シェイプ内のテキストがシェイプの幅を超えたときに、テキストは 1 行のままシェイプの外側に延びます。
{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**

はい。パディング（内部余白）はテキストの使用可能領域を減少させるため、AutoFit が早めに作動し、フォントが縮小されたりシェイプがリサイズされたりします。AutoFit を調整する前に余白を確認し、必要に応じて調整してください。

**How does AutoFit interact with manual and soft line breaks?**

強制改行はそのまま残り、AutoFit はそれらの周囲でフォントサイズや間隔を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する度合いが緩和されることが多いです。

**Does changing the theme font or triggering font substitution affect AutoFit results?**

はい。異なる字形メトリクスを持つフォントに置き換えると、テキストの幅や高さが変わり、最終的なフォントサイズや行折り返しに影響します。フォント変更や置換を行った後は、スライドを再確認してください。