---
title: 使用 Python 在簡報中管理 ActiveX 控制項
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
description: "編輯 ActiveX 文字方塊與按鈕、更新控制項預覽，並在 PowerPoint 簡報中使用 Aspose.Slides for Python via Java 重複使用 Windows Media Player 控制項。"
---
## **簡介**

ActiveX 控制項為 PowerPoint 投影片提供互動元素，例如文字方塊、指令按鈕和媒體播放器。Aspose.Slides for Python via Java 透過 [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) 讓您存取投影片的控制項。使用此集合可編輯控制項、在投影片上移動或移除它。

## **列出 ActiveX 控制項及其儲存的屬性**

若要檢查不熟悉的樣本檔，請以唯讀模式開啟並遍歷每張投影片上的控制項。範例會報告投影片編號、控制項名稱、[getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId)，以及 [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) 中的每個鍵值對。它會在不啟動控制項、觸發事件或巨集、改變值或儲存檔案的情況下讀取簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

從 `ActiveX.pptm` 的選取輸出顯示了一個文字方塊和一個指令按鈕。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的屬性集合會顯示為 `[]`。對於使用二進位儲存的控制項，[getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) 可能會傳回 `None`，顯示為 `Properties unavailable`。如果只需要名稱，可在確認集合可用後使用 [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties)。報告列出簡報中可用的屬性。控制項在執行時可能支援其他屬性。

## **修改 ActiveX 控制項**

此範例假設第一張投影片上有一個名為 `TextBox1` 的文字方塊以及一個名為 `CommandButton1` 的指令按鈕，且簡報為啟用巨集的格式。它使用[控制項屬性集合](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/)來變更文字方塊的值與按鈕的標題。每個控制項亦有 PowerPoint 在啟動前可顯示的靜態預覽。為每個控制項提供顯示更新文字與外觀的 PNG。範例透過 [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) 指派這些影像。

此範例透過使用 [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame) 將第一張投影片上所有控制項的框架向下移動 100 點。它以 PPTM 格式儲存編輯後的簡報，然後使用 [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) 產生第二個副本，將該投影片上的所有 ActiveX 控制項全部移除。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **新增 ActiveX 媒體播放器控制項**

若要重複使用已設定好的 Windows Media Player 控制項，請以第一張投影片包含名為 `WindowsMediaPlayer1` 的播放器的樣本檔為起點。[SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) 將整張投影片複製到新簡報。範例在其[屬性集合](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) 中設定播放器的 `URL`，並將複製的投影片儲存為輸出唯一的投影片。影片仍維持外部檔案，因此請選擇播放器在播放時可存取的路徑。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **常見問題**

**Aspose.Slides 能在不執行的情況下保留 ActiveX 控制項嗎？**

可以。Aspose.Slides 能在不啟動控制項的情況下讀取並儲存控制項，包括其屬性與位置。

**ActiveX 控制項與 OLE 物件有何不同？**

ActiveX 控制項允許使用者與投影片互動，例如輸入文字或點擊按鈕。 [OLE 物件](/slides/zh-hant/python-java/manage-ole/) 則讓投影片可包含或連結至由其他應用程式管理的內容，例如 Excel 工作表。

**在使用 Aspose.Slides 儲存簡報後，ActiveX 事件仍會觸發 VBA 巨集嗎？**

請將簡報儲存為支援巨集的格式（例如 PPTM）以保留其 VBA 專案。當 Windows 版 PowerPoint 的安全性設定允許 ActiveX 控制項與巨集時，便會執行現有的事件處理常式。