---
title: 在 Aspose.Slides for Node.js via Java 中的多執行緒
linktitle: 多執行緒
type: docs
weight: 310
url: /zh-hant/nodejs-java/multithreading/
keywords:
- 多執行緒
- 多執行緒
- 平行工作
- 轉換投影片
- 投影片轉影像
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java 的多執行緒功能提升了 PowerPoint 與 OpenDocument 的處理效能。探索高效簡報工作流程的最佳實踐。"
---
## **簡介**

雖然在多執行緒環境下可以平行處理簡報（除了解析/載入/克隆之外）且大多數情況都能順利執行，但仍有小機會在多執行緒使用此函式庫時得到不正確的結果。

我們強烈建議您 **不要** 在多執行緒環境中使用單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 實例，因為這可能導致難以偵測的不可預期錯誤或失敗。

在多執行緒中載入、儲存和/或克隆 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例 **不是** 安全的，此類操作 **不受支援**。如果您必須執行此類任務，必須透過多個單執行緒的行程平行處理，且每個行程都應使用其自己的簡報實例。

## **並行將簡報投影片轉換為影像**

假設我們想要將 PowerPoint 簡報的所有投影片平行轉換為 PNG 影像。由於在多執行緒中使用單一的 `Presentation` 實例不安全，我們將投影片拆分為多個簡報，並在各自的執行緒中平行轉換為影像。以下程式碼示例說明了如何做到這一點。

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // 將投影片 i 提取為單獨的簡報。
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // 等待所有任務完成。
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **常見問題**

**我需要在每個執行緒中呼叫授權設定嗎？**

不需要。只需在執行緒啟動之前於每個程序/應用程式域執行一次即可。如果 [license setup](/slides/zh-hant/nodejs-java/licensing/) 可能同時被呼叫（例如在延遲初始化期間），請同步該呼叫，因為授權設定方法本身並非執行緒安全。

**我可以在執行緒之間傳遞 `Presentation` 或 `Slide` 物件嗎？**

不建議在執行緒之間傳遞「即時」的簡報物件：請為每個執行緒使用獨立的實例，或事先為每個執行緒建立獨立的簡報/投影片容器。此做法呼應一般建議，即不要在執行緒之間共享單一簡報實例。

**只要每個執行緒具有自己的 `Presentation` 實例，將匯出平行化為不同格式（PDF、HTML、影像）是否安全？**

是的。只要使用獨立的實例並指定不同的輸出路徑，此類工作通常能正確平行化；請避免共享簡報物件或共享 I/O 串流。

**在多執行緒環境下，我應該如何處理全域字型設定（資料夾、替代）？**

請在啟動執行緒前先初始化所有全域字型設定，且在平行工作期間不要更改它們。如此可避免存取共享字型資源時的競爭條件。