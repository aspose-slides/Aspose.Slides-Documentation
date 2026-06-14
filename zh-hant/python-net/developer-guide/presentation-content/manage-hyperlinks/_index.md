---
title: 使用 Python 管理簡報中的超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/python-net/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 影像超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- Python
description: "使用 Aspose.Slides for Python via .NET，輕鬆在 PowerPoint 與 OpenDocument 簡報中管理超連結，幾分鐘內提升互動性與工作流程。"
---
## **簡介**

超連結是指向外部資源、物件或資料項目，或檔案內特定位置的參照。PowerPoint 簡報中常見的超連結類型包括：

* 內嵌於文字、圖形或媒體中的網站連結
* 連結至投影片

Aspose.Slides for Python via .NET 可在簡報中執行各種與超連結相關的操作。

## **新增 URL 超連結**

本節說明在使用 Aspose.Slides 時，如何將 URL 超連結加入投影片元素。包括將連結位址指派給文字、圖形與圖片，確保簡報播放時的順暢導覽。

### **將 URL 超連結加入文字**

以下程式碼範例示範如何將網站超連結加入文字：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **將 URL 超連結加入圖形或框格**

以下程式碼範例示範如何將網站超連結加入圖形：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **將 URL 超連結加入媒體**

Aspose.Slides 允許您為影像、音訊與影片檔案加入超連結。

以下程式碼範例示範如何為**影像**加入超連結：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 將圖像新增至簡報。
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # 在投影片 1 上使用先前加入的圖像建立圖片框架。
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

以下程式碼範例示範如何為**音訊檔案**加入超連結：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

以下程式碼範例示範如何為**影片**加入超連結：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
您可能想參考[管理使用 Python 的簡報中的 OLE](/slides/zh-hant/python-net/manage-ole/)。
{{% /alert %}}

## **使用超連結建立目錄**

由於超連結可參照物件或位置，您可以利用它們建立目錄。

以下範例程式碼示範如何用超連結建立目錄：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **格式化超連結**

本節說明如何在 Aspose.Slides 中格式化超連結的外觀。您將學會控制顏色與其他樣式選項，以在文字、圖形與圖片中保持超連結格式的一致性。

### **超連結顏色**

使用 [Hyperlink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/) 類別的 [color_source](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/color_source/) 屬性，您可以設定超連結的顏色並讀取顏色資訊。此功能於 PowerPoint 2019 引入，透過此屬性所做的變更不會套用至較早版本的 PowerPoint。

以下範例示範如何在同一投影片上加入不同顏色的超連結：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **從簡報中移除超連結**

本節說明在使用 Aspose.Slides 時，如何從簡報中移除超連結。您將學會在保留原始內容與格式的同時，清除文字、圖形與圖片的連結目標。

### **從文字中移除超連結**

以下範例程式碼示範如何從投影片文字中移除超連結：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **從圖形或框格中移除超連結**

以下範例程式碼示範如何從投影片圖形中移除超連結：

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **可變超連結**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/) 類別是可變的。使用此類別，您可以變更以下屬性之值：

- [target_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

以下程式碼片段示範如何為投影片新增超連結，然後編輯其工具提示文字：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **IHyperlinkQueries 支援的屬性**

您可以從簡報、投影片或包含超連結的文字框取得 [HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/)。

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/hyperlink_queries/)

[HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/) 類別支援以下方法：

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
您可能想試用 Aspose 提供的簡易、免費線上[PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor)。
{{% /alert %}}

## **常見問題**

**如何建立不僅指向投影片，而是指向「章節」或章節的第一張投影片的內部導覽？**

PowerPoint 的章節是投影片的分組；導覽實際上會指向特定投影片。若要「導覽至章節」，通常會連結到該章節的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上皆可使用嗎？**

可以。母片與版面配置元素支援超連結。此類連結會在子投影片上顯示，且在投影播放時可點擊。

**將簡報匯出為 PDF、HTML、影像或影片時，超連結會被保留嗎？**

在[PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)與[HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)中會保留連結。匯出為[影像](/slides/zh-hant/python-net/convert-powerpoint-to-png/)與[影片](/slides/zh-hant/python-net/convert-powerpoint-to-video/)時，因為這些格式為點陣影格或影片，無法保留超連結的點擊功能。