---
title: 圖片
type: docs
weight: 50
url: /zh-hant/python-net/examples/elements/picture/
keywords:
- 圖片
- 圖片框
- 新增圖片
- 存取圖片
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中處理圖片：插入、取代、裁切、壓縮、調整透明度與效果、填充形狀，並匯出為 PPT、PPTX 和 ODP。"
---
說明如何使用 **Aspose.Slides for Python via .NET** 從記憶體中的影像插入和存取圖片。以下示例會在記憶體中建立影像，將其放置於投影片上，然後再取得它。

## **加入圖片**
此程式碼從檔案載入影像，並將其作為圖片框插入到第一張投影片上。

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 從檔案載入影像。
        with open("image.png", "rb") as image_stream:
            # 將影像加入簡報資源。
            image = presentation.images.add_image(image_stream)

        # 在第一張投影片上插入顯示影像的圖片框。
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **存取圖片**
此範例確保投影片中包含圖片框，然後存取找到的第一個圖片框。

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # 存取投影片上的第一個圖片框。
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```