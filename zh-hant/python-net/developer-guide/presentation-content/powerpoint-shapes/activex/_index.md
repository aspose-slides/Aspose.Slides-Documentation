---
title: 使用 Python 在簡報中管理 ActiveX 控制項
linktitle: ActiveX
type: docs
weight: 80
url: /zh-hant/python-net/activex/
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
description: "編輯 ActiveX 文字方塊和按鈕、更新控制項預覽，並在 PowerPoint 簡報中重新使用 Windows Media Player 控制項，使用 Aspose.Slides for Python via .NET。"
---
## **簡介**

ActiveX 控制項為 PowerPoint 投影片提供文字方塊、指令按鈕和媒體播放器等互動元素。Aspose.Slides for Python via .NET 透過 [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/) 讓您取得投影片的控制項集合。使用此集合可編輯控制項、在投影片上移動它，或將其移除。

## **列出 ActiveX 控制項及其儲存屬性**

要檢查不熟悉的範本，請以讀取模式開啟並遍歷每張投影片上的控制項。此範例會報告投影片編號、控制項名稱、[class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/)，以及 [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) 中的每個鍵值對。它會在不啟動控制項、觸發事件或巨集、變更值或儲存檔案的情況下讀取簡報。

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

從 `ActiveX.pptm` 中選取的輸出顯示了一個文字方塊和一個指令按鈕。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的屬性集合會顯示為 `[]`。對於使用二進位儲存的控制項，`properties` 可能回傳 `None`，顯示為 `Properties unavailable`。如果只需要屬性名稱，請在檢查 `None` 後使用 [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/)。報告列出簡報中可用的屬性。控制項在執行時可能支援其他屬性。

## **修改 ActiveX 控制項**

此範例假設在第一張投影片上有一個名為 `TextBox1` 的文字方塊以及一個名為 `CommandButton1` 的指令按鈕，且簡報為支援巨集的格式。它使用 [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) 變更文字方塊的值和按鈕的標題。每個控制項都有 PowerPoint 在啟動前可以顯示的靜態預覽。請提供顯示更新後文字與外觀的 PNG 圖檔給每個控制項。此範例透過 [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/) 指定這些圖像。

此範例透過變更其 [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/)，將第一張投影片上的所有控制項向下移動 100 點。它會以 PPTM 格式儲存編輯後的簡報，然後使用 [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) 儲存第二個副本，該副本會將該投影片上的所有 ActiveX 控制項移除。

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **新增 ActiveX 媒體播放器控制項**

若要重複使用已配置的 Windows Media Player 控制項，請從第一張投影片包含名為 `WindowsMediaPlayer1` 的播放器的範本開始。[SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) 會將整張投影片複製到新簡報中。此範例在其 [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) 中設定播放器的 `URL`，並將複製的投影片儲存為輸出唯一的投影片。影片保持外部檔案，因此請選擇播放期間播放器可存取的路徑。

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**Aspose.Slides 能否在不執行的情況下保留 ActiveX 控制項？**

可以。Aspose.Slides 能在不啟動控制項的情況下讀取並儲存控制項，包括它們的屬性和位置。

**ActiveX 控制項與 OLE 物件有何不同？**

ActiveX 控制項讓使用者與投影片互動，例如輸入文字或點擊按鈕。 [OLE 物件](/slides/zh-hant/python-net/manage-ole/) 允許投影片包含或鏈結至由其他應用程式管理的內容，如 Excel 工作表。

**在使用 Aspose.Slides 儲存簡報後，ActiveX 事件仍會觸發 VBA 巨集嗎？**

請將簡報儲存為支援巨集的格式（例如 PPTM），以保留其 VBA 專案。當 Windows 版 PowerPoint 的安全性設定允許 ActiveX 控制項與巨集時，便會執行現有的事件處理常式。