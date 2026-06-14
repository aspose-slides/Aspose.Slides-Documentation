---
title: 在 Aspose.Slides for Android via Java 中的多執行緒
linktitle: 多執行緒
type: docs
weight: 310
url: /zh-hant/androidjava/multithreading/
keywords:
- 多執行緒
- 多執行緒
- 平行工作
- 轉換投影片
- 投影片轉圖片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java 的多執行緒可提升 PowerPoint 和 OpenDocument 處理效能。探索高效簡報工作流程的最佳實踐。"
---
## **Introduction**

雖然可以對簡報執行平行作業（除了解析/載入/克隆之外），且大多數情況下都能順利完成，但在多執行緒環境中使用此函式庫時，仍有小機率會得到不正確的結果。

我們強烈建議您 **不要** 在多執行緒環境中使用單一 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 實例，因為這可能導致不可預測的錯誤或失敗，且不易偵測。

在多執行緒中 **不** 安全載入、儲存和/或克隆 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。此類操作 **不** 被支援。如果需要執行此類工作，必須使用多個單執行緒程序來平行處理，且每個程序都應使用各自的簡報實例。

## **Convert Presentation Slides to Images in Parallel**

假設我們想要平行將 PowerPoint 簡報的所有投影片轉換為 PNG 圖片。由於在多執行緒中使用單一 `Presentation` 實例並不安全，我們會將簡報投影片拆分為多個獨立的簡報，並在各自的執行緒中平行轉換投影片為圖片。以下程式碼範例展示了如何實作。

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// 提取投影片 i 為單獨的簡報。
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// 在單獨的任務中將投影片轉換為影像。
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
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
		}
	}));
}

// 等待所有任務完成。
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **FAQ**

**Do I need to call license setup in every thread?**

不需要。只要在執行緒啟動前於每個 process/app domain 執行一次即可。如果 [license setup](/slides/zh-hant/androidjava/licensing/) 可能同時被呼叫（例如在延遲初始化期間），請對該呼叫加上同步，因為授權設定方法本身並非 thread‑safe。

**Can I pass `Presentation` or `Slide` objects between threads?**

不建議在執行緒之間傳遞「即時」的簡報物件：請為每個執行緒使用獨立的實例，或事先為每個執行緒建立獨立的簡報/投影片容器。此做法遵循一般建議，即不要在多執行緒間共享單一簡報實例。

**Is it safe to parallelize export to different formats (PDF, HTML, images) provided each thread has its own `Presentation` instance?**

是的。只要使用獨立的實例並指定各自的輸出路徑，這類任務通常能正確平行化；請避免共享任何簡報物件或共享 I/O 串流。

**What should I do with global font settings (folders, substitutions) in multithreading?**

在啟動執行緒前，先初始化所有全域 [font settings](/slides/zh-hant/androidjava/powerpoint-fonts/)，且在平行工作期間不要變更它們。這可避免存取共享字型資源時的競爭情況。