---
title: Aspose.Slides for Python via Java 中的多執行緒
linktitle: 多執行緒
type: docs
weight: 310
url: /zh-hant/python-java/multithreading/
keywords:
- 多執行緒
- 多執行緒
- 平行工作
- 轉換投影片
- 投影片轉圖像
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java 多執行緒提升 PowerPoint 與 OpenDocument 處理效能。探索高效簡報工作流程的最佳實踐。"
---
## **簡介**

雖然可以對簡報執行平行作業（解析、載入和複製除外），且通常運作良好，但在多執行緒使用此函式庫時仍有少許產生不正確結果的可能性。

我們強烈建議您 **不要** 在多執行緒環境中使用單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例，因為這可能導致難以偵測的不可預期錯誤或失敗。

在多執行緒中載入、儲存和/或複製 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例 **不是** 安全的。此類操作 **不受支援**。如果需要執行此類工作，必須使用多個單執行緒行程來平行化操作——且每個行程都應使用其自己的簡報實例。

## **平行將簡報投影片轉換為圖像**

假設我們想要平行地將 PowerPoint 簡報的所有投影片轉換為 PNG 影像。由於在多執行緒中使用單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例並不安全，我們將簡報的投影片拆分為多個獨立的簡報，並在各自的執行緒中平行地將投影片轉換為影像。以下程式碼範例示範了如何做到這一點。

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # 將投影片提取為單獨的簡報。
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # 在單獨的工作中將投影片轉換為圖像。
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # 等待所有工作完成。
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **常見問題**

**我需要在每個執行緒中呼叫授權設定嗎？**

不需要。只需在執行緒啟動前於每個行程執行一次即可。如果 [license setup](/slides/zh-hant/python-java/licensing/) 可能同時被呼叫（例如在延遲初始化期間），請同步該呼叫，因為授權設定方法本身不是執行緒安全的。

**我可以在執行緒之間傳遞 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 或 [Slide](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/) 物件嗎？**

不建議在執行緒之間傳遞「即時」的簡報物件：請為每個執行緒使用獨立的實例，或事先為每個執行緒建立獨立的簡報或投影片容器。此做法符合一般不在執行緒間共享單一簡報實例的建議。

**如果每個執行緒都有自己的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例，平行匯出至不同格式（PDF、HTML、影像）是否安全？**

是的。只要使用獨立的實例並指定各自的輸出路徑，這類任務通常能正確平行化；請避免共享任何簡報物件或共享 I/O 串流。

**在多執行緒環境下，我該如何處理全域字型設定（資料夾、替代）？**

在啟動執行緒之前先初始化所有全域的 [font settings](/slides/zh-hant/python-java/powerpoint-fonts/)，且在平行工作期間不要更改它們。這可避免存取共享字型資源時的競爭狀況。