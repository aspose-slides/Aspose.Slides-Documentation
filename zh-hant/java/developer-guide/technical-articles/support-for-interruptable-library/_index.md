---
title: 可中斷函式庫支援
type: docs
weight: 120
url: /zh-hant/java/support-for-interruptable-library/
keywords:
- 可中斷函式庫
- 中斷令牌
- 取消令牌
- 長時間執行的任務
- 中斷任務
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 使長時間執行的任務可取消。安全地中斷 PowerPoint 與 OpenDocument 的算繪和轉換，並提供範例。"
---
## **概觀**

Aspose.Slides 提供可中斷的處理機制，用於長時間執行的簡報任務，例如反序列化、序列化和算繪。此機制基於 `InterruptionToken` 與 `InterruptionTokenSource` 類別。

`InterruptionToken` 可指派給 `LoadOptions`，並傳遞至 `Presentation` 建構式。當呼叫 `InterruptionTokenSource.interrupt()` 時，相關的長時間任務將被中斷。

## **可中斷函式庫**

在 [Aspose.Slides 18.4](https://releases.aspose.com/slides/zh-hant/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) 中，我們引入了 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontokensource/) 類別。它們允許您中斷長時間執行的任務，例如反序列化、序列化和算繪。

- [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontokensource/) 是傳遞給 [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) 的 token（或 tokens）的來源。
- 當設定了 [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) 且將 [LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/) 實例傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 建構式時，呼叫 [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontokensource/#interrupt--) 會中斷與該 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 相關的任何長時間任務。

下列程式碼片段示範了如何中斷執行中的任務：

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // 在單獨的執行緒中執行動作
Thread.sleep(10000);     // 逾時
tokenSource.interrupt(); // 停止轉換
```

## **常見問題**

**Aspose.Slides 中斷函式庫的目的為何？**

它提供了一種機制，可在長時間操作（例如載入、儲存或算繪簡報）完成之前中斷它們。當必須限制處理時間或任務已不再需要時，此功能相當有用。

**[InterruptionToken](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontoken/) 與 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontokensource/) 有何不同？**

- `InterruptionToken` 會傳遞給 Aspose.Slides API，並在長時間操作期間被檢查。
- `InterruptionTokenSource` 用於您的程式碼中以建立 token，並透過呼叫 `Interrupt()` 觸發中斷。

**哪些任務可以被中斷？**

任何接受 [InterruptionToken](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontoken/) 的 Aspose.Slides 任務——例如使用 `Presentation(path, loadOptions)` 載入簡報或使用 `Presentation.save(...)` 儲存——都可以被中斷。

**中斷會立即發生嗎？**

不會。中斷是合作式的：操作會定期檢查 token，並在偵測到已呼叫 [Interrupt()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontokensource/#interrupt--) 時立即停止。

**如果在任務已完成後呼叫 [Interrupt()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontokensource/#interrupt--) 會發生什麼情況？**

不會有任何作用——如果相對的任務已完成，呼叫將不會產生影響。

**我可以在多個任務中重複使用相同的 [InterruptionTokenSource](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontokensource/) 嗎？**

可以——但在對該來源呼叫 [Interrupt()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/interruptiontokensource/#interrupt--) 後，所有使用其 token 的任務都會被中斷。請使用不同的 token 來源以獨立管理任務。