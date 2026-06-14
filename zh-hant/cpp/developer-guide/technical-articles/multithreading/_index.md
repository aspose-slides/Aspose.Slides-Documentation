---
title: Aspose.Slides for C++ 的多執行緒
linktitle: 多執行緒
type: docs
weight: 200
url: /zh-hant/cpp/multithreading/
keywords:
- 多執行緒
- 多執行緒
- 平行工作
- 轉換投影片
- 投影片轉影像
- PowerPoint
- OpenDocument
- 投影片
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 的多執行緒功能提升 PowerPoint 與 OpenDocument 的處理效能。探索有效投影片工作流程的最佳實踐。"
---
## **簡介**

雖然在多執行緒環境中可以對投影片進行平行工作（除了分析/載入/複製之外），且大多情況下都能正常運作，但在多執行緒使用此函式庫時仍有小機會產生錯誤的結果。

強烈建議您 **不要** 在多執行緒環境中使用單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 實例，因為這可能導致難以偵測的不可預期錯誤或失敗。

在多執行緒中載入、儲存和/或複製 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例並不安全，且此類操作 **不受支援**。如果需要執行此類任務，必須使用多個單執行緒的程序來平行處理，而每個程序都應使用各自的投影片實例。

## **在平行環境中將投影片轉換為影像**

假設我們想要在平行環境中將 PowerPoint 投影片全部轉換為 PNG 影像。由於在多執行緒中使用單一 `Presentation` 實例不安全，我們將投影片分割成多個獨立的投影片檔，然後在各自的執行緒中平行地將投影片轉換為影像。以下程式碼範例示範了如何執行此操作。

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // 將第 i 張投影片抽取為獨立的簡報。
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // 在獨立的任務中將投影片轉換為影像。
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// 等待所有任務完成。
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **常見問題**

**我需要在每個執行緒中呼叫授權設定嗎？**

不需要。只要在執行緒啟動前於每個程序/應用程式域執行一次即可。如果 [license setup](/slides/zh-hant/cpp/licensing/) 可能同時被呼叫（例如在延遲初始化期間），請同步此呼叫，因為授權設定方法本身不是執行緒安全的。

**我可以在執行緒之間傳遞 `Presentation` 或 `Slide` 物件嗎？**

不建議在執行緒之間傳遞「即時」的投影片物件：請為每個執行緒使用獨立的實例，或事先為每個執行緒建立各自的投影片/投影片容器。此做法符合一般不在執行緒間共享單一投影片實例的建議。

**只要每個執行緒都有自己的 `Presentation` 實例，平行匯出為不同格式（PDF、HTML、影像）是否安全？**

是的。只要使用獨立的實例並指定不同的輸出路徑，這類工作通常可以正確平行執行；請避免共享投影片物件或共享 I/O 串流。

**在多執行緒環境中，應如何處理全域字型設定（資料夾、替代字型）？**

請在啟動執行緒前初始化所有全域字型設定，並在平行作業期間不要變更它們。這可消除存取共享字型資源時的競爭情形。