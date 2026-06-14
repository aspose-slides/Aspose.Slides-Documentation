---
title: 多執行緒於 Aspose.Slides for Python
linktitle: 多執行緒
type: docs
weight: 200
url: /zh-hant/python-net/multithreading/
keywords:
- 多執行緒
- 多個執行緒
- 平行工作
- 轉換投影片
- 投影片轉圖像
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "透過 .NET 多執行緒，Aspose.Slides for Python 可提升 PowerPoint 與 OpenDocument 的處理效能。探索高效簡報工作流程的最佳實踐。"
---
## **簡介**

儘管可以對投影片執行平行工作（除了解析/載入/複製之外），且大多數情況下一切順利，但在多執行緒使用此函式庫時仍有小概率會得到不正確的結果。

我們強烈建議 **不要** 在多執行緒環境中使用單一的 Presentation 實例，因為這可能導致難以偵測的不可預測錯誤或失敗。

在多執行緒中載入、儲存和/或複製 Presentation 類別的實例 **不是** 安全的，此類操作 **不受支援**。如果您需要執行此類任務，必須使用多個單執行緒程序來平行化操作——且每個程序都應使用自己的 presentation 實例。

## **平行將投影片轉換為圖像**

假設我們想要將 PowerPoint 投影片全部平行轉換為 PNG 圖像。由於在多執行緒中使用單一 `Presentation` 實例並不安全，我們將投影片分割成多個獨立的 presentation，並在各自的執行緒中平行將投影片轉換為圖像。以下程式碼範例展示了如何實作。

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # 將投影片 i 抽取至單獨的簡報中。
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # 將投影片轉換為圖像。
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# 等待所有任務完成。
for task in conversion_tasks:
    task.result()

del presentation
```

## **常見問題**

**我需要在每個執行緒中呼叫授權設定嗎？**

不需要。只要在執行緒啟動前於每個程序/應用程式域執行一次即可。如果 [license setup](/slides/zh-hant/python-net/licensing/) 可能同時被呼叫（例如在延遲初始化期間），請同步該呼叫，因為授權設定方法本身並非執行緒安全的。

**我可以在執行緒之間傳遞 `Presentation` 或 `Slide` 物件嗎？**

不建議在執行緒之間傳遞「活躍」的 presentation 物件：請於每個執行緒使用獨立的實例，或事先為每個執行緒建立不同的 presentation/slide 容器。此做法符合一般不在執行緒間共享單一 presentation 實例的建議。

**只要每個執行緒都有自己的 `Presentation` 實例，平行匯出至不同格式（PDF、HTML、圖像）是否安全？**

是的。只要使用獨立的實例與各自的輸出路徑，此類任務通常能正確平行化；請避免共享任何 presentation 物件或 I/O 串流。

**在多執行緒環境下，該怎麼處理全域字型設定（資料夾、替代）？**

在啟動執行緒之前先初始化所有全域字型設定，且在平行工作期間不要更改它們。如此即可避免存取共享字型資源時的競爭情況。