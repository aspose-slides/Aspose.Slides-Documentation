---
title: 使用 Python 管理簡報中的佔位符
linktitle: 管理佔位符
type: docs
weight: 10
url: /zh-hant/python-net/manage-placeholder/
keywords:
- 佔位符
- 文字佔位符
- 圖片佔位符
- 圖表佔位符
- 提示文字
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "輕鬆透過 .NET 在 Aspose.Slides for Python 中管理佔位符：取代文字、客製化提示，並在 PowerPoint 與 OpenDocument 中設定圖片透明度。"
---
## **概覽**

Aspose.Slides 允許您以程式方式管理簡報中的佔位符。本篇說明如何在投影片上找到佔位符並變更其文字、在佔位符版面配置中設定自訂提示文字，以及調整用作佔位符背景的圖片透明度。文中亦包含簡短的 FAQ，說明基礎佔位符與投影片本地形狀的差異、如何透過版面配置或母片套用佔位符變更，並指向標頭與頁腳佔位符的管理方式。

## **變更佔位符文字**

使用 Aspose.Slides for Python，您可以在簡報的投影片上尋找並修改佔位符。Aspose.Slides 允許您修改佔位符中的文字。

**前提條件：** 您需要一個包含佔位符的簡報。您可以在 Microsoft PowerPoint 中建立此類簡報。

以下示範如何使用 Aspose.Slides 取代佔位符中的文字：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別，並將簡報作為參數傳入。
2. 依索引取得投影片的參考。
3. 迭代形狀以尋找佔位符。
4. 使用與 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 相關聯的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 變更文字。
5. 儲存已修改的簡報。

```python
import aspose.slides as slides

# 實例化 Presentation 類別。
with slides.Presentation("ReplacingText.pptx") as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 迭代形狀以尋找佔位符。
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # 更改每個佔位符中的文字。
            shape.text_frame.text = "This is Placeholder"

    # 將簡報儲存至磁碟。
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定佔位符的提示文字**

標準與預建版面配置會包含像是 **Click to add a title** 或 **Click to add a subtitle** 的佔位符提示文字。使用 Aspose.Slides，您可以在佔位符版面配置中將這些提示換成自訂文字。

以下 Python 範例說明如何為佔位符設定提示文字：

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # 迭代形狀以尋找佔位符。
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **設定佔位符中的圖片透明度**

Aspose.Slides 讓您能夠設定文字佔位符背景圖片的透明度。透過調整該框架中圖片的透明度，您可以根據顏色使文字或圖片更為突出。

以下 Python 範例說明如何在形狀內設定圖片背景的透明度：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **常見問題**

**什麼是基礎佔位符，它與投影片上的本地形狀有何不同？**

基礎佔位符是版面配置或母片上原始的形狀，投影片的形狀會從它繼承類型、位置以及部分格式。本地形狀則是獨立的；如果沒有基礎佔位符，則不會套用繼承。

**如何在不逐一遍歷每張投影片的情況下，更新簡報中所有標題或說明文字？**

編輯版面配置或母片上的相應佔位符。基於這些版面配置／母片的投影片會自動繼承變更。

**如何控制標準的標頭/頁腳佔位符——日期與時間、投影片編號與頁腳文字？**

使用對應範圍（一般投影片、版面配置、母片、備註/講義）的 HeaderFooter 管理員，開啟或關閉這些佔位符，並設定其內容。