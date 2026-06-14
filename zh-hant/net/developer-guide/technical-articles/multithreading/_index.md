---
title: 在 Aspose.Slides for .NET 中的多執行緒
linktitle: 多執行緒
type: docs
weight: 310
url: /zh-hant/net/multithreading/
keywords:
- 多執行緒
- 多個執行緒
- 平行工作
- 轉換投影片
- 投影片轉影像
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 多執行緒可提升 PowerPoint 與 OpenDocument 的處理效能。探索有效簡報工作流程的最佳實踐。"
---
## **簡介**

儘管在簡報上進行平行工作是可行的（除了解析/載入/複製之外），且大多數情況下運作正常，但在多執行緒使用此函式庫時仍有小概率會得到不正確的結果。

我們強烈建議您 **不要** 在多執行緒環境中使用單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 實例，因為這可能導致難以偵測的不可預期錯誤或失敗。 

在多執行緒中載入、儲存和/或複製 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例 **不是** 安全的，此類操作 **不受支援**。如果需要執行這類任務，必須透過多個單執行緒的程序來平行化操作——每個程序都應使用各自的簡報實例。 

## **將簡報投影片平行轉換為影像**

讓我們假設要將 PowerPoint 簡報的所有投影片平行轉換為 PNG 影像。由於在多執行緒中使用單一 `Presentation` 實例是不安全的，我們將簡報投影片拆分成多個獨立的簡報，並在不同執行緒中各自使用一個簡報進行平行轉換。以下程式碼範例示範如何做到這一點。

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // 提取第 i 張投影片成為單獨的簡報。
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // 在單獨的任務中將投影片轉換為影像。
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **常見問題**

**我需要在每個執行緒中呼叫授權設定嗎？**

不需要。只要在執行緒啟動之前於每個程序/應用程式域執行一次即可。如果 [license setup](/slides/zh-hant/net/licensing/) 可能同時被呼叫（例如在延遲初始化時），請同步此呼叫，因為授權設定方法本身不是執行緒安全的。

**我可以在執行緒之間傳遞 `Presentation` 或 `Slide` 物件嗎？**

不建議在執行緒之間傳遞「活躍」的簡報物件：請於每個執行緒使用獨立的實例，或事先為每個執行緒建立不同的簡報/投影片容器。此做法遵循一般建議，即不要在多執行緒間共用單一簡報實例。

**只要每個執行緒都有自己的 `Presentation` 實例，將匯出平行化為不同格式（PDF、HTML、影像）是否安全？**

是的。只要使用獨立的實例與各自的輸出路徑，此類工作通常能正確平行化；請避免共用任何簡報物件或共用 I/O 串流。

**在多執行緒環境下，全球字型設定（資料夾、替代字型）該如何處理？**

請在啟動執行緒之前初始化所有全域字型設定，且在平行作業期間不要更改它們。這樣可避免存取共享字型資源時的競爭問題。