---
title: 使用 Python 管理簡報中的 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/python-java/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 管理 ActiveX
- 新增 ActiveX
- 修改 ActiveX
- 媒體播放器
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何使用 ActiveX 來自動化並增強 PowerPoint 簡報，為開發人員提供對投影片的強大控制。"
---
## **簡介**

ActiveX 控制項在簡報中使用。Aspose.Slides for Python via Java 允許您新增與管理 ActiveX 控制項，但相較於一般簡報圖形，其管理方式稍微複雜。Aspose.Slides 支援新增 Media Player ActiveX 控制項。請注意，ActiveX 控制項並非圖形；它們不屬於簡報的[ShapeCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/)。它們屬於獨立的[ControlCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/controlcollection/)。本主題將示範如何使用它們。

## **將 Media Player ActiveX 控制項新增至投影片**

若要新增 ActiveX Media Player 控制項，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例，產生空白簡報。
1. 在 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 中存取目標投影片。
1. 使用由 [ControlCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/controlcollection/) 提供的 [addControl](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/controlcollection/#addControl) 方法新增 Media Player ActiveX 控制項。
1. 取得 Media Player ActiveX 控制項並透過其屬性設定影片路徑。
1. 將簡報另存為 PPTX 檔案。

以下範例程式碼依上述步驟示範如何將 Media Player ActiveX 控制項新增至投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# 建立一個空白簡報。
presentation = Presentation()
try:
    # 新增 Media Player ActiveX 控制項。
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # 設定影片路徑。
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # 儲存簡報。
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **修改 ActiveX 控制項**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java 提供管理 ActiveX 控制項的元件。您可以存取簡報中已新增的 ActiveX 控制項，並透過其屬性進行修改或刪除。

{{% /alert %}}

若要在投影片上管理簡單的 ActiveX 控制項（如文字方塊與簡易指令按鈕），請執行以下動作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例，載入含有 ActiveX 控制項的簡報。
1. 依索引取得投影片參考。
1. 透過存取 [ControlCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/controlcollection/) 取得投影片上的 ActiveX 控制項。
1. 使用 [Control](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/control/) 物件取得 TextBox1 ActiveX 控制項。
1. 更改 TextBox1 ActiveX 控制項的屬性，包括文字、字型、字型高度與框架位置。
1. 取得第二個名為 CommandButton1 的 ActiveX 控制項。
1. 更改按鈕的標題、字型與位置。
1. 調整 ActiveX 控制項框架的位置。
1. 將修改後的簡報寫入 PPTM 檔案。

以下範例程式碼依上述步驟示範如何管理簡單的 ActiveX 控制項：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# 載入包含 ActiveX 控制項的簡報。
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # 存取第一張投影片。
        slide = presentation.getSlides().get_Item(0)

        # 變更文字方塊的文字。
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # 變更替代圖像。PowerPoint 在 ActiveX 啟用期間會取代它，
            # 因此有時可以保持不變。
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # 變更按鈕的標題。
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # 變更替代圖像。
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # 將控制項向下移動 100 點。
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # 移除控制項。
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **常見問題**

**Aspose.Slides 在讀取並重新儲存時，若 ActiveX 控制項無法在 Python 執行階段執行，是否仍會保留它們？**

是的。Aspose.Slides 將它們視為簡報的一部分，能讀取/修改其屬性與框架；不需要執行控制項本身即能保留。

**ActiveX 控制項與簡報中的 OLE 物件有何不同？**

ActiveX 控制項是互動式受管理的控制項（按鈕、文字方塊、媒體播放器），而 [OLE](/slides/zh-hant/python-java/manage-ole/) 指的是嵌入的應用程式物件（例如 Excel 工作表）。它們的儲存與處理方式不同，且具有不同的屬性模型。

**如果檔案已由 Aspose.Slides 修改，ActiveX 事件與 VBA 巨集是否仍會運作？**

Aspose.Slides 會保留現有的標記與中繼資料；然而，事件與巨集只能在 Windows 上的 PowerPoint 中執行，且需符合安全設定。此函式庫不會執行 VBA。