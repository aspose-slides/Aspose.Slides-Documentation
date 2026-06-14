---
title: 在 Aspose.Slides for PHP via Java 中的多執行緒
linktitle: 多執行緒
type: docs
weight: 310
url: /zh-hant/php-java/multithreading/
keywords:
- 多執行緒
- 多執行緒
- 平行工作
- 轉換投影片
- 投影片轉影像
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java 的多執行緒可提升 PowerPoint 與 OpenDocument 的處理效能。探索高效簡報工作流程的最佳實踐。"
---
## **簡介**

雖然在平行處理簡報（除了剖析/載入/複製）是可行的，且大多數情況下都能正常運作，但在多執行緒中使用此函式庫時，仍有小概率會得到不正確的結果。

我們強烈建議 **不要** 在多執行緒環境中使用單一的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 實例，因為它可能導致難以偵測的不可預期錯誤或失敗。

在多執行緒中載入、儲存和/或複製 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例 **不是** 安全的，此類操作 **不受支援**。如果需要執行此類工作，必須使用多個單執行緒程序來平行化操作，且每個程序都應使用各自的簡報實例。

在 PHP 中使用擴充功能時，我們不保證多執行緒的安全性。若使用，請自行承擔風險。

## **常見問題**

**我需要在每個執行緒中呼叫授權設定嗎？**

不需要。在執行緒啟動前於每個程序/應用程式域只需設定一次即可。如果 [license setup](/slides/zh-hant/php-java/licensing/) 可能同時被呼叫（例如在延遲初始化期間），請同步此呼叫，因為授權設定方法本身不是執行緒安全的。

**我可以在執行緒之間傳遞 `Presentation` 或 `Slide` 物件嗎？**

不建議在執行緒之間傳遞「即時」的簡報物件：請在每個執行緒使用獨立的實例，或事先為每個執行緒建立單獨的簡報/投影片容器。此做法遵循一般建議，即不要在執行緒間共享單一簡報實例。

**在每個執行緒都有自己的 `Presentation` 實例的前提下，將匯出平行化至不同格式（PDF、HTML、影像）是否安全？**

是的。只要使用獨立的實例與不同的輸出路徑，這類工作通常能正確平行化；請避免共享簡報物件或共享 I/O 串流。

**在多執行緒環境下該如何處理全域字型設定（資料夾、替代）？**

在啟動執行緒前先初始化所有全域 [font settings](/slides/zh-hant/php-java/powerpoint-fonts/)，且在平行工作期間不要更改它們。這可消除存取共享字型資源時的競爭情況。