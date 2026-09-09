---
title: 使用 Python 的 AutoFit 強化您的簡報
linktitle: AutoFit 設定
type: docs
weight: 30
url: /zh-hant/python-java/manage-autofit-settings/
keywords:
- 文字方塊
- 自動調整
- 不自動調整
- 適合文字
- 縮小文字
- 文字換行
- 調整形狀大小
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中管理 AutoFit 設定，以優化 PowerPoint 與 OpenDocument 簡報中的文字顯示，提升內容可讀性。"
---
## **簡介**

預設情況下，當您新增文字方塊時，Microsoft PowerPoint 會使用 **Resize shape to fit text** 設定 — 它會自動調整文字方塊的大小，以確保文字始終適合其中。

![PowerPoint 中的文字方塊](textbox-in-powerpoint.png)

* 當文字方塊中的文字變長或變大時，PowerPoint 會自動放大文字方塊—增加其高度—以容納更多文字。
* 當文字方塊中的文字變短或變小時，PowerPoint 會自動縮小文字方塊—減少其高度—以移除多餘的空間。

在 PowerPoint 中，以下四個重要參數或選項會控制文字方塊的自動調整行為：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint 自動調整選項](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java 提供類似的選項——[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別下的某些屬性——允許您在簡報中控制文字方塊的自動調整行為。

## **調整形狀以符合文字**

如果您希望文字方塊中的文字在變更後始終能適合該方塊，必須使用 **Resize shape to fit text** 選項。要指定此設定，請使用 [setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 方法（來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別），並傳入 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textautofittype/#Shape)。

![PowerPoint 永久適合設定](alwaysfit-setting-powerpoint.png)

以下 Python 程式碼示範如何在 PowerPoint 簡報中指定文字必須始終適合其方塊：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果文字變長或變大，文字方塊會自動調整大小（高度增高），以確保所有文字都能適合其中。若文字變短，則會相反。

## **不自動調整**

如果您希望文字方塊或形狀在文字變更時保持其尺寸不變，必須使用 **Do not Autofit** 選項。要指定此設定，請使用 [setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 方法（來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別），並傳入 [None](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textautofittype/#None)。

![PowerPoint 不自動調整設定](donotautofit-setting-powerpoint.png)

以下 Python 程式碼示範如何在 PowerPoint 簡報中指定文字方塊必須始終保持其尺寸：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

當文字過長而超出方塊時，會溢出。

## **文字過長時縮小**

如果文字過長而無法容納於方塊內，您可以使用 **Shrink text on overflow** 選項，指定必須縮小文字的大小和間距以使其適合方塊。要設定此選項，請使用 [setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 方法（來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別），並傳入 [Normal](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textautofittype/#Normal)。

![PowerPoint 文字溢出時縮小設定](shrinktextonoverflow-setting-powerpoint.png)

以下 Python 程式碼示範如何在 PowerPoint 簡報中指定文字在溢出時縮小：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
使用 **Shrink text on overflow** 選項時，僅在文字過長而超出方塊時才會套用此設定。
{{% /alert %}}

## **文字自動換行**

如果您希望形狀內的文字在超出形狀邊框（僅寬度）時自動換行，必須使用 **Wrap text in shape** 參數。要指定此設定，需使用 [setWrapText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setWrapText) 方法（來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別），並傳入 [NullableBool.True_](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/#True)。

以下 Python 程式碼示範如何在 PowerPoint 簡報中使用換行文字設定：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
如果對形狀使用 [setWrapText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setWrapText) 方法並傳入 [NullableBool.False](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/#False)，當形狀內的文字長度超過形狀寬度時，文字會以單行延伸至形狀邊框之外。
{{% /alert %}}

## **常見問答**

**文字框的內部邊距會影響 AutoFit 嗎？**

是。內部邊距（Padding）會減少文字可用的區域，導致 AutoFit 更早啟動——更快縮小字型或調整形狀大小。在微調 AutoFit 之前，請先檢查並調整邊距。

**AutoFit 如何與手動和軟換行互動？**

強制換行會保留原樣，AutoFit 會依據它們調整字型大小與間距。移除不必要的換行通常可減少 AutoFit 必須縮小文字的力度。

**變更主題字型或觸發字型替換會影響 AutoFit 結果嗎？**

會。使用不同字形度量的字型替換會改變文字的寬高，從而影響最終的字型大小與換行。任何字型變更或替換後，請重新檢查投影片。