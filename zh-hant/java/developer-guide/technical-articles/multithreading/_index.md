---
title: Aspose.Slides for Java 中的多執行緒
linktitle: 多執行緒
type: docs
weight: 310
url: /zh-hant/java/multithreading/
keywords:
- 多執行緒
- 多執行緒
- 平行工作
- 轉換投影片
- 投影片轉圖像
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 的多執行緒功能提升 PowerPoint 與 OpenDocument 處理效能。探索高效簡報工作流程的最佳實踐。"
---
## **簡介**

儘管可以對簡報進行平行處理（除了剖析/載入/克隆之外），且大多數情況下運作良好，但在多執行緒使用此函式庫時，仍有小概率會得到不正確的結果。

我們強烈建議您 **不要** 在多執行緒環境中使用單一 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 實例，因為這可能導致難以偵測的不可預期錯誤或失敗。

在多執行緒中載入、儲存和/或克隆 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例 **不是** 安全的，此類操作 **不受支援**。如果需要執行此類工作，必須使用多個單執行緒程序來平行化操作——每個程序都應使用其自己的簡報實例。

## **並行將簡報投影片轉換為圖像**

假設我們想要將 PowerPoint 簡報的所有投影片平行轉換為 PNG 圖像。由於在多執行緒中使用單一 `Presentation` 實例不安全，我們將投影片分割成多個簡報，並在各自的執行緒中平行將投影片轉換為圖像。以下程式碼範例示範了如何實作。

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // 將投影片 i 提取到單獨的簡報中。
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // 在單獨的工作中將投影片轉換為圖像。
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// 等待所有工作完成.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **常見問題**

**我需要在每個執行緒中呼叫授權設定嗎？**

不需要。只要在執行緒啟動前於每個程序/應用程式域執行一次即可。如果 [license setup](/slides/zh-hant/java/licensing/) 可能會同時被呼叫（例如在延遲初始化期間），請同步化該呼叫，因為授權設定方法本身不是執行緒安全的。

**我可以在執行緒之間傳遞 `Presentation` 或 `Slide` 物件嗎？**

不建議在執行緒之間傳遞「活躍」的簡報物件：請在每個執行緒使用獨立的實例，或事先為每個執行緒建立不同的簡報/投影片容器。此做法遵循一般建議，即不要在執行緒間共享單一簡報實例。

**只要每個執行緒都有自己的 `Presentation` 實例，將匯出平行化為不同格式（PDF、HTML、圖像）是否安全？**

是的。只要使用獨立的實例與各自的輸出路徑，此類任務通常可以正確平行化；請避免共享簡報物件與共享 I/O 串流。

**在多執行緒環境中，該如何處理全域字型設定（資料夾、替代）？**

在啟動執行緒前先初始化所有全域 [font settings](/slides/zh-hant/java/powerpoint-fonts/)，且在平行作業期間不要更改它們。這可避免存取共享字型資源時的競爭條件。