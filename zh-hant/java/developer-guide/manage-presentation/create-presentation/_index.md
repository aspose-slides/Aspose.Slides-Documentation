---
title: 在 Java 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/java/create-presentation/
keywords:
- 建立簡報
- 新簡報
- 建立 PPT
- 新 PPT
- 建立 PPTX
- 新 PPTX
- 建立 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中建立簡報——產生 PPT、PPTX 與 ODP 檔案，受益於 OpenDocument 支援，並以程式方式儲存以獲得可靠的結果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中建立簡報、向投影片添加簡單內容，並將結果儲存為檔案。它還示範了如何建立並儲存新簡報、開啟支援格式的現有簡報，並將其另存為其他格式。此外，本文還包括一個簡短的 FAQ，涵蓋有關格式、範本、投影片尺寸、單位、記憶體使用、執行緒、授權、數位簽章和 VBA 支援的常見問題。

## **建立簡報**

在 Aspose.Slides for Java 中從頭建立 PowerPoint 檔案，就像實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別一樣直接。建構式會自動提供一個只有單一投影片的空白簡報，讓您立即擁有可放置圖形、文字、圖表或任何其他應用程式所需內容的畫布。當您修改該投影片──或加入新投影片──後，即可將結果保存為 PPTX、舊版 PPT，甚至 OpenDocument 格式。下面的簡短程式碼範例示篕了透過在第一張投影片上加入簡單圖形的工作流程。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 使用 `Shapes` 集合提供的 `addAutoShape` 方法，加入一個 `Cloud` 類型的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 物件。  
4. 向自動圖形加入文字。  
5. 將修改後的簡報儲存為 PPTX 檔案。

在下方範例中，將雲狀圖形加入簡報的第一張投影片。

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增類型為 Cloud 的自動圖形。
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The new presentation](new_presentation.png)

## **常見問題**

**我可以將新簡報儲存為哪些格式？**  
您可以儲存為 [PPTX, PPT, and ODP](/slides/zh-hant/java/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/java/convert-powerpoint-to-png/)、以及 [images](/slides/zh-hant/java/convert-powerpoint-to-png/)，等等。

**我可以從範本 (POTX/POTM) 開始，然後儲存為一般的 PPTX 嗎？**  
可以。載入範本後儲存為欲用的格式；POTX/POTM/PPTM 等相似格式 [are supported](/slides/zh-hant/java/supported-file-formats/)。

**在建立簡報時，我如何控制投影片大小/長寬比？**  
設定 [slide size](/slides/zh-hant/java/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**尺寸和座標以什麼單位衡量？**  
以點 (point) 為單位：1 吋等於 72 個單位。

**我如何處理包含大量媒體檔案的超大簡報，以降低記憶體使用量？**  
使用 [BLOB management strategies](/slides/zh-hant/java/manage-blob/)，透過暫存檔限制記憶體內儲存，並優先採用基於檔案的工作流程，而非完全使用記憶體串流。

**我可以平行建立/儲存簡報嗎？**  
您無法在 [multiple threads](/slides/zh-hant/java/multithreading/) 中操作同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 實例。請在每個執行緒或行程中執行獨立的實例。

**我該如何移除試用版浮水印與限制？**  
[Apply a license](/slides/zh-hant/java/licensing/) 每個行程執行一次。授權 XML 必須保持未修改，若有多執行緒，授權設定亦需同步化。

**我可以為我建立的 PPTX 加上數位簽章嗎？**  
可以。[Digital signatures](/slides/zh-hant/java/digital-signature-in-powerpoint/)（新增與驗證）在簡報中受到支援。

**在建立的簡報中是否支援巨集 (VBA)？**  
可以。您可以 [create/edit VBA projects](/slides/zh-hant/java/presentation-via-vba/) 並將檔案儲存為支援巨集的格式，如 PPTM/PPSM。