---
title: 使用 Python 的 AutoFit 提升簡報效果
linktitle: AutoFit 設定
type: docs
weight: 30
url: /zh-hant/python-java/manage-autofit-settings/
keywords:
- 文字方塊
- AutoFit
- 不要 AutoFit
- 適應文字
- 縮小文字
- 文字換行
- 調整形狀大小
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "學習如何在 Aspose.Slides for Python via Java 中管理 AutoFit 設定，以優化 PowerPoint 與 OpenDocument 簡報中的文字顯示，提升內容可讀性。"
---
## **簡介**

預設情況下，當您新增文字方塊時，Microsoft PowerPoint 會對該文字方塊使用 **Resize shape to fix text** 設定——它會自動調整文字方塊的大小，以確保文字始終能完整容納。 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 當文字方塊中的文字變長或變大時，PowerPoint 會自動放大文字方塊—增加其高度—以容納更多文字。 
* 當文字方塊中的文字變短或變小時，PowerPoint 會自動縮小文字方塊—減少其高度—以清除多餘的空間。 

在 PowerPoint，以下是控制文字方塊自動調整行為的四個重要參數或選項：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java 提供了類似的選項—[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別中的某些屬性—讓您能控制簡報中文字方塊的自動調整行為。 

## **將形狀調整為符合文字大小**

如果您希望方塊中的文字在變更後仍能始終適合該方塊，必須使用 **Resize shape to fix text** 選項。要設定此項，請使用 [setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 方法（來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別），並傳入 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textautofittype/#Shape)。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

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

如果文字變長或變大，文字方塊會自動調整大小（高度增加），以確保所有文字都能容納其中。若文字變短，則會相反。 

## **不自動調整**

如果您希望文字方塊或形狀無論文字內容如何變更，都保持其尺寸，必須使用 **Do not Autofit** 選項。要設定此項，請使用 [setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 方法（來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別），並傳入 [None](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textautofittype/#None)。 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

當文字過長而超出其方塊時，會溢出。 

## **文字溢出時縮小**

如果文字過長而超出方塊，透過 **Shrink text on overflow** 選項，您可以指定將文字的大小與間距縮小，使其適合方塊。要設定此項，請使用 [setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 方法（來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別），並傳入 [Normal](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textautofittype/#Normal)。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 Python 程式碼示範如何在 PowerPoint 簡報中指定文字在溢出時必須縮小：

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
當使用 **Shrink text on overflow** 選項時，僅會在文字過長而超出方塊時套用此設定。 
{{% /alert %}}

## **文字換行**

如果您希望當文字超出形狀邊框（僅寬度）時，文字能在形狀內自動換行，必須使用 **Wrap text in shape** 參數。要設定此項，請使用 [setWrapText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setWrapText) 方法（來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/) 類別），並傳入 [NullableBool.True](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/#True)。 

以下 Python 程式碼示範如何在 PowerPoint 簡報中使用換行文字設定：

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

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
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
如果您對形狀使用 [setWrapText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setWrapText) 方法並傳入 [NullableBool.False](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/#False)，當形狀內的文字長度超過形狀寬度時，文字會沿單行延伸至形狀邊界之外。 
{{% /alert %}}

## **常見問題**

**文字框的內邊距會影響 AutoFit 嗎？**

是的。內部間距（padding）會減少文字可用的區域，因而使 AutoFit 提前啟動—更早縮小字型或調整形狀大小。在調整 AutoFit 前，請先檢查並調整邊距。 

**AutoFit 與手動與軟換行如何互動？**

強制換行會保留，AutoFit 會在其周圍調整字型大小與間距。移除不必要的換行通常能降低 AutoFit 收縮文字的力度。 

**更改主題字型或觸發字型替代會影響 AutoFit 的結果嗎？**

會的。替換為具有不同字形度量的字型會改變文字的寬度/高度，從而影響最終字型大小與換行。任何字型變更或替代後，請重新檢查投影片。