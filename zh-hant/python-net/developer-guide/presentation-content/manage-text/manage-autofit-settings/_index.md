---
title: 使用 Python 的 AutoFit 提升簡報品質
linktitle: AutoFit 設定
type: docs
weight: 30
url: /zh-hant/python-net/manage-autofit-settings/
keywords:
  - 文字方塊
  - 自動調整
  - 不自動調整
  - 適合文字
  - 縮小文字
  - 換行文字
  - 調整形狀大小
  - PowerPoint
  - 簡報
  - Python
  - Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中管理 AutoFit 設定，以最佳化 PowerPoint 與 OpenDocument 簡報中的文字顯示，提升內容可讀性。"
---
## **簡介**

預設情況下，當您新增文字方塊時，Microsoft PowerPoint 會使用 **Resize shape to fix text** 設定──它會自動調整文字方塊的大小，以確保文字始終能完全容納在其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 當文字方塊中的文字變長或變大時，PowerPoint 會自動放大文字方塊（增加高度），以容納更多文字。  
* 當文字方塊中的文字變短或變小時，PowerPoint 會自動縮小文字方塊（減少高度），以清除多餘的空間。  

在 PowerPoint 中，以下是控制文字方塊自動調整行為的四個重要參數或選項：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET 提供了類似的選項——[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 類別中的某些屬性——讓您能在簡報中控制文字方塊的自動調整行為。

## **調整形狀以符合文字**

如果您希望盒子內的文字在變更後始終能貼合盒子，必須使用 **Resize shape to fix text** 選項。要指定此設定，只需將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 類別的 [autofit_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 屬性設為 `SHAPE`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 Python 程式碼示範了如何指定文字必須始終貼合其盒子於 PowerPoint 簡報中：

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

如果文字變長或變大，文字方塊會自動調整大小（高度增加），以確保全部文字都能容納其中。若文字變短，則會反向調整。

## **不要自動調整**

如果您希望文字方塊或形狀無論文字如何變更都保持其尺寸，必須使用 **Do not Autofit** 選項。要指定此設定，只需將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 類別的 [autofit_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 屬性設為 `NONE`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 Python 程式碼示範了如何指定文字方塊在 PowerPoint 簡報中始終保持其尺寸：

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

當文字超出盒子範圍時，會溢出。

## **文字溢出時縮小**

如果文字過長而無法容納於盒子中，透過 **Shrink text on overflow** 選項，您可以指定縮小文字的大小與間距，使其適合盒子。要指定此設定，只需將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 類別的 [autofit_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 屬性設為 `NORMAL`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 Python 程式碼示範了如何在 PowerPoint 簡報中指定文字在溢出時縮小：

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
使用 **Shrink text on overflow** 選項時，僅當文字過長而無法容納於盒子時才會套用此設定。
{{% /alert %}}

## **文字換行**

如果您希望形狀內的文字在超出形狀邊界（僅寬度）時自動換行，必須使用 **Wrap text in shape** 參數。要指定此設定，只需將 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 類別的 [wrap_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/) 屬性設為 `NullableBool.TRUE`。

以下 Python 程式碼示範了如何在 PowerPoint 簡報中使用換行文字設定：

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
如果對形狀將 `wrap_text` 屬性設為 `NullableBool.FALSE`，當形狀內的文字長度超過形狀寬度時，文字會在單行上延伸超出形狀邊界。 
{{% /alert %}}

## **常見問題**

**文字框的內部邊距會影響 AutoFit 嗎？**  
是。內部間距（邊距）會減少文字可用的區域，因此 AutoFit 會較早啟動——會更早縮小字型或調整形狀大小。在調整 AutoFit 前，請先檢查並調整邊距。

**AutoFit 如何與手動及軟換行符互動？**  
強制換行會保留原樣，AutoFit 會依此調整字型大小與間距。移除不必要的換行通常能降低 AutoFit 必須縮小文字的程度。

**變更佈景主題字型或觸發字型替換會影響 AutoFit 結果嗎？**  
會。替換為字型度量不同的字型會改變文字的寬度/高度，進而影響最終字型大小與換行。進行任何字型變更或替換後，請重新檢查投影片。