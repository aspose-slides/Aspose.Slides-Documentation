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
description: "了解 Aspose.Slides for Python via .NET 如何利用 ActiveX 自動化並強化 PowerPoint 簡報，為開發人員提供對投影片的強大控制功能。"
---
## **簡介**

ActiveX 控制項在簡報中使用。Aspose.Slides for Python via .NET 允許您管理 ActiveX 控制項，但其管理方式較為複雜，且不同於一般簡報圖形。自 Aspose.Slides for Python via .NET 6.9.0 版起，該元件支援管理 ActiveX 控制項。目前，您可以存取簡報中已加入的 ActiveX 控制項，並透過其各種屬性進行修改或刪除。請記住，ActiveX 控制項不是圖形，亦不屬於簡報的 IShapeCollection，而是屬於獨立的 IControlCollection。本篇文章將說明如何使用它們。

## **修改 ActiveX 控制項**
要管理投影片上如文字方塊和簡易指令按鈕等單純的 ActiveX 控制項：

1. 建立 Presentation 類別的實例，並載入其中包含 ActiveX 控制項的簡報。
2. 根據索引取得投影片的參考。
3. 透過存取 IControlCollection 來取得投影片中的 ActiveX 控制項。
4. 使用 ControlEx 物件存取 TextBox1 ActiveX 控制項。
5. 變更 TextBox1 ActiveX 控制項的各種屬性，包括文字、字型、字型大小以及框架位置。
6. 存取名為 CommandButton1 的第二個控制項。
7. 變更按鈕的標題、字型與位置。
8. 調整 ActiveX 控制項框架的位置。
9. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼片段會更新簡報投影片上的 ActiveX 控制項，如下所示。

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# 存取包含 ActiveX 控制項的簡報
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # 存取簡報中的第一張投影片
    slide = presentation.slides[0]

    # 變更文字方塊文字
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # 變更替代圖片。PowerPoint 會在 ActiveX 啟動時取代此圖片，所以有時可以保留圖片不變。

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # 變更按鈕標題
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # 變更替代圖片
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # 將 ActiveX 框架向下移動 100 點
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # 儲存已編輯 ActiveX 控制項的簡報
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # 現在移除控制項
    slide.controls.clear()

    # 儲存已清除 ActiveX 控制項的簡報
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **新增 ActiveX 媒體播放器控制項**
若要新增 ActiveX 媒體播放器控制項，請執行以下步驟：

1. 建立 Presentation 類別的實例，並載入其中包含 Media Player ActiveX 控制項的範例簡報。
2. 建立目標 Presentation 類別的實例，並產生空白簡報。
3. 將範本簡報中包含 Media Player ActiveX 控制項的投影片複製至目標 Presentation。
4. 在目標 Presentation 中存取已複製的投影片。
5. 透過存取 IControlCollection 來取得投影片中的 ActiveX 控制項。
6. 取得 Media Player ActiveX 控制項，並使用其屬性設定影片路徑。
7. 將簡報儲存為 PPTX 檔案。

```py
import aspose.slides as slides

# 實例化代表 PPTX 檔案的 Presentation 類別
with slides.Presentation(path + "template.pptx") as presentation:

    # 建立空白的簡報實例
    with slides.Presentation() as newPresentation:

        # 移除預設投影片
        newPresentation.slides.remove_at(0)

        # 複製包含 Media Player ActiveX 控制項的投影片
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # 存取 Media Player ActiveX 控制項並設定影片路徑
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # 儲存簡報
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**當在 Python 執行環境無法執行時，Aspose.Slides 讀取並重新儲存時會保留 ActiveX 控制項嗎？**  
會。Aspose.Slides 將它們視為簡報的一部分，能夠讀取和修改其屬性與框架；不需要執行控制項本身即可保留它們。

**ActiveX 控制項與簡報中的 OLE 物件有何不同？**  
ActiveX 控制項是互動式的受管理控制項（按鈕、文字方塊、媒體播放器），而 [OLE](/slides/zh-hant/python-net/manage-ole/) 則指嵌入的應用程式物件（例如 Excel 工作表）。它們的儲存與處理方式不同，且具有不同的屬性模型。

**如果檔案已由 Aspose.Slides 修改，ActiveX 事件與 VBA 巨集仍會運作嗎？**  
Aspose.Slides 會保留既有的標記與中繼資料；然而，事件與巨集僅在 Windows 上的 PowerPoint 並且安全性允許時才會執行。此函式庫不會執行 VBA。